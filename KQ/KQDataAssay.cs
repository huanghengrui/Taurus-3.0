using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmKQDataAssay : frmBaseDialog
    {
        private bool IsWorking = false;

        protected override void InitForm()
        {
            formCode = "KQDataAssay";
            CreateCardGridView(cardGrid);

            IgnoreDimission = false;
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
            IsWorking = false;
            RefreshControl();
        }

        public frmKQDataAssay()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = rbEmp.Checked && !IsWorking;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
        }

        private void RefreshControl()
        {
            label1.Enabled = !IsWorking;
            dtpStart.Enabled = !IsWorking;
            label2.Enabled = !IsWorking;
            dtpEnd.Enabled = !IsWorking;
            rbAll.Enabled = !IsWorking;
            rbEmp.Enabled = !IsWorking;
            button1.Enabled = !IsWorking;
            button2.Enabled = IsWorking;
            btnCancel.Enabled = !IsWorking;
            RadioButton_Click(null, null);
        }

        private void frmKQDataAssay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                dtpStart.Focus();
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorStartDateBegreater", ""));
                return;
            }
            int week = 0;
            long days = Pub.DateDiff(DateInterval.Day, dtpStart.Value.Date, dtpEnd.Value.Date) + 1;
            if (days > 31)
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Error001", ""), 31));
                return;
            }
            if(cbWeek.Checked)
            {
                week = 1;
                if (days > 7)
                {
                    Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Error001", ""), 7));
                    return;
                }
            }
            if (rbEmp.Checked && (cardGrid.RowCount == 0))
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            IsWorking = true;
            RefreshControl();
            string msg = Pub.GetResText(formCode, "Msg001", "");
            bool IsError = false;
            DateTime StartTime = DateTime.Now;
            DataTable dt = null;
            label3.Text = msg;
            progBar.Value = 0;
            string EmpNo;
            DateTime StartDate = dtpStart.Value.Date;
            DateTime EndDate = dtpEnd.Value.Date;
            int empCount = 0;
            try
            {
                if (SystemInfo.DBType == 0)
                {
                    SystemInfo.objACKQ.PKQ_Temp_KQ_KQData(StartDate, EndDate);
                }
               
                SystemInfo.db.WriteConfig("KQ", "AllowAdjust", true);
                if (rbAll.Checked)
                {
                    dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000213, new string[] { "0" }));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        label3.Text = msg + string.Format("{0}/{1}", i + 1, dt.Rows.Count) + "  [" +
                          dt.Rows[i]["DepartID"].ToString() + "]" + dt.Rows[i]["DepartName"].ToString() + " - [" +
                          dt.Rows[i]["EmpNo"].ToString() + "]" + dt.Rows[i]["EmpName"].ToString() + "  " +
                          Pub.GetDateDiffTimes(StartTime, DateTime.Now, true);
                        EmpNo = dt.Rows[i]["EmpNo"].ToString();
                        if (!CalcEmpData(EmpNo, StartDate, EndDate,week))
                        {
                            IsError = true;
                            break;
                        }
                        empCount += 1;
                        progBar.Value = (i + 1) * 100 / dt.Rows.Count;
                        if (!IsWorking) break;
                        Application.DoEvents();
                    }
                }
                else
                {
                    DataTable dtGrid = (DataTable)cardGrid.DataSource;
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        label3.Text = msg + string.Format("{0}/{1}", i + 1, cardGrid.RowCount) + "  [" +
                          dtGrid.Rows[i]["DepartID"].ToString() + "]" + dtGrid.Rows[i]["DepartName"].ToString() + " - [" +
                          dtGrid.Rows[i]["EmpNo"].ToString() + "]" + dtGrid.Rows[i]["EmpName"].ToString() + "  " +
                          Pub.GetDateDiffTimes(StartTime, DateTime.Now, true);
                        EmpNo = dtGrid.Rows[i]["EmpNo"].ToString();
                        if (!CalcEmpData(EmpNo, StartDate, EndDate,week))
                        {
                            IsError = true;
                            break;
                        }
                        empCount += 1;
                        progBar.Value = (i + 1) * 100 / cardGrid.RowCount;
                        if (!IsWorking) break;
                        Application.DoEvents();
                    }
                }
                SystemInfo.db.DeleteConfig("KQ", "AllowAdjust");
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
                dt = null;
            }
            IsWorking = false;
            RefreshControl();
            if (IsError)
                msg = Pub.GetResText(formCode, "Msg003", "");
            else
                msg = Pub.GetResText(formCode, "Msg002", "");
            label3.Text = string.Format(msg, empCount, Pub.GetDateDiffTimes(StartTime, DateTime.Now, true));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsWorking = false;
        }

        private bool CalcEmpData(string EmpNo, DateTime StartDate, DateTime EndDate, int week)
        {
            bool ret = false;
            string KQYM = "";
            if (week == 1)
            {
                KQYM = StartDate.ToString(SystemInfo.DateFormatLog);
            }
            else
            {
                KQYM = StartDate.ToString(SystemInfo.YMFormatDB);
            }
            
            if (SystemInfo.DBType == 0)
            {
                ret = SystemInfo.objACKQ.PKQ_Calc(EmpNo, StartDate, EndDate, KQYM, week);
            }
            else
            {
                string strStart = StartDate.ToString(SystemInfo.SQLDateFMT);
                string strEnd = EndDate.ToString(SystemInfo.SQLDateFMT);
                string calcSQL = "";
                try
                {
                    if(week==1)
                    {
                        calcSQL = Pub.GetSQL(DBCode.DB_000213, new string[] { "2", EmpNo, strStart, strEnd, KQYM });
                    }
                    else
                    {
                        calcSQL = Pub.GetSQL(DBCode.DB_000213, new string[] { "1", EmpNo, strStart, strEnd, KQYM });
                    }
                    
                    SystemInfo.db.ExecSQL(calcSQL);
                    ret = true;
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E, calcSQL);
                }
            }
            return ret;
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