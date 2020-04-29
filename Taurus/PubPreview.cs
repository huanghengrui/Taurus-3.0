using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace Taurus
{
  public partial class frmPubPreview : frmBaseForm
  {
    private GridppReport Report = null;
    private string title = "";
    private string StrPosition = "";

    protected override void InitForm()
    {
      formCode = "PubPreview";
      base.InitForm();
      this.Text = this.Text + "[" + title + "]";
      Rectangle rect = Screen.PrimaryScreen.WorkingArea;
      this.Left = rect.Left;
      this.Top = rect.Top;
      this.Width = rect.Width;
      this.Height = rect.Height;
      this.WindowState = FormWindowState.Maximized;
      StrPosition = Pub.GetResText(formCode, "ItemPosition", "");
      printView.Report = Report;
      printView.Start();
      ItemFit_Click(null, null);
      Pub.SetFormAppIcon(this);
    }

    public frmPubPreview(GridppReport report, string Title)
    {
      Report = report;
      title = Title;
      InitializeComponent();
    }

    private void printView_StatusChange(object sender, EventArgs e)
    {
      lblRecordState.Text = string.Format(StrPosition, printView.CurPageNo, printView.PageCount);
    }

    private void ItemPrint_Click(object sender, EventArgs e)
    {
      printView.Print(true);
    }

    private void ItemSetup_Click(object sender, EventArgs e)
    {
      if (printView.Report.Printer.PageSetupDialog()) printView.Refresh();
    }

    private void ItemZoomIn_Click(object sender, EventArgs e)
    {
      printView.ZoomIn();
    }

    private void ItemZoomOut_Click(object sender, EventArgs e)
    {
      printView.ZoomOut();
    }

    private void ItemFit_Click(object sender, EventArgs e)
    {
      printView.ZoomToFit();
      ItemFit.CheckState = CheckState.Checked;
      ItemWidth.CheckState = CheckState.Unchecked;
      ItemHeight.CheckState = CheckState.Unchecked;
    }

    private void ItemWidth_Click(object sender, EventArgs e)
    {
      printView.ZoomToWidth();
      ItemFit.CheckState = CheckState.Unchecked;
      ItemWidth.CheckState = CheckState.Checked;
      ItemHeight.CheckState = CheckState.Unchecked;
    }

    private void ItemHeight_Click(object sender, EventArgs e)
    {
      printView.ZoomToHeight();
      ItemFit.CheckState = CheckState.Unchecked;
      ItemWidth.CheckState = CheckState.Unchecked;
      ItemHeight.CheckState = CheckState.Checked;
    }

    private void ItemFirst_Click(object sender, EventArgs e)
    {
      printView.FirstPage();
    }

    private void ItemPrior_Click(object sender, EventArgs e)
    {
      printView.PriorPage();
    }

    private void ItemNext_Click(object sender, EventArgs e)
    {
      printView.NextPage();
    }

    private void ItemLast_Click(object sender, EventArgs e)
    {
      printView.LastPage();
    }

    private void ItemExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}