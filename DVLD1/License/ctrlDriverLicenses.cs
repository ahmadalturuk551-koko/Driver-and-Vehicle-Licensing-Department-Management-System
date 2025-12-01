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

namespace DVLD1.License
{
    public partial class ctrlDriverLicenses : UserControl
    {
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
        int _ApplicantPersonID;

        public void LoadLocalLicenseData(int ApplicantPersonID)
        {

            dgvLocalLicenses.DataSource = clsLicense.GetLocalLicensesOfPerson(ApplicantPersonID);

            _ApplicantPersonID = ApplicantPersonID;
            _SetlblRecord(dgvLocalLicenses.Rows.Count);
        }

        void _SetlblRecord(int RecordCount)
        {
            lblRecord.Text = RecordCount.ToString();
        }

        public void _LoadInternationalLicenseData()
        {
            dgvInternationalLicenses.DataSource = clsLicense.GetInternationalLicensesOfPerson(_ApplicantPersonID);
            _SetlblRecord(dgvInternationalLicenses.Rows.Count);
        }

        private void tcpLicenseHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(tcpLicenseHistory.SelectedIndex == 1)
            {
                _LoadInternationalLicenseData();
            }
            else
            {
                LoadLocalLicenseData(_ApplicantPersonID);
            }
        }
    }
}
