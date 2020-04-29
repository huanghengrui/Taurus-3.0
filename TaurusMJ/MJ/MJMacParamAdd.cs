using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmMJMacParamAdd : frmBaseDialog
    {
        public string DoorMagnetic_TypeAll = "";
        public string Anti_backAll = "";
        public string ServerRequestAll = "";
        public string Use_AlarmAll = "";
        public string Wiegand_OutputAll = "";
        public string Wiegand_InputAll = "";
        private string MacSN = "";
        private List<TDIConnInfo> ConnList = new List<TDIConnInfo>();
        private List<string> AddList = new List<string>();
        protected override void InitForm()
        {
            formCode = "PubDevSet";
            DataTableReader dr = null;
            SetcomboboxNumber(cbbGlogWarning);
            SetcomboboxNumber(cbbDoorMagneticDelay);
           
            SetcomboboxNumber(cbbOpenDoorDelay);
            SetcomboboxNumber(cbbManagers);
            SetcomboboxNumber(cbbVolume);
            SetcomboboxNumber(cbbMutiUser);
            SetcomboboxNumber(cbbShowResultTime);
            SetcomboboxNumber(cbbReverifyTime);
            SetcomboboxNumber(cbbScreensaversTime);
            SetcomboboxNumber(cbbSleepTime);
            SetcomboboxNumber(cbbWiegandType);

          
            base.InitForm();
           
            this.Text = CurrentOprt;

            DoorMagnetic_TypeAll = Pub.GetResText(formCode, "no", "");//门磁类型"no","close","open"
            Anti_backAll = Pub.GetResText(formCode, "no", "");//防潜回"no","yes"
            Use_AlarmAll = Pub.GetResText(formCode, "yes", "");//防拆报警"no","yes"
            ServerRequestAll = Pub.GetResText(formCode, "no", ""); //是否传送
            Wiegand_OutputAll = Pub.GetResText(formCode, "CardNo", ""); //韦根输出
            Wiegand_InputAll = Pub.GetResText(formCode, "CardNo", ""); //韦根输入
         
            cbbWiegandType.Items.Add(26);
            cbbWiegandType.Items.Add(34);

            cbbDoorMagneticType.Items.Add(Pub.GetResText(formCode, "no", ""));
            cbbDoorMagneticType.Items.Add(Pub.GetResText(formCode, "close", ""));
            cbbDoorMagneticType.Items.Add(Pub.GetResText(formCode, "open", ""));
            cbbAntiback.Items.Add(Pub.GetResText(formCode, "no", ""));
            cbbAntiback.Items.Add(Pub.GetResText(formCode, "yes", ""));
            cbbUseAlarm.Items.Add(Pub.GetResText(formCode, "no", ""));
            cbbUseAlarm.Items.Add(Pub.GetResText(formCode, "yes", ""));
          
            cbbWiegandOutput.Items.Add(Wiegand_OutputAll);
            cbbWiegandInput.Items.Add(Wiegand_InputAll);
            cbbWiegandOutput.Items.Add(Pub.GetResText(formCode, "EmpNoParam", ""));
            cbbWiegandInput.Items.Add(Pub.GetResText(formCode, "EmpNoParam", ""));

            dr=SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "8" }));
            while(dr.Read())
            {
                cbbMacSN.Items.Add(dr["MacSN"].ToString());
            }
           this.Text = Title + "[" + CurrentOprt + "]";
            Application.DoEvents();
            InitParam();
        }


        public frmMJMacParamAdd(string Mac,string title, string currentOprt)
        {
            Title = title;
            CurrentOprt = currentOprt;
            MacSN = Mac;
            InitializeComponent();
            if (MacSN != "")
                cbbMacSN.Enabled = false;
        }
        public frmMJMacParamAdd(List<string> Mac, string title, string currentOprt)
        {
            Title = title;
            CurrentOprt = currentOprt;
            AddList.Clear();
            AddList= Mac;
            InitializeComponent();
            
            cbbMacSN.Enabled = false;
        }
        public frmMJMacParamAdd(List<TDIConnInfo> connList,string title, string currentOprt)
        {
            Title = title;
            CurrentOprt = currentOprt;
            ConnList = connList;
            InitializeComponent();
            cbbMacSN.Enabled = false;
        }
        public void DefaultControl()
        {
            cbbGlogWarning.Text = "0"; //考勤记录警告0-1000
            cbbDoorMagneticDelay.Text = "10";//门磁延时0-200
            cbbAlarmDelay.Text = "1";//报警延时0-255
           
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
        }

        private void InitParam()
        {
            DataTableReader dr = null;
            string DoorMagnetic_Type = "";
            string Anti_back = "";
            
            string Use_Alarm = "";
            string Wiegand_Output = "";
            string Wiegand_Input = "";
            if (MacSN == "")
            {
                if (cbbMacSN.Items.Count > 0)
                    cbbMacSN.SelectedIndex=0;//机器号1-255
                DefaultControl();
            }
            else
            {
                cbbMacSN.Text = MacSN;
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN }));
                if (dr.Read())
                {
                    cbbGlogWarning.Text = dr["GlogWarning"].ToString();
                    cbbDoorMagneticDelay.Text = dr["DoorMagneticDelay"].ToString();
                    cbbAlarmDelay.Text = dr["AlarmDelay"].ToString();

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

                    Application.DoEvents();
                }
            }
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string DoorMagnetic_Type = "";
            string Anti_back = "";
            string ServerRequest = "";
            string Use_Alarm = "";
            string Glog_Warning = "";
            string DoorMagnetic_Delay = "";
            string Alarm_Delay = "";
            
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

            List<string> sql = new List<string>();
            string msg = "";
            bool ret = true;
           
            string Err = "";
            Glog_Warning = cbbGlogWarning.Text.Trim();
            DoorMagnetic_Delay = cbbDoorMagneticDelay.Text.Trim();
            Alarm_Delay = cbbAlarmDelay.Text.Trim();
            string DiMacNo = cbbMacSN.Text.Trim();
           
            OpenDoor_Delay = cbbOpenDoorDelay.Text.Trim();
            Managers = cbbManagers.Text.Trim();
            Volume = cbbVolume.Text.Trim();
            MutiUser = cbbMutiUser.Text.Trim();

            Show_ResultTime = cbbShowResultTime.Text.Trim();
            Reverify_Time = cbbReverifyTime.Text.Trim();
            Screensavers_Time = cbbScreensaversTime.Text.Trim();
            Sleep_Time = cbbSleepTime.Text.Trim();
            Wiegand_Type = cbbWiegandType.Text.Trim();
           
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
            if (int.Parse(DiMacNo) > 255 || int.Parse(DiMacNo) < 0)
            {
                Err = string.Format(Pub.GetResText(formCode, "Error", ""), label9.Text, 0, 255);
                Pub.MessageBoxShow(Err);
                cbbMacSN.Focus();
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

            DataTableReader dr = null;
            if (AddList.Count > 0)
            {
                for (int i = 0; i < AddList.Count; i++)
                {
                    MacSN = AddList[i].ToString();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN }));
                    if (dr.Read())
                    {
                        continue;
                    }
                    else
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "202", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                      ServerRequest,Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,MacSN,OpenDoor_Delay,
                      Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                      Wiegand_Type,ServerIPAddress,ServerPort,Wiegand_Output,Wiegand_Input}));
                    }
                }

            }
            else if (ConnList.Count > 0)
            {
                for (int i = 0; i < ConnList.Count; i++)
                {
                    MacSN = ConnList[i].MacSN.ToString();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN }));
                    if (dr.Read())
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "203", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                      ServerRequest,Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,MacSN,OpenDoor_Delay,
                      Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                      Wiegand_Type,ServerIPAddress,ServerPort,Wiegand_Output,Wiegand_Input}));
                    }
                    else
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "202", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                      ServerRequest,Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,MacSN,OpenDoor_Delay,
                      Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                      Wiegand_Type,ServerIPAddress,ServerPort,Wiegand_Output,Wiegand_Input}));
                    }
                }

            }
            else if (MacSN == "")
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", DiMacNo }));
                if (dr.Read())
                {
                    msg = string.Format( Pub.GetResText("", "ErrorCannotRepeated",""), label9.Text);
                    Pub.MessageBoxShow(msg,MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "202", DiMacNo, DoorMagnetic_Type, Anti_back,
                      ServerRequest,Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,DiMacNo,OpenDoor_Delay,
                      Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                      Wiegand_Type,ServerIPAddress,ServerPort,Wiegand_Output,Wiegand_Input}));
                }
            }
            else
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", MacSN }));
                if (dr.Read())
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "203", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                      ServerRequest,Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,DiMacNo,OpenDoor_Delay,
                      Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                      Wiegand_Type,ServerIPAddress,ServerPort,Wiegand_Output,Wiegand_Input}));
                }
                else
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "202", MacSN.ToString(), DoorMagnetic_Type, Anti_back,
                      ServerRequest,Use_Alarm,Glog_Warning,DoorMagnetic_Delay,Alarm_Delay,DiMacNo,OpenDoor_Delay,
                      Managers,Volume,MutiUser,Show_ResultTime,Reverify_Time,Screensavers_Time,Sleep_Time,
                      Wiegand_Type,ServerIPAddress,ServerPort,Wiegand_Output,Wiegand_Input}));
                }
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
            Pub.MessageBoxShow(msg);
            SystemInfo.db.WriteSYLog(Title,CurrentOprt, msg);
            Application.DoEvents();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
