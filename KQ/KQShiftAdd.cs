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
    public partial class frmKQShiftAdd : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "KQShiftAdd";
            base.InitForm();
            InitDepartTreeView(tvDepart);
            this.Text = Title + "[" + CurrentOprt + "]";
            MaskedTextBox txtSignin;
            MaskedTextBox txtSignout;
            TextBox txtAhead;
            TextBox txtDefer;
            for (int No = 1; No <= 5; No++)
            {
                txtSignin = (MaskedTextBox)this.Controls["txtSignin" + No.ToString()];
                txtSignout = (MaskedTextBox)this.Controls["txtSignout" + No.ToString()];
                txtSignin.Text = "00:00";
                txtSignout.Text = "00:00";
                txtAhead = (TextBox)this.Controls["txtAhead" + No.ToString()];
                txtDefer = (TextBox)this.Controls["txtDefer" + No.ToString()];
                SetTextboxNumber(txtAhead);
                SetTextboxNumber(txtDefer);
            }
            LoadData();
        }

        public frmKQShiftAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void SetNodeChecked(TreeNode nodes, string DepartID)
        {
            string node = "";
            node = nodes.Text.Substring(node.IndexOf('[') + 2);
            node = node.Remove(node.LastIndexOf(']'));
            if (node == DepartID)
            {
                nodes.Checked = true;
                return;
            }
            for (int i = 0; i < nodes.Nodes.Count; i++)
            {
                SetNodeChecked(nodes.Nodes[i], DepartID);
            }
        }

        private void LoadData()
        {
            TIDAndName idn = new TIDAndName("", "");
            cbbSort1.Items.Clear();
            cbbSort2.Items.Clear();
            cbbSort3.Items.Clear();
            cbbSort4.Items.Clear();
            cbbSort5.Items.Clear();
            idn = new TIDAndName("", "");
            cbbSort2.Items.Add(idn);
            cbbSort3.Items.Add(idn);
            cbbSort4.Items.Add(idn);
            cbbSort5.Items.Add(idn);
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "2" }));
                while (dr.Read())
                {
                    idn = new TIDAndName(dr["SortID"].ToString(), "[" + dr["SortID"].ToString() + "]" +
                      dr["SortName"].ToString());
                    cbbSort1.Items.Add(idn);
                    cbbSort2.Items.Add(idn);
                    cbbSort3.Items.Add(idn);
                    cbbSort4.Items.Add(idn);
                    cbbSort5.Items.Add(idn);
                }
                cbbSort1.SelectedIndex = 0;
                cbbSort2.SelectedIndex = 0;
                cbbSort3.SelectedIndex = 0;
                cbbSort4.SelectedIndex = 0;
                cbbSort5.SelectedIndex = 0;
                dr.Close();
                if (SysID != "")
                {
                    txtShiftID.Enabled = false;
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "3", SysID }));
                    if (dr.Read())
                    {
                        txtShiftID.Text = dr["ShiftID"].ToString();
                        txtShiftName.Text = dr["ShiftName"].ToString();
                        chkIsAuto.Checked = Pub.ValueToBool(dr["IsAuto"].ToString());
                        TextBox txtAhead;
                        TextBox txtDefer;
                        MaskedTextBox txtSignin;
                        MaskedTextBox txtSignout;
                        CheckBox chkSignin;
                        CheckBox chkSignout;
                        CheckBox chkDrift;
                        ComboBox cbbSort;
                        string s;
                        for (int No = 1; No <= 5; No++)
                        {
                            txtAhead = (TextBox)this.Controls["txtAhead" + No.ToString()];
                            txtDefer = (TextBox)this.Controls["txtDefer" + No.ToString()];
                            txtSignin = (MaskedTextBox)this.Controls["txtSignin" + No.ToString()];
                            txtSignout = (MaskedTextBox)this.Controls["txtSignout" + No.ToString()];
                            chkSignin = (CheckBox)this.Controls["chkSignin" + No.ToString()];
                            chkSignout = (CheckBox)this.Controls["chkSignout" + No.ToString()];
                            chkDrift = (CheckBox)this.Controls["chkDrift" + No.ToString()];
                            cbbSort = (ComboBox)this.Controls["cbbSort" + No.ToString()];
                            chkDrift.Checked = Pub.ValueToBool(dr["Drift" + No.ToString()].ToString());
                            chkSignin.Checked = Pub.ValueToBool(dr["Signin" + No.ToString()].ToString());
                            chkSignout.Checked = Pub.ValueToBool(dr["Signout" + No.ToString()].ToString());
                            txtAhead.Text = dr["ShiftAhead" + No.ToString()].ToString();
                            txtDefer.Text = dr["ShiftDefer" + No.ToString()].ToString();
                            s = dr["SigninTime" + No.ToString()].ToString();
                            if (s == "") s = "00:00";
                            txtSignin.Text = s;
                            s = dr["SignoutTime" + No.ToString()].ToString();
                            if (s == "") s = "00:00";
                            txtSignout.Text = s;
                            for (int i = 0; i < cbbSort.Items.Count; i++)
                            {
                                if (((TIDAndName)cbbSort.Items[i]).id == dr["SortID" + No.ToString()].ToString())
                                {
                                    cbbSort.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                        dr.Close();
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "4", txtShiftID.Text }));
                        while (dr.Read())
                        {
                            for (int i = 0; i < tvDepart.Nodes.Count; i++)
                                SetNodeChecked(tvDepart.Nodes[i], dr["DepartID"].ToString());
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

        private void GetNodeSql(TreeNode nodes, string ShiftID, ref List<string> sql)
        {
            string node = "";
            node = nodes.Text.Substring(node.IndexOf('[') + 2);
            node = node.Remove(node.LastIndexOf(']'));
            if (nodes.Checked) sql.Add(Pub.GetSQL(DBCode.DB_000204, new string[] { "7", ShiftID, node }));
            for (int i = 0; i < nodes.Nodes.Count; i++)
            {
                GetNodeSql(nodes.Nodes[i], ShiftID, ref sql);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string ShiftID = txtShiftID.Text.Trim();
            string ShiftName = txtShiftName.Text.Trim();
            string[] Signin = new string[5];
            string[] Signout = new string[5];
            string[] ShiftAhead = new string[5];
            string[] ShiftDefer = new string[5];
            string[] Drift = new string[5];
            string[] SigninTime = new string[5];
            string[] SignoutTime = new string[5];
            string[] SortID = new string[5];
            double WorkHours = 0.0;
            double OverHours = 0.0;
            string IsAuto = Convert.ToByte(chkIsAuto.Checked).ToString();
            int typeID;
            int ShiftCount = 0;
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            bool IsOk = true;

            if (txtSignin1.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignin1.Focus();
                ShowErrorEnterCorrect(label7.Text);
                return;
            }
            if (txtSignout1.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignout1.Focus();
                ShowErrorEnterCorrect(label7.Text);
                return;
            }

            if (txtSignin2.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignin2.Focus();
                ShowErrorEnterCorrect(label10.Text);
                return;
            }
            if (txtSignout2.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignout2.Focus();
                ShowErrorEnterCorrect(label10.Text);
                return;
            }

            if (txtSignin3.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignin3.Focus();
                ShowErrorEnterCorrect(label7.Text);
                return;
            }
            if (txtSignout3.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignout3.Focus();
                ShowErrorEnterCorrect(label11.Text);
                return;
            }

            if (txtSignin4.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignin4.Focus();
                ShowErrorEnterCorrect(label13.Text);
                return;
            }
            if (txtSignout4.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignout4.Focus();
                ShowErrorEnterCorrect(label13.Text);
                return;
            }

            if (txtSignin5.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignin5.Focus();
                ShowErrorEnterCorrect(label12.Text);
                return;
            }
            if (txtSignout5.Text.Trim().Replace(" ", "").Length != 5)
            {
                txtSignout5.Focus();
                ShowErrorEnterCorrect(label12.Text);
                return;
            }

            if (ShiftID == "")
            {
                txtShiftID.Focus();
                ShowErrorEnterCorrect(label1.Text);
                return;
            }
            if (ShiftName == "")
            {
                txtShiftName.Focus();
                ShowErrorEnterCorrect(label3.Text);
                return;
            }
            TextBox txtAhead;
            TextBox txtDefer;
            MaskedTextBox txtSignin;
            MaskedTextBox txtSignout;
            CheckBox chkSignin;
            CheckBox chkSignout;
            CheckBox chkDrift;
            ComboBox cbbSort;
            DateTime dtin = new DateTime();
            DateTime dtout = new DateTime();
            string[] tmp;
            for (int No = 1; No <= 5; No++)
            {
                txtAhead = (TextBox)this.Controls["txtAhead" + No.ToString()];
                txtDefer = (TextBox)this.Controls["txtDefer" + No.ToString()];
                txtSignin = (MaskedTextBox)this.Controls["txtSignin" + No.ToString()];
                txtSignout = (MaskedTextBox)this.Controls["txtSignout" + No.ToString()];
                chkSignin = (CheckBox)this.Controls["chkSignin" + No.ToString()];
                chkSignout = (CheckBox)this.Controls["chkSignout" + No.ToString()];
                chkDrift = (CheckBox)this.Controls["chkDrift" + No.ToString()];
                cbbSort = (ComboBox)this.Controls["cbbSort" + No.ToString()];
                SortID[No - 1] = ((TIDAndName)cbbSort.Items[cbbSort.SelectedIndex]).id;
                Signin[No - 1] = Convert.ToByte(chkSignin.Checked).ToString();
                Signout[No - 1] = Convert.ToByte(chkSignout.Checked).ToString();
                ShiftAhead[No - 1] = txtAhead.Text.Trim();
                ShiftDefer[No - 1] = txtDefer.Text.Trim();
                Drift[No - 1] = Convert.ToByte(chkDrift.Checked).ToString();
                SigninTime[No - 1] = txtSignin.Text.Trim();
                SignoutTime[No - 1] = txtSignout.Text.Trim();
                tmp = SigninTime[No - 1].Split(':');
                if (tmp.Length != 2 || tmp[0] == "" || tmp[1] == "") SigninTime[No - 1] = "00:00";
                tmp = SignoutTime[No - 1].Split(':');
                if (tmp.Length != 2 || tmp[0] == "" || tmp[1] == "") SignoutTime[No - 1] = "00:00";
                if (SigninTime[No - 1] == "00:00" && SignoutTime[No - 1] == "00:00")
                {
                    SortID[No - 1] = "";
                    Signin[No - 1] = "0";
                    Signout[No - 1] = "0";
                    ShiftAhead[No - 1] = "0";
                    ShiftDefer[No - 1] = "0";
                    Drift[No - 1] = "0";
                    SigninTime[No - 1] = "";
                    SignoutTime[No - 1] = "";
                    continue;
                }
                dtin = new DateTime();
                if (!DateTime.TryParse(txtSignin.Text, out dtin)) continue;
                dtout = new DateTime();
                if (!DateTime.TryParse(txtSignout.Text, out dtout)) continue;
                if (dtin >= dtout)
                {
                    txtSignin.Focus();
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorShiftTime", ""));
                    return;
                }
                if (txtSignout.Text.Trim() == "00:00")
                {
                    txtSignout.Focus();
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorEmptyTime", ""));
                    return;
                }
                if (txtSignin.Text.Trim() == "00:00")
                {
                    txtSignin.Focus();
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorEmptyTime", ""));
                    return;
                }
                if (chkSignin.Checked && txtAhead.Text == "")
                {
                    txtAhead.Focus();
                    ShowErrorEnterCorrect(label5.Text);
                    return;
                }
                if (chkSignout.Checked && txtDefer.Text == "")
                {
                    txtDefer.Focus();
                    ShowErrorEnterCorrect(label6.Text);
                    return;
                }
                if (cbbSort.SelectedIndex == -1)
                {
                    cbbSort.Focus();
                    ShowErrorSelectCorrect(label8.Text);
                    return;
                }
            }
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    if (SortID[i] == "" || SigninTime[i] == "" || SignoutTime[i] == "") continue;
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000201, new string[] { "4", SortID[i] }));
                    if (dr.Read())
                    {
                        double t = SystemInfo.db.GetTimeHours(SigninTime[i], SignoutTime[i]);
                        typeID = Convert.ToInt32(dr["CalcTypeID"].ToString());
                        if (typeID == 0)
                            WorkHours += t;
                        else if (typeID == 1)
                            OverHours += t;
                    }
                    ShiftCount++;
                }
                if (SysID == "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "3", ShiftID }));
                    if (dr.Read())
                    {
                        txtShiftID.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                        IsOk = false;
                    }
                    sql.Add(Pub.GetSQL(DBCode.DB_000204, new string[] { "5", ShiftID, ShiftName, Signin[0], Signout[0], 
            ShiftAhead[0], ShiftDefer[0], Drift[0], SigninTime[0], SignoutTime[0], SortID[0], Signin[1], Signout[1], 
            ShiftAhead[1], ShiftDefer[1], Drift[1], SigninTime[1], SignoutTime[1], SortID[1], Signin[2], Signout[2], 
            ShiftAhead[2], ShiftDefer[2], Drift[2], SigninTime[2], SignoutTime[2], SortID[2], Signin[3], Signout[3], 
            ShiftAhead[3], ShiftDefer[3], Drift[3], SigninTime[3], SignoutTime[3], SortID[3], Signin[4], Signout[4], 
            ShiftAhead[4], ShiftDefer[4], Drift[4], SigninTime[4], SignoutTime[4], SortID[4], WorkHours.ToString().Replace(",","."), 
            OverHours.ToString().Replace(",","."), IsAuto, ShiftCount.ToString().Replace(",",".") }));
                    for (int i = 0; i < tvDepart.Nodes.Count; i++)
                        GetNodeSql(tvDepart.Nodes[i], ShiftID, ref sql);
                }
                else
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_000204, new string[] { "6", ShiftName, Signin[0], Signout[0], ShiftAhead[0], 
            ShiftDefer[0], Drift[0], SigninTime[0], SignoutTime[0], SortID[0], Signin[1], Signout[1], ShiftAhead[1], 
            ShiftDefer[1], Drift[1], SigninTime[1], SignoutTime[1], SortID[1], Signin[2], Signout[2], ShiftAhead[2], 
            ShiftDefer[2], Drift[2], SigninTime[2], SignoutTime[2], SortID[2], Signin[3], Signout[3], ShiftAhead[3], 
            ShiftDefer[3], Drift[3], SigninTime[3], SignoutTime[3], SortID[3], Signin[4], Signout[4], ShiftAhead[4], 
            ShiftDefer[4], Drift[4], SigninTime[4], SignoutTime[4], SortID[4], WorkHours.ToString().Replace(",","."), 
            OverHours.ToString().Replace(",","."), IsAuto, ShiftCount.ToString().Replace(",","."), SysID }));
                    sql.Add(Pub.GetSQL(DBCode.DB_000204, new string[] { "12", SysID }));
                    for (int i = 0; i < tvDepart.Nodes.Count; i++)
                        GetNodeSql(tvDepart.Nodes[i], SysID, ref sql);
                }
            }
            catch (Exception E)
            {
                IsOk = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (!IsOk) return;
            if (SystemInfo.db.ExecSQL(sql) != 0) return;
            SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
            //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tvDepart_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (optSelectAll.Checked) SelectTreeNode(e.Node);
        }
    }
}