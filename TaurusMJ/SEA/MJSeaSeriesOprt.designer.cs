namespace Taurus
{
  partial class frmMJSeaSeriesOprt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJSeaSeriesOprt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSeaSeriesOprt = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lblMsg = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.msgGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.progBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lbQuickSearchMac = new System.Windows.Forms.Label();
            this.txtQuickSearchMac = new System.Windows.Forms.TextBox();
            this.GridMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(389, 373);
            this.btnOk.Text = "";
            this.btnOk.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(469, 373);
            this.btnCancel.Text = "";
            this.btnCancel.Visible = false;
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
            // GridMenu
            // 
            this.GridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemSelect,
            this.ItemUnselect});
            this.GridMenu.Name = "GridMenu";
            this.GridMenu.Size = new System.Drawing.Size(193, 48);
            // 
            // ItemSelect
            // 
            this.ItemSelect.Name = "ItemSelect";
            this.ItemSelect.Size = new System.Drawing.Size(192, 22);
            this.ItemSelect.Text = "toolStripMenuItem1";
            this.ItemSelect.Click += new System.EventHandler(this.ItemSelect_Click);
            // 
            // ItemUnselect
            // 
            this.ItemUnselect.Name = "ItemUnselect";
            this.ItemUnselect.Size = new System.Drawing.Size(192, 22);
            this.ItemUnselect.Text = "toolStripMenuItem2";
            this.ItemUnselect.Click += new System.EventHandler(this.ItemUnselect_Click);
            // 
            // bindingSource
            // 
            this.bindingSource.AllowNew = false;
            // 
            // btnSeaSeriesOprt
            // 
            this.btnSeaSeriesOprt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSeaSeriesOprt.Location = new System.Drawing.Point(10, 432);
            this.btnSeaSeriesOprt.Name = "btnSeaSeriesOprt";
            this.btnSeaSeriesOprt.Size = new System.Drawing.Size(100, 25);
            this.btnSeaSeriesOprt.TabIndex = 2;
            this.btnSeaSeriesOprt.Text = "button1";
            this.btnSeaSeriesOprt.Click += new System.EventHandler(this.btnOprt_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Location = new System.Drawing.Point(610, 432);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "button2";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(255, 428);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = "label1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(11, 68);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.msgGrid);
            this.splitContainer1.Size = new System.Drawing.Size(671, 352);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.TabIndex = 14;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeight = 25;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid.ContextMenuStrip = this.GridMenu;
            this.dataGrid.DataSource = this.bindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.EnableHeadersVisualStyles = false;
            this.dataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(671, 241);
            this.dataGrid.StandardTab = true;
            this.dataGrid.TabIndex = 2;
            this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGrid_DataError);
            this.dataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGrid_KeyDown);
            this.dataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGrid_KeyUp);
            this.dataGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseClick);
            // 
            // msgGrid
            // 
            this.msgGrid.AllowUserToAddRows = false;
            this.msgGrid.AllowUserToDeleteRows = false;
            this.msgGrid.AllowUserToResizeColumns = false;
            this.msgGrid.AllowUserToResizeRows = false;
            this.msgGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msgGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.msgGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.msgGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.msgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.msgGrid.ColumnHeadersVisible = false;
            this.msgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.msgGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.msgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgGrid.EnableHeadersVisualStyles = false;
            this.msgGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.msgGrid.Location = new System.Drawing.Point(0, 0);
            this.msgGrid.MultiSelect = false;
            this.msgGrid.Name = "msgGrid";
            this.msgGrid.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.msgGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.msgGrid.RowHeadersVisible = false;
            this.msgGrid.RowTemplate.Height = 23;
            this.msgGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.msgGrid.Size = new System.Drawing.Size(671, 107);
            this.msgGrid.TabIndex = 3;
            this.msgGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.msgGrid_CellDoubleClick);
            this.msgGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.msgGrid_DataError);
            this.msgGrid.Resize += new System.EventHandler(this.msgGrid_Resize);
            // 
            // Column1
            // 
            this.Column1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Column1.HeaderText = "Column1";
            this.Column1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column1.Name = "Column1";
            this.Column1.PasswordChar = '\0';
            this.Column1.ReadOnly = true;
            this.Column1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Column1.Text = "";
            // 
            // progBar
            // 
            // 
            // 
            // 
            this.progBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progBar.Location = new System.Drawing.Point(187, 446);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(340, 17);
            this.progBar.TabIndex = 15;
            this.progBar.Text = "progressBarX1";
            // 
            // lbQuickSearchMac
            // 
            this.lbQuickSearchMac.AutoSize = true;
            this.lbQuickSearchMac.Location = new System.Drawing.Point(443, 43);
            this.lbQuickSearchMac.Name = "lbQuickSearchMac";
            this.lbQuickSearchMac.Size = new System.Drawing.Size(41, 12);
            this.lbQuickSearchMac.TabIndex = 16;
            this.lbQuickSearchMac.Tag = "lblQuickSearch";
            this.lbQuickSearchMac.Text = "label1";
            // 
            // txtQuickSearchMac
            // 
            this.txtQuickSearchMac.Location = new System.Drawing.Point(520, 39);
            this.txtQuickSearchMac.Name = "txtQuickSearchMac";
            this.txtQuickSearchMac.Size = new System.Drawing.Size(161, 21);
            this.txtQuickSearchMac.TabIndex = 17;
            this.txtQuickSearchMac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuickSearchMac_KeyDown);
            // 
            // frmMJSeaSeriesOprt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(693, 469);
            this.Controls.Add(this.txtQuickSearchMac);
            this.Controls.Add(this.lbQuickSearchMac);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSeaSeriesOprt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJSeaSeriesOprt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMJOprt_FormClosing);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSeaSeriesOprt, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.lblMsg, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.progBar, 0);
            this.Controls.SetChildIndex(this.lbQuickSearchMac, 0);
            this.Controls.SetChildIndex(this.txtQuickSearchMac, 0);
            this.GridMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    protected System.Windows.Forms.BindingSource bindingSource;
    private DevComponents.DotNetBar.ButtonX btnSeaSeriesOprt;
    private DevComponents.DotNetBar.ButtonX btnExit;
    private System.Windows.Forms.Label lblMsg;
    private System.Windows.Forms.ContextMenuStrip GridMenu;
    private System.Windows.Forms.ToolStripMenuItem ItemSelect;
    private System.Windows.Forms.ToolStripMenuItem ItemUnselect;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public DevComponents.DotNetBar.Controls.DataGridViewX dataGrid;
        private DevComponents.DotNetBar.Controls.DataGridViewX msgGrid;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column1;
        private DevComponents.DotNetBar.Controls.ProgressBarX progBar;
        private System.Windows.Forms.Label lbQuickSearchMac;
        private System.Windows.Forms.TextBox txtQuickSearchMac;
    }
}
