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
  public partial class frmKQHolidayAdd : frmBaseDialog
  {

    protected override void InitForm()
    {
      formCode = "KQHolidayAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
      KeyPreview = true;
    }

    public frmKQHolidayAdd(string title, string CurrentTool, string GUID)
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
        if (SysID != "")
        {
          dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000209, new string[] { "2", SysID }));
          if (dr.Read())
          {
            txtHolidayName.Text = dr["HolidayName"].ToString();
            txtBeginTime.Value = Convert.ToDateTime(dr["HolidayBeginTime"].ToString());
            txtEndTime.Value = Convert.ToDateTime(dr["HolidayEndTime"].ToString());
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

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (txtHolidayName.Text.Trim() == "")
      {
        txtHolidayName.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (txtBeginTime.Value > txtEndTime.Value)
      {
        txtBeginTime.Focus();
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorStartDateBegreater", ""));
        return;
      }
      string HolidayName = txtHolidayName.Text.Trim();
      string sql = "";
      DataTableReader dr = null;
      bool IsError = false;
      try
      {
        if (SysID == "")
        {
          sql = Pub.GetSQL(DBCode.DB_000209, new string[] { "3", HolidayName, 
            txtBeginTime.Value.ToString(SystemInfo.SQLDateFMT), txtEndTime.Value.ToString(SystemInfo.SQLDateFMT) });
        }
        else
        {
          sql = Pub.GetSQL(DBCode.DB_000209, new string[] { "4", HolidayName, 
            txtBeginTime.Value.ToString(SystemInfo.SQLDateFMT), txtEndTime.Value.ToString(SystemInfo.SQLDateFMT), SysID });
        }
        SystemInfo.db.ExecSQL(sql);
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
      SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
      //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}