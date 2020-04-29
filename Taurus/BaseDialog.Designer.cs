namespace Taurus
{
  partial class frmBaseDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseDialog));
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lbTitlte = new System.Windows.Forms.Label();
            this.btnClosess = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(390, 295);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 1000;
            this.btnOk.Text = "button1";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(470, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 1001;
            this.btnCancel.Text = "button2";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.Color.Transparent;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lbTitlte);
            this.panelEx1.Controls.Add(this.btnClosess);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(554, 31);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.panelEx1.Style.BorderWidth = 0;
            this.panelEx1.Style.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1005;
            this.panelEx1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseDown);
            this.panelEx1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseMove);
            this.panelEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseUp);
            // 
            // lbTitlte
            // 
            this.lbTitlte.AutoSize = true;
            this.lbTitlte.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitlte.ForeColor = System.Drawing.Color.White;
            this.lbTitlte.Location = new System.Drawing.Point(6, 9);
            this.lbTitlte.Name = "lbTitlte";
            this.lbTitlte.Size = new System.Drawing.Size(63, 13);
            this.lbTitlte.TabIndex = 2;
            this.lbTitlte.Text = "考勤软件";
            // 
            // btnClosess
            // 
            this.btnClosess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.btnClosess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnClosess.Location = new System.Drawing.Point(519, 3);
            this.btnClosess.Name = "btnClosess";
            this.btnClosess.Size = new System.Drawing.Size(30, 25);
            this.btnClosess.Symbol = "57676";
            this.btnClosess.SymbolColor = System.Drawing.Color.White;
            this.btnClosess.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnClosess.SymbolSize = 15F;
            this.btnClosess.TabIndex = 1;
            this.btnClosess.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnClosess.Click += new System.EventHandler(this.btnClosess_Click);
            this.btnClosess.MouseEnter += new System.EventHandler(this.btnClosess_MouseEnter);
            this.btnClosess.MouseLeave += new System.EventHandler(this.btnClosess_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 297);
            this.panel1.TabIndex = 1009;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 1);
            this.panel2.TabIndex = 1010;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(553, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 296);
            this.panel3.TabIndex = 1011;
            // 
            // frmBaseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(554, 328);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaseDialog";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmBaseDialog_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

    }

        #endregion

        public DevComponents.DotNetBar.ButtonX btnOk;
        public DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        protected System.Windows.Forms.Label lbTitlte;
        private DevComponents.DotNetBar.LabelX btnClosess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
