using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace Taurus
{
    public partial class frmRSEmpChart : frmBaseMDIChildReportPrint
    {
        private IGRChart DetailChart = null;

        protected override void InitForm()
        {
            formCode = "RSEmpChart";
            ReportFile = "RSEmpChart";
            IgnoreReportHead = true;
            IgnoreTagExt = true;
            IsInitBaseForm = true;
            base.InitForm();
            lblRecordState.Visible = false;
            SetReportTitle(dispView, this.Text);
            Report.Initialize += new _IGridppReportEvents_InitializeEventHandler(Report_Initialize);
        }

        public frmRSEmpChart()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            if (rbBar.Checked)
                Report.ControlByName("DetailChart").AsChart.ChartType = GRChartType.grctBarChart;
            else
                Report.ControlByName("DetailChart").AsChart.ChartType = GRChartType.grctPieChart;
            ExecItemRefresh();
        }

        private void Report_Initialize()
        {
            ItemExport.Enabled = false;
            ItemPrint.Enabled = false;
            string sql = "";
            if (rbSex.Checked)
                sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "101" });
            else if (rbDepart.Checked)
                sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "102" });
            if (sql == "") return;
            DataTable dt = null;
            string fn;
            int v = 0;
            DetailChart = Report.ControlByName("DetailChart").AsChart;
            DetailChart.YAxisMaximum = 0;
            try
            {
                dt = SystemInfo.db.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    if (rbBar.Checked)
                    {
                        DetailChart.SeriesCount = 1;
                        DetailChart.GroupCount = Convert.ToInt16(dt.Rows.Count);
                    }
                    else
                    {
                        DetailChart.SeriesCount = Convert.ToInt16(dt.Rows.Count);
                        DetailChart.GroupCount = 1;
                    }
                    for (short i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i].IsNull(0))
                            fn = "[NULL]";
                        else
                            fn = dt.Rows[i][0].ToString();
                        v = Convert.ToInt32(dt.Rows[i][1]);
                        if (rbBar.Checked)
                        {
                            DetailChart.set_GroupLabel(i, fn);
                            DetailChart.set_SeriesLabel(i, "");
                            DetailChart.set_Value(0, i, v);
                        }
                        else
                        {
                            DetailChart.set_GroupLabel(i, "");
                            DetailChart.set_SeriesLabel(i, fn);
                            DetailChart.set_Value(i, 0, v);
                        }
                        DetailChart.YAxisMaximum = DetailChart.YAxisMaximum + v;
                    }
                }
                ItemExport.Enabled = true;
                ItemPrint.Enabled = true;
            }
            catch (Exception E)
            {
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
            DetailChart.SnapShot();
        }

        protected override void ExecItemRefresh()
        {
            contextMenu.Close();
            RefreshMsg(StrReading);
            dispView.Refresh();
            RefreshForm(true);
            RefreshMsg("");
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemPrint.Enabled = true;
            ItemExport.Enabled = true;
            SetContextMenuState();
        }
    }
}