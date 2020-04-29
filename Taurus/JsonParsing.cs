using System;
using System.Collections.Generic;
using System.Text;

namespace Taurus
{
    public class _AnswerInfo
    {
        public string cmd;
        public int result_code;
    }

    public class _ResultInfo<T>
    {
        public string cmd;
        public int result_code;
        public T result_data;
    }

    public class DeviceInfo
    {
        public string deviceId;
        public int cardCount;
        public int cardLimit;
        public int faceCount;
        public int faceLimit;
        public string faceVer;
        public int Face;
        public string firmware;
        public int fpCount;
        public int fpLimit;
        public string fpVer;
        public int logCount;
        public int logLimit;
        public int managerCount;
        public int maxBufferLen;
        public string name;
        public int pwdCount;
        public int pwdLimit;
        public int userCount;
        public int userLimit;
        public int allLogCount;
    }

    public class UserListInfo<T>
    {
        public int packageId;
        public int usersCount;
        public List<T> users;
    }

    public class UserIdName
    {
        public string userId;
        public string name;

        public UserIdName(string userId, string name)
        {
            this.userId = userId;
            this.name = name;
        }
    }

    public class PersonInfo<T>
    {
        public int packageId;
        public int usersCount;
        public T[] users;
    }

    public class GetUsers
    {
        public string userId;
        public string name;
        public int privilege;
        public string card;
        public string pwd;
        public List<string> fps;
        public string face;
        public string palm;
        public string photo;
        public string vaildStart;
        public string vaildEnd;
    }

    public class RecordInfo<T>
    {
        public int allLogCount;
        public List<T> logs;
        public int logsCount;
        public int packageId;
    }

    public class Logs
    {
        public string time;
        public string inOut;
        public int ioMode;
        public string userId;
        public string verifyMode;
        public string doorMode;
        public string logPhoto;
    }

    public class MonitoringLogs
    {
        public string inOut;
        public int ioMode;
        public string time;
        public string userId;
        public string verifyMode;
        public string doorMode;
        public string logPhoto;
    }

    public class ParameterInfo
    {
        public string devName;
        public string wiegandType;
        public string language;
        public string volume;
        public string antiPass;
        public string openDoorDelay;
        public string tamperAlarm;
        public string alarmDelay;
        public string reverifyTime;
        public string screensaversTime;
        public string sleepTime;
        public string verifyMode;

        public ParameterInfo(string devName, string wiegandType, string language, string volume, string antiPass, string openDoorDelay, string tamperAlarm, string alarmDelay, string reverifyTime, string screensaversTime, string sleepTime, string verifyMode)
        {
            this.devName = devName;
            this.wiegandType = wiegandType;
            this.language = language;
            this.volume = volume;
            this.antiPass = antiPass;
            this.openDoorDelay = openDoorDelay;
            this.tamperAlarm = tamperAlarm;
            this.alarmDelay = alarmDelay;
            this.reverifyTime = reverifyTime;
            this.screensaversTime = screensaversTime;
            this.sleepTime = sleepTime;
            this.verifyMode = verifyMode;
        }
    }

    public class NetParameterInfo
    {
        public string serverHost;
        public string serverPort;
        public string pushServerHost;
        public string pushServerPort;
        public string interval;
        public string pushEnable;

        public NetParameterInfo(string serverHost, string serverPort, string pushServerHost, string pushServerPort, string interval, string pushEnable)
        {
            this.serverHost = serverHost;
            this.serverPort = serverPort;
            this.pushServerHost = pushServerHost;
            this.pushServerPort = pushServerPort;
            this.interval = interval;
            this.pushEnable = pushEnable;
        }
    }

    public class DeviceCmd
    {
        public string cmd;

        public DeviceCmd(string cmd)
        {
            this.cmd = cmd;
        }
    }

    public class _DeviceCmd<T>
    {
        public string cmd;
        public T data;

        public _DeviceCmd(string cmd, T data)
        {
            this.cmd = cmd;
            this.data = data;
        }
    }

    public class GetUserIdListCmd
    {
        public int packageId;

        public GetUserIdListCmd(int packageId)
        {
            this.packageId = packageId;
        }
    }

    public class SetUserInfoCmd<T>
    {
        public List<T> users;

        public SetUserInfoCmd(List<T> users)
        {
            this.users = users;
        }
    }

    public class GetUserInfoCmd
    {
        public int packageId;
        public List<string> usersId;

        public GetUserInfoCmd(int packageId, List<string> usersId)
        {
            this.packageId = packageId;
            this.usersId = usersId;
        }
    }

    public class DeleteUserInfoCmd
    {
        public int usersCount;
        public List<string> usersId;

        public DeleteUserInfoCmd(int usersCount, List<string> usersId)
        {
            this.usersCount = usersCount;
            this.usersId = usersId;
        }
    }
    public class SetUsers
    {
        public string userId;
        public string name;
        public int privilege;
        public string card;
        public string pwd;
        public List<string> fps;
        public string face;
        public string palm;
        public string photo;
        public string vaildStart;
        public string vaildEnd;
        public byte update;
        public byte photoEnroll;

        public SetUsers(string userId, string name, int privilege, string card, string pwd, List<string> fps, string face, string palm, string photo, string vaildStart, string vaildEnd, byte update, byte photoEnroll)
        {
            this.userId = userId;
            this.name = name;
            this.privilege = privilege;
            this.card = card;
            this.pwd = pwd;
            this.fps = fps;
            this.face = face;
            this.palm = palm;
            this.photo = photo;
            this.vaildStart = vaildStart;
            this.vaildEnd = vaildEnd;
            this.update = update;
            this.photoEnroll = photoEnroll;
        }
    }

    public class SetUsersErorr
    {
        public List<string> usersId;
    }

    public class GetLogDataCmd
    {
        public int packageId;
        public int newLog;
        public string beginTime;
        public string endTime;
        public int clearMark;

        public GetLogDataCmd(int packageId, int newLog, string beginTime, string endTime, int clearMark)
        {
            this.packageId = packageId;
            this.newLog = newLog;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.clearMark = clearMark;
        }
    }
    //远程控制门
    public class SetDoor
    {
        public string doorStatus;

        public SetDoor(string doorStatus)
        {
            this.doorStatus = doorStatus;
        }
    }
    /// <summary>
    /// 设置时间
    /// </summary>
    public class SetTimeCmd
    {
        public string syncTime;

        public SetTimeCmd(string syncTime)
        {
            this.syncTime = syncTime;
        }
    }

    public class EnterEnrollCmd
    {
        public string userId;
        public string feature;

        public EnterEnrollCmd(string userId, string feature)
        {
            this.userId = userId;
            this.feature = feature;
        }
    }

    public class httpTime
    {
        public string time;
    }
}
