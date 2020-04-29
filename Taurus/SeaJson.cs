using System;
using System.Collections.Generic;
using System.Text;

namespace Taurus
{
    class SeaJson
    {

    }
    public class jsonBody<T>
    {
        public string cmd;
        public T info;

        public jsonBody(string cmd, T info)
        {
            this.cmd = cmd;
            this.info = info;
        }
    }

    public class Answer
    {
        public string Result;
        public string Detail;
    }

    /// <summary>
    /// 设置时间
    /// </summary>
    public class SeaSeriesSyncTime
    {
        public int Year;
        public int Month;
        public int Day;
        public int Hour;
        public int Minute;
        public int Second;

        public SeaSeriesSyncTime(int year, int month, int day, int hour, int minute, int second)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }

    public class GetMachineInfo
    {
        public int PersonNum;
        public int CardNum;
        public int RecordNum;
    }
    /// <summary>
    /// 查询记录总数
    /// </summary>
    public class SearchControlNum
    {
        public string DeviceID;
        public string BeginTime;
        public string EndTime;

        public SearchControlNum(string deviceID, string beginTime, string endTime)
        {
            DeviceID = deviceID;
            BeginTime = beginTime;
            EndTime = endTime;
        }
    }

    public class GetSearchControlNum
    {
        public int DeviceID;
        public int ControlNum; 
    }
    /// <summary>
    /// 查询抓拍记录总数
    /// </summary>
    public class SearchCaptureNum
    {
        public string DeviceID;
        public string BeginTime;
        public string EndTime;

        public SearchCaptureNum(string deviceID, string beginTime, string endTime)
        {
            DeviceID = deviceID;
            BeginTime = beginTime;
            EndTime = endTime;
        }
    }

    public class GetSearchCaptureNum
    {
        public int DeviceID;
        public int CaptureNum;
    }

    /// <summary>
    /// 查询抓拍记录指令
    /// </summary>
    public class SearchCapture
    {
        public int DeviceID;
        public string BeginTime;
        public string EndTime;
        public int BeginNO;
        public int RequestCount;

        public SearchCapture(int deviceID, string beginTime, string endTime, int beginNO, int requestCount)
        {
            DeviceID = deviceID;
            BeginTime = beginTime;
            EndTime = endTime;
            BeginNO = beginNO;
            RequestCount = requestCount;
        }
    }

    /// <summary>
    /// 获取抓拍记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GetSearchCapture<T>
    {
        public int DeviceID;
        public int Listnum;
        public List<T> List;
    }

    public class OneSearchCapture
    {
        public int LibSnapID;
        public string CreateTime;
        public string SnapPicinfo;
        public double Temperature;
        public int TemperatureAlarm;
    }

    /// <summary>
    /// 初始化设备
    /// </summary>
    public class SeaSeriesInitDevice
    {
        public int DefaltDoorSet;
        public int DefaltSoundSet;
        public int DefaltNetPar;
        public int DefaltCenterPar;
        public int DefaltCapture;
        public int DefaltLog;
        public int DefaltPerson;
        public int DefaltRecord;
        public int DefaltMaintainTime;
        public int DefaltSystemSettings;
        public int DefaltEnterIPC;
        public int DefaltServerBasicPara;
        public int DefaltWorktype;

        public SeaSeriesInitDevice(int defaltDoorSet, int defaltSoundSet, int defaltNetPar, int defaltCenterPar, int defaltCapture, int defaltLog, int defaltPerson, int defaltRecord, int defaltMaintainTime, int defaltSystemSettings, int defaltEnterIPC, int defaltServerBasicPara, int defaltWorktype)
        {
            DefaltDoorSet = defaltDoorSet;
            DefaltSoundSet = defaltSoundSet;
            DefaltNetPar = defaltNetPar;
            DefaltCenterPar = defaltCenterPar;
            DefaltCapture = defaltCapture;
            DefaltLog = defaltLog;
            DefaltPerson = defaltPerson;
            DefaltRecord = defaltRecord;
            DefaltMaintainTime = defaltMaintainTime;
            DefaltSystemSettings = defaltSystemSettings;
            DefaltEnterIPC = defaltEnterIPC;
            DefaltServerBasicPara = defaltServerBasicPara;
            DefaltWorktype = defaltWorktype;
        }
    }
    /// <summary>
    /// 删除所有人员
    /// </summary>
    public class DefaltPersonCmd
    {
        public int DefaltPerson;

