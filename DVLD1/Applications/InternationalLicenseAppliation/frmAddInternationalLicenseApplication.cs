using DataBusinessLayer;
using DVLD1.GlobalClasses;
using DVLD1.License;
using DVLD1.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.Applications.InternationalLicenseAppliation
{
    public partial class frmAddInternationalLicenseApplication : Form
    {
        clsLicense _License;


        int _SelectedLicenseID;
        int _InternationalLicenseID;
        public frmAddInternationalLicenseApplication()
        {
            InitializeComponent();
            ctrlShowDrivingLicenseInfoWithFilter1.OnLicenseFound += CtrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound;
        }

        private void frmAddInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _ResetForm()
        {
            LlblShowLicensesHistory.Enabled = false;
            LlShowLicenseInfo.Enabled = false;
            btnIssue.Enabled = false;
        }

        private void CtrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound(int LicenseID)
        {

            _SelectedLicenseID = LicenseID;
            if (_SelectedLicenseID == -1)

            {
                _ResetForm();
                return;

            }
            _License = clsLicense.Find(LicenseID);
            LlblShowLicensesHistory.Enabled = true;

            //check the InternationaLicense class, person could not issue international InternationaLicense without having
            //normal InternationaLicense of class 3.

            if (ctrlShowDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if person already have an active international InternationaLicense
            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlShowDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                clsInternationalLicense InternationaLicense = clsInternationalLicense.Find(ActiveInternaionalLicenseID);
                MessageBox.Show("Person already have an active international InternationaLicense with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LlShowLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssue.Enabled = false;

                lblILApplicationID.Text = InternationaLicense.ApplicationID.ToString();
                _InternationalLicenseID = InternationaLicense.InternationalLicenseID;
                lblILicenseID.Text = InternationaLicense.InternationalLicenseID.ToString();
                lblLocalLicenseID.Text = InternationaLicense.IssuedUsingLocalLicenseID.ToString();
                return;
            }

            btnIssue.Enabled = true;

        }

        void _LoadData()
        {
            lblAplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblAplicationDate.Text;
            lblExiprationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;


        }

        void _FillData()
        {
            if (MessageBox.Show("Are you sure you want to issue the InternationaLicense?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicantPersonID = ctrlShowDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            InternationalLicense.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            InternationalLicense.DriverID = ctrlShowDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlShowDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.ID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblILApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblILicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = false;
           

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _FillData();
        }

        private void LlblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicsenseHistory frm = new frmShowLicsenseHistory(_License.ApplicationID);
            frm.ShowDialog();
        }

        private void LlShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
