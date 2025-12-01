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
    public partial class frmUpdateTestType : Form
    {
        int _ID;
        clsTestType _TestType;
        public frmUpdateTestType(int iD)
        {
            InitializeComponent();
            _ID = iD;  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        void _LoadData()
        {
          _TestType = clsTestType.Find(_ID);

            if (_TestType != null)
            {
                lblID.Text = _TestType.ID.ToString();
                mtTitle.Text = _TestType.TypeTitle;
                rtbDescription.Text = _TestType.TypeDescription;
                mtFees.Text = _TestType.Fees.ToString();
            }
        }

        bool _FillInTestType()
        {

            if (!string.IsNullOrEmpty(mtTitle.Text) && !string.IsNullOrEmpty(rtbDescription.Text) && !string.IsNullOrEmpty(mtFees.Text))
            {
                _TestType.TypeTitle = mtTitle.Text;
                _TestType.TypeDescription = rtbDescription.Text;
                _TestType.Fees = Convert.ToInt32(mtFees.Text);
                return true;
            }
            else
            {

                MessageBox.Show("Fill in all fileds.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_FillInTestType())
            {
                if (_TestType.UpdateTestType())
                {
                    MessageBox.Show("Data updated successufly.", "Successeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data updating failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    
}
