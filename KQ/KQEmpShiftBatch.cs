using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmKQEmpShiftBatch : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "KQEmpShiftBatch";
            CreateCardGridView(cardGrid);
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
            DataTableReader dr = null;
            TIDAndName idn;
            cbbRule.Items.Clear();
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000205, new string[] { "0" }));
                while (dr.Read())
                {
                    idn = new TIDAndName(dr["ShiftRuleID"].ToString(), "[" + dr["ShiftRuleID"].ToString() + "]" +
                      dr["ShiftRuleName"].ToString());
                    cbbRule.Items.Add(idn);
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (cbbRule.Items.Count > 0) cbbRule.SelectedIndex = 0;
        }

        public frmKQEmpShiftBatch(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dtpEnd.Value < dtpStart.Value)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            if (cbbRule.SelectedIndex < 0)
            {
                ShowErrorSelectCorrect(label3.Text);
                return;
            }
            if (cardGrid.RowCount == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            string ShiftRuleID = ((TIDAndName)cbbRule.Items[cbbRule.SelectedIndex]).id;
            List<string> sql = new List<string>();
            string EmpNo = "";
            DataTable dt = null;
            bool IsError = false;
            int days = (int)Pub.DateDiff(DateInterval.Day, dtpStart.Value, dtpEnd.Value);
            int flag = 0;
            int CycDays = 0;
            int row = 0;
            try
            {
                dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000205, new string[] { "3", ShiftRuleID }));
                flag = Convert.ToInt32(dt.Rows[0]["ShiftRulecycID"].ToString());
                CycDays = Convert.ToInt32(dt.Rows[0]["ShiftRulecyc"].ToString());
                dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000205, new string[] { "4", ShiftRuleID }));
                DataTable dtGrid = (DataTable)cardGrid.DataSource;
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    EmpNo = dtGrid.Rows[i]["EmpNo"].ToString();
                    sql.Add(Pub.GetSQL(DBCode.DB_000206, new string[] { "3", EmpNo,
            dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT) }));
                    switch (flag)
                    {
                        case 0:
                            row = 1;
                            for (int j = 0; j <= days; j++)
                            {
                                if (row > CycDays) row = 1;
                                sql.Add(Pub.GetSQL(DBCode.DB_000206, new string[] { "2", EmpNo,
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row - 1]["ShiftID"].ToString() }));
                                row += 1;
                            }
                            break;
                        case 1:
                            for (int j = 0; j <= days; j++)
                            {
                                row = (int)dtpStart.Value.AddDays(j).DayOfWeek;
                                sql.Add(Pub.GetSQL(DBCode.DB_000206, new string[] { "2", EmpNo,
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row]["ShiftID"].ToString() }));
                            }
                            break;
                        case 2:
                            for (int j = 0; j <= days; j++)
                            {
                                row = dtpStart.Value.AddDays(j).Day;
                                sql.Add(Pub.GetSQL(DBCode.DB_000206, new string[] { "2", EmpNo,
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row - 1]["ShiftID"].ToString() }));
                            }
                            break;
                    }
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Clear();
                    dt.Reset();
                }
            }
            if (IsError) return;
            if (SystemInfo.db.ExecSQL(sql) != 0) return;
            SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
            //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ((DataTable)cardGrid.DataSource).Clear();
            cardGrid.DataSource = null;
        }

        private void cardGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblMsg.Text = string.Format(Pub.GetResText(formCode, "MsgSelectNo", ""), cardGrid.Rows.Count);
        }
    }
}