using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1
{
    public partial class frmShowPersonInfo : Form
    {
        int _PersonID;

        public frmShowPersonInfo(int PersonId)
        {
            InitializeComponent();
            _PersonID = PersonId;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LaodData(_PersonID);
        }
    }
}
