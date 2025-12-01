namespace DVLD1.License
{
    partial class frmShowLicenseInfo
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
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlShowDrivingLicenseInfo1 = new DVLD1.License.ctrlShowDrivingLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTitle
            // 
            this.pbTitle.Image = global::DVLD1.Properties.Resources.LicenseView_400;
            this.pbTitle.Location = new System.Drawing.Point(508, -9);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(157, 173);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTitle.TabIndex = 0;
            this.pbTitle.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::DVLD1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1036, 761);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlShowDrivingLicenseInfo1
            // 
            this.ctrlShowDrivingLicenseInfo1.Location = new System.Drawing.Point(13, 145);
            this.ctrlShowDrivingLicenseInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlShowDrivingLicenseInfo1.Name = "ctrlShowDrivingLicenseInfo1";
            this.ctrlShowDrivingLicenseInfo1.Size = new System.Drawing.Size(1199, 667);
            this.ctrlShowDrivingLicenseInfo1.TabIndex = 3;
            // 
            // frmShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 826);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlShowDrivingLicenseInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowLicenseInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show License Info";
            this.Load += new System.EventHandler(this.frmShowLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Button button1;
        private ctrlShowDrivingLicenseInfo ctrlShowDrivingLicenseInfo1;
    }
}