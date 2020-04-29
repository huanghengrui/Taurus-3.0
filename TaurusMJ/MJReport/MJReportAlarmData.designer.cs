namespace Taurus
{
  partial class frmMJReportAlarmData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJReportAlarmData));
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectMacSN = new DevComponents.DotNetBar.ButtonX();
            this.txtMacSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlarmMode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAlarmMode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSelectMacSN);
            this.panel1.Controls.Add(this.txtMacSN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Size = new System.Drawing.Size(220, 391);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(367, 391);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(220, 40);
            this.pnlDisp.Size = new System.Drawing.Size(367, 391);
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
            this.btnSelectMacSN.Location = new System.Drawing.Point(175, 75);
            this.btnSelectMacSN.Name = "btnSelectMacSN";
            this.btnSelectMacSN.Size = new System.Drawing.Size(35, 20);
            this.btnSelectMacSN.TabIndex = 70;
            this.btnSelectMacSN.Tag = "btnSelectEmp";
            this.btnSelectMacSN.Text = "button1";
            this.btnSelectMacSN.Click += new System.EventHandler(this.btnSelectMacSN_Click);
            // 
            // txtMacSN
            // 
            this.txtMacSN.Location = new System.Drawing.Point(71, 74);
            this.txtMacSN.Name = "txtMacSN";
            this.txtMacSN.Size = new System.Drawing.Size(139, 21);
            this.txtMacSN.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 68;
            this.label3.Tag = "MacSN";
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 71;
            this.label2.Tag = "AlarmMode";
            this.label2.Text = "label2";
            // 
            // txtAlarmMode
            // 
            this.txtAlarmMode.Location = new System.Drawing.Point(70, 117);
            this.txtAlarmMode.Multiline = true;
            this.txtAlarmMode.Name = "txtAlarmMode";
            this.txtAlarmMode.Size = new System.Drawing.Size(140, 20);
            this.txtAlarmMode.TabIndex = 72;
            // 
            // frmMJReportAlarmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(587, 462);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJReportAlarmData";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlarmMode;
    }
}
