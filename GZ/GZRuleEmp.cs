using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Taurus
{
    public partial class frmGZRuleEmp : frmBaseMDIChildGrid
    {

        protected override void InitForm()
        {
            formCode = "GZRuleEmp";
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "EmpNo", false, true, 0);
            AddColumn(0, "EmpName", false, false, 0);
            AddColumn(0, "DepartName", false, false, 0);
            AddColumn(0, "RuleIDName", false, false, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            //SetToolItemState("ItemLine1", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmGZRuleEmp()
        {
            InitializeComponent();
        }
        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            SelectData(e.CheckedState);
        }
        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmGZRuleEmpAdd frm = new frmGZRuleEmpAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmGZRuleEmpAdd frm = new frmGZRuleEmpAdd(this.Text, CurrentTool, GetEmpNo());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        private string GetEmpNo()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["EmpNo"].ToString();
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000402, new string[] { "0" });
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_000402, new string[] { "1", dataGrid[1, rowIndex].Value.ToString() });
            sql.Add(ret);
        }
    }
}