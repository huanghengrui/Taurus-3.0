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
    public partial class frmKQReportLog : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "KQReportLog";
            ReportFile = "KQReportLog";
            IsInitBaseForm = true;
            IgnoreDimission = false;
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
            WindowState = FormWindowState.Maximized;
        }

        public frmKQReportLog()
        {
            InitializeComponent();
        }

        protected override void ExecItemRefresh()
        {

            string MacSN = "";
            string OprtModule = "";
            string OprtTool = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                MacSN = txtEmp.Tag.ToString();
            }
            else if (txtEmp.Text.Trim() != "")
            {
                MacSN = txtEmp.Text.Trim();
            }

            if (txtOprtModule.Text.Trim() != "")
            {
                OprtModule = txtOprtModule.Text.Trim();
            }
            if (txtOprtTool.Text.Trim() != "")
            {
                OprtTool = txtOprtTool.Text.Trim();
            }

            QuerySQL = Pub.GetSQL(DBCode.DB_000214, new string[] { "7", dtpStart.Value.ToString(SystemInfo.SQLDateFMT),
        dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), MacSN ,OprtModule,OprtTool});
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp(IgnoreDimission);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp.Text = frm.EmpName;
                txtEmp.Tag = frm.EmpNo;
            }
        }

        private void dispView_ContentCellDblClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEvent e)
        {

            MessageBox.Show(Report.FieldByName("OprtDetail").AsString, Pub.GetResText(formCode, "OprtDetail", ""));

        }
    }
}