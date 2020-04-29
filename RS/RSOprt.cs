using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Taurus
{
    public partial class frmRSOprt : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        private int flag = 0;
        private List<TDIConnInfo> connList = new List<TDIConnInfo>();
        private List<TimeZone> timeList = new List<TimeZone>();
        private List<UInt32> fingerNoList = new List<UInt32>();
        private bool IsWorking = false;
        private string GUID = "";
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;

        private TDownSelectList[] selList = new TDownSelectList[0];
        private List<UInt32> cardList = new List<UInt32>();
        private List<TDownInfoList> downList = new List<TDownInfoList>();
        private List<TDimInfo> execList = new List<TDimInfo>();


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
            btnOprt.Text = oprt;
            toolTip.SetToolTip(btnOprt, btnOprt.Text);
            string QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "0" });
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

        public frmRSOprt(string Title, string Oprt, int Flag, string guid)
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
            int MacSeriesTypeId = 0;
            Int32.TryParse(dataGrid[3, RowIndex].Value.ToString(), out MacSeriesTypeId);
            bool IsGPRS = Pub.ValueToBool(dataGrid[11, RowIndex].Value);
            if (IsGPRS || MacSeriesTypeId==3)
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
            bool state = false;
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
                RefreshMsg(oprt + "[" + conn.MacSN_GPRS.ToString() + "]......",i);
                RefreshMacMsg(oprt + "[" + conn.MacSN_GPRS.ToString() + "]......");
                MacMsg = "";
                Application.DoEvents();
                switch(conn.MacSeriesTypeId)
                {
                    case 2:
                        if(SystemInfo.ShowSEA != 1)
                        {
                            MacMsg = string.Format(Pub.GetResText(formCode, "MsgUnModuleInfo", ""), Pub.GetResText(formCode, "SeaDev", ""));
                            break;
                        }

                        if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                        {
                            if (RegisterInfo.EndDate < DateTime.Now)
                            {
                                MacMsg = RegisterInfo.StateText;
                                break;
                            }
                        }
                        SystemInfo.MacSeriesTypeId = 2;
                        url = "http://" + conn.NetHost + "/";
                        string body = "";
                        string urlTestConnt = "http://" + conn.NetHost + "/action/GetSysParam";
                        bool ret = DeviceObject.objFK623.POST_GetResponse(urlTestConnt, conn.MacSeriesUserName, conn.SeaSeries_Pwd, ref body);

                        if (ret)
                        {
                            state = Sea_ExecMacCommand(conn.MacSN_GPRS, url, conn.MacSeriesUserName, conn.SeaSeries_Pwd, ref MacMsg);
                        }
                        else
                        {
                            state = false;
                        }
                        break;
                    case 3:
                        if (SystemInfo.ShowSTAR != 1)
                        {
                            MacMsg = string.Format(Pub.GetResText(formCode, "MsgUnModuleInfo", ""), Pub.GetResText(formCode, "StarDev", ""));
                            break;
                        }

                        if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                        {
                            if (RegisterInfo.EndDate < DateTime.Now)
                            {
                                MacMsg = RegisterInfo.StateText;
                                break;
                            }
                        }
                        SystemInfo.MacSeriesTypeId = 3;
                        string cmd = "GetDeviceInfo";
                        DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
                        StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));
                        if (DeviceObject.socKetClient.Open(conn.NetHost, conn.NetPort, conn.NetPassword))
                        {
                            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                            {
                                state = Star_ExecMacCommand(conn.MacSN_GPRS, ref MacMsg);
                            }
                        }
                        break;
                    default:
                        DeviceObject.objFK623.InitConn(conn);
                        if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
                        DeviceObject.objFK623.EnableDevice(0);
                        state = DeviceObject.objFK623.IsOpen;
                        if (state) state = ExecMacCommand(conn.MacSN_GPRS, ref MacMsg);
                        break;
                }
                switch (conn.MacSeriesTypeId)
                {
                    case 2:
                        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                        if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                        UpdateMacMsg(MacMsg + DeviceObject.objFK623.SeaBodyStr() + ExecTimes, state);
                        msg = msg + conn.MacSN_GPRS.ToString() + ":" + MacMsg + DeviceObject.objFK623.SeaBodyStr() + ";";
                        break;
                    case 3:
                        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                        if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                        UpdateMacMsg(MacMsg + DeviceObject.socKetClient.ErrMsg + ExecTimes, state);
                        msg = msg + conn.MacSN_GPRS + ":" + MacMsg + DeviceObject.socKetClient.ErrMsg + ";";
                        DeviceObject.socKetClient.Close();
                        break;
                    default:
                        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                        if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                        UpdateMacMsg(MacMsg + DeviceObject.objFK623.ErrMsg + ExecTimes, state);
                        msg = msg + conn.MacSN_GPRS.ToString() + ":" + MacMsg + DeviceObject.objFK623.ErrMsg + ";";
                        DeviceObject.objFK623.EnableDevice(1);
                        DeviceObject.objFK623.Close();
                        break;
                }
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
                case 0://下载
                    ret = DownloadInfo(ref MacMsg);
                    break;
                case 1://上传
                    ret = UploadInfo(MacSN, ref MacMsg);
                    break;
                case 10://远程注册
                    if(UploadInfo(MacSN, ref MacMsg))
                    {
                        ret = RemoteReg(MacSN, ref MacMsg);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
            }
            return ret;
        }

        private bool Star_ExecMacCommand(string MacSN, ref string MacMsg)
        {
            bool ret = false;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://下载
                    ret = Star_DownloadInfo(ref MacMsg);
                    break;
                case 1://上传
                    ret = Star_UploadInfo(MacSN, ref MacMsg);
                    break;
                case 10://远程注册
                    if(Star_UploadInfo(MacSN, ref MacMsg))
                    {
                        ret = Star_RemoteReg(MacSN, ref MacMsg);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
            }
            return ret;
        }

        private bool Sea_ExecMacCommand(string MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://下载
                    ret = SeaSeries_DownloadInfo(url, name, pwd, MacSN, ref MacMsg);
                    break;
                case 1://上传
                    ret = SeaSeries_UploadInfo(url, name, pwd, MacSN, ref MacMsg);
                    break;
                case 10://远程注册
                    MacMsg = Pub.GetResText("", "ErrorMacParam", "");
                    ret = false;
                    break;
            }
            return ret;
        }

        private bool UploadInfo(string MacSN, ref string MacMsg)
        {
            bool ret = false; 
            ExtCmd_USERDOORINFO uiOld;
            ExtCmd_USERDOORINFO uiNew;
            DateTime dt;
            byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];

            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int PasswordData = 0;
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            string getName = "";
            string EmpNo = "";
            DialogResult MessRet;
            bool SupportFlag = false;
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            int ExistsCount = 0;
            bool IsSupportPhoto = true;
            int ErrCode = 0;
            string CardNo = "";
            string pwd = "";
            byte[] buff = new byte[0];
            int cardCount = 0;
            int ExistsCardCount = 0;
            cardList.Clear();
            cardList.Add(0);
            string EmpNoList = "";
            bool IsExistDelete = SystemInfo.db.ReadConfig("SystemInfo", "IsExistDelete", true);
            bool IsUploadName = SystemInfo.db.ReadConfig("SystemInfo", "IsUploadName", true);
            bool IsReOpen = false;
            EmpNoList = GUID;
            if (flag==10)
            {
                string[] guid = EmpNoList.Split('@');
                EmpNoList = guid[3];
            }
            DataTable dtUploadcount = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "604", EmpNoList }));
            DataTable dtUpload = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "207", EmpNoList }));
            if (dtUpload == null)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }
            progBar.ProgressType = eProgressItemType.Standard;
            try
            {
                for (int i = 0; i < dtUpload.Rows.Count; i++)
                {
                    EnrollNumber = Convert.ToUInt32(dtUpload.Rows[i]["FingerNo"].ToString());
                    BackupNumber = Convert.ToInt32(dtUpload.Rows[i]["FingerBkNo"].ToString());
                    if (BackupNumber == (int)FKBackup.BACKUP_PSW || BackupNumber == (int)FKBackup.BACKUP_CARD)
                    {
                        continue;
                    }
                    Privilege = Convert.ToInt32(dtUpload.Rows[i]["FingerPrivilege"].ToString());
                    EnrollName = dtUpload.Rows[i]["EmpName"].ToString();
                    progBar.Value = (i + 1) * 100 / dtUpload.Rows.Count;
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {3}/{4}  {0}[{1}: {2}]", EnrollName, EnrollNumber, BackupNumber,
                      i + 1, dtUpload.Rows.Count);
                    if (string.IsNullOrEmpty(dtUpload.Rows[i]["FingerData"].ToString()))
                        continue;
                    buff = (byte[])dtUpload.Rows[i]["FingerData"];
                    if (BackupNumber >= (int)FKBackup.BACKUP_FP_0 && BackupNumber <= (int)FKBackup.BACKUP_FP_9)
                    {
                        fpData = new byte[(int)FKMax.FK_FPDataSize];
                    }
                   
                    else if (BackupNumber == (int)FKBackup.BACKUP_FACE)
                    {
                        fpData = new byte[(int)FKMax.FK_FaceDataSize];
                    }
                    else if (BackupNumber == (int)FKBackup.BACKUP_VEIN_0)
                    {
                        fpData = new byte[(int)FKMax.FK_VeinDataSize];
                    }
                    else if (BackupNumber >= (int)FKBackup.BACKUP_PALMVEIN_0 && BackupNumber <= (int)FKBackup.BACKUP_PALMVEIN_3)
                    {
                        fpData = new byte[(int)FKMax.PALMVEINDataSize];
                    }
                    Array.Copy(buff, fpData, fpData.Length);
                EEE:
                    DeviceObject.objFK623.IsSupportedEnrollData(BackupNumber, ref SupportFlag);
                    if (SupportFlag)
                    {

                        if (IsExistDelete && flag != 10)
                        {

                            if (!GetDeteleCardSuccess(EnrollNumber))
                            {
                                if (DeviceObject.objFK623.GetUserName(EnrollNumber, ref getName))
                                {
                                    for (int xi = 0; xi < 16; xi++)
                                    {
                                        DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, xi);
                                    }

                                }
                                cardList.Add(EnrollNumber);
                            }
                        }

                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.PutEnrollData(EnrollNumber, BackupNumber,
                         Privilege, fpData, PasswordData);
                    }
                    else if (!IsReOpen)
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATADOUBLE)
                    {
                        if (IsExistDelete && flag != 10)
                        {
                            DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, BackupNumber);
                            goto EEE;
                        }
                        else
                        {
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            ExistsCount++;
                        }
                    }
                    if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                    {
                        if (GetUploadSuccess(EnrollNumber) || DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_INVALID_PARAM)
                        {
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            continue;
                        }
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_MEMORYOVER)
                        {
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            break;
                        }
                        IsReOpen = false;
                        ErrCode = DeviceObject.objFK623.RunCode;
                        if (ErrCode == (int)FKRun.RUNERR_UNKNOWNERROR) continue;
                        if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                        {
                            IsReOpen = true;
                            if (DeviceObject.objFK623.ReOpen()) goto EEE;
                            DeviceObject.objFK623.RunCode = ErrCode;
                        }
                        MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                          Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                        if (MessRet == DialogResult.Yes)
                            goto EEE;
                        else if (MessRet == DialogResult.Cancel)
                            break;
                        else
                            continue;
                    }
                    else
                    {
                        CountUpFp++;
                    }
                    Application.DoEvents();
                }
                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                {
                    if (dtUpload.Rows.Count > 0 && ExistsCount < dtUpload.Rows.Count)
                    {
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.SaveEnrollData();
                    }
                }
                cardCount = 0;
                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());
                    CardNo = dtUploadcount.Rows[i]["CardNo10"].ToString();
                    pwd = dtUploadcount.Rows[i]["pwd"].ToString();
                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    Privilege = Convert.ToInt32(dtUploadcount.Rows[i]["FingerPrivilege"].ToString());
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            if (string.IsNullOrEmpty(CardNo)) continue;
                            BackupNumber = 11;
                            buff = EncAndDec.getCard(CardNo);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(pwd)) break;
                            BackupNumber = 10;
                            buff = EncAndDec.getPWD(pwd);
                        }
                        cardCount++;
                        progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;
                        lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "EmpCardNo", "")+"、"+ Pub.GetResText(formCode, "EmpPWDNo", "") +
                          string.Format(" - {3}/{4}  {0}[{1}: {2}]", EnrollName, EnrollNumber, BackupNumber,
                          i + 1, dtUploadcount.Rows.Count);

                        fpData = new byte[(int)FKMax.FK_PasswordDataSize];
                        Array.Copy(buff, fpData, fpData.Length);
                    EEE:
                        DeviceObject.objFK623.IsSupportedEnrollData(BackupNumber, ref SupportFlag);
                        if (SupportFlag)
                        {

                            if (IsExistDelete)
                            {

                                if (!GetDeteleCardSuccess(EnrollNumber))
                                {
                                    if (DeviceObject.objFK623.GetUserName(EnrollNumber, ref getName))
                                    {
                                        for (int xi = 0; xi < 16; xi++)
                                        {
                                            DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, xi);
                                        }

                                    }
                                    cardList.Add(EnrollNumber);
                                }
                            }

                            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.PutEnrollData(EnrollNumber, BackupNumber,
                             Privilege, fpData, PasswordData);
                        }
                        else if (!IsReOpen)
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATADOUBLE)
                        {
                            if (IsExistDelete)
                            {
                                DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, BackupNumber);
                                goto EEE;
                            }
                            else
                            {
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                ExistsCardCount++;
                            }
                        }
                        if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                        {
                            if (GetUploadSuccess(EnrollNumber) || DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_INVALID_PARAM)
                            {
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                continue;
                            }
                            if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_MEMORYOVER)
                            {
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                break;
                            }
                            IsReOpen = false;
                            ErrCode = DeviceObject.objFK623.RunCode;
                            if (ErrCode == (int)FKRun.RUNERR_UNKNOWNERROR) continue;
                            if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                            {
                                IsReOpen = true;
                                if (DeviceObject.objFK623.ReOpen()) goto EEE;
                                DeviceObject.objFK623.RunCode = ErrCode;
                            }
                            MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                              Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                            if (MessRet == DialogResult.Yes)
                                goto EEE;
                            else if (MessRet == DialogResult.Cancel)
                                break;
                            else
                                continue;
                        }
                        else
                        {
                            CountUpFp++;
                        }
                        Application.DoEvents();
                    }

                }

                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                {
                    if (cardCount > 0 && ExistsCardCount < cardCount)
                    {
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.SaveEnrollData();
                    }
                    if (IsUploadName)
                    {
                        for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                        {
                            EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                            lblMsg.Text = StatusMsg + Pub.GetResText("", "MsgFingerName", "") + string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber,
                              i + 1, dtUploadcount.Rows.Count);
                            progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;
                            Application.DoEvents();
                            EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());
                        ContinueName:
                            if (!DeviceObject.objFK623.SetUserName(EnrollNumber,EnrollName, ref ErrCode))
                            {
                                if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                                {
                                    if (DeviceObject.objFK623.ReOpen()) goto ContinueName;
                                }
                                MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.GetRunMsg(ErrCode) + "\r\n\r\n" +
                                  Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNo);
                                if (MessRet == DialogResult.Yes)
                                    goto ContinueName;
                                else
                                    break;
                            }
                            CountUp++;
                            if (IsSupportPhoto)
                            {
                                DataTableReader drPhoto = null;
                                try
                                {
                                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                                    drPhoto = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "13",
                   EmpNo }));
                                    if (drPhoto.Read())
                                    {
                                        if (drPhoto["EmpPhotoImage"].ToString() != "")
                                        {
                                            byte[] buf = (byte[])(drPhoto["EmpPhotoImage"]);
                                            nPhotoSize = buf.Length;
                                            if (nPhotoSize > 0) DeviceObject.objFK623.SetEnrollPhoto(EnrollNumber, buf, nPhotoSize);
                                        }
                                    }
                                }
                                catch (Exception E)
                                {
                                    Pub.ShowErrorMsg(E);
                                }
                                finally
                                {
                                    if (drPhoto != null) drPhoto.Close();
                                    drPhoto = null;
                                }
                            }

                            uiOld = new ExtCmd_USERDOORINFO();
                            uiOld.Init(false, EnrollNumber);
                            DeviceObject.objFK623.StructToByteArray(uiOld, byt);
                            ret = DeviceObject.objFK623.ExtCommand(byt);
                            uiOld = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));

                            uiNew = new ExtCmd_USERDOORINFO();
                            uiNew.Init(true, EnrollNumber);
                            uiNew.WeekPassTime = uiOld.WeekPassTime;
                            try
                            {
                                dt = Convert.ToDateTime(dtUploadcount.Rows[i]["StartDate"].ToString());
                                uiNew.StartYear = (short)dt.Year;
                                uiNew.StartMonth = (byte)dt.Month;
                                uiNew.StartDay = (byte)dt.Day;
                            }
                            catch
                            {
                            }
                            try
                            {
                                dt = Convert.ToDateTime(dtUploadcount.Rows[i]["EndDate"].ToString());
                                uiNew.EndYear = (short)dt.Year;
                                uiNew.EndMonth = (byte)dt.Month;
                                uiNew.EndDay = (byte)dt.Day;
                            }
                            catch
                            {
                            }
                            if(uiNew.StartYear == 0&& uiNew.EndYear == 0)
                            {
                                continue;
                            }
                            if (uiNew.StartYear == 0)
                                uiNew.StartYear = 1900;

                        
                            DeviceObject.objFK623.StructToByteArray(uiNew, byt);
                            ret = DeviceObject.objFK623.ExtCommand(byt);
                        }
                    }
                    ret = true;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");

                MacMsg = string.Format(tmp, dtUploadcount.Rows.Count, CountUp, CountUpFp);
            }
            return ret;
        }
        private bool GetUploadSuccess(UInt32 EnrollNumber)
        {
            bool ret = false;
            for (int i = 0; i < selList.Length; i++)
            {
                if (selList[i].EnrollNumber == EnrollNumber)
                {
                    ret = selList[i].IsSuccess;
                    return ret;
                }
            }
            return ret;
        }
        private bool GetDeteleCardSuccess(UInt32 EnrollNumber)
        {
            bool ret = false;
            for (int i = 0; i < cardList.Count; i++)
            {
                if (cardList[i] == EnrollNumber)
                {
                    ret = true;
                    return ret;
                }
            }
            return ret;
        }

        private bool DownloadInfo(ref string MacMsg)
        {
            downList.Clear();
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int PasswordData = 0;
            byte[] fpData = new byte[(int)FKMax.FK_FaceDataSize];
            string EnrollName = "";
            DialogResult MessRet;
            string EmpNo = "";
            bool ReqName = false;
            int FingerCount = 0;
            int PSWCount = 0;
            int CardCount = 0;
            int FaceCount = 0;
            int PalVeinCnt = 0;
            int EmpCount = 0;
            int ErrCode = 0;
            execList.Clear();
            string StatusMsg = lblMsg.Text;
            progBar.ProgressType = eProgressItemType.Standard;
            ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_USERS, ref EmpCount);
            if (!ret) return false;
            ReOpen:
            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.ReadAllUserID();
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (!ret) return false;
            do
            {
            FFF:
                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetAllUserID(ref EnrollNumber, ref BackupNumber,
                  ref Privilege, ref EnableFlag);
                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                {
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    break;
                }
                if (FindExecInfo(EnrollNumber, BackupNumber)) goto FFF;
                EEE:
                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetEnrollData(EnrollNumber, BackupNumber,
                  ref Privilege, fpData, ref PasswordData);

                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                {
                    ErrCode = DeviceObject.objFK623.RunCode;
                    if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_READ_FAIL)
                    {
                        if (DeviceObject.objFK623.ReOpen()) goto ReOpen;
                        DeviceObject.objFK623.RunCode = ErrCode;
                    }
                    MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                      Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                    if (MessRet == DialogResult.Yes)
                        goto EEE;
                    else if (MessRet == DialogResult.Cancel)
                        break;
                    else
                        goto FFF;
                }
                CountFingerInfo(BackupNumber, ref FingerCount, ref PSWCount, ref CardCount, ref FaceCount, ref PalVeinCnt);
                SystemInfo.db.SaveEnrollToDB(EnrollNumber, BackupNumber, EnableFlag, Privilege, PasswordData,
                  fpData, "", ref ReqName);
                AddDownInfo(new TDownInfoList(EnrollNumber, ReqName));
                execList.Add(new TDimInfo(EnrollNumber, BackupNumber));
                lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                  string.Format(" - {2}/{3}  [{0}: {1}]", EnrollNumber, BackupNumber, downList.Count, EmpCount);
                if (EmpCount > 0)
                    progBar.Value = downList.Count * 100 / EmpCount;
                Application.DoEvents();
            }
            while (true);
            byte[] buff = new byte[0];
            byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
            ExtCmd_USERDOORINFO ui = new ExtCmd_USERDOORINFO();
            DateTime dt;
            string StartDate = "";
            string EndDate = "";
            bool retDate = false;
            StatusMsg = StatusMsg + Pub.GetResText(formCode, "MsgFingerName", "");
            for (int i = 0; i < downList.Count; i++)
            {
                EnrollNumber = downList[i].EnrollNumber;
                lblMsg.Text = StatusMsg + string.Format(" - {1}/{2}  [{0}]", EnrollNumber, i + 1, downList.Count);
                progBar.Value = (i + 1) * 100 / downList.Count;

                ui.Init(false, EnrollNumber);
                DeviceObject.objFK623.StructToByteArray(ui, byt);
                retDate = DeviceObject.objFK623.ExtCommand(byt);
                ui = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));

                StartDate = "";
                dt = new DateTime();
                try
                {
                    dt = new DateTime(ui.StartYear, ui.StartMonth, ui.StartDay);
                    StartDate = dt.ToString(SystemInfo.SQLDateFMT);
                }
                catch
                {
                }
                EndDate = "";
                try
                {
                    dt = new DateTime(ui.EndYear, ui.EndMonth, ui.EndDay);
                    EndDate =dt.ToString(SystemInfo.SQLDateFMT);
                }
                catch
                {
                }
              
                if (downList[i].ReqName)
                {
                    EnrollName = "";
                    DeviceObject.objFK623.GetUserName(EnrollNumber, ref EnrollName);
                    if (EnrollName != "") SystemInfo.db.SetEmpNameByFinger(EnrollNumber, EnrollName);
                }
                if (SystemInfo.db.GetEmpNoByFingerNo(EnrollNumber, ref EmpNo))
                {

                    if (retDate)
                    {
                        if (SystemInfo.DBType == 0)
                        {
                            if (StartDate == "") StartDate = "NULL";
                            else StartDate = "CDate('" + StartDate + "')";
                            if (EndDate == "") EndDate = "NULL";
                            else EndDate = "CDate('" + EndDate + "')";
                        }
                        else
                        {
                            if (StartDate == "") StartDate = "NULL";
                            else StartDate = "'" + StartDate + "'";
                            if (EndDate == "") EndDate = "NULL";
                            else EndDate = "'" + EndDate + "'";
                        }
                        //保存有效期
                        string sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "36", EmpNo, StartDate, EndDate });
                        SystemInfo.db.ExecSQL(sql);
                    }

                    if (DeviceObject.objFK623.GetEnrollPhoto(EnrollNumber, ref buff) && buff.Length > 0)
                    {
                        SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "7", EmpNo }),
                          "EmpPhotoImage", buff);
                    }
                }
                buff = null;
                Application.DoEvents();
            }
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgDownInfo", "");
                MacMsg = string.Format(tmp, downList.Count, FingerCount, FaceCount, PSWCount, CardCount, PalVeinCnt, "0");
            }
            SystemInfo.db.UpdateEmpInfoCount(this.Text);
            return ret;
        }
        private void CountFingerInfo(int BackupNumber, ref int FingerCount, ref int PSWCount, ref int CardCount,
        ref int FaceCount, ref int PalmVeinCnt)
        {
            switch (BackupNumber)
            {
                case (int)FKBackup.BACKUP_FP_0:
                case (int)FKBackup.BACKUP_FP_1:
                case (int)FKBackup.BACKUP_FP_2:
                case (int)FKBackup.BACKUP_FP_3:
                case (int)FKBackup.BACKUP_FP_4:
                case (int)FKBackup.BACKUP_FP_5:
                case (int)FKBackup.BACKUP_FP_6:
                case (int)FKBackup.BACKUP_FP_7:
                case (int)FKBackup.BACKUP_FP_8:
                case (int)FKBackup.BACKUP_FP_9:
                    FingerCount++;
                    break;
                case (int)FKBackup.BACKUP_PSW:
                    PSWCount++;
                    break;
                case (int)FKBackup.BACKUP_CARD:
                    CardCount++;
                    break;
                case (int)FKBackup.BACKUP_FACE:
                    FaceCount++;
                    break;
                case (int)FKBackup.BACKUP_PALMVEIN_0:
                case (int)FKBackup.BACKUP_PALMVEIN_1:
                case (int)FKBackup.BACKUP_PALMVEIN_2:
                case (int)FKBackup.BACKUP_PALMVEIN_3:
                    PalmVeinCnt++;
                    break;
            }
        }

        private void AddDownInfo(TDownInfoList downInfo)
        {
            bool isFind = false;
            for (int i = 0; i < downList.Count; i++)
            {
                if (downList[i].EnrollNumber == downInfo.EnrollNumber)
                {
                    isFind = true;
                    break;
                }
            }
            if (!isFind) downList.Add(downInfo);
        }

        private bool FindExecInfo(UInt32 EnrollNumber, int BackupNumber)
        {
            bool ret = false;
            for (int i = 0; i < execList.Count; i++)
            {
                if (execList[i].EnrollNumber == EnrollNumber && execList[i].BakNo == BackupNumber)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

      
        private bool Star_UploadInfo(string MacSN, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            string EmpNo = "";
            string EmpNoList = "";
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
            EmpNoList = GUID;
            if (flag == 10)
            {
                string[] guid = EmpNoList.Split('@');
                EmpNoList = guid[3];
            }
            DataTable dtUploadcount = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "604", EmpNoList }));
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
                        if (personIDList.result_data.users != null)
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
                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    fps = new List<string>();
                    face = null;
                    palm = null;
                    photo = null;
                    vaildStart = null;
                    vaildEnd = null;

                    photoEnroll = 1;
                    update = 0;
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());

                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber,
                      i + 1, dtUploadcount.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;

                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                    CardNo10 = dtUploadcount.Rows[i]["CardNo10"].ToString();
                    Pwd = dtUploadcount.Rows[i]["pwd"].ToString();
                    Privilege = Convert.ToInt32(dtUploadcount.Rows[i]["FingerPrivilege"].ToString());
                    vaildStart = dtUploadcount.Rows[i]["StartDate"].ToString();
                    IsDateTime("yyyyMMdd", ref vaildStart);

                    vaildEnd = dtUploadcount.Rows[i]["EndDate"].ToString();
                    IsDateTime("yyyyMMdd", ref vaildEnd);

                    if (string.IsNullOrEmpty(vaildStart)) vaildStart = "00000000";
                    if (string.IsNullOrEmpty(vaildEnd)) vaildEnd = "00000000";
                    CountUp++;
                    photo = "";
                    nPhotoSize = 0;
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EmpPhoto"].ToString()))
                    {

                        dataBuffer = (byte[])(dtUploadcount.Rows[i]["EmpPhoto"]);
                        nPhotoSize = dataBuffer.Length;
                        if (nPhotoSize > 0)
                        {
                            photo = Convert.ToBase64String(dataBuffer);

                        }

                    }
                    if(nPhotoSize==0)
                    {
                        if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EmpPhotoImage"].ToString()))
                        {
                            dataBuffer = (byte[])(dtUploadcount.Rows[i]["EmpPhotoImage"]);
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
                        //        dataBuffer = (byte[])(dr["Fb0" + j]);
                        //        fps.Add(Convert.ToBase64String(dataBuffer));
                        //    }

                        //}

                        if (!string.IsNullOrEmpty(dr["Face00"].ToString()))
                        {
                            dataBuffer = (byte[])(dr["Face00"]);
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
                sendCount = 0;
                if (usersList.Count > 0)
                {
                    setUserInfoCmd = new SetUserInfoCmd<SetUsers>(usersList);
                    devSetUserInfoCmd = new _DeviceCmd<SetUserInfoCmd<SetUsers>>(cmd, setUserInfoCmd);
                ER:
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
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                if (ID != "")
                {
                    tmp += "  <" + Pub.GetResText(formCode, "UnsuccessfulEmpNo", "") + ID + ">  ";
                }
                MacMsg = string.Format(tmp, CountUp, dtUploadcount.Rows.Count, CountUpFp);
            }
          
            return ret;
        }

        private bool Star_DownloadInfo(ref string MacMsg)
        {
            bool ret = false;
            int Privilege = 0;
            byte[] fpData = new byte[(int)FKMax.FK_FaceDataSize];
            string EmpNo = "";
            int FingerCount = 0;
            int PSWCount = 0;
            int CardCount = 0;
            int FaceCount = 0;
            int PalVeinCnt = 0;
            string StartDate = "";
            string EndDate = "";
            DataTable dtInsert = new DataTable();
            DataTable dtUpdate = new DataTable();
            DataTable dtSelect = new DataTable();
            DataTable dtSelectData = new DataTable();
            DataTable dtInsertData = new DataTable();
            DataTable dtUpdateData = new DataTable();
            DataRow[] rows = null;
            DataRow[] rowsData = null;
            string HireDate = "";
            string EmpSex = "";
            
            int userCount = 0;
            byte[] CardData = new byte[0];
            byte[] PwdData = new byte[0];

            byte[] EmpPhotoBuff = null;
            
            //byte[] fps00 = new byte[0];
            //byte[] fps01 = new byte[0];
            //byte[] fps02 = new byte[0];
            //byte[] fps03 = new byte[0];
            //byte[] fps04 = new byte[0];
            //byte[] fps05 = new byte[0];
            //byte[] fps06 = new byte[0];
            //byte[] fps07 = new byte[0];
            //byte[] fps08 = new byte[0];
            //byte[] fps09 = new byte[0];
            byte[] face00 = new byte[0];
            byte[] palm00 = new byte[0];
            byte[] photo = new byte[0];
            int sendCount = 0;
            int count = 0;
            int UsersCount = 0;
            string cmd = "";
            StringBuilder jsonStringBuilder = null;
            string StatusMsg = lblMsg.Text;
            progBar.ProgressType = eProgressItemType.Standard;
            List<_ResultInfo<PersonInfo<GetUsers>>> PersonInfoList = new List<_ResultInfo<PersonInfo<GetUsers>>>();
            List<string> usersIDList = new List<string>();

            try
            {
                dtInsert = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "37" }));
                dtUpdate = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "37" }));
                dtSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "27" }));
                dtSelectData = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "28" }));
                dtInsertData = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "29" }));
                dtUpdateData = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "29" }));
                progBar.ProgressType = eProgressItemType.Marquee;
                ret = true;

                sendCount = 0;
                PersonInfoList.Clear();
                GetUserInfoCmd getUserInfoCmd = null;

                #region 首先获取机器上的所有用户数
                cmd = "GetDeviceInfo";
                DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
                jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));

                if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                {
                    int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                    if (state == 0)
                    {
                        _ResultInfo<DeviceInfo> deviceInfo = JsonConvert.DeserializeObject<_ResultInfo<DeviceInfo>>(jsonStringBuilder.ToString());
                        UsersCount = deviceInfo.result_data.userCount;
                    }
                }
                if (UsersCount <= 0)
                {
                    DeviceObject.socKetClient.ErrMsg = Pub.GetResText("", "FK_RUNERR_DATAARRAY_NONE", "");
                    ret = false;
                    return ret;
                }
                #endregion
                cmd = "GetUserInfo";
                getUserInfoCmd = new GetUserInfoCmd(0, null);
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
                            count++;
                           
                            //fps00 = null;
                            //fps01 = null;
                            //fps02 = null;
                            //fps03 = null;
                            //fps04 = null;
                            //fps05 = null;
                            //fps06 = null;
                            //fps07 = null;
                            //fps08 = null;
                            //fps09 = null;
                            face00 = null;
                            palm00 = null;
                            photo = null;
                            EmpPhotoBuff = null;
                           
                            if (getUserInfo.result_data.users[i].photo != null)
                            {
                                string photoStr = getUserInfo.result_data.users[i].photo;
                                photo = Convert.FromBase64String(photoStr);

                                MemoryStream ms = new MemoryStream(photo);
                                Image empPhotoImage = CustomSizeImage(Image.FromStream(ms));
                                ms.Dispose();
                                using (Bitmap t = new Bitmap(empPhotoImage))
                                {
                                    ms = new MemoryStream();
                                    t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    EmpPhotoBuff = ms.ToArray();
                                    ms.Dispose();
                                    ms.Close();
                                }

                            }
                            StartDate = getUserInfo.result_data.users[i].vaildStart;
                            EndDate = getUserInfo.result_data.users[i].vaildEnd;
                            StartDate = stringToTimeStr(StartDate);
                            EndDate = stringToTimeStr(EndDate);

                            StartDate = CheckTimeStr(StartDate);
                            EndDate = CheckTimeStr(EndDate);
                            if (!string.IsNullOrEmpty(getUserInfo.result_data.users[i].pwd))
                            {
                                PSWCount++;
                            }
                            if (!string.IsNullOrEmpty(getUserInfo.result_data.users[i].card))
                            {
                                CardCount++;
                            }
                            rows = dtSelect.Select("FingerNo=" + getUserInfo.result_data.users[i].userId + "");
                            if (rows.Length > 0)
                            {
                                EmpNo = rows[0]["EmpNo"].ToString();
                                HireDate = rows[0]["EmpHireDate"].ToString();

                                dtUpdate.Rows.Add(new object[] { EmpNo, getUserInfo.result_data.users[i].name, EmpSex, SystemInfo.CommanyID, HireDate , "",
                                getUserInfo.result_data.users[i].card,getUserInfo.result_data.users[i].pwd,getUserInfo.result_data.users[i].userId,Privilege.ToString(), true,
                                "","",false,EmpPhotoBuff,"",StartDate,EndDate});
                            }
                            else
                            {
                                EmpNo = SystemInfo.db.GetAutoEmpNo(Convert.ToUInt32(getUserInfo.result_data.users[i].userId));
                                HireDate = DateTime.Now.ToString(Pub.GetResText("", "YMWFormatForm", ""));
                                dtSelect.Rows.Add(new object[] { getUserInfo.result_data.users[i].userId, EmpNo, HireDate });
                                dtInsert.Rows.Add(new object[] { EmpNo, getUserInfo.result_data.users[i].name, EmpSex, SystemInfo.CommanyID, HireDate , "",
                                getUserInfo.result_data.users[i].card,getUserInfo.result_data.users[i].pwd,getUserInfo.result_data.users[i].userId,Privilege.ToString(), true,
                                "","",false,EmpPhotoBuff,"",StartDate,EndDate});
                            }

                            if (getUserInfo.result_data.users[i].face != null)
                            {
                                string faceStr = getUserInfo.result_data.users[i].face;
                                face00 = Convert.FromBase64String(faceStr);
                                FaceCount++;
                            }
                            if (getUserInfo.result_data.users[i].palm != null)
                            {
                                string palmStr = getUserInfo.result_data.users[i].palm;
                                palm00 = Convert.FromBase64String(palmStr);
                                PalVeinCnt++;
                            }
                            if (getUserInfo.result_data.users[i].fps != null)
                            {
                                for (int j = 0; j < getUserInfo.result_data.users[i].fps.Count; j++)
                                {
                                    if (getUserInfo.result_data.users[i].fps[j] != null)
                                    {
                                        //FingerCount++;
                                        //string fpsStr = getUserInfo.result_data.users[i].fps[j];
                                        //switch (j)
                                        //{
                                        //    case 0:
                                        //        fps00 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 1:
                                        //        fps01 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 2:
                                        //        fps02 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 3:
                                        //        fps03 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 4:
                                        //        fps04 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 5:
                                        //        fps05 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 6:
                                        //        fps06 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 7:
                                        //        fps07 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 8:
                                        //        fps08 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 9:
                                        //        fps09 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //}
                                        FingerCount++;
                                        byte[] fpDatas = Convert.FromBase64String(getUserInfo.result_data.users[i].fps[j]);
                                        byte[] buff = new byte[1680];
                                        byte[] FpDataConv = new byte[1680];
                                        byte[] header = { 0x45, 0x4e, 0x52, 0x4f, 0x4c, 0x4c, 0x46, 0x50, 0x01, 0x28 };
                                        Array.Copy(header, 0, FpDataConv, 0, header.Length); //Add Fixed Header 
                                        Array.Copy(fpDatas, 0, FpDataConv, 80, fpDatas.Length);
                                        ObjFpReader.ConvEnrollData(FpDataConv, ref buff, 1680);

                                        SystemInfo.db.SaveStarEnrollToDB(UInt32.Parse(getUserInfo.result_data.users[i].userId), buff, j.ToString());
                                    }
                                }
                            }

                            rowsData = dtSelectData.Select("FingerNo=" + getUserInfo.result_data.users[i].userId + "");
                            if (rowsData.Length == 0)
                            {
                                dtInsertData.Rows.Add(new object[] { EmpNo,getUserInfo.result_data.users[i].userId, null, null, null, null, null, null, null, null, null, null,
                               face00,palm00 });
                            }
                            else
                            {
                                dtUpdateData.Rows.Add(new object[] { EmpNo,getUserInfo.result_data.users[i].userId, null, null, null, null, null, null, null, null, null, null,
                               face00,palm00 });
                            }

                            userCount++;
                            lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                          string.Format(" - {2}/{3}  [{0}: {1}]", getUserInfo.result_data.users[i].userId, getUserInfo.result_data.users[i].name, userCount, UsersCount);
                            if (userCount > 0)
                                progBar.Value = userCount * 100 / UsersCount;
                            Application.DoEvents();

                            if (dtInsert.Rows.Count > 100)
                            {
                                SystemInfo.db.batchEmpInSertData(dtInsert, "RS_Emp");
                                dtInsert.Clear();
                            }
                            if (dtUpdate.Rows.Count > 100)
                            {
                                SystemInfo.db.batchEmpUpdateData(dtUpdate, "RS_Emp", "EmpNo");
                                dtUpdate.Clear();
                            }

                            if (dtInsertData.Rows.Count > 100)
                            {
                                SystemInfo.db.batchEmpInSertData(dtInsertData, "RS_EmpDynamicInfo");
                                dtInsertData.Clear();
                            }
                            if (dtUpdateData.Rows.Count > 100)
                            {
                                SystemInfo.db.batchEmpUpdateData(dtUpdateData, "RS_EmpDynamicInfo", "EmpNo");
                                dtUpdateData.Clear();
                            }
                        }
                        if (dtInsert.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsert, "RS_Emp");
                            dtInsert.Clear();
                        }
                        if (dtUpdate.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdate, "RS_Emp", "EmpNo");
                            dtUpdate.Clear();
                        }

                        if (dtInsertData.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsertData, "RS_EmpDynamicInfo");
                            dtInsertData.Clear();
                        }
                        if (dtUpdateData.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdateData, "RS_EmpDynamicInfo", "EmpNo");
                            dtUpdateData.Clear();
                        }
                    }
                }
               
                SystemInfo.db.UpdateEmpInfoCount(this.Text);
                SystemInfo.db.UpdateEmpInfoCount_Star();
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgDownInfo_Star", "");
                MacMsg = string.Format(tmp, userCount, FingerCount, FaceCount, PSWCount, CardCount, PalVeinCnt);
            }
          
            return ret;
        }

        private bool SeaSeries_UploadInfo(string url, string name, string pwd,string MacSN,  ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            string addUrl = url + "action/AddPerson";
            string selUrl = url + "action/SearchPerson";
            string updUrl = url + "action/EditPerson";
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            int EmpSex = 2;
            string EmpNo = "";

            string EmpCertNo = "";
            string CardNo10 = "";
            long WeCardNo10 = 0;
            int WeCardNoType = 0;
            string EmpAddress = "";
            string EmpPhoneNo = "";
            string picinfo = "";
            string EmpMemo = "";
            string ValidBegin = "";
            string ValidEnd = "";
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            int Valid = 0;
            bool IsUpdate = false;
            EditPersonInfo editPerson = null;
            Person<EditPersonInfo> editPersonCmd = null;

            SearchOnePerson searchOnePerson = null;
            jsonBody<SearchOnePerson> searchOnePersonCmd = null;

            PersonInfo personInfo = null;
            Person<PersonInfo> addPerson = null;
            string jsonString = "";
            List<int> CustomizeIDList = new List<int>();
            string ID = "";
            DataTable dtUploadcount = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "604", GUID }));
            if (dtUploadcount == null)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }
            progBar.ProgressType = eProgressItemType.Standard;
            try
            {
                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    CustomizeIDList = new List<int>();
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());
                    CustomizeIDList.Add(Convert.ToInt32(EnrollNumber));
                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber,
                      i + 1, dtUploadcount.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;

                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                    if (dtUploadcount.Rows[i]["EmpSex"].ToString().Equals(Pub.GetResText("", "EmpSex0", "")))
                    {
                        EmpSex = 0;
                    }
                    else if (dtUploadcount.Rows[i]["EmpSex"].ToString().Equals(Pub.GetResText("", "EmpSex1", "")))
                    {
                        EmpSex = 1;
                    }
                    else
                    {
                        EmpSex = 2;
                    }
                    EmpCertNo = dtUploadcount.Rows[i]["EmpCertNo"].ToString();
                    CardNo10 = dtUploadcount.Rows[i]["CardNo10"].ToString();
                    long.TryParse(CardNo10, out WeCardNo10);
                    EmpAddress = dtUploadcount.Rows[i]["EmpAddress"].ToString();
                    EmpPhoneNo = dtUploadcount.Rows[i]["EmpPhoneNo"].ToString();
                    EmpMemo = dtUploadcount.Rows[i]["EmpMemo"].ToString();
                    ValidBegin = "";
                    ValidEnd = "";
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["StartDate"].ToString()))
                        ValidBegin = Convert.ToDateTime(dtUploadcount.Rows[i]["StartDate"]).ToString(SystemInfo.SQLDateFMT) + "T00:00:00";
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EndDate"].ToString()))
                        ValidEnd = Convert.ToDateTime(dtUploadcount.Rows[i]["EndDate"]).ToString(SystemInfo.SQLDateFMT) + "T23:59:59";

                    if (ValidBegin != "" || ValidEnd != "")
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
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EmpPhoto"].ToString()))
                    {

                        byte[] buf = (byte[])(dtUploadcount.Rows[i]["EmpPhoto"]);
                        nPhotoSize = buf.Length;
                        if (nPhotoSize > 0)
                        {
                            picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buf);
                            CountUpFp++;
                        }

                    }
                    if(nPhotoSize==0)
                    {
                        if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EmpPhotoImage"].ToString()))
                        {
                            byte[] buf = (byte[])(dtUploadcount.Rows[i]["EmpPhotoImage"]);
                            nPhotoSize = buf.Length;
                            if (nPhotoSize > 0)
                            {
                                picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buf);
                                CountUpFp++;
                            }
                        }
                    }

                    CardNo10 = StrToHex(CardNo10);
                    if (CardNo10.Length > 10) CardNo10 = CardNo10.Substring(CardNo10.Length - 10, 10);

                    if (WeCardNo10 != 0) WeCardNoType = 2;
                    else WeCardNoType = 0;
                    searchOnePerson = new SearchOnePerson(Int32.Parse(MacSN), 0, EnrollNumber.ToString(), 0);
                    searchOnePersonCmd = new jsonBody<SearchOnePerson>("SearchPerson", searchOnePerson);
                    jsonString = JsonConvert.SerializeObject(searchOnePersonCmd);
                    IsUpdate = false;
                    ret = DeviceObject.objFK623.POST_GetResponse(selUrl, name, pwd, ref jsonString);
                    if(ret)
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
                         EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, CardNo10, Valid, "", ValidBegin, ValidEnd);
                        editPersonCmd = new Person<EditPersonInfo>("EditPerson", editPerson, picinfo);
                        jsonString = JsonConvert.SerializeObject(editPersonCmd);
                        ret = DeviceObject.objFK623.POST_GetResponse(updUrl, name, pwd, ref jsonString);
                    }
                    else
                    {
                        //增加人员
                        personInfo = new PersonInfo(Convert.ToInt32(MacSN), 0, EnrollName, EmpSex, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                            EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, CardNo10, Valid, Convert.ToInt32(EnrollNumber), "", ValidBegin, ValidEnd, "1", "1", "1", "1");
                        addPerson = new Person<PersonInfo>("AddPerson", personInfo, picinfo);
                        jsonString = JsonConvert.SerializeObject(addPerson);
                        ret = DeviceObject.objFK623.POST_GetResponse(addUrl, name, pwd, ref jsonString);
                    }

                    if (!ret)
                    {
                        if(DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
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
                    ret = true;
                    Application.DoEvents();
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                if (ID != "")
                {
                    tmp += "  <" + Pub.GetResText(formCode, "UnsuccessfulEmpNo", "") + ID + ">  ";
                }
                MacMsg = string.Format(tmp, dtUploadcount.Rows.Count, CountUp, CountUpFp);
            }

            return ret;
        }

        private bool SeaSeries_DownloadInfo(string url, string name, string pwd, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            string HireDate = "";
            int Privilege = 0;
            byte[] Photo = new byte[0];
            int EmpCount = 0;
            DataRow[] rows = null;
            string EmpNo = "";
            byte[] EmpPhotoBuff = null;
            byte[] PhotoBuff = null;
            int PersonNum = 0;
            int PhotoCount = 0;
            string EmpSex = "";
            string jsonString = "";
            string StatusMsg = lblMsg.Text;
            string CardNo = "";
            int userCount = 0;
            int CardCount = 0;
            string StartDate = "";
            string EndDate = "";

            byte[] CardData = new byte[0];

            progBar.ProgressType = eProgressItemType.Standard;

            DataTable dtInsert = new DataTable();
            DataTable dtUpdate = new DataTable();
            DataTable dtSelect = new DataTable();
            try
            {
                dtInsert = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "26" }));
                dtUpdate = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "26" }));
                dtSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "27" }));

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
                int i = 0;
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
                            Photo = new byte[0];
                            if (!string.IsNullOrEmpty(searchMultiplePersonInfo.info.List[j].Picinfo))
                                Photo = Convert.FromBase64String(searchMultiplePersonInfo.info.List[j].Picinfo.Replace("data:image/jpeg;base64,", ""));
                            if(searchMultiplePersonInfo.info.List[j].RFIDCard!=null)
                            {
                                CardNo = searchMultiplePersonInfo.info.List[j].RFIDCard.ToString();

                                if (CardNo != "")
                                    CardNo = HexToStr(CardNo);
                                if (CardNo.Length > 10) CardNo = CardNo.Substring(CardNo.Length - 10, 10);
                                CardCount++;
                            }
                            else
                            {
                                CardNo = searchMultiplePersonInfo.info.List[j].MjCardNo.ToString();
                                if (CardNo.Length > 1) CardCount++;
                                else
                                {
                                    CardNo = "";
                                }
                                if (CardNo.Length > 10) CardNo = CardNo.Substring(CardNo.Length - 10, 10);
                            }

                            if (searchMultiplePersonInfo.info.List[j].Gender == 0)
                            {
                                EmpSex = Pub.GetResText("", "EmpSex0", "");
                            }
                            else if (searchMultiplePersonInfo.info.List[j].Gender == 1)
                            {
                                EmpSex = Pub.GetResText("", "EmpSex1", "");
                            }
                            else
                            {
                                EmpSex = "";
                            }
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

                            if (Photo.Length > 1)
                            {
                                MemoryStream ms = new MemoryStream(Photo);
                                Image empPhotoImage = CustomSizeImage(Image.FromStream(ms));
                                ms.Dispose();
                                using (Bitmap t = new Bitmap(empPhotoImage))
                                {
                                    ms = new MemoryStream();
                                    t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    EmpPhotoBuff = ms.ToArray();
                                    ms.Dispose();
                                    ms.Close();
                                }

                                MemoryStream msi = new MemoryStream(Photo);
                                Image empPhoto = CustomSizePhoto(Image.FromStream(msi));
                                msi.Dispose();
                                using (Bitmap ti = new Bitmap(empPhoto))
                                {
                                    msi = new MemoryStream();
                                    ti.Save(msi, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    PhotoBuff = msi.ToArray();
                                    msi.Dispose();
                                    msi.Close();
                                }
                                PhotoCount = 1;
                            }
                            else
                            {
                                PhotoCount = 0;
                            }
                            EmpNo = "";
                            HireDate = "";

                            rows = dtSelect.Select("FingerNo=" + searchMultiplePersonInfo.info.List[j].CustomizeID + "");
                            if (rows.Length > 0)
                            {
                                EmpNo = rows[0]["EmpNo"].ToString();
                                HireDate = rows[0]["EmpHireDate"].ToString();

                                dtUpdate.Rows.Add(new object[] { EmpNo, searchMultiplePersonInfo.info.List[j].Name, EmpSex, SystemInfo.CommanyID, HireDate , searchMultiplePersonInfo.info.List[j].IdCard
                                ,CardNo,"",searchMultiplePersonInfo.info.List[j].CustomizeID,Privilege.ToString(), true,
                                searchMultiplePersonInfo.info.List[j].Address,searchMultiplePersonInfo.info.List[j].Telnum,false,
                                EmpPhotoBuff,PhotoBuff,PhotoCount,searchMultiplePersonInfo.info.List[j].Notes,StartDate,EndDate});
                            }
                            else
                            {
                                EmpNo = SystemInfo.db.GetAutoEmpNo(searchMultiplePersonInfo.info.List[j].CustomizeID);
                                HireDate = DateTime.Now.ToString(Pub.GetResText("", "YMWFormatForm", ""));
                                dtSelect.Rows.Add(new object[] { searchMultiplePersonInfo.info.List[j].CustomizeID, EmpNo, HireDate });
                                dtInsert.Rows.Add(new object[] { EmpNo, searchMultiplePersonInfo.info.List[j].Name, EmpSex, SystemInfo.CommanyID, HireDate , searchMultiplePersonInfo.info.List[j].IdCard
                                ,CardNo,"",searchMultiplePersonInfo.info.List[j].CustomizeID,Privilege.ToString(), true,
                                searchMultiplePersonInfo.info.List[j].Address,searchMultiplePersonInfo.info.List[j].Telnum,
                                false,EmpPhotoBuff,PhotoBuff,PhotoCount,searchMultiplePersonInfo.info.List[j].Notes,StartDate,EndDate});
                            }

                            userCount++;
                            lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                          string.Format(" - {2}/{3}  [{0}: {1}]", searchMultiplePersonInfo.info.List[j].CustomizeID, searchMultiplePersonInfo.info.List[j].Name, EmpCount, PersonNum);
                            if (EmpCount > 0)
                                progBar.Value = EmpCount * 100 / PersonNum;
                            Application.DoEvents();
                        }
                        if (dtInsert.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsert, "RS_Emp");
                            dtInsert.Clear();
                        }
                        if (dtUpdate.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdate, "RS_Emp", "EmpNo");
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
                string tmp = Pub.GetResText(formCode, "MsgDownInfo", "");
                MacMsg = string.Format(tmp, userCount, 0, 0, 0, CardCount, 0, userCount);
            }
            if (userCount > 0)
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                ret = true;
            }
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
        }

        private void msgGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmBaseShowMsg frm = new frmBaseShowMsg(this.Text, msgGrid[0, e.RowIndex].Value.ToString());
            frm.ShowDialog();
        }

        private bool RemoteReg(string MacSN, ref string MacMsg)
        {
            bool ret = false;
            string[] param = GUID.Split('@');
            string vStrEnrollNumber = param[0];
            int vBackupNumber = Convert.ToInt32(param[1]);
            int vPrivilege = Convert.ToInt32(param[2]);
            JObject vjobj = new JObject();
            JObject vjobjparam = new JObject();
            vjobj.Add("cmd", "enter_enroll");//enter_enroll为指令类型
            vjobjparam.Add("user_id", vStrEnrollNumber);
            vjobjparam.Add("backup_number", vBackupNumber);
            vjobjparam.Add("privilege", vPrivilege);
            vjobj.Add("param", vjobjparam);
            string vstrJsonStr = vjobj.ToString();

            int strBuliderLength = 100 * 1024;                      //指定长度
            StringBuilder sb = new StringBuilder(strBuliderLength); //初始化
            sb.Append(vstrJsonStr);                                 //增加指令
            ret = DeviceObject.objFK623.ExecJsonCmd(ref sb);

            //if (ret)
            //{
            //    MacMsg = Pub.GetResText(formCode, "FK_RUN_SUCCESS", "");
            //}
            //else
            //{
            //    MacMsg = Pub.GetResText(formCode, "FK_RUNERR_NOSUPPORT", "");
            //}
            return ret;
        }
        private bool Star_RemoteReg(string MacSN, ref string MacMsg)
        {
            bool ret = false;
           
            try
            {
                string[] param = GUID.Split('@');
                string cmd = "EnterEnroll";
                string userId = param[0];
                string feature = "";
                switch (param[1])
                {
                    case "0":
                        feature = "fp";
                        break;
                    case "12":
                        feature = "face";
                        break;
                    case "13":
                        feature = "palm";
                        break;
                }

                EnterEnrollCmd enterEnrollCmd = new EnterEnrollCmd(userId, feature);
                _DeviceCmd<EnterEnrollCmd> devEnterEnrollCmd = new _DeviceCmd<EnterEnrollCmd>(cmd, enterEnrollCmd);
                StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devEnterEnrollCmd));

                if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                {
                    int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                    if (state == 0)
                    {
                        ret = true;
                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }
    }
}