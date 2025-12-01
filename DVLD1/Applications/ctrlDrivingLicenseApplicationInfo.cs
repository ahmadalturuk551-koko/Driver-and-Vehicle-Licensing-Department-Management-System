using DataBusinessLayer;
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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();

        }

        public void LoadData(int LocalAppID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalAppID);


            lblApplicant.Text = _LocalDrivingLicenseApplication.ApplicantFullName;
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassFees.ToString();
            lblApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblApplicationStatus.Text = _LocalDrivingLicenseApplication.StatusText;
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUser.UserName;
            lblDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
       
            lblPassedTests.Text = clsTest.PassedTestsCountPerClassType(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _LocalDrivingLicenseApplication.LicenseClassID).ToString();
            //lblShowLicenseInfo.Text  i must declare it as a form
            lblStatusDate.Text = _LocalDrivingLicenseApplication.LastStatusDate.ToShortDateString();
            lblType.Text = clsApplicationType.Find(_LocalDrivingLicenseApplication.ApplicationTypeID).TypeTitle;
            
        }


        private void llblPeronInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void lblShowLicenseInfo_Click(object sender, EventArgs e)
        {


            if (clsDriver.IsExistByPersonID(_LocalDrivingLicenseApplication.ApplicantPersonID) && clsLicense.IsLicenseExist(_LocalDrivingLicenseApplication.ApplicationID, _LocalDrivingLicenseApplication.LicenseClassID))
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
            }
            
        }
    }
}
