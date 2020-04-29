using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQDepShiftBatch : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQDepShiftBatch";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
      DataTableReader dr = null;
      TIDAndName idn;
      cbbRule.Items.Clear();
      try
      {
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000205, new string[] { "0" }));
        while (dr.Read())
        {
          idn = new TIDAndName(dr["ShiftRuleID"].ToString(), "[" + dr["ShiftRuleID"].ToString() + "]" +
            dr["ShiftRuleName"].ToString());
          cbbRule.Items.Add(idn);
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
      if (cbbRule.Items.Count > 0) cbbRule.SelectedIndex = 0;
      InitDepartTreeView(tvDepart);
    }

    public frmKQDepShiftBatch(string title, string CurrentTool)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      InitializeComponent();
    }

    private void tvDepart_AfterCheck(object sender, TreeViewEventArgs e)
    {
      if (optSelectAll.Checked) SelectTreeNode(e.Node);
    }

    private bool IsSelectDepart(TreeNode node)
    {
      bool ret = false;
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        if (node.Nodes[i].Checked)
        {
          ret = true;
          break;
        }
        if (IsSelectDepart(node.Nodes[i]))
        {
          ret = true;
          break;
        }
      }
      return ret;
    }

    private void SelectDepartList(TreeNode node, ref List<string> depart)
    {
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        if (node.Nodes[i].Checked) depart.Add(node.Nodes[i].Tag.ToString());
        SelectDepartList(node.Nodes[i], ref depart);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (dtpEnd.Value < dtpStart.Value)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      if (cbbRule.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label3.Text);
        return;
      }
      bool selectDepart = false;
      for (int i = 0; i < tvDepart.Nodes.Count; i++)
      {
        if (tvDepart.Nodes[i].Checked)
        {
          selectDepart = true;
          break;
        }
        if (IsSelectDepart(tvDepart.Nodes[i]))
        {
          selectDepart = true;
          break;
        }
      }
      if (!selectDepart)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectDepart", ""));
        return;
      }
      List<string> depart = new List<string>();
      for (int i = 0; i < tvDepart.Nodes.Count; i++)
      {
        if (tvDepart.Nodes[i].Checked) depart.Add(tvDepart.Nodes[i].Tag.ToString());
        SelectDepartList(tvDepart.Nodes[i], ref depart);
      }
      string ShiftRuleID = ((TIDAndName)cbbRule.Items[cbbRule.SelectedIndex]).id;
      List<string> sql = new List<string>();
      string DepartID = "";
      DataTable dt = null;
      bool IsError = false;
      int days = (int)Pub.DateDiff(DateInterval.Day, dtpStart.Value, dtpEnd.Value);
      int flag = 0;
      int CycDays = 0;
      int row = 0;
      try
      {
        dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000205, new string[] { "3", ShiftRuleID }));
        flag = Convert.ToInt32(dt.Rows[0]["ShiftRulecycID"].ToString());
        CycDays = Convert.ToInt32(dt.Rows[0]["ShiftRulecyc"].ToString());
        dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000205, new string[] { "4", ShiftRuleID }));
        for (int i = 0; i < depart.Count; i++)
        {
          DepartID = depart[i];
          sql.Add(Pub.GetSQL(DBCode.DB_000207, new string[] { "3", DepartID, 
            dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT) }));
          switch (flag)
          {
            case 0:
              row = 1;
              for (int j = 0; j <= days; j++)
              {
                if (row > CycDays) row = 1;
                sql.Add(Pub.GetSQL(DBCode.DB_000207, new string[] { "2", DepartID, 
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row - 1]["ShiftID"].ToString() }));
                row += 1;
              }
              break;
            case 1:
              for (int j = 0; j <= days; j++)
              {
                row = (int)dtpStart.Value.AddDays(j).DayOfWeek;
                sql.Add(Pub.GetSQL(DBCode.DB_000207, new string[] { "2", DepartID, 
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row]["ShiftID"].ToString() }));
              }
              break;
            case 2:
              for (int j = 0; j <= days; j++)
              {
                row = dtpStart.Value.AddDays(j).Day;
                sql.Add(Pub.GetSQL(DBCode.DB_000207, new string[] { "2", DepartID, 
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row - 1]["ShiftID"].ToString() }));
              }
              break;
          }
        }
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dt != null)
        {
          dt.Clear();
          dt.Reset();
        }
      }
      if (IsError) return;
      if (SystemInfo.db.ExecSQL(sql) != 0) return;
      SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
      //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}