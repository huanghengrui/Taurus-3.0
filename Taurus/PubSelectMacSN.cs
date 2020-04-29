using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmPubSelectMacSN : frmBaseDialog
    {
        private TreeNode findNode = null;
        private string otherCoin = "";
        public string MacSN = "";

        public frmPubSelectMacSN()
        {
            InitializeComponent();
        }
        protected override void InitForm()
        {
            formCode = "PubSelectMacSN";
            base.InitForm();
            MacSN = "";
            if (IgnoreDimission) otherCoin += Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
            InitMacSNTreeView(tvMacSN, true, otherCoin);
            lblQuickSearchMacSN.ForeColor = Color.Blue;
        }

        public frmPubSelectMacSN(bool IgnoreDim)
        {
            IgnoreDimission = IgnoreDim;
            InitializeComponent();
        }

        public frmPubSelectMacSN(string OtherCoin)
        {
            otherCoin = OtherCoin;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tvMacSN.SelectedNode == null || tvMacSN.SelectedNode.Nodes.Count > 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectMacSN", ""));
                return;
            }
            MacSN = tvMacSN.SelectedNode.Tag.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tvMacSN_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string s = txtFind.Text;
            if (s == "") return;
            bool isFind = false;
            for (int i = 0; i < tvMacSN.Nodes.Count; i++)
            {
                if (tvMacSN.Nodes[i].Text.IndexOf(s) != -1)
                {
                    if (findNode != null && findNode.Index >= tvMacSN.Nodes[i].Index) continue;
                    findNode = tvMacSN.Nodes[i];                  
                    isFind = true;
                    break;
                }
                else
                {
                    isFind = FindNode(s, tvMacSN.Nodes[i]);
                   
                    if (isFind) break;
                }
            }
            if (!isFind) findNode = null;
            if (findNode != null) tvMacSN.SelectedNode = findNode;
           

        }
 
        private bool FindNode(string findText, TreeNode nod)
        {
            bool ret = false;
            tvMacSN.Focus();
            for (int i = 0; i < nod.Nodes.Count; i++)
            {
                if (nod.Nodes[i].Text.IndexOf(findText) != -1)
                {
                    if (findNode != null && findNode.Index >= nod.Nodes[i].Index) continue;
                    findNode = nod.Nodes[i];
                    tvMacSN.SelectedNode = nod.Nodes[i];//选中
                    nod.Nodes[i].Checked = true;
                    ret = true;
                    break;
                }
                else
                {
                    ret = FindNode(findText, nod.Nodes[i]);
                   // nod.Nodes[i].Checked = true;
                    if (ret) break;
                }
            }
            return ret;
        }
        private void setParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                setParentNodeCheckedState(currNode.Parent, state);
            }
        }
        //选中节点之后，选中节点的所有子节点
        private void setChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
            {
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    setChildNodeCheckedState(tn, state);
                }
            }
        }

        private void tvMacSN_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {

                if (e.Node.Checked == true)
                {
                    //选中节点之后，选中该节点所有的子节点
                    setChildNodeCheckedState(e.Node, true);
                }
                else if (e.Node.Checked == false)
                {
                    //取消节点选中状态之后，取消该节点所有子节点选中状态
                    setChildNodeCheckedState(e.Node, false);
                    //如果节点存在父节点，取消父节点的选中状态
                    if (e.Node.Parent != null)
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
            }
        }
    }
}
