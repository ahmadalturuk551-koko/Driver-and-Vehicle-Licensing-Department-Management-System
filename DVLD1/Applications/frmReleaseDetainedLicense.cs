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
using System.Timers;
using System.Windows.Forms;

namespace DVLD1.Applications
{
    public partial class frmReleaseDetainedLicense : Form
    {
        clsApplication _Application;
        clsLicense _License;
        clsDetainedLicense _DetainedLicense;
        clsApplicationType _ApplicationType;
        float TotalPaid;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            ctrlShowDrivingLicenseInfoWithFilter1.OnLicenseFound += ctrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound;
            _ApplicationType = clsApplicationType.Find(5);
        }

        void ctrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound(int LicenseID)
        {
            _License = clsLicense.Find(LicenseID);

            if(_License != null)
            {
                LlblShowLicenseHistory.Enabled = true;

                if(!_License.IsLiceneseDetained)
                {
                    _ResetForm();
                    lblLicenseID.Text = _License.ID.ToString();
                    MessageBox.Show("Selected license is not detained please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LlblshowLicense.Enabled = true;
                    LlblShowLicenseHistory.Enabled = true;
                }
                else
                {
                    LlblshowLicense.Enabled = false;
                    LlblShowLicenseHistory.Enabled = true;
                    _DetainedLicense = clsDetainedLicense.Find(LicenseID);
                    _FillInData();
                }
            }
            else
            {
                _ResetForm();
            }
        }

        void _FillInData()
        {
            lblApplicationFees.Text = _ApplicationType.Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();
            lblDetainID.Text = _DetainedLicense.ID.ToString();
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblLicenseID.Text = _License.ID.ToString();
            TotalPaid = _ApplicationType.Fees + _DetainedLicense.FineFees;
            lblTotalFees.Text = (TotalPaid).ToString();
            LlblShowLicenseHistory.Enabled = true;
            btnRelease.Enabled = true;
        }

        void _ResetForm()
        {
            btnRelease.Enabled = false;
            LlblShowLicenseHistory.Enabled = false;
            LlblshowLicense.Enabled = false;
            lblApplicationFees.Text = "[???]";
            lblCreatedBy.Text = "[???]";
            lblDetainDate.Text = "[???]";
            lblDetainID.Text = "[???]";
            lblFineFees.Text = "[???]";
            lblLicenseID.Text = "[???]";
            TotalPaid = 0;
            lblTotalFees.Text = "[???]";
            lblrReleaseID.Text = "[???]";
        }

        int CreateApplication()
        {
            _Application = new clsApplication();
            _Application.ApplicantPersonID = _License.Driver.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = _ApplicationType.ID;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = TotalPaid;
            _Application.Save();

            return _Application.ApplicationID;

        }

        void _ReleaseLicense()
        {
            int ReleaseApplicationID = CreateApplication();
            if (ReleaseApplicationID != -1)
            {
                _DetainedLicense.IsReleased = true;
                _DetainedLicense.ReleaseDate = DateTime.Now;
                _DetainedLicense.ReleasedByUserID = clsGlobal.CurrentUser.UserID;
                _DetainedLicense.ReleaseApplicationID = ReleaseApplicationID;

                if (_DetainedLicense.Save())
                {
                    btnRelease.Enabled = false;
                    LlblshowLicense.Enabled = true;
                    lblrReleaseID.Text = ReleaseApplicationID.ToString();
                    MessageBox.Show("License released successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Some thing went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Koko1");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlblshowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_License != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(_License.ApplicationID);
                frm.ShowDialog();

            }
        }

        private void LlblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_License != null)
            {
                frmShowLicsenseHistory frm = new frmShowLicsenseHistory(_License.ApplicationID);
                frm.ShowDialog();

            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            _ReleaseLicense();
        }
    }
}
