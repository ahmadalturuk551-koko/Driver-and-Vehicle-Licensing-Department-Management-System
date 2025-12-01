namespace DVLD1.Applications
{
    partial class frmReplacementForDamagedOrLostLicenses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlShowDrivingLicenseInfoWithFilter1 = new DVLD1.License.ctrlShowDrivingLicenseInfoWithFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblLRApplicationID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LlShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.LlShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssueReplacment = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlShowDrivingLicenseInfoWithFilter1
            // 
            this.ctrlShowDrivingLicenseInfoWithFilter1.Location = new System.Drawing.Point(3, -5);
            this.ctrlShowDrivingLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctrlShowDrivingLicenseInfoWithFilter1.Name = "ctrlShowDrivingLicenseInfoWithFilter1";
            this.ctrlShowDrivingLicenseInfoWithFilter1.Size = new System.Drawing.Size(1197, 679);
            this.ctrlShowDrivingLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrlShowDrivingLicenseInfoWithFilter1.OnLicenseFound += new System.Action<int>(this.ctrlShowDrivingLicenseInfoWithFilter1_OnLicenseFound);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLostLicense);
            this.groupBox1.Controls.Add(this.rbDamagedLicense);
            this.groupBox1.Location = new System.Drawing.Point(535, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacment For";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(421, 29);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(143, 29);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.TabStop = true;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Location = new System.Drawing.Point(104, 29);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(191, 29);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.lblCreatedBy);
            this.groupBox2.Controls.Add(this.lblOldLicenseID);
            this.groupBox2.Controls.Add(this.lblReplacedLicenseID);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblApplicationFees);
            this.groupBox2.Controls.Add(this.lblApplicationDate);
            this.groupBox2.Controls.Add(this.lblLRApplicationID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 685);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1182, 198);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info For License Replacment";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD1.Properties.Resources.User_32__2;
            this.pictureBox6.Location = new System.Drawing.Point(728, 134);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 20;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD1.Properties.Resources.Number_32;
            this.pictureBox5.Location = new System.Drawing.Point(728, 85);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD1.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(728, 47);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD1.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(266, 134);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD1.Properties.Resources.Calendar_32;
            this.pictureBox2.Location = new System.Drawing.Point(266, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(799, 138);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(57, 25);
            this.lblCreatedBy.TabIndex = 15;
            this.lblCreatedBy.Text = "[???]";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(799, 89);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(57, 25);
            this.lblOldLicenseID.TabIndex = 14;
            this.lblOldLicenseID.Text = "[???]";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(799, 44);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(57, 25);
            this.lblReplacedLicenseID.TabIndex = 13;
            this.lblReplacedLicenseID.Text = "[???]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD1.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(266, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(507, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Created By:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(507, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 25);
            this.label11.TabIndex = 7;
            this.label11.Text = "Old License ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(507, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(197, 25);
            this.label12.TabIndex = 6;
            this.label12.Text = "Replaced License ID:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(350, 141);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(57, 25);
            this.lblApplicationFees.TabIndex = 5;
            this.lblApplicationFees.Text = "[???]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(350, 92);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(57, 25);
            this.lblApplicationDate.TabIndex = 4;
            this.lblApplicationDate.Text = "[???]";
            // 
            // lblLRApplicationID
            // 
            this.lblLRApplicationID.AutoSize = true;
            this.lblLRApplicationID.Location = new System.Drawing.Point(350, 47);
            this.lblLRApplicationID.Name = "lblLRApplicationID";
            this.lblLRApplicationID.Size = new System.Drawing.Size(57, 25);
            this.lblLRApplicationID.TabIndex = 3;
            this.lblLRApplicationID.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Application Fees";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "L.R.Application ID:";
            // 
            // LlShowLicensesHistory
            // 
            this.LlShowLicensesHistory.AutoSize = true;
            this.LlShowLicensesHistory.Enabled = false;
            this.LlShowLicensesHistory.Location = new System.Drawing.Point(12, 918);
            this.LlShowLicensesHistory.Name = "LlShowLicensesHistory";
            this.LlShowLicensesHistory.Size = new System.Drawing.Size(210, 25);
            this.LlShowLicensesHistory.TabIndex = 3;
            this.LlShowLicensesHistory.TabStop = true;
            this.LlShowLicensesHistory.Text = "Show Licenses History";
            this.LlShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlShowLicensesHistory_LinkClicked);
            // 
            // LlShowLicensesInfo
            // 
            this.LlShowLicensesInfo.AutoSize = true;
            this.LlShowLicensesInfo.Enabled = false;
            this.LlShowLicensesInfo.Location = new System.Drawing.Point(253, 918);
            this.LlShowLicensesInfo.Name = "LlShowLicensesInfo";
            this.LlShowLicensesInfo.Size = new System.Drawing.Size(230, 25);
            this.LlShowLicensesInfo.TabIndex = 4;
            this.LlShowLicensesInfo.TabStop = true;
            this.LlShowLicensesInfo.Text = "Show New License\'s Info";
            this.LlShowLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlShowLicensesInfo_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD1.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(771, 909);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 43);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssueReplacment
            // 
            this.btnIssueReplacment.Enabled = false;
            this.btnIssueReplacment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIssueReplacment.Image = global::DVLD1.Properties.Resources.Renew_Driving_License_32;
            this.btnIssueReplacment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacment.Location = new System.Drawing.Point(939, 909);
            this.btnIssueReplacment.Name = "btnIssueReplacment";
            this.btnIssueReplacment.Size = new System.Drawing.Size(245, 43);
            this.btnIssueReplacment.TabIndex = 6;
            this.btnIssueReplacment.Text = "Issue Replacment";
            this.btnIssueReplacment.UseVisualStyleBackColor = true;
            this.btnIssueReplacment.Click += new System.EventHandler(this.btnIssueReplacment_Click);
            // 
            // frmReplacementForDamagedOrLostLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 971);
            this.Controls.Add(this.btnIssueReplacment);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.LlShowLicensesInfo);
            this.Controls.Add(this.LlShowLicensesHistory);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlShowDrivingLicenseInfoWithFilter1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplacementForDamagedOrLostLicenses";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replacement for Damaged or Lost Licenses";
            this.Load += new System.EventHandler(this.frmReplacementForDamagedOrLostLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private License.ctrlShowDrivingLicenseInfoWithFilter ctrlShowDrivingLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblLRApplicationID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LlShowLicensesHistory;
        private System.Windows.Forms.LinkLabel LlShowLicensesInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssueReplacment;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}