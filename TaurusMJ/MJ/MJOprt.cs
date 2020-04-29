using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;

namespace Taurus
{
    public partial class frmMJOprt : frmBaseDialog
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
            AddColumn(0, "MacSeriesTypeName", true, false, 0);
            AddColumn(0, "MacTypeID", true, false, 0);
            AddColumn(0, "MacTypeName", true, false, 0);
            AddColumn(0, "MacConnType", false, false, 0);
            AddColumn(0, "MacIP", false, false, 0);
            AddColumn(0, "MacPort", false, false, 0);
            AddColumn(0, "MacConnPWD", true, false, 0);
            AddColumn(1, "IsGPRS", false, false, 1, 60);
            
            base.InitForm();
            msgGrid.BackgroundColor = dataGrid.BackgroundColor;
            msgGrid.DefaultCellStyle.SelectionForeColor = dataGrid.DefaultCellStyle.SelectionForeColor;
            this.Text = title;
            btnOprt.Text = oprt;
            toolTip.SetToolTip(btnOprt, btnOprt.Text);
            string QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "8" });
            try
            {
                bindingSource.DataSource = SystemInfo.db.GetDataTable(QuerySQL);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, QuerySQL);
            }
            toolTip.SetToolTip(txtQuickSearchMac, string.Format(Pub.GetResText(formCode, "MsgFindMacSN", ""),
            Pub.GetResText(formCode, "MacSN", ""),
            Pub.GetResText(formCode, "MacDesc", "")));
            RefresButton();
            msgGrid_Resize(null, null);
        }

        public frmMJOprt(string Title, string Oprt, int Flag, List<string> guid)
        {
            title = Title;
            oprt = Oprt;
            flag = Flag;
            GUID = guid;
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
            btnOprt.Enabled = !IsWorking && (bindingSource.Count > 0);
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
            Int32.TryParse(dataGrid[3, RowIndex].Value.ToString(), out MacSeriesTypeId);
            string SeaSeriesPwd = dataGrid[10, RowIndex].Value.ToString();
            return Pub.ValueToDIConnInfo(MacSN, MacSN_GRPS, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS, MacSeriesTypeId, SeaSeriesPwd,"");
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
            TDIConnInfo conn;
            for (int i = 0; i < connList.Count; i++)
            {
                conn = connList[i];
                RefreshMsg(oprt + "[" + conn.MacSN_GPRS.ToString() + "]......",i);
                RefreshMacMsg(oprt + "[" + conn.MacSN_GPRS.ToString() + "]......");
                DeviceObject.objFK623.InitConn(conn);
                if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
                DeviceObject.objFK623.EnableDevice(0);
                state = DeviceObject.objFK623.IsOpen;
                if (state) state = ExecMacCommand(conn.MacSN_GPRS, ref MacMsg);
                ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                UpdateMacMsg(MacMsg + DeviceObject.objFK623.ErrMsg + ExecTimes, state);
                msg = msg + conn.MacSN_GPRS.ToString() + ":" + MacMsg + DeviceObject.objFK623.ErrMsg + ";";
                DeviceObject.objFK623.EnableDevice(1);
                DeviceObject.objFK623.Close();
                Application.DoEvents();
                start = DateTime.Now;
                if (!IsWorking) break;
            }
            SystemInfo.db.WriteSYLog(this.Text, oprt, msg);
            IsWorking = false;
            RefresButton();
            RefreshMsg("",0);
        }

        private bool ExecMacCommand(string MacSN, ref string MacMsg)
        {
            bool ret = false;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://下载时间段信息
                    ret = MJTimeDownload(MacSN, ref MacMsg);
                    break;
                case 1://上传时间段信息
                    ret = MJTimeUpload(MacSN, ref MacMsg);
                    break;
                case 10://下载打铃信息
                    ret = MJBellTimeDownload(MacSN, ref MacMsg);
                    break;
                case 11://上传打铃信息
                    ret = MJBellTimeUpload(MacSN, ref MacMsg);
                    break;
                case 20://下载权限信息
                    ret = MJPowerDownload(MacSN, ref MacMsg);
                    break;
                case 21://上传权限信息
                    ret = MJPowerUpload(MacSN, ref MacMsg);
                    break;
            }
            return ret;
        }

        private bool MJTimeDownload(string MacSN, ref string MacMsg)
        {
            bool ret = true;
            List<TimeZone> tzList = new List<TimeZone>();
            byte[] byt = new byte[(int)FKMax.SIZE_TIME_ZONE_STRUCT];
            TimeZone tz;
            for (int i = 0; i < (int)FKMax.TIME_ZONE_COUNT; i++)
            {
                tz = new TimeZone();
                tz.Init();
                tz.TimeZoneID = i + 1;
                DeviceObject.objFK623.StructToByteArray(tz, byt);
                ret = DeviceObject.objFK623.HS_GetTimeZone(byt);
                if (!ret) break;
                tz = (TimeZone)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(TimeZone));
                tzList.Add(tz);
            }
            if (ret && tzList.Count > 0)
            {
                string sql = "";
                DataTableReader dr = null;
                string ID = "";
                string Name = "";
                string[] TS = new string[(int)FKMax.TIME_SLOT_COUNT];
                string[] TE = new string[(int)FKMax.TIME_SLOT_COUNT];
                try
                {
                    for (int i = 0; i < tzList.Count; i++)
                    {
                        tz = tzList[i];
                        ID = tz.TimeZoneID.ToString();
                        for (int j = 0; j < (int)FKMax.TIME_SLOT_COUNT; j++)
                        {
                            TS[j] = string.Format("{0:d2}:{1:d2}", tz.TimeSlots[j].StartHour, tz.TimeSlots[j].StartMinute);
                            TE[j] = string.Format("{0:d2}:{1:d2}", tz.TimeSlots[j].EndHour, tz.TimeSlots[j].EndMinute);
                        }
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "403", ID }));
                        if (dr.Read())
                            sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "405", ID, Name, TS[0], TE[0], TS[1], TE[1],
                TS[2], TE[2], TS[3], TE[3], TS[4], TE[4], TS[5], TE[5], OprtInfo.OprtNo });
                        else
                            sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "404", ID, Name, TS[0], TE[0], TS[1], TE[1],
                TS[2], TE[2], TS[3], TE[3], TS[4], TE[4], TS[5], TE[5], OprtInfo.OprtNo });
                        dr.Close();
                        SystemInfo.db.ExecSQL(sql);
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
            }
            return ret;
        }

        private bool MJTimeUpload(string MacSN, ref string MacMsg)
        {
            bool ret = true;
            byte[] byt = new byte[(int)FKMax.SIZE_TIME_ZONE_STRUCT];
            TimeZone tz;
            int a = 0;
            if (timeList.Count > 0)
            {
                for (int i = 0; i < timeList.Count; i++)
                {
                    for (int j = 0; j < GUID.Count; j++)
                    {
                        a = i + 1;
                        if (GUID[j].Equals(a.ToString()))
                        {
                            tz = timeList[i];
                            DeviceObject.objFK623.StructToByteArray(tz, byt);
                            ret = DeviceObject.objFK623.HS_SetTimeZone(byt);
                            if (!ret) break;
                        }
                    }
                }
            }
            return ret;
        }

        private bool MJBellTimeDownload(string MacSN, ref string MacMsg)
        {
            int BellCount = 0;
            byte[] BellTime = new byte[Marshal.SizeOf(typeof(BellInfo))];
            bool ret = DeviceObject.objFK623.GetBellTime(ref BellCount, ref BellTime[0]);
            if (ret)
            {
                object obj = DeviceObject.objFK623.ByteArrayToStruct(BellTime, typeof(BellInfo));
                if (obj == null) ret = false;
                if (ret)
                {
                    BellInfo bi = new BellInfo();
                    bi.Init();
                    bi = (BellInfo)obj;
                    string Src = "";
                    for (int i = 0; i < (int)FKMax.MAX_BELLCOUNT_DAY; i++)
                    {
                        Src += bi.mValid[i].ToString() + "@" + string.Format("{0:d2}:{1:d2}", bi.mHour[i], bi.mMinute[i]) + "@";
                    }
                    Src = Src + BellCount.ToString();
                    ret = SystemInfo.db.WriteConfig("MJFunc", "BellTime", Src);
                }
            }
            return ret;
        }

        private bool MJBellTimeUpload(string MacSN, ref string MacMsg)
        {
            bool ret = true;
            string Src = SystemInfo.db.ReadConfig("MJFunc", "BellTime");
            MJBellTime bt = new MJBellTime(Src);
            if (bt.Exists) ret = DeviceObject.objFK623.SetBellTime(bt.BellCount, ref bt.BellTime[0]);
            return ret;
        }

        private bool MJPowerDownload(string MacSN, ref string MacMsg)
        {
            bool ret = true;
            int Count = 0;
            List<ExtCmd_USERDOORINFO> uiList = new List<ExtCmd_USERDOORINFO>();
            byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
            ExtCmd_USERDOORINFO ui = new ExtCmd_USERDOORINFO();
            for (int i = 0; i < fingerNoList.Count; i++)
            {
                ui.Init(false, fingerNoList[i]);
                DeviceObject.objFK623.StructToByteArray(ui, byt);
                ret = DeviceObject.objFK623.ExtCommand(byt);
                if (!ret)
                {
                  
                    Count++;
                    if (Count == fingerNoList.Count)
                        return MJPowerDownload(MacSN, ref MacMsg, false);

                    continue;

                }

                ui = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));
                uiList.Add(ui);
            }
            if (uiList.Count > 0)
            {
                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                ret = true;
                string sql = "";
                DataTableReader dr = null;
                string SysID = MacSN.ToString();
                string EmpNo = "";
                string SunID = "";
                string MonID = "";
                string TueID = "";
                string WedID = "";
                string ThuID = "";
                string FriID = "";
                string SatID = "";
                string StartDate = "";
                string EndDate = "";
                DateTime dt;
                try
                {
                    for (int i = 0; i < uiList.Count; i++)
                    {
                        ui = uiList[i];
                        ret = SystemInfo.db.GetEmpNoByFingerNo(ui.UserID, ref EmpNo);
                        if (!ret) break;
                        SunID = ui.WeekPassTime[0].ToString();
                        MonID = ui.WeekPassTime[1].ToString();
                        TueID = ui.WeekPassTime[2].ToString();
                        WedID = ui.WeekPassTime[3].ToString();
                        ThuID = ui.WeekPassTime[4].ToString();
                        FriID = ui.WeekPassTime[5].ToString();
                        SatID = ui.WeekPassTime[6].ToString();
                        StartDate = "NULL";
                        dt = new DateTime();
                        try
                        {
                            dt = new DateTime(ui.StartYear, ui.StartMonth, ui.StartDay);
                            StartDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
                        }
                        catch
                        {
                        }
                        EndDate = "NULL";
                        try
                        {
                            dt = new DateTime(ui.EndYear, ui.EndMonth, ui.EndDay);
                            EndDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
                        }
                        catch
                        {
                        }
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "503", SysID, EmpNo }));
                        if (dr.Read())
                            sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "505", SysID, EmpNo, SunID, MonID, TueID, WedID, ThuID,
                FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
                        else
                            sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "504", SysID, EmpNo, SunID, MonID, TueID, WedID, ThuID,
                FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
                        dr.Close();
                        SystemInfo.db.ExecSQL(sql);
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
            }
            return ret;
        }

        #region 无有效期
        private bool MJPowerDownload(string MacSN, ref string MacMsg, bool SupportValidity)
        {
            bool ret = true;

            List<UserWeekPassTime> vUserPassTimeList = new List<UserWeekPassTime>();

            byte[] bytUserPassTime = new byte[(int)FKMax.SIZE_USER_WEEK_PASS_TIME_STRUCT];
            UserWeekPassTime vUserPassTime = new UserWeekPassTime();

            for (int i = 0; i < fingerNoList.Count; i++)
            {

                vUserPassTime.Init();
                vUserPassTime.UserID = fingerNoList[i];
                DeviceObject.objFK623.StructToByteArray(vUserPassTime, bytUserPassTime);
                ret = DeviceObject.objFK623.HS_GetUserWeekPassTime(bytUserPassTime);

                if (!ret)
                {
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_NON_CARRYOUT) continue;

                    if (vUserPassTimeList.Count > 0)
                    {
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                        ret = true;
                    }
                    break;
                }

                vUserPassTime = (UserWeekPassTime)DeviceObject.objFK623.ByteArrayToStruct(bytUserPassTime, typeof(UserWeekPassTime));
                vUserPassTimeList.Add(vUserPassTime);
            }
            if (vUserPassTimeList.Count > 0)
            {
                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                ret = true;
                string sql = "";
                DataTableReader dr = null;
                string SysID = MacSN.ToString();
                string EmpNo = "";
                string SunID = "";
                string MonID = "";
                string TueID = "";
                string WedID = "";
                string ThuID = "";
                string FriID = "";
                string SatID = "";
                string StartDate = "";
                string EndDate = "";
           
                try
                {
                    for (int i = 0; i < vUserPassTimeList.Count; i++)
                    {
                        vUserPassTime = vUserPassTimeList[i];
                        ret = SystemInfo.db.GetEmpNoByFingerNo(vUserPassTime.UserID, ref EmpNo);
                        if (!ret) break;
                        SunID = vUserPassTime.WeekPassTime[0].ToString();
                        MonID = vUserPassTime.WeekPassTime[1].ToString();
                        TueID = vUserPassTime.WeekPassTime[2].ToString();
                        WedID = vUserPassTime.WeekPassTime[3].ToString();
                        ThuID = vUserPassTime.WeekPassTime[4].ToString();
                        FriID = vUserPassTime.WeekPassTime[5].ToString();
                        SatID = vUserPassTime.WeekPassTime[6].ToString();
                        StartDate = "NULL";
                    
                        EndDate = "NULL";
                      
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "503", SysID, EmpNo }));
                        if (dr.Read())
                            sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "505", SysID, EmpNo, SunID, MonID, TueID, WedID, ThuID,
                FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
                        else
                            sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "504", SysID, EmpNo, SunID, MonID, TueID, WedID, ThuID,
                FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
                        dr.Close();
                        SystemInfo.db.ExecSQL(sql);
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
            }
            return ret;
        }
        #endregion

        private bool MJPowerUpload(string MacSN, ref string MacMsg)
        {
            bool ret = true;
            List<ExtCmd_USERDOORINFO> uiList = new List<ExtCmd_USERDOORINFO>();
            List<UserWeekPassTime> vUserPassTimeList = new List<UserWeekPassTime>();
            UserWeekPassTime vUserPassTime;
            ExtCmd_USERDOORINFO ui;
            DataTableReader dr = null;
            DateTime dt;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "500", MacSN.ToString() }));
                while (dr.Read())
                {
                    for (int i = 0; i < GUID.Count; i++)
                    {

                        if (GUID[i].Equals(dr["GUID"].ToString()))
                        {
                            ui = new ExtCmd_USERDOORINFO();
                            ui.Init(true, Convert.ToUInt32(dr["FingerNo"].ToString()));
                            ui.WeekPassTime[0] = Convert.ToByte(dr["SunID"].ToString());
                            ui.WeekPassTime[1] = Convert.ToByte(dr["MonID"].ToString());
                            ui.WeekPassTime[2] = Convert.ToByte(dr["TueID"].ToString());
                            ui.WeekPassTime[3] = Convert.ToByte(dr["WedID"].ToString());
                            ui.WeekPassTime[4] = Convert.ToByte(dr["ThuID"].ToString());
                            ui.WeekPassTime[5] = Convert.ToByte(dr["FriID"].ToString());
                            ui.WeekPassTime[6] = Convert.ToByte(dr["SatID"].ToString());
                            vUserPassTime = new UserWeekPassTime();
                            //无有效期
                            vUserPassTime.Init();
                            vUserPassTime.UserID = Convert.ToUInt32(dr["FingerNo"].ToString());
                            vUserPassTime.WeekPassTime[0] = Convert.ToByte(dr["SunID"].ToString());
                            vUserPassTime.WeekPassTime[1] = Convert.ToByte(dr["MonID"].ToString());
                            vUserPassTime.WeekPassTime[2] = Convert.ToByte(dr["TueID"].ToString());
                            vUserPassTime.WeekPassTime[3] = Convert.ToByte(dr["WedID"].ToString());
                            vUserPassTime.WeekPassTime[4] = Convert.ToByte(dr["ThuID"].ToString());
                            vUserPassTime.WeekPassTime[5] = Convert.ToByte(dr["FriID"].ToString());
                            vUserPassTime.WeekPassTime[6] = Convert.ToByte(dr["SatID"].ToString());

                            vUserPassTimeList.Add(vUserPassTime);
                            try
                            {
                                dt = Convert.ToDateTime(dr["StartDate"].ToString());
                                ui.StartYear = (short)dt.Year;
                                ui.StartMonth = (byte)dt.Month;
                                ui.StartDay = (byte)dt.Day;
                            }
                            catch
                            {
                            }
                            try
                            {
                                dt = Convert.ToDateTime(dr["EndDate"].ToString());
                                ui.EndYear = (short)dt.Year;
                                ui.EndMonth = (byte)dt.Month;
                                ui.EndDay = (byte)dt.Day;
                            }
                            catch
                            {
                            }
                            uiList.Add(ui);
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
                if (dr != null) dr.Close();
                dr = null;
            }
            if (ret && uiList.Count > 0)
            {
                byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
                byte[] bytUserPassTime = new byte[(int)FKMax.SIZE_USER_WEEK_PASS_TIME_STRUCT];
                for (int i = 0; i < uiList.Count; i++)
                {

                    ui = uiList[i];

                    if (ui.EndYear == 0 && ui.StartYear == 0)
                    {
                        DeviceObject.objFK623.StructToByteArray(vUserPassTimeList[i], bytUserPassTime);
                        ret = DeviceObject.objFK623.HS_SetUserWeekPassTime(bytUserPassTime);
                        continue;
                    }

                    if (ui.StartYear == 0)
                        ui.StartYear = 1900;


                    DeviceObject.objFK623.StructToByteArray(ui, byt);
                    ret = DeviceObject.objFK623.ExtCommand(byt);
                    if (!ret)
                    {
                        //break;
                        DeviceObject.objFK623.StructToByteArray(vUserPassTimeList[i], bytUserPassTime);
                        ret = DeviceObject.objFK623.HS_SetUserWeekPassTime(bytUserPassTime);
                    }
                }
            }
            return ret;
        }

        #region 无有效期
        private bool MJPowerUpload(int MacSN, ref string MacMsg, bool SupportValidity)
        {
            bool ret = true;

            List<UserWeekPassTime> vUserPassTimeList = new List<UserWeekPassTime>();
            UserWeekPassTime vUserPassTime;
            DataTableReader dr = null;

            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "500", MacSN.ToString() }));
                while (dr.Read())
                {
                    for (int i = 0; i < GUID.Count; i++)
                    {

                        if (GUID[i].Equals(dr["GUID"].ToString()))
                        {
                            vUserPassTime = new UserWeekPassTime();
                            vUserPassTime.Init();
                            vUserPassTime.UserID = Convert.ToUInt32(dr["FingerNo"].ToString());
                            vUserPassTime.WeekPassTime[0] = Convert.ToByte(dr["SunID"].ToString());
                            vUserPassTime.WeekPassTime[1] = Convert.ToByte(dr["MonID"].ToString());
                            vUserPassTime.WeekPassTime[2] = Convert.ToByte(dr["TueID"].ToString());
                            vUserPassTime.WeekPassTime[3] = Convert.ToByte(dr["WedID"].ToString());
                            vUserPassTime.WeekPassTime[4] = Convert.ToByte(dr["ThuID"].ToString());
                            vUserPassTime.WeekPassTime[5] = Convert.ToByte(dr["FriID"].ToString());
                            vUserPassTime.WeekPassTime[6] = Convert.ToByte(dr["SatID"].ToString());

                            vUserPassTimeList.Add(vUserPassTime);
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
                if (dr != null) dr.Close();
                dr = null;
            }
            if (ret && vUserPassTimeList.Count > 0)
            {
                byte[] bytUserPassTime = new byte[(int)FKMax.SIZE_USER_WEEK_PASS_TIME_STRUCT];
                for (int i = 0; i < vUserPassTimeList.Count; i++)
                {
                    vUserPassTime = vUserPassTimeList[i];
                    DeviceObject.objFK623.StructToByteArray(vUserPassTime, bytUserPassTime);
                    ret = DeviceObject.objFK623.HS_SetUserWeekPassTime(bytUserPassTime);
                    if (!ret) break;
                }
            }
            return ret;
        }
        #endregion

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