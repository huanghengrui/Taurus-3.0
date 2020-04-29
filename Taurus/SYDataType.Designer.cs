namespace Taurus
{
    partial class frmSYDataType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYDataType));
            this.rbAccess = new System.Windows.Forms.RadioButton();
            this.rbSql = new System.Windows.Forms.RadioButton();
            this.lbACSQ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(340, 132);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(420, 132);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // rbAccess
            // 
            this.rbAccess.AutoSize = true;
            this.rbAccess.Location = new System.Drawing.Point(29, 39);
            this.rbAccess.Name = "rbAccess";
            this.rbAccess.Size = new System.Drawing.Size(95, 16);
            this.rbAccess.TabIndex = 1003;
            this.rbAccess.Text = "radioButton1";
            this.rbAccess.UseVisualStyleBackColor = true;
            // 
            // rbSql
            // 
            this.rbSql.AutoSize = true;
            this.rbSql.Location = new System.Drawing.Point(29, 68);
            this.rbSql.Name = "rbSql";
            this.rbSql.Size = new System.Drawing.Size(95, 16);
            this.rbSql.TabIndex = 1004;
            this.rbSql.Text = "radioButton2";
            this.rbSql.UseVisualStyleBackColor = true;
            // 
            // lbACSQ
            // 
            this.lbACSQ.AutoSize = true;
            this.lbACSQ.ForeColor = System.Drawing.Color.Red;
            this.lbACSQ.Location = new System.Drawing.Point(27, 98);
            this.lbACSQ.Name = "lbACSQ";
            this.lbACSQ.Size = new System.Drawing.Size(41, 12);
            this.lbACSQ.TabIndex = 1005;
            this.lbACSQ.Text = "label1";
            // 
            // frmSYDataType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 165);
            this.Controls.Add(this.lbACSQ);
            this.Controls.Add(this.rbSql);
            this.Controls.Add(this.rbAccess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(2, 2);
            this.Name = "frmSYDataType";
            this.Text = "SYDataType";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.rbAccess, 0);
            this.Controls.SetChildIndex(this.rbSql, 0);
            this.Controls.SetChildIndex(this.lbACSQ, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbAccess;
        private System.Windows.Forms.RadioButton rbSql;
        private System.Windows.Forms.Label lbACSQ;
    }
}