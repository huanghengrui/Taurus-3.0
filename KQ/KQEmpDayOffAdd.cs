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
    public partial class frmKQEmpDayOffAdd : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "KQEmpDayOffAdd";
            CreateCardGridView(cardGrid);
            IgnoreDimission = false;
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            groupBox1.Enabled = SysID == "";
            txtEmpNo.Enabled = groupBox1.Enabled;
            btnSelectEmp.Enabled = groupBox1.Enabled;
            btnSelectEmp.Visible = btnSelectEmp.Enabled;
            txtEmpName.Enabled = groupBox1.Enabled;
            txtDepart.Enabled = groupBox1.Enabled;
            toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
            dtpStart.Value = DateTime.Now.Date.AddHours(8);
            dtpEnd.Value = DateTime.Now.Date.AddHours(17).AddMinutes(30);
            LoadData();
        }

        public frmKQEmpDayOffAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            TIDAndName idn = new TIDAndName("", "");
            cbbSort.Items.Clear();
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000210, new string[] { "2" }));
                while (dr.Read())
                {
                    idn = new TIDAndName(dr["SortID"].ToString(), "[" + dr["SortID"].ToString() + "]" +
                      dr["SortName"].ToString());
                    cbbSort.Items.Add(idn);
                }
                cbbSort.SelectedIndex = 0;
                dr.Close();
                if (SysID != "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000210, new string[] { "3", SysID }));
                    if (dr.Read())
                    {
                        txtEmpNo.Text = dr["EmpNo"].ToString();
                        txtEmpName.Text = dr["EmpName"].ToString();
                        txtDepart.Text = "[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString();
                        dtpStart.Value = Convert.ToDateTime(dr["BeginTime"].ToString());
                        dtpEnd.Value = Convert.ToDateTime(dr["EndTime"].ToString());
                        txtReason.Text = dr["DayOffReason"].ToString();
                        for (int i = 0; i < cbbSort.Items.Count; i++)
                        {
                            if (((TIDAndName)cbbSort.Items[i]).id == dr["SortID"].ToString())
                            {
                                cbbSort.SelectedIndex = i;
                                break;
                            }
                        }
                    }
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

        private void GetSql(string EmpNo, string SortID, string Reason, ref List<string> sql)
        {
            string tmp = "";
            string BeginTime = dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT);
            string EndTime = dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT);
            DataTableReader dr = null;
            if (SysID == "")
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000210, new string[] { "10", EmpNo, BeginTime, EndTime }));
                if (!dr.Read())
                {
                    tmp = Pub.GetSQL(DBCode.DB_000210, new string[] { "4", EmpNo, SortID, BeginTime, EndTime, Reason,
          OprtInfo.OprtNo });
                }
                  
            }
            else
            {
                tmp = Pub.GetSQL(DBCode.DB_000210, new string[] { "5", SortID, BeginTime, EndTime, Reason,
          OprtInfo.OprtNo, SysID });
            }
            sql.Add(tmp);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckEmp()) return;
            if (dtpStart.Value > dtpEnd.Value)
            {
                dtpStart.Focus();
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorStartTimeBegreater", ""));
                return;
            }
            if (cbbSort.SelectedIndex == -1)
            {
                cbbSort.Focus();
                ShowErrorSelectCorrect(label7.Text);
                return;
            }
            string EmpNo = txtEmpNo.Text.Trim();
            string SortID = ((TIDAndName)cbbSort.Items[cbbSort.SelectedIndex]).id;
            string Reason = txtReason.Text.Trim();
            if (!Pub.CheckTextMaxLength(label8.Text, Reason, txtReason.MaxLength)) return;
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            bool IsError = false;
            try
            {
                if (SysID == "")
                {
                    if (EmpNo != "")
                        GetSql(EmpNo, SortID, Reason, ref sql);
                    if (cardGrid.DataSource != null)
                    {
                        DataTable dtGrid = (DataTable)cardGrid.DataSource;
                        for (int i = 0; i < dtGrid.Rows.Count; i++)
                        {
                            if (dtGrid.Rows[i]["EmpNo"].ToString() == EmpNo) continue;
                            GetSql(dtGrid.Rows[i]["EmpNo"].ToString(), SortID, Reason, ref sql);
                        }
                    }
                }
                else
                {
                    GetSql(EmpNo, SortID, Reason, ref sql);
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return;
            if (SystemInfo.db.ExecSQL(sql) != 0) return;
            SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
            //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp(IgnoreDimission);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmpNo.Text = frm.EmpNo;
                txtEmpNo_Leave(null, null);
            }
        }

        private void txtEmpNo_Leave(object sender, EventArgs e)
        {
            txtEmpNo.Tag = "";
            txtEmpName.Text = "";
            txtDepart.Text = "";
            if (txtEmpNo.Text.Trim() != "")
            {
                string EmpName = "";
                string CardNo10 = "";
                string CardNo81 = "";
                string CardNo82 = "";
                string DepartID = "";
                string DepartName = "";
                if (SystemInfo.db.GetEmpInfoCard(txtEmpNo.Text.Trim(), ref EmpName, ref CardNo10, ref CardNo81,
                  ref CardNo82, ref DepartID, ref DepartName))
                {
                    txtEmpName.Text = EmpName;
                    txtDepart.Text = "[" + DepartID + "]" + DepartName;
                }
                else
                {
                    txtEmpNo.Text = "";
                    txtEmpName.Text = "";
                    txtDepart.Text = "";
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
                }
            }
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ((DataTable)cardGrid.DataSource).Clear();
            cardGrid.DataSource = null;
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
        }

        private bool CheckEmp()
        {
            if (txtEmpNo.Text.Trim() == "" && cardGrid.DataSource == null)
            {
                txtEmpNo.Focus();
                ShowErrorEnterCorrect(label2.Text);
                return false;
            }
            string EmpName = "";
            string CardNo10 = "";
            string CardNo81 = "";
            string CardNo82 = "";
            string DepartID = "";
            string DepartName = "";
            if (!SystemInfo.db.GetEmpInfoCard(txtEmpNo.Text.Trim(), ref EmpName, ref CardNo10, ref CardNo81,
              ref CardNo82, ref DepartID, ref DepartName) && cardGrid.DataSource == null)
            {
                txtEmpNo.Focus();
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
                return false;
            }
            return true;
        }

        private void cardGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblMsg.Text = string.Format(Pub.GetResText(formCode, "MsgSelectNo", ""), cardGrid.Rows.Count);
        }
    }
}