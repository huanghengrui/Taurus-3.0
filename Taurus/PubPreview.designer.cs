namespace Taurus
{
  partial class frmPubPreview
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubPreview));
      this.Toolbar = new System.Windows.Forms.ToolStrip();
      this.ItemPrint = new System.Windows.Forms.ToolStripButton();
      this.ItemSetup = new System.Windows.Forms.ToolStripButton();
      this.ItemLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemZoomIn = new System.Windows.Forms.ToolStripButton();
      this.ItemZoomOut = new System.Windows.Forms.ToolStripButton();
      this.ItemLine2 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemFit = new System.Windows.Forms.ToolStripButton();
      this.ItemWidth = new System.Windows.Forms.ToolStripButton();
      this.ItemHeight = new System.Windows.Forms.ToolStripButton();
      this.ItemLine4 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemFirst = new System.Windows.Forms.ToolStripButton();
      this.ItemPrior = new System.Windows.Forms.ToolStripButton();
      this.ItemNext = new System.Windows.Forms.ToolStripButton();
      this.ItemLast = new System.Windows.Forms.ToolStripButton();
      this.ItemLine5 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemExit = new System.Windows.Forms.ToolStripButton();
      this.printView = new AxgrproLib.AxGRPrintViewer();
      this.Statusbar = new System.Windows.Forms.StatusStrip();
      this.lblRecordState = new System.Windows.Forms.ToolStripStatusLabel();
      this.Toolbar.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.printView)).BeginInit();
      this.Statusbar.SuspendLayout();
      this.SuspendLayout();
      // 
      // Toolbar
      // 
      this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemPrint,
            this.ItemSetup,
            this.ItemLine1,
            this.ItemZoomIn,
            this.ItemZoomOut,
            this.ItemLine2,
            this.ItemFit,
            this.ItemWidth,
            this.ItemHeight,
            this.ItemLine4,
            this.ItemFirst,
            this.ItemPrior,
            this.ItemNext,
            this.ItemLast,
            this.ItemLine5,
            this.ItemExit});
      this.Toolbar.Location = new System.Drawing.Point(0, 0);
      this.Toolbar.Name = "Toolbar";
      this.Toolbar.Size = new System.Drawing.Size(554, 35);
      this.Toolbar.TabIndex = 0;
      this.Toolbar.Text = "toolStrip1";
      // 
      // ItemPrint
      // 
      this.ItemPrint.Image = ((System.Drawing.Image)(resources.GetObject("ItemPrint.Image")));
      this.ItemPrint.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemPrint.Name = "ItemPrint";
      this.ItemPrint.Size = new System.Drawing.Size(105, 32);
      this.ItemPrint.Text = "toolStripButton1";
      this.ItemPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemPrint.Click += new System.EventHandler(this.ItemPrint_Click);
      // 
      // ItemSetup
      // 
      this.ItemSetup.Image = ((System.Drawing.Image)(resources.GetObject("ItemSetup.Image")));
      this.ItemSetup.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemSetup.Name = "ItemSetup";
      this.ItemSetup.Size = new System.Drawing.Size(105, 32);
      this.ItemSetup.Text = "toolStripButton1";
      this.ItemSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemSetup.Click += new System.EventHandler(this.ItemSetup_Click);
      // 
      // ItemLine1
      // 
      this.ItemLine1.Name = "ItemLine1";
      this.ItemLine1.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemZoomIn
      // 
      this.ItemZoomIn.Image = global::Taurus.Properties.Resources.ViewZoomIn;
      this.ItemZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemZoomIn.Name = "ItemZoomIn";
      this.ItemZoomIn.Size = new System.Drawing.Size(105, 32);
      this.ItemZoomIn.Text = "toolStripButton1";
      this.ItemZoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemZoomIn.Click += new System.EventHandler(this.ItemZoomIn_Click);
      // 
      // ItemZoomOut
      // 
      this.ItemZoomOut.Image = global::Taurus.Properties.Resources.ViewZoomOut;
      this.ItemZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemZoomOut.Name = "ItemZoomOut";
      this.ItemZoomOut.Size = new System.Drawing.Size(105, 32);
      this.ItemZoomOut.Text = "toolStripButton1";
      this.ItemZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemZoomOut.Click += new System.EventHandler(this.ItemZoomOut_Click);
      // 
      // ItemLine2
      // 
      this.ItemLine2.Name = "ItemLine2";
      this.ItemLine2.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemFit
      // 
      this.ItemFit.Checked = true;
      this.ItemFit.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ItemFit.Image = ((System.Drawing.Image)(resources.GetObject("ItemFit.Image")));
      this.ItemFit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemFit.Name = "ItemFit";
      this.ItemFit.Size = new System.Drawing.Size(105, 32);
      this.ItemFit.Text = "toolStripButton1";
      this.ItemFit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemFit.Click += new System.EventHandler(this.ItemFit_Click);
      // 
      // ItemWidth
      // 
      this.ItemWidth.Image = ((System.Drawing.Image)(resources.GetObject("ItemWidth.Image")));
      this.ItemWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemWidth.Name = "ItemWidth";
      this.ItemWidth.Size = new System.Drawing.Size(105, 32);
      this.ItemWidth.Text = "toolStripButton2";
      this.ItemWidth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemWidth.Click += new System.EventHandler(this.ItemWidth_Click);
      // 
      // ItemHeight
      // 
      this.ItemHeight.Image = ((System.Drawing.Image)(resources.GetObject("ItemHeight.Image")));
      this.ItemHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemHeight.Name = "ItemHeight";
      this.ItemHeight.Size = new System.Drawing.Size(105, 32);
      this.ItemHeight.Text = "toolStripButton3";
      this.ItemHeight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemHeight.Click += new System.EventHandler(this.ItemHeight_Click);
      // 
      // ItemLine4
      // 
      this.ItemLine4.Name = "ItemLine4";
      this.ItemLine4.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemFirst
      // 
      this.ItemFirst.Image = ((System.Drawing.Image)(resources.GetObject("ItemFirst.Image")));
      this.ItemFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemFirst.Name = "ItemFirst";
      this.ItemFirst.Size = new System.Drawing.Size(105, 32);
      this.ItemFirst.Text = "toolStripButton4";
      this.ItemFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemFirst.Click += new System.EventHandler(this.ItemFirst_Click);
      // 
      // ItemPrior
      // 
      this.ItemPrior.Image = ((System.Drawing.Image)(resources.GetObject("ItemPrior.Image")));
      this.ItemPrior.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemPrior.Name = "ItemPrior";
      this.ItemPrior.Size = new System.Drawing.Size(105, 32);
      this.ItemPrior.Text = "toolStripButton5";
      this.ItemPrior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemPrior.Click += new System.EventHandler(this.ItemPrior_Click);
      // 
      // ItemNext
      // 
      this.ItemNext.Image = ((System.Drawing.Image)(resources.GetObject("ItemNext.Image")));
      this.ItemNext.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemNext.Name = "ItemNext";
      this.ItemNext.Size = new System.Drawing.Size(105, 32);
      this.ItemNext.Text = "toolStripButton6";
      this.ItemNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemNext.Click += new System.EventHandler(this.ItemNext_Click);
      // 
      // ItemLast
      // 
      this.ItemLast.Image = ((System.Drawing.Image)(resources.GetObject("ItemLast.Image")));
      this.ItemLast.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemLast.Name = "ItemLast";
      this.ItemLast.Size = new System.Drawing.Size(105, 32);
      this.ItemLast.Text = "toolStripButton7";
      this.ItemLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemLast.Click += new System.EventHandler(this.ItemLast_Click);
      // 
      // ItemLine5
      // 
      this.ItemLine5.Name = "ItemLine5";
      this.ItemLine5.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemExit
      // 
      this.ItemExit.Image = ((System.Drawing.Image)(resources.GetObject("ItemExit.Image")));
      this.ItemExit.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemExit.Name = "ItemExit";
      this.ItemExit.Size = new System.Drawing.Size(105, 32);
      this.ItemExit.Text = "toolStripButton8";
      this.ItemExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemExit.Click += new System.EventHandler(this.ItemExit_Click);
      // 
      // printView
      // 
      this.printView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.printView.Enabled = true;
      this.printView.Location = new System.Drawing.Point(0, 35);
      this.printView.Name = "printView";
      this.printView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("printView.OcxState")));
      this.printView.Size = new System.Drawing.Size(554, 293);
      this.printView.TabIndex = 1;
      this.printView.StatusChange += new System.EventHandler(this.printView_StatusChange);
      // 
      // Statusbar
      // 
      this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRecordState});
      this.Statusbar.Location = new System.Drawing.Point(0, 302);
      this.Statusbar.Name = "Statusbar";
      this.Statusbar.Size = new System.Drawing.Size(554, 26);
      this.Statusbar.TabIndex = 2;
      this.Statusbar.Text = "Statusbar";
      // 
      // lblRecordState
      // 
      this.lblRecordState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.lblRecordState.Margin = new System.Windows.Forms.Padding(5);
      this.lblRecordState.Name = "lblRecordState";
      this.lblRecordState.Size = new System.Drawing.Size(135, 16);
      this.lblRecordState.Text = "toolStripStatusLabel1";
      // 
      // frmPubPreview
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(554, 328);
      this.Controls.Add(this.Statusbar);
      this.Controls.Add(this.printView);
      this.Controls.Add(this.Toolbar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = true;
      this.Name = "frmPubPreview";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "";
      this.Toolbar.ResumeLayout(false);
      this.Toolbar.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.printView)).EndInit();
      this.Statusbar.ResumeLayout(false);
      this.Statusbar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip Toolbar;
    private System.Windows.Forms.ToolStripButton ItemPrint;
    private System.Windows.Forms.ToolStripButton ItemSetup;
    private System.Windows.Forms.ToolStripSeparator ItemLine1;
    private System.Windows.Forms.ToolStripButton ItemZoomIn;
    private System.Windows.Forms.ToolStripButton ItemZoomOut;
    private System.Windows.Forms.ToolStripSeparator ItemLine2;
    private System.Windows.Forms.ToolStripButton ItemFit;
    private System.Windows.Forms.ToolStripButton ItemWidth;
    private System.Windows.Forms.ToolStripButton ItemHeight;
    private System.Windows.Forms.ToolStripSeparator ItemLine4;
    private System.Windows.Forms.ToolStripButton ItemFirst;
    private System.Windows.Forms.ToolStripButton ItemPrior;
    private System.Windows.Forms.ToolStripButton ItemNext;
    private System.Windows.Forms.ToolStripButton ItemLast;
    private System.Windows.Forms.ToolStripSeparator ItemLine5;
    private System.Windows.Forms.ToolStripButton ItemExit;
    private AxgrproLib.AxGRPrintViewer printView;
    protected System.Windows.Forms.StatusStrip Statusbar;
    protected System.Windows.Forms.ToolStripStatusLabel lblRecordState;
  }
}
