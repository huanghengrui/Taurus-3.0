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
    public class StarHttpServer
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
            if (!stop)
                httpListener.BeginGetContext(new AsyncCallback(EndReciver), null);
        }

        void EndReciver(IAsyncResult ar)
        {
            if (!stop)
            {
                var context = httpListener.EndGetContext(ar);
                Dispather(context);
                Receive();
            }
        }

        StarRequestHelper RequestHelper;
        StarResponseHelper ResponseHelper;
        void Dispather(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            RequestHelper = new StarRequestHelper(request, label, prog, textFormat);
            ResponseHelper = new StarResponseHelper(response);
            RequestHelper.DispatchResources(state => { ResponseHelper.WriteToClient(state); });

        }

    }

    public class StarRequestHelper
    {
        private HttpListenerRequest request;
        private Label label;
        Taurus.FingerReadData.ProcessReadData prog;
        private FingerReadData readData = new FingerReadData("");
        private TFingerLog attLog = new TFingerLog();
        KQTextFormatInfo textFormat;
        string MacSN = "";
        string GUID = "";

        public StarRequestHelper(HttpListenerRequest request, Label label, Taurus.FingerReadData.ProcessReadData prog, KQTextFormatInfo textFormat)
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
                 if (request.Headers.Get("request_code").Contains("realtime_glog"))
                {
                    StreamReader sr = new StreamReader(request.InputStream);
                    string requestBody = sr.ReadToEnd();
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
                action.Invoke(405);
                return;
            }

            action.Invoke(404);
        }

        public void SaveFaceLog(string LogStr)
        {
            byte[] PhotoImage = null;
            string InOutMode = "";
            string VerifyStatus = "";
            int DevMode = 0;

            MonitoringLogs logs = JsonConvert.DeserializeObject<MonitoringLogs>(LogStr);

            MacSN = request.Headers.Get("dev_id");
            //获取设备模式
            DataTableReader dr = SystemInfo.db.GetDataReader("SELECT * FROM VDI_MacInfo WHERE MacSN='" + MacSN + "'");
            if (dr.Read())
            {
                Int32.TryParse(dr["DevModeID"].ToString(), out DevMode);
            }
            dr.Close();

            attLog = new TFingerLog();
            attLog.Remark = request.Headers.Get("Host");
            UInt32 FingerNo = Convert.ToUInt32(logs.userId);
           
            attLog.CardID = FingerNo.ToString("0000000000");
            attLog.CardTime = DateTime.Parse(readData.stringToTimeStr(logs.time));
            attLog.FingerNo = FingerNo;
            InOutMode = logs.inOut;
            if (logs.doorMode == null)
                attLog.DoorMode = 9;
            else
                attLog.DoorMode = readData.GetDoorMode(logs.doorMode); 
            VerifyStatus = logs.verifyMode;
            if(VerifyStatus!=null)
                attLog.VerifyMode = readData.GetVerifyModeID(VerifyStatus);
            attLog.InOut = readData.GetInOut(InOutMode);
            attLog.IoMode = logs.ioMode;
            readData.Star_SetLogName(attLog);
            bool IsKQ = readData.IsKQData(attLog);
            if (IsKQ)
            {
                readData.WriteTextFile(attLog, MacSN);
                if (textFormat.Allow) readData.WriteTextFormat(textFormat, attLog, MacSN);
                if (DevMode == 0 || DevMode == 1)
                {
                    readData.SaveDB(attLog, MacSN, true, ref GUID);
                    if (GUID != "" && PhotoImage != null)
                    {
                        readData.SaveDBPhoto(GUID, PhotoImage);
                    }
                }
              
            }
            else
            {
                if (attLog.VerifyMode == 0)
                {
                    attLog.VerifyMode = attLog.DoorMode;
                    attLog.VerifyModeName = attLog.DoorModeName;
                }
                readData.WriteTextFileMJ(attLog, MacSN);
                if (DevMode == 0 || DevMode == 2)
                {
                    readData.SaveDBMJ(attLog, MacSN, true, ref GUID);
                    if (GUID != "" && PhotoImage != null)
                    {
                        readData.SaveDBPhotoMJ(GUID, PhotoImage);
                    }
                }
              
            }
            if (IsKQ && attLog.DoorMode > 0)
            {
                attLog.VerifyMode = attLog.DoorMode;
                attLog.VerifyModeName = attLog.DoorModeName;

                if (DevMode == 0 || DevMode == 2)
                {
                    readData.SaveDBMJ(attLog, MacSN, true, ref GUID);
                    if (GUID != "" && PhotoImage != null)
                    {
                        readData.SaveDBPhotoMJ(GUID, PhotoImage);
                    }
                }
            }
       
            if (prog != null) prog(1, 1, MacSN, attLog, GUID, true);
        }
      
    }

    /// <summary>
    /// 返回确认信息
    /// </summary>
    public class StarResponseHelper
    {
        private HttpListenerResponse response;
        private Stream OutputStream;
        public Stream _OutputStream
        {
            get { return OutputStream; }
            set { OutputStream = value; }
        }

        public StarResponseHelper(HttpListenerResponse response)
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
