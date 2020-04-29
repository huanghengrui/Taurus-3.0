namespace Taurus
{
  partial class frmSelectEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectEmp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.gbxEmpInfo = new System.Windows.Forms.GroupBox();
            this.cardGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblQuickSearchToolTip = new System.Windows.Forms.Label();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.btnQuickSearch = new DevComponents.DotNetBar.ButtonX();
            this.lblMsg = new System.Windows.Forms.Label();
            this.rbEmp = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.gbxEmpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(480, 409);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(560, 409);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "");
            this.ilTreeState.Images.SetKeyName(1, "");
            this.ilTreeState.Images.SetKeyName(2, "");
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.Location = new System.Drawing.Point(90, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "button1";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gbxEmpInfo
            // 
            this.gbxEmpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEmpInfo.Controls.Add(this.cardGrid);
            this.gbxEmpInfo.Controls.Add(this.lblQuickSearchToolTip);
            this.gbxEmpInfo.Controls.Add(this.btnClear);
            this.gbxEmpInfo.Controls.Add(this.txtQuickSearch);
            this.gbxEmpInfo.Controls.Add(this.lblQuickSearch);
            this.gbxEmpInfo.Controls.Add(this.btnQuickSearch);
            this.gbxEmpInfo.Location = new System.Drawing.Point(10, 76);
            this.gbxEmpInfo.Name = "gbxEmpInfo";
            this.gbxEmpInfo.Size = new System.Drawing.Size(625, 323);
            this.gbxEmpInfo.TabIndex = 2;
            this.gbxEmpInfo.TabStop = false;
            this.gbxEmpInfo.Text = "groupBox1";
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
            this.cardGrid.Size = new System.Drawing.Size(605, 263);
            this.cardGrid.StandardTab = true;
            this.cardGrid.TabIndex = 6;
            this.cardGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.cardGrid_DataBindingComplete);
            // 
            // lblQuickSearchToolTip
            // 
            this.lblQuickSearchToolTip.AutoSize = true;
            this.lblQuickSearchToolTip.Location = new System.Drawing.Point(355, 26);
            this.lblQuickSearchToolTip.Name = "lblQuickSearchToolTip";
            this.lblQuickSearchToolTip.Size = new System.Drawing.Size(41, 12);
            this.lblQuickSearchToolTip.TabIndex = 7;
            this.lblQuickSearchToolTip.Text = "label1";
            // 
            // txtQuickSearch
            // 
            this.txtQuickSearch.Location = new System.Drawing.Point(250, 22);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(100, 21);
            this.txtQuickSearch.TabIndex = 5;
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
            this.btnQuickSearch.TabIndex = 3;
            this.btnQuickSearch.Text = "button1";
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(15, 409);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 1002;
            this.lblMsg.Text = "label1";
            // 
            // rbEmp
            // 
            this.rbEmp.AutoSize = true;
            this.rbEmp.Location = new System.Drawing.Point(17, 54);
            this.rbEmp.Name = "rbEmp";
            this.rbEmp.Size = new System.Drawing.Size(95, 16);
            this.rbEmp.TabIndex = 1;
            this.rbEmp.Text = "radioButton2";
            this.rbEmp.UseVisualStyleBackColor = true;
            this.rbEmp.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(17, 34);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(95, 16);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "radioButton1";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // frmSelectEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(644, 442);
            this.Controls.Add(this.rbEmp);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.gbxEmpInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectEmp";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbxEmpInfo, 0);
            this.Controls.SetChildIndex(this.lblMsg, 0);
            this.Controls.SetChildIndex(this.rbAll, 0);
            this.Controls.SetChildIndex(this.rbEmp, 0);
            this.gbxEmpInfo.ResumeLayout(false);
            this.gbxEmpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.ButtonX btnClear;
    private System.Windows.Forms.GroupBox gbxEmpInfo;
    private DevComponents.DotNetBar.Controls.DataGridViewX cardGrid;
    private System.Windows.Forms.Label lblQuickSearchToolTip;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private DevComponents.DotNetBar.ButtonX btnQuickSearch;
    private System.Windows.Forms.Label lblMsg;
    private System.Windows.Forms.RadioButton rbEmp;
    private System.Windows.Forms.RadioButton rbAll;
  }
}
