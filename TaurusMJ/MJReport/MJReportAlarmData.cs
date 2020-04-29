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
    public partial class frmMJReportAlarmData : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "KQReportMJData";
            ReportFile = "MJReportAlarmData";
            IsInitBaseForm = true;
            IgnoreDimission = false;
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
        }

        public frmMJReportAlarmData()
        {
            InitializeComponent();
        }


        protected override void ExecItemRefresh()
        {
            string MacTag = "0";
            string MacSN = "";
            string AlarmMode = "";

            if ((txtMacSN.Text.Trim() != "") && (txtMacSN.Tag != null))
            {
                MacSN = txtMacSN.Text.Trim();
                MacTag = "1";
            }
            else if ((txtMacSN.Text.Trim() != ""))
            {
                MacSN = txtMacSN.Text.Trim();
            }
            if (txtAlarmMode.Text.Trim() != "")
            {
                AlarmMode = txtAlarmMode.Text.Trim();
            }

            QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "804", dtpStart.Value.ToString(SystemInfo.SQLDateFMT),
       dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), MacTag, MacSN, AlarmMode});
            RefreshSQL();
           // cbbAlarmMode_DropDown();
        }

        private void btnSelectMacSN_Click(object sender, EventArgs e)
        {
            frmPubSelectMacSN frm = new frmPubSelectMacSN();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtMacSN.Text = frm.MacSN;
                txtMacSN.Tag = frm.MacSN;
            }
        }

        private void RefreshSQL()
        {
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }

        /*private void cbbAlarmMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAlarmMode.Text = cbbAlarmMode.Text;
        }

       private void cbbAlarmMode_DropDown()
        {
            bool ret = false;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                ret = false;
                if (Report.FieldByName("AlarmMode").IsNull)
                {
                    Report.DetailGrid.Recordset.Next();
                    continue;
                }
                if (Report.FieldByName("AlarmMode").AsString.ToString() == "")
                {
                    Report.DetailGrid.Recordset.Next();
                    continue;
                }
                if (cbbAlarmMode.Items.Count > 0)
                    for (int i = 0; i < cbbAlarmMode.Items.Count; i++)
                    {
                        if (cbbAlarmMode.Items[i].ToString() == Report.FieldByName("AlarmMode").AsString)
                        {
                            ret = true;
                            break;
                        }
                    }
                if (!ret)
                    cbbAlarmMode.Items.Add(Report.FieldByName("AlarmMode").AsString);
                Report.DetailGrid.Recordset.Next();
            }
        }*/
    }
}