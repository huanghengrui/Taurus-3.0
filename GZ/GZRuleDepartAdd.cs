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
    public partial class frmGZRuleDepartAdd : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "GZRuleDepartAdd";
            base.InitForm();
            InitDepartTreeView(tvDepart);
            this.Text = Title + "[" + CurrentOprt + "]";
            groupBox1.Enabled = SysID == "";
            txtDepartID.Enabled = groupBox1.Enabled;
            btnSelectDepart.Enabled = groupBox1.Enabled;
            btnSelectDepart.Visible = groupBox1.Enabled;
            txtDepartName.Enabled = false;
            LoadData();
            KeyPreview = true;
        }

        public frmGZRuleDepartAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepartID.Text = frm.DepartID;
                txtDepartName.Text = frm.DepartName;
            }
        }

        private void tvDepart_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (optSelectAll.Checked) SelectTreeNode(e.Node);
        }

        private void LoadData()
        {
            TIDAndName idn = new TIDAndName("", "");
            cbbRule.Items.Clear();
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000401, new string[] { "1" }));
                while (dr.Read())
                {
                    idn = new TIDAndName(dr["ItemID"].ToString(), "[" + dr["ItemID"].ToString() + "]" + dr["ItemName"].ToString());
                    cbbRule.Items.Add(idn);
                }
                if (cbbRule.Items.Count > 0) cbbRule.SelectedIndex = 0;
                dr.Close();
                if (SysID != "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000403, new string[] { "2", SysID }));
                    if (dr.Read())
                    {
                        txtDepartID.Text = dr["DepartID"].ToString();
                        txtDepartName.Text = dr["DepartName"].ToString();
                        txtDepartID.Enabled = false;
                        btnSelectDepart.Enabled = false;
                        txtDepartName.Tag = dr["DepartID"].ToString();
                        for (int i = 0; i < cbbRule.Items.Count; i++)
                        {
                            if (((TIDAndName)cbbRule.Items[i]).id == dr["GZRuleID"].ToString())
                            {
                                cbbRule.SelectedIndex = i;
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
        private bool SelectNode(TreeNode nodes)
        {
            bool ret = false;

            if (nodes.Checked)
            {
                ret = true;
                return ret;
            }

            for (int i = 0; i < nodes.Nodes.Count; i++)
            {
                ret = SelectNode(nodes.Nodes[i]);
            }
            return ret;
        }
        private void GetNodeSql(TreeNode nodes, string RuleID, string DepartID, ref List<string> sql)
        {
            string node = "";
            node = nodes.Text.Substring(node.IndexOf('[') + 2);
            node = node.Remove(node.LastIndexOf(']'));
            if (nodes.Checked && node != DepartID)
                sql.Add(Pub.GetSQL(DBCode.DB_000403, new string[] { "3", RuleID, node }));
            for (int i = 0; i < nodes.Nodes.Count; i++)
            {
                GetNodeSql(nodes.Nodes[i], RuleID, DepartID, ref sql);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool ret = false;
            for (int i = 0; i < tvDepart.Nodes.Count; i++)
                ret = SelectNode(tvDepart.Nodes[i]);
            if (txtDepartID.Text.Trim() == "" && !ret)
            {
                txtDepartID.Focus();
                ShowErrorEnterCorrect(label2.Text);
                return;
            }
            if (cbbRule.SelectedIndex == -1)
            {
                cbbRule.Focus();
                ShowErrorSelectCorrect(label3.Text);
                return;
            }
            string DepartID = txtDepartID.Text;
            string RuleID = ((TIDAndName)cbbRule.Items[cbbRule.SelectedIndex]).id;
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            bool IsError = false;
            try
            {
                if (SysID == "")
                {
                    if(RuleID!="" && DepartID!="")
                        sql.Add(Pub.GetSQL(DBCode.DB_000403, new string[] { "3", RuleID, DepartID }));
                    for (int i = 0; i < tvDepart.Nodes.Count; i++)
                        GetNodeSql(tvDepart.Nodes[i], RuleID, DepartID, ref sql);
                }
                else
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_000403, new string[] { "3", RuleID, DepartID }));
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

        private void txtDepartID_Leave(object sender, EventArgs e)
        {
            txtDepartID.Tag = "";
            txtDepartName.Text = "";
            if (txtDepartID.Text.Trim() != "")
            {
                string DepartName = "";
                if (SystemInfo.db.GetDepartInfo(txtDepartID.Text.Trim(), ref DepartName))
                {
                    txtDepartName.Text = DepartName;
                }
                else
                {
                    txtDepartID.Text = "";
                    txtDepartName.Text = "";
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorDepartNotExists", ""));
                }
            }
        }
    }
}