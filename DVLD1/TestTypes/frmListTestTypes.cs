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

namespace DVLD1.TestTypes
{
    public partial class frmListTestTypes : Form
    {
        DataTable _DataTable;

        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        void _LoadData()
        {
            _DataTable = clsTestType.GetAllTypes();

            dgvAllTypes.DataSource = _DataTable;
            dgvAllTypes.Columns["TestTypeDescription"].Visible = false;

            lblRecordsCount.Text = dgvAllTypes.RowCount.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType(Convert.ToInt32(dgvAllTypes.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _LoadData();
        }
    }
}
