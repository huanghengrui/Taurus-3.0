using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmPubSelectEmpList : frmBaseDialog
    {
        private string title = "";
        private string otherCoin = "";
        public DataTable dtData = new DataTable();
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;
        protected override void InitForm()
        {
            formCode = "PubSelectEmpList";
            CreateCardGridView(cardGrid);
            IsToggleCheckStateAll = true;
            base.InitForm();
            this.Text = title;
            InitDepartTreeView(tvDepart);
            InitDepartTreeView(tvEmp, true, otherCoin);
            dtData.Clear();
            dtData.Reset();
            if (tvEmp.StateImageList == null)
            {
                tvEmp.AfterCheck += tvEmp_AfterCheck;
                tvEmp.CheckBoxes = true;
            }
        }

        public frmPubSelectEmpList(string Title, string OtherCoin)
        {
            title = Title;
            otherCoin = OtherCoin;
            InitializeComponent();
        }

        private bool FindSelectedEmp(string EmpNo)
        {
            bool ret = false;
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                if (dtData.Rows[i]["EmpNo"].ToString() == EmpNo)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        private void SelectDepart(TreeNode node)
        {
            string DepartID = node.Tag.ToString();
            DataTable dt = null;
            try
            {
                if (node.Checked)
                {
                    if (dtData.Rows.Count == 0)
                    {
                        dtData = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000100, new string[] { "7", DepartID, otherCoin }));
                    }
                    else
                    {
                        dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000100, new string[] { "7", DepartID, otherCoin }));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!FindSelectedEmp(dt.Rows[i]["EmpNo"].ToString())) dtData.Rows.Add(dt.Rows[i].ItemArray);
                        }
                    }
                }
                else
                {
                    for (int i = dtData.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dtData.Rows[i]["DepartID"].ToString() == DepartID)
                        {
                            dtData.Rows.RemoveAt(i);
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
                if (dt != null)
                {
                    dt.Clear();
                    dt.Reset();
                }
            }
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                SelectDepart(node.Nodes[i]);
            }
            bindingSource.DataSource = dtData;
        }

        private void tvDepart_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (optSelectAll.Checked) SelectTreeNode(e.Node);
            SelectDepart(e.Node);
        }

        private void SelectEmp(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                string EmpNo = node.Tag.ToString();
                DataTable dt = null;
                bool state = false;
                if (tvEmp.StateImageList == null)
                    state = node.Checked;
                else
                    state = node.StateImageIndex == 1;
                try
                {
                    if (state)
                    {
                        if (dtData.Rows.Count == 0)
                        {
                            dtData = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "203", EmpNo, otherCoin }));
                        }
                        else
                        {
                            dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "203", EmpNo, otherCoin }));
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (!FindSelectedEmp(dt.Rows[i]["EmpNo"].ToString()))
                                {
                                    dtData.Rows.Add(dt.Rows[i].ItemArray);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = dtData.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dtData.Rows[i]["EmpNo"].ToString() == EmpNo)
                            {
                                dtData.Rows.RemoveAt(i);
                                break;
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
                    if (dt != null)
                    {
                        dt.Clear();
                        dt.Reset();
                    }
                }
            }
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                SelectEmp(node.Nodes[i]);
            }
            bindingSource.DataSource = dtData;
        }

        protected override void ToggleCheckStateAll(TreeNode node)
        {
            base.ToggleCheckStateAll(node);
            SelectEmp(node);
        }

        private void tvEmp_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SelectTreeNode(e.Node);
            SelectEmp(e.Node);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtData.Rows.Count > 0)
            {
                DataRowView drv = (DataRowView)bindingSource.Current;
                dtData.Rows.Remove(drv.Row);
            }
            bindingSource.DataSource = dtData;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtData.Clear();
            dtData.Reset();
            bindingSource.DataSource = dtData;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dtData.Rows.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void cardGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblMsg.Text = string.Format(Pub.GetResText(formCode, "MsgSelectNo", ""), cardGrid.Rows.Count);
        }

        private void tvEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey && !isSelectEnd)
            {
                selectNo = tvEmp.SelectedNode.Index; 
                isSelect = true;
                isSelectEnd = true;
            }
  
        }

        private void tvEmp_KeyUp(object sender, KeyEventArgs e)
        {
            isSelect = false;
            isSelectEnd = false;
        }

        private void tvEmp_MouseClick(object sender, MouseEventArgs e)
        {   
            TreeView Tv_temp = (TreeView)sender;
            
            if ((sender as TreeView) != null)
            {
                Tv_temp.SelectedNode = Tv_temp.GetNodeAt(e.X, e.Y);
                selectNoEnd = Tv_temp.SelectedNode.Index;
                
            }
            tvSelect(tvEmp,2);
        }

        private void tvDepart_MouseClick(object sender, MouseEventArgs e)
        {
            TreeView Tv_temp = (TreeView)sender;

            if ((sender as TreeView) != null)
            {
                Tv_temp.SelectedNode = Tv_temp.GetNodeAt(e.X, e.Y);
                selectNoEnd = Tv_temp.SelectedNode.Index;

            }
            tvSelect(tvDepart,1);
        }

        private void tvDepart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey && !isSelectEnd)
            {
                selectNo = tvDepart.SelectedNode.Index;
                isSelect = true;
                isSelectEnd = true;
            }
        }

        private void tvDepart_KeyUp(object sender, KeyEventArgs e)
        {
            isSelect = false;
            isSelectEnd = false;
        }

        private void tvSelect(TreeView tvTemp,int stata)
        {
            if (selectNoEnd < 0) return;
            if (isSelect)
            {
                int i = 0;
                for (int j = 0; j < tvTemp.SelectedNode.Parent.Nodes.Count; j++)
                {

                    if (selectNo < selectNoEnd)
                    {
                        if (i >= selectNo && i <= selectNoEnd)
                        {
                            tvTemp.SelectedNode.Parent.Nodes[i].Checked = true;
                            tvTemp.SelectedNode.Parent.Nodes[i].StateImageIndex = 1;
                            base.ToggleCheckStateAll(tvTemp.SelectedNode.Parent.Nodes[i]);
                            if(stata==1)
                            {
                                SelectDepart(tvTemp.SelectedNode.Parent.Nodes[i]);
                            }
                            else if (stata == 2)
                                SelectEmp(tvTemp.SelectedNode.Parent.Nodes[i]);
                        }

                    }
                    else
                    {
                        if (i <= selectNo && i >= selectNoEnd)
                        {
                            tvTemp.SelectedNode.Parent.Nodes[i].Checked = true;
                            tvTemp.SelectedNode.Parent.Nodes[i].StateImageIndex = 1;
                            base.ToggleCheckStateAll(tvTemp.SelectedNode.Parent.Nodes[i]);
                            if (stata == 1)
                            {
                                SelectDepart(tvTemp.SelectedNode.Parent.Nodes[i]);
                            }
                            else if (stata == 2)
                                SelectEmp(tvTemp.SelectedNode.Parent.Nodes[i]);
                        }
                    }
                    i++;
                }
            }
        }
    }
}