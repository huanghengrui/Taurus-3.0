namespace Taurus
{
  partial class frmBaseMDIChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMDIChild));
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.ItemImport = new System.Windows.Forms.ToolStripButton();
            this.ItemExport = new System.Windows.Forms.ToolStripButton();
            this.ItemPrint = new System.Windows.Forms.ToolStripButton();
            this.ItemLine1 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemAdd = new System.Windows.Forms.ToolStripButton();
            this.ItemEdit = new System.Windows.Forms.ToolStripButton();
            this.ItemDelete = new System.Windows.Forms.ToolStripButton();
            this.ItemLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemTAG1 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG2 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG3 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG4 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG5 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG6 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG7 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAGExt = new System.Windows.Forms.ToolStripDropDownButton();
            this.ItemLine3 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemSelect = new System.Windows.Forms.ToolStripButton();
            this.ItemUnselect = new System.Windows.Forms.ToolStripButton();
            this.ItemLine4 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemRefresh = new System.Windows.Forms.ToolStripButton();
            this.ItemLine5 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemFindLabel = new System.Windows.Forms.ToolStripLabel();
            this.ItemFindText = new System.Windows.Forms.ToolStripTextBox();
            this.ItemLine6 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemZoomIn = new System.Windows.Forms.ToolStripButton();
            this.ItemZoomOut = new System.Windows.Forms.ToolStripButton();
            this.ItemLine7 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemClose = new System.Windows.Forms.ToolStripButton();
            this.labelStatus = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Statusbar = new DevComponents.DotNetBar.Bar();
            this.lblRecordState = new DevComponents.DotNetBar.LabelItem();
            this.progBar = new DevComponents.DotNetBar.ProgressBarItem();
            this.lblMsg = new DevComponents.DotNetBar.LabelItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lbTitlte = new System.Windows.Forms.Label();
            this.btnClosess = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.Toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).BeginInit();
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
            // bindingSource
            // 
            this.bindingSource.AllowNew = false;
            this.bindingSource.PositionChanged += new System.EventHandler(this.bindingSource_PositionChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // Toolbar
            // 
            this.Toolbar.BackColor = System.Drawing.Color.White;
            this.Toolbar.GripMargin = new System.Windows.Forms.Padding(0);
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemImport,
            this.ItemExport,
            this.ItemPrint,
            this.ItemLine1,
            this.ItemAdd,
            this.ItemEdit,
            this.ItemDelete,
            this.ItemLine2,
            this.ItemTAG1,
            this.ItemTAG2,
            this.ItemTAG3,
            this.ItemTAG4,
            this.ItemTAG5,
            this.ItemTAG6,
            this.ItemTAG7,
            this.ItemTAGExt,
            this.ItemLine3,
            this.ItemSelect,
            this.ItemUnselect,
            this.ItemLine4,
            this.ItemRefresh,
            this.ItemLine5,
            this.ItemFindLabel,
            this.ItemFindText,
            this.ItemLine6,
            this.ItemZoomIn,
            this.ItemZoomOut,
            this.ItemLine7,
            this.ItemClose});
            this.Toolbar.Location = new System.Drawing.Point(0, 31);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Padding = new System.Windows.Forms.Padding(0);
            this.Toolbar.Size = new System.Drawing.Size(593, 40);
            this.Toolbar.TabIndex = 0;
            this.Toolbar.Text = "Toolbar";
            // 
            // ItemImport
            // 
            this.ItemImport.Image = global::Taurus.Properties.Resources.Import;
            this.ItemImport.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemImport.Name = "ItemImport";
            this.ItemImport.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ItemImport.Size = new System.Drawing.Size(30, 37);
            this.ItemImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemImport.Click += new System.EventHandler(this.ItemImport_Click);
            // 
            // ItemExport
            // 
            this.ItemExport.Image = global::Taurus.Properties.Resources.Export;
            this.ItemExport.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemExport.Name = "ItemExport";
            this.ItemExport.Size = new System.Drawing.Size(23, 37);
            this.ItemExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemExport.Click += new System.EventHandler(this.ItemExport_Click);
            // 
            // ItemPrint
            // 
            this.ItemPrint.Image = global::Taurus.Properties.Resources.FilePrint;
            this.ItemPrint.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemPrint.Name = "ItemPrint";
            this.ItemPrint.Size = new System.Drawing.Size(23, 37);
            this.ItemPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemPrint.Click += new System.EventHandler(this.ItemPrint_Click);
            // 
            // ItemLine1
            // 
            this.ItemLine1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ItemLine1.Name = "ItemLine1";
            this.ItemLine1.Size = new System.Drawing.Size(6, 40);
            this.ItemLine1.Visible = false;
            // 
            // ItemAdd
            // 
            this.ItemAdd.Image = global::Taurus.Properties.Resources.AddBtn;
            this.ItemAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemAdd.Name = "ItemAdd";
            this.ItemAdd.Size = new System.Drawing.Size(23, 37);
            this.ItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemAdd.Click += new System.EventHandler(this.ItemAdd_Click);
            // 
            // ItemEdit
            // 
            this.ItemEdit.Image = global::Taurus.Properties.Resources.EditBtn;
            this.ItemEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemEdit.Name = "ItemEdit";
            this.ItemEdit.Size = new System.Drawing.Size(23, 37);
            this.ItemEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemEdit.Click += new System.EventHandler(this.ItemEdit_Click);
            // 
            // ItemDelete
            // 
            this.ItemDelete.Image = global::Taurus.Properties.Resources.DeleteBtn;
            this.ItemDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemDelete.Name = "ItemDelete";
            this.ItemDelete.Size = new System.Drawing.Size(23, 37);
            this.ItemDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemDelete.Click += new System.EventHandler(this.ItemDelete_Click);
            // 
            // ItemLine2
            // 
            this.ItemLine2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ItemLine2.Name = "ItemLine2";
            this.ItemLine2.Size = new System.Drawing.Size(6, 40);
            this.ItemLine2.Visible = false;
            // 
            // ItemTAG1
            // 
            this.ItemTAG1.Enabled = false;
            this.ItemTAG1.Image = global::Taurus.Properties.Resources.SignalLEDBlue;
            this.ItemTAG1.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG1.Name = "ItemTAG1";
            this.ItemTAG1.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG1.Visible = false;
            this.ItemTAG1.Click += new System.EventHandler(this.ItemTAG1_Click);
            // 
            // ItemTAG2
            // 
            this.ItemTAG2.Enabled = false;
            this.ItemTAG2.Image = global::Taurus.Properties.Resources.SignalLEDGreen;
            this.ItemTAG2.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG2.Name = "ItemTAG2";
            this.ItemTAG2.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG2.Visible = false;
            this.ItemTAG2.Click += new System.EventHandler(this.ItemTAG2_Click);
            // 
            // ItemTAG3
            // 
            this.ItemTAG3.Enabled = false;
            this.ItemTAG3.Image = global::Taurus.Properties.Resources.SignalLEDLtBlue;
            this.ItemTAG3.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG3.Name = "ItemTAG3";
            this.ItemTAG3.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG3.Visible = false;
            this.ItemTAG3.Click += new System.EventHandler(this.ItemTAG3_Click);
            // 
            // ItemTAG4
            // 
            this.ItemTAG4.Enabled = false;
            this.ItemTAG4.Image = global::Taurus.Properties.Resources.SignalLEDOrange;
            this.ItemTAG4.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG4.Name = "ItemTAG4";
            this.ItemTAG4.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG4.Visible = false;
            this.ItemTAG4.Click += new System.EventHandler(this.ItemTAG4_Click);
            // 
            // ItemTAG5
            // 
            this.ItemTAG5.Enabled = false;
            this.ItemTAG5.Image = global::Taurus.Properties.Resources.SignalLEDRed;
            this.ItemTAG5.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG5.Name = "ItemTAG5";
            this.ItemTAG5.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG5.Visible = false;
            this.ItemTAG5.Click += new System.EventHandler(this.ItemTAG5_Click);
            // 
            // ItemTAG6
            // 
            this.ItemTAG6.Enabled = false;
            this.ItemTAG6.Image = global::Taurus.Properties.Resources.SignalLEDViolet;
            this.ItemTAG6.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG6.Name = "ItemTAG6";
            this.ItemTAG6.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG6.Visible = false;
            this.ItemTAG6.Click += new System.EventHandler(this.ItemTAG6_Click);
            // 
            // ItemTAG7
            // 
            this.ItemTAG7.Enabled = false;
            this.ItemTAG7.Image = global::Taurus.Properties.Resources.SignalLEDYellow;
            this.ItemTAG7.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG7.Name = "ItemTAG7";
            this.ItemTAG7.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG7.Visible = false;
            this.ItemTAG7.Click += new System.EventHandler(this.ItemTAG7_Click);
            // 
            // ItemTAGExt
            // 
            this.ItemTAGExt.Enabled = false;
            this.ItemTAGExt.Image = global::Taurus.Properties.Resources.ToolsHammer;
            this.ItemTAGExt.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAGExt.Name = "ItemTAGExt";
            this.ItemTAGExt.Size = new System.Drawing.Size(29, 37);
            this.ItemTAGExt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAGExt.Visible = false;
            // 
            // ItemLine3
            // 
            this.ItemLine3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ItemLine3.Name = "ItemLine3";
            this.ItemLine3.Size = new System.Drawing.Size(6, 40);
            this.ItemLine3.Visible = false;
            // 
            // ItemSelect
            // 
            this.ItemSelect.Image = global::Taurus.Properties.Resources.EditSelectAll;
            this.ItemSelect.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemSelect.Name = "ItemSelect";
            this.ItemSelect.Size = new System.Drawing.Size(23, 37);
            this.ItemSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemSelect.Click += new System.EventHandler(this.ItemSelect_Click);
            // 
            // ItemUnselect
            // 
            this.ItemUnselect.Image = global::Taurus.Properties.Resources.EditUnSelectAll;
            this.ItemUnselect.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemUnselect.Name = "ItemUnselect";
            this.ItemUnselect.Size = new System.Drawing.Size(23, 37);
            this.ItemUnselect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemUnselect.Click += new System.EventHandler(this.ItemUnselect_Click);
            // 
            // ItemLine4
            // 
            this.ItemLine4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ItemLine4.Name = "ItemLine4";
            this.ItemLine4.Size = new System.Drawing.Size(6, 40);
            this.ItemLine4.Visible = false;
            // 
            // ItemRefresh
            // 
            this.ItemRefresh.Image = global::Taurus.Properties.Resources.DBRefresh;
            this.ItemRefresh.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemRefresh.Name = "ItemRefresh";
            this.ItemRefresh.Size = new System.Drawing.Size(23, 37);
            this.ItemRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemRefresh.Click += new System.EventHandler(this.ItemRefresh_Click);
            // 
            // ItemLine5
            // 
            this.ItemLine5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ItemLine5.Name = "ItemLine5";
            this.ItemLine5.Size = new System.Drawing.Size(6, 40);
            this.ItemLine5.Visible = false;
            // 
            // ItemFindLabel
            // 
            this.ItemFindLabel.Enabled = false;
            this.ItemFindLabel.Name = "ItemFindLabel";
            this.ItemFindLabel.Size = new System.Drawing.Size(96, 37);
            this.ItemFindLabel.Text = "toolStripLabel1";
            this.ItemFindLabel.Visible = false;
            // 
            // ItemFindText
            // 
            this.ItemFindText.AutoSize = false;
            this.ItemFindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemFindText.Enabled = false;
            this.ItemFindText.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ItemFindText.Name = "ItemFindText";
            this.ItemFindText.Size = new System.Drawing.Size(100, 23);
            this.ItemFindText.Visible = false;
            this.ItemFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemFindText_KeyDown);
            // 
            // ItemLine6
            // 
            this.ItemLine6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ItemLine6.Name = "ItemLine6";
            this.ItemLine6.Size = new System.Drawing.Size(6, 40);
            this.ItemLine6.Visible = false;
            // 
            // ItemZoomIn
            // 
            this.ItemZoomIn.Image = global::Taurus.Properties.Resources.ViewZoomIn;
            this.ItemZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemZoomIn.Name = "ItemZoomIn";
            this.ItemZoomIn.Size = new System.Drawing.Size(107, 37);
            this.ItemZoomIn.Text = "toolStripButton1";
            this.ItemZoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemZoomIn.Visible = false;
            this.ItemZoomIn.Click += new System.EventHandler(this.ItemZoomIn_Click);
            // 
            // ItemZoomOut
            // 
            this.ItemZoomOut.Image = global::Taurus.Properties.Resources.ViewZoomOut;
            this.ItemZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemZoomOut.Name = "ItemZoomOut";
            this.ItemZoomOut.Size = new System.Drawing.Size(107, 37);
            this.ItemZoomOut.Text = "toolStripButton2";
            this.ItemZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemZoomOut.Visible = false;
            this.ItemZoomOut.Click += new System.EventHandler(this.ItemZoomOut_Click);
            // 
            // ItemLine7
            // 
            this.ItemLine7.Name = "ItemLine7";
            this.ItemLine7.Size = new System.Drawing.Size(6, 40);
            this.ItemLine7.Visible = false;
            // 
            // ItemClose
            // 
            this.ItemClose.Image = global::Taurus.Properties.Resources.Exit;
            this.ItemClose.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemClose.Name = "ItemClose";
            this.ItemClose.Size = new System.Drawing.Size(107, 37);
            this.ItemClose.Text = "toolStripButton1";
            this.ItemClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemClose.Click += new System.EventHandler(this.ItemClose_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.PaddingLeft = 2;
            this.labelStatus.PaddingRight = 2;
            this.labelStatus.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.labelStatus.Stretch = true;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.PaddingLeft = 2;
            this.labelItem1.PaddingRight = 2;
            this.labelItem1.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.labelItem1.Stretch = true;
            // 
            // Statusbar
            // 
            this.Statusbar.AccessibleDescription = "DotNetBar Bar (Statusbar)";
            this.Statusbar.AccessibleName = "DotNetBar Bar";
            this.Statusbar.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.Statusbar.AntiAlias = true;
            this.Statusbar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.Statusbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Statusbar.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.Statusbar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Statusbar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
            this.Statusbar.IsMaximized = false;
            this.Statusbar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblRecordState,
            this.progBar,
            this.lblMsg});
            this.Statusbar.ItemSpacing = 2;
            this.Statusbar.Location = new System.Drawing.Point(0, 346);
            this.Statusbar.Name = "Statusbar";
            this.Statusbar.PaddingBottom = 0;
            this.Statusbar.PaddingTop = 0;
            this.Statusbar.Size = new System.Drawing.Size(593, 30);
            this.Statusbar.Stretch = true;
            this.Statusbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Statusbar.TabIndex = 2;
            this.Statusbar.TabStop = false;
            this.Statusbar.Text = "bar1";
            // 
            // lblRecordState
            // 
            this.lblRecordState.BorderSide = DevComponents.DotNetBar.eBorderSide.Right;
            this.lblRecordState.BorderType = DevComponents.DotNetBar.eBorderType.Raised;
            this.lblRecordState.Name = "lblRecordState";
            this.lblRecordState.PaddingLeft = 5;
            this.lblRecordState.PaddingRight = 5;
            this.lblRecordState.Text = "labelItem2";
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
            this.progBar.ChunkGradientAngle = 0F;
            this.progBar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.progBar.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.progBar.Name = "progBar";
            this.progBar.RecentlyUsed = false;
            // 
            // lblMsg
            // 
            this.lblMsg.BorderSide = DevComponents.DotNetBar.eBorderSide.Left;
            this.lblMsg.BorderType = DevComponents.DotNetBar.eBorderType.Sunken;
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.PaddingLeft = 5;
            this.lblMsg.PaddingRight = 5;
            this.lblMsg.Text = "labelItem3";
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
            this.panelEx1.Size = new System.Drawing.Size(593, 31);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.panelEx1.Style.BorderWidth = 0;
            this.panelEx1.Style.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1013;
            this.panelEx1.Visible = false;
            this.panelEx1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseDown);
            this.panelEx1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseMove);
            this.panelEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panTitle_MouseUp);
            // 
            // lbTitlte
            // 
            this.lbTitlte.AutoSize = true;
            this.lbTitlte.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitlte.ForeColor = System.Drawing.Color.White;
            this.lbTitlte.Location = new System.Drawing.Point(5, 9);
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
            this.btnClosess.Location = new System.Drawing.Point(554, 3);
            this.btnClosess.Name = "btnClosess";
            this.btnClosess.Size = new System.Drawing.Size(35, 25);
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
            // frmBaseMDIChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 376);
            this.Controls.Add(this.Statusbar);
            this.Controls.Add(this.Toolbar);
            this.Controls.Add(this.panelEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.Name = "frmBaseMDIChild";
            this.Text = "";
            this.Shown += new System.EventHandler(this.frmBaseMDIChild_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    protected System.Windows.Forms.ToolStripButton ItemExport;
    protected System.Windows.Forms.ToolStripButton ItemImport;
    protected System.Windows.Forms.ToolStripButton ItemPrint;
    protected System.Windows.Forms.ToolStripButton ItemAdd;
    protected System.Windows.Forms.ToolStripButton ItemEdit;
    protected System.Windows.Forms.ToolStripButton ItemDelete;
    protected System.Windows.Forms.ToolStripButton ItemTAG1;
    protected System.Windows.Forms.ToolStripButton ItemTAG2;
    protected System.Windows.Forms.ToolStripButton ItemTAG3;
    protected System.Windows.Forms.ToolStripButton ItemTAG4;
    protected System.Windows.Forms.ToolStripButton ItemTAG5;
    protected System.Windows.Forms.ToolStripButton ItemTAG6;
    protected System.Windows.Forms.ToolStripButton ItemTAG7;
    protected System.Windows.Forms.ToolStripButton ItemSelect;
    protected System.Windows.Forms.ToolStripButton ItemUnselect;
    protected System.Windows.Forms.ToolStripTextBox ItemFindText;
    protected System.Windows.Forms.ToolStrip Toolbar;
    protected System.Windows.Forms.ToolStripLabel ItemFindLabel;
    protected System.Windows.Forms.ToolStripDropDownButton ItemTAGExt;
    protected System.Windows.Forms.ToolStripButton ItemRefresh;
    protected System.Windows.Forms.BindingSource bindingSource;
    protected System.Windows.Forms.ContextMenuStrip contextMenu;
    private System.Windows.Forms.SaveFileDialog dlgSave;
    protected System.Windows.Forms.ToolStripButton ItemZoomIn;
    protected System.Windows.Forms.ToolStripButton ItemZoomOut;
    private System.Windows.Forms.ToolStripButton ItemClose;
        protected System.Windows.Forms.ToolStripSeparator ItemLine1;
        protected System.Windows.Forms.ToolStripSeparator ItemLine2;
        protected System.Windows.Forms.ToolStripSeparator ItemLine3;
        protected System.Windows.Forms.ToolStripSeparator ItemLine4;
        protected System.Windows.Forms.ToolStripSeparator ItemLine5;
        protected System.Windows.Forms.ToolStripSeparator ItemLine6;
        protected System.Windows.Forms.ToolStripSeparator ItemLine7;
        protected DevComponents.DotNetBar.LabelItem labelStatus;
        protected DevComponents.DotNetBar.LabelItem labelItem1;
        protected DevComponents.DotNetBar.Bar Statusbar;
        protected DevComponents.DotNetBar.LabelItem lblRecordState;
        protected DevComponents.DotNetBar.ProgressBarItem progBar;
        protected DevComponents.DotNetBar.LabelItem lblMsg;
        protected DevComponents.DotNetBar.PanelEx panelEx1;
        protected System.Windows.Forms.Label lbTitlte;
        protected DevComponents.DotNetBar.LabelX btnClosess;
    }
}
