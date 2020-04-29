namespace Taurus
{
  partial class frmBaseMDIChildTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMDIChildTree));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tvEmp = new System.Windows.Forms.TreeView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.spl = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Statusbar
            // 
            this.Statusbar.Location = new System.Drawing.Point(0, 365);
            this.Statusbar.Size = new System.Drawing.Size(644, 30);
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
            this.lblMsg.Text = "";
            // 
            // panelEx1
            // 
            this.panelEx1.Location = new System.Drawing.Point(0, 25);
            this.panelEx1.Size = new System.Drawing.Size(644, 31);
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
            this.btnClosess.Location = new System.Drawing.Point(581, 3);
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
            // tvEmp
            // 
            this.tvEmp.BackColor = System.Drawing.Color.White;
            this.tvEmp.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvEmp.FullRowSelect = true;
            this.tvEmp.HideSelection = false;
            this.tvEmp.ImageIndex = 0;
            this.tvEmp.ImageList = this.imgList;
            this.tvEmp.ItemHeight = 20;
            this.tvEmp.Location = new System.Drawing.Point(0, 56);
            this.tvEmp.Name = "tvEmp";
            this.tvEmp.SelectedImageIndex = 0;
            this.tvEmp.Size = new System.Drawing.Size(200, 309);
            this.tvEmp.TabIndex = 5;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(204, 56);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(440, 309);
            this.pnlRight.TabIndex = 7;
            // 
            // spl
            // 
            this.spl.Location = new System.Drawing.Point(200, 56);
            this.spl.Name = "spl";
            this.spl.Size = new System.Drawing.Size(4, 309);
            this.spl.TabIndex = 6;
            this.spl.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(34, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 79);
            this.panel1.TabIndex = 8;
            // 
            // frmBaseMDIChildTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(644, 395);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.spl);
            this.Controls.Add(this.tvEmp);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaseMDIChildTree";
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.Controls.SetChildIndex(this.Statusbar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tvEmp, 0);
            this.Controls.SetChildIndex(this.spl, 0);
            this.Controls.SetChildIndex(this.pnlRight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imgList;
    protected System.Windows.Forms.TreeView tvEmp;
    protected System.Windows.Forms.Panel pnlRight;
        protected System.Windows.Forms.Splitter spl;
        private System.Windows.Forms.Panel panel1;
    }
}
