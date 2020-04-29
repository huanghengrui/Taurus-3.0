using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Data;
using Newtonsoft.Json;

namespace Taurus
{
    public class SeaHttpServer
    {
        HttpListener httpListener = new HttpListener();
        Label label;
        Taurus.FingerReadData.ProcessReadData prog;
        bool stop = false;
        KQTextFormatInfo textFormat;
        public void Setup(int port, Taurus.FingerReadData.ProcessReadData prog, Label label, KQTextFormatInfo textFormat)
        {
            try
            {
                this.label = label;
                this.prog = prog;
                this.textFormat = textFormat;
                if (port == 0)
                {
                    stop = true;
                    httpListener.Close();
                    return;
                }
                stop = false;
                httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                httpListener.Prefixes.Add(string.Format("http://*:{0}/", port));
                httpListener.Start();
                Receive();
               
            }
            catch
            {

            }
           
        }

        private void Receive()
        {
            if(!stop)
                httpListener.BeginGetContext(new AsyncCallback(EndReciver), null);
        }

        void EndReciver(IAsyncResult ar)
        {
            if(!stop)
            {
                var context = httpListener.EndGetContext(ar);
                Dispather(context);
                Receive();
            } 
        }

        RequestHelper RequestHelper;
        ResponseHelper ResponseHelper;
        void Dispather(HttpListenerContext context)
        {
            HttpListenerRequest request= context.Request;
            HttpListenerResponse response = context.Response;
            RequestHelper = new RequestHelper(request, label,prog, textFormat);
            ResponseHelper = new ResponseHelper(response);
            RequestHelper.DispatchResources(state => { ResponseHelper.WriteToClient(state); });
           
        }

    }

    public class RequestHelper
    {  
        private HttpListenerRequest request;
        private Label label;
        private Base Pub = new Base();
        Taurus.FingerReadData.ProcessReadData prog;
        private FingerReadData readData = new FingerReadData("");
        private TFingerLog attLog = new TFingerLog();
        private PIDLog pidLog = new PIDLog();
        KQTextFormatInfo textFormat;
        string MacSN = "";
        string GUID = "";

        public RequestHelper(HttpListenerRequest request, Label label, Taurus.FingerReadData.ProcessReadData prog, KQTextFormatInfo textFormat)
        {
            this.request = request;
            this.label = label;
            this.prog = prog;
            this.textFormat = textFormat;
        }
        
         public delegate void ExecutingDispatch(int state);
         public void DispatchResources(ExecutingDispatch action)
         {
             var rawUrl = request.RawUrl;
             try
             {
                 string deviceId = request.Headers.Get("dev_id");
                 StreamReader sr = new StreamReader(request.InputStream);
                 string requestBody = sr.ReadToEnd();

                if (requestBody.Contains("VerifyPush"))
                {
                    if (label.InvokeRequired)
                    {
                        label.Invoke(new Action<String>(s =>
                        {
                            SaveFaceLog(s);

                        }), requestBody);
                    }
                    else
                    {
                        SaveFaceLog(requestBody);
                    }
                }
                else if (requestBody.Contains("CardVerify"))
                {
                    if (label.InvokeRequired)
                    {
                        label.Invoke(new Action<String>(s =>
                        {
                            SaveCardLog(s);

                        }), requestBody);
                    }
                    else
                    {
                        SaveCardLog(requestBody);
                    }
                }
                else if (requestBody.Contains("IDCardInfoPus"))
                {
                    if (label.InvokeRequired)
                    {
                        label.Invoke(new Action<String>(s =>
                        {
                            SaveFaceLog(s);

                        }), requestBody);
                    }
                    else
                    {
                        SaveFaceLog(requestBody);
                    }
                }
                else if (requestBody.Contains("SnapPush"))
                {
                    if (label.InvokeRequired)
                    {
                        label.Invoke(new Action<String>(s =>
                        {
                            SaveSnapLog(s);

                        }), requestBody);
                    }
                    else
                    {
                        SaveSnapLog(requestBody);
                    }
                }
                else if (requestBody.Contains("RemoteOpenDoorPush"))
                {
                    if (label.InvokeRequired)
                    {
                        label.Invoke(new Action<String>(s =>
                        {
                            SaveFaceLog(s);

                        }), requestBody);
                    }
                    else
                    {
                        SaveFaceLog(requestBody);
                    }
                }
            }
             catch
             {
                return;
             }

            action.Invoke(404);
            
        }

