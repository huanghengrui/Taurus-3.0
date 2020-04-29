using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQReportDayDetail : frmBaseForm
  {
    protected override void InitForm()
    {
      formCode = "KQReportDayDetail";
      findGrid.AutoGenerateColumns = false;
      base.InitForm();
    }

    public frmKQReportDayDetail()
    {
      InitializeComponent();
    }

    public void ShowKQData(string EmpNo, DateTime KQDate)
    {
      string sql = Pub.GetSQL(DBCode.DB_000216, new string[] { "1", EmpNo, KQDate.ToString(SystemInfo.SQLDateFMT) });
      findGrid.DataSource = null;
      try
      {
        findGrid.DataSource = SystemInfo.db.GetDataTable(sql);
      }
      catch (Exception e)
      {
        Pub.ShowErrorMsg(e, sql);
      }
    }

    private void findGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      e.Cancel = true;
    }
  }
}