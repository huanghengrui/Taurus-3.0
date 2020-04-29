namespace Taurus
{
    partial class frmBaseDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseDate));
            this.cbEmp = new System.Windows.Forms.RadioButton();
            this.cbAll = new System.Windows.Forms.RadioButton();
            this.gbxEmpTime = new System.Windows.Forms.GroupBox();
            this.KQDate = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbNew = new System.Windows.Forms.RadioButton();
            this.lbTips = new System.Windows.Forms.Label();
            this.paTiming = new System.Windows.Forms.Panel();
            this.dtFive = new System.Windows.Forms.DateTimePicker();
            this.dtFour = new System.Windows.Forms.DateTimePicker();
            this.dtThree = new System.Windows.Forms.DateTimePicker();
            this.dtTwo = new System.Windows.Forms.DateTimePicker();
            this.cbFive = new System.Windows.Forms.CheckBox();
            this.cbFour = new System.Windows.Forms.CheckBox();
            this.cbThree = new System.Windows.Forms.CheckBox();
            this.cbTwo = new System.Windows.Forms.CheckBox();
            this.cbOne = new System.Windows.Forms.CheckBox();
            this.dtOne = new System.Windows.Forms.DateTimePicker();
            this.cbTiming = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxEmpTime.SuspendLayout();
            this.paTiming.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(152, 458);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 458);
            this.btnCancel.Text = "";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // cbEmp
            // 
            this.cbEmp.AutoSize = true;
            this.cbEmp.Location = new System.Drawing.Point(25, 84);
            this.cbEmp.Name = "cbEmp";
            this.cbEmp.Size = new System.Drawing.Size(95, 16);
            this.cbEmp.TabIndex = 1015;
            this.cbEmp.Text = "radioButton2";
            this.cbEmp.UseVisualStyleBackColor = true;
            this.cbEmp.Click += new System.EventHandler(this.cbEmp_Click);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(25, 62);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(95, 16);
            this.cbAll.TabIndex = 1014;
            this.cbAll.Text = "radioButton1";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.Click += new System.EventHandler(this.cbAll_Click);
            // 
            // gbxEmpTime
            // 
            this.gbxEmpTime.Controls.Add(this.KQDate);
            this.gbxEmpTime.Controls.Add(this.dtpEnd);
            this.gbxEmpTime.Controls.Add(this.dtpStart);
            this.gbxEmpTime.Location = new System.Drawing.Point(22, 108);
            this.gbxEmpTime.Name = "gbxEmpTime";
            this.gbxEmpTime.Size = new System.Drawing.Size(291, 111);
            this.gbxEmpTime.TabIndex = 1016;
            this.gbxEmpTime.TabStop = false;
            this.gbxEmpTime.Text = "groupBox1";
            // 
            // KQDate
            // 
            this.KQDate.AutoSize = true;
            this.KQDate.Location = new System.Drawing.Point(53, 36);
            this.KQDate.Name = "KQDate";
            this.KQDate.Size = new System.Drawing.Size(41, 12);
            this.KQDate.TabIndex = 1013;
            this.KQDate.Tag = "Begindate";
            this.KQDate.Text = "label1";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(122, 69);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(111, 21);
            this.dtpEnd.TabIndex = 1015;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(122, 31);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(111, 21);
            this.dtpStart.TabIndex = 1012;
            this.dtpStart.TabStop = false;
            this.dtpStart.Value = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // cbNew
            // 
            this.cbNew.AutoSize = true;
            this.cbNew.Checked = true;
            this.cbNew.Location = new System.Drawing.Point(25, 40);
            this.cbNew.Name = "cbNew";
            this.cbNew.Size = new System.Drawing.Size(95, 16);
            this.cbNew.TabIndex = 1024;
            this.cbNew.TabStop = true;
            this.cbNew.Text = "radioButton1";
            this.cbNew.UseVisualStyleBackColor = true;
            this.cbNew.Click += new System.EventHandler(this.cbNew_Click);
            // 
            // lbTips
            // 
            this.lbTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTips.ForeColor = System.Drawing.Color.Red;
            this.lbTips.Location = new System.Drawing.Point(0, 0);
            this.lbTips.Name = "lbTips";
            this.lbTips.Size = new System.Drawing.Size(291, 32);
            this.lbTips.TabIndex = 1027;
            this.lbTips.Text = "label2";
            // 
            // paTiming
            // 
            this.paTiming.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paTiming.Controls.Add(this.dtFive);
            this.paTiming.Controls.Add(this.dtFour);
            this.paTiming.Controls.Add(this.dtThree);
            this.paTiming.Controls.Add(this.dtTwo);
            this.paTiming.Controls.Add(this.cbFive);
            this.paTiming.Controls.Add(this.cbFour);
            this.paTiming.Controls.Add(this.cbThree);
            this.paTiming.Controls.Add(this.cbTwo);
            this.paTiming.Controls.Add(this.cbOne);
            this.paTiming.Controls.Add(this.dtOne);
            this.paTiming.Enabled = false;
            this.paTiming.Location = new System.Drawing.Point(19, 288);
            this.paTiming.Name = "paTiming";
            this.paTiming.Size = new System.Drawing.Size(291, 163);
            this.paTiming.TabIndex = 1026;
            // 
            // dtFive
            // 
            this.dtFive.CustomFormat = "HH:mm";
            this.dtFive.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtFive.Location = new System.Drawing.Point(139, 132);
            this.dtFive.Name = "dtFive";
            this.dtFive.ShowUpDown = true;
            this.dtFive.Size = new System.Drawing.Size(98, 21);
            this.dtFive.TabIndex = 17;
            this.dtFive.Value = new System.DateTime(2018, 12, 30, 0, 0, 0, 0);
            this.dtFive.ValueChanged += new System.EventHandler(this.dtFive_ValueChanged);
            // 
            // dtFour
            // 
            this.dtFour.CustomFormat = "HH:mm";
            this.dtFour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtFour.Location = new System.Drawing.Point(139, 101);
            this.dtFour.Name = "dtFour";
            this.dtFour.ShowUpDown = true;
            this.dtFour.Size = new System.Drawing.Size(98, 21);
            this.dtFour.TabIndex = 16;
            this.dtFour.Value = new System.DateTime(2018, 12, 30, 0, 0, 0, 0);
            this.dtFour.ValueChanged += new System.EventHandler(this.dtFour_ValueChanged);
            // 
            // dtThree
            // 
            this.dtThree.CustomFormat = "HH:mm";
            this.dtThree.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtThree.Location = new System.Drawing.Point(139, 73);
            this.dtThree.Name = "dtThree";
            this.dtThree.ShowUpDown = true;
            this.dtThree.Size = new System.Drawing.Size(98, 21);
            this.dtThree.TabIndex = 15;
            this.dtThree.Value = new System.DateTime(2018, 12, 30, 0, 0, 0, 0);
            this.dtThree.ValueChanged += new System.EventHandler(this.dtThree_ValueChanged);
            // 
            // dtTwo
            // 
            this.dtTwo.CustomFormat = "HH:mm";
            this.dtTwo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTwo.Location = new System.Drawing.Point(139, 40);
            this.dtTwo.Name = "dtTwo";
            this.dtTwo.ShowUpDown = true;
            this.dtTwo.Size = new System.Drawing.Size(98, 21);
            this.dtTwo.TabIndex = 14;
            this.dtTwo.Value = new System.DateTime(2018, 12, 30, 0, 0, 0, 0);
            this.dtTwo.ValueChanged += new System.EventHandler(this.dtTwo_ValueChanged);
            // 
            // cbFive
            // 
            this.cbFive.AutoSize = true;
            this.cbFive.Location = new System.Drawing.Point(14, 137);
            this.cbFive.Name = "cbFive";
            this.cbFive.Size = new System.Drawing.Size(78, 16);
            this.cbFive.TabIndex = 13;
            this.cbFive.Text = "checkBox5";
            this.cbFive.UseVisualStyleBackColor = true;
            this.cbFive.Click += new System.EventHandler(this.cbFive_Click);
            // 
            // cbFour
            // 
            this.cbFour.AutoSize = true;
            this.cbFour.Location = new System.Drawing.Point(14, 106);
            this.cbFour.Name = "cbFour";
            this.cbFour.Size = new System.Drawing.Size(78, 16);
            this.cbFour.TabIndex = 12;
            this.cbFour.Text = "checkBox4";
            this.cbFour.UseVisualStyleBackColor = true;
            this.cbFour.Click += new System.EventHandler(this.cbFour_Click);
            // 
            // cbThree
            // 
            this.cbThree.AutoSize = true;
            this.cbThree.Location = new System.Drawing.Point(14, 73);
            this.cbThree.Name = "cbThree";
            this.cbThree.Size = new System.Drawing.Size(78, 16);
            this.cbThree.TabIndex = 11;
            this.cbThree.Text = "checkBox3";
            this.cbThree.UseVisualStyleBackColor = true;
            this.cbThree.Click += new System.EventHandler(this.cbThree_Click);
            // 
            // cbTwo
            // 
            this.cbTwo.AutoSize = true;
            this.cbTwo.Location = new System.Drawing.Point(14, 40);
            this.cbTwo.Name = "cbTwo";
            this.cbTwo.Size = new System.Drawing.Size(78, 16);
            this.cbTwo.TabIndex = 10;
            this.cbTwo.Text = "checkBox2";
            this.cbTwo.UseVisualStyleBackColor = true;
            this.cbTwo.Click += new System.EventHandler(this.cbTwo_Click);
            // 
            // cbOne
            // 
            this.cbOne.AutoSize = true;
            this.cbOne.Checked = true;
            this.cbOne.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOne.Location = new System.Drawing.Point(14, 8);
            this.cbOne.Name = "cbOne";
            this.cbOne.Size = new System.Drawing.Size(78, 16);
            this.cbOne.TabIndex = 9;
            this.cbOne.Text = "checkBox1";
            this.cbOne.UseVisualStyleBackColor = true;
            this.cbOne.Click += new System.EventHandler(this.cbOne_Click);
            // 
            // dtOne
            // 
            this.dtOne.CustomFormat = "HH:mm";
            this.dtOne.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtOne.Location = new System.Drawing.Point(139, 8);
            this.dtOne.Name = "dtOne";
            this.dtOne.ShowUpDown = true;
            this.dtOne.Size = new System.Drawing.Size(98, 21);
            this.dtOne.TabIndex = 8;
            this.dtOne.Value = new System.DateTime(2018, 12, 30, 20, 31, 0, 0);
            this.dtOne.ValueChanged += new System.EventHandler(this.dtOne_ValueChanged);
            // 
            // cbTiming
            // 
            this.cbTiming.AutoSize = true;
            this.cbTiming.Location = new System.Drawing.Point(22, 227);
            this.cbTiming.Name = "cbTiming";
            this.cbTiming.Size = new System.Drawing.Size(95, 16);
            this.cbTiming.TabIndex = 1025;
            this.cbTiming.Text = "radioButton1";
            this.cbTiming.UseVisualStyleBackColor = true;
            this.cbTiming.Click += new System.EventHandler(this.cbTiming_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTips);
            this.panel1.Location = new System.Drawing.Point(19, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 32);
            this.panel1.TabIndex = 1032;
            // 
            // frmBaseDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paTiming);
            this.Controls.Add(this.cbTiming);
            this.Controls.Add(this.cbNew);
            this.Controls.Add(this.cbEmp);
            this.Controls.Add(this.cbAll);
            this.Controls.Add(this.gbxEmpTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaseDate";
            this.Text = "BaseDate";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbxEmpTime, 0);
            this.Controls.SetChildIndex(this.cbAll, 0);
            this.Controls.SetChildIndex(this.cbEmp, 0);
            this.Controls.SetChildIndex(this.cbNew, 0);
            this.Controls.SetChildIndex(this.cbTiming, 0);
            this.Controls.SetChildIndex(this.paTiming, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.gbxEmpTime.ResumeLayout(false);
            this.gbxEmpTime.PerformLayout();
            this.paTiming.ResumeLayout(false);
            this.paTiming.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton cbEmp;
        private System.Windows.Forms.RadioButton cbAll;
        private System.Windows.Forms.GroupBox gbxEmpTime;
        private System.Windows.Forms.Label KQDate;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.RadioButton cbNew;
        private System.Windows.Forms.Label lbTips;
        private System.Windows.Forms.Panel paTiming;
        private System.Windows.Forms.DateTimePicker dtFive;
        private System.Windows.Forms.DateTimePicker dtFour;
        private System.Windows.Forms.DateTimePicker dtThree;
        private System.Windows.Forms.DateTimePicker dtTwo;
        private System.Windows.Forms.CheckBox cbFive;
        private System.Windows.Forms.CheckBox cbFour;
        private System.Windows.Forms.CheckBox cbThree;
        private System.Windows.Forms.CheckBox cbTwo;
        private System.Windows.Forms.CheckBox cbOne;
        private System.Windows.Forms.DateTimePicker dtOne;
        private System.Windows.Forms.RadioButton cbTiming;
        private System.Windows.Forms.Panel panel1;
    }
}