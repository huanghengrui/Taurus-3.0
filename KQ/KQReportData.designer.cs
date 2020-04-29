namespace Taurus
{
  partial class frmKQReportData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQReportData));
            this.btnSelectDepart = new DevComponents.DotNetBar.ButtonX();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectEmp = new DevComponents.DotNetBar.ButtonX();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.picData = new System.Windows.Forms.PictureBox();
            this.btnSelectMacSN = new DevComponents.DotNetBar.ButtonX();
            this.txtMacSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelectMacSN);
            this.panel1.Controls.Add(this.txtMacSN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.picData);
            this.panel1.Controls.Add(this.picPhoto);
            this.panel1.Controls.Add(this.btnSelectDepart);
            this.panel1.Controls.Add(this.txtDepart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSelectEmp);
            this.panel1.Controls.Add(this.txtEmp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Size = new System.Drawing.Size(220, 756);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(416, 756);
            this.dispView.SelectionCellChange += new AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEventHandler(this.dispView_SelectionCellChange);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(220, 40);
            this.pnlDisp.Size = new System.Drawing.Size(416, 756);
            // 
            // Statusbar
            // 
            this.Statusbar.Location = new System.Drawing.Point(0, 796);
            this.Statusbar.Size = new System.Drawing.Size(636, 30);
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
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // btnSelectDepart
            // 
            this.btnSelectDepart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectDepart.Location = new System.Drawing.Point(175, 98);
            this.btnSelectDepart.Name = "btnSelectDepart";
            this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart.TabIndex = 5;
            this.btnSelectDepart.Text = "button1";
            this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(70, 97);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(140, 21);
            this.txtDepart.TabIndex = 4;
            this.txtDepart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepart_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 34;
            this.label2.Tag = "Depart";
            this.label2.Text = "label2";
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectEmp.Location = new System.Drawing.Point(175, 66);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 3;
            this.btnSelectEmp.Text = "button1";
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(70, 65);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(140, 21);
            this.txtEmp.TabIndex = 2;
            this.txtEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmp_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 33;
            this.label1.Tag = "Emp";
            this.label1.Text = "label1";
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
            // picPhoto
            // 
            this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPhoto.Location = new System.Drawing.Point(10, 162);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(201, 268);
            this.picPhoto.TabIndex = 51;
            this.picPhoto.TabStop = false;
            // 
            // picData
            // 
            this.picData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picData.Location = new System.Drawing.Point(10, 439);
            this.picData.Name = "picData";
            this.picData.Size = new System.Drawing.Size(200, 260);
            this.picData.TabIndex = 52;
            this.picData.TabStop = false;
            // 
            // btnSelectMacSN
            // 
            this.btnSelectMacSN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectMacSN.Location = new System.Drawing.Point(174, 131);
            this.btnSelectMacSN.Name = "btnSelectMacSN";
            this.btnSelectMacSN.Size = new System.Drawing.Size(35, 20);
            this.btnSelectMacSN.TabIndex = 73;
            this.btnSelectMacSN.Tag = "btnSelectEmp";
            this.btnSelectMacSN.Text = "button1";
            this.btnSelectMacSN.Click += new System.EventHandler(this.btnSelectMacSN_Click);
            // 
            // txtMacSN
            // 
            this.txtMacSN.Location = new System.Drawing.Point(70, 130);
            this.txtMacSN.Name = "txtMacSN";
            this.txtMacSN.Size = new System.Drawing.Size(139, 21);
            this.txtMacSN.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 71;
            this.label3.Tag = "MacSN";
            this.label3.Text = "label3";
            // 
            // frmKQReportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(636, 826);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKQReportData";
            this.Controls.SetChildIndex(this.Statusbar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.ButtonX btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label2;
    private DevComponents.DotNetBar.ButtonX btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.PictureBox picPhoto;
    private System.Windows.Forms.PictureBox picData;
        private DevComponents.DotNetBar.ButtonX btnSelectMacSN;
        private System.Windows.Forms.TextBox txtMacSN;
        private System.Windows.Forms.Label label3;
    }
}
