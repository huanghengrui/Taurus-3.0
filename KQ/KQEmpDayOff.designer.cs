namespace Taurus
{
    partial class frmKQEmpDayOff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQEmpDayOff));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tvEmp
            // 
            this.tvEmp.LineColor = System.Drawing.Color.Black;
            this.tvEmp.Size = new System.Drawing.Size(200, 257);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 40);
            this.panel1.Size = new System.Drawing.Size(200, 257);
            // 
            // dispView
            // 
            this.dispView.Size = new System.Drawing.Size(350, 257);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(204, 40);
            this.pnlDisp.Size = new System.Drawing.Size(350, 257);
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // frmKQEmpDayOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(554, 328);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKQEmpDayOff";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

  }
}
