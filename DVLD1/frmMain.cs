using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusinessLayer;
using DVLD1.Applications;
using DVLD1.Applications.InternationalLicenseAppliation;
using DVLD1.Drivers;
using DVLD1.GlobalClasses;
using DVLD1.LocalDrivingLicenseApplications;
using DVLD1.TestTypes;
using DVLD1.Users;

namespace DVLD1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

      
       

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManagePeople = new frmManagePeopole();

            frmManagePeople.ShowDialog();
            
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUsersPassword frm = new frmUpdateUsersPassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SignOut();
        }

        void _SignOut()
        {
            clsGlobal.CurrentUser = null;
            this.Close();
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
            
        }


        private void localDrivingLecienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenses frm = new frmManageLocalDrivingLicenses();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicense frm = new frmAddEditLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicenseApplication frm = new frmAddInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses frm = new frmListInternationalLicenses();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication frm = new frmRenewLicenseApplication();
            frm.ShowDialog();
        }

        private void replacmentForLostOrDamagedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForDamagedOrLostLicenses frm = new frmReplacementForDamagedOrLostLicenses();
            frm.ShowDialog();
        }

        private void detainLicensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();

        }
    }
}
