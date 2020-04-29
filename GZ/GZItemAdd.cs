using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmGZItemAdd : frmBaseDialog
  {
    private bool IsAdd = false;
    private Dictionary<string, TIDAndName> list = new Dictionary<string, TIDAndName>();
    protected override void InitForm()
    {
      formCode = "GZItemAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      IsAdd = SysID == "";
      SetTextboxNumber(txtGZItemID);
      initlb();
      if (SysID != "") LoadData();
    }

    public frmGZItemAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void initlb()
    {
      DataTableReader dr = null;
      try
      {
        TIDAndName item;
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000401, new string[] { "0", SysID }));
        while (dr.Read())
        {
          item = new TIDAndName(dr["RuleID"].ToString(), dr["RuleName"].ToString());
          if (dr["RuleMode"].ToString() == "1")
            lbGZItemIn.Items.Add(item);
          else 
            lbGZItemOut.Items.Add(item);
          list.Add(dr["RuleID"].ToString(), item);
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
      if (lbGZItemIn.Items.Count > 0) lbGZItemIn.SelectedIndex = 0;
      if (lbGZItemOut.Items.Count > 0) lbGZItemOut.SelectedIndex = 0;
    }

    private void add(ListBox lbFrom, ListBox lbTo)
    {
      TIDAndName item = (TIDAndName)lbFrom.SelectedItem;
      int i = lbFrom.SelectedIndex;
      if (item == null) return;
      lbFrom.Items.Remove(item);
      if (lbFrom.Items.Count > 0)
      {
        if (i == 0) i++;
        lbFrom.SelectedIndex = i - 1;
      }
      lbTo.Items.Add(item);
      lbTo.SelectedItem = item;
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      txtGZItemID.Enabled = false;
      try
      {
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000401, new string[] { "2", SysID }));
        if (dr.Read())
        {
          txtGZItemID.Text = dr["ItemID"].ToString();
          txtGZItemName.Text = dr["ItemName"].ToString();
          TIDAndName item;
          for (int i = 0; dr["ItemOut" + i].ToString() != ""; i++)
          {
            if (list.TryGetValue(dr["ItemOut" + i].ToString(), out item))
            {
              lbGZItemOut.SelectedItem = item;
              add(lbGZItemOut, lbGZItem2);
            }
          }
          for (int i = 0; dr["ItemIn" + i].ToString() != ""; i++)
          {
            if (list.TryGetValue(dr["ItemIn" + i].ToString(), out item))
            {
              lbGZItemIn.SelectedItem = item;
              add(lbGZItemIn, lbGZItem1);
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

    private void btnOk_Click(object sender, EventArgs e)
    {
      string ItemId = txtGZItemID.Text.Trim();
      string ItemName = txtGZItemName.Text.Trim();
      if (ItemId == "")
      {
        txtGZItemID.Focus();
        ShowErrorEnterCorrect(lblGZItemID.Text);
        return;
      }
      if (ItemName == "")
      {
        txtGZItemName.Focus();
        ShowErrorEnterCorrect(lblGZItemName.Text);
        return;
      }
      string[] RuleIn = new string[20];
      string[] RuleOut = new string[20];
      for (int i = 0; i < 20; i++)
      {
        if (i < lbGZItem1.Items.Count) RuleIn[i] = ((TIDAndName)lbGZItem1.Items[i]).id;
        else RuleIn[i] = "NULL";
        if (i < lbGZItem2.Items.Count) RuleOut[i] = ((TIDAndName)lbGZItem2.Items[i]).id;
        else RuleOut[i] = "NULL";
      }
      DataTableReader dr = null;
      bool IsOk = true;
      string sql = "";
      try
      {
        if (IsAdd)
        {
          dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000401, new string[] { "2", ItemId }));
          if (dr.Read())
          {
            txtGZItemID.Focus();
            ShowErrorCannotRepeated(lblGZItemID.Text);
            IsOk = false;
          }
          dr.Close();
          if (IsOk)
          {
            sql = Pub.GetSQL(DBCode.DB_000401, new string[] { "3", ItemId, ItemName, RuleIn[0], RuleIn[1], 
              RuleIn[2], RuleIn[3], RuleIn[4], RuleIn[5], RuleIn[6], RuleIn[7], RuleIn[8], RuleIn[9], RuleIn[10], 
              RuleIn[11], RuleIn[12], RuleIn[13], RuleIn[14], RuleIn[15], RuleIn[16], RuleIn[17], RuleIn[18], 
              RuleIn[19], RuleOut[0], RuleOut[1], RuleOut[2], RuleOut[3], RuleOut[4], RuleOut[5], RuleOut[6], 
              RuleOut[7], RuleOut[8], RuleOut[9], RuleOut[10], RuleOut[11], RuleOut[12], RuleOut[13], RuleOut[14], 
              RuleOut[15], RuleOut[16], RuleOut[17], RuleOut[18], RuleOut[19]});
          }
        }
        else
        {
          sql = Pub.GetSQL(DBCode.DB_000401, new string[] { "4", ItemName, RuleIn[0], RuleIn[1], RuleIn[2], 
            RuleIn[3], RuleIn[4], RuleIn[5], RuleIn[6], RuleIn[7], RuleIn[8], RuleIn[9], RuleIn[10], RuleIn[11], 
            RuleIn[12], RuleIn[13], RuleIn[14], RuleIn[15], RuleIn[16], RuleIn[17], RuleIn[18], RuleIn[19],
            RuleOut[0], RuleOut[1], RuleOut[2], RuleOut[3], RuleOut[4], RuleOut[5], RuleOut[6], RuleOut[7], 
            RuleOut[8], RuleOut[9], RuleOut[10], RuleOut[11], RuleOut[12], RuleOut[13], RuleOut[14], RuleOut[15], 
            RuleOut[16], RuleOut[17], RuleOut[18], RuleOut[19], ItemId });
        }
        if (IsOk) SystemInfo.db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        IsOk = false;
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsOk)
      {
        SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
        //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void btAdd_Click(object sender, EventArgs e)
    {
      if (lbGZItem1.Items.Count >= 20) return;
      add(lbGZItemIn, lbGZItem1);
    }

    private void btDel_Click(object sender, EventArgs e)
    {
      add(lbGZItem1, lbGZItemIn);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (lbGZItem2.Items.Count >= 20) return;
      add(lbGZItemOut, lbGZItem2);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      add(lbGZItem2, lbGZItemOut);
    }

    private void lbGZItemIn_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (lbGZItem1.Items.Count >= 20) return;
      add(lbGZItemIn, lbGZItem1);
    }

    private void lbGZItemOut_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (lbGZItem2.Items.Count >= 20) return;
      add(lbGZItemOut, lbGZItem2);
    }

    private void lbGZItem1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      add(lbGZItem1, lbGZItemIn);
    }

    private void lbGZItem2_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      add(lbGZItem2, lbGZItemOut);
    }

    private void btUp1_Click(object sender, EventArgs e)
    {
      ListBox lb;
      if (((ButtonX)sender).Name.ToString().EndsWith("1")) lb = lbGZItem1;
      else lb = lbGZItem2;
      if (lb.SelectedIndex > 0)
      {
        object selstr = lb.Items[lb.SelectedIndex - 1];
        lb.Items[lb.SelectedIndex - 1] = lb.SelectedItem;
        lb.Items[lb.SelectedIndex] = selstr;
        lb.SelectedItem = lb.Items[lb.SelectedIndex - 1];
      }
    }

    private void btDown1_Click(object sender, EventArgs e)
    {
      ListBox lb;
      if (((ButtonX)sender).Name.ToString().EndsWith("1")) lb = lbGZItem1;
      else lb = lbGZItem2;
      if (lb.SelectedIndex < lb.Items.Count - 1 && lb.SelectedIndex >= 0)
      {
        object selstr = lb.Items[lb.SelectedIndex + 1];
        lb.Items[lb.SelectedIndex + 1] = lb.SelectedItem;
        lb.Items[lb.SelectedIndex] = selstr;
        lb.SelectedItem = lb.Items[lb.SelectedIndex + 1];
      }
    }
  }
}