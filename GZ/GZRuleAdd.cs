using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmGZRuleAdd : frmBaseDialog
    {
        private bool IsAdd = false;
        private List<Object> func = new List<Object>();
        private Regex reg = new Regex(@"^\d|\.$");
        private Regex isnumber = new Regex(@"^\d+(\.)?\d*$");
        private Regex f = new Regex(@"[\+\-\*/\(\)]{1}");
        protected override void InitForm()
        {
            formCode = "GZRuleAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            IsAdd = SysID == "";
            cbbmode.Items.Add(Pub.GetResText(formCode, "modeOut", ""));
            cbbmode.Items.Add(Pub.GetResText(formCode, "modeIn", ""));
            cbbmode.SelectedIndex = 0;
            SetTextboxNumber(txtGZRuleID);
            initListBox();
            txtGZRuleCash.Enter += TextBoxCurrency_Enter;
            txtGZRuleCash.Leave += TextBoxCurrency_Leave;
            txtGZRuleCash.Text = SystemInfo.CurrencySymbol + "0.00";
            if (SysID != "") LoadData();
        }

        public frmGZRuleAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void initListBox()
        {
            TIDAndName item = new TIDAndName("EmpGZ", Pub.GetResText(formCode, "EmpGZ", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("MustDaysM", Pub.GetResText(formCode, "MustDays", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("WorkDays", Pub.GetResText(formCode, "WorkDays", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("SunDays", Pub.GetResText(formCode, "SunDays", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("HdDays", Pub.GetResText(formCode, "HdDays", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("AbsentDays", Pub.GetResText(formCode, "AbsentDays", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("WorkHrs", Pub.GetResText(formCode, "WorkHrs", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("LateMins", Pub.GetResText(formCode, "LateMins", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("LateCount", Pub.GetResText(formCode, "LateCount", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("LeaveMins", Pub.GetResText(formCode, "LeaveMins", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("LeaveCount", Pub.GetResText(formCode, "LeaveCount", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("OtHrs", Pub.GetResText(formCode, "OtHrs", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("SunHrs", Pub.GetResText(formCode, "SunHrs", ""));
            ListGZItem.Items.Add(item);
            item = new TIDAndName("HdHrs", Pub.GetResText(formCode, "HdHrs", ""));
            ListGZItem.Items.Add(item);
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000400, new string[] { "0" }));
                while (dr.Read())
                {
                    int num = Convert.ToInt32(dr["SortID"].ToString().Substring(3)) - 1;
                    item = new TIDAndName("Hrs1" + num, dr["SortName"].ToString());
                    ListGZItem.Items.Add(item);
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

        private void LoadData()
        {
            DataTableReader dr = null;
            txtGZRuleID.Enabled = false;
            cbbmode.Enabled = false;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000400, new string[] { "2", SysID }));
                if (dr.Read())
                {
                    txtGZRuleID.Text = dr["RuleID"].ToString();
                    txtGZRuleName.Text = dr["RuleName"].ToString();
                    cbbmode.SelectedIndex = Convert.ToInt32(dr["RuleMode"]);
                    chkIsFunction.Checked = Pub.ValueToBool(dr["IsFunction"]);
                    double m = 0;
                    double.TryParse(dr["RuleCash"].ToString(), out m);
                    txtGZRuleCash.Text = m.ToString(SystemInfo.CurrencySymbol + "0.00");
                    getfunction(dr["RuleFunction"].ToString());
                }
                showtxtWindow();
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

        private void getfunction(string RuleFunction)
        {
            string value = "";
            Object item;
            bool b = f.IsMatch(RuleFunction);
            MatchCollection m = f.Matches(RuleFunction);
            for (int i = 0; i < m.Count; i++)
            {
                if (i == 0) value = RuleFunction.Substring(0, m[i].Index);
                else value = RuleFunction.Substring(m[i - 1].Index + 1, m[i].Index - m[i - 1].Index - 1);
                if (isnumber.IsMatch(value)) func.Add(value);
                else
                {
                    for (int j = 0; j < ListGZItem.Items.Count; j++)
                    {
                        if (value == ((TIDAndName)ListGZItem.Items[j]).id)
                        {
                            item = ListGZItem.Items[j];
                            func.Add(item);
                            break;
                        }
                    }
                }
                func.Add(m[i].Value);
                if (i + 1 == m.Count)
                {
                    value = RuleFunction.Substring(m[i].Index + 1);
                    if (isnumber.IsMatch(value)) func.Add(value);
                    else
                    {
                        for (int j = 0; j < ListGZItem.Items.Count; j++)
                        {
                            if (value == ((TIDAndName)ListGZItem.Items[j]).id)
                            {
                                item = ListGZItem.Items[j];
                                func.Add(item);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string RuleNo = txtGZRuleID.Text.Trim();
            string RuleName = txtGZRuleName.Text.Trim();
            string RuleMode = cbbmode.SelectedIndex.ToString();
            string RuleCash = CurrencyToStringEx(txtGZRuleCash.Text.Trim());
            string IsFunction = Convert.ToByte(chkIsFunction.Checked).ToString();
            string RuleFunction = "";
            string VRuleFunction = "";
            for (int i = 0; i < func.Count; i++)
            {
                //if (typeof(TIDAndName) == func[i].GetType())
                if (f.IsMatch(func[i].ToString()) || isnumber.IsMatch(func[i].ToString()))
                    RuleFunction += func[i].ToString();
                else RuleFunction += ((TIDAndName)func[i]).id;
                VRuleFunction += func[i].ToString();
            }
            if (RuleNo == "")
            {
                txtGZRuleID.Focus();
                ShowErrorEnterCorrect(lblGZRuleID.Text);
                return;
            }
            if (RuleName == "")
            {
                txtGZRuleName.Focus();
                ShowErrorEnterCorrect(lblGZRuleName.Text);
                return;
            }
            if (chkIsFunction.Checked && !checkIsOK())
            {
                return;
            }
            if (RuleCash == "")
            {
                RuleCash = "0.00";
            }
            if (!Pub.IsNumeric(RuleCash))
            {
                ShowErrorEnterCorrect(lblGZRuleCash.Text);
                return;
            }
            if(chkIsFunction.Checked)
            {
                RuleCash = "0.00";
            }
            else
            {
                VRuleFunction = "";
                RuleFunction = "";
            }
            DataTableReader dr = null;
            bool IsOk = true;
            string sql = "";
            try
            {
                if (IsAdd)
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000400, new string[] { "2", RuleNo }));
                    if (dr.Read())
                    {
                        txtGZRuleID.Focus();
                        ShowErrorCannotRepeated(lblGZRuleID.Text);
                        IsOk = false;
                    }
                    dr.Close();
                    if (IsOk)
                    {
                        sql = Pub.GetSQL(DBCode.DB_000400, new string[] { "3", RuleNo, RuleName, RuleMode, IsFunction,
              RuleCash, RuleFunction, VRuleFunction });
                    }
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000400, new string[] { "4", RuleName, RuleMode, IsFunction, RuleCash,
            RuleFunction, VRuleFunction, RuleNo });
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

        private void btKeyBorad_Click(object sender, EventArgs e)
        {
            ButtonX bt = (ButtonX)sender;
            if (bt.Text == "¡û")
            {
                if (func.Count == 0) return;
                func.RemoveAt(func.Count - 1);
            }
            else if (bt.Text == "C")
            {
                func.Clear();
            }
            else if (reg.IsMatch(bt.Text))
            {
                if (func.Count == 0 || !reg.IsMatch(func[func.Count - 1].ToString())) func.Add(bt.Text);
                else func[func.Count - 1] = func[func.Count - 1] + bt.Text;
            }
            else
            {
                func.Add(bt.Text);
            }
            showtxtWindow();
        }

        private void showtxtWindow()
        {
            txtWindow.Clear();
            for (int i = 0; i < func.Count; i++)
            {
                if (i > 0 && !isnumber.IsMatch(func[i].ToString()) && isnumber.IsMatch(func[i - 1].ToString()))
                    txtWindow.AppendText(" ");
                txtWindow.AppendText(func[i].ToString());
                if (!isnumber.IsMatch(func[i].ToString())) txtWindow.AppendText(" ");
            }
        }

        private void ListGZItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListGZItem.SelectedItem == null) return;
            func.Add(ListGZItem.SelectedItem);
            showtxtWindow();
        }

        private void chkIsFunction_CheckedChanged(object sender, EventArgs e)
        {
            gbFunction.Enabled = chkIsFunction.Checked;
            txtGZRuleCash.Enabled = !chkIsFunction.Checked;
        }

        private void btcheck_Click(object sender, EventArgs e)
        {
            checkIsOK();
        }

        private bool checkIsOK()
        {
            string RuleFunction = "";
            string sql = "";
            bool IsOk = true;
            for (int i = 0; i < func.Count; i++)
            {
                if (f.IsMatch(func[i].ToString()) || isnumber.IsMatch(func[i].ToString()))
                {
                    double doubleNo;
                    if (double.TryParse(func[i].ToString(), out doubleNo) && doubleNo == 0)
                    {
                        if (i > 0 && func[i - 1].ToString() == "/")
                        {
                            IsOk = false;
                            break;
                        }
                    }
                    RuleFunction += func[i].ToString();
                }
                else RuleFunction += ((TIDAndName)func[i]).id;
            }
            if (IsOk)
            {
                try
                {
                    sql = Pub.GetSQL(DBCode.DB_000400, new string[] { "6" });
                    sql = string.Format(sql, RuleFunction);
                    SystemInfo.db.ExecSQL(sql);
                }
                catch
                {
                    IsOk = false;
                    //Pub.ShowErrorMsg(ex, sql);
                }
            }
            if (IsOk)
                Pub.MessageBoxShow(Pub.GetResText(formCode, "checkOK", ""), MessageBoxIcon.Information);
            else
                Pub.MessageBoxShow(Pub.GetResText(formCode, "checkErr", ""));
            return IsOk;
        }
    }
}