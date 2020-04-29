namespace Taurus
{
    partial class UC_Butten
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUc = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnUc
            // 
            this.btnUc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.btnUc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnUc.Location = new System.Drawing.Point(3, 3);
            this.btnUc.Name = "btnUc";
            this.btnUc.Size = new System.Drawing.Size(33, 25);
            this.btnUc.Symbol = "57345";
            this.btnUc.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnUc.TabIndex = 2;
            this.btnUc.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // UC_Butten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnUc);
            this.Name = "UC_Butten";
            this.Size = new System.Drawing.Size(36, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX btnUc;
    }
}
