namespace DVLD1.License
{
    partial class ctrlShowDrivingLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlShowDrivingLicenseInfo1 = new DVLD1.License.ctrlShowDrivingLicenseInfo();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindLicense);
            this.gbFilter.Controls.Add(this.maskedTextBox1);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gbFilter.Location = new System.Drawing.Point(5, 8);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(392, 52);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLicense.Image = global::DVLD1.Properties.Resources.License_Type_32;
            this.btnFindLicense.Location = new System.Drawing.Point(285, 18);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(49, 33);
            this.btnFindLicense.TabIndex = 2;
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(146, 21);
            this.maskedTextBox1.Mask = "0000000000000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(122, 30);
            this.maskedTextBox1.TabIndex = 1;
            this.maskedTextBox1.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "LicenseID :";
            // 
            // ctrlShowDrivingLicenseInfo1
            // 
            this.ctrlShowDrivingLicenseInfo1.Location = new System.Drawing.Point(4, 51);
            this.ctrlShowDrivingLicenseInfo1.Name = "ctrlShowDrivingLicenseInfo1";
            this.ctrlShowDrivingLicenseInfo1.Size = new System.Drawing.Size(792, 379);
            this.ctrlShowDrivingLicenseInfo1.TabIndex = 0;
            // 
            // ctrlShowDrivingLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrlShowDrivingLicenseInfo1);
            this.Name = "ctrlShowDrivingLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(799, 435);
            this.Load += new System.EventHandler(this.ctrlShowDrivingLicenseInfoWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowDrivingLicenseInfo ctrlShowDrivingLicenseInfo1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
    }
}
