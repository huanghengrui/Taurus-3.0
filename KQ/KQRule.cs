using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmKQRule : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "KQRule";
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "RuleID", false, false, 0);
            AddColumn(0, "RuleName", false, true, 0);
            AddColumn(0, "RuleLateIgnore", false, false, 0);
            AddColumn(0, "RuleLeaveIgnore", false, false, 0);
            AddColumn(0, "RuleDupLimit", false, false, 0);
            AddColumn(0, "RuleLateLeaveCalHrs", false, false, 0);
            AddColumn(0, "RuleLateHrs", false, false, 0);
            AddColumn(0, "RuleLeaveHrs", false, false, 0);
            AddColumn(1, "RuleAheadHrs", false, false, 1, 0);
            AddColumn(0, "RuleAheadMins", false, false, 1, 0);
            AddColumn(1, "RuleDeferHrs", false, false, 1, 0);
            AddColumn(0, "RuleDeferMins", false, false, 1, 0);
            AddColumn(1, "RuleSunday", false, false, 1, 0);
            AddColumn(1, "RuleMonday", false, false, 1, 0);
            AddColumn(1, "RuleTuesday", false, false, 1, 0);
            AddColumn(1, "RuleWednesday", false, false, 1, 0);
            AddColumn(1, "RuleThursday", false, false, 1, 0);
            AddColumn(1, "RuleFriday", false, false, 1, 0);
            AddColumn(1, "RuleSaturday", false, false, 1, 0);
            AddColumn(1, "RuleNoRule", false, false, 1, 0);
            AddColumn(0, "RuleRestDays", false, false, 1, 0);
            AddColumn(1, "RuleReadLate", false, false, 1, 0);
            AddColumn(1, "RuleReadLeave", false, false, 1, 0);
            AddColumn(1, "RuleReadWorkHrs", false, false, 1, 0);
            AddColumn(1, "RuleHeadAndTail", false, false, 1, 0);
            AddColumn(1, "RuleLeaveOvertime", false, false, 1, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            //SetToolItemState("ItemLine1", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmKQRule()
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
            frmKQRuleAdd frm = new frmKQRuleAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmKQRuleAdd frm = new frmKQRuleAdd(this.Text, CurrentTool, GetRuleID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000200, new string[] { "0" });
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_000200, new string[] { "5", dataGrid[1, rowIndex].Value.ToString() });
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
            if (RuleID.ToUpper() == "R0001")
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""));
                return false;
            }
            bool ret = base.CheckDelete(rowIndex);
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000200, new string[] { "3", RuleID }));
                if (dr.Read()) ret = Convert.ToInt32(dr[0].ToString()) == 0;
                if (ret)
                {
                    dr.Close();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000200, new string[] { "4", RuleID }));
                    if (dr.Read()) ret = Convert.ToInt32(dr[0].ToString()) == 0;
                }
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