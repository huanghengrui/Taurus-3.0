using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using System.Net.Sockets;

namespace Taurus
{
    public enum FKRun
    {
        RUN_SUCCESS = 1,
        RUNERR_NOSUPPORT = 0,
        RUNERR_UNKNOWNERROR = -1,
        RUNERR_NO_OPEN_COMM = -2,
        RUNERR_WRITE_FAIL = -3,
        RUNERR_READ_FAIL = -4,
        RUNERR_INVALID_PARAM = -5,
        RUNERR_NON_CARRYOUT = -6,
        RUNERR_DATAARRAY_END = -7,
        RUNERR_DATAARRAY_NONE = -8,
        RUNERR_MEMORY = -9,
        RUNERR_MIS_PASSWORD = -10,
        RUNERR_MEMORYOVER = -11,
        RUNERR_DATADOUBLE = -12,
        RUNERR_MANAGEROVER = -14,
        RUNERR_FPDATAVERSION = -15,
        RUNERR_LOGINOUTMODE = -16
    }

    public enum StarFKRun
    {
        RUNERR_FULL_CAPACITY=-5,  //设备容量满
        RUNERR_CONNET = -4,      //通讯错误
        RUNERR_TIMEOUT = -3,     //超时错误
        RUNERR_PARAM = -2,          //参数错误
        RUNERR_ERRORR = -1,   //错误
        RUN_SUCCESS = 0,     //
        RUNERR_DEV_BUSY = 1, //设备忙
        RUNERR_DEV_WORKING = 2, //设备工作中
        RUNERR_DEV_WORK_SUCCESS = 3 //设备工作完成
    }

    public enum FKMax
    {
        MAX_BELLCOUNT_DAY = 24,
        MAX_PASSCTRLGROUP_COUNT = 50,
        MAX_PASSCTRL_COUNT = 7,         // Pass Count Max Value
        MAX_USERPASSINFO_COUNT = 3,
        MAX_GROUPPASSKIND_COUNT = 5,
        MAX_GROUPPASSINFO_COUNT = 3,
        MAX_GROUPMATCHINFO_COUNT = 10,
        MAX_PASSTIMECOUNT = 6,          //Pass Count Max Value
        MAX_TIMEGROUP = 255,            //Time Group
        MAX_RECORDTIMEINFO_COUNT = 6,   //Record Time

        MAX_REAL_TIME = 4,
        MAX_SHIFTCOUNT = 24,
        MAX_POSTCOUNT = 16,
        MAX_SHIFTDAY = 32,

        TIME_SLOT_COUNT = 6,
        TIME_ZONE_COUNT = 255,
        SIZE_TIME_ZONE_STRUCT = 32,
        SIZE_USER_WEEK_PASS_TIME_STRUCT = 16,

        FK_PasswordDataSize = 40,
        FK_FPDataSize = 1680,
        FK_FaceDataSize = 20080,
        FK_VeinDataSize = 3080,
        FK_PhotoDataSize = 15000,
        PALMVEINDataSize = 20080,
        FK_BellSize = MAX_BELLCOUNT_DAY * 3,
        FK_PassSize = 28,

        NAME_BYTE_COUNT = 128,
        USER_INFO_SIZE_V2 = 184,
        USER_INFO_SIZE_V3 = 196,
        USER_INFO_VER2 = 2,
        USER_INFO_VER3 = 3,
        POST_SHIFT_SIZE_V2 = 2476,
        POST_SHIFT_VER2 = 2,
        MAX_DAY_IN_MONTH = 31,
        USER_ID_LENGTH = 16,

        SIZE_EXT_CMD_CODE = 56,
        VER_USERDOORINFO_V1 = 2,
        SIZE_USERDOORINFO_V1 = 20
    }

    public enum FKBackup
    {
        BACKUP_FP_0 = 0,                // 被登记的第一个指纹区
        BACKUP_FP_1 = 1,                // Finger 1
        BACKUP_FP_2 = 2,                // Finger 2
        BACKUP_FP_3 = 3,                // Finger 3
        BACKUP_FP_4 = 4,                // Finger 4
        BACKUP_FP_5 = 5,                // Finger 5
        BACKUP_FP_6 = 6,                // Finger 6
        BACKUP_FP_7 = 7,                // Finger 7
        BACKUP_FP_8 = 8,                // Finger 8
        BACKUP_FP_9 = 9,                // 被登记的第十个指纹区
        BACKUP_PSW = 10,                // 被登记密码
        BACKUP_CARD = 11,               // 被登记卡号
        BACKUP_FACE = 12,               // Face
        BACKUP_PALMVEIN_0 = 13,
        BACKUP_PALMVEIN_1 = 14,
        BACKUP_PALMVEIN_2 = 15,
        BACKUP_PALMVEIN_3 = 16,
        BACKUP_VEIN_0 = 20              // Vein 0
    }

    //Manipulation of SuperLogData
    public enum FKSLog
    {
        LOG_ENROLL_USER = 3,               // Enroll-User
        LOG_ENROLL_MANAGER = 4,            // Enroll-Manager
        LOG_ENROLL_DELFP = 5,              // FP Delete
        LOG_ENROLL_DELPASS = 6,            // Pass Delete
        LOG_ENROLL_DELCARD = 7,            // Card Delete
        LOG_LOG_ALLDEL = 8,                // LogAll Delete
        LOG_SETUP_SYS = 9,                 // Setup Sys
        LOG_SETUP_TIME = 10,               // Setup Time
        LOG_SETUP_LOG = 11,                // Setup Log
        LOG_SETUP_COMM = 12,               // Setup Comm
        LOG_PASSTIME = 13,                 // Pass Time Set
        LOG_SETUP_DOOR = 14,               // Door Set Log
    };
    ///<summary>
    ////Manipulation of LogData
    ///</summary>
    public enum FKLog
    {
        //VerifyMode of GeneralLogData
        LOG_FPVERIFY = 1,               //Fp Verify
        LOG_PASSVERIFY = 2,             //Pass Verify
        LOG_CARDVERIFY = 3,             //Card Verify
        LOG_FPPASS_VERIFY = 4,          //Pass+Fp Verify
        LOG_FPCARD_VERIFY = 5,          //Card+Fp Verify
        LOG_PASSFP_VERIFY = 6,          //Pass+Fp Verify
        LOG_CARDFP_VERIFY = 7,          //Card+Fp Verify
        LOG_CARDPASS_VERIFY = 9,        //Card+Pass Verify
        LOG_FACEVERIFY = 20,            //Face Verify
        LOG_FACECARDVERIFY = 21,        //Face+Card Verify
        LOG_FACEPASSVERIFY = 22,        //Face+Pass Verify
        LOG_CARDFACEVERIFY = 23,        //Card+Face Verify
        LOG_PASSFACEVERIFY = 24,        //Pass+Face Verify
        LOG_FACE_FP_VERIFY = 25,        // Face+Finger Verify
        LOG_FP_FACE_VERIFY = 26,        // Finger+Face Verify
        LOG_VEINVERIFY_CIF11 = 30,      // Vein Verify
        LOG_VEINCARDVERIFY_CIF11 = 31,  // Vein+Card Verify
        LOG_VEINPASSVERIFY_CIF11 = 32,  // Vein+Pass Verify
        LOG_CARDVEINVERIFY_CIF11 = 33,  // Vein+Card Verify
        LOG_PASSVEINVERIFY_CIF11 = 34,  // Vein+Pass Verify
        LOG_PPVERIFY = 40,                  // PALM Verify
        LOG_PPPASSVERIFY = 41,              // Pass+PP Verify
        LOG_PPCARDVERIFY = 42,              // Card+PP Verify
        LOG_PASSPPVERIFY = 43,              // Pass+PP Verify
        LOG_CARDPPVERIFY = 44,              // Card+PP Verify
        LOG_FACE_PP_VERIFY = 45,            // Face+PP Verify
        LOG_PP_FACE_VERIFY = 46,            // PP+Face Verify
        LOG_FP_PP_VERIFY = 47,              // Fp+PP Verify
                                            //Verify Kind of Device

        LOG_MASK = 256,               //Mask
        LOG_MASK_WHITE = 257,               //Mask+White

        LOG_TEMPPERATURE = 512,               //temperature
        LOG_TEMPPERATURE_WHITE = 513,               //temperature+White

        LOG_TEMPPERATURE_MASK = 768,               //temperature+Mask
        LOG_TEMPPERATURE_MASK_WHITE_CARD = 793,               //temperature+Mask+White


        VK_NONE = 0,
        VK_FP = 1,
        VK_PASS = 2,
        VK_CARD = 3,
        VK_FACE = 4,
        VK_FINGERVEIN = 5,
        VK_IRIS = 6,
        VK_PALMVEIN = 7,
        VK_VOICE = 8,
        //IOMode of GeneralLogData
        LOG_IOMODE_IO = 0,
        LOG_IOMODE_IN1 = 1,
        LOG_IOMODE_OUT1 = 2,
        LOG_IOMODE_IN2 = 3,
        LOG_IOMODE_OUT2 = 4,
        LOG_IOMODE_IN3 = 5,
        LOG_IOMODE_OUT3 = 6,
        LOG_IOMODE_IN4 = 7,
        LOG_IOMODE_OUT4 = 8,
        //DoorMode of GeneralLogData
        LOG_CLOSE_DOOR = 1,                    //正常关门
        LOG_OPEN_HAND = 2,                     //开门按钮开门
        LOG_PROG_OPEN = 3,                     //电脑开门
        LOG_PROG_CLOSE = 4,                    //电脑关门
        LOG_OPEN_IREGAL = 5,                   //非法开门
        LOG_CLOSE_IREGAL = 6,                  //非法关门
        LOG_OPEN_COVER = 7,                    //机器外壳打开
        LOG_CLOSE_COVER = 8,                   //机器外壳关闭
        LOG_OPEN_DOOR = 9,                     //正常开门
        LOG_OPEN_DOOR_THREAT = 10             //胁迫开门
    }
    ///<summary>
    ////Machine Privilege
    ///</summary>
    public enum FKMP
    {
        MP_NONE = 0,                    // General user
        MP_MANAGER_1 = 1,               // Manager1 : Super Manager
        MP_MANAGER_2 = 2,               // Manager2 : General Manager
        MP_MANAGER_3 = 3                // Manager3 : Capable to register user
    }

    ///<summary>
    ////Index of  GetDeviceStatus
    ///</summary>
    public enum FKDS
    {
        GET_MANAGERS = 1,
        GET_USERS = 2,
        GET_FPS = 3,
        GET_PSWS = 4,
        GET_SLOGS = 5,
        GET_GLOGS = 6,
        GET_ASLOGS = 7,
        GET_AGLOGS = 8,
        GET_CARDS = 9,
        GET_FACES = 10,
        GET_PALMVEINS = 40
    }

    ///<summary>
    ////Index of  GetDeviceInfo
    ///</summary>
    public enum FKDI
    {
        DI_MANAGERS = 1,                // Numbers of Manager
        DI_MACHINENUM = 2,
        DI_LANGAUGE = 3,                // Language
        DI_POWEROFF_TIME = 4,           // Auto-PowerOff Time
        DI_LOCK_CTRL = 5,               // Lock Control
        DI_GLOG_WARNING = 6,            // General-Log Warning
        DI_SLOG_WARNING = 7,            // Super-Log Warning
        DI_VERIFY_INTERVALS = 8,        // Verify Interval Time
        DI_RSCOM_BPS = 9,               // Comm Buadrate
        DI_DATE_SEPARATE = 10,          // Date Separate Symbol
        DI_VERIFY_KIND = 24,            // VerrifyKind
        DI_MULTIUSERS = 77              // MultiUser
    }

    ///<summary>
    ////Baudrate = value of DI_RSCOM_BPS
    ///</summary>
    public enum FKBPS
    {
        BPS_9600 = 3,
        BPS_19200 = 4,
        BPS_38400 = 5,
        BPS_57600 = 6,
        BPS_115200 = 7
    }
    ///<summary>
    ////Door Status
    ///</summary>
    public enum FKDoor
    {
        DOOR_CONTROLRESET = 0,          // 机器的门控制状态
        DOOR_OPEND = 1,                 // 门已开
        DOOR_CLOSED = 2,                // 门已关
        DOOR_COMMNAD = 3                // 按照门控制指令，门开了后过一段时间自动关门
    }

    public enum ConnType
    {
        USB,
        Comm,
        TCPIP
    }

    public enum FKProtocol
    {
        PROTOCOL_TCPIP = 0,             // TCP/IP
        PROTOCOL_UDP = 1,               // UDP
    }

