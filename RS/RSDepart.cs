using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmRSDepart : frmBaseMDIChild
    {
        protected override void InitForm()
        {
            formCode = "RSDepart";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            //SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemSelect", false);
            SetToolItemState("ItemUnselect", false);
            // SetToolItemState("ItemLine4", false);
           
            base.InitForm();
            ExecItemRefresh();
        }

        public frmRSDepart()
        {
            InitializeComponent();
        }
     
        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmRSDepartAdd frm = new frmRSDepartAdd(this.Text, true, CurrentTool, "", GetDepartID(), GetParentDepart());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmRSDepartAdd frm = new frmRSDepartAdd(this.Text, false, CurrentTool, GetDepartID(), GetParentDepartEditID(),
              GetParentDepartEdit());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemDelete()
        {
            string SysID = GetDepartID();
            if (SysID == "")
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgNoSelectDelete", ""));
                return;
            }
            TreeNode node = tvDepart.SelectedNode;
            if (node.Parent == null)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            bool IsError = false;
            DataTableReader dr = null;
            List<string> sql = new List<string>();
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "2", SysID }));
                if (dr.Read())
                {
                    IsError = true;
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""));
                }
                if (!IsError)
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "12", SysID }));
                    if (dr.Read())
                    {
                        IsError = true;
                        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
                    }
                }
                if (!IsError)
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_000100, new string[] { "6", SysID }));
                    if (SystemInfo.db.ExecSQL(sql) != 0) IsError = true;
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
            SystemInfo.db.WriteSYLog(this.Text, CurrentTool, sql);
            ExecItemRefresh();
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
        }

        protected override void ExecItemRefresh()
        {
            RefreshMsg(StrReading);
            InitDepartTreeView(tvDepart);
            RefreshForm(true);
            RefreshMsg("");
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            int row = 0;
            int rows = 0;
            row = 0;
            if (tvDepart.SelectedNode != null) row = tvDepart.SelectedNode.Index + 1;
            rows = tvDepart.GetNodeCount(true);
            ItemImport.Enabled = ItemImport.Visible && State;
            ItemExport.Enabled = ItemExport.Visible && State && (rows > 0);
            ItemPrint.Enabled = ItemPrint.Visible && State && (rows > 0);
            ItemAdd.Enabled = ItemAdd.Visible && State;
            ItemEdit.Enabled = ItemEdit.Visible && State && (rows > 0);
            ItemDelete.Enabled = ItemDelete.Visible && State && (rows > 0);
            ItemTAG1.Enabled = ItemTAG1.Visible && State && (rows > 0);
            ItemTAG2.Enabled = ItemTAG2.Visible && State && (rows > 0);
            ItemTAG3.Enabled = ItemTAG3.Visible && State && (rows > 0);
            ItemTAG4.Enabled = ItemTAG4.Visible && State && (rows > 0);
            ItemTAG5.Enabled = ItemTAG5.Visible && State && (rows > 0);
            ItemTAG6.Enabled = ItemTAG6.Visible && State && (rows > 0);
            ItemTAG7.Enabled = ItemTAG7.Visible && State && (rows > 0);
            ItemTAGExt.Enabled = ItemTAGExt.Visible && State && (rows > 0);
            for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
            {
                ItemTAGExt.DropDownItems[i].Enabled = ItemTAGExt.Enabled;
            }
            ItemSelect.Enabled = ItemSelect.Visible && State && (rows > 0);
            ItemUnselect.Enabled = ItemUnselect.Visible && State && (rows > 0);
            ItemRefresh.Enabled = ItemRefresh.Visible && State;
            SetContextMenuState();
            lblRecordState.Text = string.Format(StrPosition, row, rows);
            lblRecordState.Enabled = false;
            lblRecordState.Visible = false;
        }

        private void tvDepart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshForm(true);
        }

        private string GetDepartID()
        {
            string ret = "";
            if ((tvDepart.SelectedNode != null) && (tvDepart.SelectedNode.Tag != null))
            {
                ret = tvDepart.SelectedNode.Tag.ToString();
            }
            return ret;
        }

        private string GetParentDepart()
        {
            string ret = "";
            if (tvDepart.SelectedNode != null)
            {
                ret = tvDepart.SelectedNode.Text;
            }
            return ret;
        }

        private string GetParentDepartEditID()
        {
            string ret = "";
            if ((tvDepart.SelectedNode != null) && (tvDepart.SelectedNode.Parent != null) &&
              (tvDepart.SelectedNode.Parent.Tag != null))
            {
                ret = tvDepart.SelectedNode.Parent.Tag.ToString();
            }
            return ret;
        }

        private string GetParentDepartEdit()
        {
            string ret = "";
            if ((tvDepart.SelectedNode != null) && (tvDepart.SelectedNode.Parent != null))
            {
                ret = tvDepart.SelectedNode.Parent.Text;
            }
            return ret;
        }
    }
}