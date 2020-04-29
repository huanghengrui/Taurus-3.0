using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQEmpSignCard : frmBaseMDIChildReportTree
  {
    protected override void InitForm()
    {
      formCode = "KQEmpSignCard";
      ReportFile = "KQEmpSignCard";
      SetToolItemState("ItemImport", false);
      //SetToolItemState("ItemLine5", true);
      SetToolItemState("ItemFindLabel", true);
      SetToolItemState("ItemFindText", true);
      ReportStartIndex = 3;
      IsInitBaseForm = true;
      InitEmp = true;
      base.InitForm();
      FindSQL = Pub.GetSQL(DBCode.DB_000212, new string[] { "5" });
      FindOrderBy = Pub.GetSQL(DBCode.DB_000212, new string[] { "6" });
      FindKeyWord = formCode;
      ExecTreeAfterSelect(tvEmp.SelectedNode);
    }

    public frmKQEmpSignCard()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQEmpSignCardAdd frm = new frmKQEmpSignCardAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmKQEmpSignCardAdd frm = new frmKQEmpSignCardAdd(this.Text, CurrentTool, Report.FieldByName("GUID").AsString);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemFindText()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000212, new string[] { "7", ItemFindText.Text.Trim() });
      ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_000212, new string[] { "1", Report.FieldByName("GUID").AsString });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = Pub.GetResText(formCode, "EmpNo", "") + "=" + Report.FieldByName("EmpNo").AsString + "," +
        Pub.GetResText(formCode, "KQDateTime", "") + "=" + Report.FieldByName("KQDateTime").AsString;
      return ret;
    }

    protected override void ExecTreeAfterSelect()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000212, new string[] { "8", FindSQL, FindOrderBy, nodeEmpNo, 
        nodeDepartID, nodeDepartList });
      base.ExecTreeAfterSelect();
    }
  }
}