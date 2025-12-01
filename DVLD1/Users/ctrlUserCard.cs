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
    public partial class ctrlUserCard : UserControl
    {

        public clsUser User;
        public ctrlUserCard()
        {
            InitializeComponent();

        }

        public void ResetData()
        {
            ctrlPersonCard1.ResetCotrol();
            lblActiveMode.Text = "???";
            lblUserID.Text = "???";
            lblUserName.Text = "???";
            ;
        }

        public bool LoadData(int UserID)
        {

            User = clsUser.Find(UserID);

            if (User != null)
            {
                ctrlPersonCard1.LaodData(User.PersonID);


                lblActiveMode.Text = (User.IsActive ? "Yes" : "No");

                lblUserName.Text = User.UserName;

                lblUserID.Text = User.UserID.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("User is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetData();
                return false;
            }

        }



    }
}
