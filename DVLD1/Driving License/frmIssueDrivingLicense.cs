using DataBusinessLayer;
using DVLD1.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.Driving_License
{
    public partial class frmIssueDrivingLicense : Form
    {

        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;
        clsLicense License;
        clsDriver Driver;
        int LicenseID = -1;
        public frmIssueDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
         
        }

        void _LoadData()
        {
            ctrlDrivingLicenseApplicationInfo1.LoadData(_LocalDrivingLicenseApplicationID);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        int IssueLicense()
        {
           // 1 - FirstTime, 2 - Renew, 3 - Replacement for Damaged, 4 - Replacement for Lost.
            License = new clsLicense();
            License.IssueDate = DateTime.Now;
            License.Notes = rtbNotes.Text;
            License.ApplicationID = LocalDrivingLicenseApplication.ApplicationID;
            License.ExpirationDate = DateTime.Now.AddYears(clsGlobal.ExpirationPeroid);
            License.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            License.LicenseClassID = LocalDrivingLicenseApplication.LicenseClassID;
            License.DriverID = AddNewDriver();
            License.IssueReason = 1;
            License.PaidFees = Convert.ToSingle( LocalDrivingLicenseApplication.PaidFees);
            License.IsActive = true;

            if(License.DriverID != -1)
            {
                if(License.Save())
                {
                    return License.ID;
                }
            }

            return -1;
        }

        int AddNewDriver()
        {
            Driver = new clsDriver();
            Driver.PersonID = LocalDrivingLicenseApplication.ApplicantPersonID;
            Driver.CreatedDate = DateTime.Now;
            Driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if (Driver.Save())
                return Driver.ID;
            else
                return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            LicenseID = IssueLicense();
            LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            if (LocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("License issued successfully with license ID = " + LicenseID.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           else
            {
                MessageBox.Show("Some thing went wrong", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
                this.Hide();
           
        }
    }
}
