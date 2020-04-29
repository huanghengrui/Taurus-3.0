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
    public partial class frmKQRuleCalcAdd : frmBaseDialog
    {
        private bool IsAdd = false;
        private bool IsFirst = true;

        protected override void InitForm()
        {
            formCode = "KQRuleCalcAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            cbbOvertimeSort.Enabled = false;
            cbbSort.Items.Clear();
            cbbSort.Items.Add(Pub.GetResText(formCode, "KQUsual", ""));
            cbbSort.Items.Add(Pub.GetResText(formCode, "KQOvertime", ""));
            cbbSort.Items.Add(Pub.GetResText(formCode, "KQLeave", ""));
            cbbSort.SelectedIndex = 0;
            cbbOvertimeSort.Items.Clear();
            cbbOvertimeSort.Items.Add(Pub.GetResText(formCode, "Usual", ""));
            cbbOvertimeSort.Items.Add(Pub.GetResText(formCode, "Weekend", ""));
            cbbOvertimeSort.Items.Add(Pub.GetResText(formCode, "Holiday", ""));
            cbbOvertimeSort.SelectedIndex = -1;
            IsAdd = SysID == "";
            IsFirst = false;
            LoadData();
            lbCalc.Text = string.Format(Pub.GetResText("", "lbCalc",""), label5.Text, label6.Text);
            if (IsAdd) InitSortID(cbbSort.SelectedIndex);
            if (!SystemInfo.AllowAdjust)
            {
                label4.Enabled = false;
                label4.Visible = false;
                txtStart.Enabled = false;
                txtStart.Visible = false;
                label5.Enabled = false;
                label5.Visible = false;
                txtTune.Enabled = false;
                txtTune.Visible = false;
                label6.Enabled = false;
                label6.Visible = false;
                txtInteger.Enabled = false;
                txtInteger.Visible = false;
                Height -= 25;
            }
        }

        public frmKQRuleCalcAdd(string title, string CurrentTool, string GUID)
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
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000201, new string[] { "4", SysID }));
                    if (dr.Read())
                    {
                        if (dr["CalcTypeID"].ToString() == "1")
                        {
                            cbbOvertimeSort.Enabled = true;
                            cbbOvertimeSort.SelectedIndex = Convert.ToInt32(dr["OvertimeTypeID"].ToString()) - 1;
                        }
                        else
                        {
                            cbbOvertimeSort.SelectedIndex = -1;
                            cbbOvertimeSort.Enabled = false;
                        }
                        cbbSort.SelectedIndex = Convert.ToInt32(dr["CalcTypeID"].ToString());
                        txtSortID.Text = dr["SortID"].ToString();
                        txtSortName.Text = dr["SortName"].ToString();
                        txtOvertimeRate.Text = dr["OvertimeRate"].ToString();
                        if (SystemInfo.AllowAdjust)
                        {
                            txtStart.Text = dr["Start"].ToString();
                            txtTune.Text = dr["Tune"].ToString();
                            txtInteger.Text = dr["Integer"].ToString();
                        }
                        cbbSort.Enabled = false;
                        txtSortID.Enabled = false;
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
            cbbSort_SelectedIndexChanged(null, null);
        }

        private void cbbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSort.SelectedIndex != 1)
            {
                cbbOvertimeSort.Enabled = false;
                cbbOvertimeSort.SelectedIndex = -1;
                txtOvertimeRate.Enabled = false;
                label8.Enabled = false;
            }
            else
            {
                cbbOvertimeSort.Enabled = true;
                if (cbbOvertimeSort.SelectedIndex == -1) cbbOvertimeSort.SelectedIndex = 0;
                txtOvertimeRate.Enabled = true;
                label8.Enabled = true;
            }
            InitSortID(cbbSort.SelectedIndex);
        }

        private void InitSortID(int index)
        {
            if (!IsAdd || IsFirst) return;
            DataTableReader dr = null;
            string tmp = "A0" + index.ToString() + "1";
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000201, new string[] { "7", index.ToString() }));
                if (dr.Read())
                {
                    int x = Convert.ToInt32(dr[0].ToString().Substring(3)) + 1;
                    if (x > 9)
                    {
                        Pub.MessageBoxShow(cbbSort.Text + Pub.GetResText(formCode, "Error001", ""));
                        tmp = "";
                        btnOk.Enabled = false;
                    }
                    else
                        tmp = "A0" + index.ToString() + x.ToString();
                }
                txtSortID.Text = tmp;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            string RSortID = txtSortID.Text.Trim();
            string RSortName = txtSortName.Text.Trim();
            string RCalcID = cbbSort.SelectedIndex.ToString();
            string RCalcName = cbbSort.Text.Trim();
            string ROverID = (cbbOvertimeSort.SelectedIndex + 1).ToString();
            string ROverName = cbbOvertimeSort.Text.Trim();
            if (cbbOvertimeSort.SelectedIndex == -1)
            {
                ROverID = "NULL";
                ROverName = "";
            }
            string ROvertimeRate = txtOvertimeRate.Text.Trim();
            double doubleNo;
            if (cbbSort.SelectedIndex == 1)
            {
                if (ROvertimeRate == "" || double.TryParse(ROvertimeRate, out doubleNo) == false || doubleNo <= 0)
                {
                    ShowErrorEnterCorrect(label8.Text);
                    return;
                }
            }
            else
            {
                ROvertimeRate = "NULL";
            }
            string RStart = "";
            string RTune = "";
            string RInteger = "";
            if (SystemInfo.AllowAdjust)
            {
                RStart = txtStart.Text.Trim();
                RTune = txtTune.Text.Trim();
                RInteger = txtInteger.Text.Trim();
                int intNo = 0;
                if ((RStart != "" && !int.TryParse(RStart, out intNo)) || intNo < 0)
                {
                    ShowErrorEnterCorrect(label4.Text);
                    return;
                }
                if ((RTune != "" && !int.TryParse(RTune, out intNo)) || intNo < 0)
                {
                    ShowErrorEnterCorrect(label5.Text);
                    return;
                }
                if ((RInteger != "" && !int.TryParse(RInteger, out intNo)) || intNo < 0)
                {
                    ShowErrorEnterCorrect(label6.Text);
                    return;
                }
            }
            if (RStart == "") RStart = "NULL";
            if (RTune == "") RTune = "NULL";
            if (RInteger == "") RInteger = "NULL";
            DataTableReader dr = null;
            bool IsOk = true;
            string sql = "";
            try
            {
                if (IsAdd)
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000201, new string[] { "4", RSortID }));
                    if (dr.Read())
                    {
                        txtSortID.Focus();
                        ShowErrorCannotRepeated(label2.Text);
                        IsOk = false;
                    }
                    dr.Close();
                    if (IsOk)
                    {
                        sql = Pub.GetSQL(DBCode.DB_000201, new string[] { "5", RSortID, RSortName, RCalcID, RCalcName, ROverID,
              ROverName, RStart, RTune, RInteger, "0", ROvertimeRate, "0", "0" });
                    }
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000201, new string[] { "6", RSortName, RCalcID, RCalcName, ROverID, ROverName,
            RStart, RTune, RInteger, "0", ROvertimeRate, "0", "0", SysID });
                }
                if (IsOk) SystemInfo.db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                IsOk = false;
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsOk)
            {
                SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
                //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}