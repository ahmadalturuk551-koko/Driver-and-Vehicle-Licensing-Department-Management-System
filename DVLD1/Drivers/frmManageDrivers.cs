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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD1.Drivers
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        DataTable _dtDrivers;
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

  

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {



            _ChangeMTBFilter();


        }

        void _ChangeMTBFilter()
        {
            if (cmbFilterBy.SelectedIndex == 0)
            {
                mtbFilterBy.Visible = false;
                return;
            }

            mtbFilterBy.Visible = true;

            if (cmbFilterBy.SelectedIndex == 1)
            {
                mtbFilterBy.Mask = "00000000000";

                return;
            }

            if (cmbFilterBy.SelectedIndex == 2)
            {
                mtbFilterBy.Mask = "00000000000";
                return;
            }

            if (cmbFilterBy.SelectedIndex == 3)
            {
                mtbFilterBy.Mask = "AAAAAAAAAAAAA";
                return;
            }

            if (cmbFilterBy.SelectedIndex == 4)
            {
                mtbFilterBy.Mask = "LLLLLLLLLLLLLLLLLL";
                return;
            }
        }

        void _LoadData()
        {
            _dtDrivers = clsDriver.GetAll();

            dgvAllDrivers.DataSource = _dtDrivers;

            _RefreshRecordLabelTXT();

            cmbFilterBy.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        void _Filter()
        {
            string filterText = mtbFilterBy.Text.Trim();
            string selectedColumn = cmbFilterBy.Text.Replace(" ", "").Trim();

            _dtDrivers.DefaultView.RowFilter = $"Convert([{selectedColumn}], 'System.String') LIKE '{filterText}%'";

            _RefreshRecordLabelTXT();
        }

        void _RefreshRecordLabelTXT()
        {
            lblRecords.Text = _dtDrivers.DefaultView.Count.ToString();
        }
       
    }
    
}
