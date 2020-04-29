namespace Taurus
{
  partial class frmKQDataAssay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQDataAssay));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbEmp = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.lblQuickSearchToolTip = new System.Windows.Forms.Label();
            this.cardGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.btnQuickSearch = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.button2 = new DevComponents.DotNetBar.ButtonX();
            this.lblMsg = new System.Windows.Forms.Label();
            this.progBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.cbWeek = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(430, 394);
            this.btnOk.Text = "";
            this.btnOk.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(510, 394);
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
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "label1";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(99, 43);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(100, 21);
            this.dtpStart.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(309, 43);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(100, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(10, 94);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(95, 16);
            this.rbAll.TabIndex = 2;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "radioButton1";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbEmp
            // 
            this.rbEmp.AutoSize = true;
            this.rbEmp.Location = new System.Drawing.Point(10, 114);
            this.rbEmp.Name = "rbEmp";
            this.rbEmp.Size = new System.Drawing.Size(95, 16);
            this.rbEmp.TabIndex = 3;
            this.rbEmp.Text = "radioButton2";
            this.rbEmp.UseVisualStyleBackColor = true;
            this.rbEmp.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblQuickSearchToolTip);
            this.groupBox1.Controls.Add(this.cardGrid);
            this.groupBox1.Controls.Add(this.txtQuickSearch);
            this.groupBox1.Controls.Add(this.lblQuickSearch);
            this.groupBox1.Controls.Add(this.btnQuickSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 199);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "EmpList";
            this.groupBox1.Text = "groupBox1";
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.Location = new System.Drawing.Point(90, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "button1";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblQuickSearchToolTip
            // 
            this.lblQuickSearchToolTip.AutoSize = true;
            this.lblQuickSearchToolTip.ForeColor = System.Drawing.Color.Blue;
            this.lblQuickSearchToolTip.Location = new System.Drawing.Point(355, 26);
            this.lblQuickSearchToolTip.Name = "lblQuickSearchToolTip";
            this.lblQuickSearchToolTip.Size = new System.Drawing.Size(41, 12);
            this.lblQuickSearchToolTip.TabIndex = 9;
            this.lblQuickSearchToolTip.Text = "label1";
            // 
            // cardGrid
            // 
            this.cardGrid.AllowUserToAddRows = false;
            this.cardGrid.AllowUserToDeleteRows = false;
            this.cardGrid.AllowUserToResizeRows = false;
            this.cardGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cardGrid.ColumnHeadersHeight = 25;
            this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cardGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.cardGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.cardGrid.Location = new System.Drawing.Point(10, 50);
            this.cardGrid.MultiSelect = false;
            this.cardGrid.Name = "cardGrid";
            this.cardGrid.ReadOnly = true;
            this.cardGrid.RowHeadersVisible = false;
            this.cardGrid.RowTemplate.Height = 23;
            this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cardGrid.Size = new System.Drawing.Size(555, 139);
            this.cardGrid.StandardTab = true;
            this.cardGrid.TabIndex = 8;
            this.cardGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.cardGrid_DataBindingComplete);
            // 
            // txtQuickSearch
            // 
            this.txtQuickSearch.Location = new System.Drawing.Point(250, 22);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(100, 21);
            this.txtQuickSearch.TabIndex = 7;
            this.txtQuickSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuickSearch_KeyDown);
            // 
            // lblQuickSearch
            // 
            this.lblQuickSearch.AutoSize = true;
            this.lblQuickSearch.Location = new System.Drawing.Point(170, 26);
            this.lblQuickSearch.Name = "lblQuickSearch";
            this.lblQuickSearch.Size = new System.Drawing.Size(41, 12);
            this.lblQuickSearch.TabIndex = 5;
            this.lblQuickSearch.Text = "label1";
            // 
            // btnQuickSearch
            // 
            this.btnQuickSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuickSearch.Location = new System.Drawing.Point(10, 20);
            this.btnQuickSearch.Name = "btnQuickSearch";
            this.btnQuickSearch.Size = new System.Drawing.Size(75, 25);
            this.btnQuickSearch.TabIndex = 5;
            this.btnQuickSearch.Text = "button1";
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(10, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(535, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(10, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(96, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(186, 401);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 1002;
            this.lblMsg.Text = "label4";
            // 
            // progBar
            // 
            // 
            // 
            // 
            this.progBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progBar.Location = new System.Drawing.Point(10, 363);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(573, 23);
            this.progBar.TabIndex = 1003;
            this.progBar.Text = "progressBarX1";
            // 
            // cbWeek
            // 
            this.cbWeek.AutoSize = true;
            this.cbWeek.Location = new System.Drawing.Point(10, 72);
            this.cbWeek.Name = "cbWeek";
            this.cbWeek.Size = new System.Drawing.Size(78, 16);
            this.cbWeek.TabIndex = 1004;
            this.cbWeek.Text = "checkBox1";
            this.cbWeek.UseVisualStyleBackColor = true;
            // 
            // frmKQDataAssay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(594, 425);
            this.Controls.Add(this.cbWeek);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbEmp);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKQDataAssay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKQDataAssay_FormClosing);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpStart, 0);
            this.Controls.SetChildIndex(this.dtpEnd, 0);
            this.Controls.SetChildIndex(this.rbAll, 0);
            this.Controls.SetChildIndex(this.rbEmp, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.lblMsg, 0);
            this.Controls.SetChildIndex(this.progBar, 0);
            this.Controls.SetChildIndex(this.cbWeek, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.RadioButton rbAll;
    private System.Windows.Forms.RadioButton rbEmp;
    private System.Windows.Forms.GroupBox groupBox1;
    private DevComponents.DotNetBar.Controls.DataGridViewX cardGrid;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private DevComponents.DotNetBar.ButtonX btnQuickSearch;
    private System.Windows.Forms.Label label3;
    private DevComponents.DotNetBar.ButtonX button1;
    private DevComponents.DotNetBar.ButtonX button2;
    private System.Windows.Forms.Label lblQuickSearchToolTip;
    private DevComponents.DotNetBar.ButtonX btnClear;
    private System.Windows.Forms.Label lblMsg;
        private DevComponents.DotNetBar.Controls.ProgressBarX progBar;
        private System.Windows.Forms.CheckBox cbWeek;
    }
}
