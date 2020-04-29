using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmPubSelectDepart : frmBaseDialog
  {
    public string DepartID = "";
    public string DepartName = "";

    protected override void InitForm()
    {
      formCode = "PubSelectDepart";
      base.InitForm();
      DepartID = "";
      DepartName = "";
      InitDepartTreeView(tvDepart);
    }

    public frmPubSelectDepart()
    {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (tvDepart.SelectedNode == null)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectDepart", ""));
        return;
      }
      DepartID = tvDepart.SelectedNode.Tag.ToString();
      DepartName = tvDepart.SelectedNode.Text;
      DepartName = DepartName.Substring(DepartName.IndexOf(']') + 1);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void tvDepart_DoubleClick(object sender, EventArgs e)
    {
      btnOk.PerformClick();
    }
  }
}