        public DefaltPersonCmd(int defaltPerson)
        {
            DefaltPerson = defaltPerson;
        }
    }

    /// <summary>
    /// 添加人员
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Person<T>
    {
        public string cmd;
        public T info;
        public string picinfo;

        public Person(string cmd, T info, string picinfo)
        {
            this.cmd = cmd;
            this.info = info;
            this.picinfo = picinfo;
        }
    }

    /// <summary>
    /// 人员信息
    /// </summary>
    public class PersonInfo
    {
        public int DeviceID;
        public int PersonType;
        public string Name;
        public int Gender;
        public int Nation;
        public int CardType;
        public string IdCard;
        public string Birthday;
        public string Telnum;
        public string Native;
        public string Address;
        public string Notes;
        public int MjCardFrom;
        public long MjCardNo;
        public string RFIDCard;
        public int Tempvalid;
        public int CustomizeID;
        public string PersonUUID;
        public string ValidBegin;
        public string ValidEnd;
        public string ChannelAuthority0;
        public string ChannelAuthority1;
        public string ChannelAuthority2;
        public string ChannelAuthority3;

        public PersonInfo(int deviceID, int personType, string name, int gender, int nation, int cardType, string idCard, string birthday, string telnum, string native, string address, string notes, int mjCardFrom, long mjCardNo, string rFIDCard, int tempvalid, int customizeID, string personUUID, string validBegin, string validEnd, string channelAuthority0, string channelAuthority1, string channelAuthority2, string channelAuthority3)
        {
            DeviceID = deviceID;
            PersonType = personType;
            Name = name;
            Gender = gender;
            Nation = nation;
            CardType = cardType;
            IdCard = idCard;
            Birthday = birthday;
            Telnum = telnum;
            Native = native;
            Address = address;
            Notes = notes;
            MjCardFrom = mjCardFrom;
            MjCardNo = mjCardNo;
            RFIDCard = rFIDCard;
            Tempvalid = tempvalid;
            CustomizeID = customizeID;
            PersonUUID = personUUID;
            ValidBegin = validBegin;
            ValidEnd = validEnd;
            ChannelAuthority0 = channelAuthority0;
            ChannelAuthority1 = channelAuthority1;
            ChannelAuthority2 = channelAuthority2;
            ChannelAuthority3 = channelAuthority3;
        }
    }
    /// <summary>
    /// 单个人员信息查询指令
    /// </summary>
    public class SearchOnePerson
    {
        public int DeviceID;
        public int SearchType;
        public string SearchID;
        public int Picture;

        public SearchOnePerson(int deviceID, int searchType, string searchID, int picture)
        {
            DeviceID = deviceID;
            SearchType = searchType;
            SearchID = searchID;
            Picture = picture;
        }
    }
    /// <summary>
    /// 查询人员总数指令
    /// </summary>
    public class SearchTotlePerson
    {
        public int DeviceID;
        public int PersonType;
        public string BeginTime;
        public string EndTime;
        public int Gender;
        public string Age;
        public long MjCardNo;
        public string Name;

        public SearchTotlePerson(int deviceID, int personType, string beginTime, string endTime, int gender, string age, long mjCardNo, string name)
        {
            DeviceID = deviceID;
            PersonType = personType;
            BeginTime = beginTime;
            EndTime = endTime;
            Gender = gender;
            Age = age;
            MjCardNo = mjCardNo;
            Name = name;
        }
    }
    /// <summary>
    /// 查询人员总数指令
    /// </summary>
    public class SearchTotlePersonInfo
    {
        public int DeviceID;
        public int PersonNum;
    }
    /// <summary>
    /// 查询多个人员
    /// </summary>
    public class SearchMultiplePerson
    {
        public int DeviceID;
        public int PersonType;
        public string BeginTime;
        public string EndTime;
        public int Gender;
        public string Age;
        public long MjCardNo;
        public string Name;
        public int BeginNO;
        public int RequestCount;
        public int Picture;

