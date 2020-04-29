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
  public partial class frmPubDisplay : frmBaseDialog
  {
    private GridppReport Report = null;
    private string title = "";
    private int StartIndex = 1;

    protected override void InitForm()
    {
      formCode = "PubDisplay";
      base.InitForm();
      this.Text = title;
      chkDisply.Items.Clear();
      string s = "";
      for (int i = StartIndex; i <= Report.DetailGrid.Columns.Count; i++)
      {
        s = Report.DetailGrid.Columns[i].TitleCell.Text;
        if (Report.DetailGrid.Columns[i].TitleCell.SupCell != null)
          s = Report.DetailGrid.Columns[i].TitleCell.SupCell.Text + s;
        chkDisply.Items.Add(s, Report.DetailGrid.Columns[i].Visible);
      }
    }

    public frmPubDisplay(GridppReport report, string Title, int ReportStartIndex)
    {
      Report = report;
      title = Title;
      StartIndex = ReportStartIndex;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      for (int i = StartIndex; i <= Report.DetailGrid.Columns.Count; i++)
      {
        Report.DetailGrid.Columns[i].Visible = chkDisply.GetItemChecked(i - StartIndex);
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}