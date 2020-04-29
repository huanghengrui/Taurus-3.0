namespace Taurus
{
    partial class frmPubSelectMacSN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubSelectMacSN));
            this.tvMacSN = new System.Windows.Forms.TreeView();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblQuickSearchMacSN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(322, 435);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(402, 435);
            this.btnCancel.Text = "";
            // 
            // ilTreeState
            // 
            this.ilTreeState.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilTreeState.ImageSize = new System.Drawing.Size(16, 16);
            this.ilTreeState.ImageStream = null;
            // 
            // tvMacSN
            // 
            this.tvMacSN.BackColor = System.Drawing.SystemColors.Window;
            this.tvMacSN.CausesValidation = false;
            this.tvMacSN.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvMacSN.Location = new System.Drawing.Point(12, 37);
            this.tvMacSN.Name = "tvMacSN";
            this.tvMacSN.ShowLines = false;
            this.tvMacSN.ShowNodeToolTips = true;
            this.tvMacSN.Size = new System.Drawing.Size(464, 390);
            this.tvMacSN.TabIndex = 1002;
            this.tvMacSN.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvMacSN_AfterCheck);
            this.tvMacSN.DoubleClick += new System.EventHandler(this.tvMacSN_DoubleClick);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(12, 436);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 21);
            this.txtFind.TabIndex = 1003;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // lblQuickSearchMacSN
            // 
            this.lblQuickSearchMacSN.AutoSize = true;
            this.lblQuickSearchMacSN.Location = new System.Drawing.Point(119, 440);
            this.lblQuickSearchMacSN.Name = "lblQuickSearchMacSN";
            this.lblQuickSearchMacSN.Size = new System.Drawing.Size(41, 12);
            this.lblQuickSearchMacSN.TabIndex = 1004;
            this.lblQuickSearchMacSN.Text = "label1";
            // 
            // frmPubSelectMacSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 467);
            this.Controls.Add(this.lblQuickSearchMacSN);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.tvMacSN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPubSelectMacSN";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.tvMacSN, 0);
            this.Controls.SetChildIndex(this.txtFind, 0);
            this.Controls.SetChildIndex(this.lblQuickSearchMacSN, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvMacSN;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label lblQuickSearchMacSN;
    }
}