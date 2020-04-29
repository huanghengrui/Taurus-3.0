namespace Taurus
{
    partial class frmKQRuleAdd
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQRuleAdd));
            this.Label1 = new System.Windows.Forms.Label();
            this.txtRuleID = new System.Windows.Forms.TextBox();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtdefer = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAhead = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtleaveH = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtlateH = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CHKdefer = new System.Windows.Forms.CheckBox();
            this.CHKAhead = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtlateleaveM = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtrepeatlimit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtleaveignore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtlateignore = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CHKLeaveOvertime = new System.Windows.Forms.CheckBox();
            this.CHKleave = new System.Windows.Forms.CheckBox();
            this.CHKlate = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CHKHeadAndTail = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.CHKworktime = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtRestDays = new System.Windows.Forms.TextBox();
            this.chkNoRule = new System.Windows.Forms.CheckBox();
            this.RestDays = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.chkRuleSaturday = new System.Windows.Forms.CheckBox();
            this.chkRuleFriday = new System.Windows.Forms.CheckBox();
            this.chkRuleThursday = new System.Windows.Forms.CheckBox();
            this.chkRuleWednesday = new System.Windows.Forms.CheckBox();
            this.chkRuleTuesday = new System.Windows.Forms.CheckBox();
            this.chkRuleMonday = new System.Windows.Forms.CheckBox();
            this.chkRuleSunday = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(295, 416);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(375, 416);
            this.btnCancel.Text = "";
            // 
            // lbTitlte
            // 
            this.lbTitlte.BackColor = System.Drawing.Color.Transparent;
            this.lbTitlte.Size = new System.Drawing.Size(0, 13);
            this.lbTitlte.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 46);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(23, 12);
            this.Label1.TabIndex = 1001;
            this.Label1.Tag = "RuleID";
            this.Label1.Text = "ddd";
            // 
            // txtRuleID
            // 
            this.txtRuleID.Location = new System.Drawing.Point(100, 42);
            this.txtRuleID.MaxLength = 50;
            this.txtRuleID.Name = "txtRuleID";
            this.txtRuleID.Size = new System.Drawing.Size(120, 21);
            this.txtRuleID.TabIndex = 0;
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(320, 42);
            this.txtRuleName.MaxLength = 50;
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(120, 21);
            this.txtRuleName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1002;
            this.label2.Tag = "RuleName";
            this.label2.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtdefer);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtAhead);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtleaveH);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtlateH);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.CHKdefer);
            this.groupBox1.Controls.Add(this.CHKAhead);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtlateleaveM);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtrepeatlimit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtleaveignore);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtlateignore);
            this.groupBox1.Location = new System.Drawing.Point(10, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 136);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label21.Location = new System.Drawing.Point(10, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 1028;
            this.label21.Tag = "leavetime";
            this.label21.Text = "label2";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label22.Location = new System.Drawing.Point(10, 24);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 1027;
            this.label22.Tag = "latetime";
            this.label22.Text = "label2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label16.Location = new System.Drawing.Point(355, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 1026;
            this.label16.Tag = "label6";
            this.label16.Text = "label6";
            // 
            // txtdefer
            // 
            this.txtdefer.Location = new System.Drawing.Point(310, 105);
            this.txtdefer.MaxLength = 32;
            this.txtdefer.Name = "txtdefer";
            this.txtdefer.Size = new System.Drawing.Size(45, 21);
            this.txtdefer.TabIndex = 11;
            this.txtdefer.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Location = new System.Drawing.Point(355, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 1024;
            this.label15.Tag = "label6";
            this.label15.Text = "label6";
            // 
            // txtAhead
            // 
            this.txtAhead.Location = new System.Drawing.Point(310, 80);
            this.txtAhead.MaxLength = 32;
            this.txtAhead.Name = "txtAhead";
            this.txtAhead.Size = new System.Drawing.Size(45, 21);
            this.txtAhead.TabIndex = 9;
            this.txtAhead.Text = "0";
            // 
            // label13
            // 
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(355, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 24);
            this.label13.TabIndex = 1021;
            this.label13.Tag = "label3";
            this.label13.Text = "label3";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtleaveH
            // 
            this.txtleaveH.Location = new System.Drawing.Point(310, 45);
            this.txtleaveH.MaxLength = 32;
            this.txtleaveH.Name = "txtleaveH";
            this.txtleaveH.Size = new System.Drawing.Size(45, 21);
            this.txtleaveH.TabIndex = 5;
            this.txtleaveH.Text = "0";
            // 
            // label14
            // 
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Location = new System.Drawing.Point(230, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 24);
            this.label14.TabIndex = 1022;
            this.label14.Tag = "leavemore";
            this.label14.Text = "label3";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(355, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 24);
            this.label11.TabIndex = 1018;
            this.label11.Tag = "label3";
            this.label11.Text = "label3";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtlateH
            // 
            this.txtlateH.Location = new System.Drawing.Point(310, 20);
            this.txtlateH.MaxLength = 32;
            this.txtlateH.Name = "txtlateH";
            this.txtlateH.Size = new System.Drawing.Size(45, 21);
            this.txtlateH.TabIndex = 4;
            this.txtlateH.Text = "0";
            // 
            // label12
            // 
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(230, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 24);
            this.label12.TabIndex = 1019;
            this.label12.Tag = "latemore";
            this.label12.Text = "label3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CHKdefer
            // 
            this.CHKdefer.Location = new System.Drawing.Point(230, 105);
            this.CHKdefer.Name = "CHKdefer";
            this.CHKdefer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CHKdefer.Size = new System.Drawing.Size(75, 21);
            this.CHKdefer.TabIndex = 10;
            this.CHKdefer.Tag = "defer";
            this.CHKdefer.Text = "checkBox1";
            this.CHKdefer.UseVisualStyleBackColor = true;
            this.CHKdefer.CheckedChanged += new System.EventHandler(this.CHKdefer_CheckedChanged);
            // 
            // CHKAhead
            // 
            this.CHKAhead.Location = new System.Drawing.Point(230, 80);
            this.CHKAhead.Name = "CHKAhead";
            this.CHKAhead.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CHKAhead.Size = new System.Drawing.Size(75, 21);
            this.CHKAhead.TabIndex = 8;
            this.CHKAhead.Tag = "early";
            this.CHKAhead.Text = "checkBox1";
            this.CHKAhead.UseVisualStyleBackColor = true;
            this.CHKAhead.CheckedChanged += new System.EventHandler(this.CHKearly_CheckedChanged);
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(135, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 24);
            this.label9.TabIndex = 1013;
            this.label9.Tag = "DEwroktime";
            this.label9.Text = "label5";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtlateleaveM
            // 
            this.txtlateleaveM.Location = new System.Drawing.Point(90, 105);
            this.txtlateleaveM.MaxLength = 32;
            this.txtlateleaveM.Name = "txtlateleaveM";
            this.txtlateleaveM.Size = new System.Drawing.Size(45, 21);
            this.txtlateleaveM.TabIndex = 7;
            this.txtlateleaveM.Text = "0";
            // 
            // label10
            // 
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(10, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 24);
            this.label10.TabIndex = 1014;
            this.label10.Tag = "lateleave";
            this.label10.Text = "label5";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(135, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1010;
            this.label7.Tag = "min";
            this.label7.Text = "label4";
            // 
            // txtrepeatlimit
            // 
            this.txtrepeatlimit.Location = new System.Drawing.Point(90, 80);
            this.txtrepeatlimit.MaxLength = 32;
            this.txtrepeatlimit.Name = "txtrepeatlimit";
            this.txtrepeatlimit.Size = new System.Drawing.Size(45, 21);
            this.txtrepeatlimit.TabIndex = 6;
            this.txtrepeatlimit.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(10, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1011;
            this.label8.Tag = "RuleDupLimit";
            this.label8.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(135, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1007;
            this.label5.Tag = "label4";
            this.label5.Text = "label2";
            // 
            // txtleaveignore
            // 
            this.txtleaveignore.Location = new System.Drawing.Point(90, 45);
            this.txtleaveignore.MaxLength = 32;
            this.txtleaveignore.Name = "txtleaveignore";
            this.txtleaveignore.Size = new System.Drawing.Size(45, 21);
            this.txtleaveignore.TabIndex = 3;
            this.txtleaveignore.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(135, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1003;
            this.label4.Tag = "label4";
            this.label4.Text = "label2";
            // 
            // txtlateignore
            // 
            this.txtlateignore.Location = new System.Drawing.Point(90, 20);
            this.txtlateignore.MaxLength = 32;
            this.txtlateignore.Name = "txtlateignore";
            this.txtlateignore.Size = new System.Drawing.Size(45, 21);
            this.txtlateignore.TabIndex = 2;
            this.txtlateignore.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CHKLeaveOvertime);
            this.groupBox2.Controls.Add(this.CHKleave);
            this.groupBox2.Controls.Add(this.CHKlate);
            this.groupBox2.Location = new System.Drawing.Point(10, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 82);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // CHKLeaveOvertime
            // 
            this.CHKLeaveOvertime.AutoSize = true;
            this.CHKLeaveOvertime.Location = new System.Drawing.Point(10, 61);
            this.CHKLeaveOvertime.Name = "CHKLeaveOvertime";
            this.CHKLeaveOvertime.Size = new System.Drawing.Size(78, 16);
            this.CHKLeaveOvertime.TabIndex = 14;
            this.CHKLeaveOvertime.Tag = "RuleLeaveOvertime";
            this.CHKLeaveOvertime.Text = "checkBox2";
            this.CHKLeaveOvertime.UseVisualStyleBackColor = true;
            // 
            // CHKleave
            // 
            this.CHKleave.AutoSize = true;
            this.CHKleave.Location = new System.Drawing.Point(10, 41);
            this.CHKleave.Name = "CHKleave";
            this.CHKleave.Size = new System.Drawing.Size(78, 16);
            this.CHKleave.TabIndex = 13;
            this.CHKleave.Tag = "RuleReadLeave";
            this.CHKleave.Text = "checkBox2";
            this.CHKleave.UseVisualStyleBackColor = true;
            // 
            // CHKlate
            // 
            this.CHKlate.AutoSize = true;
            this.CHKlate.Location = new System.Drawing.Point(10, 21);
            this.CHKlate.Name = "CHKlate";
            this.CHKlate.Size = new System.Drawing.Size(78, 16);
            this.CHKlate.TabIndex = 12;
            this.CHKlate.Tag = "RuleReadLate";
            this.CHKlate.Text = "checkBox2";
            this.CHKlate.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CHKHeadAndTail);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.CHKworktime);
            this.groupBox3.Location = new System.Drawing.Point(310, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 82);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // CHKHeadAndTail
            // 
            this.CHKHeadAndTail.AutoSize = true;
            this.CHKHeadAndTail.Location = new System.Drawing.Point(10, 38);
            this.CHKHeadAndTail.Name = "CHKHeadAndTail";
            this.CHKHeadAndTail.Size = new System.Drawing.Size(78, 16);
            this.CHKHeadAndTail.TabIndex = 1030;
            this.CHKHeadAndTail.Tag = "RuleHeadAndTail";
            this.CHKHeadAndTail.Text = "checkBox3";
            this.CHKHeadAndTail.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label23.ForeColor = System.Drawing.Color.Blue;
            this.label23.Location = new System.Drawing.Point(3, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(134, 27);
            this.label23.TabIndex = 1029;
            this.label23.Tag = "label23";
            this.label23.Text = "label23";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CHKworktime
            // 
            this.CHKworktime.AutoSize = true;
            this.CHKworktime.Location = new System.Drawing.Point(10, 17);
            this.CHKworktime.Name = "CHKworktime";
            this.CHKworktime.Size = new System.Drawing.Size(78, 16);
            this.CHKworktime.TabIndex = 14;
            this.CHKworktime.Tag = "RuleReadWorkHrs";
            this.CHKworktime.Text = "checkBox3";
            this.CHKworktime.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.txtRestDays);
            this.groupBox5.Controls.Add(this.chkNoRule);
            this.groupBox5.Controls.Add(this.RestDays);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.chkRuleSaturday);
            this.groupBox5.Controls.Add(this.chkRuleFriday);
            this.groupBox5.Controls.Add(this.chkRuleThursday);
            this.groupBox5.Controls.Add(this.chkRuleWednesday);
            this.groupBox5.Controls.Add(this.chkRuleTuesday);
            this.groupBox5.Controls.Add(this.chkRuleMonday);
            this.groupBox5.Controls.Add(this.chkRuleSunday);
            this.groupBox5.Location = new System.Drawing.Point(10, 301);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(440, 105);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(220, 65);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(210, 30);
            this.label25.TabIndex = 1019;
            this.label25.Text = "label25";
            // 
            // txtRestDays
            // 
            this.txtRestDays.Location = new System.Drawing.Point(320, 40);
            this.txtRestDays.MaxLength = 32;
            this.txtRestDays.Name = "txtRestDays";
            this.txtRestDays.Size = new System.Drawing.Size(45, 21);
            this.txtRestDays.TabIndex = 23;
            this.txtRestDays.Tag = "";
            this.txtRestDays.Text = "0";
            // 
            // chkNoRule
            // 
            this.chkNoRule.AutoSize = true;
            this.chkNoRule.Location = new System.Drawing.Point(220, 20);
            this.chkNoRule.Name = "chkNoRule";
            this.chkNoRule.Size = new System.Drawing.Size(78, 16);
            this.chkNoRule.TabIndex = 22;
            this.chkNoRule.Tag = "RuleNoRule";
            this.chkNoRule.Text = "checkBox4";
            this.chkNoRule.UseVisualStyleBackColor = true;
            // 
            // RestDays
            // 
            this.RestDays.AutoSize = true;
            this.RestDays.Location = new System.Drawing.Point(220, 44);
            this.RestDays.Name = "RestDays";
            this.RestDays.Size = new System.Drawing.Size(41, 12);
            this.RestDays.TabIndex = 1030;
            this.RestDays.Tag = "RuleRestDays";
            this.RestDays.Text = "label8";
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label24.Location = new System.Drawing.Point(100, 80);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(110, 20);
            this.label24.TabIndex = 1029;
            this.label24.Tag = "label24";
            this.label24.Text = "label24";
            // 
            // chkRuleSaturday
            // 
            this.chkRuleSaturday.AutoSize = true;
            this.chkRuleSaturday.Location = new System.Drawing.Point(100, 60);
            this.chkRuleSaturday.Name = "chkRuleSaturday";
            this.chkRuleSaturday.Size = new System.Drawing.Size(78, 16);
            this.chkRuleSaturday.TabIndex = 21;
            this.chkRuleSaturday.Tag = "RuleSaturday";
            this.chkRuleSaturday.Text = "checkBox4";
            this.chkRuleSaturday.UseVisualStyleBackColor = true;
            // 
            // chkRuleFriday
            // 
            this.chkRuleFriday.AutoSize = true;
            this.chkRuleFriday.Location = new System.Drawing.Point(100, 40);
            this.chkRuleFriday.Name = "chkRuleFriday";
            this.chkRuleFriday.Size = new System.Drawing.Size(78, 16);
            this.chkRuleFriday.TabIndex = 20;
            this.chkRuleFriday.Tag = "RuleFriday";
            this.chkRuleFriday.Text = "checkBox4";
            this.chkRuleFriday.UseVisualStyleBackColor = true;
            // 
            // chkRuleThursday
            // 
            this.chkRuleThursday.AutoSize = true;
            this.chkRuleThursday.Location = new System.Drawing.Point(100, 20);
            this.chkRuleThursday.Name = "chkRuleThursday";
            this.chkRuleThursday.Size = new System.Drawing.Size(78, 16);
            this.chkRuleThursday.TabIndex = 19;
            this.chkRuleThursday.Tag = "RuleThursday ";
            this.chkRuleThursday.Text = "checkBox4";
            this.chkRuleThursday.UseVisualStyleBackColor = true;
            // 
            // chkRuleWednesday
            // 
            this.chkRuleWednesday.AutoSize = true;
            this.chkRuleWednesday.Location = new System.Drawing.Point(10, 80);
            this.chkRuleWednesday.Name = "chkRuleWednesday";
            this.chkRuleWednesday.Size = new System.Drawing.Size(78, 16);
            this.chkRuleWednesday.TabIndex = 18;
            this.chkRuleWednesday.Tag = "RuleWednesday ";
            this.chkRuleWednesday.Text = "checkBox4";
            this.chkRuleWednesday.UseVisualStyleBackColor = true;
            // 
            // chkRuleTuesday
            // 
            this.chkRuleTuesday.AutoSize = true;
            this.chkRuleTuesday.Location = new System.Drawing.Point(10, 60);
            this.chkRuleTuesday.Name = "chkRuleTuesday";
            this.chkRuleTuesday.Size = new System.Drawing.Size(78, 16);
            this.chkRuleTuesday.TabIndex = 17;
            this.chkRuleTuesday.Tag = "RuleTuesday ";
            this.chkRuleTuesday.Text = "checkBox4";
            this.chkRuleTuesday.UseVisualStyleBackColor = true;
            // 
            // chkRuleMonday
            // 
            this.chkRuleMonday.AutoSize = true;
            this.chkRuleMonday.Location = new System.Drawing.Point(10, 40);
            this.chkRuleMonday.Name = "chkRuleMonday";
            this.chkRuleMonday.Size = new System.Drawing.Size(78, 16);
            this.chkRuleMonday.TabIndex = 16;
            this.chkRuleMonday.Tag = "RuleMonday ";
            this.chkRuleMonday.Text = "checkBox4";
            this.chkRuleMonday.UseVisualStyleBackColor = true;
            // 
            // chkRuleSunday
            // 
            this.chkRuleSunday.AutoSize = true;
            this.chkRuleSunday.Location = new System.Drawing.Point(10, 20);
            this.chkRuleSunday.Name = "chkRuleSunday";
            this.chkRuleSunday.Size = new System.Drawing.Size(78, 16);
            this.chkRuleSunday.TabIndex = 15;
            this.chkRuleSunday.Tag = "RuleSunday";
            this.chkRuleSunday.Text = "checkBox4";
            this.chkRuleSunday.UseVisualStyleBackColor = true;
            // 
            // frmKQRuleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(459, 449);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtRuleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRuleID);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKQRuleAdd";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.txtRuleID, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRuleName, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtRuleID;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtlateignore;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtdefer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAhead;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtleaveH;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtlateH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox CHKdefer;
        private System.Windows.Forms.CheckBox CHKAhead;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtlateleaveM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtrepeatlimit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtleaveignore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CHKleave;
        private System.Windows.Forms.CheckBox CHKlate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CHKworktime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox chkRuleSaturday;
        private System.Windows.Forms.CheckBox chkRuleFriday;
        private System.Windows.Forms.CheckBox chkRuleThursday;
        private System.Windows.Forms.CheckBox chkRuleWednesday;
        private System.Windows.Forms.CheckBox chkRuleTuesday;
        private System.Windows.Forms.CheckBox chkRuleMonday;
        private System.Windows.Forms.CheckBox chkRuleSunday;
        private System.Windows.Forms.TextBox txtRestDays;
        private System.Windows.Forms.CheckBox chkNoRule;
        private System.Windows.Forms.Label RestDays;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox CHKHeadAndTail;
        private System.Windows.Forms.CheckBox CHKLeaveOvertime;
    }
}
