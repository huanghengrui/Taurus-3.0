using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmMJSeaUserPwd : frmBaseDialog
    {

        protected override void InitForm()
        {
            formCode = "MJSeaUserPwd";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
        }
        public frmMJSeaUserPwd()
        {
            InitializeComponent();
        }
   
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtMacSeriesUserName.Text == "")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), lbMacSeriesUserName.Text));
                txtMacSeriesUserName.Focus();
                return;
            }

            if(txtPwd1.Text=="")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label1.Text));
                txtPwd1.Focus();
                return;
            }
            if (txtPwd2.Text == "")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label2.Text));
                txtPwd2.Focus();
                return;
            }
            if (txtPwd2.Text != txtPwd1.Text)
            {
                Pub.MessageBoxShow(Pub.GetResText("", "Error001", ""));
                txtPwd2.Focus();
                return;
            }

            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(this.Text, label1.Text, txtMacSeriesUserName.Text+":"+txtPwd2.Text,4,null);
            frm.ShowDialog();
        }
    }
}
