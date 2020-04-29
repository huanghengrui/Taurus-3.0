namespace Taurus
{
  partial class frmSYDataRest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYDataRest));
            this.btnDBPath = new DevComponents.DotNetBar.ButtonX();
            this.txtBak = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(275, 90);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 90);
            this.btnCancel.TabIndex = 21;
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
            this.btnDBPath.Location = new System.Drawing.Point(410, 58);
            this.btnDBPath.Name = "btnDBPath";
            this.btnDBPath.Size = new System.Drawing.Size(20, 20);
            this.btnDBPath.TabIndex = 12;
            this.btnDBPath.Text = ">";
            this.btnDBPath.Click += new System.EventHandler(this.btnDBPath_Click);
            // 
            // txtBak
            // 
            this.txtBak.Location = new System.Drawing.Point(10, 58);
            this.txtBak.Name = "txtBak";
            this.txtBak.ReadOnly = true;
            this.txtBak.Size = new System.Drawing.Size(395, 21);
            this.txtBak.TabIndex = 11;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(10, 38);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 12);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "label1";
            // 
            // frmSYDataRest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(439, 123);
            this.Controls.Add(this.btnDBPath);
            this.Controls.Add(this.txtBak);
            this.Controls.Add(this.Label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSYDataRest";
            this.Controls.SetChildIndex(this.Label3, 0);
            this.Controls.SetChildIndex(this.txtBak, 0);
            this.Controls.SetChildIndex(this.btnDBPath, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.ButtonX btnDBPath;
    private System.Windows.Forms.TextBox txtBak;
    private System.Windows.Forms.Label Label3;
  }
}
