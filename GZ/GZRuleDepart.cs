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
    public partial class frmGZRuleDepart : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "GZRuleDepart";
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "DepartID", false, true, 0);
            AddColumn(0, "DepartName", false, true, 0);
            AddColumn(0, "RuleIDName", false, true, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            //SetToolItemState("ItemLine1", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmGZRuleDepart()
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
            frmGZRuleDepartAdd frm = new frmGZRuleDepartAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmGZRuleDepartAdd frm = new frmGZRuleDepartAdd(this.Text, CurrentTool, GetDepartID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        private string GetDepartID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["DepartID"].ToString();
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000403, new string[] { "0" });
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_000403, new string[] { "1", dataGrid[1, rowIndex].Value.ToString() });
            sql.Add(ret);
        }
    }
}