using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQReportRecords : frmBaseMDIChildReportPrint
  {
    protected override void InitForm()
    {
      formCode = "KQReportRecords";
      ReportFile = "KQReportRecords";
      IsInitBaseForm = true;
      IgnoreDimission = false;
      base.InitForm();
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
      RefreshReport();
    }

    public frmKQReportRecords()
    {
      InitializeComponent();
    }

    protected override void ExecItemRefresh()
    {
      string EmpTag = "0";
      string EmpNo = "";
      string DepartTag = "0";
      string DepartID = "";
      string DepartList = "";
      string ResultYM = dtpStart.Value.ToString(SystemInfo.YMFormatDB);
      if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
      {
        EmpNo = txtEmp.Tag.ToString();
        EmpTag = "1";
      }
      else if (txtEmp.Text.Trim() != "")
      {
        EmpNo = txtEmp.Text.Trim();
      }
      if ((txtDepart.Text.Trim() != "") && (txtDepart.Tag != null))
      {
        DepartID = txtDepart.Tag.ToString();
        DepartTag = "1";
        if (DepartID != "") DepartList = SystemInfo.db.GetDepartChildID(DepartID);
        if (DepartList == "") DepartList = "''";
      }
      else if (txtDepart.Text.Trim() != "")
      {
        DepartID = txtDepart.Text.Trim();
      }
      long days = Pub.DateDiff(DateInterval.Day, dtpStart.Value.Date, dtpEnd.Value.Date) + 1;
      if (days > 31)
      {
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Error001", ""), 31));
        return;
      }
      CalcRecords(EmpTag, EmpNo, DepartTag, DepartID, DepartList, ResultYM);
      QuerySQL = Pub.GetSQL(DBCode.DB_000215, new string[] { "1", EmpTag, EmpNo, DepartTag, DepartID, DepartList, ResultYM });
      System.Threading.Thread.Sleep(1000);
      base.ExecItemRefresh();
      SetReportTitle(dispView, this.Text);
    }

    private void RefreshReport()
    {
      try
      {
        for (int i = 1; i <= Report.DetailGrid.Columns.Count; i++)
        {
          Report.DetailGrid.Columns[i].Visible = false;
        }
        DateTime dt = dtpStart.Value;
        int idx = 1;
        while (dt.Date <= dtpEnd.Value.Date && idx <= 31)
        {
          Report.DetailGrid.Columns[idx].TitleCell.Text = dt.Day.ToString();// dt.Date.ToString("MM\r\ndd");
          Report.DetailGrid.Columns[idx].Visible = true;
          dt = dt.AddDays(1);
          idx++;
        }
        dispView.Refresh();
      }
      finally
      {
      }
    }

    private void CalcRecords(string EmpTag, string EmpNo, string DepartTag, string DepartID, string DepartList, string ResultYM)
    {
      progBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard;
      progBar.Value = 0;
      string msg = Pub.GetResText(formCode, "Msg001", "");
      int empCount = 0;
      bool IsError = false;
      DateTime StartTime = DateTime.Now;
      List<string> sql = new List<string>();
      DataTable dt = null;
      try
      {
        dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000404, new string[] { "5", EmpTag, EmpNo, DepartTag, DepartID, DepartList }));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
          lblMsg.Text = msg + string.Format("{0}/{1}", i + 1, dt.Rows.Count) + "  [" +
            dt.Rows[i]["DepartID"].ToString() + "]" + dt.Rows[i]["DepartName"].ToString() + " - [" +
            dt.Rows[i]["EmpNo"].ToString() + "]" + dt.Rows[i]["EmpName"].ToString() + "  " +
            Pub.GetDateDiffTimes(StartTime, DateTime.Now, true);
          Application.DoEvents();
          if (!CalcRecordsData(dt.Rows[i]["EmpNo"].ToString(), dt.Rows[i]["EmpName"].ToString(), 
            dt.Rows[i]["DepartID"].ToString(), dt.Rows[i]["DepartName"].ToString(), ResultYM))
          {
            IsError = true;
            break;
          }
          empCount += 1;
          progBar.Value = (i + 1) * 100 / dt.Rows.Count;
          Application.DoEvents();
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dt != null)
        {
          dt.Clear();
          dt.Reset();
        }
        dt = null;
      }
      if (IsError)
        msg = Pub.GetResText(formCode, "Msg003", "");
      else
        msg = Pub.GetResText(formCode, "Msg002", "");
      RefreshMsg(string.Format(msg, empCount, Pub.GetDateDiffTimes(StartTime, DateTime.Now, true)));
    }

    private bool CalcRecordsData(string EmpNo, string EmpName, string DepartID, string DepartName, string ResultYM)
    {
      return SystemInfo.objACKQ.PKQ_CalcRecords(EmpNo, EmpName, DepartID, DepartName, dtpStart.Value.Date,
        dtpEnd.Value.Date, ResultYM);
    }

    private void btnSelectEmp_Click(object sender, EventArgs e)
    {
      frmPubSelectEmp frm = new frmPubSelectEmp(IgnoreDimission);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtEmp.Text = frm.EmpName;
        txtEmp.Tag = frm.EmpNo;
      }
    }

    private void btnSelectDepart_Click(object sender, EventArgs e)
    {
      frmPubSelectDepart frm = new frmPubSelectDepart();
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtDepart.Text = frm.DepartName;
        txtDepart.Tag = frm.DepartID;
      }
    }

    private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
    {
      txtEmp.Tag = null;
    }

    private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
    {
      txtDepart.Tag = null;
    }

    private void dtpStart_ValueChanged(object sender, EventArgs e)
    {
      RefreshReport();
    }

    private void dtpEnd_ValueChanged(object sender, EventArgs e)
    {
      RefreshReport();
    }
  }
}