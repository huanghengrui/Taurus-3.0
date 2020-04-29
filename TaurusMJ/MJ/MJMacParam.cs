using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Taurus
{
    public partial class frmMJMacParam : frmBaseDialog
    {
     
        private DataTable dtReal = new DataTable();
        private List<TDIConnInfo> connList = new List<TDIConnInfo>();
        private List<string> AddList = new List<string>();
        private bool IsWorking = false;
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;
        protected override void InitForm()
        {
            formCode = "PubMacParam";
            
            dataGrid.Columns.Clear();
            AddColumn(dataGrid, 3, "SelectCheck",         false, false, 1, 60);
            AddColumn(dataGrid, 0, "MacSN", false, false, 1, 0);
            AddColumn(dataGrid, 0, "MacDesc",             false, false, 0, 0);
            AddColumn(dataGrid, 0, "MacTypeID",           true, false, 0, 0);
            AddColumn(dataGrid, 0, "MacTypeName",         true, false, 0, 0);
            AddColumn(dataGrid, 0, "MacConnType",         true, false, 0, 0);
            AddColumn(dataGrid, 0, "MacIP",               true, false, 0, 0);
            AddColumn(dataGrid, 0, "MacPort",             true, false, 0, 0);
            AddColumn(dataGrid, 0, "MacConnPWD",          true, false, 0, 0);
            AddColumn(dataGrid, 0, "IsGPRS",              true, false, 1, 60);

            AddColumn(dataGrid, 0, "Managers",            false, false, 1, 0);
            AddColumn(dataGrid, 0, "Volume",              false, false, 1, 0);
            AddColumn(dataGrid, 0, "ShowResultTime",      false, false, 1, 0);
            AddColumn(dataGrid, 0, "GlogWarning",         false, false, 1, 0);
            AddColumn(dataGrid, 0, "ReverifyTime",        false, false, 1, 0);
            AddColumn(dataGrid, 0, "ScreensaversTime",    false, false, 1, 0);
            AddColumn(dataGrid, 0, "SleepTime",           false, false, 1, 0);

            AddColumn(dataGrid, 0, "MutiUser",            false, false, 1, 0);
            AddColumn(dataGrid, 0, "OpenDoorDelay",       false, false, 1, 0);
            AddColumn(dataGrid, 0, "DoorMagneticType",    false, false, 1, 0);
            AddColumn(dataGrid, 0, "DoorMagneticDelay",   false, false, 1, 0);
            AddColumn(dataGrid, 0, "UseAlarm",            false, false, 1, 0);
            AddColumn(dataGrid, 0, "AlarmDelay",          false, false, 1, 0);
            AddColumn(dataGrid, 0, "WiegandType",         false, false, 1, 0);
            AddColumn(dataGrid, 0, "WiegandOutput",       false, false, 1, 0);
            AddColumn(dataGrid, 0, "WiegandInput",        false, false, 1, 0);
            base.InitForm();
            
            msgGrid.BackgroundColor = dataGrid.BackgroundColor;
            msgGrid.DefaultCellStyle.SelectionForeColor = dataGrid.DefaultCellStyle.SelectionForeColor;
            Toolbar.BackColor = dataGrid.BackgroundColor;
            dtReal.Rows.Clear();
            dtReal.Columns.Add("SelectCheck",     typeof(bool));
            dtReal.Columns.Add("MacSN",           typeof(string));
            dtReal.Columns.Add("MacDesc",         typeof(string));
            dtReal.Columns.Add("MacTypeID",       typeof(string));
            dtReal.Columns.Add("MacTypeName",     typeof(string));
            dtReal.Columns.Add("MacConnType",     typeof(string));
            dtReal.Columns.Add("MacIP",           typeof(string));
            dtReal.Columns.Add("MacPort",         typeof(string));
            dtReal.Columns.Add("MacConnPWD",      typeof(string));
            dtReal.Columns.Add("IsGPRS",          typeof(bool));


            dtReal.Columns.Add("Managers",        typeof(string));
            dtReal.Columns.Add("Volume",          typeof(string));
            dtReal.Columns.Add("ShowResultTime",  typeof(string));
            dtReal.Columns.Add("GlogWarning",     typeof(string));
            dtReal.Columns.Add("ReverifyTime",    typeof(string));
            dtReal.Columns.Add("ScreensaversTime", typeof(string));
            dtReal.Columns.Add("SleepTime",       typeof(string));

            dtReal.Columns.Add("MutiUser",       typeof(string));
            dtReal.Columns.Add("OpenDoorDelay",     typeof(string));
            dtReal.Columns.Add("DoorMagneticType",  typeof(string));
            dtReal.Columns.Add("DoorMagneticDelay", typeof(string));
            dtReal.Columns.Add("UseAlarm",          typeof(string));
            dtReal.Columns.Add("AlarmDelay",        typeof(string));
            dtReal.Columns.Add("WiegandType",       typeof(string));
            dtReal.Columns.Add("WiegandOutput",     typeof(string));
            dtReal.Columns.Add("WiegandInput",      typeof(string));
           
            Column1.Width = msgGrid.Width - 20;
            RefresButton();
            Application.DoEvents();
        }
        public frmMJMacParam()
        {
            InitializeComponent();    
        }

        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            SelectData(e.CheckedState);
        }

        protected void SelectData(bool State)
        {
            if (dataGrid.DataSource != null)
            { 
                for (int i = 0; i < dtReal.Rows.Count; i++)
                {
                    dtReal.Rows[i].BeginEdit();
                    dtReal.Rows[i]["SelectCheck"] = State;
                    dtReal.Rows[i].EndEdit();
                }
            }
        }
        private void frmPubMacParam_Load(object sender, EventArgs e)
        {
            dtReal.Rows.Clear();
            DataTableReader dra = null;
            DataTableReader dr = null;
            string DoorMagnetic_Type = "";
            string Anti_back = "";
          
            string Use_Alarm = "";
            string Wiegand_Output = "";
            string Wiegand_Input = "";
            string GlogWarning = "";
            string DoorMagneticDelay = "";
            string AlarmDelay = "";
            string DiMacNo = "";
            string OpenDoorDelay = "";
            string Managers = "";
            string Volume = "";

            string MutiUser = "";
            string ShowResultTime = "";
            string ReverifyTime = "";
            string ScreensaversTime = "";
            string SleepTime = "";
            string WiegandType = "";
            string DoorMagneticType = "";
            string Antiback = "";
            string UseAlarm = "";
            string WiegandInput = "";
            string WiegandOutput = "";
           
            string MacDesc = "";
            string MacTypeID = "";
            string MacTypeName = "";
            string MacConnType = "";
            string MacIP = "";
            string MacPort = "";
            string MacConnPWD = "";
            bool IsGPRS = false;
            string DoorMagnetic_TypeAll = Pub.GetResText(formCode, "no", "");//门磁类型"no","close","open"
            string Anti_backAll = Pub.GetResText(formCode, "no", "");//防潜回"no","yes"
            string Use_AlarmAll = Pub.GetResText(formCode, "yes", "");//防拆报警"no","yes"
            string ServerRequestAll = Pub.GetResText(formCode, "no", ""); //是否传送
            string Wiegand_OutputAll = Pub.GetResText(formCode, "CardNo", ""); //韦根输出
            string Wiegand_InputAll = Pub.GetResText(formCode, "CardNo", ""); //韦根输入
            string MacSN = "";
            dra = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "0" }));
            while (dra.Read())
            {
                if (!Convert.IsDBNull(dra["MacSN"]))
                    MacSN = dra["MacSN"].ToString();
                if (!Convert.IsDBNull(dra["MacDesc"]))
                    MacDesc = dra["MacDesc"].ToString();
                if (!Convert.IsDBNull(dra["MacTypeID"]))
                    MacTypeID = dra["MacTypeID"].ToString();
                if (!Convert.IsDBNull(dra["MacTypeName"]))
                    MacTypeName = dra["MacTypeName"].ToString();
                if (!Convert.IsDBNull(dra["MacConnType"]))
                    MacConnType = dra["MacConnType"].ToString();
                if (!Convert.IsDBNull(dra["MacIP"]))
                    MacIP = dra["MacIP"].ToString();
                if (!Convert.IsDBNull(dra["MacPort"]))
                    MacPort = dra["MacPort"].ToString();
                if (!Convert.IsDBNull(dra["MacConnPWD"]))
                    MacConnPWD = dra["MacConnPWD"].ToString();
                if (!Convert.IsDBNull(dra["IsGPRS"]))
                    IsGPRS = Convert.ToBoolean(dra["IsGPRS"]) ;
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN }));
                if (dr.Read())
                {
                    GlogWarning = dr["GlogWarning"].ToString();
                    DoorMagneticDelay = dr["DoorMagneticDelay"].ToString();
                    AlarmDelay = dr["AlarmDelay"].ToString();
                    DiMacNo = dr["DiMacNo"].ToString();
                    OpenDoorDelay = dr["OpenDoorDelay"].ToString();
                    Managers = dr["Managers"].ToString();
                    Volume = dr["Volume"].ToString();

                    MutiUser = dr["MutiUser"].ToString();
                    ShowResultTime = dr["ShowResultTime"].ToString();
                    ReverifyTime = dr["ReverifyTime"].ToString();
                    ScreensaversTime = dr["ScreensaversTime"].ToString();
                    SleepTime = dr["SleepTime"].ToString();
                    WiegandType = dr["WiegandType"].ToString();

                    Wiegand_Output = dr["WiegandOutput"].ToString();
                    Wiegand_Input = dr["WiegandInput"].ToString();
                    DoorMagnetic_Type = dr["DoorMagneticType"].ToString();
                    if (DoorMagnetic_Type == "no")
                    {
                        DoorMagneticType = DoorMagnetic_TypeAll;
                    }
                    else if (DoorMagnetic_Type == "close")
                    {
                        DoorMagneticType = Pub.GetResText(formCode, "close", "");
                    }
                    else
                    {
                        DoorMagneticType = Pub.GetResText(formCode, "open", "");
                    }
                    Anti_back = dr["Antiback"].ToString();
                    if (Anti_back == "no")
                    {
                        Antiback = Anti_backAll;
                    }
                    else
                    {
                        Antiback = Pub.GetResText(formCode, "yes", "");
                    }

                    Use_Alarm = dr["UseAlarm"].ToString();
                    if (Use_Alarm == "yes")
                    {
                        UseAlarm = Use_AlarmAll;
                    }
                    else
                    {
                        UseAlarm = Pub.GetResText(formCode, "no", "");
                    }

                    if (Wiegand_Input == "1")
                    {
                        WiegandInput = Pub.GetResText(formCode, "CardNo", "");
                    }
                    else
                    {
                        WiegandInput = Pub.GetResText(formCode, "EmpNoParam", "");
                    }

                    if (Wiegand_Output == "1")
                    {
                        WiegandOutput = Pub.GetResText(formCode, "CardNo", "");
                    }
                    else
                    {
                        WiegandOutput = Pub.GetResText(formCode, "EmpNoParam", "");
                    }
                  
                    dtReal.Rows.Add(new object[] { false, MacSN, MacDesc, MacTypeID, MacTypeName, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS, Managers, Volume, ShowResultTime,
                    GlogWarning,ReverifyTime,ScreensaversTime,SleepTime/*,ServerIPAddress,ServerPort,ServerRequest*/,MutiUser,OpenDoorDelay,DoorMagneticType,
                    DoorMagneticDelay,UseAlarm,AlarmDelay,WiegandType,WiegandOutput,WiegandInput});
                    Application.DoEvents();
                }
            }
            dataGrid.DataSource = dtReal;
            lbTitlte.Text = Pub.GetResText("Main", "mnuMJMacParam", "");
            RefresButton();
            Application.DoEvents();
        }


        private TDIConnInfo RowDataToConnInfo(int RowIndex)
        {
            int MacSN = 0;
            string MacSN_GRPS = "";
            bool IsGPRS = Pub.ValueToBool(dataGrid[9, RowIndex].Value);
            if (IsGPRS)
                MacSN_GRPS = dataGrid[1, RowIndex].Value.ToString();
            else
            {
                MacSN = Convert.ToInt32(dataGrid[1, RowIndex].Value.ToString());
                MacSN_GRPS = MacSN.ToString();
            }
            string MacConnType = dataGrid[5, RowIndex].Value.ToString();
            string MacIP = dataGrid[6, RowIndex].Value.ToString();
            string MacPort = dataGrid[7, RowIndex].Value.ToString();
            string MacConnPWD = dataGrid[8, RowIndex].Value.ToString();
            string SeaSeriesPwd = dataGrid[8, RowIndex].Value.ToString();
            return Pub.ValueToDIConnInfo(MacSN, MacSN_GRPS, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS,1, SeaSeriesPwd,"");
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

        private bool InitAddList()
        {
            DataTableReader dr = null;
            AddList.Clear();
            string AddMacSN = "";
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "0" }));
            while (dr.Read())
            {
                AddMacSN = dr["MacSN"].ToString();
                AddList.Add(AddMacSN);
            }
            return AddList.Count > 0;
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

        private void RefresButton()
        {
            dataGrid.Enabled = !IsWorking;
            ItemAdd.Enabled = !IsWorking ;
            ItemEdit.Enabled = !IsWorking && (dtReal.Rows.Count > 0);
            ItemDelete.Enabled = !IsWorking && (dtReal.Rows.Count > 0);
            ItemTAG1.Enabled = !IsWorking && (dtReal.Rows.Count > 0);
            ItemTAG2.Enabled = !IsWorking && (dtReal.Rows.Count > 0);
            ItemMomAdd.Enabled = !IsWorking;
            ItemMomEdit.Enabled = !IsWorking && (dtReal.Rows.Count > 0);
            ItemRefresh.Enabled = !IsWorking;
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
            }
            return ret;
        }

        private bool UploadParam(int MacSN)
        {
            bool ret = false;
            bool reta = false;
            JObject vjobjparam = new JObject();
            string vstrJsonStr = "";
            DataTableReader dr = null;
            JObject vjobj = new JObject();
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN.ToString() }));
                if (dr.Read())
                {
                    vjobj.Add("cmd", "lock_control_set");
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
                    vjobjparam.Add("Use_Alarm", dr["UseAlarm"].ToString());                     //防拆报警"no","yes"
                    vjobj.Add("param", vjobjparam);
                    vstrJsonStr = vjobj.ToString();
                    ret = DeviceObject.objFK623.SetDeviceInfo(2, Convert.ToInt32(MacSN.ToString()));
                    reta = DeviceObject.objFK623.ExecJsonCmd(ref vstrJsonStr);
                    vstrJsonStr = "";
                    if (ret && !reta)
                    {
                        string msg = Pub.GetResText("", "ErrorMacParam", "");
                        Pub.MessageBoxShow(msg, MessageBoxIcon.Warning);
                        return reta;
                    }
                }
                else
                {
                    ret = false;
                    reta = false;
                }

            }
            catch (Exception E)
            {
                reta = false;
                ret = false;

                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return reta;
        }
        private bool DownloadParam(int MacSN)
        {
            bool ret = false;
            bool reta = false;
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
            StringBuilder vstrJsonStr = new StringBuilder(500);

            try
            {
                JObject vjobj = new JObject();
                vjobj.Add("cmd", "lock_control_get");
                vstrJsonStr.Append(vjobj.ToString());
                ret = DeviceObject.objFK623.GetDeviceInfo(2, ref DiMacNo);
                reta = DeviceObject.objFK623.ExecJsonCmd(ref vstrJsonStr);
                if (ret && !reta)
                {
                    string msg = Pub.GetResText("", "ErrorMacParam", "");
                    Pub.MessageBoxShow(msg,MessageBoxIcon.Warning);
                    return reta;
                }
                
                if (vstrJsonStr != null)
                {
                    vstrJsonStr = vstrJsonStr.Replace("\"", "").Replace("{", "").Replace("}", "").Replace("\n", "");
                    param = vstrJsonStr.ToString().Split(',');
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

                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN.ToString() }));
                    if (dr.Read())
                    {
                        sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "203", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                        "",Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,MacSN.ToString(),OpenDoor_Delay,
                        Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                        Wiegand_Type,"","".ToString(),Wiegand_Output,Wiegand_Input});
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "202", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                        "",Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,MacSN.ToString(),OpenDoor_Delay,
                        Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                        Wiegand_Type,"","".ToString(),Wiegand_Output,Wiegand_Input});
                    }

                    SystemInfo.db.ExecSQL(sql);
                }
            }
            catch (Exception E)
            {
                ret = false;
                reta = false;
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            vstrJsonStr = null;
            frmPubMacParam_Load(null, null);
            Application.DoEvents();
            return reta;
        }

        private void ItemAdd_Click(object sender, EventArgs e)
        {  
            frmMJMacParamAdd frm = new frmMJMacParamAdd("",this.Text, ItemAdd.Text);
            if(frm.ShowDialog()==DialogResult.OK) frmPubMacParam_Load(null, null);
        }

        private void ItemEdit_Click(object sender, EventArgs e)
        {
            int index =dataGrid.CurrentRow.Index;    //取得选中行的索引  
            string MacSN = dataGrid.Rows[index].Cells[1].Value.ToString();
            frmMJMacParamAdd frm = new frmMJMacParamAdd(MacSN, this.Text, ItemEdit.Text);
            if (frm.ShowDialog() == DialogResult.OK) frmPubMacParam_Load(null, null);
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
            List<string> sql = new List<string>();
            if (!InitMacList()) return;
            for(int i=0;i< connList.Count;i++)
            {
                sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "205", connList[i].MacSN.ToString() }));
            }
            try
            {
                SystemInfo.db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            SystemInfo.db.WriteSYLog(this.Text, ItemDelete.Text, sql);
            frmPubMacParam_Load(null, null);   
        }

        private void ItemTAG1_Click(object sender, EventArgs e)
        {
            ExecMacOprt(ItemTAG1.Text, 1);
        }

        private void ItemTAG2_Click(object sender, EventArgs e)
        {
            ExecMacOprt(ItemTAG2.Text, 0);
        }

        private void ItemRefresh_Click(object sender, EventArgs e)
        {
            frmPubMacParam_Load(null,null);
        }

        private void ItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void msgGrid_Resize(object sender, EventArgs e)
        {
            Column1.Width = msgGrid.Width - 20;
        }

        private void ItemMomEdit_Click(object sender, EventArgs e)
        {
            if (!InitMacList()) return;
            frmMJMacParamAdd frm = new frmMJMacParamAdd(connList, this.Text, ItemMomEdit.Text);
            if (frm.ShowDialog() == DialogResult.OK) frmPubMacParam_Load(null, null);
        }

        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Y <= 20) return;
            int index = dataGrid.CurrentRow.Index;    //取得选中行的索引  
            string MacSN = dataGrid.Rows[index].Cells[1].Value.ToString();
            frmMJMacParamAdd frm = new frmMJMacParamAdd(MacSN, this.Text, ItemEdit.Text);
            if (frm.ShowDialog() == DialogResult.OK) frmPubMacParam_Load(null, null);
        }

        private void ItemMomAdd_Click(object sender, EventArgs e)
        {
            if (!InitAddList()) return;
            frmMJMacParamAdd frm = new frmMJMacParamAdd(AddList, this.Text, ItemAdd.Text);
            if (frm.ShowDialog() == DialogResult.OK) frmPubMacParam_Load(null, null);
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
            if(dataGrid.Rows.Count<=0)
            {
                return;
            }
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
    }
}
