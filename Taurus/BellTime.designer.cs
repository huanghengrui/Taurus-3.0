namespace Taurus
{
  partial class frmBellTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBellTime));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new HeaderView(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvGrid = new System.Windows.Forms.TreeView();
            this.GridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemPasteUpData = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemEmptyData = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbCount = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.GridMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(170, 303);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 303);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.CellHeight = 17;
            this.dataGrid.ColumnDeep = 2;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeight = 34;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGrid.ColumnTreeView = new System.Windows.Forms.TreeView[] {
        this.tvGrid};
            this.dataGrid.ContextMenuStrip = this.GridMenu;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrid.Location = new System.Drawing.Point(4, 35);
            this.dataGrid.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dataGrid.MergeColumnNames")));
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RefreshAtHscroll = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(324, 258);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
            this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGrid_DataError);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MJPT_ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.GridMenu.Opening += new System.ComponentModel.CancelEventHandler(this.GridMenu_Opening);
            // 
            // ItemPasteUpData
            // 
            this.ItemPasteUpData.Name = "ItemPasteUpData";
            this.ItemPasteUpData.Size = new System.Drawing.Size(192, 22);
            this.ItemPasteUpData.Text = "toolStripMenuItem1";
            this.ItemPasteUpData.Click += new System.EventHandler(this.ItemPasteUpData_Click);
            // 
            // ItemEmptyData
            // 
            this.ItemEmptyData.Name = "ItemEmptyData";
            this.ItemEmptyData.Size = new System.Drawing.Size(192, 22);
            this.ItemEmptyData.Text = "toolStripMenuItem2";
            this.ItemEmptyData.Click += new System.EventHandler(this.ItemEmptyData_Click);
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
            this.label1.Location = new System.Drawing.Point(10, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1003;
            this.label1.Text = "label1";
            // 
            // cbbCount
            // 
            this.cbbCount.DisplayMember = "Text";
            this.cbbCount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCount.ForeColor = System.Drawing.Color.Black;
            this.cbbCount.FormattingEnabled = true;
            this.cbbCount.ItemHeight = 16;
            this.cbbCount.Location = new System.Drawing.Point(74, 303);
            this.cbbCount.Name = "cbbCount";
            this.cbbCount.Size = new System.Drawing.Size(50, 22);
            this.cbbCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbCount.TabIndex = 1004;
            // 
            // frmBellTime
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(329, 336);
            this.Controls.Add(this.cbbCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.dataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBellTime";
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtTime, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbbCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.GridMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private HeaderView dataGrid;
    private System.Windows.Forms.TreeView tvGrid;
    private System.Windows.Forms.MaskedTextBox txtTime;
    private System.Windows.Forms.ContextMenuStrip GridMenu;
    private System.Windows.Forms.ToolStripMenuItem ItemPasteUpData;
    private System.Windows.Forms.ToolStripMenuItem ItemEmptyData;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbCount;
    }
}
