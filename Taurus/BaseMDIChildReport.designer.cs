namespace Taurus
{
  partial class frmBaseMDIChildReport
  {
    /// <summary>
    /// ����������������
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// ������������ʹ�õ���Դ��
    /// </summary>
    /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows ������������ɵĴ���

    /// <summary>
    /// �����֧������ķ��� - ��Ҫ
    /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMDIChildReport));
            this.pnlDisp = new System.Windows.Forms.Panel();
            this.dispView = new AxgrproLib.AxGRDisplayViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.SuspendLayout();
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // pnlDisp
            // 
            this.pnlDisp.Controls.Add(this.dispView);
            this.pnlDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisp.Location = new System.Drawing.Point(0, 25);
            this.pnlDisp.Name = "pnlDisp";
            this.pnlDisp.Size = new System.Drawing.Size(634, 348);
            this.pnlDisp.TabIndex = 3;
            // 
            // dispView
            // 
            this.dispView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dispView.Enabled = true;
            this.dispView.Location = new System.Drawing.Point(0, 0);
            this.dispView.Name = "dispView";
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(634, 348);
            this.dispView.TabIndex = 4;
            this.dispView.TabStop = false;
            this.dispView.KeyDownEvent += new AxgrproLib._IGRDisplayViewerEvents_KeyDownEventHandler(this.dispView_KeyDownEvent);
            this.dispView.KeyUpEvent += new AxgrproLib._IGRDisplayViewerEvents_KeyUpEventHandler(this.dispView_KeyUpEvent);
            this.dispView.MouseDownEvent += new AxgrproLib._IGRDisplayViewerEvents_MouseDownEventHandler(this.dispView_MouseDownEvent);
            this.dispView.ContentCellClick += new AxgrproLib._IGRDisplayViewerEvents_ContentCellClickEventHandler(this.dispView_ContentCellClick);
            this.dispView.ContentCellDblClick += new AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEventHandler(this.dispView_ContentCellDblClick);
            this.dispView.ColumnLayoutChange += new System.EventHandler(this.dispView_ColumnLayoutChange);
            this.dispView.SelectionCellChange += new AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEventHandler(this.dispView_SelectionCellChange);
            // 
            // frmBaseMDIChildReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(634, 404);
            this.Controls.Add(this.pnlDisp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaseMDIChildReport";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaseMDIChildReport_KeyDown);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    protected AxgrproLib.AxGRDisplayViewer dispView;
    protected System.Windows.Forms.Panel pnlDisp;


  }
}
