namespace Taurus
{
    partial class frmMJStarNetParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJStarNetParam));
            this.btnGetParam = new DevComponents.DotNetBar.ButtonX();
            this.txtPushServerPort = new System.Windows.Forms.TextBox();
            this.lbPushServerPort = new System.Windows.Forms.Label();
            this.txtPushServerHost = new System.Windows.Forms.TextBox();
            this.lbPushServerHost = new System.Windows.Forms.Label();
            this.lbSecondI = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lbInterval = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.lbServerPort = new System.Windows.Forms.Label();
            this.txtServerHost = new System.Windows.Forms.TextBox();
            this.lbServerHost = new System.Windows.Forms.Label();
            this.chkPushEnable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(322, 266);
            this.btnOk.Size = new System.Drawing.Size(95, 25);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(389, 266);
            this.btnCancel.Size = new System.Drawing.Size(28, 25);
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
            // btnGetParam
            // 
            this.btnGetParam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetParam.Location = new System.Drawing.Point(207, 266);
            this.btnGetParam.Name = "btnGetParam";
            this.btnGetParam.Size = new System.Drawing.Size(95, 25);
            this.btnGetParam.TabIndex = 1025;
            this.btnGetParam.Text = "button1";
            this.btnGetParam.Click += new System.EventHandler(this.btnGetParam_Click);
            // 
            // txtPushServerPort
            // 
            this.txtPushServerPort.Location = new System.Drawing.Point(217, 152);
            this.txtPushServerPort.Name = "txtPushServerPort";
            this.txtPushServerPort.Size = new System.Drawing.Size(152, 21);
            this.txtPushServerPort.TabIndex = 1036;
            // 
            // lbPushServerPort
            // 
            this.lbPushServerPort.AutoSize = true;
            this.lbPushServerPort.BackColor = System.Drawing.Color.Transparent;
            this.lbPushServerPort.Location = new System.Drawing.Point(39, 156);
            this.lbPushServerPort.Name = "lbPushServerPort";
            this.lbPushServerPort.Size = new System.Drawing.Size(89, 12);
            this.lbPushServerPort.TabIndex = 1035;
            this.lbPushServerPort.Text = "PushServerPort";
            // 
            // txtPushServerHost
            // 
            this.txtPushServerHost.Location = new System.Drawing.Point(217, 114);
            this.txtPushServerHost.Name = "txtPushServerHost";
            this.txtPushServerHost.Size = new System.Drawing.Size(152, 21);
            this.txtPushServerHost.TabIndex = 1034;
            // 
            // lbPushServerHost
            // 
            this.lbPushServerHost.AutoSize = true;
            this.lbPushServerHost.BackColor = System.Drawing.Color.Transparent;
            this.lbPushServerHost.Location = new System.Drawing.Point(39, 118);
            this.lbPushServerHost.Name = "lbPushServerHost";
            this.lbPushServerHost.Size = new System.Drawing.Size(89, 12);
            this.lbPushServerHost.TabIndex = 1033;
            this.lbPushServerHost.Text = "PushServerHost";
            // 
            // lbSecondI
            // 
            this.lbSecondI.AutoSize = true;
            this.lbSecondI.BackColor = System.Drawing.Color.Transparent;
            this.lbSecondI.Location = new System.Drawing.Point(375, 193);
            this.lbSecondI.Name = "lbSecondI";
            this.lbSecondI.Size = new System.Drawing.Size(41, 12);
            this.lbSecondI.TabIndex = 1032;
            this.lbSecondI.Tag = "lbSecond";
            this.lbSecondI.Text = "Second";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(217, 189);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(152, 21);
            this.txtInterval.TabIndex = 1031;
            // 
            // lbInterval
            // 
            this.lbInterval.AutoSize = true;
            this.lbInterval.BackColor = System.Drawing.Color.Transparent;
            this.lbInterval.Location = new System.Drawing.Point(39, 193);
            this.lbInterval.Name = "lbInterval";
            this.lbInterval.Size = new System.Drawing.Size(53, 12);
            this.lbInterval.TabIndex = 1030;
            this.lbInterval.Text = "Interval";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(217, 76);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(152, 21);
            this.txtServerPort.TabIndex = 1029;
            // 
            // lbServerPort
            // 
            this.lbServerPort.AutoSize = true;
            this.lbServerPort.BackColor = System.Drawing.Color.Transparent;
            this.lbServerPort.Location = new System.Drawing.Point(39, 80);
            this.lbServerPort.Name = "lbServerPort";
            this.lbServerPort.Size = new System.Drawing.Size(65, 12);
            this.lbServerPort.TabIndex = 1028;
            this.lbServerPort.Text = "ServerPort";
            // 
            // txtServerHost
            // 
            this.txtServerHost.Location = new System.Drawing.Point(217, 37);
            this.txtServerHost.Name = "txtServerHost";
            this.txtServerHost.Size = new System.Drawing.Size(152, 21);
            this.txtServerHost.TabIndex = 1027;
            // 
            // lbServerHost
            // 
            this.lbServerHost.AutoSize = true;
            this.lbServerHost.BackColor = System.Drawing.Color.Transparent;
            this.lbServerHost.Location = new System.Drawing.Point(39, 41);
            this.lbServerHost.Name = "lbServerHost";
            this.lbServerHost.Size = new System.Drawing.Size(65, 12);
            this.lbServerHost.TabIndex = 1026;
            this.lbServerHost.Text = "ServerHost";
            // 
            // chkPushEnable
            // 
            this.chkPushEnable.AutoSize = true;
            this.chkPushEnable.Location = new System.Drawing.Point(41, 235);
            this.chkPushEnable.Name = "chkPushEnable";
            this.chkPushEnable.Size = new System.Drawing.Size(78, 16);
            this.chkPushEnable.TabIndex = 1037;
            this.chkPushEnable.Text = "checkBox1";
            this.chkPushEnable.UseVisualStyleBackColor = true;
            // 
            // frmMJStarNetParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 303);
            this.Controls.Add(this.chkPushEnable);
            this.Controls.Add(this.txtPushServerPort);
            this.Controls.Add(this.lbPushServerPort);
            this.Controls.Add(this.txtPushServerHost);
            this.Controls.Add(this.lbPushServerHost);
            this.Controls.Add(this.lbSecondI);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.lbInterval);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.lbServerPort);
            this.Controls.Add(this.txtServerHost);
            this.Controls.Add(this.lbServerHost);
            this.Controls.Add(this.btnGetParam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJStarNetParam";
            this.Text = "MJStarNetParam";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnGetParam, 0);
            this.Controls.SetChildIndex(this.lbServerHost, 0);
            this.Controls.SetChildIndex(this.txtServerHost, 0);
            this.Controls.SetChildIndex(this.lbServerPort, 0);
            this.Controls.SetChildIndex(this.txtServerPort, 0);
            this.Controls.SetChildIndex(this.lbInterval, 0);
            this.Controls.SetChildIndex(this.txtInterval, 0);
            this.Controls.SetChildIndex(this.lbSecondI, 0);
            this.Controls.SetChildIndex(this.lbPushServerHost, 0);
            this.Controls.SetChildIndex(this.txtPushServerHost, 0);
            this.Controls.SetChildIndex(this.lbPushServerPort, 0);
            this.Controls.SetChildIndex(this.txtPushServerPort, 0);
            this.Controls.SetChildIndex(this.chkPushEnable, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnGetParam;
        private System.Windows.Forms.TextBox txtPushServerPort;
        private System.Windows.Forms.Label lbPushServerPort;
        private System.Windows.Forms.TextBox txtPushServerHost;
        private System.Windows.Forms.Label lbPushServerHost;
        private System.Windows.Forms.Label lbSecondI;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lbInterval;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label lbServerPort;
        private System.Windows.Forms.TextBox txtServerHost;
        private System.Windows.Forms.Label lbServerHost;
        private System.Windows.Forms.CheckBox chkPushEnable;
    }
}