using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmGZRule : frmBaseMDIChildGrid
    {
        private string modeIn = "", modeOut = "";
        protected override void InitForm()
        {
            formCode = "GZRule";
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "RuleID", false, true, 0);
            AddColumn(0, "RuleName", false, true, 0);
            AddColumn(0, "Mode", false, true, 0);
            AddColumn(1, "IsFunction", false, false, 1, 60);
            AddColumn(0, "RuleCash", false, false, 0);
            AddColumn(0, "VRuleFunction", false, false, 1, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            //SetToolItemState("ItemLine1", false);
            base.InitForm();
            modeIn = Pub.GetResText(formCode, "modeIn", "");
            modeOut = Pub.GetResText(formCode, "modeOut", "");
            ExecItemRefresh();
        }

        public frmGZRule()
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
            frmGZRuleAdd frm = new frmGZRuleAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmGZRuleAdd frm = new frmGZRuleAdd(this.Text, CurrentTool, GetRuleID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000400, new string[] { "1" });
            QuerySQL = string.Format(QuerySQL, modeIn, modeOut);
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_000400, new string[] { "5", dataGrid[1, rowIndex].Value.ToString() });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
               dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        private string GetRuleID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["RuleID"].ToString();
        }

        protected override bool CheckDelete(int rowIndex)
        {
            string RuleID = dataGrid[1, rowIndex].Value.ToString();
            bool ret = base.CheckDelete(rowIndex);
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000400, new string[] { "7", RuleID }));
                if (dr.Read()) ret = Convert.ToInt32(dr[0].ToString()) == 0;
                if (!ret) Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return ret;
        }
    }
}