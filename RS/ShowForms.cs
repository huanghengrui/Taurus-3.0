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
            FormsList.Name = "RS";
            FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
            SubAdd("RSDepart", 0, true);
            SubAdd("RSEmp", 0, true);
            SubAdd("RSDimission", 0);
            SubAdd("RSEmpChart", 1);
            return FormsList;
        }

        public Form GetForm(string frmName)
        {
            Form ret = null;
            switch (frmName)
            {
                case "RSDepart":
                    // ShowRSDepart();
                    ret = new frmRSDepart();
                    break;
                case "RSEmp":
                    ret = new frmRSEmp();
                    break;
                case "RSDimission":
                    ret = new frmRSDimission();
                    break;
                case "RSEmpChart":
                    ret = new frmRSEmpChart();
                    break;
            }
            return ret;
        }

        private void ShowRSDepart()
        {
            frmRSDepart frm = new frmRSDepart();
            frm.ShowDialog();
        }
    }
}