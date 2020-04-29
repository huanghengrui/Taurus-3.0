using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQEmpOtSure : frmBaseMDIChildReportTree
  {
    protected override void InitForm()
    {
      formCode = "KQEmpOtSure";
      ReportFile = "KQEmpOtSure";
      SetToolItemState("ItemImport", false);
      //SetToolItemState("ItemLine5", true);
      SetToolItemState("ItemFindLabel", true);
      SetToolItemState("ItemFindText", true);
      ReportStartIndex = 3;
      IsInitBaseForm = true;
      InitEmp = true;
      base.InitForm();
      FindSQL = Pub.GetSQL(DBCode.DB_000211, new string[] { "6" });
      FindOrderBy = Pub.GetSQL(DBCode.DB_000211, new string[] { "7" });
      FindKeyWord = formCode;
      ExecTreeAfterSelect(tvEmp.SelectedNode);
    }

    public frmKQEmpOtSure()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQEmpOtSureAdd frm = new frmKQEmpOtSureAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmKQEmpOtSureAdd frm = new frmKQEmpOtSureAdd(this.Text, CurrentTool,
        Report.FieldByName("EmpOtSureID").AsString);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemFindText()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000211, new string[] { "8", ItemFindText.Text.Trim() });
      ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_000211, new string[] { "1", Report.FieldByName("EmpOtSureID").AsString });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = Pub.GetResText(formCode, "EmpNo", "") + "=" + Report.FieldByName("EmpNo").AsString + "," +
        Pub.GetResText(formCode, "BeginTime", "") + "=" + Report.FieldByName("BeginTime").AsString + "," +
        Pub.GetResText(formCode, "EndTime", "") + "=" + Report.FieldByName("EndTime").AsString;
      return ret;
    }

    protected override void ExecTreeAfterSelect()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000211, new string[] { "9", FindSQL, FindOrderBy, nodeEmpNo, 
        nodeDepartID, nodeDepartList });
      base.ExecTreeAfterSelect();
    }
  }
}