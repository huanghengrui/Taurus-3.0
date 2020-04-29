using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmException : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "Exception";
      base.InitForm();
      Label1.Text = SystemInfo.AppTitle + " " + SystemInfo.AppVersion;
    }

    public frmException()
    {
      InitializeComponent();
    }

    public void InitErrorMessage(string ErrorMessage)
    {
      txtMsg.Text = ErrorMessage;
    }
  }
}