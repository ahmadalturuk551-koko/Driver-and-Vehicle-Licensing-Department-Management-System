using DataBusinessLayer;
using DVLD1.GlobalClasses;
using DVLD1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD1
{
    public partial class frmLoginScreen : Form
    {
        clsUser _User;

        
        enum enPasswordMode { Showen = 1,Hided = 2};
        enPasswordMode PasswordMode = enPasswordMode.Hided;
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static void SaveCredentials(string filePath, string username, string password)
        {
            string content = username + ":" + password;
            File.WriteAllText(filePath, content);
        }


        void ClearFileContent(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
            }
  
        }


        bool LoadCredentials(ref string username, ref string password, string filepath)
        {
            if (!File.Exists(filepath))
                return false;

            string content = File.ReadAllText(filepath);

            if (string.IsNullOrWhiteSpace(content))
                return false;

            string[] parts = content.Split(':');

            if (parts.Length != 2)
            {
                username = "";
                password = "";
                return false;
            }

            username = parts[0];
            password = parts[1];
            return true;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            

           _User = clsUser.FindByUsernameAndPassword(txtUsername.Text, txtPassword.Text);

            if(cbRememberMe.Checked)
            {
                SaveCredentials(clsGlobal.UsernameAndPassFilePath, txtUsername.Text, txtPassword.Text);
            }
            else
            {
                ClearFileContent(clsGlobal.UsernameAndPassFilePath);
            }


            if(_User != null )
            {
               
                if (!_User.IsActive)
                {
                    MessageBox.Show("Your account is deactivated, please contact your admin!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsGlobal.CurrentUser = _User;   
                frmMain frm = new frmMain();
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid Username/Password!", "Wrong Credentials", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string password = "", username = "";
            PasswordMode = enPasswordMode.Hided;
            LoadCredentials(ref username, ref password, clsGlobal.UsernameAndPassFilePath);

            txtUsername.Text = username;
            txtPassword.Text = password;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                cbRememberMe.Checked = true;

            else
                cbRememberMe.Checked = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _ChangePasswordChar();
            _ChangePictureOfPbPassword();
            _ChangePasswordShowenMode();
        }

        void _ChangePasswordShowenMode()
        {

            if (PasswordMode == enPasswordMode.Hided)
            {

                PasswordMode = enPasswordMode.Showen;
              
            }
            else
            {
                PasswordMode = enPasswordMode.Hided;

            }
        }

        void _ChangePictureOfPbPassword()
        {
            if (PasswordMode == enPasswordMode.Hided)
            {
                pictureBox3.Image = Resources.eye;
            }
            else
            {
                pictureBox3.Image = Resources.Vision_Test_32;
            }
        }
        void _ChangePasswordChar()
        {
            if (PasswordMode == enPasswordMode.Hided)
            { 
                txtPassword.PasswordChar = '\0';
            }
            else
            {
               
                txtPassword.PasswordChar = '*';
  
            }
        }

      
    }
}
