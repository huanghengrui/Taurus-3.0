namespace Taurus
{
  partial class frmDBConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBConnect));
            this.pnlMSSQL = new System.Windows.Forms.Panel();
            this.txtMSSQLUserPass = new System.Windows.Forms.TextBox();
            this.lblMSSQLUserPass = new System.Windows.Forms.Label();
            this.txtMSSQLUserName = new System.Windows.Forms.TextBox();
            this.lblMSSQLUserName = new System.Windows.Forms.Label();
            this.rbMSSQLSQL = new System.Windows.Forms.RadioButton();
            this.rbMSSQLWindowsNT = new System.Windows.Forms.RadioButton();
            this.lblMSSQLVerify = new System.Windows.Forms.Label();
            this.txtMSSQLServer = new System.Windows.Forms.TextBox();
            this.lblMSSQLServer = new System.Windows.Forms.Label();
            this.btnTest = new DevComponents.DotNetBar.ButtonX();
            this.pnlMSSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(305, 162);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(385, 162);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // pnlMSSQL
            // 
            this.pnlMSSQL.Controls.Add(this.txtMSSQLUserPass);
            this.pnlMSSQL.Controls.Add(this.lblMSSQLUserPass);
            this.pnlMSSQL.Controls.Add(this.txtMSSQLUserName);
            this.pnlMSSQL.Controls.Add(this.lblMSSQLUserName);
            this.pnlMSSQL.Controls.Add(this.rbMSSQLSQL);
            this.pnlMSSQL.Controls.Add(this.rbMSSQLWindowsNT);
            this.pnlMSSQL.Controls.Add(this.lblMSSQLVerify);
            this.pnlMSSQL.Controls.Add(this.txtMSSQLServer);
            this.pnlMSSQL.Controls.Add(this.lblMSSQLServer);
            this.pnlMSSQL.Location = new System.Drawing.Point(8, 41);
            this.pnlMSSQL.Name = "pnlMSSQL";
            this.pnlMSSQL.Size = new System.Drawing.Size(455, 115);
            this.pnlMSSQL.TabIndex = 3;
            // 
            // txtMSSQLUserPass
            // 
            this.txtMSSQLUserPass.Location = new System.Drawing.Point(350, 90);
            this.txtMSSQLUserPass.MaxLength = 50;
            this.txtMSSQLUserPass.Name = "txtMSSQLUserPass";
            this.txtMSSQLUserPass.Size = new System.Drawing.Size(100, 21);
            this.txtMSSQLUserPass.TabIndex = 10;
            this.txtMSSQLUserPass.UseSystemPasswordChar = true;
            // 
            // lblMSSQLUserPass
            // 
            this.lblMSSQLUserPass.AutoSize = true;
            this.lblMSSQLUserPass.Location = new System.Drawing.Point(280, 94);
            this.lblMSSQLUserPass.Name = "lblMSSQLUserPass";
            this.lblMSSQLUserPass.Size = new System.Drawing.Size(41, 12);
            this.lblMSSQLUserPass.TabIndex = 9;
            this.lblMSSQLUserPass.Text = "label8";
            // 
            // txtMSSQLUserName
            // 
            this.txtMSSQLUserName.Location = new System.Drawing.Point(160, 90);
            this.txtMSSQLUserName.MaxLength = 50;
            this.txtMSSQLUserName.Name = "txtMSSQLUserName";
            this.txtMSSQLUserName.Size = new System.Drawing.Size(100, 21);
            this.txtMSSQLUserName.TabIndex = 8;
            // 
            // lblMSSQLUserName
            // 
            this.lblMSSQLUserName.AutoSize = true;
            this.lblMSSQLUserName.Location = new System.Drawing.Point(90, 94);
            this.lblMSSQLUserName.Name = "lblMSSQLUserName";
            this.lblMSSQLUserName.Size = new System.Drawing.Size(41, 12);
            this.lblMSSQLUserName.TabIndex = 7;
            this.lblMSSQLUserName.Text = "label7";
            // 
            // rbMSSQLSQL
            // 
            this.rbMSSQLSQL.AutoSize = true;
            this.rbMSSQLSQL.Location = new System.Drawing.Point(90, 60);
            this.rbMSSQLSQL.Name = "rbMSSQLSQL";
            this.rbMSSQLSQL.Size = new System.Drawing.Size(95, 16);
            this.rbMSSQLSQL.TabIndex = 6;
            this.rbMSSQLSQL.TabStop = true;
            this.rbMSSQLSQL.Text = "radioButton2";
            this.rbMSSQLSQL.UseVisualStyleBackColor = true;
            this.rbMSSQLSQL.Click += new System.EventHandler(this.rbMSSQL_Click);
            // 
            // rbMSSQLWindowsNT
            // 
            this.rbMSSQLWindowsNT.AutoSize = true;
            this.rbMSSQLWindowsNT.Location = new System.Drawing.Point(90, 30);
            this.rbMSSQLWindowsNT.Name = "rbMSSQLWindowsNT";
            this.rbMSSQLWindowsNT.Size = new System.Drawing.Size(95, 16);
            this.rbMSSQLWindowsNT.TabIndex = 5;
            this.rbMSSQLWindowsNT.TabStop = true;
            this.rbMSSQLWindowsNT.Text = "radioButton1";
            this.rbMSSQLWindowsNT.UseVisualStyleBackColor = true;
            this.rbMSSQLWindowsNT.Click += new System.EventHandler(this.rbMSSQL_Click);
            // 
            // lblMSSQLVerify
            // 
            this.lblMSSQLVerify.AutoSize = true;
            this.lblMSSQLVerify.Location = new System.Drawing.Point(0, 34);
            this.lblMSSQLVerify.Name = "lblMSSQLVerify";
            this.lblMSSQLVerify.Size = new System.Drawing.Size(41, 12);
            this.lblMSSQLVerify.TabIndex = 4;
            this.lblMSSQLVerify.Text = "label6";
            // 
            // txtMSSQLServer
            // 
            this.txtMSSQLServer.Location = new System.Drawing.Point(90, 0);
            this.txtMSSQLServer.MaxLength = 100;
            this.txtMSSQLServer.Name = "txtMSSQLServer";
            this.txtMSSQLServer.Size = new System.Drawing.Size(200, 21);
            this.txtMSSQLServer.TabIndex = 3;
            // 
            // lblMSSQLServer
            // 
            this.lblMSSQLServer.AutoSize = true;
            this.lblMSSQLServer.Location = new System.Drawing.Point(0, 4);
            this.lblMSSQLServer.Name = "lblMSSQLServer";
            this.lblMSSQLServer.Size = new System.Drawing.Size(41, 12);
            this.lblMSSQLServer.TabIndex = 2;
            this.lblMSSQLServer.Text = "label5";
            // 
            // btnTest
            // 
            this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(10, 162);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 25);
            this.btnTest.TabIndex = 5;
            this.btnTest.Tag = "btnTestConnect";
            this.btnTest.Text = "button1";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmDBConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(469, 195);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.pnlMSSQL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDBConnect";
            this.Controls.SetChildIndex(this.pnlMSSQL, 0);
            this.Controls.SetChildIndex(this.btnTest, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlMSSQL.ResumeLayout(false);
            this.pnlMSSQL.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlMSSQL;
    private System.Windows.Forms.TextBox txtMSSQLServer;
    private System.Windows.Forms.Label lblMSSQLServer;
    private System.Windows.Forms.Label lblMSSQLVerify;
    private System.Windows.Forms.TextBox txtMSSQLUserPass;
    private System.Windows.Forms.Label lblMSSQLUserPass;
    private System.Windows.Forms.TextBox txtMSSQLUserName;
    private System.Windows.Forms.Label lblMSSQLUserName;
    private System.Windows.Forms.RadioButton rbMSSQLSQL;
    private System.Windows.Forms.RadioButton rbMSSQLWindowsNT;
    private DevComponents.DotNetBar.ButtonX btnTest;
  }
}
