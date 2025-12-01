namespace DVLD1.License
{
    partial class ctrlDriverLicenses
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
            this.tcpLicenseHistory = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tcpLicenseHistory.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcpLicenseHistory
            // 
            this.tcpLicenseHistory.Controls.Add(this.tpLocal);
            this.tcpLicenseHistory.Controls.Add(this.tpInternational);
            this.tcpLicenseHistory.Location = new System.Drawing.Point(27, 36);
            this.tcpLicenseHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcpLicenseHistory.Name = "tcpLicenseHistory";
            this.tcpLicenseHistory.SelectedIndex = 0;
            this.tcpLicenseHistory.Size = new System.Drawing.Size(1214, 258);
            this.tcpLicenseHistory.TabIndex = 4;
            this.tcpLicenseHistory.SelectedIndexChanged += new System.EventHandler(this.tcpLicenseHistory_SelectedIndexChanged);
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.dgvLocalLicenses);
            this.tpLocal.Location = new System.Drawing.Point(4, 34);
            this.tpLocal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpLocal.Size = new System.Drawing.Size(1206, 220);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(4, 5);
            this.dgvLocalLicenses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.RowHeadersWidth = 51;
            this.dgvLocalLicenses.RowTemplate.Height = 24;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1198, 210);
            this.dgvLocalLicenses.TabIndex = 0;
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.dgvInternationalLicenses);
            this.tpInternational.Location = new System.Drawing.Point(4, 34);
            this.tpInternational.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpInternational.Size = new System.Drawing.Size(1206, 220);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(4, 5);
            this.dgvInternationalLicenses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowHeadersWidth = 51;
            this.dgvInternationalLicenses.RowTemplate.Height = 24;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1198, 210);
            this.dgvInternationalLicenses.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRecord);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1253, 335);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DriverLicsenses";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(194, 299);
            this.lblRecord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(23, 25);
            this.lblRecord.TabIndex = 7;
            this.lblRecord.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 299);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "# Redcord:";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcpLicenseHistory);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1267, 343);
            this.tcpLicenseHistory.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.tpInternational.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcpLicenseHistory;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label2;
    }
}
