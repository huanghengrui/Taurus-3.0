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
    public partial class frmMJStarParam : frmBaseDialog
    {
        public string MacSN = "";
        protected override void InitForm()
        {
            formCode = "MJStarParam";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
            SetTextboxNumber(txtOpenDoorDelay);
            SetTextboxNumber(txtAlarmDelay);
            SetTextboxNumber(txtReverifyTime);
            SetTextboxNumber(txtScreensaversTime);
            SetTextboxNumber(txtSleepTime);
            cbbVerifyMode.Items.AddRange(new object[] {
                new StarVerifyModeType("1", Pub.GetResText(formCode,"PersonalPunchInMode","")),
                new StarVerifyModeType("2", "Face or Finger or Card or Password"),
                new StarVerifyModeType("3", "Password + (Face or Finger)"),
                new StarVerifyModeType("4", "Card + (Face or Finger)"),
                new StarVerifyModeType("6", "Finger + Face")
            });
            cbbVerifyMode.SelectedIndex = 0;
            cbbLanguage.Items.AddRange(new object[] {
                new LanguageType("ar",Pub.GetResText(formCode,"Arabic","")),
                new LanguageType("CHS",Pub.GetResText(formCode,"SimplifiedChinese","")),
                new LanguageType("CHT",Pub.GetResText(formCode,"TraditionalChinese","")),
                new LanguageType("en",Pub.GetResText(formCode,"English","")),
                new LanguageType("KR",Pub.GetResText(formCode,"Korean","")),
                new LanguageType("th",Pub.GetResText(formCode,"ThaiLanguage","")),
                new LanguageType("tr",Pub.GetResText(formCode,"Turkish","")),
                new LanguageType("es-AR",Pub.GetResText(formCode,"Spanish-Argentine","")),
                new LanguageType("es",Pub.GetResText(formCode,"Spanish","")),
                new LanguageType("pt",Pub.GetResText(formCode,"Portuguese","")),
                new LanguageType("pt-BR",Pub.GetResText(formCode,"Portuguese-Brazilian","")),
                new LanguageType("FRA",Pub.GetResText(formCode,"French","")),
                new LanguageType("id",Pub.GetResText(formCode,"Indonesian","")),
                new LanguageType("de",Pub.GetResText(formCode,"German","")),
                new LanguageType("fa",Pub.GetResText(formCode,"Persian","")),
                new LanguageType("ja",Pub.GetResText(formCode,"Japanese","")),
                new LanguageType("vi",Pub.GetResText(formCode,"Vietnamese","")),  
             });
            cbbLanguage.SelectedIndex = 0;
            RefreshParameter();
        }
        public frmMJStarParam()
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
                    txtDevName.Text = dr["DevName"].ToString();
                    cbbWiegandType.Text = dr["WiegandType"].ToString();
                    foreach(LanguageType type in cbbLanguage.Items)
                    {
                        if(dr["DevLanguage"].ToString() == type.id)
                        {
                            cbbLanguage.SelectedItem = type;
                            break;
                        }
                    }
                  
                    cbbVolume.Text = dr["Volume"].ToString();
                    txtOpenDoorDelay.Text = dr["OpenDoorDelay"].ToString();
                    txtAlarmDelay.Text = dr["AlarmDelay"].ToString();
                    txtReverifyTime.Text = dr["ReverifyTime"].ToString();
                    txtScreensaversTime.Text = dr["ScreensaversTime"].ToString();
                    txtSleepTime.Text = dr["SleepTime"].ToString();

                    foreach(StarVerifyModeType starVerify in cbbVerifyMode.Items)
                    {
                        if(starVerify.id == dr["verifyMode"].ToString())
                        {
                            cbbVerifyMode.SelectedItem = starVerify;
                            break;
                        }
                    }

                    MacSN = dr["MacSN"].ToString();
                    if (dr["AntiPass"].ToString() == "yes")
                        chkAntiPass.Checked = true;
                    else
                        chkAntiPass.Checked = false;

                    if (dr["TamperAlarm"].ToString() == "yes")
                        chkTamperAlarm.Checked = true;
                    else
                        chkTamperAlarm.Checked = false;

                    if(dr["TamperAlarm"].ToString()=="")
                    {
                        DefaultParameter();
                    }
                }
                else
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
            txtDevName.Text = "DynamicDev";
            cbbWiegandType.SelectedIndex = 1;
          
            cbbLanguage.SelectedIndex = 1;
            cbbVolume.SelectedIndex = 5;
            chkAntiPass.Checked = false;
            txtOpenDoorDelay.Text = "7";
            chkTamperAlarm.Checked = false;
            txtAlarmDelay.Text = "5";
            txtReverifyTime.Text = "1";
            txtScreensaversTime.Text = "0";
            txtSleepTime.Text = "0";
            cbbVerifyMode.SelectedIndex = 1;
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
            if (string.IsNullOrEmpty(cbbLanguage.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""), lbLanguage.Text));
                return;
            }
            if (string.IsNullOrEmpty(cbbVerifyMode.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""), lbVerifyMode.Text));
                return;
            }

            if (string.IsNullOrEmpty(cbbWiegandType.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""), lbWiegandType.Text));
                return;
            }
            if (string.IsNullOrEmpty(cbbVolume.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""), lbVolume.Text));
                return;
            }

            if (string.IsNullOrEmpty(txtOpenDoorDelay.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbOpenDoorDelay.Text));
                txtOpenDoorDelay.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtAlarmDelay.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbAlarmDelay.Text));
                txtAlarmDelay.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtReverifyTime.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbReverifyTime.Text));
                txtReverifyTime.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtScreensaversTime.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbScreensaversTime.Text));
                txtScreensaversTime.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSleepTime.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), lbSleepTime.Text));
                txtSleepTime.Focus();
                return;
            }

            string deviceName = txtDevName.Text.Trim();
            string wiegandType = cbbWiegandType.Text;
            string language =((LanguageType)cbbLanguage.SelectedItem).id;
            string volume = cbbVolume.Text;
            string antiPass = "";
            string openDoorDelay = txtOpenDoorDelay.Text.Trim();
            string tamperAlarm = "";
            string alarmDelay = txtAlarmDelay.Text.Trim();
            string reverifyTime = txtReverifyTime.Text.Trim();
            string screensaversTime = txtScreensaversTime.Text.Trim();
            string sleepTime = txtSleepTime.Text.Trim();
            string verifyMode = ((StarVerifyModeType)cbbVerifyMode.SelectedItem).id;

            if (chkAntiPass.Checked)
                antiPass = "yes";
            else
                antiPass = "no";

            if(chkTamperAlarm.Checked)
                tamperAlarm = "yes";
            else
                tamperAlarm = "no";

            string cmd = "SetDeviceSetting";
            string sql = "";
            try
            {
                if (MacSN == "")
                {
                    sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "22", "1", deviceName, wiegandType, language,
                    antiPass,openDoorDelay,tamperAlarm,alarmDelay,volume,reverifyTime,screensaversTime,
                    sleepTime,verifyMode});
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "23", deviceName, wiegandType, language,
                    antiPass,openDoorDelay,tamperAlarm,alarmDelay,volume,reverifyTime,screensaversTime,
                    sleepTime,verifyMode,MacSN});
                }

                if (SystemInfo.db.ExecSQL(sql) >= 0)
                {
                    ParameterInfo parameterInfoCmd = new ParameterInfo(deviceName, wiegandType, language, volume, antiPass,
                      openDoorDelay, tamperAlarm, alarmDelay, reverifyTime, screensaversTime, sleepTime, verifyMode);
                    _DeviceCmd<ParameterInfo> devParameterInfoCmd = new _DeviceCmd<ParameterInfo>(cmd, parameterInfoCmd);
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
                    _ResultInfo<ParameterInfo> parameterInfo = JsonConvert.DeserializeObject<_ResultInfo<ParameterInfo>>(frm.BodyParameter.ToString());
                  
                    if (MacSN == "")
                    {
                        sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "22", "1", parameterInfo.result_data.devName, parameterInfo.result_data.wiegandType, parameterInfo.result_data.language,
                    parameterInfo.result_data.antiPass,parameterInfo.result_data.openDoorDelay,parameterInfo.result_data.tamperAlarm,parameterInfo.result_data.alarmDelay,
                    parameterInfo.result_data.volume,parameterInfo.result_data.reverifyTime,parameterInfo.result_data.screensaversTime,
                    parameterInfo.result_data.sleepTime,parameterInfo.result_data.verifyMode});
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "23", parameterInfo.result_data.devName, parameterInfo.result_data.wiegandType, parameterInfo.result_data.language,
                    parameterInfo.result_data.antiPass,parameterInfo.result_data.openDoorDelay,parameterInfo.result_data.tamperAlarm,parameterInfo.result_data.alarmDelay,
                    parameterInfo.result_data.volume,parameterInfo.result_data.reverifyTime,parameterInfo.result_data.screensaversTime,
                    parameterInfo.result_data.sleepTime,parameterInfo.result_data.verifyMode,"1"});
                    }
                    SystemInfo.db.ExecSQL(sql);
                    Pub.MessageBoxShow(Pub.GetResText("", "MsgReadEndData", ""));
                }

                RefreshParameter();
            }
        }
        public class StarVerifyModeType
        {
            private string _id;
            private string _name;

            public StarVerifyModeType(string id, string name)
            {
                _id = id;
                _name = name;
            }

            public string id
            {
                get { return _id; }
                set { _id = value; }
            }

            public string name
            {
                get { return _name; }
                set { _name = value; }
            }

            public override string ToString()
            {
                return _name;
            }
        }
        public class LanguageType
        {
            private string _id;
            private string _name;

            public LanguageType(string id, string name)
            {
                _id = id;
                _name = name;
            }

            public string id
            {
                get { return _id; }
                set { _id = value;}
            }

            public string name
            {
                get { return _name; }
                set { _name = value; }
            }

            public override string ToString()
            {
                return _name;
            }
        }
    }
}
