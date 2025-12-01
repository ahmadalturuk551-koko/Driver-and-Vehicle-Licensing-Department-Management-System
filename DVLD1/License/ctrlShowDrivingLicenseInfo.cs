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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD1.License
{
    public partial class ctrlShowDrivingLicenseInfo : UserControl
    {
        int _ApplicationID;
        clsApplication _Application;
        clsDriver _Driver;
        clsLicense _License;
     

        public enum enLicenseType { Local = 1,International = 2};
        public enLicenseType LicenseType;

        public ctrlShowDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadDataByLicenseID(int LicenseID)
        {
            _License = clsLicense.Find(LicenseID);
            _Driver = clsDriver.Find(_License.DriverID);
            _FillDataOfLocal();
        }

        public void LoadDataByApplicationID(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
            _Application = clsApplication.FindBaseApplication(_ApplicationID);
            _Driver = clsDriver.FindByPersonID(_Application.ApplicantPersonID);
            _License = clsLicense.FindByApplicationID(_ApplicationID);

            if (_License != null)
                _FillDataOfLocal();
            else
                MessageBox.Show("License is not exist", "Erorr", MessageBoxButtons.OK);
        }

        void _FillDataOfLocal()
        {
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblDateOfBirth.Text = _Driver.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _Driver.ID.ToString();
            lblExiprationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblGendor.Text = _Driver.PersonInfo.GenforTxt;
            lblIsActive.Text = _License.ActiveMode;
            if(_License.IsLiceneseDetained)
            {

                lblIsDetained.Text = "Yes";
            }
            else
            {
                lblIsDetained.Text = "No";

            }
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = _License.IssueReasonTxt;
            lblLicenseID.Text = _License.ID.ToString();
            lblName.Text = _Driver.PersonInfo.FullName;
            lblNationalNo.Text = _Driver.PersonInfo.NationalNo.ToString();

            if (string.IsNullOrEmpty(_License.Notes))
            {
                lblNotes.Text = "No Notes";

            }
            else
            {

                lblNotes.Text = _License.Notes;
            }

            if (_Driver.PersonInfo.GenforTxt == "Male")
            {
                pbGendor.Image = Properties.Resources.Man_32;
            }
            else
            {
                pbGendor.Image = Properties.Resources.Woman_32;
            }

            if (!string.IsNullOrEmpty(_Driver.PersonInfo.ImageBath))
            {

                pbPersonImage.Load(_Driver.PersonInfo.ImageBath);
            }
        }

        
        public void ResetForm()
        {
            lblClass.Text = "[???]";
            lblDateOfBirth.Text = "[???]";        
            lblDriverID.Text = "[???]";
            lblExiprationDate.Text = "[???]";
            lblGendor.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblIsDetained.Text = "[???]";
            lblIssueDate.Text = "[???]";
            lblIssueReason.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblIsDetained.Text = "[???]";
            lblNotes.Text = "[???]";

            pbGendor.Image = Properties.Resources.Man_32;

            pbPersonImage.Image = Properties.Resources.person_boy;
            
        }

        private void ctrlShowDrivingLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
