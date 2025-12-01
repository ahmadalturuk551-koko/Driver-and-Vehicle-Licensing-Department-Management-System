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
using System.Xml.Serialization;

namespace DVLD1.Applications
{
    public partial class frmListApplicationTypes : Form
    {

        DataTable _AllApps;

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListApplications_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        void _LoadData()
        {
            _AllApps = clsApplicationType.GetAllApplications();

            dgvAllTypes.DataSource = _AllApps;

            lblRecordsCount.Text = dgvAllTypes.RowCount.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplication frm = new frmUpdateApplication(Convert.ToInt32(dgvAllTypes.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _LoadData();
        }
    }
}
