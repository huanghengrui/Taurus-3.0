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
  public partial class frmRSDimissionAdd : frmBaseDialog
  {
    private string OtherCoin = "";

    protected override void InitForm()
    {
      formCode = "RSDimissionAdd";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      groupBox1.Enabled = SysID == "";
      txtEmpNo.Enabled = groupBox1.Enabled;
      btnSelectEmp.Enabled = groupBox1.Enabled;
      btnSelectEmp.Visible = btnSelectEmp.Enabled;
      txtEmpName.Enabled = groupBox1.Enabled;
      txtDepart.Enabled = groupBox1.Enabled;
      toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
      LoadData();
      OtherCoin = Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
    }

    public frmRSDimissionAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      try
      {
        if (SysID == "")
        {
          txtDimissionOprt.Text = OprtInfo.OprtNo;
          dtpDimissionDate.Value = DateTime.Now;
        }
        else
        {
          txtEmpNo.Enabled = false;
          btnSelectEmp.Enabled = false;
          dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000102, new string[] { "3", SysID }));
          if (dr.Read())
          {
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtDepart.Text = "[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString();
            dtpDimissionDate.Value = Convert.ToDateTime(dr["DimissionDate"]);
            txtDimissionOprt.Text = dr["DimissionOprt"].ToString();
            txtDimissionReason.Text = dr["DimissionReason"].ToString();
            dr.Close();
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

    private void btnSelectEmp_Click(object sender, EventArgs e)
    {
      frmPubSelectEmp frm = new frmPubSelectEmp(IgnoreDimission);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtEmpNo.Text = frm.EmpNo;
        txtEmpNo_Leave(null, null);
      }
    }

    private void GetSql(string EmpNo, string DimissionOprt, string DimissionReason, ref List<string> sql)
    {
      string tmp = "";
      string DimissionDate = dtpDimissionDate.Value.ToString(SystemInfo.SQLDateFMT);
      if (SysID == "")
      {
        tmp = Pub.GetSQL(DBCode.DB_000102, new string[] { "4", DimissionOprt, DimissionDate, DimissionReason, EmpNo });
      }
      else
      {
        tmp = Pub.GetSQL(DBCode.DB_000102, new string[] { "4", DimissionOprt, DimissionDate, DimissionReason, SysID });
      }
      sql.Add(tmp);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string EmpNo = txtEmpNo.Text.Trim();
      if (EmpNo == "" && cardGrid.DataSource == null)
      {
        txtEmpNo.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return;
      }
      string DimissionOprt = txtDimissionOprt.Text.Trim();
      if (DimissionOprt == "")
      {
        txtDimissionOprt.Focus();
        ShowErrorEnterCorrect(label4.Text);
        return;
      }
      string DimissionReason = txtDimissionReason.Text.Trim();
      if (DimissionReason == "")
      {
        txtDimissionReason.Focus();
        ShowErrorEnterCorrect(label8.Text);
        return;
      }
      if (!Pub.CheckTextMaxLength(label8.Text, DimissionReason, txtDimissionReason.MaxLength)) return;
      List<string> sql = new List<string>();
      DataTableReader dr = null;
      bool IsError = false;
      try
      {
        if (SysID == "")
        {
          GetSql(EmpNo, DimissionOprt, DimissionReason, ref sql);
          if (cardGrid.DataSource != null)
          {
            DataTable dtGrid = (DataTable)cardGrid.DataSource;
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
              if (dtGrid.Rows[i]["EmpNo"].ToString() == EmpNo) continue;
              GetSql(dtGrid.Rows[i]["EmpNo"].ToString(), DimissionOprt, DimissionReason, ref sql);
            }
          }
        }
        else
        {
          GetSql(EmpNo, DimissionOprt, DimissionReason, ref sql);
        }
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E, sql);
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

    private void txtEmpNo_Leave(object sender, EventArgs e)
    {
      txtEmpNo.Tag = "";
      txtEmpName.Text = "";
      txtDepart.Text = "";
      if (txtEmpNo.Text.Trim() != "")
      {
        string EmpName = "";
        string CardNo10 = "";
        string CardNo81 = "";
        string CardNo82 = "";
        string DepartID = "";
        string DepartName = "";
        if (SystemInfo.db.GetEmpInfoCard(txtEmpNo.Text.Trim(), ref EmpName, ref CardNo10, ref CardNo81,
          ref CardNo82, ref DepartID, ref DepartName, OtherCoin))
        {
          txtEmpName.Text = EmpName;
          txtDepart.Text = "[" + DepartID + "]" + DepartName;
        }
        else
        {
          txtEmpNo.Text = "";
          txtEmpName.Text = "";
          txtDepart.Text = "";
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
        }
      }
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      ((DataTable)cardGrid.DataSource).Clear();
      cardGrid.DataSource = null;
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
    }

    private bool CheckEmp()
    {
      if (txtEmpNo.Text.Trim() == "")
      {
        txtEmpNo.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return false;
      }
      string EmpName = "";
      string CardNo10 = "";
      string CardNo81 = "";
      string CardNo82 = "";
      string DepartID = "";
      string DepartName = "";
      if (!SystemInfo.db.GetEmpInfoCard(txtEmpNo.Text.Trim(), ref EmpName, ref CardNo10, ref CardNo81,
        ref CardNo82, ref DepartID, ref DepartName, OtherCoin))
      {
        txtEmpNo.Focus();
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
        return false;
      }
      return true;
    }

    private void cardGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      lblMsg.Text = string.Format(Pub.GetResText(formCode, "MsgSelectNo", ""), cardGrid.Rows.Count);
    }
  }
}