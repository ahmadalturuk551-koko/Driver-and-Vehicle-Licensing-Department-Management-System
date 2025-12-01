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
    public partial class frmTakeTest : Form
    {
        int _TestAppointmentID;

        clsTestAppointment _TestAppointment;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public clsTest Test;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enTestType _TestType;

        enum enMode { AddNew = 1,Update = 2};
        enMode Mode;
        public frmTakeTest(int TestAppiontmentID,enTestType testType)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppiontmentID;
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_TestAppointment.LocalDrivingLicenseApplicationID);
            
        }

        void _LoadData()
        {
            lblDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            lblDClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblName.Text = _LocalDrivingLicenseApplication.ApplicantFullName;
            //  lblTestID.Text = 
            lblTrail.Text = clsTest.TestTrails(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestAppointment.TestTypeID).ToString();

            switch (_TestType)
            {
                case enTestType.VisionTest:
                    this.Text = "Vision Test Appointment";
                    pictureBox1.Image = Properties.Resources.Vision_512;

                    break;
                case enTestType.WrittenTest:
                    this.Text = "WrittenTest Test Appointment";
                    pictureBox1.Image = Properties.Resources.Written_Test_512;

                    break;
                case enTestType.StreetTest:
                    this.Text = "WrittenTest Test Appointment";
                    pictureBox1.Image = Properties.Resources.Street_Test_32;

                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private bool _TakeTest()
        {
            Test = new clsTest();

            if(rbFailed.Checked)
            {
                Test.TestResult = false;

            }
            else
            {
                Test.TestResult = true;
            }

            Test.Notes = richTextBox1.Text;

            Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            Test.TestAppointmentID = _TestAppointmentID;
            

            if (Test.Save())
            {
                
                return true;
            }
            else
            {

                return false;
            }

        }

        void _LockAppointment()
        {
            _TestAppointment.IsLocked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //
           

            if(_TakeTest())
            {
                MessageBox.Show("Test taken successfully.", "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _LockAppointment();
                if(_TestAppointment.Save())
                {
                    MessageBox.Show("Koko.", "koko", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
            }
            else
            {
                MessageBox.Show("Something went wrong", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

            lblTestID.Text = Test.TestID.ToString();

            this.Close();
        }
    }
}
