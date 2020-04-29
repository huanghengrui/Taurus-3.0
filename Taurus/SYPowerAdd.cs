using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmSYPowerAdd : frmBaseDialog
    {
        protected override void InitForm()
        {
            DateTime dt = new DateTime(2099, 12, 31);
            formCode = "SYPowerAdd";
            funcGrid.Columns.Clear();

            AddColumn(funcGrid, 0, "Module", false, false, 0, 100);
            AddColumn(funcGrid, 0, "SubName", false, false, 0, 160);
            AddColumn(funcGrid, 3, "SelectCheck", false, false, 1, 0);
            AddColumn(funcGrid, 0, "ModuleID", true, false, 0, 100);
            AddColumn(funcGrid, 0, "SubID", true, false, 0, 100);
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            Label1.ForeColor = Color.Red;
            Label2.ForeColor = Color.Red;
            Label4.ForeColor = Color.Blue;
            FuncObject funcObj;
            FuncSubObject funcSubObj;
            funcGrid.Columns[0].ReadOnly = true;
            funcGrid.Rows.Clear();
            for (int i = 0; i < SystemInfo.funcList.Count; i++)
            {
                funcObj = SystemInfo.funcList[i];
                for (int j = 0; j < funcObj.SubCount; j++)
                {
                    funcSubObj = funcObj.SubGet(j);
                    if (funcSubObj.IsLine != 2)
                    {
                        funcGrid.Rows.Add();
                        funcGrid[0, funcGrid.RowCount - 1].Value = funcObj.Text;
                        funcGrid[1, funcGrid.RowCount - 1].Value = funcSubObj.Text;
                        funcGrid[2, funcGrid.RowCount - 1].Value = false;
                        funcGrid[3, funcGrid.RowCount - 1].Value = funcObj.Name;
                        funcGrid[4, funcGrid.RowCount - 1].Value = funcSubObj.Name;
                    }
                }
            }
            funcGrid.MergeColumnNames.Add(funcGrid.Columns[0].Name);
            if (SysID != "") LoadData();
        }

        public frmSYPowerAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }
        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            ChangeAllSelectStatus(e.CheckedState);
        }

        private void ChangeAllSelectStatus(bool IsChecked)
        {
            int count = funcGrid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)funcGrid.Rows[i].Cells[2];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == !IsChecked)
                {
                    funcGrid.BeginEdit(true);
                    checkCell.Value = IsChecked;
                    funcGrid.EndEdit();
                }
                else
                {
                    continue;
                }
            }
        }
        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "4", SysID }));
                if (dr.Read())
                {
                    txtOprtNo.Text = dr["OprtNo"].ToString();
                    txtOprtName.Text = dr["OprtName"].ToString();
                    txtOprtPWD.Text = Pub.GetOprtDecrypt(dr["OprtPWD"].ToString());
                    txtOprtPWDA.Text = txtOprtPWD.Text;
                    txtOprtDesc.Text = dr["OprtDesc"].ToString();
                }
                dr.Close();
                string ModuleID;
                string SubID;
                for (int i = 0; i < funcGrid.RowCount; i++)
                {
                    ModuleID = funcGrid[3, i].Value.ToString();
                    SubID = funcGrid[4, i].Value.ToString();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "103", SysID, ModuleID, SubID }));
                    if (dr.Read()) funcGrid[2, i].Value = true;
                    dr.Close();
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

        private void funcGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.RowIndex < funcGrid.Rows.Count) && (e.ColumnIndex == 2))
            {
                funcGrid[e.ColumnIndex, e.RowIndex].Value = !Pub.ValueToBool(funcGrid[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string OprtNo = txtOprtNo.Text.Trim();
            string OprtName = txtOprtName.Text.Trim();
            string Pass = txtOprtPWD.Text.Trim();
            string PassA = txtOprtPWDA.Text.Trim();
            string Desc = txtOprtDesc.Text.Trim();
            DataTableReader dr = null;
            bool IsOk = false;
            List<string> sql = new List<string>();
            if (!Pub.CheckTextMaxLength(Label1.Text, txtOprtNo.Text, txtOprtNo.MaxLength)) return;
            if (!Pub.CheckTextMaxLength(Label2.Text, txtOprtName.Text, txtOprtName.MaxLength)) return;
            if (!Pub.CheckTextMaxLength(Label3.Text, txtOprtPWD.Text, txtOprtPWD.MaxLength)) return;
            if (!Pub.CheckTextMaxLength(Label8.Text, txtOprtDesc.Text, txtOprtDesc.MaxLength)) return;
            if (OprtNo == "")
            {
                txtOprtNo.Focus();
                ShowErrorEnterCorrect(Label1.Text);
                return;
            }
            if (Pub.GetTextLength(OprtNo) < 3)
            {
                txtOprtNo.Focus();
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            if (OprtName == "")
            {
                txtOprtName.Focus();
                ShowErrorEnterCorrect(Label2.Text);
                return;
            }
            if (Pass != PassA)
            {
                txtOprtPWD.Focus();
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorPasswordTwo", ""));
                return;
            }
            Pass = Pub.GetOprtEncrypt(Pass);
            if (Pass == "") Pass = Pub.GetOprtEncrypt("0");
            try
            {
                if (SysID == "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "5", OprtNo }));
                    if (dr.Read())
                    {
                        txtOprtNo.Focus();
                        ShowErrorCannotRepeated(Label1.Text);
                    }
                    else
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "1", OprtNo, OprtName, Pass, Desc }));
                        IsOk = true;
                    }
                }
                else
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "6", SysID, OprtNo }));
                    if (dr.Read())
                    {
                        txtOprtNo.Focus();
                        ShowErrorCannotRepeated(Label1.Text);
                    }
                    else
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "2", OprtNo, OprtName, Pass, Desc, SysID }));
                        sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "101", SysID }));
                        IsOk = true;
                    }
                }
                if (IsOk)
                {
                    string ModuleID;
                    string SubID;
                    for (int i = 0; i < funcGrid.RowCount; i++)
                    {
                        ModuleID = funcGrid[3, i].Value.ToString();
                        SubID = funcGrid[4, i].Value.ToString();
                        if (Pub.ValueToBool(funcGrid[2, i].Value))
                        {
                            sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "102", OprtNo, ModuleID, SubID }));
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
            if (IsOk)
            {
                if (SystemInfo.db.ExecSQL(sql) != 0) return;
                SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
                //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SelectModule(bool state)
        {
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
                funcGrid[2, i].Value = state;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectModule(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectModule(false);
        }
    }
}