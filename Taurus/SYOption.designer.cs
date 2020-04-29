namespace Taurus
{
  partial class frmSYOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYOption));
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.rbReal = new System.Windows.Forms.RadioButton();
            this.txtTXTPath = new System.Windows.Forms.TextBox();
            this.btnSecletPatn = new DevComponents.DotNetBar.ButtonX();
            this.tabTxtSet = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.chkAttendancePhoto = new System.Windows.Forms.CheckBox();
            this.chkOutHrs = new System.Windows.Forms.CheckBox();
            this.chkUploadName = new System.Windows.Forms.CheckBox();
            this.chkExistDelete = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.rb34 = new System.Windows.Forms.RadioButton();
            this.rb26 = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWarning = new System.Windows.Forms.CheckBox();
            this.btnPath = new DevComponents.DotNetBar.ButtonX();
            this.tabPage2 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(279, 183);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 183);
            this.btnCancel.Text = "";
            // 
            // lbTitlte
            // 
            this.lbTitlte.BackColor = System.Drawing.Color.Transparent;
            this.lbTitlte.Size = new System.Drawing.Size(0, 13);
            this.lbTitlte.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(4, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 137);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro;
            this.tabControl1.TabIndex = 1009;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabPage1);
            this.tabControl1.Tabs.Add(this.tabPage2);
            this.tabControl1.Tabs.Add(this.tabPage3);
            this.tabControl1.Tabs.Add(this.tabTxtSet);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.dtTime);
            this.tabControlPanel4.Controls.Add(this.rbTime);
            this.tabControlPanel4.Controls.Add(this.rbReal);
            this.tabControlPanel4.Controls.Add(this.txtTXTPath);
            this.tabControlPanel4.Controls.Add(this.btnSecletPatn);
            this.tabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(443, 110);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 15;
            this.tabControlPanel4.TabItem = this.tabTxtSet;
            // 
            // dtTime
            // 
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTime.Location = new System.Drawing.Point(33, 52);
            this.dtTime.Name = "dtTime";
            this.dtTime.ShowUpDown = true;
            this.dtTime.Size = new System.Drawing.Size(232, 21);
            this.dtTime.TabIndex = 12;
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
            this.rbTime.BackColor = System.Drawing.Color.Transparent;
            this.rbTime.Location = new System.Drawing.Point(33, 27);
            this.rbTime.Name = "rbTime";
            this.rbTime.Size = new System.Drawing.Size(95, 16);
            this.rbTime.TabIndex = 11;
            this.rbTime.TabStop = true;
            this.rbTime.Text = "radioButton2";
            this.rbTime.UseVisualStyleBackColor = false;
            this.rbTime.CheckedChanged += new System.EventHandler(this.rbTime_CheckedChanged);
            // 
            // rbReal
            // 
            this.rbReal.AutoSize = true;
            this.rbReal.BackColor = System.Drawing.Color.Transparent;
            this.rbReal.Location = new System.Drawing.Point(33, 4);
            this.rbReal.Name = "rbReal";
            this.rbReal.Size = new System.Drawing.Size(95, 16);
            this.rbReal.TabIndex = 10;
            this.rbReal.TabStop = true;
            this.rbReal.Text = "radioButton1";
            this.rbReal.UseVisualStyleBackColor = false;
            // 
            // txtTXTPath
            // 
            this.txtTXTPath.Enabled = false;
            this.txtTXTPath.Location = new System.Drawing.Point(33, 79);
            this.txtTXTPath.Name = "txtTXTPath";
            this.txtTXTPath.Size = new System.Drawing.Size(232, 21);
            this.txtTXTPath.TabIndex = 8;
            // 
            // btnSecletPatn
            // 
            this.btnSecletPatn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSecletPatn.Location = new System.Drawing.Point(275, 79);
            this.btnSecletPatn.Name = "btnSecletPatn";
            this.btnSecletPatn.Size = new System.Drawing.Size(75, 23);
            this.btnSecletPatn.TabIndex = 9;
            this.btnSecletPatn.Text = "button1";
            this.btnSecletPatn.Click += new System.EventHandler(this.btnSecletPatn_Click);
            // 
            // tabTxtSet
            // 
            this.tabTxtSet.AttachedControl = this.tabControlPanel4;
            this.tabTxtSet.Name = "tabTxtSet";
            this.tabTxtSet.Text = "tabItem1";
            this.tabTxtSet.Visible = false;
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.panelEx2);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(443, 110);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabPage1;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.chkAttendancePhoto);
            this.panelEx2.Controls.Add(this.chkOutHrs);
            this.panelEx2.Controls.Add(this.chkUploadName);
            this.panelEx2.Controls.Add(this.chkExistDelete);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(1, 1);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(441, 108);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // chkAttendancePhoto
            // 
            this.chkAttendancePhoto.AutoSize = true;
            this.chkAttendancePhoto.Location = new System.Drawing.Point(17, 62);
            this.chkAttendancePhoto.Name = "chkAttendancePhoto";
            this.chkAttendancePhoto.Size = new System.Drawing.Size(78, 16);
            this.chkAttendancePhoto.TabIndex = 6;
            this.chkAttendancePhoto.Text = "checkBox1";
            this.chkAttendancePhoto.UseVisualStyleBackColor = true;
            // 
            // chkOutHrs
            // 
            this.chkOutHrs.AutoSize = true;
            this.chkOutHrs.Location = new System.Drawing.Point(17, 87);
            this.chkOutHrs.Name = "chkOutHrs";
            this.chkOutHrs.Size = new System.Drawing.Size(78, 16);
            this.chkOutHrs.TabIndex = 5;
            this.chkOutHrs.Tag = "OutHrs";
            this.chkOutHrs.Text = "checkBox1";
            this.chkOutHrs.UseVisualStyleBackColor = true;
            // 
            // chkUploadName
            // 
            this.chkUploadName.AutoSize = true;
            this.chkUploadName.Location = new System.Drawing.Point(17, 37);
            this.chkUploadName.Name = "chkUploadName";
            this.chkUploadName.Size = new System.Drawing.Size(78, 16);
            this.chkUploadName.TabIndex = 4;
            this.chkUploadName.Text = "checkBox1";
            this.chkUploadName.UseVisualStyleBackColor = true;
            // 
            // chkExistDelete
            // 
            this.chkExistDelete.AutoSize = true;
            this.chkExistDelete.Location = new System.Drawing.Point(17, 12);
            this.chkExistDelete.Name = "chkExistDelete";
            this.chkExistDelete.Size = new System.Drawing.Size(78, 16);
            this.chkExistDelete.TabIndex = 3;
            this.chkExistDelete.Text = "checkBox1";
            this.chkExistDelete.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.AttachedControl = this.tabControlPanel1;
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Text = "tabItem1";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.panelEx3);
            this.tabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(443, 110);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 9;
            this.tabControlPanel3.TabItem = this.tabPage3;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.rb34);
            this.panelEx3.Controls.Add(this.rb26);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(1, 1);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(441, 108);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 4;
            // 
            // rb34
            // 
            this.rb34.AutoSize = true;
            this.rb34.Location = new System.Drawing.Point(26, 53);
            this.rb34.Name = "rb34";
            this.rb34.Size = new System.Drawing.Size(95, 16);
            this.rb34.TabIndex = 3;
            this.rb34.TabStop = true;
            this.rb34.Text = "radioButton2";
            this.rb34.UseVisualStyleBackColor = true;
            // 
            // rb26
            // 
            this.rb26.AutoSize = true;
            this.rb26.Location = new System.Drawing.Point(26, 30);
            this.rb26.Name = "rb26";
            this.rb26.Size = new System.Drawing.Size(95, 16);
            this.rb26.TabIndex = 2;
            this.rb26.TabStop = true;
            this.rb26.Text = "radioButton1";
            this.rb26.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.AttachedControl = this.tabControlPanel3;
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Text = "tabItem3";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.panelEx4);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(443, 110);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 5;
            this.tabControlPanel2.TabItem = this.tabPage2;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.label2);
            this.panelEx4.Controls.Add(this.txtTime);
            this.panelEx4.Controls.Add(this.txtPath);
            this.panelEx4.Controls.Add(this.label1);
            this.panelEx4.Controls.Add(this.chkWarning);
            this.panelEx4.Controls.Add(this.btnPath);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx4.Location = new System.Drawing.Point(1, 1);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(441, 108);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(260, 56);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(72, 21);
            this.txtTime.TabIndex = 10;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(32, 24);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(236, 21);
            this.txtPath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // chkWarning
            // 
            this.chkWarning.AutoSize = true;
            this.chkWarning.Location = new System.Drawing.Point(32, 61);
            this.chkWarning.Name = "chkWarning";
            this.chkWarning.Size = new System.Drawing.Size(78, 16);
            this.chkWarning.TabIndex = 8;
            this.chkWarning.Text = "checkBox1";
            this.chkWarning.UseVisualStyleBackColor = true;
            // 
            // btnPath
            // 
            this.btnPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPath.Location = new System.Drawing.Point(295, 22);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(75, 23);
            this.btnPath.TabIndex = 7;
            this.btnPath.Text = "button1";
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.AttachedControl = this.tabControlPanel2;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Text = "tabItem2";
            // 
            // frmSYOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(457, 215);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSYOption";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.tabControlPanel4.PerformLayout();
            this.tabControlPanel1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.tabControlPanel3.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.tabControlPanel2.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog dlgOpen;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkWarning;
        private DevComponents.DotNetBar.ButtonX btnPath;
        private DevComponents.DotNetBar.TabItem tabPage2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.CheckBox chkAttendancePhoto;
        private System.Windows.Forms.CheckBox chkOutHrs;
        private System.Windows.Forms.CheckBox chkUploadName;
        private System.Windows.Forms.CheckBox chkExistDelete;
        private DevComponents.DotNetBar.TabItem tabPage1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.RadioButton rb34;
        private System.Windows.Forms.RadioButton rb26;
        private DevComponents.DotNetBar.TabItem tabPage3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.TextBox txtTXTPath;
        private DevComponents.DotNetBar.ButtonX btnSecletPatn;
        private DevComponents.DotNetBar.TabItem tabTxtSet;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.RadioButton rbReal;
        private System.Windows.Forms.DateTimePicker dtTime;
    }
}
