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

namespace DVLD1.Applications.InternationalLicenseAppliation
{
    public partial class frmListInternationalLicenses : Form
    {
        DataTable _dtInternationalLicenses;
        int _InternationalLicenseID;
        clsInternationalLicense _InternationalLicense;
        public frmListInternationalLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _LoadData()
        {
            _dtInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();

            dgvAllApps.DataSource = _dtInternationalLicenses;

            cbFilterBy.SelectedIndex = 0;

            _UpdateRecordLabel();
            mtbFiterBy.Visible = false;
            cbStatus.Visible = false;
        }

        private void frmListInternationalLicenses_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChangeMtMask();
            
            if(cbFilterBy.SelectedIndex == 0)
            {   
                _LoadData();
                return;
            }

            if  (cbFilterBy.SelectedIndex == 4)
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
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2 || cbFilterBy.SelectedIndex == 3)
            {
                mtbFiterBy.Mask = "9999999999999999";
               
            }
            
        }

        private void mtbFiterBy_TextChanged(object sender, EventArgs e)
        {
            string filterText = mtbFiterBy.Text.Trim();
            string selectedColumn = cbFilterBy.Text.Replace(" ", "").Trim();

            _Filter(selectedColumn, filterText);
         
        }

        void _Filter(string Column, string FilterTxt)
        {
            _dtInternationalLicenses.DefaultView.RowFilter = $"Convert([{Column}], 'System.String') LIKE '{FilterTxt}%'";

            _UpdateRecordLabel();
        }

        void _UpdateRecordLabel()
        {
            lblRecords.Text = _dtInternationalLicenses.DefaultView.Count.ToString();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChangeFilter();

        }

        void _ChangeFilter()
        {
            switch (cbStatus.SelectedIndex)
            {

                case 1:
                    _Filter("IsActive", "true");
                    break;
                case 2:
                    _Filter("IsActive", "false");
                    break;
                default:
                    _Filter("IsActive", "");
                    break;
            }

        }

        private void btnAddNewInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicenseApplication frm = new frmAddInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _InternationalLicenseID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);

            frmShowPersonInfo frm = new frmShowPersonInfo(_InternationalLicense.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _InternationalLicenseID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _InternationalLicenseID = Convert.ToInt32(dgvAllApps.CurrentRow.Cells[0].Value);
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
            frmShowLicsenseHistory frm = new frmShowLicsenseHistory(_InternationalLicense.ApplicationID);
            frm.ShowDialog();
        }
    }
}
