namespace Taurus
{
  partial class frmMacInfoAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMacInfoAdd));
            this.lblMacSN = new System.Windows.Forms.Label();
            this.txtMacSN = new System.Windows.Forms.TextBox();
            this.rbUSB = new System.Windows.Forms.RadioButton();
            this.rbLAN = new System.Windows.Forms.RadioButton();
            this.pnlLAN = new System.Windows.Forms.Panel();
            this.txtMacSeriesUserName = new System.Windows.Forms.TextBox();
            this.lbMacSeriesUserName = new System.Windows.Forms.Label();
            this.chkGPRS = new System.Windows.Forms.CheckBox();
            this.txtLANPWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLANPort = new System.Windows.Forms.TextBox();
            this.lblLANPort = new System.Windows.Forms.Label();
            this.txtLANIP = new System.Windows.Forms.TextBox();
            this.lblLANIP = new System.Windows.Forms.Label();
            this.btnTestConnect = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cbbMacType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbMacType = new System.Windows.Forms.Label();
            this.btnGetMacSN = new DevComponents.DotNetBar.ButtonX();
            this.cbbInOutMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbMsgGetMacNo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbMacMode = new System.Windows.Forms.Label();
            this.cbbMacMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnParentGroup = new DevComponents.DotNetBar.ButtonX();
            this.txtDevGroup = new System.Windows.Forms.TextBox();
            this.lbSelectGroup = new System.Windows.Forms.Label();
            this.pnlLAN.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(318, 375);
            this.btnOk.Size = new System.Drawing.Size(75, 24);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(399, 375);
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
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
            // lblMacSN
            // 
            this.lblMacSN.AutoSize = true;
            this.lblMacSN.Location = new System.Drawing.Point(6, 12);
            this.lblMacSN.Name = "lblMacSN";
            this.lblMacSN.Size = new System.Drawing.Size(41, 12);
            this.lblMacSN.TabIndex = 19;
            this.lblMacSN.Tag = "MacSN";
            this.lblMacSN.Text = "label1";
            // 
            // txtMacSN
            // 
            this.txtMacSN.Location = new System.Drawing.Point(96, 8);
            this.txtMacSN.MaxLength = 50;
            this.txtMacSN.Name = "txtMacSN";
            this.txtMacSN.Size = new System.Drawing.Size(120, 21);
            this.txtMacSN.TabIndex = 0;
            // 
            // rbUSB
            // 
            this.rbUSB.AutoSize = true;
            this.rbUSB.Checked = true;
            this.rbUSB.Location = new System.Drawing.Point(3, 106);
            this.rbUSB.Name = "rbUSB";
            this.rbUSB.Size = new System.Drawing.Size(95, 16);
            this.rbUSB.TabIndex = 2;
            this.rbUSB.TabStop = true;
            this.rbUSB.Text = "radioButton1";
            this.rbUSB.UseVisualStyleBackColor = true;
            this.rbUSB.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbLAN
            // 
            this.rbLAN.AutoSize = true;
            this.rbLAN.Location = new System.Drawing.Point(3, 127);
            this.rbLAN.Name = "rbLAN";
            this.rbLAN.Size = new System.Drawing.Size(95, 16);
            this.rbLAN.TabIndex = 6;
            this.rbLAN.Text = "radioButton1";
            this.rbLAN.UseVisualStyleBackColor = true;
            this.rbLAN.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // pnlLAN
            // 
            this.pnlLAN.Controls.Add(this.txtMacSeriesUserName);
            this.pnlLAN.Controls.Add(this.lbMacSeriesUserName);
            this.pnlLAN.Controls.Add(this.chkGPRS);
            this.pnlLAN.Controls.Add(this.txtLANPWD);
            this.pnlLAN.Controls.Add(this.label3);
            this.pnlLAN.Controls.Add(this.txtLANPort);
            this.pnlLAN.Controls.Add(this.lblLANPort);
            this.pnlLAN.Controls.Add(this.txtLANIP);
            this.pnlLAN.Controls.Add(this.lblLANIP);
            this.pnlLAN.Location = new System.Drawing.Point(6, 151);
            this.pnlLAN.Name = "pnlLAN";
            this.pnlLAN.Size = new System.Drawing.Size(451, 95);
            this.pnlLAN.TabIndex = 31;
            // 
            // txtMacSeriesUserName
            // 
            this.txtMacSeriesUserName.Location = new System.Drawing.Point(90, 34);
            this.txtMacSeriesUserName.Name = "txtMacSeriesUserName";
            this.txtMacSeriesUserName.Size = new System.Drawing.Size(120, 21);
            this.txtMacSeriesUserName.TabIndex = 12;
            // 
            // lbMacSeriesUserName
            // 
            this.lbMacSeriesUserName.AutoSize = true;
            this.lbMacSeriesUserName.Location = new System.Drawing.Point(-2, 37);
            this.lbMacSeriesUserName.Name = "lbMacSeriesUserName";
            this.lbMacSeriesUserName.Size = new System.Drawing.Size(41, 12);
            this.lbMacSeriesUserName.TabIndex = 11;
            this.lbMacSeriesUserName.Text = "label2";
            // 
            // chkGPRS
            // 
            this.chkGPRS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkGPRS.AutoSize = true;
            this.chkGPRS.Location = new System.Drawing.Point(232, 71);
            this.chkGPRS.Name = "chkGPRS";
            this.chkGPRS.Size = new System.Drawing.Size(78, 16);
            this.chkGPRS.TabIndex = 10;
            this.chkGPRS.Tag = "IsGPRS";
            this.chkGPRS.Text = "checkBox1";
            this.chkGPRS.UseVisualStyleBackColor = true;
            // 
            // txtLANPWD
            // 
            this.txtLANPWD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLANPWD.Location = new System.Drawing.Point(90, 67);
            this.txtLANPWD.MaxLength = 64;
            this.txtLANPWD.Name = "txtLANPWD";
            this.txtLANPWD.Size = new System.Drawing.Size(120, 21);
            this.txtLANPWD.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Tag = "";
            this.label3.Text = "label2";
            // 
            // txtLANPort
            // 
            this.txtLANPort.Location = new System.Drawing.Point(320, 0);
            this.txtLANPort.MaxLength = 6;
            this.txtLANPort.Name = "txtLANPort";
            this.txtLANPort.Size = new System.Drawing.Size(120, 21);
            this.txtLANPort.TabIndex = 8;
            // 
            // lblLANPort
            // 
            this.lblLANPort.AutoSize = true;
            this.lblLANPort.Location = new System.Drawing.Point(230, 4);
            this.lblLANPort.Name = "lblLANPort";
            this.lblLANPort.Size = new System.Drawing.Size(41, 12);
            this.lblLANPort.TabIndex = 2;
            this.lblLANPort.Tag = "MacPort";
            this.lblLANPort.Text = "label2";
            // 
            // txtLANIP
            // 
            this.txtLANIP.Location = new System.Drawing.Point(90, 0);
            this.txtLANIP.MaxLength = 50;
            this.txtLANIP.Name = "txtLANIP";
            this.txtLANIP.Size = new System.Drawing.Size(120, 21);
            this.txtLANIP.TabIndex = 7;
            // 
            // lblLANIP
            // 
            this.lblLANIP.AutoSize = true;
            this.lblLANIP.Location = new System.Drawing.Point(0, 4);
            this.lblLANIP.Name = "lblLANIP";
            this.lblLANIP.Size = new System.Drawing.Size(41, 12);
            this.lblLANIP.TabIndex = 0;
            this.lblLANIP.Tag = "MacIP";
            this.lblLANIP.Text = "label1";
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTestConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestConnect.Location = new System.Drawing.Point(9, 375);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(75, 24);
            this.btnTestConnect.TabIndex = 11;
            this.btnTestConnect.Text = "button1";
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Tag = "MacDesc";
            this.label1.Text = "label1";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDesc.Location = new System.Drawing.Point(96, 255);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(350, 21);
            this.txtDesc.TabIndex = 10;
            // 
            // cbbMacType
            // 
            this.cbbMacType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMacType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMacType.ForeColor = System.Drawing.Color.Black;
            this.cbbMacType.FormattingEnabled = true;
            this.cbbMacType.ItemHeight = 16;
            this.cbbMacType.Location = new System.Drawing.Point(326, 7);
            this.cbbMacType.Name = "cbbMacType";
            this.cbbMacType.Size = new System.Drawing.Size(131, 22);
            this.cbbMacType.TabIndex = 11;
            this.cbbMacType.SelectedIndexChanged += new System.EventHandler(this.cbbMacType_SelectedIndexChanged);
            // 
            // lbMacType
            // 
            this.lbMacType.AutoSize = true;
            this.lbMacType.Location = new System.Drawing.Point(236, 12);
            this.lbMacType.Name = "lbMacType";
            this.lbMacType.Size = new System.Drawing.Size(41, 12);
            this.lbMacType.TabIndex = 1002;
            this.lbMacType.Tag = "MacSeriesTypeName";
            this.lbMacType.Text = "label2";
            // 
            // btnGetMacSN
            // 
            this.btnGetMacSN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetMacSN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetMacSN.Location = new System.Drawing.Point(99, 375);
            this.btnGetMacSN.Name = "btnGetMacSN";
            this.btnGetMacSN.Size = new System.Drawing.Size(75, 24);
            this.btnGetMacSN.TabIndex = 1003;
            this.btnGetMacSN.Text = "button1";
            this.btnGetMacSN.Visible = false;
            this.btnGetMacSN.Click += new System.EventHandler(this.btnGetMacSN_Click);
            // 
            // cbbInOutMode
            // 
            this.cbbInOutMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbInOutMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbInOutMode.ForeColor = System.Drawing.Color.Black;
            this.cbbInOutMode.FormattingEnabled = true;
            this.cbbInOutMode.ItemHeight = 16;
            this.cbbInOutMode.Location = new System.Drawing.Point(326, 40);
            this.cbbInOutMode.Name = "cbbInOutMode";
            this.cbbInOutMode.Size = new System.Drawing.Size(131, 22);
            this.cbbInOutMode.TabIndex = 1004;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1005;
            this.label2.Tag = "InOutMode";
            this.label2.Text = "label2";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbMsgGetMacNo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(1, 322);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(482, 41);
            this.panel4.TabIndex = 1015;
            // 
            // lbMsgGetMacNo
            // 
            this.lbMsgGetMacNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMsgGetMacNo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbMsgGetMacNo.Location = new System.Drawing.Point(0, 0);
            this.lbMsgGetMacNo.Name = "lbMsgGetMacNo";
            this.lbMsgGetMacNo.Size = new System.Drawing.Size(482, 41);
            this.lbMsgGetMacNo.TabIndex = 0;
            this.lbMsgGetMacNo.Text = "label4";
            this.lbMsgGetMacNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(1, 363);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(482, 45);
            this.panel5.TabIndex = 1016;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbMacMode);
            this.panel6.Controls.Add(this.cbbMacMode);
            this.panel6.Controls.Add(this.btnParentGroup);
            this.panel6.Controls.Add(this.txtDevGroup);
            this.panel6.Controls.Add(this.lbSelectGroup);
            this.panel6.Controls.Add(this.txtMacSN);
            this.panel6.Controls.Add(this.lbMacType);
            this.panel6.Controls.Add(this.lblMacSN);
            this.panel6.Controls.Add(this.rbUSB);
            this.panel6.Controls.Add(this.rbLAN);
            this.panel6.Controls.Add(this.pnlLAN);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txtDesc);
            this.panel6.Controls.Add(this.cbbInOutMode);
            this.panel6.Controls.Add(this.cbbMacType);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(1, 31);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(482, 289);
            this.panel6.TabIndex = 1017;
            // 
            // lbMacMode
            // 
            this.lbMacMode.AutoSize = true;
            this.lbMacMode.Location = new System.Drawing.Point(6, 78);
            this.lbMacMode.Name = "lbMacMode";
            this.lbMacMode.Size = new System.Drawing.Size(41, 12);
            this.lbMacMode.TabIndex = 1011;
            this.lbMacMode.Tag = "";
            this.lbMacMode.Text = "label2";
            // 
            // cbbMacMode
            // 
            this.cbbMacMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMacMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMacMode.ForeColor = System.Drawing.Color.Black;
            this.cbbMacMode.FormattingEnabled = true;
            this.cbbMacMode.ItemHeight = 16;
            this.cbbMacMode.Location = new System.Drawing.Point(96, 73);
            this.cbbMacMode.Name = "cbbMacMode";
            this.cbbMacMode.Size = new System.Drawing.Size(120, 22);
            this.cbbMacMode.TabIndex = 1010;
            // 
            // btnParentGroup
            // 
            this.btnParentGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnParentGroup.Location = new System.Drawing.Point(187, 42);
            this.btnParentGroup.Name = "btnParentGroup";
            this.btnParentGroup.Size = new System.Drawing.Size(28, 19);
            this.btnParentGroup.TabIndex = 1009;
            this.btnParentGroup.Text = "button1";
            this.btnParentGroup.Click += new System.EventHandler(this.btnParentGroup_Click);
            // 
            // txtDevGroup
            // 
            this.txtDevGroup.Location = new System.Drawing.Point(96, 41);
            this.txtDevGroup.MaxLength = 50;
            this.txtDevGroup.Name = "txtDevGroup";
            this.txtDevGroup.Size = new System.Drawing.Size(120, 21);
            this.txtDevGroup.TabIndex = 1008;
            // 
            // lbSelectGroup
            // 
            this.lbSelectGroup.AutoSize = true;
            this.lbSelectGroup.Location = new System.Drawing.Point(6, 45);
            this.lbSelectGroup.Name = "lbSelectGroup";
            this.lbSelectGroup.Size = new System.Drawing.Size(41, 12);
            this.lbSelectGroup.TabIndex = 1007;
            this.lbSelectGroup.Tag = "";
            this.lbSelectGroup.Text = "label4";
            // 
            // frmMacInfoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(484, 409);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnGetMacSN);
            this.Controls.Add(this.btnTestConnect);
            this.Controls.Add(this.panel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMacInfoAdd";
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnTestConnect, 0);
            this.Controls.SetChildIndex(this.btnGetMacSN, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.pnlLAN.ResumeLayout(false);
            this.pnlLAN.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblMacSN;
    private System.Windows.Forms.TextBox txtMacSN;
    private System.Windows.Forms.RadioButton rbUSB;
    private System.Windows.Forms.RadioButton rbLAN;
    private System.Windows.Forms.Panel pnlLAN;
    private System.Windows.Forms.TextBox txtLANPort;
    private System.Windows.Forms.Label lblLANPort;
    private System.Windows.Forms.TextBox txtLANIP;
    private System.Windows.Forms.Label lblLANIP;
    private DevComponents.DotNetBar.ButtonX btnTestConnect;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.TextBox txtLANPWD;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox chkGPRS;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbMacType;
        private System.Windows.Forms.Label lbMacType;
        private DevComponents.DotNetBar.ButtonX btnGetMacSN;
        private System.Windows.Forms.TextBox txtMacSeriesUserName;
        private System.Windows.Forms.Label lbMacSeriesUserName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbInOutMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbMsgGetMacNo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private DevComponents.DotNetBar.ButtonX btnParentGroup;
        private System.Windows.Forms.TextBox txtDevGroup;
        private System.Windows.Forms.Label lbSelectGroup;
        private System.Windows.Forms.Label lbMacMode;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbMacMode;
    }
}
