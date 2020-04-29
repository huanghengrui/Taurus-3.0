using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public class ShowForms
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
            FormsList.Name = "KQ";
            FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
            if (SystemInfo.AllowInOutMode) SubAdd("KQInOutMode", 0);
            SubAdd("KQRuleSetup", 2);
            SubAdd("KQRule", 3);
            SubAdd("KQRuleCalc", 3);
            SubAdd("KQRuleEmp", 3);
            SubAdd("KQRuleDepart", 3);
            SubAdd("KQShiftSetup", 2);
            SubAdd("KQShift", 3);
            SubAdd("KQShiftRule", 3);
            SubAdd("KQEmpShift", 3);
            SubAdd("KQDepShift", 3);
            SubAdd("KQRegister", 2);
            SubAdd("KQHoliday", 3);
            SubAdd("KQEmpDayOff", 3);
            SubAdd("KQEmpOtSure", 3);
            SubAdd("KQEmpSignCard", 3);
            SubAdd("KQReport", 2);
            SubAdd("KQReportData", 3);
            SubAdd("KQReportRecords", 3);
            SubAdd("KQDataAssay", 4, true);
            SubAdd("KQReportDataFilter", 4);
            SubAdd("KQReportMonthDetail", 3);
            SubAdd("KQReportDay", 3); 
            SubAdd("KQReportMonth", 3);
            SubAdd("KQReportTotal", 3, true);
            SubAdd("KQReportWeek", 3);
            SubAdd("KQWeekReportTotal", 3, true);
            return FormsList;
        }

        public Form GetForm(string frmName)
        {
            Form ret = null;
            switch (frmName)
            {
                case "KQInOutMode":
                    ShowKQInOutMode();
                    break;
                case "KQRule":
                    ret = new frmKQRule();
                    //ShowKQRule();
                    break;
                case "KQRuleCalc":
                    ret = new frmKQRuleCalc();
                    //ShowKQRuleCalc();
                    break;
                case "KQRuleEmp":
                    ret = new frmKQRuleEmp();
                    //ShowKQRuleEmp();
                    break;
                case "KQRuleDepart":
                    ret = new frmKQRuleDepart();
                    //ShowKQRuleDepart();
                    break;
                case "KQShift":
                    ret = new frmKQShift();
                    // ShowKQShift();
                    break;
                case "KQShiftRule":
                    ret = new frmKQShiftRule();
                    //ShowKQShiftRule();
                    break;
                case "KQEmpShift":
                    ret = new frmKQEmpShift();
                    break;
                case "KQDepShift":
                    ret = new frmKQDepShift();
                    break;
                case "KQHoliday":
                    ret = new frmKQHoliday();
                    break;
                case "KQEmpDayOff":
                    ret = new frmKQEmpDayOff();
                    break;
                case "KQEmpOtSure":
                    ret = new frmKQEmpOtSure();
                    break;
                case "KQEmpSignCard":
                    ret = new frmKQEmpSignCard();
                    break;
                case "KQDataAssay":
                    ShowKQDataAssay();
                    break;
                case "KQReportData":
                    ret = new frmKQReportData();
                    break;
                case "KQReportDataFilter":
                    ret = new frmKQReportDataFilter();
                    break;
                case "KQReportMonthDetail":
                    ret = new frmKQReportMonthDetail();
                    break;
                case "KQReportRecords":
                    ret = new frmKQReportRecords();
                    break;
                case "KQReportDay":
                    ret = new frmKQReportDay();
                    break;
              
                case "KQReportMonth":
                    ret = new frmKQReportMonth();
                    break;
                case "KQReportTotal":
                    ret = new frmKQReportTotal();
                    break;
                case "KQReportWeek":
                    ret = new frmKQReportWeek();
                    break;
                case "KQWeekReportTotal":
                    ret = new frmKQWeekReportTotal();
                    break;
            }
            return ret;
        }
        private void ShowKQRule()
        {
            frmKQRule frm = new frmKQRule();
            frm.ShowDialog();
        }
        private void ShowKQRuleCalc()
        {
            frmKQRuleCalc frm = new frmKQRuleCalc();
            frm.ShowDialog();
        }
        private void ShowKQRuleEmp()
        {
            frmKQRuleEmp frm = new frmKQRuleEmp();
            frm.ShowDialog();
        }
        private void ShowKQRuleDepart()
        {
            frmKQRuleDepart frm = new frmKQRuleDepart();
            frm.ShowDialog();
        }
        private void ShowKQShift()
        {
            frmKQShift frm = new frmKQShift();
            frm.ShowDialog();
        }
        private void ShowKQShiftRule()
        {
            frmKQShiftRule frm = new frmKQShiftRule();
            frm.ShowDialog();
        }
        private void ShowKQInOutMode()
        {
            frmKQInOutMode frm = new frmKQInOutMode();
            frm.ShowDialog();
        }

        private void ShowKQDataAssay()
        {
            frmKQDataAssay frm = new frmKQDataAssay();
            frm.ShowDialog();
        }
    }
}