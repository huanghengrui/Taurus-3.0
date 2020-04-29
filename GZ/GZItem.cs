using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmGZItem : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "GZItem";
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "ItemID", false, true, 0);
            AddColumn(0, "ItemName", false, false, 0);
            AddColumn(0, "In", false, false, 1, 0);
            AddColumn(0, "Out", false, false, 1, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            // SetToolItemState("ItemLine1", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmGZItem()
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
            frmGZItemAdd frm = new frmGZItemAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmGZItemAdd frm = new frmGZItemAdd(this.Text, CurrentTool, GetItemID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000401, new string[] { "1" });
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_000401, new string[] { "5", dataGrid[1, rowIndex].Value.ToString() });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        private string GetItemID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["ItemID"].ToString();
        }
    }
}