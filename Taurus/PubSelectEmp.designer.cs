namespace Taurus
{
  partial class frmPubSelectEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubSelectEmp));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tvEmp = new System.Windows.Forms.TreeView();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblQuickSearchToolTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(430, 459);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(510, 459);
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
            this.imgList.Images.SetKeyName(1, "USER_P2.BMP");
            // 
            // tvEmp
            // 
            this.tvEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvEmp.FullRowSelect = true;
            this.tvEmp.HideSelection = false;
            this.tvEmp.ImageIndex = 0;
            this.tvEmp.ImageList = this.imgList;
            this.tvEmp.ItemHeight = 20;
            this.tvEmp.Location = new System.Drawing.Point(10, 35);
            this.tvEmp.Name = "tvEmp";
            this.tvEmp.SelectedImageIndex = 0;
            this.tvEmp.Size = new System.Drawing.Size(575, 414);
            this.tvEmp.TabIndex = 0;
            this.tvEmp.DoubleClick += new System.EventHandler(this.tvEmp_DoubleClick);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFind.Location = new System.Drawing.Point(10, 459);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 21);
            this.txtFind.TabIndex = 1;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // lblQuickSearchToolTip
            // 
            this.lblQuickSearchToolTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQuickSearchToolTip.AutoSize = true;
            this.lblQuickSearchToolTip.Location = new System.Drawing.Point(115, 463);
            this.lblQuickSearchToolTip.Name = "lblQuickSearchToolTip";
            this.lblQuickSearchToolTip.Size = new System.Drawing.Size(41, 12);
            this.lblQuickSearchToolTip.TabIndex = 1003;
            this.lblQuickSearchToolTip.Text = "label1";
            // 
            // frmPubSelectEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(594, 492);
            this.Controls.Add(this.lblQuickSearchToolTip);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.tvEmp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPubSelectEmp";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.tvEmp, 0);
            this.Controls.SetChildIndex(this.txtFind, 0);
            this.Controls.SetChildIndex(this.lblQuickSearchToolTip, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imgList;
    private System.Windows.Forms.TreeView tvEmp;
    private System.Windows.Forms.TextBox txtFind;
    private System.Windows.Forms.Label lblQuickSearchToolTip;
  }
}
