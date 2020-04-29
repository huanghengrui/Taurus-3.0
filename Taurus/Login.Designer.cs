namespace Taurus
{
  partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbbOpter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.chkPass = new System.Windows.Forms.CheckBox();
            this.btnConnect = new DevComponents.DotNetBar.ButtonX();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(313, 218);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(393, 218);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(204, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 28);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbOpter
            // 
            this.cbbOpter.DisplayMember = "Text";
            this.cbbOpter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbOpter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOpter.ForeColor = System.Drawing.Color.Black;
            this.cbbOpter.FormattingEnabled = true;
            this.cbbOpter.ItemHeight = 15;
            this.cbbOpter.Location = new System.Drawing.Point(252, 70);
            this.cbbOpter.Name = "cbbOpter";
            this.cbbOpter.Size = new System.Drawing.Size(200, 21);
            this.cbbOpter.TabIndex = 5;
            this.cbbOpter.ValueMember = "Value";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(182, 70);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 12);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "label1";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(182, 111);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 12);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "label1";
            // 
            // chkPass
            // 
            this.chkPass.AutoSize = true;
            this.chkPass.BackColor = System.Drawing.Color.Transparent;
            this.chkPass.ForeColor = System.Drawing.Color.Black;
            this.chkPass.Location = new System.Drawing.Point(252, 136);
            this.chkPass.Name = "chkPass";
            this.chkPass.Size = new System.Drawing.Size(78, 16);
            this.chkPass.TabIndex = 8;
            this.chkPass.Text = "checkBox1";
            this.chkPass.UseVisualStyleBackColor = false;
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.BackColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(178, 218);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 25);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "button1";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(252, 107);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(200, 21);
            this.txtPass.TabIndex = 7;
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.Location = new System.Drawing.Point(232, 36);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(225, 15);
            this.lblVersion.TabIndex = 20;
            this.lblVersion.Text = "label1";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // lblHint
            // 
            this.lblHint.BackColor = System.Drawing.Color.Transparent;
            this.lblHint.ForeColor = System.Drawing.Color.Black;
            this.lblHint.Location = new System.Drawing.Point(184, 159);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(268, 13);
            this.lblHint.TabIndex = 22;
            this.lblHint.Text = "label4";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Taurus.Properties.Resources.login;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblHint);
            this.panel1.Controls.Add(this.cbbOpter);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.chkPass);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 221);
            this.panel1.TabIndex = 1009;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(481, 253);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.ShowInTaskbar = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnConnect, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cbbOpter;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.CheckBox chkPass;
    private DevComponents.DotNetBar.ButtonX btnConnect;
    private System.Windows.Forms.TextBox txtPass;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel panel1;
    }
}
