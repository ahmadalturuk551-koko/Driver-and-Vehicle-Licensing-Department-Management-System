namespace DVLD1.People
{
    partial class ctrlPersonCardWithFilter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtbFilterBy = new System.Windows.Forms.MaskedTextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.ctrlPersonCard1 = new DVLD1.ctrlPersonCard();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtbFilterBy);
            this.groupBox1.Controls.Add(this.cmbFilterBy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFindPerson);
            this.groupBox1.Controls.Add(this.btnAddNewPerson);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(49, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1298, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // mtbFilterBy
            // 
            this.mtbFilterBy.Location = new System.Drawing.Point(405, 56);
            this.mtbFilterBy.Name = "mtbFilterBy";
            this.mtbFilterBy.Size = new System.Drawing.Size(209, 30);
            this.mtbFilterBy.TabIndex = 1;
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "None",
            "National No",
            "Person ApplicationID"});
            this.cmbFilterBy.Location = new System.Drawing.Point(158, 53);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(209, 33);
            this.cmbFilterBy.TabIndex = 0;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter By:";
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindPerson.Image = global::DVLD1.Properties.Resources.SearchPerson;
            this.btnFindPerson.Location = new System.Drawing.Point(714, 32);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(61, 57);
            this.btnFindPerson.TabIndex = 2;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::DVLD1.Properties.Resources.Add_Person_40;
            this.btnAddNewPerson.Location = new System.Drawing.Point(803, 32);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(61, 57);
            this.btnAddNewPerson.TabIndex = 3;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.AutoSize = true;
            this.ctrlPersonCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ctrlPersonCard1.Location = new System.Drawing.Point(4, 172);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1343, 502);
            this.ctrlPersonCard1.TabIndex = 2;
            this.ctrlPersonCard1.Load += new System.EventHandler(this.ctrlPersonCard1_Load);
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(1384, 700);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.MaskedTextBox mtbFilterBy;
        private ctrlPersonCard ctrlPersonCard1;
    }
}
