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
  public partial class frmKQInOutMode : frmBaseDialog
  {

    protected override void InitForm()
    {
      formCode = "KQInOutMode";
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      LoadData();
    }

    public frmKQInOutMode()
    {
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TextBox txt;
      try
      {
        for (int i = 1; i <= 10; i++)
        {
          dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000400, new string[] { "100", i.ToString() }));
          if (dr.Read())
          {
            txt = (TextBox)Controls["textBox" + i];
            if (txt != null) txt.Text = dr["InOutModeName"].ToString();
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
      DataTableReader dr = null;
      TextBox txt;
      List<string> sql = new List<string>();
      bool IsError = false;
      try
      {
        for (int i = 1; i <= 10; i++)
        {
          txt = (TextBox)Controls["textBox" + i];
          if (txt==null)continue;
          dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000400, new string[] { "100", i.ToString() }));
          if (dr.Read())
            sql.Add(Pub.GetSQL(DBCode.DB_000400, new string[] { "102", i.ToString(), txt.Text.Trim() }));
          else
            sql.Add(Pub.GetSQL(DBCode.DB_000400, new string[] { "101", i.ToString(), txt.Text.Trim() }));
          dr.Close();
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
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}