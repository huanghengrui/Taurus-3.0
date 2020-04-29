namespace Taurus
{
    partial class frmMJSeaUserPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJSeaUserPwd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd1 = new System.Windows.Forms.TextBox();
            this.txtPwd2 = new System.Windows.Forms.TextBox();
            this.lbMacSeriesUserName = new System.Windows.Forms.Label();
            this.txtMacSeriesUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(144, 146);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(234, 146);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1002;
            this.label1.Tag = "lbRecTuneUrl";
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1003;
            this.label2.Tag = "MacPort";
            this.label2.Text = "label2";
            // 
            // txtPwd1
            // 
            this.txtPwd1.Location = new System.Drawing.Point(129, 75);
            this.txtPwd1.MaxLength = 64;
            this.txtPwd1.Name = "txtPwd1";
            this.txtPwd1.PasswordChar = '*';
            this.txtPwd1.Size = new System.Drawing.Size(180, 21);
            this.txtPwd1.TabIndex = 1004;
            // 
            // txtPwd2
            // 
            this.txtPwd2.Location = new System.Drawing.Point(129, 112);
            this.txtPwd2.MaxLength = 64;
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.PasswordChar = '*';
            this.txtPwd2.Size = new System.Drawing.Size(180, 21);
            this.txtPwd2.TabIndex = 1005;
            // 
            // lbMacSeriesUserName
            // 
            this.lbMacSeriesUserName.AutoSize = true;
            this.lbMacSeriesUserName.Location = new System.Drawing.Point(16, 42);
            this.lbMacSeriesUserName.Name = "lbMacSeriesUserName";
            this.lbMacSeriesUserName.Size = new System.Drawing.Size(41, 12);
            this.lbMacSeriesUserName.TabIndex = 1007;
            this.lbMacSeriesUserName.Text = "label4";
            // 
            // txtMacSeriesUserName
            // 
            this.txtMacSeriesUserName.Location = new System.Drawing.Point(129, 38);
            this.txtMacSeriesUserName.Name = "txtMacSeriesUserName";
            this.txtMacSeriesUserName.Size = new System.Drawing.Size(180, 21);
            this.txtMacSeriesUserName.TabIndex = 1008;
            // 
            // frmMJSeaUserPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 177);
            this.Controls.Add(this.txtMacSeriesUserName);
            this.Controls.Add(this.lbMacSeriesUserName);
            this.Controls.Add(this.txtPwd2);
            this.Controls.Add(this.txtPwd1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJSeaUserPwd";
            this.Text = "MJSeaUserPwd";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtPwd1, 0);
            this.Controls.SetChildIndex(this.txtPwd2, 0);
            this.Controls.SetChildIndex(this.lbMacSeriesUserName, 0);
            this.Controls.SetChildIndex(this.txtMacSeriesUserName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd1;
        private System.Windows.Forms.TextBox txtPwd2;
        private System.Windows.Forms.Label lbMacSeriesUserName;
        private System.Windows.Forms.TextBox txtMacSeriesUserName;
    }
}