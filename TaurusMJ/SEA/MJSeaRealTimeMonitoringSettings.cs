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
    public partial class frmMJRealTimeMonitoringSettings : frmBaseDialog
    {

        protected override void InitForm()
        {
            formCode = "MJRealTimeMonitoringSettings";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
            SetTextboxNumber(txtPort);
            txtIP.Text = GetLocalIP();
            txtPort.Text = "8080";
        }
        public frmMJRealTimeMonitoringSettings()
        {
            InitializeComponent();
        }
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName();
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        string ip = "";
                        ip = IpEntry.AddressList[i].ToString();
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtIP.Text=="")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect",""),label1.Text));
                txtIP.Focus();
                return;
            }
            if (txtPort.Text == "")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label2.Text));
                txtPort.Focus();
                return;
            }
           
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(this.Text, Pub.GetResText("", "btnSeaSeriesOprt", ""), "http://"+txtIP.Text+":"+txtPort.Text,1,null);
            frm.ShowDialog();
        }
    }
}
