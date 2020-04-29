using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmSYSetPort : frmBaseDialog
    {
        private string oprt = "";

        protected override void InitForm()
        {
            formCode = "SYSetPort";
            IsAllEmpInfo = true;
            SetTextboxNumber(txtRegularPort);
            SetTextboxNumber(txtSeaPort);
            SetTextboxNumber(txtStarPort);
            base.InitForm();
            this.Text = oprt;
            lbSeaPort.Visible = SystemInfo.ShowSEA == 1;
            txtSeaPort.Visible = SystemInfo.ShowSEA == 1;

            lbStarPort.Visible = SystemInfo.ShowSTAR == 1;
            txtStarPort.Visible = SystemInfo.ShowSTAR == 1;
            txtRegularPort.Text = SystemInfo.db.ReadConfig("SystemInfo", "RegularPort","7005");
            txtSeaPort.Text = SystemInfo.db.ReadConfig("SystemInfo", "SeaPort", "8080");
            txtStarPort.Text = SystemInfo.db.ReadConfig("SystemInfo", "StarPort", "8001");
        }

        public frmSYSetPort(string Oprt)
        {
            InitializeComponent();
            oprt = Oprt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.WriteConfig("SystemInfo", "RegularPort", txtRegularPort.Text.Trim())) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "SeaPort", txtSeaPort.Text.Trim())) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "StarPort", txtStarPort.Text.Trim())) return;

            SystemInfo.RegularPort = Convert.ToInt32(txtRegularPort.Text.Trim());
            SystemInfo.SeaPort = Convert.ToInt32(txtSeaPort.Text.Trim());
            SystemInfo.StarPort = Convert.ToInt32(txtStarPort.Text.Trim());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
