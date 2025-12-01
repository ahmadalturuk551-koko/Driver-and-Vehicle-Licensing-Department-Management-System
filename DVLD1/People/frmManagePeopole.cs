using DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD1
{
    public partial class frmManagePeopole : Form
    {
        
        public frmManagePeopole()
        {
            InitializeComponent();
        }

        private void frmManagePeopole_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private DataTable _dtPeople;

        private void _LoadData()
        {

            _dtPeople = clsPerson.GetAllPeople();

            _dtPeople.Columns["GendorCaption"].ColumnName = "Gender";

  

            dgvAllPeople.DataSource = _dtPeople;


            if (dgvAllPeople.Columns.Contains("ImagePath"))
            {
                dgvAllPeople.Columns["ImagePath"].Visible = false;
            }

            if (dgvAllPeople.Columns.Contains("NationalityCountryID"))
            {
                dgvAllPeople.Columns["NationalityCountryID"].Visible = false;
            }

            if (dgvAllPeople.Columns.Contains("Gendor"))
            {
                dgvAllPeople.Columns["Gendor"].Visible = false;
            }

            lblRecords.Text = _dtPeople.Rows.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
            this.Close();

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            maskedTextBox1.Visible = true;
            maskedTextBox1.Mask = "";
           
            if(comboBox1.SelectedIndex == 0)
            {
                maskedTextBox1.Mask = "AAAAAAAAAAA";
                
                return;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                maskedTextBox1.Mask = "00000000000";
                return;
            }

            if(comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3||
                comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5)
            {
                maskedTextBox1.Mask = "LLLLLLLLLLLLLLLLL";
                return;
            }

            if (comboBox1.SelectedIndex == 6)
            {
                maskedTextBox1.Mask = "LLLLLLLLLLL";
                return;
            }


            if (comboBox1.SelectedIndex == 7)
            {
                maskedTextBox1.Mask = "00000000000";
                return;
            }

            if (comboBox1.SelectedIndex == 8)
            {
                maskedTextBox1.Mask = "LLLLLLLLLLL";
                return;
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            string filterText = maskedTextBox1.Text.Trim();
            string selectedColumn = comboBox1.Text.Replace(" ","").Trim();

            _dtPeople.DefaultView.RowFilter = $"Convert([{selectedColumn}], 'System.String') LIKE '{filterText}%'";

            lblRecords.Text = _dtPeople.DefaultView.Count.ToString();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditPerson();
            form.ShowDialog();
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditPerson(Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value));
            form.ShowDialog();
            _LoadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are you sure you wanna delete person with ApplicationID" + ID.ToString() ,"Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(ID))
                    MessageBox.Show("Deleted sucessfully.");

                else
                    MessageBox.Show("Deleting failed.");

                _LoadData();
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddPerson_Click(sender, e);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmShowPerson = new frmShowPersonInfo(Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value));
            frmShowPerson.ShowDialog();
            _LoadData();
        }

      
    }
}
