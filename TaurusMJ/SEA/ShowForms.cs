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
            FormsList.Name = "SEA";
            FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");

            SubAdd("MJDoorSeaSeries", 0);
            SubAdd("MJDoorCondition", 0);
            SubAdd("MJRealTimeMonitoringSettings", 0);
            SubAdd("MJSeaUserPwd", 0);
            SubAdd("MJSeaNetParam", 0);
            SubAdd("MJSeaSetSound", 0);
            SubAdd("MJSeaRebootDevice", 0);
            SubAdd("MJSeaTemperature", 0);
            SubAdd("MJSeaPower", 1, true);
            SubAdd("MJReportSeaSnapShots", 1, true);
            return FormsList;
        }

        public Form GetForm(string frmName)
        {
            Form ret = null;
            switch (frmName)
            {
                case "MJRealTimeMonitoringSettings":
                    ShowMJRealTimeMonitoringSettings();
                    break;
                case "MJDoorCondition":
                    ShowMJDoorCondition();
                    break;
                case "MJDoorSeaSeries":
                    ShowMJSeaSeriesOprt();
                    break;
                case "MJSeaUserPwd":
                    ShowMJSeaUserPwd();
                    break;
                case "MJSeaNetParam":
                    ShowMJSeaNetParam();
                    break;
                case "MJSeaSetSound":
                    ShowMJSeaSetSound();
                    break;
                case "MJSeaRebootDevice":
                    ShowMJSeaRebootDevice();
                    break;
                case "MJSeaTemperature":
                    ShowMJSeaTemperature();
                    break;
                case "MJSeaPower":
                    ret = new frmMJSeaPower();
                    break;
                case "MJReportSeaSnapShots":
                    ret = new frmMJReportSeaSnapShots();
                    break;
             
            }
            return ret;
        }
        private void ShowMJSeaTemperature()
        {
            frmMJSeaTemperature frm = new frmMJSeaTemperature();
            frm.ShowDialog();
        }
        private void ShowMJDoorCondition()
        {
            frmMJDoorCondition frm = new frmMJDoorCondition();
            frm.ShowDialog();
        }
        private void ShowMJRealTimeMonitoringSettings()
        {
            frmMJRealTimeMonitoringSettings frm = new frmMJRealTimeMonitoringSettings();
            frm.ShowDialog();
        }
        private void ShowMJSeaSeriesOprt()
        {
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt("","","",0,null);
            frm.ShowDialog();
        }

        private void ShowMJSeaRebootDevice()
        {
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt("", "", "", 11, null);
            frm.ShowDialog();
        }

        private void ShowMJSeaUserPwd()
        {
            frmMJSeaUserPwd frm = new frmMJSeaUserPwd();
            frm.ShowDialog();
        }
        private void ShowMJSeaNetParam()
        {
            frmMJSeaNetParam frm = new frmMJSeaNetParam();
            frm.ShowDialog();
        }
        private void ShowMJSeaSetSound()
        {
            frmMJSeaSetSound frm = new frmMJSeaSetSound();
            frm.ShowDialog();
        }
    }
}