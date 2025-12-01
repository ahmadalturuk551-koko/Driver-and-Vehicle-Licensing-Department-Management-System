using DataBusinessLayer;
using DVLD1.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.Tests
{
    public partial class frmScheduleTest : Form
    {
        int _LocalDrivingAppID;

        int _TestTypeID;

        int _TestAppointmentID;

        float _PaidFees;

        clsTestAppointment TestAppointment;

        clsLocalDrivingLicenseApplication _LDApp;

        clsTestType _clsTestType;

        enum enMode { AddNew = 1,Update = 2};
        enMode Mode;
        enum EnTestType { VisionTest = 1,WrittenTest = 2,StreetTest = 3 };
        EnTestType _enTestType;

        public frmScheduleTest(int LocalDrivingAppID, int TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingAppID = LocalDrivingAppID;
            _TestTypeID = TestTypeID;
            _enTestType = (EnTestType)TestTypeID;
            _LDApp = clsLocalDrivingLicenseApplication.Find(LocalDrivingAppID);
            _clsTestType = clsTestType.Find(TestTypeID);
            TestAppointment = new clsTestAppointment();
            Mode = enMode.AddNew;
        }

        public frmScheduleTest(int TestAppointmentID , int LocalDrivingAppID, int TestTypeID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            Mode = enMode.Update;
            _LocalDrivingAppID = LocalDrivingAppID;
            _TestTypeID = TestTypeID;
            _enTestType = (EnTestType)TestTypeID;
            _LDApp = clsLocalDrivingLicenseApplication.Find(LocalDrivingAppID);
            _clsTestType = clsTestType.Find(TestTypeID);

        }

        void _LoadData()
        {


            switch (_enTestType)
            {
                case EnTestType.VisionTest:
                    gbTestInfo.Text = "Vision Test";
                    pbTitle.Image = Properties.Resources.Vision_512;
                    break;
                case EnTestType.WrittenTest:
                    gbTestInfo.Text = "Written Test";
                    pbTitle.Image = Properties.Resources.Written_Test_512;
                    break;
                case EnTestType.StreetTest:
                    gbTestInfo.Text = "Street Test";
                    pbTitle.Image = Properties.Resources.Street_Test_32;
                    break;
            }

            lblDLAppID.Text = _LDApp.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _LDApp.LicenseClassInfo.ClassName;
            lblFees.Text = _clsTestType.Fees.ToString();
            lblName.Text = _LDApp.ApplicantFullName;
            dateTimePicker1.Value = DateTime.Now;
            lblTrail.Text = clsTest.TestTrails(_LDApp.LocalDrivingLicenseApplicationID, _TestTypeID).ToString();

            //Retake Test
            if (clsTest.WillRetakeTest(_LocalDrivingAppID, _TestTypeID))
            {
                gbRetakeTestInfo.Enabled = true;
                lblRAppFees.Text = _LDApp.ApplicationType.Fees.ToString();

                _PaidFees = _clsTestType.Fees + clsApplicationType.Find(8).Fees;
                lblTotalFees.Text = _PaidFees.ToString();
       
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblRAppFees.Text = "0";
                _PaidFees = _clsTestType.Fees;
                lblTotalFees.Text = _PaidFees.ToString();
            }

            _LDApp.PaidFees = _PaidFees;

            if (Mode == enMode.Update)
            {
                dateTimePicker1.Value = TestAppointment.AppointmentDate;

                if (TestAppointment.IsLocked)
                {
                    LockTestAppointment();
                }

                if (_LDApp.ApplicationTypeID == 8)
                {
                    lblRTAppID.Text = _LDApp.ApplicationID.ToString();
                }
            }

             if (clsTest.WillRetakeTest(_LocalDrivingAppID,_TestTypeID) && !TestAppointment.IsLocked)
            {
                UnlockRetakeSection();
            }


        }

        public void LockTestAppointment()
        {
            lblLockedInfo.Text = "Person already sat for the test,appointment locked";
            btnSave.Enabled = false;
            dateTimePicker1.Enabled = false;
            

        }

        void UnlockRetakeSection()
        {
            gbRetakeTestInfo.Enabled = true;
            lblRAppFees.Text = clsApplicationType.Find(8).Fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {

            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(clsTest.IsPassedTest(_LocalDrivingAppID, _TestTypeID))
            {
                return;
            }

            if (clsTest.WillRetakeTest(_LocalDrivingAppID, _TestTypeID))
            {
             
                _LDApp.ApplicationID = AddRetakeTestApplication();

                if (_LDApp.ApplicationID != -1)
                {

                    _LDApp.Save();

                  
                    lblRTAppID.Text = _LDApp.ApplicationID.ToString();
                   
                }
                else
                {
                    MessageBox.Show("Kko");
                }
          
            }

            if (!clsTestAppointment.IsAnActiveTestAppExist(_TestTypeID, _LocalDrivingAppID))
            {
                _AddNewTestAppointment();
            }

            this.Close();


        }

        int AddRetakeTestApplication()
        {
            clsApplication RetakeApplication = new clsApplication();

            RetakeApplication.ApplicationTypeID = 8;//Retake
            RetakeApplication.ApplicationDate = DateTime.Now;
            RetakeApplication.LastStatusDate = DateTime.Now;
            RetakeApplication.PaidFees = _LDApp.LicenseClassInfo.ClassFees; ;
            RetakeApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            RetakeApplication.ApplicantPersonID = _LDApp.ApplicantPersonID;
            RetakeApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            if (RetakeApplication.Save())
            {
                return RetakeApplication.ApplicationID;
            }

            return -1;


        }

        void _AddNewTestAppointment()
        {

           

            TestAppointment.PaidFees = _clsTestType.Fees;
            TestAppointment.IsLocked = false;
            TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            TestAppointment.AppointmentDate = dateTimePicker1.Value;
            TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingAppID;
            TestAppointment.TestTypeID = _TestTypeID;
            TestAppointment.PaidFees = _PaidFees;
            
            if(TestAppointment.Save())
            {
                MessageBox.Show("Test appointment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
