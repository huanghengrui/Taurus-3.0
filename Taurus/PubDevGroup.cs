using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmPubDevGroup : frmBaseDialog
    {
        private string oprt = "";
        public static bool Stop = false;
        public static bool Exit = false;
        protected string otherCoin = "";
        protected bool IsInit = false;
        protected bool InitEmp = false;
        protected string QuerySQL = "";
        protected string currentTool = "";
        protected static TreeNode SeNode = null;
        protected string SysID = "";
        protected string DevGroupUpInfo = "";
        protected string DevGroupUpID = "";
        //protected string SysUpID = "";
        protected override void InitForm()
        {
            formCode = "PubDevGroup";
            IsAllEmpInfo = true;
            base.InitForm();
            DataTableReader dr = null;
            this.Text = oprt+"["+currentTool+"]";
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "30"}));
            if (!dr.Read())
            {
                Name = Pub.GetResText(formCode, "DevGroupName", "");
                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "34", "001", Name, "", "" }));
            }
            Name = "";
            InitDevGroupTreeView(tvEmp, InitEmp, otherCoin);
        }


        public frmPubDevGroup(string title, string CurrentTool)
        {
            oprt = title;
            currentTool = CurrentTool;
            InitializeComponent();
        }

        private void ItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvEmp_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!IsInit) ExecTreeAfterSelect(e.Node);
            SeNode = e.Node;
        }

        protected void ExecTreeAfterSelect(TreeNode node)
       {
            DataTableReader dr = null;
            txtGroupNo.Text ="";
            txtGroupName.Text = "";
            txtRemarks.Text = "";
            txtGroupSuperior.Text = "";
            DevGroupUpID = "";
            ItemStatus(false);
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "33", node.Tag.ToString() }));
            if (dr.Read())
            {
                txtGroupNo.Text = dr["DevGroupID"].ToString();
                txtGroupName.Text = dr["DevGroupName"].ToString();
                txtRemarks.Text = dr["DevGroupMemo"].ToString();
                
                if (dr["DevGroupUpID"].ToString() != "")
                { 
                     dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "33",dr["DevGroupUpID"].ToString() }));
                     if (dr.Read())
                     { 
                         txtGroupSuperior.Text = dr["DevGroupName"].ToString();
                         DevGroupUpID = dr["DevGroupID"].ToString();
                     }
                }
                  
            }
            dr.Close();
         
        }

        private void ItemEdit_Click(object sender, EventArgs e)
        {
            ItemStatus(true);
            SysID = txtGroupNo.Text;
        }
        private void ItemStatus(bool statu)
        { 
            txtGroupNo.Enabled = statu;
            txtGroupName.Enabled = statu;
            txtRemarks.Enabled = statu;
            btnParentGroup.Enabled = statu;
            ItemSave.Enabled = statu;
            ItemUnsave.Enabled = statu;
        }

        private void ItemUnsave_Click(object sender, EventArgs e)
        {
            ExecTreeAfterSelect(SeNode);
            ItemStatus(false);
        }
        /// <summary>
        /// 获取节点深度
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        private int getDepth(TreeNode treeNode)
        {
            int max = 0;
            if (treeNode.Nodes.Count == 0)
                return 0;
            else
            {
                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (getDepth(node) > max)
                        max = getDepth(node);
                }
                return max+1;
            }
        }

        private void ItemSave_Click(object sender, EventArgs e)
        {
             string ID = txtGroupNo.Text.Trim();
             string Name = txtGroupName.Text.Trim();
             string Desc = txtRemarks.Text.Trim();

             if (ID == "")
             {
               txtGroupNo.Focus();
               ShowErrorEnterCorrect(lbGroupNo.Text);
               return;
             }
             if (!Pub.CheckTextMaxLength(lbGroupNo.Text, ID, txtGroupNo.MaxLength))
             {
               txtGroupNo.Focus();
               return;
             }

             if (Name == "")
             {
               txtGroupName.Focus();
               ShowErrorEnterCorrect(lbGroupName.Text);
               return;
             }
             if (!Pub.CheckTextMaxLength(lbGroupName.Text, Name,txtGroupName.MaxLength))
             {
               txtGroupName.Focus();
               return;
             }
             if (!Pub.CheckTextMaxLength(lbRemarks.Text, Desc,txtRemarks.MaxLength))
             {
               txtRemarks.Focus();
               return;
             }
             DataTableReader dr = null;
             bool IsOk = false;
             List<string> sql = new List<string>();
             try
             {
               if (SysID == "")
               {
                 dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "31", ID }));
                 if (dr.Read())
                 {
                   txtGroupNo.Focus();
                   ShowErrorCannotRepeated(lbGroupNo.Text);
                 }
                 else
                 {
                   sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "34", ID, Name, DevGroupUpID, Desc }));
                   IsOk = true;
                 }
               }
               else
               {
                 dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "35", SysID, ID }));
                 if (dr.Read())
                 {
                   txtGroupNo.Focus();
                   ShowErrorCannotRepeated(lbGroupNo.Text);
                 }
                 else
                 {
                   sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "36", ID, Name, DevGroupUpID, Desc, SysID }));
                   sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "40",ID,SysID}));
                  
                   dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "38", SysID }));
                   if (dr.Read())
                   {
                      sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "37", ID,Name, SysID }));  
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
               SystemInfo.db.WriteSYLog(this.Text, currentTool, sql);
               //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
               //this.DialogResult = DialogResult.OK;
               //this.Close();
               InitDevGroupTreeView(tvEmp, InitEmp, otherCoin);
               //int depth = getDepth(tvEmp.Nodes[0]);
               // if (depth > 4)
               // {
               //     SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "29", ID }));
               //     InitDevGroupTreeView(tvEmp, InitEmp, otherCoin);
               //     Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", "")); 
               // }
               // else
                { 
                    for (int i = 0; i < tvEmp.Nodes.Count; i++)
                    {
                        SelectNodes(ID, tvEmp.Nodes[i]);
                    }   
                }
              
               ItemStatus(false);
             }
    
        }

        private void SelectNodes(string ID,TreeNode node)
        { 
              for (int i = 0; i < node.Nodes.Count; i++)
               {
                     for (int j = 0; j < node.Nodes[i].Nodes.Count; j++)
                     {
                         if (node.Nodes[i].Nodes[j].Text.Contains("["+ID+"]"))
                         {
                             tvEmp.SelectedNode = node.Nodes[i].Nodes[j];
                             tvEmp.Focus();
                             return;
                         }
                       
                     }
                 SelectNodes(ID, node.Nodes[i]);
               }    
        }

        private void btnParentGroup_Click(object sender, EventArgs e)
        {
            int id = 1;
            DataTableReader dr = null;
            
            frmPubSelectDevGroup frm = new frmPubSelectDevGroup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
              string s1 = frm.GroupID;
              string s2 = frm.GroupName;
              if (s1 == SysID)
              {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                return;
              }
              string s3 = SystemInfo.db.GetGroupChildIDByID(SysID);
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
              dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "31", s1}));
              while (dr.Read())
              {
                  id++; 
              }
                DevGroupUpID = s1;
                txtGroupNo.Text = s1 + "00" + id.ToString();
                //txtGroupSuperior.Text = s1;
                DevGroupUpInfo = s2;
                txtGroupSuperior.Text = DevGroupUpInfo;
                txtGroupSuperior.Tag = s1;
            }
                
        }

        private void ItemAdd_Click(object sender, EventArgs e)
        {
            ItemStatus(true);
            int id = 1;
            SysID = "";
            DataTableReader dr = null;
            txtGroupNo.Text ="";
            txtGroupName.Text = "";
            txtRemarks.Text = "";
            txtGroupSuperior.Text = "";
           // string[] tmp = SeNode.Text.ToString().Split(']');
            txtGroupSuperior.Text =SeNode.Text.ToString();
            txtGroupSuperior.Tag = SeNode.Tag.ToString();
            DevGroupUpID = SeNode.Tag.ToString();
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "31", DevGroupUpID}));
            while (dr.Read())
            {
                id++; 
            }
            txtGroupNo.Text = SeNode.Tag.ToString() + "00" + id.ToString();
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
             DataTableReader dr = null;
            //string[] tmp = SeNode.Text.ToString().Split(']');
            //tmp = tmp[0].Split('[');
            string ID=SeNode.Tag.ToString();
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "31", ID}));
            while (dr.Read())
            {
                 Pub.MessageBoxShow(Pub.GetResText(formCode, "Error004", ""));
                 return;
            }
            
            if (SeNode == tvEmp.Nodes[0])
            { 
                 Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
                 return;
            }
            SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "39", ID }));
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "38", ID }));
            if (dr.Read())
            {
               SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "37","","", ID }));  
            }
            InitDevGroupTreeView(tvEmp, InitEmp, otherCoin);
        }

        private void frmPubDevGroup_Load(object sender, EventArgs e)
        {

        }
    }
}
