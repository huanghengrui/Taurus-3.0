namespace Taurus
{
    partial class frmPubSelectDevGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubSelectDevGroup));
            this.tvGroup = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(240, 345);
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(321, 345);
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
            // tvGroup
            // 
            this.tvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvGroup.BackColor = System.Drawing.Color.White;
            this.tvGroup.FullRowSelect = true;
            this.tvGroup.HideSelection = false;
            this.tvGroup.ItemHeight = 20;
            this.tvGroup.Location = new System.Drawing.Point(12, 34);
            this.tvGroup.Name = "tvGroup";
            this.tvGroup.Size = new System.Drawing.Size(383, 303);
            this.tvGroup.TabIndex = 1002;
            this.tvGroup.DoubleClick += new System.EventHandler(this.tvGroup_DoubleClick);
            // 
            // frmPubSelectDevGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 380);
            this.Controls.Add(this.tvGroup);
            this.Name = "frmPubSelectDevGroup";
            this.Text = "PubSelectDevGroup";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.tvGroup, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvGroup;
    }
}