namespace Taurus
{
  partial class frmSYPowerAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYPowerAdd));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtOprtNo = new System.Windows.Forms.TextBox();
            this.txtOprtName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtOprtPWD = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtOprtPWDA = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtOprtDesc = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.funcGrid = new RowMergeView();
            ((System.ComponentModel.ISupportInitialize)(this.funcGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(301, 462);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(381, 462);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 45);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 12);
            this.Label1.TabIndex = 19;
            this.Label1.Tag = "OprtNo";
            this.Label1.Text = "label1";
            // 
            // txtOprtNo
            // 
            this.txtOprtNo.Location = new System.Drawing.Point(100, 41);
            this.txtOprtNo.MaxLength = 50;
            this.txtOprtNo.Name = "txtOprtNo";
            this.txtOprtNo.Size = new System.Drawing.Size(120, 21);
            this.txtOprtNo.TabIndex = 0;
            // 
            // txtOprtName
            // 
            this.txtOprtName.Location = new System.Drawing.Point(100, 71);
            this.txtOprtName.MaxLength = 50;
            this.txtOprtName.Name = "txtOprtName";
            this.txtOprtName.Size = new System.Drawing.Size(120, 21);
            this.txtOprtName.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 75);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 12);
            this.Label2.TabIndex = 21;
            this.Label2.Tag = "OprtName";
            this.Label2.Text = "label2";
            // 
            // txtOprtPWD
            // 
            this.txtOprtPWD.Location = new System.Drawing.Point(100, 101);
            this.txtOprtPWD.MaxLength = 10;
            this.txtOprtPWD.Name = "txtOprtPWD";
            this.txtOprtPWD.PasswordChar = '*';
            this.txtOprtPWD.Size = new System.Drawing.Size(120, 21);
            this.txtOprtPWD.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(10, 105);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 12);
            this.Label3.TabIndex = 23;
            this.Label3.Tag = "OprtPWD";
            this.Label3.Text = "label3";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(240, 105);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(41, 12);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "label4";
            // 
            // txtOprtPWDA
            // 
            this.txtOprtPWDA.Location = new System.Drawing.Point(100, 131);
            this.txtOprtPWDA.MaxLength = 10;
            this.txtOprtPWDA.Name = "txtOprtPWDA";
            this.txtOprtPWDA.PasswordChar = '*';
            this.txtOprtPWDA.Size = new System.Drawing.Size(120, 21);
            this.txtOprtPWDA.TabIndex = 3;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(10, 135);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(41, 12);
            this.Label5.TabIndex = 26;
            this.Label5.Text = "label5";
            // 
            // txtOprtDesc
            // 
            this.txtOprtDesc.Location = new System.Drawing.Point(100, 161);
            this.txtOprtDesc.MaxLength = 100;
            this.txtOprtDesc.Name = "txtOprtDesc";
            this.txtOprtDesc.Size = new System.Drawing.Size(355, 21);
            this.txtOprtDesc.TabIndex = 4;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(10, 165);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(41, 12);
            this.Label8.TabIndex = 32;
            this.Label8.Tag = "OprtDesc";
            this.Label8.Text = "label8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1002;
            this.label6.Tag = "";
            this.label6.Text = "label8";
            // 
            // funcGrid
            // 
            this.funcGrid.AllowUserToAddRows = false;
            this.funcGrid.AllowUserToDeleteRows = false;
            this.funcGrid.AllowUserToResizeRows = false;
            this.funcGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.funcGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.funcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.funcGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.funcGrid.Location = new System.Drawing.Point(100, 191);
            this.funcGrid.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.funcGrid.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("funcGrid.MergeColumnNames")));
            this.funcGrid.MultiSelect = false;
            this.funcGrid.Name = "funcGrid";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.funcGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.funcGrid.RowHeadersVisible = false;
            this.funcGrid.RowTemplate.Height = 23;
            this.funcGrid.Size = new System.Drawing.Size(356, 262);
            this.funcGrid.TabIndex = 5;
            this.funcGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.funcGrid_CellClick);
            // 
            // frmSYPowerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(465, 495);
            this.Controls.Add(this.funcGrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOprtDesc);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtOprtPWDA);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtOprtPWD);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtOprtName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtOprtNo);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.Name = "frmSYPowerAdd";
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.txtOprtNo, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.txtOprtName, 0);
            this.Controls.SetChildIndex(this.Label3, 0);
            this.Controls.SetChildIndex(this.txtOprtPWD, 0);
            this.Controls.SetChildIndex(this.Label4, 0);
            this.Controls.SetChildIndex(this.Label5, 0);
            this.Controls.SetChildIndex(this.txtOprtPWDA, 0);
            this.Controls.SetChildIndex(this.Label8, 0);
            this.Controls.SetChildIndex(this.txtOprtDesc, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.funcGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.funcGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.TextBox txtOprtNo;
    private System.Windows.Forms.TextBox txtOprtName;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.TextBox txtOprtPWD;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.TextBox txtOprtPWDA;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.TextBox txtOprtDesc;
    private System.Windows.Forms.Label Label8;
    private System.Windows.Forms.Label label6;
    private RowMergeView funcGrid;
  }
}
