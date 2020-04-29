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
    public partial class frmKQEmpSignCardAdd : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "KQEmpSignCardAdd";
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
            dtpTime.Value = DateTime.Now;
            LoadData();
        }

        public frmKQEmpSignCardAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
                if (SysID != "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000212, new string[] { "2", SysID }));
                    if (dr.Read())
                    {
                        txtEmpNo.Text = dr["EmpNo"].ToString();
                        txtEmpName.Text = dr["EmpName"].ToString();
                        txtDepart.Text = "[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString();
                        dtpTime.Value = Convert.ToDateTime(dr["KQDateTime"].ToString());
                        txtReason.Text = dr["Remark"].ToString();
                        dr.Close();
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

        private void GetSql(string EmpNo, string Reason, ref List<string> sql)
        {
            string tmp = "";
            string KQDate = dtpTime.Value.ToString(SystemInfo.SQLDateFMT);
            int KQTime = dtpTime.Value.Hour * 60 * 60 + dtpTime.Value.Minute * 60;
            if (SysID == "")
            {
                if (SystemInfo.DBType == 0)
                    tmp = SystemInfo.objACKQ.PKQ_KQDataSaveEx(EmpNo, dtpTime.Value, Reason);
                else
                    tmp = Pub.GetSQL(DBCode.DB_000212, new string[] { "3", EmpNo, KQDate, KQTime.ToString(),
            Reason, OprtInfo.OprtNo });
            }
            else
            {
                if (SystemInfo.DBType == 0)
                    tmp = SystemInfo.objACKQ.PKQ_KQDataSaveExU(EmpNo, dtpTime.Value, Reason, SysID);
                else
                    tmp = Pub.GetSQL(DBCode.DB_000212, new string[] { "4", KQDate, KQTime.ToString(), Reason,
          OprtInfo.OprtNo, SysID });
            }
            if (tmp != "") sql.Add(tmp);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckEmp()) return;
            string EmpNo = txtEmpNo.Text.Trim();
            string Reason = txtReason.Text.Trim();
            if (!Pub.CheckTextMaxLength(label8.Text, Reason, txtReason.MaxLength)) return;
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            bool IsError = false;
            try
            {
                if (SysID == "")
                {
                    GetSql(EmpNo, Reason, ref sql);
                    if (cardGrid.DataSource != null)
                    {
                        DataTable dtGrid = (DataTable)cardGrid.DataSource;
                        for (int i = 0; i < dtGrid.Rows.Count; i++)
                        {
                            if (dtGrid.Rows[i]["EmpNo"].ToString() == EmpNo) continue;
                            GetSql(dtGrid.Rows[i]["EmpNo"].ToString(), Reason, ref sql);
                        }
                    }
                }
                else
                {
                    GetSql(EmpNo, Reason, ref sql);
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

        private void frmKQEmpSignCardAdd_Load(object sender, EventArgs e)
        {

        }
    }
}