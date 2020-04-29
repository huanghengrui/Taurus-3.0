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
    public partial class frmMJSeaPowerAdd : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "MJPowerAdd";
            macGrid.Columns.Clear();
            AddColumn(macGrid, 3, "SelectCheck", false, false, 1, 60);
            AddColumn(macGrid, 0, "MacSN", false, false, 0, 100);
            AddColumn(macGrid, 0, "MacDesc", false, false, 0, 100);
            CreateCardGridView(cardGrid);
            cardGrid.Columns[1].Visible = false;
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
            toolTip.SetToolTip(txtQuickSearchMac, string.Format(Pub.GetResText(formCode, "MsgFindMacSN", ""),
          Pub.GetResText(formCode, "MacSN", ""),
          Pub.GetResText(formCode, "MacDesc", "")));
            txtEmpName.Enabled = false;
            txtDepartName.Enabled = false;
            LoadData();
            KeyPreview = true;
            btnSelectStartDate.Text = "...";
            btnSelectEndDate.Text = "...";
        }

        public frmMJSeaPowerAdd(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }
        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            ChangeAllSelectStatus(e.CheckedState);
        }

        private void ChangeAllSelectStatus(bool IsChecked)
        {
            int count = macGrid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)macGrid.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == !IsChecked)
                {
                    macGrid.BeginEdit(true);
                    checkCell.Value = IsChecked;
                    macGrid.EndEdit();
                }
                else
                {
                    continue;
                }
            }
        }
        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp(IgnoreDimission);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmpNo.Text = frm.EmpNo;
                txtEmpName.Text = frm.EmpName;
                txtDepartName.Text = frm.DepartName;
            }
        }

        private void LoadData()
        {
           
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "9" }));
                int rowindex = 0;
                while (dr.Read())
                {
                    macGrid.Rows.Add();
                    macGrid[0, rowindex].Value = true;
                    macGrid[1, rowindex].Value = dr["MacSN"].ToString();
                    macGrid[2, rowindex].Value = dr["MacDesc"].ToString();
                    rowindex++;
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

        private void txtEmpNo_Leave(object sender, EventArgs e)
        {
            txtEmpNo.Tag = "";
            txtEmpName.Text = "";
            txtDepartName.Text = "";
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
                    txtDepartName.Text = "[" + DepartID + "]" + DepartName;
                }
                else
                {
                    txtEmpNo.Text = "";
                    txtEmpName.Text = "";
                    txtDepartName.Text = "";
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtEmpNo.Text.Trim() == "" && cardGrid.DataSource == null)
            {
                txtEmpNo.Focus();
                ShowErrorEnterCorrect(label2.Text);
                return;
            }
         
            string EmpSysID = txtEmpNo.Text;
           
            string StartDate = "NULL";
            string EndDate = "NULL";
            DateTime StartDT;
            DateTime endDT;
            if (DateTime.TryParse(txtStartDate.Text, out StartDT))
                StartDate = "'" + StartDT.ToString(SystemInfo.SQLDateFMT) + "'";
            if (DateTime.TryParse(txtEndDate.Text, out endDT))
                EndDate = "'" + endDT.ToString(SystemInfo.SQLDateFMT) + "'";

            if (StartDT > endDT)
            {
                Pub.MessageBoxShow(Pub.GetResText("BaseDate", "Error001", ""));
                return;
            }
            List<string> macList = new List<string>();
            for (int i = 0; i < macGrid.RowCount; i++)
            {
                if (Pub.ValueToBool(macGrid[0, i].EditedFormattedValue))
                {
                    macList.Add(macGrid[1, i].Value.ToString());
                    // macList.Add(macGrid[2, i].Value.ToString());
                }
            }
            if (macList.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
                return;
            }
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            bool IsError = false;
            string MacSN;
            try
            {
                for (int i = 0; i < macList.Count; i++)
                {
                    MacSN = macList[i];
                    if(EmpSysID != "")
                    {
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "513", MacSN, EmpSysID }));
                        if (dr.Read())
                            sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "515", MacSN, EmpSysID, OprtInfo.OprtNo, StartDate, EndDate }));
                        else
                            sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "514", MacSN, EmpSysID, OprtInfo.OprtNo, StartDate, EndDate }));
                        dr.Close();
                    }
                    if (cardGrid.DataSource != null)
                    {
                        DataTable dtGrid = (DataTable)cardGrid.DataSource;
                        string EmpNo;
                        for (int j = 0; j < dtGrid.Rows.Count; j++)
                        {
                            EmpNo = dtGrid.Rows[j]["EmpNo"].ToString();
                            if (EmpNo == EmpSysID) continue;
                            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "513", MacSN, EmpNo }));
                            if (dr.Read())
                                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "515", MacSN, EmpNo,OprtInfo.OprtNo, StartDate, EndDate }));
                            else
                                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "514", MacSN, EmpNo,OprtInfo.OprtNo, StartDate, EndDate }));
                            dr.Close();
                        }
                    }
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

        private void cardGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblMsg.Text = string.Format(Pub.GetResText(formCode, "MsgSelectNo", ""), cardGrid.Rows.Count);
        }

        private void btnSelectStartDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtStartDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtStartDate.Text = d.ToShortDateString();
        }

        private void btnSelectEndDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtEndDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtEndDate.Text = d.ToShortDateString();
        }

        private void txtQuickSearchMac_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalMac(txtQuickSearchMac, e, macGrid);
        }
    }
}