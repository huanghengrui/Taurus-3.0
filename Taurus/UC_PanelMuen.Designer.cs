namespace Taurus
{
    partial class UC_PanelMuen
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelMuen = new DevComponents.DotNetBar.PanelEx();
            this.barMuen = new System.Windows.Forms.Panel();
            this.btnAutoHide = new DevComponents.DotNetBar.LabelX();
            this.btnClosePanel = new DevComponents.DotNetBar.LabelX();
            this.labelItem = new DevComponents.DotNetBar.LabelX();
            this.splitterPanel = new System.Windows.Forms.Splitter();
            this.barMuen.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMuen
            // 
            this.PanelMuen.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelMuen.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PanelMuen.DisabledBackColor = System.Drawing.Color.Empty;
            this.PanelMuen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMuen.Location = new System.Drawing.Point(0, 26);
            this.PanelMuen.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMuen.MaximumSize = new System.Drawing.Size(1000, 0);
            this.PanelMuen.MinimumSize = new System.Drawing.Size(10, 0);
            this.PanelMuen.Name = "PanelMuen";
            this.PanelMuen.Size = new System.Drawing.Size(240, 637);
            this.PanelMuen.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelMuen.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelMuen.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelMuen.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelMuen.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelMuen.Style.GradientAngle = 90;
            this.PanelMuen.TabIndex = 61;
            // 
            // barMuen
            // 
            this.barMuen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.barMuen.Controls.Add(this.btnAutoHide);
            this.barMuen.Controls.Add(this.btnClosePanel);
            this.barMuen.Controls.Add(this.labelItem);
            this.barMuen.Dock = System.Windows.Forms.DockStyle.Top;
            this.barMuen.ForeColor = System.Drawing.Color.White;
            this.barMuen.Location = new System.Drawing.Point(0, 0);
            this.barMuen.Name = "barMuen";
            this.barMuen.Size = new System.Drawing.Size(240, 26);
            this.barMuen.TabIndex = 1;
            // 
            // btnAutoHide
            // 
            // 
            // 
            // 
            this.btnAutoHide.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnAutoHide.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAutoHide.ImageTextSpacing = 0;
            this.btnAutoHide.Location = new System.Drawing.Point(180, 0);
            this.btnAutoHide.Name = "btnAutoHide";
            this.btnAutoHide.PaddingLeft = 3;
            this.btnAutoHide.Size = new System.Drawing.Size(30, 26);
            this.btnAutoHide.Symbol = "58827";
            this.btnAutoHide.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnAutoHide.SymbolSize = 12F;
            this.btnAutoHide.TabIndex = 3;
            this.btnAutoHide.Click += new System.EventHandler(this.btnAutoHide_Click);
            this.btnAutoHide.MouseEnter += new System.EventHandler(this.LableX_MouseEnter);
            this.btnAutoHide.MouseLeave += new System.EventHandler(this.LableX_MouseLeave);
            // 
            // btnClosePanel
            // 
            // 
            // 
            // 
            this.btnClosePanel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnClosePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClosePanel.ImageTextSpacing = 0;
            this.btnClosePanel.Location = new System.Drawing.Point(210, 0);
            this.btnClosePanel.Name = "btnClosePanel";
            this.btnClosePanel.PaddingLeft = 3;
            this.btnClosePanel.Size = new System.Drawing.Size(30, 26);
            this.btnClosePanel.Symbol = "57676";
            this.btnClosePanel.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnClosePanel.SymbolSize = 12F;
            this.btnClosePanel.TabIndex = 4;
            this.btnClosePanel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnClosePanel.Click += new System.EventHandler(this.btnClosePanel_Click);
            this.btnClosePanel.MouseEnter += new System.EventHandler(this.LableX_MouseEnter);
            this.btnClosePanel.MouseLeave += new System.EventHandler(this.LableX_MouseLeave);
            // 
            // labelItem
            // 
            // 
            // 
            // 
            this.labelItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelItem.ImageTextSpacing = 6;
            this.labelItem.Location = new System.Drawing.Point(0, 0);
            this.labelItem.Name = "labelItem";
            this.labelItem.PaddingLeft = 10;
            this.labelItem.Size = new System.Drawing.Size(240, 26);
            this.labelItem.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.labelItem.TabIndex = 2;
            this.labelItem.Text = "labelX2";
            // 
            // splitterPanel
            // 
            this.splitterPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterPanel.Location = new System.Drawing.Point(240, 0);
            this.splitterPanel.Name = "splitterPanel";
            this.splitterPanel.Size = new System.Drawing.Size(3, 663);
            this.splitterPanel.TabIndex = 65;
            this.splitterPanel.TabStop = false;
            this.splitterPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseDown);
            this.splitterPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseMove);
            this.splitterPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseUp);
            // 
            // UC_PanelMuen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelMuen);
            this.Controls.Add(this.barMuen);
            this.Controls.Add(this.splitterPanel);
            this.MaximumSize = new System.Drawing.Size(1000, 0);
            this.Name = "UC_PanelMuen";
            this.Size = new System.Drawing.Size(243, 663);
            this.barMuen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.PanelEx PanelMuen;
        public System.Windows.Forms.Panel barMuen;
        public DevComponents.DotNetBar.LabelX labelItem;
        public DevComponents.DotNetBar.LabelX btnAutoHide;
        public DevComponents.DotNetBar.LabelX btnClosePanel;
        public System.Windows.Forms.Splitter splitterPanel;
    }
}
