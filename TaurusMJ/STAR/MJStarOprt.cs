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
    public partial class frmMJStarOprt : frmBaseDialog
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
        private StringBuilder Parameter = new StringBuilder();
        public StringBuilder BodyParameter = new StringBuilder();
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
            btnStarOprt.Text = oprt;
            btnOpenDoor.Text = Pub.GetResText("MJDoor", "btnCOpen", "");
            btnCloseDoor.Text = Pub.GetResText("Main", "ItemMJDoorClose", "");
            toolTip.SetToolTip(btnStarOprt, btnStarOprt.Text);

            toolTip.SetToolTip(txtQuickSearchMac, string.Format(Pub.GetResText(formCode, "MsgFindMacSN", ""),
          Pub.GetResText(formCode, "MacSN", ""),
          Pub.GetResText(formCode, "MacDesc", "")));
            string QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "20" });
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

        public frmMJStarOprt(string Title, string Oprt, StringBuilder msg, int Flag, List<String> guid)
        {
            title = Title;
            oprt = Oprt;
            Parameter = msg;
            flag = Flag;
            GUID = guid;

            InitializeComponent();
            switch (flag)
            {
                case 10:
                    title = Pub.GetResText("Main", "mnuMJDoor", "");
                    oprt = Pub.GetResText("MJDoor", "btnOpen", "");
                    btnOpenDoor.Visible = true;
                    btnCloseDoor.Visible = true;
                    break;
                case 20:
                    title = Pub.GetResText("Main", "mnuMJStarRebootDevice", "");
                    oprt = Pub.GetResText("Main", "mnuMJStarRebootDevice", "");
                    break;
            }
            BodyParameter = new StringBuilder();
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
            btnStarOprt.Enabled = !IsWorking && (bindingSource.Count > 0);
            btnExit.Enabled = !IsWorking;
            progBar.Visible = IsWorking;
        }

        private TDIConnInfo RowDataToConnInfo(int RowIndex)
        {
            int MacSN = 0;
            string MacSN_GRPS = "";
            int MacSeriesTypeId = 0;
            Int32.TryParse(dataGrid[3, RowIndex].Value.ToString(), out MacSeriesTypeId);
            bool IsGPRS = Pub.ValueToBool(dataGrid[11, RowIndex].Value);
            if (IsGPRS || MacSeriesTypeId == 3)
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

        private void RefreshMsg(string msg, int count)
        {
            RefreshMsg(msg, count, false);
        }

        private void RefreshMsg(string msg, int count, bool IsEnd)
        {
            lblMsg.Text = msg;
            if ((lblMsg.Text == "") || IsEnd)
            {
                progBar.Value = 0;
                progBar.ProgressType = eProgressItemType.Standard;
            }
            else
            {
                progBar.Value = count * 100 / connList.Count;
                progBar.ProgressType = eProgressItemType.Standard;
            }
        }

        private void ExecMacOprt()
        {
            bool state = false;
            string msg = "";
            string MacMsg = "";
            if (!InitMacList()) return;
            IsWorking = true;
            RefresButton();
            DateTime start = new DateTime();
            start = DateTime.Now;
            string ExecTimes = "";
            TDIConnInfo conn;

            for (int i = 0; i < connList.Count; i++)
            {
                conn = connList[i];
                RefreshMsg(oprt + "[" + conn.MacSN_GPRS.ToString() + "]......", i);
                RefreshMacMsg(oprt + "[" + conn.MacSN_GPRS.ToString() + "]......");


                SystemInfo.MacSeriesTypeId = 3;
                string cmd = "GetDeviceInfo";
                DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
                StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));
                if (DeviceObject.socKetClient.Open(conn.NetHost, conn.NetPort, conn.NetPassword))
                {
                    if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                    {
                        state = ExecMacCommand(conn.MacSN_GPRS, ref MacMsg);
                    }
                }
                ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                UpdateMacMsg(MacMsg + DeviceObject.socKetClient.ErrMsg + ExecTimes, state);
                msg = msg + conn.MacSN_GPRS + ":" + MacMsg + DeviceObject.socKetClient.ErrMsg + ";";
                DeviceObject.socKetClient.Close();
                Application.DoEvents();
                start = DateTime.Now;
                if (!IsWorking) break;
            }
            SystemInfo.db.WriteSYLog(this.Text, oprt, msg);
            IsWorking = false;
            RefresButton();
            RefreshMsg("", 0);
        }

        private bool ExecMacCommand(string MacSN, ref string MacMsg)
        {
            bool ret = false;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {

                case 1://设置参数
                    ret = SetSatrParam(ref MacMsg);
                    break;
                case 2://获取参数
                    ret = GetSatrParam(ref MacMsg);
                    break;
                case 3://获取有效期
                    ret = GetValidity(MacSN, ref MacMsg);
                    break;
                case 4://设置有效期
                    ret = SetValidity(MacSN, ref MacMsg);
                    break;
                case 10://临时开门
                    ret = MJDoorOpenClose(MacSN, ref MacMsg);
                    break;
                case 11://开门
                    ret = MJDoorOpen(MacSN, ref MacMsg);
                    break;
                case 12://关门
                    ret = MJDoorClose(MacSN, ref MacMsg);
                    break;
                case 20://重启
                    ret = MJStarRebootDevice(MacSN, ref MacMsg);
                    break;

            }
            return ret;
        }

        public bool SetValidity(string MacSN, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            string EmpNo = "";

            string CardNo10 = "";

            string Pwd = "";
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            int Privilege = 0;
            SetUsers setUsers = null;
            SetUserInfoCmd<SetUsers> setUserInfoCmd = null;
            _DeviceCmd<SetUserInfoCmd<SetUsers>> devSetUserInfoCmd = null;
            List<SetUsers> usersList = new List<SetUsers>();
            List<string> fps = new List<string>();
            string face = "";
            string palm = "";
            string photo = "";
            string vaildStart = "";
            string vaildEnd = "";
            int BufferLen = 0;
            byte photoEnroll = 0;
            byte update = 0;
            string ID = "";
            int sendCount = 0;
            List<int> CustomizeIDList = new List<int>();
            DataTableReader dr = null;
            DataTableReader drfp = null;
            int maxBufferLen = 0;
            byte[] dataBuffer = new byte[0];
            List<string> usersIDList = new List<string>();
            DataRow[] empRows = null;
            DataTable dtUploadcount = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "623", "" }));

            if (dtUploadcount == null)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }
            progBar.ProgressType = eProgressItemType.Standard;

            #region 获取可发送数据的最大值
            string cmd = "GetDeviceInfo";
            DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    _ResultInfo<DeviceInfo> deviceInfo = JsonConvert.DeserializeObject<_ResultInfo<DeviceInfo>>(jsonStringBuilder.ToString());
                    maxBufferLen = deviceInfo.result_data.maxBufferLen;
                }
                else
                {
                    string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                    MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                    return true;
                }
            }
            #endregion

            #region 首先获取机器上的所有用户id
            cmd = "GetUserIdList";
            GetUserIdListCmd getUserIdListCmd = new GetUserIdListCmd(0);
            _DeviceCmd<GetUserIdListCmd> devGetUserIdListCmd = new _DeviceCmd<GetUserIdListCmd>(cmd, getUserIdListCmd);
        RE:
            jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devGetUserIdListCmd));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    try
                    {
                        _ResultInfo<UserListInfo<UserIdName>> personIDList = JsonConvert.DeserializeObject<_ResultInfo<UserListInfo<UserIdName>>>(jsonStringBuilder.ToString());
                        if (personIDList.result_data.usersCount > 0)
                        {
                            foreach (UserIdName idName in personIDList.result_data.users)
                            {
                                usersIDList.Add(idName.userId);
                            }
                            if (personIDList.result_data.packageId != 0)
                            {
                                devGetUserIdListCmd.data.packageId++;
                                goto RE;
                            }
                            ret = true;
                        }

                    }
                    catch
                    {

                    }

                }
                else if (state == -6)
                {
                    sendCount++;
                    if (sendCount > 2)
                        return ret;
                    else
                        goto RE;
                }
                else
                {
                    return ret;
                }
            }
            else
            {
                ret = false;
            }
            #endregion

            try
            {
                sendCount = 0;
                cmd = "SetUserInfo";
                for (int i = 0; i < GUID.Count; i++)
                {
                    empRows = dtUploadcount.Select("GUID='" + GUID[i] + "'AND MacSN='" + MacSN + "'");
                    if (empRows.Length > 0)
                    {
                        fps = new List<string>();
                        face = null;
                        palm = null;
                        photo = null;
                        photoEnroll = 1;
                        update = 0;

                        EnrollNumber = Convert.ToUInt32(empRows[0]["FingerNo"].ToString());

                        EnrollName = empRows[0]["EmpName"].ToString();
                        lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber,
                          i + 1, GUID.Count);
                        progBar.Value = (i + 1) * 100 / GUID.Count;

                        EmpNo = empRows[0]["EmpNo"].ToString();
                        CardNo10 = empRows[0]["CardNo10"].ToString();
                        Pwd = empRows[0]["pwd"].ToString();
                        Privilege = Convert.ToInt32(empRows[0]["FingerPrivilege"].ToString());
                        vaildStart = empRows[0]["StartDate"].ToString();
                        IsDateTime("yyyyMMdd", ref vaildStart);

                        vaildEnd = empRows[0]["EndDate"].ToString();
                        IsDateTime("yyyyMMdd", ref vaildEnd);

                        if (string.IsNullOrEmpty(vaildStart)) vaildStart = "00000000";
                        if (string.IsNullOrEmpty(vaildEnd)) vaildEnd = "00000000";

                        CountUp++;
                        photo = "";
                        nPhotoSize = 0;
                        if (!string.IsNullOrEmpty(empRows[0]["EmpPhoto"].ToString()))
                        {

                            dataBuffer = (byte[])empRows[0]["EmpPhoto"];
                            nPhotoSize = dataBuffer.Length;
                            if (nPhotoSize > 0)
                            {
                                photo = Convert.ToBase64String(dataBuffer);

                            }

                        }
                        if(nPhotoSize==0)
                        {
                            if (!string.IsNullOrEmpty(empRows[0]["EmpPhotoImage"].ToString()))
                            {
                                dataBuffer = (byte[])empRows[0]["EmpPhotoImage"];
                                nPhotoSize = dataBuffer.Length;
                                if (nPhotoSize > 0)
                                {
                                    photo = Convert.ToBase64String(dataBuffer);

                                }
                            }
                        }

                        if (CardNo10 == "") CardNo10 = null;
                        if (Pwd == "") Pwd = null;

                        for (int j = 0; j < 10; j++)
                        {
                            drfp = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "39", EnrollNumber.ToString(), j.ToString() }));
                            if (drfp.Read())
                            {
                                dataBuffer = (byte[])(drfp["FingerData"]);

                                byte[] fpDataZip = new byte[(int)FKMax.FK_FPDataSize];
                                Array.Copy(dataBuffer, 0, fpDataZip, 0, fpDataZip.Length);

                                byte[] buffConv = new byte[(int)FKMax.FK_FPDataSize];

                                long apnVersion = 0x80;
                                long apnSize = 1680;
                                int apnFpDataSize = 1680;
                                byte[] fpdata = new byte[1600];
                                ObjFpReader.ConvEnrollData(dataBuffer, ref buffConv, 1680);
                                Array.Copy(buffConv, 80, fpdata, 0, 1600);

                                ObjFpReader.FPCONV_Init();
                                ObjFpReader.FPCONV_GetFpDataVersionAndSize(fpdata, ref apnVersion, ref apnSize);

                                ObjFpReader.FPCONV_GetFpDataSize(0x80, ref apnFpDataSize);
                                byte[] buffConvNew = new byte[apnFpDataSize];
                                ObjFpReader.FPCONV_Convert((int)apnVersion, fpdata, 0x80, buffConvNew);

                                fps.Add(Convert.ToBase64String(buffConvNew));
                            }
                            drfp.Close();
                        }

                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "34", EmpNo }));
                        if (dr.Read())
                        {
                            //for (int j = 0; j < 10; j++)
                            //{
                            //    if (!string.IsNullOrEmpty(dr["Fb0" + j].ToString()))
                            //    {
                            //        dataBuffer = (byte[])dr["Fb0" + j];
                            //        fps.Add(Convert.ToBase64String(dataBuffer));
                            //    }

                            //}
                            if (!string.IsNullOrEmpty(dr["Face00"].ToString()))
                            {
                                dataBuffer = (byte[])dr["Face00"];
                                face = Convert.ToBase64String(dataBuffer);
                                photoEnroll = 0;
                            }

                            if (!string.IsNullOrEmpty(dr["Falm00"].ToString()))
                            {
                                dataBuffer = (byte[])(dr["Falm00"]);
                                palm = Convert.ToBase64String(dataBuffer);
                            }
                        }
                        if (usersIDList != null)
                        {
                            if (usersIDList.Contains(EnrollNumber.ToString()))
                            {
                                update = 1;
                            }
                        }
                        if (string.IsNullOrEmpty(photo))
                        {
                            photo = null;
                            photoEnroll = 0;
                        }
                        CountUpFp++;
                        setUsers = new SetUsers(EnrollNumber.ToString(), EnrollName, Privilege, CardNo10, Pwd, fps, face, palm, photo, vaildStart, vaildEnd, update, photoEnroll);
                        BufferLen += CalculatedLength(setUsers);
                        if (BufferLen > maxBufferLen)
                        {
                            setUserInfoCmd = new SetUserInfoCmd<SetUsers>(usersList);
                            devSetUserInfoCmd = new _DeviceCmd<SetUserInfoCmd<SetUsers>>(cmd, setUserInfoCmd);
                        ES:
                            jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devSetUserInfoCmd), maxBufferLen);

                            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                            {
                                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                                if (state == 0)
                                {
                                    _ResultInfo<SetUsersErorr> resultInfo = JsonConvert.DeserializeObject<_ResultInfo<SetUsersErorr>>(jsonStringBuilder.ToString());
                                    if (resultInfo.result_data != null)
                                    {
                                        foreach (string id in resultInfo.result_data.usersId)
                                        {
                                            ID += " [" + id + "] ";
                                            CountUp--;
                                        }
                                    }
                                    ret = true;
                                }
                                else if (state == -6)
                                {
                                    sendCount++;
                                    if (sendCount > 3)
                                    {
                                        ret = false;
                                        return ret;
                                    }
                                    else
                                    {
                                        if (DeviceObject.socKetClient.Open()) goto ES;
                                        else
                                        {
                                            ret = false;
                                            return ret;
                                        }
                                    }
                                }
                                else
                                {
                                    ret = false;
                                    return ret;
                                }

                            }
                            else
                            {
                                if (DeviceObject.socKetClient.ErrMsg.Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                                {
                                    DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.socKetClient.ErrMsg + "\r\n\r\n" +
                             Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                                    if (MessRet == DialogResult.OK)
                                    {
                                        if (DeviceObject.socKetClient.Open()) goto ES;
                                        else
                                        {
                                            ret = false;
                                            return ret;
                                        }
                                    }
                                    else
                                    {
                                        ret = false;
                                        return ret;
                                    }
                                }
                            }
                            BufferLen = CalculatedLength(setUsers);
                            usersList.Clear();
                        }

                        usersList.Add(setUsers);

                        Application.DoEvents();
                    }
                }
                sendCount = 0;
                if (usersList.Count > 0)
                {
                    setUserInfoCmd = new SetUserInfoCmd<SetUsers>(usersList);
                    devSetUserInfoCmd = new _DeviceCmd<SetUserInfoCmd<SetUsers>>(cmd, setUserInfoCmd);
                    jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devSetUserInfoCmd), maxBufferLen);
                ER:
                    if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                    {
                        int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                        if (state == 0)
                        {
                            _ResultInfo<SetUsersErorr> resultInfo = JsonConvert.DeserializeObject<_ResultInfo<SetUsersErorr>>(jsonStringBuilder.ToString());
                            if (resultInfo.result_data != null)
                            {
                                foreach (string id in resultInfo.result_data.usersId)
                                {
                                    ID += " [" + id + "] ";
                                    CountUp--;
                                }
                            }
                            ret = true;
                        }
                        else if (state == -6)
                        {
                            sendCount++;
                            if (sendCount > 3)
                            {
                                ret = false;
                                return ret;
                            }
                            else
                            {
                                if (DeviceObject.socKetClient.Open()) goto ER;
                                else
                                {
                                    ret = false;
                                    return ret;
                                }
                            }    
                        }
                        else
                        {
                            ret = false;
                            return ret;
                        }

                    }
                    else
                    {
                        if (DeviceObject.socKetClient.ErrMsg.Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.socKetClient.ErrMsg + "\r\n\r\n" +
                     Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                            if (MessRet == DialogResult.OK)
                            {
                                if (DeviceObject.socKetClient.Open()) goto ER;
                                else
                                {
                                    ret = false;
                                    return ret;
                                }
                            }
                            else
                            {
                                ret = false;
                                return ret;
                            }
                        }
                    }

                }
            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                if (ID != "")
                {
                    tmp += "  <" + Pub.GetResText(formCode, "UnsuccessfulEmpNo", "") + ID + ">  ";
                }
                MacMsg = string.Format(tmp, CountUp, GUID.Count, CountUpFp);
            }
            return ret;
        }

        public bool GetValidity(string MacSN, ref string MacMsg)
        {
            bool ret = false;
            string cmd = "";
            int sendCount = 0;
            StringBuilder jsonStringBuilder = null;
            string StatusMsg = lblMsg.Text;
            progBar.ProgressType = eProgressItemType.Standard;
            List<_ResultInfo<PersonInfo<GetUsers>>> PersonInfoList = new List<_ResultInfo<PersonInfo<GetUsers>>>();
            List<string> usersIDList = new List<string>();
            int EmpCount = 0;
            try
            {

                DataRow[] rows = null;
                DataRow[] empRows = null;
                string EmpNo = "";

                string StartDate = "NULL";
                string EndDate = "NULL";

                byte[] CardData = new byte[0];
                string guid = "";

                DataTable dtInsert = new DataTable();
                DataTable dtUpdate = new DataTable();
                DataTable dtSelect = new DataTable();
                DataTable dtEmpSelect = new DataTable();

                dtInsert = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "559" }));
                dtUpdate = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "559" }));
                dtSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "558", MacSN.ToString() }));
                dtEmpSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "27" }));


                #region 首先获取机器上的所有用户id
                cmd = "GetUserIdList";
                GetUserIdListCmd getUserIdListCmd = new GetUserIdListCmd(0);
                _DeviceCmd<GetUserIdListCmd> devGetUserIdListCmd = new _DeviceCmd<GetUserIdListCmd>(cmd, getUserIdListCmd);
            RE:
                jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devGetUserIdListCmd));
                if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                {
                    int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                    if (state == 0)
                    {
                        try
                        {
                            _ResultInfo<UserListInfo<UserIdName>> personIDList = JsonConvert.DeserializeObject<_ResultInfo<UserListInfo<UserIdName>>>(jsonStringBuilder.ToString());
                            if (personIDList.result_data.usersCount > 0)
                            {
                                foreach (UserIdName idName in personIDList.result_data.users)
                                {
                                    usersIDList.Add(idName.userId);
                                }
                                if (personIDList.result_data.packageId != 0)
                                {
                                    devGetUserIdListCmd.data.packageId++;
                                    goto RE;
                                }
                                ret = true;
                            }
                        }
                        catch
                        {

                        }

                    }
                    else if (state == -6)
                    {
                        sendCount++;
                        if (sendCount > 2)
                            return ret;
                        else
                            goto RE;
                    }
                    else
                    {
                        return ret;
                    }
                }
                else
                {
                    ret = false;
                }
                #endregion

                if (usersIDList == null||usersIDList.Count<=0)
                {
                    DeviceObject.socKetClient.ErrMsg = Pub.GetResText("", "FK_RUNERR_DATAARRAY_NONE", "");
                    ret = false;
                    return ret;
                }
                ret = true;
                cmd = "GetUserInfo";
                progBar.ProgressType = eProgressItemType.Marquee;
                sendCount = 0;
                PersonInfoList.Clear();
                GetUserInfoCmd getUserInfoCmd = new GetUserInfoCmd(0, usersIDList);
                _DeviceCmd<GetUserInfoCmd> devGetUserInfoCmd = new _DeviceCmd<GetUserInfoCmd>(cmd, getUserInfoCmd);
                while (true)
                {
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgGetDataInfoBao", "") + " - " + devGetUserInfoCmd.data.packageId;
                    Application.DoEvents();
                    jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devGetUserInfoCmd));
                    if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                    {
                        int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                        if (state == 0)
                        {
                            _ResultInfo<PersonInfo<GetUsers>> getUserInfo = JsonConvert.DeserializeObject<_ResultInfo<PersonInfo<GetUsers>>>(jsonStringBuilder.ToString());

                            if (getUserInfo.result_data.users == null)
                            {
                                ret = false;
                                break;
                            }

                            PersonInfoList.Add(getUserInfo);

                            if (getUserInfo.result_data.packageId != 0)//表示没有获取完数据，让packageId+1，重新发送获取获取下一包数据
                            {
                                devGetUserInfoCmd.data.packageId++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (state == -6)
                        {
                            sendCount++;
                            if (sendCount > 2)
                            {
                                ret = false;
                                break;
                            }
                            else
                            {
                                if (DeviceObject.socKetClient.Open()) continue;
                                else
                                {
                                    ret = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            ret = false;
                            break;
                        }
                    }
                    else
                    {
                        if (DeviceObject.socKetClient.ErrMsg.Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.socKetClient.ErrMsg + "\r\n\r\n" +
                     Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                            if (MessRet == DialogResult.OK)
                            {
                                if (DeviceObject.socKetClient.Open()) continue;
                                else
                                {
                                    ret = false;
                                    break;
                                }
                            }
                            else
                            {
                                ret = false;
                                break;
                            }
                        }
                    }
                }
                if (PersonInfoList.Count > 0)
                {
                    progBar.ProgressType = eProgressItemType.Standard;
                    for (int l = 0; l < PersonInfoList.Count; l++)
                    {
                        _ResultInfo<PersonInfo<GetUsers>> getUserInfo = PersonInfoList[l];
                        for (int i = 0; i < getUserInfo.result_data.users.Length; i++)
                        {
                            EmpCount++;

                            StartDate = getUserInfo.result_data.users[i].vaildStart;
                            EndDate = getUserInfo.result_data.users[i].vaildEnd;

                            StartDate = stringToTimeStr(StartDate);
                            EndDate = stringToTimeStr(EndDate);

                            StartDate = CheckTimeStr(StartDate);
                            EndDate = CheckTimeStr(EndDate);
                            empRows = dtEmpSelect.Select("FingerNo=" + getUserInfo.result_data.users[i].userId + "");
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
                          string.Format(" - {2}/{3}  [{0}: {1}]", getUserInfo.result_data.users[i].userId, getUserInfo.result_data.users[i].name, EmpCount, usersIDList.Count);
                            if (EmpCount > 0)
                                progBar.Value = EmpCount * 100 / usersIDList.Count;
                            Application.DoEvents();
                        }
                        if (dtInsert.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsert, "DI_StarPower");
                            dtInsert.Clear();
                        }
                        if (dtUpdate.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdate, "DI_StarPower", "GUID");
                            dtUpdate.Clear();
                        }
                    }
                }

            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, EmpCount, usersIDList.Count, EmpCount);
            }

            return ret;
        }

        private string GetGUID()
        {
            string ret = System.Guid.NewGuid().ToString().ToUpper();
            return ret;
        }

        public bool SetSatrParam(ref string MacMsg)
        {
            bool ret = false;

            if (DeviceObject.socKetClient.SendData(ref Parameter))
            {
                int state = DeviceObject.socKetClient.JsonRecive(Parameter);
                if (state == 0)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        public bool GetSatrParam(ref string MacMsg)
        {
            bool ret = false;

            if (DeviceObject.socKetClient.SendData(ref Parameter))
            {
                int state = DeviceObject.socKetClient.JsonRecive(Parameter);
                if (state == 0)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }
            if (ret) BodyParameter = Parameter;
            this.DialogResult = DialogResult.OK;
            DeviceObject.socKetClient.Close();
            IsWorking = false;
            this.Close();
            return ret;
        }

        private bool MJDoorOpen(string MacSN, ref string MacMsg)
        {
            bool ret = false;

            string cmd = "SetDoorStatus";
            SetDoor setDoor = new SetDoor("open");
            _DeviceCmd<SetDoor> devSetDoor = new _DeviceCmd<SetDoor>(cmd, setDoor);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devSetDoor));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }
        private bool MJDoorOpenClose(string MacSN, ref string MacMsg)
        {
            bool ret = false;

            string cmd = "SetDoorStatus";
            SetDoor setDoor = new SetDoor("open_close");
            _DeviceCmd<SetDoor> devSetDoor = new _DeviceCmd<SetDoor>(cmd, setDoor);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devSetDoor));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        private bool MJStarRebootDevice(string MacSN, ref string MacMsg)
        {
            bool ret = false;

            string cmd = "Restart";

            DeviceCmd devRestart = new DeviceCmd(cmd);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devRestart));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }
        private bool MJDoorClose(string MacSN, ref string MacMsg)
        {
            bool ret = false;

            string cmd = "SetDoorStatus";
            SetDoor setDoor = new SetDoor("close");
            _DeviceCmd<SetDoor> devSetDoor = new _DeviceCmd<SetDoor>(cmd, setDoor);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devSetDoor));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }


        private void btnOprt_Click(object sender, EventArgs e)
        {
            if (flag == 11) flag = 10;
            else if (flag == 12) flag = 10;
            oprt = btnStarOprt.Text;
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

        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            flag = 11;
            oprt = btnOpenDoor.Text;
            ExecMacOprt();
        }

        private void btnCloseDoor_Click(object sender, EventArgs e)
        {
            flag = 12;
            oprt = btnCloseDoor.Text;
            ExecMacOprt();
        }

        private void msgGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmBaseShowMsg frm = new frmBaseShowMsg(this.Text, msgGrid[0, e.RowIndex].Value.ToString());
            frm.ShowDialog();
        }
    }
}