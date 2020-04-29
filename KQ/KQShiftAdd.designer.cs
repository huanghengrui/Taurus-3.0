namespace Taurus
{
    partial class frmKQShiftAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQShiftAdd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optSelectAll = new System.Windows.Forms.RadioButton();
            this.optSelect = new System.Windows.Forms.RadioButton();
            this.tvDepart = new System.Windows.Forms.TreeView();
            this.txtShiftID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAhead1 = new System.Windows.Forms.TextBox();
            this.txtSignin1 = new System.Windows.Forms.MaskedTextBox();
            this.chkSignin1 = new System.Windows.Forms.CheckBox();
            this.chkSignout1 = new System.Windows.Forms.CheckBox();
            this.txtSignout1 = new System.Windows.Forms.MaskedTextBox();
            this.txtDefer1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkDrift1 = new System.Windows.Forms.CheckBox();
            this.chkDrift2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDefer2 = new System.Windows.Forms.TextBox();
            this.txtSignout2 = new System.Windows.Forms.MaskedTextBox();
            this.txtSignin2 = new System.Windows.Forms.MaskedTextBox();
            this.txtAhead2 = new System.Windows.Forms.TextBox();
            this.chkSignout2 = new System.Windows.Forms.CheckBox();
            this.chkSignin2 = new System.Windows.Forms.CheckBox();
            this.chkDrift3 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDefer3 = new System.Windows.Forms.TextBox();
            this.txtSignout3 = new System.Windows.Forms.MaskedTextBox();
            this.txtSignin3 = new System.Windows.Forms.MaskedTextBox();
            this.txtAhead3 = new System.Windows.Forms.TextBox();
            this.chkSignout3 = new System.Windows.Forms.CheckBox();
            this.chkSignin3 = new System.Windows.Forms.CheckBox();
            this.chkDrift5 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDefer5 = new System.Windows.Forms.TextBox();
            this.txtSignout5 = new System.Windows.Forms.MaskedTextBox();
            this.txtSignin5 = new System.Windows.Forms.MaskedTextBox();
            this.txtAhead5 = new System.Windows.Forms.TextBox();
            this.chkSignout5 = new System.Windows.Forms.CheckBox();
            this.chkSignin5 = new System.Windows.Forms.CheckBox();
            this.chkDrift4 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDefer4 = new System.Windows.Forms.TextBox();
            this.txtSignout4 = new System.Windows.Forms.MaskedTextBox();
            this.txtSignin4 = new System.Windows.Forms.MaskedTextBox();
            this.txtAhead4 = new System.Windows.Forms.TextBox();
            this.chkSignout4 = new System.Windows.Forms.CheckBox();
            this.chkSignin4 = new System.Windows.Forms.CheckBox();
            this.chkIsAuto = new System.Windows.Forms.CheckBox();
            this.cbbSort1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbSort2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbSort3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbSort4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbSort5 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(590, 358);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(680, 358);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optSelectAll);
            this.groupBox1.Controls.Add(this.optSelect);
            this.groupBox1.Controls.Add(this.tvDepart);
            this.groupBox1.Location = new System.Drawing.Point(431, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 305);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "ShiftDepart";
            this.groupBox1.Text = "groupBox1";
            // 
            // optSelectAll
            // 
            this.optSelectAll.AutoSize = true;
            this.optSelectAll.Location = new System.Drawing.Point(10, 40);
            this.optSelectAll.Name = "optSelectAll";
            this.optSelectAll.Size = new System.Drawing.Size(95, 16);
            this.optSelectAll.TabIndex = 45;
            this.optSelectAll.TabStop = true;
            this.optSelectAll.Text = "radioButton2";
            this.optSelectAll.UseVisualStyleBackColor = true;
            // 
            // optSelect
            // 
            this.optSelect.AutoSize = true;
            this.optSelect.Checked = true;
            this.optSelect.Location = new System.Drawing.Point(10, 20);
            this.optSelect.Name = "optSelect";
            this.optSelect.Size = new System.Drawing.Size(95, 16);
            this.optSelect.TabIndex = 44;
            this.optSelect.TabStop = true;
            this.optSelect.Text = "radioButton1";
            this.optSelect.UseVisualStyleBackColor = true;
            // 
            // tvDepart
            // 
            this.tvDepart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDepart.CheckBoxes = true;
            this.tvDepart.FullRowSelect = true;
            this.tvDepart.HideSelection = false;
            this.tvDepart.ItemHeight = 20;
            this.tvDepart.Location = new System.Drawing.Point(10, 60);
            this.tvDepart.Name = "tvDepart";
            this.tvDepart.Size = new System.Drawing.Size(305, 235);
            this.tvDepart.TabIndex = 46;
            this.tvDepart.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDepart_AfterCheck);
            // 
            // txtShiftID
            // 
            this.txtShiftID.Location = new System.Drawing.Point(80, 43);
            this.txtShiftID.MaxLength = 10;
            this.txtShiftID.Name = "txtShiftID";
            this.txtShiftID.Size = new System.Drawing.Size(100, 21);
            this.txtShiftID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 41;
            this.label1.Tag = "ShiftID";
            this.label1.Text = "label1";
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(270, 43);
            this.txtShiftName.MaxLength = 10;
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(100, 21);
            this.txtShiftName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(200, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 43;
            this.label3.Tag = "ShiftName";
            this.label3.Text = "label3";
            // 
            // txtAhead1
            // 
            this.txtAhead1.Location = new System.Drawing.Point(60, 123);
            this.txtAhead1.Name = "txtAhead1";
            this.txtAhead1.Size = new System.Drawing.Size(40, 21);
            this.txtAhead1.TabIndex = 5;
            this.txtAhead1.Text = "0";
            // 
            // txtSignin1
            // 
            this.txtSignin1.Location = new System.Drawing.Point(105, 123);
            this.txtSignin1.Mask = "90:00";
            this.txtSignin1.Name = "txtSignin1";
            this.txtSignin1.PromptChar = ' ';
            this.txtSignin1.Size = new System.Drawing.Size(45, 21);
            this.txtSignin1.TabIndex = 6;
            // 
            // chkSignin1
            // 
            this.chkSignin1.AutoSize = true;
            this.chkSignin1.Location = new System.Drawing.Point(105, 103);
            this.chkSignin1.Name = "chkSignin1";
            this.chkSignin1.Size = new System.Drawing.Size(78, 16);
            this.chkSignin1.TabIndex = 3;
            this.chkSignin1.Tag = "Signin";
            this.chkSignin1.Text = "checkBox1";
            this.chkSignin1.UseVisualStyleBackColor = true;
            // 
            // chkSignout1
            // 
            this.chkSignout1.AutoSize = true;
            this.chkSignout1.Location = new System.Drawing.Point(155, 103);
            this.chkSignout1.Name = "chkSignout1";
            this.chkSignout1.Size = new System.Drawing.Size(78, 16);
            this.chkSignout1.TabIndex = 4;
            this.chkSignout1.Tag = "Signout";
            this.chkSignout1.Text = "checkBox2";
            this.chkSignout1.UseVisualStyleBackColor = true;
            // 
            // txtSignout1
            // 
            this.txtSignout1.Location = new System.Drawing.Point(155, 123);
            this.txtSignout1.Mask = "90:00";
            this.txtSignout1.Name = "txtSignout1";
            this.txtSignout1.PromptChar = ' ';
            this.txtSignout1.Size = new System.Drawing.Size(45, 21);
            this.txtSignout1.TabIndex = 7;
            // 
            // txtDefer1
            // 
            this.txtDefer1.Location = new System.Drawing.Point(205, 123);
            this.txtDefer1.Name = "txtDefer1";
            this.txtDefer1.Size = new System.Drawing.Size(40, 21);
            this.txtDefer1.TabIndex = 8;
            this.txtDefer1.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 57;
            this.label7.Tag = "No1";
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 58;
            this.label8.Tag = "Sort";
            this.label8.Text = "label8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 60;
            this.label4.Tag = "ID";
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 61;
            this.label5.Tag = "Aheah";
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Tag = "Defer";
            this.label6.Text = "label6";
            // 
            // chkDrift1
            // 
            this.chkDrift1.AutoSize = true;
            this.chkDrift1.Location = new System.Drawing.Point(355, 127);
            this.chkDrift1.Name = "chkDrift1";
            this.chkDrift1.Size = new System.Drawing.Size(15, 14);
            this.chkDrift1.TabIndex = 10;
            this.chkDrift1.Tag = "Drift";
            this.chkDrift1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDrift1.UseVisualStyleBackColor = true;
            // 
            // chkDrift2
            // 
            this.chkDrift2.AutoSize = true;
            this.chkDrift2.Location = new System.Drawing.Point(355, 177);
            this.chkDrift2.Name = "chkDrift2";
            this.chkDrift2.Size = new System.Drawing.Size(15, 14);
            this.chkDrift2.TabIndex = 18;
            this.chkDrift2.Tag = "Drift";
            this.chkDrift2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDrift2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 71;
            this.label10.Tag = "No2";
            this.label10.Text = "label10";
            // 
            // txtDefer2
            // 
            this.txtDefer2.Location = new System.Drawing.Point(205, 173);
            this.txtDefer2.Name = "txtDefer2";
            this.txtDefer2.Size = new System.Drawing.Size(40, 21);
            this.txtDefer2.TabIndex = 16;
            this.txtDefer2.Text = "0";
            // 
            // txtSignout2
            // 
            this.txtSignout2.Location = new System.Drawing.Point(155, 173);
            this.txtSignout2.Mask = "90:00";
            this.txtSignout2.Name = "txtSignout2";
            this.txtSignout2.PromptChar = ' ';
            this.txtSignout2.Size = new System.Drawing.Size(45, 21);
            this.txtSignout2.TabIndex = 15;
            // 
            // txtSignin2
            // 
            this.txtSignin2.Location = new System.Drawing.Point(105, 173);
            this.txtSignin2.Mask = "90:00";
            this.txtSignin2.Name = "txtSignin2";
            this.txtSignin2.PromptChar = ' ';
            this.txtSignin2.Size = new System.Drawing.Size(45, 21);
            this.txtSignin2.TabIndex = 14;
            // 
            // txtAhead2
            // 
            this.txtAhead2.Location = new System.Drawing.Point(60, 173);
            this.txtAhead2.Name = "txtAhead2";
            this.txtAhead2.Size = new System.Drawing.Size(40, 21);
            this.txtAhead2.TabIndex = 13;
            this.txtAhead2.Text = "0";
            // 
            // chkSignout2
            // 
            this.chkSignout2.AutoSize = true;
            this.chkSignout2.Location = new System.Drawing.Point(155, 153);
            this.chkSignout2.Name = "chkSignout2";
            this.chkSignout2.Size = new System.Drawing.Size(78, 16);
            this.chkSignout2.TabIndex = 12;
            this.chkSignout2.Tag = "Signout";
            this.chkSignout2.Text = "checkBox5";
            this.chkSignout2.UseVisualStyleBackColor = true;
            // 
            // chkSignin2
            // 
            this.chkSignin2.AutoSize = true;
            this.chkSignin2.Location = new System.Drawing.Point(105, 153);
            this.chkSignin2.Name = "chkSignin2";
            this.chkSignin2.Size = new System.Drawing.Size(78, 16);
            this.chkSignin2.TabIndex = 11;
            this.chkSignin2.Tag = "Signin";
            this.chkSignin2.Text = "checkBox6";
            this.chkSignin2.UseVisualStyleBackColor = true;
            // 
            // chkDrift3
            // 
            this.chkDrift3.AutoSize = true;
            this.chkDrift3.Location = new System.Drawing.Point(355, 227);
            this.chkDrift3.Name = "chkDrift3";
            this.chkDrift3.Size = new System.Drawing.Size(15, 14);
            this.chkDrift3.TabIndex = 26;
            this.chkDrift3.Tag = "Drift";
            this.chkDrift3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDrift3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 80;
            this.label11.Tag = "No3";
            this.label11.Text = "label11";
            // 
            // txtDefer3
            // 
            this.txtDefer3.Location = new System.Drawing.Point(205, 223);
            this.txtDefer3.Name = "txtDefer3";
            this.txtDefer3.Size = new System.Drawing.Size(40, 21);
            this.txtDefer3.TabIndex = 24;
            this.txtDefer3.Text = "0";
            // 
            // txtSignout3
            // 
            this.txtSignout3.Location = new System.Drawing.Point(155, 223);
            this.txtSignout3.Mask = "90:00";
            this.txtSignout3.Name = "txtSignout3";
            this.txtSignout3.PromptChar = ' ';
            this.txtSignout3.Size = new System.Drawing.Size(45, 21);
            this.txtSignout3.TabIndex = 23;
            // 
            // txtSignin3
            // 
            this.txtSignin3.Location = new System.Drawing.Point(105, 223);
            this.txtSignin3.Mask = "90:00";
            this.txtSignin3.Name = "txtSignin3";
            this.txtSignin3.PromptChar = ' ';
            this.txtSignin3.Size = new System.Drawing.Size(45, 21);
            this.txtSignin3.TabIndex = 22;
            // 
            // txtAhead3
            // 
            this.txtAhead3.Location = new System.Drawing.Point(60, 223);
            this.txtAhead3.Name = "txtAhead3";
            this.txtAhead3.Size = new System.Drawing.Size(40, 21);
            this.txtAhead3.TabIndex = 21;
            this.txtAhead3.Text = "0";
            // 
            // chkSignout3
            // 
            this.chkSignout3.AutoSize = true;
            this.chkSignout3.Location = new System.Drawing.Point(155, 203);
            this.chkSignout3.Name = "chkSignout3";
            this.chkSignout3.Size = new System.Drawing.Size(78, 16);
            this.chkSignout3.TabIndex = 20;
            this.chkSignout3.Tag = "Signout";
            this.chkSignout3.Text = "checkBox8";
            this.chkSignout3.UseVisualStyleBackColor = true;
            // 
            // chkSignin3
            // 
            this.chkSignin3.AutoSize = true;
            this.chkSignin3.Location = new System.Drawing.Point(105, 203);
            this.chkSignin3.Name = "chkSignin3";
            this.chkSignin3.Size = new System.Drawing.Size(78, 16);
            this.chkSignin3.TabIndex = 19;
            this.chkSignin3.Tag = "Signin";
            this.chkSignin3.Text = "checkBox9";
            this.chkSignin3.UseVisualStyleBackColor = true;
            // 
            // chkDrift5
            // 
            this.chkDrift5.AutoSize = true;
            this.chkDrift5.Location = new System.Drawing.Point(355, 327);
            this.chkDrift5.Name = "chkDrift5";
            this.chkDrift5.Size = new System.Drawing.Size(15, 14);
            this.chkDrift5.TabIndex = 42;
            this.chkDrift5.Tag = "Drift";
            this.chkDrift5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDrift5.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 327);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 98;
            this.label12.Tag = "No5";
            this.label12.Text = "label12";
            // 
            // txtDefer5
            // 
            this.txtDefer5.Location = new System.Drawing.Point(205, 323);
            this.txtDefer5.Name = "txtDefer5";
            this.txtDefer5.Size = new System.Drawing.Size(40, 21);
            this.txtDefer5.TabIndex = 40;
            this.txtDefer5.Text = "0";
            // 
            // txtSignout5
            // 
            this.txtSignout5.Location = new System.Drawing.Point(155, 323);
            this.txtSignout5.Mask = "90:00";
            this.txtSignout5.Name = "txtSignout5";
            this.txtSignout5.PromptChar = ' ';
            this.txtSignout5.Size = new System.Drawing.Size(45, 21);
            this.txtSignout5.TabIndex = 39;
            this.toolTip.SetToolTip(this.txtSignout5, "本班段下班时间");
            // 
            // txtSignin5
            // 
            this.txtSignin5.Location = new System.Drawing.Point(105, 323);
            this.txtSignin5.Mask = "90:00";
            this.txtSignin5.Name = "txtSignin5";
            this.txtSignin5.PromptChar = ' ';
            this.txtSignin5.Size = new System.Drawing.Size(45, 21);
            this.txtSignin5.TabIndex = 38;
            // 
            // txtAhead5
            // 
            this.txtAhead5.Location = new System.Drawing.Point(60, 323);
            this.txtAhead5.Name = "txtAhead5";
            this.txtAhead5.Size = new System.Drawing.Size(40, 21);
            this.txtAhead5.TabIndex = 37;
            this.txtAhead5.Text = "0";
            // 
            // chkSignout5
            // 
            this.chkSignout5.AutoSize = true;
            this.chkSignout5.Location = new System.Drawing.Point(155, 303);
            this.chkSignout5.Name = "chkSignout5";
            this.chkSignout5.Size = new System.Drawing.Size(84, 16);
            this.chkSignout5.TabIndex = 36;
            this.chkSignout5.Tag = "Signout";
            this.chkSignout5.Text = "checkBox11";
            this.chkSignout5.UseVisualStyleBackColor = true;
            // 
            // chkSignin5
            // 
            this.chkSignin5.AutoSize = true;
            this.chkSignin5.Location = new System.Drawing.Point(105, 303);
            this.chkSignin5.Name = "chkSignin5";
            this.chkSignin5.Size = new System.Drawing.Size(84, 16);
            this.chkSignin5.TabIndex = 35;
            this.chkSignin5.Tag = "Signin";
            this.chkSignin5.Text = "checkBox12";
            this.chkSignin5.UseVisualStyleBackColor = true;
            // 
            // chkDrift4
            // 
            this.chkDrift4.AutoSize = true;
            this.chkDrift4.Location = new System.Drawing.Point(355, 277);
            this.chkDrift4.Name = "chkDrift4";
            this.chkDrift4.Size = new System.Drawing.Size(15, 14);
            this.chkDrift4.TabIndex = 34;
            this.chkDrift4.Tag = "Drift";
            this.chkDrift4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDrift4.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 277);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 89;
            this.label13.Tag = "No4";
            this.label13.Text = "label13";
            // 
            // txtDefer4
            // 
            this.txtDefer4.Location = new System.Drawing.Point(205, 273);
            this.txtDefer4.Name = "txtDefer4";
            this.txtDefer4.Size = new System.Drawing.Size(40, 21);
            this.txtDefer4.TabIndex = 32;
            this.txtDefer4.Text = "0";
            // 
            // txtSignout4
            // 
            this.txtSignout4.Location = new System.Drawing.Point(155, 273);
            this.txtSignout4.Mask = "90:00";
            this.txtSignout4.Name = "txtSignout4";
            this.txtSignout4.PromptChar = ' ';
            this.txtSignout4.Size = new System.Drawing.Size(45, 21);
            this.txtSignout4.TabIndex = 31;
            // 
            // txtSignin4
            // 
            this.txtSignin4.Location = new System.Drawing.Point(105, 273);
            this.txtSignin4.Mask = "90:00";
            this.txtSignin4.Name = "txtSignin4";
            this.txtSignin4.PromptChar = ' ';
            this.txtSignin4.Size = new System.Drawing.Size(45, 21);
            this.txtSignin4.TabIndex = 30;
            // 
            // txtAhead4
            // 
            this.txtAhead4.Location = new System.Drawing.Point(60, 273);
            this.txtAhead4.Name = "txtAhead4";
            this.txtAhead4.Size = new System.Drawing.Size(40, 21);
            this.txtAhead4.TabIndex = 29;
            this.txtAhead4.Text = "0";
            // 
            // chkSignout4
            // 
            this.chkSignout4.AutoSize = true;
            this.chkSignout4.Location = new System.Drawing.Point(155, 253);
            this.chkSignout4.Name = "chkSignout4";
            this.chkSignout4.Size = new System.Drawing.Size(84, 16);
            this.chkSignout4.TabIndex = 28;
            this.chkSignout4.Tag = "Signout";
            this.chkSignout4.Text = "checkBox14";
            this.chkSignout4.UseVisualStyleBackColor = true;
            // 
            // chkSignin4
            // 
            this.chkSignin4.AutoSize = true;
            this.chkSignin4.Location = new System.Drawing.Point(105, 253);
            this.chkSignin4.Name = "chkSignin4";
            this.chkSignin4.Size = new System.Drawing.Size(84, 16);
            this.chkSignin4.TabIndex = 27;
            this.chkSignin4.Tag = "Signin";
            this.chkSignin4.Text = "checkBox15";
            this.chkSignin4.UseVisualStyleBackColor = true;
            // 
            // chkIsAuto
            // 
            this.chkIsAuto.AutoSize = true;
            this.chkIsAuto.Location = new System.Drawing.Point(80, 73);
            this.chkIsAuto.Name = "chkIsAuto";
            this.chkIsAuto.Size = new System.Drawing.Size(36, 16);
            this.chkIsAuto.TabIndex = 2;
            this.chkIsAuto.Tag = "IsAuto";
            this.chkIsAuto.Text = "dd";
            this.chkIsAuto.UseVisualStyleBackColor = true;
            // 
            // cbbSort1
            // 
            this.cbbSort1.DisplayMember = "Text";
            this.cbbSort1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSort1.ForeColor = System.Drawing.Color.Black;
            this.cbbSort1.FormattingEnabled = true;
            this.cbbSort1.ItemHeight = 16;
            this.cbbSort1.Location = new System.Drawing.Point(252, 124);
            this.cbbSort1.Name = "cbbSort1";
            this.cbbSort1.Size = new System.Drawing.Size(97, 22);
            this.cbbSort1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbSort1.TabIndex = 1002;
            // 
            // cbbSort2
            // 
            this.cbbSort2.DisplayMember = "Text";
            this.cbbSort2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSort2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSort2.ForeColor = System.Drawing.Color.Black;
            this.cbbSort2.FormattingEnabled = true;
            this.cbbSort2.ItemHeight = 16;
            this.cbbSort2.Location = new System.Drawing.Point(252, 174);
            this.cbbSort2.Name = "cbbSort2";
            this.cbbSort2.Size = new System.Drawing.Size(97, 22);
            this.cbbSort2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbSort2.TabIndex = 1003;
            // 
            // cbbSort3
            // 
            this.cbbSort3.DisplayMember = "Text";
            this.cbbSort3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSort3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSort3.ForeColor = System.Drawing.Color.Black;
            this.cbbSort3.FormattingEnabled = true;
            this.cbbSort3.ItemHeight = 16;
            this.cbbSort3.Location = new System.Drawing.Point(252, 224);
            this.cbbSort3.Name = "cbbSort3";
            this.cbbSort3.Size = new System.Drawing.Size(97, 22);
            this.cbbSort3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbSort3.TabIndex = 1004;
            // 
            // cbbSort4
            // 
            this.cbbSort4.DisplayMember = "Text";
            this.cbbSort4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSort4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSort4.ForeColor = System.Drawing.Color.Black;
            this.cbbSort4.FormattingEnabled = true;
            this.cbbSort4.ItemHeight = 16;
            this.cbbSort4.Location = new System.Drawing.Point(252, 273);
            this.cbbSort4.Name = "cbbSort4";
            this.cbbSort4.Size = new System.Drawing.Size(97, 22);
            this.cbbSort4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbSort4.TabIndex = 1005;
            // 
            // cbbSort5
            // 
            this.cbbSort5.DisplayMember = "Text";
            this.cbbSort5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSort5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSort5.ForeColor = System.Drawing.Color.Black;
            this.cbbSort5.FormattingEnabled = true;
            this.cbbSort5.ItemHeight = 16;
            this.cbbSort5.Location = new System.Drawing.Point(252, 323);
            this.cbbSort5.Name = "cbbSort5";
            this.cbbSort5.Size = new System.Drawing.Size(97, 22);
            this.cbbSort5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbSort5.TabIndex = 1006;
            // 
            // frmKQShiftAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(764, 391);
            this.Controls.Add(this.cbbSort5);
            this.Controls.Add(this.cbbSort4);
            this.Controls.Add(this.cbbSort3);
            this.Controls.Add(this.cbbSort2);
            this.Controls.Add(this.cbbSort1);
            this.Controls.Add(this.chkIsAuto);
            this.Controls.Add(this.chkDrift5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDefer5);
            this.Controls.Add(this.txtSignout5);
            this.Controls.Add(this.txtSignin5);
            this.Controls.Add(this.txtAhead5);
            this.Controls.Add(this.chkSignout5);
            this.Controls.Add(this.chkSignin5);
            this.Controls.Add(this.chkDrift4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDefer4);
            this.Controls.Add(this.txtSignout4);
            this.Controls.Add(this.txtSignin4);
            this.Controls.Add(this.txtAhead4);
            this.Controls.Add(this.chkSignout4);
            this.Controls.Add(this.chkSignin4);
            this.Controls.Add(this.chkDrift3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDefer3);
            this.Controls.Add(this.txtSignout3);
            this.Controls.Add(this.txtSignin3);
            this.Controls.Add(this.txtAhead3);
            this.Controls.Add(this.chkSignout3);
            this.Controls.Add(this.chkSignin3);
            this.Controls.Add(this.chkDrift2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDefer2);
            this.Controls.Add(this.txtSignout2);
            this.Controls.Add(this.txtSignin2);
            this.Controls.Add(this.txtAhead2);
            this.Controls.Add(this.chkSignout2);
            this.Controls.Add(this.chkSignin2);
            this.Controls.Add(this.chkDrift1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDefer1);
            this.Controls.Add(this.txtSignout1);
            this.Controls.Add(this.txtSignin1);
            this.Controls.Add(this.txtAhead1);
            this.Controls.Add(this.txtShiftName);
            this.Controls.Add(this.txtShiftID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSignout1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSignin1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKQShiftAdd";
            this.Controls.SetChildIndex(this.chkSignin1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.chkSignout1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtShiftID, 0);
            this.Controls.SetChildIndex(this.txtShiftName, 0);
            this.Controls.SetChildIndex(this.txtAhead1, 0);
            this.Controls.SetChildIndex(this.txtSignin1, 0);
            this.Controls.SetChildIndex(this.txtSignout1, 0);
            this.Controls.SetChildIndex(this.txtDefer1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.chkDrift1, 0);
            this.Controls.SetChildIndex(this.chkSignin2, 0);
            this.Controls.SetChildIndex(this.chkSignout2, 0);
            this.Controls.SetChildIndex(this.txtAhead2, 0);
            this.Controls.SetChildIndex(this.txtSignin2, 0);
            this.Controls.SetChildIndex(this.txtSignout2, 0);
            this.Controls.SetChildIndex(this.txtDefer2, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.chkDrift2, 0);
            this.Controls.SetChildIndex(this.chkSignin3, 0);
            this.Controls.SetChildIndex(this.chkSignout3, 0);
            this.Controls.SetChildIndex(this.txtAhead3, 0);
            this.Controls.SetChildIndex(this.txtSignin3, 0);
            this.Controls.SetChildIndex(this.txtSignout3, 0);
            this.Controls.SetChildIndex(this.txtDefer3, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.chkDrift3, 0);
            this.Controls.SetChildIndex(this.chkSignin4, 0);
            this.Controls.SetChildIndex(this.chkSignout4, 0);
            this.Controls.SetChildIndex(this.txtAhead4, 0);
            this.Controls.SetChildIndex(this.txtSignin4, 0);
            this.Controls.SetChildIndex(this.txtSignout4, 0);
            this.Controls.SetChildIndex(this.txtDefer4, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.chkDrift4, 0);
            this.Controls.SetChildIndex(this.chkSignin5, 0);
            this.Controls.SetChildIndex(this.chkSignout5, 0);
            this.Controls.SetChildIndex(this.txtAhead5, 0);
            this.Controls.SetChildIndex(this.txtSignin5, 0);
            this.Controls.SetChildIndex(this.txtSignout5, 0);
            this.Controls.SetChildIndex(this.txtDefer5, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.chkDrift5, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.chkIsAuto, 0);
            this.Controls.SetChildIndex(this.cbbSort1, 0);
            this.Controls.SetChildIndex(this.cbbSort2, 0);
            this.Controls.SetChildIndex(this.cbbSort3, 0);
            this.Controls.SetChildIndex(this.cbbSort4, 0);
            this.Controls.SetChildIndex(this.cbbSort5, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TreeView tvDepart;
    private System.Windows.Forms.TextBox txtShiftID;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtShiftName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtAhead1;
    private System.Windows.Forms.MaskedTextBox txtSignin1;
    private System.Windows.Forms.CheckBox chkSignin1;
    private System.Windows.Forms.CheckBox chkSignout1;
    private System.Windows.Forms.MaskedTextBox txtSignout1;
    private System.Windows.Forms.TextBox txtDefer1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.CheckBox chkDrift1;
    private System.Windows.Forms.CheckBox chkDrift2;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtDefer2;
    private System.Windows.Forms.MaskedTextBox txtSignout2;
    private System.Windows.Forms.MaskedTextBox txtSignin2;
    private System.Windows.Forms.TextBox txtAhead2;
    private System.Windows.Forms.CheckBox chkSignout2;
    private System.Windows.Forms.CheckBox chkSignin2;
    private System.Windows.Forms.CheckBox chkDrift3;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtDefer3;
    private System.Windows.Forms.MaskedTextBox txtSignout3;
    private System.Windows.Forms.MaskedTextBox txtSignin3;
    private System.Windows.Forms.TextBox txtAhead3;
    private System.Windows.Forms.CheckBox chkSignout3;
    private System.Windows.Forms.CheckBox chkSignin3;
    private System.Windows.Forms.CheckBox chkDrift5;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox txtDefer5;
    private System.Windows.Forms.MaskedTextBox txtSignout5;
    private System.Windows.Forms.MaskedTextBox txtSignin5;
    private System.Windows.Forms.TextBox txtAhead5;
    private System.Windows.Forms.CheckBox chkSignout5;
    private System.Windows.Forms.CheckBox chkSignin5;
    private System.Windows.Forms.CheckBox chkDrift4;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txtDefer4;
    private System.Windows.Forms.MaskedTextBox txtSignout4;
    private System.Windows.Forms.MaskedTextBox txtSignin4;
    private System.Windows.Forms.TextBox txtAhead4;
    private System.Windows.Forms.CheckBox chkSignout4;
    private System.Windows.Forms.CheckBox chkSignin4;
    private System.Windows.Forms.RadioButton optSelectAll;
    private System.Windows.Forms.RadioButton optSelect;
    private System.Windows.Forms.CheckBox chkIsAuto;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbSort1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbSort2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbSort3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbSort4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbSort5;
    }
}
