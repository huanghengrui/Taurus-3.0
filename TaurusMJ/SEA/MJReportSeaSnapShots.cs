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
    public partial class frmMJReportSeaSnapShots : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "MJReportSeaSnapShots";
            ReportFile = "MJReportSeaSnapShots";
            IsInitBaseForm = true;
            IgnoreDimission = false;
            ItemAdd.Tag = "btnAddEmpInfo";
            base.InitForm();
            SetToolItemState("ItemSelect", true);
            SetToolItemState("ItemUnselect", true);
            SetToolItemState("ItemDelete", true);

            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);     
        }

        public frmMJReportSeaSnapShots()
        {
            InitializeComponent();
        }

        private void btnGetSnapshotsLog_Click(object sender, EventArgs e)
        {
            string startTime = dtpStart.Value.ToString(SystemInfo.SQLDateFMT);
            string endTime = dtpEnd.Value.ToString(SystemInfo.SQLDateFMT);
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(btnGetSnapshotsLog.Text, btnGetSnapshotsLog.Text, startTime + "@" + endTime, 13, null);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        private void btnClearSnapshotsLog_Click(object sender, EventArgs e)
        {
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(btnClearSnapshotsLog.Text, btnClearSnapshotsLog.Text, "", 12, null);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            string SysID = Report.FieldByName("GUID").AsString;
            if(SysID=="")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorSelectCorrect", ""),this.Text));
                return;
            }
            frmRSEmpAdd frm = new frmRSEmpAdd(this.Text, CurrentTool, SysID, 3);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemRefresh()
        {
           
            picData.BackgroundImage = null;
            QuerySQL = Pub.GetSQL(DBCode.DB_000214, new string[] { "10", dtpStart.Value.ToString(SystemInfo.SQLDateFMT),
       dtpEnd.Value.ToString(SystemInfo.SQLDateFMT)});
            RefreshSQL();
            
            if (string.IsNullOrEmpty(Report.FieldByName("GUID").AsString))
            {
                SetToolItemState("ItemAdd", false);

            }
            else
            {
                SetToolItemState("ItemAdd", true);
            }
        }

        private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
        {
            picData.BackgroundImage = null;
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "14",
          Report.FieldByName("GUID").AsString }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }
                dr.Close();
                if(picData.BackgroundImage !=null)
                {
                    return;
                }
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "11",
          Report.FieldByName("GUID").AsString }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
        }

        private void RefreshSQL()
        {
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_000214, new string[] { "12", Report.FieldByName("GUID").AsString});
            sql.Add(ret);
            if(SystemInfo.DBType==0)
            {
                ret = Pub.GetSQL(DBCode.DB_000214, new string[] { "15", Report.FieldByName("GUID").AsString });
                sql.Add(ret);
            }
           
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = "[" + Report.FieldByName("GUID").AsString + "]";
            return ret;
        }

        private void dispView_ContentCellDblClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEvent e)
        {
            string SysID = Report.FieldByName("GUID").AsString;
            frmRSEmpAdd frm = new frmRSEmpAdd(this.Text, CurrentTool, SysID,3);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        private void frmMJReportSeaSnapShots_Load(object sender, EventArgs e)
        {
            
        }

    }
}