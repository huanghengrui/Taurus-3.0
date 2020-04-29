using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmKQShift : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "KQShift";
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "ShiftID", false, true, 0);
            AddColumn(0, "ShiftName", false, false, 0);
            AddColumn(0, "WorkHours", false, false, 0);
            AddColumn(0, "OverHours", false, false, 0);
            AddColumn(1, "IsAuto", false, false, 1, 0);
            AddColumn(0, "SigninTime1", false, false, 0);
            AddColumn(0, "SignoutTime1", false, false, 0);
            AddColumn(0, "SigninTime2", false, false, 0);
            AddColumn(0, "SignoutTime2", false, false, 0);
            AddColumn(0, "SigninTime3", false, false, 0);
            AddColumn(0, "SignoutTime3", false, false, 0);
            AddColumn(0, "SigninTime4", false, false, 0);
            AddColumn(0, "SignoutTime4", false, false, 0);
            AddColumn(0, "SigninTime5", false, false, 0);
            AddColumn(0, "SignoutTime5", false, false, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            //SetToolItemState("ItemLine1", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmKQShift()
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
            frmKQShiftAdd frm = new frmKQShiftAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmKQShiftAdd frm = new frmKQShiftAdd(this.Text, CurrentTool, GetShiftID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000204, new string[] { "0" });
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ShiftID = dataGrid[1, rowIndex].Value.ToString();
            sql.Add(Pub.GetSQL(DBCode.DB_000204, new string[] { "1", ShiftID }));
            sql.Add(Pub.GetSQL(DBCode.DB_000204, new string[] { "8", ShiftID }));
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        private string GetShiftID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["ShiftID"].ToString();
        }

        protected override bool CheckDelete(int rowIndex)
        {
            bool ret = base.CheckDelete(rowIndex);
            string ShiftID = dataGrid[1, rowIndex].Value.ToString();
            if (ShiftID == "001")
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                return false;
            }
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "9", ShiftID }));
                if (dr.Read()) ret = Convert.ToInt32(dr[0].ToString()) == 0;
                if (ret)
                {
                    dr.Close();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "10", ShiftID }));
                    if (dr.Read()) ret = Convert.ToInt32(dr[0].ToString()) == 0;
                }
                if (ret)
                {
                    dr.Close();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "11", ShiftID }));
                    if (dr.Read()) ret = Convert.ToInt32(dr[0].ToString()) == 0;
                }
                if (!ret) Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""));
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