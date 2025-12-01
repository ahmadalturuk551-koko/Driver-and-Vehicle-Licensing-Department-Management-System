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

namespace DVLD1.People
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            _LoadData();
        }

        clsPerson _Person;

        public int _PersonID;

        void _LoadData()
        {
            _Person = new clsPerson();
            cmbFilterBy.SelectedIndex = 0;
            mtbFilterBy.Visible = false;
            _PersonID = -1;
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtbFilterBy.Visible = true;

            switch(cmbFilterBy.Text)
            {
                case "National No":
                    mtbFilterBy.Mask = "AAAAAAAAA";
                    break;
                case "Person ApplicationID":
                    mtbFilterBy.Mask = "999999999";
                    break;
                case "None":                 
                    mtbFilterBy.Visible = false;
                    break;
      
            }

        }

        public void LoadPersonData(string NationalNo)
        {
            if (clsPerson.IsPersonExist(NationalNo))
            {
                _Person = clsPerson.Find(NationalNo);
                ctrlPersonCard1.LaodData(_Person.ID);
                _PersonID = _Person.ID;

            }
            else
            {
                ctrlPersonCard1.ResetCotrol();
                MessageBox.Show("Person is not exist", "Not exist", MessageBoxButtons.OK, MessageBoxIcon.None);
                _PersonID = -1;
            }
        }

        public void LoadPersonData(int PersonID)
        {
            if (clsPerson.IsPersonExist(PersonID))
            {
                _Person = clsPerson.Find(PersonID);
                ctrlPersonCard1.LaodData(PersonID);
                _PersonID = _Person.ID;
                mtbFilterBy.Text = _Person.NationalNo.ToString();
                cmbFilterBy.SelectedIndex = 1;
            }
            else
            {
                ctrlPersonCard1.ResetCotrol();
             //   MessageBox.Show("Person is not exist", "Not exist", MessageBoxButtons.OK, MessageBoxIcon.None);
                _PersonID = -1;
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(mtbFilterBy.Text))
            {

                if (cmbFilterBy.Text == "National No")
                {
                    LoadPersonData(mtbFilterBy.Text);
                    return;
                }
            
                if(cmbFilterBy.Text == "Person ApplicationID")
                {
                    LoadPersonData(Convert.ToInt32(mtbFilterBy.Text));
                }
            }
    
            
        }

        private void koko(object sender,int personID)
        {
            LoadPersonData(personID);
            mtbFilterBy.Text = personID.ToString();
            cmbFilterBy.SelectedIndex = 1;
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
             frmAddEditPerson frm = new frmAddEditPerson();
             frm.BackPersonID += koko;
             frm.ShowDialog();
             
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}