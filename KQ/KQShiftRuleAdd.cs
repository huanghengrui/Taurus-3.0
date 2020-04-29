using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmKQShiftRuleAdd : frmBaseDialog
  {
    private bool IsAdd = false;
    protected override void InitForm()
    {
      formCode = "KQShiftRuleAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      IsAdd = SysID == "";
      cbbShiftRulecycName.Items.Clear();
      cbbShiftRulecycName.Items.Add(Pub.GetResText(formCode, "day", ""));
      cbbShiftRulecycName.Items.Add(Pub.GetResText(formCode, "week", ""));
      cbbShiftRulecycName.Items.Add(Pub.GetResText(formCode, "month", ""));
      cbbShiftRulecycName.SelectedIndex = 0;
      txtShiftRulecyc.Text = "1";
      SetTextboxNumber(txtShiftRulecyc);
      LoadData();
    }

    public frmKQShiftRuleAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      TIDAndName idn = new TIDAndName("", "");
      ComboBox cbb;
      for (int i = 1; i <= 31; i++)
      {
        cbb = (ComboBox)this.groupBox1.Controls["cbb" + i.ToString().Trim()];
        cbb.Items.Add(idn);
        cbb.SelectedIndex = 0;
      }
      DataTableReader dr = null;
      try
      {
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "0" }));
        while (dr.Read())
        {
          idn = new TIDAndName(dr["ShiftID"].ToString(), "[" + dr["ShiftID"].ToString() + "]" + 
            dr["ShiftName"].ToString());
          for (int i = 1; i <= 31; i++)
          {
            cbb = (ComboBox)this.groupBox1.Controls["cbb" + i.ToString().Trim()];
            cbb.Items.Add(idn);
          }
        }
        dr.Close();
        if (SysID != "")
        {
          int row = 0;
          txtShiftRuleID.Enabled = false;
          dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000205, new string[] { "3", SysID }));
          if (dr.Read())
          {
            txtShiftRuleID.Text = dr["ShiftRuleID"].ToString();
            txtShiftRuleName.Text = dr["ShiftRuleName"].ToString();
            cbbShiftRulecycName.SelectedIndex = int.Parse(dr["ShiftRulecycID"].ToString());
            txtShiftRulecyc.Text = dr["ShiftRulecyc"].ToString();
            dr.Close();
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000205, new string[] { "4", SysID }));
            while (dr.Read())
            {
              int.TryParse(dr["ShiftRulecycNo"].ToString(), out row);
              cbb = (ComboBox)this.groupBox1.Controls["cbb" + row.ToString().Trim()];
              for (int i = 0; i < cbb.Items.Count; i++)
              {
                if (((TIDAndName)cbb.Items[i]).id == dr["ShiftID"].ToString())
                {
                  cbb.SelectedIndex = i;
                  break;
                }
              }
            }
          }
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
    }

    private void cbbShiftRulecycName_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtShiftRulecyc.Enabled = cbbShiftRulecycName.SelectedIndex == 0;
      if (cbbShiftRulecycName.SelectedIndex == 0)
      {
        foreach (Control control in this.groupBox1.Controls)
          control.Visible = false;
        if (txtShiftRulecyc.Text.ToString() == "") txtShiftRulecyc.Text = "1";
        if (int.Parse(txtShiftRulecyc.Text) > 31) txtShiftRulecyc.Text = "1";
        for (int No = 1; No <= int.Parse(txtShiftRulecyc.Text.Trim()); No++)
        {
          ComboBox cbb = (ComboBox)this.groupBox1.Controls["cbb" + No.ToString()];
          Label lbl = (Label)this.groupBox1.Controls["lbl" + No.ToString()];
          lbl.Visible = true;
          cbb.Visible = true;
        }
      }
      else if (cbbShiftRulecycName.SelectedIndex == 1)
      {
        foreach (Control control in this.groupBox1.Controls)
          control.Visible = false;
        txtShiftRulecyc.Text = "7";
        label32.Visible = true;
        label33.Visible = true;
        label34.Visible = true;
        label35.Visible = true;
        label36.Visible = true;
        label37.Visible = true;
        label38.Visible = true;
        for (int No = 1; No <= 7; No++)
        {
          ComboBox cbb = (ComboBox)this.groupBox1.Controls["cbb" + No.ToString()];
          cbb.Visible = true;
        }
      }
      else if (cbbShiftRulecycName.SelectedIndex == 2)
      {
        foreach (Control control in this.groupBox1.Controls)
          control.Visible = false;
        txtShiftRulecyc.Text = "31";
        for (int No = 1; No <= 31; No++)
        {
          ComboBox cbb = (ComboBox)this.groupBox1.Controls["cbb" + No.ToString()];
          Label lbl = (Label)this.groupBox1.Controls["lbl" + No.ToString()];
          lbl.Visible = true;
          cbb.Visible = true;
        }
      }
    }

    private void txtShiftRulecyc_Leave(object sender, EventArgs e)
    {
      if (txtShiftRulecyc.Text == "")
      {
        txtShiftRulecyc.Focus();
        ShowErrorEnterCorrect(label42.Text);
        return;
      }
      if (int.Parse(txtShiftRulecyc.Text) <= 0)
      {
        txtShiftRulecyc.Focus();
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string ShiftRuleID = txtShiftRuleID.Text.Trim();
      string ShiftRuleName = txtShiftRuleName.Text.Trim();
      string ShiftRulecycName = cbbShiftRulecycName.Text.Trim();
      string ShiftRulecycID = cbbShiftRulecycName.SelectedIndex.ToString();
      string ShiftRulecyc = txtShiftRulecyc.Text.Trim();
      int days;
      if (ShiftRuleID == "")
      {
        txtShiftRuleID.Focus();
        ShowErrorEnterCorrect(label39.Text);
        return;
      }
      if (ShiftRuleName == "")
      {
        txtShiftRuleName.Focus();
        ShowErrorEnterCorrect(label40.Text);
        return;
      }
      DataTableReader dr = null;
      bool IsOk = true;
      List<string> sql = new List<string>();
      try
      {
        if (IsAdd)
        {
          dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000205, new string[] { "3", ShiftRuleID }));
          if (dr.Read())
          {
            txtShiftRuleID.Focus();
            ShowErrorCannotRepeated(label39.Text);
            IsOk = false;
          }
          dr.Close();
          if (IsOk)
          {
            sql.Add(Pub.GetSQL(DBCode.DB_000205, new string[] { "5", ShiftRuleID, ShiftRuleName, ShiftRulecycID, 
              ShiftRulecycName, ShiftRulecyc }));
          }
        }
        else
        {
          sql.Add(Pub.GetSQL(DBCode.DB_000205, new string[] { "6", ShiftRuleName, ShiftRulecycID, ShiftRulecycName, 
            ShiftRulecyc, SysID }));
          sql.Add(Pub.GetSQL(DBCode.DB_000205, new string[] { "7", SysID }));
        }
        if (cbbShiftRulecycName.SelectedIndex == 0)
          days = int.Parse(txtShiftRulecyc.Text.Trim());
        else if (cbbShiftRulecycName.SelectedIndex == 1)
          days = 7;
        else
          days = 31;
        for (int i = 1; i <= days; i++)
        {
          ComboBox cbb = (ComboBox)this.groupBox1.Controls["cbb" + i.ToString()];
          string ShiftID = ((TIDAndName)cbb.SelectedItem).id;
          sql.Add(Pub.GetSQL(DBCode.DB_000205, new string[] { "8", ShiftRuleID, i.ToString(), ShiftID }));
        }
      }
      catch (Exception E)
      {
        IsOk = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (!IsOk) return;
      if (SystemInfo.db.ExecSQL(sql) != 0) return;
      SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
      //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}