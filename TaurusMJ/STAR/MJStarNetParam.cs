using Newtonsoft.Json;
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
    public partial class frmMJStarNetParam : frmBaseDialog
    {
        public string MacSN = "";
        protected override void InitForm()
        {
            formCode = "MJStarNetParam";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
           
            SetTextboxNumber(txtServerPort);
            SetTextboxNumber(txtPushServerPort);
            SetTextboxNumber(txtInterval);
         
            RefreshParameter();
        }
        public frmMJStarNetParam()
        {
            InitializeComponent();
        }

        public void RefreshParameter()
        {
            DataTableReader dr = null;

            string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "21" });

            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    txtServerHost.Text = dr["ServerHost"].ToString();
                    txtServerPort.Text = dr["ServerPort"].ToString();
                    txtPushServerHost.Text = dr["PushServerHost"].ToString();
                    txtPushServerPort.Text = dr["PushServerPort"].ToString();
                    txtInterval.Text = dr["Interval"].ToString();
                    if (dr["pushEnable"].ToString() == "yes")
                        chkPushEnable.Checked = true;
                    else
                        chkPushEnable.Checked = false;
                    MacSN = dr["MacSN"].ToString();
                }
                if (string.IsNullOrEmpty(txtServerHost.Text) || string.IsNullOrEmpty(txtPushServerHost.Text))
                {
                    DefaultParameter();
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                dr = null;
            }
            Application.DoEvents();
        }
        /// <summary>
        /// 默认参数
        /// </summary>
        private void DefaultParameter()
        {
            txtServerHost.Text = GetLocalIP();
            txtServerPort.Text = "8002";
            txtPushServerHost.Text = GetLocalIP();
            txtPushServerPort.Text = "8001";
            txtInterval.Text = "1";
            chkPushEnable.Checked = false;
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
            string serverHost = txtServerHost.Text.Trim();
            string serverPort = txtServerPort.Text.Trim();
            string pushServerHost = txtPushServerHost.Text.Trim();
            string pushServerPort = txtPushServerPort.Text.Trim();
            string interval = txtInterval.Text.Trim();

            if(string.IsNullOrEmpty(serverHost))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbServerHost.Text));
                txtServerHost.Focus();
                return;
            }
            if (string.IsNullOrEmpty(serverPort))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbServerPort.Text));
                txtServerPort.Focus();
                return;
            }
            if (string.IsNullOrEmpty(pushServerHost))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbPushServerHost.Text));
                txtPushServerHost.Focus();
                return;
            }
            if (string.IsNullOrEmpty(pushServerPort))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbPushServerPort.Text));
                txtPushServerPort.Focus();
                return;
            }
            if (string.IsNullOrEmpty(interval))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbInterval.Text));
                txtInterval.Focus();
                return;
            }

            string pushEnable = "";
            if(chkPushEnable.Checked)
                pushEnable = "yes";
            else
                pushEnable = "no";
            string cmd = "SetDeviceSetting";
            string sql = "";
            try
            {
                if (MacSN == "")
                {
                    sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "24", "1", serverHost,serverPort,pushServerHost,pushServerPort,interval, pushEnable });
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "25", serverHost,serverPort,pushServerHost,pushServerPort,interval, pushEnable, MacSN});
                }


                if (SystemInfo.db.ExecSQL(sql) >= 0)
                {
                    NetParameterInfo parameterInfoCmd = new NetParameterInfo(serverHost, serverPort, pushServerHost, pushServerPort, interval, pushEnable);
                    _DeviceCmd<NetParameterInfo> devParameterInfoCmd = new _DeviceCmd<NetParameterInfo>(cmd, parameterInfoCmd);
                    StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devParameterInfoCmd));
                    frmMJStarOprt frm = new frmMJStarOprt(this.Text, btnOk.Text, jsonStringBuilder, 1, null);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Pub.ShowErrorMsg(ex, sql);
            }
        }
        private string GetGUID()
        {
            string ret = System.Guid.NewGuid().ToString().ToUpper();
            return ret;
        }


        private void btnGetParam_Click(object sender, EventArgs e)
        {
            string cmd = "GetDeviceSetting";
            string sql = "";
            DeviceCmd devGetDeviceSettingCmd = new DeviceCmd(cmd);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devGetDeviceSettingCmd));
            frmMJStarOprt frm = new frmMJStarOprt(this.Text, btnGetParam.Text, jsonStringBuilder, 2, null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.BodyParameter.Length > 0)
                {
                    _ResultInfo<NetParameterInfo> parameterInfo = JsonConvert.DeserializeObject< _ResultInfo<NetParameterInfo>> (frm.BodyParameter.ToString());
                    if (MacSN == "")
                    {
                        sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "24", "1", parameterInfo.result_data.serverHost,parameterInfo.result_data.serverPort,parameterInfo.result_data.pushServerHost,
                    parameterInfo.result_data.pushServerPort,parameterInfo.result_data.interval,parameterInfo.result_data.pushEnable});
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "25", parameterInfo.result_data.serverHost,parameterInfo.result_data.serverPort,parameterInfo.result_data.pushServerHost,
                    parameterInfo.result_data.pushServerPort,parameterInfo.result_data.interval,parameterInfo.result_data.pushEnable,MacSN});
                    }
                    
                    Pub.MessageBoxShow(Pub.GetResText("", "MsgReadEndData", ""));
                }
                if (SystemInfo.db.ExecSQL(sql) >= 0)
                    RefreshParameter();
            }
        }
    }
}