        public void SaveSnapLog(string LogStr)
        {
            VerifyPush<SnapPush> verifyPush = JsonConvert.DeserializeObject<VerifyPush<SnapPush>>(LogStr);
            byte[] PhotoImage = null;
            MacSN = verifyPush.info.DeviceID.ToString();
            PhotoImage = Convert.FromBase64String(verifyPush.SanpPic.Replace("data:image/jpeg;base64,", ""));
            DateTime time = Convert.ToDateTime(verifyPush.info.CreateTime);
            SystemInfo.db.SaveSnapLog(MacSN, verifyPush.info.PictureType, time.ToString(SystemInfo.SQLDateTimeFMT), verifyPush.info.Temperature.ToString(), verifyPush.info.TemperatureAlarm, PhotoImage , ref GUID);
            if (prog != null) prog(1, 1, MacSN, null, GUID, true);
        }


        public void SaveCardLog(string LogStr)
        {
            jsonBody<CardVerify> verifyPush = JsonConvert.DeserializeObject<jsonBody<CardVerify>>(LogStr);
            byte[] PhotoImage = null;
            int InOutMode = 0;
            int DevMode = 0;
            MacSN = verifyPush.info.DeviceID.ToString();
            attLog.Remark = verifyPush.info.CardNo;
            UInt32 FingerNo = 0;
            attLog = new TFingerLog();
            attLog.CardID = FingerNo.ToString("0000000000");
            attLog.CardTime = DateTime.Parse(verifyPush.info.CreateTime);
            attLog.FingerNo = FingerNo;

            DataTableReader dr = SystemInfo.db.GetDataReader("SELECT * FROM VDI_MacInfo WHERE MacSN='" + MacSN + "'");
            if (dr.Read())
            {
                int.TryParse(dr["InOutMode"].ToString(), out InOutMode);
                int.TryParse(dr["DevModeID"].ToString(), out DevMode);
            }
            dr.Close();
            attLog.InOutMode = InOutMode;

            readData.Sea_SetLogName(attLog, InOutMode, 1, 21);

            readData.WriteTextFile(attLog, MacSN);
            if (textFormat.Allow) readData.WriteTextFormat(textFormat, attLog, MacSN);
            if (DevMode == 0 || DevMode == 1)
            {
                readData.SaveDB(attLog, MacSN, true, ref GUID);
                if (GUID != "")
                {
                    if (PhotoImage != null)
                        readData.SaveDBPhoto(GUID, PhotoImage);
                }
            }

            if (attLog.VerifyMode == 0 || (attLog.VerifyMode != 2 && attLog.VerifyMode != 3))
            {
                attLog.VerifyMode = attLog.DoorMode;
                attLog.VerifyModeName = attLog.DoorModeName;
            }

            readData.WriteTextFileMJ(attLog, MacSN);
            if (DevMode == 0 || DevMode == 2)
            {
                readData.SaveDBMJ(attLog, MacSN, true, ref GUID);
                if (GUID != "")
                {
                    if (PhotoImage != null)
                        readData.SaveDBPhotoMJ(GUID, PhotoImage);
                }
            }

            if (prog != null) prog(1, 1, MacSN, attLog, GUID, true);
        }

