namespace Taurus
{
  partial class frmRSDepart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRSDepart));
            this.tvDepart = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // tvDepart
            // 
            this.tvDepart.ContextMenuStrip = this.contextMenu;
            this.tvDepart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDepart.FullRowSelect = true;
            this.tvDepart.HideSelection = false;
            this.tvDepart.ImageIndex = 0;
            this.tvDepart.ImageList = this.imgList;
            this.tvDepart.ItemHeight = 20;
            this.tvDepart.Location = new System.Drawing.Point(0, 25);
            this.tvDepart.Name = "tvDepart";
            this.tvDepart.SelectedImageIndex = 0;
            this.tvDepart.Size = new System.Drawing.Size(709, 409);
            this.tvDepart.TabIndex = 3;
            this.tvDepart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDepart_AfterSelect);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Silver;
            this.imgList.Images.SetKeyName(0, "REPORTL_p2.bmp");
            // 
            // frmRSDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(709, 465);
            this.Controls.Add(this.tvDepart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRSDepart";
            this.Controls.SetChildIndex(this.tvDepart, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView tvDepart;
    private System.Windows.Forms.ImageList imgList;

  }
}
