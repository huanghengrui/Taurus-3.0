namespace Taurus
{
    partial class frmKQHolidayAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQHolidayAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.txtHolidayName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBeginTime = new System.Windows.Forms.DateTimePicker();
            this.txtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(142, 149);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 149);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Tag = "HolidayName";
            this.label1.Text = "label2";
            // 
            // txtHolidayName
            // 
            this.txtHolidayName.BackColor = System.Drawing.SystemColors.Window;
            this.txtHolidayName.Location = new System.Drawing.Point(70, 39);
            this.txtHolidayName.MaxLength = 10;
            this.txtHolidayName.Name = "txtHolidayName";
            this.txtHolidayName.Size = new System.Drawing.Size(230, 21);
            this.txtHolidayName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 42;
            this.label5.Tag = "HolidayBeginTime";
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 45;
            this.label4.Tag = "HolidayEndTime";
            this.label4.Text = "label4";
            // 
            // txtBeginTime
            // 
            this.txtBeginTime.CustomFormat = "";
            this.txtBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtBeginTime.Location = new System.Drawing.Point(70, 69);
            this.txtBeginTime.Name = "txtBeginTime";
            this.txtBeginTime.Size = new System.Drawing.Size(230, 21);
            this.txtBeginTime.TabIndex = 1;
            // 
            // txtEndTime
            // 
            this.txtEndTime.CustomFormat = "";
            this.txtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtEndTime.Location = new System.Drawing.Point(70, 99);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(230, 21);
            this.txtEndTime.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(10, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 18);
            this.label3.TabIndex = 1030;
            this.label3.Tag = "label3";
            this.label3.Text = "label3";
            // 
            // frmKQHolidayAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(314, 183);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtBeginTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHolidayName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKQHolidayAdd";
            this.Controls.SetChildIndex(this.txtHolidayName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtBeginTime, 0);
            this.Controls.SetChildIndex(this.txtEndTime, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtHolidayName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.DateTimePicker txtBeginTime;
    private System.Windows.Forms.DateTimePicker txtEndTime;
    private System.Windows.Forms.Label label3;

  }
}
