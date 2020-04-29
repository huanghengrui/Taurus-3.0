namespace Taurus
{
    partial class frmMJSeaNetParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJSeaNetParam));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddr = new System.Windows.Forms.TextBox();
            this.txtSubmask = new System.Windows.Forms.TextBox();
            this.txtWebPort = new System.Windows.Forms.TextBox();
            this.txtListenPort = new System.Windows.Forms.TextBox();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetNetParam = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(242, 238);
            this.btnOk.Size = new System.Drawing.Size(95, 25);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 238);
            this.btnCancel.Text = "";
            this.btnCancel.Visible = false;
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
            this.label1.Location = new System.Drawing.Point(14, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1002;
            this.label1.Tag = "lbRecTuneUrl";
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1003;
            this.label2.Tag = "MacPort";
            this.label2.Text = "label2";
            // 
            // txtIPAddr
            // 
            this.txtIPAddr.Location = new System.Drawing.Point(155, 46);
            this.txtIPAddr.MaxLength = 64;
            this.txtIPAddr.Name = "txtIPAddr";
            this.txtIPAddr.Size = new System.Drawing.Size(180, 21);
            this.txtIPAddr.TabIndex = 1004;
            // 
            // txtSubmask
            // 
            this.txtSubmask.Location = new System.Drawing.Point(155, 85);
            this.txtSubmask.MaxLength = 64;
            this.txtSubmask.Name = "txtSubmask";
            this.txtSubmask.Size = new System.Drawing.Size(180, 21);
            this.txtSubmask.TabIndex = 1005;
            // 
            // txtWebPort
            // 
            this.txtWebPort.Location = new System.Drawing.Point(155, 202);
            this.txtWebPort.Name = "txtWebPort";
            this.txtWebPort.Size = new System.Drawing.Size(180, 21);
            this.txtWebPort.TabIndex = 1017;
            // 
            // txtListenPort
            // 
            this.txtListenPort.Location = new System.Drawing.Point(155, 163);
            this.txtListenPort.Name = "txtListenPort";
            this.txtListenPort.Size = new System.Drawing.Size(180, 21);
            this.txtListenPort.TabIndex = 1016;
            // 
            // txtGateway
            // 
            this.txtGateway.Location = new System.Drawing.Point(155, 124);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(180, 21);
            this.txtGateway.TabIndex = 1015;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1014;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1013;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1012;
            this.label3.Text = "label3";
            // 
            // btnGetNetParam
            // 
            this.btnGetNetParam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetNetParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetNetParam.Location = new System.Drawing.Point(133, 238);
            this.btnGetNetParam.Name = "btnGetNetParam";
            this.btnGetNetParam.Size = new System.Drawing.Size(95, 25);
            this.btnGetNetParam.TabIndex = 1025;
            this.btnGetNetParam.Text = "button1";
            this.btnGetNetParam.Click += new System.EventHandler(this.btnGetNetParam_Click);
            // 
            // frmMJSeaNetParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 271);
            this.Controls.Add(this.btnGetNetParam);
            this.Controls.Add(this.txtWebPort);
            this.Controls.Add(this.txtListenPort);
            this.Controls.Add(this.txtGateway);
            this.Controls.Add(this.txtSubmask);
            this.Controls.Add(this.txtIPAddr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJSeaNetParam";
            this.Text = "MJSeaNetParam";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtIPAddr, 0);
            this.Controls.SetChildIndex(this.txtSubmask, 0);
            this.Controls.SetChildIndex(this.txtGateway, 0);
            this.Controls.SetChildIndex(this.txtListenPort, 0);
            this.Controls.SetChildIndex(this.txtWebPort, 0);
            this.Controls.SetChildIndex(this.btnGetNetParam, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPAddr;
        private System.Windows.Forms.TextBox txtSubmask;
        private System.Windows.Forms.TextBox txtWebPort;
        private System.Windows.Forms.TextBox txtListenPort;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnGetNetParam;
    }
}