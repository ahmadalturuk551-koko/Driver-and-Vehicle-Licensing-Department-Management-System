using DataBusinessLayer;
using DVLD1.Applications;
using DVLD1.Applications.LocalDrivingLicenseApplications;
using DVLD1.Appointments;
using DVLD1.Driving_License;
using DVLD1.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DVLD1.LocalDrivingLicenseApplications
{
    public partial class frmManageLocalDrivingLicenses : Form
    {
        DataTable _DataTable;
        clsLocalDrivingLicenseApplication _LDLApp;
        int _SelectedLocalAppID;
        public frmManageLocalDrivingLicenses()
        {
            InitializeComponent();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewLDApp_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);


                frmAddEditLocalDrivingLicense frm = new frmAddEditLocalDrivingLicense();
                frm.ShowDialog();
                _LoadData();


        }

        private void frmManageLocalDrivingLicenses_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        void _LoadData()
        {
            _DataTable = clsLocalDrivingLicenseApplication.GetAllLocalApplications();

            _DataTable.Columns[0].ColumnName = "L.D.AppID";

            dgvAllApps.DataSource = _DataTable;

            lblRecords.Text = dgvAllApps.RowCount.ToString();

            mtbFiterBy.Visible = false;
            cbFilterBy.SelectedIndex = 0;
            cbStatus.Visible = false;

            //i should declare the 3 statments like that if is passed the tests menuItem.Enabled = false

           
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChangeMtMask();

            if (cbFilterBy.SelectedIndex == 0)
            {
                mtbFiterBy.Visible = false;
                cbStatus.Visible = false;
            }
            else if(cbFilterBy.SelectedIndex == 4)
            {
                mtbFiterBy.Visible = false;
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = 0;
            }
            else
            {
                mtbFiterBy.Visible = true;
                cbStatus.Visible = false;
            }
           
        }

        void _ChangeMtMask()
        {
            if (cbFilterBy.SelectedIndex == 1)
            {
                mtbFiterBy.Mask = "9999999999999999";
                return;
            }
            if (cbFilterBy.SelectedIndex == 2)
            {
                mtbFiterBy.Mask = "AAAAAAAAAAAAAAAA";
                return;
            }
            if (cbFilterBy.SelectedIndex == 3)
            {
                mtbFiterBy.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLLLLLLL";
                return;
            }

        }

        private void mtbFiterBy_TextChanged(object sender, EventArgs e)
        {
            string filterText = mtbFiterBy.Text.Trim();
            string selectedColumn = cbFilterBy.Text.Replace(" ", "").Trim();

            _Filter(selectedColumn, filterText);


        }

        void _Filter(string Column,string FilterTxt)
        {
            _DataTable.DefaultView.RowFilter = $"Convert([{Column}], 'System.String') LIKE '{FilterTxt}%'";

            lblRecords.Text = _DataTable.DefaultView.Count.ToString();
        }

        void _ChangeFilter()
        {
            switch (cbStatus.SelectedIndex)
            {
                case 1:
                    _Filter("Status", "New");
                    break;
                case 2:
                    _Filter("Status", "Cancelled");
                    break;
                case 3:
                    _Filter("Status", "Completed");
                    break;
                default:
                    _Filter("Status", "");
                    break;
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChangeFilter();

        }



        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);

            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);

            if(LocalApp.ApplicationStatus == clsApplication.enApplicationStatus.Cancelled)
            {
                return;
            }

            if (clsApplication.CancelApplication(LocalApp.ApplicationID))
            {
                MessageBox.Show("Application with ID " + _SelectedLocalAppID.ToString() + " cancelled.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _LoadData();
            }
            else
            {
                MessageBox.Show("Some thing went wrong","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);

            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);


            if (LocalApp.Delete())
            {
                MessageBox.Show("Application with ID " + _SelectedLocalAppID.ToString() + " deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadData();
            }
            else
            {
                MessageBox.Show("Some thing went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);

            frmAddEditLocalDrivingLicense frm = new frmAddEditLocalDrivingLicense(_SelectedLocalAppID);
            frm.ShowDialog();
            _LoadData();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            frmShowDrivingLicenseApplicationInfo frm = new frmShowDrivingLicenseApplicationInfo(_SelectedLocalAppID);
            frm.ShowDialog();
            
        }

        private void sechuduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
             _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);
            frmTestAppiontment frm = new frmTestAppiontment(_SelectedLocalAppID, frmTestAppiontment.enTestType.VisionTest);
            frm.ShowDialog();
            _LoadData();
        }




        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (dgvAllApps.CurrentRow == null) return;

            int _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication _LDLApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);
            if (_LDLApp == null) return; // حماية من null

            // عناصر القائمة
            ToolStripItem showHistory = contextMenuStrip1.Items["showLicenseHistoryToolStripMenuItem"];
            ToolStripItem issueFirstTime = contextMenuStrip1.Items["issueDrivingLicenseFirstTimeToolStripMenuItem"];
            ToolStripItem sche = contextMenuStrip1.Items["scheToolStripMenuItem"];
            ToolStripItem deleteApp = contextMenuStrip1.Items["deleteApplicationToolStripMenuItem"];
            ToolStripItem cancelApp = contextMenuStrip1.Items["cancelApplicationToolStripMenuItem"];
            ToolStripItem editApp = contextMenuStrip1.Items["editApplicationToolStripMenuItem"];
            ToolStripItem showLicenseInfo = contextMenuStrip1.Items["showLicenseInfoToolStripMenuItem"];

            ToolStripMenuItem scheduleVision = sechuduleVisionTestToolStripMenuItem;
            ToolStripMenuItem scheduleWritten = sechuduleWrittenTestToolStripMenuItem;
            ToolStripMenuItem scheduleStreet = sechuduleStreetTestToolStripMenuItem;

            // تعطيل الكل كبداية
            foreach (ToolStripItem item in contextMenuStrip1.Items)
                item.Enabled = false;

            bool driverExists = clsDriver.IsExistByPersonID(_LDLApp.ApplicantPersonID);
            var status = _LDLApp.ApplicationStatus;
            bool passedAll = clsTest.IsPassedAllTests(_SelectedLocalAppID);

            // ----------------------------
            // لو السائق عنده رخصة مسبقاً
            // ----------------------------
            if (driverExists)
            {
                showHistory.Enabled = true;

                if (status == clsApplication.enApplicationStatus.Completed)
                {
                    // مكتمل => بس عرض المعلومات
                    showLicenseInfo.Enabled = true;
                    issueFirstTime.Enabled = false;
                }
                else if (status != clsApplication.enApplicationStatus.Cancelled)
                {
                    // تطبيق فعّال بس مو مكتمل
                    sche.Enabled = true;
                    deleteApp.Enabled = true;
                    cancelApp.Enabled = true;
                    editApp.Enabled = true;

                    // السماح بجدولة الاختبارات (لو ما اجتاز الكل)
                    if (!passedAll)
                    {
                        scheduleVision.Enabled = true;
                        scheduleWritten.Enabled = true;
                        scheduleStreet.Enabled = true;
                    }
                }
            }
            // ----------------------------
            // لو السائق جديد (ما عنده رخصة)
            // ----------------------------
            else
            {
                if (status != clsApplication.enApplicationStatus.Cancelled)
                {
                    sche.Enabled = true;
                    deleteApp.Enabled = true;
                    cancelApp.Enabled = true;
                    editApp.Enabled = true;

                    if (!passedAll)
                    {
                        scheduleVision.Enabled = true;
                        scheduleWritten.Enabled = true;
                        scheduleStreet.Enabled = true;
                    }
                    showLicenseInfo.Enabled = (status == clsApplication.enApplicationStatus.Completed);
                }
            }

            // ----------------------------
            // التحكم بتسلسل الاختبارات
            // ----------------------------
            if (!passedAll && status != clsApplication.enApplicationStatus.Cancelled)
            {
                if (!clsTest.IsPassedVisionTest(_SelectedLocalAppID))
                {
                    scheduleVision.Enabled = true;
                    scheduleWritten.Enabled = false;
                    scheduleStreet.Enabled = false;
                }
                else if (!clsTest.IsPassedWrittenTest(_SelectedLocalAppID))
                {
                    scheduleVision.Enabled = false;
                    scheduleWritten.Enabled = true;
                    scheduleStreet.Enabled = false;
                }
                else if (!clsTest.IsPassedStreetTest(_SelectedLocalAppID))
                {
                    scheduleVision.Enabled = false;
                    scheduleWritten.Enabled = false;
                    scheduleStreet.Enabled = true;
                }
            }

            // ----------------------------
            // في حال اجتاز كل الامتحانات
            // ----------------------------
            if (passedAll && status == clsApplication.enApplicationStatus.New)
            {
                sche.Enabled = false;
                scheduleVision.Enabled = false;
                scheduleWritten.Enabled = false;
                scheduleStreet.Enabled = false;

                issueFirstTime.Enabled = true; // ✅ تفعيل إصدار الرخصة
            }
        }

        private void sechuduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);
            frmTestAppiontment frm = new frmTestAppiontment(_SelectedLocalAppID, frmTestAppiontment.enTestType.WrittenTest);
            frm.ShowDialog();
            _LoadData();
        }

        private void sechuduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);
            frmTestAppiontment frm = new frmTestAppiontment(_SelectedLocalAppID, frmTestAppiontment.enTestType.StreetTest);
            frm.ShowDialog();
            _LoadData();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense(_SelectedLocalAppID);
            frm.ShowDialog();
            _LoadData();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);

            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LDLApp.ApplicationID);
            frm.ShowDialog();

        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SelectedLocalAppID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_SelectedLocalAppID);
            frmShowLicsenseHistory frm = new frmShowLicsenseHistory(_LDLApp.ApplicationID);
            frm.ShowDialog();

        }
    }
}
