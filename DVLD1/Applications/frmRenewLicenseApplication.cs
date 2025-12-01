using DataBusinessLayer;
using DVLD1.GlobalClasses;
using DVLD1.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.Applications
{
    public partial class frmRenewLicenseApplication : Form
    {
        clsLicense _OldLicense;
        clsLicense _NewLicense;
        clsApplication _Application;
        float _TotalFees;
        int _RenewApplicationID;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
            ctrlShowDrivingLicenseInfoWithFilter1.OnLicenseFound += CtrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CtrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound(int LicenseID)
        {
            _OldLicense = clsLicense.Find(LicenseID);

            if( _OldLicense == null ) 
            {
                _ResetForm();
             

            }
            else
            {
                LlShowLicensesHistory.Enabled = true;

                _FillInData();
                _CheckExpirationDate();
            }
            
        }

        void _CheckExpirationDate()
        {
            if (!_OldLicense.IsExpired())
            {
                MessageBox.Show("Selected License is active,it will expire on: " + _OldLicense.ExpirationDate.ToShortDateString(), "License is active", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnRenew.Enabled = false;
            }
            else
            {
                btnRenew.Enabled = true;
             

            }
        }

        void _LoadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.Find(2).Fees.ToString(); 
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        void _FillInData()
        {
            lblOldLicenseID.Text = _OldLicense.ID.ToString();
            lblLicenseFees.Text = _OldLicense.PaidFees.ToString();
            lblTotalFees.Text = _SetTotalFees().ToString();
            lblExpirationDate.Text = _OldLicense.ExpirationDate.ToShortDateString();
            
        }

        float _SetTotalFees()
        {
            return _TotalFees = (clsApplicationType.Find(2).Fees + _OldLicense.PaidFees);
        }

        void _ResetForm()
        {          
            lblLicenseFees.Text = "[???]";
            lblOldLicenseID.Text = "[???]";
            lblRenewedLiceneID.Text = "[???]";
            lblRLApplicationId.Text = "[???]";
            lblTotalFees.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            LlShowLicensesHistory.Enabled = false;
            LlShowNewLicenseInfo.Enabled = false;
            
        }

        int AddRenewApplicaton()
        {
            _Application = new clsApplication();
            _Application.ApplicantPersonID = _OldLicense.Driver.PersonID;
            _Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _Application.ApplicationDate = DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            _Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
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
            _NewLicense.ApplicationID = _RenewApplicationID;
            _NewLicense.DriverID = _OldLicense.DriverID;
            _NewLicense.Notes = rtbNotes.Text;
            _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _NewLicense.IsActive = true;
            _NewLicense.IssueDate = DateTime.Now;
            _NewLicense.ExpirationDate = _NewLicense.IssueDate.AddYears(10);
            _NewLicense.LicenseClassID = _OldLicense.LicenseClassID;
            _NewLicense.IssueReason = 2;
            _NewLicense.PaidFees = _TotalFees;
            if(_NewLicense.Save())
            {
                return _NewLicense.ID;
            }
            else
            {
                return -1;
            }

        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void LlShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicense.ApplicationID);
            frm.ShowDialog();

        }

        private void LlShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicsenseHistory frm = new frmShowLicsenseHistory(_OldLicense.ApplicationID);
            frm.ShowDialog();
        }

        void _DeActiveOldLicense()
        {
            _OldLicense.IsActive = false;
            _OldLicense.Save();
            
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {

            _RenewApplicationID = AddRenewApplicaton();

            if (_RenewApplicationID != -1)
            {
                _DeActiveOldLicense();

                if(IssueNewLicense() != -1)
                {
                    MessageBox.Show("License Renewed Successfully with ID = " + _NewLicense.ID.ToString(), "Success");
                    ctrlShowDrivingLicenseInfoWithFilter1.LoadData();
                    btnRenew.Enabled = false;
                    LlShowNewLicenseInfo.Enabled = true;
                    lblRenewedLiceneID.Text = _NewLicense.ID.ToString();
                    lblRLApplicationId.Text = _RenewApplicationID.ToString();
                }
                else
                {
                    MessageBox.Show("Koko1");

                    btnRenew.Enabled = true;
                    LlShowNewLicenseInfo.Enabled = false;
                }
            }
            else
            {
                    MessageBox.Show("Koko2");

            }


        }
    }
}
