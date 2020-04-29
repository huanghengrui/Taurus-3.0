namespace Taurus
{
    partial class frmMJStarPowerEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJStarPowerEdit));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepartName = new System.Windows.Forms.TextBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.btnSelectStartDate = new DevComponents.DotNetBar.ButtonX();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.btnSelectEndDate = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(256, 136);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(336, 136);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Tag = "EmpNo";
            this.label2.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Tag = "EmpName";
            this.label1.Text = "label2";
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmpName.Location = new System.Drawing.Point(290, 37);
            this.txtEmpName.MaxLength = 10;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(120, 21);
            this.txtEmpName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 36;
            this.label4.Tag = "DepartName";
            this.label4.Text = "label3";
            // 
            // txtDepartName
            // 
            this.txtDepartName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartName.Location = new System.Drawing.Point(80, 67);
            this.txtDepartName.MaxLength = 10;
            this.txtDepartName.Name = "txtDepartName";
            this.txtDepartName.Size = new System.Drawing.Size(120, 21);
            this.txtDepartName.TabIndex = 3;
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmpNo.Location = new System.Drawing.Point(80, 37);
            this.txtEmpNo.MaxLength = 10;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(120, 21);
            this.txtEmpNo.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 1019;
            this.label11.Tag = "StartDate";
            this.label11.Text = "label4";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(81, 100);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(120, 21);
            this.txtStartDate.TabIndex = 11;
            // 
            // btnSelectStartDate
            // 
            this.btnSelectStartDate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectStartDate.Location = new System.Drawing.Point(166, 101);
            this.btnSelectStartDate.Name = "btnSelectStartDate";
            this.btnSelectStartDate.Size = new System.Drawing.Size(34, 19);
            this.btnSelectStartDate.TabIndex = 12;
            this.btnSelectStartDate.Text = "...";
            this.btnSelectStartDate.Click += new System.EventHandler(this.btnSelectStartDate_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1022;
            this.label12.Tag = "EndDate";
            this.label12.Text = "label4";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(291, 100);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(120, 21);
            this.txtEndDate.TabIndex = 13;
            // 
            // btnSelectEndDate
            // 
            this.btnSelectEndDate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectEndDate.Location = new System.Drawing.Point(376, 101);
            this.btnSelectEndDate.Name = "btnSelectEndDate";
            this.btnSelectEndDate.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEndDate.TabIndex = 14;
            this.btnSelectEndDate.Text = "...";
            this.btnSelectEndDate.Click += new System.EventHandler(this.btnSelectEndDate_Click);
            // 
            // frmMJSeaPowerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(420, 169);
            this.Controls.Add(this.btnSelectEndDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSelectStartDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDepartName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMJStarPowerEdit";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtEmpName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDepartName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtEmpNo, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtStartDate, 0);
            this.Controls.SetChildIndex(this.btnSelectStartDate, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtEndDate, 0);
            this.Controls.SetChildIndex(this.btnSelectEndDate, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDepartName;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStartDate;
        private DevComponents.DotNetBar.ButtonX btnSelectStartDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEndDate;
        private DevComponents.DotNetBar.ButtonX btnSelectEndDate;
    }
}
