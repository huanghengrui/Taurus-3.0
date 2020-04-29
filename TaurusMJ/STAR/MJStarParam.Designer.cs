namespace Taurus
{
    partial class frmMJStarParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJStarParam));
            this.btnGetParam = new DevComponents.DotNetBar.ButtonX();
            this.cbbVerifyMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbVerifyMode = new System.Windows.Forms.Label();
            this.cbbVolume = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbVolume = new System.Windows.Forms.Label();
            this.lbMinuteSl = new System.Windows.Forms.Label();
            this.lbMinuteSc = new System.Windows.Forms.Label();
            this.txtSleepTime = new System.Windows.Forms.TextBox();
            this.lbSleepTime = new System.Windows.Forms.Label();
            this.txtScreensaversTime = new System.Windows.Forms.TextBox();
            this.lbScreensaversTime = new System.Windows.Forms.Label();
            this.lbMinuteR = new System.Windows.Forms.Label();
            this.lbSecondA = new System.Windows.Forms.Label();
            this.lbSecondO = new System.Windows.Forms.Label();
            this.txtReverifyTime = new System.Windows.Forms.TextBox();
            this.lbReverifyTime = new System.Windows.Forms.Label();
            this.txtAlarmDelay = new System.Windows.Forms.TextBox();
            this.lbAlarmDelay = new System.Windows.Forms.Label();
            this.txtOpenDoorDelay = new System.Windows.Forms.TextBox();
            this.lbOpenDoorDelay = new System.Windows.Forms.Label();
            this.cbbLanguage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.cbbWiegandType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbWiegandType = new System.Windows.Forms.Label();
            this.txtDevName = new System.Windows.Forms.TextBox();
            this.lbDevName = new System.Windows.Forms.Label();
            this.chkAntiPass = new System.Windows.Forms.CheckBox();
            this.chkTamperAlarm = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(610, 264);
            this.btnOk.Size = new System.Drawing.Size(95, 25);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(616, 264);
            this.btnCancel.Size = new System.Drawing.Size(89, 25);
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
            // btnGetParam
            // 
            this.btnGetParam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetParam.Location = new System.Drawing.Point(495, 264);
            this.btnGetParam.Name = "btnGetParam";
            this.btnGetParam.Size = new System.Drawing.Size(95, 25);
            this.btnGetParam.TabIndex = 1025;
            this.btnGetParam.Text = "button1";
            this.btnGetParam.Click += new System.EventHandler(this.btnGetParam_Click);
            // 
            // cbbVerifyMode
            // 
            this.cbbVerifyMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbVerifyMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVerifyMode.ForeColor = System.Drawing.Color.Black;
            this.cbbVerifyMode.FormattingEnabled = true;
            this.cbbVerifyMode.ItemHeight = 16;
            this.cbbVerifyMode.Location = new System.Drawing.Point(183, 192);
            this.cbbVerifyMode.Name = "cbbVerifyMode";
            this.cbbVerifyMode.Size = new System.Drawing.Size(124, 22);
            this.cbbVerifyMode.TabIndex = 1054;
            // 
            // lbVerifyMode
            // 
            this.lbVerifyMode.AutoSize = true;
            this.lbVerifyMode.BackColor = System.Drawing.Color.Transparent;
            this.lbVerifyMode.Location = new System.Drawing.Point(19, 197);
            this.lbVerifyMode.Name = "lbVerifyMode";
            this.lbVerifyMode.Size = new System.Drawing.Size(65, 12);
            this.lbVerifyMode.TabIndex = 1053;
            this.lbVerifyMode.Text = "VerifyMode";
            // 
            // cbbVolume
            // 
            this.cbbVolume.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVolume.ForeColor = System.Drawing.Color.Black;
            this.cbbVolume.FormattingEnabled = true;
            this.cbbVolume.ItemHeight = 16;
            this.cbbVolume.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbbVolume.Location = new System.Drawing.Point(183, 154);
            this.cbbVolume.Name = "cbbVolume";
            this.cbbVolume.Size = new System.Drawing.Size(124, 22);
            this.cbbVolume.TabIndex = 1052;
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.BackColor = System.Drawing.Color.Transparent;
            this.lbVolume.Location = new System.Drawing.Point(19, 159);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(41, 12);
            this.lbVolume.TabIndex = 1051;
            this.lbVolume.Text = "Volume";
            // 
            // lbMinuteSl
            // 
            this.lbMinuteSl.AutoSize = true;
            this.lbMinuteSl.BackColor = System.Drawing.Color.Transparent;
            this.lbMinuteSl.Location = new System.Drawing.Point(667, 197);
            this.lbMinuteSl.Name = "lbMinuteSl";
            this.lbMinuteSl.Size = new System.Drawing.Size(41, 12);
            this.lbMinuteSl.TabIndex = 1050;
            this.lbMinuteSl.Tag = "lbMinute";
            this.lbMinuteSl.Text = "Minute";
            // 
            // lbMinuteSc
            // 
            this.lbMinuteSc.AutoSize = true;
            this.lbMinuteSc.BackColor = System.Drawing.Color.Transparent;
            this.lbMinuteSc.Location = new System.Drawing.Point(667, 159);
            this.lbMinuteSc.Name = "lbMinuteSc";
            this.lbMinuteSc.Size = new System.Drawing.Size(41, 12);
            this.lbMinuteSc.TabIndex = 1049;
            this.lbMinuteSc.Tag = "lbMinute";
            this.lbMinuteSc.Text = "Minute";
            // 
            // txtSleepTime
            // 
            this.txtSleepTime.Location = new System.Drawing.Point(535, 193);
            this.txtSleepTime.Name = "txtSleepTime";
            this.txtSleepTime.Size = new System.Drawing.Size(120, 21);
            this.txtSleepTime.TabIndex = 1048;
            // 
            // lbSleepTime
            // 
            this.lbSleepTime.AutoSize = true;
            this.lbSleepTime.BackColor = System.Drawing.Color.Transparent;
            this.lbSleepTime.Location = new System.Drawing.Point(351, 197);
            this.lbSleepTime.Name = "lbSleepTime";
            this.lbSleepTime.Size = new System.Drawing.Size(59, 12);
            this.lbSleepTime.TabIndex = 1047;
            this.lbSleepTime.Text = "SleepTime";
            // 
            // txtScreensaversTime
            // 
            this.txtScreensaversTime.Location = new System.Drawing.Point(535, 155);
            this.txtScreensaversTime.Name = "txtScreensaversTime";
            this.txtScreensaversTime.Size = new System.Drawing.Size(120, 21);
            this.txtScreensaversTime.TabIndex = 1046;
            // 
            // lbScreensaversTime
            // 
            this.lbScreensaversTime.AutoSize = true;
            this.lbScreensaversTime.BackColor = System.Drawing.Color.Transparent;
            this.lbScreensaversTime.Location = new System.Drawing.Point(351, 159);
            this.lbScreensaversTime.Name = "lbScreensaversTime";
            this.lbScreensaversTime.Size = new System.Drawing.Size(101, 12);
            this.lbScreensaversTime.TabIndex = 1045;
            this.lbScreensaversTime.Text = "ScreensaversTime";
            // 
            // lbMinuteR
            // 
            this.lbMinuteR.AutoSize = true;
            this.lbMinuteR.BackColor = System.Drawing.Color.Transparent;
            this.lbMinuteR.Location = new System.Drawing.Point(665, 121);
            this.lbMinuteR.Name = "lbMinuteR";
            this.lbMinuteR.Size = new System.Drawing.Size(41, 12);
            this.lbMinuteR.TabIndex = 1044;
            this.lbMinuteR.Tag = "lbMinute";
            this.lbMinuteR.Text = "Minute";
            // 
            // lbSecondA
            // 
            this.lbSecondA.AutoSize = true;
            this.lbSecondA.BackColor = System.Drawing.Color.Transparent;
            this.lbSecondA.Location = new System.Drawing.Point(667, 81);
            this.lbSecondA.Name = "lbSecondA";
            this.lbSecondA.Size = new System.Drawing.Size(41, 12);
            this.lbSecondA.TabIndex = 1043;
            this.lbSecondA.Tag = "lbSecond";
            this.lbSecondA.Text = "Second";
            // 
            // lbSecondO
            // 
            this.lbSecondO.AutoSize = true;
            this.lbSecondO.BackColor = System.Drawing.Color.Transparent;
            this.lbSecondO.Location = new System.Drawing.Point(665, 45);
            this.lbSecondO.Name = "lbSecondO";
            this.lbSecondO.Size = new System.Drawing.Size(41, 12);
            this.lbSecondO.TabIndex = 1042;
            this.lbSecondO.Tag = "lbSecond";
            this.lbSecondO.Text = "Second";
            // 
            // txtReverifyTime
            // 
            this.txtReverifyTime.Location = new System.Drawing.Point(535, 117);
            this.txtReverifyTime.Name = "txtReverifyTime";
            this.txtReverifyTime.Size = new System.Drawing.Size(120, 21);
            this.txtReverifyTime.TabIndex = 1041;
            // 
            // lbReverifyTime
            // 
            this.lbReverifyTime.AutoSize = true;
            this.lbReverifyTime.BackColor = System.Drawing.Color.Transparent;
            this.lbReverifyTime.Location = new System.Drawing.Point(351, 121);
            this.lbReverifyTime.Name = "lbReverifyTime";
            this.lbReverifyTime.Size = new System.Drawing.Size(77, 12);
            this.lbReverifyTime.TabIndex = 1040;
            this.lbReverifyTime.Text = "ReverifyTime";
            // 
            // txtAlarmDelay
            // 
            this.txtAlarmDelay.Location = new System.Drawing.Point(535, 77);
            this.txtAlarmDelay.Name = "txtAlarmDelay";
            this.txtAlarmDelay.Size = new System.Drawing.Size(120, 21);
            this.txtAlarmDelay.TabIndex = 1039;
            // 
            // lbAlarmDelay
            // 
            this.lbAlarmDelay.AutoSize = true;
            this.lbAlarmDelay.BackColor = System.Drawing.Color.Transparent;
            this.lbAlarmDelay.Location = new System.Drawing.Point(351, 81);
            this.lbAlarmDelay.Name = "lbAlarmDelay";
            this.lbAlarmDelay.Size = new System.Drawing.Size(65, 12);
            this.lbAlarmDelay.TabIndex = 1038;
            this.lbAlarmDelay.Text = "AlarmDelay";
            // 
            // txtOpenDoorDelay
            // 
            this.txtOpenDoorDelay.Location = new System.Drawing.Point(535, 41);
            this.txtOpenDoorDelay.Name = "txtOpenDoorDelay";
            this.txtOpenDoorDelay.Size = new System.Drawing.Size(124, 21);
            this.txtOpenDoorDelay.TabIndex = 1035;
            // 
            // lbOpenDoorDelay
            // 
            this.lbOpenDoorDelay.AutoSize = true;
            this.lbOpenDoorDelay.BackColor = System.Drawing.Color.Transparent;
            this.lbOpenDoorDelay.Location = new System.Drawing.Point(351, 45);
            this.lbOpenDoorDelay.Name = "lbOpenDoorDelay";
            this.lbOpenDoorDelay.Size = new System.Drawing.Size(83, 12);
            this.lbOpenDoorDelay.TabIndex = 1034;
            this.lbOpenDoorDelay.Text = "OpenDoorDelay";
            // 
            // cbbLanguage
            // 
            this.cbbLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLanguage.ForeColor = System.Drawing.Color.Black;
            this.cbbLanguage.FormattingEnabled = true;
            this.cbbLanguage.ItemHeight = 16;
            this.cbbLanguage.Location = new System.Drawing.Point(183, 116);
            this.cbbLanguage.Name = "cbbLanguage";
            this.cbbLanguage.Size = new System.Drawing.Size(124, 22);
            this.cbbLanguage.TabIndex = 1031;
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoSize = true;
            this.lbLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lbLanguage.Location = new System.Drawing.Point(19, 121);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(53, 12);
            this.lbLanguage.TabIndex = 1030;
            this.lbLanguage.Text = "Language";
            // 
            // cbbWiegandType
            // 
            this.cbbWiegandType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbWiegandType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWiegandType.ForeColor = System.Drawing.Color.Black;
            this.cbbWiegandType.FormattingEnabled = true;
            this.cbbWiegandType.ItemHeight = 16;
            this.cbbWiegandType.Items.AddRange(new object[] {
            "26",
            "34"});
            this.cbbWiegandType.Location = new System.Drawing.Point(183, 76);
            this.cbbWiegandType.Name = "cbbWiegandType";
            this.cbbWiegandType.Size = new System.Drawing.Size(124, 22);
            this.cbbWiegandType.TabIndex = 1029;
            // 
            // lbWiegandType
            // 
            this.lbWiegandType.AutoSize = true;
            this.lbWiegandType.BackColor = System.Drawing.Color.Transparent;
            this.lbWiegandType.Location = new System.Drawing.Point(19, 81);
            this.lbWiegandType.Name = "lbWiegandType";
            this.lbWiegandType.Size = new System.Drawing.Size(71, 12);
            this.lbWiegandType.TabIndex = 1028;
            this.lbWiegandType.Text = "WiegandType";
            // 
            // txtDevName
            // 
            this.txtDevName.Location = new System.Drawing.Point(183, 41);
            this.txtDevName.Name = "txtDevName";
            this.txtDevName.Size = new System.Drawing.Size(124, 21);
            this.txtDevName.TabIndex = 1027;
            // 
            // lbDevName
            // 
            this.lbDevName.AutoSize = true;
            this.lbDevName.BackColor = System.Drawing.Color.Transparent;
            this.lbDevName.Location = new System.Drawing.Point(19, 45);
            this.lbDevName.Name = "lbDevName";
            this.lbDevName.Size = new System.Drawing.Size(47, 12);
            this.lbDevName.TabIndex = 1026;
            this.lbDevName.Text = "DevName";
            // 
            // chkAntiPass
            // 
            this.chkAntiPass.AutoSize = true;
            this.chkAntiPass.Location = new System.Drawing.Point(16, 236);
            this.chkAntiPass.Name = "chkAntiPass";
            this.chkAntiPass.Size = new System.Drawing.Size(78, 16);
            this.chkAntiPass.TabIndex = 1055;
            this.chkAntiPass.Text = "checkBox1";
            this.chkAntiPass.UseVisualStyleBackColor = true;
            // 
            // chkTamperAlarm
            // 
            this.chkTamperAlarm.AutoSize = true;
            this.chkTamperAlarm.Location = new System.Drawing.Point(351, 238);
            this.chkTamperAlarm.Name = "chkTamperAlarm";
            this.chkTamperAlarm.Size = new System.Drawing.Size(78, 16);
            this.chkTamperAlarm.TabIndex = 1056;
            this.chkTamperAlarm.Text = "checkBox1";
            this.chkTamperAlarm.UseVisualStyleBackColor = true;
            // 
            // frmMJStarParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 295);
            this.Controls.Add(this.chkTamperAlarm);
            this.Controls.Add(this.chkAntiPass);
            this.Controls.Add(this.cbbVerifyMode);
            this.Controls.Add(this.lbVerifyMode);
            this.Controls.Add(this.cbbVolume);
            this.Controls.Add(this.lbVolume);
            this.Controls.Add(this.lbMinuteSl);
            this.Controls.Add(this.lbMinuteSc);
            this.Controls.Add(this.txtSleepTime);
            this.Controls.Add(this.lbSleepTime);
            this.Controls.Add(this.txtScreensaversTime);
            this.Controls.Add(this.lbScreensaversTime);
            this.Controls.Add(this.lbMinuteR);
            this.Controls.Add(this.lbSecondA);
            this.Controls.Add(this.lbSecondO);
            this.Controls.Add(this.txtReverifyTime);
            this.Controls.Add(this.lbReverifyTime);
            this.Controls.Add(this.txtAlarmDelay);
            this.Controls.Add(this.lbAlarmDelay);
            this.Controls.Add(this.txtOpenDoorDelay);
            this.Controls.Add(this.lbOpenDoorDelay);
            this.Controls.Add(this.cbbLanguage);
            this.Controls.Add(this.lbLanguage);
            this.Controls.Add(this.cbbWiegandType);
            this.Controls.Add(this.lbWiegandType);
            this.Controls.Add(this.txtDevName);
            this.Controls.Add(this.lbDevName);
            this.Controls.Add(this.btnGetParam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJStarParam";
            this.Text = "MJSeaNetParam";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnGetParam, 0);
            this.Controls.SetChildIndex(this.lbDevName, 0);
            this.Controls.SetChildIndex(this.txtDevName, 0);
            this.Controls.SetChildIndex(this.lbWiegandType, 0);
            this.Controls.SetChildIndex(this.cbbWiegandType, 0);
            this.Controls.SetChildIndex(this.lbLanguage, 0);
            this.Controls.SetChildIndex(this.cbbLanguage, 0);
            this.Controls.SetChildIndex(this.lbOpenDoorDelay, 0);
            this.Controls.SetChildIndex(this.txtOpenDoorDelay, 0);
            this.Controls.SetChildIndex(this.lbAlarmDelay, 0);
            this.Controls.SetChildIndex(this.txtAlarmDelay, 0);
            this.Controls.SetChildIndex(this.lbReverifyTime, 0);
            this.Controls.SetChildIndex(this.txtReverifyTime, 0);
            this.Controls.SetChildIndex(this.lbSecondO, 0);
            this.Controls.SetChildIndex(this.lbSecondA, 0);
            this.Controls.SetChildIndex(this.lbMinuteR, 0);
            this.Controls.SetChildIndex(this.lbScreensaversTime, 0);
            this.Controls.SetChildIndex(this.txtScreensaversTime, 0);
            this.Controls.SetChildIndex(this.lbSleepTime, 0);
            this.Controls.SetChildIndex(this.txtSleepTime, 0);
            this.Controls.SetChildIndex(this.lbMinuteSc, 0);
            this.Controls.SetChildIndex(this.lbMinuteSl, 0);
            this.Controls.SetChildIndex(this.lbVolume, 0);
            this.Controls.SetChildIndex(this.cbbVolume, 0);
            this.Controls.SetChildIndex(this.lbVerifyMode, 0);
            this.Controls.SetChildIndex(this.cbbVerifyMode, 0);
            this.Controls.SetChildIndex(this.chkAntiPass, 0);
            this.Controls.SetChildIndex(this.chkTamperAlarm, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnGetParam;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbVerifyMode;
        private System.Windows.Forms.Label lbVerifyMode;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbVolume;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.Label lbMinuteSl;
        private System.Windows.Forms.Label lbMinuteSc;
        private System.Windows.Forms.TextBox txtSleepTime;
        private System.Windows.Forms.Label lbSleepTime;
        private System.Windows.Forms.TextBox txtScreensaversTime;
        private System.Windows.Forms.Label lbScreensaversTime;
        private System.Windows.Forms.Label lbMinuteR;
        private System.Windows.Forms.Label lbSecondA;
        private System.Windows.Forms.Label lbSecondO;
        private System.Windows.Forms.TextBox txtReverifyTime;
        private System.Windows.Forms.Label lbReverifyTime;
        private System.Windows.Forms.TextBox txtAlarmDelay;
        private System.Windows.Forms.Label lbAlarmDelay;
        private System.Windows.Forms.TextBox txtOpenDoorDelay;
        private System.Windows.Forms.Label lbOpenDoorDelay;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbLanguage;
        private System.Windows.Forms.Label lbLanguage;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbWiegandType;
        private System.Windows.Forms.Label lbWiegandType;
        private System.Windows.Forms.TextBox txtDevName;
        private System.Windows.Forms.Label lbDevName;
        private System.Windows.Forms.CheckBox chkAntiPass;
        private System.Windows.Forms.CheckBox chkTamperAlarm;
    }
}