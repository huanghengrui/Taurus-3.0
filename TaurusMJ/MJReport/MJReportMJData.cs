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
    public partial class frmMJReportMJData : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "MJReportMJData";
            ReportFile = "MJReportMJData";
            IsInitBaseForm = true;
            IgnoreDimission = false;
            base.InitForm();
            
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
            #region 从数据库获取
            //DataTableReader dr = null;
            //bool ret = false;
            //bool reta = false;

            //dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "8" }));
            //while (dr.Read())
            //{
            //    ret = false;
            //    reta = false;
            //    if (dr[0].ToString() == "") continue;
            //    if (dr[1].ToString() == "") continue;
            //    if (cbbInOutMode.Items.Count > 0)
            //        for (int i = 0; i < cbbInOutMode.Items.Count; i++)
            //        {
            //            if (cbbInOutMode.Items[i].ToString() == dr[0].ToString())
            //            {
            //                ret = true;
            //                break;
            //            }
            //        }
            //    if (!ret)
            //        cbbInOutMode.Items.Add(dr[0].ToString());
            //    //if (cbbVerifyMode.Items.Count > 0)
            //    //    for (int i = 0; i < cbbVerifyMode.Items.Count; i++)
            //    //    {
            //    //        if (cbbVerifyMode.Items[i].ToString() == dr[1].ToString())
            //    //        {
            //    //            reta = true;
            //    //            break;
            //    //        }
            //    //    }
            //    //if (!reta)
            //    //    cbbVerifyMode.Items.Add(dr[1].ToString());
            //}
            #endregion

        }

        public frmMJReportMJData()
        {
            InitializeComponent();
        }


        protected override void ExecItemRefresh()
        {
            string EmpTag = "0";
            string EmpNo = "";
            string MacTag = "0";
            string MacSN = "";
            string InOutMode = "";
            string VerifyMode = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }

            if ((txtMacSN.Text.Trim() != "") && (txtMacSN.Tag != null))
            {
                MacSN = txtMacSN.Text.Trim();
                MacTag = "1";
            }
            else if ((txtMacSN.Text.Trim() != ""))
            {
                MacSN = txtMacSN.Text.Trim();
            }
            if (txtInOutMode.Text.Trim() != "")
            {
                InOutMode = txtInOutMode.Text.Trim();
            }
            if (txtVerifyMode.Text.Trim() != "")
            {
                VerifyMode = txtVerifyMode.Text.Trim();
            }
            picData.BackgroundImage = null;
            QuerySQL = Pub.GetSQL(DBCode.DB_000214, new string[] { "2", dtpStart.Value.ToString(SystemInfo.SQLDateFMT),
       dtpEnd.Value.ToString(SystemInfo.SQLDateFMT),EmpTag, EmpNo, MacTag, MacSN, InOutMode,VerifyMode});
            RefreshSQL();
           // cbbInOutMode_DropDown();
           // cbbVerifyMode_DropDown();
        }

        private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
        {
            picData.BackgroundImage = null;
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "3",
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

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp(IgnoreDimission);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp.Text = frm.EmpName;
                txtEmp.Tag = frm.EmpNo;
            }
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

        private void txtMacSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RefreshSQL()
        {
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }

        private void btnAccessLog_Click(object sender, EventArgs e)
        {
            string EmpTag = "0";
            string EmpNo = "";
            string MacTag = "0";
            string MacSN = "";
            string InOutMode = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }

            if ((txtMacSN.Text.Trim() != "") && (txtMacSN.Tag != null))
            {
                MacSN = txtMacSN.Text.Trim();
                MacTag = "1";
            }
            else if ((txtMacSN.Text.Trim() != ""))
            {
                MacSN = txtMacSN.Text.Trim();
            }
            if (txtInOutMode.Text.Trim() != "")
            {
                InOutMode = txtInOutMode.Text.Trim();
            }
            picData.BackgroundImage = null;
            QuerySQL = Pub.GetSQL(DBCode.DB_000214, new string[] { "5", dtpStart.Value.ToString(SystemInfo.SQLDateFMT),
       dtpEnd.Value.ToString(SystemInfo.SQLDateFMT),EmpTag, EmpNo, MacTag, MacSN, InOutMode});
            RefreshSQL();
        }

        private void btnAlarmLog_Click(object sender, EventArgs e)
        {
            string EmpTag = "0";
            string EmpNo = "";
            string MacTag = "0";
            string MacSN = "";
            string InOutMode = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }

            if ((txtMacSN.Text.Trim() != "") && (txtMacSN.Tag != null))
            {
                MacSN = txtMacSN.Text.Trim();
                MacTag = "1";
            }
            else if ((txtMacSN.Text.Trim() != ""))
            {
                MacSN = txtMacSN.Text.Trim();
            }
            if (txtInOutMode.Text.Trim() != "")
            {
                InOutMode = txtInOutMode.Text.Trim();
            }
            picData.BackgroundImage = null;
            QuerySQL = Pub.GetSQL(DBCode.DB_000214, new string[] { "6", dtpStart.Value.ToString(SystemInfo.SQLDateFMT),
       dtpEnd.Value.ToString(SystemInfo.SQLDateFMT),EmpTag, EmpNo, MacTag, MacSN, InOutMode});
            RefreshSQL();
        }

    /*    private void cbbVerifyMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVerifyMode.Text = cbbVerifyMode.Text;
        }

        private void cbbVerifyMode_DropDown()
        {
            bool ret = false;
            
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                ret = false;
                if (Report.FieldByName("VerifyModeName").IsNull)
                {
                    Report.DetailGrid.Recordset.Next();
                    continue;
                }
                if (Report.FieldByName("VerifyModeName").AsString.ToString() == "")
                {
                    Report.DetailGrid.Recordset.Next();
                    continue;
                }
                if (cbbVerifyMode.Items.Count > 0)
                    for (int i = 0; i < cbbVerifyMode.Items.Count; i++)
                    {
                        if (cbbVerifyMode.Items[i].ToString() == Report.FieldByName("VerifyModeName").AsString)
                        {
                            ret = true;
                            break;
                        }
                    }
                if (!ret)
                    cbbVerifyMode.Items.Add(Report.FieldByName("VerifyModeName").AsString);
                Report.DetailGrid.Recordset.Next();
            }
        }

        private void cbbInOutMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInOutMode.Text = cbbInOutMode.Text;
        }

        private void cbbInOutMode_DropDown()
        {
            bool ret = false;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                ret = false;
                if (Report.FieldByName("InOutModeName").IsNull)
                {
                    Report.DetailGrid.Recordset.Next();
                    continue;
                }
                if (Report.FieldByName("InOutModeName").AsString.ToString() == "")
                {
                    Report.DetailGrid.Recordset.Next();
                    continue;
                }
                if (cbbInOutMode.Items.Count > 0)
                    for (int i = 0; i < cbbInOutMode.Items.Count; i++)
                    {
                        if (cbbInOutMode.Items[i].ToString() == Report.FieldByName("InOutModeName").AsString)
                        {
                            ret = true;
                            break;
                        }
                    }
                if (!ret)
                    cbbInOutMode.Items.Add(Report.FieldByName("InOutModeName").AsString);
                Report.DetailGrid.Recordset.Next();
            }
        }*/
    }
}