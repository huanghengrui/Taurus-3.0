using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace Taurus
{
    public partial class frmMJDevSet : frmBaseForm
    {
        public string DoorMagnetic_TypeAll = "";
        public string Anti_backAll = "";
        public string ServerRequestAll = "";
        public string Use_AlarmAll = "";
        public string Wiegand_OutputAll = "";
        public string Wiegand_InputAll = "";
        private List<TDIConnInfo> connList = new List<TDIConnInfo>();
        private bool IsWorking = false;
        private string Title = "";
        private string CurrentOprt = "";
        protected override void InitForm()
        {
            formCode = "PubDevSet";
            SetTextboxNumber(txtServerPort);

            SetcomboboxNumber(cbbGlogWarning);
            SetcomboboxNumber(cbbDoorMagneticDelay);
            SetcomboboxNumber(cbbDiMacNo);
            SetcomboboxNumber(cbbOpenDoorDelay);
            SetcomboboxNumber(cbbManagers);
            SetcomboboxNumber(cbbVolume);
            SetcomboboxNumber(cbbMutiUser);
            SetcomboboxNumber(cbbShowResultTime);
            SetcomboboxNumber(cbbReverifyTime);
            SetcomboboxNumber(cbbScreensaversTime);
            SetcomboboxNumber(cbbSleepTime);
            SetcomboboxNumber(cbbWiegandType);

            DEVGrid.Columns.Clear();

            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "MacSN", false, 0);
            AddColumn(0, "MacDesc", false, false, 0);
            AddColumn(0, "MacTypeID", true, false, 0);
            AddColumn(0, "MacTypeName", true, false, 0);
            AddColumn(0, "MacConnType", false, false, 0);
            AddColumn(0, "MacIP", false, false, 0);
            AddColumn(0, "MacPort", false, false, 0);
            AddColumn(0, "MacConnPWD", true, false, 0);
            AddColumn(1, "IsGPRS", false, false, 1, 60);

            base.InitForm();
            this.Text = CurrentOprt;
            string QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "0" });
            try
            {
                bindingSource.DataSource = SystemInfo.db.GetDataTable(QuerySQL);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, QuerySQL);
            }

            DoorMagnetic_TypeAll = Pub.GetResText(formCode, "no", "");//门磁类型"no","close","open"
            Anti_backAll = Pub.GetResText(formCode, "no", "");//防潜回"no","yes"
            Use_AlarmAll = Pub.GetResText(formCode, "yes", "");//防拆报警"no","yes"
            ServerRequestAll = Pub.GetResText(formCode, "no", ""); //是否传送
            Wiegand_OutputAll = Pub.GetResText(formCode, "CardNo", ""); //韦根输出
            Wiegand_InputAll = Pub.GetResText(formCode, "CardNo", ""); //韦根输入
            Column1.Width = msgGrid.Width - 20;

            for (int i = 0; i <= 1440; i++)
            {

                if (i <= 1000)
                {
                    cbbGlogWarning.Items.Add(i);
                }
                if (i <= 200)
                {
                    cbbDoorMagneticDelay.Items.Add(i);
                    cbbOpenDoorDelay.Items.Add(i);
                }
                   
                if (i <= 255)
                {
                    cbbAlarmDelay.Items.Add(i);
                    cbbDiMacNo.Items.Add(i);
                   
                }
                if (i <= 10)
                {
                    cbbManagers.Items.Add(i);
                    cbbVolume.Items.Add(i);
                    cbbMutiUser.Items.Add(i);
                }
                if (i <= 60)
                {
                   
                    cbbReverifyTime.Items.Add(i);

                    cbbSleepTime.Items.Add(i);
                }
                if (i <= 30)
                {
                    cbbShowResultTime.Items.Add(i);
                }
                    cbbScreensaversTime.Items.Add(i);
            }
            cbbWiegandType.Items.Add(26);
            cbbWiegandType.Items.Add(34);

            cbbDoorMagneticType.Items.Add(Pub.GetResText(formCode, "no", ""));
            cbbDoorMagneticType.Items.Add(Pub.GetResText(formCode, "close", ""));
            cbbDoorMagneticType.Items.Add(Pub.GetResText(formCode, "open", ""));
            cbbAntiback.Items.Add(Pub.GetResText(formCode, "no", ""));
            cbbAntiback.Items.Add(Pub.GetResText(formCode, "yes", ""));
            cbbUseAlarm.Items.Add(Pub.GetResText(formCode, "no", ""));
            cbbUseAlarm.Items.Add(Pub.GetResText(formCode, "yes", ""));
            cbbServerRequest.Items.Add(Pub.GetResText(formCode, "no", ""));
            cbbServerRequest.Items.Add(Pub.GetResText(formCode, "yes", ""));
            cbbWiegandOutput.Items.Add(Wiegand_OutputAll);
            cbbWiegandInput.Items.Add(Wiegand_InputAll);
            cbbWiegandOutput.Items.Add(Pub.GetResText(formCode, "EmpNoParam", ""));
            cbbWiegandInput.Items.Add(Pub.GetResText(formCode, "EmpNoParam", ""));
            Application.DoEvents();
            DEVGrid_CellClick(null, null);

        }
        public void DefaultControl()
        {
            cbbGlogWarning.Text = "0"; //考勤记录警告0-1000
            cbbDoorMagneticDelay.Text = "10";//门磁延时0-200
            cbbAlarmDelay.Text = "1";//报警延时0-255
            cbbDiMacNo.Text = "1";//机器号1-255
            cbbOpenDoorDelay.Text = "5";//开门延时0-200
            cbbManagers.Text = "5";//管理者总数0-10
            cbbVolume.Text = "5";//音量0-10

            cbbMutiUser.Text = "1";//同时确认数1-10
            cbbShowResultTime.Text = "1";//界面返回时间0-30
            cbbReverifyTime.Text = "1";//重复确认时间0-60
            cbbScreensaversTime.Text = "60";//屏幕保护时间0-60*24
            cbbSleepTime.Text = "0";// 睡眠时间0 - 60
            cbbWiegandType.Text = "34";//Wiegand格式26,34
            cbbWiegandOutput.Text = Wiegand_OutputAll;//Wiegand输出0,1
            cbbWiegandInput.Text = Wiegand_InputAll;//Wiegand输入0,1
            cbbDoorMagneticType.Text = DoorMagnetic_TypeAll;//门磁类型"no","close","open"
            cbbAntiback.Text = Anti_backAll;//防潜回"no","yes"
            cbbUseAlarm.Text = Use_AlarmAll;//防拆报警"no","yes"
            cbbServerRequest.Text = ServerRequestAll; //是否传送
            txtServerIPAddress.Text = "192.168.001.100";//服务器IP地址
            txtServerPort.Text = "7005";//服务器端口
        }

        private TDIConnInfo RowDataToConnInfo(int RowIndex)
        {
            int MacSN = 0;
            string MacSN_GRPS = "";
            bool IsGPRS = Pub.ValueToBool(DEVGrid[9, RowIndex].Value);
            if (IsGPRS)
                MacSN_GRPS = DEVGrid[1, RowIndex].Value.ToString();
            else
            {
                MacSN = Convert.ToInt32(DEVGrid[1, RowIndex].Value.ToString());
                MacSN_GRPS = MacSN.ToString();
            }
            string MacConnType = DEVGrid[5, RowIndex].Value.ToString();
            string MacIP = DEVGrid[6, RowIndex].Value.ToString();
            string MacPort = DEVGrid[7, RowIndex].Value.ToString();
            string MacConnPWD = DEVGrid[8, RowIndex].Value.ToString();
            return Pub.ValueToDIConnInfo(MacSN, MacSN_GRPS, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS,1,"","");
        }

        private void RowToConnInfo(int RowIndex)
        {
            connList.Add(RowDataToConnInfo(RowIndex));
        }
        private bool InitMacList()
        {
            connList.Clear();
            if (DEVGrid.RowCount == 1)
            {
                RowToConnInfo(0);
            }
            else
            {
                for (int i = 0; i < DEVGrid.RowCount; i++)
                {
                    if (Pub.ValueToBool(DEVGrid[0, i].EditedFormattedValue))
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

        private void ExecMacOprt(string oprt, int flag)
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
            TDIConnInfo conn;
            for (int i = 0; i < connList.Count; i++)
            {
                conn = connList[i];
                RefreshMacMsg(oprt + "[" + conn.MacSN.ToString() + "]......");
                DeviceObject.objFK623.InitConn(conn);
                if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
                DeviceObject.objFK623.EnableDevice(0);
                state = DeviceObject.objFK623.IsOpen;
                if (state) state = ExecMacCommand(flag, conn.MacSN, ref MacMsg);
                ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                UpdateMacMsg(MacMsg + DeviceObject.objFK623.ErrMsg + ExecTimes, state);
                msg = msg + conn.MacSN.ToString() + ":" + MacMsg + DeviceObject.objFK623.ErrMsg + ";";
                DeviceObject.objFK623.EnableDevice(1);
                DeviceObject.objFK623.Close();
                start = DateTime.Now;
                if (!IsWorking) break;
            }
            SystemInfo.db.WriteSYLog(this.Text, oprt, msg);
            IsWorking = false;
            RefresButton();
        }

        private bool ExecMacCommand(int flag, int MacSN, ref string MacMsg)
        {
            bool ret = false;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://上传参数
                    ret = UploadParam(MacSN);
                    break;
                case 1://下载参数
                    ret = DownloadParam(MacSN);
                    break;
                case 2://解除报警
                    ret = AlarmParam(MacSN);
                    break;
            }
            return ret;
        }

        private bool UploadParam(int MacSN)
        {
            bool ret = false;
            JObject vjobjparam = new JObject();
            string ServerIPAddress = "";
            int ServerPort = 0;
            int ServerRequest = 0;
            string vstrJsonStr = "";
            DataTableReader dr = null;
            JObject vjobj = new JObject();
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN.ToString() }));
                if (dr.Read())
                {
                    vjobj.Add("cmd\0", "lock_control_set\0");
                    vjobjparam.Add("Managers", dr["Managers"].ToString());                      //管理者总数0-10
                    vjobjparam.Add("Volume", dr["Volume"].ToString());                          //音量0-10
                    vjobjparam.Add("Glog_Warning", dr["GlogWarning"].ToString());               //考勤记录警告0-1000
                    vjobjparam.Add("Show_ResultTime", dr["ShowResultTime"].ToString());         //界面返回时间0-30
                    vjobjparam.Add("Reverify_Time", dr["ReverifyTime"].ToString());             //重复确认时间0-60
                    vjobjparam.Add("Screensavers_Time", dr["ScreensaversTime"].ToString());     //屏幕保护时间0-60*24
                    vjobjparam.Add("Sleep_Time", dr["SleepTime"].ToString());                   //睡眠时间0 - 60
                    vjobjparam.Add("Wiegand_Type", dr["WiegandType"].ToString());               //Wiegand格式26,34
                    vjobjparam.Add("Wiegand_Output", dr["WiegandOutput"].ToString());           //Wiegand输出0,1
                    vjobjparam.Add("Wiegand_Input", dr["WiegandInput"].ToString());             //Wiegand输入0,1
                    vjobjparam.Add("OpenDoor_Delay", dr["OpenDoorDelay"].ToString());           //开门延时0-200
                    vjobjparam.Add("MutiUser", dr["MutiUser"].ToString());                      //同时确认数1-10
                    vjobjparam.Add("DoorMagnetic_Type", dr["DoorMagneticType"].ToString());     //门磁类型"no","close","open"
                    vjobjparam.Add("DoorMagnetic_Delay", dr["DoorMagneticDelay"].ToString());   //门磁延时0-200
                    vjobjparam.Add("Alarm_Delay", dr["AlarmDelay"].ToString());                 //报警延时0-255
                    vjobjparam.Add("Anti-back", dr["Antiback"].ToString());                     //防潜回"no","yes"
                    vjobjparam.Add("Use_Alarm", dr["UseAlarm"].ToString() + "\0");                     //防拆报警"no","yes"
                    vjobj.Add("param", vjobjparam);
                    vstrJsonStr = vjobj.ToString();
                    ret = DeviceObject.objFK623.ExecJsonCmd(ref vstrJsonStr);
                    vstrJsonStr = "";
                    ServerIPAddress = dr["ServerIPAddress"].ToString();
                    ServerPort = Convert.ToInt32(dr["ServerPort"].ToString());
                    ServerRequest = Convert.ToInt32(dr["ServerRequest"].ToString());

                    ret = DeviceObject.objFK623.SetServerNetInfo(ServerIPAddress, ServerPort, ServerRequest);

                    ret = DeviceObject.objFK623.SetDeviceInfo(2, Convert.ToInt32(MacSN.ToString()));
                }
                else
                {
                    ret = false;
                }

            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }

            return ret;
        }


        private bool DownloadParam(int MacSN)
        {
            bool ret = false;
            string ServerIPAddress = "192.168.1.100";
            int ServerPort = 0;
            int ServerRequest = 0;
            int DiMacNo = 0;
            string DoorMagnetic_Type = "no";
            string Anti_back = "no";
            string Use_Alarm = "yes";
            string Glog_Warning = "0";
            string DoorMagnetic_Delay = "10";
            string Alarm_Delay = "1";
            string OpenDoor_Delay = "5";
            string Managers = "5";
            string Volume = "5";
            string MutiUser = "1";
            DataTableReader dr = null;
            string Show_ResultTime = "1";
            string Reverify_Time = "1";
            string Screensavers_Time = "60";
            string Sleep_Time = "0";
            string Wiegand_Type = "34";
            string Wiegand_Output = "0";
            string Wiegand_Input = "0";
            string sql = "";
            string[] param = new string[0];
            string[] tmp = new string[2];
            string vstrJsonStr = new string('a', 500);
            try
            {
                JObject vjobj = new JObject();
                vjobj.Add("cmd", "lock_control_get");
                vstrJsonStr = vjobj.ToString() + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

                ret = DeviceObject.objFK623.ExecJsonCmd(ref vstrJsonStr);

                if (vstrJsonStr != null && vstrJsonStr != "")
                {
                    string logText = vstrJsonStr.Replace("\"", "").Replace("{", "").Replace("}", "");

                    param = logText.Split(',');
                    for (int i = 0; i < param.Length; i++)
                    {
                        tmp = null;
                        tmp = param[i].Split(':');
                        switch (tmp[0])
                        {
                            case "Alarm_Delay":

                                Alarm_Delay = tmp[1];
                                break;
                            case "Anti-back":

                                Anti_back = tmp[1];
                                break;
                            case "DoorMagnetic_Delay":

                                DoorMagnetic_Delay = tmp[1];
                                break;
                            case "DoorMagnetic_Type":

                                DoorMagnetic_Type = tmp[1];
                                break;
                            case "Glog_Warning":

                                Glog_Warning = tmp[1];
                                break;
                            case "Managers":

                                Managers = tmp[1];
                                break;
                            case "MutiUser":

                                MutiUser = tmp[1];
                                break;
                            case "OpenDoor_Delay":

                                OpenDoor_Delay = tmp[1];
                                break;
                            case "Reverify_Time":

                                Reverify_Time = tmp[1];
                                break;
                            case "Screensavers_Time":

                                Screensavers_Time = tmp[1];
                                break;
                            case "Show_ResultTime":

                                Show_ResultTime = tmp[1];
                                break;
                            case "Sleep_Time":

                                Sleep_Time = tmp[1];
                                break;
                            case "Use_Alarm":

                                Use_Alarm = tmp[1];
                                break;
                            case "Volume":

                                Volume = tmp[1];
                                break;
                            case "Wiegand_Input":

                                Wiegand_Input = tmp[1];
                                break;
                            case "Wiegand_Output":

                                Wiegand_Output = tmp[1];
                                break;
                            case "Wiegand_Type":

                                Wiegand_Type = tmp[1];
                                break;

                        }
                    }
                    ret = DeviceObject.objFK623.GetServerNetInfo(ref ServerIPAddress, ref ServerPort, ref ServerRequest);

                    ret = DeviceObject.objFK623.GetDeviceInfo(2, ref DiMacNo);

                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN.ToString() }));
                    if (dr.Read())
                    {
                        sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "203", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                        ServerRequest.ToString(),Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,DiMacNo.ToString(),OpenDoor_Delay,
                        Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                        Wiegand_Type,ServerIPAddress,ServerPort.ToString(),Wiegand_Output,Wiegand_Input});
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "202", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                        ServerRequest.ToString(),Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,DiMacNo.ToString(),OpenDoor_Delay,
                        Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                        Wiegand_Type,ServerIPAddress,ServerPort.ToString(),Wiegand_Output,Wiegand_Input});
                    }

                    SystemInfo.db.ExecSQL(sql);
                }
                else
                {
                    ret = DeviceObject.objFK623.GetServerNetInfo(ref ServerIPAddress, ref ServerPort, ref ServerRequest);
                    ret = DeviceObject.objFK623.GetDeviceInfo(2, ref DiMacNo);
                    if (ret)
                    {
                        cbbServerRequest.Text = ServerRequest.ToString(); //是否传送
                        txtServerIPAddress.Text = ServerIPAddress;//服务器IP地址
                        txtServerPort.Text = ServerPort.ToString();//服务器端口
                        cbbDiMacNo.Text = DiMacNo.ToString();//机器号1-255
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN.ToString() }));
                        if (dr.Read())
                        {
                            sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "203", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                        ServerRequest.ToString(),Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,DiMacNo.ToString(),OpenDoor_Delay,
                        Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                        Wiegand_Type,ServerIPAddress,ServerPort.ToString(),Wiegand_Output,Wiegand_Input});
                        }
                        else
                        {
                            sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "202", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                        ServerRequest.ToString(),Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,DiMacNo.ToString().ToString(),OpenDoor_Delay,
                        Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                        Wiegand_Type,ServerIPAddress,ServerPort.ToString(),Wiegand_Output,Wiegand_Input});
                        }

                        SystemInfo.db.ExecSQL(sql);
                    }
                    else
                        ret = false;
                    return ret;
                }


            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            vstrJsonStr = null;
            DEVGrid_CellClick(null, null);
            Application.DoEvents();
            return ret;
        }

        private bool AlarmParam(int MacSN)
        {
            bool ret = false;
            ret = DeviceObject.objFK623.SetAlarmStatus(0);
            return ret;
        }

        private void RefresButton()
        {
            DEVGrid.Enabled = !IsWorking;
            tabControl1.Enabled = !IsWorking && (bindingSource.Count > 0);
            btnUpload.Enabled = !IsWorking && (bindingSource.Count > 0);
            btnDownload.Enabled = !IsWorking && (bindingSource.Count > 0);
            btnSave.Enabled = !IsWorking && (bindingSource.Count > 0);
            btnAlarm.Enabled = !IsWorking && (bindingSource.Count > 0);
        }

        public frmMJDevSet(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }
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
            AddColumn(DEVGrid, colType, Field, IsHide, HasSort, CenterFlag, colWidth);
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
        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            SelectData(e.CheckedState);
        }

        private void DEVGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = DEVGrid.CurrentRow.Index;    //取得选中行的索引  
            string MacSN = DEVGrid.Rows[index].Cells[1].Value.ToString();

            DataTableReader dr = null;
            string DoorMagnetic_Type = "";
            string Anti_back = "";
            string ServerRequest = "";
            string Use_Alarm = "";
            string Wiegand_Output = "";
            string Wiegand_Input = "";
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN }));
            if (dr.Read())
            {
                cbbGlogWarning.Text = dr["GlogWarning"].ToString();
                cbbDoorMagneticDelay.Text = dr["DoorMagneticDelay"].ToString();
                cbbAlarmDelay.Text = dr["AlarmDelay"].ToString();
                cbbDiMacNo.Text = dr["DiMacNo"].ToString();
                cbbOpenDoorDelay.Text = dr["OpenDoorDelay"].ToString();
                cbbManagers.Text = dr["Managers"].ToString();
                cbbVolume.Text = dr["Volume"].ToString();

                cbbMutiUser.Text = dr["MutiUser"].ToString();
                cbbShowResultTime.Text = dr["ShowResultTime"].ToString();
                cbbReverifyTime.Text = dr["ReverifyTime"].ToString();
                cbbScreensaversTime.Text = dr["ScreensaversTime"].ToString();
                cbbSleepTime.Text = dr["SleepTime"].ToString();
                cbbWiegandType.Text = dr["WiegandType"].ToString();

                Wiegand_Output = dr["WiegandOutput"].ToString();
                Wiegand_Input = dr["WiegandInput"].ToString();
                DoorMagnetic_Type = dr["DoorMagneticType"].ToString();
                if (DoorMagnetic_Type == "no")
                {
                    cbbDoorMagneticType.Text = DoorMagnetic_TypeAll;
                }
                else if (DoorMagnetic_Type == "close")
                {
                    cbbDoorMagneticType.Text = Pub.GetResText(formCode, "close", "");
                }
                else
                {
                    cbbDoorMagneticType.Text = Pub.GetResText(formCode, "open", "");
                }
                Anti_back = dr["Antiback"].ToString();
                if (Anti_back == "no")
                {
                    cbbAntiback.Text = Anti_backAll;
                }
                else
                {
                    cbbAntiback.Text = Pub.GetResText(formCode, "yes", "");
                }

                Use_Alarm = dr["UseAlarm"].ToString();
                if (Use_Alarm == "yes")
                {
                    cbbUseAlarm.Text = Use_AlarmAll;
                }
                else
                {
                    cbbUseAlarm.Text = Pub.GetResText(formCode, "no", "");
                }
                ServerRequest = dr["ServerRequest"].ToString();
                if (ServerRequest == "0")
                {
                    cbbServerRequest.Text = ServerRequestAll;
                }
                else
                {
                    cbbServerRequest.Text = Pub.GetResText(formCode, "yes", "");
                }


                if (Wiegand_Input == "1")
                {
                    cbbWiegandInput.Text = Pub.GetResText(formCode, "CardNo", "");
                }
                else
                {
                    cbbWiegandInput.Text = Pub.GetResText(formCode, "EmpNoParam", "");
                }

                if (Wiegand_Output == "1")
                {
                    cbbWiegandOutput.Text = Pub.GetResText(formCode, "CardNo", "");
                }
                else
                {
                    cbbWiegandOutput.Text = Pub.GetResText(formCode, "EmpNoParam", "");
                }
                txtServerIPAddress.Text = dr["ServerIPAddress"].ToString();
                txtServerPort.Text = dr["ServerPort"].ToString();
                Application.DoEvents();
            }
            else
            {
                DefaultControl();
                Application.DoEvents();
            }
        }

        private void RefreshMacMsg(string msg)
        {
            msgGrid.Rows.Add();
            msgGrid[0, msgGrid.RowCount - 1].Value = "[" + DateTime.Now.ToString() + "] " + msg;
            msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
            msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
            Application.DoEvents();
        }

        private void UpdateMacMsg(string msg, bool state)
        {
            string s = msgGrid[0, msgGrid.RowCount - 1].Value.ToString();

            msgGrid[0, msgGrid.RowCount - 1].Value = s + "    " + msg;
            if (state)
                msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Blue;
            else
                msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Red;
            Application.DoEvents();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //btnSave_Click(null,null);
            ExecMacOprt(btnUpload.Text, 0);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            ExecMacOprt(btnDownload.Text, 1);
        }

        private void msgGrid_Resize(object sender, EventArgs e)
        {
            Column1.Width = msgGrid.Width - 20;
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            ExecMacOprt(btnAlarm.Text, 2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string DoorMagnetic_Type = "";
            string Anti_back = "";
            string ServerRequest = "";
            string Use_Alarm = "";
            string Glog_Warning = "";
            string DoorMagnetic_Delay = "";
            string Alarm_Delay = "";
            string Di_MacNo = "";
            string OpenDoor_Delay = "";
            string Managers = "";
            string Volume = "";
            string MutiUser = "";

            string Show_ResultTime = "";
            string Reverify_Time = "";
            string Screensavers_Time = "";
            string Sleep_Time = "";
            string Wiegand_Type = "";
            string Wiegand_Output = "";
            string Wiegand_Input = "";
            string ServerIPAddress = "";
            string ServerPort = "";

            string MacSN = "";
            string sql = "";
            string msg = "";
            bool ret = true;
            string Mac = "";
            string Err = "";
            Glog_Warning = cbbGlogWarning.Text.Trim();
            DoorMagnetic_Delay = cbbDoorMagneticDelay.Text.Trim();
            Alarm_Delay = cbbAlarmDelay.Text.Trim();
            Di_MacNo = cbbDiMacNo.Text.Trim();
            OpenDoor_Delay = cbbOpenDoorDelay.Text.Trim();
            Managers = cbbManagers.Text.Trim();
            Volume = cbbVolume.Text.Trim();
            MutiUser = cbbMutiUser.Text.Trim();

            Show_ResultTime = cbbShowResultTime.Text.Trim();
            Reverify_Time = cbbReverifyTime.Text.Trim();
            Screensavers_Time = cbbScreensaversTime.Text.Trim();
            Sleep_Time = cbbSleepTime.Text.Trim();
            Wiegand_Type = cbbWiegandType.Text.Trim();
            ServerIPAddress = txtServerIPAddress.Text.Trim();
            ServerPort = txtServerPort.Text.Trim();
            Application.DoEvents();
            if (int.Parse(Managers) > 10 || int.Parse(Managers) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label1.Text, 0, 10);
                Pub.MessageBoxShow(Err);
                cbbManagers.Focus();
                return;
            }

            if (int.Parse(Volume) > 10 || int.Parse(Volume) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label2.Text, 0, 10);
                Pub.MessageBoxShow(Err);
                cbbVolume.Focus();
                return;
            }
            if (int.Parse(Glog_Warning) > 1000 || int.Parse(Glog_Warning) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label4.Text, 0, 1000);
                Pub.MessageBoxShow(Err);
                cbbGlogWarning.Focus();
                return;
            }
            if (int.Parse(Show_ResultTime) > 30 || int.Parse(Show_ResultTime) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label3.Text, 0, 30);
                Pub.MessageBoxShow(Err);
                cbbShowResultTime.Focus();
                return;
            }
            if (int.Parse(Reverify_Time) > 60 || int.Parse(Reverify_Time) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label5.Text, 0, 60);
                Pub.MessageBoxShow(Err);
                cbbReverifyTime.Focus();
                return;
            }
            if (int.Parse(Screensavers_Time) > 1440 || int.Parse(Screensavers_Time) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label6.Text, 0, 1440);
                Pub.MessageBoxShow(Err);
                cbbScreensaversTime.Focus();
                return;
            }
            if (int.Parse(Sleep_Time) > 60 || int.Parse(Sleep_Time) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label7.Text, 0, 60);
                Pub.MessageBoxShow(Err);
                cbbSleepTime.Focus();
                return;
            }
            if (int.Parse(OpenDoor_Delay) > 200 || int.Parse(OpenDoor_Delay) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label14.Text, 0, 200);
                Pub.MessageBoxShow(Err);
                cbbOpenDoorDelay.Focus();
                return;
            }
            if (int.Parse(MutiUser) > 10 || int.Parse(MutiUser) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label13.Text, 0, 10);
                Pub.MessageBoxShow(Err);
                cbbMutiUser.Focus();
                return;
            }
            if (int.Parse(DoorMagnetic_Delay) > 200 || int.Parse(DoorMagnetic_Delay) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label15.Text, 0, 200);
                Pub.MessageBoxShow(Err);
                cbbDoorMagneticDelay.Focus();
                return;
            }

            if (int.Parse(Alarm_Delay) > 255 || int.Parse(Alarm_Delay) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label14.Text, 0, 255);
                Pub.MessageBoxShow(Err);
                cbbAlarmDelay.Focus();
                return;
            }
            if (int.Parse(Di_MacNo) > 255 || int.Parse(Di_MacNo) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label9.Text, 0, 255);
                Pub.MessageBoxShow(Err);
                cbbDiMacNo.Focus();
                return;
            }


            Wiegand_Output = cbbWiegandOutput.Text.Trim();
            Wiegand_Input = cbbWiegandInput.Text.Trim();

            if (Wiegand_Output == Pub.GetResText(formCode, "CardNo", ""))
            {
                Wiegand_Output = "1";
            }
            else
            {
                Wiegand_Output = "0";
            }

            if (Wiegand_Input == Pub.GetResText(formCode, "CardNo", ""))
            {
                Wiegand_Input = "1";
            }
            else
            {
                Wiegand_Input = "0";
            }

            DoorMagnetic_Type = cbbDoorMagneticType.Text.Trim();
            Anti_back = cbbAntiback.Text.Trim();
            ServerRequest = cbbServerRequest.Text.Trim();
            Use_Alarm = cbbUseAlarm.Text.Trim();

            if (DoorMagnetic_Type == DoorMagnetic_TypeAll)
            {
                DoorMagnetic_Type = "no";
            }
            else if (DoorMagnetic_Type == Pub.GetResText(formCode, "close", ""))
            {
                DoorMagnetic_Type = "close";
            }
            else
            {
                DoorMagnetic_Type = "open";
            }

            if (Anti_back == Anti_backAll)
            {
                Anti_back = "no";
            }
            else
            {
                Anti_back = "yes";
            }

            if (ServerRequest == ServerRequestAll)
            {
                ServerRequest = "0";
            }
            else
            {
                ServerRequest = "1";
            }

            if (Use_Alarm == Use_AlarmAll)
            {
                Use_Alarm = "yes";
            }
            else
            {
                Use_Alarm = "no";
            }

            DataTable dt = (DataTable)bindingSource.DataSource;

            int index = DEVGrid.CurrentRow.Index;    //取得选中行的索引  
            MacSN = DEVGrid.Rows[index].Cells[1].Value.ToString();
            Application.DoEvents();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ret = true;
                bool Select = false;
                if (!Convert.IsDBNull(dt.Rows[i]["SelectCheck"]))
                {
                    Select = Convert.ToBoolean(dt.Rows[i]["SelectCheck"]);
                }
                if (MacSN == "")
                {
                    if (!Select) continue;
                    MacSN = dt.Rows[i]["MacSN"].ToString();
                    if (Mac == MacSN)
                    {
                        MacSN = "";
                        continue;
                    }
                }
                else
                {
                    Mac = MacSN;
                    i = -1;
                }
                msg = " [" + MacSN + "] " + "...";
                RefreshMacMsg(msg);
                DataTableReader dr = null;
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN }));
                if (dr.Read())
                {
                    sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "203", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                          ServerRequest,Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,Di_MacNo,OpenDoor_Delay,
                          Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                          Wiegand_Type,ServerIPAddress,ServerPort,Wiegand_Output,Wiegand_Input});
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "202", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                          ServerRequest,Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,Di_MacNo,OpenDoor_Delay,
                          Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                          Wiegand_Type,ServerIPAddress,ServerPort,Wiegand_Output,Wiegand_Input});
                }
                try
                {
                    SystemInfo.db.ExecSQL(sql);
                }
                catch (Exception E)
                {
                    ret = false;
                    Pub.ShowErrorMsg(E, sql);
                }
                finally
                {
                    if (dr != null) dr.Close();
                    dr = null;
                }
                if (ret)
                {
                    msg = Pub.GetResText(formCode, "MsgSaveSucceed", "");
                }
                else
                {
                    msg = Pub.GetResText(formCode, "MsgSaveFail", "");
                }
                UpdateMacMsg(msg, ret);
                MacSN = "";
                Application.DoEvents();
            }
        }
    }
}