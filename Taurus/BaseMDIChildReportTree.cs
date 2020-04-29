using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmBaseMDIChildReportTree : frmBaseMDIChildReport
    {
        protected string otherCoin = "";
        protected bool IsInit = false;
        protected bool InitEmp = false;
        protected bool IsInitBaseForm = false;
        protected string nodeEmpNo = "";
        protected string nodeDepartID = "";
        protected string nodeDepartList = "";
        protected int startWidth = 0;
        protected int endWidth = 0;
        protected bool isMove = false;

        protected override void InitForm()
        {
            this.Hide();
            IsInit = true;
            IgnoreRefreshFirst = true;
            if (IsInitBaseForm) base.InitForm();
            
            InitDepartTreeView(tvEmp, InitEmp, otherCoin);
            IsInit = false;
            this.Show();
        }

        public frmBaseMDIChildReportTree()
        {
            InitializeComponent();
            
        }

        private void tvEmp_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!IsInit) ExecTreeAfterSelect(e.Node);
        }

        protected void ExecTreeAfterSelect(TreeNode node)
        {
            nodeEmpNo = "";
            nodeDepartID = "";
            nodeDepartList = "";
            QuerySQL = "";
            if (node == null) return;
            if (InitEmp)
            {
                if (node.Nodes.Count == 0)
                    nodeEmpNo = node.Tag.ToString();
                else
                {
                    nodeDepartID = node.Tag.ToString();
                    nodeDepartList = SystemInfo.db.GetDepartChildID(nodeDepartID);
                    if (nodeDepartList == "") nodeDepartList = "''";
                }
            }
            else
            {
                nodeDepartID = node.Tag.ToString();
                nodeDepartList = SystemInfo.db.GetDepartChildID(nodeDepartID);
                if (nodeDepartList == "") nodeDepartList = "''";
            }
            ExecTreeAfterSelect();
        }

        protected virtual void ExecTreeAfterSelect()
        {
            if (QuerySQL != "") ExecItemRefresh();
        }
        private void splitter_MouseDown(object sender, MouseEventArgs e)
        {
            startWidth = e.X;
            isMove = true;
        }

        private void splitter_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                endWidth = e.X;
                panel1.Width = panel1.Width + endWidth - startWidth;
            }
        }

        private void splitter_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
    }
}