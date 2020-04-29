namespace Taurus
{
    partial class frmSYSetPort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYSetPort));
            this.lbRegularPort = new System.Windows.Forms.Label();
            this.lbSeaPort = new System.Windows.Forms.Label();
            this.lbStarPort = new System.Windows.Forms.Label();
            this.txtRegularPort = new System.Windows.Forms.TextBox();
            this.txtStarPort = new System.Windows.Forms.TextBox();
            this.txtSeaPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(120, 166);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 166);
            this.btnCancel.Text = "";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // lbRegularPort
            // 
            this.lbRegularPort.AutoSize = true;
            this.lbRegularPort.Location = new System.Drawing.Point(21, 58);
            this.lbRegularPort.Name = "lbRegularPort";
            this.lbRegularPort.Size = new System.Drawing.Size(41, 12);
            this.lbRegularPort.TabIndex = 1015;
            this.lbRegularPort.Text = "label1";
            // 
            // lbSeaPort
            // 
            this.lbSeaPort.AutoSize = true;
            this.lbSeaPort.Location = new System.Drawing.Point(23, 93);
            this.lbSeaPort.Name = "lbSeaPort";
            this.lbSeaPort.Size = new System.Drawing.Size(41, 12);
            this.lbSeaPort.TabIndex = 1016;
            this.lbSeaPort.Text = "label2";
            // 
            // lbStarPort
            // 
            this.lbStarPort.AutoSize = true;
            this.lbStarPort.Location = new System.Drawing.Point(23, 128);
            this.lbStarPort.Name = "lbStarPort";
            this.lbStarPort.Size = new System.Drawing.Size(41, 12);
            this.lbStarPort.TabIndex = 1017;
            this.lbStarPort.Text = "label3";
            // 
            // txtRegularPort
            // 
            this.txtRegularPort.Location = new System.Drawing.Point(176, 54);
            this.txtRegularPort.Name = "txtRegularPort";
            this.txtRegularPort.Size = new System.Drawing.Size(100, 21);
            this.txtRegularPort.TabIndex = 1018;
            // 
            // txtStarPort
            // 
            this.txtStarPort.Location = new System.Drawing.Point(175, 124);
            this.txtStarPort.Name = "txtStarPort";
            this.txtStarPort.Size = new System.Drawing.Size(100, 21);
            this.txtStarPort.TabIndex = 1019;
            // 
            // txtSeaPort
            // 
            this.txtSeaPort.Location = new System.Drawing.Point(176, 89);
            this.txtSeaPort.Name = "txtSeaPort";
            this.txtSeaPort.Size = new System.Drawing.Size(100, 21);
            this.txtSeaPort.TabIndex = 1020;
            // 
            // frmSYSetPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 200);
            this.Controls.Add(this.txtSeaPort);
            this.Controls.Add(this.txtStarPort);
            this.Controls.Add(this.txtRegularPort);
            this.Controls.Add(this.lbStarPort);
            this.Controls.Add(this.lbSeaPort);
            this.Controls.Add(this.lbRegularPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSYSetPort";
            this.Text = "SYSetPort";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lbRegularPort, 0);
            this.Controls.SetChildIndex(this.lbSeaPort, 0);
            this.Controls.SetChildIndex(this.lbStarPort, 0);
            this.Controls.SetChildIndex(this.txtRegularPort, 0);
            this.Controls.SetChildIndex(this.txtStarPort, 0);
            this.Controls.SetChildIndex(this.txtSeaPort, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRegularPort;
        private System.Windows.Forms.Label lbSeaPort;
        private System.Windows.Forms.Label lbStarPort;
        private System.Windows.Forms.TextBox txtRegularPort;
        private System.Windows.Forms.TextBox txtStarPort;
        private System.Windows.Forms.TextBox txtSeaPort;
    }
}