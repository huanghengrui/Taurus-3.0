namespace Taurus
{
    partial class frmKQRuleDepartAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQRuleDepartAdd));
            this.label2 = new System.Windows.Forms.Label();
            this.txtDepartID = new System.Windows.Forms.TextBox();
            this.btnSelectDepart = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepartName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optSelectAll = new System.Windows.Forms.RadioButton();
            this.optSelect = new System.Windows.Forms.RadioButton();
            this.tvDepart = new System.Windows.Forms.TreeView();
            this.cbbRule = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(455, 320);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(535, 320);
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
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Tag = "DepartID";
            this.label2.Text = "label1";
            // 
            // txtDepartID
            // 
            this.txtDepartID.Location = new System.Drawing.Point(80, 39);
            this.txtDepartID.MaxLength = 10;
            this.txtDepartID.Name = "txtDepartID";
            this.txtDepartID.Size = new System.Drawing.Size(120, 21);
            this.txtDepartID.TabIndex = 0;
            this.txtDepartID.Leave += new System.EventHandler(this.txtDepartID_Leave);
            // 
            // btnSelectDepart
            // 
            this.btnSelectDepart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectDepart.Location = new System.Drawing.Point(165, 40);
            this.btnSelectDepart.Name = "btnSelectDepart";
            this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart.TabIndex = 1;
            this.btnSelectDepart.Text = "...";
            this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 32;
            this.label3.Tag = "RuleIDName";
            this.label3.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 36;
            this.label4.Tag = "DepartName";
            this.label4.Text = "label3";
            // 
            // txtDepartName
            // 
            this.txtDepartName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartName.Location = new System.Drawing.Point(80, 69);
            this.txtDepartName.MaxLength = 10;
            this.txtDepartName.Name = "txtDepartName";
            this.txtDepartName.Size = new System.Drawing.Size(120, 21);
            this.txtDepartName.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optSelectAll);
            this.groupBox1.Controls.Add(this.optSelect);
            this.groupBox1.Controls.Add(this.tvDepart);
            this.groupBox1.Location = new System.Drawing.Point(210, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 275);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "SameDepart";
            this.groupBox1.Text = "groupBox1";
            // 
            // optSelectAll
            // 
            this.optSelectAll.AutoSize = true;
            this.optSelectAll.Location = new System.Drawing.Point(10, 40);
            this.optSelectAll.Name = "optSelectAll";
            this.optSelectAll.Size = new System.Drawing.Size(95, 16);
            this.optSelectAll.TabIndex = 6;
            this.optSelectAll.TabStop = true;
            this.optSelectAll.Text = "radioButton2";
            this.optSelectAll.UseVisualStyleBackColor = true;
            // 
            // optSelect
            // 
            this.optSelect.AutoSize = true;
            this.optSelect.Checked = true;
            this.optSelect.Location = new System.Drawing.Point(10, 20);
            this.optSelect.Name = "optSelect";
            this.optSelect.Size = new System.Drawing.Size(95, 16);
            this.optSelect.TabIndex = 5;
            this.optSelect.TabStop = true;
            this.optSelect.Text = "radioButton1";
            this.optSelect.UseVisualStyleBackColor = true;
            // 
            // tvDepart
            // 
            this.tvDepart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDepart.CheckBoxes = true;
            this.tvDepart.FullRowSelect = true;
            this.tvDepart.HideSelection = false;
            this.tvDepart.ItemHeight = 20;
            this.tvDepart.Location = new System.Drawing.Point(10, 60);
            this.tvDepart.Name = "tvDepart";
            this.tvDepart.Size = new System.Drawing.Size(380, 205);
            this.tvDepart.TabIndex = 7;
            this.tvDepart.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDepart_AfterCheck);
            // 
            // cbbRule
            // 
            this.cbbRule.DisplayMember = "Text";
            this.cbbRule.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRule.ForeColor = System.Drawing.Color.Black;
            this.cbbRule.FormattingEnabled = true;
            this.cbbRule.ItemHeight = 16;
            this.cbbRule.Location = new System.Drawing.Point(80, 101);
            this.cbbRule.Name = "cbbRule";
            this.cbbRule.Size = new System.Drawing.Size(121, 22);
            this.cbbRule.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbRule.TabIndex = 1002;
            // 
            // frmKQRuleDepartAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(619, 353);
            this.Controls.Add(this.cbbRule);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDepartName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelectDepart);
            this.Controls.Add(this.txtDepartID);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKQRuleDepartAdd";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDepartID, 0);
            this.Controls.SetChildIndex(this.btnSelectDepart, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtDepartName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cbbRule, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtDepartID;
    private DevComponents.DotNetBar.ButtonX btnSelectDepart;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TreeView tvDepart;
    private System.Windows.Forms.RadioButton optSelectAll;
    private System.Windows.Forms.RadioButton optSelect;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbRule;
    }
}
