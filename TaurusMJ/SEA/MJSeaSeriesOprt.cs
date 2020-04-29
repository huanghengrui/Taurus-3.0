using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;
using Newtonsoft.Json;
using System.IO;

namespace Taurus
{
    public partial class frmMJSeaSeriesOprt : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        private int flag = 0;
        private List<TDIConnInfo> connList = new List<TDIConnInfo>();
        private List<TimeZone> timeList = new List<TimeZone>();
        private List<UInt32> fingerNoList = new List<UInt32>();
        private bool IsWorking = false;
        private List<string> GUID = new List<string>();
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;
        private string Parameter = "";
        public string BodyParameter = "";
        public string[] userNameAndPwd = new string[0];

        private void AddColumn(int colType, string Field, int colWidth)
        {
            AddColumn(colType, Field, false, true, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, int colWidth)
        {
            AddColumn(colType, Field, IsHide, true, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, bool HasSort, int colWidth)
        {
            AddColumn(colType, Field, IsHide, HasSort, 0, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, bool HasSort, byte CenterFlag, int colWidth)
        {
            AddColumn(dataGrid, colType, Field, IsHide, HasSort, CenterFlag, colWidth);
        }

        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            SelectData(e.CheckedState);
        }

        protected override void InitForm()
        {
            formCode = "MJOprt";
            dataGrid.Columns.Clear();
            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "MacSN", false, 0);
            AddColumn(0, "MacDesc", false, false, 0);
            AddColumn(0, "MacSeriesTypeId", true, false, 0);
            AddColumn(0, "MacSeriesTypeName", false, false, 0);
            AddColumn(0, "MacTypeID", true, false, 0);
            AddColumn(0, "MacTypeName", true, false, 0);
            AddColumn(0, "MacConnType", false, false, 0);
            AddColumn(0, "MacIP", false, false, 0);
            AddColumn(0, "MacPort", false, false, 0);
            AddColumn(0, "MacConnPWD", true, false, 0);
            AddColumn(1, "IsGPRS", false, false, 1, 60);
            AddColumn(0, "MacSeriesUserName", true, false, 0);
           
            base.InitForm();
            msgGrid.BackgroundColor = dataGrid.BackgroundColor;
            msgGrid.DefaultCellStyle.SelectionForeColor = dataGrid.DefaultCellStyle.SelectionForeColor;
            this.Text = title;
            btnSeaSeriesOprt.Text = oprt;
            toolTip.SetToolTip(btnSeaSeriesOprt, btnSeaSeriesOprt.Text);
            toolTip.SetToolTip(txtQuickSearchMac, string.Format(Pub.GetResText(formCode, "MsgFindMacSN", ""),
          Pub.GetResText(formCode, "MacSN", ""),
          Pub.GetResText(formCode, "MacDesc", "")));
            string QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "9" });
            try
            {
                bindingSource.DataSource = SystemInfo.db.GetDataTable(QuerySQL);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, QuerySQL);
            }
            RefresButton();
            msgGrid_Resize(null, null);
        }

        public frmMJSeaSeriesOprt(string Title, string Oprt,string msg,int Flag,List<String> guid)
        {
            title = Title;
            oprt = Oprt;
            Parameter = msg;
            flag = Flag;
            GUID = guid;
            switch (flag)
            {
                case 0:
                    title = Pub.GetResText("", "mnuMJDoorSeaSeries", "");
                    oprt = Pub.GetResText("Main", "ItemMJDoorOpen", "");
                    break;
                case 4:
                    userNameAndPwd = msg.Split(':');
                    break;
                case 11:
                    title = Pub.GetResText("", "mnuMJSeaRebootDevice", "");
                    oprt = Pub.GetResText("", "mnuMJSeaRebootDevice", "");
                    break;
            }
            BodyParameter = "";
            InitializeComponent();
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void msgGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void msgGrid_Resize(object sender, EventArgs e)
        {
            Column1.Width = msgGrid.Width - 20;
        }

        private void RefresButton()
        {
            dataGrid.Enabled = !IsWorking;
            btnSeaSeriesOprt.Enabled = !IsWorking && (bindingSource.Count > 0);
            btnExit.Enabled = !IsWorking;
            progBar.Visible = IsWorking;
        }

        private TDIConnInfo RowDataToConnInfo(int RowIndex)
        {
            int MacSN = 0;
            string MacSN_GRPS = "";
            bool IsGPRS = Pub.ValueToBool(dataGrid[11, RowIndex].Value);
            if (IsGPRS)
                MacSN_GRPS = dataGrid[1, RowIndex].Value.ToString();
            else
            {
                MacSN = Convert.ToInt32(dataGrid[1, RowIndex].Value.ToString());
                MacSN_GRPS = MacSN.ToString();
            }
            string MacConnType = dataGrid[7, RowIndex].Value.ToString();
            string MacIP = dataGrid[8, RowIndex].Value.ToString();
            string MacPort = dataGrid[9, RowIndex].Value.ToString();
            string MacConnPWD = dataGrid[10, RowIndex].Value.ToString();
            int MacSeriesTypeId = 0;
            Int32.TryParse(dataGrid[3, RowIndex].Value.ToString(),out MacSeriesTypeId);
            string SeaSeriesPwd = dataGrid[10, RowIndex].Value.ToString();
            string MacSeriesUserName = dataGrid[12, RowIndex].Value.ToString();
            return Pub.ValueToDIConnInfo(MacSN, MacSN_GRPS, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS, MacSeriesTypeId, SeaSeriesPwd, MacSeriesUserName);
        }

        private void RowToConnInfo(int RowIndex)
        {
            connList.Add(RowDataToConnInfo(RowIndex));
        }

        private bool InitMacList()
        {
            connList.Clear();
            if (dataGrid.RowCount == 1)
            {
                RowToConnInfo(0);
            }
            else
            {
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
                    {
                        RowToConnInfo(i);
                    }
                }
            }
            if (connList.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
            }
            return connList.Count > 0;
        }

        private void RefreshMacMsg(string msg)
        {
            msgGrid.Rows.Add();
            msgGrid[0, msgGrid.RowCount - 1].Value = "[" + DateTime.Now.ToString() + "] " + msg;
            msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
            msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
        }

        private void UpdateMacMsg(string msg, bool state)
        {
            string s = msgGrid[0, msgGrid.RowCount - 1].Value.ToString();

            msgGrid[0, msgGrid.RowCount - 1].Value = s + "    " + msg;
            if (state)
                msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Blue;
            else
                msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Red;
        }

        private void RefreshMsg(string msg,int count)
        {
            RefreshMsg(msg,count, false);
        }

        private void RefreshMsg(string msg,int count, bool IsEnd)
        {
            lblMsg.Text = msg;
            if ((lblMsg.Text == "") || IsEnd)
            {
                progBar.Value = 0;
                progBar.ProgressType =  eProgressItemType.Standard;
            }
            else
            {
                progBar.Value = count*100/ connList.Count;
                progBar.ProgressType = eProgressItemType.Standard;
            }
        }

        private void ExecMacOprt()
        {
            bool state;
            string msg = "";
            string MacMsg = "";
            if (!InitMacList()) return;
            IsWorking = true;
            RefresButton();
            DateTime start = new DateTime();
            start = DateTime.Now;
            string ExecTimes = "";
            string url = "";
            TDIConnInfo conn;

            for (int i = 0; i < connList.Count; i++)
            {
                conn = connList[i];
                RefreshMsg(oprt + "[" + conn.MacSN.ToString() + "]......",i);
                RefreshMacMsg(oprt + "[" + conn.MacSN.ToString() + "]......");


                SystemInfo.MacSeriesTypeId = 2;
                url = "http://" + conn.NetHost + "/";
                string body = "";
                string urlTestConnt = "http://" + conn.NetHost + "/action/GetSysParam";
                bool ret = DeviceObject.objFK623.POST_GetResponse(urlTestConnt, conn.MacSeriesUserName, conn.SeaSeries_Pwd, ref body);

                if (ret)
                {
                    state = ExecMacCommand(conn.MacSN, url, conn.MacSeriesUserName, conn.SeaSeries_Pwd, ref MacMsg);
                }
                else
                {
                    state = false;
                }
                
                ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                UpdateMacMsg(MacMsg + DeviceObject.objFK623.SeaBodyStr() + ExecTimes, state);
                msg = msg + conn.MacSN.ToString() + ":" + MacMsg + DeviceObject.objFK623.SeaBodyStr() + ";";
               
                Application.DoEvents();
                start = DateTime.Now;
                if (!IsWorking) break;
            }
            SystemInfo.db.WriteSYLog(this.Text, oprt, msg);
            IsWorking = false;
            RefresButton();
            RefreshMsg("",0);
        }

        private bool ExecMacCommand(int MacSN,string url, string name, string pwd,  ref string MacMsg)
        {
            bool ret = false;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://远程控制门
                    ret = MJDoorOpen(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 1://下载时间段信息
                    ret = MJRealTimeMonitoringSettingsUpload(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 2://设置开门参数
                    ret = SetMJCondition(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 3://获取开门参数
                    ret = GetMJCondition(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 4://设置设备密码
                    ret = SetMJPwd(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 5://设置网络参数
                    ret = SetNetParam(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 6://获取网络参数
                    ret = GetNetParam(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 7://获取有效期
                    ret = GetValidity(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 8://设置有效期
                    ret = SetValidity(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 9://设置声音参数
                    ret = SetSound(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 10://获取声音参数
                    ret = GetSound(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 11://重启设备
                    ret = MJRebootDevice(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 12://清除抓拍记录
                    ret = MJClearSnapshotsLog(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 13://回收抓拍记录
                    ret = MJGetSnapshotsLog(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 14://设置温度参数
                    ret = SetTemperatureParam(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 15://获取温度参数
                    ret = GetTemperatureParam(MacSN, url, name, pwd, ref MacMsg);
                    break;

            }
            return ret;
        }

        private bool MJGetSnapshotsLog(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            DateTime dateTime = DateTime.Now.AddYears(1);
            string[] date = Parameter.Split('@');
            string _strWorkingDayAM = date[0] + "T00:00:00";
            string _strWorkingDayPM = date[1] + "T23:59:59";
            int RecordCount = 0;
           
            string selurl = url + "action/SearchCaptureNum";
            SearchCaptureNum searchCaptureNum = new SearchCaptureNum(MacSN.ToString(), _strWorkingDayAM, _strWorkingDayPM);

            jsonBody<SearchCaptureNum> jsonBodyNum = new jsonBody<SearchCaptureNum>("SearchCaptureNum", searchCaptureNum);
            string jsonBodyStr = JsonConvert.SerializeObject(jsonBodyNum);
            ret = DeviceObject.objFK623.POST_GetResponse(selurl, name, pwd, ref jsonBodyStr);
            if (!ret)
            {
                return ret;
            }
            jsonBody<GetSearchCaptureNum> getMachineInfo = JsonConvert.DeserializeObject<jsonBody<GetSearchCaptureNum>>(jsonBodyStr);
            RecordCount = getMachineInfo.info.CaptureNum;
            if (RecordCount == 0)
            {
                MacMsg = string.Format("{0} /{1} ", 0, RecordCount);
                return ret;
            }
            //RecordCount = 100;
            string urlRecord = url + "action/SearchCapture";

            SearchCapture searchCaptureCmd = new SearchCapture(MacSN, _strWorkingDayAM, _strWorkingDayPM, 0, 10);

            jsonBody<SearchCapture> jsonBody = new jsonBody<SearchCapture>("SearchCapture", searchCaptureCmd);
            int RecordIndex = 0;
            int Count = 0;
            int SendCount = 0;
            while (true)
            {
                jsonBody.info.BeginNO = Count;
                Count = Count + 10;
                string jsonString = JsonConvert.SerializeObject(jsonBody);
            EE:
                ret = DeviceObject.objFK623.POST_GetResponse(urlRecord, name, pwd, ref jsonString);

                if (!ret)
                {
                    if(RecordIndex>0)
                    {
                        ret = true;
                        FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                    }
                    
                    break;
                }
                jsonBody<GetSearchCapture<OneSearchCapture>> dataInfo = JsonConvert.DeserializeObject<jsonBody<GetSearchCapture<OneSearchCapture>>>(jsonString.Replace(",,",","));

                if (dataInfo.info.Listnum == 0)
                {
                    SendCount++;
                    if (SendCount >= 3)
                        break;
                    else
                        goto EE;
                }
                string GUID = "";
                byte[] PhotoImage = null;
                for (int i = 0; i < dataInfo.info.Listnum; i++)
                {
                    PhotoImage = Convert.FromBase64String(dataInfo.info.List[i].SnapPicinfo.Replace("data:image/jpeg;base64,", ""));
                    DateTime time = Convert.ToDateTime(dataInfo.info.List[i].CreateTime);
                    SystemInfo.db.SaveSnapLog(MacSN.ToString(), "0", time.ToString(SystemInfo.SQLDateTimeFMT), dataInfo.info.List[i].Temperature.ToString(), dataInfo.info.List[i].TemperatureAlarm, PhotoImage, ref GUID);
                    RecordIndex = RecordIndex + 1;
                    lblMsg.Text = btnSeaSeriesOprt.Text + string.Format("{0} /{1} ", RecordIndex, RecordCount);
                    MacMsg = string.Format("{0} /{1} ", RecordIndex, RecordCount);
                    if (RecordCount > 0)
                        progBar.Value = RecordIndex * 100 / RecordCount;
                    Application.DoEvents();
                }

            }

            return ret;
        }

        private bool MJClearSnapshotsLog(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            url = url + "action/SetFactoryDefault";
            SeaSeriesInitDevice seaSeriesInitDevice = new SeaSeriesInitDevice(0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0);
            jsonBody<SeaSeriesInitDevice> SeaSeriesInitDeviceJson = new jsonBody<SeaSeriesInitDevice>("SetFactoryDefault", seaSeriesInitDevice);
            string jsonString = JsonConvert.SerializeObject(SeaSeriesInitDeviceJson);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
           
            return ret;
        }

        private bool MJDoorOpen(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/OpenDoor";
           
            OpenDoorCmd openDoorCmd = new OpenDoorCmd(MacSN,0,1);

            jsonBody<OpenDoorCmd> jsonBodyOpenDoorCmd = new jsonBody<OpenDoorCmd>("OpenDoor", openDoorCmd);
            string jsonString = JsonConvert.SerializeObject(jsonBodyOpenDoorCmd);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
           
            return ret;
        }

        private bool MJRealTimeMonitoringSettingsUpload(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            List<string> TopList = new List<string>();
            TopList.Add("Snap");
            TopList.Add("Verify");
            url = url + "action/Subscribe";
            SubscribeUrlInfo subscribeUrlInfo = new SubscribeUrlInfo("/Subscribe/Snap", "/Subscribe/Verify", "/Subscribe/heartbeat");
            Subscribe<SubscribeUrlInfo> subscribe = new Subscribe<SubscribeUrlInfo>(MacSN,2, TopList, Parameter, subscribeUrlInfo, "none");

            jsonBody<Subscribe<SubscribeUrlInfo>> jsonBodySubscribe = new jsonBody<Subscribe<SubscribeUrlInfo>>("Subscribe", subscribe);
            string jsonString = JsonConvert.SerializeObject(jsonBodySubscribe);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
           
            return ret;
        }

        private bool SetMJCondition(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetDoorCondition";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            return ret;
        }
        private bool GetMJCondition(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/GetDoorCondition";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            if (ret)
            {
                BodyParameter = Parameter;
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
            }

            this.DialogResult = DialogResult.OK;
            IsWorking = false;
            this.Close();
            return ret;
        }

        private bool SetMJPwd(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetUserPwd";

            SetUserPwd userPwd = new SetUserPwd(userNameAndPwd[0], userNameAndPwd[1]);
            jsonBody<SetUserPwd> jsonBody = new jsonBody<SetUserPwd>("SetUserPwd", userPwd);
            string jsonString = JsonConvert.SerializeObject(jsonBody);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
            if (ret)
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                Pub.MessageBoxShow(btnSeaSeriesOprt.Text + Pub.GetResText("", "FK_RUN_SUCCESS", ""));
                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "10", userNameAndPwd[0], userNameAndPwd[1], MacSN.ToString() });
                SystemInfo.db.ExecSQL(sql);
            }
            return ret;
        }

        private bool SetNetParam(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetNetParam";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            return ret;
        }



        private bool GetNetParam(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/GetNetParam";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            if (ret)
            {
                BodyParameter = Parameter;
            }

            this.DialogResult = DialogResult.OK;
            IsWorking = false;
            this.Close();
            return ret;
        }

        private bool SetTemperatureParam(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetTemperature";
            Parameter = Parameter.Replace("111111", MacSN.ToString());
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            return ret;
        }



        private bool GetTemperatureParam(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/GetTemperature";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            if (ret)
            {
                BodyParameter = Parameter;
            }

            this.DialogResult = DialogResult.OK;
            IsWorking = false;
            this.Close();
            return ret;
        }

        private bool SetValidity(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            string addUrl = url + "action/AddPerson";
            string delUrl = url + "action/SearchPerson";
            string UpdUrl = url + "action/EditPerson";
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            int EmpSex = 2;
            string EmpNo = "";
            DataRow[] empRows = null;
            string EmpCertNo = "";
            string CardNo10 = "";
            long WeCardNo10 = 0;
            int WeCardNoType = 0;
            string EmpAddress = "";
            string EmpPhoneNo = "";
            string picinfo = "";
            string EmpMemo = "";
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            string jsonString = "";
            List<int> CustomizeIDList = new List<int>();
            string ID = "";
            int Valid = 0;
            string ValidBegin = "";
            string ValidEnd = "";
            bool IsUpdate = true;
            EditPersonInfo editPerson = null;
            Person<EditPersonInfo> editPersonCmd = null;

            SearchOnePerson searchOnePerson = null;
            jsonBody<SearchOnePerson> searchOnePersonCmd = null;

            PersonInfo personInfo = null;
            Person<PersonInfo> addPerson = null;
            DataTable dtUploadcount = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "613","" })); 
            if (dtUploadcount == null)
            {
                string tmp = btnSeaSeriesOprt.Text;
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }
            progBar.ProgressType = eProgressItemType.Standard;
            try
            {
                for (int i = 0; i < GUID.Count; i++)
                {
                    empRows = dtUploadcount.Select("GUID='" + GUID[i] + "'AND MacSN='"+MacSN+"'");
                    if(empRows.Length>0)
                    {
                        CustomizeIDList = new List<int>();
                        EnrollNumber = Convert.ToUInt32(empRows[0]["FingerNo"].ToString());
                        CustomizeIDList.Add(Convert.ToInt32(EnrollNumber));
                        EnrollName = empRows[0]["EmpName"].ToString();
                        lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]",  EnrollNumber, EnrollName,
                          i + 1, GUID.Count);
                        progBar.Value = (i + 1) * 100 / GUID.Count;

                        EmpNo = empRows[0]["EmpNo"].ToString();
                        if (empRows[0]["EmpSex"].ToString().Equals(Pub.GetResText("", "EmpSex0", "")))
                        {
                            EmpSex = 0;
                        }
                        else if (empRows[0]["EmpSex"].ToString().Equals(Pub.GetResText("", "EmpSex1", "")))
                        {
                            EmpSex = 1;
                        }
                        else
                        {
                            EmpSex = 2;
                        }
                        EmpCertNo = empRows[0]["EmpCertNo"].ToString();
                        CardNo10 = empRows[0]["CardNo10"].ToString();
                        long.TryParse(CardNo10, out WeCardNo10);
                        EmpAddress = empRows[0]["EmpAddress"].ToString();
                        EmpPhoneNo = empRows[0]["EmpPhoneNo"].ToString();
                        EmpMemo = empRows[0]["EmpMemo"].ToString();
                        CardNo10 = StrToHex(CardNo10);
                        if (CardNo10.Length > 10) CardNo10 = CardNo10.Substring(CardNo10.Length - 10, 10);
                        if (WeCardNo10 != 0) WeCardNoType = 2;
                        else WeCardNoType = 0;
                        ValidBegin = "";
                        ValidEnd = "";
                        if (!string.IsNullOrEmpty(empRows[0]["StartDate"].ToString()))
                            ValidBegin = Convert.ToDateTime(empRows[0]["StartDate"]).ToString(SystemInfo.SQLDateFMT) + "T00:00:00";
                        if (!string.IsNullOrEmpty(empRows[0]["EndDate"].ToString()))
                            ValidEnd = Convert.ToDateTime(empRows[0]["EndDate"]).ToString(SystemInfo.SQLDateFMT) + "T23:59:59";

                        if(ValidBegin != ""|| ValidEnd != "")
                        {
                            Valid = 1;
                        }
                        else
                        {
                            Valid = 0;
                        }

                        CountUp++;

                        picinfo = "";
                        nPhotoSize = 0;
                        if (!string.IsNullOrEmpty(empRows[0]["EmpPhoto"].ToString()))
                        {

                            byte[] buf = (byte[])(empRows[0]["EmpPhoto"]);
                            nPhotoSize = buf.Length;
                            if (nPhotoSize > 0)
                            {
                                picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buf);
                                CountUpFp++;
                            }

                        }
                        if(nPhotoSize==0)
                        {
                            if (!string.IsNullOrEmpty(empRows[0]["EmpPhotoImage"].ToString()))
                            {
                                byte[] buf = (byte[])(empRows[0]["EmpPhotoImage"]);
                                nPhotoSize = buf.Length;
                                if (nPhotoSize > 0)
                                {
                                    picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buf);
                                    CountUpFp++;
                                }
                            }
                        }

                        searchOnePerson = new SearchOnePerson(MacSN, 0, EnrollNumber.ToString(), 0);
                        searchOnePersonCmd = new jsonBody<SearchOnePerson>("SearchPerson", searchOnePerson);
                        jsonString = JsonConvert.SerializeObject(searchOnePersonCmd);
                        IsUpdate = false;
                        ret = DeviceObject.objFK623.POST_GetResponse(delUrl, name, pwd, ref jsonString);
                        if (ret)
                        {
                            jsonBody<SearchPersonInfo> searchPersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchPersonInfo>>(jsonString);
                            if (searchPersonInfo.info.CustomizeID == EnrollNumber)
                            {
                                IsUpdate = true;
                            }
                        }

                        EEE:
                        if (IsUpdate)
                        {
                            editPerson = new EditPersonInfo(Convert.ToInt32(MacSN), 0, Convert.ToInt32(EnrollNumber), 0, EnrollName, EmpSex, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                           EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, StrToHex(CardNo10), Valid, "", ValidBegin, ValidEnd);
                            editPersonCmd = new Person<EditPersonInfo>("EditPerson", editPerson, picinfo);
                            jsonString = JsonConvert.SerializeObject(editPersonCmd);
                            ret = DeviceObject.objFK623.POST_GetResponse(UpdUrl, name, pwd, ref jsonString);
                        }
                        else
                        {
                            //增加人员
                            personInfo = new PersonInfo(MacSN, 0, EnrollName, EmpSex, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                             EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, StrToHex(CardNo10), Valid, Convert.ToInt32(EnrollNumber), "", ValidBegin, ValidEnd, "1", "1", "1", "1");
                            addPerson = new Person<PersonInfo>("AddPerson", personInfo, picinfo);

                            jsonString = JsonConvert.SerializeObject(addPerson);
                            ret = DeviceObject.objFK623.POST_GetResponse(addUrl, name, pwd, ref jsonString);
                        }

                        if (!ret)
                        {
                            if (DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                            {
                                DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                         Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                                if (MessRet == DialogResult.Yes)
                                    goto EEE;
                                else if (MessRet == DialogResult.Cancel)
                                {
                                    ret = false;
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                ID += "[" + EnrollNumber + "]" + DeviceObject.objFK623.SeaBodyStr() + "]";
                            }

                        }

                        Application.DoEvents();
                    }
                    ret = true;
                }
                
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if(ret && CountUp==0) 
                    FK623Attend.SeaBody = Pub.GetResText("", "FK_RUNERR_DATAARRAY_NONE", "");
                else if (!ret)
                    FK623Attend.SeaBody = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                else
                    FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                string tmp = btnSeaSeriesOprt.Text;
                if (ID != "")
                {
                    tmp += "  <" + Pub.GetResText(formCode, "UnsuccessfulEmpNo", "") + ID + ">  ";
                }
                MacMsg = string.Format(tmp, GUID.Count, CountUp, CountUpFp);
            }

            return ret;
        }

        private bool GetValidity(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            byte[] Photo = new byte[0];
            int EmpCount = 0;
            DataRow[] rows = null;
            DataRow[] empRows = null;
            string EmpNo = "";

            int PersonNum = 0;

            string jsonString = "";
            string StatusMsg = lblMsg.Text;

            string StartDate = "NULL";
            string EndDate = "NULL";

            byte[] CardData = new byte[0];
            string guid = "";

            progBar.ProgressType = eProgressItemType.Standard;

            DataTable dtInsert = new DataTable();
            DataTable dtUpdate = new DataTable();
            DataTable dtSelect = new DataTable();
            DataTable dtEmpSelect = new DataTable();
            try
            {
                dtInsert = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "519" }));
                dtUpdate = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "519" }));
                dtSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "518", MacSN.ToString() }));
                dtEmpSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "27" }));

                //查询人员总数
                string searchTotlePersonUrl = url + "action/SearchPersonNum";
                SearchTotlePerson searchTotlePerson = new SearchTotlePerson(Convert.ToInt32(MacSN), 0, "", "", 2, "0-100", 0, "");
                jsonBody<SearchTotlePerson> jsonBodySearchTotlePerson = new jsonBody<SearchTotlePerson>("SearchPersonNum", searchTotlePerson);
                jsonString = JsonConvert.SerializeObject(jsonBodySearchTotlePerson);
                ret = DeviceObject.objFK623.POST_GetResponse(searchTotlePersonUrl, name, pwd, ref jsonString);
                if (!ret) return false;
                jsonBody<SearchTotlePersonInfo> searchTotlePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchTotlePersonInfo>>(jsonString);
                {
                    PersonNum = searchTotlePersonInfo.info.PersonNum;
                }
                if (PersonNum == 0)
                {
                    return false;
                }

                int i= 0;
                while(true)
                {
                    //查询人员
                    string searchMultipleUrl = url + "action/SearchPersonList";
                    SearchMultiplePerson searchMultiple = new SearchMultiplePerson(Convert.ToInt32(MacSN), 0, "", "", 2, "0-100", 0, "", i * 10, 10, 1);
                    i++;
                    jsonBody<SearchMultiplePerson> jsonBodySearchMultiplePerson = new jsonBody<SearchMultiplePerson>("SearchPersonList", searchMultiple);
                    ES:
                    jsonString = JsonConvert.SerializeObject(jsonBodySearchMultiplePerson);
                    ret = DeviceObject.objFK623.POST_GetResponse(searchMultipleUrl, name, pwd, ref jsonString);
                    if (!ret)
                    {
                        if (DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                   Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                            if (MessRet == DialogResult.OK)
                            {
                                goto ES;
                            }
                            else
                            {
                                ret = false;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>> searchMultiplePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>>>(jsonString);
                    {
                        for (int j = 0; j < searchMultiplePersonInfo.info.Listnum; j++)
                        {
                            EmpCount++;

                            if (searchMultiplePersonInfo.info.List[j].Tempvalid != 0)
                            {
                                StartDate = searchMultiplePersonInfo.info.List[j].ValidBegin;
                                EndDate = searchMultiplePersonInfo.info.List[j].ValidEnd;
                            }
                            else
                            {
                                StartDate = null;
                                EndDate = null;
                            }

                            empRows = dtEmpSelect.Select("FingerNo=" + searchMultiplePersonInfo.info.List[j].CustomizeID + "");
                            if (empRows.Length > 0)
                            {
                                EmpNo = empRows[0]["EmpNo"].ToString();
                                rows = dtSelect.Select("EmpNo='" + EmpNo + "'");
                                if (rows.Length > 0)
                                {
                                    guid = rows[0]["GUID"].ToString();
                                    dtUpdate.Rows.Add(new object[] { guid, MacSN, EmpNo, OprtInfo.OprtNo, DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), StartDate, EndDate });
                                }
                                else
                                {
                                    dtInsert.Rows.Add(new object[] { GetGUID(), MacSN, EmpNo, OprtInfo.OprtNo, DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), StartDate, EndDate });
                                    dtSelect.Rows.Add(new object[] { GetGUID(), MacSN, EmpNo, OprtInfo.OprtNo, DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), StartDate, EndDate });
                                }
                            }

                            lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                          string.Format(" - {2}/{3}  [{0}: {1}]", searchMultiplePersonInfo.info.List[j].CustomizeID, searchMultiplePersonInfo.info.List[j].Name, EmpCount, PersonNum);
                            if (EmpCount > 0)
                                progBar.Value = EmpCount * 100 / PersonNum;
                            Application.DoEvents();
                        }
                        if (dtInsert.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsert, "DI_SeaPower");
                            dtInsert.Clear();
                        }
                        if (dtUpdate.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdate, "DI_SeaPower", "GUID");
                            dtUpdate.Clear();
                        }
                    }
                }
                
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, PersonNum, EmpCount, EmpCount);
            }

            if (EmpCount > 0)
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                ret = true;
            }
            return ret;
        }

        private string GetGUID()
        {
            string ret = System.Guid.NewGuid().ToString().ToUpper();
            return ret;
        }
        private bool SetSound(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetSound";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            return ret;
        }



        private bool GetSound(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/GetSound";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            if (ret)
            {
                BodyParameter = Parameter;
            }

            this.DialogResult = DialogResult.OK;
            IsWorking = false;
            this.Close();
            return ret;
        }


        private bool MJRebootDevice(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/RebootDevice";

            RebootDeviceCmd rebootDeviceCmd = new RebootDeviceCmd(MacSN, 1);

            jsonBody<RebootDeviceCmd> jsonBodyRebootDeviceCmd = new jsonBody<RebootDeviceCmd>("RebootDevice", rebootDeviceCmd);
            string jsonString = JsonConvert.SerializeObject(jsonBodyRebootDeviceCmd);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
            return ret;
        }

        private void btnOprt_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                timeList.Clear();
                TimeZone tz;
                DataTableReader dr = null;
                string tmp;
                bool IsError = false;
                try
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "400" }));
                    while (dr.Read())
                    {
                        tz = new TimeZone();
                        tz.Init();
                        tz.TimeZoneID = Convert.ToInt32(dr["PassTimeID"].ToString());
                        for (int i = 0; i < (int)FKMax.TIME_SLOT_COUNT; i++)
                        {
                            tmp = dr["T" + (i + 1).ToString() + "S"].ToString();
                            tz.TimeSlots[i].StartHour = Convert.ToByte(tmp.Substring(0, 2));
                            tz.TimeSlots[i].StartMinute = Convert.ToByte(tmp.Substring(3, 2));
                            tmp = dr["T" + (i + 1).ToString() + "E"].ToString();
                            tz.TimeSlots[i].EndHour = Convert.ToByte(tmp.Substring(0, 2));
                            tz.TimeSlots[i].EndMinute = Convert.ToByte(tmp.Substring(3, 2));
                        }
                        timeList.Add(tz);
                    }
                }
                catch (Exception E)
                {
                    IsError = true;
                    Pub.ShowErrorMsg(E);
                }
                finally
                {
                    if (dr != null) dr.Close();
                    dr = null;
                }
                if (IsError) return;
            }
            else if (flag == 20)
            {
                fingerNoList.Clear();
                DataTableReader dr = null;
                bool IsError = false;
                try
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "508" }));
                    while (dr.Read())
                    {
                        fingerNoList.Add(Convert.ToUInt32(dr["FingerNo"].ToString()));
                    }
                }
                catch (Exception E)
                {
                    IsError = true;
                    Pub.ShowErrorMsg(E);
                }
                finally
                {
                    if (dr != null) dr.Close();
                    dr = null;
                }
                if (IsError) return;
            }
            ExecMacOprt();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMJOprt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }

        private void SelectData(bool State)
        {
            if (bindingSource.DataSource != null)
            {
                DataTable dt = (DataTable)bindingSource.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i].BeginEdit();
                    dt.Rows[i]["SelectCheck"] = State;
                    dt.Rows[i].EndEdit();
                }
            }
        }

        private void ItemSelect_Click(object sender, EventArgs e)
        {
            SelectData(true);
        }

        private void ItemUnselect_Click(object sender, EventArgs e)
        {
            SelectData(false);
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey && !isSelectEnd)
            {
                selectNo = dataGrid.CurrentRow.Index;
                isSelect = true;
                isSelectEnd = true;
            }
           
        }

        private void dataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            isSelect = false;
            isSelectEnd = false;
        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGrid.Rows.Count == 0) return;
            selectNoEnd = dataGrid.CurrentRow.Index;
            if (selectNoEnd < 0) return;
            if (isSelect)
            {
                int i = 0;
                for (int j = 0; j < dataGrid.RowCount; j++)
                {

                    if (selectNo < selectNoEnd)
                    {
                        if (i >= selectNo && i <= selectNoEnd)
                            dataGrid.Rows[i].Cells[0].Value = true;
                    }
                    else
                    {
                        if (i <= selectNo && i >= selectNoEnd)
                            dataGrid.Rows[i].Cells[0].Value = true;
                    }
                    i++;
                }
            }
        }

        private void txtQuickSearchMac_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalMac(txtQuickSearchMac, e, dataGrid);
            txtQuickSearchMac.Focus();
        }

        private void msgGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmBaseShowMsg frm = new frmBaseShowMsg(this.Text, msgGrid[0, e.RowIndex].Value.ToString());
            frm.ShowDialog();
        }
    }
}