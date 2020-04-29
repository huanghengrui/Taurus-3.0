using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmPubSelectDevGroup : frmBaseDialog
    {

         public string GroupID = "";
         public string GroupName = "";
         
         protected override void InitForm()
         {
           formCode = "PubSelectDevGroup";
           base.InitForm();
           GroupID = "";
           GroupName = "";
           InitDevGroupTreeView(tvGroup, false, "");
         }
        public frmPubSelectDevGroup()
        {
            InitializeComponent();
        }

         private void btnOk_Click(object sender, EventArgs e)
        {
          if (tvGroup.SelectedNode == null)
          {
            Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectDepart", ""));
            return;
          }
          GroupID = tvGroup.SelectedNode.Tag.ToString();
          GroupName = tvGroup.SelectedNode.Text;
          GroupName = GroupName.Substring(GroupName.IndexOf(']') + 1);
          this.DialogResult = DialogResult.OK;
          this.Close();
        }

        private void tvGroup_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
