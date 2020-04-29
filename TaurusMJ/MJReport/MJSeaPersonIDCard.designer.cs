namespace Taurus
{
  partial class frmMJSeaPersonIDCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJSeaPersonIDCard));
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectMacSN = new DevComponents.DotNetBar.ButtonX();
            this.txtMacSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAlarmLog = new DevComponents.DotNetBar.ButtonX();
            this.btnAccessLog = new DevComponents.DotNetBar.ButtonX();
            this.txtInOutMode = new System.Windows.Forms.TextBox();
            this.picData = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtInOutMode);
            this.panel1.Controls.Add(this.btnAlarmLog);
            this.panel1.Controls.Add(this.btnAccessLog);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSelectMacSN);
            this.panel1.Controls.Add(this.txtMacSN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtEmp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picData);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Size = new System.Drawing.Size(220, 501);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(497, 501);
            this.dispView.SelectionCellChange += new AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEventHandler(this.dispView_SelectionCellChange);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(220, 71);
            this.pnlDisp.Size = new System.Drawing.Size(497, 501);
            // 
            // Statusbar
            // 
            this.Statusbar.Location = new System.Drawing.Point(0, 572);
            this.Statusbar.Size = new System.Drawing.Size(717, 30);
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
            // panelEx1
            // 
            this.panelEx1.Location = new System.Drawing.Point(0, 40);
            this.panelEx1.Size = new System.Drawing.Size(717, 31);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.panelEx1.Style.BorderWidth = 0;
            this.panelEx1.Style.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // btnClosess
            // 
            // 
            // 
            // 
            this.btnClosess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnClosess.Location = new System.Drawing.Point(675, 3);
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(70, 35);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(140, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(70, 10);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 21);
            this.dtpStart.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 32;
            this.label4.Tag = "KQDateTime";
            this.label4.Text = "label4";
            // 
            // btnSelectMacSN
            // 
            this.btnSelectMacSN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectMacSN.Location = new System.Drawing.Point(174, 113);
            this.btnSelectMacSN.Name = "btnSelectMacSN";
            this.btnSelectMacSN.Size = new System.Drawing.Size(35, 20);
            this.btnSelectMacSN.TabIndex = 70;
            this.btnSelectMacSN.Tag = "btnSelectEmp";
            this.btnSelectMacSN.Text = "button1";
            this.btnSelectMacSN.Click += new System.EventHandler(this.btnSelectMacSN_Click);
            // 
            // txtMacSN
            // 
            this.txtMacSN.Location = new System.Drawing.Point(70, 112);
            this.txtMacSN.Name = "txtMacSN";
            this.txtMacSN.Size = new System.Drawing.Size(139, 21);
            this.txtMacSN.TabIndex = 69;
            this.txtMacSN.TextChanged += new System.EventHandler(this.txtMacSN_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 68;
            this.label3.Tag = "MacSN";
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(70, 76);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(140, 21);
            this.txtEmp.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 67;
            this.label1.Tag = "Emp";
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 71;
            this.label2.Tag = "InOutMode";
            this.label2.Text = "label2";
            // 
            // btnAlarmLog
            // 
            this.btnAlarmLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAlarmLog.Location = new System.Drawing.Point(101, 484);
            this.btnAlarmLog.Name = "btnAlarmLog";
            this.btnAlarmLog.Size = new System.Drawing.Size(85, 23);
            this.btnAlarmLog.TabIndex = 77;
            this.btnAlarmLog.Text = "button2";
            this.btnAlarmLog.Visible = false;
            this.btnAlarmLog.Click += new System.EventHandler(this.btnAlarmLog_Click);
            // 
            // btnAccessLog
            // 
            this.btnAccessLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccessLog.Location = new System.Drawing.Point(10, 484);
            this.btnAccessLog.Name = "btnAccessLog";
            this.btnAccessLog.Size = new System.Drawing.Size(85, 23);
            this.btnAccessLog.TabIndex = 76;
            this.btnAccessLog.Text = "button1";
            this.btnAccessLog.Visible = false;
            this.btnAccessLog.Click += new System.EventHandler(this.btnAccessLog_Click);
            // 
            // txtInOutMode
            // 
            this.txtInOutMode.Location = new System.Drawing.Point(70, 152);
            this.txtInOutMode.Multiline = true;
            this.txtInOutMode.Name = "txtInOutMode";
            this.txtInOutMode.Size = new System.Drawing.Size(138, 20);
            this.txtInOutMode.TabIndex = 80;
            // 
            // picData
            // 
            this.picData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picData.Location = new System.Drawing.Point(10, 205);
            this.picData.Name = "picData";
            this.picData.Size = new System.Drawing.Size(200, 257);
            this.picData.TabIndex = 52;
            this.picData.TabStop = false;
            // 
            // frmMJSeaPersonIDCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(717, 602);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJSeaPersonIDCard";
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.Controls.SetChildIndex(this.Statusbar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnSelectMacSN;
        private System.Windows.Forms.TextBox txtMacSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnAlarmLog;
        private DevComponents.DotNetBar.ButtonX btnAccessLog;
        private System.Windows.Forms.TextBox txtInOutMode;
        private System.Windows.Forms.PictureBox picData;
    }
}
