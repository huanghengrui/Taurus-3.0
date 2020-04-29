using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmKQShiftRule : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "KQShiftRule";
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "ShiftRuleID", false, true, 0);
            AddColumn(0, "ShiftRuleName", false, false, 0);
            AddColumn(0, "ShiftRulecycName", false, false, 0);
            AddColumn(0, "ShiftRulecyc", false, false, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
           // SetToolItemState("ItemLine1", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmKQShiftRule()
        {
            InitializeComponent();
        }
        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            SelectData(e.CheckedState);
        }
        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000205, new string[] { "0" });
            base.ExecItemRefresh();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQShiftRuleAdd frm = new frmKQShiftRuleAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmKQShiftRuleAdd frm = new frmKQShiftRuleAdd(this.Text, CurrentTool, GetShiftRuleID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        private string GetShiftRuleID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["ShiftRuleID"].ToString();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            sql.Add(Pub.GetSQL(DBCode.DB_000205, new string[] { "1", dataGrid[1, rowIndex].Value.ToString() }));
            sql.Add(Pub.GetSQL(DBCode.DB_000205, new string[] { "2", dataGrid[1, rowIndex].Value.ToString() }));
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }
    }
}