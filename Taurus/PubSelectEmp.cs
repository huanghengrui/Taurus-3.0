using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmPubSelectEmp : frmBaseDialog
  {
    private TreeNode findNode = null;
    private string otherCoin = "";
    public string EmpNo = "";
    public string EmpName = "";
    public string CardNo10 = "";
    public string CardNo81 = "";
    public string CardNo82 = "";
    public string DepartID = "";
    public string DepartName = "";

    protected override void InitForm()
    {
      formCode = "PubSelectEmp";
      base.InitForm();
      EmpNo = "";
      EmpName = "";
      CardNo10 = "";
      CardNo81 = "";
      CardNo82 = "";
      if (IgnoreDimission) otherCoin += Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
      InitDepartTreeView(tvEmp, true, otherCoin);
      lblQuickSearchToolTip.ForeColor = Color.Blue;
    }

    public frmPubSelectEmp()
    {
      InitializeComponent();
    }

    public frmPubSelectEmp(bool IgnoreDim)
    {
      IgnoreDimission = IgnoreDim;
      InitializeComponent();
    }

    public frmPubSelectEmp(string OtherCoin)
    {
      otherCoin = OtherCoin;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (tvEmp.SelectedNode == null || tvEmp.SelectedNode.Nodes.Count > 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
        return;
      }
      EmpNo = tvEmp.SelectedNode.Tag.ToString();
      if (!SystemInfo.db.GetEmpInfoCard(EmpNo, ref EmpName, ref CardNo10, ref CardNo81, ref CardNo82, 
        ref DepartID, ref DepartName, otherCoin)) return;
      if (EmpName.Trim() == "") EmpName = EmpNo;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void tvEmp_DoubleClick(object sender, EventArgs e)
    {
      btnOk.PerformClick();
    }

    private bool FindNode(string findText, TreeNode nod)
    {
      bool ret = false;
      for (int i = 0; i < nod.Nodes.Count; i++)
      {
        if (nod.Nodes[i].Text.IndexOf(findText) != -1)
        {
          if (findNode != null && findNode.Index >= nod.Nodes[i].Index) continue;
          findNode = nod.Nodes[i];
          ret = true;
          break;
        }
        else
        {
          ret = FindNode(findText, nod.Nodes[i]);
          if (ret) break;
        }
      }
      return ret;
    }

    private void txtFind_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Enter) return;
      string s = txtFind.Text;
      if (s == "") return;
      bool isFind = false;
      for (int i = 0; i < tvEmp.Nodes.Count; i++)
      {
        if (tvEmp.Nodes[i].Text.IndexOf(s) != -1)
        {
          if (findNode != null && findNode.Index >= tvEmp.Nodes[i].Index) continue;
          findNode = tvEmp.Nodes[i];
          isFind = true;
          break;
        }
        else
        {
          isFind = FindNode(s, tvEmp.Nodes[i]);
          if (isFind) break;
        }
      }
      if (!isFind) findNode = null;
      if (findNode != null) tvEmp.SelectedNode = findNode;
    }
  }
}