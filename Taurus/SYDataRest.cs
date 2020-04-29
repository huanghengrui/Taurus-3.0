using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmSYDataRest : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYDataRest";
      base.InitForm();
      this.Text = Title;
    }

    public frmSYDataRest(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void btnDBPath_Click(object sender, EventArgs e)
    {
      string BakFile = txtBak.Text;
      if (BakFile == "") BakFile = SystemInfo.db.GetDatabasePath().ToString() + SystemInfo.NameSpace + ".bak";
      BakFile = Pub.SelectDBPath(false, BakFile);
      if (BakFile != "") txtBak.Text = BakFile;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string FileName = txtBak.Text;
      string msg = Pub.GetResText(formCode, "Msg001", "");
      bool IsOk = false;

      if (FileName == "")
      {
        btnDBPath.Focus();
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorDBFileEmpty", ""));
        return;
      }
      Pub.ShowMessageForm(msg);
      try
      {
        IsOk = SystemInfo.db.RestoreDatabase(FileName);
        SystemInfo.db.Close();
        if (IsOk)
        {
          string fn = FileName.Substring(FileName.LastIndexOf("\\") + 1).ToLower();
          try
          {
            SystemInfo.db.Open(SystemInfo.ConnStr);
          }
          catch (Exception E)
          {
            IsOk = false;
            Pub.ShowErrorMsg(E);
          }
        }
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
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg002", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}