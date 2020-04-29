namespace Taurus
{
  partial class frmMacDataFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMacDataFormat));
            this.chkAllow = new System.Windows.Forms.CheckBox();
            this.gbxFormat = new System.Windows.Forms.GroupBox();
            this.txtDataTime = new System.Windows.Forms.TextBox();
            this.lblDataTime = new System.Windows.Forms.Label();
            this.chkDataTime = new System.Windows.Forms.CheckBox();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.chkCardNo = new System.Windows.Forms.CheckBox();
            this.lblEmpNameHint = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.chkEmpName = new System.Windows.Forms.CheckBox();
            this.lblEmpNoHint = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.lblEmpNo = new System.Windows.Forms.Label();
            this.chkEmpNo = new System.Windows.Forms.CheckBox();
            this.lblMacSNHint = new System.Windows.Forms.Label();
            this.txtMacSN = new System.Windows.Forms.TextBox();
            this.lblMacSN = new System.Windows.Forms.Label();
            this.chkMacSN = new System.Windows.Forms.CheckBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.txtSep = new System.Windows.Forms.TextBox();
            this.rbSepCustom = new System.Windows.Forms.RadioButton();
            this.rbSepTAB = new System.Windows.Forms.RadioButton();
            this.rbSepNo = new System.Windows.Forms.RadioButton();
            this.lblSep = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.chkOrder = new System.Windows.Forms.ListBox();
            this.btnOrderUp = new DevComponents.DotNetBar.ButtonX();
            this.btnOrderDown = new DevComponents.DotNetBar.ButtonX();
            this.btnShowFormat = new DevComponents.DotNetBar.ButtonX();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.gbxFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(470, 365);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(550, 365);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // chkAllow
            // 
            this.chkAllow.AutoSize = true;
            this.chkAllow.Location = new System.Drawing.Point(10, 37);
            this.chkAllow.Name = "chkAllow";
            this.chkAllow.Size = new System.Drawing.Size(78, 16);
            this.chkAllow.TabIndex = 0;
            this.chkAllow.Text = "checkBox1";
            this.chkAllow.UseVisualStyleBackColor = true;
            this.chkAllow.CheckedChanged += new System.EventHandler(this.chkAllow_CheckedChanged);
            // 
            // gbxFormat
            // 
            this.gbxFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxFormat.Controls.Add(this.txtDataTime);
            this.gbxFormat.Controls.Add(this.lblDataTime);
            this.gbxFormat.Controls.Add(this.chkDataTime);
            this.gbxFormat.Controls.Add(this.txtCardNo);
            this.gbxFormat.Controls.Add(this.lblCardNo);
            this.gbxFormat.Controls.Add(this.chkCardNo);
            this.gbxFormat.Controls.Add(this.lblEmpNameHint);
            this.gbxFormat.Controls.Add(this.txtEmpName);
            this.gbxFormat.Controls.Add(this.lblEmpName);
            this.gbxFormat.Controls.Add(this.chkEmpName);
            this.gbxFormat.Controls.Add(this.lblEmpNoHint);
            this.gbxFormat.Controls.Add(this.txtEmpNo);
            this.gbxFormat.Controls.Add(this.lblEmpNo);
            this.gbxFormat.Controls.Add(this.chkEmpNo);
            this.gbxFormat.Controls.Add(this.lblMacSNHint);
            this.gbxFormat.Controls.Add(this.txtMacSN);
            this.gbxFormat.Controls.Add(this.lblMacSN);
            this.gbxFormat.Controls.Add(this.chkMacSN);
            this.gbxFormat.Controls.Add(this.lblHint);
            this.gbxFormat.Controls.Add(this.txtSep);
            this.gbxFormat.Controls.Add(this.rbSepCustom);
            this.gbxFormat.Controls.Add(this.rbSepTAB);
            this.gbxFormat.Controls.Add(this.rbSepNo);
            this.gbxFormat.Controls.Add(this.lblSep);
            this.gbxFormat.Location = new System.Drawing.Point(10, 59);
            this.gbxFormat.Name = "gbxFormat";
            this.gbxFormat.Size = new System.Drawing.Size(615, 220);
            this.gbxFormat.TabIndex = 1;
            this.gbxFormat.TabStop = false;
            this.gbxFormat.Text = "groupBox1";
            // 
            // txtDataTime
            // 
            this.txtDataTime.Location = new System.Drawing.Point(170, 190);
            this.txtDataTime.MaxLength = 20;
            this.txtDataTime.Name = "txtDataTime";
            this.txtDataTime.Size = new System.Drawing.Size(140, 21);
            this.txtDataTime.TabIndex = 23;
            // 
            // lblDataTime
            // 
            this.lblDataTime.AutoSize = true;
            this.lblDataTime.Location = new System.Drawing.Point(120, 194);
            this.lblDataTime.Name = "lblDataTime";
            this.lblDataTime.Size = new System.Drawing.Size(41, 12);
            this.lblDataTime.TabIndex = 22;
            this.lblDataTime.Text = "label1";
            // 
            // chkDataTime
            // 
            this.chkDataTime.AutoSize = true;
            this.chkDataTime.Location = new System.Drawing.Point(10, 194);
            this.chkDataTime.Name = "chkDataTime";
            this.chkDataTime.Size = new System.Drawing.Size(78, 16);
            this.chkDataTime.TabIndex = 21;
            this.chkDataTime.Text = "checkBox1";
            this.chkDataTime.UseVisualStyleBackColor = true;
            this.chkDataTime.CheckedChanged += new System.EventHandler(this.chkDataTime_CheckedChanged);
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(170, 160);
            this.txtCardNo.MaxLength = 2;
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(40, 21);
            this.txtCardNo.TabIndex = 20;
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Location = new System.Drawing.Point(120, 164);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(41, 12);
            this.lblCardNo.TabIndex = 19;
            this.lblCardNo.Text = "label1";
            // 
            // chkCardNo
            // 
            this.chkCardNo.AutoSize = true;
            this.chkCardNo.Location = new System.Drawing.Point(10, 164);
            this.chkCardNo.Name = "chkCardNo";
            this.chkCardNo.Size = new System.Drawing.Size(78, 16);
            this.chkCardNo.TabIndex = 18;
            this.chkCardNo.Tag = "FingerNo";
            this.chkCardNo.Text = "checkBox1";
            this.chkCardNo.UseVisualStyleBackColor = true;
            this.chkCardNo.CheckedChanged += new System.EventHandler(this.chkCardNo_CheckedChanged);
            // 
            // lblEmpNameHint
            // 
            this.lblEmpNameHint.AutoSize = true;
            this.lblEmpNameHint.Location = new System.Drawing.Point(215, 134);
            this.lblEmpNameHint.Name = "lblEmpNameHint";
            this.lblEmpNameHint.Size = new System.Drawing.Size(41, 12);
            this.lblEmpNameHint.TabIndex = 17;
            this.lblEmpNameHint.Text = "label2";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(170, 130);
            this.txtEmpName.MaxLength = 2;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(40, 21);
            this.txtEmpName.TabIndex = 16;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(120, 134);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(41, 12);
            this.lblEmpName.TabIndex = 15;
            this.lblEmpName.Text = "label1";
            // 
            // chkEmpName
            // 
            this.chkEmpName.AutoSize = true;
            this.chkEmpName.Location = new System.Drawing.Point(10, 134);
            this.chkEmpName.Name = "chkEmpName";
            this.chkEmpName.Size = new System.Drawing.Size(78, 16);
            this.chkEmpName.TabIndex = 14;
            this.chkEmpName.Text = "checkBox1";
            this.chkEmpName.UseVisualStyleBackColor = true;
            this.chkEmpName.CheckedChanged += new System.EventHandler(this.chkEmpName_CheckedChanged);
            // 
            // lblEmpNoHint
            // 
            this.lblEmpNoHint.AutoSize = true;
            this.lblEmpNoHint.Location = new System.Drawing.Point(215, 104);
            this.lblEmpNoHint.Name = "lblEmpNoHint";
            this.lblEmpNoHint.Size = new System.Drawing.Size(41, 12);
            this.lblEmpNoHint.TabIndex = 13;
            this.lblEmpNoHint.Text = "label2";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(170, 100);
            this.txtEmpNo.MaxLength = 2;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(40, 21);
            this.txtEmpNo.TabIndex = 12;
            // 
            // lblEmpNo
            // 
            this.lblEmpNo.AutoSize = true;
            this.lblEmpNo.Location = new System.Drawing.Point(120, 104);
            this.lblEmpNo.Name = "lblEmpNo";
            this.lblEmpNo.Size = new System.Drawing.Size(41, 12);
            this.lblEmpNo.TabIndex = 11;
            this.lblEmpNo.Text = "label1";
            // 
            // chkEmpNo
            // 
            this.chkEmpNo.AutoSize = true;
            this.chkEmpNo.Location = new System.Drawing.Point(10, 104);
            this.chkEmpNo.Name = "chkEmpNo";
            this.chkEmpNo.Size = new System.Drawing.Size(78, 16);
            this.chkEmpNo.TabIndex = 10;
            this.chkEmpNo.Text = "checkBox1";
            this.chkEmpNo.UseVisualStyleBackColor = true;
            this.chkEmpNo.CheckedChanged += new System.EventHandler(this.chkEmpNo_CheckedChanged);
            // 
            // lblMacSNHint
            // 
            this.lblMacSNHint.AutoSize = true;
            this.lblMacSNHint.Location = new System.Drawing.Point(215, 74);
            this.lblMacSNHint.Name = "lblMacSNHint";
            this.lblMacSNHint.Size = new System.Drawing.Size(41, 12);
            this.lblMacSNHint.TabIndex = 9;
            this.lblMacSNHint.Text = "label2";
            // 
            // txtMacSN
            // 
            this.txtMacSN.Location = new System.Drawing.Point(170, 70);
            this.txtMacSN.MaxLength = 2;
            this.txtMacSN.Name = "txtMacSN";
            this.txtMacSN.Size = new System.Drawing.Size(40, 21);
            this.txtMacSN.TabIndex = 8;
            // 
            // lblMacSN
            // 
            this.lblMacSN.AutoSize = true;
            this.lblMacSN.Location = new System.Drawing.Point(120, 74);
            this.lblMacSN.Name = "lblMacSN";
            this.lblMacSN.Size = new System.Drawing.Size(41, 12);
            this.lblMacSN.TabIndex = 7;
            this.lblMacSN.Text = "label1";
            // 
            // chkMacSN
            // 
            this.chkMacSN.AutoSize = true;
            this.chkMacSN.Location = new System.Drawing.Point(10, 74);
            this.chkMacSN.Name = "chkMacSN";
            this.chkMacSN.Size = new System.Drawing.Size(78, 16);
            this.chkMacSN.TabIndex = 6;
            this.chkMacSN.Text = "checkBox1";
            this.chkMacSN.UseVisualStyleBackColor = true;
            this.chkMacSN.CheckedChanged += new System.EventHandler(this.chkMacSN_CheckedChanged);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(10, 50);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(41, 12);
            this.lblHint.TabIndex = 5;
            this.lblHint.Text = "label1";
            // 
            // txtSep
            // 
            this.txtSep.Location = new System.Drawing.Point(415, 20);
            this.txtSep.Name = "txtSep";
            this.txtSep.Size = new System.Drawing.Size(40, 21);
            this.txtSep.TabIndex = 4;
            // 
            // rbSepCustom
            // 
            this.rbSepCustom.AutoSize = true;
            this.rbSepCustom.Location = new System.Drawing.Point(310, 24);
            this.rbSepCustom.Name = "rbSepCustom";
            this.rbSepCustom.Size = new System.Drawing.Size(95, 16);
            this.rbSepCustom.TabIndex = 3;
            this.rbSepCustom.TabStop = true;
            this.rbSepCustom.Text = "radioButton3";
            this.rbSepCustom.UseVisualStyleBackColor = true;
            this.rbSepCustom.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbSepTAB
            // 
            this.rbSepTAB.AutoSize = true;
            this.rbSepTAB.Location = new System.Drawing.Point(215, 24);
            this.rbSepTAB.Name = "rbSepTAB";
            this.rbSepTAB.Size = new System.Drawing.Size(95, 16);
            this.rbSepTAB.TabIndex = 2;
            this.rbSepTAB.TabStop = true;
            this.rbSepTAB.Text = "radioButton2";
            this.rbSepTAB.UseVisualStyleBackColor = true;
            this.rbSepTAB.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbSepNo
            // 
            this.rbSepNo.AutoSize = true;
            this.rbSepNo.Location = new System.Drawing.Point(120, 24);
            this.rbSepNo.Name = "rbSepNo";
            this.rbSepNo.Size = new System.Drawing.Size(95, 16);
            this.rbSepNo.TabIndex = 1;
            this.rbSepNo.TabStop = true;
            this.rbSepNo.Text = "radioButton1";
            this.rbSepNo.UseVisualStyleBackColor = true;
            this.rbSepNo.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // lblSep
            // 
            this.lblSep.AutoSize = true;
            this.lblSep.Location = new System.Drawing.Point(10, 24);
            this.lblSep.Name = "lblSep";
            this.lblSep.Size = new System.Drawing.Size(41, 12);
            this.lblSep.TabIndex = 0;
            this.lblSep.Text = "label1";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(10, 293);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(41, 12);
            this.lblOrder.TabIndex = 19;
            this.lblOrder.Text = "label1";
            // 
            // chkOrder
            // 
            this.chkOrder.FormattingEnabled = true;
            this.chkOrder.IntegralHeight = false;
            this.chkOrder.ItemHeight = 12;
            this.chkOrder.Location = new System.Drawing.Point(80, 289);
            this.chkOrder.Name = "chkOrder";
            this.chkOrder.Size = new System.Drawing.Size(100, 65);
            this.chkOrder.TabIndex = 2;
            // 
            // btnOrderUp
            // 
            this.btnOrderUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrderUp.Image = global::Taurus.Properties.Resources.ArrowUp;
            this.btnOrderUp.Location = new System.Drawing.Point(185, 289);
            this.btnOrderUp.Name = "btnOrderUp";
            this.btnOrderUp.Size = new System.Drawing.Size(30, 30);
            this.btnOrderUp.TabIndex = 3;
            this.btnOrderUp.Text = "button1";
            this.btnOrderUp.Click += new System.EventHandler(this.btnOrderUp_Click);
            // 
            // btnOrderDown
            // 
            this.btnOrderDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrderDown.Image = global::Taurus.Properties.Resources.ArrowDown;
            this.btnOrderDown.Location = new System.Drawing.Point(185, 324);
            this.btnOrderDown.Name = "btnOrderDown";
            this.btnOrderDown.Size = new System.Drawing.Size(30, 30);
            this.btnOrderDown.TabIndex = 4;
            this.btnOrderDown.Text = "button1";
            this.btnOrderDown.Click += new System.EventHandler(this.btnOrderDown_Click);
            // 
            // btnShowFormat
            // 
            this.btnShowFormat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowFormat.Location = new System.Drawing.Point(230, 293);
            this.btnShowFormat.Name = "btnShowFormat";
            this.btnShowFormat.Size = new System.Drawing.Size(100, 25);
            this.btnShowFormat.TabIndex = 5;
            this.btnShowFormat.Text = "button1";
            this.btnShowFormat.Click += new System.EventHandler(this.btnShowFormat_Click);
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(230, 329);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.ReadOnly = true;
            this.txtFormat.Size = new System.Drawing.Size(395, 21);
            this.txtFormat.TabIndex = 6;
            // 
            // frmMacDataFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(634, 398);
            this.Controls.Add(this.txtFormat);
            this.Controls.Add(this.btnShowFormat);
            this.Controls.Add(this.btnOrderUp);
            this.Controls.Add(this.chkOrder);
            this.Controls.Add(this.btnOrderDown);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.chkAllow);
            this.Controls.Add(this.gbxFormat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMacDataFormat";
            this.Controls.SetChildIndex(this.gbxFormat, 0);
            this.Controls.SetChildIndex(this.chkAllow, 0);
            this.Controls.SetChildIndex(this.lblOrder, 0);
            this.Controls.SetChildIndex(this.btnOrderDown, 0);
            this.Controls.SetChildIndex(this.chkOrder, 0);
            this.Controls.SetChildIndex(this.btnOrderUp, 0);
            this.Controls.SetChildIndex(this.btnShowFormat, 0);
            this.Controls.SetChildIndex(this.txtFormat, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.gbxFormat.ResumeLayout(false);
            this.gbxFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox chkAllow;
    private System.Windows.Forms.GroupBox gbxFormat;
    private System.Windows.Forms.TextBox txtSep;
    private System.Windows.Forms.RadioButton rbSepCustom;
    private System.Windows.Forms.RadioButton rbSepTAB;
    private System.Windows.Forms.RadioButton rbSepNo;
    private System.Windows.Forms.Label lblSep;
    private System.Windows.Forms.Label lblMacSNHint;
    private System.Windows.Forms.TextBox txtMacSN;
    private System.Windows.Forms.Label lblMacSN;
    private System.Windows.Forms.CheckBox chkMacSN;
    private System.Windows.Forms.Label lblHint;
    private System.Windows.Forms.Label lblEmpNoHint;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label lblEmpNo;
    private System.Windows.Forms.CheckBox chkEmpNo;
    private System.Windows.Forms.Label lblEmpNameHint;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label lblEmpName;
    private System.Windows.Forms.CheckBox chkEmpName;
    private System.Windows.Forms.TextBox txtCardNo;
    private System.Windows.Forms.Label lblCardNo;
    private System.Windows.Forms.CheckBox chkCardNo;
    private System.Windows.Forms.TextBox txtDataTime;
    private System.Windows.Forms.Label lblDataTime;
    private System.Windows.Forms.CheckBox chkDataTime;
    private System.Windows.Forms.Label lblOrder;
    private System.Windows.Forms.ListBox chkOrder;
    private DevComponents.DotNetBar.ButtonX btnOrderUp;
    private DevComponents.DotNetBar.ButtonX btnOrderDown;
    private DevComponents.DotNetBar.ButtonX btnShowFormat;
    private System.Windows.Forms.TextBox txtFormat;
  }
}
