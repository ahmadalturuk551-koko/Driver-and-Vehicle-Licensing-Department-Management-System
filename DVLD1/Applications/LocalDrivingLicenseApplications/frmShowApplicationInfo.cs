using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1.Applications.LocalDrivingLicenseApplications
{
    public partial class frmShowDrivingLicenseApplicationInfo : Form
    {
        int AppID;

        public frmShowDrivingLicenseApplicationInfo(int ApplicationID)
        {
            InitializeComponent();
            this.AppID = ApplicationID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadData(AppID);
        }
    }
}
