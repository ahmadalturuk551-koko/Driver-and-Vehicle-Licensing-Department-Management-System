using DataBusinessLayer;
using DataBusinessLayer;
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

namespace DVLD1
{
    public partial class ctrlPersonCard : UserControl
    {

        clsPerson _Person;

        int _PersonId;
        public ctrlPersonCard()
        {
            InitializeComponent();

        }



        public void ResetCotrol()
        {
            lblAddress.Text = "[???]";
            lblCountry.Text = "[???]";
            lblDateOfBirth.Text = "[?/?/?]";
            lblEmail.Text = "[???]";
            lblGendor.Text = "[???]";
            lblName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblPersonID.Text = "[???]";
            lblPhone.Text = "[???]";
            pbPersonImage.Image = Properties.Resources.person_boy;
            lblEditPerson.Visible = false;
            _PersonId = -1;
        }

        public void LaodData(int PersonId)
        {
            _PersonId = PersonId;

            _Person = clsPerson.Find(_PersonId);

         

            if (_Person  == null)
            {
                MessageBox.Show("Person with ApplicationID" + PersonId + " is not found.", "Not Found!", MessageBoxButtons.OK,MessageBoxIcon.None);
                ResetCotrol();
                return;
            }

            string Country = clsCountry.Find(_Person.NationalityCountryID).CountryName;

            lblAddress.Text = _Person.Address;
            lblCountry.Text = Country;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblEmail.Text = _Person.Email;

            if(_Person.Gendor == 0)
            {

                lblGendor.Text = "Male";
               
            }
           
            else
                lblGendor.Text = "Female";

            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblPersonID.Text = _Person.ID.ToString();
            lblPhone.Text = _Person.Phone;

            if (!string.IsNullOrEmpty(_Person.ImageBath) && File.Exists(_Person.ImageBath))
            {
                lblEditPerson.Visible = true;
                pbPersonImage.Load(_Person.ImageBath);
            }
            else
            {
                if(lblGendor.Text == "Male")
                {
                    pbPersonImage.Image = Properties.Resources.person_boy;
                }
                else
                { 
                    pbPersonImage.Image = Properties.Resources.person_girl;
                }
                
            }
        }

        private void lblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmAddEditPerson(_PersonId);
            frm.ShowDialog();
            LaodData(_PersonId);
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            ResetCotrol();
        }
    }
}
