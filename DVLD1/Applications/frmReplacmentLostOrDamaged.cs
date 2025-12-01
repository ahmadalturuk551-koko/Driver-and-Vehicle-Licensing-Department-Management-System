using DataBusinessLayer;
using DVLD1.GlobalClasses;
using DVLD1.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.Applications
{
    public partial class frmReplacementForDamagedOrLostLicenses : Form
    {
        clsLicense _OldLicense;
        clsLicense _NewLicense;
        clsApplication _Application;
        float _TotalFees;
        int _ReplacmentApplicationID;
        enum enApplicationType { ReplacmentForLost = 1, ReplacmentForDamaged = 2 };
        enApplicationType _ApplicationType;

        public frmReplacementForDamagedOrLostLicenses()
        {
            InitializeComponent();
            ctrlShowDrivingLicenseInfoWithFilter1.OnLicenseFound += ctrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReplacementForDamagedOrLostLicenses_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ctrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound(int obj)
        {
            int LicenseID = obj;
            _OldLicense = clsLicense.Find(LicenseID);

            if (_OldLicense == null)
            {
                _ResetForm();


            }
            else
            {
                LlShowLicensesHistory.Enabled = true;

                _FillInData();
                _CheckIsActive();
            }
        }

        void _CheckIsActive()
        {
            if(_OldLicense.IsActive)
            {
                MessageBox.Show("Selected License is active select another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssueReplacment.Enabled = false;
            }
            else
            {
                btnIssueReplacment.Enabled = true;
            }
        }

        void _LoadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.Find(2).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            rbDamagedLicense.Checked = true;

            _SetApplicationType();
        }

        void _SetApplicationType()
        {
            if (rbDamagedLicense.Checked)
            {
                _ApplicationType = enApplicationType.ReplacmentForDamaged;
            }
            else
            {
                _ApplicationType = enApplicationType.ReplacmentForLost;
            }
        }

        void _FillInData()
        {
            lblOldLicenseID.Text = _OldLicense.ID.ToString();

           

        }

        void _SetFeesLabel()
        {
            if (_ApplicationType == enApplicationType.ReplacmentForLost)
            {

                lblApplicationFees.Text = clsApplicationType.Find(3).Fees.ToString();
            }
            else
            {
                lblApplicationFees.Text = clsApplicationType.Find(4).Fees.ToString();

            }
        }

        void _ResetForm()
        {
            lblOldLicenseID.Text = "[???]";
            lblApplicationFees.Text = "[???]";
            lblReplacedLicenseID.Text = "[???]";
            lblLRApplicationID.Text = "[???]";
            LlShowLicensesHistory.Enabled = false;
            LlShowLicensesInfo.Enabled = false;
            btnIssueReplacment.Enabled = false;
        }

        int AddNewApplicaton()
        {
            _Application = new clsApplication();
            _Application.ApplicantPersonID = _OldLicense.Driver.PersonID;
            _Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _Application.ApplicationDate = DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            if (_ApplicationType == enApplicationType.ReplacmentForLost)
            {

                _Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            }
            else
            {
                _Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;

            }
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Application.PaidFees = _TotalFees;

            if (_Application.Save())
            {

                return _Application.ApplicationID;
            }
            else
                return -1;
        }

        int IssueNewLicense()
        {
            _NewLicense = new clsLicense();
            _NewLicense.ApplicationID = _ReplacmentApplicationID;
            _NewLicense.DriverID = _OldLicense.DriverID;
            _NewLicense.Notes = "";
            _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _NewLicense.IsActive = true;
            _NewLicense.IssueDate = DateTime.Now;
            _NewLicense.ExpirationDate = _NewLicense.IssueDate.AddYears(10);
            _NewLicense.LicenseClassID = _OldLicense.LicenseClassID;
            _NewLicense.IssueReason = 2;
            _NewLicense.PaidFees = _TotalFees;
            if (_NewLicense.Save())
            {
                return _NewLicense.ID;
            }
            else
            {
                return -1;
            }

        }

        private void LlShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicsenseHistory frm = new frmShowLicsenseHistory(_OldLicense.ApplicationID);
            frm.ShowDialog();
        }

       
        private void btnIssueReplacment_Click(object sender, EventArgs e)
        {

            _ReplacmentApplicationID = AddNewApplicaton();

            if (_ReplacmentApplicationID != -1)
            {
           

                if (IssueNewLicense() != -1)
                {
                    MessageBox.Show("License Replaced Successfully with ID = " + _NewLicense.ID.ToString(), "Success");
                    ctrlShowDrivingLicenseInfoWithFilter1.LoadData();
                    btnIssueReplacment.Enabled = false;
                    LlShowLicensesInfo.Enabled = true;
                    lblReplacedLicenseID.Text = _NewLicense.ID.ToString();
                    lblLRApplicationID.Text = _ReplacmentApplicationID.ToString();
                }
                else
                {
                    MessageBox.Show("Koko1");

                    btnIssueReplacment.Enabled = true;
                    LlShowLicensesInfo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Koko2");

            }

        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _SetApplicationType();
            _SetFeesLabel();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _SetApplicationType();
            _SetFeesLabel();
        }

        private void LlShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicense.ApplicationID);
            frm.ShowDialog();
        }


    }
    
}
