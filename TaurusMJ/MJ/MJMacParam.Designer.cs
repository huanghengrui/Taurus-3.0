namespace Taurus
{
    partial class frmMJMacParam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJMacParam));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.ItemAdd = new System.Windows.Forms.ToolStripButton();
            this.ItemEdit = new System.Windows.Forms.ToolStripButton();
            this.ItemMomAdd = new System.Windows.Forms.ToolStripButton();
            this.ItemMomEdit = new System.Windows.Forms.ToolStripButton();
            this.ItemDelete = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG1 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG2 = new System.Windows.Forms.ToolStripButton();
            this.ItemRefresh = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.msgGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.Toolbar.SuspendLayout();
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
            this.btnOk.Location = new System.Drawing.Point(389, 300);
            this.btnOk.Text = "";
            this.btnOk.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(469, 300);
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
            // Toolbar
            // 
            this.Toolbar.AutoSize = false;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemAdd,
            this.ItemEdit,
            this.ItemMomAdd,
            this.ItemMomEdit,
            this.ItemDelete,
            this.ItemTAG1,
            this.ItemTAG2,
            this.ItemRefresh});
            this.Toolbar.Location = new System.Drawing.Point(1, 31);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(798, 32);
            this.Toolbar.TabIndex = 16;
            this.Toolbar.Text = "Toolbar";
            // 
            // ItemAdd
            // 
            this.ItemAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ItemAdd.ForeColor = System.Drawing.Color.White;
            this.ItemAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemAdd.Margin = new System.Windows.Forms.Padding(5);
            this.ItemAdd.Name = "ItemAdd";
            this.ItemAdd.Size = new System.Drawing.Size(23, 22);
            this.ItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemAdd.Click += new System.EventHandler(this.ItemAdd_Click);
            // 
            // ItemEdit
            // 
            this.ItemEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ItemEdit.ForeColor = System.Drawing.Color.White;
            this.ItemEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemEdit.Margin = new System.Windows.Forms.Padding(5);
            this.ItemEdit.Name = "ItemEdit";
            this.ItemEdit.Size = new System.Drawing.Size(23, 22);
            this.ItemEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemEdit.Click += new System.EventHandler(this.ItemEdit_Click);
            // 
            // ItemMomAdd
            // 
            this.ItemMomAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ItemMomAdd.ForeColor = System.Drawing.Color.White;
            this.ItemMomAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemMomAdd.Margin = new System.Windows.Forms.Padding(5);
            this.ItemMomAdd.Name = "ItemMomAdd";
            this.ItemMomAdd.Size = new System.Drawing.Size(23, 22);
            this.ItemMomAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemMomAdd.Click += new System.EventHandler(this.ItemMomAdd_Click);
            // 
            // ItemMomEdit
            // 
            this.ItemMomEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ItemMomEdit.ForeColor = System.Drawing.Color.White;
            this.ItemMomEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemMomEdit.Margin = new System.Windows.Forms.Padding(5);
            this.ItemMomEdit.Name = "ItemMomEdit";
            this.ItemMomEdit.Size = new System.Drawing.Size(23, 22);
            this.ItemMomEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemMomEdit.Click += new System.EventHandler(this.ItemMomEdit_Click);
            // 
            // ItemDelete
            // 
            this.ItemDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ItemDelete.ForeColor = System.Drawing.Color.White;
            this.ItemDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemDelete.Margin = new System.Windows.Forms.Padding(5);
            this.ItemDelete.Name = "ItemDelete";
            this.ItemDelete.Size = new System.Drawing.Size(23, 22);
            this.ItemDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemDelete.Click += new System.EventHandler(this.ItemDelete_Click);
            // 
            // ItemTAG1
            // 
            this.ItemTAG1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ItemTAG1.ForeColor = System.Drawing.Color.White;
            this.ItemTAG1.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG1.Margin = new System.Windows.Forms.Padding(5);
            this.ItemTAG1.Name = "ItemTAG1";
            this.ItemTAG1.Size = new System.Drawing.Size(23, 22);
            this.ItemTAG1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG1.Click += new System.EventHandler(this.ItemTAG1_Click);
            // 
            // ItemTAG2
            // 
            this.ItemTAG2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ItemTAG2.ForeColor = System.Drawing.Color.White;
            this.ItemTAG2.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG2.Margin = new System.Windows.Forms.Padding(5);
            this.ItemTAG2.Name = "ItemTAG2";
            this.ItemTAG2.Size = new System.Drawing.Size(23, 22);
            this.ItemTAG2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG2.Click += new System.EventHandler(this.ItemTAG2_Click);
            // 
            // ItemRefresh
            // 
            this.ItemRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.ItemRefresh.ForeColor = System.Drawing.Color.White;
            this.ItemRefresh.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.ItemRefresh.Name = "ItemRefresh";
            this.ItemRefresh.Size = new System.Drawing.Size(23, 22);
            this.ItemRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemRefresh.Click += new System.EventHandler(this.ItemRefresh_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(1, 63);
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
            this.splitContainer1.Size = new System.Drawing.Size(798, 392);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 1009;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
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
            this.dataGrid.Size = new System.Drawing.Size(798, 328);
            this.dataGrid.StandardTab = true;
            this.dataGrid.TabIndex = 15;
            this.dataGrid.UseCustomBackgroundColor = true;
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
            this.msgGrid.Size = new System.Drawing.Size(798, 60);
            this.msgGrid.TabIndex = 5;
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
            // frmMJMacParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 456);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmMJMacParam";
            this.ShowInTaskbar = true;
            this.Text = "MJMacParam";
            this.Load += new System.EventHandler(this.frmPubMacParam_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.Toolbar, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.ToolStrip Toolbar;
        protected System.Windows.Forms.ToolStripButton ItemAdd;
        protected System.Windows.Forms.ToolStripButton ItemEdit;
        protected System.Windows.Forms.ToolStripButton ItemDelete;
        protected System.Windows.Forms.ToolStripButton ItemTAG1;
        protected System.Windows.Forms.ToolStripButton ItemTAG2;
        protected System.Windows.Forms.ToolStripButton ItemRefresh;
        protected System.Windows.Forms.ToolStripButton ItemMomEdit;
        protected System.Windows.Forms.ToolStripButton ItemMomAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGrid;
        private DevComponents.DotNetBar.Controls.DataGridViewX msgGrid;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column1;
    }
}