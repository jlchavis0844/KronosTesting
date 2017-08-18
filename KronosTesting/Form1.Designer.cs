using System.Data.SqlClient;

namespace KronosTesting
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnName = new System.Windows.Forms.Button();
            this.cbSchools = new System.Windows.Forms.ComboBox();
            this.lblSchools = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblfName = new System.Windows.Forms.Label();
            this.tbfName = new System.Windows.Forms.TextBox();
            this.lbllName = new System.Windows.Forms.Label();
            this.tblName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAgents = new System.Windows.Forms.ComboBox();
            this.tbTags = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbLast4 = new System.Windows.Forms.TextBox();
            this.lblLast4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(0, 9);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(90, 21);
            this.btnName.TabIndex = 0;
            this.btnName.Text = "Clear Fliters";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // cbSchools
            // 
            this.cbSchools.FormattingEnabled = true;
            this.cbSchools.Location = new System.Drawing.Point(154, 9);
            this.cbSchools.Name = "cbSchools";
            this.cbSchools.Size = new System.Drawing.Size(137, 21);
            this.cbSchools.TabIndex = 2;
            this.cbSchools.SelectedIndexChanged += new System.EventHandler(this.cbSchools_SelectedIndexChanged);
            // 
            // lblSchools
            // 
            this.lblSchools.AutoSize = true;
            this.lblSchools.Location = new System.Drawing.Point(113, 13);
            this.lblSchools.Name = "lblSchools";
            this.lblSchools.Size = new System.Drawing.Size(40, 13);
            this.lblSchools.TabIndex = 3;
            this.lblSchools.Text = "School";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(956, 9);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(137, 20);
            this.tbEmail.TabIndex = 4;
            this.tbEmail.TextChanged += new System.EventHandler(this.tbEmail_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(918, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Email";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(771, 10);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(137, 20);
            this.tbPhone.TabIndex = 6;
            this.tbPhone.TextChanged += new System.EventHandler(this.tbPhone_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(727, 13);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Phone";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblfName
            // 
            this.lblfName.AutoSize = true;
            this.lblfName.Location = new System.Drawing.Point(306, 13);
            this.lblfName.Name = "lblfName";
            this.lblfName.Size = new System.Drawing.Size(57, 13);
            this.lblfName.TabIndex = 9;
            this.lblfName.Text = "First Name";
            // 
            // tbfName
            // 
            this.tbfName.Location = new System.Drawing.Point(369, 9);
            this.tbfName.Name = "tbfName";
            this.tbfName.Size = new System.Drawing.Size(137, 20);
            this.tbfName.TabIndex = 8;
            this.tbfName.TextChanged += new System.EventHandler(this.tbfName_TextChanged);
            // 
            // lbllName
            // 
            this.lbllName.AutoSize = true;
            this.lbllName.Location = new System.Drawing.Point(516, 13);
            this.lbllName.Name = "lbllName";
            this.lbllName.Size = new System.Drawing.Size(58, 13);
            this.lbllName.TabIndex = 11;
            this.lbllName.Text = "Last Name";
            // 
            // tblName
            // 
            this.tblName.Location = new System.Drawing.Point(580, 9);
            this.tblName.Name = "tblName";
            this.tblName.Size = new System.Drawing.Size(137, 20);
            this.tblName.TabIndex = 10;
            this.tblName.TextChanged += new System.EventHandler(this.tblName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbAgents);
            this.panel1.Controls.Add(this.tbTags);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lblRecordCount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 750);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1269, 37);
            this.panel1.TabIndex = 12;
            // 
            // cbAgents
            // 
            this.cbAgents.FormattingEnabled = true;
            this.cbAgents.Location = new System.Drawing.Point(769, 5);
            this.cbAgents.Name = "cbAgents";
            this.cbAgents.Size = new System.Drawing.Size(223, 21);
            this.cbAgents.TabIndex = 17;
            // 
            // tbTags
            // 
            this.tbTags.Location = new System.Drawing.Point(469, 5);
            this.tbTags.Name = "tbTags";
            this.tbTags.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTags.Size = new System.Drawing.Size(294, 20);
            this.tbTags.TabIndex = 16;
            this.tbTags.Text = "TDS 125 Open Enrollment";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 4);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(187, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Create a Base Lead With Tag :";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(1, 9);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(90, 13);
            this.lblRecordCount.TabIndex = 13;
            this.lblRecordCount.Text = "Current Records: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Reload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.AllowUserToOrderColumns = true;
            this.dgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgData.Location = new System.Drawing.Point(0, 0);
            this.dgData.Name = "dgData";
            this.dgData.ReadOnly = true;
            this.dgData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgData.Size = new System.Drawing.Size(1269, 703);
            this.dgData.TabIndex = 1;
            this.dgData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgData_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbLast4);
            this.panel2.Controls.Add(this.lblLast4);
            this.panel2.Controls.Add(this.tbEmail);
            this.panel2.Controls.Add(this.btnName);
            this.panel2.Controls.Add(this.cbSchools);
            this.panel2.Controls.Add(this.lbllName);
            this.panel2.Controls.Add(this.lblSchools);
            this.panel2.Controls.Add(this.tblName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblfName);
            this.panel2.Controls.Add(this.tbPhone);
            this.panel2.Controls.Add(this.tbfName);
            this.panel2.Controls.Add(this.lblEmail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1269, 42);
            this.panel2.TabIndex = 13;
            // 
            // tbLast4
            // 
            this.tbLast4.Location = new System.Drawing.Point(1142, 10);
            this.tbLast4.Name = "tbLast4";
            this.tbLast4.Size = new System.Drawing.Size(100, 20);
            this.tbLast4.TabIndex = 13;
            this.tbLast4.TextChanged += new System.EventHandler(this.tbLast4_TextChanged);
            // 
            // lblLast4
            // 
            this.lblLast4.AutoSize = true;
            this.lblLast4.Location = new System.Drawing.Point(1103, 12);
            this.lblLast4.Name = "lblLast4";
            this.lblLast4.Size = new System.Drawing.Size(33, 13);
            this.lblLast4.TabIndex = 12;
            this.lblLast4.Text = "Last4";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(1279, 792);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgData);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1269, 703);
            this.panel4.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 812);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Open Enrollment Client Finder Thingy ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.ComboBox cbSchools;
        private System.Windows.Forms.Label lblSchools;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblfName;
        private System.Windows.Forms.TextBox tbfName;
        private System.Windows.Forms.Label lbllName;
        private System.Windows.Forms.TextBox tblName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbLast4;
        private System.Windows.Forms.Label lblLast4;
        private System.Windows.Forms.TextBox tbTags;
        private System.Windows.Forms.ComboBox cbAgents;
    }
}

