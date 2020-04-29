using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmMJSetTimer : frmBaseDialog
    {


        protected override void InitForm()
        {
            SetTextboxNumber(txtTimer);
            formCode = "MJSetTimer";
            txtTimer.Focus();
            base.InitForm();
            this.Text = Title;
            label2.Text = Pub.GetResText("PubDevSet", "lbSecond", "");
        }

        public frmMJSetTimer(string title)
        {
            Title = title;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime();
            if (txtTimer.Text == "" || txtTimer.Text == null || int.Parse(txtTimer.Text) < 0)
            {
                string tmp = string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), label1.Text);
                Pub.MessageBoxShow(tmp, MessageBoxIcon.Error);
                txtTimer.Focus();
                return;

            }
            time = DateTime.Now;
            SystemInfo.SetTimer = time.AddSeconds(int.Parse(txtTimer.Text));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtTimer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null,null);
            }
        }
    }
}
