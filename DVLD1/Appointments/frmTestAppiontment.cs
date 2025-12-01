using DataBusinessLayer;
using DVLD1.GlobalClasses;
using DVLD1.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DataBusinessLayer.clsApplication;

namespace DVLD1.Appointments
{
    public partial class frmTestAppiontment : Form
    {
        public enum enTestType { VisionTest = 1,WrittenTest = 2,StreetTest = 3};

        public enTestType _TestType; 

        int _LocalDrivingAppID;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public frmTestAppiontment(int localDrivingAppID,enTestType testType)
        {
            InitializeComponent();
            _LocalDrivingAppID = localDrivingAppID;
            _TestType = testType;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(localDrivingAppID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVisionTestAppiontment_Load(object sender, EventArgs e)
        {
         
            _LoadData();
        }

      

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            //I should check if he has an active appointment

            if(clsTest.IsPassedAllTests(_LocalDrivingAppID))
            {
                MessageBox.Show("Person passed the all tests", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(clsTest.IsPassedTest(_LocalDrivingAppID, (int)_TestType))
            {
                MessageBox.Show("Person passed the test", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                return;
            }

            if (!clsTestAppointment.IsAnActiveTestAppExist((int)_TestType, _LocalDrivingAppID))
            {
                frmScheduleTest frm = new frmScheduleTest(_LocalDrivingAppID, (int)_TestType);
                frm.ShowDialog();
                _LoadData();
            }
            else
            {
                MessageBox.Show("Person already have an active appointment for this test,You cann't add new appointment.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        void _LoadData()
        {
            
            dgvAppiontments.DataSource = clsTestAppointment.GetAllAppiontments((int)_TestType, _LocalDrivingAppID);

            ctrlDrivingLicenseApplicationInfo1.LoadData(_LocalDrivingAppID);

            lblRecordCount.Text = dgvAppiontments.RowCount.ToString();

            switch(_TestType)
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

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvAppiontments.CurrentRow.Cells[0].Value);
            frmTakeTest frm = new frmTakeTest(id, frmTakeTest.enTestType.VisionTest);
            frm.ShowDialog();           
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvAppiontments.CurrentRow.Cells[0].Value);
            frmScheduleTest frm = new frmScheduleTest(id,_LocalDrivingAppID,(int)_TestType);
            frm.ShowDialog();
            _LoadData();
        }
    }
}