        public SearchMultiplePerson(int deviceID, int personType, string beginTime, string endTime, int gender, string age, long mjCardNo, string name, int beginNO, int requestCount, int picture)
        {
            DeviceID = deviceID;
            PersonType = personType;
            BeginTime = beginTime;
            EndTime = endTime;
            Gender = gender;
            Age = age;
            MjCardNo = mjCardNo;
            Name = name;
            BeginNO = beginNO;
            RequestCount = requestCount;
            Picture = picture;
        }
    }
    /// <summary>
    /// 人员列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchMultiplePersonInfo<T>
    {
        public int DeviceID;
        public int Listnum;
        public List<T> List;
    }
    /// <summary>
    /// 单个人员
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchOnePersonInfo<T>
    {
        public string cmd;
        public T info;
        public string picinfo;
    }

    /// <summary>
    /// 查询的人员信息
    /// </summary>
    public class SearchPersonInfo
    {
        public int LibID;
        public int PersonType;
        public string Name;
        public int Gender;
        public int Nation;
        public int CardType;
        public string IdCard;
        public string RFIDCard;
        public string Birthday;
        public string Telnum;
        public string Native;
        public string Address;
        public string Notes;
        public int MjCardFrom;
        public long MjCardNo;
        public int Tempvalid;
        public UInt32 CustomizeID;
        public string PersonUUID;
        public string ValidBegin;
        public string ValidEnd;
        public string Picinfo;
    }
    /// <summary>
    /// 删除人员
    /// </summary>
    public class DeletePerson
    {
        public int DeviceID;
        public int TotalNum;
        public int IdType;
        public List<int> CustomizeID;

        public DeletePerson(int deviceID, int totalNum, int idType, List<int> customizeID)
        {
            DeviceID = deviceID;
            TotalNum = totalNum;
            IdType = idType;
            CustomizeID = customizeID;
        }
    }
    public class DeleteAllPerson
    {
        public int DeviceID;
        public int TotalNum;
        public int IdType;
        public List<int> LibID;

        public DeleteAllPerson(int deviceID, int totalNum, int idType, List<int> libID)
        {
            DeviceID = deviceID;
            TotalNum = totalNum;
            IdType = idType;
            LibID = libID;
        }
    }
    /// <summary>
    /// 查询记录指令
    /// </summary>
    public class SearchControlCmd
    {
        public int DeviceID;
        public string BeginTime;
        public string EndTime;
        public int BeginNO;
        public int RequestCount;
        public int Picture;

        public SearchControlCmd(int deviceID, string beginTime, string endTime, int beginNO, int requestCount, int picture)
        {
            DeviceID = deviceID;
            BeginTime = beginTime;
            EndTime = endTime;
            BeginNO = beginNO;
            RequestCount = requestCount;
            Picture = picture;
        }
    }

    public class SearchControl<T>
    {
        public int DeviceID;
        public int TotalNum;
        public List<T> SearchInfo;
    }
    /// <summary>
    /// 记录
    /// </summary>
    public class SearchInfo
    {
        public int CustomizeID;
        public int LibID;
        public string Time;
        public int Gender;
        public string Birthday;
        public string CardType;
        public string Address;
        public int VerfyType;
        public int VerifyStatus;
        public int PersonType;
        public string Name;
        public long MjCardNo;
        public string IdCard;
        public string SnapPicinfo;
        public string RegPicinfo;
        public int Nation;
        public int RemoteOpenDoor;
        public double Temperature;
        public int TemperatureAlarm;
    }
    /// <summary>
    /// 重启
    /// </summary>
    public class RebootDevice
    {
        public int DeviceID;
        public int IsRebootDevice;
    }
    /// <summary>
    /// 开门
    /// </summary>
    public class OpenDoorCmd
    {
        public int DeviceID;
        public int Chn;
        public int status;

        public OpenDoorCmd(int deviceID, int chn, int status)
        {
            DeviceID = deviceID;
            Chn = chn;
            this.status = status;
        }
    }

    /// <summary>
    /// 开门
    /// </summary>
    public class RebootDeviceCmd
    {
        public int DeviceID;
        public int IsRebootDevice;

        public RebootDeviceCmd(int deviceID, int isRebootDevice)
        {
            DeviceID = deviceID;
            IsRebootDevice = isRebootDevice;
        }
    }

