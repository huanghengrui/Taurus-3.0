namespace Taurus
{
  partial class frmGZItemAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGZItemAdd));
            this.lblGZItemID = new System.Windows.Forms.Label();
            this.txtGZItemID = new System.Windows.Forms.TextBox();
            this.txtGZItemName = new System.Windows.Forms.TextBox();
            this.lblGZItemName = new System.Windows.Forms.Label();
            this.lbGZItem1 = new System.Windows.Forms.ListBox();
            this.btAdd1 = new DevComponents.DotNetBar.ButtonX();
            this.btDel1 = new DevComponents.DotNetBar.ButtonX();
            this.gbGZItem1 = new System.Windows.Forms.GroupBox();
            this.gbGZItemIn = new System.Windows.Forms.GroupBox();
            this.lbGZItemIn = new System.Windows.Forms.ListBox();
            this.gbGZItemOut = new System.Windows.Forms.GroupBox();
            this.lbGZItemOut = new System.Windows.Forms.ListBox();
            this.btDel2 = new DevComponents.DotNetBar.ButtonX();
            this.btAdd2 = new DevComponents.DotNetBar.ButtonX();
            this.gbGZItem2 = new System.Windows.Forms.GroupBox();
            this.lbGZItem2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btDown1 = new DevComponents.DotNetBar.ButtonX();
            this.btUp1 = new DevComponents.DotNetBar.ButtonX();
            this.btUp2 = new DevComponents.DotNetBar.ButtonX();
            this.btDown2 = new DevComponents.DotNetBar.ButtonX();
            this.gbGZItem1.SuspendLayout();
            this.gbGZItemIn.SuspendLayout();
            this.gbGZItemOut.SuspendLayout();
            this.gbGZItem2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(310, 400);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(390, 400);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // lblGZItemID
            // 
            this.lblGZItemID.AutoSize = true;
            this.lblGZItemID.Location = new System.Drawing.Point(10, 48);
            this.lblGZItemID.Name = "lblGZItemID";
            this.lblGZItemID.Size = new System.Drawing.Size(41, 12);
            this.lblGZItemID.TabIndex = 1002;
            this.lblGZItemID.Tag = "GZItemID";
            this.lblGZItemID.Text = "label1";
            // 
            // txtGZItemID
            // 
            this.txtGZItemID.Location = new System.Drawing.Point(80, 44);
            this.txtGZItemID.MaxLength = 10;
            this.txtGZItemID.Name = "txtGZItemID";
            this.txtGZItemID.Size = new System.Drawing.Size(115, 21);
            this.txtGZItemID.TabIndex = 0;
            // 
            // txtGZItemName
            // 
            this.txtGZItemName.Location = new System.Drawing.Point(280, 44);
            this.txtGZItemName.Name = "txtGZItemName";
            this.txtGZItemName.Size = new System.Drawing.Size(185, 21);
            this.txtGZItemName.TabIndex = 1;
            // 
            // lblGZItemName
            // 
            this.lblGZItemName.AutoSize = true;
            this.lblGZItemName.Location = new System.Drawing.Point(210, 48);
            this.lblGZItemName.Name = "lblGZItemName";
            this.lblGZItemName.Size = new System.Drawing.Size(41, 12);
            this.lblGZItemName.TabIndex = 1004;
            this.lblGZItemName.Tag = "GZItemName";
            this.lblGZItemName.Text = "label2";
            // 
            // lbGZItem1
            // 
            this.lbGZItem1.FormattingEnabled = true;
            this.lbGZItem1.IntegralHeight = false;
            this.lbGZItem1.ItemHeight = 12;
            this.lbGZItem1.Location = new System.Drawing.Point(10, 20);
            this.lbGZItem1.Name = "lbGZItem1";
            this.lbGZItem1.Size = new System.Drawing.Size(175, 110);
            this.lbGZItem1.TabIndex = 7;
            this.lbGZItem1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbGZItem1_MouseDoubleClick);
            // 
            // btAdd1
            // 
            this.btAdd1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btAdd1.Location = new System.Drawing.Point(210, 124);
            this.btAdd1.Name = "btAdd1";
            this.btAdd1.Size = new System.Drawing.Size(55, 25);
            this.btAdd1.TabIndex = 4;
            this.btAdd1.Tag = "btAdd";
            this.btAdd1.Text = "button1";
            this.btAdd1.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDel1
            // 
            this.btDel1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btDel1.Location = new System.Drawing.Point(210, 154);
            this.btDel1.Name = "btDel1";
            this.btDel1.Size = new System.Drawing.Size(55, 25);
            this.btDel1.TabIndex = 5;
            this.btDel1.Tag = "btDel";
            this.btDel1.Text = "button2";
            this.btDel1.Click += new System.EventHandler(this.btDel_Click);
            // 
            // gbGZItem1
            // 
            this.gbGZItem1.Controls.Add(this.lbGZItem1);
            this.gbGZItem1.Location = new System.Drawing.Point(270, 74);
            this.gbGZItem1.Name = "gbGZItem1";
            this.gbGZItem1.Size = new System.Drawing.Size(195, 140);
            this.gbGZItem1.TabIndex = 1010;
            this.gbGZItem1.TabStop = false;
            this.gbGZItem1.Tag = "gbGZItem";
            this.gbGZItem1.Text = "groupBox1";
            // 
            // gbGZItemIn
            // 
            this.gbGZItemIn.Controls.Add(this.lbGZItemIn);
            this.gbGZItemIn.Location = new System.Drawing.Point(10, 74);
            this.gbGZItemIn.Name = "gbGZItemIn";
            this.gbGZItemIn.Size = new System.Drawing.Size(195, 140);
            this.gbGZItemIn.TabIndex = 1011;
            this.gbGZItemIn.TabStop = false;
            this.gbGZItemIn.Tag = "gbGZItemIn";
            this.gbGZItemIn.Text = "groupBox2";
            // 
            // lbGZItemIn
            // 
            this.lbGZItemIn.FormattingEnabled = true;
            this.lbGZItemIn.IntegralHeight = false;
            this.lbGZItemIn.ItemHeight = 12;
            this.lbGZItemIn.Location = new System.Drawing.Point(10, 20);
            this.lbGZItemIn.Name = "lbGZItemIn";
            this.lbGZItemIn.Size = new System.Drawing.Size(175, 110);
            this.lbGZItemIn.TabIndex = 2;
            this.lbGZItemIn.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbGZItemIn_MouseDoubleClick);
            // 
            // gbGZItemOut
            // 
            this.gbGZItemOut.Controls.Add(this.lbGZItemOut);
            this.gbGZItemOut.Location = new System.Drawing.Point(10, 224);
            this.gbGZItemOut.Name = "gbGZItemOut";
            this.gbGZItemOut.Size = new System.Drawing.Size(195, 140);
            this.gbGZItemOut.TabIndex = 1015;
            this.gbGZItemOut.TabStop = false;
            this.gbGZItemOut.Tag = "gbGZItemOut";
            this.gbGZItemOut.Text = "groupBox2";
            // 
            // lbGZItemOut
            // 
            this.lbGZItemOut.FormattingEnabled = true;
            this.lbGZItemOut.IntegralHeight = false;
            this.lbGZItemOut.ItemHeight = 12;
            this.lbGZItemOut.Location = new System.Drawing.Point(10, 20);
            this.lbGZItemOut.Name = "lbGZItemOut";
            this.lbGZItemOut.Size = new System.Drawing.Size(175, 110);
            this.lbGZItemOut.TabIndex = 8;
            this.lbGZItemOut.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbGZItemOut_MouseDoubleClick);
            // 
            // btDel2
            // 
            this.btDel2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btDel2.Location = new System.Drawing.Point(210, 304);
            this.btDel2.Name = "btDel2";
            this.btDel2.Size = new System.Drawing.Size(55, 25);
            this.btDel2.TabIndex = 12;
            this.btDel2.Tag = "btDel";
            this.btDel2.Text = "button2";
            this.btDel2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btAdd2
            // 
            this.btAdd2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btAdd2.Location = new System.Drawing.Point(210, 274);
            this.btAdd2.Name = "btAdd2";
            this.btAdd2.Size = new System.Drawing.Size(55, 25);
            this.btAdd2.TabIndex = 10;
            this.btAdd2.Tag = "btAdd";
            this.btAdd2.Text = "button1";
            this.btAdd2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbGZItem2
            // 
            this.gbGZItem2.Controls.Add(this.lbGZItem2);
            this.gbGZItem2.Location = new System.Drawing.Point(270, 224);
            this.gbGZItem2.Name = "gbGZItem2";
            this.gbGZItem2.Size = new System.Drawing.Size(195, 140);
            this.gbGZItem2.TabIndex = 1014;
            this.gbGZItem2.TabStop = false;
            this.gbGZItem2.Tag = "gbGZItem";
            this.gbGZItem2.Text = "groupBox1";
            // 
            // lbGZItem2
            // 
            this.lbGZItem2.FormattingEnabled = true;
            this.lbGZItem2.IntegralHeight = false;
            this.lbGZItem2.ItemHeight = 12;
            this.lbGZItem2.Location = new System.Drawing.Point(10, 20);
            this.lbGZItem2.Name = "lbGZItem2";
            this.lbGZItem2.Size = new System.Drawing.Size(175, 110);
            this.lbGZItem2.TabIndex = 14;
            this.lbGZItem2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbGZItem2_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(10, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 60);
            this.label1.TabIndex = 1016;
            this.label1.Tag = "msg1";
            this.label1.Text = "label1";
            // 
            // btDown1
            // 
            this.btDown1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btDown1.Location = new System.Drawing.Point(210, 184);
            this.btDown1.Name = "btDown1";
            this.btDown1.Size = new System.Drawing.Size(55, 25);
            this.btDown1.TabIndex = 6;
            this.btDown1.Tag = "btDown";
            this.btDown1.Text = "button3";
            this.btDown1.Click += new System.EventHandler(this.btDown1_Click);
            // 
            // btUp1
            // 
            this.btUp1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btUp1.Location = new System.Drawing.Point(210, 94);
            this.btUp1.Name = "btUp1";
            this.btUp1.Size = new System.Drawing.Size(55, 25);
            this.btUp1.TabIndex = 3;
            this.btUp1.Tag = "btUp";
            this.btUp1.Text = "button4";
            this.btUp1.Click += new System.EventHandler(this.btUp1_Click);
            // 
            // btUp2
            // 
            this.btUp2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btUp2.Location = new System.Drawing.Point(210, 244);
            this.btUp2.Name = "btUp2";
            this.btUp2.Size = new System.Drawing.Size(55, 25);
            this.btUp2.TabIndex = 9;
            this.btUp2.Tag = "btUp";
            this.btUp2.Text = "button5";
            this.btUp2.Click += new System.EventHandler(this.btUp1_Click);
            // 
            // btDown2
            // 
            this.btDown2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btDown2.Location = new System.Drawing.Point(210, 334);
            this.btDown2.Name = "btDown2";
            this.btDown2.Size = new System.Drawing.Size(55, 25);
            this.btDown2.TabIndex = 13;
            this.btDown2.Tag = "btDown";
            this.btDown2.Text = "button6";
            this.btDown2.Click += new System.EventHandler(this.btDown1_Click);
            // 
            // frmGZItemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(474, 433);
            this.Controls.Add(this.btUp2);
            this.Controls.Add(this.btDown2);
            this.Controls.Add(this.btUp1);
            this.Controls.Add(this.btDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbGZItemOut);
            this.Controls.Add(this.btDel2);
            this.Controls.Add(this.btAdd2);
            this.Controls.Add(this.gbGZItem2);
            this.Controls.Add(this.gbGZItemIn);
            this.Controls.Add(this.btDel1);
            this.Controls.Add(this.btAdd1);
            this.Controls.Add(this.txtGZItemName);
            this.Controls.Add(this.lblGZItemName);
            this.Controls.Add(this.txtGZItemID);
            this.Controls.Add(this.lblGZItemID);
            this.Controls.Add(this.gbGZItem1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGZItemAdd";
            this.Controls.SetChildIndex(this.gbGZItem1, 0);
            this.Controls.SetChildIndex(this.lblGZItemID, 0);
            this.Controls.SetChildIndex(this.txtGZItemID, 0);
            this.Controls.SetChildIndex(this.lblGZItemName, 0);
            this.Controls.SetChildIndex(this.txtGZItemName, 0);
            this.Controls.SetChildIndex(this.btAdd1, 0);
            this.Controls.SetChildIndex(this.btDel1, 0);
            this.Controls.SetChildIndex(this.gbGZItemIn, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbGZItem2, 0);
            this.Controls.SetChildIndex(this.btAdd2, 0);
            this.Controls.SetChildIndex(this.btDel2, 0);
            this.Controls.SetChildIndex(this.gbGZItemOut, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btDown1, 0);
            this.Controls.SetChildIndex(this.btUp1, 0);
            this.Controls.SetChildIndex(this.btDown2, 0);
            this.Controls.SetChildIndex(this.btUp2, 0);
            this.gbGZItem1.ResumeLayout(false);
            this.gbGZItemIn.ResumeLayout(false);
            this.gbGZItemOut.ResumeLayout(false);
            this.gbGZItem2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGZItemID;
        private System.Windows.Forms.TextBox txtGZItemID;
        private System.Windows.Forms.TextBox txtGZItemName;
        private System.Windows.Forms.Label lblGZItemName;
        private System.Windows.Forms.ListBox lbGZItem1;
        private DevComponents.DotNetBar.ButtonX btAdd1;
        private DevComponents.DotNetBar.ButtonX btDel1;
        private System.Windows.Forms.GroupBox gbGZItem1;
        private System.Windows.Forms.GroupBox gbGZItemIn;
        private System.Windows.Forms.ListBox lbGZItemIn;
        private System.Windows.Forms.GroupBox gbGZItemOut;
        private System.Windows.Forms.ListBox lbGZItemOut;
        private DevComponents.DotNetBar.ButtonX btDel2;
        private DevComponents.DotNetBar.ButtonX btAdd2;
        private System.Windows.Forms.GroupBox gbGZItem2;
        private System.Windows.Forms.ListBox lbGZItem2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btDown1;
        private DevComponents.DotNetBar.ButtonX btUp1;
        private DevComponents.DotNetBar.ButtonX btUp2;
        private DevComponents.DotNetBar.ButtonX btDown2;

    }
}
