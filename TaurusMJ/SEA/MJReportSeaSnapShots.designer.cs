namespace Taurus
{
  partial class frmMJReportSeaSnapShots
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJReportSeaSnapShots));
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.picData = new System.Windows.Forms.PictureBox();
            this.btnGetSnapshotsLog = new DevComponents.DotNetBar.ButtonX();
            this.btnClearSnapshotsLog = new DevComponents.DotNetBar.ButtonX();
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
            this.panel1.Controls.Add(this.btnGetSnapshotsLog);
            this.panel1.Controls.Add(this.picData);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnClearSnapshotsLog);
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Size = new System.Drawing.Size(220, 501);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(497, 501);
            this.dispView.ContentCellDblClick += new AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEventHandler(this.dispView_ContentCellDblClick);
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
            this.dtpEnd.Location = new System.Drawing.Point(74, 35);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(140, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(74, 10);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 21);
            this.dtpStart.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 32;
            this.label4.Tag = "gbxEmpTime";
            this.label4.Text = "label4";
            // 
            // picData
            // 
            this.picData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picData.Location = new System.Drawing.Point(14, 117);
            this.picData.Name = "picData";
            this.picData.Size = new System.Drawing.Size(200, 257);
            this.picData.TabIndex = 52;
            this.picData.TabStop = false;
            // 
            // btnGetSnapshotsLog
            // 
            this.btnGetSnapshotsLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetSnapshotsLog.Location = new System.Drawing.Point(74, 74);
            this.btnGetSnapshotsLog.Name = "btnGetSnapshotsLog";
            this.btnGetSnapshotsLog.Size = new System.Drawing.Size(136, 25);
            this.btnGetSnapshotsLog.TabIndex = 53;
            this.btnGetSnapshotsLog.Text = "button1";
            this.btnGetSnapshotsLog.Click += new System.EventHandler(this.btnGetSnapshotsLog_Click);
            // 
            // btnClearSnapshotsLog
            // 
            this.btnClearSnapshotsLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearSnapshotsLog.Location = new System.Drawing.Point(113, 74);
            this.btnClearSnapshotsLog.Name = "btnClearSnapshotsLog";
            this.btnClearSnapshotsLog.Size = new System.Drawing.Size(100, 25);
            this.btnClearSnapshotsLog.TabIndex = 54;
            this.btnClearSnapshotsLog.Text = "button1";
            this.btnClearSnapshotsLog.Visible = false;
            this.btnClearSnapshotsLog.Click += new System.EventHandler(this.btnClearSnapshotsLog_Click);
            // 
            // frmMJReportSeaSnapShots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(717, 602);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJReportSeaSnapShots";
            this.Load += new System.EventHandler(this.frmMJReportSeaSnapShots_Load);
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
    private System.Windows.Forms.PictureBox picData;
        private DevComponents.DotNetBar.ButtonX btnClearSnapshotsLog;
        private DevComponents.DotNetBar.ButtonX btnGetSnapshotsLog;
    }
}
