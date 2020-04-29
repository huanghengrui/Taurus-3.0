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
  public partial class frmPowerSetup : frmBaseMDIChildReportTree
  {
    private string Title = "";
    private string CurrentOprt = "";
    private string SysID = "";

    protected override void InitForm()
    {
      SetToolItemState("ItemImport", false);
      formCode = "PowerSetup";
      ReportFile = "PowerSetup";
      ReportStartIndex = 3;
      IsInitBaseForm = true;
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      ExecTreeAfterSelect(tvEmp.SelectedNode);
    }

    public frmPowerSetup(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmPowerSetupAdd frm = new frmPowerSetupAdd(this.Text, CurrentTool, SysID);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmPowerSetupEdit frm = new frmPowerSetupEdit(this.Text, CurrentTool, Report.FieldByName("GUID").AsString);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecTreeAfterSelect()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "600", nodeDepartID, nodeDepartList });
      base.ExecTreeAfterSelect();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_000300, new string[] { "502", Report.FieldByName("MacSN").AsString,
        Report.FieldByName("EmpNo").AsString  });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = "[" + Report.FieldByName("EmpNo").AsString + "]" + Report.FieldByName("EmpName").AsString + 
        " [" + Report.FieldByName("MacSN").AsString + "]";
      return ret;
    }
  }
}