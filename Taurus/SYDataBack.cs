using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmSYDataBack : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYDataBack";
      base.InitForm();
      this.Text = Title;
      this.txtBak.Text = SystemInfo.NameSpace + DateTime.Now.ToString(SystemInfo.DateTimeFormatLog);
      txtPath.Text = SystemInfo.db.GetDatabasePath().ToString();
    }

    public frmSYDataBack(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void btnDBPath_Click(object sender, EventArgs e)
    {
      string DBPath = txtPath.Text;
      DBPath = Pub.SelectDBPath(true, DBPath);
      if (DBPath != "") txtPath.Text = DBPath;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string FileName = txtBak.Text.Trim();
      string DBPath = txtPath.Text;
      string msg = Pub.GetResText(formCode, "Msg001", "");
      bool IsOk = false;
      string[] s = FileName.Split('.');

      if (FileName == "")
      {
        txtBak.Focus();
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorDBFileEmpty", ""));
        return;
      }
      if (DBPath == "")
      {
        btnDBPath.Focus();
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorDBPathEmpty", ""));
        return;
      }
      string fileExt = ".bak";
      if (SystemInfo.DBType == 0) fileExt = ".mdb";
      if (s.Length == 1)
        FileName = FileName + fileExt;
      else if (s[s.Length - 1].Trim() == "")
      {
        FileName = "";
        for (int i = 0; i < s.Length; i++)
        {
          if (s[i].Trim() != "") FileName = FileName + s[i].Trim() + ".";
        }
        FileName = FileName.Substring(0, FileName.Length - 1);
      }
      s = FileName.Split('.');
      if (s.Length == 1) FileName = FileName + fileExt;
      FileName = DBPath + FileName;
      Pub.ShowMessageForm(msg);
      try
      {
        IsOk = SystemInfo.db.BackupDatabase(FileName);
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
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg002", ""), "\r\n" + FileName), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}