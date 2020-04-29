namespace Taurus
{
    partial class frmRSDimissionAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRSDimissionAdd));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDimissionOprt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDimissionReason = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDimissionDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectEmp = new DevComponents.DotNetBar.ButtonX();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.cardGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.btnQuickSearch = new DevComponents.DotNetBar.ButtonX();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(465, 326);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(545, 326);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // txtDimissionOprt
            // 
            this.txtDimissionOprt.Location = new System.Drawing.Point(94, 163);
            this.txtDimissionOprt.MaxLength = 10;
            this.txtDimissionOprt.Name = "txtDimissionOprt";
            this.txtDimissionOprt.Size = new System.Drawing.Size(159, 21);
            this.txtDimissionOprt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(4, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1008;
            this.label4.Tag = "DimissionOprt";
            this.label4.Text = "label4";
            // 
            // txtDimissionReason
            // 
            this.txtDimissionReason.Location = new System.Drawing.Point(94, 193);
            this.txtDimissionReason.MaxLength = 255;
            this.txtDimissionReason.Multiline = true;
            this.txtDimissionReason.Name = "txtDimissionReason";
            this.txtDimissionReason.Size = new System.Drawing.Size(160, 125);
            this.txtDimissionReason.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(4, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1054;
            this.label8.Tag = "DimissionReason";
            this.label8.Text = "label8";
            // 
            // dtpDimissionDate
            // 
            this.dtpDimissionDate.CustomFormat = "";
            this.dtpDimissionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDimissionDate.Location = new System.Drawing.Point(94, 133);
            this.dtpDimissionDate.Name = "dtpDimissionDate";
            this.dtpDimissionDate.Size = new System.Drawing.Size(160, 21);
            this.dtpDimissionDate.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(4, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1052;
            this.label5.Tag = "DimissionDate";
            this.label5.Text = "label5";
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectEmp.Location = new System.Drawing.Point(219, 44);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 1;
            this.btnSelectEmp.Text = "button1";
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(94, 103);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.ReadOnly = true;
            this.txtDepart.Size = new System.Drawing.Size(160, 21);
            this.txtDepart.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(4, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1050;
            this.label1.Tag = "Depart";
            this.label1.Text = "label1";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(94, 73);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(160, 21);
            this.txtEmpName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(4, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1049;
            this.label3.Tag = "EmpName";
            this.label3.Text = "label3";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(94, 43);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(160, 21);
            this.txtEmpNo.TabIndex = 0;
            this.txtEmpNo.Leave += new System.EventHandler(this.txtEmpNo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1048;
            this.label2.Tag = "EmpNo";
            this.label2.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.cardGrid);
            this.groupBox1.Controls.Add(this.txtQuickSearch);
            this.groupBox1.Controls.Add(this.lblQuickSearch);
            this.groupBox1.Controls.Add(this.btnQuickSearch);
            this.groupBox1.Location = new System.Drawing.Point(264, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 275);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "SameEmp";
            this.groupBox1.Text = "groupBox1";
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.Location = new System.Drawing.Point(90, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "button1";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cardGrid
            // 
            this.cardGrid.AllowUserToAddRows = false;
            this.cardGrid.AllowUserToDeleteRows = false;
            this.cardGrid.AllowUserToResizeRows = false;
            this.cardGrid.BackgroundColor = System.Drawing.SystemColors.Control;
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
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
            this.cardGrid.Size = new System.Drawing.Size(330, 215);
            this.cardGrid.StandardTab = true;
            this.cardGrid.TabIndex = 12;
            this.cardGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.cardGrid_DataBindingComplete);
            // 
            // txtQuickSearch
            // 
            this.txtQuickSearch.Location = new System.Drawing.Point(250, 22);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(90, 21);
            this.txtQuickSearch.TabIndex = 10;
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
            this.btnQuickSearch.TabIndex = 8;
            this.btnQuickSearch.Text = "button1";
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(264, 328);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 1055;
            this.lblMsg.Text = "label6";
            // 
            // frmRSDimissionAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(629, 360);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDimissionReason);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpDimissionDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelectEmp);
            this.Controls.Add(this.txtDepart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDimissionOprt);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmRSDimissionAdd";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDimissionOprt, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtEmpNo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtEmpName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDepart, 0);
            this.Controls.SetChildIndex(this.btnSelectEmp, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dtpDimissionDate, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtDimissionReason, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblMsg, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtDimissionOprt;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDimissionReason;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.DateTimePicker dtpDimissionDate;
    private System.Windows.Forms.Label label5;
    private DevComponents.DotNetBar.ButtonX btnSelectEmp;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.GroupBox groupBox1;
    private DevComponents.DotNetBar.ButtonX btnClear;
    private DevComponents.DotNetBar.Controls.DataGridViewX cardGrid;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private DevComponents.DotNetBar.ButtonX btnQuickSearch;
    private System.Windows.Forms.Label lblMsg;

  }
}
