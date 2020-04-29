using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmSYRegister : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYRegister";
      base.InitForm();
      this.Text = Title;
      txtSerial.Text = RegisterInfo.Serial;
      txtUser.Text = RegisterInfo.RegUser;
      txtKey.Text = RegisterInfo.RegKey;
    }

    public frmSYRegister(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string RegUser = txtUser.Text.Trim();
      if (RegUser == "")
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
        txtUser.Focus();
        return;
      }
      string RegKey = txtKey.Text.Trim();
      try
      {
        if (!SystemInfo.db.IsRegister(false, RegUser, RegKey))
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg001", ""));
          return;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
        return;
      }
      Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg002", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}