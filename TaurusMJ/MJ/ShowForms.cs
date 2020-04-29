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
            FormsList.Name = "MJ";
            FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");

            SubAdd("MJDoor", 1);
            SubAdd("MJMacParam", 0);
            SubAdd("MJTime", 0, true);
            SubAdd("MJBellTime", 0);
            SubAdd("MJPower", 0, true);

            return FormsList;
        }

        public Form GetForm(string frmName)
        {
            Form ret = null;
            switch (frmName)
            {
                case "MJTime":
                    ret = new frmMJTime();
                    break;
                case "MJMacParam":
                    ShowPubMacParam();
                    break;
                case "MJBellTime":
                    ShowMJBellTime();
                    break;
                case "MJPower":
                    ret = new frmMJPower();
                    break;
                case "MJDoor":
                    ShowMJDoor();
                    break;
            }
            return ret;
        }

        private void ShowPubMacParam()
        {
            frmMJMacParam frm = new frmMJMacParam();
            frm.ShowDialog();
        }

        private void ShowMJBellTime()
        {
            frmMJBellTime frm = new frmMJBellTime();
            frm.ShowDialog();
        }

        private void ShowMJDoor()
        {
            frmMJDoor frm = new frmMJDoor();
            frm.ShowDialog();
        }
    }
}