        /// <summary>
        /// 实时密码识别
        /// </summary>
        public class PwdVerify
    {
        public int DeviceID;
        public string CreateTime;
        public int HasPic;
        public string SanpPic;
    }
    /// <summary>
    /// 实时卡识别
    /// </summary>
    public class CardVerify
    {
        public int DeviceID;
        public string CreateTime;
        public string CardNo;
        public int HasPic;
        public string SanpPic;
    }
    /// <summary>
    /// 实时二维码识别
    /// </summary>
    public class QRCodePush
    {
        public int DeviceID;
        public string QRcodeInfo;
    }
    /// <summary>
    /// 实时人脸识别
    /// </summary>
    public class VerifyPush<T>
    {
        public string cmd;
        public T info;
        public string SanpPic;
    }

    /// <summary>
    /// 实时人脸识别信息
    /// </summary>
    public class VerifyPushInfo
    {
        public int DeviceID;
        public int PersonID;
        public string CreateTime;
        public int VerifyStatus;
        public int VerfyType;
        public int PersonType;
        public string Name;
        public int Gender;
        public int Nation;
        public int CardType;
        public string IdCard;
        public string Notes;
        public int MjCardFrom;
        public long MjCardNo;
        public int Tempvalid;
        public int CustomizeID;
        public string PersonUUID;
        public string RFIDCard;
        public int Sendintime;
        public string Birthday;
        public string Address;
        public int RemoteOpenDoor;
        public double Temperature;
        public int TemperatureAlarm;
    }
    /// <summary>
    /// 实时远程开门信息
    /// </summary>
    public class RemoteOpenDoorPushInfo
    {
        public int DeviceID;
        public int PersonID;
        public string CreateTime;
        public int VerfyType;
    }
    /// <summary>
    /// 实时陌生人识别
    /// </summary>
    public class SnapPush
    {
        public int DeviceID;
        public string CreateTime;
        public string PictureType;
        public double Temperature;
        public int TemperatureAlarm;
    }

    public class Subscribe<T>
    {
        public int DeviceID;
        public int Num;
        public List<string> Topics;
        public string SubscribeAddr;
        public T SubscribeUrl;
        public string Auth;

        public Subscribe(int deviceID, int num, List<string> topics, string subscribeAddr, T subscribeUrl, string auth)
        {
            DeviceID = deviceID;
            Num = num;
            Topics = topics;
            SubscribeAddr = subscribeAddr;
            SubscribeUrl = subscribeUrl;
            Auth = auth;
        }
    }

    public class SubscribeUrlInfo
    {
        public string Snap;
        public string Verify;
        public string HeartBeat;

        public SubscribeUrlInfo(string snap, string verify, string heartBeat)
        {
            Snap = snap;
            Verify = verify;
            HeartBeat = heartBeat;
        }
    }

    public class DoorCondition
    {
        public int FaceThreshold;
        public int IDCardThreshold;
        public int OpendoorWay;
        public int VerifyMode;
        public int ControlType;
        public int Wiegand;
        public uint PublicMjCardNo;
        public uint AutoMjCardBgnNo;
        public uint AutoMjCardEndNo;
        public int IOStayTime;

        public DoorCondition(int faceThreshold, int iDCardThreshold, int opendoorWay, int verifyMode, int controlType, int wiegand, uint publicMjCardNo, uint autoMjCardBgnNo, uint autoMjCardEndNo, int iOStayTime)
        {
            FaceThreshold = faceThreshold;
            IDCardThreshold = iDCardThreshold;
            OpendoorWay = opendoorWay;
            VerifyMode = verifyMode;
            ControlType = controlType;
            Wiegand = wiegand;
            PublicMjCardNo = publicMjCardNo;
            AutoMjCardBgnNo = autoMjCardBgnNo;
            AutoMjCardEndNo = autoMjCardEndNo;
            IOStayTime = iOStayTime;
        }
    }

    /// <summary>
    /// 设置密码
    /// </summary>
    public class SetUserPwd
    {
        public string User;
        public string Pwd;

        public SetUserPwd(string user, string pwd)
        {
            User = user;
            Pwd = pwd;
        }
    }
    /// <summary>
    /// 网络参数
    /// </summary>
    public class NetParam
    {
        public string IPAddr;
        public string Submask;
        public string Gateway;
        public int ListenPort;
        public int WebPort;

        public NetParam(string iPAddr, string submask, string gateway, int listenPort, int webPort)
        {
            IPAddr = iPAddr;
            Submask = submask;
            Gateway = gateway;
            ListenPort = listenPort;
            WebPort = webPort;
        }
    }

