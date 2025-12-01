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

namespace DVLD1.Applications
{
    public partial class frmUpdateApplication : Form
    {

        int _ID;
        clsApplicationType _Application;

        public frmUpdateApplication(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillInApp();
            if(_Application.UpdateApplication())
            {
                MessageBox.Show("Data updated successfully.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Data updated successfully.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void frmUpdateApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        void _LoadData()
        {
            _Application = clsApplicationType.Find(_ID);

            if (_Application != null)
            {

                lblID.Text = _ID.ToString();
                mtFees.Text = _Application.Fees.ToString();
                mtTitle.Text = _Application.TypeTitle;
            }

        }

        void _FillInApp()
        {
            _Application.Fees = Convert.ToInt32(mtFees.Text);
            _Application.TypeTitle = mtTitle.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
