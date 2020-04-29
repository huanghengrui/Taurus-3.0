using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Taurus
{
  public partial class frmDBPathSelect : frmBaseDialog
  {
    public bool OnlyPath = false;
    public string SelectItemName = "";
    public bool UseLocal = false;

    protected override void InitForm()
    {
      formCode = "DBPathSelect";
      base.InitForm();
      Label1.Visible = OnlyPath;
      Label2.Visible = !OnlyPath;
      if (OnlyPath)
      {
        this.Text = this.Text + Pub.GetResText(formCode, "SelectFolder", "");
      }
      else
      {
        this.Text = this.Text + Pub.GetResText(formCode, "SelectDBBak", "");
      }
      AddFixedDrives();
      FindPath(SelectItemName);
      if ((tv.Nodes.Count > 0) && (SelectItemName == "") && (tv.SelectedNode == null))
      {
        tv.SelectedNode = tv.Nodes[0];
        SelectChange(tv.Nodes[0]);
      }
      tv.Focus();
    }

    public frmDBPathSelect()
    {
      InitializeComponent();
    }

    private void tv_AfterCollapse(object sender, TreeViewEventArgs e)
    {
      if (e.Node.Level == 0)
      {
        e.Node.ImageIndex = 3;
        e.Node.SelectedImageIndex = 3;
      }
      else if (e.Node.Tag.ToString().Substring(0, 1) == "1")
      {
        e.Node.ImageIndex = 2;
        e.Node.SelectedImageIndex = 2;
      }
      else
      {
        e.Node.ImageIndex = 0;
        e.Node.SelectedImageIndex = 1;
      }
    }

    private void tv_AfterSelect(object sender, TreeViewEventArgs e)
    {
      SelectChange(e.Node);
    }

    private void tv_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
      if (e.Node.Level == 0)
      {
        e.Node.ImageIndex = 3;
        e.Node.SelectedImageIndex = 3;
      }
      else if (e.Node.Tag.ToString().Substring(0, 1) == "1")
      {
        e.Node.ImageIndex = 2;
        e.Node.SelectedImageIndex = 2;
      }
      else
      {
        e.Node.ImageIndex = 0;
        e.Node.SelectedImageIndex = 1;
      }
      AddSubDirs(e.Node, e.Node.Tag.ToString().Substring(1));
      tv.SelectedNode = e.Node;
    }

    private void tv_DoubleClick(object sender, EventArgs e)
    {
      if (btnOk.Enabled)
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private bool AddFixedDrives()
    {
      bool ret = false;
      DataTableReader dr = null;
      TreeNode tn;
      string tmp = "";
      tv.Nodes.Clear();
      if (UseLocal)
      {
        System.IO.DriveInfo[] drs = System.IO.DriveInfo.GetDrives();
        for (int i = 0; i < drs.Length; i++)
        {
          if (drs[i].DriveType == System.IO.DriveType.Fixed || drs[i].DriveType == System.IO.DriveType.Removable)
          {
            tmp = drs[i].Name;
            tmp = tmp.Substring(0, 2);
            tn = tv.Nodes.Add(tmp);
            tn.ImageIndex = 3;
            tn.SelectedImageIndex = 3;
            tn.Tag = "0";
            tn.Tag = tn.Tag.ToString() + GetFullPath(tn);
            tn.Nodes.Add("");
          }
        }
      }
      else if ((SystemInfo.DBType == 1) || (SystemInfo.DBType == 2))
      {
        try
        {
          dr = SystemInfo.db.GetDataReader("EXEC master..xp_fixeddrives");
          while (dr.Read())
          {
            tmp = dr[0].ToString().Trim();
            tmp = tmp.Substring(0, 1) + ":(" + dr[1].ToString().Trim() + dr.GetName(1) + ")";
            tn = tv.Nodes.Add(tmp);
            tn.ImageIndex = 3;
            tn.SelectedImageIndex = 3;
            tn.Tag = "0";
            tn.Tag = tn.Tag.ToString() + GetFullPath(tn);
            tn.Nodes.Add("");
          }
          ret = true;
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
      return ret;
    }

    private bool AddSubDirs(TreeNode ParentNode, string ParentPath)
    {
      bool ret = false;
      DataTableReader dr = null;
      TreeNode tn;
      string tmp = "";
      if ((ParentNode.Nodes.Count > 0) && (ParentNode.Nodes[0].Text == ""))
      {
        ParentNode.Nodes.Clear();
        if (UseLocal)
        {
          DirectoryInfo Folder = new DirectoryInfo(ParentPath);
          foreach (DirectoryInfo NextFolder in Folder.GetDirectories())
          {
            tmp = NextFolder.Name;
            tn = ParentNode.Nodes.Add(tmp);
            tn.ImageIndex = 0;
            tn.SelectedImageIndex = 1;
            tn.Tag = "0";
            tn.Nodes.Add("");
            tn.Tag = tn.Tag.ToString() + GetFullPath(tn);
          }
          if (!OnlyPath)
          {
            foreach (FileInfo NextFile in Folder.GetFiles())
            {
              tmp = NextFile.Name;
              tn = ParentNode.Nodes.Add(tmp);
              tn.ImageIndex = 2;
              tn.SelectedImageIndex = 2;
              tn.Tag = "1";
              tn.Tag = tn.Tag.ToString() + GetFullPath(tn);
            }
          }
        }
        else if ((SystemInfo.DBType == 1) || (SystemInfo.DBType == 2))
        {
          try
          {
            dr = SystemInfo.db.GetDataReader("EXEC master..xp_dirtree '" + ParentPath + "',1," +
              Convert.ToByte(!OnlyPath).ToString());
            while (dr.Read())
            {
              tmp = dr[0].ToString().Trim();
              tn = ParentNode.Nodes.Add(tmp);
              if (!OnlyPath && (dr[2].ToString() == "1"))
              {
                tn.ImageIndex = 2;
                tn.SelectedImageIndex = 2;
                tn.Tag = "1";
              }
              else
              {
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 1;
                tn.Tag = "0";
                tn.Nodes.Add("");
              }
              tn.Tag = tn.Tag.ToString() + GetFullPath(tn);
            }
            ret = true;
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
      }
      return ret;
    }

    private string GetFullPath(TreeNode node)
    {
      string ret = node.Text;

      if (node.Level == 0)
        ret = ret.Substring(0, 2) + "\\";
      else if (node.Tag.ToString().Substring(0, 1) != "1")
        ret = ret + "\\";
      while (node.Level > 0)
      {
        node = node.Parent;
        if (node.Level == 0)
          ret = node.Text.Substring(0, 2) + "\\" + ret;
        else
          ret = node.Text + "\\" + ret;
      }
      return ret;
    }

    private void SelectChange(TreeNode node)
    {
      SelectItemName = node.Tag.ToString().Substring(1);

      if (!OnlyPath && (node.Tag.ToString().Substring(0, 1) != "1")) SelectItemName = "";
      lblPath.Text = SelectItemName;
      btnOk.Enabled = (SelectItemName != "");
    }

    private void FindPath(string Path)
    {
      TreeNode node = null;
      string s = "";
      if ((Path == "") || (tv.Nodes.Count == 0)) return;
      for (int i = 0; i < tv.Nodes.Count; i++)
      {
        s = tv.Nodes[i].Tag.ToString().Substring(1);
        if (s.ToLower() == Path.Substring(0, s.Length).ToLower())
        {
          node = tv.Nodes[i];
          break;
        }
      }
      if (node == null) return;
      node.Expand();
      tv.SelectedNode = node;
      if (node.Nodes.Count > 0) node = node.Nodes[0]; else node = null;
      while (node != null)
      {
        s = node.Tag.ToString().Substring(1);
        if (s.ToLower() == Path.ToLower())
        {
          tv.SelectedNode = node;
          break;
        }
        if ((s.ToLower() != Path.ToLower()) && (s.ToLower() == Pub.GetFileNamePath(Path).ToLower())) tv.SelectedNode = node;
        if ((Path.Length >= s.Length) && (s.ToLower() == Path.Substring(0, s.Length).ToLower()))
        {
          node.Expand();
          tv.SelectedNode = node;
          if (node.Nodes.Count > 0) node = node.Nodes[0]; else node = null;
          continue;
        }
        node = node.NextNode;
      }
      if (tv.SelectedNode != null) SelectChange(tv.SelectedNode);
    }
  }
}