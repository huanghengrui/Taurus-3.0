namespace Taurus
{
  partial class frmMJTimeAdd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJTimeAdd));
            this.tvGrid = new System.Windows.Forms.TreeView();
            this.GridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemPasteUpData = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemEmptyData = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpE6 = new System.Windows.Forms.DateTimePicker();
            this.dtpS6 = new System.Windows.Forms.DateTimePicker();
            this.dtpE5 = new System.Windows.Forms.DateTimePicker();
            this.dtpS5 = new System.Windows.Forms.DateTimePicker();
            this.dtpE4 = new System.Windows.Forms.DateTimePicker();
            this.dtpS4 = new System.Windows.Forms.DateTimePicker();
            this.dtpE3 = new System.Windows.Forms.DateTimePicker();
            this.dtpS3 = new System.Windows.Forms.DateTimePicker();
            this.dtpE2 = new System.Windows.Forms.DateTimePicker();
            this.dtpS2 = new System.Windows.Forms.DateTimePicker();
            this.dtpE1 = new System.Windows.Forms.DateTimePicker();
            this.dtpS1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbbID = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.GridMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(365, 175);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(445, 175);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // tvGrid
            // 
            this.tvGrid.LineColor = System.Drawing.Color.Empty;
            this.tvGrid.Location = new System.Drawing.Point(0, 0);
            this.tvGrid.Name = "tvGrid";
            this.tvGrid.Size = new System.Drawing.Size(121, 97);
            this.tvGrid.TabIndex = 0;
            // 
            // GridMenu
            // 
            this.GridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemPasteUpData,
            this.ItemEmptyData});
            this.GridMenu.Name = "GridMenu";
            this.GridMenu.Size = new System.Drawing.Size(193, 48);
            // 
            // ItemPasteUpData
            // 
            this.ItemPasteUpData.Name = "ItemPasteUpData";
            this.ItemPasteUpData.Size = new System.Drawing.Size(192, 22);
            this.ItemPasteUpData.Text = "toolStripMenuItem1";
            // 
            // ItemEmptyData
            // 
            this.ItemEmptyData.Name = "ItemEmptyData";
            this.ItemEmptyData.Size = new System.Drawing.Size(192, 22);
            this.ItemEmptyData.Text = "toolStripMenuItem2";
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Location = new System.Drawing.Point(606, 438);
            this.txtTime.Mask = "90:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.PromptChar = ' ';
            this.txtTime.Size = new System.Drawing.Size(40, 21);
            this.txtTime.TabIndex = 1002;
            this.txtTime.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1003;
            this.label1.Tag = "PassTimeID";
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpE6);
            this.groupBox1.Controls.Add(this.dtpS6);
            this.groupBox1.Controls.Add(this.dtpE5);
            this.groupBox1.Controls.Add(this.dtpS5);
            this.groupBox1.Controls.Add(this.dtpE4);
            this.groupBox1.Controls.Add(this.dtpS4);
            this.groupBox1.Controls.Add(this.dtpE3);
            this.groupBox1.Controls.Add(this.dtpS3);
            this.groupBox1.Controls.Add(this.dtpE2);
            this.groupBox1.Controls.Add(this.dtpS2);
            this.groupBox1.Controls.Add(this.dtpE1);
            this.groupBox1.Controls.Add(this.dtpS1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dtpE6
            // 
            this.dtpE6.CustomFormat = "HH:mm";
            this.dtpE6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE6.Location = new System.Drawing.Point(440, 70);
            this.dtpE6.Name = "dtpE6";
            this.dtpE6.ShowUpDown = true;
            this.dtpE6.Size = new System.Drawing.Size(60, 21);
            this.dtpE6.TabIndex = 11;
            this.dtpE6.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpS6
            // 
            this.dtpS6.CustomFormat = "HH:mm";
            this.dtpS6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS6.Location = new System.Drawing.Point(440, 40);
            this.dtpS6.Name = "dtpS6";
            this.dtpS6.ShowUpDown = true;
            this.dtpS6.Size = new System.Drawing.Size(60, 21);
            this.dtpS6.TabIndex = 10;
            this.dtpS6.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpE5
            // 
            this.dtpE5.CustomFormat = "HH:mm";
            this.dtpE5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE5.Location = new System.Drawing.Point(370, 70);
            this.dtpE5.Name = "dtpE5";
            this.dtpE5.ShowUpDown = true;
            this.dtpE5.Size = new System.Drawing.Size(60, 21);
            this.dtpE5.TabIndex = 9;
            this.dtpE5.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpS5
            // 
            this.dtpS5.CustomFormat = "HH:mm";
            this.dtpS5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS5.Location = new System.Drawing.Point(370, 40);
            this.dtpS5.Name = "dtpS5";
            this.dtpS5.ShowUpDown = true;
            this.dtpS5.Size = new System.Drawing.Size(60, 21);
            this.dtpS5.TabIndex = 8;
            this.dtpS5.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpE4
            // 
            this.dtpE4.CustomFormat = "HH:mm";
            this.dtpE4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE4.Location = new System.Drawing.Point(300, 70);
            this.dtpE4.Name = "dtpE4";
            this.dtpE4.ShowUpDown = true;
            this.dtpE4.Size = new System.Drawing.Size(60, 21);
            this.dtpE4.TabIndex = 7;
            this.dtpE4.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpS4
            // 
            this.dtpS4.CustomFormat = "HH:mm";
            this.dtpS4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS4.Location = new System.Drawing.Point(300, 40);
            this.dtpS4.Name = "dtpS4";
            this.dtpS4.ShowUpDown = true;
            this.dtpS4.Size = new System.Drawing.Size(60, 21);
            this.dtpS4.TabIndex = 6;
            this.dtpS4.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpE3
            // 
            this.dtpE3.CustomFormat = "HH:mm";
            this.dtpE3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE3.Location = new System.Drawing.Point(230, 70);
            this.dtpE3.Name = "dtpE3";
            this.dtpE3.ShowUpDown = true;
            this.dtpE3.Size = new System.Drawing.Size(60, 21);
            this.dtpE3.TabIndex = 5;
            this.dtpE3.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpS3
            // 
            this.dtpS3.CustomFormat = "HH:mm";
            this.dtpS3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS3.Location = new System.Drawing.Point(230, 40);
            this.dtpS3.Name = "dtpS3";
            this.dtpS3.ShowUpDown = true;
            this.dtpS3.Size = new System.Drawing.Size(60, 21);
            this.dtpS3.TabIndex = 4;
            this.dtpS3.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpE2
            // 
            this.dtpE2.CustomFormat = "HH:mm";
            this.dtpE2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE2.Location = new System.Drawing.Point(160, 70);
            this.dtpE2.Name = "dtpE2";
            this.dtpE2.ShowUpDown = true;
            this.dtpE2.Size = new System.Drawing.Size(60, 21);
            this.dtpE2.TabIndex = 3;
            this.dtpE2.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpS2
            // 
            this.dtpS2.CustomFormat = "HH:mm";
            this.dtpS2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS2.Location = new System.Drawing.Point(160, 40);
            this.dtpS2.Name = "dtpS2";
            this.dtpS2.ShowUpDown = true;
            this.dtpS2.Size = new System.Drawing.Size(60, 21);
            this.dtpS2.TabIndex = 2;
            this.dtpS2.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpE1
            // 
            this.dtpE1.CustomFormat = "HH:mm";
            this.dtpE1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE1.Location = new System.Drawing.Point(90, 70);
            this.dtpE1.Name = "dtpE1";
            this.dtpE1.ShowUpDown = true;
            this.dtpE1.Size = new System.Drawing.Size(60, 21);
            this.dtpE1.TabIndex = 1;
            this.dtpE1.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // dtpS1
            // 
            this.dtpS1.CustomFormat = "HH:mm";
            this.dtpS1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS1.Location = new System.Drawing.Point(90, 40);
            this.dtpS1.Name = "dtpS1";
            this.dtpS1.ShowUpDown = true;
            this.dtpS1.Size = new System.Drawing.Size(60, 21);
            this.dtpS1.TabIndex = 0;
            this.dtpS1.Value = new System.DateTime(2015, 9, 17, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 7;
            this.label9.Tag = "ColumnT6";
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(370, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 6;
            this.label8.Tag = "ColumnT5";
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 5;
            this.label7.Tag = "ColumnT4";
            this.label7.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Tag = "ColumnT3";
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Tag = "ColumnT2";
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Tag = "ColumnT1";
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Tag = "PassTimeEnd";
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Tag = "PassTimeStart";
            this.label2.Text = "label2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 1006;
            this.label10.Tag = "PassTimeName";
            this.label10.Text = "label10";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(313, 36);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(210, 21);
            this.txtName.TabIndex = 1;
            // 
            // cbbID
            // 
            this.cbbID.DisplayMember = "Text";
            this.cbbID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbID.ForeColor = System.Drawing.Color.Black;
            this.cbbID.FormattingEnabled = true;
            this.cbbID.ItemHeight = 16;
            this.cbbID.Location = new System.Drawing.Point(76, 35);
            this.cbbID.Name = "cbbID";
            this.cbbID.Size = new System.Drawing.Size(87, 22);
            this.cbbID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbID.TabIndex = 1007;
            // 
            // frmMJTimeAdd
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(529, 208);
            this.Controls.Add(this.cbbID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJTimeAdd";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtTime, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.cbbID, 0);
            this.GridMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView tvGrid;
    private System.Windows.Forms.MaskedTextBox txtTime;
    private System.Windows.Forms.ContextMenuStrip GridMenu;
    private System.Windows.Forms.ToolStripMenuItem ItemPasteUpData;
    private System.Windows.Forms.ToolStripMenuItem ItemEmptyData;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtpS1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.DateTimePicker dtpE2;
    private System.Windows.Forms.DateTimePicker dtpS2;
    private System.Windows.Forms.DateTimePicker dtpE1;
    private System.Windows.Forms.DateTimePicker dtpE6;
    private System.Windows.Forms.DateTimePicker dtpS6;
    private System.Windows.Forms.DateTimePicker dtpE5;
    private System.Windows.Forms.DateTimePicker dtpS5;
    private System.Windows.Forms.DateTimePicker dtpE4;
    private System.Windows.Forms.DateTimePicker dtpS4;
    private System.Windows.Forms.DateTimePicker dtpE3;
    private System.Windows.Forms.DateTimePicker dtpS3;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbID;
    }
}
