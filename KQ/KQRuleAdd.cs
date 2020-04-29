using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmKQRuleAdd : frmBaseDialog
    {
        private bool IsAdd = false;
        protected override void InitForm()
        {
            formCode = "KQRuleAdd";
            txtAhead.Enabled = false;
            txtdefer.Enabled = false;
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            Label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
            IsAdd = SysID == "";
            SetTextboxNumber(txtlateignore);
            SetTextboxNumber(txtleaveignore);
            SetTextboxNumber(txtlateH);
            SetTextboxNumber(txtleaveH);
            SetTextboxNumber(txtrepeatlimit);
            SetTextboxNumber(txtlateleaveM);
            SetTextboxNumber(txtAhead);
            SetTextboxNumber(txtdefer);
            SetTextboxNumber(txtRestDays);
            if (SysID != "") LoadData();
        }

        public frmKQRuleAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            txtRuleID.Enabled = false;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000200, new string[] { "6", SysID }));
                if (dr.Read())
                {
                    txtlateignore.Text = dr["RuleLateIgnore"].ToString();
                    txtleaveignore.Text = dr["RuleLeaveIgnore"].ToString();
                    txtlateH.Text = dr["RuleLateHrs"].ToString();
                    txtleaveH.Text = dr["RuleLeaveHrs"].ToString();
                    txtrepeatlimit.Text = dr["RuleDupLimit"].ToString();
                    txtlateleaveM.Text = dr["RuleLateLeaveCalHrs"].ToString();
                    txtAhead.Text = dr["RuleAheadMins"].ToString();
                    txtdefer.Text = dr["RuleDeferMins"].ToString();
                    txtRuleID.Text = dr["RuleID"].ToString();
                    txtRuleName.Text = dr["RuleName"].ToString();
                    CHKdefer.Checked = Pub.ValueToBool(dr["RuleDeferHrs"].ToString());
                    CHKAhead.Checked = Pub.ValueToBool(dr["RuleAheadHrs"].ToString());
                    CHKlate.Checked = Pub.ValueToBool(dr["RuleReadlate"].ToString());
                    CHKleave.Checked = Pub.ValueToBool(dr["RuleReadleave"].ToString());
                    CHKworktime.Checked = Pub.ValueToBool(dr["RuleReadWorkHrs"].ToString());
                    chkRuleSunday.Checked = Pub.ValueToBool(dr["RuleSunday"].ToString());
                    chkRuleMonday.Checked = Pub.ValueToBool(dr["RuleMonday"].ToString());
                    chkRuleTuesday.Checked = Pub.ValueToBool(dr["RuleTuesday"].ToString());
                    chkRuleWednesday.Checked = Pub.ValueToBool(dr["RuleWednesday"].ToString());
                    chkRuleThursday.Checked = Pub.ValueToBool(dr["RuleThursday"].ToString());
                    chkRuleFriday.Checked = Pub.ValueToBool(dr["RuleFriday"].ToString());
                    chkRuleSaturday.Checked = Pub.ValueToBool(dr["RuleSaturday"].ToString()); 
                    chkNoRule.Checked = Pub.ValueToBool(dr["RuleNoRule"].ToString());
                    txtRestDays.Text = dr["RuleRestDays"].ToString();
                    CHKHeadAndTail.Checked = Pub.ValueToBool(dr["RuleHeadAndTail"].ToString());
                    CHKLeaveOvertime.Checked = Pub.ValueToBool(dr["RuleLeaveOvertime"].ToString());
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            string RuleNo = txtRuleID.Text.Trim();
            if (RuleNo == "")
            {
                txtRuleID.Focus();
                ShowErrorEnterCorrect(Label1.Text);
                return;
            }
            string RuleName = txtRuleName.Text.Trim();
            if (RuleName == "")
            {
                txtRuleName.Focus();
                ShowErrorEnterCorrect(label2.Text);
                return;
            }
            string Rlateignore = Convert.ToInt32(txtlateignore.Text.Trim()).ToString();
            string Rleaveignore = Convert.ToInt32(txtleaveignore.Text.Trim()).ToString();
            string RlateH = Convert.ToInt32(txtlateH.Text.Trim()).ToString();
            string RleaveH = Convert.ToInt32(txtleaveH.Text.Trim()).ToString();
            string Rrepeatlimit = Convert.ToInt32(txtrepeatlimit.Text.Trim()).ToString();
            string RlateleaveM = Convert.ToInt32(txtlateleaveM.Text.Trim()).ToString();
            string RAhead = Convert.ToInt32(txtAhead.Text.Trim()).ToString();
            string RCHKAhead = Convert.ToByte(CHKAhead.Checked).ToString();
            string Rdefer = Convert.ToInt32(txtdefer.Text.Trim()).ToString();
            string RCHKdefer = Convert.ToByte(CHKdefer.Checked).ToString();
            string RReadlate = Convert.ToByte(CHKlate.Checked).ToString();
            string RReadleave = Convert.ToByte(CHKleave.Checked).ToString();
            string RReadWorkHrs = Convert.ToByte(CHKworktime.Checked).ToString();
            string RsmallN = "";
            string RbigN = "";
            if (RsmallN == ":") RsmallN = "";
            if (RbigN == ":") RbigN = "";
            string RuleSunday = Convert.ToByte(chkRuleSunday.Checked).ToString();
            string RuleMonday = Convert.ToByte(chkRuleMonday.Checked).ToString();
            string RuleTuesday = Convert.ToByte(chkRuleTuesday.Checked).ToString();
            string RuleWednesday = Convert.ToByte(chkRuleWednesday.Checked).ToString();
            string RuleThursday = Convert.ToByte(chkRuleThursday.Checked).ToString();
            string RuleFriday = Convert.ToByte(chkRuleFriday.Checked).ToString();
            string RuleSaturday = Convert.ToByte(chkRuleSaturday.Checked).ToString();
            string RNoRule = Convert.ToByte(chkNoRule.Checked).ToString();
            string RRestDays = Convert.ToInt32(txtRestDays.Text.ToString()).ToString();
            string RuleHeadAndTail = Convert.ToByte(CHKHeadAndTail.Checked).ToString();
            string RuleLeaveOvertime = Convert.ToByte(CHKLeaveOvertime.Checked).ToString();
            DataTableReader dr = null;
            bool IsOk = true;
            string sql = "";
            try
            {
                if (IsAdd)
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000200, new string[] { "6", RuleNo }));
                    if (dr.Read())
                    {
                        txtRuleID.Focus();
                        ShowErrorCannotRepeated(Label1.Text);
                        IsOk = false;
                    }
                    dr.Close();
                    if (IsOk)
                    {
                        sql = Pub.GetSQL(DBCode.DB_000200, new string[] { "7", RuleNo, RuleName, Rlateignore, Rleaveignore,
              Rrepeatlimit, RlateleaveM, RlateH, RleaveH, RCHKAhead, RAhead, RCHKdefer, Rdefer, RReadlate,
              RReadleave, RReadWorkHrs, RuleSunday, RuleMonday, RuleTuesday, RuleWednesday, RuleThursday, RuleFriday,
              RuleSaturday, RNoRule, RRestDays, RsmallN, RbigN, RuleHeadAndTail,RuleLeaveOvertime });
                    }
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000200, new string[] { "8", RuleName, Rlateignore, Rleaveignore, Rrepeatlimit,
            RlateleaveM, RlateH, RleaveH, RCHKAhead, RAhead, RCHKdefer, Rdefer, RReadlate, RReadleave, RReadWorkHrs,
            RuleSunday, RuleMonday, RuleTuesday, RuleWednesday, RuleThursday, RuleFriday, RuleSaturday, RNoRule,
            RRestDays, RsmallN, RbigN, RuleHeadAndTail,RuleLeaveOvertime, SysID });
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

        private void CHKearly_CheckedChanged(object sender, EventArgs e)
        {
            txtAhead.Enabled = !txtAhead.Enabled;
            if (!txtAhead.Enabled) txtAhead.Text = "0";
        }

        private void CHKdefer_CheckedChanged(object sender, EventArgs e)
        {
            txtdefer.Enabled = !txtdefer.Enabled;
            if (!txtdefer.Enabled) txtdefer.Text = "0";
        }
    }
}