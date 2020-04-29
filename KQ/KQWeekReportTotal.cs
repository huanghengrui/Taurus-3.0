using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQWeekReportTotal : frmBaseMDIChildReportPrint
  {
    protected override void InitForm()
    {
      formCode = "KQReportWeek";
      ReportFile = "KQWeekReportTotal";
      IgnoreTagExt = true;
      IsInitBaseForm = true;
      IgnoreDimission = false;
      ShowKQType = true;
      base.InitForm();
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
      dtpStart.CustomFormat = SystemInfo.YMWFormatForm;
    }

    public frmKQWeekReportTotal()
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
      string ResultYM = dtpStart.Value.ToString(SystemInfo.YMWFormatForm);
      string ResultYMA = dtpStart.Value.ToString(SystemInfo.DateFormatLog);
      string tmpTitle = dtpStart.Value.ToString(SystemInfo.YMWFormatForm);
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
      QuerySQL = Pub.GetSQL(DBCode.DB_000218, new string[] { "1", EmpTag, EmpNo, DepartTag, DepartID, DepartList, ResultYMA });
      SetReportDate(dispView, lbWeek.Text + ": " + ResultYM);
      base.ExecItemRefresh();
      SetReportTitle(dispView, tmpTitle + this.Text);
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
  }
}