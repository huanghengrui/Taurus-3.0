using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AxgrproLib;
using grproLib;

namespace Taurus
{
    public partial class frmRSDimission : frmBaseMDIChildReportTree
    {
        protected override void InitForm()
        {
            formCode = "RSDimission";
            ReportFile = "RSDimission";
            ReportStartIndex = 2;
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemTAG1", true);
            //SetToolItemState("ItemLine5", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            IsInitBaseForm = true;
            base.InitForm();
            FindSQL = Pub.GetSQL(DBCode.DB_000102, new string[] { "0", SystemInfo.FingerPrivilegeGeneralUser,
        SystemInfo.FingerPrivilegeManager });
            FindOrderBy = Pub.GetSQL(DBCode.DB_000102, new string[] { "1" });
            FindKeyWord = formCode;
            ExecTreeAfterSelect(tvEmp.SelectedNode);
        }

        public frmRSDimission()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmRSDimissionAdd frm = new frmRSDimissionAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmRSDimissionAdd frm = new frmRSDimissionAdd(this.Text, CurrentTool, GetEmpNo());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            string msg = "";
            string EmpNo = "";
            List<string> sql = new List<string>();
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiChecked)
                {
                    EmpNo = GetEmpNo();
                    sql.Add(Pub.GetSQL(DBCode.DB_000102, new string[] { "2", EmpNo }));
                    msg = msg + GetDelMsg(0) + ";";
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (sql.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg001", ""));
                return;
            }
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg002", ""))) return;
            if (SystemInfo.db.ExecSQL(sql) != 0) return;
            SystemInfo.db.WriteSYLog(this.Text, CurrentTool, msg);
            ExecItemRefresh();
            Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg003", ""), MessageBoxIcon.Information);
        }

        protected override void ExecItemFindText()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000102, new string[] { "5", FindSQL, FindOrderBy, ItemFindText.Text.Trim() });
            ExecItemRefresh();
        }

        private string GetEmpNo()
        {
            return Report.FieldByName("EmpNo").AsString;
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string EmpNo = GetEmpNo();
            if (SystemInfo.DBType == 0)
                sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "8", EmpNo }));
            sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "9", EmpNo }));
            if (SystemInfo.DBType == 0)
            {
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "506", EmpNo }));
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "516", EmpNo }));
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "556", EmpNo }));
                sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "33", EmpNo }));
            }
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = Pub.GetResText(formCode, "EmpNo", "") + "=" + Report.FieldByName("EmpNo").AsString + "," +
              Pub.GetResText(formCode, "EmpName", "") + "=" + Report.FieldByName("EmpName").AsString;
            return ret;
        }

        protected override void ExecTreeAfterSelect()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000102, new string[] { "6", FindSQL, FindOrderBy, nodeDepartID, nodeDepartList });
            base.ExecTreeAfterSelect();
        }
    }
}