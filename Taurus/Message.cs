using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmMessage : frmBaseForm
  {
    public string MsgText = "";
    public string MsgFlag = "";

    public frmMessage()
    {
      InitializeComponent();
    }

    private void frmMessage_Shown(object sender, EventArgs e)
    {
      bool IsOk = false;

      this.label1.Text = MsgText;
      Application.DoEvents();
      switch (MsgFlag)
      {
        case "CompactDB":
          IsOk = SystemInfo.db.CompactDatabase();
          break;
        default:
          return;
      }
      if (IsOk)
        this.DialogResult = DialogResult.OK;
      else
        this.DialogResult = DialogResult.None;
      this.Close();
    }
  }
}

