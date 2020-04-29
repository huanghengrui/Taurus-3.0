namespace Taurus
{
    partial class frmMJSeaSetSound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJSeaSetSound));
            this.btnGetSetSound = new DevComponents.DotNetBar.ButtonX();
            this.chkVerifySuccAudio = new System.Windows.Forms.CheckBox();
            this.chkVerifyFailAudio = new System.Windows.Forms.CheckBox();
            this.chkRemoteCtrlAudio = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkVerifySuccGuiTip = new System.Windows.Forms.CheckBox();
            this.chkVerifyFailGuiTip = new System.Windows.Forms.CheckBox();
            this.chkUnregisteredGuiTip = new System.Windows.Forms.CheckBox();
            this.cbbVolume = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chkIPHide = new System.Windows.Forms.CheckBox();
            this.chkIsShowName = new System.Windows.Forms.CheckBox();
            this.chkIsShowTitle = new System.Windows.Forms.CheckBox();
            this.chkIsShowVersion = new System.Windows.Forms.CheckBox();
            this.chkIsShowDate = new System.Windows.Forms.CheckBox();
            this.chkIDCardNumHide = new System.Windows.Forms.CheckBox();
            this.chkICCardNumHide = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(217, 423);
            this.btnOk.Size = new System.Drawing.Size(95, 25);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 423);
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
            // btnGetSetSound
            // 
            this.btnGetSetSound.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetSetSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetSetSound.Location = new System.Drawing.Point(96, 423);
            this.btnGetSetSound.Name = "btnGetSetSound";
            this.btnGetSetSound.Size = new System.Drawing.Size(105, 25);
            this.btnGetSetSound.TabIndex = 1025;
            this.btnGetSetSound.Text = "button1";
            this.btnGetSetSound.Click += new System.EventHandler(this.btnGetSetSound_Click);
            // 
            // chkVerifySuccAudio
            // 
            this.chkVerifySuccAudio.AutoSize = true;
            this.chkVerifySuccAudio.Location = new System.Drawing.Point(18, 41);
            this.chkVerifySuccAudio.Name = "chkVerifySuccAudio";
            this.chkVerifySuccAudio.Size = new System.Drawing.Size(78, 16);
            this.chkVerifySuccAudio.TabIndex = 1026;
            this.chkVerifySuccAudio.Text = "checkBox1";
            this.chkVerifySuccAudio.UseVisualStyleBackColor = true;
            // 
            // chkVerifyFailAudio
            // 
            this.chkVerifyFailAudio.AutoSize = true;
            this.chkVerifyFailAudio.Location = new System.Drawing.Point(18, 71);
            this.chkVerifyFailAudio.Name = "chkVerifyFailAudio";
            this.chkVerifyFailAudio.Size = new System.Drawing.Size(78, 16);
            this.chkVerifyFailAudio.TabIndex = 1027;
            this.chkVerifyFailAudio.Text = "checkBox2";
            this.chkVerifyFailAudio.UseVisualStyleBackColor = true;
            // 
            // chkRemoteCtrlAudio
            // 
            this.chkRemoteCtrlAudio.AutoSize = true;
            this.chkRemoteCtrlAudio.Location = new System.Drawing.Point(128, 71);
            this.chkRemoteCtrlAudio.Name = "chkRemoteCtrlAudio";
            this.chkRemoteCtrlAudio.Size = new System.Drawing.Size(78, 16);
            this.chkRemoteCtrlAudio.TabIndex = 1028;
            this.chkRemoteCtrlAudio.Text = "checkBox3";
            this.chkRemoteCtrlAudio.UseVisualStyleBackColor = true;
            this.chkRemoteCtrlAudio.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1029;
            this.label1.Text = "label1";
            // 
            // chkVerifySuccGuiTip
            // 
            this.chkVerifySuccGuiTip.AutoSize = true;
            this.chkVerifySuccGuiTip.Location = new System.Drawing.Point(18, 125);
            this.chkVerifySuccGuiTip.Name = "chkVerifySuccGuiTip";
            this.chkVerifySuccGuiTip.Size = new System.Drawing.Size(78, 16);
            this.chkVerifySuccGuiTip.TabIndex = 1030;
            this.chkVerifySuccGuiTip.Text = "checkBox4";
            this.chkVerifySuccGuiTip.UseVisualStyleBackColor = true;
            // 
            // chkVerifyFailGuiTip
            // 
            this.chkVerifyFailGuiTip.AutoSize = true;
            this.chkVerifyFailGuiTip.Location = new System.Drawing.Point(18, 155);
            this.chkVerifyFailGuiTip.Name = "chkVerifyFailGuiTip";
            this.chkVerifyFailGuiTip.Size = new System.Drawing.Size(78, 16);
            this.chkVerifyFailGuiTip.TabIndex = 1031;
            this.chkVerifyFailGuiTip.Text = "checkBox5";
            this.chkVerifyFailGuiTip.UseVisualStyleBackColor = true;
            // 
            // chkUnregisteredGuiTip
            // 
            this.chkUnregisteredGuiTip.AutoSize = true;
            this.chkUnregisteredGuiTip.Location = new System.Drawing.Point(18, 185);
            this.chkUnregisteredGuiTip.Name = "chkUnregisteredGuiTip";
            this.chkUnregisteredGuiTip.Size = new System.Drawing.Size(78, 16);
            this.chkUnregisteredGuiTip.TabIndex = 1032;
            this.chkUnregisteredGuiTip.Text = "checkBox6";
            this.chkUnregisteredGuiTip.UseVisualStyleBackColor = true;
            // 
            // cbbVolume
            // 
            this.cbbVolume.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVolume.ForeColor = System.Drawing.Color.Black;
            this.cbbVolume.FormattingEnabled = true;
            this.cbbVolume.ItemHeight = 16;
            this.cbbVolume.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.cbbVolume.Location = new System.Drawing.Point(128, 94);
            this.cbbVolume.Name = "cbbVolume";
            this.cbbVolume.Size = new System.Drawing.Size(121, 22);
            this.cbbVolume.TabIndex = 1034;
            // 
            // chkIPHide
            // 
            this.chkIPHide.AutoSize = true;
            this.chkIPHide.Location = new System.Drawing.Point(18, 215);
            this.chkIPHide.Name = "chkIPHide";
            this.chkIPHide.Size = new System.Drawing.Size(78, 16);
            this.chkIPHide.TabIndex = 1035;
            this.chkIPHide.Text = "checkBox6";
            this.chkIPHide.UseVisualStyleBackColor = true;
            // 
            // chkIsShowName
            // 
            this.chkIsShowName.AutoSize = true;
            this.chkIsShowName.Location = new System.Drawing.Point(18, 245);
            this.chkIsShowName.Name = "chkIsShowName";
            this.chkIsShowName.Size = new System.Drawing.Size(78, 16);
            this.chkIsShowName.TabIndex = 1036;
            this.chkIsShowName.Text = "checkBox6";
            this.chkIsShowName.UseVisualStyleBackColor = true;
            // 
            // chkIsShowTitle
            // 
            this.chkIsShowTitle.AutoSize = true;
            this.chkIsShowTitle.Location = new System.Drawing.Point(18, 275);
            this.chkIsShowTitle.Name = "chkIsShowTitle";
            this.chkIsShowTitle.Size = new System.Drawing.Size(78, 16);
            this.chkIsShowTitle.TabIndex = 1037;
            this.chkIsShowTitle.Text = "checkBox6";
            this.chkIsShowTitle.UseVisualStyleBackColor = true;
            // 
            // chkIsShowVersion
            // 
            this.chkIsShowVersion.AutoSize = true;
            this.chkIsShowVersion.Location = new System.Drawing.Point(18, 305);
            this.chkIsShowVersion.Name = "chkIsShowVersion";
            this.chkIsShowVersion.Size = new System.Drawing.Size(78, 16);
            this.chkIsShowVersion.TabIndex = 1038;
            this.chkIsShowVersion.Text = "checkBox6";
            this.chkIsShowVersion.UseVisualStyleBackColor = true;
            // 
            // chkIsShowDate
            // 
            this.chkIsShowDate.AutoSize = true;
            this.chkIsShowDate.Location = new System.Drawing.Point(18, 335);
            this.chkIsShowDate.Name = "chkIsShowDate";
            this.chkIsShowDate.Size = new System.Drawing.Size(78, 16);
            this.chkIsShowDate.TabIndex = 1039;
            this.chkIsShowDate.Text = "checkBox6";
            this.chkIsShowDate.UseVisualStyleBackColor = true;
            // 
            // chkIDCardNumHide
            // 
            this.chkIDCardNumHide.AutoSize = true;
            this.chkIDCardNumHide.Location = new System.Drawing.Point(18, 365);
            this.chkIDCardNumHide.Name = "chkIDCardNumHide";
            this.chkIDCardNumHide.Size = new System.Drawing.Size(78, 16);
            this.chkIDCardNumHide.TabIndex = 1040;
            this.chkIDCardNumHide.Text = "checkBox6";
            this.chkIDCardNumHide.UseVisualStyleBackColor = true;
            // 
            // chkICCardNumHide
            // 
            this.chkICCardNumHide.AutoSize = true;
            this.chkICCardNumHide.Location = new System.Drawing.Point(18, 395);
            this.chkICCardNumHide.Name = "chkICCardNumHide";
            this.chkICCardNumHide.Size = new System.Drawing.Size(78, 16);
            this.chkICCardNumHide.TabIndex = 1041;
            this.chkICCardNumHide.Text = "checkBox6";
            this.chkICCardNumHide.UseVisualStyleBackColor = true;
            // 
            // frmMJSeaSetSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 455);
            this.Controls.Add(this.chkICCardNumHide);
            this.Controls.Add(this.chkIDCardNumHide);
            this.Controls.Add(this.chkIsShowDate);
            this.Controls.Add(this.chkIsShowVersion);
            this.Controls.Add(this.chkIsShowTitle);
            this.Controls.Add(this.chkIsShowName);
            this.Controls.Add(this.chkIPHide);
            this.Controls.Add(this.cbbVolume);
            this.Controls.Add(this.chkUnregisteredGuiTip);
            this.Controls.Add(this.chkVerifyFailGuiTip);
            this.Controls.Add(this.chkVerifySuccGuiTip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkRemoteCtrlAudio);
            this.Controls.Add(this.chkVerifyFailAudio);
            this.Controls.Add(this.chkVerifySuccAudio);
            this.Controls.Add(this.btnGetSetSound);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJSeaSetSound";
            this.Text = "MJSeaSetSound";
            this.Load += new System.EventHandler(this.frmMJSeaSetSound_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnGetSetSound, 0);
            this.Controls.SetChildIndex(this.chkVerifySuccAudio, 0);
            this.Controls.SetChildIndex(this.chkVerifyFailAudio, 0);
            this.Controls.SetChildIndex(this.chkRemoteCtrlAudio, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkVerifySuccGuiTip, 0);
            this.Controls.SetChildIndex(this.chkVerifyFailGuiTip, 0);
            this.Controls.SetChildIndex(this.chkUnregisteredGuiTip, 0);
            this.Controls.SetChildIndex(this.cbbVolume, 0);
            this.Controls.SetChildIndex(this.chkIPHide, 0);
            this.Controls.SetChildIndex(this.chkIsShowName, 0);
            this.Controls.SetChildIndex(this.chkIsShowTitle, 0);
            this.Controls.SetChildIndex(this.chkIsShowVersion, 0);
            this.Controls.SetChildIndex(this.chkIsShowDate, 0);
            this.Controls.SetChildIndex(this.chkIDCardNumHide, 0);
            this.Controls.SetChildIndex(this.chkICCardNumHide, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnGetSetSound;
        private System.Windows.Forms.CheckBox chkVerifySuccAudio;
        private System.Windows.Forms.CheckBox chkVerifyFailAudio;
        private System.Windows.Forms.CheckBox chkRemoteCtrlAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkVerifySuccGuiTip;
        private System.Windows.Forms.CheckBox chkVerifyFailGuiTip;
        private System.Windows.Forms.CheckBox chkUnregisteredGuiTip;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbVolume;
        private System.Windows.Forms.CheckBox chkIPHide;
        private System.Windows.Forms.CheckBox chkIsShowName;
        private System.Windows.Forms.CheckBox chkIsShowTitle;
        private System.Windows.Forms.CheckBox chkIsShowVersion;
        private System.Windows.Forms.CheckBox chkIsShowDate;
        private System.Windows.Forms.CheckBox chkIDCardNumHide;
        private System.Windows.Forms.CheckBox chkICCardNumHide;
    }
}