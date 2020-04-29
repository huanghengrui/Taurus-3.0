using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using grproLib;

namespace Taurus
{
    public partial class frmGZReport : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "GZReport";
            ReportFile = "GZReport";
            IsInitBaseForm = true;
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            IgnoreDimission = false;
            ShowKQType = false;
            base.InitForm();
            SetToolItemState("ItemTAGExt", false);
            if (contextMenu.Items["popItemSetupDisplay"] != null) contextMenu.Items["popItemSetupDisplay"].Visible = false;
            dtpYM.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpYM.CustomFormat = SystemInfo.YMFormatForm;
            InitcbbGZItem();
        }

        public frmGZReport()
        {
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            List<string> sql = getFreezeSql("1");
            if (sql.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgNoSelectFreeze", ""));
                return;
            }
            if (SystemInfo.db.ExecSQL(sql) != 0) return;
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgFreezeSucceed", ""), MessageBoxIcon.Information);
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG1();
            List<string> sql = getFreezeSql("0");
            if (sql.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgNoSelectBreakFreeze", ""));
                return;
            }
            if (SystemInfo.db.ExecSQL(sql) != 0) return;
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgBreakFreezeSucceed", ""), MessageBoxIcon.Information);
        }

        private List<string> getFreezeSql(string IsFreeze)
        {
            List<string> sql = new List<string>();
            string EmpNo = "";
            string YM = dtpYM.Value.ToString(SystemInfo.YMFormatDB);
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                EmpNo = Report.FieldByName("EmpNo").AsString;
                sql.Add(Pub.GetSQL(DBCode.DB_000404, new string[] { "7", IsFreeze, YM, EmpNo }));
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            return sql;
        }

        protected override void ExecItemRefresh()
        {
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            if (cbbGZItem.SelectedIndex == -1) return;
            string ItemID = ((TIDAndName)cbbGZItem.SelectedItem).id;
            string ResultYM = dtpYM.Value.ToString(SystemInfo.YMFormat);
            string ResultYMA = dtpYM.Value.ToString(SystemInfo.YMFormatDB);
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
            if(!ProsecutionRules(EmpNo,DepartID))
            {
                string msg = string.Format(Pub.GetResText(formCode, "Msg004", ""), Pub.GetResText("Main", "mnuGZRuleEmp", ""),
                      Pub.GetResText("Main", "mnuGZRuleDepart", ""));
                Pub.MessageBoxShow(msg);
                return;
            }
            CalcGZ(ItemID, EmpTag, EmpNo, DepartTag, DepartID, DepartList, ResultYMA);
            QuerySQL = Pub.GetSQL(DBCode.DB_000404, new string[] { "4", ItemID, EmpTag, EmpNo, DepartTag, DepartID, DepartList, ResultYMA });
            SetReportDate(dispView, lblYM.Text + ": " + ResultYM);
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }

        private bool ProsecutionRules(string EmpNo,string DepartID)
        {
            bool ret = false;
            DataTableReader drE = null;
            DataTableReader drD = null;
            string sqlE = "";
            string sqlD = "";
            sqlE = Pub.GetSQL(DBCode.DB_000402, new string[] { "0" });
            sqlD = Pub.GetSQL(DBCode.DB_000403, new string[] { "0" });
            if(EmpNo != "")
            {
                sqlE = Pub.GetSQL(DBCode.DB_000402, new string[] { "3",EmpNo });
            }
            if(DepartID != "")
            {
                sqlD = Pub.GetSQL(DBCode.DB_000403, new string[] { "4",DepartID });
            }
            try
            {
                drE = SystemInfo.db.GetDataReader(sqlE);
                drD = SystemInfo.db.GetDataReader(sqlD);
                if (drE.Read() || drD.Read())
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }

            }catch(Exception ex)
            {
                Pub.ShowErrorMsg(ex,sqlE+"\r\n"+sqlD);
            }

            return ret;
        }

        private void CalcGZ(string ItemID, string EmpTag, string EmpNo, string DepartTag, string DepartID, string DepartList, string ResultYM)
        {
            progBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard;
            progBar.Value = 0;
            string msg = Pub.GetResText(formCode, "Msg001", "");
            int empCount = 0;
            bool IsError = false;
            DateTime StartTime = DateTime.Now;
            List<string> sql = new List<string>();
            DataTable dt = null;
            try
            {
                dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000404, new string[] { "5", EmpTag, EmpNo, DepartTag, DepartID, DepartList }));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblMsg.Text = msg + string.Format("{0}/{1}", i + 1, dt.Rows.Count) + "  [" +
                      dt.Rows[i]["DepartID"].ToString() + "]" + dt.Rows[i]["DepartName"].ToString() + " - [" +
                      dt.Rows[i]["EmpNo"].ToString() + "]" + dt.Rows[i]["EmpName"].ToString() + "  " +
                      Pub.GetDateDiffTimes(StartTime, DateTime.Now, true);
                    Application.DoEvents();
                    if (!CalcGZData(dt.Rows[i]["EmpNo"].ToString(), ResultYM))
                    {
                        IsError = true;
                        break;
                    }
                    empCount += 1;
                    progBar.Value = (i + 1) * 100 / dt.Rows.Count;
                    Application.DoEvents();
                }
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
                dt = null;
            }
            if (IsError)
                msg = Pub.GetResText(formCode, "Msg003", "");
            else
                msg = Pub.GetResText(formCode, "Msg002", "");
            RefreshMsg(string.Format(msg, empCount, Pub.GetDateDiffTimes(StartTime, DateTime.Now, true)));
        }

        private bool CalcGZData(string EmpNo, string ResultYM)
        {
            bool ret = false;
            if (SystemInfo.DBType == 0)
            {
                ret = SystemInfo.objACGZ.PGZ_Calc(EmpNo, ResultYM);
            }
            else
            {
                string calcSQL = "";
                try
                {
                    calcSQL = Pub.GetSQL(DBCode.DB_000404, new string[] { "6", EmpNo, ResultYM });
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

        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmp.Tag = null;
        }

        private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepart.Tag = null;
        }


        private void InitcbbGZItem()
        {
            DataTableReader dr = null;
            TIDAndName idn = null;
            bool ret = false;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000404, new string[] { "0" }));
                while (dr.Read())
                {
                    idn = new TIDAndName(dr["ItemID"].ToString(), "[" + dr["ItemID"].ToString() + "]" +
                      dr["ItemName"].ToString());
                    for(int i=0;i<cbbGZItem.Items.Count;i++)
                    {
                        if (((TIDAndName)cbbGZItem.Items[i]).name.Equals(idn.name))
                        {
                            ret = true;
                            break;
                        }
                        ret = false;
                    }
                    if(!ret)
                        cbbGZItem.Items.Add(idn);
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
            if (cbbGZItem.Items.Count > 0)
                cbbGZItem.SelectedIndex = 0;
            else
            {
                ItemRefresh.Enabled = false;
                InitRepVisiable();
            }
        }

        private void cbbGZItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitRepVisiable();
            if (cbbGZItem.SelectedIndex == -1) return;
            DataTableReader dr = null;
            TIDAndName idn = null;
            string[] In = null, Out = null;
            idn = (TIDAndName)cbbGZItem.SelectedItem;
            if (idn != null)
            {
                try
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000404, new string[] { "1", idn.id }));
                    if (dr.Read())
                    {
                        In = dr["In"].ToString().Split(',');
                        Out = dr["Out"].ToString().Split(',');
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
            }
            if (In != null)
            {
                Report.DetailGrid.Columns[3].TitleCell.Visible = true;
                for (int i = 0; i < In.Length; i++)
                {
                    if (In[i] == "") continue;
                    Report.DetailGrid.Columns[i + 3].Visible = true;
                    Report.DetailGrid.Columns[i + 3].TitleCell.Text = In[i];
                }
            }
            if (Out != null)
            {
                Report.DetailGrid.Columns[23].TitleCell.Visible = true;
                for (int i = 0; i < Out.Length; i++)
                {
                    if (Out[i] == "") continue;
                    Report.DetailGrid.Columns[i + 23].Visible = true;
                    Report.DetailGrid.Columns[i + 23].TitleCell.Text = Out[i];
                }
            }
            QuerySQL  = "";
            dispView.Refresh();
            base.ExecItemRefresh();
        }

        private void RefreshDispView()
        {
            if (cbbGZItem.SelectedIndex == -1) return;
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            string ItemID = ((TIDAndName)cbbGZItem.SelectedItem).id;
            string ResultYM = dtpYM.Value.ToString(SystemInfo.YMFormat);
            string ResultYMA = dtpYM.Value.ToString(SystemInfo.YMFormatDB);
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
            QuerySQL = Pub.GetSQL(DBCode.DB_000404, new string[] { "4", ItemID, EmpTag, EmpNo, DepartTag, DepartID, DepartList, ResultYMA });
            SetReportDate(dispView, lblYM.Text + ": " + ResultYM);
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }

        private void InitRepVisiable()
        {
            Report.DetailGrid.Columns[3].TitleCell.Text = "";
            Report.DetailGrid.Columns[23].TitleCell.Text = "";
            for (int i = 4; i < 23; i++)
            {
                Report.DetailGrid.Columns[i].Visible = false;
                Report.DetailGrid.Columns[i].TitleCell.Text = "";
                Report.DetailGrid.Columns[i + 20].Visible = false;
                Report.DetailGrid.Columns[i + 20].TitleCell.Text = "";
            }
            Report.DetailGrid.Columns[3].TitleCell.Visible = false;
            Report.DetailGrid.Columns[23].TitleCell.Visible = false;
            Report.DetailGrid.Recordset.QuerySQL = "";
            dispView.Refresh();
        }

        private void cbbGZItem_DropDown(object sender, EventArgs e)
        {
            InitcbbGZItem();
        }
    }
}