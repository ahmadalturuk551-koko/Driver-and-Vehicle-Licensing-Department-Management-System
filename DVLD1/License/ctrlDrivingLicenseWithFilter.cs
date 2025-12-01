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
    public partial class ctrlShowDrivingLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseFound;

        int _LicesneID;
        public clsLicense SelectedLicenseInfo;
        public ctrlShowDrivingLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        public void LoadData()
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                return;
            }

            _LicesneID = Convert.ToInt32(maskedTextBox1.Text.Trim());
            clsLicense license = clsLicense.Find(_LicesneID);

            if (license != null)
            {

                ctrlShowDrivingLicenseInfo1.LoadDataByLicenseID(_LicesneID);
                SelectedLicenseInfo = clsLicense.Find(_LicesneID);
                OnLicenseFound?.Invoke(_LicesneID);
            }
            else
            {
                MessageBox.Show("There is no License with ID '" + _LicesneID.ToString() + "' you entered.", "Not exist");
                ctrlShowDrivingLicenseInfo1.ResetForm();
                OnLicenseFound?.Invoke(-1);
            }
        }

        private void ctrlShowDrivingLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            ctrlShowDrivingLicenseInfo1.ResetForm();
        }

        public void ChangeGboxFilterEnableStatus(bool status)
        {
            gbFilter.Enabled = status;
        }
    }
}
