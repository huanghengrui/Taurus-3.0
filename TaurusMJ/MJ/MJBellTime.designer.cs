namespace Taurus
{
  partial class frmMJBellTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJBellTime));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.Column2 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.Column3 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.Column4 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.Column5 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.Column6 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.GridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemPasteUpData = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemEmptyData = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDown = new DevComponents.DotNetBar.ButtonX();
            this.btnUp = new DevComponents.DotNetBar.ButtonX();
            this.cbbCount = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.GridMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(370, 326);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(450, 326);
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
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGrid.ContextMenuStrip = this.GridMenu;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGrid.Location = new System.Drawing.Point(10, 40);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(515, 279);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
            this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGrid_DataError);
            // 
            // Column1
            // 
            this.Column1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column1.DataPropertyName = "MJPT_ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
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
            // Column2
            // 
            this.Column2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Column2.HeaderText = "Column2";
            this.Column2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column2.Name = "Column2";
            this.Column2.PasswordChar = '\0';
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Text = "";
            // 
            // Column3
            // 
            this.Column3.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Column3.HeaderText = "Column3";
            this.Column3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column3.Name = "Column3";
            this.Column3.PasswordChar = '\0';
            this.Column3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Text = "";
            // 
            // Column4
            // 
            this.Column4.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column4.DataPropertyName = "MJPT_ID";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
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
            // Column5
            // 
            this.Column5.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Column5.HeaderText = "Column5";
            this.Column5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column5.Name = "Column5";
            this.Column5.PasswordChar = '\0';
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Text = "";
            // 
            // Column6
            // 
            this.Column6.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Column6.HeaderText = "Column6";
            this.Column6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column6.Name = "Column6";
            this.Column6.PasswordChar = '\0';
            this.Column6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Text = "";
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
            this.label1.Location = new System.Drawing.Point(10, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1003;
            this.label1.Text = "label1";
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.Location = new System.Drawing.Point(140, 325);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 25);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "button1";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUp.Location = new System.Drawing.Point(245, 325);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 25);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "button2";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // cbbCount
            // 
            this.cbbCount.DisplayMember = "Text";
            this.cbbCount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCount.ForeColor = System.Drawing.Color.Black;
            this.cbbCount.FormattingEnabled = true;
            this.cbbCount.ItemHeight = 16;
            this.cbbCount.Location = new System.Drawing.Point(58, 326);
            this.cbbCount.Name = "cbbCount";
            this.cbbCount.Size = new System.Drawing.Size(62, 22);
            this.cbbCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbCount.TabIndex = 1004;
            // 
            // frmMJBellTime
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(534, 359);
            this.Controls.Add(this.cbbCount);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.dataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJBellTime";
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtTime, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnDown, 0);
            this.Controls.SetChildIndex(this.btnUp, 0);
            this.Controls.SetChildIndex(this.cbbCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.GridMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.Controls.DataGridViewX dataGrid;
    private System.Windows.Forms.MaskedTextBox txtTime;
    private System.Windows.Forms.ContextMenuStrip GridMenu;
    private System.Windows.Forms.ToolStripMenuItem ItemPasteUpData;
    private System.Windows.Forms.ToolStripMenuItem ItemEmptyData;
    private System.Windows.Forms.Label label1;
    private DevComponents.DotNetBar.ButtonX btnDown;
    private DevComponents.DotNetBar.ButtonX btnUp;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column1;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column3;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column4;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column5;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbCount;
    }
}
