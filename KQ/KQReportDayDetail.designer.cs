namespace Taurus
{
  partial class frmKQReportDayDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQReportDayDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.findGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.Column3 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column4 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            ((System.ComponentModel.ISupportInitialize)(this.findGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "");
            // 
            // findGrid
            // 
            this.findGrid.AllowUserToAddRows = false;
            this.findGrid.AllowUserToDeleteRows = false;
            this.findGrid.AllowUserToResizeRows = false;
            this.findGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.findGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.findGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.findGrid.ColumnHeadersHeight = 20;
            this.findGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.findGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.findGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.findGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findGrid.GridColor = System.Drawing.Color.White;
            this.findGrid.Location = new System.Drawing.Point(0, 0);
            this.findGrid.MultiSelect = false;
            this.findGrid.Name = "findGrid";
            this.findGrid.ReadOnly = true;
            this.findGrid.RowHeadersVisible = false;
            this.findGrid.RowTemplate.Height = 20;
            this.findGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.findGrid.Size = new System.Drawing.Size(334, 136);
            this.findGrid.StandardTab = true;
            this.findGrid.TabIndex = 1;
            this.findGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.findGrid_DataError);
            // 
            // Column1
            // 
            this.Column1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column1.DataPropertyName = "KQDateTime";
            this.Column1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Column1.HeaderText = "Column1";
            this.Column1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column1.Name = "Column1";
            this.Column1.PasswordChar = '\0';
            this.Column1.ReadOnly = true;
            this.Column1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Text = "";
            // 
            // Column3
            // 
            this.Column3.Checked = true;
            this.Column3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column3.CheckValue = "N";
            this.Column3.DataPropertyName = "IsSignIn";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            this.Column4.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column4.DataPropertyName = "Remark";
            this.Column4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Column4.HeaderText = "Column4";
            this.Column4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column4.Name = "Column4";
            this.Column4.PasswordChar = '\0';
            this.Column4.ReadOnly = true;
            this.Column4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Text = "";
            // 
            // frmKQReportDayDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(334, 136);
            this.Controls.Add(this.findGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKQReportDayDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.findGrid)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.DataGridViewX findGrid;
    private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column1;
    private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column3;
    private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column4;
  }
}
