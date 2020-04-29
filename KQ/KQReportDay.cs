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
    public partial class frmKQReportDay : frmBaseMDIChildReportPrint
    {
        //private IGRField ResultIsNormalField = null;
        private frmKQReportDayDetail frmDetail = null;

        protected override void InitForm()
        {
            formCode = "KQReportDay";
            ReportFile = "KQReportDay";
            IsInitBaseForm = true;
            bool ret = false;
            IgnoreDimission = false;
            base.InitForm();
            Report.Initialize += new _IGridppReportEvents_InitializeEventHandler(Report_Initialize);
            Report.SectionFormat += new _IGridppReportEvents_SectionFormatEventHandler(Report_SectionFormat);
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
            string ssql = "SELECT[Value] FROM SY_Config WHERE ID = 'SystemInfo' AND[Key] = 'OutHrs'";
            DataTableReader dr = SystemInfo.db.GetDataReader(ssql);
            if (dr.Read())
            {
                if (dr[0].ToString() == "1") ret = true;
                else ret = false;
            }
            if (ret)
            {
                Report.DetailGrid.Columns[21].Visible = true;
            }
            else
            {
                Report.DetailGrid.Columns[21].Visible = false;
            }
            dispView.Refresh();
        }

        public frmKQReportDay()
        {
            InitializeComponent();
        }

        protected override void ExecItemRefresh()
        {
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }
            if ((txtDepart.Text.Trim() != "") && (txtDepart.Tag != null))
            {
                DepartID = txtDepart.Tag.ToString();
                DepartTag = "1";
                if (DepartID != "") DepartList = SystemInfo.db.GetDepartChildID(DepartID);
                if (DepartList == "") DepartList = "''";
            }
            else if (txtDepart.Text.Trim() != "")
            {
                DepartID = txtDepart.Text.Trim();
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_000216, new string[] { "0", EmpTag, EmpNo, DepartTag, DepartID, DepartList,
        dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT),
        Convert.ToByte(chkLeave.Checked).ToString(), Convert.ToByte(chkAhead.Checked).ToString(),
        Convert.ToByte(chkLater.Checked).ToString(), Convert.ToByte(chkAbsent.Checked).ToString(),
        Convert.ToByte(chkOtSure.Checked).ToString() });
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

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepart.Text = frm.DepartName;
                txtDepart.Tag = frm.DepartID;
            }
        }

        private void Report_Initialize()
        {
            //ResultIsNormalField = dispView.Report.FieldByName("ResultIsNormal");
        }

        private void Report_SectionFormat(IGRSection pSender)
        {
            /*try
            {
              if (ResultIsNormalField == null) return;
              if (ResultIsNormalField.AsString == "N")
              {
                for (int i = 1; i <= dispView.Report.DetailGrid.ColumnContent.ContentCells.Count; i++)
                {
                  dispView.Report.DetailGrid.ColumnContent.ContentCells[i].ForeColor = Pub.ColorToOleColor(Color.Red);
                }
              }
              else
              {
                for (int i = 1; i <= dispView.Report.DetailGrid.ColumnContent.ContentCells.Count; i++)
                {
                  dispView.Report.DetailGrid.ColumnContent.ContentCells[i].ForeColor = Pub.ColorToOleColor(Color.Black);
                }
              }
            }
            catch
            {
            }*/
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            chkLeave.Enabled = !chkAll.Checked;
            chkAhead.Enabled = chkLeave.Enabled;
            chkLater.Enabled = chkLeave.Enabled;
            chkAbsent.Enabled = chkLeave.Enabled;
            if (!chkLeave.Enabled)
            {
                chkLeave.Checked = true;
                chkAhead.Checked = true;
                chkLater.Checked = true;
                chkAbsent.Checked = true;
            }
        }

        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmp.Tag = null;
        }

        private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepart.Tag = null;
        }

        private void dispView_ContentCellDblClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEvent e)
        {
            if (frmDetail == null)
            {
                frmDetail = new frmKQReportDayDetail();
                frmDetail.Left = this.Width - frmDetail.Width - 7;
                frmDetail.Top = pnlDisp.Top + 42;
                frmDetail.TopLevel = false;
                frmDetail.Parent = this;
                frmDetail.FormClosed += this.frmDetail_Closed;
                frmDetail.Show();
                frmDetail.BringToFront();
            }
            ShowKQData();
        }

        private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
        {
            if (dispView.SelRowNo != e.oldRow) ShowKQData();
        }

        private void frmKQReportResultDay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmDetail != null) frmDetail.Close();
        }

        private void frmDetail_Closed(object sender, FormClosedEventArgs e)
        {
            frmDetail.Dispose();
            frmDetail = null;
        }

        private void ShowKQData()
        {
            if (frmDetail == null) return;
            string EmpNo = Report.FieldByName("EmpNo").AsString;
            DateTime KQDate = Report.FieldByName("KQDate").AsDateTime;
            frmDetail.ShowKQData(EmpNo, KQDate);
        }
    }
}