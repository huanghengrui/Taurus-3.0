namespace Taurus
{
  partial class frmGZRule
  {
    /// <summary>
    /// ����������������
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// ������������ʹ�õ���Դ��
    /// </summary>
    /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows ������������ɵĴ���

    /// <summary>
    /// �����֧������ķ��� - ��Ҫ
    /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
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
