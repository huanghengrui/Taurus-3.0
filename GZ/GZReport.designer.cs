namespace Taurus
{
  partial class frmGZReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGZReport));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.dtpYM = new System.Windows.Forms.DateTimePicker();
            this.lblYM = new System.Windows.Forms.Label();
            this.btnSelectDepart = new DevComponents.DotNetBar.ButtonX();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.lblDep = new System.Windows.Forms.Label();
            this.btnSelectEmp = new DevComponents.DotNetBar.ButtonX();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.lbEmp = new System.Windows.Forms.Label();
            this.lblGZItem = new System.Windows.Forms.Label();
            this.cbbGZItem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbGZItem);
            this.panel1.Controls.Add(this.lblGZItem);
            this.panel1.Controls.Add(this.btnSelectDepart);
            this.panel1.Controls.Add(this.txtDepart);
            this.panel1.Controls.Add(this.lblDep);
            this.panel1.Controls.Add(this.btnSelectEmp);
            this.panel1.Controls.Add(this.txtEmp);
            this.panel1.Controls.Add(this.lbEmp);
            this.panel1.Controls.Add(this.lblYM);
            this.panel1.Controls.Add(this.dtpYM);
            this.panel1.Size = new System.Drawing.Size(220, 258);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(334, 258);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(220, 40);
            this.pnlDisp.Size = new System.Drawing.Size(334, 258);
            // 
            // Statusbar
            // 
            this.Statusbar.Location = new System.Drawing.Point(0, 298);
            this.Statusbar.Size = new System.Drawing.Size(554, 30);
            // 
            // lblRecordState
            // 
            this.lblRecordState.Text = "";
            // 
            // progBar
            // 
            // 
            // 
            // 
            this.progBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progBar.BackStyle.MarginLeft = 5;
            this.progBar.BackStyle.MarginRight = 5;
            this.progBar.BackStyle.PaddingLeft = 5;
            this.progBar.BackStyle.PaddingRight = 5;
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Silver;
            this.imgList.Images.SetKeyName(0, "REPORTL_p2.bmp");
            this.imgList.Images.SetKeyName(1, "USER_P2.BMP");
            // 
            // dtpYM
            // 
            this.dtpYM.CustomFormat = "yyyy-MM";
            this.dtpYM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYM.Location = new System.Drawing.Point(70, 10);
            this.dtpYM.Name = "dtpYM";
            this.dtpYM.ShowUpDown = true;
            this.dtpYM.Size = new System.Drawing.Size(140, 21);
            this.dtpYM.TabIndex = 5;
            // 
            // lblYM
            // 
            this.lblYM.AutoSize = true;
            this.lblYM.Location = new System.Drawing.Point(10, 14);
            this.lblYM.Name = "lblYM";
            this.lblYM.Size = new System.Drawing.Size(41, 12);
            this.lblYM.TabIndex = 6;
            this.lblYM.Text = "label1";
            // 
            // btnSelectDepart
            // 
            this.btnSelectDepart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectDepart.Location = new System.Drawing.Point(175, 71);
            this.btnSelectDepart.Name = "btnSelectDepart";
            this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart.TabIndex = 47;
            this.btnSelectDepart.Text = "button1";
            this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(70, 70);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(140, 21);
            this.txtDepart.TabIndex = 46;
            this.txtDepart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepart_KeyPress);
            // 
            // lblDep
            // 
            this.lblDep.AutoSize = true;
            this.lblDep.Location = new System.Drawing.Point(10, 74);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(41, 12);
            this.lblDep.TabIndex = 49;
            this.lblDep.Tag = "Depart";
            this.lblDep.Text = "label2";
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectEmp.Location = new System.Drawing.Point(175, 41);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 45;
            this.btnSelectEmp.Text = "button1";
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(70, 40);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(140, 21);
            this.txtEmp.TabIndex = 44;
            this.txtEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmp_KeyPress);
            // 
            // lbEmp
            // 
            this.lbEmp.AutoSize = true;
            this.lbEmp.Location = new System.Drawing.Point(10, 44);
            this.lbEmp.Name = "lbEmp";
            this.lbEmp.Size = new System.Drawing.Size(41, 12);
            this.lbEmp.TabIndex = 48;
            this.lbEmp.Tag = "Emp";
            this.lbEmp.Text = "label3";
            // 
            // lblGZItem
            // 
            this.lblGZItem.AutoSize = true;
            this.lblGZItem.Location = new System.Drawing.Point(10, 104);
            this.lblGZItem.Name = "lblGZItem";
            this.lblGZItem.Size = new System.Drawing.Size(41, 12);
            this.lblGZItem.TabIndex = 51;
            this.lblGZItem.Tag = "GZItem";
            this.lblGZItem.Text = "label5";
            // 
            // cbbGZItem
            // 
            this.cbbGZItem.DisplayMember = "Text";
            this.cbbGZItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbGZItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGZItem.FormattingEnabled = true;
            this.cbbGZItem.ItemHeight = 16;
            this.cbbGZItem.Location = new System.Drawing.Point(70, 101);
            this.cbbGZItem.Name = "cbbGZItem";
            this.cbbGZItem.Size = new System.Drawing.Size(139, 22);
            this.cbbGZItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbGZItem.TabIndex = 52;
            this.cbbGZItem.DropDown += new System.EventHandler(this.cbbGZItem_DropDown);
            this.cbbGZItem.SelectedIndexChanged += new System.EventHandler(this.cbbGZItem_SelectedIndexChanged);
            // 
            // frmGZReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(554, 328);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGZReport";
            this.Controls.SetChildIndex(this.Statusbar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imgList;
    private System.Windows.Forms.DateTimePicker dtpYM;
    private System.Windows.Forms.Label lblYM;
    private DevComponents.DotNetBar.ButtonX btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label lblDep;
    private DevComponents.DotNetBar.ButtonX btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label lbEmp;
    private System.Windows.Forms.Label lblGZItem;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbGZItem;
    }
}
