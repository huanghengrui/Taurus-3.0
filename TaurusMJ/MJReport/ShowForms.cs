using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    class ShowForms
    {
        private const string formCode = "Main";
        private FuncObject FormsList = new FuncObject();

        private void SubAdd(string Name, byte IsLine, bool IsTool)
        {
            FormsList.SubAdd(Name, SystemInfo.res.GetResText(formCode, "mnu" + Name, ""), IsLine, IsTool);
        }

        private void SubAdd(string Name, byte IsLine)
        {
            SubAdd(Name, IsLine, false);
        }

        public FuncObject GetFormsList()
        {
            FormsList.Name = "MJReport";
            FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");

            SubAdd("MJReportMJData", 1);
            SubAdd("MJReportOpenData", 0);
            SubAdd("MJReportAlarmData", 0);
            SubAdd("MJSeaPersonIDCard", 0);

            return FormsList;
        }

        public Form GetForm(string frmName)
        {
            Form ret = null;
            switch (frmName)
            {
                case "MJReportMJData":
                    ret = new frmMJReportMJData();
                    break;
                case "MJReportOpenData":
                    ret = new frmMJReportOpenData();
                    break;
                case "MJReportAlarmData":
                    ret = new frmMJReportAlarmData();
                    break;
                case "MJSeaPersonIDCard":
                    ret = new frmMJSeaPersonIDCard();
                    break;
            }
            return ret;
        }
    }
}