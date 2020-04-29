using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQDepShift : frmBaseMDIChildTree
  {
    private string DepartID = "";

    protected override void InitForm()
    {
      formCode = "KQDepShift";
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemTAG3", true);
      //SetToolItemState("ItemLine3", true);
      base.InitForm();
      SetToolImage("ItemTAG1", "FileSave");
      SetToolImage("ItemTAG2", "EditUndo");
      SetToolImage("ItemTAG3", "FileSaveAll");
      DataTableReader dr = null;
      TIDAndName idn = new TIDAndName("", "");
      ComboBox cbb;
      for (int i = 1; i <= 31; i++)
      {
        cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
        cbb.Items.Clear();
        cbb.Items.Add(idn);
      }
      try
      {
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "0" }));
        while (dr.Read())
        {
          idn = new TIDAndName(dr["ShiftID"].ToString(), "[" + dr["ShiftID"].ToString() + "]" + 
            dr["ShiftName"].ToString());
          for (int i = 1; i <= 31; i++)
          {
            cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
            cbb.Items.Add(idn);
          }
        }
        for (int i = 1; i <= 31; i++)
        {
          cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
          cbb.SelectedIndex = 0;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      dtpYM.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    }

    public frmKQDepShift()
    {
      InitializeComponent();
    }

    private void pnlRight_Resize(object sender, EventArgs e)
    {
      int w = pnlRight.Width - 80;
      int ww = w / 7;
      int l = 10;
      Label lab;
      for (int i = 1; i <= 7; i++)
      {
        lab = (Label)pnlRight.Controls["lblWeek" + i.ToString()];
        lab.Width = ww;
        lab.Left = l;
        lab.Top = 80;
        l += ww + 10;
      }
      DisplayDays();
      RefreshForm(true);
    }

    private void tvEmp_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (IsInit) return;
      DisplayDays();
      RefreshForm(true);
    }

    private void dtpYM_ValueChanged(object sender, EventArgs e)
    {
      if (IsInit) return;
      DisplayDays();
      RefreshForm(true);
    }

    private void DisplayDays()
    {
      Label lab;
      ComboBox cbb;
      for (int i = 1; i <= 31; i++)
      {
        lab = (Label)pnlRight.Controls["lblDay" + i.ToString("00")];
        lab.Visible = false;
        lab.Enabled = false;
        cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
        cbb.Visible = false;
        cbb.Enabled = false;
      }
      DateTime dt = new DateTime(dtpYM.Value.Year, dtpYM.Value.Month, 1);
      int days = dt.AddMonths(1).AddDays(-1).Day;
      int week = (int)dt.DayOfWeek;
      int l = 10;
      switch (week)
      {
        case 0:
          l = lblWeek1.Left;
          break;
        case 1:
          l = lblWeek2.Left;
          break;
        case 2:
          l = lblWeek3.Left;
          break;
        case 3:
          l = lblWeek4.Left;
          break;
        case 4:
          l = lblWeek5.Left;
          break;
        case 5:
          l = lblWeek6.Left;
          break;
        case 6:
          l = lblWeek7.Left;
          break;
      }
      int xl = l;
      int t = 100;
      int w = lblWeek1.Width;
      for (int i = 1; i <= days; i++)
      {
        lab = (Label)pnlRight.Controls["lblDay" + i.ToString("00")];
        lab.Text = i.ToString();
        toolTip.SetToolTip(lab, lab.Text);
        cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
        lab.Width = w;
        lab.Left = l;
        lab.Visible = true;
        lab.Enabled = true;
        lab.Top = t;
        cbb.Width = w;
        cbb.Left = l;
        cbb.Top = t + 20;
        cbb.Visible = true;
        cbb.Enabled = true;
        l += w + 10;
        if (l + w >= pnlRight.Width)
        {
          l = 10;
          t += 60;
        }
      }
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      RefreshForm(false);
    }

    protected override void ExecItemDelete()
    {
      string sql = Pub.GetSQL(DBCode.DB_000207, new string[] { "1", DepartID, dtpYM.Value.Year.ToString(), 
        dtpYM.Value.Month.ToString() });
      try
      {
        SystemInfo.db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
        return;
      }
      SystemInfo.db.WriteSYLog(this.Text, CurrentTool, sql);
      RefreshForm(true);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      List<string> sql = new List<string>();
      sql.Add(Pub.GetSQL(DBCode.DB_000207, new string[] { "1", DepartID, dtpYM.Value.Year.ToString(), 
        dtpYM.Value.Month.ToString() }));
      DateTime dt = new DateTime(dtpYM.Value.Year, dtpYM.Value.Month, 1);
      int days = dt.AddMonths(1).AddDays(-1).Day;
      string ShiftNo = "";
      ComboBox cbb;
      for (int i = 1; i <= days; i++)
      {
        cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
        ShiftNo = ((TIDAndName)cbb.Items[cbb.SelectedIndex]).id;
        sql.Add(Pub.GetSQL(DBCode.DB_000207, new string[] { "2", DepartID, 
          dt.AddDays(i - 1).ToString(SystemInfo.SQLDateFMT), ShiftNo }));
      }
      if (SystemInfo.db.ExecSQL(sql) != 0) return;
      RefreshForm(true);
      SystemInfo.db.WriteSYLog(this.Text, CurrentTool, sql);
      //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      RefreshForm(true);
    }

    protected override void ExecItemTAG3()
    {
      base.ExecItemTAG3();
      frmKQDepShiftBatch frm = new frmKQDepShiftBatch(this.Text, CurrentTool);
      if (frm.ShowDialog() == DialogResult.OK) RefreshForm(true);
    }

    protected override void ExecItemRefresh()
    {
      DateTime StartTime = DateTime.Now;
      QuerySQL = Pub.GetSQL(DBCode.DB_000207, new string[] { "0", DepartID, dtpYM.Value.Year.ToString(), 
        dtpYM.Value.Month.ToString() });
      RefreshMsg(StrReading);
      DataTable dt = null;
      if (QuerySQL != "")
      {
        try
        {
          dt = SystemInfo.db.GetDataTable(QuerySQL);
        }
        catch (Exception E)
        {
          Pub.ShowErrorMsg(E, QuerySQL);
        }
      }
      ComboBox cbb;
      for (int i = 1; i <= 31; i++)
      {
        cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
        if (cbb.Items.Count > 0) cbb.SelectedIndex = 0;
      }
      if (dt != null)
      {
        DateTime d = new DateTime(dtpYM.Value.Year, dtpYM.Value.Month, 1);
        for (int i = 1; i <= 31; i++)
        {
          cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
          for (int j = 0; j < dt.Rows.Count; j++)
          {
            if (dt.Rows[j]["DepShiftDate"].ToString() == d.AddDays(i - 1).ToString())
            {
              for (int k = 0; k < cbb.Items.Count; k++)
              {
                if (((TIDAndName)cbb.Items[k]).id == dt.Rows[j]["ShiftNo"].ToString())
                {
                  cbb.SelectedIndex = k;
                  break;
                }
              }
              break;
            }
          }
        }
      }
      dt.Clear();
      dt.Reset();
      RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      bool IsDepart = false;
      DepartID = "";
      if (tvEmp.SelectedNode != null)
      {
        DepartID = tvEmp.SelectedNode.Tag.ToString();
        IsDepart = true;
      }
      ItemEdit.Enabled = IsDepart && State;
      ItemDelete.Enabled = IsDepart && State;
      ItemTAG1.Enabled = IsDepart && !State;
      ItemTAG2.Enabled = ItemTAG1.Enabled;
      ItemTAG3.Enabled = (tvEmp.SelectedNode != null) && State;
      label1.Enabled = State;
      dtpYM.Enabled = State;
      tvEmp.Enabled = State;
      Label lab;
      ComboBox cbb;
      for (int i = 1; i <= 31; i++)
      {
        lab = (Label)pnlRight.Controls["lblDay" + i.ToString("00")];
        if (lab.Visible) lab.Enabled = ItemTAG1.Enabled;
        cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
        if (cbb.Visible) cbb.Enabled = ItemTAG1.Enabled;
      }
      if (State) ExecItemRefresh();
    }

    private void frmKQDepShift_Shown(object sender, EventArgs e)
    {
      RefreshForm(true);
    }
  }
}