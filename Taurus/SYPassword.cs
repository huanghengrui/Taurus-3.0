using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmSYPassword : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYPassword";
      base.InitForm();
      this.Text = Title;
    }

    public frmSYPassword(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string OldPass = Pub.GetOprtEncrypt(txtOld.Text.Trim());
      string Pass = Pub.GetOprtEncrypt(txtNew.Text.Trim());
      string PassA = Pub.GetOprtEncrypt(txtNewA.Text.Trim());
      string PWD = Pub.GetOprtEncrypt("0");
      string OldPassA = "";
      DataTableReader dr = null;
      bool IsOk = false;
      try
      {
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "2", OprtInfo.OprtNo }));
        if (!dr.Read())
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOldPassword", ""));
        }
        else if (Pass != PassA)
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorPasswordTwo", ""));
        }
        else
        {
          OldPassA = dr["OprtPWD"].ToString();
          if (OldPass == OldPassA || PWD == OldPass)
          {
            SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "10", Pass, OprtInfo.OprtNo }));
            IsOk = true;
          }
          else
          {
            Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOldPassword", ""));
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
      if (IsOk)
      {
        string msg = Pub.GetResText(formCode, "MsgPasswordSuccess", "");
        SystemInfo.db.WriteSYLog(this.Text, btnOk.Text, msg);
        Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}