namespace Taurus
{
  partial class frmKQReportDay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQReportDay));
            this.btnSelectDepart = new DevComponents.DotNetBar.ButtonX();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectEmp = new DevComponents.DotNetBar.ButtonX();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkOtSure = new System.Windows.Forms.CheckBox();
            this.chkAbsent = new System.Windows.Forms.CheckBox();
            this.chkLater = new System.Windows.Forms.CheckBox();
            this.chkAhead = new System.Windows.Forms.CheckBox();
            this.chkLeave = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnSelectDepart);
            this.panel1.Controls.Add(this.txtDepart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSelectEmp);
            this.panel1.Controls.Add(this.txtEmp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Size = new System.Drawing.Size(220, 255);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(332, 255);
            this.dispView.ContentCellDblClick += new AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEventHandler(this.dispView_ContentCellDblClick);
            this.dispView.SelectionCellChange += new AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEventHandler(this.dispView_SelectionCellChange);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(220, 40);
            this.pnlDisp.Size = new System.Drawing.Size(332, 255);
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
            this.btnSelectDepart.Location = new System.Drawing.Point(175, 96);
            this.btnSelectDepart.Name = "btnSelectDepart";
            this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart.TabIndex = 5;
            this.btnSelectDepart.Text = "button1";

            this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(70, 95);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(140, 21);
            this.txtDepart.TabIndex = 4;
            this.txtDepart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepart_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 43;
            this.label2.Tag = "Depart";
            this.label2.Text = "label2";
            // 
            // btnSelectEmp
            // 
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
            this.label1.TabIndex = 42;
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
            this.label4.TabIndex = 41;
            this.label4.Tag = "SihftKQDate";
            this.label4.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.chkOtSure);
            this.groupBox1.Controls.Add(this.chkAbsent);
            this.groupBox1.Controls.Add(this.chkLater);
            this.groupBox1.Controls.Add(this.chkAhead);
            this.groupBox1.Controls.Add(this.chkLeave);
            this.groupBox1.Location = new System.Drawing.Point(10, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 140);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(10, 120);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(78, 16);
            this.chkAll.TabIndex = 5;
            this.chkAll.Text = "checkBox4";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkOtSure
            // 
            this.chkOtSure.AutoSize = true;
            this.chkOtSure.Location = new System.Drawing.Point(10, 100);
            this.chkOtSure.Name = "chkOtSure";
            this.chkOtSure.Size = new System.Drawing.Size(78, 16);
            this.chkOtSure.TabIndex = 4;
            this.chkOtSure.Text = "checkBox4";
            this.chkOtSure.UseVisualStyleBackColor = true;
            // 
            // chkAbsent
            // 
            this.chkAbsent.AutoSize = true;
            this.chkAbsent.Location = new System.Drawing.Point(10, 80);
            this.chkAbsent.Name = "chkAbsent";
            this.chkAbsent.Size = new System.Drawing.Size(78, 16);
            this.chkAbsent.TabIndex = 3;
            this.chkAbsent.Text = "checkBox4";
            this.chkAbsent.UseVisualStyleBackColor = true;
            // 
            // chkLater
            // 
            this.chkLater.AutoSize = true;
            this.chkLater.Location = new System.Drawing.Point(10, 60);
            this.chkLater.Name = "chkLater";
            this.chkLater.Size = new System.Drawing.Size(78, 16);
            this.chkLater.TabIndex = 2;
            this.chkLater.Text = "checkBox3";
            this.chkLater.UseVisualStyleBackColor = true;
            // 
            // chkAhead
            // 
            this.chkAhead.AutoSize = true;
            this.chkAhead.Location = new System.Drawing.Point(10, 40);
            this.chkAhead.Name = "chkAhead";
            this.chkAhead.Size = new System.Drawing.Size(78, 16);
            this.chkAhead.TabIndex = 1;
            this.chkAhead.Text = "checkBox2";
            this.chkAhead.UseVisualStyleBackColor = true;
            // 
            // chkLeave
            // 
            this.chkLeave.AutoSize = true;
            this.chkLeave.Location = new System.Drawing.Point(10, 20);
            this.chkLeave.Name = "chkLeave";
            this.chkLeave.Size = new System.Drawing.Size(78, 16);
            this.chkLeave.TabIndex = 0;
            this.chkLeave.Text = "checkBox1";
            this.chkLeave.UseVisualStyleBackColor = true;
            // 
            // frmKQReportDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(552, 326);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKQReportDay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKQReportResultDay_FormClosing);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox chkLeave;
    private System.Windows.Forms.CheckBox chkAbsent;
    private System.Windows.Forms.CheckBox chkLater;
    private System.Windows.Forms.CheckBox chkAhead;
    private System.Windows.Forms.CheckBox chkAll;
    private System.Windows.Forms.CheckBox chkOtSure;
  }
}
