using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmRSDepartAdd : frmBaseDialog
    {
        private bool IsAdd = false;
        private string DepartUpID = "";
        private string DepartUpInfo = "";

        protected override void InitForm()
        {
            formCode = "RSDepartAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            txtParent.Text = DepartUpInfo;
            LoadData();
            if (DepartUpID == "")
            {
                txtID.ReadOnly = true;
                txtID.Enabled = false;
            }
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
            if ((IsAdd) || (DepartUpID == ""))
            {
                label4.Visible = false;
                txtParent.Enabled = false;
                txtParent.Visible = false;
                btnParentDepart.Enabled = false;
                btnParentDepart.Visible = false;
            }
        }

        public frmRSDepartAdd(string title, bool AddData, string CurrentTool, string DepartID,
          string ParentDepartID, string ParentDepart)
        {
            Title = title;
            IsAdd = AddData;
            CurrentOprt = CurrentTool;
            SysID = DepartID;
            DepartUpID = ParentDepartID;
            DepartUpInfo = ParentDepart;
            InitializeComponent();
        }
        private Decimal ChangeDataToD(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Decimal.Parse(strData, System.Globalization.NumberStyles.Float);
            }
            return dData;
        }
        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
                if (IsAdd)
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "0", DepartUpID }));
                    long MaxID = 1;
                    if (dr.Read()) MaxID = Convert.ToInt64(dr[0])+1;
                    dr.Close();

                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "1", DepartUpID }));
                    string ID = "";
                    if (dr.Read()) ID = dr["DepartID"].ToString();
                    string tmp = "";
                    int size = 4;
                    if (ID.Length <= 4) size = 4;
                    size = size + ID.Length;
                    while (tmp.Length < size)
                    {
                        tmp += "0";
                    }
                    if (tmp.Length > txtID.MaxLength) tmp = tmp.Substring(0, txtID.MaxLength);
                    tmp = MaxID.ToString(tmp);
                    tmp = ID + tmp.Substring(ID.Length);
                    txtID.Text = tmp;
                }
                else
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "1", SysID }));
                    if (dr.Read())
                    {
                        txtID.Text = dr["DepartID"].ToString();
                        txtName.Text = dr["DepartName"].ToString();
                        txtDesc.Text = dr["DepartMemo"].ToString();
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

        private void btnParentDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string s1 = frm.DepartID;
                string s2 = frm.DepartName;
                if (s1 == SysID)
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }
                string s3 = SystemInfo.db.GetDepartChildIDByID(SysID);
                if (s3 != "")
                {
                    string[] tmp = s3.Split(',');
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] == "") continue;
                        s3 = tmp[i].Substring(1);
                        s3 = s3.Substring(0, s3.Length - 1);
                        if (s3 == s1)
                        {
                            Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                            return;
                        }
                    }
                }
                DepartUpID = s1;
                DepartUpInfo = "[" + s1 + "]" + s2;
                txtParent.Text = DepartUpInfo;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text.Trim();
            string Name = txtName.Text.Trim();
            string Desc = txtDesc.Text.Trim();
            if (txtID.Enabled)
            {
                if (ID == "")
                {
                    txtID.Focus();
                    ShowErrorEnterCorrect(label1.Text);
                    return;
                }
                if (!Pub.CheckTextMaxLength(label1.Text, ID, txtID.MaxLength))
                {
                    txtID.Focus();
                    return;
                }
            }
            if (Name == "")
            {
                txtName.Focus();
                ShowErrorEnterCorrect(label2.Text);
                return;
            }
            if (!Pub.CheckTextMaxLength(label2.Text, Name, txtName.MaxLength))
            {
                txtName.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label3.Text, Desc, txtDesc.MaxLength))
            {
                txtName.Focus();
                return;
            }
            DataTableReader dr = null;
            bool IsOk = false;
            List<string> sql = new List<string>();
            try
            {
                if (SysID == "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "2", ID }));
                    if (dr.Read())
                    {
                        txtID.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                    }
                    else
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_000100, new string[] { "4", ID, Name, DepartUpID, Desc }));
                        IsOk = true;
                    }
                }
                else
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "3", SysID, ID }));
                    if (dr.Read())
                    {
                        txtID.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                    }
                    else
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_000100, new string[] { "5", ID, Name, DepartUpID, Desc, SysID }));
                        if (ID != SysID)
                        {
                            sql.Add(Pub.GetSQL(DBCode.DB_000100, new string[] { "100", ID, SysID }));
                            sql.Add(Pub.GetSQL(DBCode.DB_000100, new string[] { "101", ID, SysID }));
                            sql.Add(Pub.GetSQL(DBCode.DB_000100, new string[] { "102", ID, SysID }));
                        }
                        IsOk = true;
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
    }
}