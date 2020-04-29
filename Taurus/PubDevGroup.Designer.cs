namespace Taurus
{
    partial class frmPubDevGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubDevGroup));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbDevGroup = new System.Windows.Forms.Label();
            this.tvEmp = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnParentGroup = new DevComponents.DotNetBar.ButtonX();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.ItemAdd = new System.Windows.Forms.ToolStripButton();
            this.ItemEdit = new System.Windows.Forms.ToolStripButton();
            this.ItemDelete = new System.Windows.Forms.ToolStripButton();
            this.ItemLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemSave = new System.Windows.Forms.ToolStripButton();
            this.ItemUnsave = new System.Windows.Forms.ToolStripButton();
            this.ItemLine4 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemClose = new System.Windows.Forms.ToolStripButton();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtGroupSuperior = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtGroupNo = new System.Windows.Forms.TextBox();
            this.lbRemarks = new System.Windows.Forms.Label();
            this.lbGroupSuperior = new System.Windows.Forms.Label();
            this.lbGroupName = new System.Windows.Forms.Label();
            this.lbGroupNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(390, 354);
            this.btnOk.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(470, 354);
            this.btnCancel.Text = "";
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(1, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.tvEmp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Size = new System.Drawing.Size(612, 362);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 1015;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.lbDevGroup);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(197, 40);
            this.panel4.TabIndex = 12;
            // 
            // lbDevGroup
            // 
            this.lbDevGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDevGroup.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevGroup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbDevGroup.Location = new System.Drawing.Point(0, 0);
            this.lbDevGroup.Name = "lbDevGroup";
            this.lbDevGroup.Size = new System.Drawing.Size(197, 40);
            this.lbDevGroup.TabIndex = 0;
            this.lbDevGroup.Text = "lbDevGroup";
            this.lbDevGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvEmp
            // 
            this.tvEmp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvEmp.FullRowSelect = true;
            this.tvEmp.HideSelection = false;
            this.tvEmp.ItemHeight = 20;
            this.tvEmp.Location = new System.Drawing.Point(8, 46);
            this.tvEmp.Name = "tvEmp";
            this.tvEmp.Size = new System.Drawing.Size(181, 305);
            this.tvEmp.TabIndex = 11;
            this.tvEmp.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvEmp_AfterSelect);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.btnParentGroup);
            this.panel5.Controls.Add(this.Toolbar);
            this.panel5.Controls.Add(this.txtRemarks);
            this.panel5.Controls.Add(this.txtGroupSuperior);
            this.panel5.Controls.Add(this.txtGroupName);
            this.panel5.Controls.Add(this.txtGroupNo);
            this.panel5.Controls.Add(this.lbRemarks);
            this.panel5.Controls.Add(this.lbGroupSuperior);
            this.panel5.Controls.Add(this.lbGroupName);
            this.panel5.Controls.Add(this.lbGroupNo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(411, 362);
            this.panel5.TabIndex = 0;
            // 
            // btnParentGroup
            // 
            this.btnParentGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnParentGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParentGroup.Location = new System.Drawing.Point(343, 170);
            this.btnParentGroup.Name = "btnParentGroup";
            this.btnParentGroup.Size = new System.Drawing.Size(31, 21);
            this.btnParentGroup.TabIndex = 1001;
            this.btnParentGroup.Text = "...";
            this.btnParentGroup.Click += new System.EventHandler(this.btnParentGroup_Click);
            // 
            // Toolbar
            // 
            this.Toolbar.BackColor = System.Drawing.Color.White;
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemAdd,
            this.ItemEdit,
            this.ItemDelete,
            this.ItemLine2,
            this.ItemSave,
            this.ItemUnsave,
            this.ItemLine4,
            this.ItemClose});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(411, 40);
            this.Toolbar.TabIndex = 14;
            this.Toolbar.Text = "Toolbar";
            // 
            // ItemAdd
            // 
            this.ItemAdd.Image = global::Taurus.Properties.Resources.AddBtn;
            this.ItemAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemAdd.Name = "ItemAdd";
            this.ItemAdd.Size = new System.Drawing.Size(23, 37);
            this.ItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemAdd.Click += new System.EventHandler(this.ItemAdd_Click);
            // 
            // ItemEdit
            // 
            this.ItemEdit.Image = global::Taurus.Properties.Resources.EditBtn;
            this.ItemEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemEdit.Name = "ItemEdit";
            this.ItemEdit.Size = new System.Drawing.Size(23, 37);
            this.ItemEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemEdit.Click += new System.EventHandler(this.ItemEdit_Click);
            // 
            // ItemDelete
            // 
            this.ItemDelete.Image = global::Taurus.Properties.Resources.DeleteBtn;
            this.ItemDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemDelete.Name = "ItemDelete";
            this.ItemDelete.Size = new System.Drawing.Size(23, 37);
            this.ItemDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemDelete.Click += new System.EventHandler(this.ItemDelete_Click);
            // 
            // ItemLine2
            // 
            this.ItemLine2.Name = "ItemLine2";
            this.ItemLine2.Size = new System.Drawing.Size(6, 40);
            // 
            // ItemSave
            // 
            this.ItemSave.Image = global::Taurus.Properties.Resources.EditSelectAll;
            this.ItemSave.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemSave.Name = "ItemSave";
            this.ItemSave.Size = new System.Drawing.Size(23, 37);
            this.ItemSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemSave.Click += new System.EventHandler(this.ItemSave_Click);
            // 
            // ItemUnsave
            // 
            this.ItemUnsave.Image = global::Taurus.Properties.Resources.EditUnSelectAll;
            this.ItemUnsave.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemUnsave.Name = "ItemUnsave";
            this.ItemUnsave.Size = new System.Drawing.Size(23, 37);
            this.ItemUnsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemUnsave.Click += new System.EventHandler(this.ItemUnsave_Click);
            // 
            // ItemLine4
            // 
            this.ItemLine4.Name = "ItemLine4";
            this.ItemLine4.Size = new System.Drawing.Size(6, 40);
            // 
            // ItemClose
            // 
            this.ItemClose.Image = global::Taurus.Properties.Resources.Exit;
            this.ItemClose.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemClose.Name = "ItemClose";
            this.ItemClose.Size = new System.Drawing.Size(107, 37);
            this.ItemClose.Text = "toolStripButton1";
            this.ItemClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemClose.Click += new System.EventHandler(this.ItemClose_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Enabled = false;
            this.txtRemarks.Location = new System.Drawing.Point(143, 216);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(231, 117);
            this.txtRemarks.TabIndex = 7;
            // 
            // txtGroupSuperior
            // 
            this.txtGroupSuperior.Enabled = false;
            this.txtGroupSuperior.Location = new System.Drawing.Point(143, 170);
            this.txtGroupSuperior.Name = "txtGroupSuperior";
            this.txtGroupSuperior.Size = new System.Drawing.Size(231, 21);
            this.txtGroupSuperior.TabIndex = 6;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Enabled = false;
            this.txtGroupName.Location = new System.Drawing.Point(143, 125);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(231, 21);
            this.txtGroupName.TabIndex = 5;
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.Enabled = false;
            this.txtGroupNo.Location = new System.Drawing.Point(143, 81);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(231, 21);
            this.txtGroupNo.TabIndex = 4;
            // 
            // lbRemarks
            // 
            this.lbRemarks.AutoSize = true;
            this.lbRemarks.Location = new System.Drawing.Point(40, 217);
            this.lbRemarks.Name = "lbRemarks";
            this.lbRemarks.Size = new System.Drawing.Size(59, 12);
            this.lbRemarks.TabIndex = 3;
            this.lbRemarks.Text = "lbRemarks";
            // 
            // lbGroupSuperior
            // 
            this.lbGroupSuperior.AutoSize = true;
            this.lbGroupSuperior.Location = new System.Drawing.Point(38, 174);
            this.lbGroupSuperior.Name = "lbGroupSuperior";
            this.lbGroupSuperior.Size = new System.Drawing.Size(95, 12);
            this.lbGroupSuperior.TabIndex = 2;
            this.lbGroupSuperior.Text = "lbGroupSuperior";
            // 
            // lbGroupName
            // 
            this.lbGroupName.AutoSize = true;
            this.lbGroupName.Location = new System.Drawing.Point(40, 129);
            this.lbGroupName.Name = "lbGroupName";
            this.lbGroupName.Size = new System.Drawing.Size(71, 12);
            this.lbGroupName.TabIndex = 1;
            this.lbGroupName.Text = "lbGroupName";
            // 
            // lbGroupNo
            // 
            this.lbGroupNo.AutoSize = true;
            this.lbGroupNo.Location = new System.Drawing.Point(40, 85);
            this.lbGroupNo.Name = "lbGroupNo";
            this.lbGroupNo.Size = new System.Drawing.Size(59, 12);
            this.lbGroupNo.TabIndex = 0;
            this.lbGroupNo.Text = "lbGroupNo";
            // 
            // frmPubDevGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 394);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPubDevGroup";
            this.Text = "PubDevGroup";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbDevGroup;
        protected System.Windows.Forms.TreeView tvEmp;
        private System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.ToolStrip Toolbar;
        protected System.Windows.Forms.ToolStripButton ItemAdd;
        protected System.Windows.Forms.ToolStripButton ItemEdit;
        protected System.Windows.Forms.ToolStripButton ItemDelete;
        protected System.Windows.Forms.ToolStripSeparator ItemLine2;
        protected System.Windows.Forms.ToolStripButton ItemSave;
        protected System.Windows.Forms.ToolStripButton ItemUnsave;
        protected System.Windows.Forms.ToolStripSeparator ItemLine4;
        private System.Windows.Forms.ToolStripButton ItemClose;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtGroupSuperior;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtGroupNo;
        private System.Windows.Forms.Label lbRemarks;
        private System.Windows.Forms.Label lbGroupSuperior;
        private System.Windows.Forms.Label lbGroupName;
        private System.Windows.Forms.Label lbGroupNo;
        public DevComponents.DotNetBar.ButtonX btnParentGroup;
    }
}