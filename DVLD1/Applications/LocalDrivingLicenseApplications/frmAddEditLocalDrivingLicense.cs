using DataBusinessLayer;
using DVLD1.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.Applications
{
    public partial class frmAddEditLocalDrivingLicense : Form
    {

        public enum enMode { AddNew = 1,Update = 2};

        public enMode Mode;

        clsLocalDrivingLicenseApplication _LocalApplication;

        clsPerson _ApplicantPerson;

        public frmAddEditLocalDrivingLicense()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            _LocalApplication = new clsLocalDrivingLicenseApplication();
            _ApplicantPerson = new clsPerson();
        }

        public frmAddEditLocalDrivingLicense(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _LocalApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseAppID);
            _ApplicantPerson = clsPerson.Find(_LocalApplication.ApplicantPersonID);


        }


        private void frmAddNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {          
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1._PersonID == -1)
            {

                MessageBox.Show("Select a person", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ApplicantPerson = clsPerson.Find(ctrlPersonCardWithFilter1._PersonID);

            tabControl1.SelectedIndex = 1;


        }

        void _FillInData()
        {
            //ApplicantPersonID, ApplicationDate, ApplicationTypeID, (Int32)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID
            _LocalApplication.ApplicantPersonID = _ApplicantPerson.ID;
            _LocalApplication.ApplicationTypeID = 1;
            _LocalApplication.ApplicationDate = DateTime.Now;
            _LocalApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalApplication.LastStatusDate = DateTime.Now;
            _LocalApplication.PaidFees = _LocalApplication.LicenseClassInfo.ClassFees;
            _LocalApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            // Local Driving License 
            _LocalApplication.LicenseClassID = _LocalApplication.LicenseClassInfo.LicenseClassID;
            


        }

        void _LoadData()
        {
           

            _LocalApplication.ApplicationDate = DateTime.Now;

            lblAppDate.Text = _LocalApplication.ApplicationDate.ToShortDateString();

            DataTable ClassesDt = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in ClassesDt.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"].ToString());
            }


            _LocalApplication.CreatedByUser = clsGlobal.CurrentUser;

            lblCreatedBy.Text = _LocalApplication.CreatedByUser.UserName;
        

            ctrlPersonCardWithFilter1.LoadPersonData(_ApplicantPerson.ID);

          

            _SetCmbSelectedItem();
            _SetLicenseClass();
            _SetFeesLbl();
            _SetTitleTxt();
            _SetlblLocalAppID();
        }
        
        void _SetCmbSelectedItem()
        {
            if(Mode == enMode.AddNew)
            {

                cbLicenseClass.SelectedIndex = 2;
            }
            else
            {
                cbLicenseClass.SelectedIndex = _LocalApplication.LicenseClassID - 1;
            }
        }

        void _SetLicenseClass()
        {
          

            // License class ID starts from 1 to 7 for that reason we added one to cbLicenseClass.SelectedIndex
            _LocalApplication.LicenseClassInfo = clsLicenseClass.Find(cbLicenseClass.SelectedIndex + 1);

            
        }
    
        void _SetFeesLbl()
        {
            lblAppFees.Text = _LocalApplication.LicenseClassInfo.ClassFees.ToString();
        }


        void _SetTitleTxt()
        {
            if (Mode == enMode.Update)
            {
                lblTitle.Text = "Update Local Driving License Application";
            }
            else
            {
                lblTitle.Text = "New Local Driving License Application";
            }
        }

        void _SetlblLocalAppID()
        {
            if(Mode == enMode.Update)
            {
                lblAppID.Text = _LocalApplication.LocalDrivingLicenseApplicationID.ToString();
            }
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SetLicenseClass();
            _SetFeesLbl();
        }

        void _SetLocalDrivingLicenseLbl()
        {
            lblAppID.Text = _LocalApplication.LocalDrivingLicenseApplicationID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicenseApplication.IsThereLocalDrivingLicenseApp(_ApplicantPerson.NationalNo, cbLicenseClass.Text))
            {
                MessageBox.Show("Person has a License of this class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalDrivingLicenseApplication.IsThereAnActiveLocalDrivingLicenseApp(_ApplicantPerson.NationalNo,cbLicenseClass.Text))
            {
                MessageBox.Show("There is an active application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInData();



            if (ctrlPersonCardWithFilter1._PersonID == -1)
            {

                MessageBox.Show("Select a person", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_LocalApplication.Save())
            {
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.Update;
                _SetTitleTxt();
                _SetLocalDrivingLicenseLbl();
                _LoadData();
            }
            else
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
