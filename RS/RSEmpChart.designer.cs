namespace Taurus
{
  partial class frmRSEmpChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRSEmpChart));
            this.rbDepart = new System.Windows.Forms.RadioButton();
            this.rbSex = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbPie = new System.Windows.Forms.RadioButton();
            this.rbBar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbDepart);
            this.panel1.Controls.Add(this.rbSex);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Size = new System.Drawing.Size(180, 256);
            // 
            // dispView
            // 
            this.dispView.BackColor = System.Drawing.Color.White;
            this.dispView.ForeColor = System.Drawing.Color.Black;
            this.dispView.Size = new System.Drawing.Size(372, 256);
            // 
            // pnlDisp
            // 
            this.pnlDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.pnlDisp.ForeColor = System.Drawing.Color.Black;
            this.pnlDisp.Size = new System.Drawing.Size(372, 256);
            // 
            // Statusbar
            // 
            this.Statusbar.Location = new System.Drawing.Point(0, 296);
            this.Statusbar.Size = new System.Drawing.Size(552, 30);
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
            // rbDepart
            // 
            this.rbDepart.Location = new System.Drawing.Point(80, 80);
            this.rbDepart.Name = "rbDepart";
            this.rbDepart.Size = new System.Drawing.Size(80, 16);
            this.rbDepart.TabIndex = 4;
            this.rbDepart.TabStop = true;
            this.rbDepart.Tag = "Depart";
            this.rbDepart.Text = "radioButton1";
            this.rbDepart.UseVisualStyleBackColor = true;
            this.rbDepart.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbSex
            // 
            this.rbSex.Checked = true;
            this.rbSex.Location = new System.Drawing.Point(80, 60);
            this.rbSex.Name = "rbSex";
            this.rbSex.Size = new System.Drawing.Size(80, 16);
            this.rbSex.TabIndex = 3;
            this.rbSex.TabStop = true;
            this.rbSex.Tag = "EmpSex";
            this.rbSex.Text = "radioButton1";
            this.rbSex.UseVisualStyleBackColor = true;
            this.rbSex.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbPie);
            this.panel2.Controls.Add(this.rbBar);
            this.panel2.Location = new System.Drawing.Point(80, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 40);
            this.panel2.TabIndex = 1;
            // 
            // rbPie
            // 
            this.rbPie.Location = new System.Drawing.Point(0, 20);
            this.rbPie.Name = "rbPie";
            this.rbPie.Size = new System.Drawing.Size(80, 16);
            this.rbPie.TabIndex = 1;
            this.rbPie.Text = "radioButton2";
            this.rbPie.UseVisualStyleBackColor = true;
            this.rbPie.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbBar
            // 
            this.rbBar.Checked = true;
            this.rbBar.Location = new System.Drawing.Point(0, 2);
            this.rbBar.Name = "rbBar";
            this.rbBar.Size = new System.Drawing.Size(80, 16);
            this.rbBar.TabIndex = 0;
            this.rbBar.TabStop = true;
            this.rbBar.Text = "radioButton1";
            this.rbBar.UseVisualStyleBackColor = true;
            this.rbBar.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // frmRSEmpChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(552, 326);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRSEmpChart";
            this.Controls.SetChildIndex(this.Statusbar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Statusbar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.RadioButton rbPie;
    private System.Windows.Forms.RadioButton rbBar;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.RadioButton rbSex;
    private System.Windows.Forms.RadioButton rbDepart;
  }
}
