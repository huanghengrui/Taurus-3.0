using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Taurus
{
  public partial class frmGZRuleEmpAdd : frmBaseDialog
  {

    protected override void InitForm()
    {
      formCode = "GZRuleEmpAdd";
      CreateCardGridView(cardGrid);
      cardGrid.Columns[1].Visible = false;
      IgnoreDimission = false;
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
      groupBox1.Enabled = SysID == "";
      txtEmpNo.Enabled = groupBox1.Enabled;
      btnSelectEmp.Enabled = groupBox1.Enabled;
      btnSelectEmp.Visible = groupBox1.Enabled;
      txtEmpName.Enabled = false;
      txtDepartName.Enabled = false;
      LoadData();
      KeyPreview = true;
    }

    public frmGZRuleEmpAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void btnSelectEmp_Click(object sender, EventArgs e)
    {
      frmPubSelectEmp frm = new frmPubSelectEmp(IgnoreDimission);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtEmpNo.Text = frm.EmpNo;
        txtEmpName.Text = frm.EmpName;
        txtDepartName.Text = frm.DepartName;
      }
    }

    private void LoadData()
    {
      TIDAndName idn = new TIDAndName("", "");
      cbbRule.Items.Clear();
      DataTableReader dr = null;
      try
      {
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000401, new string[] { "1" }));
        while (dr.Read())
        {
          idn = new TIDAndName(dr["ItemID"].ToString(), "[" + dr["ItemID"].ToString() + "]" +
            dr["ItemName"].ToString());
          cbbRule.Items.Add(idn);
        }
        if (cbbRule.Items.Count > 0) cbbRule.SelectedIndex = 0;
        dr.Close();
        if (SysID != "")
        {
          dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "12", SysID }));
          if (dr.Read())
          {
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtEmpNo.Enabled = false;
            btnSelectEmp.Enabled = false;
            txtDepartName.Text = dr["DepartName"].ToString();
            txtDepartName.Tag = dr["EmpNo"].ToString();
            for (int i = 0; i < cbbRule.Items.Count; i++)
            {
              if (((TIDAndName)cbbRule.Items[i]).id == dr["EmpGZRuleID"].ToString())
              {
                cbbRule.SelectedIndex = i;
                break;
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

    private void txtEmpNo_Leave(object sender, EventArgs e)
    {
      txtEmpNo.Tag = "";
      txtEmpName.Text = "";
      txtDepartName.Text = "";
      if (txtEmpNo.Text.Trim() != "")
      {
        string EmpName = "";
        string CardNo10 = "";
        string CardNo81 = "";
        string CardNo82 = "";
        string DepartID = "";
        string DepartName = "";
        if (SystemInfo.db.GetEmpInfoCard(txtEmpNo.Text.Trim(), ref EmpName, ref CardNo10, ref CardNo81,
          ref CardNo82, ref DepartID, ref DepartName))
        {
          txtEmpName.Text = EmpName;
          txtDepartName.Text = "[" + DepartID + "]" + DepartName;
        }
        else
        {
          txtEmpNo.Text = "";
          txtEmpName.Text = "";
          txtDepartName.Text = "";
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
        }
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      ((DataTable)cardGrid.DataSource).Clear();
      cardGrid.DataSource = null;
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (txtEmpNo.Text.Trim() == "" && cardGrid.DataSource == null)
      {
        txtEmpNo.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return;
      }
      if (cbbRule.SelectedIndex == -1)
      {
        cbbRule.Focus();
        ShowErrorSelectCorrect(label3.Text);
        return;
      }
      string EmpSysID = txtEmpNo.Text;
      string RuleSysID = ((TIDAndName)cbbRule.Items[cbbRule.SelectedIndex]).id;
      List<string> sql = new List<string>();
      DataTableReader dr = null;
      bool IsError = false;
      try
      {
        if (SysID == "")
        {
          sql.Add(Pub.GetSQL(DBCode.DB_000402, new string[] { "2", RuleSysID, EmpSysID }));
          if (cardGrid.DataSource != null)
          {
            DataTable dtGrid = (DataTable)cardGrid.DataSource;
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
              if (dtGrid.Rows[i]["EmpNo"].ToString() == EmpSysID) continue;
              sql.Add(Pub.GetSQL(DBCode.DB_000402, new string[] { "2", RuleSysID, dtGrid.Rows[i]["EmpNo"].ToString() }));
            }
          }
        }
        else
        {
          sql.Add(Pub.GetSQL(DBCode.DB_000402, new string[] { "2", RuleSysID, EmpSysID }));
        }
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsError) return;
      if (SystemInfo.db.ExecSQL(sql) != 0) return;
      SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
      //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void cardGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      lblMsg.Text = string.Format(Pub.GetResText(formCode, "MsgSelectNo", ""), cardGrid.Rows.Count);
    }
  }
}