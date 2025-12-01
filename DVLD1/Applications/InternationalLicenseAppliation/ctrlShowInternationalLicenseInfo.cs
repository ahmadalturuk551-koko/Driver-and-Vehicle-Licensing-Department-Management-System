using DataBusinessLayer;
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
    public partial class ctrlShowInternationalLicenseInfo : UserControl
    {
        public clsInternationalLicense internationalLicens;
        public ctrlShowInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void ctrlShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        public bool LoadData(int InternationalLicenseID)
        {
            internationalLicens = clsInternationalLicense.Find(InternationalLicenseID);

            if(internationalLicens != null)
            {
                _FillInData();
                return true;
            }
            else
            {
                _ResetForm();
                return false;
            }

        }

        void _FillInData()
        {
            lblApplicationID.Text = internationalLicens.ApplicationID.ToString();
            lblDateOfBirth.Text = internationalLicens.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = internationalLicens.DriverID.ToString();
            lblExpirationDate.Text = internationalLicens.ExpirationDate.ToShortDateString();
            lblFullName.Text = internationalLicens.DriverInfo.PersonInfo.FullName;
            lblGendor.Text = internationalLicens.DriverInfo.PersonInfo.GenforTxt;

            if(lblGendor.Text == "Male")
            {
                pbGendor.Image = Properties.Resources.Man_32;
            }
            else
            {
                pbGendor.Image = Properties.Resources.Woman_32;

            }

            lblInternationalLicenseID.Text = internationalLicens.InternationalLicenseID.ToString();
            lblIsActive.Text = internationalLicens.IsActiveTxt;
            lblIssueDate.Text = internationalLicens.IssueDate.ToShortDateString();
            lblLocalLicenseID.Text = internationalLicens.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = internationalLicens.DriverInfo.PersonInfo.NationalNo.ToString();
            
            if(!string.IsNullOrEmpty(internationalLicens.DriverInfo.PersonInfo.ImageBath))
            {
                pbPersonImage.Image = Image.FromFile(internationalLicens.DriverInfo.PersonInfo.ImageBath);
            }
           
        }

        void _ResetForm()
        {
            lblApplicationID.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblDriverID.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblFullName.Text = "[???]";
            lblGendor.Text = "[???]";
            lblInternationalLicenseID.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblIssueDate.Text = "[???]";
            lblLocalLicenseID.Text = "[???]";
            lblNationalNo.Text = "[???]";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
