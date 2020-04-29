using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmRSConvertDepart : frmBaseDialog
    {
        private string GUID = "";

        protected override void InitForm()
        {
            formCode = "RSEmpAdd";
            base.InitForm();
            this.Text = Title;
            txtDepartName.Text = SystemInfo.CommanyName;
            txtDepartName.Tag = SystemInfo.CommanyID;
        }

         public frmRSConvertDepart(string titel, string guid)
        {
            InitializeComponent();
            Title = titel;
            GUID = guid;
        }
       
        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
           
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepartName.Text = frm.DepartName;
                txtDepartName.Tag = frm.DepartID;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int ret = 0;
            try
            {
                string sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "38", txtDepartName.Tag.ToString(), GUID });
                ret = SystemInfo.db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }

            if (ret > 0)
            {
                Pub.MessageBoxShow(this.Text + Pub.GetResText("", "FK_RUN_SUCCESS", ""));
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
