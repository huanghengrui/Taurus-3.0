namespace Taurus
{
  partial class frmBaseMDIChildReportTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMDIChildReportTree));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.tvEmp = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(437, 319);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(200, 56);
            this.pnlDisp.MinimumSize = new System.Drawing.Size(100, 0);
            this.pnlDisp.Size = new System.Drawing.Size(437, 319);
            // 
            // Statusbar
            // 
            this.Statusbar.Location = new System.Drawing.Point(0, 375);
            this.Statusbar.Size = new System.Drawing.Size(637, 30);
            // 
            // lblRecordState
            // 
            this.lblRecordState.Text = "";
            // 
            // progBar
            // 
            // 
            // 
            // 
            this.progBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progBar.BackStyle.MarginLeft = 5;
            this.progBar.BackStyle.MarginRight = 5;
            this.progBar.BackStyle.PaddingLeft = 5;
            this.progBar.BackStyle.PaddingRight = 5;
            // 
            // lblMsg
            // 
            this.lblMsg.Text = "0:0:0.0";
            // 
            // panelEx1
            // 
            this.panelEx1.Location = new System.Drawing.Point(0, 25);
            this.panelEx1.Size = new System.Drawing.Size(637, 31);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.panelEx1.Style.BorderWidth = 0;
            this.panelEx1.Style.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // lbTitlte
            // 
            this.lbTitlte.BackColor = System.Drawing.Color.Transparent;
            this.lbTitlte.Size = new System.Drawing.Size(0, 13);
            this.lbTitlte.Text = "";
            // 
            // btnClosess
            // 
            this.btnClosess.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.btnClosess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnClosess.Location = new System.Drawing.Point(598, 3);
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
            this.imgList.TransparentColor = System.Drawing.Color.White;
            this.imgList.Images.SetKeyName(0, "REPORTL_p2.bmp");
            this.imgList.Images.SetKeyName(1, "USER_P2.BMP");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter);
            this.panel1.Controls.Add(this.tvEmp);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.MaximumSize = new System.Drawing.Size(1000, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 319);
            this.panel1.TabIndex = 9;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter.Location = new System.Drawing.Point(197, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 319);
            this.splitter.TabIndex = 10;
            this.splitter.TabStop = false;
            this.splitter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseDown);
            this.splitter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseMove);
            this.splitter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseUp);
            // 
            // tvEmp
            // 
            this.tvEmp.BackColor = System.Drawing.Color.White;
            this.tvEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEmp.FullRowSelect = true;
            this.tvEmp.HideSelection = false;
            this.tvEmp.ImageIndex = 0;
            this.tvEmp.ImageList = this.imgList;
            this.tvEmp.ItemHeight = 20;
            this.tvEmp.Location = new System.Drawing.Point(0, 0);
            this.tvEmp.Name = "tvEmp";
            this.tvEmp.SelectedImageIndex = 0;
            this.tvEmp.Size = new System.Drawing.Size(200, 319);
            this.tvEmp.TabIndex = 9;
            this.tvEmp.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvEmp_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 0);
            this.panel2.TabIndex = 0;
            // 
            // frmBaseMDIChildReportTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(637, 405);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBaseMDIChildReportTree";
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.Controls.SetChildIndex(this.Statusbar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imgList;
    protected System.Windows.Forms.TreeView tvEmp;
    protected System.Windows.Forms.Panel panel1;
    protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Splitter splitter;
    }
}
