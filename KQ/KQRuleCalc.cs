using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmKQRuleCalc : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "KQRuleCalc";
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "SortID", false, true, 0);
            AddColumn(0, "SortName", false, false, 0);
            AddColumn(0, "CalcTypeName", false, false, 0);
            AddColumn(0, "OvertimeTypeName", false, false, 0);
            AddColumn(0, "OvertimeRate", false, false, 0);
            if (SystemInfo.AllowAdjust)
            {
                AddColumn(0, "Start", false, false, 0);
                AddColumn(0, "Tune", false, false, 0);
                AddColumn(0, "Integer", false, false, 0);
            }
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
           // SetToolItemState("ItemLine1", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmKQRuleCalc()
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
            frmKQRuleCalcAdd frm = new frmKQRuleCalcAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmKQRuleCalcAdd frm = new frmKQRuleCalcAdd(this.Text, CurrentTool, GetRuleID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000201, new string[] { "0" });
            base.ExecItemRefresh();
        }

        private string GetRuleID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["SortID"].ToString();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_000201, new string[] { "1", dataGrid[1, rowIndex].Value.ToString() });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        protected override bool CheckDelete(int rowIndex)
        {
            string SortID = dataGrid[1, rowIndex].Value.ToString();
            if (SortID == "A001" || SortID == "A011" || SortID == "A012" || SortID == "A013" ||
              SortID == "A021" || SortID == "A022")
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""));
                return false;
            }
            bool ret = base.CheckDelete(rowIndex);
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000201, new string[] { "2", SortID }));
                if (dr.Read()) ret = Convert.ToInt32(dr[0].ToString()) == 0;
                if (ret)
                {
                    dr.Close();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000201, new string[] { "3", SortID }));
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