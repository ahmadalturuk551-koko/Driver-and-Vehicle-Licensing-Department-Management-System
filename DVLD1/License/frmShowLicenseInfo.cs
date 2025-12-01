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
    public partial class frmShowLicenseInfo : Form
    {
        int _ApplicationID;

        public frmShowLicenseInfo(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }    

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlShowDrivingLicenseInfo1.LoadDataByApplicationID(_ApplicationID);
        }
    }
}
