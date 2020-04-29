using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmDBConnect : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "DBConnect";
      base.InitForm();
      this.txtMSSQLServer.Text = SystemInfo.ini.ReadIni("MSSQL", "Server", "(local)");
      this.rbMSSQLWindowsNT.Checked = SystemInfo.ini.ReadIni("MSSQL", "WindowsNT", true);
      this.rbMSSQLSQL.Checked = !this.rbMSSQLWindowsNT.Checked;
      this.txtMSSQLUserName.Text = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserName", ""), SystemInfo.Encry);
      this.txtMSSQLUserPass.Text = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserPass", ""), SystemInfo.Encry);
      pnlMSSQL.Enabled = (SystemInfo.DBType == 1) || (SystemInfo.DBType == 2);
      pnlMSSQL.Visible = pnlMSSQL.Enabled;
      rbMSSQL_Click(null, null);
    }

    public frmDBConnect()
    {
      InitializeComponent();
      if ((SystemInfo.DBType != 1) && (SystemInfo.DBType != 2))
      {
        this.Width = 315;
        this.Height = 170;
      }
    }

    private void rbMSSQL_Click(object sender, EventArgs e)
    {
      lblMSSQLUserName.Enabled = rbMSSQLSQL.Checked;
      lblMSSQLUserPass.Enabled = lblMSSQLUserName.Enabled;
      txtMSSQLUserName.Enabled = lblMSSQLUserName.Enabled;
      txtMSSQLUserPass.Enabled = lblMSSQLUserName.Enabled;
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      TestLink(true);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (TestLink(false))
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private bool TestLink(bool IsTest)
    {
      bool ret = false;
      int DBType = SystemInfo.DBType;
      string ServerName = "";
      bool WindowsNT = true;
      string UserName = "";
      string UserPass = "";
      string ConnStr = "";
      switch (DBType)
      {
        case 1:
        case 2:
          ServerName = txtMSSQLServer.Text.Trim();
          WindowsNT = rbMSSQLWindowsNT.Checked;
          if (!WindowsNT)
          {
            UserName = txtMSSQLUserName.Text.Trim();
            UserPass = txtMSSQLUserPass.Text.Trim();
          }
          break;
      }
      ConnStr = Pub.GetMSSQLConnStr(ServerName, WindowsNT, UserName, UserPass, "master");
      try
      {
        SystemInfo.db.Open(DBType, ConnStr);
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        SystemInfo.db.Close();
      }
      if (ret)
      {
        if (!IsTest)
        {
          switch (DBType)
          {
            case 1:
              SystemInfo.ini.WriteIni("MSSQL", "Server", ServerName);
              SystemInfo.ini.WriteIni("MSSQL", "WindowsNT", WindowsNT);
              SystemInfo.ini.WriteIni("MSSQL", "UserName", Pub.GetAesEncrypt(UserName, SystemInfo.Encry));
              SystemInfo.ini.WriteIni("MSSQL", "UserPass", Pub.GetAesEncrypt(UserPass, SystemInfo.Encry));
              break;
            case 2:
              SystemInfo.ini.WriteIni("MSDE", "Server", ServerName);
              SystemInfo.ini.WriteIni("MSDE", "WindowsNT", WindowsNT);
              SystemInfo.ini.WriteIni("MSDE", "UserName", Pub.GetAesEncrypt(UserName, SystemInfo.Encry));
              SystemInfo.ini.WriteIni("MSDE", "UserPass", Pub.GetAesEncrypt(UserPass, SystemInfo.Encry));
              break;
          }
        }
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgTestDataLinkSuccess", ""), MessageBoxIcon.Information);
      }
      return ret;
    }
  }
}