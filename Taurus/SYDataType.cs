using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmSYDataType : frmBaseDialog
    {


         protected override void InitForm()
         {
           formCode = "SYDataType";
           base.InitForm();
           this.Text = Title;
            if (SystemInfo.DBType == 0)
            {
                rbAccess.Checked = true;
            }
            else if (SystemInfo.DBType == 1 || SystemInfo.DBType == 2)
            {
                rbSql.Checked = true;
            }
         }

         public frmSYDataType(string title)
         {
             Title = title;
             InitializeComponent();
         }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbAccess.Checked)
            { 
                 SystemInfo.ini.WriteIni("Public", "DBType", 0);
            }   
            else if (rbSql.Checked)
            { 
                SystemInfo.ini.WriteIni("Public", "DBType", 1);   
            }
            if (!Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "lbRestart", "")))
            {
                 SystemInfo.Restart = 1;
                 Application.ExitThread();
                 System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                 SystemInfo.Restart = 0;
            }
        }
    }
}
