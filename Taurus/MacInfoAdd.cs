
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmMacInfoAdd : frmBaseDialog
    {
        private int MacSN = 0;
        private string MacSN_GPRS = "";
        private string MacConnType = "";
        private string MacIP = "";
        private string MacPort = "";
        private string MacConnPWD = "";
        private string MacDesc = "";
        private string MacParamStr = "";
        private bool IsGPRS = false;
        private int MacSeriesTypeId = 0;
        private string MacSeriesTypeName = "";
        private string SeaSeriesPwd = "";
        private string MacSeriesUserName = "";
        private string InOutMode = "";
        private string MacDevGroupID = "";
        private string MacModeID = "";

        protected override void InitForm()
        {
            formCode = "MacInfoAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            lblMacSN.ForeColor = Color.Red;
            lblLANIP.ForeColor = Color.Red;
            lblLANPort.ForeColor = Color.Red;

            lbMsgGetMacNo.Text = string.Format(Pub.GetResText("", "MsgGetMacNo", ""), Pub.GetResText("", "SeaDev", ""));

            SetTextboxNumber(txtLANPort);

            cbbMacType.Items.AddRange(new object[] {
                new MacType(1,Pub.GetResText("","StaticDev",""))
                });

            if (SystemInfo.ShowSEA == 1)
            {
                cbbMacType.Items.AddRange(new object[] {
                new MacType(2,Pub.GetResText("","SeaDev",""))
                });
            }
            if (SystemInfo.ShowSTAR == 1)
            {
                cbbMacType.Items.AddRange(new object[] {
                new MacType(3,Pub.GetResText("","StarDev",""))
                });
            }
           
            cbbInOutMode.Items.AddRange(new object[] { Pub.GetResText("","LOG_IOMODE_IO",""),
                Pub.GetResText("","LOG_IOMODE_IN1",""),
                Pub.GetResText("","LOG_IOMODE_OUT1",""),
                });
            cbbInOutMode.SelectedIndex = 0;

            cbbMacMode.Items.AddRange(new object[] { Pub.GetResText("","LOG_DEVMODE_KQMJ",""),
                Pub.GetResText("","LOG_DEVMODE_KQ",""),
                Pub.GetResText("","LOG_DEVMODE_MJ",""),
                });
           

            if (SystemInfo.AllowMJ)
            {
                cbbMacMode.SelectedIndex = 0;
                cbbMacType.Visible = true;
                lbMacType.Visible = true;
                txtMacSeriesUserName.Visible = true;
                lbMacSeriesUserName.Visible = true;
                cbbMacMode.Enabled = true;
            }
            else
            {
                cbbMacMode.SelectedIndex = 1;
                cbbMacType.Visible = false;
                lbMacType.Visible = false;
                txtMacSeriesUserName.Visible = false;
                lbMacSeriesUserName.Visible = false;
                cbbMacMode.Enabled = false;
            }

            int index = 0;

            if(cbbMacType.Items.Count > 0)
            {
                cbbMacType.SelectedIndex = 0;
                index = ((MacType)cbbMacType.SelectedItem).id;
            }

            switch (index)
            {
                case 2:
                    txtMacSeriesUserName.Visible = true;
                    lbMacSeriesUserName.Visible = true;
                    cbbInOutMode.Visible = true;
                    chkGPRS.Visible = false;
                    pnlLAN.Height = 95;
                    panel6.Height = 300;
                    this.Height = 30 + panel6.Height + panel5.Height + panel4.Height;
                    panel4.Visible = true;
                    label2.Visible = true;
                    break;
                case 3:
                    txtMacSeriesUserName.Visible = false;
                    lbMacSeriesUserName.Visible = false;
                    cbbInOutMode.Visible = false;
                    chkGPRS.Visible = true;
                    pnlLAN.Height = 63;
                    panel6.Height = 270;
                    panel4.Visible = false;
                    this.Height = 30 + panel6.Height + panel5.Height;
                    label2.Visible = false;
                    break;
                default:
                    txtMacSeriesUserName.Visible = false;
                    lbMacSeriesUserName.Visible = false;
                    cbbInOutMode.Visible = false;
                    chkGPRS.Visible = true;
                    panel4.Visible = false;
                    pnlLAN.Height = 63;
                    panel6.Height = 270;
                    this.Height = 30 + panel6.Height + panel5.Height;
                    label2.Visible = false;
                    break;
            }
            LoadData();
            RadioButton_Click(null, null);
        }

        public frmMacInfoAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private MacType GetMacType(int id)
        {
            foreach(MacType type in cbbMacType.Items)
            {
                if(type.id == id)
                {
                    return type;
                }
            }
            return null;
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
                if (SysID == "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "103" }));
                    if (dr.Read())
                    {
                        int no = 0;
                        int.TryParse(dr[0].ToString(), out no);
                        if (no == 0)
                        {
                            no++;
                        }
                        txtMacSN.Text = no.ToString();
                    }
                }
                else
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "2", SysID }));
                    if (dr.Read())
                    {
                        txtMacSN.Text = dr["MacSN"].ToString();
                        txtDevGroup.Text = dr["DevGroupName"].ToString();
                        txtDevGroup.Tag = dr["DevGroupID"].ToString();
                        int id = 0;
                        Int32.TryParse(dr["MacSeriesTypeId"].ToString(), out id);
                        int InOutModeId = 0;
                        Int32.TryParse(dr["InOutMode"].ToString(), out InOutModeId);
                        cbbInOutMode.SelectedIndex = InOutModeId;

                        int DevModeId = 0;
                        Int32.TryParse(dr["DevModeID"].ToString(), out DevModeId);
                        cbbMacMode.SelectedIndex = DevModeId;
                        MacType type = GetMacType(id);
                        if (type != null)
                        {
                            cbbMacType.SelectedItem = type;
                        }

                        switch (dr["MacConnType"].ToString())
                        {
                            case MacConnTypeString.USB:
                                rbUSB.Checked = true;
                                break;
                            case MacConnTypeString.LAN:
                                rbLAN.Checked = true;
                                txtLANIP.Text = dr["MacIP"].ToString();
                                txtLANPort.Text = dr["MacPort"].ToString();
                                txtLANPWD.Text = dr["MacConnPWD"].ToString();
                                chkGPRS.Checked = Pub.ValueToBool(dr["IsGPRS"]);
                                break;
                        }
                        txtDesc.Text = dr["MacDesc"].ToString();
                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            pnlLAN.Enabled = rbLAN.Checked;
            if (sender == null) return;
            if (rbLAN.Checked)
            {
                if (txtLANPort.Text == "") txtLANPort.Text = "5005";
                txtLANPWD.Text = "";
                if(cbbMacType.SelectedIndex!=2)
                {
                    txtMacSeriesUserName.Enabled = false;
                }
            }
            else
            {
                txtLANPort.Text = "";
                txtLANPWD.Text = "";
            }
        }

        private bool CheckValue()
        {
            if (cbbMacType.Text == "")
            {
                MacSeriesTypeId = 0;
                MacSeriesTypeName = "";
            }
            else
            {
                if (cbbMacType.Items.Count > 0)
                {
                    MacSeriesTypeId = ((MacType)cbbMacType.SelectedItem).id;
                    MacSeriesTypeName = ((MacType)cbbMacType.SelectedItem).name;
                }
                else
                {
                    MacSeriesTypeId = 0;
                    MacSeriesTypeName = "";
                }
            }
            if (txtMacSN.Text.Trim() == "")
            {
                txtMacSN.Focus();
                ShowErrorEnterCorrect(lblMacSN.Text);
                return false;
            }
            if (rbLAN.Checked) IsGPRS = chkGPRS.Checked;
            if (!IsGPRS && !Pub.IsNumeric(txtMacSN.Text.Trim())&& MacSeriesTypeId != 3)
            {
                txtMacSN.Focus();
                ShowErrorEnterCorrect(lblMacSN.Text);
                return false;
            }
            if (IsGPRS|| MacSeriesTypeId == 3)
                MacSN_GPRS = txtMacSN.Text.Trim();
            else
            {
                MacSN = Convert.ToInt32(txtMacSN.Text.Trim());
                MacSN_GPRS = MacSN.ToString();
            }
            MacConnType = MacConnTypeString.USB;
            MacIP = "";
            MacPort = "";
            MacConnPWD = "";
            MacDesc = "";
            MacParamStr = "";
            if (rbLAN.Checked)
            {
                MacConnType = MacConnTypeString.LAN;
                MacIP = txtLANIP.Text.Trim();
                MacPort = txtLANPort.Text.Trim();
                if (MacIP == "")
                {
                    txtLANIP.Focus();
                    ShowErrorEnterCorrect(lblLANIP.Text);
                    return false;
                }
                if (!Pub.CheckTextMaxLength(lblLANIP.Text, MacIP, txtLANIP.MaxLength))
                {
                    txtLANIP.Focus();
                    return false;
                }
                if (!Pub.IsNumeric(MacPort))
                {
                    txtLANPort.Focus();
                    ShowErrorEnterCorrect(lblLANPort.Text);
                    return false;
                }
                MacConnPWD = txtLANPWD.Text.Trim();
                SeaSeriesPwd = txtLANPWD.Text.Trim();
                if (MacSeriesTypeId != 2)
                {
                    if (MacConnPWD != "" && !Pub.IsNumeric(MacConnPWD))
                    {
                        txtLANPWD.Focus();
                        ShowErrorEnterCorrect(label3.Text);
                        return false;
                    }
                }

                IsGPRS = chkGPRS.Checked;
            }
            MacDesc = txtDesc.Text.Trim();
            if (!Pub.CheckTextMaxLength(label1.Text, MacDesc, txtDesc.MaxLength))
            {
                txtDesc.Focus();
                return false;
            }

            MacModeID = cbbMacMode.SelectedIndex.ToString();
            InOutMode = cbbInOutMode.SelectedIndex.ToString();
            MacSeriesUserName = txtMacSeriesUserName.Text;
            return true;
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            if (!CheckValue()) return;
            TDIConnInfo connInfo = Pub.ValueToDIConnInfo(MacSN, MacSN_GPRS, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS, MacSeriesTypeId, SeaSeriesPwd, MacSeriesUserName);
            this.Enabled = false;
            string dt = "";
            bool ret = false;
            string msg = "";
            string Online = "";
            DateTime dTime = new DateTime();
            try
            {
                switch (MacSeriesTypeId)
                {
                    case 2:
                        if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                        {
                            if (RegisterInfo.EndDate < DateTime.Now)
                            {
                                Pub.MessageBoxShow(RegisterInfo.StateText);
                                return;
                            }
                        }
                        try
                        {
                            string url = "http://" + MacIP + "/action/GetSysTime";
                            string syncTime = "";
                            ret = DeviceObject.objFK623.POST_GetResponse(url, MacSeriesUserName, SeaSeriesPwd, ref syncTime);

                            if (ret)
                            {
                                if (syncTime != "")
                                {
                                    jsonBody<SeaSeriesSyncTime> answer = JsonConvert.DeserializeObject<jsonBody<SeaSeriesSyncTime>>(syncTime);
                                    msg = Pub.GetResText("", "FK_RUN_SUCCESS", "") + "\r\n\r\n" + answer.info.Year + "-" + answer.info.Month + "-" + answer.info.Day + " " + answer.info.Hour
                                        + ":" + answer.info.Minute + ":" + answer.info.Second;
                                    FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                                }
                                else
                                {
                                    ret = false;
                                    msg = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "") + "\r\n\r\n" + DeviceObject.objFK623.SeaBodyStr();
                                }
                            }
                            else
                            {
                                msg = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                            }
                        }
                        catch (Exception E)
                        {
                            msg = E.Message;
                        }
                        break;
                    case 3:
                        if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                        {
                            if (RegisterInfo.EndDate < DateTime.Now)
                            {
                                Pub.MessageBoxShow(RegisterInfo.StateText);
                                return;
                            }
                        }
                        string cmd = "GetDeviceInfo";
                        DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
                        StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));
                        int pwd = 0;
                        int.TryParse(MacConnPWD,out pwd);
                        if (DeviceObject.socKetClient.Open(MacIP, Convert.ToInt32(MacPort), pwd))
                        {
                            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                            {
                                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                                if (state == 0)
                                {
                                    _ResultInfo<DeviceInfo> deviceInfo = JsonConvert.DeserializeObject<_ResultInfo<DeviceInfo>>(jsonStringBuilder.ToString());

                                    string deviceId = deviceInfo.result_data.deviceId;
                                    string deviceName = deviceInfo.result_data.name;
                                    ret = true;
                                    msg = Pub.GetResText("", "FK_RUN_SUCCESS", "") + "\r\n\r\n" + deviceId + "\r\n\r\n" + deviceName;
                                }
                                else
                                {
                                    msg = DeviceObject.socKetClient.GetStarState(state);
                                }
                            }
                            else
                            {
                                ret = false;
                                msg = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                            }
                        }
                        else
                        {
                            ret = false;
                            msg = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                        }
                        DeviceObject.socKetClient.Close();
                        break;
                    default:
                        DeviceObject.objFK623.Close();
                        DeviceObject.objFK623.InitConn(connInfo);
                        DeviceObject.objFK623.Open();
                        ret = DeviceObject.objFK623.GetDeviceTime(ref dTime);
                        DeviceObject.objFK623.Close();
                        if (ret) dt = dTime.ToString();
                        msg = DeviceObject.objFK623.ErrMsg;
                        if (ret) msg = msg + "\r\n\r\n" + dt;
                        break;
                }

                if (ret)
                {
                    Online = Pub.GetResText(formCode, "Online", "");

                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "304", Online
                        , "", MacSN_GPRS}));
                    Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
                }
                else
                {
                    Online = Pub.GetResText(formCode, "Offline", "");

                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "305", Online, MacSN_GPRS }));
                    Pub.MessageBoxShow(msg);
                }
            }
            catch(Exception E)
            {
                Pub.MessageBoxShow(E.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }
       
        private void btnOk_Click(object sender, EventArgs e)
        {
            DataTableReader dr = null;
            bool IsOk = false;
            string sql = "";
            if (txtDevGroup.Text == "")
            {
                MacDevGroupID = "";
            }
            if (!CheckValue()) return;
            try
            {
                if (SysID == "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "2", MacSN_GPRS }));
                    if (dr.Read())
                    {
                        txtMacSN.Focus();
                        ShowErrorCannotRepeated(lblMacSN.Text);
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "3", MacSN_GPRS, SystemInfo.MacTypeID.ToString(), "",
              MacConnType, MacIP, MacPort, MacConnPWD, MacDesc, MacParamStr, Convert.ToByte(IsGPRS).ToString(),MacSeriesTypeId.ToString(),
              MacSeriesTypeName,MacSeriesUserName,InOutMode, MacDevGroupID,txtDevGroup.Text,MacModeID  });
                        SystemInfo.db.ExecSQL(sql);
                        IsOk = true;
                    }
                }
                else
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "4", SysID, MacSN_GPRS }));
                    if (dr.Read())
                    {
                        txtMacSN.Focus();
                        ShowErrorCannotRepeated(lblMacSN.Text);
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "5", MacSN_GPRS, SystemInfo.MacTypeID.ToString(), "",
              MacConnType, MacIP, MacPort, MacConnPWD, MacDesc, MacParamStr, Convert.ToByte(IsGPRS).ToString(),MacSeriesTypeId.ToString(), 
              MacSeriesTypeName,MacSeriesUserName,InOutMode, MacDevGroupID,txtDevGroup.Text,MacModeID, SysID });
                        SystemInfo.db.ExecSQL(sql);
                        IsOk = true;
                    }
                    if (IsOk)
                    {
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", SysID }));
                        if (dr.Read())
                        {
                            sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "204", SysID, MacSN_GPRS, "", "", "" });
                            SystemInfo.db.ExecSQL(sql);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsOk)
            {
                SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
                //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cbbMacType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = 0;

            if (cbbMacType.Items.Count > 0)
            {
                index = ((MacType)cbbMacType.SelectedItem).id;
            }

            switch (index)
            {
                case 2:
                    txtMacSeriesUserName.Text = "admin";
                    txtLANPWD.Text = "admin";
                    txtLANPort.Text = "5005";
                    btnGetMacSN.Visible = true;
                    rbLAN.Checked = true;
                    RadioButton_Click(null, null);
                    rbUSB.Enabled = false;
                    chkGPRS.Visible = false;
                    chkGPRS.Enabled = false;
                    txtMacSeriesUserName.Visible = true;
                    lbMacSeriesUserName.Visible = true;
                    chkGPRS.Checked = false;
                    cbbInOutMode.Visible = true;
                    pnlLAN.Height = 95;
                    panel6.Height = 300;
                    this.Height = 30 + panel6.Height + panel5.Height + panel4.Height;
                    panel4.Visible = true;
                    label2.Visible = true;
                    lbMacSeriesUserName.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                    break;
                case 3:
                    txtLANPort.Text = "5005";
                    txtMacSeriesUserName.Text = "";
                    txtMacSeriesUserName.Visible = false;
                    lbMacSeriesUserName.Visible = false;
                    chkGPRS.Visible = true;
                    chkGPRS.Enabled = true;
                    btnGetMacSN.Visible = true;
                    rbLAN.Checked = true;
                    RadioButton_Click(null, null);
                    rbUSB.Enabled = false;
                    txtLANPWD.Text = "";
                    cbbInOutMode.Visible = false;
                    panel4.Visible = false;
                    pnlLAN.Height = 63;
                    panel6.Height = 270;
                    this.Height = 30 + panel6.Height + panel5.Height;
                    label2.Visible = false;
                    lbMacSeriesUserName.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    break;
                default:
                    txtLANPort.Text = "5005";
                    txtMacSeriesUserName.Text = "";
                    txtMacSeriesUserName.Visible = false;
                    lbMacSeriesUserName.Visible = false;
                    chkGPRS.Visible = true;
                    chkGPRS.Enabled = true;
                    rbUSB.Enabled = true;
                    txtLANPWD.Text = "";
                    btnGetMacSN.Visible = false;
                    cbbInOutMode.Visible = false;
                    panel4.Visible = false;
                    pnlLAN.Height = 63;
                    panel6.Height = 270;
                    this.Height = 30 + panel6.Height + panel5.Height;
                    label2.Visible = false;
                    lbMacSeriesUserName.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    break;
            }
        }

        private void btnGetMacSN_Click(object sender, EventArgs e)
        {
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return;
                }
            }
            if (!CheckValue()) return;
            TDIConnInfo connInfo = Pub.ValueToDIConnInfo(MacSN, MacSN_GPRS, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS, MacSeriesTypeId, SeaSeriesPwd, MacSeriesUserName);
            this.Enabled = false;
            bool ret = false;
            string Online = "";
            string msg = "";
            try
            {
                switch (MacSeriesTypeId)
                {
                    case 2:
                        string syncTime = "";
                        string url = "http://" + MacIP + "/action/GetSysParam";
                        ret = DeviceObject.objFK623.POST_GetResponse(url, MacSeriesUserName, SeaSeriesPwd, ref syncTime);

                        if (ret)
                        {
                            if (syncTime != "")
                            {
                                jsonBody<GetSysParam> answer = JsonConvert.DeserializeObject<jsonBody<GetSysParam>>(syncTime);
                                txtMacSN.Text = answer.info.DeviceID.ToString();
                                Pub.MessageBoxShow(Pub.GetResText("", "MsgReadEndData", ""));
                                Application.DoEvents();
                            }
                        }
                        else
                        {
                            ret = false;
                            Pub.MessageBoxShow(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", ""));
                        }
                        break;
                    case 3:
                        string cmd = "GetDeviceInfo";
                        DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
                        StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));
                        int pwd = 0;
                        int.TryParse(MacConnPWD, out pwd);
                        if (DeviceObject.socKetClient.Open(MacIP, Convert.ToInt32(MacPort), pwd))
                        {
                            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                            {
                                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                                if (state == 0)
                                {
                                    _ResultInfo<DeviceInfo> deviceInfo = JsonConvert.DeserializeObject<_ResultInfo<DeviceInfo>>(jsonStringBuilder.ToString());

                                    string deviceId = deviceInfo.result_data.deviceId;
                                    string deviceName = deviceInfo.result_data.name;
                                    txtMacSN.Text = deviceId;
                                    ret = true;
                                    Pub.MessageBoxShow(Pub.GetResText("", "MsgReadEndData", ""));
                                }
                                else
                                {
                                    ret = false;
                                    msg = DeviceObject.socKetClient.GetStarState(state);
                                }
                            }
                            else
                            {
                                ret = false;
                                Pub.MessageBoxShow(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", ""));
                            }

                        }
                        else
                        {
                            ret = false;
                            Pub.MessageBoxShow(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", ""));
                        }
                        DeviceObject.socKetClient.Close();
                        break;
                }
                if (ret)
                {
                    Online = Pub.GetResText(formCode, "Online", "");
                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "304", Online
                        , "", MacSN_GPRS}));
                }
                else
                {
                    Online = Pub.GetResText(formCode, "Offline", "");
                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "305", Online, MacSN_GPRS }));
                }
            }
            catch (Exception E)
            {
                msg = E.Message;
            }

            this.Enabled = true;
        }

        public class MacType
        {
            private int _id;
            private string _name;

            public MacType(int id, string name)
            {
                _id = id;
                _name = name;
            }

            public int id
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

        private void btnParentGroup_Click(object sender, EventArgs e)
        {
            frmPubSelectDevGroup frm = new frmPubSelectDevGroup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string s1 = frm.GroupID;
                string s2 = frm.GroupName;
                txtDevGroup.Tag = s1;
                txtDevGroup.Text = s2;
                MacDevGroupID = s1;
            }
        }
    }
}