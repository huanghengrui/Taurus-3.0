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
            FormsList.Name = "STAR";
            FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");

            SubAdd("MJStarOpenDoor", 1);
            SubAdd("MJStarParam", 0);
            SubAdd("MJStarNetParam", 0);
            SubAdd("MJStarPower", 0);
            SubAdd("MJStarRebootDevice", 0);
            
            return FormsList;
        }

        public Form GetForm(string frmName)
        {
            Form ret = null;
            switch (frmName)
            {
                case "MJStarParam":
                    ShowMJStarParam();
                    break;
                case "MJStarNetParam":
                    ShowMJStarNetParam();
                    break;
                case "MJStarPower":
                    ret = new frmMJStarPower();
                    break;
                case "MJStarOpenDoor":
                    ShowMJStarOpenDoor();
                    break;
                case "MJStarRebootDevice":
                    ShowMJStarRebootDevice();
                    break;
            }
            return ret;
        }

        private void ShowMJStarRebootDevice()
        {
            frmMJStarOprt frm = new frmMJStarOprt("", "", null, 20, null);
            frm.ShowDialog();
        }

        private void ShowMJStarOpenDoor()
        {
            frmMJStarOprt frm = new frmMJStarOprt("", "", null, 10, null);
            frm.ShowDialog();
        }
        private void ShowMJStarParam()
        {
            frmMJStarParam frm = new frmMJStarParam();
            frm.ShowDialog();
        }
        private void ShowMJStarNetParam()
        {
            frmMJStarNetParam frm = new frmMJStarNetParam();
            frm.ShowDialog();
        }
    }
}