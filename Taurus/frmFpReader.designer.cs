namespace Taurus
{
    partial class frmFpReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFpReader));
            this.picFpImage = new System.Windows.Forms.PictureBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnInit = new DevComponents.DotNetBar.ButtonX();
            this.lblEmpNo = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.btnEnroll = new DevComponents.DotNetBar.ButtonX();
            this.btnVerify = new DevComponents.DotNetBar.ButtonX();
            this.btnStop = new DevComponents.DotNetBar.ButtonX();
            this.gbxFpReader = new System.Windows.Forms.GroupBox();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnClearFpData = new DevComponents.DotNetBar.ButtonX();
            this.lblFingerNo = new System.Windows.Forms.Label();
            this.txtFingerNo = new System.Windows.Forms.TextBox();
            this.btnGetFpData = new DevComponents.DotNetBar.ButtonX();
            this.cbbDevice = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.picFpImage)).BeginInit();
            this.gbxFpReader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(389, 330);
            this.btnOk.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(469, 330);
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
            // picFpImage
            // 
            this.picFpImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFpImage.Location = new System.Drawing.Point(4, 43);
            this.picFpImage.Name = "picFpImage";
            this.picFpImage.Size = new System.Drawing.Size(224, 256);
            this.picFpImage.TabIndex = 0;
            this.picFpImage.TabStop = false;
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(246, 40);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(238, 21);
            this.txtInfo.TabIndex = 4;
            // 
            // btnInit
            // 
            this.btnInit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInit.Location = new System.Drawing.Point(409, 83);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 6;
            this.btnInit.Text = "Init";
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // lblEmpNo
            // 
            this.lblEmpNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmpNo.AutoSize = true;
            this.lblEmpNo.Location = new System.Drawing.Point(244, 116);
            this.lblEmpNo.Name = "lblEmpNo";
            this.lblEmpNo.Size = new System.Drawing.Size(35, 12);
            this.lblEmpNo.TabIndex = 11;
            this.lblEmpNo.Text = "EmpNo";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpNo.Location = new System.Drawing.Point(332, 113);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(152, 21);
            this.txtEmpNo.TabIndex = 12;
            this.txtEmpNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpNo_KeyDown);
            // 
            // btnEnroll
            // 
            this.btnEnroll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEnroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnroll.Location = new System.Drawing.Point(14, 20);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(110, 23);
            this.btnEnroll.TabIndex = 13;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerify.Location = new System.Drawing.Point(128, 20);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(104, 23);
            this.btnVerify.TabIndex = 14;
            this.btnVerify.Text = "Verify";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnStop
            // 
            this.btnStop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(380, 289);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(104, 23);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // gbxFpReader
            // 
            this.gbxFpReader.Controls.Add(this.btnClose);
            this.gbxFpReader.Controls.Add(this.btnEnroll);
            this.gbxFpReader.Controls.Add(this.btnVerify);
            this.gbxFpReader.Location = new System.Drawing.Point(246, 198);
            this.gbxFpReader.Name = "gbxFpReader";
            this.gbxFpReader.Size = new System.Drawing.Size(238, 85);
            this.gbxFpReader.TabIndex = 16;
            this.gbxFpReader.TabStop = false;
            this.gbxFpReader.Text = "groupBox1";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(128, 49);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClearFpData
            // 
            this.btnClearFpData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearFpData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFpData.Location = new System.Drawing.Point(380, 169);
            this.btnClearFpData.Name = "btnClearFpData";
            this.btnClearFpData.Size = new System.Drawing.Size(104, 23);
            this.btnClearFpData.TabIndex = 17;
            this.btnClearFpData.Text = "Clear";
            this.btnClearFpData.Click += new System.EventHandler(this.btnClearFpData_Click);
            // 
            // lblFingerNo
            // 
            this.lblFingerNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFingerNo.AutoSize = true;
            this.lblFingerNo.Location = new System.Drawing.Point(244, 142);
            this.lblFingerNo.Name = "lblFingerNo";
            this.lblFingerNo.Size = new System.Drawing.Size(53, 12);
            this.lblFingerNo.TabIndex = 19;
            this.lblFingerNo.Text = "FingerNo";
            // 
            // txtFingerNo
            // 
            this.txtFingerNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFingerNo.Location = new System.Drawing.Point(332, 139);
            this.txtFingerNo.Name = "txtFingerNo";
            this.txtFingerNo.ReadOnly = true;
            this.txtFingerNo.Size = new System.Drawing.Size(152, 21);
            this.txtFingerNo.TabIndex = 20;
            // 
            // btnGetFpData
            // 
            this.btnGetFpData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetFpData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFpData.Location = new System.Drawing.Point(246, 169);
            this.btnGetFpData.Name = "btnGetFpData";
            this.btnGetFpData.Size = new System.Drawing.Size(104, 23);
            this.btnGetFpData.TabIndex = 21;
            this.btnGetFpData.Text = "Get";
            this.btnGetFpData.Visible = false;
            this.btnGetFpData.Click += new System.EventHandler(this.btnGetFpData_Click);
            // 
            // cbbDevice
            // 
            this.cbbDevice.DisplayMember = "Text";
            this.cbbDevice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDevice.ForeColor = System.Drawing.Color.Black;
            this.cbbDevice.FormattingEnabled = true;
            this.cbbDevice.ItemHeight = 16;
            this.cbbDevice.Location = new System.Drawing.Point(246, 84);
            this.cbbDevice.Name = "cbbDevice";
            this.cbbDevice.Size = new System.Drawing.Size(121, 22);
            this.cbbDevice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbDevice.TabIndex = 22;
            this.cbbDevice.SelectedIndexChanged += new System.EventHandler(this.cbbDevice_SelectedIndexChanged);
            // 
            // frmFpReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 316);
            this.Controls.Add(this.cbbDevice);
            this.Controls.Add(this.btnGetFpData);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtFingerNo);
            this.Controls.Add(this.lblFingerNo);
            this.Controls.Add(this.btnClearFpData);
            this.Controls.Add(this.gbxFpReader);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.lblEmpNo);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.picFpImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFpReader";
            this.Text = "frmFpReader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFpReader_FormClosing);
            this.Controls.SetChildIndex(this.picFpImage, 0);
            this.Controls.SetChildIndex(this.txtInfo, 0);
            this.Controls.SetChildIndex(this.btnInit, 0);
            this.Controls.SetChildIndex(this.lblEmpNo, 0);
            this.Controls.SetChildIndex(this.txtEmpNo, 0);
            this.Controls.SetChildIndex(this.gbxFpReader, 0);
            this.Controls.SetChildIndex(this.btnClearFpData, 0);
            this.Controls.SetChildIndex(this.lblFingerNo, 0);
            this.Controls.SetChildIndex(this.txtFingerNo, 0);
            this.Controls.SetChildIndex(this.btnStop, 0);
            this.Controls.SetChildIndex(this.btnGetFpData, 0);
            this.Controls.SetChildIndex(this.cbbDevice, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picFpImage)).EndInit();
            this.gbxFpReader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFpImage;
        private System.Windows.Forms.TextBox txtInfo;
        private DevComponents.DotNetBar.ButtonX btnInit;
        private System.Windows.Forms.Label lblEmpNo;
        private System.Windows.Forms.TextBox txtEmpNo;
        private DevComponents.DotNetBar.ButtonX btnEnroll;
        private DevComponents.DotNetBar.ButtonX btnVerify;
        private DevComponents.DotNetBar.ButtonX btnStop;
        private System.Windows.Forms.GroupBox gbxFpReader;
        private DevComponents.DotNetBar.ButtonX btnClearFpData;
        private System.Windows.Forms.Label lblFingerNo;
        private System.Windows.Forms.TextBox txtFingerNo;
        private DevComponents.DotNetBar.ButtonX btnGetFpData;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbDevice;
    }
}