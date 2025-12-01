using DataBusinessLayer;
using DVLD1.People;
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

namespace DVLD1.Users
{
    public partial class frmEditAddNewUser : Form
    {
        clsUser _User;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public frmEditAddNewUser()
        {
            InitializeComponent();
            _User = new clsUser();
            _Mode = enMode.AddNew;
        }

        public frmEditAddNewUser(int _UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _User = clsUser.Find(_UserID);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //there is no current person in this case

            if (ctrlPersonCardWithFilter1._PersonID == -1)
            {
                MessageBox.Show("Please select a person", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(errorProvider1.GetError(mtbConfPassword) == "Passwords don't match")
            {
                MessageBox.Show("Passwords don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbConfPassword.Focus();
                return;
            }

            if(string.IsNullOrEmpty(mtbConfPassword.Text) || string.IsNullOrEmpty(mtbUserName.Text)|| string.IsNullOrEmpty(mtbPassword.Text))
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInUserInfo();

            if (_User.Save())
            {
                MessageBox.Show("Data saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
            }

      


        }



        private void btnNext_Click(object sender, EventArgs e)
        {
           if(ctrlPersonCardWithFilter1._PersonID == -1)
           {
                
                MessageBox.Show("Select a person", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
           }

            if (_Mode == enMode.AddNew)
            {
                if (!clsUser.IsUserExistByPersonID(ctrlPersonCardWithFilter1._PersonID))
                {
                    tabControl1.SelectedIndex = 1;

                }
                else
                {
                    MessageBox.Show("Selected person is already have a user,select another one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                tabControl1.SelectedIndex = 1;
            }
            

            
        }


        void _FillInUserInfo()
        {
            _User.Password = mtbPassword.Text;
            _User.UserName = mtbUserName.Text;
            _User.IsActive =cbActiveMode.Checked;
            _User.PersonID = ctrlPersonCardWithFilter1._PersonID;
        }


        private void mtbConfPassword_Validating(object sender, CancelEventArgs e)
        {
            if(mtbPassword.Text != mtbConfPassword.Text)
            {
                errorProvider1.SetError(mtbConfPassword, "Passwords don't match");
                mtbConfPassword.Focus();
            }
            else
            {
                errorProvider1.SetError(mtbConfPassword, "");
            }

        }

        void _FillOutTheForm()
        {
            mtbPassword.Text = _User.Password;
            mtbUserName.Text = _User.UserName;
            mtbConfPassword.Text = _User.Password;
            cbActiveMode.Checked = _User.IsActive;
            ctrlPersonCardWithFilter1._PersonID = _User.PersonID;
            ctrlPersonCardWithFilter1.LoadPersonData(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();


        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
            }
            else
            {

                lblTitle.Text = "Update User";
                _FillOutTheForm();


            }
        }
    }
}