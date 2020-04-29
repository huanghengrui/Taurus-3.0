namespace Taurus
{
  partial class frmGZRule
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
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGZRule));
        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
        this.SuspendLayout();
        // 
        // imageList1
        // 
        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        this.imageList1.Images.SetKeyName(0, "T1.bmp");
        this.imageList1.Images.SetKeyName(1, "T2.bmp");
        // 
        // frmGZRule
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.ClientSize = new System.Drawing.Size(554, 328);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "frmGZRule";
        ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imageList1;
  }
}
