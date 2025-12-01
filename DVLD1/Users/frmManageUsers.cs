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

namespace DVLD1.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private DataTable _UserDt;


        private void _LoadData()
        {

            _UserDt = clsUser.GetAllUsers(); 

            dgvAllUsers.DataSource = _UserDt;
            
            dgvAllUsers.Columns["Password"].Visible = false;

            dgvAllUsers.Columns["FullName"].DisplayIndex = 3;

           
            lblRecordsCount.Text = dgvAllUsers.RowCount.ToString();

            cmbFilterBy.SelectedItem = cmbFilterBy.Items[0];

            cmbActiveMode.Visible = false;


            dgvAllUsers.Columns[0].Width = 130;


            dgvAllUsers.Columns[1].Width = 130;


            dgvAllUsers.Columns[2].Width = 130;


            dgvAllUsers.Columns[3].Width = 400;


            dgvAllUsers.Columns[4].Width = 130;
        }



        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblRecordsCount_Click(object sender, EventArgs e)
        {
            
        } 

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {         

            if(cmbFilterBy.SelectedIndex == 5)
            {
                mtbFilterBy.Visible = false;
                cmbActiveMode.Visible = true;
                cmbActiveMode.SelectedIndex = 0;

                return;
            }

            cmbActiveMode.Visible = false;

            if (cmbFilterBy.SelectedIndex != 0)
                mtbFilterBy.Visible = true;

            else
                mtbFilterBy.Visible = false;

        }

        private void mtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterText = mtbFilterBy.Text.Trim();
            string selectedColumn = cmbFilterBy.Text.Replace(" ", "").Trim();

            _UserDt.DefaultView.RowFilter = $"Convert([{selectedColumn}], 'System.String') LIKE '{filterText}%'";

            lblRecordsCount.Text = _UserDt.DefaultView.Count.ToString();
        }

        private void cmbActiveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = "";

            switch (cmbActiveMode.SelectedItem.ToString())
            {
                case "Yes":
                    filter = "IsActive = 1";   // أو = 1 إذا العمود int
                    break;
                case "No":
                    filter = "IsActive = 0";  // أو = 0
                    break;
                case "All":
                    filter = ""; // بدون فلترة
                    break;
            }

            _UserDt.DefaultView.RowFilter = filter;

            lblRecordsCount.Text = _UserDt.DefaultView.Count.ToString(); 
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmEditAddNewUser();
            frm.ShowDialog();
            _LoadData();

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete user with ApplicationID" + dgvAllUsers.CurrentRow.Cells[0].Value.ToString(), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                if (clsUser.DeleteUser(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Selected user deleted succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadData();
                }
                else
                {

                    MessageBox.Show("Deleting faild", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUsersPassword frm = new frmUpdateUsersPassword(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddNewUser frm = new frmEditAddNewUser(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }
    }
}
