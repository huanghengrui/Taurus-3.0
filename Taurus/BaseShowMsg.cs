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
    public partial class frmBaseShowMsg : frmBaseDialog
    {
        private string Str;

        protected override void InitForm()
        {
            formCode = "BaseShowMsg";
            base.InitForm();
            label1.Text = Str;
            toolTip.SetToolTip(label1, Str);
            this.Text = Title;
            Application.DoEvents();
        }

        public frmBaseShowMsg(string title, string str)
        {
            Title = title;
            Str = str;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
