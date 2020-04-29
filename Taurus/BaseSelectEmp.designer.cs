namespace Taurus
{
    partial class frmBaseSelectEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseSelectEmp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbEmp = new System.Windows.Forms.RadioButton();
            this.gbxEmpInfo = new System.Windows.Forms.GroupBox();
            this.cardGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lbPrompt = new System.Windows.Forms.Label();
            this.textUsernum = new System.Windows.Forms.TextBox();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.lblFingerNo = new System.Windows.Forms.Label();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnRemove = new DevComponents.DotNetBar.ButtonX();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.btnGetListFromMac = new DevComponents.DotNetBar.ButtonX();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.btnStop = new DevComponents.DotNetBar.ButtonX();
            this.progBar1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.gbxEmpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOk.Location = new System.Drawing.Point(528, 382);
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(608, 382);
            this.btnCancel.Text = "取消";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.ForeColor = System.Drawing.Color.Black;
            this.rbAll.Location = new System.Drawing.Point(15, 38);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(95, 16);
            this.rbAll.TabIndex = 1002;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "radioButton1";
            this.rbAll.UseVisualStyleBackColor = false;
            this.rbAll.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbEmp
            // 
            this.rbEmp.AutoSize = true;
            this.rbEmp.ForeColor = System.Drawing.Color.Black;
            this.rbEmp.Location = new System.Drawing.Point(15, 60);
            this.rbEmp.Name = "rbEmp";
            this.rbEmp.Size = new System.Drawing.Size(95, 16);
            this.rbEmp.TabIndex = 1003;
            this.rbEmp.Text = "radioButton2";
            this.rbEmp.UseVisualStyleBackColor = false;
            this.rbEmp.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // gbxEmpInfo
            // 
            this.gbxEmpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEmpInfo.Controls.Add(this.cardGrid);
            this.gbxEmpInfo.Controls.Add(this.lbPrompt);
            this.gbxEmpInfo.Controls.Add(this.textUsernum);
            this.gbxEmpInfo.Controls.Add(this.lblQuickSearch);
            this.gbxEmpInfo.Controls.Add(this.lblFingerNo);
            this.gbxEmpInfo.Controls.Add(this.btnAdd);
            this.gbxEmpInfo.Controls.Add(this.btnRemove);
            this.gbxEmpInfo.Controls.Add(this.txtUserId);
            this.gbxEmpInfo.Controls.Add(this.btnClear);
            this.gbxEmpInfo.Controls.Add(this.btnGetListFromMac);
            this.gbxEmpInfo.ForeColor = System.Drawing.Color.Black;
            this.gbxEmpInfo.Location = new System.Drawing.Point(9, 84);
            this.gbxEmpInfo.Name = "gbxEmpInfo";
            this.gbxEmpInfo.Size = new System.Drawing.Size(671, 292);
            this.gbxEmpInfo.TabIndex = 1004;
            this.gbxEmpInfo.TabStop = false;
            this.gbxEmpInfo.Text = "groupBox1";
            // 
            // cardGrid
            // 
            this.cardGrid.AllowUserToAddRows = false;
            this.cardGrid.AllowUserToDeleteRows = false;
            this.cardGrid.AllowUserToResizeRows = false;
            this.cardGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cardGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cardGrid.ColumnHeadersHeight = 25;
            this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cardGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.cardGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cardGrid.Location = new System.Drawing.Point(9, 49);
            this.cardGrid.MultiSelect = false;
            this.cardGrid.Name = "cardGrid";
            this.cardGrid.RowHeadersVisible = false;
            this.cardGrid.RowTemplate.Height = 23;
            this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cardGrid.Size = new System.Drawing.Size(656, 209);
            this.cardGrid.StandardTab = true;
            this.cardGrid.TabIndex = 14;
            this.cardGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cardGrid_KeyDown);
            this.cardGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cardGrid_KeyUp);
            this.cardGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cardGrid_MouseClick);
            // 
            // lbPrompt
            // 
            this.lbPrompt.ForeColor = System.Drawing.Color.Black;
            this.lbPrompt.Location = new System.Drawing.Point(212, 268);
            this.lbPrompt.Name = "lbPrompt";
            this.lbPrompt.Size = new System.Drawing.Size(433, 12);
            this.lbPrompt.TabIndex = 13;
            this.lbPrompt.Text = "label3";
            // 
            // textUsernum
            // 
            this.textUsernum.BackColor = System.Drawing.Color.White;
            this.textUsernum.ForeColor = System.Drawing.Color.Black;
            this.textUsernum.Location = new System.Drawing.Point(97, 263);
            this.textUsernum.Name = "textUsernum";
            this.textUsernum.Size = new System.Drawing.Size(100, 21);
            this.textUsernum.TabIndex = 12;
            this.textUsernum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textUsernum_KeyDown);
            this.textUsernum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textUsernum_KeyPress);
            // 
            // lblQuickSearch
            // 
            this.lblQuickSearch.ForeColor = System.Drawing.Color.Black;
            this.lblQuickSearch.Location = new System.Drawing.Point(7, 268);
            this.lblQuickSearch.Name = "lblQuickSearch";
            this.lblQuickSearch.Size = new System.Drawing.Size(88, 12);
            this.lblQuickSearch.TabIndex = 11;
            this.lblQuickSearch.Text = "label2";
            // 
            // lblFingerNo
            // 
            this.lblFingerNo.AutoSize = true;
            this.lblFingerNo.ForeColor = System.Drawing.Color.Black;
            this.lblFingerNo.Location = new System.Drawing.Point(409, 25);
            this.lblFingerNo.Name = "lblFingerNo";
            this.lblFingerNo.Size = new System.Drawing.Size(41, 12);
            this.lblFingerNo.TabIndex = 10;
            this.lblFingerNo.Text = "label1";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdd.Location = new System.Drawing.Point(591, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "button6";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemove.Location = new System.Drawing.Point(168, 20);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "button5";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.Color.White;
            this.txtUserId.ForeColor = System.Drawing.Color.Black;
            this.txtUserId.Location = new System.Drawing.Point(486, 21);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 21);
            this.txtUserId.TabIndex = 6;
            this.txtUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserId_KeyPress);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.Location = new System.Drawing.Point(87, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "button2";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGetListFromMac
            // 
            this.btnGetListFromMac.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetListFromMac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGetListFromMac.Location = new System.Drawing.Point(6, 20);
            this.btnGetListFromMac.Name = "btnGetListFromMac";
            this.btnGetListFromMac.Size = new System.Drawing.Size(75, 23);
            this.btnGetListFromMac.TabIndex = 0;
            this.btnGetListFromMac.Text = "button1";
            this.btnGetListFromMac.Click += new System.EventHandler(this.btnGetAllFromMac_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Location = new System.Drawing.Point(9, 393);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 1005;
            this.lblMsg.Text = "label1";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMsg1
            // 
            this.lblMsg1.AutoSize = true;
            this.lblMsg1.ForeColor = System.Drawing.Color.Black;
            this.lblMsg1.Location = new System.Drawing.Point(378, 393);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(41, 12);
            this.lblMsg1.TabIndex = 0;
            this.lblMsg1.Text = "label1";
            this.lblMsg1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsg1.Visible = false;
            // 
            // btnStop
            // 
            this.btnStop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStop.Location = new System.Drawing.Point(131, 388);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1007;
            this.btnStop.Text = "停止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // progBar1
            // 
            // 
            // 
            // 
            this.progBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progBar1.Location = new System.Drawing.Point(294, 390);
            this.progBar1.Name = "progBar1";
            this.progBar1.Size = new System.Drawing.Size(75, 18);
            this.progBar1.TabIndex = 1008;
            this.progBar1.Text = "progressBarX1";
            // 
            // frmBaseSelectEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 415);
            this.Controls.Add(this.progBar1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblMsg1);
            this.Controls.Add(this.gbxEmpInfo);
            this.Controls.Add(this.rbEmp);
            this.Controls.Add(this.rbAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaseSelectEmp";
            this.Text = "BaseSelectEmp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaseSelectEmp_FormClosing);
            this.Controls.SetChildIndex(this.rbAll, 0);
            this.Controls.SetChildIndex(this.rbEmp, 0);
            this.Controls.SetChildIndex(this.gbxEmpInfo, 0);
            this.Controls.SetChildIndex(this.lblMsg1, 0);
            this.Controls.SetChildIndex(this.lblMsg, 0);
            this.Controls.SetChildIndex(this.btnStop, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.progBar1, 0);
            this.gbxEmpInfo.ResumeLayout(false);
            this.gbxEmpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbEmp;
        private System.Windows.Forms.GroupBox gbxEmpInfo;
        private DevComponents.DotNetBar.ButtonX btnGetListFromMac;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private System.Windows.Forms.TextBox txtUserId;
        private DevComponents.DotNetBar.ButtonX btnRemove;
        private System.Windows.Forms.Label lblMsg;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.Label lblFingerNo;
        private System.Windows.Forms.Label lbPrompt;
        private System.Windows.Forms.TextBox textUsernum;
        private System.Windows.Forms.Label lblQuickSearch;
        private System.Windows.Forms.Label lblMsg1;
        public DevComponents.DotNetBar.Controls.DataGridViewX cardGrid;
        private DevComponents.DotNetBar.ButtonX btnStop;
        private DevComponents.DotNetBar.Controls.ProgressBarX progBar1;
    }
}