namespace Taurus
{
  partial class frmAbout
  {
    /// <summary>
    /// ����������������
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// ������������ʹ�õ���Դ��
    /// </summary>
    /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows ������������ɵĴ���

    /// <summary>
    /// �����֧������ķ��� - ��Ҫ
    /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblOem = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(383, 255);
            this.btnOk.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(382, 254);
            this.btnCancel.Text = "";
            this.btnCancel.Visible = false;
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // lblOem
            // 
            this.lblOem.Location = new System.Drawing.Point(20, 135);
            this.lblOem.Name = "lblOem";
            this.lblOem.Size = new System.Drawing.Size(100, 65);
            this.lblOem.TabIndex = 22;
            this.lblOem.Text = "label3";
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.White;
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.ForeColor = System.Drawing.Color.Blue;
            this.txtInfo.Location = new System.Drawing.Point(122, 125);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(315, 85);
            this.txtInfo.TabIndex = 1002;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::Taurus.Properties.Resources.about;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.lblOem);
            this.panel1.Location = new System.Drawing.Point(6, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 215);
            this.panel1.TabIndex = 1009;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(467, 286);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAbout";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblOem;
    private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Panel panel1;
    }
}
