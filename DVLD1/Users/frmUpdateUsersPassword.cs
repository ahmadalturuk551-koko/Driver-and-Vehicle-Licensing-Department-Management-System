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

namespace DVLD1.Users
{
    public partial class frmUpdateUsersPassword : Form
    {
        int _UserID;
        public frmUpdateUsersPassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        clsUser _User;

        private void frmUpdateUsersPassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.Find(_UserID);

            ctrlUserCard1.LoadData(_UserID);
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(txtCurrentPassword) != "The password is wrong!" &&
                errorProvider1.GetError(txtConfirmPassword) != "The passwords don't match.")
            {
                if (_ChangeUsersPassword())
                {
                    MessageBox.Show("Password has been changed successfully.");
                    _CleanTextBoxes();
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }

            }
   
        }

        bool _ChangeUsersPassword()
        {
            _User.Password = txtConfirmPassword.Text;

            if(_User.Save())
            {
                return true;
            }
            return false;

        }

        void _CleanTextBoxes()
        {
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text != _User.Password)
            {
                errorProvider1.SetError(txtCurrentPassword, "The password is wrong!");
                txtCurrentPassword.Focus();
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");


            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtNewPassword.Text != txtConfirmPassword.Text)
            {

                errorProvider1.SetError(txtConfirmPassword, "The passwords don't match.");
                txtConfirmPassword.Focus();
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }

        }
    }
}
