namespace DVLD1.License
{
    partial class frmShowLicsenseHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlDriverLicenses1 = new DVLD1.License.ctrlDriverLicenses();
            this.ctrlPersonCard2 = new DVLD1.ctrlPersonCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(544, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "License History";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Image = global::DVLD1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1152, 879);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(35, 524);
            this.ctrlDriverLicenses1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(1268, 348);
            this.ctrlDriverLicenses1.TabIndex = 7;
            // 
            // ctrlPersonCard2
            // 
            this.ctrlPersonCard2.AutoSize = true;
            this.ctrlPersonCard2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ctrlPersonCard2.Location = new System.Drawing.Point(-22, 13);
            this.ctrlPersonCard2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlPersonCard2.Name = "ctrlPersonCard2";
            this.ctrlPersonCard2.Size = new System.Drawing.Size(1343, 502);
            this.ctrlPersonCard2.TabIndex = 2;
         
            // 
            // frmShowLicsenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 941);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonCard2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowLicsenseHistory";
            this.ShowIcon = false;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmShowLicsenseHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrlPersonCard ctrlPersonCard2;
        private System.Windows.Forms.Button button1;
        private ctrlDriverLicenses ctrlDriverLicenses1;
    }
}