using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Reflection;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Win32;
using DevComponents.DotNetBar;

//using DAO = Microsoft.Office.Interop.Access.Dao;

namespace Taurus
{
    public struct SystemInfo
    {
        public static bool isInit = false;
        public static string AppPath = "";
        public static string ReportPath = "";
        public static string DataFilePath = "";
        public static string System32Path = "";
        public static string AppTitle = "";
        public static int DBType = 1;
        public static int ShowMJ = 1;
        public static int ShowKQ = 1;
        public static int ShowGZ = 1;
        public static int ShowSEA = 1;
        public static int ShowSTAR = 1;
        public static string ConnStr = "";
        public static string ConnStrReport = "";
        public static string AppVersion = "V3.0.0";
        public static string DBVersion = "";
        public static DateTime DBDate = new DateTime();
        public static DateTime SetTimer = new DateTime();
        public static List<TDIConnInfo> TimerOpen = null;
        public static string ComputerName = "";
        public static string NameSpace = "";
        public static string CommanyName = "";
        public static string CommanyID = "";
        public static string LangName = "";
        public static string CustomerName = "";
        public static string AccessDB = "";
        public static int Restart = 0;
        public static bool isclose = false;
        public static bool IsTimerOpen = false;
        public static bool IsZhNeutral = false;
        public static IniFile ini = null;
        public static LangRes res = null;
        public static IniFile webIni = null;
        public static Database db = null;
        public static ACCESS objAC = new ACCESS();
        public static ACCESS_KQ objACKQ = new ACCESS_KQ();
        
        public static ACCESS_GZ objACGZ = new ACCESS_GZ();

        public static SaveDataToDatabase saveDataToDatabase = new SaveDataToDatabase();

        public const string Encry = "yaoyuchen";
        public const string ReportRegister = "19B6T1BGD4W3";
        public const int MaxDeviceID = 255;
        public const int LANPort = 5005;
        public const uint MaxCardID = 0xffffffff;
        public const uint MaxCardID8 = 0xffffff;
        public static string SQLDateFMT = "yyyy-MM-dd";
        public static string SQLDateFM = "yyyy-MM";
        public static string SQLDateTimeFMT = "yyyy-MM-dd HH:mm:ss";
        public static string StarDateTimeFMT = "yyyyMMddHHmmss";
        public static string DateFormatDBVer = "yyyy.MM.dd";
        public static string SQLDateTMF = "dd-MM-yyyy";
        public static string SQLDateymd = "yyyyMMdd";
        public static string SQLDatehm = "HH:mm";
        public static string SQLDatehms = "H:mm:ss";
        public static string DateTimeFormat = "";
        public static string DateTimeFormatLog = "";
        public static string DateFormatLog = "";
        public static string YMFormat = "";
        public static string YMFormatDB = "";
        public static string YMFormatForm = "";
        public static string YMWFormatForm = "";
        public const int MacTypeID = 4;
        public static string CurrencySymbol = "";
        public static int MacSeriesTypeId = 0;

        public static string FingerPrivilegeGeneralUser = "";
        public static string FingerPrivilegeManager = "";
        public static string EmpSexMale = "";
        public static string EmpSexFemale = "";

        //自动导出txt记录
        public static bool IsZDTxtTime = true;
        public static bool IsZDTxtReal = true;
        public static string ZDTxtTime = "";
        public static string ZDTxtPath = "";

        public static bool SystemIsExit = true;
        public static bool IsMacNomber = false;
        public static bool isAttendancePhoto = false;
        public static bool IsWarning = false;

        public static IntPtr MainHandle;

        public static bool IsRestart = false;

        public static List<FuncObject> funcList = new List<FuncObject>();

        public static bool AllowInOutMode = false;
        public static bool AllowMJ = false;
        public static bool AllowGZ = false;
        public static bool AllowSEA = false;
        public static bool AllowSTAR = false;
        public static bool AllowAdjust = true;

        public static int RegularPort = 7005;
        public static int SeaPort = 8080;
        public static int StarPort = 8001;

        public static List<string> sqlList = new List<string>();

        public static List<string> langList = new List<string>()
    {
      "CHS", "CHT", "JPN", "KOR", "DEU", "RUS", "FRA", "ESN", "SQI", "ARG", "AZE", "ETI", "EUQ", "BGR",
      "BEL", "ISL", "PLK", "TTT", "DAN", "DIV", "FOS", "FAR", "SAN", "FIN", "KAT", "GUJ", "KKZ", "NLD",
      "KYR", "GLC", "CAT", "CSY", "KAN", "HRV", "KNK", "LVI", "LTH", "ROM", "MAR", "MSL", "MKI", "MON",
      "AFK", "NOR", "PAN", "PTG", "SVE", "SRL", "SKY", "SLV", "SWK", "TEL", "TAM", "THA", "TRK", "URD",
      "UKR", "UZB", "HEB", "ELL", "HUN", "SYR", "HYE", "ITA", "HIN", "IND", "VIT", "ENG",
    };
        public static string[] AppTitleLNG = new string[langList.Count];
    }

    public struct DBServerInfo
    {
        public static string ServerName = "";
        public static bool WindowsNT = true;
        public static string UserName = "";
        public static string UserPass = "";
    }

    public struct OprtInfo
    {
        public static string OprtNo = "";
        public static bool OprtIsSys = false;
        public static string OprtNoAndName = "";
    }

    public struct RegisterInfo
    {
        public static string ProductName = "Taurus(HYSOON)";
        public static string Serial = "";
        public static bool MustReg = false;
        public static bool IsReg = false;
        public static bool IsAlways = false;
        public static bool IsTest = false;
        public static bool IsValid = false;
        public static string RegUser = "";
        public static string RegKey = "";
        public static string StateText = "";
        public static DateTime StartDate;
        public static DateTime EndDate;
        public static DateTime ValidDate;
        public static string RegDateText = "";
    }

