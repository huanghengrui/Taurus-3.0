using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmPassTime : frmBaseMDIChildReport
  {
    private string Title = "";
    private string CurrentOprt = "";

    protected override void InitForm()
    {
      SetToolItemState("ItemImport", false);
      formCode = "PassTime";
      ReportFile = "PassTime";
      ReportStartIndex = 2;
      base.InitForm();
      QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "400" });
      this.Text = Title + "[" + CurrentOprt + "]" ;
    }

    public frmPassTime(string title, string CurrentTool)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmPassTimeAdd frm = new frmPassTimeAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmPassTimeAdd frm = new frmPassTimeAdd(this.Text, CurrentTool, 
        Report.FieldByName("PassTimeID").AsString);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_000300, new string[] { "401", Report.FieldByName("PassTimeID").AsString });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = Pub.GetResText(formCode, "PassTimeID", "") + "=" + Report.FieldByName("PassTimeID").AsString;
      return ret;
    }
  }
}