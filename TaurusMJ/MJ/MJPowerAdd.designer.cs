namespace Taurus
{
    partial class frmMJPowerAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJPowerAdd));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepartName = new System.Windows.Forms.TextBox();
            this.cbbSun = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.cardGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.btnQuickSearch = new DevComponents.DotNetBar.ButtonX();
            this.btnSelectEmp = new DevComponents.DotNetBar.ButtonX();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.cbbMon = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbTue = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbWed = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbThu = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbFri = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbSat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.btnSelectStartDate = new DevComponents.DotNetBar.ButtonX();
            this.btnSelectEndDate = new DevComponents.DotNetBar.ButtonX();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gbxDev = new System.Windows.Forms.GroupBox();
            this.txtQuickSearchMac = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.macGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
            this.gbxDev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(781, 397);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(861, 397);
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
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Tag = "EmpNo";
            this.label2.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 32;
            this.label3.Tag = "SunID";
            this.label3.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Tag = "EmpName";
            this.label1.Text = "label2";
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmpName.Location = new System.Drawing.Point(80, 71);
            this.txtEmpName.MaxLength = 10;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(120, 21);
            this.txtEmpName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 36;
            this.label4.Tag = "DepartName";
            this.label4.Text = "label3";
            // 
            // txtDepartName
            // 
            this.txtDepartName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartName.Location = new System.Drawing.Point(80, 101);
            this.txtDepartName.MaxLength = 10;
            this.txtDepartName.Name = "txtDepartName";
            this.txtDepartName.Size = new System.Drawing.Size(120, 21);
            this.txtDepartName.TabIndex = 3;
            // 
            // cbbSun
            // 
            this.cbbSun.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSun.ForeColor = System.Drawing.Color.Black;
            this.cbbSun.FormattingEnabled = true;
            this.cbbSun.ItemHeight = 16;
            this.cbbSun.Location = new System.Drawing.Point(80, 131);
            this.cbbSun.Name = "cbbSun";
            this.cbbSun.Size = new System.Drawing.Size(120, 22);
            this.cbbSun.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.cardGrid);
            this.groupBox1.Controls.Add(this.txtQuickSearch);
            this.groupBox1.Controls.Add(this.lblQuickSearch);
            this.groupBox1.Controls.Add(this.btnQuickSearch);
            this.groupBox1.Location = new System.Drawing.Point(210, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 350);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "SameEmp";
            this.groupBox1.Text = "groupBox1";
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.Location = new System.Drawing.Point(90, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "button1";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cardGrid
            // 
            this.cardGrid.AllowUserToAddRows = false;
            this.cardGrid.AllowUserToDeleteRows = false;
            this.cardGrid.AllowUserToResizeRows = false;
            this.cardGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.cardGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cardGrid.ColumnHeadersHeight = 25;
            this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cardGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.cardGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cardGrid.Location = new System.Drawing.Point(10, 47);
            this.cardGrid.MultiSelect = false;
            this.cardGrid.Name = "cardGrid";
            this.cardGrid.ReadOnly = true;
            this.cardGrid.RowHeadersVisible = false;
            this.cardGrid.RowTemplate.Height = 23;
            this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cardGrid.Size = new System.Drawing.Size(461, 297);
            this.cardGrid.StandardTab = true;
            this.cardGrid.TabIndex = 3;
            this.cardGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.cardGrid_DataBindingComplete);
            // 
            // txtQuickSearch
            // 
            this.txtQuickSearch.Location = new System.Drawing.Point(250, 18);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(140, 21);
            this.txtQuickSearch.TabIndex = 2;
            this.txtQuickSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuickSearch_KeyDown);
            // 
            // lblQuickSearch
            // 
            this.lblQuickSearch.AutoSize = true;
            this.lblQuickSearch.Location = new System.Drawing.Point(170, 22);
            this.lblQuickSearch.Name = "lblQuickSearch";
            this.lblQuickSearch.Size = new System.Drawing.Size(41, 12);
            this.lblQuickSearch.TabIndex = 5;
            this.lblQuickSearch.Text = "label1";
            // 
            // btnQuickSearch
            // 
            this.btnQuickSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuickSearch.Location = new System.Drawing.Point(10, 16);
            this.btnQuickSearch.Name = "btnQuickSearch";
            this.btnQuickSearch.Size = new System.Drawing.Size(75, 25);
            this.btnQuickSearch.TabIndex = 0;
            this.btnQuickSearch.Text = "button1";
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectEmp.Location = new System.Drawing.Point(165, 42);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 1;
            this.btnSelectEmp.Text = "...";
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(80, 41);
            this.txtEmpNo.MaxLength = 10;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(120, 21);
            this.txtEmpNo.TabIndex = 0;
            this.txtEmpNo.Leave += new System.EventHandler(this.txtEmpNo_Leave);
            // 
            // cbbMon
            // 
            this.cbbMon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMon.ForeColor = System.Drawing.Color.Black;
            this.cbbMon.FormattingEnabled = true;
            this.cbbMon.ItemHeight = 16;
            this.cbbMon.Location = new System.Drawing.Point(80, 161);
            this.cbbMon.Name = "cbbMon";
            this.cbbMon.Size = new System.Drawing.Size(120, 22);
            this.cbbMon.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1003;
            this.label5.Tag = "MonID";
            this.label5.Text = "label4";
            // 
            // cbbTue
            // 
            this.cbbTue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTue.ForeColor = System.Drawing.Color.Black;
            this.cbbTue.FormattingEnabled = true;
            this.cbbTue.ItemHeight = 16;
            this.cbbTue.Location = new System.Drawing.Point(80, 191);
            this.cbbTue.Name = "cbbTue";
            this.cbbTue.Size = new System.Drawing.Size(120, 22);
            this.cbbTue.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1005;
            this.label6.Tag = "TueID";
            this.label6.Text = "label4";
            // 
            // cbbWed
            // 
            this.cbbWed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbWed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWed.ForeColor = System.Drawing.Color.Black;
            this.cbbWed.FormattingEnabled = true;
            this.cbbWed.ItemHeight = 16;
            this.cbbWed.Location = new System.Drawing.Point(80, 221);
            this.cbbWed.Name = "cbbWed";
            this.cbbWed.Size = new System.Drawing.Size(120, 22);
            this.cbbWed.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1007;
            this.label7.Tag = "WedID";
            this.label7.Text = "label4";
            // 
            // cbbThu
            // 
            this.cbbThu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbThu.ForeColor = System.Drawing.Color.Black;
            this.cbbThu.FormattingEnabled = true;
            this.cbbThu.ItemHeight = 16;
            this.cbbThu.Location = new System.Drawing.Point(80, 251);
            this.cbbThu.Name = "cbbThu";
            this.cbbThu.Size = new System.Drawing.Size(120, 22);
            this.cbbThu.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1009;
            this.label8.Tag = "ThuID";
            this.label8.Text = "label4";
            // 
            // cbbFri
            // 
            this.cbbFri.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbFri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFri.ForeColor = System.Drawing.Color.Black;
            this.cbbFri.FormattingEnabled = true;
            this.cbbFri.ItemHeight = 16;
            this.cbbFri.Location = new System.Drawing.Point(80, 281);
            this.cbbFri.Name = "cbbFri";
            this.cbbFri.Size = new System.Drawing.Size(120, 22);
            this.cbbFri.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1011;
            this.label9.Tag = "FriID";
            this.label9.Text = "label4";
            // 
            // cbbSat
            // 
            this.cbbSat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSat.ForeColor = System.Drawing.Color.Black;
            this.cbbSat.FormattingEnabled = true;
            this.cbbSat.ItemHeight = 16;
            this.cbbSat.Location = new System.Drawing.Point(80, 311);
            this.cbbSat.Name = "cbbSat";
            this.cbbSat.Size = new System.Drawing.Size(120, 22);
            this.cbbSat.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 1013;
            this.label10.Tag = "SatID";
            this.label10.Text = "label4";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(208, 407);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 1014;
            this.lblMsg.Text = "label1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 345);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 1016;
            this.label11.Tag = "StartDate";
            this.label11.Text = "label4";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(80, 341);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(120, 21);
            this.txtStartDate.TabIndex = 11;
            // 
            // btnSelectStartDate
            // 
            this.btnSelectStartDate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectStartDate.Location = new System.Drawing.Point(165, 342);
            this.btnSelectStartDate.Name = "btnSelectStartDate";
            this.btnSelectStartDate.Size = new System.Drawing.Size(34, 19);
            this.btnSelectStartDate.TabIndex = 12;
            this.btnSelectStartDate.Text = "...";
            this.btnSelectStartDate.Click += new System.EventHandler(this.btnSelectStartDate_Click);
            // 
            // btnSelectEndDate
            // 
            this.btnSelectEndDate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectEndDate.Location = new System.Drawing.Point(165, 372);
            this.btnSelectEndDate.Name = "btnSelectEndDate";
            this.btnSelectEndDate.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEndDate.TabIndex = 14;
            this.btnSelectEndDate.Text = "...";
            this.btnSelectEndDate.Click += new System.EventHandler(this.btnSelectEndDate_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(80, 371);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(120, 21);
            this.txtEndDate.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1019;
            this.label12.Tag = "EndDate";
            this.label12.Text = "label4";
            // 
            // gbxDev
            // 
            this.gbxDev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDev.Controls.Add(this.txtQuickSearchMac);
            this.gbxDev.Controls.Add(this.label13);
            this.gbxDev.Controls.Add(this.macGrid);
            this.gbxDev.Location = new System.Drawing.Point(665, 41);
            this.gbxDev.Name = "gbxDev";
            this.gbxDev.Size = new System.Drawing.Size(273, 350);
            this.gbxDev.TabIndex = 16;
            this.gbxDev.TabStop = false;
            this.gbxDev.Text = "groupBox2";
            // 
            // txtQuickSearchMac
            // 
            this.txtQuickSearchMac.Location = new System.Drawing.Point(81, 20);
            this.txtQuickSearchMac.Name = "txtQuickSearchMac";
            this.txtQuickSearchMac.Size = new System.Drawing.Size(132, 21);
            this.txtQuickSearchMac.TabIndex = 3;
            this.txtQuickSearchMac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuickSearchMac_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 6;
            this.label13.Tag = "lblQuickSearch";
            this.label13.Text = "label1";
            // 
            // macGrid
            // 
            this.macGrid.AllowUserToAddRows = false;
            this.macGrid.AllowUserToDeleteRows = false;
            this.macGrid.AllowUserToResizeRows = false;
            this.macGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.macGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.macGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.macGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.macGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.macGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.macGrid.Location = new System.Drawing.Point(6, 47);
            this.macGrid.MultiSelect = false;
            this.macGrid.Name = "macGrid";
            this.macGrid.RowHeadersVisible = false;
            this.macGrid.RowTemplate.Height = 23;
            this.macGrid.Size = new System.Drawing.Size(261, 297);
            this.macGrid.TabIndex = 1;
            // 
            // frmMJPowerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(938, 430);
            this.Controls.Add(this.gbxDev);
            this.Controls.Add(this.btnSelectEndDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSelectStartDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.cbbSat);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbbFri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbbThu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbbWed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbTue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbMon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelectEmp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.cbbSun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDepartName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMJPowerAdd";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtEmpName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDepartName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cbbSun, 0);
            this.Controls.SetChildIndex(this.txtEmpNo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnSelectEmp, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cbbMon, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cbbTue, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cbbWed, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cbbThu, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cbbFri, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.cbbSat, 0);
            this.Controls.SetChildIndex(this.lblMsg, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtStartDate, 0);
            this.Controls.SetChildIndex(this.btnSelectStartDate, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtEndDate, 0);
            this.Controls.SetChildIndex(this.btnSelectEndDate, 0);
            this.Controls.SetChildIndex(this.gbxDev, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
            this.gbxDev.ResumeLayout(false);
            this.gbxDev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDepartName;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cbbSun;
    private System.Windows.Forms.GroupBox groupBox1;
    private DevComponents.DotNetBar.ButtonX btnClear;
    private DevComponents.DotNetBar.Controls.DataGridViewX cardGrid;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private DevComponents.DotNetBar.ButtonX btnQuickSearch;
    private DevComponents.DotNetBar.ButtonX btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmpNo;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cbbMon;
    private System.Windows.Forms.Label label5;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTue;
    private System.Windows.Forms.Label label6;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cbbWed;
    private System.Windows.Forms.Label label7;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cbbThu;
    private System.Windows.Forms.Label label8;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cbbFri;
    private System.Windows.Forms.Label label9;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cbbSat;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label lblMsg;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtStartDate;
    private DevComponents.DotNetBar.ButtonX btnSelectStartDate;
    private DevComponents.DotNetBar.ButtonX btnSelectEndDate;
    private System.Windows.Forms.TextBox txtEndDate;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.GroupBox gbxDev;
    private DevComponents.DotNetBar.Controls.DataGridViewX macGrid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQuickSearchMac;
    }
}