    public struct SHFileInfo
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttribs;
        [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
        public string pszDisplayName;
        [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
        public string pszTypeName;
    };

    public struct MacConnTypeString
    {
        public const string USB = "USB";
        public const string Comm = "RS232/485";
        public const string LAN = "LAN";
    }

    public struct DeviceObject
    {
        public static HSCPID.CPIC objCPIC = new HSCPID.CPIC();
        public static HSCPID.AES objAES = new HSCPID.AES();
        public static HSCPID.DES objDES = new HSCPID.DES();
        public static FK623Attend objFK623 = new FK623Attend();
        public static SocKetClient socKetClient = new SocKetClient();
    }

    public enum SHGFI
    {
        SmallIcon = 0x00000001,
        LargeIcon = 0x00000000,
        ICON = 0x000000100,
        DISPLAYNAME = 0x000000200,
        TYPENAME = 0x000000400,
        SysIconIndex = 0x00004000,
        UseFileAttributes = 0x00000010
    }

    public enum DateInterval
    {
        Milliseconds, Second, Minute, Hour, Day, Week, Month, Quarter, Year
    }

    public enum DBCode
    {
        DB_000001, //系统
        DB_000002, //系统权限
        DB_000100, //部门
        DB_000101, //人员
        DB_000102, //离职
        DB_000200, //考勤规则
        DB_000201, //计算规则
        DB_000202, //人员考勤规则
        DB_000203, //部门考勤规则
        DB_000204, //班次定义
        DB_000205, //排班规律
        DB_000206, //个人排班表建立
        DB_000207, //部门排班表建立
        DB_000208, //考勤规则及排班情况查询
        DB_000209, //假日登记
        DB_000210, //请假登记
        DB_000211, //加班登记
        DB_000212, //手工签卡
        DB_000213, //考勤数据分析
        DB_000214, //考勤原始记录表
        DB_000215, //考勤刷卡记录表
        DB_000216, //考勤日报表
        DB_000217, //考勤月报表
        DB_000218, //考勤统计表
        DB_000219, //考勤月记录表
        DB_000300, //设备管理
        DB_000400, //薪资项目设置
        DB_000401, //薪资规则设置
        DB_000402, //个人薪资规则设置
        DB_000403, //部门薪资规则设置
        DB_000404, //工资表管理
        DB_000500  //海系列
    }

    public class ListToDatatable
    {
        public ListToDatatable() { }
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {

            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                return new DataTable();
            }

            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable("dt");
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }

            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);

                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }
    }

    public class Base
    {
        private static MSSQL objMS = new MSSQL();
        private static frmMessage frmMsg = null;
        private static frmException frmErr = null;
        private static frmDBPathSelect DBPathSelect = null;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern IntPtr SendMessageA(IntPtr hwnd, int wMsg, StringBuilder wParam, StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern IntPtr SendMessageB(IntPtr hwnd, int wMsg, IntPtr wParam, StringBuilder lParam);
        public int SendMessage(IntPtr hwnd, int wMsg, StringBuilder wParam, StringBuilder lParam)
        {
            IntPtr ptr = SendMessageA(hwnd, wMsg, wParam, lParam);
            int ret = Convert.ToInt32(PtrToString(ptr));
            return ret;
        }
        public int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, StringBuilder lParam)
        {
            IntPtr ptr = SendMessageB(hwnd, wMsg, wParam, lParam);
            int ret = Convert.ToInt32(PtrToString(ptr));
            return ret;
        }

        public string PtrToString(IntPtr Ptr)
        {
            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(Ptr);
        }

        public IntPtr StringToPtr(string src)
        {
            return System.Runtime.InteropServices.Marshal.StringToBSTR(src);
        }

        public bool IsNumeric(string str)
        {
            if (str == null) str = "";
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg.IsMatch(str);
        }

        public string GetWGCardNo(byte[] CardNo)
        {
            long a = 0;

            string card = string.Format("{0:X8}", Convert.ToInt64(Convert.ToInt64(Encoding.Default.GetString(CardNo)).ToString("0000000000")));
            if (SystemInfo.db.ReadConfig("SystemInfo", "Isrb26", false))
                card = card.Substring(2, card.Length - 2);
            a = Convert.ToInt64(card, 16);
            return a.ToString();
        }

        public string ValidatTime(string str)
        {
            string ret = "";
            string[] tmp = str.Split(':');
            if (tmp.Length >= 2)
            {
                if (tmp[0].Trim() == "")
                    tmp[0] = "00";
                else if (tmp[0].Trim().Length == 1)
                    tmp[0] = "0" + tmp[0].Trim();
                if (tmp[1].Trim() == "")
                    tmp[1] = "00";
                else if (tmp[1].Trim().Length == 1)
                    tmp[1] = tmp[1].Trim() + "0";
                ret = tmp[0] + ":" + tmp[1];
            }
            else
                ret = "00:00";
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(ret, out dt)) ret = "00:00";
            return ret;
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        private static extern int GetWindowText(int hwnd, StringBuilder lpString, int cch);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetActiveWindow();
        public string GetWindowTitle()
        {
            StringBuilder s = new StringBuilder(1024);
            IntPtr activeWindow = GetActiveWindow();
            int i = GetWindowText(activeWindow.ToInt32(), s, s.Capacity);
            return s.ToString();
        }

        public string GetFileNamePath(string FileName)
        {
            FileName = FileName.Replace("/", "\\");
            string ret = "";
            string[] tmp = FileName.Split('\\');
            for (int i = 0; i < tmp.Length - 1; i++)
            {
                ret = ret + tmp[i] + "\\";
            }
            return ret;
        }

        public string GetFileName(string FileName)
        {
            FileName = FileName.Replace("/", "\\");
            string ret = "";
            string[] tmp = FileName.Split('\\');
            ret = tmp[tmp.Length - 1];
            return ret;
        }

        public string GetFileNameExt(string FileName)
        {
            string ret = GetFileName(FileName);
            string[] tmp = FileName.Split('.');
            ret = tmp[tmp.Length - 1];
            return ret;
        }

        public string GetFileTimeString(string fileName)
        {
            DateTime dt = GetFileTime(fileName);
            return dt.ToString();
        }

        public DateTime GetFileTime(string fileName)
        {
            DateTime dt = File.GetLastWriteTime(fileName);
            return dt;
        }

        public void WriteTextFile(string FileName, string Text)
        {
            string path = GetFileNamePath(FileName);
            StreamWriter writer = null;
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                if (File.Exists(FileName))
                    writer = new StreamWriter(FileName, true);
                else
                    writer = new StreamWriter(FileName);
                writer.WriteLine(Text);
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        public void ShowErrorMsg(Exception E)
        {
            ShowErrorMsg(E, "");
        }

        public bool FindMJInfo(string date, string MacSNn, string EmpNoo)
        {
            DataTableReader dr = null;
            bool ret = false;
            dr = SystemInfo.db.GetDataReader(GetSQL(DBCode.DB_000300, new string[] { "701", MacSNn, EmpNoo }));
            if (dr.Read())
            {
                string fGUID = dr["GUID"].ToString();
                SystemInfo.db.ExecSQL(GetSQL(DBCode.DB_000300, new string[] { "702", fGUID }));
            }
            return ret;
        }
        public void ShowErrorMsg(Exception E, string Other)
        {
            string time = DateTime.Now.ToString(SystemInfo.DateTimeFormat);
            string src = GetResText("", "ErrorSource", "") + E.Source;
            string inf = E.StackTrace;
            string msg = GetResText("", "ErrorMessage", "") + E.Message;
            //WriteTextFile(SystemInfo.AppPath + "Error.log", "[" + time + "] " + Application.ExecutablePath + "\r\n" +
            //src + "\r\n" + inf + "\r\n" + msg + "\r\n");
            if (frmErr == null) frmErr = new frmException();
            if (Other != "") Other = "\r\n\r\n" + Other;
            frmErr.InitErrorMessage(E.Message + "\r\n" + Other);
            frmErr.ShowDialog();
            frmErr = null;
        }

        public void ShowErrorMsg(Exception E, List<string> Other)
        {
            string tmp = "";
            for (int i = 0; i < Other.Count; i++)
            {
                tmp = tmp + Other[i] + "\r\n";
            }
            ShowErrorMsg(E, tmp);
        }

        public void MessageBoxShow(string Msg)
        {
            MessageBoxShow(Msg, MessageBoxIcon.Exclamation);
        }

        public void MessageBoxShow(string Msg, MessageBoxIcon Icon)
        {
            string Title = SystemInfo.AppTitle;
            if (Title == "") Title = GetWindowTitle().ToString();
            MessageBoxEx.Show(Msg, Title, MessageBoxButtons.OK, Icon);
        }

        public bool MessageBoxShowQuestion(string Msg)
        {
            return MessageBoxShowQuestion(Msg, MessageBoxIcon.Question);
        }

        public bool MessageBoxShowQuestion(string Msg, MessageBoxIcon Icon)
        {
            string Title = SystemInfo.AppTitle;
            if (Title == "") Title = GetWindowTitle().ToString();
            return MessageBoxEx.Show(Msg, Title, MessageBoxButtons.YesNo, Icon,
              MessageBoxDefaultButton.Button2) == DialogResult.No;
        }

        public DialogResult MessageBoxQuestion(string Msg)
        {
            return MessageBoxQuestion(Msg, MessageBoxButtons.YesNoCancel);
        }

        public DialogResult MessageBoxQuestion(string Msg, MessageBoxButtons BoxButtons)
        {
            string Title = SystemInfo.AppTitle;
            if (Title == "") Title = GetWindowTitle().ToString();
            return MessageBoxEx.Show(Msg, Title, BoxButtons, MessageBoxIcon.Question);
        }

        public int GetTextLength(string Text)
        {
            int ret = 0;
            int a;
            for (int i = 0; i < Text.Length; i++)
            {
                a = Convert.ToInt32(Text[i]);
                if ((a < 0) || (a > 255)) ret = ret + 2; else ret = ret + 1;
            }
            return ret;
        }

        public bool CheckTextMaxLength(string LabelText, string Text, int MaxLength)
        {
            int size = GetTextLength(Text);
            bool ret = ((MaxLength == 0) || (MaxLength == 32767) ||
              ((MaxLength > 0) && (MaxLength < 32767) & (size <= MaxLength)));
            if (!ret) MessageBoxShow(string.Format(GetResText("Public", "ErrorOutrideMaxLength", ""), size, MaxLength));
            return ret;
        }

        public bool ShowMessageDialog(string MsgText, string MsgFlag)
        {
            bool ret = false;
            if (frmMsg == null) frmMsg = new frmMessage();
            frmMsg.MsgText = MsgText;
            frmMsg.MsgFlag = MsgFlag;
            ret = (frmMsg.ShowDialog() == DialogResult.OK);
            frmMsg = null;
            return ret;
        }

        public void ShowMessageForm(string MsgText)
        {
            if (frmMsg == null) frmMsg = new frmMessage();
            frmMsg.MsgText = MsgText;
            frmMsg.Show();
            Application.DoEvents();
        }

        public void FreeMessageForm()
        {
            if (frmMsg != null) frmMsg.Close();
            frmMsg = null;
        }

        public string GetMSSQLConnStr(string ServerName, bool WindowsNT, string UserName, string UserPass,
          string DBName)
        {
            if (WindowsNT)
                return string.Format("Trusted_Connection=true;Server={0};Database={1};Pooling=False", ServerName, DBName);
            else
                return string.Format("Trusted_Connection=false;Server={0};Database={1};uid={2};pwd={3};Pooling=False",
                  ServerName, DBName, UserName, UserPass);
        }

        public string GetMSSQLConnStrReport(string ServerName, bool WindowsNT, string UserName, string UserPass)
        {
            if (WindowsNT)
                return string.Format("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;" +
                  "Data Source={0};Initial Catalog={1}", ServerName, SystemInfo.NameSpace);
            else
                return string.Format("Provider=SQLOLEDB.1;Persist Security Info=True;Data Source={0};" +
                  "Initial Catalog={1};User ID={2};Password={3}", ServerName, SystemInfo.NameSpace, UserName, UserPass);
        }

        public string GetACCESSConnStr()
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SystemInfo.AccessDB;
        }

        public string GetACCESSConnStrReport()
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SystemInfo.AccessDB;
        }

        public string GetSQL(DBCode code, string[] Param)
        {
            return GetSQL(code, Param, SystemInfo.DBType);
        }

        public string GetSQL(DBCode code, string[] Param, int DBType)
        {
            string ret = "";
            switch (DBType)
            {
                case 0:
                    ret = SystemInfo.objAC.GetSQL(code, Param);
                    break;
                case 1:
                case 2:
                    ret = objMS.GetSQL(code, Param);
                    break;
            }
            return ret;
        }

        public string SelectDBPath(bool OnlyPath, bool UseLocal, string DefPath)
        {
            string ret = "";
            if (DBPathSelect == null) DBPathSelect = new frmDBPathSelect();
            DBPathSelect.OnlyPath = OnlyPath;
            DBPathSelect.SelectItemName = DefPath;
            DBPathSelect.UseLocal = UseLocal;
            if (DBPathSelect.ShowDialog() == DialogResult.OK) ret = DBPathSelect.SelectItemName;
            DBPathSelect = null;
            return ret;
        }

        public string SelectDBPath(bool OnlyPath, string DefPath)
        {
            return SelectDBPath(OnlyPath, SystemInfo.DBType == 0, DefPath);
        }

        public void SetFormAppIcon(Form frm)
        {
            frm.Icon = Taurus.Properties.Resources.favicon;
        }
        public void SetFormAppIcon(Office2007Form frm)
        {
            frm.Icon = Taurus.Properties.Resources.favicon;
        }

        public void SetFormAppIcon(OfficeForm frm)
        {
            frm.Icon = Taurus.Properties.Resources.favicon;
        }
        [DllImport("kernel32.dll")]
        static extern bool GetComputerName(IntPtr p, ref int lpnSize);
        public string GetComputerName()
        {
            IntPtr p = Marshal.AllocHGlobal(256);
            int len = 256;
            GetComputerName(p, ref len);
            return PtrToString(p);
        }

        public string GetOprtEncrypt(string src)
        {
            string ret = src;
            ret = DeviceObject.objAES.AesEncrypt(ret, SystemInfo.Encry);
            if (ret == null) ret = "";
            return ret;
        }

        public string GetOprtDecrypt(string src)
        {
            string ret = "";
            ret = DeviceObject.objAES.AesDecrypt(src, SystemInfo.Encry);
            if (ret == null) ret = "";
            return ret;
        }

        public string GetAesEncrypt(string src, string key)
        {
            string ret = src;
            if (src != "")
            {
                ret = DeviceObject.objAES.AesEncrypt(ret, key);
                if (ret == null) ret = "";
            }
            return ret;
        }

        public string GetAesDecrypt(string src, string key)
        {
            string ret = "";
            if (src != "")
            {
                ret = DeviceObject.objAES.AesDecrypt(src, key);
                if (ret == null) ret = "";
            }
            return ret;
        }

        public void InitCommList(System.Windows.Forms.ComboBox cbb)
        {
            cbb.Items.Clear();
            RegistryKey Key;
            Key = Registry.LocalMachine;
            const string Key_Comm = "HARDWARE\\DEVICEMAP\\SERIALCOMM";
            Key = Key.OpenSubKey(Key_Comm);
            TCommPort commPort;
            string tmp = "";
            if (Key != null)
            {
                string[] ValueNames = Key.GetValueNames();
                string CommName, S;
                int CommIndex;
                for (int i = 0; i < ValueNames.Length; i++)
                {
                    CommName = Key.GetValue(ValueNames[i]).ToString().Trim();
                    tmp = CommName.Substring(CommName.Length - 1);
                    while (tmp != "" && !IsNumeric(tmp))
                    {
                        CommName = CommName.Substring(0, CommName.Length - 1);
                        tmp = CommName.Substring(CommName.Length - 1);
                    }
                    if (CommName != "")
                    {
                        S = CommName.Substring(3);
                        CommIndex = Convert.ToInt32(S);
                        if (CommIndex > 10) CommName = "\\\\.\\" + CommName;
                        commPort = new TCommPort(CommIndex, CommName);
                        cbb.Items.Add(commPort);
                    }
                }
                Key.Close();
                Key = null;
            }
            if (cbb.Items.Count == 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    commPort = new TCommPort(i, "COM" + i.ToString());
                    cbb.Items.Add(commPort);
                }
            }
        }

        public string GetTempPathFileName(string fileName)
        {
            string tempPath = Path.GetTempPath();
            fileName = tempPath + Path.GetFileName(fileName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            string fileExt = Path.GetExtension(fileName);
            int i = 0;
            while (File.Exists(fileName))
            {
                fileName = tempPath + fileNameWithoutExt + string.Format("({0})", ++i) + fileExt;
            }
            return fileName;
        }

        public bool GetSelectDate(bool ShowTime, ref DateTime SelectDate)
        {
            frmPubSelectDate frm = new frmPubSelectDate(ShowTime, SelectDate);
            bool ret = frm.ShowDialog() == DialogResult.OK;
            if (ret) SelectDate = frm.SelectDateTime;
            return ret;
        }

        public long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate)
        {
            long lngDateDiffValue = 0;
            System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (Interval)
            {
                case DateInterval.Milliseconds:
                    lngDateDiffValue = (long)TS.TotalMilliseconds;
                    break;
                case DateInterval.Second:
                    lngDateDiffValue = (long)TS.TotalSeconds;
                    break;
                case DateInterval.Minute:
                    lngDateDiffValue = (long)TS.TotalMinutes;
                    break;
                case DateInterval.Hour:
                    lngDateDiffValue = (long)TS.TotalHours;
                    break;
                case DateInterval.Day:
                    lngDateDiffValue = (long)TS.Days;
                    break;
                case DateInterval.Week:
                    lngDateDiffValue = (long)(TS.Days / 7);
                    break;
                case DateInterval.Month:
                    lngDateDiffValue = (long)(TS.Days / 30);
                    break;
                case DateInterval.Quarter:
                    lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;
                case DateInterval.Year:
                    lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            }
            return (lngDateDiffValue);
        }

        public string GetDateDiffTimes(System.DateTime StartDate, System.DateTime EndDate)
        {
            return GetDateDiffTimes(StartDate, EndDate, false);
        }

        public string GetDateDiffTimes(System.DateTime StartDate, System.DateTime EndDate, bool HideText)
        {
            long Milliseconds = DateDiff(DateInterval.Milliseconds, StartDate, EndDate);
            string ret = "";
            long sec = Milliseconds / 1000;
            long hour = sec / 3600;
            sec = sec % 3600;
            long minute = sec / 60;
            sec = sec % 60;
            Milliseconds = Milliseconds % 1000;
            ret = string.Format("{0}:{1}:{2}.{3}", hour, minute, sec, Milliseconds);
            if (!HideText) ret = GetResText("Public", "ExecTimes", "") + ret;
            return ret;
        }

        public string GetResText(string Code, string ID, string Def)
        {
            string ret = "";
            try
            {
                ret = SystemInfo.res.GetResText(Code, ID, Def);
            }
            catch
            {
            }
            return ret;
        }

        public string GetResText(string Code, string ID, string Def, string[] Codes)
        {
            return SystemInfo.res.GetResText(Code, ID, Def, Codes);
        }

        public frmMain GetAppMainForm()
        {
            frmMain frm = null;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "frmMain")
                {
                    frm = (frmMain)Application.OpenForms[i];
                    break;
                }
            }
            return frm;
        }

        [DllImport("shell32")]
        private static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);
        [StructLayout(LayoutKind.Sequential)]
        private struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            public string lpVerb;
            public string lpFile;
            public string lpParameters;
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr IDList;
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }
        [DllImport("Kernel32.dll ")]
        private static extern int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);
        public void ExpandFile(string fileName, string path)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
                info.cbSize = Marshal.SizeOf(info);
                info.lpVerb = "open";
                info.lpFile = "expand.exe";
                info.lpDirectory = path;
                if (path.Substring(path.Length - 1, 1) == "\\") path = path.Substring(0, path.Length - 1);
                info.lpParameters = "-F:* \"" + fileName + "\" \"" + path + "\"";
                info.fMask = 67142464;
                ShellExecuteEx(ref info);
                if (info.hProcess != new IntPtr(0))
                {
                    WaitForSingleObject(info.hProcess, 0xFFFFFFFF);
                    CloseHandle(info.hProcess);
                }
            }
            catch (Exception E)
            {
                ShowErrorMsg(E);
            }
        }

        public bool ExecuteFile(string fileName, string path, string param)
        {
            bool ret = false;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.WorkingDirectory = path;
                proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proc.StartInfo.Verb = "open";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.Start();
                string cmdLine = "\"" + fileName + "\" " + param + "\r\nExit";
                proc.StandardInput.WriteLine(cmdLine);
                proc.BeginErrorReadLine();
                proc.WaitForExit();
                ret = true;
            }
            catch (Exception E)
            {
                ShowErrorMsg(E);
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return ret;
        }

        public uint RGBToOleColor(byte r, byte g, byte b)
        {
            return ((uint)b) * 256 * 256 + ((uint)g) * 256 + r;
        }

        public uint ColorToOleColor(System.Drawing.Color val)
        {
            return RGBToOleColor(val.R, val.G, val.B);
        }

        public bool ValueToBool(object value)
        {
            bool ret = (value.ToString() == "1") || (value.ToString().ToLower() == "true");
            return ret;
        }

        public string GetObjFileName(string objName)
        {
            string ret = "";
            RegistryKey root = Registry.ClassesRoot;
            RegistryKey clsid = root.OpenSubKey(objName + "\\Clsid", false);
            string v = clsid.GetValue("").ToString();
            clsid.Close();
            if (v != "")
            {
                clsid = root.OpenSubKey("CLSID\\" + v + "\\InprocServer32", false);
                ret = clsid.GetValue("").ToString();
            }
            return ret;
        }

        public string GetObjFilePath(string objName)
        {
            string ret = "";
            RegistryKey root = Registry.ClassesRoot;
            RegistryKey clsid = root.OpenSubKey(objName + "\\Clsid", false);
            string v = clsid.GetValue("").ToString();
            clsid.Close();
            if (v != "")
            {
                clsid = root.OpenSubKey("CLSID\\" + v + "\\InprocServer32", false);
                ret = clsid.GetValue("").ToString();
                ret = GetFileNamePath(ret);
            }
            return ret;
        }

        [DllImport("kernel32.dll")]
        private static extern void CopyMemory(byte[] Destination, int[] Source, int Size);
        [DllImport("kernel32.dll")]
        private static extern void CopyMemory(int[] Destination, byte[] Source, int Size);
        public void MemoryCopy(byte[] Destination, int[] Source, int Size)
        {
            int len = Size;
            if (len > Destination.Length) len = Destination.Length;
            CopyMemory(Destination, Source, Size);
        }
        public void MemoryCopy(int[] Destination, byte[] Source, int Size)
        {
            int len = Size;
            if (len > Destination.Length * 4) len = Destination.Length * 4;
            CopyMemory(Destination, Source, Size);
        }

        public void CardNo10ToCardNo8(ref string CardNo10, ref string CardNo81, ref string CardNo82)
        {
            UInt32 tmp = Convert.ToUInt32(CardNo10);
            CardNo10 = tmp.ToString("0000000000");
            string tmpS = Convert.ToString(tmp, 16);
            tmpS = "00000000" + tmpS;
            tmpS = tmpS.Substring(tmpS.Length - 8);
            CardNo81 = Convert.ToUInt32("0x" + tmpS.Substring(2), 16).ToString("00000000");
            CardNo82 = Convert.ToUInt32("0x" + tmpS.Substring(2, 2), 16).ToString("000") +
              Convert.ToUInt32("0x" + tmpS.Substring(4), 16).ToString("00000");
        }

        public TDIConnInfo ValueToDIConnInfo(int MacSN, string MacSN_GPRS, string MacConnType, string MacIP,
          string MacPort, string MacConnPWD, bool IsGPRS,int MacSeriesTypeId,string SeaSeriesPwd,string MacSeriesUserName)
        {
            TDIConnInfo connInfo = new TDIConnInfo();
            connInfo.MacSeriesTypeId = MacSeriesTypeId;
            connInfo.MacSN = MacSN;
            connInfo.MacSN_GPRS = MacSN_GPRS;
            connInfo.MacType = SystemInfo.MacTypeID;
            connInfo.CommPort = "";
            connInfo.CommBaudRate = 0;
            connInfo.NetHost = "";
            connInfo.NetPassword = 0;
            connInfo.IsGPRS = IsGPRS;
            connInfo.SeaSeries_Pwd = SeaSeriesPwd;
            connInfo.MacSeriesUserName = MacSeriesUserName;
            if (MacConnType.ToUpper() == MacConnTypeString.USB)
                connInfo.ConnType = 0;
            else if (MacConnType.ToUpper() == MacConnTypeString.Comm)
            {
                connInfo.ConnType = 1;
                connInfo.CommPort = MacPort;
                connInfo.CommBaudRate = Convert.ToInt32(MacConnPWD);
            }
            else if (MacConnType.ToUpper() == MacConnTypeString.LAN)
            {
                connInfo.ConnType = 2;
                connInfo.NetHost = MacIP;
                connInfo.NetPort = Convert.ToInt32(MacPort);
                if (IsNumeric(MacConnPWD)) connInfo.NetPassword = Convert.ToInt32(MacConnPWD);
            }
            return connInfo;
        }

        public bool ShowSelectEmpList(string Title, string OtherCoin, ref DataTable selList)
        {
            frmPubSelectEmpList frm = new frmPubSelectEmpList(Title, OtherCoin);
            bool ret = frm.ShowDialog() == DialogResult.OK;
            if (ret) selList = frm.dtData;
            return ret;
        }

        public string ByteToHex(byte b)
        {
            string ret = Convert.ToString(b, 16);
            while (ret.Length < 2) ret = "0" + ret;
            ret = ret.ToUpper();
            return ret;
        }

        public string EnrollByteToString(byte[] bytes)
        {
            return EnrollByteToString(bytes, false);
        }

        public string EnrollByteToString(byte[] bytes, bool AddSpace)
        {
            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += ByteToHex(bytes[i]);
                if (AddSpace) ret += " ";
            }
            return ret.Trim();
        }

        public int ByteToInt(byte[] src)
        {
            int ret = 0;
            byte b = 0;
            for (int i = 0; i < 4; i++)
            {
                b = src[i];
                ret += (b & 0xff) << (i * 8);
            }
            return ret;
        }

        public byte[] IntToByte(int src)
        {
            byte[] ret = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                ret[i] = (byte)(src >> i * 8 & 0xff);
            }
            return ret;
        }

        public bool CheckCardExists()
        {
            byte IDCardDevice = SystemInfo.ini.ReadIni("Public", "IDCardDevice", (byte)0);
            DeviceObject.objCPIC.IDCardType = IDCardDevice;
            return DeviceObject.objCPIC.CardIsExists();
        }

        public bool GetCardNo(ref string CardNo)
        {
            string CH = "";
            string C8 = "";
            byte IDCardDevice = SystemInfo.ini.ReadIni("Public", "IDCardDevice", (byte)0);
            DeviceObject.objCPIC.IDCardType = IDCardDevice;
            bool ret = DeviceObject.objCPIC.GetCardData(ref CardNo, ref CH, ref C8);
            if (ret) DeviceObject.objCPIC.Buzzer(1);
            return ret;
        }

        public void IDCardInit()
        {
            DeviceObject.objCPIC.IDCardInit();
        }

        public bool IDCardGet(ref string EmpName, ref byte EmpSexNum, ref string EmpIDCard, ref string EmpAddress, ref string EmpPhotoPath)
        {
            string EmpSex = "";
            string EmpNation = "";
            string EmpIssued = "";
            string EmpNewAddr = "";
            DateTime EmpBorn = new DateTime();
            DateTime EmpValidStart = new DateTime();
            DateTime EmpValidEnd = new DateTime();
            byte IDCardDevice = SystemInfo.ini.ReadIni("Public", "IDCardDevice", (byte)0);
            byte IDCardPort = SystemInfo.ini.ReadIni("Public", "IDCardDevice", (byte)0);
            return DeviceObject.objCPIC.IDCardGet(SystemInfo.AppPath, IDCardDevice, IDCardPort, ref EmpName, ref EmpSex, ref EmpNation, ref EmpAddress,
              ref EmpIDCard, ref EmpIssued, ref EmpNewAddr, ref EmpSexNum, ref EmpBorn, ref EmpValidStart, ref EmpValidEnd, ref EmpPhotoPath);
        }

        public void IDCardFree()
        {
            DeviceObject.objCPIC.IDCardFree();
        }

        public System.Globalization.CultureInfo InitLangName()
        {
            System.Globalization.CultureInfo UICulture = null;
            switch (Application.CurrentCulture.LCID)
            {
                case 0x804://简体中文
                    UICulture = new System.Globalization.CultureInfo("zh-CN");
                    SystemInfo.LangName = "CHS";
                    break;
                case 0x404://繁体中文
                case 0x0c04:
                case 0x1004:
                case 0x1404:
                    UICulture = new System.Globalization.CultureInfo("zh-TW");
                    SystemInfo.LangName = "CHT";
                    break;
                case 0x0411: //日语
                    UICulture = new System.Globalization.CultureInfo("ja-JP");
                    SystemInfo.LangName = "JPN";
                    break;
                case 0x0412: //朝鲜语
                    UICulture = new System.Globalization.CultureInfo("ko-KR");
                    SystemInfo.LangName = "KOR";
                    break;
                case 0x0c07://德语
                case 0x0407:
                case 0x1407:
                case 0x1007:
                case 0x0807:
                    UICulture = new System.Globalization.CultureInfo("de-DE");
                    SystemInfo.LangName = "DEU";
                    break;
                case 0x0419: //俄语
                    UICulture = new System.Globalization.CultureInfo("ru-RU");
                    SystemInfo.LangName = "RUS";
                    break;
                case 0x080c://法语
                case 0x040c:
                case 0x0c0c:
                case 0x140c:
                case 0x180c:
                case 0x100c:
                    UICulture = new System.Globalization.CultureInfo("fr-FR");
                    SystemInfo.LangName = "FRA";
                    break;
                case 0x2c0a://西班牙语
                case 0x3c0a:
                case 0x180a:
                case 0x500a:
                case 0x400a:
                case 0x040a:
                case 0x1c0a:
                case 0x300a:
                case 0x240a:
                case 0x140a:
                case 0x0c0a:
                case 0x480a:
                case 0x280a:
                case 0x080a:
                case 0x4c0a:
                case 0x440a:
                case 0x100a:
                case 0x200a:
                case 0x380a:
                case 0x340a:
                    UICulture = new System.Globalization.CultureInfo("es-ES");
                    SystemInfo.LangName = "ESN";
                    break;
                case 0x041c://阿尔巴尼亚语
                    SystemInfo.LangName = "SQI";
                    break;
                case 0x1401://阿拉伯语
                case 0x3801:
                case 0x2001:
                case 0x0c01:
                case 0x3c01:
                case 0x4001:
                case 0x3401:
                case 0x3001:
                case 0x1001:
                case 0x1801:
                case 0x0401:
                case 0x1c01:
                case 0x2801:
                case 0x2401:
                case 0x0801:
                case 0x2c01:
                    UICulture = new System.Globalization.CultureInfo("ar-DZ");
                    SystemInfo.LangName = "ARG";
                    break;
                case 0x042c://阿塞拜疆语
                case 0x082c:
                    UICulture = new System.Globalization.CultureInfo("az-AZ-Cyrl");
                    SystemInfo.LangName = "AZE";
                    break;
                case 0x0425: //爱沙尼亚语
                    UICulture = new System.Globalization.CultureInfo("et-EE");
                    SystemInfo.LangName = "ETI";
                    break;
                case 0x042d://巴斯克语
                    UICulture = new System.Globalization.CultureInfo("eu-ES");
                    SystemInfo.LangName = "EUQ";
                    break;
                case 0x0402: //保加利亚语
                    UICulture = new System.Globalization.CultureInfo("bg-BG");
                    SystemInfo.LangName = "BGR";
                    break;
                case 0x0423: //比利时语
                    UICulture = new System.Globalization.CultureInfo("nl-NL");
                    SystemInfo.LangName = "BEL";
                    break;
                case 0x040f: //冰岛语
                    UICulture = new System.Globalization.CultureInfo("is-IS");
                    SystemInfo.LangName = "ISL";
                    break;
                case 0x0415: //波兰语
                    UICulture = new System.Globalization.CultureInfo("pl-PL");
                    SystemInfo.LangName = "PLK";
                    break;
                case 0x0444: //鞑靼语
                    UICulture = new System.Globalization.CultureInfo("tt-RU");
                    SystemInfo.LangName = "TTT";
                    break;
                case 0x0406: //丹麦语
                    UICulture = new System.Globalization.CultureInfo("da-DK");
                    SystemInfo.LangName = "DAN";
                    break;
                case 0x0465: //第维埃语
                    UICulture = new System.Globalization.CultureInfo("div-MV");
                    SystemInfo.LangName = "DIV";
                    break;
                case 0x0438: //法罗语
                    UICulture = new System.Globalization.CultureInfo("fo-FO");
                    SystemInfo.LangName = "FOS";
                    break;
                case 0x0429: //波斯语
                    UICulture = new System.Globalization.CultureInfo("fa-IR");
                    SystemInfo.LangName = "FAR";
                    break;
                case 0x044f: //梵语
                    UICulture = new System.Globalization.CultureInfo("sa-IN");
                    SystemInfo.LangName = "SAN";
                    break;
                case 0x040b: //芬兰语
                    UICulture = new System.Globalization.CultureInfo("fi-FI");
                    SystemInfo.LangName = "FIN";
                    break;
                case 0x0437: //格鲁吉亚语
                    UICulture = new System.Globalization.CultureInfo("ka-GE");
                    SystemInfo.LangName = "KAT";
                    break;
                case 0x0447: //古吉拉特语
                    UICulture = new System.Globalization.CultureInfo("gu-IN");
                    SystemInfo.LangName = "GUJ";
                    break;
                case 0x043f: //哈萨克语
                    UICulture = new System.Globalization.CultureInfo("kk-KZ");
                    SystemInfo.LangName = "KKZ";
                    break;
                case 0x0813://荷兰语
                case 0x0413:
                    UICulture = new System.Globalization.CultureInfo("nl-NL");
                    SystemInfo.LangName = "NLD";
                    break;
                case 0x0440: //吉尔吉斯语
                    UICulture = new System.Globalization.CultureInfo("ky-KG");
                    SystemInfo.LangName = "KYR";
                    break;
                case 0x0456: //加里西亚语
                    UICulture = new System.Globalization.CultureInfo("gl-ES");
                    SystemInfo.LangName = "GLC";
                    break;
                case 0x0403: //加泰隆语
                    UICulture = new System.Globalization.CultureInfo("ca-ES");
                    SystemInfo.LangName = "CAT";
                    break;
                case 0x0405: //捷克语
                    UICulture = new System.Globalization.CultureInfo("cs-CZ");
                    SystemInfo.LangName = "CSY";
                    break;
                case 0x044b: //卡纳拉语
                    UICulture = new System.Globalization.CultureInfo("kn-IN");
                    SystemInfo.LangName = "KAN";
                    break;
                case 0x041a: //克罗地亚语
                    UICulture = new System.Globalization.CultureInfo("hr-HR");
                    SystemInfo.LangName = "HRV";
                    break;
                case 0x0457: //贡根语
                    UICulture = new System.Globalization.CultureInfo("kok-IN");
                    SystemInfo.LangName = "KNK";
                    break;
                case 0x0426: //拉脱维亚语
                    UICulture = new System.Globalization.CultureInfo("lv-LV");
                    SystemInfo.LangName = "LVI";
                    break;
                case 0x0427: //立陶宛语
                    UICulture = new System.Globalization.CultureInfo("lt-LT");
                    SystemInfo.LangName = "LTH";
                    break;
                case 0x0418: //罗马尼亚语
                    UICulture = new System.Globalization.CultureInfo("ro-RO");
                    SystemInfo.LangName = "ROM";
                    break;
                case 0x044e: //马拉地语
                    UICulture = new System.Globalization.CultureInfo("mr-IN");
                    SystemInfo.LangName = "MAR";
                    break;
                case 0x043e://马来语
                case 0x083e:
                    UICulture = new System.Globalization.CultureInfo("ms-MY");
                    SystemInfo.LangName = "MSL";
                    break;
                case 0x042f: //马其顿语
                    UICulture = new System.Globalization.CultureInfo("mk-MK");
                    SystemInfo.LangName = "MKI";
                    break;
                case 0x0450: //蒙古语
                    UICulture = new System.Globalization.CultureInfo("mn-MN");
                    SystemInfo.LangName = "MON";
                    break;
                case 0x0436: //南非语
                    UICulture = new System.Globalization.CultureInfo("af-ZA");
                    SystemInfo.LangName = "AFK";
                    break;
                case 0x0414://挪威语
                case 0x0814:
                    UICulture = new System.Globalization.CultureInfo("nb-NO");
                    SystemInfo.LangName = "NOR";
                    break;
                case 0x0446: //旁遮普语
                    UICulture = new System.Globalization.CultureInfo("pa-IN");
                    SystemInfo.LangName = "PAN";
                    break;
                case 0x0416://葡萄牙语
                case 0x0816:
                    UICulture = new System.Globalization.CultureInfo("pt-PT");
                    SystemInfo.LangName = "PTG";
                    break;
                case 0x041d://瑞典语
                case 0x081d:
                    UICulture = new System.Globalization.CultureInfo("sv-FI");
                    SystemInfo.LangName = "SVE";
                    break;
                case 0x081a://塞尔维亚
                case 0x0c1a:
                    UICulture = new System.Globalization.CultureInfo("sr-SP-Cyrl");
                    SystemInfo.LangName = "SRL";
                    break;
                case 0x041b://斯洛伐克语
                    UICulture = new System.Globalization.CultureInfo("sk-SK");
                    SystemInfo.LangName = "SKY";
                    break;
                case 0x0424: //斯洛文尼亚语
                    UICulture = new System.Globalization.CultureInfo("sl-SI");
                    SystemInfo.LangName = "SLV";
                    break;
                case 0x0441: //斯瓦希里语
                    UICulture = new System.Globalization.CultureInfo("sw-KE");
                    SystemInfo.LangName = "SWK";
                    break;
                case 0x044a: //泰卢固语
                    UICulture = new System.Globalization.CultureInfo("te-IN");
                    SystemInfo.LangName = "TEL";
                    break;
                case 0x0449: //泰米尔语
                    UICulture = new System.Globalization.CultureInfo("ta-IN");
                    SystemInfo.LangName = "TAM";
                    break;
                case 0x041e: //泰语
                    UICulture = new System.Globalization.CultureInfo("th-TH");
                    SystemInfo.LangName = "THA";
                    break;
                case 0x041f: //土尔其语
                    UICulture = new System.Globalization.CultureInfo("tr-TR");
                    SystemInfo.LangName = "TRK";
                    break;
                case 0x0420: //乌尔都语
                    UICulture = new System.Globalization.CultureInfo("ur-PK");
                    SystemInfo.LangName = "URD";
                    break;
                case 0x0422://乌克兰语
                    UICulture = new System.Globalization.CultureInfo("uk-UA");
                    SystemInfo.LangName = "UKR";
                    break;
                case 0x0443://乌兹别克语
                case 0x0843:
                    UICulture = new System.Globalization.CultureInfo("uz-UZ-Cyrl");
                    SystemInfo.LangName = "UZB";
                    break;
                case 0x040d: //希伯来语
                    UICulture = new System.Globalization.CultureInfo("he-IL");
                    SystemInfo.LangName = "HEB";
                    break;
                case 0x0408: //希腊语
                    UICulture = new System.Globalization.CultureInfo("el-GR");
                    SystemInfo.LangName = "ELL";
                    break;
                case 0x040e: //匈牙利语
                    UICulture = new System.Globalization.CultureInfo("hu-HU");
                    SystemInfo.LangName = "HUN";
                    break;
                case 0x045a: //叙利亚语
                    UICulture = new System.Globalization.CultureInfo("syr-SY");
                    SystemInfo.LangName = "SYR";
                    break;
                case 0x042b: //亚美尼亚语
                    UICulture = new System.Globalization.CultureInfo("hy-AM");
                    SystemInfo.LangName = "HYE";
                    break;
                case 0x0810://意大利语
                case 0x0410:
                    UICulture = new System.Globalization.CultureInfo("it-IT");
                    SystemInfo.LangName = "ITA";
                    break;
                case 0x0439: //印地语
                    UICulture = new System.Globalization.CultureInfo("hi-IN");
                    SystemInfo.LangName = "HIN";
                    break;
                case 0x0421://印度尼西亚语
                    UICulture = new System.Globalization.CultureInfo("id-ID");
                    SystemInfo.LangName = "IND";
                    break;
                case 0x042a: //越南语
                    UICulture = new System.Globalization.CultureInfo("vi-VN");
                    SystemInfo.LangName = "VIT";
                    break;
                default:
                    UICulture = new System.Globalization.CultureInfo("en-US");
                    SystemInfo.LangName = "ENG";
                    break;
            }
            return UICulture;
        }
    }

    public class IniFile
    {
        private Base Pub = new Base();
        private string FileName;

        public IniFile(string IniFileName)
        {
            FileName = IniFileName;
        }
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern bool GetPrivateProfileString(string section, string key, string def,
          StringBuilder retVal, int size, string fileName);
        public string ReadIni(string Section, string Key, string Def)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, Key, "", temp, 1024, FileName);
            string ret = temp.ToString().Trim();
            if (ret == "") ret = Def;
            return ret;
        }

        public byte ReadIni(string Section, string Key, byte Def)
        {
            string ret = ReadIni(Section, Key, Def.ToString());
            if (!Pub.IsNumeric(ret)) ret = "0";
            return Convert.ToByte(ret);
        }

        public int ReadIni(string Section, string Key, int Def)
        {
            string ret = ReadIni(Section, Key, Def.ToString());
            if (!Pub.IsNumeric(ret)) ret = "0";
            return Convert.ToInt32(ret);
        }

        public bool ReadIni(string Section, string Key, bool Def)
        {
            byte ret = ReadIni(Section, Key, Convert.ToByte(Def));
            return ret == 1;
        }

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern bool WritePrivateProfileString(string section, string key, string Val, string fileName);
        public void WriteIni(string Section, string Key, string Val)
        {
            WritePrivateProfileString(Section, Key, Val, FileName);
        }

        public void WriteIni(string Section, string Key, byte Val)
        {
            WriteIni(Section, Key, Val.ToString());
        }

        public void WriteIni(string Section, string Key, int Val)
        {
            WriteIni(Section, Key, Val.ToString());
        }

        public void WriteIni(string Section, string Key, bool Val)
        {
            WriteIni(Section, Key, Convert.ToByte(Val));
        }

        public void EraseSection(string Section)
        {
            WritePrivateProfileString(Section, null, null, FileName);
        }

        [DllImport("Kernel32.dll")]
        private extern static int GetPrivateProfileSectionNamesA(byte[] buffer, int iLen, string fileName);
        public List<string> ReadSections()
        {
            List<string> ret = new List<string>();
            byte[] buffer = new byte[65535];
            int rel = GetPrivateProfileSectionNamesA(buffer, buffer.GetUpperBound(0), FileName);
            int iCnt, iPos;
            string tmp;
            if (rel > 0)
            {
                iCnt = 0;
                iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "") ret.Add(tmp);
                    }
                }
            }
            return ret;
        }
    }

    public class LangRes
    {
        private static string AppDir;
        private static string LangName;
        private static IniFile LangIni;
        private static string LangFile;
        private static bool IsBig5 = false;

        public LangRes(string AppPath)
        {
            AppDir = AppPath;
            LangName = SystemInfo.LangName;
            LangFile = AppDir + "Lang\\" + LangName + ".lng";
            if (LangName == "CHT")
            {
                if (File.Exists(LangFile))
                    IsBig5 = true;
                else if (File.Exists(AppDir + "Lang\\CHS.lng"))
                {
                    LangFile = AppDir + "Lang\\CHS.lng";
                }
            }
            else if (LangName != "CHS")
            {
                if (!File.Exists(LangFile)) SystemInfo.LangName = "ENG";
                LangName = SystemInfo.LangName;
                LangFile = AppDir + "Lang\\" + LangName + ".lng";
            }
            LangIni = new IniFile(LangFile);
        }

        [DllImport("Kernel32", CharSet = CharSet.Auto)]
        private static extern Int32 MultiByteToWideChar(UInt32 codePage, UInt32 dwFlags,
          [In, MarshalAs(UnmanagedType.LPStr)] String lpMultiByteStr, Int32 cbMultiByte,
          [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpWideCharStr, Int32 cchWideChar);
        [DllImport("Kernel32.dll")]
        private static extern int WideCharToMultiByte(uint CodePage, uint dwFlags,
          [In, MarshalAs(UnmanagedType.LPWStr)]string lpWideCharStr, int cchWideChar,
          [Out, MarshalAs(UnmanagedType.LPStr)]StringBuilder lpMultiByteStr, int cbMultiByte,
          IntPtr lpDefaultChar, IntPtr lpUsedDefaultChar);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc,
          [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpDestStr, int cchDest);
        public string GBtoBIG5(string src, bool IsFull)
        {
            string ret = "";
            int len = MultiByteToWideChar(936, 0, src, -1, null, 0);
            StringBuilder wideStr = new StringBuilder(len * 2 + 1);
            len = LCMapString(0x0804, 0x04000000, src, -1, wideStr, len * 2);
            if (IsFull)
            {
                StringBuilder ws = new StringBuilder(len + 1);
                MultiByteToWideChar(936, 0, wideStr.ToString(), -1, ws, len);
                len = WideCharToMultiByte(950, 0, ws.ToString(), -1, null, 0, IntPtr.Zero, IntPtr.Zero);
                ret = ws.ToString();
            }
            else
                ret = wideStr.ToString();
            return ret;
        }

        public string GBtoBIG5(string src)
        {
            return GBtoBIG5(src, false);
        }

        public string GetResText(string Code, string ID, string Def)
        {
            if (ID == null) ID = "";
            string ret = LangIni.ReadIni(Code, ID, "");
            Base pub = new Base();
            if (ret == "") ret = LangIni.ReadIni("Public", ID, "");
            if (ret == "") ret = LangIni.ReadIni("Main", ID, "");
            if ((ret == "") && ((pub.IsNumeric(Def) || (Def.Trim() == "-")))) ret = Def;
            ret = ret.Replace("#13#10", "\r\n");
            if ((LangName == "CHT") && !IsBig5) ret = GBtoBIG5(ret);
            return ret;
        }

        public string GetResText(string Code, string ID, string Def, string[] Codes)
        {
            string ret = GetResText(Code, ID, Def);
            if (ret == "")
            {
                for (int i = Codes.GetLowerBound(0); i <= Codes.GetUpperBound(0); i++)
                {
                    ret = GetResText(Codes[i], ID, Def);
                    if (ret != "") break;
                }
            }
            return ret;
        }
    }

    public class EncAndDec
    {
        private static UInt32 gPassEncryptKey;

        public static byte[] getPWD(string pwd)
        {
            //PWD_HS1:  IDC_HS1:;
            byte[] bpwd = new byte[(int)FKMax.FK_PasswordDataSize];
            byte[] head = Encoding.ASCII.GetBytes("PWD_HS1:");
            byte[] spwd = Encoding.ASCII.GetBytes(pwd);
            byte[] temp = new byte[32 - spwd.Length];
            byte[] mpwd = MergerArray(spwd, temp);
            temp = new byte[32];
            FKHS3760_EncryptPwd(ref mpwd, ref temp, 32);
            bpwd = MergerArray(head, temp);
            return bpwd;
        }

        public static byte[] getCard(string card)
        {
            Int64 tmp = Convert.ToInt64(card);
            if (tmp > int.MaxValue)
            {
                tmp = tmp - 0xffffffff - 1;
                card = tmp.ToString();
            }
            //PWD_HS1:  IDC_HS1:;
            byte[] bcard = new byte[(int)FKMax.FK_PasswordDataSize];
            byte[] head = Encoding.ASCII.GetBytes("IDC_HS1:");
            byte[] scard = Encoding.ASCII.GetBytes(card);
            byte[] temp = new byte[32 - scard.Length];
            byte[] mcard = MergerArray(scard, temp);
            bcard = MergerArray(head, mcard);
            return bcard;
        }

        private static byte[] MergerArray(byte[] First, byte[] Second)
        {
            byte[] result = new byte[First.Length + Second.Length];
            First.CopyTo(result, 0);
            Second.CopyTo(result, First.Length);
            return result;
        }

        private static void FKHS3760_EncryptPwd(ref byte[] apOrgPwdData, ref byte[] apEncPwdData, int aPwdLen)
        {
            int i;

            gPassEncryptKey = 12415;
            for (i = 0; i < aPwdLen; i++)
                apEncPwdData[i] = Encrypt_1Byte(apOrgPwdData[i]);
        }

        private static byte Encrypt_1Byte(byte aByteData)
        {
            UInt32 U0 = 28904;
            UInt32 U1 = 35756;
            byte vCrytData;

            vCrytData = (byte)(aByteData ^ (byte)(gPassEncryptKey >> 8));
            gPassEncryptKey = (vCrytData + gPassEncryptKey) * U0 + U1;
            return vCrytData;
        }

        private static void FKHS3760_DecryptPwd(byte[] apEncPwdData, ref byte[] apOrgPwdData, int aPwdLen)
        {
            int i;

            gPassEncryptKey = 12415;
            for (i = 0; i < aPwdLen; i++)
                apOrgPwdData[i] = Decrypt_1Byte(apEncPwdData[i]);
        }

        private static byte Decrypt_1Byte(byte aByteData)
        {
            UInt32 U0 = 28904;
            UInt32 U1 = 35756;
            byte vCrytData;

            vCrytData = (byte)(aByteData ^ (byte)(gPassEncryptKey >> 8));
            gPassEncryptKey = (aByteData + gPassEncryptKey) * U0 + U1;
            return vCrytData;
        }

        public static void PWDAndCard(int BackupNumber, byte[] buff, ref string No)
        {
            if (BackupNumber == (int)FKBackup.BACKUP_PSW || BackupNumber == (int)FKBackup.BACKUP_CARD)
            {
                byte[] mbytCurEnrollData = new byte[(int)FKMax.FK_PasswordDataSize];
                Array.Copy(buff, mbytCurEnrollData, mbytCurEnrollData.Length);
                byte[] head = new byte[8];
                byte[] data = new byte[mbytCurEnrollData.Length - 8];
                string strhead = "";
                int len = mbytCurEnrollData.Length;
                for (int i = 0; i < mbytCurEnrollData.Length; i++)
                {
                    if (mbytCurEnrollData[i] == 0)
                    {
                        len = i - 8;
                        break;
                    }
                    if (i < 8)
                    {
                        head[i] = mbytCurEnrollData[i];
                        if (i == 7) strhead = Encoding.ASCII.GetString(head);
                    }
                    else
                    {
                        data[i - 8] = mbytCurEnrollData[i];
                    }
                }
                if (len < 1) return;
                byte[] tdata = new byte[len];
                Array.Copy(data, tdata, data.Length < tdata.Length ? data.Length : tdata.Length);
                if (strhead.StartsWith("IDC"))
                {
                    bool isZero = false;
                    for (int i = 0; i < tdata.Length; i++)
                    {
                        if (tdata[i] == 0) isZero = true;
                        if (isZero) tdata[i] = 0;
                    }
                    No = Encoding.ASCII.GetString(tdata);
                    Int64 tmp = Convert.ToInt64(No);
                    if (tmp < 0)
                    {
                        tmp = 0xffffffff + tmp + 1;
                        No = tmp.ToString();
                    }
                }
                else if (strhead.StartsWith("PWD"))
                {
                    byte[] pwd = new byte[tdata.Length];
                    EncAndDec.FKHS3760_DecryptPwd(tdata, ref pwd, pwd.Length);
                    bool isZero = false;
                    for (int i = 0; i < pwd.Length; i++)
                    {
                        if (pwd[i] == 0) isZero = true;
                        if (isZero) pwd[i] = 0;
                    }
                    No = Encoding.ASCII.GetString(pwd).Replace("\0", "");
                }
            }
        }
    }

    public class Database
    {
        private SqlConnection sqlConn = null;
        private OleDbConnection oleConn = null;
        public List<string> KQsql = new List<string>();

        private string ConnStr = "";
        private Base Pub = new Base();
        private int _DBType = 0;

        const int CommandTimeout = 42000;

        private CryptED Crypt = new CryptED();

        const int C_RegKey = 33990;
        const ushort con_Initial = 0xFFFF;
        ushort[] t16 =
        {
      0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7, 0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD,
      0xE1CE, 0xF1EF, 0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6, 0x9339, 0x8318, 0xB37B, 0xA35A,
      0xD3BD, 0xC39C, 0xF3FF, 0xE3DE, 0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485, 0xA56A, 0xB54B,
      0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D, 0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4,
      0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC, 0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861,
      0x2802, 0x3823, 0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B, 0x5AF5, 0x4AD4, 0x7AB7, 0x6A96,
      0x1A71, 0x0A50, 0x3A33, 0x2A12, 0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A, 0x6CA6, 0x7C87,
      0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41, 0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49,
      0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70, 0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A,
      0x9F59, 0x8F78, 0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F, 0x1080, 0x00A1, 0x30C2, 0x20E3,
      0x5004, 0x4025, 0x7046, 0x6067, 0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E, 0x02B1, 0x1290,
      0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256, 0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D,
      0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405, 0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E,
      0xC71D, 0xD73C, 0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634, 0xD94C, 0xC96D, 0xF90E, 0xE92F,
      0x99C8, 0x89E9, 0xB98A, 0xA9AB, 0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3, 0xCB7D, 0xDB5C,
      0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A, 0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92,
      0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9, 0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83,
      0x1CE0, 0x0CC1, 0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8, 0x6E17, 0x7E36, 0x4E55, 0x5E74,
      0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
    };
        private int Key0_int = 0;

        public Database(string ConnectionString)
        {
            ConnStr = ConnectionString;
            _DBType = SystemInfo.DBType;
        }

        public void Open()
        {
            Open(ConnStr);
        }

        public void Open(string ConnectionString)
        {
            ConnStr = ConnectionString;
            Open(_DBType, ConnStr);
        }

        public void Open(int DBType, string ConnectionString)
        {
            _DBType = DBType;
            ConnStr = ConnectionString;
            Close();
            switch (_DBType)
            {
                case 1:
                case 2:
                    sqlConn = new SqlConnection(ConnStr);
                    sqlConn.Open();
                    break;
                case 0:
                case 255:
                    oleConn = new OleDbConnection(ConnStr);
                    oleConn.Open();
                    break;
            }
        }

        public void SetConnStr(string ConnectionString)
        {
            ConnStr = ConnectionString;
        }

        public void Close()
        {
            if (sqlConn != null)
            {
                sqlConn.Close();
                sqlConn = null;
            }
            if (oleConn != null)
            {
                oleConn.Close();
                oleConn = null;
            }
        }

        public bool IsOpen
        {
            get
            {
                return ((sqlConn != null) && (sqlConn.State == ConnectionState.Open)) ||
                  ((oleConn != null) && (oleConn.State == ConnectionState.Open));
            }
        }

        public int ExecSQL(string SQLQuery)
        {
            SQLQuery = SQLQuery.Trim();
            int ret = 0;
            if (!IsOpen) Open();
            switch (_DBType)
            {
                case 1:
                case 2:
                    SqlCommand sqlCmd = new SqlCommand(SQLQuery, sqlConn);
                    sqlCmd.CommandTimeout = CommandTimeout;
                    ret = sqlCmd.ExecuteNonQuery();
                    sqlCmd.Dispose();
                    sqlCmd = null;
                    break;
                case 0:
                case 255:
                    OleDbCommand oleCmd = new OleDbCommand(SQLQuery, oleConn);
                    oleCmd.CommandTimeout = CommandTimeout;
                    ret = oleCmd.ExecuteNonQuery();
                    oleCmd.Dispose();
                    oleCmd = null;
                    break;
            }
            return ret;
        }

        public int ThreadExecSQL(string SQLQuery)
        {
            SQLQuery = SQLQuery.Trim();
            int ret = 0;
            switch (_DBType)
            {
                case 1:
                case 2:
                    using (SqlConnection sql = new SqlConnection(SystemInfo.ConnStr))
                    {
                        sql.Open();
                        SqlCommand sqlCmd = new SqlCommand(SQLQuery, sql);
                        sqlCmd.CommandTimeout = CommandTimeout;
                        ret = sqlCmd.ExecuteNonQuery();
                        sqlCmd.Dispose();
                        sqlCmd = null;
                    }
                    break;
                case 0:
                case 255:
                    lock (obj)
                    {
                        using (OleDbConnection ole = new OleDbConnection(SystemInfo.ConnStr))
                        {
                            ole.Open();
                            OleDbCommand oleCmd = new OleDbCommand(SQLQuery, oleConn);
                            oleCmd.CommandTimeout = CommandTimeout;
                            ret = oleCmd.ExecuteNonQuery();
                            oleCmd.Dispose();
                            oleCmd = null;
                        }

                    }
                    break;
            }
            return ret;
        }

        public int ExecSQL(List<string> SQLQuery)
        {
            int ret = 0;
            string sql = "";
            try
            {
                if (!IsOpen) Open();
                switch (_DBType)
                {
                    case 1:
                    case 2:
                        SqlCommand sqlCmd;
                        SqlTransaction sqlTran = sqlConn.BeginTransaction();
                        try
                        {
                            for (int i = 0; i < SQLQuery.Count; i++)
                            {
                                sql = SQLQuery[i].Trim();
                                if (sql == "") continue;
                                sqlCmd = new SqlCommand(sql, sqlConn);
                                sqlCmd.CommandTimeout = CommandTimeout;
                                sqlCmd.Transaction = sqlTran;
                                sqlCmd.ExecuteNonQuery();
                            }
                            sqlTran.Commit();
                        }
                        catch (Exception E)
                        {
                            ret = 1;
                            Pub.ShowErrorMsg(E, sql);
                            sqlTran.Rollback();
                        }
                        break;
                    case 0:
                    case 255:
                        OleDbCommand oleCmd;
                        OleDbTransaction oleTran = oleConn.BeginTransaction();
                        try
                        {
                            for (int i = 0; i < SQLQuery.Count; i++)
                            {
                                sql = SQLQuery[i].Trim();
                                if (sql == "") continue;
                                oleCmd = new OleDbCommand(sql, oleConn);
                                oleCmd.CommandTimeout = CommandTimeout;
                                oleCmd.Transaction = oleTran;
                                oleCmd.ExecuteNonQuery();
                            }
                            oleTran.Commit();
                        }
                        catch (Exception E)
                        {
                            ret = 1;
                            Pub.ShowErrorMsg(E, sql);
                            oleTran.Rollback();
                        }
                        break;
                }
            }
            catch (Exception E)
            {
                ret = 1;
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }
        private object obj = new object();

        public int ThreadExecSQL(List<string> SQLQuery)
        {
            int ret = 0;
            string sql = "";
            try
            {
                switch (_DBType)
                {
                    case 1:
                    case 2:
                        using (SqlConnection sqlThread = new SqlConnection(SystemInfo.ConnStr))
                        {
                            sqlThread.Open();
                            SqlCommand sqlCmd;
                            SqlTransaction sqlTran = sqlThread.BeginTransaction();
                            try
                            {
                                for (int i = 0; i < SQLQuery.Count; i++)
                                {
                                    sql = SQLQuery[i].Trim();
                                    if (sql == "") continue;
                                    sqlCmd = new SqlCommand(sql, sqlThread);
                                    sqlCmd.CommandTimeout = CommandTimeout;
                                    sqlCmd.Transaction = sqlTran;
                                    sqlCmd.ExecuteNonQuery();
                                    sqlCmd.Dispose();
                                }
                                sqlTran.Commit();
                            }
                            catch (Exception E)
                            {
                                ret = 1;
                                sqlTran.Rollback();
                                throw E;
                            }
                        }
                        break;
                    case 0:
                    case 255:
                        lock(obj)
                        {
                            using (OleDbConnection oleThread = new OleDbConnection(SystemInfo.ConnStr))
                            {
                                oleThread.Open();
                                OleDbCommand oleCmd;
                                OleDbTransaction oleTran = oleThread.BeginTransaction();
                                try
                                {
                                    for (int i = 0; i < SQLQuery.Count; i++)
                                    {
                                        sql = SQLQuery[i].Trim();
                                        if (sql == "") continue;
                                        oleCmd = new OleDbCommand(sql, oleThread);
                                        oleCmd.CommandTimeout = CommandTimeout;
                                        oleCmd.Transaction = oleTran;
                                        oleCmd.ExecuteNonQuery();
                                        oleCmd.Dispose();
                                    }
                                    oleTran.Commit();
                                }
                                catch (Exception E)
                                {
                                    ret = 1;
                                    oleTran.Rollback();
                                    throw E;
                                }
                            }
                        }
                   
                        break;
                }
            }
            catch (Exception E)
            {
                ret = 1;
                throw E;
            }
            return ret;
        }

        #region 根据datatable获得列名   string[] strs = GetColumnsByDataTable(dtName)
        /// <summary>
        /// 根据datatable获得列名
        /// </summary>
        /// <param name="dt">表对象</param>
        /// <returns>返回结果的数据列数组</returns>
        public static string[] GetColumnsByDataTable(DataTable dt)
        {
            string[] strColumns = null;

            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                strColumns = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = dt.Columns[i].ColumnName;
                }
            }
            return strColumns;
        }
        #endregion

        /// <summary>
        /// 批量插入数据到数据库
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="DestinationTableName">数据库对应的表的名称</param>
        /// <returns></returns>
        public bool batchSeveData(DataTable dt, string DestinationTableName)
        {
            #region 用DAO的方式需安装驱动
            //DAO.DBEngine dbEngine = new DAO.DBEngine();
            //DAO.Database db = dbEngine.OpenDatabase(SystemInfo.AccessDB);

            //DAO.Recordset rs = db.OpenRecordset("KQ_KQData");
            //DAO.Field[] myFields = new DAO.Field[15];
            //myFields[0] = rs.Fields["[GUID]"];
            //myFields[1] = rs.Fields["EmpNo"];
            //myFields[2] = rs.Fields["KQDateTime"];
            //myFields[3] = rs.Fields["KQDate"];
            //myFields[4] = rs.Fields["KQTime"];
            //myFields[5] = rs.Fields["MacSN"];
            //myFields[6] = rs.Fields["IsSignIn"];
            //myFields[7] = rs.Fields["IsInvalid"];
            //myFields[8] = rs.Fields["OprtNo"];
            //myFields[9] = rs.Fields["OprtDate"];
            //myFields[10] = rs.Fields["Remark"];
            //myFields[11] = rs.Fields["VerifyModeID"];
            //myFields[12] = rs.Fields["VerifyModeName"];
            //myFields[13] = rs.Fields["InOutModeID"];
            //myFields[14] = rs.Fields["InOutModeName"];

            //for (int i = 0; i < sList.Count; i++)
            //{
            //    rs.AddNew();

            //    myFields[0].Value = sList[i].GUID;
            //    myFields[1].Value = sList[i].EmpNo;
            //    myFields[2].Value = sList[i].KQDateTime;
            //    myFields[3].Value = sList[i].KQDate;
            //    myFields[4].Value = sList[i].KQTime;
            //    myFields[5].Value = sList[i].MacSN;
            //    myFields[6].Value = sList[i].IsSignIn;
            //    myFields[7].Value = sList[i].IsInvalid;
            //    myFields[8].Value = sList[i].OprtNo;

            //    myFields[9].Value = sList[i].OprtDate;
            //    myFields[10].Value = sList[i].Remark;
            //    myFields[11].Value = sList[i].VerifyModeID;
            //    myFields[12].Value = sList[i].VerifyModeName;
            //    myFields[13].Value = sList[i].InOutModeID;
            //    myFields[14].Value = sList[i].InOutModeName;
            //    rs.Update();

            //}
            //rs.Close();
            //db.Close();
            #endregion

            try
            {
                if (!IsOpen) Open();
                switch (_DBType)
                {
                    case 1:
                    case 2:
                        DataTable dataTable = SystemInfo.db.GetDataTable("SELECT * FROM " + DestinationTableName);
                        string[] DBColumnName = GetColumnsByDataTable(dataTable);

                        string[] DataTableTitle = GetColumnsByDataTable(dt);
                        SqlBulkCopy bcp = new SqlBulkCopy(sqlConn);
                        //指定目标数据库表名
                        bcp.DestinationTableName = DestinationTableName;
                        //指定源列和目标列之间的对应关系
                        for (int i = 0; i < DataTableTitle.Length; i++)
                        {
                            for (int j = 0; j < DBColumnName.Length; j++)
                            {
                                if (DataTableTitle[i].Equals(DBColumnName[j]))
                                {
                                    bcp.ColumnMappings.Add(DataTableTitle[i], DBColumnName[j]);
                                    break;
                                }
                            }
                        }
                        //写入数据库表 
                        bcp.WriteToServer(dt);
                        bcp.Close();
                        sqlConn.Close();
                        break;
                    case 0:
                    case 255:
                        List<string> columnList = new List<string>();
                        foreach (DataColumn one in dt.Columns)
                        {
                            columnList.Add(one.ColumnName);
                        }
                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = new OleDbCommand("SELECT * FROM " + DestinationTableName, oleConn);
                        using (OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter))
                        {
                            builder.QuotePrefix = "[";
                            builder.QuoteSuffix = "]";
                            adapter.InsertCommand = builder.GetInsertCommand();
                            foreach (string one in columnList)
                            {
                                adapter.InsertCommand.Parameters.Add(new OleDbParameter(one, dt.Columns[one].DataType));
                            }
                            adapter.Update(dt);

                            adapter.Dispose();
                            adapter = null;
                        }
                        break;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return true;
        }

        public int ExecSQL(List<string> SQLQuery, Taurus.FingerReadData.ProcessReadData prog)
        {
            int ret = 0;
            string sql = "";
            try
            {
                if (!IsOpen) Open();
                switch (_DBType)
                {
                    case 1:
                    case 2:
                        SqlCommand sqlCmd;
                        SqlTransaction sqlTran = sqlConn.BeginTransaction();
                        try
                        {
                            for (int i = 0; i < SQLQuery.Count; i++)
                            {
                                sql = SQLQuery[i].Trim();
                                if (sql == "") continue;
                                sqlCmd = new SqlCommand(sql, sqlConn);
                                sqlCmd.CommandTimeout = CommandTimeout;
                                sqlCmd.Transaction = sqlTran;
                                sqlCmd.ExecuteNonQuery();

                            }
                            sqlTran.Commit();
                        }
                        catch (Exception E)
                        {
                            ret = 1;
                            Pub.ShowErrorMsg(E, sql);
                            sqlTran.Rollback();
                        }
                        break;
                    case 0:
                    case 255:
                        OleDbCommand oleCmd;
                        OleDbTransaction oleTran = oleConn.BeginTransaction();
                        try
                        {
                            for (int i = 0; i < SQLQuery.Count; i++)
                            {
                                sql = SQLQuery[i].Trim();
                                if (sql == "") continue;
                                oleCmd = new OleDbCommand(sql, oleConn);
                                oleCmd.CommandTimeout = CommandTimeout;
                                oleCmd.Transaction = oleTran;
                                oleCmd.ExecuteNonQuery();
                                if (i % 100 == 0)
                                    if (prog != null) prog(SQLQuery.Count, i + 1, "", null, "", false);
                            }
                            oleTran.Commit();
                        }
                        catch (Exception E)
                        {
                            ret = 1;
                            Pub.ShowErrorMsg(E, sql);
                            oleTran.Rollback();
                        }
                        break;
                }
            }
            catch (Exception E)
            {
                ret = 1;
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        public int ExecSQL(string SQLQuery, bool HideError)
        {
            int ret = 0;
            if (HideError)
            {
                try
                {
                    ret = ExecSQL(SQLQuery);
                }
                catch
                {
                }
            }
            else
            {
                ret = ExecSQL(SQLQuery);
            }
            return ret;
        }

        public string ExecSQLMsg(string SQLQuery)
        {
            string ret = "";
            DataTableReader dr = GetDataReader(SQLQuery);
            if (dr.Read()) ret = dr[0].ToString();
            dr.Close();
            return ret.Trim();
        }

        public DataTableReader GetDataReader(string SQLQuery)
        {
            DataSet ds = GetDataSet(SQLQuery);
            return ds.CreateDataReader();
        }

        public DataSet GetDataSet(string SQLQuery)
        {
            DataSet ds = new DataSet();
            if (SQLQuery == "")
            {
                ds = null;
            }
            else
            {
                if (!IsOpen)
                {
                    if (ConnStr == "")
                        Open(SystemInfo.ConnStr);
                    else
                        Open();
                }
                switch (_DBType)
                {
                    case 1:
                    case 2:
                        SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlConn);
                        if (sqlDA.SelectCommand != null) sqlDA.SelectCommand.CommandTimeout = CommandTimeout;
                        if (sqlDA.DeleteCommand != null) sqlDA.DeleteCommand.CommandTimeout = CommandTimeout;
                        if (sqlDA.UpdateCommand != null) sqlDA.UpdateCommand.CommandTimeout = CommandTimeout;
                        sqlDA.Fill(ds, "DataSource");
                        sqlDA.Dispose();
                        sqlDA = null;
                        break;
                    case 0:
                    case 255:
                        OleDbDataAdapter oleDA = new OleDbDataAdapter(SQLQuery, oleConn);
                        if (oleDA.SelectCommand != null) oleDA.SelectCommand.CommandTimeout = CommandTimeout;
                        if (oleDA.DeleteCommand != null) oleDA.DeleteCommand.CommandTimeout = CommandTimeout;
                        if (oleDA.UpdateCommand != null) oleDA.UpdateCommand.CommandTimeout = CommandTimeout;
                        oleDA.Fill(ds, "DataSource");
                        oleDA.Dispose();
                        oleDA = null;
                        break;
                }
            }
            return ds;
        }

        public DataTableReader ThreadGetDataReader(string SQLQuery)
        {
            DataSet ds = ThreadGetDataSet(SQLQuery);
            return ds.CreateDataReader();
        }

        public DataSet ThreadGetDataSet(string SQLQuery)
        {
            DataSet ds = new DataSet();
            if (SQLQuery == "")
            {
                ds = null;
            }
            else
            {
                if (!IsOpen)
                {
                    if (ConnStr == "")
                        Open(SystemInfo.ConnStr);
                    else
                        Open();
                }
                switch (_DBType)
                {
                    case 1:
                    case 2:
                        using(SqlConnection sql = new SqlConnection(SystemInfo.ConnStr))
                        {
                            sql.Open();
                            SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlConn);
                            if (sqlDA.SelectCommand != null) sqlDA.SelectCommand.CommandTimeout = CommandTimeout;
                            if (sqlDA.DeleteCommand != null) sqlDA.DeleteCommand.CommandTimeout = CommandTimeout;
                            if (sqlDA.UpdateCommand != null) sqlDA.UpdateCommand.CommandTimeout = CommandTimeout;
                            sqlDA.Fill(ds, "DataSource");
                            sqlDA.Dispose();
                            sqlDA = null;
                        }
                        break;
                    case 0:
                    case 255:
                        lock(obj)
                        {
                            using (OleDbConnection ole = new OleDbConnection(SystemInfo.ConnStr))
                            {
                                ole.Open();
                                OleDbDataAdapter oleDA = new OleDbDataAdapter(SQLQuery, oleConn);
                                if (oleDA.SelectCommand != null) oleDA.SelectCommand.CommandTimeout = CommandTimeout;
                                if (oleDA.DeleteCommand != null) oleDA.DeleteCommand.CommandTimeout = CommandTimeout;
                                if (oleDA.UpdateCommand != null) oleDA.UpdateCommand.CommandTimeout = CommandTimeout;
                                oleDA.Fill(ds, "DataSource");
                                oleDA.Dispose();
                                oleDA = null;
                            }
                        }
                        break;
                }
            }
            return ds;
        }

        public DataTable GetDataTable(string SQLQuery)
        {
            DataTable dt = new DataTable();

            if (SQLQuery == "")
            {
                dt = null;
            }
            else
            {
                if (!IsOpen) Open();
                switch (_DBType)
                {
                    case 1:
                    case 2:
                        SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlConn);
                        if (sqlDA.SelectCommand != null) sqlDA.SelectCommand.CommandTimeout = CommandTimeout;
                        if (sqlDA.DeleteCommand != null) sqlDA.DeleteCommand.CommandTimeout = CommandTimeout;
                        if (sqlDA.UpdateCommand != null) sqlDA.UpdateCommand.CommandTimeout = CommandTimeout;
                        sqlDA.Fill(dt);
                        sqlDA.Dispose();
                        sqlDA = null;
                        break;
                    case 0:
                    case 255:
                        OleDbDataAdapter oleDA = new OleDbDataAdapter(SQLQuery, oleConn);
                        if (oleDA.SelectCommand != null) oleDA.SelectCommand.CommandTimeout = CommandTimeout;
                        if (oleDA.DeleteCommand != null) oleDA.DeleteCommand.CommandTimeout = CommandTimeout;
                        if (oleDA.UpdateCommand != null) oleDA.UpdateCommand.CommandTimeout = CommandTimeout;
                        oleDA.Fill(dt);
                        oleDA.Dispose();
                        oleDA = null;
                        break;
                }
            }
            return dt;
        }

        public DataTable GetDataTableList()
        {
            DataTable dt = new DataTable();
            if (!IsOpen) Open();
            switch (_DBType)
            {
                case 1:
                case 2:
                    dt = sqlConn.GetSchema("Tables");
                    break;
                case 0:
                case 255:
                    dt = oleConn.GetSchema("Tables");
                    break;
            }
            return dt;
        }

        public bool CompactDatabase()
        {
            bool ret = false;
            DataTableReader dr = null;
            try
            {
                switch (_DBType)
                {
                    case 0:
                        SystemInfo.db.Close();
                        ret = SystemInfo.objAC.CompactJetDatabase(SystemInfo.AccessDB);
                        SystemInfo.db.Open();
                        break;
                    case 1:
                    case 2:
                        dr = GetDataReader("SELECT * FROM sysfiles");
                        while (dr.Read())
                        {
                            ExecSQL("DBCC SHRINKFILE('" + dr["name"].ToString().Trim() + "')");
                        }
                        ret = true;
                        break;
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
            return ret;
        }

        public string GetGroupChildIDByID(string GroupID)
        {
            string ret = "";
            string s = "";
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "31", GroupID }));
                while (dr.Read())
                {
                    GroupID = dr["DevGroupID"].ToString();
                    s = GetGroupChildIDByID(GroupID);
                    if (s != "") s = s + ",";
                    ret = ret + "'" + GroupID + "'," + s.Trim();
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
            if (ret != "") ret = ret.Substring(0, ret.Length - 1);
            return ret;
        }

        public bool CheckAppIsNewVer(string DBAppVer)
        {
            return CheckAppIsNewVer(false, DBAppVer);
        }

        public bool CheckAppIsNewVer(bool CheckRevision, string DBAppVer)
        {
            bool ret = false;
            string[] tmp1 = Application.ProductVersion.Split('.');
            string[] tmp2 = DBAppVer.Split('.');
            if (tmp2.Length == 3)
            {
                if (CheckRevision)
                {
                    if ((Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0])) &&
                      (Convert.ToUInt32(tmp1[1]) >= Convert.ToUInt32(tmp2[1])))
                    {
                        if (Convert.ToUInt32(tmp1[2]) >= Convert.ToUInt32(tmp2[2])) ret = true;
                    }
                    else if ((Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0])) &&
                      (Convert.ToUInt32(tmp1[1]) >= Convert.ToUInt32(tmp2[1])))
                        ret = true;
                    else if (Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0]))
                        ret = true;
                }
                else
                {
                    if ((Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0])) &&
                      (Convert.ToUInt32(tmp1[1]) >= Convert.ToUInt32(tmp2[1])) &&
                      (Convert.ToUInt32(tmp1[2]) > Convert.ToUInt32(tmp2[2])))
                        ret = true;
                    else if ((Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0])) &&
                      (Convert.ToUInt32(tmp1[1]) > Convert.ToUInt32(tmp2[1])))
                        ret = true;
                    else if (Convert.ToUInt32(tmp1[0]) > Convert.ToUInt32(tmp2[0]))
                        ret = true;
                }
            }
            else if (!CheckRevision)
                ret = true;
            return ret;
        }

        public void ReadSystemConfig()
        {
            SystemInfo.AllowMJ = ReadConfig("SystemInfo", "AllowMJ", false);
            SystemInfo.AllowGZ = ReadConfig("SystemInfo", "AllowGZ", false);
            SystemInfo.AllowSEA = ReadConfig("SystemInfo", "AllowSEA", false);
            SystemInfo.AllowSTAR = ReadConfig("SystemInfo", "AllowSTAR", false);

            SystemInfo.isAttendancePhoto = ReadConfig("SystemInfo", "AttendancePhoto", false);
            SystemInfo.IsWarning = SystemInfo.db.ReadConfig("SystemInfo", "IsWarning", false);

            //txt自动导出
            SystemInfo.IsZDTxtTime = SystemInfo.db.ReadConfig("SystemInfo", "IsrbTime", false);
            SystemInfo.IsZDTxtReal = SystemInfo.db.ReadConfig("SystemInfo", "IsrbReal", true); 
            SystemInfo.ZDTxtPath = SystemInfo.db.ReadConfig("SystemInfo", "TxtPath");
            SystemInfo.ZDTxtTime = SystemInfo.db.ReadConfig("SystemInfo", "dtTime");

            //监控端口
            SystemInfo.RegularPort = Convert.ToInt32(SystemInfo.db.ReadConfig("SystemInfo", "RegularPort", "7005"));
            SystemInfo.SeaPort = Convert.ToInt32(SystemInfo.db.ReadConfig("SystemInfo", "SeaPort", "8080"));
            SystemInfo.StarPort = Convert.ToInt32(SystemInfo.db.ReadConfig("SystemInfo", "StarPort", "8001"));
        }

        public void UpdateOneEmpInfoCount(string FingerNo)
        {
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            int idx;
            string EnrollNo = "0";
            int count = 0;
            try
            {
                ExecSQL(Pub.GetSQL(DBCode.DB_000101, new string[] { "215", FingerNo}));
                for (int i = 0; i < 5; i++)
                {
                    idx = 300 + i + 1;
                    dr = GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { idx.ToString() }));
                    while (dr.Read())
                    {
                        EnrollNo = dr[0].ToString();
                        count = Convert.ToInt32(dr[1].ToString());
                        if (EnrollNo.Equals(FingerNo))
                        {
                            sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "300", i.ToString(), count.ToString(),
              EnrollNo .ToString()}));
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception E)
            {
                sql.Clear();
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (sql.Count > 0) ExecSQL(sql);
        }

        public void UpdateEmpInfoCount(string Title)
        {
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            int idx;
            UInt32 EnrollNo = 0;
            int count = 0;
            try
            {
                ExecSQL(Pub.GetSQL(DBCode.DB_000101, new string[] { "213" }));
                for (int i = 0; i < 5; i++)
                {
                    idx = 300 + i + 1;
                    dr = GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { idx.ToString() }));
                    while (dr.Read())
                    {   
                        EnrollNo = Convert.ToUInt32(dr[0].ToString());
                      
                        count = Convert.ToInt32(dr[1].ToString());
                        sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "300", i.ToString(), count.ToString(),
              EnrollNo.ToString()}));
                    }
                    dr.Close();
                }
            }
            catch (Exception E)
            {
                sql.Clear();
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (sql.Count > 0) ExecSQL(sql);
        }

        public void UpdateEmpInfoCount_Star()
        {
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            DataTableReader dr1 = null;
            string EmpNo = "";
            int FingerCount = 0;
            int FaceCount = 0;
            int PalVeinCnt = 0;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "32" }));
                while (dr.Read())
                {
                    EmpNo = dr["EmpNo"].ToString();
                    dr1 = GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "34",EmpNo }));
                    if(dr1.Read())
                    {
                        FingerCount = 0;
                        FaceCount = 0;
                        PalVeinCnt = 0;
                        #region 指纹
                        //for (int i = 0; i < 10; i++)
                        //{
                        //    if (!string.IsNullOrEmpty(dr1["Fb0" + i].ToString()))
                        //    {
                        //        FingerCount++;
                        //    }
                        //}
                        #endregion
                        if (!string.IsNullOrEmpty(dr1["Face00"].ToString()))
                        {
                            FaceCount++;
                        }
                        if (!string.IsNullOrEmpty(dr1["Falm00"].ToString()))
                        {
                            PalVeinCnt++;
                        }
                        sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "31", EmpNo, FingerCount.ToString(), FaceCount.ToString(), PalVeinCnt.ToString() }));
                    }
                    dr1.Close();
                }
                dr.Close();
            }
            catch (Exception E)
            {
                sql.Clear();
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (sql.Count > 0) ExecSQL(sql);
        }

        public void UpdateDatabase(string Title, DateTime dt)
        {
            System.Resources.ResourceManager rm = null;
            DateTime newDate;
            string UpSql = "";
            try
            {
                rm = new System.Resources.ResourceManager("Taurus.Properties.Resources", Assembly.GetExecutingAssembly());//取资源
                newDate = new DateTime(2020, 5, 9);
                if (dt < newDate)
                {
                    Pub.ShowMessageForm(Pub.GetResText("", "MsgUpgrading", ""));
                    for (int i = 1; i <= 20; i++)
                    {
                        switch (SystemInfo.DBType)
                        {
                            case 0:
                                UpdateDatabaseScript(rm, "ACCESS_UPDATE_" + i.ToString("000"), i == 6, ref UpSql);
                                AccessAddMJTime();
                                break;
                            case 1:
                            case 2:
                                UpdateDatabaseScript(rm, "UPDATE_" + i.ToString("000"), i == 6, ref UpSql);
                                break;
                        }
                    }
                    string resName = "";
                    string refFileName = "";
                    switch (SystemInfo.DBType)
                    {
                        case 0:
                            resName = "ACCESS_DATA_" + SystemInfo.LangName;
                            refFileName = "ACCESS";
                            break;
                        case 1:
                        case 2:
                            resName = "DATA_" + SystemInfo.LangName;
                            refFileName = "MSSQL";
                            break;
                    }
                    refFileName = SystemInfo.AppPath + SystemInfo.LangName + "_" + refFileName + ".sql";
                    if (File.Exists(refFileName))
                        UpdateDatabaseScript(refFileName, ref UpSql);
                    else
                        UpdateDatabaseScript(rm, resName, ref UpSql);
                    UpdateEmpInfoCount(Title);
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, UpSql);
            }
            finally
            {
                Pub.FreeMessageForm();
            }
        }

        private void UpdateDatabaseScript(string resFileName, ref string UpSql)
        {
            UpSql = "";
            StreamReader sr = new StreamReader(resFileName, Encoding.Default);
            string[] sql = sr.ReadToEnd().Split(new string[] { "\r\nGO" }, StringSplitOptions.None);
            for (int i = 0; i < sql.Length; i++)
            {
                UpSql = sql[i].Trim();
                if (UpSql != "")
                {
                    if (SystemInfo.DBType == 0)
                        UpdateAccess(UpSql, false);
                    else
                        ExecSQL(UpSql, false);
                }
            }
        }

        private void UpdateDatabaseScript(System.Resources.ResourceManager rm, string resName, ref string UpSql)
        {
            UpdateDatabaseScript(rm, resName, false, ref UpSql);
        }

        private void UpdateDatabaseScript(System.Resources.ResourceManager rm, string resName, bool HideError,
          ref string UpSql)
        {
            UpdateDatabaseScript(rm, resName, HideError, 0, ref UpSql);
        }

        private void UpdateDatabaseScript(System.Resources.ResourceManager rm, string resName, bool HideError,
          int StartLine, ref string UpSql)
        {
            UpSql = "";
            string[] sql = rm.GetString(resName).Split(new string[] { "\r\nGO" }, StringSplitOptions.None);
            for (int i = StartLine; i < sql.Length; i++)
            {
                UpSql = sql[i].Trim();
                if (UpSql != "")
                {
                    if (SystemInfo.DBType == 0)
                        UpdateAccess(UpSql, HideError);
                    else
                        ExecSQL(UpSql, HideError);
                }
            }
        }

        private void AccessAddMJTime()
        {
            DataTableReader dr = null;
            try
            {
                for(int i=2;i<=255;i++)
                {
                    dr = GetDataReader("SELECT PassTimeID FROM DI_PsssTime WHERE PassTimeID=" + i);
                    if(!dr.Read())
                    {
                       string sql = string.Format(@"INSERT INTO DI_PsssTime(PassTimeID, PassTimeName, T1S, T1E, T2S, T2E, T3S, T3E, T4S, T4E, T5S, T5E,
                              T6S, T6E, OprtNo, OprtDate) VALUES({0}, '', '00:00', '00:00', '00:00', '00:00', '00:00', '00:00', '00:00',
                                 '00:00', '00:00', '00:00', '00:00', '00:00', 'ADMIN', Now())",i);
                        ExecSQL(sql);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return;
        }

        private bool AccessExistsTable(string TableName)
        {
            bool ret = false;
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader("SELECT * FROM " + TableName);
                ret = true;
            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return ret;
        }

        private bool AccessExistsData(string sql)
        {
            bool ret = false;
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(sql);
                if (dr.Read()) ret = true;
            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return ret;
        }

        private void UpdateAccess(string sql, bool HideError)
        {
            string[] tmp = sql.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            const string ct = "CREATE TABLE ";
            const string cv = "CREATE VIEW ";
            const string dx = "DATAEXISTS ";
            string na;
            if (tmp[0].IndexOf(ct, 0) == 0)
            {
                na = tmp[0].Substring(ct.Length);
                if (!AccessExistsTable(na)) ExecSQL(sql, HideError);
            }
            else if (tmp[0].IndexOf(cv, 0) == 0)
            {
                na = tmp[0].Substring(cv.Length);
                ExecSQL("DROP TABLE " + na, true);
                ExecSQL(sql, HideError);
            }
            else if (tmp[0].IndexOf(dx, 0) == 0)
            {
                na = tmp[0].Substring(dx.Length);
                if (!AccessExistsData(na))
                {
                    na = "";
                    for (int i = 1; i < tmp.Length; i++)
                    {
                        na += tmp[i] + "\r\n";
                        if (tmp[i].Substring(tmp[i].Length - 1) == ";")
                        {
                            ExecSQL(na, HideError);
                            na = "";
                        }
                    }
                    if (na != "") ExecSQL(na, HideError);
                }
            }
            else
            {
                ExecSQL(sql, HideError);
            }
        }

        public bool UpdateScript(string FileName)
        {
            bool ret = false;
            StreamReader reader = null;
            string line = "";
            string sql = "";
            try
            {
                reader = new StreamReader(FileName, Encoding.Default);
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line.ToLower() == "go")
                    {
                        ExecSQL(sql);
                        sql = "";
                    }
                    else
                    {
                        sql = sql + line + "\r\n";
                    }
                }
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return ret;
        }

        public void UpdateModuleResources(string Title, Assembly am)
        {
            System.Resources.ResourceManager rm = null;
            string UpSql = "";
            try
            {
                rm = new System.Resources.ResourceManager("Taurus.Properties.Resources", am);
                string resName = "";
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        resName = "UPDATE_999";
                        break;
                }
                if (rm.GetString(resName) != null)
                {
                    string[] lines = rm.GetString(resName).Split(new string[] { "\r\nGO" }, StringSplitOptions.None);
                    string s = lines[0];
                    int Y = Convert.ToInt32(s.Substring(0, 4));
                    int M = Convert.ToInt32(s.Substring(4, 2));
                    int D = Convert.ToInt32(s.Substring(6, 2));
                    DateTime newDate = new DateTime(Y, M, D);
                    if (SystemInfo.DBDate < newDate) UpdateDatabaseScript(rm, resName, true, 1, ref UpSql);
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, UpSql);
            }
        }

        public bool UpdateTextData(string sql, string txtField, string Data)
        {
            bool ret = false;
            try
            {
                if (!IsOpen) Open();
                switch (_DBType)
                {
                    case 0:
                        OleDbCommand oleCmd = new OleDbCommand(sql, oleConn);
                        oleCmd.CommandTimeout = CommandTimeout;
                        OleDbParameter oleParam = new OleDbParameter("@" + txtField, OleDbType.BSTR);
                        oleParam.Value = Data;
                        oleCmd.Parameters.Add(oleParam);
                        ret = oleCmd.ExecuteNonQuery() > 0;
                        break;
                    case 1:
                    case 2:
                        SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                        sqlCmd.CommandTimeout = CommandTimeout;
                        SqlParameter sqlParam = new SqlParameter("@" + txtField, SqlDbType.Text);
                        sqlParam.Value = Data;
                        sqlCmd.Parameters.Add(sqlParam);
                        ret = sqlCmd.ExecuteNonQuery() > 0;
                        break;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        public bool UpdateByteData(string sql)
        {
            bool ret = false;
            try
            {
                byte[] bt = new byte[4];
                bt[0] = 0;
                bt[1] = 1;
                bt[2] = 2;
                bt[3] = 3;
                string guid = "";
                
                OleDbConnection con = oleConn;
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
             
                cmd.CommandText = "INSERT INTO KQ_KQDataPhoto([GUID],Photo) VALUES('" + guid + "',@Photo)"; ;
                cmd.Parameters.Add("@Photo", OleDbType.VarBinary).Value = bt;
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        public bool UpdateByteData(string sql, string picField, byte[] Data)
        {
            bool ret = false;
            try
            {
                if (!IsOpen) Open();
                switch (_DBType)
                {
                    case 0:
                        OleDbCommand oleCmd = new OleDbCommand(sql, oleConn);
                        oleCmd.CommandTimeout = CommandTimeout;
                        OleDbParameter oleParam = new OleDbParameter("@" + picField, OleDbType.Binary);
                        oleParam.Value = Data;
                        oleCmd.Parameters.Add(oleParam);
                        ret = oleCmd.ExecuteNonQuery() > 0;
                        break;
                    case 1:
                    case 2:
                        SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                        sqlCmd.CommandTimeout = CommandTimeout;
                        SqlParameter sqlParam = new SqlParameter("@" + picField, SqlDbType.Image);
                        sqlParam.Value = Data;
                        sqlCmd.Parameters.Add(sqlParam);
                        ret = sqlCmd.ExecuteNonQuery() > 0;
                        break;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        public bool UpdateByteData(string sql, string picField, int count)
        {
            bool ret = false;
            try
            {
                if (!IsOpen) Open();
                switch (_DBType)
                {
                    case 0:
                        OleDbCommand oleCmd = new OleDbCommand(sql, oleConn);
                        oleCmd.CommandTimeout = CommandTimeout;
                        OleDbParameter oleParam = new OleDbParameter("@" + picField, OleDbType.Binary);
                        oleParam.Value = count;
                        oleCmd.Parameters.Add(oleParam);
                        ret = oleCmd.ExecuteNonQuery() > 0;
                        break;
                    case 1:
                    case 2:
                        SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                        sqlCmd.CommandTimeout = CommandTimeout;
                        SqlParameter sqlParam = new SqlParameter("@" + picField, SqlDbType.Binary);
                        sqlParam.Value = count;
                        sqlCmd.Parameters.Add(sqlParam);
                        ret = sqlCmd.ExecuteNonQuery() > 0;
                        break;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }
        /// <summary>
        /// 批量人员更新数据到数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="DestinationTableName"></param>
        /// <returns></returns>
        public bool batchEmpUpdateData(DataTable dt, string DestinationTableName, string FieldName)
        {
            string SQLQuery = "";
            string SQL= "";
            int count = 0;
            bool ret = false;
            OleDbCommand oleCmd = null;
            OleDbParameter oleParam = null;
            SqlCommand sqlCmd = null;
            SqlParameter sqlParam = null;
            if (!IsOpen) Open();
            try
            {
                SQLQuery = "UPDATE [" + DestinationTableName + "] SET ";
                foreach (DataColumn one in dt.Columns)
                {
                    SQLQuery += "[" + one.ColumnName + "]=@" + one.ColumnName + ",";
                }
                SQLQuery = SQLQuery.Substring(0, SQLQuery.Length - 1);

                switch (_DBType)
                {
                    case 0:
                        for (int i = 0; i < dt.Rows.Count; i++)
                         {
                            count = 0;
                            foreach (DataColumn one in dt.Columns)
                             {
                                 if (count == 0)
                                 {
                                     SQL = SQLQuery + " where ["+ FieldName + "]='" + dt.Rows[i][FieldName] + "'";
                                     oleCmd = new OleDbCommand(SQL, oleConn);
                                     oleCmd.CommandTimeout = CommandTimeout;
                                 }
                                 oleParam = new OleDbParameter("@" + one.ColumnName, one.DataType);
                                 oleParam.Value = dt.Rows[i][one.ColumnName];
                                 oleCmd.Parameters.Add(oleParam);
                                count ++;
                            }
                             ret = oleCmd.ExecuteNonQuery() > 0;
                         }
                        break;
                    case 1:
                    case 2:
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            count = 0;
                            foreach (DataColumn one in dt.Columns)
                            {
                                if (count == 0)
                                {
                                    SQL = SQLQuery + " where [" + FieldName + "]='" + dt.Rows[i][FieldName] + "'";
                                    sqlCmd = new SqlCommand(SQL, sqlConn);
                                    sqlCmd.CommandTimeout = CommandTimeout;
                                }
                                sqlParam = new SqlParameter("@" + one.ColumnName, one.DataType);
                                if (dt.Rows[i][one.ColumnName].ToString() == "" && one.DataType.Name == "Byte[]")
                                {
                                    sqlParam = new SqlParameter("@" + one.ColumnName, SqlDbType.Image);
                                    sqlParam.Value = DBNull.Value;
                                }
                                else
                                {
                                    sqlParam.Value = dt.Rows[i][one.ColumnName];
                                }
                                sqlCmd.Parameters.Add(sqlParam);
                                count++;
                            }
                            ret = sqlCmd.ExecuteNonQuery() > 0;
                        }
                        break;
                }

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "\r\n" + SQLQuery);
            }
           
            return ret;
        }

        /// <summary>
        /// 批量插入人员数据到数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="DestinationTableName"></param>
        /// <returns></returns>
        public bool batchEmpInSertData(DataTable dt, string DestinationTableName)
        {
            string SQLQuery = "";
            int count = 0;
            bool ret = false;
            SqlCommand sqlCmd = null;
            SqlParameter sqlParam = null;
            OleDbCommand oleCmd = null;
            OleDbParameter oleParam = null;
            if (!IsOpen) Open();
            try
            {
                SQLQuery = "Insert into [" + DestinationTableName + "](";
                foreach (DataColumn one in dt.Columns)
                {
                    SQLQuery += "[" + one.ColumnName + "],";
                }
                SQLQuery = SQLQuery.Substring(0, SQLQuery.Length - 1) + ") VALUES(";
                foreach (DataColumn one in dt.Columns)
                {
                    SQLQuery += "@" + one.ColumnName + ",";
                }
                SQLQuery = SQLQuery.Substring(0, SQLQuery.Length - 1)+")";

                switch (_DBType)
                {
                    case 0:
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            count = 0;
                            foreach (DataColumn one in dt.Columns)
                            {
                                if (count == 0)
                                {
                                    oleCmd = new OleDbCommand(SQLQuery, oleConn);
                                    oleCmd.CommandTimeout = CommandTimeout;
                                }
                                oleParam = new OleDbParameter("@" + one.ColumnName, one.DataType);
                                oleParam.Value = dt.Rows[i][one.ColumnName];

                                oleCmd.Parameters.Add(oleParam);
                                count ++;
                            }
                            ret = oleCmd.ExecuteNonQuery() > 0;
                        }
                        break;
                    case 1:
                    case 2:
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                           
                            count = 0;
                            foreach (DataColumn one in dt.Columns)
                            {
                                if (count == 0)
                                {
                                    sqlCmd = new SqlCommand(SQLQuery, sqlConn);
                                    sqlCmd.CommandTimeout = CommandTimeout;
                                }
                                sqlParam = new SqlParameter("@" + one.ColumnName, one.DataType);
                                if(dt.Rows[i][one.ColumnName].ToString()=="" && one.DataType.Name== "Byte[]")
                                {
                                    sqlParam = new SqlParameter("@" + one.ColumnName, SqlDbType.Image);
                                    sqlParam.Value = DBNull.Value;
                                }
                                else
                                {
                                    sqlParam.Value = dt.Rows[i][one.ColumnName];
                                }
                                
                                sqlCmd.Parameters.Add(sqlParam);
                                count++;
                            }

                            ret = sqlCmd.ExecuteNonQuery() > 0;
                        }
                        break;
                }

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "\r\n" + SQLQuery);
            }

            return ret;
        }

        public void SaveSnapLog(string MacSN,string PictureType,string OprtDate,string Temperature,int TemperatureAlarm, byte[] Photo, ref string GUID)
        {
            try
            {
                if (!IsOpen) Open();
                string sql = "";
                if (Temperature == "0") Temperature = "";
                switch (_DBType)
                {
                    case 0:
                        sql = "select * from DI_SeaSnapShots where MacSN='" + MacSN + "' and OprtDate=CDate('" + OprtDate + "')";
                        break;
                    case 1:
                    case 2:
                        sql = "select * from DI_SeaSnapShots where MacSN='" + MacSN + "' and OprtDate='" + OprtDate + "'";
                        break;
                }
                DataTableReader dr = GetDataReader(sql);
                if(dr.Read())
                {
                    return;
                }
                else
                {
                    sql = "insert into DI_SeaSnapShots ([GUID], MacSN,PictureType,OprtDate,Temperature,TemperatureAlarm) VALUES(@GUID, @MacSN,@PictureType," +
            "@OprtDate,@Temperature,@TemperatureAlarm)";
                }

                GUID = Guid.NewGuid().ToString().ToUpper();
                switch (_DBType)
                {
                    case 0:
                        OleDbCommand oleCmd = new OleDbCommand(sql, oleConn);
                        oleCmd.CommandTimeout = CommandTimeout;
                        OleDbParameter oleParam = new OleDbParameter("@GUID", GUID);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@MacSN", MacSN);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@PictureType", PictureType);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@OprtDate", OprtDate);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@Temperature", Temperature);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@TemperatureAlarm", TemperatureAlarm);
                        oleCmd.Parameters.Add(oleParam);
                        oleCmd.ExecuteNonQuery();

                        oleCmd = new OleDbCommand("insert into DI_SeaSnapShotsPhoto ([GUID],Photo ) VALUES(@GUID,@Photo)", oleConn);
                        oleCmd.CommandTimeout = CommandTimeout;
                        oleParam = new OleDbParameter("@GUID", GUID);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@Photo", Photo);
                        oleCmd.Parameters.Add(oleParam);
                        oleCmd.ExecuteNonQuery();
                        break;
                    case 1:
                    case 2:
                        SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                        sqlCmd.CommandTimeout = CommandTimeout;
                        SqlParameter sqlParam = new SqlParameter("@GUID", GUID);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@MacSN", MacSN);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@PictureType", PictureType);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@OprtDate", OprtDate);
                        sqlCmd.Parameters.Add(sqlParam);
                       
                        sqlParam = new SqlParameter("@Temperature", Temperature);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@TemperatureAlarm", TemperatureAlarm);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlCmd.ExecuteNonQuery();

                        sqlCmd = new SqlCommand("insert into DI_SeaSnapShotsPhoto ([GUID],Photo ) VALUES(@GUID,@Photo)", sqlConn);
                        sqlCmd.CommandTimeout = CommandTimeout;
                        sqlParam = new SqlParameter("@GUID", GUID);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@Photo", Photo);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlCmd.ExecuteNonQuery();
                        break;
                }        
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
          
        }

        public bool SavePIDLog(PIDLog pidLog, ref string GUID)
        {
            bool ret = false;
            try
            {
                if (!IsOpen) Open();
                string sql = "";
                string Temperature = pidLog.Temperature.ToString();
                if (Temperature == "0") Temperature = "";
                switch (_DBType)
                {
                    case 0:
                        sql = "select * from MJ_SeaPersonIDCard where MacSN='" + pidLog.MacSN + "' and KQDateTime=CDate('" + pidLog.Time.ToString(SystemInfo.SQLDateTimeFMT) + "')";
                        break;
                    case 1:
                    case 2:
                        sql = "select * from MJ_SeaPersonIDCard where MacSN='" + pidLog.MacSN + "' and KQDateTime='" + pidLog.Time.ToString(SystemInfo.SQLDateTimeFMT) + "'";
                        break;
                }
                DataTableReader dr = GetDataReader(sql);
                if (dr.Read())
                {
                    return ret;
                }
                else
                {
                    sql = "insert into MJ_SeaPersonIDCard ([GUID],EmpName,KQDateTime, MacSN,Gender,Birthday,CardType,EmpCertNo,EmpAddress,InOutModeID,InOutModeName,Temperature,TemperatureAlarm,Nation) " +
                        "VALUES(@GUID, @EmpName,@KQDateTime, @MacSN,@Gender,@Birthday,@CardType,@EmpCertNo,@EmpAddress,@InOutModeID,@InOutModeName,@Temperature,@TemperatureAlarm,@Nation)";
                }

                GUID = Guid.NewGuid().ToString().ToUpper();
                switch (_DBType)
                {
                    case 0:
                        OleDbCommand oleCmd = new OleDbCommand(sql, oleConn);
                        oleCmd.CommandTimeout = CommandTimeout;
                        OleDbParameter oleParam = new OleDbParameter("@GUID", GUID);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@EmpName", pidLog.Name);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@KQDateTime", pidLog.Time.ToString(SystemInfo.SQLDateTimeFMT));
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@MacSN", pidLog.MacSN);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@Gender", pidLog.Gender);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@Birthday", pidLog.Birthday.ToString(SystemInfo.SQLDateFMT));
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@CardType", pidLog.CardType);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@EmpCertNo", pidLog.EmpCertNo);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@EmpAddress", pidLog.EmpAddress);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@InOutModeID", pidLog.InOutMode);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@InOutModeName", pidLog.InOutModeName);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@Temperature", Temperature);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@TemperatureAlarm", pidLog.TemperatureAlarm);
                        oleCmd.Parameters.Add(oleParam);
                        oleParam = new OleDbParameter("@Nation", pidLog.Nation);
                        oleCmd.Parameters.Add(oleParam);
                        ret = oleCmd.ExecuteNonQuery() == 1;
                        break;
                    case 1:
                    case 2:
                        SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                        sqlCmd.CommandTimeout = CommandTimeout;
                        SqlParameter sqlParam = new SqlParameter("@GUID", GUID);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@EmpName", pidLog.Name);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@KQDateTime", pidLog.Time.ToString(SystemInfo.SQLDateTimeFMT));
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@MacSN", pidLog.MacSN);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@Gender", pidLog.Gender);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@Birthday", pidLog.Birthday.ToString(SystemInfo.SQLDateFMT));
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@CardType", pidLog.CardType);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@EmpCertNo", pidLog.EmpCertNo);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@EmpAddress", pidLog.EmpAddress);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@InOutModeID", pidLog.InOutMode);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@InOutModeName", pidLog.InOutModeName);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@Temperature", Temperature);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@TemperatureAlarm", pidLog.TemperatureAlarm);
                        sqlCmd.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter("@Nation", pidLog.Nation);
                        sqlCmd.Parameters.Add(sqlParam);
                        ret = sqlCmd.ExecuteNonQuery() == 1;
                        break;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            return ret;
        }

        public void WriteSYLog(string Title, string Tool, string Detail)
        {
            Detail = Detail.Replace("'", "");
            string sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "9", Title, Tool, Detail, OprtInfo.OprtNoAndName,
        SystemInfo.ComputerName });
            ExecSQL(sql, true);
        }

        public void WriteSYLog(string Title, string Tool, List<string> Detail)
        {
            string tmp = "";
            int max = Detail.Count;
            if (max > 100) max = 100;
            for (int i = 0; i < max; i++)
            {
                tmp = tmp + Detail[i] + "\r\n";
            }
            tmp = "Count: " + Detail.Count.ToString() + "  " + tmp;
            if (max < Detail.Count) tmp = tmp + "  ......";
            WriteSYLog(Title, Tool, tmp);
        }

        public bool CheckOprtRole(string SubID, bool AllowCheckOprtRole)
        {
            string ModuleID = SubID.Substring(0, 2);
            return CheckOprtRole(ModuleID, SubID, AllowCheckOprtRole);
        }

        public bool CheckOprtRole(string ModuleID, string SubID, bool AllowCheckOprtRole)
        {
            bool ret = false;
            if (!AllowCheckOprtRole) return true;
            if (OprtInfo.OprtIsSys) return true;
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "103", OprtInfo.OprtNo, ModuleID, SubID }));
                if (dr.Read()) ret = true;
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
            if (!ret) Pub.MessageBoxShow(Pub.GetResText("", "ErrorNoPower", ""));
            return ret;
        }

        public string GetDatabasePath()
        {
            string ret = "";
            string tmp = DBServerInfo.ServerName;
            switch (_DBType)
            {
                case 0:
                    ret = SystemInfo.AppPath + "Database\\";
                    break;
                case 1:
                case 2:
                    const string loc = "(local)";
                    if ((tmp == "") || (tmp == ".") || (tmp.ToLower() == loc) ||
                      (tmp.ToLower() == SystemInfo.ComputerName.ToLower()) ||
                      (tmp.ToLower().Substring(0, loc.Length + 1) == loc.ToLower() + "\\") ||
                      ((tmp.Length > SystemInfo.ComputerName.Length + 1) &&
                      ((tmp.ToLower().Substring(0, SystemInfo.ComputerName.Length + 1) == SystemInfo.ComputerName.ToLower() + "\\"))))
                    {
                        ret = SystemInfo.AppPath + "Database\\";
                    }
                    else
                    {
                        DataTableReader dr = null;
                        try
                        {
                            dr = GetDataReader("SELECT filename FROM master..sysfiles");//获取数据库安装路径
                            if (dr.Read())
                            {
                                ret = dr["filename"].ToString().Trim();
                                ret = Pub.GetFileNamePath(ret);
                            }
                        }
                        finally
                        {
                            if (dr != null) dr.Close();
                            dr = null;
                        }
                    }
                    break;
            }
            return ret;
        }

        public bool BackupDatabase(string FileName)
        {
            bool ret = false;
            string tmp = "";
            try
            {
                switch (_DBType)
                {
                    case 0:
                        File.Copy(SystemInfo.AccessDB, FileName, true);
                        ret = SystemInfo.objAC.CompactJetDatabase(FileName);
                        break;
                    case 1:
                    case 2:
                        tmp = "BACKUP DATABASE [" + SystemInfo.NameSpace + "] TO DISK='" + FileName + "' WITH INIT";
                        ExecSQL(tmp);
                        ret = true;
                        break;

                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        public bool RestoreDatabase(string FileName)
        {
            bool ret = false;
            DataTableReader dr = null;
            string tmp;
            string[] s;
            string DataFile = "";
            string LogFile = "";
            string InfoDataFile = "";
            string InfoLogFile = "";
            try
            {
                switch (_DBType)
                {
                    case 0:
                        ret = SystemInfo.objAC.RestoreDatabase(FileName, SystemInfo.AccessDB);
                        break;
                    case 1:
                    case 2:
                        dr = GetDataReader("SELECT filename FROM sysfiles");
                        dr.Read();
                        tmp = dr[0].ToString().Trim();
                        s = tmp.Split('.');
                        if (s[s.Length - 1].ToLower() == "mdf")
                            DataFile = tmp;
                        else
                            LogFile = tmp;
                        dr.Read();
                        tmp = dr[0].ToString().Trim();
                        dr.Close();
                        s = tmp.Split('.');
                        if (s[s.Length - 1].ToLower() == "mdf")
                            DataFile = tmp;
                        else
                            LogFile = tmp;
                        dr = GetDataReader("RESTORE FILELISTONLY FROM DISK='" + FileName + "'");
                        dr.Read();
                        tmp = dr["Type"].ToString().Trim().ToLower();
                        if (tmp == "d")
                            InfoDataFile = dr[0].ToString().Trim();
                        else
                            InfoLogFile = dr[0].ToString().Trim();
                        dr.Read();
                        tmp = dr["Type"].ToString().Trim().ToLower();
                        if (tmp == "d")
                            InfoDataFile = dr[0].ToString().Trim();
                        else
                            InfoLogFile = dr[0].ToString().Trim();
                        dr.Close();
                        ExecSQL("USE master");
                        dr = GetDataReader("SELECT spid FROM master..sysprocesses WHERE dbid=db_id( '" +
                          SystemInfo.NameSpace + "')");
                        if (dr.Read()) ExecSQL("KILL " + dr[0].ToString().Trim());
                        dr.Close();
                        tmp = "RESTORE DATABASE " + SystemInfo.NameSpace + " FROM DISK='" + FileName +
                          "' WITH REPLACE, MOVE '" + InfoDataFile + "' TO '" + DataFile + "', MOVE '" +
                          InfoLogFile + "' TO '" + LogFile + "'";
                        ExecSQL(tmp);
                        ret = true;
                        break;
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
            return ret;
        }

        public string GetDepartChildIDByID(string DepartID)
        {
            string ret = "";
            string s = "";
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "2", DepartID }));
                while (dr.Read())
                {
                    DepartID = dr["DepartID"].ToString();
                    s = GetDepartChildIDByID(DepartID);
                    if (s != "") s = s + ",";
                    ret = ret + "'" + DepartID + "'," + s.Trim();
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
            if (ret != "") ret = ret.Substring(0, ret.Length - 1);
            return ret;
        }

        public bool GetServerDate(ref DateTime ServerDate)
        {
            ServerDate = new DateTime();
            bool ret = false;
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "14" }));
                if (dr.Read())
                {
                    ServerDate = Convert.ToDateTime(dr[0]);
                    ret = true;
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
            return ret;
        }

        public string ReadConfig(string ID, string KeyWord, string Def)
        {
            string ret = Def;
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "15", ID, KeyWord }));
                if (dr.Read()) ret = dr[0].ToString();
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
            return ret;
        }

        public string ReadConfig(string ID, string KeyWord)
        {
            return ReadConfig(ID, KeyWord, "");
        }

        public bool ReadConfig(string ID, string KeyWord, bool Def)
        {
            string ret = ReadConfig(ID, KeyWord, Convert.ToByte(Def).ToString());
            if (Pub.IsNumeric(ret))
                return Convert.ToByte(ret) == 1;
            else
                return false;
        }

        public byte ReadConfig(string ID, string KeyWord, byte Def)
        {
            string ret = ReadConfig(ID, KeyWord, Def.ToString());
            if (Pub.IsNumeric(ret))
                return Convert.ToByte(ret);
            else
                return 0;
        }

        public int ReadConfig(string ID, string KeyWord, int Def)
        {
            string ret = ReadConfig(ID, KeyWord, Def.ToString());
            if (Pub.IsNumeric(ret))
                return Convert.ToInt32(ret);
            else
                return 0;
        }

        public bool WriteConfig(string ID, string KeyWord, string Value, string title, string oprt)
        {
            bool ret = false;
            DataTableReader dr = null;
            string sql = "";
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "15", ID, KeyWord }));
                if (dr.Read())
                    sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "17", ID, KeyWord, Value });
                else
                    sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "16", ID, KeyWord, Value });
                ExecSQL(sql);
                ret = true;
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
            if ((ret) && (title != ""))
            {
                WriteSYLog(title, oprt, sql);
            }
            return ret;
        }

        public bool WriteConfig(string ID, string KeyWord, string Value)
        {
            return WriteConfig(ID, KeyWord, Value, "", "");
        }

        public bool WriteConfig(string ID, string KeyWord, byte Value, string title, string oprt)
        {
            return WriteConfig(ID, KeyWord, Value.ToString(), title, oprt);
        }

        public bool WriteConfig(string ID, string KeyWord, byte Value)
        {
            return WriteConfig(ID, KeyWord, Value, "", "");
        }

        public bool WriteConfig(string ID, string KeyWord, int Value, string title, string oprt)
        {
            return WriteConfig(ID, KeyWord, Value.ToString(), title, oprt);
        }

        public bool WriteConfig(string ID, string KeyWord, int Value)
        {
            return WriteConfig(ID, KeyWord, Value, "", "");
        }

        public bool WriteConfig(string ID, string KeyWord, bool Value, string title, string oprt)
        {
            return WriteConfig(ID, KeyWord, Convert.ToByte(Value), title, oprt);
        }

        public bool WriteConfig(string ID, string KeyWord, bool Value)
        {
            return WriteConfig(ID, KeyWord, Value, "", "");
        }

        public bool DeleteConfig(string ID, string KeyWord)
        {
            bool ret = false;
            try
            {
                ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "18", ID, KeyWord }));
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        public bool GetDepartInfo(string DepartID, ref string DepartName)
        {
            bool ret = false;
            DepartName = "";
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "1", DepartID }));
                if (dr.Read())
                {
                    DepartName = dr["DepartName"].ToString();
                    ret = true;
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
            return ret;
        }

        public string GetDepartChildID(string DepartID)
        {
            string ret = "";
            string s = "";
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "2", DepartID }));
                while (dr.Read())
                {
                    DepartID = dr["DepartID"].ToString();
                    s = GetDepartChildID(DepartID);
                    if (s != "") s = s + ",";
                    ret = ret + "'" + DepartID + "'," + s.Trim();
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
            if (ret != "") ret = ret.Substring(0, ret.Length - 1);
            return ret;
        }

        public bool GetEmpInfoCard(string EmpNo, ref string EmpName, ref string CardNo10, ref string CardNo81,
          ref string CardNo82, ref string DepartID, ref string DepartName)
        {
            return GetEmpInfoCard(EmpNo, ref EmpName, ref CardNo10, ref CardNo81, ref CardNo82, ref DepartID,
              ref DepartName, "");
        }

        public bool GetEmpInfoCard(string EmpNo, ref string EmpName, ref string CardNo10, ref string CardNo81,
          ref string CardNo82, ref string DepartID, ref string DepartName, string OtherCoin)
        {
            bool ret = false;
            EmpName = "";
            CardNo10 = "";
            CardNo81 = "";
            CardNo82 = "";
            DepartID = "";
            DepartName = "";
            //if (OtherCoin == "") OtherCoin = Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "203", EmpNo, OtherCoin }));
                if (dr.Read())
                {
                    EmpName = dr["EmpName"].ToString();
                    CardNo10 = dr["CardNo10"].ToString();
                    CardNo81 = dr["CardNo81"].ToString();
                    CardNo82 = dr["CardNo82"].ToString();
                    DepartID = dr["DepartID"].ToString();
                    DepartName = dr["DepartName"].ToString();
                    ret = true;
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
            return ret;
        }

        public string GetAutoEmpNo(UInt32 EnrollNumber)
        {
            string ret = "";
            UInt32 tmp = EnrollNumber;
            DataTableReader dr = null;
            string s = "E" + tmp.ToString("000000");
            try
            {
                while (ret == "")
                {
                    dr = GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "5", s }));
                    if (dr.Read())
                    {
                        tmp++;
                        s = "E" + tmp.ToString("000000");
                    }
                    else
                        ret = "E" + tmp.ToString("000000");
                    dr.Close();
                }
            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return ret;
        }

        public bool GetEmpNoByFingerNo(UInt32 FingerNo, ref string EmpNo)
        {
            EmpNo = "";
            bool ret = false;
            DataTableReader dr = null;
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "10", FingerNo.ToString() }));
                if (dr.Read())
                {
                    EmpNo = dr["EmpNo"].ToString();
                    ret = true;
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
            return ret;
        }

        public bool SaveEnrollToDB(UInt32 EnrollNumber, int BackupNumber, int EnableFlag, int Privilege,
          int PasswordData, byte[] fpData, string EnrollName, ref bool ReqName)
        {
            byte[] buff = new byte[0];
            if (BackupNumber >= (int)FKBackup.BACKUP_FP_0 && BackupNumber <= (int)FKBackup.BACKUP_FP_9)
            {
                buff = new byte[(int)FKMax.FK_FPDataSize];
            }
            else if (BackupNumber == (int)FKBackup.BACKUP_PSW || BackupNumber == (int)FKBackup.BACKUP_CARD)
            {
                buff = new byte[(int)FKMax.FK_PasswordDataSize];
            }
            else if (BackupNumber == (int)FKBackup.BACKUP_FACE)
            {
                buff = new byte[(int)FKMax.FK_FaceDataSize];
            }
            else if (BackupNumber >= (int)FKBackup.BACKUP_PALMVEIN_0 && BackupNumber <= (int)FKBackup.BACKUP_PALMVEIN_3)
            {
                buff = new byte[(int)FKMax.PALMVEINDataSize];
            }
            else if (BackupNumber == (int)FKBackup.BACKUP_VEIN_0)
            {
                buff = new byte[(int)FKMax.FK_VeinDataSize];
            }
            Array.Copy(fpData, buff, buff.Length);
            ReqName = false;
            bool ret = false;
            DataTableReader dr = null;
            string EmpNo = "";
            List<string> sql = new List<string>();
            try
            {
                dr = GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "10", EnrollNumber.ToString() }));
                if (dr.Read()) EmpNo = dr["EmpNo"].ToString();
                dr.Close();
                if (EmpNo == "")
                {
                    ReqName = true;
                    EmpNo = GetAutoEmpNo(EnrollNumber);
                    string HireDate = Pub.GetSQL(DBCode.DB_000001, new string[] { "13" });
                    sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "6", EmpNo, EnrollName, "", SystemInfo.CommanyID,
            HireDate, "", "", "", "", EnrollNumber.ToString(), Privilege.ToString(), "1", "", "", "", "", "0","","NULL","NULL" }));
                }
                else
                    sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "202", Privilege.ToString(), EmpNo }));
              
                //保存卡号、密码
                if ((BackupNumber == (int)FKBackup.BACKUP_PSW) || (BackupNumber == (int)FKBackup.BACKUP_CARD))
                {
                    string No = "";
                    EncAndDec.PWDAndCard(BackupNumber, fpData, ref No);
                    sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { BackupNumber == (int)FKBackup.BACKUP_PSW ? "211" : "210", No,
            EnrollNumber.ToString() }));
                }
                else  //保存其他数据
                {
                    dr = GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "203", SystemInfo.MacTypeID.ToString(),
          EnrollNumber.ToString(), BackupNumber.ToString() }));
                    sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { dr.Read() ? "205" : "204", SystemInfo.MacTypeID.ToString(),
          EnrollNumber.ToString(), BackupNumber.ToString(), "NULL"  }));
                    dr.Close();
                }

                if (ExecSQL(sql) == 0)
                {
                    if(!(BackupNumber == (int)FKBackup.BACKUP_PSW || BackupNumber == (int)FKBackup.BACKUP_CARD))
                    {
                        UpdateByteData(Pub.GetSQL(DBCode.DB_000300, new string[] { "202", SystemInfo.MacTypeID.ToString(),
            EnrollNumber.ToString(), BackupNumber.ToString() }), "FingerData", buff);
                    }    
                }
                ret = true;
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
            return ret;
        }

        public bool SaveStarEnrollToDB(UInt32 EnrollNumber, byte[] Data, string BackNum)
        {
            bool ret = false;
            DataTableReader dr = null;
            List<string> sql = new List<string>();
            try
            {
                if(Data.Length > 0)
                {
                    dr = GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "203", SystemInfo.MacTypeID.ToString(),
          EnrollNumber.ToString(), BackNum }));
                    sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { dr.Read() ? "205" : "204", SystemInfo.MacTypeID.ToString(),
          EnrollNumber.ToString(), BackNum, "NULL"  }));
                    dr.Close();
                    if (ExecSQL(sql) == 0)
                    {
                        UpdateByteData(Pub.GetSQL(DBCode.DB_000300, new string[] { "202", SystemInfo.MacTypeID.ToString(),
            EnrollNumber.ToString(), BackNum }), "FingerData", Data);
                    }
                }
                else
                {
                    ExecSQL(Pub.GetSQL(DBCode.DB_000101, new string[] { "30", EnrollNumber.ToString(), BackNum }));
                }
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }

            return ret;
        }

        protected Bitmap CustomSizeImage(Image img)
        {
            double whX = 240.00 / 180.00;
            int w = 180;
            int h = Convert.ToInt32(w * whX);
            Bitmap bmp = new Bitmap(w, h);
            int srcX = 0;
            int srcY = 0;
            int srcW = img.Width;
            int srcH = img.Height;
            double zoom = ((double)w) / ((double)srcW);
            Graphics g = Graphics.FromImage(bmp);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            Color c = Color.FromArgb(new Bitmap(img).GetPixel(1, 1).ToArgb());
            g.Clear(c);
            if (srcW * whX != srcH)
            {
                if (srcW * whX >= srcH)
                {
                    srcH = Convert.ToInt32(srcW * whX);
                    srcY = -(srcH - img.Height) / 2;
                }
                else
                {
                    srcW = Convert.ToInt32(srcH / whX);
                    srcX = -(srcW - img.Width) / 2;
                }
            }
            g.DrawImage(img, new Rectangle(0, 0, w, h), new Rectangle(srcX, srcY, srcW, srcH), GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }

        protected Bitmap CustomSizePhoto(Image img)
        {
            double whX = 640.00 / 480.00;
            int w = 480;
            int h = Convert.ToInt32(w * whX);
            Bitmap bmp = new Bitmap(w, h);
            int srcX = 0;
            int srcY = 0;
            int srcW = img.Width;
            int srcH = img.Height;
            double zoom = ((double)w) / ((double)srcW);
            Graphics g = Graphics.FromImage(bmp);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            Color c = Color.FromArgb(new Bitmap(img).GetPixel(1, 1).ToArgb());
            g.Clear(c);
            if (srcW * whX != srcH)
            {
                if (srcW * whX >= srcH)
                {
                    srcH = Convert.ToInt32(srcW * whX);
                    srcY = -(srcH - img.Height) / 2;
                }
                else
                {
                    srcW = Convert.ToInt32(srcH / whX);
                    srcX = -(srcW - img.Width) / 2;
                }
            }
            g.DrawImage(img, new Rectangle(0, 0, w, h), new Rectangle(srcX, srcY, srcW, srcH), GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }

        public void SetEmpNameByFinger(UInt32 FingerNo, string EmpName)
        {
            string sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "207", FingerNo.ToString(), EmpName });
            try
            {
                ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
        }

        public double GetTimeHours(string InTime, string OutTime)
        {
            double ret = 0;
            if (SystemInfo.DBType == 0)
                ret = SystemInfo.objACKQ.GetTimeSecond(InTime, OutTime);
            else
            {
                DataTableReader dr = null;
                try
                {
                    dr = GetDataReader(Pub.GetSQL(DBCode.DB_000204, new string[] { "13", InTime, OutTime }));
                    if (dr.Read())
                    {
                        ret = Convert.ToInt32(dr[0].ToString());
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
            ret = Math.Round(ret / 60.00 / 60.00, 2);
            return ret;
        }

        public string GetRegSerial()
        {
            HardInfo.HardInfo hardInfo = new HardInfo.HardInfo();
            string tmp = hardInfo.GetDiskSN();
            if (tmp == "") tmp = hardInfo.GetHostName();
            if (tmp == "") tmp = hardInfo.GetMacAddress();
            string ret = DeviceObject.objAES.AesEncrypt(tmp, tmp);
            ret = DeviceObject.objDES.Des3EncryptA(ret, "123456789012345678901234");
            return ret;
        }

        ushort UpdateCRC(ushort src, byte ch)
        {
            int ret = (src << 8) ^ t16[ch ^ (src >> 8)];
            while ((ret > 65535) || (ret < 0)) ret = ret & 0xffff;
            return Convert.ToUInt16(ret);
        }

        ushort CRCCheck(char[] X, int Num)
        {
            ushort tmp = 0;
            if (Num > 0)
            {
                tmp = UpdateCRC(con_Initial, Convert.ToByte(X[0]));
                for (int i = 1; i < Num; i++) tmp = UpdateCRC(tmp, Convert.ToByte(X[i]));
            }
            return tmp;
        }
        string GetKeyEx(string Key)
        {
            string ret = Key;
            while (ret.Length < 5) ret = "0" + ret;
            return ret;
        }

        bool IsRightKey(string Key)
        {
            string tmp = Crypt.StrEncrypt(RegisterInfo.Serial, C_RegKey);
            char[] P = new char[tmp.Length];
            tmp.CopyTo(0, P, 0, tmp.Length);
            ushort CRC = CRCCheck(P, P.Length);
            return (GetKeyEx(Convert.ToString(CRC)) == Key);
        }

        bool IsRightKeyAll(string Key)
        {
            string tmp = Crypt.StrEncrypt("8EA9B7DF48CEE555", C_RegKey);
            char[] P = new char[tmp.Length];
            tmp.CopyTo(0, P, 0, tmp.Length);
            ushort CRC = CRCCheck(P, P.Length);
            return (GetKeyEx(Convert.ToString(CRC)) == Key);
        }

        bool IsRightSoft(string Key)
        {
            string tmp = Crypt.StrEncrypt(RegisterInfo.ProductName, Key0_int);
            char[] P = new char[tmp.Length];
            tmp.CopyTo(0, P, 0, tmp.Length);
            ushort CRC = CRCCheck(P, P.Length);
            return (GetKeyEx(Convert.ToString(CRC)) == Key);
        }

        bool IsUserKey(string User, string Key)
        {
            string tmp = Crypt.StrEncrypt(User, Key0_int);
            char[] P = new char[tmp.Length];
            tmp.CopyTo(0, P, 0, tmp.Length);
            ushort CRC = CRCCheck(P, P.Length);
            return (GetKeyEx(Convert.ToString(CRC)) == Key);
        }

        string GetRightKey()
        {
            string tmp = Crypt.StrEncrypt(RegisterInfo.Serial, C_RegKey);
            char[] P = new char[tmp.Length];
            tmp.CopyTo(0, P, 0, tmp.Length);
            ushort CRC = CRCCheck(P, P.Length);
            return GetKeyEx(Convert.ToString(CRC));
        }

        string GetRightSoft(int Key0_int)
        {
            string tmp = Crypt.StrEncrypt(RegisterInfo.ProductName, Key0_int);
            char[] P = new char[tmp.Length];
            tmp.CopyTo(0, P, 0, tmp.Length);
            ushort CRC = CRCCheck(P, P.Length);
            return GetKeyEx(Convert.ToString(CRC));
        }

        string GetUserKey(string User, int Key0_int)
        {
            string tmp = Crypt.StrEncrypt(User, Key0_int);
            char[] P = new char[tmp.Length];
            tmp.CopyTo(0, P, 0, tmp.Length);
            ushort CRC = CRCCheck(P, P.Length);
            return GetKeyEx(Convert.ToString(CRC));
        }

        string GetDateKey(bool IsAlways, DateTime ValidDate, string Key0)
        {
            string tmp = "36526";
            if (!IsAlways) tmp = ValidDate.ToOADate().ToString();
            return Crypt.StrEncrypt(tmp, Key0, 0);
        }

        public string GetRegKey(string User, bool IsAlways, DateTime ValidDate)
        {
            string Key0 = GetRightKey();
            int Key0_int = Convert.ToInt32(Key0) * 2;
            string Key1 = GetRightSoft(Key0_int);
            string Key2 = GetDateKey(IsAlways, ValidDate, Key0);
            string Key3 = GetUserKey(User, Key0_int);
            return Key0 + "-" + Key1 + "-" + Key2 + "-" + Key3;
        }

        public bool IsRegister(bool ReadDB, string RegUser, string RegKey)
        {
            bool ret = false;
            string ProdKey = Crypt.StrEncrypt(RegisterInfo.ProductName, C_RegKey);
            string tmp = "";
            RegisterInfo.RegUser = "";
            RegisterInfo.RegKey = "";
            RegisterInfo.IsAlways = true;
            RegisterInfo.IsTest = true;
            RegisterInfo.IsValid = true;
            tmp = ReadConfig("SystemRegister", "BasicName", "");
            if (tmp == "") return false;
            if (ReadDB)
            {
                RegUser = ReadConfig(RegisterInfo.Serial, "RegUser", "");
                RegKey = ReadConfig(RegisterInfo.Serial, "RegKey", "");
            }
            if (tmp == Crypt.StrEncrypt("36891", ProdKey, 0))
                RegisterInfo.StartDate = DateTime.Now.Date;
            else
            {
                double tmpD = 0;
                try
                {
                    tmpD = Convert.ToDouble(Crypt.StrDecrypt(tmp, ProdKey));
                }
                catch
                {
                    try
                    {
                        tmpD = Convert.ToDouble(Crypt.StrDecrypt(tmp, C_RegKey));
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    RegisterInfo.StartDate = DateTime.FromOADate(tmpD);
                }
            }
            try
            {
                tmp = Convert.ToString(RegisterInfo.StartDate.ToOADate());
                tmp = Crypt.StrEncrypt(tmp, ProdKey, 0);
                if (!WriteConfig("SystemRegister", "BasicName", tmp)) return false;
                RegisterInfo.EndDate = RegisterInfo.StartDate.AddDays(30);//试用期
                RegisterInfo.IsValid = (RegisterInfo.EndDate < DateTime.Now.Date);
                if (RegKey != "")
                {
                    tmp = RegKey;
                    string[] tmpS = tmp.Split('-');
                    string Key0 = "";
                    string Key1 = "";
                    string Key2 = "";
                    string Key3 = "";
                    if (tmpS.Length >= 1) Key0 = tmpS[0];
                    if (tmpS.Length >= 2) Key1 = tmpS[1];
                    if (tmpS.Length >= 3) Key2 = tmpS[2];
                    if (tmpS.Length >= 4) Key3 = tmpS[3];
                    if ((Key0 != "") && (Key1 != "") && (Key2 != "") && (Key3 != ""))
                    {
                        Key0_int = Convert.ToInt32(Key0) * 2;
                        if ((IsRightKey(Key0) || IsRightKeyAll(Key0)) && IsRightSoft(Key1) && IsUserKey(RegUser, Key3))
                        {
                            tmp = Crypt.StrDecrypt(Key2, Key0);
                            tmp = tmp.Substring(0, 5);
                            DateTime d = new DateTime();
                            d = DateTime.FromOADate(Convert.ToDouble(tmp));
                            if (Key2 == Crypt.StrEncrypt("36526", Key0, 0))
                            {
                                RegisterInfo.IsAlways = true;
                                RegisterInfo.IsValid = false;
                            }
                            else
                            {
                                RegisterInfo.IsValid = (d < DateTime.Now.Date);
                            }
                            if (!ReadDB)
                            {
                                if (!WriteConfig(RegisterInfo.Serial, "RegUser", RegUser)) return false;
                                if (!WriteConfig(RegisterInfo.Serial, "RegKey", RegKey)) return false;
                            }
                            RegisterInfo.EndDate = d;
                            RegisterInfo.IsTest = false;
                            RegisterInfo.RegUser = RegUser;
                            RegisterInfo.RegKey = RegKey;
                            if (RegisterInfo.RegKey != null) RegisterInfo.MustReg = true;
                            ret = true;
                        }
                    }
                }
            }catch(Exception e)
            {
                Pub.ShowErrorMsg(e);
            }
            if (RegisterInfo.IsTest)
            {
                if (RegisterInfo.IsValid)
                    RegisterInfo.StateText = Pub.GetResText("Main", "IsTest1", "");
                else
                    RegisterInfo.StateText = string.Format(Pub.GetResText("Main", "IsTest", ""),
                      RegisterInfo.EndDate.ToShortDateString());
            }
            else if (RegisterInfo.IsAlways)
            {
                RegisterInfo.StateText = string.Format(Pub.GetResText("Main", "IsAlways", ""), RegisterInfo.RegUser);
            }
            else
            {
                if (RegisterInfo.IsValid)
                    RegisterInfo.StateText = string.Format(Pub.GetResText("Main", "IsValid", ""), RegisterInfo.RegUser);
                else
                    RegisterInfo.StateText = string.Format(Pub.GetResText("Main", "IsAlways", ""), RegisterInfo.RegUser);
                RegisterInfo.RegDateText = string.Format(Pub.GetResText("Main", "IsValidDate", ""),
                  RegisterInfo.RegUser, RegisterInfo.EndDate.ToShortDateString());
            }
            return ret;
        }
    }

    public class TCommPort
    {
        private int _CommIndex;
        private string _CommName;

        public TCommPort(int Index, string Name)
        {
            _CommIndex = Index;
            _CommName = Name;
        }

        public int CommIndex
        {
            get { return _CommIndex; }
            set { _CommIndex = value; }
        }

        public string CommName
        {
            set { _CommName = value; }
        }

        public override string ToString()
        {
            return _CommName;
        }
    }

    public class TIDAndName
    {
        private string _id;
        private string _name;

        public TIDAndName(string id, string name)
        {
            _id = id;
            _name = name;
        }

        public string id
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

    public class FuncSubObject
    {
        private string _text = "";
        private string _name = "";
        private byte _IsLine = 0;
        private bool _isTool = false;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public byte IsLine
        {
            get { return _IsLine; }
            set { _IsLine = value; }
        }

        public bool IsTool
        {
            get { return _isTool; }
            set { _isTool = value; }
        }
    }

    public class TDIConnInfo
    {
        private int _MacSN = 0;
        private string _MacSN_GPRS = "";
        private byte _MacType = 0;
        private int _ConnType = 0;
        private string _CommPort = "";
        private int _CommBaudRate = 0;
        private string _NetHost = "";
        private int _NetPort = 0;
        private int _NetPassword = 0;
        private bool _IsGPRS = false;
        private int _MacSeriesTypeId = 0;
        private string _SeaSeries_Pwd = "";
        private string _MacSeriesUserName = "";

        public int MacSN
        {
            get { return _MacSN; }
            set { _MacSN = value; }
        }

        public string MacSN_GPRS
        {
            get { if (_IsGPRS|| MacSeriesTypeId == 3) return _MacSN_GPRS; else return _MacSN.ToString(); }
            set { _MacSN_GPRS = value; }
        }

        public byte MacType
        {
            get { return _MacType; }
            set { _MacType = value; }
        }

        public int ConnType
        {
            get { return _ConnType; }
            set { _ConnType = value; }
        }

        public string CommPort
        {
            get { return _CommPort; }
            set { _CommPort = value; }
        }

        public int CommPortInt
        {
            get
            {
                int ret = 0;
                int.TryParse(_CommPort.Substring(3), out ret);
                return ret;
            }
        }

        public int CommBaudRate
        {
            get { return _CommBaudRate; }
            set { _CommBaudRate = value; }
        }

        public string NetHost
        {
            get { return _NetHost; }
            set { _NetHost = value; }
        }

        public int NetPort
        {
            get { return _NetPort; }
            set { _NetPort = value; }
        }

        public int NetPassword
        {
            get { return _NetPassword; }
            set { _NetPassword = value; }
        }

        public bool IsGPRS
        {
            get { return _IsGPRS; }
            set { _IsGPRS = value; }
        }

        public int ProtocolType
        {
            get { return (int)FKProtocol.PROTOCOL_UDP; }
        }
        public int MacSeriesTypeId
        {
            get { return _MacSeriesTypeId; }
            set { _MacSeriesTypeId = value; }
        }
        public string SeaSeries_Pwd
        {
            get { return _SeaSeries_Pwd; }
            set { _SeaSeries_Pwd = value; }
        }
        public string MacSeriesUserName
        {
            get { return _MacSeriesUserName; }
            set { _MacSeriesUserName = value; }
        }
    }

    public class FuncObject
    {
        private string _text = "";
        private string _name = "";
        private System.Collections.ArrayList list = new System.Collections.ArrayList();

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int SubCount
        {
            get { return list.Count; }
        }

        public void SubAdd(string Name, string Text, byte IsLine, bool IsTool)
        {
            FuncSubObject obj = new FuncSubObject();
            obj.Name = Name;
            obj.Text = Text;
            obj.IsLine = IsLine;
            obj.IsTool = IsTool;
            list.Add(obj);
        }

        public FuncSubObject SubGet(int Index)
        {
            FuncSubObject obj = new FuncSubObject();

            if ((list.Count > 0) && (Index < list.Count)) obj = (FuncSubObject)list[Index];
            return obj;
        }
    }

    public class TRealSocket
    {
        public delegate void ReadSocketData(string SocketData);
        private Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private bool RunningFlag = false;
        private ReadSocketData ReadSocket;
        private bool IsSend = false;

        public TRealSocket(int Port, ReadSocketData readData)
        {
            ReadSocket = readData;
            IPEndPoint ipLocalPoint = new IPEndPoint(IPAddress.Any, Port);
            sock.Bind(ipLocalPoint);
            RunningFlag = true;
        }

        ~TRealSocket()
        {
            Stop();
        }

        public void Start()
        {
            ReceiveHandle();
        }

        public void Stop()
        {
            RunningFlag = false;
            if (sock != null) sock.Close();
            sock = null;
        }

        public void Send(string data)
        {
            int size = data.Length / 2;
            byte[] s = new byte[size];
            for (int i = 0; i < size; i++)
            {
                s[i] = Convert.ToByte(data.Substring(i * 2, 2), 16);
            }
            sock.Send(s);
        }

        private string ByteToHex(byte byt)
        {
            string ret = Convert.ToString(byt, 16);
            while (ret.Length < 2)
            {
                ret = "0" + ret;
            }
            return ret.ToUpper();
        }

        private void ReceiveHandle()
        {
            string msg;
            byte[] data = new byte[1024];
            while (RunningFlag)
            {
                if (sock == null || sock.Available < 1)
                {
                    Application.DoEvents();
                    continue;
                }
                if (IsSend)
                {
                    Application.DoEvents();
                    continue;
                }
                IsSend = true;
                int len = sock.Receive(data);
                msg = "";
                for (int i = 0; i < len; i++)
                {
                    msg += ByteToHex(data[i]);
                }
                ReadSocket(msg);
                IsSend = false;
            }
        }
    }

    public class KQTextFormatInfo
    {
        private Base Pub = new Base();

        public const string KQ_ConfigID = "KQSetup";
        public const string KQ_TextFormat = "TextFormat";

        private bool _Allow = false;
        private byte _SepFlag = 0;
        private string _SepStr = "";
        private bool _MacSNAllow = true;
        private byte _MacSNLen = 3;
        private byte _MacSNOrder = 0;
        private bool _EmpNoAllow = true;
        private byte _EmpNoLen = 10;
        private byte _EmpNoOrder = 1;
        private bool _EmpNameAllow = true;
        private byte _EmpNameLen = 20;
        private byte _EmpNameOrder = 2;
        private bool _CardNoAllow = true;
        private byte _CardNoLen = 10;
        private byte _CardNoOrder = 3;
        private bool _DataTimeAllow = true;
        private string _DataTimeFormat = "yyyyMMddHHmmss";
        private byte _DataTimeOrder = 4;

        public KQTextFormatInfo(string formatString)
        {
            string[] tmp = formatString.Split('#');
            if (tmp.Length >= 18)
            {
                _Allow = tmp[0] == "1";
                byte.TryParse(tmp[1], out _SepFlag);
                _SepStr = tmp[2];
                _MacSNAllow = tmp[3] == "1";
                byte.TryParse(tmp[4], out _MacSNLen);
                byte.TryParse(tmp[5], out _MacSNOrder);
                _EmpNoAllow = tmp[6] == "1";
                byte.TryParse(tmp[7], out _EmpNoLen);
                byte.TryParse(tmp[8], out _EmpNoOrder);
                _EmpNameAllow = tmp[9] == "1";
                byte.TryParse(tmp[10], out _EmpNameLen);
                byte.TryParse(tmp[11], out _EmpNameOrder);
                _CardNoAllow = tmp[12] == "1";
                byte.TryParse(tmp[13], out _CardNoLen);
                byte.TryParse(tmp[14], out _CardNoOrder);
                _DataTimeAllow = tmp[15] == "1";
                _DataTimeFormat = tmp[16];
                byte.TryParse(tmp[17], out _DataTimeOrder);
            }
        }

        public bool Allow
        {
            get { return _Allow; }
        }

        public byte SepFlag
        {
            get { return _SepFlag; }
        }

        public string SepStr
        {
            get { return _SepStr; }
        }

        public bool MacSNAllow
        {
            get { return _MacSNAllow; }
        }

        public byte MacSNLen
        {
            get { return _MacSNLen; }
        }

        public byte MacSNOrder
        {
            get { return _MacSNOrder; }
        }

        public bool EmpNoAllow
        {
            get { return _EmpNoAllow; }
        }

        public byte EmpNoLen
        {
            get { return _EmpNoLen; }
        }

        public byte EmpNoOrder
        {
            get { return _EmpNoOrder; }
        }

        public bool EmpNameAllow
        {
            get { return _EmpNameAllow; }
        }

        public byte EmpNameLen
        {
            get { return _EmpNameLen; }
        }

        public byte EmpNameOrder
        {
            get { return _EmpNameOrder; }
        }

        public bool CardNoAllow
        {
            get { return _CardNoAllow; }
        }

        public byte CardNoLen
        {
            get { return _CardNoLen; }
        }

        public byte CardNoOrder
        {
            get { return _CardNoOrder; }
        }

        public bool DataTimeAllow
        {
            get { return _DataTimeAllow; }
        }

        public string DataTimeFormat
        {
            get { return _DataTimeFormat; }
        }

        public byte DataTimeOrder
        {
            get { return _DataTimeOrder; }
        }

        public string GetKQFormatText(string MacSN, string EmpNo, string EmpName, string CardNo, DateTime dt)
        {
            string ret = "";
            string SepStr = "";
            string MacSNX = "";
            string EmpNoX = "";
            string EmpNameX = "";
            string CardNoX = "";
            string DataTimeX = "";
            if (_Allow)
            {
                switch (_SepFlag)
                {
                    case 0:
                        SepStr = "";
                        break;
                    case 1:
                        SepStr = "\t";
                        break;
                    default:
                        SepStr = _SepStr;
                        break;
                }
                if (_MacSNAllow)
                {
                    MacSNX = MacSN;
                    if (_MacSNLen > 0)
                    {
                        while (MacSNX.Length > _MacSNLen)
                        {
                            MacSNX = MacSNX.Substring(1);
                        }
                        while (MacSNX.Length < _MacSNLen)
                        {
                            MacSNX = " " + MacSNX;
                        }
                    }
                }
                if (_EmpNoAllow)
                {
                    EmpNoX = EmpNo;
                    if (_EmpNoLen > 0)
                    {
                        while (EmpNoX.Length > _EmpNoLen)
                        {
                            EmpNoX = EmpNoX.Substring(1);
                        }
                        while (EmpNoX.Length < _EmpNoLen)
                        {
                            EmpNoX = " " + EmpNoX;
                        }
                    }
                }
                if (_EmpNameAllow)
                {
                    EmpNameX = EmpName;
                    if (_EmpNameLen > 0)
                    {
                        while (Pub.GetTextLength(EmpNameX) > _EmpNameLen)
                        {
                            EmpNameX = EmpNameX.Substring(1);
                        }
                        while (Pub.GetTextLength(EmpNameX) < _EmpNameLen)
                        {
                            EmpNameX = " " + EmpNameX;
                        }
                    }
                }
                if (_CardNoAllow)
                {
                    CardNoX = CardNo;
                    if (_CardNoLen > 0)
                    {
                        while (CardNoX.Length > _CardNoLen)
                        {
                            CardNoX = CardNoX.Substring(1);
                        }
                        while (CardNoX.Length < _CardNoLen)
                        {
                            CardNoX = "0" + CardNoX;
                        }
                    }
                }
                if (_DataTimeAllow)
                {
                    DataTimeX = dt.ToString();
                    if (_DataTimeFormat != "") DataTimeX = dt.ToString(_DataTimeFormat);
                }
                if (_MacSNOrder == 0)
                    ret = ret + MacSNX + SepStr;
                else if (_EmpNoOrder == 0)
                    ret = ret + EmpNoX + SepStr;
                else if (_EmpNameOrder == 0)
                    ret = ret + EmpNameX + SepStr;
                else if (_CardNoOrder == 0)
                    ret = ret + CardNoX + SepStr;
                else if (_DataTimeOrder == 0)
                    ret = ret + DataTimeX + SepStr;
                if (_MacSNOrder == 1)
                    ret = ret + MacSNX + SepStr;
                else if (_EmpNoOrder == 1)
                    ret = ret + EmpNoX + SepStr;
                else if (_EmpNameOrder == 1)
                    ret = ret + EmpNameX + SepStr;
                else if (_CardNoOrder == 1)
                    ret = ret + CardNoX + SepStr;
                else if (_DataTimeOrder == 1)
                    ret = ret + DataTimeX + SepStr;
                if (_MacSNOrder == 2)
                    ret = ret + MacSNX + SepStr;
                else if (_EmpNoOrder == 2)
                    ret = ret + EmpNoX + SepStr;
                else if (_EmpNameOrder == 2)
                    ret = ret + EmpNameX + SepStr;
                else if (_CardNoOrder == 2)
                    ret = ret + CardNoX + SepStr;
                else if (_DataTimeOrder == 2)
                    ret = ret + DataTimeX + SepStr;
                if (_MacSNOrder == 3)
                    ret = ret + MacSNX + SepStr;
                else if (_EmpNoOrder == 3)
                    ret = ret + EmpNoX + SepStr;
                else if (_EmpNameOrder == 3)
                    ret = ret + EmpNameX + SepStr;
                else if (_CardNoOrder == 3)
                    ret = ret + CardNoX + SepStr;
                else if (_DataTimeOrder == 3)
                    ret = ret + DataTimeX + SepStr;
                if (_MacSNOrder == 4)
                    ret = ret + MacSNX + SepStr;
                else if (_EmpNoOrder == 4)
                    ret = ret + EmpNoX + SepStr;
                else if (_EmpNameOrder == 4)
                    ret = ret + EmpNameX + SepStr;
                else if (_CardNoOrder == 4)
                    ret = ret + CardNoX + SepStr;
                else if (_DataTimeOrder == 4)
                    ret = ret + DataTimeX + SepStr;
                if (ret.Substring(ret.Length - SepStr.Length) == SepStr) ret = ret.Substring(0, ret.Length - SepStr.Length);
            }
            return ret;
        }
    }

    public class CryptED
    {
        private readonly int C_1 = 42594;
        private readonly int C_2 = 14712;

        private string ByteToHex(byte b)
        {
            string ret = Convert.ToString(b, 16);
            while (ret.Length < 2) ret = "0" + ret;
            ret = ret.ToUpper();
            return ret;
        }

        private byte IntToByte(int src)
        {
            while ((src > 255) || (src < 0)) src = src & 0xff;
            return Convert.ToByte(src);
        }

        private byte StrToByte(string s)
        {
            char c = Convert.ToChar(s);
            int i = Convert.ToInt32(c);
            byte b = IntToByte(i);
            return b;
        }

        private byte StrToByte(char c)
        {
            byte b = Convert.ToByte(c);
            return b;
        }

        private string StringToBCD(string StrIn)
        {
            string ret = "";
            int Len = StrIn.Length;
            for (int I = 0; I < Len; I++)
            {
                string s = StrIn.Substring(I, 1);
                ret = ret + ByteToHex(StrToByte(s));
            }
            return ret;
        }

        private string Encrypt(string StrIn, int Key)
        {
            string ret = "";
            int Len = StrIn.Length;
            for (int I = 0; I < Len; I++)
            {
                string s = StrIn.Substring(I, 1);
                byte b = StrToByte(s);
                b = (byte)(b ^ (Key >> 8));
                s = Convert.ToChar(b).ToString();
                ret = ret + s;
                Key = (b + Key) * C_1 + C_2;
            }
            return ret;
        }

        private string StringEncryptToBCD(string StrIn, int Key)
        {
            return StringToBCD(Encrypt(StrIn, Key));
        }

        public string StrEncrypt(string src, string Key, int Len)
        {
            if (Len > 0) while (src.Length < Len) src = "0" + src;
            if (src == "") return "";
            int key = 0;
            for (int i = 0; i < Key.Length; i++) key = key + StrToByte(Key[i]);
            return StringEncryptToBCD(src, key);
        }

        public string StrEncrypt(string src, int Key)
        {
            if (src == "") return "";
            return StringEncryptToBCD(src, Key);
        }

        private int CharToInt(string c)
        {
            c = c.ToUpper();
            if ((c == "0") || (c == "1") || (c == "2") || (c == "3") || (c == "4") || (c == "5") ||
              (c == "6") || (c == "7") || (c == "8") || (c == "9"))
                return Convert.ToByte(Convert.ToChar(c)) - 48;
            else if ((c == "A") || (c == "B") || (c == "C") || (c == "D") || (c == "E") || (c == "F"))
                return Convert.ToByte(Convert.ToChar(c)) - 55;
            else
                return 0;
        }

        private string BCDToString(string StrIn)
        {
            string ret = "";
            int Len = StrIn.Length / 2;
            for (int I = 0; I < Len; I++)
            {
                string s = StrIn.Substring(I * 2, 1);
                int i1 = CharToInt(s) * 16;
                s = StrIn.Substring(I * 2 + 1, 1);
                int i2 = CharToInt(s);
                byte b = (byte)(i1 + i2);
                s = Convert.ToChar(b).ToString();
                ret = ret + s;
            }
            return ret;
        }

        private string Decrypt(string StrIn, int Key)
        {
            string ret = "";
            int Len = StrIn.Length;
            for (int I = 0; I < Len; I++)
            {
                string s = StrIn.Substring(I, 1);
                byte b = StrToByte(s);
                byte b1 = (byte)(b ^ (Key >> 8));
                s = Convert.ToChar(b1).ToString();
                ret = ret + s;
                Key = (b + Key) * C_1 + C_2;
            }
            return ret;
        }

        private string StringDecryptFromBCD(string StrIn, int Key)
        {
            return Decrypt(BCDToString(StrIn), Key);
        }

        public string StrDecrypt(string src, string Key)
        {
            int key = 0;
            for (int i = 0; i < Key.Length; i++) key = key + StrToByte(Key[i]);
            return StringDecryptFromBCD(src, key);
        }

        public string StrDecrypt(string src, int Key)
        {
            return StringDecryptFromBCD(src, Key);
        }
    }
}
