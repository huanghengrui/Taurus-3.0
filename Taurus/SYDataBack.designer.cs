namespace Taurus
{
  partial class frmSYDataBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYDataBack));
            this.btnDBPath = new DevComponents.DotNetBar.ButtonX();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtBak = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(275, 139);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 139);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // btnDBPath
            // 
            this.btnDBPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDBPath.Location = new System.Drawing.Point(410, 111);
            this.btnDBPath.Name = "btnDBPath";
            this.btnDBPath.Size = new System.Drawing.Size(20, 20);
            this.btnDBPath.TabIndex = 17;
            this.btnDBPath.Text = ">";
            this.btnDBPath.Click += new System.EventHandler(this.btnDBPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(10, 111);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(395, 21);
            this.txtPath.TabIndex = 16;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 91);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(41, 12);
            this.Label4.TabIndex = 15;
            this.Label4.Text = "label1";
            // 
            // txtBak
            // 
            this.txtBak.Location = new System.Drawing.Point(10, 56);
            this.txtBak.MaxLength = 50;
            this.txtBak.Name = "txtBak";
            this.txtBak.Size = new System.Drawing.Size(395, 21);
            this.txtBak.TabIndex = 14;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(10, 36);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 12);
            this.Label3.TabIndex = 13;
            this.Label3.Text = "label1";
            // 
            // frmSYDataBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(439, 172);
            this.Controls.Add(this.btnDBPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtBak);
            this.Controls.Add(this.Label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSYDataBack";
            this.Controls.SetChildIndex(this.Label3, 0);
            this.Controls.SetChildIndex(this.txtBak, 0);
            this.Controls.SetChildIndex(this.Label4, 0);
            this.Controls.SetChildIndex(this.txtPath, 0);
            this.Controls.SetChildIndex(this.btnDBPath, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.ButtonX btnDBPath;
    private System.Windows.Forms.TextBox txtPath;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.TextBox txtBak;
    private System.Windows.Forms.Label Label3;
  }
}
