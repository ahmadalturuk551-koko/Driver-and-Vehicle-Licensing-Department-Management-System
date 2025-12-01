using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.Applications.InternationalLicenseAppliation
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        int _InternationalLicenseID;
        public frmShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if(ctrlShowInternationalLicenseInfo1.LoadData(_InternationalLicenseID))
            {

            }
            else
            {
                MessageBox.Show("koko");
            }
        }
    }
}
