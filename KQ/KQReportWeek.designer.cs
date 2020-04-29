namespace Taurus
{
  partial class frmKQReportWeek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQReportWeek));
            this.lbWeek = new System.Windows.Forms.Label();
            this.btnSelectDepart = new DevComponents.DotNetBar.ButtonX();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectEmp = new DevComponents.DotNetBar.ButtonX();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.btnSelectDepart);
            this.panel1.Controls.Add(this.txtDepart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSelectEmp);
            this.panel1.Controls.Add(this.txtEmp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbWeek);
            this.panel1.Size = new System.Drawing.Size(220, 256);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(332, 256);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(220, 40);
            this.pnlDisp.Size = new System.Drawing.Size(332, 256);
            // 
            // Statusbar
            // 
            this.Statusbar.Location = new System.Drawing.Point(0, 296);
            this.Statusbar.Size = new System.Drawing.Size(552, 30);
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
            // lbWeek
            // 
            this.lbWeek.AutoSize = true;
            this.lbWeek.Location = new System.Drawing.Point(10, 14);
            this.lbWeek.Name = "lbWeek";
            this.lbWeek.Size = new System.Drawing.Size(41, 12);
            this.lbWeek.TabIndex = 43;
            this.lbWeek.Tag = "KQYM";
            this.lbWeek.Text = "label4";
            // 
            // btnSelectDepart
            // 
            this.btnSelectDepart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectDepart.Location = new System.Drawing.Point(175, 71);
            this.btnSelectDepart.Name = "btnSelectDepart";
            this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart.TabIndex = 4;
            this.btnSelectDepart.Text = "button1";
            this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(70, 70);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(140, 21);
            this.txtDepart.TabIndex = 3;
            this.txtDepart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepart_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 49;
            this.label2.Tag = "Depart";
            this.label2.Text = "label2";
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectEmp.Location = new System.Drawing.Point(175, 41);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 2;
            this.btnSelectEmp.Text = "button1";
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(70, 40);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(140, 21);
            this.txtEmp.TabIndex = 1;
            this.txtEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmp_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 48;
            this.label1.Tag = "Emp";
            this.label1.Text = "label1";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(69, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 21);
            this.dtpStart.TabIndex = 50;
            // 
            // frmKQReportWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(552, 326);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKQReportWeek";
            this.Controls.SetChildIndex(this.Statusbar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lbWeek;
    private DevComponents.DotNetBar.ButtonX btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label2;
    private DevComponents.DotNetBar.ButtonX btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
    }
}