        public void SaveFaceLog(string LogStr)
        {
            byte[] PhotoImage = null;
            DataTableReader dr = null;
            int InOutMode = 0;
            int VerifyStatus = 0;
            int VerifyType = 0;
            int DevMode = 0;
            VerifyPush<VerifyPushInfo> verifyPush = null;
            VerifyPush<RemoteOpenDoorPushInfo> remoteOpenDoorPush = null;
            if (LogStr.Contains("RemoteOpenDoorPush"))
            {
                remoteOpenDoorPush = JsonConvert.DeserializeObject<VerifyPush<RemoteOpenDoorPushInfo>>(LogStr);
                MacSN = remoteOpenDoorPush.info.DeviceID.ToString();
                attLog.Remark = "";
                UInt32 FingerNo = 0;
                attLog = new TFingerLog();
                attLog.CardID = FingerNo.ToString("0000000000");
                attLog.CardTime = DateTime.Parse(remoteOpenDoorPush.info.CreateTime);
                attLog.FingerNo = FingerNo;
                VerifyStatus = 27;
                VerifyType = remoteOpenDoorPush.info.VerfyType;
            }
            else
            {
                verifyPush = JsonConvert.DeserializeObject<VerifyPush<VerifyPushInfo>>(LogStr);
                MacSN = verifyPush.info.DeviceID.ToString();
                attLog.Remark = verifyPush.info.Notes;
                if (verifyPush.info.CustomizeID < 0) verifyPush.info.CustomizeID = 0;
                 UInt32 FingerNo =(UInt32)verifyPush.info.CustomizeID;
                attLog = new TFingerLog();
                attLog.CardID = FingerNo.ToString("0000000000");
                attLog.CardTime = DateTime.Parse(verifyPush.info.CreateTime);
                attLog.FingerNo = FingerNo;
                attLog.Temperature = verifyPush.info.Temperature;
                attLog.TemperatureAlarm = verifyPush.info.TemperatureAlarm;
                VerifyType = verifyPush.info.VerfyType;
                VerifyStatus = verifyPush.info.VerifyStatus;
                if (verifyPush.SanpPic != null)
                {
                    PhotoImage = Convert.FromBase64String(verifyPush.SanpPic.Replace("data:image/jpeg;base64,", ""));
                }
                else
                {
                    PhotoImage = new byte[0];
                }
            }
            dr = SystemInfo.db.GetDataReader("SELECT * FROM VDI_MacInfo WHERE MacSN='" + MacSN + "'");
            if (dr.Read())
            {
                int.TryParse(dr["InOutMode"].ToString(), out InOutMode);
                int.TryParse(dr["DevModeID"].ToString(), out DevMode);
            }
            dr.Close();
            readData.Sea_SetLogName(attLog, InOutMode,VerifyStatus, VerifyType);
            if (attLog.VerifyMode == 2 || attLog.VerifyMode == 3)
            {
                pidLog.Name = verifyPush.info.Name;
                pidLog.Time = attLog.CardTime;
                pidLog.MacSN = MacSN;
                if (verifyPush.info.Gender == 0)
                {
                    pidLog.Gender = Pub.GetResText("Public", "EmpSex0", "");
                }
                else if (verifyPush.info.Gender == 1)
                {
                    pidLog.Gender = Pub.GetResText("Public", "EmpSex1", "");
                }
                else
                {
                    pidLog.Gender = "";
                }
                pidLog.Birthday = DateTime.Parse(verifyPush.info.Birthday);
                pidLog.CardType = Pub.GetResText("Public", "LOG_IDCARD", "");
                pidLog.EmpCertNo = verifyPush.info.IdCard;
                pidLog.EmpAddress = verifyPush.info.Address;
                pidLog.InOutMode = attLog.InOutMode;
                pidLog.InOutModeName = attLog.InOutModeName;
                pidLog.Temperature = verifyPush.info.Temperature;
                pidLog.TemperatureAlarm = verifyPush.info.TemperatureAlarm;
                pidLog.Nation = readData.Sea_GetNation(verifyPush.info.Nation);

                readData.SavePID(pidLog, ref GUID);//人证记录表
                if (GUID != "" && PhotoImage != null)
                {
                    readData.SavePIDPhoto(GUID, PhotoImage);
                }
            }
            readData.WriteTextFile(attLog, MacSN);
            if (textFormat.Allow) readData.WriteTextFormat(textFormat, attLog, MacSN);
            if (DevMode == 0 || DevMode == 1)
            {
                readData.SaveDB(attLog, MacSN, true, ref GUID);
                if (GUID != "")
                {
                    if (PhotoImage != null)
                        readData.SaveDBPhoto(GUID, PhotoImage);
                }
            }

            if (attLog.VerifyMode == 0 || (attLog.VerifyMode != 2 && attLog.VerifyMode != 3))
            {
                attLog.VerifyMode = attLog.DoorMode;
                attLog.VerifyModeName = attLog.DoorModeName;
            }

            readData.WriteTextFileMJ(attLog, MacSN);
            if (DevMode == 0 || DevMode == 2)
            {
                readData.SaveDBMJ(attLog, MacSN, true, ref GUID);
                if (GUID != "")
                {
                    if (PhotoImage != null)
                        readData.SaveDBPhotoMJ(GUID, PhotoImage);
                }
            }
            if (prog != null) prog(1, 1, MacSN, attLog, GUID, true);
        }

    }

    /// <summary>
    /// 返回确认信息
    /// </summary>
    public class ResponseHelper
    {
        private HttpListenerResponse response;
        private Stream OutputStream;
        public Stream _OutputStream
        {
            get { return OutputStream; }
            set { OutputStream = value; }
        }

        public ResponseHelper(HttpListenerResponse response)
        {
            this.response = response;
            OutputStream = response.OutputStream;
        }
      
        public void WriteToClient(int state)
        {
            response.StatusCode = 200;

            try
            {
                using (StreamWriter writer = new StreamWriter(OutputStream))
                {
                    response.Headers["response_code"] = "OK";
                    response.Headers["trans_id"] = "100";
                }
            }
            catch 
            {
               
            }
         
        }
    }
}
