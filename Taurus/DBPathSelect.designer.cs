namespace Taurus
{
  partial class frmDBPathSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBPathSelect));
            this.tv = new System.Windows.Forms.TreeView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(230, 364);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(310, 364);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // tv
            // 
            this.tv.FullRowSelect = true;
            this.tv.HideSelection = false;
            this.tv.HotTracking = true;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.ImageList;
            this.tv.Location = new System.Drawing.Point(14, 36);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(375, 270);
            this.tv.TabIndex = 0;
            this.tv.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterCollapse);
            this.tv.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_BeforeExpand);
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Closed Folder_p4.bmp");
            this.ImageList.Images.SetKeyName(1, "Open Folder_p5.bmp");
            this.ImageList.Images.SetKeyName(2, "37_p5.bmp");
            this.ImageList.Images.SetKeyName(3, "Hard Drive_p5.bmp");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 312);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 12);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "label1";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 312);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 12);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "label1";
            // 
            // lblPath
            // 
            this.lblPath.AutoEllipsis = true;
            this.lblPath.Location = new System.Drawing.Point(10, 332);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(375, 25);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "label3";
            // 
            // frmDBPathSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(394, 397);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.tv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDBPathSelect";
            this.Controls.SetChildIndex(this.tv, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.lblPath, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView tv;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.Label lblPath;
    private System.Windows.Forms.ImageList ImageList;
  }
}
