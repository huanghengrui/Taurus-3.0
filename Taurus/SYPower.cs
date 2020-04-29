using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmSYPower : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "SYPower";
      AddColumn(3, "SelectCheck", false, false, 1, 0);
      AddColumn(0, "OprtNo", false, true, 80);
      AddColumn(0, "OprtName", false, true, 0);
      AddColumn(0, "OprtDesc", false, false, 0);
      AddColumn(1, "OprtIsSys", false, false, 1, 60);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
     // SetToolItemState("ItemLine1", false);
      base.InitForm();
      ExecItemRefresh();
    }

    public frmSYPower()
    {
      InitializeComponent();
    }

    public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
    {
        SelectData(e.CheckedState);
    }
    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmSYPowerAdd frm = new frmSYPowerAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmSYPowerAdd frm = new frmSYPowerAdd(this.Text, CurrentTool, GetOprtNo());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000002, new string[] { "0" });
      base.ExecItemRefresh();
    }
    
    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      if (bindingSource.Count > 0)
      {
        DataRowView drv = (DataRowView)bindingSource.Current;
        bool IsSys = Pub.ValueToBool(drv.Row["OprtIsSys"].ToString());
        ItemEdit.Enabled = ItemEdit.Enabled && !IsSys;
        ItemDelete.Enabled = ItemDelete.Enabled && !IsSys;
        SetContextMenuState();
      }
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = "";
      string OprtNo = dataGrid[1, rowIndex].Value.ToString();
      bool IsSys = false;
      bool.TryParse(dataGrid[4, rowIndex].Value.ToString(), out IsSys);
      if (!IsSys)
      {
        ret = Pub.GetSQL(DBCode.DB_000002, new string[] { "3", OprtNo });
        sql.Add(ret);
        sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "101", OprtNo }));
      }
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      bool IsSys = false;
      bool.TryParse(dataGrid[4, rowIndex].Value.ToString(), out IsSys);
      if (!IsSys)
      {
        ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
          dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
      }
      return ret;
    }

    private string GetOprtNo()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      return drv.Row["OprtNo"].ToString();
    }
  }
}