    /// <summary>
    /// 温度参数
    /// </summary>
    public class TemperatureParam
    {
        public int DeviceID;
        public int FaceMaskTPTMode;
        public double TemperatureCheck;
        public double TemperatureHigh;
        public double EnvTemperature;
        public double EnvTemperatureCheck;
        public int OpenLaser;

        public TemperatureParam(int deviceID, int faceMaskTPTMode, double temperatureCheck, double temperatureHigh, double envTemperature, double envTemperatureCheck, int openLaser)
        {
            DeviceID = deviceID;
            FaceMaskTPTMode = faceMaskTPTMode;
            TemperatureCheck = Math.Round(temperatureCheck, 2);
            TemperatureHigh = Math.Round(temperatureHigh, 2);
            EnvTemperature = Math.Round(envTemperature, 2);
            EnvTemperatureCheck = Math.Round(envTemperatureCheck, 2);
            OpenLaser = openLaser;
        }
    }          

        /// <summary>
        /// 用来进行有效期设置
        /// </summary>
        public class EditPersonInfo
    {
        public int DeviceID;
        public int IdType;
        public int CustomizeID;
        public int PersonType;
        public string Name;
        public int Gender;
        public int Nation;
        public int CardType;
        public string IdCard;
        public string Birthday;
        public string Telnum;
        public string Native;
        public string Address;
        public string Notes;
        public int MjCardFrom;
        public long MjCardNo;
        public string RFIDCard;
        public int Tempvalid;
        public string PersonUUID;
        public string ValidBegin;
        public string ValidEnd;
       

        public EditPersonInfo(int deviceID, int idType, int customizeID, int personType, string name, int gender, int nation, int cardType, string idCard, string birthday, string telnum, string native, string address, string notes, int mjCardFrom, long mjCardNo, string rFIDCard, int tempvalid, string personUUID, string validBegin, string validEnd)
        {
            DeviceID = deviceID;
            IdType = idType;
            CustomizeID = customizeID;
            PersonType = personType;
            Name = name;
            Gender = gender;
            Nation = nation;
            CardType = cardType;
            IdCard = idCard;
            Birthday = birthday;
            Telnum = telnum;
            Native = native;
            Address = address;
            Notes = notes;
            MjCardFrom = mjCardFrom;
            MjCardNo = mjCardNo;
            RFIDCard = rFIDCard;
            Tempvalid = tempvalid;
            PersonUUID = personUUID;
            ValidBegin = validBegin;
            ValidEnd = validEnd;
        }
    }
    /// <summary>
    /// 设置声音
    /// </summary>
    public class SetSound
    {
        public int VerifySuccAudio;
        public int VerifyFailAudio;
        public int RemoteCtrlAudio;
        public int Volume;
        public int VerifySuccGuiTip;
        public int VerifyFailGuiTip;
        public int UnregisteredGuiTip;

        public int IPHide;
        public int IsShowName;
        public int IsShowTitle;
        public int IsShowVersion;
        public int IsShowDate;
        public int IDCardNumHide;
        public int ICCardNumHide;

        public SetSound(int verifySuccAudio, int verifyFailAudio, int remoteCtrlAudio, int volume, int verifySuccGuiTip, int verifyFailGuiTip, int unregisteredGuiTip, int iPHide, int isShowName, int isShowTitle, int isShowVersion, int isShowDate, int iDCardNumHide, int iCCardNumHide)
        {
            VerifySuccAudio = verifySuccAudio;
            VerifyFailAudio = verifyFailAudio;
            RemoteCtrlAudio = remoteCtrlAudio;
            Volume = volume;
            VerifySuccGuiTip = verifySuccGuiTip;
            VerifyFailGuiTip = verifyFailGuiTip;
            UnregisteredGuiTip = unregisteredGuiTip;
            IPHide = iPHide;
            IsShowName = isShowName;
            IsShowTitle = isShowTitle;
            IsShowVersion = isShowVersion;
            IsShowDate = isShowDate;
            IDCardNumHide = iDCardNumHide;
            ICCardNumHide = iCCardNumHide;
        }
    }

    /// <summary>
    /// 获取设备信息
    /// </summary>
    public class GetSysParam
    {
        public string Name;
        public int DeviceID;
        public string Version;
    }

}
