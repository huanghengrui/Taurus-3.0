namespace Taurus
{
    partial class frmKQRuleEmpAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQRuleEmpAdd));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepartName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.cardGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.btnQuickSearch = new DevComponents.DotNetBar.ButtonX();
            this.btnSelectEmp = new DevComponents.DotNetBar.ButtonX();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.cbbRule = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(455, 258);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(535, 258);
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
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Tag = "EmpNo";
            this.label2.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 32;
            this.label3.Tag = "RuleIDName";
            this.label3.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Tag = "EmpName";
            this.label1.Text = "label2";
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmpName.Location = new System.Drawing.Point(80, 69);
            this.txtEmpName.MaxLength = 10;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(120, 21);
            this.txtEmpName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 36;
            this.label4.Tag = "DepartName";
            this.label4.Text = "label3";
            // 
            // txtDepartName
            // 
            this.txtDepartName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartName.Location = new System.Drawing.Point(80, 99);
            this.txtDepartName.MaxLength = 10;
            this.txtDepartName.Name = "txtDepartName";
            this.txtDepartName.Size = new System.Drawing.Size(120, 21);
            this.txtDepartName.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.cardGrid);
            this.groupBox1.Controls.Add(this.txtQuickSearch);
            this.groupBox1.Controls.Add(this.lblQuickSearch);
            this.groupBox1.Controls.Add(this.btnQuickSearch);
            this.groupBox1.Location = new System.Drawing.Point(210, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 214);
            this.groupBox1.TabIndex = 5;
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
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "button1";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cardGrid
            // 
            this.cardGrid.AllowUserToAddRows = false;
            this.cardGrid.AllowUserToDeleteRows = false;
            this.cardGrid.AllowUserToResizeRows = false;
            this.cardGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cardGrid.ColumnHeadersHeight = 25;
            this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cardGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.cardGrid.EnableHeadersVisualStyles = false;
            this.cardGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cardGrid.Location = new System.Drawing.Point(10, 50);
            this.cardGrid.MultiSelect = false;
            this.cardGrid.Name = "cardGrid";
            this.cardGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cardGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.cardGrid.RowHeadersVisible = false;
            this.cardGrid.RowTemplate.Height = 23;
            this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cardGrid.Size = new System.Drawing.Size(380, 155);
            this.cardGrid.StandardTab = true;
            this.cardGrid.TabIndex = 9;
            this.cardGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.cardGrid_DataBindingComplete);
            // 
            // txtQuickSearch
            // 
            this.txtQuickSearch.Location = new System.Drawing.Point(250, 22);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(140, 21);
            this.txtQuickSearch.TabIndex = 8;
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
            this.btnQuickSearch.TabIndex = 6;
            this.btnQuickSearch.Text = "button1";
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectEmp.Location = new System.Drawing.Point(165, 40);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 1;
            this.btnSelectEmp.Text = "...";
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(80, 39);
            this.txtEmpNo.MaxLength = 10;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(120, 21);
            this.txtEmpNo.TabIndex = 0;
            this.txtEmpNo.Leave += new System.EventHandler(this.txtEmpNo_Leave);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(210, 264);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 1002;
            this.lblMsg.Text = "label5";
            // 
            // cbbRule
            // 
            this.cbbRule.DisplayMember = "Text";
            this.cbbRule.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRule.ForeColor = System.Drawing.Color.Black;
            this.cbbRule.FormattingEnabled = true;
            this.cbbRule.ItemHeight = 16;
            this.cbbRule.Location = new System.Drawing.Point(80, 130);
            this.cbbRule.Name = "cbbRule";
            this.cbbRule.Size = new System.Drawing.Size(121, 22);
            this.cbbRule.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbRule.TabIndex = 1003;
            // 
            // frmKQRuleEmpAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(619, 291);
            this.Controls.Add(this.cbbRule);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnSelectEmp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDepartName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKQRuleEmpAdd";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtEmpName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDepartName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtEmpNo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnSelectEmp, 0);
            this.Controls.SetChildIndex(this.lblMsg, 0);
            this.Controls.SetChildIndex(this.cbbRule, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
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
    private System.Windows.Forms.GroupBox groupBox1;
    private DevComponents.DotNetBar.ButtonX btnClear;
    private DevComponents.DotNetBar.Controls.DataGridViewX cardGrid;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private DevComponents.DotNetBar.ButtonX btnQuickSearch;
    private DevComponents.DotNetBar.ButtonX btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label lblMsg;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbRule;
    }
}
