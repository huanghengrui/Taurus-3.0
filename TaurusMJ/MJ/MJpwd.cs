using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmMJpwd : frmBaseDialog
    {

        protected override void InitForm()
        {
            SetTextboxNumber(txtTimer);
            formCode = "MJpwd";
            base.InitForm();
            this.Text = Title;
        }

        public frmMJpwd(string title)
        {
            Title = title;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            string OprtPWD = Pub.GetOprtEncrypt(txtTimer.Text.Trim());
            string PWD = OprtPWD;
            if (PWD == "") PWD = Pub.GetOprtEncrypt("0");
            DataTableReader dr = null;
           
            string Pass = "";
            if (txtTimer.Text == "" || txtTimer.Text == null || int.Parse(txtTimer.Text) < 0)
            {
                string tmp = string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), label1.Text);
                Pub.MessageBoxShow(tmp, MessageBoxIcon.Error);
                txtTimer.Focus();
                return;
            }
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "2", OprtInfo.OprtNo }));
            dr.Read();
            Pass = dr["OprtPWD"].ToString();
            if (Pass != OprtPWD && Pass != PWD)
            {
                txtTimer.Focus();
                string tmp = string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), label1.Text);
                Pub.MessageBoxShow(tmp, MessageBoxIcon.Error);
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
