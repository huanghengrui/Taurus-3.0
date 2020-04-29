namespace Taurus
{
  partial class frmPubSelectDepart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubSelectDepart));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tvDepart = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(230, 368);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(310, 368);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Silver;
            this.imgList.Images.SetKeyName(0, "REPORTL_p2.bmp");
            // 
            // tvDepart
            // 
            this.tvDepart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDepart.FullRowSelect = true;
            this.tvDepart.HideSelection = false;
            this.tvDepart.ImageIndex = 0;
            this.tvDepart.ImageList = this.imgList;
            this.tvDepart.ItemHeight = 20;
            this.tvDepart.Location = new System.Drawing.Point(10, 35);
            this.tvDepart.Name = "tvDepart";
            this.tvDepart.SelectedImageIndex = 0;
            this.tvDepart.Size = new System.Drawing.Size(375, 323);
            this.tvDepart.TabIndex = 0;
            this.tvDepart.DoubleClick += new System.EventHandler(this.tvDepart_DoubleClick);
            // 
            // frmPubSelectDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(394, 401);
            this.Controls.Add(this.tvDepart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPubSelectDepart";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.tvDepart, 0);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList imgList;
    private System.Windows.Forms.TreeView tvDepart;
  }
}