    public struct BellInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_BELLCOUNT_DAY)]
        public byte[] mValid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_BELLCOUNT_DAY)]
        public byte[] mHour;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_BELLCOUNT_DAY)]
        public byte[] mMinute;

        public void Init()
        {
            mValid = new byte[(int)FKMax.MAX_BELLCOUNT_DAY];
            mHour = new byte[(int)FKMax.MAX_BELLCOUNT_DAY];
            mMinute = new byte[(int)FKMax.MAX_BELLCOUNT_DAY];
        }
    }

    public struct PassTime
    {
        public byte StartHour;                  // Door open enable start time(hour)
        public byte StartMinute;              // Door open enable start time(minute)
        public byte EndHour;                  // Door open enable end time(hour)
        public byte EndMinute;                // Door open enable end time(minute)
    };

    public struct PassCtrlTime
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_PASSCTRL_COUNT)]
        public PassTime[] mPassTime;

        public void Init()
        {
            mPassTime = new PassTime[(int)FKMax.MAX_PASSCTRL_COUNT];
        }
    }

    public struct PassCtrlTimeAll
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_PASSCTRLGROUP_COUNT)]
        public PassCtrlTime[] mPassCtrlTime;

        public void Init()
        {
            mPassCtrlTime = new PassCtrlTime[(int)FKMax.MAX_PASSCTRLGROUP_COUNT];
            for (int i = 0; i < (int)FKMax.MAX_PASSCTRLGROUP_COUNT; i++)
            {
                mPassCtrlTime[i].Init();
            }
        }
    }

    public struct UserPassInfo
    {
        public static byte[] UserPassID = new byte[(int)FKMax.MAX_USERPASSINFO_COUNT];
    }

    public struct GroupPassInfo
    {
        public static byte[] GroupPassID = new byte[(int)FKMax.MAX_GROUPPASSINFO_COUNT];
    }

    public struct GroupMatchInfo
    {
        public static ushort[] GroupMatch = new ushort[(int)FKMax.MAX_GROUPMATCHINFO_COUNT];
    }


    public struct TimeSlot
    {
        public byte StartHour;
        public byte StartMinute;
        public byte EndHour;
        public byte EndMinute;
    };

    public struct TimeZone
    {
        public int Size;
        public int TimeZoneID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.TIME_SLOT_COUNT)]
        public TimeSlot[] TimeSlots;

        public void Init()
        {
            Size = (int)FKMax.SIZE_TIME_ZONE_STRUCT;
            TimeZoneID = 0;
            TimeSlots = new TimeSlot[(int)FKMax.TIME_SLOT_COUNT];
        }
    };

    public struct UserWeekPassTime
    {
        public int Size;
        public UInt32 UserID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public byte[] WeekPassTime;
        public byte Reserved;

        public void Init()
        {
            Size = (int)FKMax.SIZE_USER_WEEK_PASS_TIME_STRUCT;
            UserID = 0;
            WeekPassTime = new byte[7];
        }
    }

    public struct ExtCmdStructHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.SIZE_EXT_CMD_CODE)]
        public byte[] bytCmdCode;    // 0, 56
        public Int32 StructVer;     // 56, 4
        public Int32 StructSize;    // 60, 4

        public void Init(string asCmdCode, int aStructVer, int aStructSize)
        {
            bytCmdCode = new byte[(int)FKMax.SIZE_EXT_CMD_CODE];
            Array.Clear(bytCmdCode, 0, bytCmdCode.Length);
            byte[] bytAnsi = System.Text.Encoding.GetEncoding("utf-8").GetBytes(asCmdCode);
            int nBytesToCopy = bytAnsi.Length;
            if (nBytesToCopy > bytCmdCode.Length - 1) nBytesToCopy = bytCmdCode.Length - 1;
            Array.Copy(bytAnsi, bytCmdCode, nBytesToCopy);

            StructVer = aStructVer;
            StructSize = aStructSize;
        }
    }

    public struct ExtCmd_USERDOORINFO
    {
        public ExtCmdStructHeader CmdHeader;
        public UInt32 UserID;       //4
        public byte Reserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public byte[] WeekPassTime;
        public short StartYear;
        public byte StartMonth;
        public byte StartDay;
        public short EndYear;
        public byte EndMonth;
        public byte EndDay;

        public void Init(bool IsSet, UInt32 anUserID)
        {
            CmdHeader = new ExtCmdStructHeader();
            CmdHeader.Init(IsSet ? "ECMD_SetUserDoorInfo" : "ECMD_GetUserDoorInfo", (int)FKMax.VER_USERDOORINFO_V1, (int)FKMax.SIZE_USERDOORINFO_V1);
            WeekPassTime = new byte[7];
            UserID = anUserID;
            Reserved = 0;
            StartYear = 0;
            StartMonth = 0;
            StartDay = 0;
            EndYear = 0;
            EndMonth = 0;
            EndDay = 0;
        }
    }

    public struct DoorTime
    {
        public byte PassStartH;               // Door open enable start time(hour)
        public byte PassStartM;               // Door open enable start time(minute)
        public byte PassEndH;                   // Door open enable end time(hour)
        public byte PassEndM;                   // Door open enable end time(minute)
    }

    public struct DoorPassTime
    {
        public static DoorTime[] DoorTime = new DoorTime[(int)FKMax.MAX_PASSTIMECOUNT];
    }

    public struct LockInfo
    {
        public static DoorTime[,] LockTime = new DoorTime[(int)FKMax.MAX_TIMEGROUP, (int)FKMax.MAX_PASSTIMECOUNT];
    }

    public struct RecordTimeInfo
    {
        public static byte[] mValid = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mStartHour = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mStartMinute = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mEndHour = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mEndMinute = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mReserve = new byte[2];
    }

    public struct RealTimeInfo
    {
        public static byte Valid;
        public static byte AckTime;
        public static byte WaitTime;
        public static byte Reserve;
        public static int SendPos;
        public static byte[] Hour = new byte[(int)FKMax.MAX_REAL_TIME];
        public static byte[] Minute = new byte[(int)FKMax.MAX_REAL_TIME];
    }

    public struct ShiftTime
    {
        public static byte AMStartH;    //AM time(hour)
        public static byte AMStartM;    //AM min(minute)
        public static byte AMEndH;      //AM time(hour)
        public static byte AMEndM;      //AM min(minute)
        public static byte PMStartH;    //PM time(hour)
        public static byte PMStartM;    //PM min(minute)
        public static byte PMEndH;      //PM time(hour)
        public static byte PMEndM;      //PM min(minute)
        public static byte OVStartH;    //OV time(hour)
        public static byte OVStartM;    //OV min(minute)
        public static byte OVEndH;      //OV time(hour)
        public static byte OVEndM;      //OV min(minute)
    }

    public struct PostInfo
    {
        public static byte[] PostName = new byte[(int)FKMax.NAME_BYTE_COUNT];
    }

    public struct PostShift
    {
        public int Size;
        public int Ver;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_SHIFTCOUNT)]
        public ShiftTime[] ShiftTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_POSTCOUNT)]
        public PostInfo[] PostInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.NAME_BYTE_COUNT)]
        public byte[] CompanyName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Reserved;

        public void Init()
        {
            ShiftTime = new ShiftTime[(int)FKMax.MAX_SHIFTCOUNT];
            PostInfo = new PostInfo[(int)FKMax.MAX_POSTCOUNT];
            CompanyName = new byte[(int)FKMax.NAME_BYTE_COUNT];
            Reserved = new byte[4];
        }
    }

    public struct UserData
    {
        public int Size;
        public int Ver;
        public UInt32 UserId;
        public int Reserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.NAME_BYTE_COUNT)]
        public byte[] UserName;
        public int PostID;
        public short YearAssigned;
        public short MonthAssigned;
        public byte StartWeekdayOfMonth;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_DAY_IN_MONTH)]
        public byte[] ShiftID;

        public void Init()
        {
            UserName = new byte[(int)FKMax.NAME_BYTE_COUNT];
            ShiftID = new byte[(int)FKMax.MAX_DAY_IN_MONTH];
        }
    }

    public struct UserDataV3
    {
        public Int32 Size;                  // 0, 4
        public Int32 Ver;                   // 4, 4
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.USER_ID_LENGTH)]
        public byte[] UserId;                // 8, 4
        public Int32 Reserved;              // 12, 4
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.NAME_BYTE_COUNT)]
        public byte[] UserName;             // 16, 128
        public Int32 PostId;                // 144, 4
        public Int16 YearAssigned;          // 148, 2
        public Int16 MonthAssigned;         // 150, 2
        public byte StartWeekdayOfMonth;    // 152, 1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_DAY_IN_MONTH)]
        public byte[] ShiftId;              // 152, 32

        public void Init()
        {
            Size = (int)FKMax.USER_INFO_SIZE_V3;
            Ver = 2;
            UserId = new byte[(int)FKMax.USER_ID_LENGTH];
            YearAssigned = 0;
            MonthAssigned = 0;
            UserName = new byte[(int)FKMax.NAME_BYTE_COUNT];
            PostId = 0;
            ShiftId = new byte[(int)FKMax.MAX_DAY_IN_MONTH];
        }
    };  // size = 196 bytes

    /// <summary>
    /// 星系列设备的socket通讯
    /// </summary>
    public class SocKetClient
    {
        public Socket c_socket;
        public IPEndPoint point = null;
        public IAsyncResult asyncResult;
        private Base Pub = new Base();
       
        public const int PROTOCOLKEY = 0x18181818;  //协议token
        public byte[] Header = new byte[32];  //头协议
        public const int LEN = 4;
        public const int HEADERLEN = 32;

        public int ReceiveBufferSize = 409600; //接收的包的最大容量
        public int socKetPwd = 0;   //通讯密码
        public string socKetIp = "";
        public int socKetPort = 0;
        public bool IsOpen = false;
        public string ErrMsg = "";

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <param name="connetIp"></param>
        /// <param name="connetPort"></param>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public bool Start()
        {
            bool ret = false;
            try
            {
                //创建通信的Socket
                c_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(socKetIp);
                point = new IPEndPoint(ip, socKetPort);

                c_socket.SendTimeout = 30000;
                c_socket.ReceiveTimeout = 30000;

                //连接到对应的IP地址和端口号
                c_socket.Connect(point);
                IsOpen = true;
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public bool Open()
        {
            Close();
            return Start();
        }

        public bool Open(string connetIp, int connetPort, int pwd)
        {
            bool ret = false;
            socKetIp = connetIp;
            socKetPort = connetPort;
            socKetPwd = pwd;
            ret = Open();
            if (ret)
                ErrMsg = Pub.GetResText("", "FK_RUN_SUCCESS", "");
            else
                ErrMsg = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
            return ret;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if(c_socket != null)
            {
                if (c_socket.Connected)
                {
                    c_socket.Shutdown(SocketShutdown.Both);
                    c_socket.Close();
                    IsOpen = false;
                }
            }
        }

        /// <summary>
        /// 添加头数据到要发送的内容的前面，默认32字节
        /// </summary>
        /// <param name="sendBuff"></param>
        /// <returns></returns>
        public byte[] GetSendBuff(byte[] sendBuff)
        {
            byte[] newSendBuff = new byte[HEADERLEN + sendBuff.Length];
            byte[] buf = new byte[4];
            if (ConvertIntToByteArray(sendBuff.Length, ref buf))
                Buffer.BlockCopy(buf, 0,
                                Header, 0,
                                LEN);
            if (ConvertIntToByteArray(PROTOCOLKEY, ref buf))
                Buffer.BlockCopy(buf, 0,
                                Header, 4,
                                LEN);
            if (ConvertIntToByteArray(socKetPwd, ref buf))
                Buffer.BlockCopy(buf, 0,
                                Header, 8,
                                LEN);
            Buffer.BlockCopy(Header, 0,
                               newSendBuff, 0,
                               HEADERLEN);
            Buffer.BlockCopy(sendBuff, 0,
                               newSendBuff, HEADERLEN,
                               sendBuff.Length);
            return newSendBuff;
        }

        /// <summary>
        /// int类型转为byte[]类型
        /// </summary>
        /// <param name="m"></param>
        /// <param name="arry"></param>
        /// <returns></returns>
        public static bool ConvertIntToByteArray(Int32 m, ref byte[] arry)
        {
            if (arry == null) return false;
            if (arry.Length < 4) return false;

            arry[0] = (byte)(m & 0xFF);
            arry[1] = (byte)((m & 0xFF00) >> 8);
            arry[2] = (byte)((m & 0xFF0000) >> 16);
            arry[3] = (byte)((m >> 24) & 0xFF);

            return true;
        }
        /// <summary>
        /// 发送的数据
        /// </summary>
        public bool SendData(ref StringBuilder jsonStringBuilder)
        {
            bool ret = false;
            byte[] buffer = Encoding.UTF8.GetBytes(jsonStringBuilder.ToString());
            buffer = GetSendBuff(buffer);
            jsonStringBuilder = new StringBuilder("");
            try
            {
                c_socket.Send(buffer);
                Thread.Sleep(100);
                Recive(ref jsonStringBuilder);
                ret = true;
            }
            catch/*(Exception E)*/
            {
                ret = false;
                return ret;
            }
            finally
            {
                if (ret)
                    ErrMsg = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                else
                    ErrMsg = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
            }
            return ret;
        }

        /// <summary>
        /// 解析从设备获取到的数据
        /// </summary>
        public int JsonRecive(StringBuilder jsonStringBuilder)
        {
            string reciveDataStr = jsonStringBuilder.ToString();
            if (!reciveDataStr.Contains("cmd"))
            {
                ErrMsg = GetStarState(-6);
                return -6;
            }

            _AnswerInfo resultInfo = JsonConvert.DeserializeObject<_AnswerInfo>(reciveDataStr);

            ErrMsg = GetStarState(resultInfo.result_code);

            return resultInfo.result_code;
        }
       
        /// <summary>
        /// 接收信息
        /// </summary>
        public void Recive(ref StringBuilder jsonStringBuilder)
        {
            int numberValidBytes = 0;
            byte[] buffer = null;
            byte[] newbuffer = null;
            int bufCount = 0;
            int bufRecCount = 0;
            string token = "";
            string reciveData = "";
            while (true)
            {
                try
                {
                    if (!c_socket.Connected)
                    {
                        break;
                    }

                    buffer = new byte[ReceiveBufferSize];
                    numberValidBytes = c_socket.Receive(buffer);

                    //实际接收到的有效字节数
                    if (numberValidBytes <= 0)
                    {
                        break;
                    }
                    else      //表示收到的是数据
                    {
                        if(jsonStringBuilder.Length == 0)
                        {
                            if (numberValidBytes >= 32)
                            {
                                byte[] bufLength = new byte[4];
                                Array.Copy(buffer, 4, bufLength, 0, 4);
                                token = bufLength[0].ToString("X") + bufLength[1].ToString("X") + bufLength[2].ToString("X") + bufLength[3].ToString("X");
                                
                                if (token == "18181818")     //对应0x18181818
                                {
                                    Array.Copy(buffer, 0, bufLength, 0, 4);
                                    bufCount = BitConverter.ToInt32(bufLength, 0);
                                    if (numberValidBytes > 32)
                                    {
                                        numberValidBytes = numberValidBytes - 32;
                                        newbuffer = new byte[numberValidBytes];
                                        Array.Copy(buffer, 32, newbuffer, 0, numberValidBytes);
                                        buffer = newbuffer;
                                    }
                                    else
                                        continue;
                                }
                            }
                        }
                        
                        reciveData = Encoding.UTF8.GetString(buffer, 0, numberValidBytes);
                        bufRecCount += numberValidBytes;
                        if (reciveData.Length > 0)
                        {
                            if(jsonStringBuilder.Length == 0)
                            {
                                jsonStringBuilder = new StringBuilder(reciveData, numberValidBytes + 1024);
                            }
                            else
                            {
                                jsonStringBuilder.Append(reciveData);
                            }
                            
                            if (bufRecCount >= bufCount) //接收一包数据完成
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception E)
                {
                    throw E;
                }
            
            }
        }

        public string GetStarState(int index)
        {
            string ret = "";
            switch (index)
            {
                case (int)StarFKRun.RUNERR_FULL_CAPACITY:
                    ret = Pub.GetResText("", "FK_RUNERR_FULL_CAPACITY", "");
                    break;
                case (int)StarFKRun.RUNERR_CONNET:
                    ret = Pub.GetResText("", "FK_RUNERR_CONNET", "");
                    break;
                case (int)StarFKRun.RUNERR_TIMEOUT:
                    ret = Pub.GetResText("", "FK_RUNERR_TIMEOUT", "");
                    break;
                case (int)StarFKRun.RUNERR_PARAM:
                    ret = Pub.GetResText("", "FK_RUNERR_PARAM", "");
                    break;
                case (int)StarFKRun.RUNERR_ERRORR:
                    ret = Pub.GetResText("", "FK_RUNERR_ERRORR", "");
                    break;
                case (int)StarFKRun.RUN_SUCCESS:
                    ret = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                    break;
                case (int)StarFKRun.RUNERR_DEV_BUSY:
                    ret = Pub.GetResText("", "FK_RUNERR_DEV_BUSY", "");
                    break;
                case (int)StarFKRun.RUNERR_DEV_WORKING:
                    ret = Pub.GetResText("", "FK_RUNERR_DEV_WORKING", "");
                    break;
                case (int)StarFKRun.RUNERR_DEV_WORK_SUCCESS:
                    ret = Pub.GetResText("", "FK_RUNERR_DEV_WORK_SUCCESS", "");
                    break;
                default:
                    ret = Pub.GetResText("", "FK_RUNERR_UNKNOWNERROR", "");
                    break;
            }
            return ret;
        }
    }

    ///<summary>
    ///调用FK623Attend.dll
    ///</summary>
    public class FK623Attend
    {
        private Taurus.Base Pub = new Taurus.Base();
        private const string Dll_FK623Attend = "FK623Attend.dll";
        private TDIConnInfo conn = null;
        private static bool OpenFlag = false;
        private static int hComm = 0;
        private const int License = 1261;
        public static int ResultCode = (int)FKRun.RUN_SUCCESS;
        private static int ReTimes = 0;
        public static string SeaBody = "";

        public string SeaBodyStr()
        {
            return SeaBody;
        }

        public FK623Attend()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static FtpWebRequest FtpGetRequest(string URI, string username, string password)
        {
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
            //提供身份验证信息
            result.Credentials = new System.Net.NetworkCredential(username, password);
            //设置请求完成之后是否保持到FTP服务器的控制连接，默认值为true
            result.KeepAlive = false;
            return result;
        }


        public bool POST_GetResponse(string url, string name, string pwd, ref string json )
        {
            string StrDate = "";
            try
            {
                //此处为为http请求url 
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                CookieContainer cookieContainer = new CookieContainer();
                request.KeepAlive = false; //解决基础连接已关闭
                request.ProtocolVersion = HttpVersion.Version11;//解决基础连接已关闭
                request.CookieContainer = cookieContainer;
                request.Credentials = GetCredentialCache(url, name, pwd);
                request.Headers.Add("Authorization", GetAuthorization(name, pwd));
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                request.AllowAutoRedirect = true;
                request.Timeout = 30000;
               
                byte[] payload = Encoding.UTF8.GetBytes(json);
                json = "";
                request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                
                StreamReader Reader = new StreamReader(s, Encoding.UTF8);
                while ((StrDate = Reader.ReadLine()) != null)
                {
                    json += StrDate;
                }
            }
            catch(Exception e)
            {
                //Pub.ShowErrorMsg(E);
                string s = e.Message;
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                return false;
            }
            if (json == "")
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                return false;
            }
            else
            {
                try
                {
                    jsonBody<Answer> body = JsonConvert.DeserializeObject<jsonBody<Answer>>(json);
                    if (body.info.Result == "Fail")
                    {
                        FK623Attend.SeaBody = body.info.Detail;
                        return false;
                    }
                    else
                    {
                        FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                        return true;
                    }
                }
                catch
                {
                    FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                    return true;
                }
              
            }
        }

        /// <summary>
        /// 创建认证
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static CredentialCache GetCredentialCache(string uri, string username, string password)
        {
            CredentialCache credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Basic", new NetworkCredential(username, password));

            return credCache;
        }
        /// <summary>
        /// 创建Basic
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string GetAuthorization(string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            return "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
        }

        public void InitConn(TDIConnInfo connInfo)
        {
            conn = connInfo;
        }

        public bool IsOpen
        {
            get { return OpenFlag; }
        }

        public void Open()
        {
            Close();
            ResultCode = (int)FKRun.RUNERR_UNKNOWNERROR;
            if (conn.ConnType == 0)
                hComm = ConnectUSB(conn.MacSN);
            else if (conn.ConnType == 1)
                hComm = ConnectComm(conn.MacSN, conn.CommPortInt, conn.CommBaudRate, "", 0, 0);
            else
            {
                IPAddress ip;
                if (!IPAddress.TryParse(conn.NetHost, out ip))
                {
                    try
                    {
                        IPHostEntry hostEntry = Dns.GetHostEntry(conn.NetHost);
                        IPEndPoint ipEndPoint = new IPEndPoint(hostEntry.AddressList[0], 0);
                        conn.NetHost = ipEndPoint.Address.ToString();
                    }
                    catch
                    {
                    }
                }
                if (conn.IsGPRS)
                    hComm = ConnectGPRS(conn.MacSN_GPRS, conn.NetHost, conn.NetPort, 0, 0, conn.NetPassword);
                else
                    hComm = ConnectNet(conn.MacSN, conn.NetHost, conn.NetPort, 0, 0, conn.NetPassword);
            }
            if (hComm > 0)
            {
                OpenFlag = true;
                ResultCode = (int)FKRun.RUN_SUCCESS;
            }
            else
            {
                ResultCode = hComm;
            }
        }

        public bool ReOpen()
        {
            bool ret = false;
            ReTimes = 0;
            Close();
            while (ReTimes < 5)
            {
                ReTimes++;
                Open();
                if (OpenFlag)
                {
                    EnableDevice(0);
                    break;
                }
            }
            ret = OpenFlag;
            return ret;
        }

        public string ErrMsg
        {
            get { return ReturnResultPrint(); }
        }

        public int RunCode
        {
            get { return ResultCode; }
            set { ResultCode = value; }
        }

        public void Close()
        {
            if (OpenFlag) DisConnect();
            OpenFlag = false;
        }

        public string GetRunMsg(int ResultCode)
        {
            switch (ResultCode)
            {
                case (int)FKRun.RUN_SUCCESS: return Pub.GetResText("", "FK_RUN_SUCCESS", "");
                case (int)FKRun.RUNERR_NOSUPPORT: return Pub.GetResText("", "FK_RUNERR_NOSUPPORT", "");
                case (int)FKRun.RUNERR_UNKNOWNERROR: return Pub.GetResText("", "FK_RUNERR_UNKNOWNERROR", "");
                case (int)FKRun.RUNERR_NO_OPEN_COMM: return Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                case (int)FKRun.RUNERR_WRITE_FAIL: return Pub.GetResText("", "FK_RUNERR_WRITE_FAIL", "");
                case (int)FKRun.RUNERR_READ_FAIL: return Pub.GetResText("", "FK_RUNERR_READ_FAIL", "");
                case (int)FKRun.RUNERR_INVALID_PARAM: return Pub.GetResText("", "FK_RUNERR_INVALID_PARAM", "");
                case (int)FKRun.RUNERR_NON_CARRYOUT: return Pub.GetResText("", "FK_RUNERR_NON_CARRYOUT", "");
                case (int)FKRun.RUNERR_DATAARRAY_END: return Pub.GetResText("", "FK_RUNERR_DATAARRAY_END", "");
                case (int)FKRun.RUNERR_DATAARRAY_NONE: return Pub.GetResText("", "FK_RUNERR_DATAARRAY_NONE", "");
                case (int)FKRun.RUNERR_MEMORY: return Pub.GetResText("", "FK_RUNERR_MEMORY", "");
                case (int)FKRun.RUNERR_MIS_PASSWORD: return Pub.GetResText("", "FK_RUNERR_MIS_PASSWORD", "");
                case (int)FKRun.RUNERR_MEMORYOVER: return Pub.GetResText("", "FK_RUNERR_MEMORYOVER", "");
                case (int)FKRun.RUNERR_DATADOUBLE: return Pub.GetResText("", "FK_RUNERR_DATADOUBLE", "");
                case (int)FKRun.RUNERR_MANAGEROVER: return Pub.GetResText("", "FK_RUNERR_MANAGEROVER", "");
                case (int)FKRun.RUNERR_FPDATAVERSION: return Pub.GetResText("", "FK_RUNERR_FPDATAVERSION", "");
                case (int)FKRun.RUNERR_LOGINOUTMODE: return Pub.GetResText("", "FK_RUNERR_LOGINOUTMODE", "");
                default:
                    return Pub.GetResText("", "FK_RUNERR_UNKNOWNERROR", "");
            }
        }

        private string GetStringVerifyMode(ref int VerifyMode)
        {
            string ret = "";
            if (VerifyMode == 0) return ret;
            int bytCount = 4;
            byte[] bytKind = new byte[bytCount];
            int vFirstKind, vSecondKind;
            bytKind = BitConverter.GetBytes(VerifyMode);
            for (int i = bytCount - 1; i >= 0; i--)
            {
                vFirstKind = vSecondKind = bytKind[i];
                vFirstKind = vFirstKind & 0xF0;
                vSecondKind = vSecondKind & 0x0F;
                vFirstKind = vFirstKind >> 4;
                if (vFirstKind == 0) break;
                if (i < bytCount - 1) ret += "+";
                switch (vFirstKind)
                {
                    case (int)FKLog.VK_FP:
                        ret += Pub.GetResText("Public", "VK_FP", "");
                        VerifyMode = (int)FKLog.LOG_FPVERIFY;
                        break;
                    case (int)FKLog.VK_PASS:
                        ret += Pub.GetResText("Public", "VK_PASS", "");
                        VerifyMode = (int)FKLog.LOG_PASSVERIFY;
                        break;
                    case (int)FKLog.VK_CARD:
                        ret += Pub.GetResText("Public", "VK_CARD", "");
                        VerifyMode = (int)FKLog.LOG_CARDVERIFY;
                        break;
                    case (int)FKLog.VK_FACE:
                        ret += Pub.GetResText("Public", "VK_FACE", "");
                        VerifyMode = (int)FKLog.LOG_FACEVERIFY;
                        break;
                    case (int)FKLog.VK_FINGERVEIN:
                        ret += Pub.GetResText("Public", "VK_FINGERVEIN", "");
                        VerifyMode = vFirstKind;
                        break;
                    case (int)FKLog.VK_IRIS:
                        ret += Pub.GetResText("Public", "VK_IRIS", "");
                        VerifyMode = vFirstKind;
                        break;
                    case (int)FKLog.VK_PALMVEIN:
                        ret += Pub.GetResText("Public", "VK_PALMVEIN", "");
                        VerifyMode = vFirstKind;
                        break;
                    case (int)FKLog.VK_VOICE:
                        ret += Pub.GetResText("Public", "VK_VOICE", "");

                        VerifyMode = vFirstKind;
                        break;
                }
                if (vSecondKind == 0) break;
                ret += "+";
                switch (vSecondKind)
                {
                    case (int)FKLog.VK_FP:
                        ret += Pub.GetResText("Public", "VK_FP", "");
                        VerifyMode = (int)FKLog.LOG_FPVERIFY;
                        break;
                    case (int)FKLog.VK_PASS:
                        ret += Pub.GetResText("Public", "VK_PASS", "");
                        VerifyMode = (int)FKLog.LOG_PASSVERIFY;
                        break;
                    case (int)FKLog.VK_CARD:
                        ret += Pub.GetResText("Public", "VK_CARD", "");
                        VerifyMode = (int)FKLog.LOG_CARDVERIFY;
                        break;
                    case (int)FKLog.VK_FACE:
                        ret += Pub.GetResText("Public", "VK_FACE", "");
                        VerifyMode = (int)FKLog.LOG_FACEVERIFY;
                        break;
                    case (int)FKLog.VK_FINGERVEIN:
                        ret += Pub.GetResText("Public", "VK_FINGERVEIN", "");
                        VerifyMode = vSecondKind;
                        break;
                    case (int)FKLog.VK_IRIS:
                        ret += Pub.GetResText("Public", "VK_IRIS", "");
                        VerifyMode = vSecondKind;
                        break;
                    case (int)FKLog.VK_PALMVEIN:
                        ret += Pub.GetResText("Public", "VK_PALMVEIN", "");
                        VerifyMode = vSecondKind;
                        break;
                    case (int)FKLog.VK_VOICE:
                        ret += Pub.GetResText("Public", "VK_VOICE", "");
                        VerifyMode = vSecondKind;
                        break;
                }
            }
            if (ret == "") ret = "--";
            return ret;
        }

        private void GetIoModeAndDoorMode(int InOutMode, ref int IoMode, ref int DoorMode, ref int InOut)
        {
            byte[] bytKind = new byte[4];
            byte[] bytDoorMode = new byte[4];
            bytKind = BitConverter.GetBytes(InOutMode);
            //IoMode = bytKind[0];
            IoMode = bytKind[0] & 0x0f;
            InOut = bytKind[0] >> 4;
            for (int i = 0; i < 3; i++)
            {
                bytDoorMode[i] = bytKind[i + 1];
            }
            bytDoorMode[3] = 0;
            DoorMode = BitConverter.ToInt32(bytDoorMode, 0);
        }

        public void GetVerifyModeName(ref int VerifyMode, ref int InOutMode, ref string VerifyName, ref string InOutName,
          ref int DoorMode, ref string DoorModeName, ref bool Bell,ref int InOut)
        {
            VerifyName = "";
            InOutName = "";
            DoorMode = 0;
            DoorModeName = "";
            InOut = 0;
            switch (VerifyMode)
            {
                case (int)FKLog.LOG_FPVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FPVERIFY", "");
                    break;
                case (int)FKLog.LOG_PASSVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PASSVERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDVERIFY", "");
                    break;
                case (int)FKLog.LOG_FPPASS_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FPPASS_VERIFY", "");
                    break;
                case (int)FKLog.LOG_FPCARD_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FPCARD_VERIFY", "");
                    break;
                case (int)FKLog.LOG_PASSFP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PASSFP_VERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDFP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDFP_VERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDPASS_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDPASS_VERIFY", "");
                    break;
                case (int)FKLog.LOG_FACEVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACEVERIFY", "");
                    break;
                case (int)FKLog.LOG_FACECARDVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACECARDVERIFY", "");
                    break;
                case (int)FKLog.LOG_FACEPASSVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACEPASSVERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDFACEVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDFACEVERIFY", "");
                    break;
                case (int)FKLog.LOG_PASSFACEVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PASSFACEVERIFY", "");
                    break;
                case (int)FKLog.LOG_FACE_FP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACE_FP_VERIFY", "");
                    break;
                case (int)FKLog.LOG_FP_FACE_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FP_FACE_VERIFY", "");
                    break;
                case (int)FKLog.LOG_PPVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PPVERIFY", "");
                    break;
                case (int)FKLog.LOG_PPPASSVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PPPASSVERIFY", "");
                    break;
                case (int)FKLog.LOG_PPCARDVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PPCARDVERIFY", "");
                    break;
                case (int)FKLog.LOG_PASSPPVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PASSPPVERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDPPVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDPPVERIFY", "");
                    break;
                case (int)FKLog.LOG_FACE_PP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACE_PP_VERIFY", "");
                    break;
                case (int)FKLog.LOG_PP_FACE_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PP_FACE_VERIFY", "");
                    break;
                case (int)FKLog.LOG_FP_PP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FP_PP_VERIFY", "");
                    break;
                default:
                    VerifyName = GetStringVerifyMode(ref VerifyMode);
                    break;
            }
            int IoMode = 0;
            GetIoModeAndDoorMode(InOutMode, ref IoMode, ref DoorMode,ref InOut );
            switch (DoorMode)
            {
                case (int)FKLog.LOG_CLOSE_DOOR:
                    DoorModeName = Pub.GetResText("Public", "LOG_CLOSE_DOOR", "");
                    break;
                case (int)FKLog.LOG_OPEN_HAND:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_HAND", "");
                    break;
                case (int)FKLog.LOG_PROG_OPEN:
                    DoorModeName = Pub.GetResText("Public", "LOG_PROG_OPEN", "");
                    // Bell = true;
                    break;
                case (int)FKLog.LOG_PROG_CLOSE:
                    DoorModeName = Pub.GetResText("Public", "LOG_PROG_CLOSE", "");
                    break;
                case (int)FKLog.LOG_OPEN_IREGAL:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_IREGAL", "");
                    Bell = true;
                    break;
                case (int)FKLog.LOG_CLOSE_IREGAL:
                    DoorModeName = Pub.GetResText("Public", "LOG_CLOSE_IREGAL", "");
                    Bell = true;
                    break;
                case (int)FKLog.LOG_OPEN_COVER:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_COVER", "");
                    Bell = true;
                    break;
                case (int)FKLog.LOG_CLOSE_COVER:
                    DoorModeName = Pub.GetResText("Public", "LOG_CLOSE_COVER", "");
                    Bell = true;
                    break;
                case (int)FKLog.LOG_OPEN_DOOR:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_DOOR", "");
                    break;
                case (int)FKLog.LOG_OPEN_DOOR_THREAT:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_DOOR_THREAT", "");
                    Bell = true;
                    break;
            }
            switch (IoMode)
            {
                case (int)FKLog.LOG_IOMODE_IO:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IO", "");
                    break;
                case (int)FKLog.LOG_IOMODE_IN1:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN1", "");
                    break;
                case (int)FKLog.LOG_IOMODE_OUT1:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT1", "");
                    break;
                case (int)FKLog.LOG_IOMODE_IN2:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN2", "");
                    break;
                case (int)FKLog.LOG_IOMODE_OUT2:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT2", "");
                    break;
                case (int)FKLog.LOG_IOMODE_IN3:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN3", "");
                    break;
                case (int)FKLog.LOG_IOMODE_OUT3:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT3", "");
                    break;
                case (int)FKLog.LOG_IOMODE_IN4:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN4", "");
                    break;
                case (int)FKLog.LOG_IOMODE_OUT4:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT4", "");
                    break;
                default:
                    InOutName = IoMode.ToString();
                    break;
            }
            InOutMode = IoMode;

            if (InOut != 0)
            {
                if (InOut == 1)
                {
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN1", ""); 
                }
                else
                {
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT1", "");
                }
                InOutMode = InOut;
            }
        }
        public void Star_GetVerifyModeName(ref int VerifyMode, ref int InOutMode, ref string VerifyName, ref string InOutName,
        ref int DoorMode, ref string DoorModeName, ref bool Bell, ref int InOut,ref int IoMode)
        {
            switch (VerifyMode)
            {
                case (int)FKLog.LOG_FPVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FPVERIFY", "");
                    break;
                case (int)FKLog.LOG_PASSVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PASSVERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDVERIFY", "");
                    break;
                case (int)FKLog.LOG_FPPASS_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FPPASS_VERIFY", "");
                    break;
                case (int)FKLog.LOG_FPCARD_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FPCARD_VERIFY", "");
                    break;
                case (int)FKLog.LOG_PASSFP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PASSFP_VERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDFP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDFP_VERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDPASS_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDPASS_VERIFY", "");
                    break;
                case (int)FKLog.LOG_FACEVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACEVERIFY", "");
                    break;
                case (int)FKLog.LOG_FACECARDVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACECARDVERIFY", "");
                    break;
                case (int)FKLog.LOG_FACEPASSVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACEPASSVERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDFACEVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDFACEVERIFY", "");
                    break;
                case (int)FKLog.LOG_PASSFACEVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PASSFACEVERIFY", "");
                    break;
                case (int)FKLog.LOG_FACE_FP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACE_FP_VERIFY", "");
                    break;
                case (int)FKLog.LOG_FP_FACE_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FP_FACE_VERIFY", "");
                    break;
                case (int)FKLog.LOG_PPVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PPVERIFY", "");
                    break;
                case (int)FKLog.LOG_PPPASSVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PPPASSVERIFY", "");
                    break;
                case (int)FKLog.LOG_PPCARDVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PPCARDVERIFY", "");
                    break;
                case (int)FKLog.LOG_PASSPPVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PASSPPVERIFY", "");
                    break;
                case (int)FKLog.LOG_CARDPPVERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_CARDPPVERIFY", "");
                    break;
                case (int)FKLog.LOG_FACE_PP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FACE_PP_VERIFY", "");
                    break;
                case (int)FKLog.LOG_PP_FACE_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_PP_FACE_VERIFY", "");
                    break;
                case (int)FKLog.LOG_FP_PP_VERIFY:
                    VerifyName = Pub.GetResText("Public", "LOG_FP_PP_VERIFY", "");
                    break;
                default:
                    VerifyName = GetStringVerifyMode(ref VerifyMode);
                    break;
            }
            switch (DoorMode)
            {
                case (int)FKLog.LOG_CLOSE_DOOR:
                    DoorModeName = Pub.GetResText("Public", "LOG_CLOSE_DOOR", "");
                    break;
                case (int)FKLog.LOG_OPEN_HAND:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_HAND", "");
                    break;
                case (int)FKLog.LOG_PROG_OPEN:
                    DoorModeName = Pub.GetResText("Public", "LOG_PROG_OPEN", "");
                    // Bell = true;
                    break;
                case (int)FKLog.LOG_PROG_CLOSE:
                    DoorModeName = Pub.GetResText("Public", "LOG_PROG_CLOSE", "");
                    break;
                case (int)FKLog.LOG_OPEN_IREGAL:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_IREGAL", "");
                    Bell = true;
                    break;
                case (int)FKLog.LOG_CLOSE_IREGAL:
                    DoorModeName = Pub.GetResText("Public", "LOG_CLOSE_IREGAL", "");
                    Bell = true;
                    break;
                case (int)FKLog.LOG_OPEN_COVER:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_COVER", "");
                    Bell = true;
                    break;
                case (int)FKLog.LOG_CLOSE_COVER:
                    DoorModeName = Pub.GetResText("Public", "LOG_CLOSE_COVER", "");
                    Bell = true;
                    break;
                case (int)FKLog.LOG_OPEN_DOOR:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_DOOR", "");
                    break;
                case (int)FKLog.LOG_OPEN_DOOR_THREAT:
                    DoorModeName = Pub.GetResText("Public", "LOG_OPEN_DOOR_THREAT", "");
                    Bell = true;
                    break;
            }
            switch (IoMode)
            {
                case (int)FKLog.LOG_IOMODE_IO:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IO", "");
                    break;
                case (int)FKLog.LOG_IOMODE_IN1:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN1", "");
                    break;
                case (int)FKLog.LOG_IOMODE_OUT1:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT1", "");
                    break;
                case (int)FKLog.LOG_IOMODE_IN2:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN2", "");
                    break;
                case (int)FKLog.LOG_IOMODE_OUT2:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT2", "");
                    break;
                case (int)FKLog.LOG_IOMODE_IN3:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN3", "");
                    break;
                case (int)FKLog.LOG_IOMODE_OUT3:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT3", "");
                    break;
                case (int)FKLog.LOG_IOMODE_IN4:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN4", "");
                    break;
                case (int)FKLog.LOG_IOMODE_OUT4:
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT4", "");
                    break;
                default:
                    InOutName = IoMode.ToString();
                    break;
            }
            InOutMode = IoMode;

            if (InOut != 0)
            {
                if (InOut == 1)
                {
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_IN1", "");
                }
                else
                {
                    InOutName = Pub.GetResText("Public", "LOG_IOMODE_OUT1", "");
                }
                InOutMode = InOut;
            }
        }
        private string ReturnResultPrint()
        {
            return GetRunMsg(ResultCode);
        }

        private string InfoIndexString(int InfoIndex, long nValue)
        {
            string ret = "";
            string S;
            switch (InfoIndex)
            {
                case (int)FKDI.DI_MANAGERS:
                    ret = Pub.GetResText("", "FK_DI_MANAGERS", "") + "={0}";
                    break;
                case (int)FKDI.DI_MACHINENUM:
                    ret = Pub.GetResText("", "MacSN", "") + "={0}";
                    break;
                case (int)FKDI.DI_LANGAUGE:
                    ret = Pub.GetResText("", "FK_DI_LANGAUGE", "") + "={0}";
                    break;
                case (int)FKDI.DI_POWEROFF_TIME:
                    ret = Pub.GetResText("", "FK_DI_POWEROFF_TIME", "") + "={0}";
                    break;
                case (int)FKDI.DI_LOCK_CTRL:
                    ret = Pub.GetResText("", "FK_DI_LOCK_CTRL", "") + "={0}";
                    break;
                case (int)FKDI.DI_GLOG_WARNING:
                    ret = Pub.GetResText("", "FK_DI_GLOG_WARNING", "") + "={0}";
                    break;
                case (int)FKDI.DI_SLOG_WARNING:
                    ret = Pub.GetResText("", "FK_DI_SLOG_WARNING", "") + "={0}";
                    break;
                case (int)FKDI.DI_VERIFY_INTERVALS:
                    ret = Pub.GetResText("", "FK_DI_VERIFY_INTERVALS", "") + "={0}";
                    break;
                case (int)FKDI.DI_RSCOM_BPS:
                    {
                        switch (nValue)
                        {
                            case (int)FKBPS.BPS_9600:
                                S = "9600";
                                break;
                            case (int)FKBPS.BPS_19200:
                                S = "19200";
                                break;
                            case (int)FKBPS.BPS_38400:
                                S = "38400";
                                break;
                            case (int)FKBPS.BPS_57600:
                                S = "57600";
                                break;
                            case (int)FKBPS.BPS_115200:
                                S = "115200";
                                break;
                            default:
                                S = "--";
                                break;
                        }
                        ret = Pub.GetResText("", "FK_DI_RSCOM_BPS", "") + "=" + S;
                        break;
                    }
                case (int)FKDI.DI_VERIFY_KIND:
                    {
                        S = "";
                        switch (nValue)
                        {
                            case 0:
                                S = "F / P / C";
                                break;
                            case 1:
                                S = "F + P";
                                break;
                            case 2:
                                S = "F + C";
                                break;
                            case 3:
                                S = "C";
                                break;
                        }
                        ret = Pub.GetResText("", "FK_DI_VERIFY_KIND", "") + "=" + S;
                        break;
                    }
                case (int)FKDI.DI_DATE_SEPARATE:
                    ret = Pub.GetResText("", "FK_DI_DATE_SEPARATE", "") + "={0}";
                    break;
                case (int)FKDI.DI_MULTIUSERS:
                    ret = Pub.GetResText("", "FK_DI_MULTIUSERS", "") + "={0}";
                    break;
                default:
                    ret = "--";
                    break;
            }
            if (ret.IndexOf("{0}") > 0) ret = string.Format(ret, nValue.ToString());
            return ret;
        }

        private string StatusIndexString(int StatusIndex, int nValue)
        {
            string ret = "";
            switch (StatusIndex)
            {
                case (int)FKDS.GET_MANAGERS:
                    ret = Pub.GetResText("", "FK_GET_MANAGERS", "") + "={0}";
                    break;
                case (int)FKDS.GET_USERS:
                    ret = Pub.GetResText("", "FK_GET_USERS", "") + "={0}";
                    break;
                case (int)FKDS.GET_FPS:
                    ret = Pub.GetResText("", "FK_GET_FPS", "") + "={0}";
                    break;
                case (int)FKDS.GET_PSWS:
                    ret = Pub.GetResText("", "FK_GET_PSWS", "") + "={0}";
                    break;
                case (int)FKDS.GET_SLOGS:
                    ret = Pub.GetResText("", "FK_GET_SLOGS", "") + "={0}";
                    break;
                case (int)FKDS.GET_GLOGS:
                    ret = Pub.GetResText("", "FK_GET_GLOGS", "") + "={0}";
                    break;
                case (int)FKDS.GET_ASLOGS:
                    ret = Pub.GetResText("", "FK_GET_ASLOGS", "") + "={0}";
                    break;
                case (int)FKDS.GET_AGLOGS:
                    ret = Pub.GetResText("", "FK_GET_AGLOGS", "") + "={0}";
                    break;
                case (int)FKDS.GET_CARDS:
                    ret = Pub.GetResText("", "FK_GET_CARDS", "") + "={0}";
                    break;
                default:
                    ret = "--";
                    break;
            }
            if (ret.IndexOf("{0}") > 0) ret = string.Format(ret, nValue.ToString());
            return ret;
        }

        private void ConvertStructToByteArray(object Struct, byte[] ByteArray)
        {
            IntPtr vptr = IntPtr.Zero;
            int Size = Marshal.SizeOf(Struct);
            if (ByteArray.Length < Size) return;
            vptr = Marshal.AllocHGlobal(Size);
            Marshal.StructureToPtr(Struct, vptr, false);
            Marshal.Copy(vptr, ByteArray, 0, Size);
            Marshal.FreeHGlobal(vptr);
        }

        private object ConvertByteArrayToStruct(byte[] ByteArray, Type Typ)
        {
            object obj;
            IntPtr ptr;
            int Size = Marshal.SizeOf(Typ);
            if (ByteArray.Length < Size) return null;
            ptr = Marshal.AllocHGlobal(Size);
            Marshal.Copy(ByteArray, 0, ptr, Size);
            obj = Marshal.PtrToStructure(ptr, Typ);
            Marshal.FreeHGlobal(ptr);
            return obj;
        }

        public UInt32 EnrollNumberToUInt32(int EnrollNumber)
        {
            Int64 ret = EnrollNumber;
            if (ret < 0) ret = 0xffffffff + ret + 1;
            return Convert.ToUInt32(ret);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_ConnectUSB(int nMachineNo, int nLicense);
        ///<summary>
        ///机器连接与断开
        ///使用USB方式连接设备
        ///</summary>
        private int ConnectUSB(int MachineNo)
        {
            return FK_ConnectUSB(MachineNo, License);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_ConnectComm(int nMachineNo, int nComPort, int nBaudRate, string nTelNumber,
          int nWaitDialTime, int nLicense, int nComTimeOut);
        ///<summary>
        ///机器连接与断开
        ///使用RS232/485方式连接设备
        ///</summary>
        private int ConnectComm(int MachineNo, int ComPort, int BaudRate, string TelNumber, int WaitDialTime,
          int ComTimeOut)
        {
            return FK_ConnectComm(MachineNo, ComPort, BaudRate, TelNumber, WaitDialTime, License, ComTimeOut);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_ConnectNet(int MachineNo, string nIpAddress, int nNetPort, int nTimeOut,
          int nProtocolType, int nNetPassword, int nLicense);
        ///<summary>
        ///机器连接与断开
        ///使用TCP/IP方式连接设备
        ///</summary>
        private int ConnectNet(int MachineNo, string IpAddress, int NetPort, int TimeOut, int ProtocolType,
          int NetPassword)
        {
            return FK_ConnectNet(MachineNo, IpAddress, NetPort, TimeOut, ProtocolType, NetPassword, License);
        }

        public static int ConnectSerNet(int MachineNo, string IpAddress, int NetPort, int TimeOut, int ProtocolType,
         int NetPassword)
        {
            return FK_ConnectNet(MachineNo, IpAddress, NetPort, TimeOut, ProtocolType, NetPassword, License);
        }

        [DllImport("FK623Attend.dll", CharSet = CharSet.Ansi)]
        private static extern int FK_ConnectGPRS(string MachineNo, string nIpAddress, int nNetPort, int nTimeOut,
          int nProtocolType, int nNetPassword, int nLicense);
        private int ConnectGPRS(string MachineNo, string IpAddress, int NetPort, int TimeOut, int ProtocolType,
          int NetPassword)
        {
            return FK_ConnectGPRS(MachineNo, IpAddress, NetPort, TimeOut, ProtocolType, NetPassword, License);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern void FK_DisConnect(int hComm);
        ///<summary>
        ///机器连接与断开
        ///断开设备
        ///</summary>
        private void DisConnect()
        {
            FK_DisConnect(hComm);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_EnableDevice(int hComm, byte nEnableFlag);
        ///<summary>
        ///机器管理
        ///设置机器是否可用
        ///</summary>
        public int EnableDevice(byte EnableFlag)
        {
            return FK_EnableDevice(hComm, EnableFlag);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern void FK_PowerOnAllDevice(int hComm);
        ///<summary>
        ///机器管理
        ///打开机器电源
        ///</summary>
        private void PowerOnAllDevice(int hComm)
        {
            FK_PowerOnAllDevice(hComm);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_PowerOffDevice(int hComm);
        ///<summary>
        ///机器管理
        ///关闭机器电源
        ///</summary>
        public int PowerOffDevice()
        {
            return FK_PowerOffDevice(hComm);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetDeviceStatus(int hComm, int nStatusIndex, ref int nValue);
        ///<summary>
        ///机器管理
        ///获取机器上的状态值
        ///</summary>
        private int GetDeviceStatus(int StatusIndex, ref int Value)
        {
            return FK_GetDeviceStatus(hComm, StatusIndex, ref Value);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetDeviceTime(int hComm, ref DateTime nDateTime);
        ///<summary>
        ///机器管理
        ///获取机器时间
        ///</summary>
        public bool GetDeviceTime(ref DateTime DateTime)
        {
            ResultCode = FK_GetDeviceTime(hComm, ref DateTime);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetDeviceTime(int hComm, DateTime nDateTime);
        ///<summary>
        ///机器管理
        ///设置机器时间
        ///</summary>
        public bool SetDeviceTime(DateTime DateTime)
        {
            ResultCode = FK_SetDeviceTime(hComm, DateTime);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetDeviceInfo(int hComm, int nInfoIndex, ref int nValue);
        ///<summary>
        ///机器管理
        ///获取机器信息
        ///</summary>
        public bool GetDeviceInfo(int InfoIndex, ref int Value)
        {
            ResultCode = FK_GetDeviceInfo(hComm, InfoIndex, ref Value);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetDeviceInfo(int hComm, int nInfoIndex, int nValue);
        ///<summary>
        ///机器管理
        ///设置机器信息
        ///</summary>
        public bool SetDeviceInfo(int InfoIndex, int Value)
        {

            ResultCode = FK_SetDeviceInfo(hComm, InfoIndex, Value);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetProductData(int hComm, int nDataIndex, StringBuilder nValue);
        ///<summary>
        ///机器管理
        ///获取产品信息
        ///</summary>
        public int GetProductData(int DataIndex, ref string Value)
        {
            StringBuilder sb = new StringBuilder(256);
            int ret = FK_GetProductData(hComm, DataIndex, sb);
            Value = sb.ToString().Trim();
            return ret;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_LoadSuperLogData(int hComm, int nReadMark);
        ///<summary>
        ///记录数据管理
        ///读取管理记录
        ///</summary>
        public int LoadSuperLogData(int ReadMark)
        {
            return FK_LoadSuperLogData(hComm, ReadMark);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBLoadSuperLogDataFromFile(int hComm, string nFilePath);
        ///<summary>
        ///记录数据管理
        ///从文件读取管理记录
        ///</summary>
        private int USBLoadSuperLogDataFromFile(string FileName)
        {
            return FK_USBLoadSuperLogDataFromFile(hComm, FileName);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetSuperLogData(int hComm, ref UInt32 nSEnrollNumber, ref UInt32 nGEnrollNumber,
          ref int nManipulation, ref int nBackupNumber, ref DateTime nDateTime);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetSuperLogData_StringID(int hComm,
          [MarshalAs(UnmanagedType.LPStr)] ref string apnSEnrollNumber,
          [MarshalAs(UnmanagedType.LPStr)] ref string apnGEnrollNumber, ref int apnManipulation, ref int apnBackupNumber, ref DateTime apnDateTime);
        ///<summary>
        ///记录数据管理
        ///通过LoadSuperLogData或者USBLoadSuperLogDataFromFile读取的管理记录一个一个获取
        ///</summary>
        public int GetSuperLogData(ref UInt32 SEnrollNumber, ref UInt32 GEnrollNumber, ref int Manipulation,
          ref int BackupNumber, ref DateTime DateTime)
        {
            return FK_GetSuperLogData(hComm, ref SEnrollNumber, ref GEnrollNumber, ref Manipulation, ref BackupNumber,
              ref DateTime);
        }
        public int GetSuperLogData(ref string SEnrollNumber, ref string GEnrollNumber, ref int Manipulation,
          ref int BackupNumber, ref DateTime DateTime)
        {
            return FK_GetSuperLogData_StringID(hComm, ref SEnrollNumber, ref GEnrollNumber, ref Manipulation,
              ref BackupNumber, ref DateTime);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_EmptySuperLogData(int hComm);
        ///<summary>
        ///记录数据管理
        ///删除机器上所有管理记录
        ///</summary>
        private int EmptySuperLogData()
        {
            return FK_EmptySuperLogData(hComm);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_LoadGeneralLogData(int hComm, int nReadMark);
        ///<summary>
        ///记录数据管理
        ///读取进出记录
        ///</summary>
        public int LoadGeneralLogData(int ReadMark)
        {
            return FK_LoadGeneralLogData(hComm, ReadMark);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBLoadGeneralLogDataFromFile(int hComm, string nFilePath);
        ///<summary>
        ///记录数据管理
        ///从文件读取进出记录
        ///</summary>
        public int USBLoadGeneralLogDataFromFile(string FileName)
        {
            return FK_USBLoadGeneralLogDataFromFile(hComm, FileName);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetGeneralLogData(int hComm, ref UInt32 nEnrollNumber, ref int nVerifyMode,
          ref int nInOutMode, ref DateTime nDateTime);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetGeneralLogData_StringID(int hComm, [MarshalAs(UnmanagedType.LPStr)] ref string apnEnrollNumber, ref int apnVerifyMode, ref int apnInOutMode, ref DateTime apnDateTime);
        ///<summary>
        ///记录数据管理
        ///通过LoadSuperLogData或者USBLoadSuperLogDataFromFile读取的管理记录一个一个获取
        ///</summary>
        public int GetGeneralLogData(ref UInt32 EnrollNumber, ref int VerifyMode, ref int InOutMode, ref DateTime DateTime)
        {
            return FK_GetGeneralLogData(hComm, ref EnrollNumber, ref VerifyMode, ref InOutMode, ref DateTime);
        }
        public int GetGeneralLogData(ref string EnrollNumber, ref int VerifyMode, ref int InOutMode, ref DateTime DateTime)
        {
            return FK_GetGeneralLogData_StringID(hComm, ref EnrollNumber, ref VerifyMode, ref InOutMode, ref DateTime);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_EmptyGeneralLogData(int hComm);
        ///<summary>
        ///记录数据管理
        ///删除机器上所有进出记录
        ///</summary>
        public bool EmptyGeneralLogData()
        {
            ResultCode = FK_EmptyGeneralLogData(hComm);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetBellTime(int hComm, ref int nBellCount, ref byte nBellInfo);
        ///<summary>
        ///响铃管理
        ///获取机器响铃信息
        ///</summary>
        public bool GetBellTime(ref int BellCount, ref byte BellInfo)
        {
            ResultCode = FK_GetBellTime(hComm, ref BellCount, ref BellInfo);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetBellTime(int hComm, int nBellCount, ref byte nBellInfo);
        ///<summary>
        ///响铃管理
        ///设置机器响铃信息
        ///</summary>
        public bool SetBellTime(int BellCount, ref byte BellInfo)
        {
            ResultCode = FK_SetBellTime(hComm, BellCount, ref BellInfo);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetEnrollData(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          ref int nMachinePrivilege, byte[] nEnrollData, ref int nPassWord);
        [DllImport("FK623Attend.dll", CharSet = CharSet.Ansi)]
        private static extern int FK_GetEnrollData_StringID(int hComm, string apEnrollNumber, int anBackupNumber,
          ref int apnMachinePrivilege, byte[] apEnrollData, ref int apnPassWord);
        ///<summary>
        ///登记数据管理
        ///获取用户登记资料和权限
        ///</summary>
        public int GetEnrollData(UInt32 EnrollNumber, int BackupNumber, ref int MachinePrivilege, byte[] EnrollData,
          ref int PassWord)
        {
            return FK_GetEnrollData(hComm, EnrollNumber, BackupNumber, ref MachinePrivilege, EnrollData, ref PassWord);
        }
        public int GetEnrollData(string EnrollNumber, int BackupNumber, ref int MachinePrivilege, byte[] EnrollData,
          ref int PassWord)
        {
            return FK_GetEnrollData_StringID(hComm, EnrollNumber, BackupNumber, ref MachinePrivilege, EnrollData,
              ref PassWord);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_PutEnrollData(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege, byte[] nEnrollData, int nPassWord);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_PutEnrollDataWithString(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege, string nEnrollData);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_PutEnrollData_StringID(int hComm, string apEnrollNumber, int anBackupNumber,
          int anMachinePrivilege, byte[] apEnrollData, int anPassWord);
        ///<summary>
        ///登记数据管理
        ///将用户的登记资料和权限传送到机器
        ///</summary>
        public int PutEnrollData(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege, byte[] EnrollData,
          int PassWord)
        {
            return FK_PutEnrollData(hComm, EnrollNumber, BackupNumber, MachinePrivilege, EnrollData, PassWord);
        }
        public int PutEnrollData(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege, string EnrollData)
        {
            return FK_PutEnrollDataWithString(hComm, EnrollNumber, BackupNumber, MachinePrivilege, EnrollData);
        }
        public int PutEnrollData(string EnrollNumber, int BackupNumber, int MachinePrivilege, byte[] EnrollData,
          int PassWord)
        {
            return FK_PutEnrollData_StringID(hComm, EnrollNumber, BackupNumber, MachinePrivilege, EnrollData, PassWord);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SaveEnrollData(int hComm);
        ///<summary>
        ///登记数据管理
        ///将PutEnrollData传送的资料登记到机器上
        ///</summary>
        public int SaveEnrollData()
        {
            return FK_SaveEnrollData(hComm);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_DeleteEnrollData(int hComm, UInt32 nEnrollNumber, int nBackupNumber);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_DeleteEnrollData_StringID(int hComm, string apEnrollNumber, int anBackupNumber);
        ///<summary>
        ///登记数据管理
        ///删除登记资料
        ///</summary>
        public int DeleteEnrollData(UInt32 EnrollNumber, int BackupNumber)
        {
            return FK_DeleteEnrollData(hComm, EnrollNumber, BackupNumber);
        }
        public int DeleteEnrollData(string EnrollNumber, int BackupNumber)
        {
            return FK_DeleteEnrollData_StringID(hComm, EnrollNumber, BackupNumber);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUSBModel(int hComm, int nModel);
        public bool SetUSBModel(int Model)
        {
            ResultCode = FK_SetUSBModel(hComm, Model);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUDiskFileFKModel(int hComm, string FKModel);
        public bool SetUDiskFileFKModel(string FKModel)
        {
            ResultCode = FK_SetUDiskFileFKModel(hComm, FKModel);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBReadAllEnrollDataFromFile(int hComm, string nFilePath);
        ///<summary>
        ///登记数据管理
        ///从文件中读取登记资料
        ///</summary>
        public bool USBReadAllEnrollDataFromFile(string FilePath)
        {
            ResultCode = FK_USBReadAllEnrollDataFromFile(hComm, FilePath);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBReadAllEnrollDataCount(int hComm, ref int nValue);
        public bool USBReadAllEnrollDataCount(ref int nValue)
        {
            ResultCode = FK_USBReadAllEnrollDataCount(hComm, ref nValue);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBGetOneEnrollData(int hComm, ref UInt32 nEnrollNumber, ref int nBackupNumber,
          ref int nMachinePrivilege, byte[] nEnrollData, ref int nPassWord, ref int nEnableFlag, [MarshalAs(UnmanagedType.LPStr)] ref string nEnrollName);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBGetOneEnrollData_StringID(int hComm, [MarshalAs(UnmanagedType.LPStr)] ref string apEnrollNumber, ref int apnBackupNumber, ref int apnMachinePrivilege, byte[] apEnrollData, ref int apnPassWord, ref int apnEnableFlag, [MarshalAs(UnmanagedType.LPStr)] ref string apstrEnrollName);
        ///<summary>
        ///登记数据管理
        ///获取通过USBReadAllEnrollDataFromFile读取的登记资料
        ///</summary>
        public int USBGetOneEnrollData(ref UInt32 EnrollNumber, ref int BackupNumber, ref int MachinePrivilege,
          byte[] EnrollData, ref int PassWord, ref int EnableFlag, ref string EnrollName)
        {
            return FK_USBGetOneEnrollData(hComm, ref EnrollNumber, ref BackupNumber, ref MachinePrivilege,
              EnrollData, ref PassWord, ref EnableFlag, ref EnrollName);
        }
        public int USBGetOneEnrollData(ref string EnrollNumber, ref int BackupNumber, ref int MachinePrivilege,
          byte[] EnrollData, ref int PassWord, ref int EnableFlag, ref string EnrollName)
        {
            return FK_USBGetOneEnrollData_StringID(hComm, ref EnrollNumber, ref BackupNumber, ref MachinePrivilege,
              EnrollData, ref PassWord, ref EnableFlag, ref EnrollName);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBSetOneEnrollData(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege, byte[] nEnrollData, int nPassWord, int nEnableFlag, string nEnrollName);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBSetOneEnrollData_StringID(int hComm, string apEnrollNumber, int anBackupNumber,
          int anMachinePrivilege, byte[] apEnrollData, int anPassWord, int anEnableFlag, string astrEnrollName);
        public int USBSetOneEnrollData(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege, byte[] EnrollData,
          int PassWord, int EnableFlag, string EnrollName)
        {
            return FK_USBSetOneEnrollData(hComm, EnrollNumber, BackupNumber, MachinePrivilege, EnrollData,
              PassWord, EnableFlag, EnrollName);
        }
        public int USBSetOneEnrollData(string EnrollNumber, int BackupNumber, int MachinePrivilege, byte[] EnrollData,
          int PassWord, int EnableFlag, string EnrollName)
        {
            return FK_USBSetOneEnrollData_StringID(hComm, EnrollNumber, BackupNumber, MachinePrivilege, EnrollData,
              PassWord, EnableFlag, EnrollName);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBWriteAllEnrollDataToFile(int hComm, string nFilePath);
        ///<summary>
        ///登记数据管理
        ///将通过USBSetOneEnrollData制作的登记资料保存为文件
        ///</summary>
        public int USBWriteAllEnrollDataToFile(string FileName)
        {
            return FK_USBWriteAllEnrollDataToFile(hComm, FileName);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBReadAllEnrollDataFromFile_Color(int hComm, string nFilePath);
        ///<summary>
        ///登记数据管理
        ///从文件中读取登记资料
        ///</summary>
        private int USBReadAllEnrollDataFromFile_Color(string FilePath)
        {
            return FK_USBReadAllEnrollDataFromFile_Color(hComm, FilePath);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBWriteAllEnrollDataToFile_Color(int hComm, string nFilePath);
        ///<summary>
        ///登记数据管理
        ///将通过USBSetOneEnrollData制作的登记资料保存为文件
        ///</summary>
        private int USBWriteAllEnrollDataToFile_Color(string FileName)
        {
            return FK_USBWriteAllEnrollDataToFile_Color(hComm, FileName);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBGetOneEnrollData_Color(int hComm, ref UInt32 nEnrollNumber, ref int nBackupNumber,
          ref int nMachinePrivilege, ref int nEnrollData, ref int nPassWord, ref int nEnableFlag, ref string nEnrollName,
          ref int nNewsKind);
        ///<summary>
        ///登记数据管理
        ///获取通过USBReadAllEnrollDataFromFile读取的登记资料
        ///</summary>
        private int USBGetOneEnrollData_Color(ref UInt32 EnrollNumber, ref int BackupNumber, ref int MachinePrivilege,
          ref int EnrollData, ref int PassWord, ref int EnableFlag, ref string EnrollName, ref int NewsKind)
        {
            return FK_USBGetOneEnrollData_Color(hComm, ref EnrollNumber, ref BackupNumber, ref MachinePrivilege,
              ref EnrollData, ref PassWord, ref EnableFlag, ref EnrollName, ref NewsKind);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_USBSetOneEnrollData_Color(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege, ref int nEnrollData, int nPassWord, int nEnableFlag, string nEnrollName, int NewsKind);
        private int USBSetOneEnrollData_Color(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege, ref int EnrollData,
          int PassWord, int EnableFlag, string EnrollName, int NewsKind)
        {
            return FK_USBSetOneEnrollData_Color(hComm, EnrollNumber, BackupNumber, MachinePrivilege, ref EnrollData,
              PassWord, EnableFlag, EnrollName, NewsKind);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_EnableUser(int hComm, UInt32 nEnrollNumber, int nBackupNumber, int nEnableFlag);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_EnableUser_StringID(int hComm, string apEnrollNumber, int anBackupNumber,
          int anEnableFlag);
        ///<summary>
        ///用户信息管理
        ///设置用户对机器是否可用
        ///</summary>
        private int EnableUser(UInt32 EnrollNumber, int BackupNumber, int EnableFlag)
        {
            return FK_EnableUser(hComm, EnrollNumber, BackupNumber, EnableFlag);
        }
        private int EnableUser(string EnrollNumber, int BackupNumber, int EnableFlag)
        {
            return FK_EnableUser_StringID(hComm, EnrollNumber, BackupNumber, EnableFlag);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_ModifyPrivilege(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_ModifyPrivilege_StringID(int hComm, string apEnrollNumber,
          int anBackupNumber, int anMachinePrivilege);
        ///<summary>
        ///用户信息管理
        ///设置用户对机器的操作权限
        ///</summary>
        private int ModifyPrivilege(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege)
        {
            return FK_ModifyPrivilege(hComm, EnrollNumber, BackupNumber, MachinePrivilege);
        }
        private int ModifyPrivilege(string EnrollNumber, int BackupNumber, int MachinePrivilege)
        {
            return FK_ModifyPrivilege_StringID(hComm, EnrollNumber, BackupNumber, MachinePrivilege);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_BenumbAllManager(int hComm);
        ///<summary>
        ///登记数据管理
        ///将所有登记用户至为一般用户
        ///</summary>
        public bool BenumbAllManager()
        {
            ResultCode = FK_BenumbAllManager(hComm);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_ReadAllUserID(int hComm);
        ///<summary>
        ///登记数据管理
        ///读取机器上所有登记资料
        ///</summary>
        public int ReadAllUserID()
        {
            return FK_ReadAllUserID(hComm);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetAllUserID(int hComm, ref UInt32 nEnrollNumber, ref int nBackupNumber,
          ref int nMachinePrivilege, ref int nEnable);
        [DllImport("FK623Attend.dll", CharSet = CharSet.Ansi)]
        private static extern int FK_GetAllUserID_StringID(int hComm, ref string apEnrollNumber,
          ref int apnBackupNumber, ref int apnMachinePrivilege, ref int apnEnableFlag);
        ///<summary>
        ///登记数据管理
        ///将通过ReadAllUserID读取的登记资料一个一个获取
        ///</summary>
        public int GetAllUserID(ref UInt32 EnrollNumber, ref int BackupNumber, ref int MachinePrivilege, ref int Enable)
        {
            return FK_GetAllUserID(hComm, ref EnrollNumber, ref BackupNumber, ref MachinePrivilege, ref Enable);
        }
        public int GetAllUserID(ref string EnrollNumber, ref int BackupNumber, ref int MachinePrivilege, ref int Enable)
        {
            return FK_GetAllUserID_StringID(hComm, ref EnrollNumber, ref BackupNumber, ref MachinePrivilege, ref Enable);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_EmptyEnrollData(int hComm);
        ///<summary>
        ///登记数据管理
        ///删除所有登记资料
        ///</summary>
        public bool EmptyEnrollData()
        {
            ResultCode = FK_EmptyEnrollData(hComm);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_ClearKeeperData(int hComm);
        ///<summary>
        ///登记数据管理
        ///删除所有登记资料和记录数据，即初始化机器
        ///</summary>
        public bool ClearKeeperData()
        {
            ResultCode = FK_ClearKeeperData(hComm);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetFontName(int hComm, string FontName, int FontType);
        ///<summary>
        ///登记数据管理
        ///将通过ReadAllUserID读取的登记资料一个一个获取
        ///</summary>
        public int SetFontName(string FontName, int FontType)
        {
            return FK_SetFontName(hComm, FontName, FontType);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetUserName(int hComm, UInt32 nEnrollNumber, ref string nUserName);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetUserInfoEx(int hComm, UInt32 nEnrollNumber, ref byte UserInfo, ref int UserInfoLen);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetUserName_StringID(int hComm, string apEnrollNumber,
          [MarshalAs(UnmanagedType.LPStr)] ref string apstrUserName);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetUserInfoEx_StringID(int hComm, string apEnrollNumber, ref byte UserInfo,
          ref int UserInfoLen);
        ///<summary>
        ///用户信息管理
        ///获取用户名称
        ///</summary>
        public bool GetUserName(UInt32 EnrollNumber, ref string UserName)
        {
            byte[] UserInfo = new byte[(int)FKMax.USER_INFO_SIZE_V2];
            int UserInfoLen = (int)FKMax.USER_INFO_SIZE_V2;
            UserData data = new UserData();
            data.Init();
            UserName = "";
            string name = "";
            data.Size = (int)FKMax.USER_INFO_SIZE_V2;
            data.Ver = (int)FKMax.USER_INFO_VER2;
            data.YearAssigned = 2014;
            data.MonthAssigned = 12;
            ConvertStructToByteArray(data, UserInfo);
            int ErrCode = FK_GetUserInfoEx(hComm, EnrollNumber, ref UserInfo[0], ref UserInfoLen);
            bool ret = ErrCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
            {
                data = (UserData)ConvertByteArrayToStruct(UserInfo, typeof(UserData));
                UserName = Encoding.GetEncoding("utf-16").GetString(data.UserName);
                UserName = UserName.Replace("\0", "").Trim();
            }
            else
            {
                ErrCode = FK_GetUserName(hComm, EnrollNumber, ref name);
                ret = ErrCode == (int)FKRun.RUN_SUCCESS;
                if (ret) UserName = name;
            }
            return ret;
        }
        public bool GetUserName(string EnrollNumber, ref string UserName)
        {
            byte[] UserInfo = new byte[(int)FKMax.USER_INFO_SIZE_V3];
            int UserInfoLen = (int)FKMax.USER_INFO_SIZE_V3;
            UserDataV3 data = new UserDataV3();
            data.Init();
            UserName = "";
            string name = "";
            data.Size = (int)FKMax.USER_INFO_SIZE_V3;
            data.Ver = (int)FKMax.USER_INFO_VER2;
            data.YearAssigned = 2014;
            data.MonthAssigned = 12;
            ConvertStructToByteArray(data, UserInfo);
            int ErrCode = FK_GetUserInfoEx_StringID(hComm, EnrollNumber, ref UserInfo[0], ref UserInfoLen);
            bool ret = ErrCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
            {
                data = (UserDataV3)ConvertByteArrayToStruct(UserInfo, typeof(UserDataV3));
                UserName = Encoding.GetEncoding("utf-16").GetString(data.UserName);
                UserName = UserName.Replace("\0", "").Trim();
            }
            else
            {
                ErrCode = FK_GetUserName_StringID(hComm, EnrollNumber, ref name);
                ret = ErrCode == (int)FKRun.RUN_SUCCESS;
                if (ret) UserName = name;
            }
            return ret;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUserName(int hComm, UInt32 nEnrollNumber, string nUserName);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUserInfoEx(int hComm, UInt32 nEnrollNumber, byte[] UserInfo, int UserInfoLen);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUserName_StringID(int hComm, string apEnrollNumber, string astrUserName);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUserInfoEx_StringID(int anHandleIndex, string apEnrollNumber, byte[] UserInfo,
          int UserInfoLen);
        ///<summary>
        ///用户信息管理
        ///设置用户名称
        ///</summary>
        public bool SetUserName(UInt32 EnrollNumber, string UserName, ref int ErrCode)
        {
            byte[] UserInfo = new byte[(int)FKMax.USER_INFO_SIZE_V2];
            int UserInfoLen = (int)FKMax.USER_INFO_SIZE_V2;
            UserData data = new UserData();
            data.Init();
            data.Size = (int)FKMax.USER_INFO_SIZE_V2;
            data.Ver = (int)FKMax.USER_INFO_VER2;
            data.YearAssigned = 2014;
            data.MonthAssigned = 12;
            data.UserId = EnrollNumber;
            Encoding.GetEncoding("utf-16").GetBytes(UserName).CopyTo(data.UserName, 0);
            ConvertStructToByteArray(data, UserInfo);
            ErrCode = FK_SetUserInfoEx(hComm, EnrollNumber, UserInfo, UserInfoLen);
            if (ErrCode != (int)FKRun.RUN_SUCCESS) ErrCode = FK_SetUserName(hComm, EnrollNumber, UserName);
            return ErrCode == (int)FKRun.RUN_SUCCESS;
        }
        public bool SetUserName(string EnrollNumber, string UserName, ref int ErrCode)
        {
            byte[] UserInfo = new byte[(int)FKMax.USER_INFO_SIZE_V3];
            int UserInfoLen = (int)FKMax.USER_INFO_SIZE_V3;
            UserDataV3 data = new UserDataV3();
            data.Init();
            data.Size = (int)FKMax.USER_INFO_SIZE_V3;
            data.Ver = (int)FKMax.USER_INFO_VER3;
            data.YearAssigned = 2014;
            data.MonthAssigned = 12;
            //data.UserId = EnrollNumber;
            Encoding.GetEncoding("utf-16").GetBytes(UserName).CopyTo(data.UserName, 0);
            ConvertStructToByteArray(data, UserInfo);
            ErrCode = FK_SetUserInfoEx_StringID(hComm, EnrollNumber, UserInfo, UserInfoLen);
            if (ErrCode != (int)FKRun.RUN_SUCCESS) ErrCode = FK_SetUserName_StringID(hComm, EnrollNumber, UserName);
            return ErrCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetNewsMessage(int hComm, int nNewsId, ref string nNews);
        ///<summary>
        ///用户信息管理
        ///获取通知信息
        ///</summary>
        private int GetNewsMessage(int NewsId, ref string News)
        {
            return FK_GetNewsMessage(hComm, NewsId, ref News);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetNewsMessage(int hComm, int nNewsId, string nNews);
        ///<summary>
        ///用户信息管理
        ///设置通知信息
        ///</summary>
        private int SetNewsMessage(int NewsId, string News)
        {
            return FK_SetNewsMessage(hComm, NewsId, News);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetUserNewsID(int hComm, UInt32 nEnrollNumber, ref int nNewsId);
        ///<summary>
        ///用户信息管理
        ///获取用户通知信息
        ///</summary>
        private int GetUserNewsID(UInt32 EnrollNumber, ref int NewsId)
        {
            return FK_GetUserNewsID(hComm, EnrollNumber, ref NewsId);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUserNewsID(int hComm, UInt32 nEnrollNumber, int nNewsId);
        ///<summary>
        ///用户信息管理
        ///设置用户通知信息
        ///</summary>
        private int SetUserNewsID(UInt32 EnrollNumber, int NewsId)
        {
            return FK_SetUserNewsID(hComm, EnrollNumber, NewsId);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetDoorStatus(int hComm, ref int nStatusVal);
        ///<summary>
        ///门铃管理
        ///获取门状态
        ///</summary>
        public bool GetDoorStatus(ref int StatusVal)
        {
            ResultCode = FK_GetDoorStatus(hComm, ref StatusVal);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        public bool GetDoorStatus(int h, ref int StatusVal)
        {
            ResultCode = FK_GetDoorStatus(h, ref StatusVal);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetDoorStatus(int hComm, int nStatusVal);
        ///<summary>
        ///门铃管理
        ///设置门状态
        ///</summary>
        public bool SetDoorStatus(int StatusVal)
        {
            ResultCode = FK_SetDoorStatus(hComm, StatusVal);
            if (SystemInfo.isclose)
            {
                ResultCode = 1;
            }
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetPassTime(int hComm, int nPassTimeID, ref int nPassTime, int PassTimeSize);
        ///<summary>
        ///门铃管理
        ///获取时间段信息
        ///</summary>
        public bool GetPassTime(int PassTimeID, ref int PassTime, int PassTimeSize)
        {
            ResultCode = FK_GetPassTime(hComm, PassTimeID, ref PassTime, PassTimeSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetPassTime(int hComm, int nPassTimeID, ref byte nPassTime, int PassTimeSize);
        ///<summary>
        ///门铃管理
        ///设置时间段信息
        ///</summary>
        public bool SetPassTime(int PassTimeID, ref byte PassTime, int PassTimeSize)
        {
            ResultCode = FK_SetPassTime(hComm, PassTimeID, ref PassTime, PassTimeSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetUserPassTime(int hComm, UInt32 nEnrollNumber, ref int nGroupID,
          ref int nPassTime, int nPassTimeIDSize);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetUserPassTime_StringID(int hComm, string apEnrollNumber,
          ref int apnGroupID, ref int nPassTime, int nPassTimeIDSize);
        ///<summary>
        ///门铃管理
        ///读取用户时间段信息
        ///</summary>
        public bool GetUserPassTime(UInt32 EnrollNumber, ref int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            ResultCode = FK_GetUserPassTime(hComm, EnrollNumber, ref GroupID, ref PassTime, PassTimeIDSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }
        public bool GetUserPassTime(string EnrollNumber, ref int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            ResultCode = FK_GetUserPassTime_StringID(hComm, EnrollNumber, ref GroupID, ref PassTime, PassTimeIDSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUserPassTime(int hComm, UInt32 nEnrollNumber, int nGroupID, ref int nPassTime,
          int nPassTimeIDSize);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetUserPassTime_StringID(int hComm, string anEnrollNumber, int anGroupID, ref int nPassTime,
          int nPassTimeIDSize);
        ///<summary>
        ///门铃管理
        ///设置用户时间段信息
        ///</summary>
        public bool SetUserPassTime(UInt32 EnrollNumber, int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            ResultCode = FK_SetUserPassTime(hComm, EnrollNumber, GroupID, ref PassTime, PassTimeIDSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }
        public bool SetUserPassTime(string EnrollNumber, int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            ResultCode = FK_SetUserPassTime_StringID(hComm, EnrollNumber, GroupID, ref PassTime, PassTimeIDSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetGroupPassTime(int hComm, int nGroupID, ref int nPassTime, int nPassTimeIDSize);
        public bool GetGroupPassTime(int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            ResultCode = FK_GetGroupPassTime(hComm, GroupID, ref PassTime, PassTimeIDSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetGroupPassTime(int hComm, int nGroupID, ref int nPassTime, int nPassTimeIDSize);
        public bool SetGroupPassTime(int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            ResultCode = FK_SetGroupPassTime(hComm, GroupID, ref PassTime, PassTimeIDSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetGroupMatch(int hComm, ref int nGroupMatch, int nGroupMatchSize);
        public bool GetGroupMatch(ref int GroupMatch, int GroupMatchSize)
        {
            ResultCode = FK_GetGroupMatch(hComm, ref GroupMatch, GroupMatchSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetGroupMatch(int hComm, ref int nGroupMatch, int nGroupMatchSize);
        public bool SetGroupMatch(ref int GroupMatch, int GroupMatchSize)
        {
            ResultCode = FK_SetGroupMatch(hComm, ref GroupMatch, GroupMatchSize);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_GetTimeZone(int hComm, byte[] abytOneTimeZone);
        public bool HS_GetTimeZone(byte[] TimeZone)
        {
            ResultCode = FK_HS_GetTimeZone(hComm, TimeZone);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_SetTimeZone(int hComm, byte[] abytOneTimeZone);
        public bool HS_SetTimeZone(byte[] TimeZone)
        {
            ResultCode = FK_HS_SetTimeZone(hComm, TimeZone);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_GetUserWeekPassTime(int hComm, byte[] abytUserWeekPassTime);
        public bool HS_GetUserWeekPassTime(byte[] UserWeekPassTime)
        {
            ResultCode = FK_HS_GetUserWeekPassTime(hComm, UserWeekPassTime);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_SetUserWeekPassTime(int hComm, byte[] abytUserWeekPassTime);
        public bool HS_SetUserWeekPassTime(byte[] UserWeekPassTime)
        {
            ResultCode = FK_HS_SetUserWeekPassTime(hComm, UserWeekPassTime);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern void FK_ConnectGetIP(ref string apnComName);
        private void ConnectGetIP(ref string apnComName)
        {
            FK_ConnectGetIP(ref apnComName);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetAdjustInfo(int hComm, ref int dwAdjustedState, ref int dwAdjustedMonth,
          ref int dwAdjustedDay, ref int dwAdjustedHour, ref int dwAdjustedMinute, ref int dwRestoredState,
          ref int dwRestoredMonth, ref int dwRestoredDay, ref int dwRestoredHour, ref int dwRestoredMinte);
        private int GetAdjustInfo(ref int dwAdjustedState, ref int dwAdjustedMonth, ref int dwAdjustedDay,
          ref int dwAdjustedHour, ref int dwAdjustedMinute, ref int dwRestoredState, ref int dwRestoredMonth,
          ref int dwRestoredDay, ref int dwRestoredHour, ref int dwRestoredMinte)
        {
            return FK_GetAdjustInfo(hComm, ref dwAdjustedState, ref dwAdjustedMonth, ref dwAdjustedDay, ref dwAdjustedHour,
              ref dwAdjustedMinute, ref dwRestoredState, ref dwRestoredMonth, ref dwRestoredDay, ref dwRestoredHour,
              ref dwRestoredMinte);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetAdjustInfo(int hComm, int dwAdjustedState, int dwAdjustedMonth, int dwAdjustedDay,
          int dwAdjustedHour, int dwAdjustedMinute, int dwRestoredState, int dwRestoredMonth, int dwRestoredDay,
          int dwRestoredHour, int dwRestoredMinte);
        private int SetAdjustInfo(int dwAdjustedState, int dwAdjustedMonth, int dwAdjustedDay, int dwAdjustedHour,
          int dwAdjustedMinute, int dwRestoredState, int dwRestoredMonth, int dwRestoredDay, int dwRestoredHour,
          int dwRestoredMinte)
        {
            return FK_SetAdjustInfo(hComm, dwAdjustedState, dwAdjustedMonth, dwAdjustedDay, dwAdjustedHour, dwAdjustedMinute,
              dwRestoredState, dwRestoredMonth, dwRestoredDay, dwRestoredHour, dwRestoredMinte);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetAccessTime(int hComm, UInt32 nEnrollNumber, ref int nAccessTime);
        private int GetAccessTime(UInt32 EnrollNumber, ref int nAccessTime)
        {
            return FK_GetAccessTime(hComm, EnrollNumber, ref nAccessTime);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetAccessTime(int hComm, UInt32 nEnrollNumber, int nAccessTime);
        private int SetAccessTime(UInt32 EnrollNumber, int nAccessTime)
        {
            return FK_SetAccessTime(hComm, EnrollNumber, nAccessTime);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetRealTimeInfo(int hComm, ref int nRealTime);
        private int GetRealTimeInfo(ref int nRealTime)
        {
            return FK_GetRealTimeInfo(hComm, ref nRealTime);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetRealTimeInfo(int hComm, ref int nRealTime);
        private int SetRealTimeInfo(ref int nRealTime)
        {
            return FK_SetRealTimeInfo(hComm, ref nRealTime);
        }
        /// <summary>
        /// 读取服务器信息
        /// </summary>
        /// <param name="hComm"></param>
        /// <param name="ServerIPAddress"></param>
        /// <param name="ServerPort"></param>
        /// <param name="ServerRequest"></param>
        /// <returns></returns>
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetServerNetInfo(int hComm, [MarshalAs(UnmanagedType.LPStr)] ref string ServerIPAddress, ref int ServerPort,
          ref int ServerRequest);
        public bool GetServerNetInfo(ref string ServerIPAddress, ref int ServerPort, ref int ServerRequest)
        {
            ResultCode = FK_GetServerNetInfo(hComm, ref ServerIPAddress, ref ServerPort, ref ServerRequest);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        /// <summary>
        /// 设置服务器信息
        /// </summary>
        /// <param name="hComm"></param>
        /// <param name="ServerIPAddress"></param>
        /// <param name="ServerPort"></param>
        /// <param name="ServerRequest"></param>
        /// <returns></returns>
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetServerNetInfo(int hComm, [MarshalAs(UnmanagedType.LPStr)] string ServerIPAddress, int ServerPort, int ServerRequest);
        public bool SetServerNetInfo(string ServerIPAddress, int ServerPort, int ServerRequest)
        {
            ResultCode = FK_SetServerNetInfo(hComm, ServerIPAddress, ServerPort, ServerRequest);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetEnrollPhoto(int hComm, UInt32 nEnrollNumber, byte[] nPhotoImage,
          ref int nPhotoLength);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetEnrollPhoto_StringID(int hComm, string apEnrollNumber, byte[] nPhotoImage,
          ref int nPhotoLength);
        public bool GetEnrollPhoto(UInt32 EnrollNumber, ref byte[] PhotoImage)
        {
            int PhotoSize = 0;
            PhotoImage = new byte[0];
            int ret = FK_GetEnrollPhoto(hComm, EnrollNumber, PhotoImage, ref PhotoSize);
            if (ret == (int)FKRun.RUN_SUCCESS)
            {
                PhotoImage = new byte[PhotoSize];
                ret = FK_GetEnrollPhoto(hComm, EnrollNumber, PhotoImage, ref PhotoSize);
            }
            return ret == (int)FKRun.RUN_SUCCESS;
        }
        public bool GetEnrollPhoto(string EnrollNumber, ref byte[] PhotoImage)
        {
            int PhotoSize = 0;
            PhotoImage = new byte[0];
            int ret = FK_GetEnrollPhoto_StringID(hComm, EnrollNumber, PhotoImage, ref PhotoSize);
            if (ret == (int)FKRun.RUN_SUCCESS)
            {
                PhotoImage = new byte[PhotoSize];
                ret = FK_GetEnrollPhoto_StringID(hComm, EnrollNumber, PhotoImage, ref PhotoSize);
            }
            return ret == (int)FKRun.RUN_SUCCESS;
        }

        /// <summary>
        /// 解除报警
        /// </summary>
        /// <param name="anHandleIndex"></param>
        /// <param name="anStatus"></param>
        /// <returns></returns>
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_SetAlarmStatus(int anHandleIndex, int anStatus);

        public bool SetAlarmStatus(int anStatus)
        {
            ResultCode = FK_HS_SetAlarmStatus(hComm, anStatus);

            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }
        /// <summary>
        /// 设备参数获取
        /// </summary>
        /// <param name="anHandleIndex"></param>
        /// <param name="apJsonStr"></param>
        /// <returns></returns>

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_ExecJsonCmd(int anHandleIndex, [MarshalAs(UnmanagedType.LPStr)] ref string apJsonStr);

        public bool ExecJsonCmd(ref string apJsonStr)
        {
            ResultCode = FK_HS_ExecJsonCmd(hComm, ref apJsonStr);

            if (apJsonStr == null || apJsonStr.Contains("cmd")) apJsonStr = "";

            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_ExecJsonCmd(int anHandleIndex, [MarshalAs(UnmanagedType.LPStr)] ref StringBuilder apJsonStr);
        public bool ExecJsonCmd(ref StringBuilder apJsonStr)
        {
            ResultCode = FK_HS_ExecJsonCmd(hComm, ref apJsonStr);

            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetEnrollPhoto(int hComm, UInt32 nEnrollNumber, byte[] nPhotoImage, int nPhotoLength);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetEnrollPhoto_StringID(int hComm, string apEnrollNumber, byte[] nPhotoImage,
          int nPhotoLength);
        public bool SetEnrollPhoto(UInt32 EnrollNumber, byte[] PhotoImage, int PhotoSize)
        {
            int ret = FK_SetEnrollPhoto(hComm, EnrollNumber, PhotoImage, PhotoSize);
            return ret == (int)FKRun.RUN_SUCCESS;
        }
        public bool SetEnrollPhoto(string EnrollNumber, byte[] PhotoImage, int PhotoSize)
        {
            int ret = FK_SetEnrollPhoto_StringID(hComm, EnrollNumber, PhotoImage, PhotoSize);
            return ret == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_DeleteEnrollPhoto(int hComm, UInt32 nEnrollNumber);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_DeleteEnrollPhoto_StringID(int hComm, string apEnrollNumber);
        private int DeleteEnrollPhoto(UInt32 EnrollNumber)
        {
            return FK_DeleteEnrollPhoto(hComm, EnrollNumber);
        }
        private int DeleteEnrollPhoto(string EnrollNumber)
        {
            return FK_DeleteEnrollPhoto_StringID(hComm, EnrollNumber);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetLogPhoto(int hComm, UInt32 nEnrollNumber, int nYear, int nMonth, int nDay,
          int nHour, int nMinute, int nSec, ref byte nPhotoImage, ref int nPhotoLength);
        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetLogPhoto_StringID(int anHandleIndex, string nEnrollNumber, int nYear,
          int nMonth, int nDay, int nHour, int nMinute, int nSec, ref byte nPhotoImage, ref int nPhotoLength);
        public bool GetLogPhoto(UInt32 EnrollNumber, DateTime LogTime, ref byte[] PhotoImage)
        {
            int PhotoSize = 0;
            PhotoImage = new byte[4];
            int ret = FK_GetLogPhoto(hComm, EnrollNumber, LogTime.Year, LogTime.Month, LogTime.Day, LogTime.Hour,
              LogTime.Minute, LogTime.Second, ref PhotoImage[0], ref PhotoSize);
            if (ret == (int)FKRun.RUN_SUCCESS)
            {
                PhotoImage = new byte[PhotoSize];
                ret = FK_GetLogPhoto(hComm, EnrollNumber, LogTime.Year, LogTime.Month, LogTime.Day, LogTime.Hour,
                  LogTime.Minute, LogTime.Second, ref PhotoImage[0], ref PhotoSize);
            }
            return ret == (int)FKRun.RUN_SUCCESS;
        }
        public bool GetLogPhoto(string EnrollNumber, DateTime LogTime, ref byte[] PhotoImage)
        {
            int PhotoSize = 0;
            PhotoImage = new byte[4];
            int ret = FK_GetLogPhoto_StringID(hComm, EnrollNumber, LogTime.Year, LogTime.Month, LogTime.Day, LogTime.Hour,
              LogTime.Minute, LogTime.Second, ref PhotoImage[0], ref PhotoSize);
            if (ret == (int)FKRun.RUN_SUCCESS)
            {
                PhotoImage = new byte[PhotoSize];
                ret = FK_GetLogPhoto_StringID(hComm, EnrollNumber, LogTime.Year, LogTime.Month, LogTime.Day, LogTime.Hour,
                  LogTime.Minute, LogTime.Second, ref PhotoImage[0], ref PhotoSize);
            }
            return ret == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_IsSupportedEnrollData(int hComm, int nBackupNumber, ref int pnSupportFlag);
        public bool IsSupportedEnrollData(int nBackupNumber, ref bool nSupportFlag)
        {
            int flag = 0;
            int ret = FK_IsSupportedEnrollData(hComm, nBackupNumber, ref flag);
            nSupportFlag = flag != 0;
            return ret == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetIsSupportStringID(int hComm);
        public bool IsSupportStringID()
        {
            return FK_GetIsSupportStringID(hComm) == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetLogDataIsSupportStringID(int hComm);
        public bool LogDataIsSupportStringID()
        {
            return FK_GetLogDataIsSupportStringID(hComm) == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetUSBEnrollDataIsSupportStringID(int hComm);
        public bool USBEnrollDataIsSupportStringID()
        {
            return FK_GetUSBEnrollDataIsSupportStringID(hComm) == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport("FK623Attend.dll", CharSet = CharSet.Ansi)]
        private static extern int FK_ExtCommand(int hComm, byte[] buff);
        public bool ExtCommand(byte[] buff)
        {
            return FK_ExtCommand(hComm, buff) == (int)FKRun.RUN_SUCCESS;
        }

        public void StructToByteArray(object Struct, byte[] ByteArray)
        {
            try
            {
                IntPtr ptr = IntPtr.Zero;
                int Size = Marshal.SizeOf(Struct);
                if (ByteArray.Length < Size) return;
                ptr = Marshal.AllocHGlobal(Size);
                Marshal.StructureToPtr(Struct, ptr, false);
                Marshal.Copy(ptr, ByteArray, 0, Size);
                Marshal.FreeHGlobal(ptr);
            }
            catch
            {
            }
        }

        public object ByteArrayToStruct(byte[] ByteArray, System.Type Type)
        {
            object obj = null;
            IntPtr ptr;
            try
            {
                int Size = Marshal.SizeOf(Type);
                if (ByteArray.Length < Size) return null;
                ptr = Marshal.AllocHGlobal(Size);
                Marshal.Copy(ByteArray, 0, ptr, Size);
                obj = Marshal.PtrToStructure(ptr, Type);
                Marshal.FreeHGlobal(ptr);
                return obj;
            }
            catch
            {
                return null;
            }
        }

        private bool GetDeviceInfoForIndex(FKDI Index, ref string info)
        {
            int Value = 0;
            string s = "";
            bool ret = GetDeviceInfo((int)Index, ref Value);
            if (ret)
                s = InfoIndexString((int)Index, Value);
            else
                s = ReturnResultPrint();
            s = "    " + s + "\r\n";
            info += s;
            return ret;
        }

        public bool GetDeviceInfoForIndex(FKDI Index, ref int Value)
        {
            Value = 0;
            bool ret = GetDeviceInfo((int)Index, ref Value);
            return ret;
        }

        private bool GetDeviceStatusForIndex(FKDS Index, ref string info)
        {
            int Value = 0;
            string s = "";
            ResultCode = GetDeviceStatus((int)Index, ref Value);
            bool ret = ResultCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
                s = StatusIndexString((int)Index, Value);
            else
                s = ReturnResultPrint();
            s = "    " + s + "\r\n";
            info += s;
            return ret;
        }

        public bool GetDeviceStatusForIndex(FKDS Index, ref int Value)
        {
            Value = 0;
            ResultCode = GetDeviceStatus((int)Index, ref Value);
            bool ret = ResultCode == (int)FKRun.RUN_SUCCESS;
            return ret;
        }

        public bool GetDeviceInfo(ref int MacMANAGERS, ref int MacUSERS, ref int MacFPS, ref int MacFaceS,
          ref int MacPSWS, ref int MacCARDS, ref int MacPALMVEINS, ref int MacGLOGS, ref int MacAGLOGS)
        {
            bool ret = false;
            MacMANAGERS = 0;
            MacUSERS = 0;
            MacFPS = 0;
            MacFaceS = 0;
            MacPSWS = 0;
            MacCARDS = 0;
            MacPALMVEINS = 0;
            MacGLOGS = 0;
            MacAGLOGS = 0;
            ret = GetDeviceStatusForIndex(FKDS.GET_MANAGERS, ref MacMANAGERS);
            if (!ret) return ret;
            ret = GetDeviceStatusForIndex(FKDS.GET_USERS, ref MacUSERS);
            if (!ret) return ret;
            ret = GetDeviceStatusForIndex(FKDS.GET_FPS, ref MacFPS);
            if (!ret) return ret;
            ret = GetDeviceStatusForIndex(FKDS.GET_FACES, ref MacFaceS);
            //if (!ret) return ret;
            ret = GetDeviceStatusForIndex(FKDS.GET_PSWS, ref MacPSWS);
            if (!ret) return ret;
            ret = GetDeviceStatusForIndex(FKDS.GET_CARDS, ref MacCARDS);
            if (!ret) return ret;
            ret = GetDeviceStatusForIndex(FKDS.GET_PALMVEINS, ref MacPALMVEINS);
            //if (!ret) return ret;
            ret = GetDeviceStatusForIndex(FKDS.GET_GLOGS, ref MacGLOGS);
            if (!ret) return ret;
            ret = GetDeviceStatusForIndex(FKDS.GET_AGLOGS, ref MacAGLOGS);
            if (!ret) return ret;
            return ret;
        }
    }

    public class PIDLog
    {
        private string _Name = "";
        private DateTime _Time = new DateTime();
        private string _MacSN = "";
        private string _Gender = "";
        private DateTime _Birthday = new DateTime();
        private string _CardType = "";
        private string _EmpCertNo = "";
        private string _EmpAddress = "";
        private int _InOutMode = 0;
        private string _InOutModeName = "";
        private string _Remark = "";
        private string _Nation = "";
        private double _Temperature;
        private int _TemperatureAlarm;

        public string Nation
        {
            get { return _Nation; }
            set { _Nation = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public DateTime Time
        {
            get { return _Time; }
            set { _Time = value; }
        }

        public string MacSN
        {
            get { return _MacSN; }
            set { _MacSN = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }


        public DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        public string CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }


        public string EmpCertNo
        {
            get { return _EmpCertNo; }
            set { _EmpCertNo = value; }
        }

        public string EmpAddress
        {
            get { return _EmpAddress; }
            set { _EmpAddress = value; }
        }

        public int InOutMode
        {
            get { return _InOutMode; }
            set { _InOutMode = value; }
        }

        public string InOutModeName
        {
            get { return _InOutModeName; }
            set { _InOutModeName = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public double Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }
        public int TemperatureAlarm
        {
            get { return _TemperatureAlarm; }
            set { _TemperatureAlarm = value; }
        }
    }

    public class TFingerLog
    {
        private string _CardID = "";
        private DateTime _Time = new DateTime();
        private byte _ReadMark = 0;
        private string _Remark = "";
        private UInt32 _FingerNo = 0;
        private int _VerifyMode = 0;
        private string _VerifyModeName = "";
        private int _InOutMode = 0;
        private string _InOutModeName = "";
        private int _DoorMode = 0;
        private string _DoorModeName = "";
        private bool _Bell = false;
        private string _DoorStauts = "";
        private int _InOut = 0;
        private int _IoMode = 0;
        private string _MacSN = "";
        private double _Temperature;
        private int _TemperatureAlarm;

        public double Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }
        public int TemperatureAlarm
        {
            get { return _TemperatureAlarm; }
            set { _TemperatureAlarm = value; }
        }

        public string CardID
        {
            get { return _CardID; }
            set { _CardID = value; }
        }

        public DateTime CardTime
        {
            get { return _Time; }
            set { _Time = value; }
        }

        public byte ReadMark
        {
            get { return _ReadMark; }
            set { _ReadMark = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public UInt32 FingerNo
        {
            get { return _FingerNo; }
            set { _FingerNo = value; }
        }

        public int VerifyMode
        {
            get { return _VerifyMode; }
            set { _VerifyMode = value; }
        }

        public string VerifyModeName
        {
            get { return _VerifyModeName; }
            set { _VerifyModeName = value; }
        }

        public int InOutMode
        {
            get { return _InOutMode; }
            set { _InOutMode = value; }
        }

        public int InOut
        {
            get { return _InOut; }
            set { _InOut = value; }
        }

        public string InOutModeName
        {
            get { return _InOutModeName; }
            set { _InOutModeName = value; }
        }

        public int DoorMode
        {
            get { return _DoorMode; }
            set { _DoorMode = value; }
        }

        public string DoorModeName
        {
            get { return _DoorModeName; }
            set { _DoorModeName = value; }
        }

        public bool Bell
        {
            get { return _Bell; }
            set { _Bell = value; }
        }

        public string DoorStauts
        {
            get { return _DoorStauts; }
            set { _DoorStauts = value; }
        }

        public int IoMode
        {
            get { return _IoMode; }
            set { _IoMode = value; }
        }
        public string MacSN
        {
            get { return _MacSN; }
            set { _MacSN = value; }
        }

    }

    public class FingerReadData
    {
        private Base Pub = new Base();
        private string cap = "";
        private string msgContinue = "";
        private byte IsNew = 0;
        private TFingerLog attLog = new TFingerLog();

        private PIDLog pidLog = new PIDLog();
        private bool IsStop = false;
        private const string TextFMT = "yyyyMMddHHmmss";
        private List<MJInfoList> NMJList = new List<MJInfoList>();
        public DataTable tableEmp = null;
        public DataTable tableTemporaryData = null;

        public DataTable dtEmpData = new DataTable();


        public delegate void ProcessReadData(int RecordCount, int RecordIndex, string MacSN, TFingerLog attLog,
          string GUID, bool ShowDetailData);

        public FingerReadData(string title)
        {
            cap = title;
            msgContinue = Pub.GetResText("", "MsgContinue", "");
        }

        public FingerReadData(string title, byte NewData)
        {
            cap = title;
            msgContinue = Pub.GetResText("", "MsgContinue", "");
            IsNew = NewData;
        }

        public void StopData()
        {
            IsStop = true;
        }

        public void SetLogName(TFingerLog attLog)
        {
            int VerifyMode = attLog.VerifyMode;
            string VerifyModeName = "";
            int InOutMode = attLog.InOutMode;
            string InOutModeName = "";
            int DoorMode = 0;
            bool Bell = false;
            string DoorModeName = "";
            int InOut = 0;
            DeviceObject.objFK623.GetVerifyModeName(ref VerifyMode, ref InOutMode, ref VerifyModeName,
              ref InOutModeName, ref DoorMode, ref DoorModeName, ref Bell, ref InOut);
            attLog.VerifyMode = VerifyMode;
            attLog.VerifyModeName = VerifyModeName;
            attLog.InOutMode = InOutMode;
            attLog.InOutModeName = InOutModeName;
            attLog.DoorMode = DoorMode;
            attLog.DoorModeName = DoorModeName;
            attLog.Bell = Bell;
            attLog.InOut = InOut;
        }

        public void Star_SetLogName(TFingerLog attLog)
        {
            int VerifyMode = attLog.VerifyMode;
            string VerifyModeName = "";
            int InOutMode = attLog.InOutMode;
            string InOutModeName = "";
            int DoorMode = attLog.DoorMode;
            int IoMode = attLog.IoMode;
            bool Bell = false;
            string DoorModeName = "";
            int InOut = attLog.InOut;
            DeviceObject.objFK623.Star_GetVerifyModeName(ref VerifyMode, ref InOutMode, ref VerifyModeName,
              ref InOutModeName, ref DoorMode, ref DoorModeName, ref Bell, ref InOut, ref IoMode);
            attLog.VerifyMode = VerifyMode;
            attLog.VerifyModeName = VerifyModeName;
            attLog.InOutMode = InOutMode;
            attLog.InOutModeName = InOutModeName;
            attLog.DoorMode = DoorMode;
            attLog.DoorModeName = DoorModeName;
            attLog.Bell = Bell;
            attLog.InOut = InOut;
            attLog.IoMode = IoMode;
        }


        public void Sea_SetLogName(TFingerLog attLog,int InOutMode,int VerifyStatus, int VerifyType)
        {
            //进出方式
            if (InOutMode == 0)
            {
                attLog.InOutModeName = Pub.GetResText("Public", "LOG_IOMODE_IO", "");
            }
            else if (InOutMode == 1)
            {
                attLog.InOutModeName = Pub.GetResText("Public", "LOG_IOMODE_IN1", "");
            }
            else if (InOutMode == 2)
            {
                attLog.InOutModeName = Pub.GetResText("Public", "LOG_IOMODE_OUT1", "");
            }
          
            //识别类型
            switch(VerifyType)
            {
                case 1:
                    attLog.VerifyMode = 1;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_WHITELIST", "");
                    break;
                case 2:
                    attLog.VerifyMode = 2;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_IDCARD", "");
                    break;
                case 3:
                    attLog.VerifyMode = 3;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_WHITELISTIDCARD", "");
                    break;
                case 21:
                    attLog.VerifyMode = 21;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_RFCARD", "");
                    break;
                case 22:
                    attLog.VerifyMode = 22;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_RFCARDWHITELIST", "");
                    break;
                case 24:
                    attLog.VerifyMode = 24;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_WIGANCARD", "");
                    break;
                case 25:
                    attLog.VerifyMode = 25;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_WIGANCARDWHITELIST", "");
                    break;
                case 27:
                    attLog.VerifyMode = 0;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_PROG_OPEN", "");
                    break;
                case 256:
                    attLog.VerifyMode = 256;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_MASK", "");
                    break;
                case 257:
                    attLog.VerifyMode = 257;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_MASK_WHITE", "");
                    break;
                case 512:
                    attLog.VerifyMode = 512;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_TEMPPERATURE", "");
                    break;
                case 513:
                    attLog.VerifyMode = 513;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_TEMPPERATURE_WHITE", "");
                    break;
                case 768:
                    attLog.VerifyMode = 513;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_TEMPPERATURE_MASK", "");
                    break;
                case 793:
                    attLog.VerifyMode = 513;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_TEMPPERATURE_MASK_WHITE_CARD", "");
                    break;

            }

            if (VerifyStatus == 1)
            {
                attLog.DoorMode = 9;
                attLog.DoorModeName = Pub.GetResText("Public", "LOG_OPEN_DOOR", "");
            }
            else if(VerifyType == 27)
            {
                attLog.DoorMode = 3;
                attLog.DoorModeName = Pub.GetResText("Public", "LOG_PROG_OPEN", "");   
            }
            else
            {
                attLog.DoorMode = 0;
            }
           
        }

       

        public bool IsKQData(TFingerLog attLog)
        {
            switch (attLog.VerifyMode)
            {
                case (int)FKLog.LOG_FPVERIFY:
                case (int)FKLog.LOG_PASSVERIFY:
                case (int)FKLog.LOG_CARDVERIFY:
                case (int)FKLog.LOG_FPPASS_VERIFY:
                case (int)FKLog.LOG_FPCARD_VERIFY:
                case (int)FKLog.LOG_PASSFP_VERIFY:
                case (int)FKLog.LOG_CARDFP_VERIFY:
                case (int)FKLog.LOG_CARDPASS_VERIFY:
                case (int)FKLog.LOG_FACEVERIFY:
                case (int)FKLog.LOG_FACECARDVERIFY:
                case (int)FKLog.LOG_FACEPASSVERIFY:
                case (int)FKLog.LOG_CARDFACEVERIFY:
                case (int)FKLog.LOG_PASSFACEVERIFY:
                case (int)FKLog.LOG_FACE_FP_VERIFY:
                case (int)FKLog.LOG_FP_FACE_VERIFY:
                case (int)FKLog.LOG_PPVERIFY:
                case (int)FKLog.LOG_PPPASSVERIFY:
                case (int)FKLog.LOG_PPCARDVERIFY:
                case (int)FKLog.LOG_PASSPPVERIFY:
                case (int)FKLog.LOG_CARDPPVERIFY:
                case (int)FKLog.LOG_FACE_PP_VERIFY:
                case (int)FKLog.LOG_PP_FACE_VERIFY:
                case (int)FKLog.LOG_FP_PP_VERIFY:
                case (int)FKLog.LOG_MASK:
                case (int)FKLog.LOG_MASK_WHITE:
                case (int)FKLog.LOG_TEMPPERATURE:
                case (int)FKLog.LOG_TEMPPERATURE_MASK:
                case (int)FKLog.LOG_TEMPPERATURE_WHITE:
                case (int)FKLog.LOG_TEMPPERATURE_MASK_WHITE_CARD:
                    return true;
                default:
                    return false;
            }
        }

        private bool IsInDate(DateTime dt, DateTime dt1, DateTime dt2)
        {
            bool ret = false;
            if (DateTime.Compare(dt, dt1) >= 0 && DateTime.Compare(dt, dt2) <= 0) ret = true;
            else ret = false;
            return ret;
        }

        private string GetGUID()
        {
            string ret = System.Guid.NewGuid().ToString().ToUpper();
            return ret;
        }

    

        public void deleteTemporaryDataMacSN(string MacSNn)
        {
            for (int i = 0; i < tableTemporaryData.Rows.Count; i++)
            {
                if (tableTemporaryData.Rows[i]["MacSN"].Equals(MacSNn))
                {
                    tableTemporaryData.Rows[i].Delete();
                }
            }
            tableTemporaryData.AcceptChanges();
        }
        public void deleteTemporaryData(string MacSNn, string EmpNoo)
        {
            for (int i = 0; i < tableTemporaryData.Rows.Count; i++)
            {
                if (tableTemporaryData.Rows[i]["MacSN"].Equals(MacSNn) && tableTemporaryData.Rows[i]["EmpNo"].Equals(EmpNoo))
                {
                    tableTemporaryData.Rows[i].Delete();
                }
            }
            tableTemporaryData.AcceptChanges();
        }

        public void deleteTemporaryData(string GUID)
        {
            for (int i = 0; i < tableTemporaryData.Rows.Count; i++)
            {
                if (tableTemporaryData.Rows[i]["GUID"].Equals(GUID))
                {
                    tableTemporaryData.Rows[i].Delete();
                }
            }
            tableTemporaryData.AcceptChanges();
        }

        public void ManyMJDate(string MacSN, TFingerLog attLog, string GUID)
        {
            string EmpNo = "";
            string EmpName = "";
            string DepartID = "";
            string DepartName = "";
            string MacDesc = "";
            string ReMacSN = "";
            string ReEmpNo = "";
            string ReEmpName = "";
            string reGUID = "";
            string EmpNoOne = "";
            string EmpNoTwo = "";
            string EmpNoTree = "";
            string EmpNoFour = "";
            string EmpNoFive = "";
            string sql = "SELECT MJDateTime, EmpNoOne FROM MJ_OpenData";

            DataTableReader dr = null;
            MJInfoList mJInfoList = null;

            try
            {
                DataRow[] dataRow = SystemInfo.saveDataToDatabase.tableRSEmp.Select("FingerNo = " + attLog.CardID + "");
                if (dataRow.Length > 0)
                {
                    EmpNo = dataRow[0]["EmpNo"].ToString();
                    EmpName = dataRow[0]["EmpName"].ToString();
                    DepartID = dataRow[0]["DepartID"].ToString();
                    DepartName = dataRow[0]["DepartName"].ToString();

                    DataRow[] timeIntervalRow = tableTemporaryData.Select("MacSN='"+MacSN+"'");
                   
                    if (timeIntervalRow.Length>0)
                    {
                        DateTime timeInterval1 = Convert.ToDateTime(timeIntervalRow[timeIntervalRow.Length - 1]["MJDateTime"].ToString());
                        DateTime timeInterval2 = attLog.CardTime;

                        TimeSpan ts = timeInterval2 - timeInterval1;
                        long timeInterval = Convert.ToInt64(ts.TotalMinutes);

                        if(timeInterval > 5)
                        {
                            deleteTemporaryDataMacSN(MacSN);
                        }
                    }
                   
                    deleteTemporaryData(MacSN, EmpNo);
                    tableTemporaryData.Rows.Add(GetGUID().ToString(), attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, EmpNo, EmpName);
                }
             
                if (attLog.DoorMode == 9)
                {
                   
                    DataRow[] row = tableTemporaryData.Select("MacSN='" + MacSN + "'");
                    for (int i = 0; i < row.Length; i++)
                    { 
                        ReMacSN = row[i]["MacSN"].ToString();
                        ReEmpNo = row[i]["EmpNo"].ToString();
                        ReEmpName = row[i]["EmpName"].ToString();

                        mJInfoList = new MJInfoList(ReMacSN, ReEmpNo, ReEmpName);
                        NMJList.Add(mJInfoList);
                        
                        reGUID = row[i]["GUID"].ToString();
                        deleteTemporaryData(reGUID);
                    }
                    switch(NMJList.Count)
                    {
                        case 1:
                            EmpNoOne = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                            EmpNoTwo = "";
                            EmpNoTree = "";
                            break;
                        case 2:
                            EmpNoOne = NMJList[NMJList.Count - 2].EnrollNumber + " [" + NMJList[NMJList.Count - 2].EmpName + "] ";
                            EmpNoTwo = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                            EmpNoTree = "";
                            break;
                        case 3:
                            EmpNoOne = NMJList[NMJList.Count - 3].EnrollNumber + " [" + NMJList[NMJList.Count - 3].EmpName + "] ";
                            EmpNoTwo = NMJList[NMJList.Count - 2].EnrollNumber + " [" + NMJList[NMJList.Count - 2].EmpName + "] ";
                            EmpNoTree = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                            break;
                        case 4:
                            EmpNoOne = NMJList[NMJList.Count - 4].EnrollNumber + " [" + NMJList[NMJList.Count - 4].EmpName + "] ";
                            EmpNoTwo = NMJList[NMJList.Count - 3].EnrollNumber + " [" + NMJList[NMJList.Count - 3].EmpName + "] ";
                            EmpNoTree = NMJList[NMJList.Count - 2].EnrollNumber + " [" + NMJList[NMJList.Count - 2].EmpName + "] ";
                            EmpNoFour = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                            break;
                        case 5:
                            EmpNoOne = NMJList[NMJList.Count - 5].EnrollNumber + " [" + NMJList[NMJList.Count - 5].EmpName + "] ";
                            EmpNoTwo = NMJList[NMJList.Count - 4].EnrollNumber + " [" + NMJList[NMJList.Count - 4].EmpName + "] ";
                            EmpNoTree = NMJList[NMJList.Count - 3].EnrollNumber + " [" + NMJList[NMJList.Count - 3].EmpName + "] ";
                            EmpNoFour = NMJList[NMJList.Count - 2].EnrollNumber + " [" + NMJList[NMJList.Count - 2].EmpName + "] ";
                            EmpNoFive = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                            break;
                    }
                   
                    if (SystemInfo.DBType == 0 || SystemInfo.DBType == 1)
                    {
                        if(tableEmp==null)
                        {
                            tableEmp = SystemInfo.db.GetDataTable(sql);
                        }
                        if (tableEmp.Select("MJDateTime='" + attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT) + "' AND EmpNoOne='" + EmpNoOne + "'").Length == 0
                            && dtEmpData.Select("MJDateTime='" + attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT) + "' AND EmpNoOne='" + EmpNoOne + "'").Length == 0)
                        {

                            dtEmpData.Rows.Add(new object[] { GetGUID().ToString(), attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, MacDesc,
                                 attLog.InOutModeName, EmpNoOne, EmpNoTwo, EmpNoTree, EmpNoFour, EmpNoFive});

                            if (dtEmpData.Rows.Count >= 7000)
                            {
                                SystemInfo.db.batchSeveData(dtEmpData, "MJ_OpenData");

                                int count = tableEmp.Rows.Count;
                            EE:
                                tableEmp = null;
                                tableEmp = SystemInfo.db.GetDataTable(sql);
                                if (tableEmp.Rows.Count == 0 || count == tableEmp.Rows.Count)
                                {
                                    goto EE;
                                }

                                dtEmpData.Rows.Clear();
                            }
                        }
                    }

                    NMJList.Clear();
                }
            }
            catch(Exception E)
            {
                Pub.ShowErrorMsg(E,sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }

        }

        public bool FK623ReadData(KQTextFormatInfo textFormat, string MacSN, ref int RecordCount,
          ref int RecordIndex, ProcessReadData prog)
        {
            RecordCount = 0;
            RecordIndex = 0;
            bool ret = false;
            int DevMode = 0;

            try
            {
                List<string> sqlList = new List<string>();
                SystemInfo.sqlList.Clear();

                SystemInfo.saveDataToDatabase.dtMJData.Rows.Clear();
                SystemInfo.saveDataToDatabase.dtData.Rows.Clear();

                SystemInfo.saveDataToDatabase.dtMJData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_MJData where 1=0");
                SystemInfo.saveDataToDatabase.dtData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_KQData where 1=0");

                if (SystemInfo.saveDataToDatabase.table != null)
                    SystemInfo.saveDataToDatabase.table.Clear();
                if (SystemInfo.saveDataToDatabase.tableMJ != null)
                    SystemInfo.saveDataToDatabase.tableMJ.Clear();
                if (SystemInfo.saveDataToDatabase.tableRSEmp != null)
                    SystemInfo.saveDataToDatabase.tableRSEmp.Clear();

                SystemInfo.saveDataToDatabase.table = SystemInfo.db.GetDataTable("SELECT EmpNo,KQDate,KQTime FROM KQ_KQData");

                SystemInfo.saveDataToDatabase.tableMJ = SystemInfo.db.GetDataTable("SELECT [GUID], MacSN,VerifyModeID,KQDate,KQTime FROM KQ_MJData");

                SystemInfo.saveDataToDatabase.tableRSEmp = SystemInfo.db.GetDataTable("SELECT FingerNo,EmpNo,EmpName,DepartID,DepartName FROM VRS_Emp");

                if (SystemInfo.AllowMJ)
                {
                    dtEmpData.Rows.Clear();
                    if (tableEmp != null)
                        tableEmp.Clear();
                    if (tableTemporaryData != null)
                        tableTemporaryData.Clear();
                    tableEmp = SystemInfo.db.GetDataTable("SELECT MJDateTime, EmpNoOne FROM MJ_OpenData");
                    dtEmpData = SystemInfo.db.GetDataTable("SELECT * FROM MJ_OpenData where 0=1");
                    tableTemporaryData = SystemInfo.db.GetDataTable("SELECT [GUID],MJDateTime,MacSN,EmpNo,EmpName FROM MJ_TemporaryData");
                }

                //获取设备模式
                DataTableReader dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "2", MacSN }));
                if (dr.Read())
                {
                    Int32.TryParse(dr["DevModeID"].ToString(), out DevMode);
                }
                dr.Close();
                bool IsTime = false;
                string GUID = "";
                if (IsNew == 1)
                    ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_GLOGS, ref RecordCount);

                else
                    ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_AGLOGS, ref RecordCount);

                if (ret && RecordCount > 0)
                {
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.LoadGeneralLogData(IsNew);
                    DeviceObject.objFK623.EnableDevice(1);
                    ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
                    if (ret)
                    {
                        UInt32 EnrollNumber = 0;
                        int VerifyMode = 0;
                        int InOutMode = 0;
                        DateTime dwDate = new DateTime();
                        byte[] PhotoImage = new byte[0];

                        do
                        {
                            if (IsStop) break;
                            Application.DoEvents();
                            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetGeneralLogData(ref EnrollNumber,
                              ref VerifyMode, ref InOutMode, ref dwDate);
                            if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                            {
                                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                                    DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                break;
                            }
                            if (!app.IsAll)
                            {
                                //判断当前时间是否在工作时间段内
                                string Stat = app.timeStat;
                                string End = app.timeEnd;
                                DateTime _strWorkingDayAM = DateTime.Parse(Stat);
                                DateTime _strWorkingDayPM = DateTime.Parse(End + " 23:59:59");
                                if (IsInDate(dwDate, _strWorkingDayAM, _strWorkingDayPM))
                                {
                                    IsTime = true;
                                }
                                else
                                    IsTime = false;
                            }
                            else
                            {
                                IsTime = true;
                            }

                            if (IsTime)
                            {
                                attLog = new TFingerLog();
                                attLog.CardID = EnrollNumber.ToString("0000000000");
                                attLog.CardTime = dwDate;
                                attLog.FingerNo = EnrollNumber;
                                attLog.VerifyMode = VerifyMode;
                                attLog.InOutMode = InOutMode;
                                SetLogName(attLog);
                                bool IsKQ = IsKQData(attLog);
                                if (IsKQ)
                                {
                                    WriteTextFile(attLog, MacSN);
                                    if (textFormat.Allow) WriteTextFormat(textFormat, attLog, MacSN);
                                    //SaveDB(attLog, MacSN, false, ref GUID);
                                    if(DevMode==0 || DevMode==1)
                                    {
                                        batchSaveDB(attLog, MacSN, true, ref GUID);//批量插入数据库
                                        if (SystemInfo.isAttendancePhoto)
                                        {
                                            if (GUID != "" && DeviceObject.objFK623.GetLogPhoto(EnrollNumber, dwDate, ref PhotoImage))
                                            {

                                                SaveDBPhoto(GUID, PhotoImage);

                                            }
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
                                    WriteTextFileMJ(attLog, MacSN);
                                    //SaveDBMJ(attLog, MacSN, false, ref GUID);
                                    if (DevMode == 0 || DevMode == 2)
                                    {
                                        batchSaveDBMJ(attLog, MacSN, true, ref GUID);//批量插入数据库
                                        if (SystemInfo.isAttendancePhoto)
                                        {
                                            if (GUID != "" && DeviceObject.objFK623.GetLogPhoto(EnrollNumber, dwDate, ref PhotoImage))
                                            {
                                                SaveDBPhotoMJ(GUID, PhotoImage);
                                            }
                                        }
                                    }
                                }
                                if (IsKQ && attLog.DoorMode > 0)
                                {
                                    attLog.VerifyMode = attLog.DoorMode;
                                    attLog.VerifyModeName = attLog.DoorModeName;
                                    //SaveDBMJ(attLog, MacSN, false, ref GUID);
                                    if (DevMode == 0 || DevMode == 2)
                                    {
                                        batchSaveDBMJ(attLog, MacSN, true, ref GUID);//批量插入数据库
                                        if (SystemInfo.isAttendancePhoto)
                                        {
                                            if (GUID != "" && DeviceObject.objFK623.GetLogPhoto(EnrollNumber, dwDate, ref PhotoImage))
                                            {
                                                SaveDBPhotoMJ(GUID, PhotoImage);
                                            }
                                        }
                                    }
                                    
                                }
                                RecordIndex = RecordIndex + 1;
                                if (prog != null) prog(RecordCount, RecordIndex, MacSN, attLog, GUID, false);
                                if (SystemInfo.AllowMJ)
                                    ManyMJDate(MacSN, attLog, GUID);
                            }
                        }
                        while (true);
                        //批量插入数据到数据库
                        if(dtEmpData.Rows.Count>0)
                        {
                            SystemInfo.db.batchSeveData(dtEmpData, "MJ_OpenData");
                        }
                        if (SystemInfo.saveDataToDatabase.dtData.Rows.Count > 0)
                        {
                            SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtData, "KQ_KQData");
                        }
                        if (SystemInfo.saveDataToDatabase.dtMJData.Rows.Count > 0)
                        {
                            SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtMJData, "KQ_MJData");
                        }

                        if (SystemInfo.AllowMJ)
                        {
                            SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "709" }));
                            for (int i = 0; i < tableTemporaryData.Rows.Count; i++)
                            {

                                string EmpNo = tableTemporaryData.Rows[i]["EmpNo"].ToString();
                                string EmpName = tableTemporaryData.Rows[i]["EmpName"].ToString();
                                string guid = tableTemporaryData.Rows[i]["GUID"].ToString();
                                string MJDateTime = tableTemporaryData.Rows[i]["MJDateTime"].ToString();
                                if (MJDateTime != "")
                                {
                                    MJDateTime = Convert.ToDateTime(MJDateTime).ToString(SystemInfo.SQLDateTimeFMT);
                                }
                                sqlList.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "708",guid,
                            MJDateTime, MacSN, EmpNo, EmpName }));
                            }
                            tableTemporaryData.Clear();
                            dtEmpData.Rows.Clear();
                            tableEmp = null;
                        }

                        if (sqlList.Count > 0)
                            SystemInfo.db.ExecSQL(sqlList, prog);
                    }
                }
                int scnt = 0;
                bool sret = false;
                if (IsNew == 1)
                    sret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_SLOGS, ref scnt);
                else
                    sret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_ASLOGS, ref scnt);

                if (sret && scnt >= 0)
                {
                    int RunCode = DeviceObject.objFK623.LoadSuperLogData(IsNew);
                    if (RunCode == (int)FKRun.RUN_SUCCESS)
                    {
                        UInt32 SEnrollNo = 0;
                        UInt32 GEnrollNo = 0;
                        int Manipulation = 0;
                        int BakNo = 0;
                        DateTime dwDate = new DateTime();
                        do
                        {
                            if (IsStop) break;
                            Application.DoEvents();
                            RunCode = DeviceObject.objFK623.GetSuperLogData(ref SEnrollNo, ref GEnrollNo,
                              ref Manipulation, ref BakNo, ref dwDate);
                            if (RunCode != (int)FKRun.RUN_SUCCESS)
                            {
                                if (RunCode == (int)FKRun.RUNERR_DATAARRAY_END) RunCode = (int)FKRun.RUN_SUCCESS;
                                break;
                            }
                            SaveDBSLog(MacSN, SEnrollNo, GEnrollNo, Manipulation, BakNo, dwDate);
                        }
                        while (true);
                    }
                }

            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {

                SystemInfo.saveDataToDatabase.dtMJData.Rows.Clear();
                SystemInfo.saveDataToDatabase.dtData.Rows.Clear();
                SystemInfo.saveDataToDatabase.table = null;
                SystemInfo.saveDataToDatabase.tableMJ = null;
                SystemInfo.saveDataToDatabase.tableRSEmp.Clear();
            }
            return ret;
        }

        public bool Star_FK623ReadData(KQTextFormatInfo textFormat, string MacSN, bool isSelect, ref int RecordCount,
         ref int RecordIndex, ProcessReadData prog)
        {
            int DevMode = 0;
            RecordCount = 0;
            RecordIndex = 0;
            bool ret = false;
            string InOutMode = "";
            string PhotoStr = "";
            string VerifyStatus = "";
            int newLog = 0;
            int clearMark = 0;
            List<string> sqlList = new List<string>();
            SystemInfo.sqlList.Clear();
            SystemInfo.saveDataToDatabase.dtMJData.Rows.Clear();
            SystemInfo.saveDataToDatabase.dtData.Rows.Clear();

            SystemInfo.saveDataToDatabase.dtMJData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_MJData where 1=0");
            SystemInfo.saveDataToDatabase.dtData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_KQData where 1=0");

            List<_ResultInfo<RecordInfo<Logs>>> RecordInfoList = new List<_ResultInfo<RecordInfo<Logs>>>();//获取记录
            if (SystemInfo.saveDataToDatabase.table != null)
                SystemInfo.saveDataToDatabase.table.Clear();
            if (SystemInfo.saveDataToDatabase.tableMJ != null)
                SystemInfo.saveDataToDatabase.tableMJ.Clear();
            if (SystemInfo.saveDataToDatabase.tableRSEmp != null)
                SystemInfo.saveDataToDatabase.tableRSEmp.Clear();

            SystemInfo.saveDataToDatabase.table = SystemInfo.db.GetDataTable("SELECT EmpNo,KQDate,KQTime FROM KQ_KQData");

            SystemInfo.saveDataToDatabase.tableMJ = SystemInfo.db.GetDataTable("SELECT [GUID], MacSN,VerifyModeID,KQDate,KQTime FROM KQ_MJData");

            SystemInfo.saveDataToDatabase.tableRSEmp = SystemInfo.db.GetDataTable("SELECT FingerNo,EmpNo,EmpName,DepartID,DepartName FROM VRS_Emp");

            if (SystemInfo.AllowMJ)
            {
                dtEmpData.Rows.Clear();
                if (tableEmp != null)
                    tableEmp.Clear();
                if (tableTemporaryData != null)
                    tableTemporaryData.Clear();
                tableEmp = SystemInfo.db.GetDataTable("SELECT MJDateTime, EmpNoOne FROM MJ_OpenData");
                dtEmpData = SystemInfo.db.GetDataTable("SELECT * FROM MJ_OpenData where 0=1");
                tableTemporaryData = SystemInfo.db.GetDataTable("SELECT [GUID],MJDateTime,MacSN,EmpNo,EmpName FROM MJ_TemporaryData");
            }

            //获取设备模式
            DataTableReader dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "2", MacSN }));
            if (dr.Read())
            {
                Int32.TryParse(dr["DevModeID"].ToString(), out DevMode);
            }
            dr.Close();

            string GUID = "";
            try
            {
                RecordInfoList.Clear();
                string cmd = "GetLogData";
                string beginTime = app.timeStat;
                string endTime = app.timeEnd;
                int sendCount = 0;
                if (isSelect)
                {
                    IsDateTime("yyyyMMdd", ref beginTime);
                    IsDateTime("yyyyMMdd", ref endTime);
                }
                else
                {
                    beginTime = null;
                    endTime = null;
                }
                if(app.IsAll)
                {
                    newLog = 0;
                    clearMark = 0;
                }
                else
                {
                    newLog = 1;
                    clearMark = 1;
                }

                RecordIndex = 0;

                GetLogDataCmd getLogDataCmd = new GetLogDataCmd(0, newLog, beginTime, endTime, clearMark);
                _DeviceCmd<GetLogDataCmd> devGetLogDataCmd = new _DeviceCmd<GetLogDataCmd>(cmd, getLogDataCmd);

                while (true)
                {
                    if(devGetLogDataCmd.data.packageId>0)
                    {
                        if (prog != null) prog(devGetLogDataCmd.data.packageId, devGetLogDataCmd.data.packageId, MacSN, null, GUID, false);
                    }

                    StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devGetLogDataCmd));
                  
                    if(DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                    {
                        int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                        if (state == 0)
                        {
                            _ResultInfo<RecordInfo<Logs>> getLogInfo = JsonConvert.DeserializeObject<_ResultInfo<RecordInfo<Logs>>>(jsonStringBuilder.ToString());
                            RecordInfoList.Add(getLogInfo);
                            ret = true;
                            if (getLogInfo.result_data.logs == null)
                            {
                                break;
                            }
                            if (getLogInfo.result_data.packageId != 0)//表示没有获取完数据，让packageId+1，重新发送获取下一包数据
                            {
                                devGetLogDataCmd.data.packageId++;
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
                                break;
                            else
                            {
                                if (DeviceObject.socKetClient.Open()) continue;
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                   
                }
                for (int l = 0; l < RecordInfoList.Count; l++)
                {
                    _ResultInfo<RecordInfo<Logs>> logInfo = RecordInfoList[l];
                    RecordCount = logInfo.result_data.allLogCount;
                    for (int i = 0; i < logInfo.result_data.logsCount; i++)
                    {
                        byte[] PhotoImage = null;
                        UInt32 FingerNo = Convert.ToUInt32(logInfo.result_data.logs[i].userId);
                        attLog = new TFingerLog();
                        attLog.CardID = FingerNo.ToString("0000000000");
                        attLog.CardTime = DateTime.Parse(stringToTimeStr(logInfo.result_data.logs[i].time));
                        attLog.FingerNo = FingerNo;
                        InOutMode = logInfo.result_data.logs[i].inOut;
                        if(logInfo.result_data.logs[i].doorMode==null)
                        {
                            attLog.DoorMode = 9;
                        }
                        else
                        {
                            attLog.DoorMode = GetDoorMode(logInfo.result_data.logs[i].doorMode);
                        }

                        if (logInfo.result_data.logs[i].logPhoto != null)
                        {
                            PhotoStr = logInfo.result_data.logs[i].logPhoto.Replace("data:image/jpeg;base64,", "");
                            if (PhotoStr.Length > 0)
                            {
                                PhotoImage = Convert.FromBase64String(PhotoStr);
                            }
                        }

                        VerifyStatus = logInfo.result_data.logs[i].verifyMode;
                        if(VerifyStatus != null)
                            attLog.VerifyMode = GetVerifyModeID(VerifyStatus);
                        else
                        {

                        }
                        attLog.InOut = GetInOut(InOutMode);
                        attLog.IoMode = logInfo.result_data.logs[i].ioMode;
                        Star_SetLogName(attLog);
                        bool IsKQ = IsKQData(attLog);
                        if (IsKQ)
                        {
                            WriteTextFile(attLog, MacSN);
                            if (textFormat.Allow) WriteTextFormat(textFormat, attLog, MacSN);
                            if(DevMode==0 || DevMode == 1)
                            {
                                batchSaveDB(attLog, MacSN, true, ref GUID);//批量插入数据库
                                if (GUID != "" && PhotoImage != null)
                                {
                                    SaveDBPhoto(GUID, PhotoImage);
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
                            WriteTextFileMJ(attLog, MacSN);
                            if (DevMode == 0 || DevMode == 2)
                            {
                                batchSaveDBMJ(attLog, MacSN, true, ref GUID);//批量插入数据库
                                if (GUID != "" && PhotoImage != null)
                                {
                                    SaveDBPhotoMJ(GUID, PhotoImage);
                                }
                            }
                            
                        }
                        if (IsKQ && attLog.DoorMode > 0)
                        {
                            attLog.VerifyMode = attLog.DoorMode;
                            attLog.VerifyModeName = attLog.DoorModeName;

                            if (DevMode == 0 || DevMode == 2)
                            {
                                batchSaveDBMJ(attLog, MacSN, true, ref GUID);//批量插入数据库
                                if (GUID != "" && PhotoImage != null)
                                {
                                    SaveDBPhotoMJ(GUID, PhotoImage);
                                }
                            }
                        }
                        RecordIndex = RecordIndex + 1;
                        if (prog != null) prog(RecordCount, RecordIndex, MacSN, attLog, GUID, false);
                        if (SystemInfo.AllowMJ)
                            ManyMJDate(MacSN, attLog, GUID);
                    }
                
                }

                //批量插入数据到数据库
                if (dtEmpData.Rows.Count > 0)
                {
                    SystemInfo.db.batchSeveData(dtEmpData, "MJ_OpenData");
                }
                if (SystemInfo.saveDataToDatabase.dtData.Rows.Count > 0)
                {
                    SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtData, "KQ_KQData");
                }
                if (SystemInfo.saveDataToDatabase.dtMJData.Rows.Count > 0)
                {
                    SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtMJData, "KQ_MJData");
                }

                if (SystemInfo.AllowMJ)
                {
                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "709" }));
                    for (int i = 0; i < tableTemporaryData.Rows.Count; i++)
                    {

                        string EmpNo = tableTemporaryData.Rows[i]["EmpNo"].ToString();
                        string EmpName = tableTemporaryData.Rows[i]["EmpName"].ToString();
                        string guid = tableTemporaryData.Rows[i]["GUID"].ToString();
                        string MJDateTime = tableTemporaryData.Rows[i]["MJDateTime"].ToString();
                        if (MJDateTime != "")
                        {
                            MJDateTime = Convert.ToDateTime(MJDateTime).ToString(SystemInfo.SQLDateTimeFMT);
                        }
                        sqlList.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "708",guid,
                            MJDateTime, MacSN, EmpNo, EmpName }));
                    }
                    tableTemporaryData.Clear();
                    dtEmpData.Rows.Clear();
                    tableEmp = null;
                }

                if (sqlList.Count > 0)
                    SystemInfo.db.ExecSQL(sqlList, prog);
            }
            catch (Exception ex)
            {
                Pub.ShowErrorMsg(ex);
            }
            finally
            {
                SystemInfo.saveDataToDatabase.dtMJData.Rows.Clear();
                SystemInfo.saveDataToDatabase.dtData.Rows.Clear();

                SystemInfo.saveDataToDatabase.table = null;
                SystemInfo.saveDataToDatabase.tableMJ = null;
                SystemInfo.saveDataToDatabase.tableRSEmp.Clear();
            }
            return ret;
        }
        /// <summary>
        /// 转换时间格式
        /// </summary>
        /// <param name="type"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool IsDateTime(string type, ref string time)
        {
            try
            {
                time = Convert.ToDateTime(time).ToString(type);

            }
            catch
            {
                time = null;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 字符串转数据格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string stringToTimeStr(string time)
        {
            if (time.Length == 14)
            {
                time = time.Insert(4, "-");
                time = time.Insert(7, "-");
                time = time.Insert(10, " ");
                time = time.Insert(13, ":");
                time = time.Insert(16, ":");
            }
            return time;
        }

        public int GetVerifyModeID(string verifyMode)
        {
            int ret = 0;
            switch(verifyMode.Replace(" ","").ToLower())
            {
                case "fp":
                    ret = (int)FKLog.LOG_FPVERIFY;
                    break;
                case "pass":
                case "password":
                    ret = (int)FKLog.LOG_PASSVERIFY;
                    break;
                case "card":
                case "idcard":
                    ret = (int)FKLog.LOG_CARDVERIFY;
                    break;
                case "fp+pass":
                case "fp+password":
                    ret = (int)FKLog.LOG_FPPASS_VERIFY;
                    break;
                case "fp+card":
                case "fp+idcard":
                    ret = (int)FKLog.LOG_FPCARD_VERIFY;
                    break;
                case "pass+fp":
                case "password+fp":
                    ret = (int)FKLog.LOG_PASSFP_VERIFY;
                    break;
                case "card+fp":
                case "idcard+fp":
                    ret = (int)FKLog.LOG_CARDFP_VERIFY;
                    break;
                case "card+pass":
                case "card+password":
                case "idcard+pass":
                case "idcard+password":
                    ret = (int)FKLog.LOG_CARDPASS_VERIFY;
                    break;
                case "face":
                    ret = (int)FKLog.LOG_FACEVERIFY;
                    break;
                case "face+card":
                case "face+idcard":
                    ret = (int)FKLog.LOG_FACECARDVERIFY;
                    break;
                case "face+pass":
                case "face+password":
                    ret = (int)FKLog.LOG_FACEPASSVERIFY;
                    break;
                case "card+face":
                case "idcard+face":
                    ret = (int)FKLog.LOG_CARDFACEVERIFY;
                    break;
                case "pass+face":
                case "password+face":
                    ret = (int)FKLog.LOG_PASSFACEVERIFY;
                    break;
                case "face+fp":
                    ret = (int)FKLog.LOG_FACE_FP_VERIFY;
                    break;
                case "fp+face":
                    ret = (int)FKLog.LOG_FP_FACE_VERIFY;
                    break;
                case "pp":
                    ret = (int)FKLog.LOG_PPVERIFY;
                    break;
                case "pp+pass":
                case "pp+password":
                    ret = (int)FKLog.LOG_PPPASSVERIFY;
                    break;
                case "pp+card":
                case "pp+idcard":
                    ret = (int)FKLog.LOG_PPCARDVERIFY;
                    break;
                case "pass+pp":
                case "password+pp":
                    ret = (int)FKLog.LOG_PASSPPVERIFY;
                    break;
                case "card+pp":
                case "idcard+pp":
                    ret = (int)FKLog.LOG_CARDPPVERIFY;
                    break;
                case "face+pp":
                    ret = (int)FKLog.LOG_FACE_PP_VERIFY;
                    break;
                case "pp+face":
                    ret = (int)FKLog.LOG_PP_FACE_VERIFY;
                    break;
                case "fp+pp":
                    ret = (int)FKLog.LOG_FP_PP_VERIFY;
                    break;
                default:
                    break;
            }
            return ret;
        }

        public int GetInOut(string inout)
        {
            int ret = 0;
            switch (inout.ToLower())
            {
                case "in":
                    ret = (int)FKLog.LOG_IOMODE_IN1;
                    break;
                case "out":
                    ret = (int)FKLog.LOG_IOMODE_OUT1;
                    break;
                default:
                    break;
            }
            return ret;
        }

        public int GetDoorMode(string inout)
        {
            int ret = 0;
            switch (inout.ToLower())
            {
                case "close_door":
                    ret = (int)FKLog.LOG_CLOSE_DOOR;
                    break;
                case "hand_open":
                    ret = (int)FKLog.LOG_OPEN_HAND;
                    break;
                case "remote_close":
                    ret = (int)FKLog.LOG_PROG_CLOSE;
                    break;
                case "remote_open":
                    ret = (int)FKLog.LOG_PROG_OPEN;
                    break;
                case "Illegal_open":
                    ret = (int)FKLog.LOG_OPEN_IREGAL;
                    break;
                case "Illegal_close":
                    ret = (int)FKLog.LOG_CLOSE_IREGAL;
                    break;
                case "Schedule_open":
                    ret = (int)FKLog.LOG_OPEN_COVER;
                    break;
                case "Schedule_close":
                    ret = (int)FKLog.LOG_CLOSE_COVER;
                    break;
                default:
                    ret = (int)FKLog.LOG_OPEN_DOOR;
                    break;
            }
            return ret;
        }

        public bool SeaSeries_FK623ReadData  (KQTextFormatInfo textFormat, string MacSN, string url, string name, string pwd, bool isSelect, ref int RecordCount,
            ref int RecordIndex, ProcessReadData prog)
        {
            RecordCount = 0;
            RecordIndex = 0;
            bool ret = false;
            int InOutMode = 0;
            int DevMode = 0;
            string PhotoStr = "";
            int VerifyStatus = 0;
            int VerifyType = 0;
            List<string> sqlList = new List<string>();
            SystemInfo.sqlList.Clear();
            SystemInfo.saveDataToDatabase.dtMJData.Rows.Clear();
            SystemInfo.saveDataToDatabase.dtData.Rows.Clear();
            SystemInfo.saveDataToDatabase.dtPIDData.Rows.Clear();

            SystemInfo.saveDataToDatabase.dtMJData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_MJData where 1=0");  //门禁记录
            SystemInfo.saveDataToDatabase.dtData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_KQData where 1=0");         //考勤记录
            SystemInfo.saveDataToDatabase.dtPIDData = SystemInfo.db.GetDataTable("SELECT * FROM MJ_SeaPersonIDCard where 1=0");     //身份证记录

            if (SystemInfo.saveDataToDatabase.table != null)
                SystemInfo.saveDataToDatabase.table.Clear();
            if (SystemInfo.saveDataToDatabase.tableMJ != null)
                SystemInfo.saveDataToDatabase.tableMJ.Clear();
            if (SystemInfo.saveDataToDatabase.tableRSEmp != null)
                SystemInfo.saveDataToDatabase.tableRSEmp.Clear();
            if (SystemInfo.saveDataToDatabase.tablePID != null)
                SystemInfo.saveDataToDatabase.tablePID.Clear();

            SystemInfo.saveDataToDatabase.table = SystemInfo.db.GetDataTable("SELECT EmpNo,KQDate,KQTime FROM KQ_KQData");

            SystemInfo.saveDataToDatabase.tableMJ = SystemInfo.db.GetDataTable("SELECT [GUID], MacSN,VerifyModeID,KQDate,KQTime FROM KQ_MJData");

            SystemInfo.saveDataToDatabase.tableRSEmp = SystemInfo.db.GetDataTable("SELECT FingerNo,EmpNo,EmpName,DepartID,DepartName FROM VRS_Emp");

            SystemInfo.saveDataToDatabase.tablePID = SystemInfo.db.GetDataTable("SELECT MacSN,KQDateTime FROM MJ_SeaPersonIDCard");


            if (SystemInfo.AllowMJ)
            {
                dtEmpData.Rows.Clear();
                if (tableEmp != null)
                    tableEmp.Clear();
                if (tableTemporaryData != null)
                    tableTemporaryData.Clear();
                tableEmp = SystemInfo.db.GetDataTable("SELECT MJDateTime, EmpNoOne FROM MJ_OpenData");
                dtEmpData = SystemInfo.db.GetDataTable("SELECT * FROM MJ_OpenData where 0=1");
                tableTemporaryData = SystemInfo.db.GetDataTable("SELECT [GUID],MJDateTime,MacSN,EmpNo,EmpName FROM MJ_TemporaryData");
            }


            DataTableReader dr = null;
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "2", MacSN}));
            if(dr.Read())
            {
                int.TryParse(dr["InOutMode"].ToString(),out InOutMode);
                int.TryParse(dr["DevModeID"].ToString(), out DevMode);
            }

            string GUID = "";
            try
            {
                DateTime dateTime = DateTime.Now.AddYears(10);
                string _strWorkingDayAM = "2000-01-01T00:00:00";
                string _strWorkingDayPM = dateTime.ToString("yyyy-MM-dd") + "T23:59:59";

                if (isSelect)
                {
                    _strWorkingDayAM = app.timeStat + "T00:00:00";
                    _strWorkingDayPM = app.timeEnd + "T23:59:59";
                }
                string selurl = url + "action/SearchControlNum";
                SearchControlNum searchControlNum = new SearchControlNum(MacSN, _strWorkingDayAM, _strWorkingDayPM);

                jsonBody<SearchControlNum> jsonBodyNum = new jsonBody<SearchControlNum>("SearchControlNum", searchControlNum);
                string jsonBodyStr = JsonConvert.SerializeObject(jsonBodyNum);
                ret = DeviceObject.objFK623.POST_GetResponse(selurl, name, pwd, ref jsonBodyStr);

                if (!ret)
                {
                    return ret;
                }
               
                jsonBody<GetSearchControlNum> getMachineInfo = JsonConvert.DeserializeObject<jsonBody<GetSearchControlNum>>(jsonBodyStr);
                RecordCount = getMachineInfo.info.ControlNum;
                if (RecordCount == 0)
                {
                    return ret;
                }
                string urlRecord = url + "action/SearchControl";

                SearchControlCmd searchControlCmd = new SearchControlCmd(int.Parse(MacSN), _strWorkingDayAM, _strWorkingDayPM, 0, 100, 0);
                if (SystemInfo.isAttendancePhoto)
                {
                    searchControlCmd.Picture = 2;
                    searchControlCmd.RequestCount = 50;
                }

                jsonBody<SearchControlCmd> jsonBody = new jsonBody<SearchControlCmd>("SearchControl", searchControlCmd);
                RecordIndex = 0;
                int Count = 0;
                int SendCount = 0;
                while (true)
                {
                    jsonBody.info.BeginNO = Count;
                    if (SystemInfo.isAttendancePhoto)
                        Count = Count + 50;
                    else
                        Count = Count + 100;
                    string jsonString = JsonConvert.SerializeObject(jsonBody);
                    EE:
                    ret = DeviceObject.objFK623.POST_GetResponse(urlRecord, name, pwd, ref jsonString);

                    if (!ret)
                    {
                        ret = true;
                        FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                        break;
                    }
                    jsonBody<SearchControl<SearchInfo>> dataInfo = JsonConvert.DeserializeObject<jsonBody<SearchControl<SearchInfo>>>(jsonString);
                   
                    if (dataInfo.info.TotalNum == 0)
                    {
                        SendCount++;
                        if (SendCount >= 3)
                        {
                            FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                            break;
                        }
                        else
                            goto EE;
                    }

                    byte[] PhotoImage = null;

                    for (int i = 0; i < dataInfo.info.TotalNum; i++)
                    {
                        if (dataInfo.info.SearchInfo[i].CustomizeID < 0) dataInfo.info.SearchInfo[i].CustomizeID = 0;
                        UInt32 FingerNo = (UInt32)dataInfo.info.SearchInfo[i].CustomizeID;
                        attLog = new TFingerLog();
                        attLog.CardID = FingerNo.ToString("0000000000");
                        attLog.CardTime = DateTime.Parse(dataInfo.info.SearchInfo[i].Time);
                        attLog.FingerNo = FingerNo;
                        attLog.InOutMode = InOutMode;
                        attLog.Temperature = dataInfo.info.SearchInfo[i].Temperature;
                        attLog.TemperatureAlarm = dataInfo.info.SearchInfo[i].TemperatureAlarm;

                        PhotoImage = null;
                        if (dataInfo.info.SearchInfo[i].SnapPicinfo != null)
                        {
                            PhotoStr = dataInfo.info.SearchInfo[i].SnapPicinfo.Replace("data:image/jpeg;base64,", "");
                            if (PhotoStr.Length > 0)
                            {
                                PhotoImage = Convert.FromBase64String(PhotoStr);
                            }
                        }
                     
                        VerifyType = dataInfo.info.SearchInfo[i].VerfyType;
                        VerifyStatus = dataInfo.info.SearchInfo[i].VerifyStatus;
                       
                        Sea_SetLogName(attLog, InOutMode, VerifyStatus, VerifyType);

                        if(attLog.VerifyMode==2||attLog.VerifyMode==3)
                        {
                            pidLog.Name = dataInfo.info.SearchInfo[i].Name;
                            pidLog.Time = DateTime.Parse(dataInfo.info.SearchInfo[i].Time);
                            pidLog.MacSN = MacSN;
                            if (dataInfo.info.SearchInfo[i].Gender == 0)
                            {
                                pidLog.Gender = Pub.GetResText("Public", "EmpSex0", "");
                            }
                            else if (dataInfo.info.SearchInfo[i].Gender == 1)
                            {
                                pidLog.Gender = Pub.GetResText("Public", "EmpSex1", "");
                            }
                            else
                            {
                                pidLog.Gender = "";
                            }
                            pidLog.Birthday = DateTime.Parse(dataInfo.info.SearchInfo[i].Birthday);
                            pidLog.CardType = Pub.GetResText("Public", "LOG_IDCARD", "");
                            pidLog.EmpCertNo = dataInfo.info.SearchInfo[i].IdCard;
                            pidLog.EmpAddress = dataInfo.info.SearchInfo[i].Address;
                            pidLog.InOutMode = attLog.InOutMode;
                            pidLog.InOutModeName = attLog.InOutModeName;
                            pidLog.Temperature = dataInfo.info.SearchInfo[i].Temperature;
                            pidLog.TemperatureAlarm = dataInfo.info.SearchInfo[i].TemperatureAlarm;
                            pidLog.Nation = Sea_GetNation(dataInfo.info.SearchInfo[i].Nation);

                            batchSavePID(pidLog, ref GUID);//人证记录表
                            if (GUID != "" && PhotoImage != null)
                            {
                                SavePIDPhoto(GUID, PhotoImage);
                            }
                        }

                        WriteTextFile(attLog, MacSN);
                        if (textFormat.Allow) WriteTextFormat(textFormat, attLog, MacSN);
                        if (DevMode == 0 || DevMode == 1)
                        {
                            batchSaveDB(attLog, MacSN, true, ref GUID);//批量插入数据库  考勤原始记录表
                            if (GUID != "" && PhotoImage != null)
                            {
                                SaveDBPhoto(GUID, PhotoImage);
                            }
                        }
                        if (attLog.VerifyMode == 0 || (attLog.VerifyMode != 2 && attLog.VerifyMode != 3))
                        {
                            attLog.VerifyMode = attLog.DoorMode;
                            attLog.VerifyModeName = attLog.DoorModeName;
                        }
                        WriteTextFileMJ(attLog, MacSN);
                        if (DevMode == 0 || DevMode == 2)
                        {
                            batchSaveDBMJ(attLog, MacSN, true, ref GUID);//批量插入数据库 门禁表
                            if (GUID != "" && PhotoImage != null)
                            {
                                SaveDBPhotoMJ(GUID, PhotoImage);
                            }
                        }

                        RecordIndex = RecordIndex + 1;
                        if (prog != null) prog(RecordCount, RecordIndex, MacSN, attLog, GUID, false);
                        if (SystemInfo.AllowMJ)
                            ManyMJDate(MacSN, attLog, GUID);//人员开门记录表
                    }
                }

                //批量插入数据到数据库
                if (dtEmpData.Rows.Count > 0)
                {
                    SystemInfo.db.batchSeveData(dtEmpData, "MJ_OpenData");
                }
                if (SystemInfo.saveDataToDatabase.dtData.Rows.Count > 0)
                {
                    SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtData, "KQ_KQData");
                }
                if (SystemInfo.saveDataToDatabase.dtMJData.Rows.Count > 0)
                {
                    SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtMJData, "KQ_MJData");
                }
                if (SystemInfo.saveDataToDatabase.dtPIDData.Rows.Count > 0)
                {
                    SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtPIDData, "MJ_SeaPersonIDCard");
                }

                if (SystemInfo.AllowMJ)
                {
                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "709" }));
                    for (int i = 0; i < tableTemporaryData.Rows.Count; i++)
                    {

                        string EmpNo = tableTemporaryData.Rows[i]["EmpNo"].ToString();
                        string EmpName = tableTemporaryData.Rows[i]["EmpName"].ToString();
                        string guid = tableTemporaryData.Rows[i]["GUID"].ToString();
                        string MJDateTime = tableTemporaryData.Rows[i]["MJDateTime"].ToString();
                        if (MJDateTime != "")
                        {
                            MJDateTime = Convert.ToDateTime(MJDateTime).ToString(SystemInfo.SQLDateTimeFMT);
                        }
                        sqlList.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "708",guid,
                            MJDateTime, MacSN, EmpNo, EmpName }));
                    }
                    tableTemporaryData.Clear();
                    dtEmpData.Rows.Clear();
                    tableEmp = null;
                }

                if (sqlList.Count > 0)
                    SystemInfo.db.ExecSQL(sqlList, prog);
            }
            catch (Exception ex)
            {
                Pub.ShowErrorMsg(ex);
            }
            finally
            {
                SystemInfo.saveDataToDatabase.dtData.Rows.Clear();
                SystemInfo.saveDataToDatabase.dtMJData.Rows.Clear();
                SystemInfo.saveDataToDatabase.dtPIDData.Rows.Clear();
                SystemInfo.saveDataToDatabase.table = null;
                SystemInfo.saveDataToDatabase.tableMJ = null;
                SystemInfo.saveDataToDatabase.tablePID = null;
                SystemInfo.saveDataToDatabase.tableRSEmp.Clear();
            }
            return ret;
        }

        #region 获取民族
        public string Sea_GetNation(int Nation)
        {
            string ret = "";
            switch (Nation)
            {
                case 1:
                    ret = "汉";
                    break;
                case 2:
                    ret = "蒙古";
                    break;
                case 3:
                    ret = "回";
                    break;
                case 4:
                    ret = "藏";
                    break;
                case 5:
                    ret = "维吾尔";
                    break;
                case 6:
                    ret = "苗";
                    break;
                case 7:
                    ret = "彝";
                    break;
                case 8:
                    ret = "壮";
                    break;
                case 9:
                    ret = "布依";
                    break;
                case 10:
                    ret = "朝鲜";
                    break;
                case 11:
                    ret = "满";
                    break;
                case 12:
                    ret = "侗";
                    break;
                case 13:
                    ret = "瑶";
                    break;
                case 14:
                    ret = "白";
                    break;
                case 15:
                    ret = "土家";
                    break;
                case 16:
                    ret = "哈尼";
                    break;
                case 17:
                    ret = "哈萨克";
                    break;
                case 18:
                    ret = "傣";
                    break;
                case 19:
                    ret = "黎";
                    break;
                case 20:
                    ret = "傈僳";
                    break;
                case 21:
                    ret = "佤";
                    break;
                case 22:
                    ret = "畲";
                    break;
                case 23:
                    ret = "高山";
                    break;
                case 24:
                    ret = "拉祜";
                    break;
                case 25:
                    ret = "水";
                    break;
                case 26:
                    ret = "东乡";
                    break;
                case 27:
                    ret = "纳西";
                    break;
                case 28:
                    ret = "景颇";
                    break;
                case 29:
                    ret = "柯尔克孜";
                    break;
                case 30:
                    ret = "土";
                    break;
                case 31:
                    ret = "达斡尔";
                    break;
                case 32:
                    ret = "仫佬";
                    break;
                case 33:
                    ret = "羌";
                    break;
                case 34:
                    ret = "布朗";
                    break;
                case 35:
                    ret = "撒拉";
                    break;
                case 36:
                    ret = "毛南";
                    break;
                case 37:
                    ret = "仡佬";
                    break;
                case 38:
                    ret = "锡伯";
                    break;
                case 39:
                    ret = "阿昌";
                    break;
                case 40:
                    ret = "普米";
                    break;
                case 41:
                    ret = "塔吉克";
                    break;
                case 42:
                    ret = "怒";
                    break;
                case 43:
                    ret = "乌孜别克";
                    break;
                case 44:
                    ret = "俄罗斯";
                    break;
                case 45:
                    ret = "鄂温克";
                    break;
                case 46:
                    ret = "德昂";
                    break;
                case 47:
                    ret = "保安";
                    break;
                case 48:
                    ret = "裕固";
                    break;
                case 49:
                    ret = "京";
                    break;
                case 50:
                    ret = "塔塔尔";
                    break;
                case 51:
                    ret = "独龙";
                    break;
                case 52:
                    ret = "鄂伦春";
                    break;
                case 53:
                    ret = "赫哲";
                    break;
                case 54:
                    ret = "门巴";
                    break;
                case 55:
                    ret = "珞巴";
                    break;
                case 56:
                    ret = "基诺";
                    break;
                default:
                    ret = "其他";
                    break;
            }
            return ret;
        }
        #endregion

        public bool FK623ReadDataUSB(string usbFile, KQTextFormatInfo textFormat, ref int RecordCount,
          ref int RecordIndex, ProcessReadData prog)
        {
            RecordCount = 0;
            RecordIndex = 0;
            int DevMode = 0;
            List<string> sqlList = new List<string>();

            SystemInfo.saveDataToDatabase.dtMJData.Rows.Clear();
            SystemInfo.saveDataToDatabase.dtData.Rows.Clear();

            SystemInfo.saveDataToDatabase.dtMJData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_MJData where 1=0");
            SystemInfo.saveDataToDatabase.dtData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_KQData where 1=0");

            if (SystemInfo.saveDataToDatabase.table != null)
                SystemInfo.saveDataToDatabase.table.Clear();
            if (SystemInfo.saveDataToDatabase.tableMJ != null)
                SystemInfo.saveDataToDatabase.tableMJ.Clear();
            if (SystemInfo.saveDataToDatabase.tableRSEmp != null)
                SystemInfo.saveDataToDatabase.tableRSEmp.Clear();

            SystemInfo.saveDataToDatabase.table = SystemInfo.db.GetDataTable("SELECT EmpNo,KQDate,KQTime FROM KQ_KQData");
            
            SystemInfo.saveDataToDatabase.tableMJ = SystemInfo.db.GetDataTable("SELECT [GUID], MacSN,VerifyModeID,KQDate,KQTime FROM KQ_MJData");

            SystemInfo.saveDataToDatabase.tableRSEmp = SystemInfo.db.GetDataTable("SELECT FingerNo,EmpNo,EmpName,DepartID,DepartName FROM VRS_Emp");

            if (SystemInfo.AllowMJ)
            {
                dtEmpData.Rows.Clear();
                if (tableEmp != null)
                    tableEmp.Clear();
                if (tableTemporaryData != null)
                    tableTemporaryData.Clear();
                tableEmp = SystemInfo.db.GetDataTable("SELECT MJDateTime, EmpNoOne FROM MJ_OpenData");
                dtEmpData = SystemInfo.db.GetDataTable("SELECT * FROM MJ_OpenData where 0=1");
                tableTemporaryData = SystemInfo.db.GetDataTable("SELECT [GUID],MJDateTime,MacSN,EmpNo,EmpName FROM MJ_TemporaryData");
            }

         

            bool ret = false;
            string MacSN = "0";
            #region Get MacSN From USBFile
            try
            {
                string[] MacSNFromUsbFile = Path.GetFileNameWithoutExtension(usbFile).Split('_');
                if (MacSNFromUsbFile.Length == 1 && MacSNFromUsbFile[0].Length == 6)
                {
                    if (MacSNFromUsbFile[0].Contains("agl") || MacSNFromUsbFile[0].Contains("glg"))
                    {
                        string str = MacSNFromUsbFile[0].Substring(3, 3);
                        MacSN = int.Parse(str).ToString();
                    }
                }
                if (MacSNFromUsbFile.Length == 2 && !string.IsNullOrEmpty(MacSNFromUsbFile[1]))
                {
                    string str = MacSNFromUsbFile[1];
                    MacSN = int.Parse(str).ToString();
                }
            }
            catch (Exception)
            {
            }
            #endregion

            //获取设备模式
            DataTableReader dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "2", MacSN }));
            if (dr.Read())
            {
                Int32.TryParse(dr["DevModeID"].ToString(), out DevMode);
            }
            dr.Close();

            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.USBLoadGeneralLogDataFromFile(usbFile);
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (!ret) return ret;
            UInt32 EnrollNumber = 0;
            int VerifyMode = 0;
            int InOutMode = 0;
            string GUID = "";
            DateTime dwDate = new DateTime();
            do
            {
                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetGeneralLogData(ref EnrollNumber, ref VerifyMode,
                  ref InOutMode, ref dwDate);
                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                {
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    break;
                }
                attLog = new TFingerLog();
            
                attLog.CardID = EnrollNumber.ToString("0000000000");
                attLog.CardTime = dwDate;
                attLog.FingerNo = EnrollNumber;
                attLog.VerifyMode = VerifyMode;
                attLog.InOutMode = InOutMode;
                SetLogName(attLog);
                bool IsKQ = IsKQData(attLog);
                if (IsKQ)
                {
                    WriteTextFile(attLog, MacSN);
                    if (textFormat.Allow) WriteTextFormat(textFormat, attLog, MacSN);
                    if(DevMode == 0 || DevMode == 1)
                    {
                        batchSaveDB(attLog, MacSN, true, ref GUID);
                        if (SystemInfo.isAttendancePhoto && GUID != "")
                        {
                            SaveDBPhoto(GUID, Pub.GetFileNamePath(usbFile) + "AttendLog\\" +
                              dwDate.ToString("yyyy_MM_dd") + "\\LF" + EnrollNumber.ToString("0000000000") +
                              dwDate.ToString("_HH_mm_ss") + ".jpg");
                            //SaveDBPhoto(GUID, Pub.GetFileNamePath(usbFile) + "AttendLog\\LF00001580.jpg");  
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
                    WriteTextFileMJ(attLog, MacSN);
                    if (DevMode == 0 || DevMode == 2)
                    {
                        batchSaveDBMJ(attLog, MacSN, true, ref GUID);
                        if (SystemInfo.isAttendancePhoto || GUID != "")
                        {
                            SaveDBPhotoMJ(GUID, Pub.GetFileNamePath(usbFile) + "AttendLog\\" +
                              dwDate.ToString("yyyy_MM_dd") + "\\LF" + EnrollNumber.ToString("0000000000") +
                              dwDate.ToString("_HH_mm_ss") + ".jpg");
                        }
                    }
                   
                    
                }
                if (IsKQ && attLog.DoorMode > 0)
                {
                    attLog.VerifyMode = attLog.DoorMode;
                    attLog.VerifyModeName = attLog.DoorModeName;
                    if (DevMode == 0 || DevMode == 2)
                    {
                        batchSaveDBMJ(attLog, MacSN, true, ref GUID);
                        if (SystemInfo.isAttendancePhoto || GUID != "")
                        {
                            SaveDBPhotoMJ(GUID, Pub.GetFileNamePath(usbFile) + "AttendLog\\" +
                              dwDate.ToString("yyyy_MM_dd") + "\\LF" + EnrollNumber.ToString("0000000000") +
                              dwDate.ToString("_HH_mm_ss") + ".jpg");
                        }
                    }
                }
                RecordIndex = RecordIndex + 1;
                RecordCount = RecordIndex;
                if (prog != null) prog(RecordCount, RecordIndex, MacSN, attLog, GUID, false);
                if (SystemInfo.AllowMJ)
                    ManyMJDate(MacSN, attLog, GUID);
            }
            while (true);

            if (dtEmpData.Rows.Count > 0)
            {
                SystemInfo.db.batchSeveData(dtEmpData, "MJ_OpenData");
            }
            if (SystemInfo.saveDataToDatabase.dtData.Rows.Count > 0)
            {
                SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtData, "KQ_KQData");
            }
            if (SystemInfo.saveDataToDatabase.dtMJData.Rows.Count > 0)
            {
                SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtMJData, "KQ_MJData");
            }

            SystemInfo.saveDataToDatabase.dtData.Rows.Clear();
            SystemInfo.saveDataToDatabase.dtMJData.Rows.Clear();

            SystemInfo.saveDataToDatabase.table = null;
            SystemInfo.saveDataToDatabase.tableMJ = null;
            SystemInfo.saveDataToDatabase.tableRSEmp.Clear();

            sqlList.Clear();
            if (SystemInfo.AllowMJ)
            {
                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "709" }));
                for (int i = 0; i < tableTemporaryData.Rows.Count; i++)
                {
                    string EmpNo = tableTemporaryData.Rows[i]["EmpNo"].ToString();
                    string EmpName = tableTemporaryData.Rows[i]["EmpName"].ToString();
                    string guid = tableTemporaryData.Rows[i]["GUID"].ToString();
                    string MJDateTime = tableTemporaryData.Rows[i]["MJDateTime"].ToString();
                    sqlList.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "708",guid,
                            MJDateTime, MacSN, EmpNo, EmpName }));
                }
                if (sqlList.Count > 0)
                    SystemInfo.db.ExecSQL(sqlList, prog);

                tableTemporaryData.Clear();
                dtEmpData.Rows.Clear();
                tableEmp = null;
            }

            return ret;
        }

        public bool ReadDataText(string textFile, KQTextFormatInfo textFormat, ref int RecordCount,
          ref int RecordIndex, ProcessReadData prog)
        {
            bool ret = false;
            RecordCount = 0;
            RecordIndex = 0;

            List<string> sqlList = new List<string>();
            SystemInfo.sqlList.Clear();
            SystemInfo.saveDataToDatabase.dtData.Rows.Clear();

            if (SystemInfo.saveDataToDatabase.table != null)
                SystemInfo.saveDataToDatabase.table.Clear();

            SystemInfo.saveDataToDatabase.table = SystemInfo.db.GetDataTable("SELECT EmpNo,KQDate,KQTime FROM KQ_KQData");

            SystemInfo.saveDataToDatabase.dtData = SystemInfo.db.GetDataTable("SELECT * FROM KQ_KQData where 1=0");

            if (SystemInfo.saveDataToDatabase.tableRSEmp != null)
                SystemInfo.saveDataToDatabase.tableRSEmp.Clear();
            SystemInfo.saveDataToDatabase.tableRSEmp = SystemInfo.db.GetDataTable("SELECT FingerNo,EmpNo,EmpName,DepartID,DepartName FROM VRS_Emp");

            StreamReader sr = null;
            string line;
            string MacSN = "0";
            string GUID = "";
            try
            {
                sr = new StreamReader(textFile);
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line.Length >= 32)
                    {
                        attLog = new TFingerLog();
                        attLog.ReadMark = Convert.ToByte(line.Substring(0, 2));
                        attLog.CardID = line.Substring(2, 10);
                        attLog.CardTime = new DateTime(Convert.ToInt16(line.Substring(12, 4)),
                          Convert.ToByte(line.Substring(16, 2)), Convert.ToByte(line.Substring(18, 2)),
                          Convert.ToByte(line.Substring(20, 2)), Convert.ToByte(line.Substring(22, 2)),
                          Convert.ToByte(line.Substring(24, 2)));
                        if (line.Length == 31)
                            MacSN = line.Substring(26, 5);
                        else if (line.Length == 41)
                        {
                            MacSN = line.Substring(26, 5);
                            attLog.VerifyMode = Convert.ToInt32(line.Substring(31, 5));
                            attLog.InOutMode = Convert.ToInt32(line.Substring(36, 5));
                            SetLogName(attLog);
                        }
                        else if (line.Length == 68)
                        {
                            MacSN = line.Substring(26, 32);
                            attLog.VerifyMode = Convert.ToInt32(line.Substring(58, 5));
                            attLog.InOutMode = Convert.ToInt32(line.Substring(63, 5));
                            SetLogName(attLog);
                        }
                        attLog.FingerNo = Convert.ToUInt32(attLog.CardID);
                        //SaveDB(attLog, MacSN, false, ref GUID);
                        batchSaveDB(attLog, MacSN, true, ref GUID);
                        RecordIndex = RecordIndex + 1;
                        RecordCount = RecordIndex;
                        if (prog != null) prog(RecordCount, RecordIndex, MacSN, attLog, GUID, false);
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
                if (sr != null) sr.Close();
            }
            if (SystemInfo.saveDataToDatabase.dtData.Rows.Count > 0)
            {
                SystemInfo.db.batchSeveData(SystemInfo.saveDataToDatabase.dtData, "KQ_KQData");
            }

            SystemInfo.saveDataToDatabase.dtData.Rows.Clear();
            SystemInfo.saveDataToDatabase.table = null;
            SystemInfo.saveDataToDatabase.tableRSEmp.Clear();
            return ret;
        }

        public void WriteTextFile(TFingerLog attLog, string MacSN)
        {
            DateTime t = attLog.CardTime;
            string fileName = SystemInfo.DataFilePath + "KQF" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            while (MacSN.Length < 32) MacSN = " " + MacSN;
            string msg = attLog.ReadMark.ToString("00") + attLog.CardID + t.ToString(TextFMT) +
              MacSN + attLog.VerifyMode.ToString("00000") + attLog.InOutMode.ToString("00000");
            Pub.WriteTextFile(fileName, msg);
        }

        public void WriteTextFileMJ(TFingerLog attLog, string MacSN)
        {
            DateTime t = attLog.CardTime;
            string fileName = SystemInfo.DataFilePath + "MJF" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            while (MacSN.Length < 32) MacSN = " " + MacSN;
            string msg = t.ToString(TextFMT) + MacSN + attLog.VerifyMode.ToString("00000") +
              attLog.InOutMode.ToString("00000");
            Pub.WriteTextFile(fileName, msg);
        }

        public void WriteTextFormat(KQTextFormatInfo textFormat, TFingerLog attLog, string MacSN)
        {
            DataTableReader dr = null;
            string EmpNo = "";
            string EmpName = "";
            bool IsError = false;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "21", attLog.CardID }));
                if (dr.Read())
                {
                    EmpNo = dr["EmpNo"].ToString();
                    EmpName = dr["EmpName"].ToString();
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
            string fileName = SystemInfo.DataFilePath + "KQF" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + "_Format.txt";
            string msg = textFormat.GetKQFormatText(MacSN, EmpNo, EmpName, attLog.CardID,
              Convert.ToDateTime(attLog.CardTime));
            Pub.WriteTextFile(fileName, msg);
        }

        public bool SaveDB(TFingerLog attLog, string MacSN)
        {
            string GUID = "";
            return SaveDB(attLog, MacSN, ref GUID);
        }

        public bool SaveDB(TFingerLog attLog, string MacSN, ref string GUID)
        {
            return SaveDB(attLog, MacSN, true, ref GUID);
        }

        public void SetInOutModeName(int InOutMode, ref string InOutModeName)
        {
            DataTableReader dr = null;
            string sql = "";
            if (SystemInfo.AllowInOutMode)
            {
                sql = Pub.GetSQL(DBCode.DB_000400, new string[] { "100", InOutMode.ToString() });
                try
                {
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (dr.Read()) InOutModeName = dr["InOutModeName"].ToString();
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E, sql);
                }
                finally
                {
                    if (dr != null) dr.Close();
                    dr = null;
                }
            }
        }

        public bool SaveDB(TFingerLog attLog, string MacSN, bool ReqConnectDB, ref string GUID)
        {
            bool ret = false;
            string InOutModeName = attLog.InOutModeName;
            SetInOutModeName(attLog.InOutMode, ref InOutModeName);
            GUID = "";
            DateTime t = attLog.CardTime;
            int KQTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;
            DataTableReader dr = null;
            if (SystemInfo.DBType == 0)
            {
                ret = SystemInfo.objACKQ.PKQ_KQDataSave(4, attLog.CardID, t, MacSN, attLog.Remark, attLog.VerifyMode,
          attLog.VerifyModeName, attLog.InOutMode, InOutModeName,attLog.Temperature.ToString(),attLog.TemperatureAlarm, ref GUID);
            }
            else
            {
                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "106", "4", attLog.CardID,
          t.ToString(SystemInfo.SQLDateFMT), KQTime.ToString(), MacSN, OprtInfo.OprtNo, attLog.Remark,
          attLog.VerifyMode.ToString(), attLog.VerifyModeName, attLog.InOutMode.ToString(), InOutModeName,attLog.Temperature.ToString(),attLog.TemperatureAlarm.ToString() });
                try
                {
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (dr.Read()) GUID = dr[0].ToString().Trim();
                    ret = GUID != "";
                }
                catch (Exception E)
                {
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

        public bool batchSaveDB(TFingerLog attLog, string MacSN, bool ReqConnectDB, ref string GUID)
        {
            bool ret = false;
            string InOutModeName = attLog.InOutModeName;
            SetInOutModeName(attLog.InOutMode, ref InOutModeName);
            GUID = "";
            DateTime t = attLog.CardTime;
            int KQTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;
           
            ret = SystemInfo.saveDataToDatabase.PKQ_KQDataSave(4, attLog.CardID, t, MacSN, attLog.Remark, attLog.VerifyMode,
                 attLog.VerifyModeName, attLog.InOutMode, InOutModeName, attLog.Temperature.ToString(), attLog.TemperatureAlarm, ref GUID);
          
            return ret;
        }

        public void SaveDBPhoto(string GUID, byte[] phData)
        {
            SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000300, new string[] { "108", GUID }), "Photo", phData);
        }

        public void SaveDBPhoto(string GUID, string fileName)
        {
            if (File.Exists(fileName))
            {
                Image img = Image.FromFile(fileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                int bufLen = (int)ms.Length;
                byte[] buff = new byte[bufLen];
                ms.Position = 0;
                ms.Read(buff, 0, bufLen);
               
                SaveDBPhoto(GUID, buff);
                
                buff = null;
                ms.Dispose();
                img.Dispose();
            }
        }

        public bool SaveDBMJ(TFingerLog attLog, string MacSN)
        {
            string GUID = "";
            return SaveDBMJ(attLog, MacSN, ref GUID);
        }

        public bool SaveDBMJ(TFingerLog attLog, string MacSN, ref string GUID)
        {
            return SaveDBMJ(attLog, MacSN, true, ref GUID);
        }

        public bool SaveDBMJ(TFingerLog attLog, string MacSN, bool ReqConnectDB, ref string GUID)
        {
            bool ret = false;
            GUID = "";
            DateTime t = attLog.CardTime;
            int KQTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;
            string Temperature = "";

            if (attLog.Temperature>0)
            {
                Temperature = attLog.Temperature.ToString();
            }

            if (SystemInfo.DBType == 0)
            {
                ret = SystemInfo.objACKQ.PKQ_MJDataSave(4,t, MacSN, attLog.Remark, attLog.VerifyMode, attLog.VerifyModeName,
           attLog.InOutMode, attLog.InOutModeName, attLog.CardID, attLog.DoorStauts, attLog.Bell, Temperature, attLog.TemperatureAlarm, ref GUID);
            }
            else
            {
                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "111", t.ToString(SystemInfo.SQLDateFMT),
          KQTime.ToString(), MacSN, OprtInfo.OprtNo, attLog.Remark, attLog.VerifyMode.ToString(),
          attLog.VerifyModeName, attLog.InOutMode.ToString(), attLog.InOutModeName,attLog.CardID.ToString(),attLog.DoorStauts,
          Convert.ToByte(attLog.Bell).ToString(),Temperature,attLog.TemperatureAlarm.ToString()});
                DataTableReader dr = null;
                try
                {
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (dr.Read()) GUID = dr[0].ToString().Trim();
                    ret = GUID != "";
                }
                catch (Exception E)
                {
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

        public bool batchSaveDBMJ(TFingerLog attLog, string MacSN, bool ReqConnectDB, ref string GUID)
        {
            bool ret = false;
            GUID = "";
            DateTime t = attLog.CardTime;
            int KQTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;

            ret = SystemInfo.saveDataToDatabase.PKQ_MJDataSave(4,t, MacSN, attLog.Remark, attLog.VerifyMode, attLog.VerifyModeName,
                attLog.InOutMode, attLog.InOutModeName, attLog.CardID, attLog.DoorStauts, attLog.Bell,attLog.Temperature.ToString(),attLog.TemperatureAlarm, ref GUID);

            return ret;
        }

        public void SaveDBPhotoMJ(string GUID, byte[] phData)
        {
            SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000300, new string[] { "112", GUID }), "Photo", phData);
        }

        public bool batchSavePID(PIDLog pidLog, ref string GUID)
        {
            bool ret = false;
            GUID = "";

            ret = SystemInfo.saveDataToDatabase.PKQ_PIDDataSave( pidLog.Name, pidLog.Time, pidLog.MacSN, pidLog.Gender, pidLog.Birthday, pidLog.CardType,
                pidLog.EmpCertNo, pidLog.EmpAddress,pidLog.InOutMode,pidLog.InOutModeName, pidLog.Temperature.ToString(), pidLog.TemperatureAlarm,pidLog.Nation,  ref GUID);

            return ret;
        }

        public bool SavePID(PIDLog pidLog, ref string GUID)
        {
            bool ret = false;
            GUID = "";

            ret = SystemInfo.db.SavePIDLog(pidLog, ref GUID);//人证记录表;
            return ret;
        }

        public void SavePIDPhoto(string GUID, byte[] phData)
        {
            SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000300, new string[] { "114", GUID }), "Photo", phData);
        }

        public void SaveDBPhotoMJ(string GUID, string fileName)
        {
            if (File.Exists(fileName))
            {
                Image img = Image.FromFile(fileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                int bufLen = (int)ms.Length;
                byte[] buff = new byte[bufLen];
                ms.Position = 0;
                ms.Read(buff, 0, bufLen);
              
                SaveDBPhotoMJ(GUID, buff);
           
                buff = null;
                ms.Dispose();
                img.Dispose();
            }
        }

        public bool SaveDBSLog(string MacSN, UInt32 SEnrollNo, UInt32 GEnrollNo, int Manipulation, int BakNo, DateTime dwDate)
        {
            bool ret = false;
            string ManipulationName = "--";
            switch (Manipulation)
            {
                case (int)FKSLog.LOG_ENROLL_USER:
                    ManipulationName = "Enroll User";
                    break;
                case (int)FKSLog.LOG_ENROLL_MANAGER:
                    ManipulationName = "Enroll Manager";
                    break;
                case (int)FKSLog.LOG_ENROLL_DELFP:
                    ManipulationName = "Delete Fp Data";
                    break;
                case (int)FKSLog.LOG_ENROLL_DELPASS:
                    ManipulationName = "Delete Password";
                    break;
                case (int)FKSLog.LOG_ENROLL_DELCARD:
                    ManipulationName = "Delete Card Data";
                    break;
                case (int)FKSLog.LOG_LOG_ALLDEL:
                    ManipulationName = "Delete All LogData";
                    break;
                case (int)FKSLog.LOG_SETUP_SYS:
                    ManipulationName = "Modify System Info";
                    break;
                case (int)FKSLog.LOG_SETUP_TIME:
                    ManipulationName = "Modify System Time";
                    break;
                case (int)FKSLog.LOG_SETUP_LOG:
                    ManipulationName = "Modify Log Setting";
                    break;
                case (int)FKSLog.LOG_SETUP_COMM:
                    ManipulationName = "Modify Comm Setting";
                    break;
                case (int)FKSLog.LOG_PASSTIME:
                    ManipulationName = "Pass Time Set";
                    break;
                case (int)FKSLog.LOG_SETUP_DOOR:
                    ManipulationName = "Door Set Log";
                    break;
            }
            string BakName = "--";
            switch (BakNo)
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
                    BakName = "Fp-" + BakNo.ToString();
                    break;
                case (int)FKBackup.BACKUP_PSW:
                    BakName = "Password";
                    break;
                case (int)FKBackup.BACKUP_CARD:
                    BakName = "Card";
                    break;
                case (int)FKBackup.BACKUP_FACE:
                    BakName = "Face";
                    break;
                case (int)FKBackup.BACKUP_PALMVEIN_0:
                case (int)FKBackup.BACKUP_PALMVEIN_1:
                case (int)FKBackup.BACKUP_PALMVEIN_2:
                case (int)FKBackup.BACKUP_PALMVEIN_3:
                    BakName = "PalmVein";
                    break;
            }
            if (SystemInfo.DBType == 0)
            {
                ret = SystemInfo.objACKQ.PKQ_KQSLogSave(MacSN, SEnrollNo, GEnrollNo, Manipulation, ManipulationName,
                  BakNo, BakName, dwDate.ToString(SystemInfo.SQLDateTimeFMT));
            }
            else
            {
                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "113", MacSN, SEnrollNo.ToString(),
        GEnrollNo.ToString(), Manipulation.ToString(), ManipulationName, BakNo.ToString(), BakName,
        dwDate.ToString(SystemInfo.SQLDateTimeFMT), OprtInfo.OprtNo });
                try
                {
                    SystemInfo.db.ExecSQL(sql);
                    ret = true;
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E, sql);
                }
            }
            string fileName = SystemInfo.DataFilePath + "KQ_SLOG" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            string sep = "\t";
            string msg = SEnrollNo.ToString() + sep + SEnrollNo.ToString() + sep + Manipulation.ToString() +
              sep + BakNo.ToString() + sep + dwDate.ToString() + sep + MacSN;
            Pub.WriteTextFile(fileName, msg);
            return ret;
        }
    }

    public class MJPassTime
    {
        private Base Pub = new Base();
        private const int count = (int)FKMax.MAX_PASSCTRLGROUP_COUNT;
        private bool _exists = false;
        private string[] _T1S = new string[count];
        private string[] _T1E = new string[count];
        private string[] _T2S = new string[count];
        private string[] _T2E = new string[count];
        private string[] _T3S = new string[count];
        private string[] _T3E = new string[count];
        private string[] _T4S = new string[count];
        private string[] _T4E = new string[count];
        private string[] _T5S = new string[count];
        private string[] _T5E = new string[count];
        private string[] _T6S = new string[count];
        private string[] _T6E = new string[count];
        private string[] _T7S = new string[count];
        private string[] _T7E = new string[count];
        private int _TimeSize = 0;
        private byte[] _PassTime;

        public MJPassTime(string Src)
        {
            _exists = false;
            string[] tmp = Src.Split('@');
            if (tmp.Length == 14)
            {
                string[] s1 = tmp[0].Split('#');
                string[] s2 = tmp[1].Split('#');
                string[] s3 = tmp[2].Split('#');
                string[] s4 = tmp[3].Split('#');
                string[] s5 = tmp[4].Split('#');
                string[] s6 = tmp[5].Split('#');
                string[] s7 = tmp[6].Split('#');
                string[] s8 = tmp[7].Split('#');
                string[] s9 = tmp[8].Split('#');
                string[] s10 = tmp[9].Split('#');
                string[] s11 = tmp[10].Split('#');
                string[] s12 = tmp[11].Split('#');
                string[] s13 = tmp[12].Split('#');
                string[] s14 = tmp[13].Split('#');
                if (s1.Length == count && s2.Length == count && s3.Length == count && s4.Length == count &&
                  s5.Length == count && s6.Length == count && s7.Length == count && s8.Length == count &&
                  s9.Length == count && s10.Length == count && s11.Length == count && s12.Length == count &&
                  s13.Length == count && s14.Length == count)
                {
                    _TimeSize = Marshal.SizeOf(typeof(PassCtrlTimeAll));
                    _PassTime = new byte[_TimeSize];
                    PassCtrlTimeAll pct = new PassCtrlTimeAll();
                    pct.Init();
                    for (int i = 0; i < count; i++)
                    {
                        _T1S[i] = Pub.ValidatTime(s1[i]);
                        _T1E[i] = Pub.ValidatTime(s2[i]);
                        _T2S[i] = Pub.ValidatTime(s3[i]);
                        _T2E[i] = Pub.ValidatTime(s4[i]);
                        _T3S[i] = Pub.ValidatTime(s5[i]);
                        _T3E[i] = Pub.ValidatTime(s6[i]);
                        _T4S[i] = Pub.ValidatTime(s7[i]);
                        _T4E[i] = Pub.ValidatTime(s8[i]);
                        _T5S[i] = Pub.ValidatTime(s9[i]);
                        _T5E[i] = Pub.ValidatTime(s10[i]);
                        _T6S[i] = Pub.ValidatTime(s11[i]);
                        _T6E[i] = Pub.ValidatTime(s12[i]);
                        _T7S[i] = Pub.ValidatTime(s13[i]);
                        _T7E[i] = Pub.ValidatTime(s14[i]);
                        pct.mPassCtrlTime[i].mPassTime[0].StartHour = Convert.ToByte(_T1S[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[0].StartMinute = Convert.ToByte(_T1S[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[0].EndHour = Convert.ToByte(_T1E[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[0].EndMinute = Convert.ToByte(_T1E[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[1].StartHour = Convert.ToByte(_T2S[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[1].StartMinute = Convert.ToByte(_T2S[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[1].EndHour = Convert.ToByte(_T2E[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[1].EndMinute = Convert.ToByte(_T2E[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[2].StartHour = Convert.ToByte(_T3S[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[2].StartMinute = Convert.ToByte(_T3S[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[2].EndHour = Convert.ToByte(_T3E[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[2].EndMinute = Convert.ToByte(_T3E[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[3].StartHour = Convert.ToByte(_T4S[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[3].StartMinute = Convert.ToByte(_T4S[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[3].EndHour = Convert.ToByte(_T4E[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[3].EndMinute = Convert.ToByte(_T4E[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[4].StartHour = Convert.ToByte(_T5S[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[4].StartMinute = Convert.ToByte(_T5S[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[4].EndHour = Convert.ToByte(_T5E[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[4].EndMinute = Convert.ToByte(_T5E[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[5].StartHour = Convert.ToByte(_T6S[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[5].StartMinute = Convert.ToByte(_T6S[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[5].EndHour = Convert.ToByte(_T6E[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[5].EndMinute = Convert.ToByte(_T6E[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[6].StartHour = Convert.ToByte(_T7S[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[6].StartMinute = Convert.ToByte(_T7S[i].Substring(3, 2));
                        pct.mPassCtrlTime[i].mPassTime[6].EndHour = Convert.ToByte(_T7E[i].Substring(0, 2));
                        pct.mPassCtrlTime[i].mPassTime[6].EndMinute = Convert.ToByte(_T7E[i].Substring(3, 2));
                    }
                    DeviceObject.objFK623.StructToByteArray((object)pct, _PassTime);
                    _exists = true;
                }
            }
        }

        public bool Exists
        {
            get { return _exists; }
        }

        public string[] T1S
        {
            get { return _T1S; }
        }

        public string[] T1E
        {
            get { return _T1E; }
        }

        public string[] T2S
        {
            get { return _T2S; }
        }

        public string[] T2E
        {
            get { return _T2E; }
        }

        public string[] T3S
        {
            get { return _T3S; }
        }

        public string[] T3E
        {
            get { return _T3E; }
        }

        public string[] T4S
        {
            get { return _T4S; }
        }

        public string[] T4E
        {
            get { return _T4E; }
        }

        public string[] T5S
        {
            get { return _T5S; }
        }

        public string[] T5E
        {
            get { return _T5E; }
        }

        public string[] T6S
        {
            get { return _T6S; }
        }

        public string[] T6E
        {
            get { return _T6E; }
        }

        public string[] T7S
        {
            get { return _T7S; }
        }

        public string[] T7E
        {
            get { return _T7E; }
        }

        public int TimeSize
        {
            get { return Marshal.SizeOf(typeof(PassCtrlTime)); }
        }

        public int TimeSizeAll
        {
            get { return _TimeSize; }
        }

        public byte[] GetPassTime(int index)
        {
            byte[] ret = new byte[TimeSize];
            Move(_PassTime, ret, index * TimeSize, 0, TimeSize);
            return ret;
        }

        private void Move(byte[] Src, byte[] Dest, int SrcStart, int DestStart, int Size)
        {
            int index = DestStart;

            for (int i = SrcStart; i < SrcStart + Size; i++)
            {
                Dest[index] = Src[i];
                index++;
            }
        }
    }

    public class MJGroupTime
    {
        private Base Pub = new Base();
        private const int count = (int)FKMax.MAX_GROUPPASSKIND_COUNT;
        private bool _exists = false;
        private byte[] _T1 = new byte[count];
        private byte[] _T2 = new byte[count];
        private byte[] _T3 = new byte[count];

        public MJGroupTime(string Src)
        {
            _exists = false;
            string[] tmp = Src.Split('@');
            if (tmp.Length == count * 3)
            {
                for (int i = 0; i < count; i++)
                {
                    byte.TryParse(tmp[i * 3], out _T1[i]);
                    byte.TryParse(tmp[i * 3 + 1], out _T2[i]);
                    byte.TryParse(tmp[i * 3 + 2], out _T3[i]);
                }
                _exists = true;
            }
        }

        public bool Exists
        {
            get { return _exists; }
        }

        public byte[] T1
        {
            get { return _T1; }
        }

        public byte[] T2
        {
            get { return _T2; }
        }

        public byte[] T3
        {
            get { return _T3; }
        }
    }
    public class KQPhoto
    {
        private string _GUID = "";
        private byte[] _PhotoImage = new byte[0];

        public string GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }

        public byte[] PhotoImage
        {
            get { return _PhotoImage; }
            set { _PhotoImage = value; }
        }

    }

    public class MJPhoto
    {
        private string _GUID = "";
        private byte[] _PhotoImage = new byte[0];

        public string GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }

        public byte[] PhotoImage
        {
            get { return _PhotoImage; }
            set { _PhotoImage = value; }
        }

    }

    public class MJBellTime
    {
        private Base Pub = new Base();
        private const int count = (int)FKMax.MAX_BELLCOUNT_DAY;
        private bool _exists = false;
        private string[] _allow = new string[count];
        private string[] _time = new string[count];
        private int _BellCount = 0;
        private int _BellSize;
        private byte[] _BellTime;

        public MJBellTime(string Src)
        {
            _exists = false;
            string[] tmp = Src.Split('@');
            if (tmp.Length == count * 2 + 1)
            {
                _BellSize = Marshal.SizeOf(typeof(BellInfo));
                _BellTime = new byte[_BellSize];
                BellInfo bi = new BellInfo();
                bi.Init();
                for (int i = 0; i < count; i++)
                {
                    _allow[i] = tmp[i * 2].ToString();
                    _time[i] = Pub.ValidatTime(tmp[i * 2 + 1]);
                    bi.mValid[i] = Convert.ToByte(_allow[i]);
                    bi.mHour[i] = Convert.ToByte(_time[i].Substring(0, 2));
                    bi.mMinute[i] = Convert.ToByte(_time[i].Substring(3, 2));
                }
                int.TryParse(tmp[tmp.Length - 1], out _BellCount);
                DeviceObject.objFK623.StructToByteArray((object)bi, _BellTime);
                _exists = true;
            }
        }

        public bool Exists
        {
            get { return _exists; }
        }

        public string[] Allow
        {
            get { return _allow; }
        }

        public string[] Time
        {
            get { return _time; }
        }

        public int BellCount
        {
            get { return _BellCount; }
        }

        public int BellSize
        {
            get { return _BellSize; }
        }

        public byte[] BellTime
        {
            get { return _BellTime; }
        }
    }
}