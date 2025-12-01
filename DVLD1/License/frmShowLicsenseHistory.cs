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
using System.Xml.Serialization;

namespace DVLD1.License
{
    public partial class frmShowLicsenseHistory : Form
    {
        int _LocalDrivingLicenseApplicationID;
        int _ApplicationID;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmShowLicsenseHistory(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(_ApplicationID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicsenseHistory_Load(object sender, EventArgs e)
        {
            _LoadPersonData();
            ctrlDriverLicenses1.LoadLocalLicenseData(_LocalDrivingLicenseApplication.ApplicantPersonID);
          
        }

        void _LoadPersonData()
        {
            ctrlPersonCard2.LaodData(_LocalDrivingLicenseApplication.ApplicantPersonID);
        }

        
    }
}
