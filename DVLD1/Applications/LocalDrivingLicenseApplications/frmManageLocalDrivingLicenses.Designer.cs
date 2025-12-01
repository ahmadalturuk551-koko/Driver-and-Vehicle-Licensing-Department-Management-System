namespace DVLD1.LocalDrivingLicenseApplications
{
    partial class frmManageLocalDrivingLicenses
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAllApps = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.scheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechuduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechuduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechuduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtbFiterBy = new System.Windows.Forms.MaskedTextBox();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewLDApp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllApps)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllApps
            // 
            this.dgvAllApps.AllowUserToAddRows = false;
            this.dgvAllApps.AllowUserToDeleteRows = false;
            this.dgvAllApps.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvAllApps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAllApps.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllApps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllApps.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllApps.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllApps.Location = new System.Drawing.Point(53, 305);
            this.dgvAllApps.Name = "dgvAllApps";
            this.dgvAllApps.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllApps.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllApps.RowHeadersWidth = 51;
            this.dgvAllApps.RowTemplate.Height = 24;
            this.dgvAllApps.Size = new System.Drawing.Size(1674, 437);
            this.dgvAllApps.TabIndex = 20;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(45, 45);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripMenuItem3,
            this.scheToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripMenuItem4,
            this.showLicenseInfoToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(393, 450);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Image = global::DVLD1.Properties.Resources.PersonDetails_32;
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(392, 52);
            this.showInfoToolStripMenuItem.Text = "Show Application Details";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(389, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD1.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(392, 52);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD1.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(392, 52);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(389, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD1.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(392, 52);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(389, 6);
            // 
            // scheToolStripMenuItem
            // 
            this.scheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechuduleVisionTestToolStripMenuItem,
            this.sechuduleWrittenTestToolStripMenuItem,
            this.sechuduleStreetTestToolStripMenuItem});
            this.scheToolStripMenuItem.Image = global::DVLD1.Properties.Resources.Schedule_Test_32;
            this.scheToolStripMenuItem.Name = "scheToolStripMenuItem";
            this.scheToolStripMenuItem.Size = new System.Drawing.Size(392, 52);
            this.scheToolStripMenuItem.Text = "Sechudle Test";
            // 
            // sechuduleVisionTestToolStripMenuItem
            // 
            this.sechuduleVisionTestToolStripMenuItem.Enabled = false;
            this.sechuduleVisionTestToolStripMenuItem.Image = global::DVLD1.Properties.Resources.Vision_Test_32;
            this.sechuduleVisionTestToolStripMenuItem.Name = "sechuduleVisionTestToolStripMenuItem";
            this.sechuduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(322, 52);
            this.sechuduleVisionTestToolStripMenuItem.Text = "Sechudule Vision Test";
            this.sechuduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechuduleVisionTestToolStripMenuItem_Click);
            // 
            // sechuduleWrittenTestToolStripMenuItem
            // 
            this.sechuduleWrittenTestToolStripMenuItem.Enabled = false;
            this.sechuduleWrittenTestToolStripMenuItem.Image = global::DVLD1.Properties.Resources.Written_Test_32_Sechdule;
            this.sechuduleWrittenTestToolStripMenuItem.Name = "sechuduleWrittenTestToolStripMenuItem";
            this.sechuduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(322, 52);
            this.sechuduleWrittenTestToolStripMenuItem.Text = "Sechudule Written Test";
            this.sechuduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.sechuduleWrittenTestToolStripMenuItem_Click);
            // 
            // sechuduleStreetTestToolStripMenuItem
            // 
            this.sechuduleStreetTestToolStripMenuItem.Enabled = false;
            this.sechuduleStreetTestToolStripMenuItem.Image = global::DVLD1.Properties.Resources.Street_Test_32;
            this.sechuduleStreetTestToolStripMenuItem.Name = "sechuduleStreetTestToolStripMenuItem";
            this.sechuduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(322, 52);
            this.sechuduleStreetTestToolStripMenuItem.Text = "Sechudule Street Test";
            this.sechuduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.sechuduleStreetTestToolStripMenuItem_Click);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD1.Properties.Resources.License_Type_32;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(392, 52);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(389, 6);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Enabled = false;
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD1.Properties.Resources.License_View_32;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(392, 52);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(389, 6);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Enabled = false;
            this.showLicenseHistoryToolStripMenuItem.Image = global::DVLD1.Properties.Resources.PersonLicenseHistory_32;
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(392, 52);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // mtbFiterBy
            // 
            this.mtbFiterBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mtbFiterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mtbFiterBy.Location = new System.Drawing.Point(426, 265);
            this.mtbFiterBy.Name = "mtbFiterBy";
            this.mtbFiterBy.Size = new System.Drawing.Size(224, 30);
            this.mtbFiterBy.TabIndex = 19;
            this.mtbFiterBy.Visible = false;
            this.mtbFiterBy.TextChanged += new System.EventHandler(this.mtbFiterBy_TextChanged);
            // 
            // lblRecords
            // 
            this.lblRecords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRecords.Location = new System.Drawing.Point(148, 760);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(23, 25);
            this.lblRecords.TabIndex = 18;
            this.lblRecords.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(49, 760);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "# Records";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.AppID",
            "NationalNo",
            "FullName",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(153, 266);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(227, 33);
            this.cbFilterBy.TabIndex = 15;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(48, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter By:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(549, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(619, 38);
            this.label1.TabIndex = 12;
            this.label1.Text = "Manage Local Driving License Applications";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "None",
            "New",
            "Cancelled",
            "Completed"});
            this.cbStatus.Location = new System.Drawing.Point(426, 266);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(144, 33);
            this.cbStatus.TabIndex = 21;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClose.Image = global::DVLD1.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1589, 760);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 44);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewLDApp
            // 
            this.btnAddNewLDApp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddNewLDApp.BackgroundImage = global::DVLD1.Properties.Resources.New_Application_64;
            this.btnAddNewLDApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewLDApp.Location = new System.Drawing.Point(1637, 220);
            this.btnAddNewLDApp.Name = "btnAddNewLDApp";
            this.btnAddNewLDApp.Size = new System.Drawing.Size(90, 73);
            this.btnAddNewLDApp.TabIndex = 13;
            this.btnAddNewLDApp.UseVisualStyleBackColor = true;
            this.btnAddNewLDApp.Click += new System.EventHandler(this.btnAddNewLDApp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DVLD1.Properties.Resources.Manage_Applications_64;
            this.pictureBox1.Location = new System.Drawing.Point(726, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageLocalDrivingLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1774, 822);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.dgvAllApps);
            this.Controls.Add(this.mtbFiterBy);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewLDApp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageLocalDrivingLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmManageLocalDrivingLicenses";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllApps)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllApps;
        private System.Windows.Forms.MaskedTextBox mtbFiterBy;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewLDApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem scheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechuduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechuduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechuduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
    }
}