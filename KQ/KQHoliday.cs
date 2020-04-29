using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQHoliday : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "KQHoliday";
      AddColumn(3, "SelectCheck", false, false, 1, 0);
      AddColumn(0, "HolidayID", true, true, 0);
      AddColumn(0, "HolidayName", false, true, 0);
      AddColumn(0, "HolidayBeginTime", false, true, 0);
      AddColumn(0, "HolidayEndTime", false, true, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      //SetToolItemState("ItemLine1", false);
      base.InitForm();
      ExecItemRefresh();
    }

    public frmKQHoliday()
    {
      InitializeComponent();
    }
     public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
     {
         SelectData(e.CheckedState);
     }
     protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000209, new string[] { "0" });
      base.ExecItemRefresh();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQHolidayAdd frm = new frmKQHolidayAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmKQHolidayAdd frm = new frmKQHolidayAdd(this.Text, CurrentTool, GetHolidayID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    private string GetHolidayID()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      return drv.Row["HolidayID"].ToString();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_000209, new string[] { "1", dataGrid[1, rowIndex].Value.ToString() });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString() + "," +
        dataGrid.Columns[3].HeaderText + "=" + dataGrid[3, rowIndex].Value.ToString();
      return ret;
    }
  }
}