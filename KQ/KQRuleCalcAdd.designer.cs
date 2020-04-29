namespace Taurus
{
    partial class frmKQRuleCalcAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQRuleCalcAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSortID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSortName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOvertimeRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTune = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInteger = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbSort = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbOvertimeSort = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCalc = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(269, 206);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(349, 206);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 32;
            this.label1.Tag = "Sort";
            this.label1.Text = "label1";
            // 
            // txtSortID
            // 
            this.txtSortID.Enabled = false;
            this.txtSortID.Location = new System.Drawing.Point(105, 40);
            this.txtSortID.MaxLength = 10;
            this.txtSortID.Name = "txtSortID";
            this.txtSortID.Size = new System.Drawing.Size(100, 21);
            this.txtSortID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 37;
            this.label2.Tag = "SortID ";
            this.label2.Text = "label2";
            // 
            // txtSortName
            // 
            this.txtSortName.Location = new System.Drawing.Point(325, 40);
            this.txtSortName.MaxLength = 10;
            this.txtSortName.Name = "txtSortName";
            this.txtSortName.Size = new System.Drawing.Size(100, 21);
            this.txtSortName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 39;
            this.label3.Tag = "SortName ";
            this.label3.Text = "label3";
            // 
            // txtOvertimeRate
            // 
            this.txtOvertimeRate.Location = new System.Drawing.Point(105, 100);
            this.txtOvertimeRate.MaxLength = 10;
            this.txtOvertimeRate.Name = "txtOvertimeRate";
            this.txtOvertimeRate.Size = new System.Drawing.Size(100, 21);
            this.txtOvertimeRate.TabIndex = 4;
            this.txtOvertimeRate.Text = "1.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 50;
            this.label8.Tag = "OvertimeRate ";
            this.label8.Text = "label8";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(225, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 57;
            this.label11.Tag = "OvertimeSort";
            this.label11.Text = "label11";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(325, 100);
            this.txtStart.MaxLength = 10;
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 21);
            this.txtStart.TabIndex = 5;
            this.txtStart.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1003;
            this.label4.Tag = "Start";
            this.label4.Text = "label4";
            // 
            // txtTune
            // 
            this.txtTune.Location = new System.Drawing.Point(105, 130);
            this.txtTune.MaxLength = 10;
            this.txtTune.Name = "txtTune";
            this.txtTune.Size = new System.Drawing.Size(100, 21);
            this.txtTune.TabIndex = 6;
            this.txtTune.Text = "15";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1005;
            this.label5.Tag = "Tune";
            this.label5.Text = "label5";
            // 
            // txtInteger
            // 
            this.txtInteger.Location = new System.Drawing.Point(325, 130);
            this.txtInteger.MaxLength = 10;
            this.txtInteger.Name = "txtInteger";
            this.txtInteger.Size = new System.Drawing.Size(100, 21);
            this.txtInteger.TabIndex = 7;
            this.txtInteger.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1007;
            this.label6.Tag = "Integer";
            this.label6.Text = "label6";
            // 
            // cbbSort
            // 
            this.cbbSort.DisplayMember = "Text";
            this.cbbSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSort.ForeColor = System.Drawing.Color.Black;
            this.cbbSort.FormattingEnabled = true;
            this.cbbSort.ItemHeight = 16;
            this.cbbSort.Location = new System.Drawing.Point(104, 69);
            this.cbbSort.Name = "cbbSort";
            this.cbbSort.Size = new System.Drawing.Size(101, 22);
            this.cbbSort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbSort.TabIndex = 1008;
            this.cbbSort.SelectedIndexChanged += new System.EventHandler(this.cbbSort_SelectedIndexChanged);
            // 
            // cbbOvertimeSort
            // 
            this.cbbOvertimeSort.DisplayMember = "Text";
            this.cbbOvertimeSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbOvertimeSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOvertimeSort.ForeColor = System.Drawing.Color.Black;
            this.cbbOvertimeSort.FormattingEnabled = true;
            this.cbbOvertimeSort.ItemHeight = 16;
            this.cbbOvertimeSort.Location = new System.Drawing.Point(325, 70);
            this.cbbOvertimeSort.Name = "cbbOvertimeSort";
            this.cbbOvertimeSort.Size = new System.Drawing.Size(100, 22);
            this.cbbOvertimeSort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbOvertimeSort.TabIndex = 1009;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbCalc);
            this.panel1.Location = new System.Drawing.Point(13, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 31);
            this.panel1.TabIndex = 1010;
            // 
            // lbCalc
            // 
            this.lbCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCalc.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbCalc.Location = new System.Drawing.Point(0, 0);
            this.lbCalc.Name = "lbCalc";
            this.lbCalc.Size = new System.Drawing.Size(408, 31);
            this.lbCalc.TabIndex = 0;
            this.lbCalc.Text = "label7";
            // 
            // frmKQRuleCalcAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(433, 237);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbbOvertimeSort);
            this.Controls.Add(this.cbbSort);
            this.Controls.Add(this.txtInteger);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTune);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtOvertimeRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSortName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSortID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKQRuleCalcAdd";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSortID, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtSortName, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtOvertimeRate, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtStart, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtTune, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtInteger, 0);
            this.Controls.SetChildIndex(this.cbbSort, 0);
            this.Controls.SetChildIndex(this.cbbOvertimeSort, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtSortID;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtSortName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtOvertimeRate;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtTune;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtInteger;
    private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbSort;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbOvertimeSort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCalc;
    }
}
