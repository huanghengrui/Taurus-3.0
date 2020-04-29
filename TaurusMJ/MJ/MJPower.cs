using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace Taurus
{
    public partial class frmMJPower : frmBaseMDIChildReportTree
    {
        protected override void InitForm()
        {
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            formCode = "MJPower";
            ReportFile = "PowerSetup";
            ReportStartIndex = 3;
            IsInitBaseForm = true;
            base.InitForm();
            ItemFindText.ToolTipText = string.Format(Pub.GetResText(formCode, "MsgFindMacSN", ""),
              Pub.GetResText(formCode, "MacSN", ""),
              Pub.GetResText(formCode, "MacDesc", ""));
            ExecTreeAfterSelect(tvEmp.SelectedNode);
        }
      
        public frmMJPower()
        {
            InitializeComponent();
        }
        protected override void ExecItemFindText()
        {
            ExecTreeAfterSelect();
            ItemFindText.Focus();
        }
        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmMJPowerAdd frm = new frmMJPowerAdd(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmMJPowerEdit frm = new frmMJPowerEdit(this.Text, CurrentTool, Report.FieldByName("GUID").AsString);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            new frmMJOprt(this.Text, CurrentTool, 20, null).ShowDialog();
            ExecItemRefresh();
        }

        protected override void ExecItemTAG2()
        {
            List<string> GUID = new List<string>();
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiChecked)
                {
                    GUID.Add(Report.FieldByName("GUID").AsString);
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (GUID.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            base.ExecItemTAG2();
            new frmMJOprt(this.Text, CurrentTool, 21, GUID).ShowDialog();
        }

        protected override void ExecTreeAfterSelect()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "600", nodeDepartID, nodeDepartList, ItemFindText.Text.Trim() });
            base.ExecTreeAfterSelect();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_000300, new string[] { "502", Report.FieldByName("MacSN").AsString,
        Report.FieldByName("EmpNo").AsString  });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = "[" + Report.FieldByName("EmpNo").AsString + "]" + Report.FieldByName("EmpName").AsString +
              " [" + Report.FieldByName("MacSN").AsString + "]";
            return ret;
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemTAG1.Enabled = State;
        }
    }
}