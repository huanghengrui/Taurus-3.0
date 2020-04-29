using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmSYDataUpdate : frmBaseDialog
  {
    private bool UpdateIsOk = false;

    protected override void InitForm()
    {
      formCode = "SYDataUpdate";
      base.InitForm();
      this.Text = Title;
      UpdateIsOk = false;
    }

    public frmSYDataUpdate(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void btnDBPath_Click(object sender, EventArgs e)
    {
      ofd.Filter = Pub.GetResText(formCode, "Msg001", "") + "|*.sql";
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        txtBak.Text = ofd.FileName;
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string FileName = txtBak.Text;
      string msg = Pub.GetResText(formCode, "Msg002", "");
      bool IsOk = false;
      if (FileName == "")
      {
        btnDBPath.Focus();
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      Pub.ShowMessageForm(msg);
      try
      {
        IsOk = SystemInfo.db.UpdateScript(FileName);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        Pub.FreeMessageForm();
      }
      if (IsOk)
      {
        UpdateIsOk = true;
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg003", ""), MessageBoxIcon.Information);
      }
    }

    private void frmDBUpdate_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (UpdateIsOk) this.DialogResult = DialogResult.OK;
    }
  }
}