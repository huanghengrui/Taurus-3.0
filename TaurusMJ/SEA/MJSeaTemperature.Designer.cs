namespace Taurus
{
    partial class frmMJSeaTemperature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJSeaTemperature));
            this.lbFaceMaskTPTMode = new System.Windows.Forms.Label();
            this.lbTemperatureCheck = new System.Windows.Forms.Label();
            this.lbEnvTemperatureCheck = new System.Windows.Forms.Label();
            this.lbEnvTemperature = new System.Windows.Forms.Label();
            this.lbTemperatureHigh = new System.Windows.Forms.Label();
            this.btnGetTemperatureParam = new DevComponents.DotNetBar.ButtonX();
            this.cbbFaceMaskTPTMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbOpenLaser = new System.Windows.Forms.Label();
            this.cbbOpenLaser = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtTemperatureCheck = new System.Windows.Forms.MaskedTextBox();
            this.txtTemperatureHigh = new System.Windows.Forms.MaskedTextBox();
            this.txtEnvTemperature = new System.Windows.Forms.MaskedTextBox();
            this.txtEnvTemperatureCheck = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(242, 241);
            this.btnOk.Size = new System.Drawing.Size(95, 25);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 241);
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
            // lbFaceMaskTPTMode
            // 
            this.lbFaceMaskTPTMode.AutoSize = true;
            this.lbFaceMaskTPTMode.Location = new System.Drawing.Point(14, 49);
            this.lbFaceMaskTPTMode.Name = "lbFaceMaskTPTMode";
            this.lbFaceMaskTPTMode.Size = new System.Drawing.Size(41, 12);
            this.lbFaceMaskTPTMode.TabIndex = 1002;
            this.lbFaceMaskTPTMode.Tag = "lbRecTuneUrl";
            this.lbFaceMaskTPTMode.Text = "label1";
            this.lbFaceMaskTPTMode.Visible = false;
            // 
            // lbTemperatureCheck
            // 
            this.lbTemperatureCheck.AutoSize = true;
            this.lbTemperatureCheck.Location = new System.Drawing.Point(14, 48);
            this.lbTemperatureCheck.Name = "lbTemperatureCheck";
            this.lbTemperatureCheck.Size = new System.Drawing.Size(41, 12);
            this.lbTemperatureCheck.TabIndex = 1003;
            this.lbTemperatureCheck.Tag = "MacPort";
            this.lbTemperatureCheck.Text = "label2";
            // 
            // lbEnvTemperatureCheck
            // 
            this.lbEnvTemperatureCheck.AutoSize = true;
            this.lbEnvTemperatureCheck.Location = new System.Drawing.Point(14, 165);
            this.lbEnvTemperatureCheck.Name = "lbEnvTemperatureCheck";
            this.lbEnvTemperatureCheck.Size = new System.Drawing.Size(41, 12);
            this.lbEnvTemperatureCheck.TabIndex = 1014;
            this.lbEnvTemperatureCheck.Text = "label5";
            // 
            // lbEnvTemperature
            // 
            this.lbEnvTemperature.AutoSize = true;
            this.lbEnvTemperature.Location = new System.Drawing.Point(14, 126);
            this.lbEnvTemperature.Name = "lbEnvTemperature";
            this.lbEnvTemperature.Size = new System.Drawing.Size(41, 12);
            this.lbEnvTemperature.TabIndex = 1013;
            this.lbEnvTemperature.Text = "label4";
            // 
            // lbTemperatureHigh
            // 
            this.lbTemperatureHigh.AutoSize = true;
            this.lbTemperatureHigh.Location = new System.Drawing.Point(14, 87);
            this.lbTemperatureHigh.Name = "lbTemperatureHigh";
            this.lbTemperatureHigh.Size = new System.Drawing.Size(41, 12);
            this.lbTemperatureHigh.TabIndex = 1012;
            this.lbTemperatureHigh.Text = "label3";
            // 
            // btnGetTemperatureParam
            // 
            this.btnGetTemperatureParam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetTemperatureParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetTemperatureParam.Location = new System.Drawing.Point(133, 241);
            this.btnGetTemperatureParam.Name = "btnGetTemperatureParam";
            this.btnGetTemperatureParam.Size = new System.Drawing.Size(95, 25);
            this.btnGetTemperatureParam.TabIndex = 1025;
            this.btnGetTemperatureParam.Text = "button1";
            this.btnGetTemperatureParam.Click += new System.EventHandler(this.btnGetNetParam_Click);
            // 
            // cbbFaceMaskTPTMode
            // 
            this.cbbFaceMaskTPTMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbFaceMaskTPTMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFaceMaskTPTMode.ForeColor = System.Drawing.Color.Black;
            this.cbbFaceMaskTPTMode.FormattingEnabled = true;
            this.cbbFaceMaskTPTMode.ItemHeight = 16;
            this.cbbFaceMaskTPTMode.Location = new System.Drawing.Point(155, 46);
            this.cbbFaceMaskTPTMode.Name = "cbbFaceMaskTPTMode";
            this.cbbFaceMaskTPTMode.Size = new System.Drawing.Size(182, 22);
            this.cbbFaceMaskTPTMode.TabIndex = 1026;
            this.cbbFaceMaskTPTMode.Visible = false;
            // 
            // lbOpenLaser
            // 
            this.lbOpenLaser.AutoSize = true;
            this.lbOpenLaser.Location = new System.Drawing.Point(14, 202);
            this.lbOpenLaser.Name = "lbOpenLaser";
            this.lbOpenLaser.Size = new System.Drawing.Size(41, 12);
            this.lbOpenLaser.TabIndex = 1027;
            this.lbOpenLaser.Text = "label6";
            // 
            // cbbOpenLaser
            // 
            this.cbbOpenLaser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbOpenLaser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOpenLaser.ForeColor = System.Drawing.Color.Black;
            this.cbbOpenLaser.FormattingEnabled = true;
            this.cbbOpenLaser.ItemHeight = 16;
            this.cbbOpenLaser.Location = new System.Drawing.Point(155, 199);
            this.cbbOpenLaser.Name = "cbbOpenLaser";
            this.cbbOpenLaser.Size = new System.Drawing.Size(182, 22);
            this.cbbOpenLaser.TabIndex = 1028;
            // 
            // txtTemperatureCheck
            // 
            this.txtTemperatureCheck.Location = new System.Drawing.Point(155, 48);
            this.txtTemperatureCheck.Mask = "0.00";
            this.txtTemperatureCheck.Name = "txtTemperatureCheck";
            this.txtTemperatureCheck.Size = new System.Drawing.Size(182, 21);
            this.txtTemperatureCheck.TabIndex = 1029;
            this.txtTemperatureCheck.Text = "000";
            // 
            // txtTemperatureHigh
            // 
            this.txtTemperatureHigh.Location = new System.Drawing.Point(155, 84);
            this.txtTemperatureHigh.Name = "txtTemperatureHigh";
            this.txtTemperatureHigh.Size = new System.Drawing.Size(182, 21);
            this.txtTemperatureHigh.TabIndex = 1030;
            this.txtTemperatureHigh.Text = "37.30";
            // 
            // txtEnvTemperature
            // 
            this.txtEnvTemperature.Location = new System.Drawing.Point(155, 123);
            this.txtEnvTemperature.Name = "txtEnvTemperature";
            this.txtEnvTemperature.Size = new System.Drawing.Size(182, 21);
            this.txtEnvTemperature.TabIndex = 1031;
            this.txtEnvTemperature.Text = "17.00";
            // 
            // txtEnvTemperatureCheck
            // 
            this.txtEnvTemperatureCheck.Location = new System.Drawing.Point(155, 162);
            this.txtEnvTemperatureCheck.Name = "txtEnvTemperatureCheck";
            this.txtEnvTemperatureCheck.Size = new System.Drawing.Size(182, 21);
            this.txtEnvTemperatureCheck.TabIndex = 1032;
            this.txtEnvTemperatureCheck.Text = "0.00";
            // 
            // frmMJSeaTemperature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 274);
            this.Controls.Add(this.txtEnvTemperatureCheck);
            this.Controls.Add(this.txtEnvTemperature);
            this.Controls.Add(this.txtTemperatureHigh);
            this.Controls.Add(this.txtTemperatureCheck);
            this.Controls.Add(this.cbbOpenLaser);
            this.Controls.Add(this.lbOpenLaser);
            this.Controls.Add(this.cbbFaceMaskTPTMode);
            this.Controls.Add(this.btnGetTemperatureParam);
            this.Controls.Add(this.lbEnvTemperatureCheck);
            this.Controls.Add(this.lbEnvTemperature);
            this.Controls.Add(this.lbTemperatureHigh);
            this.Controls.Add(this.lbTemperatureCheck);
            this.Controls.Add(this.lbFaceMaskTPTMode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMJSeaTemperature";
            this.Text = "MJSeaTemperature";
            this.Controls.SetChildIndex(this.lbFaceMaskTPTMode, 0);
            this.Controls.SetChildIndex(this.lbTemperatureCheck, 0);
            this.Controls.SetChildIndex(this.lbTemperatureHigh, 0);
            this.Controls.SetChildIndex(this.lbEnvTemperature, 0);
            this.Controls.SetChildIndex(this.lbEnvTemperatureCheck, 0);
            this.Controls.SetChildIndex(this.btnGetTemperatureParam, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.cbbFaceMaskTPTMode, 0);
            this.Controls.SetChildIndex(this.lbOpenLaser, 0);
            this.Controls.SetChildIndex(this.cbbOpenLaser, 0);
            this.Controls.SetChildIndex(this.txtTemperatureCheck, 0);
            this.Controls.SetChildIndex(this.txtTemperatureHigh, 0);
            this.Controls.SetChildIndex(this.txtEnvTemperature, 0);
            this.Controls.SetChildIndex(this.txtEnvTemperatureCheck, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFaceMaskTPTMode;
        private System.Windows.Forms.Label lbTemperatureCheck;
        private System.Windows.Forms.Label lbEnvTemperatureCheck;
        private System.Windows.Forms.Label lbEnvTemperature;
        private System.Windows.Forms.Label lbTemperatureHigh;
        private DevComponents.DotNetBar.ButtonX btnGetTemperatureParam;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbFaceMaskTPTMode;
        private System.Windows.Forms.Label lbOpenLaser;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbOpenLaser;
        private System.Windows.Forms.MaskedTextBox txtTemperatureCheck;
        private System.Windows.Forms.MaskedTextBox txtTemperatureHigh;
        private System.Windows.Forms.MaskedTextBox txtEnvTemperature;
        private System.Windows.Forms.MaskedTextBox txtEnvTemperatureCheck;
    }
}