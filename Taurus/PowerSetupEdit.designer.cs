namespace Taurus
{
    partial class frmPowerSetupEdit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPowerSetupEdit));
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtEmpName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtDepartName = new System.Windows.Forms.TextBox();
      this.cbbSun = new System.Windows.Forms.ComboBox();
      this.txtEmpNo = new System.Windows.Forms.TextBox();
      this.cbbMon = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cbbTue = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.cbbWed = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cbbThu = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.cbbFri = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.cbbSat = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.btnSelectStartDate = new System.Windows.Forms.Button();
      this.txtStartDate = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.btnSelectEndDate = new System.Windows.Forms.Button();
      this.txtEndDate = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(256, 200);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(336, 200);
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
      this.label2.Location = new System.Drawing.Point(10, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 19;
      this.label2.Tag = "EmpNo";
      this.label2.Text = "label1";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(220, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 32;
      this.label3.Tag = "SunID";
      this.label3.Text = "label4";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(220, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 34;
      this.label1.Tag = "EmpName";
      this.label1.Text = "label2";
      // 
      // txtEmpName
      // 
      this.txtEmpName.BackColor = System.Drawing.SystemColors.Control;
      this.txtEmpName.Location = new System.Drawing.Point(290, 10);
      this.txtEmpName.MaxLength = 10;
      this.txtEmpName.Name = "txtEmpName";
      this.txtEmpName.Size = new System.Drawing.Size(120, 21);
      this.txtEmpName.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 36;
      this.label4.Tag = "DepartName";
      this.label4.Text = "label3";
      // 
      // txtDepartName
      // 
      this.txtDepartName.BackColor = System.Drawing.SystemColors.Control;
      this.txtDepartName.Location = new System.Drawing.Point(80, 40);
      this.txtDepartName.MaxLength = 10;
      this.txtDepartName.Name = "txtDepartName";
      this.txtDepartName.Size = new System.Drawing.Size(120, 21);
      this.txtDepartName.TabIndex = 3;
      // 
      // cbbSun
      // 
      this.cbbSun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbSun.FormattingEnabled = true;
      this.cbbSun.Location = new System.Drawing.Point(290, 40);
      this.cbbSun.Name = "cbbSun";
      this.cbbSun.Size = new System.Drawing.Size(120, 20);
      this.cbbSun.TabIndex = 4;
      // 
      // txtEmpNo
      // 
      this.txtEmpNo.BackColor = System.Drawing.SystemColors.Control;
      this.txtEmpNo.Location = new System.Drawing.Point(80, 10);
      this.txtEmpNo.MaxLength = 10;
      this.txtEmpNo.Name = "txtEmpNo";
      this.txtEmpNo.Size = new System.Drawing.Size(120, 21);
      this.txtEmpNo.TabIndex = 0;
      // 
      // cbbMon
      // 
      this.cbbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbMon.FormattingEnabled = true;
      this.cbbMon.Location = new System.Drawing.Point(80, 70);
      this.cbbMon.Name = "cbbMon";
      this.cbbMon.Size = new System.Drawing.Size(120, 20);
      this.cbbMon.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 74);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 1003;
      this.label5.Tag = "MonID";
      this.label5.Text = "label4";
      // 
      // cbbTue
      // 
      this.cbbTue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbTue.FormattingEnabled = true;
      this.cbbTue.Location = new System.Drawing.Point(290, 70);
      this.cbbTue.Name = "cbbTue";
      this.cbbTue.Size = new System.Drawing.Size(120, 20);
      this.cbbTue.TabIndex = 6;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(220, 74);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 1005;
      this.label6.Tag = "TueID";
      this.label6.Text = "label4";
      // 
      // cbbWed
      // 
      this.cbbWed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbWed.FormattingEnabled = true;
      this.cbbWed.Location = new System.Drawing.Point(80, 100);
      this.cbbWed.Name = "cbbWed";
      this.cbbWed.Size = new System.Drawing.Size(120, 20);
      this.cbbWed.TabIndex = 7;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(10, 104);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 12);
      this.label7.TabIndex = 1007;
      this.label7.Tag = "WedID";
      this.label7.Text = "label4";
      // 
      // cbbThu
      // 
      this.cbbThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbThu.FormattingEnabled = true;
      this.cbbThu.Location = new System.Drawing.Point(290, 100);
      this.cbbThu.Name = "cbbThu";
      this.cbbThu.Size = new System.Drawing.Size(120, 20);
      this.cbbThu.TabIndex = 8;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(220, 104);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(41, 12);
      this.label8.TabIndex = 1009;
      this.label8.Tag = "ThuID";
      this.label8.Text = "label4";
      // 
      // cbbFri
      // 
      this.cbbFri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbFri.FormattingEnabled = true;
      this.cbbFri.Location = new System.Drawing.Point(80, 130);
      this.cbbFri.Name = "cbbFri";
      this.cbbFri.Size = new System.Drawing.Size(120, 20);
      this.cbbFri.TabIndex = 9;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(10, 134);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(41, 12);
      this.label9.TabIndex = 1011;
      this.label9.Tag = "FriID";
      this.label9.Text = "label4";
      // 
      // cbbSat
      // 
      this.cbbSat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbSat.FormattingEnabled = true;
      this.cbbSat.Location = new System.Drawing.Point(290, 130);
      this.cbbSat.Name = "cbbSat";
      this.cbbSat.Size = new System.Drawing.Size(120, 20);
      this.cbbSat.TabIndex = 10;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(220, 134);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(41, 12);
      this.label10.TabIndex = 1013;
      this.label10.Tag = "SatID";
      this.label10.Text = "label4";
      // 
      // btnSelectStartDate
      // 
      this.btnSelectStartDate.Location = new System.Drawing.Point(165, 161);
      this.btnSelectStartDate.Name = "btnSelectStartDate";
      this.btnSelectStartDate.Size = new System.Drawing.Size(34, 19);
      this.btnSelectStartDate.TabIndex = 12;
      this.btnSelectStartDate.Text = "...";
      this.btnSelectStartDate.UseVisualStyleBackColor = true;
      this.btnSelectStartDate.Click += new System.EventHandler(this.btnSelectStartDate_Click);
      // 
      // txtStartDate
      // 
      this.txtStartDate.Location = new System.Drawing.Point(80, 160);
      this.txtStartDate.Name = "txtStartDate";
      this.txtStartDate.Size = new System.Drawing.Size(120, 21);
      this.txtStartDate.TabIndex = 11;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(10, 164);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(41, 12);
      this.label11.TabIndex = 1019;
      this.label11.Tag = "StartDate";
      this.label11.Text = "label4";
      // 
      // btnSelectEndDate
      // 
      this.btnSelectEndDate.Location = new System.Drawing.Point(375, 161);
      this.btnSelectEndDate.Name = "btnSelectEndDate";
      this.btnSelectEndDate.Size = new System.Drawing.Size(34, 19);
      this.btnSelectEndDate.TabIndex = 14;
      this.btnSelectEndDate.Text = "...";
      this.btnSelectEndDate.UseVisualStyleBackColor = true;
      this.btnSelectEndDate.Click += new System.EventHandler(this.btnSelectEndDate_Click);
      // 
      // txtEndDate
      // 
      this.txtEndDate.Location = new System.Drawing.Point(290, 160);
      this.txtEndDate.Name = "txtEndDate";
      this.txtEndDate.Size = new System.Drawing.Size(120, 21);
      this.txtEndDate.TabIndex = 13;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(220, 164);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(41, 12);
      this.label12.TabIndex = 1022;
      this.label12.Tag = "EndDate";
      this.label12.Text = "label4";
      // 
      // frmPowerSetupEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(420, 233);
      this.Controls.Add(this.btnSelectEndDate);
      this.Controls.Add(this.txtEndDate);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.btnSelectStartDate);
      this.Controls.Add(this.txtStartDate);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.cbbSat);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.cbbFri);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.cbbThu);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.cbbWed);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.cbbTue);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cbbMon);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtEmpNo);
      this.Controls.Add(this.cbbSun);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtDepartName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtEmpName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.KeyPreview = true;
      this.Name = "frmPowerSetupEdit";
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.txtEmpName, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtDepartName, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.cbbSun, 0);
      this.Controls.SetChildIndex(this.txtEmpNo, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.cbbMon, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.cbbTue, 0);
      this.Controls.SetChildIndex(this.label7, 0);
      this.Controls.SetChildIndex(this.cbbWed, 0);
      this.Controls.SetChildIndex(this.label8, 0);
      this.Controls.SetChildIndex(this.cbbThu, 0);
      this.Controls.SetChildIndex(this.label9, 0);
      this.Controls.SetChildIndex(this.cbbFri, 0);
      this.Controls.SetChildIndex(this.label10, 0);
      this.Controls.SetChildIndex(this.cbbSat, 0);
      this.Controls.SetChildIndex(this.label11, 0);
      this.Controls.SetChildIndex(this.txtStartDate, 0);
      this.Controls.SetChildIndex(this.btnSelectStartDate, 0);
      this.Controls.SetChildIndex(this.label12, 0);
      this.Controls.SetChildIndex(this.txtEndDate, 0);
      this.Controls.SetChildIndex(this.btnSelectEndDate, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.ComboBox cbbSun;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.ComboBox cbbMon;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cbbTue;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cbbWed;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cbbThu;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cbbFri;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox cbbSat;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button btnSelectStartDate;
    private System.Windows.Forms.TextBox txtStartDate;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Button btnSelectEndDate;
    private System.Windows.Forms.TextBox txtEndDate;
    private System.Windows.Forms.Label label12;

  }
}
