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
    public partial class frmDetainLicense : Form
    {
        clsLicense _License;
        clsDetainedLicense _DetainedLicense;
        public frmDetainLicense()
        {
            InitializeComponent();
            ctrlShowDrivingLicenseInfoWithFilter1.OnLicenseFound += ctrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound;
        }

        private void ctrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound(int LicenseID)
        {
            LlShowLicense.Enabled = false;

            _License = clsLicense.Find(LicenseID);

            lblLicenseID.Text = LicenseID.ToString();

            if (_License != null)
            {
                LlShowLicenseshistory.Enabled = true;

                if (!_License.IsLiceneseDetained)
                {
                    btnDetain.Enabled = true;

                    mtbFineFees.Enabled = true;
                    LlShowLicense.Enabled = false;
                    lblDetainID.Text = "[???]";
                    lblLicenseID.Text = "[???]";
                    mtbFineFees.Text = "";

                }
                else
                {
                    btnDetain.Enabled = false;
                    _DetainedLicense = clsDetainedLicense.Find(LicenseID);
                    lblDetainID.Text = _DetainedLicense.ID.ToString();
                    mtbFineFees.Text = Convert.ToSingle( _DetainedLicense.FineFees).ToString();

                    mtbFineFees.Enabled = false;
                    LlShowLicense.Enabled = true;
                    MessageBox.Show("Selected license is already detained choose another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                btnDetain.Enabled = false;

                LlShowLicenseshistory.Enabled = false;
                lblDetainID.Text = "[???]";
                lblLicenseID.Text = "[???]";
                mtbFineFees.Text = "";
            }

        }

        void _DetainLicense()
        {
            _DetainedLicense = new clsDetainedLicense();

            _DetainedLicense.LicenseID = _License.ID;        
            _DetainedLicense.IsReleased = false;
            _DetainedLicense.FineFees = Convert.ToSingle(mtbFineFees.Text);
            _DetainedLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _DetainedLicense.DetainDate = DateTime.Now;

            if (_DetainedLicense.Save())
            {
                lblDetainID.Text = _DetainedLicense.ID.ToString();
                mtbFineFees.Text = "";
                btnDetain.Enabled = false;
                MessageBox.Show("License detained successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlShowLicense.Enabled = true;
            }
            else
            {
                MessageBox.Show("Some thing went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDetainID.Text = "[???]";

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _LoadData()
        {
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
           

        }


        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtbFineFees.Text))
            {
                MessageBox.Show("Enter fine fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _DetainLicense();
            }

        }

        private void btnShowLicenseshistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_License != null)
            {

                frmShowLicsenseHistory frm = new frmShowLicsenseHistory(_License.ApplicationID);
                frm.ShowDialog();
            }

        }

        private void LlShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_License != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(_License.ApplicationID);
                frm.ShowDialog();
            }
        }
    }
}
