using System;
using System.Collections.Generic;
using System.Text;

namespace Taurus
{
    public class MSSQL
    {
        private string GetEmpInfoSQL(string TagInfo, string EmpInfo)
        {
            string ret = "";
            if (EmpInfo == "") return ret;
            if (TagInfo == "1")
                ret = " AND EmpNo='" + EmpInfo + "'";
            else
                ret = " AND (EmpNo='" + EmpInfo + "' OR EmpName LIKE '" + EmpInfo + "%')";
            return ret;
        }
        private string GetVerifyModeInfoSQL(string VerifyModeInfo)
        {
            string ret = "";
            if (VerifyModeInfo == "") return ret;
            ret = " AND VerifyModeName LIKE '%" + VerifyModeInfo + "%'";
            return ret;
        }
        private string GetMJEmpInfoSQL(string EmpInfo)
        {
            string ret = "";
            if (EmpInfo == "") return ret;
            ret = " AND (EmpNoOne LIKE '%" + EmpInfo + "%' OR EmpNoTwo LIKE '%" + EmpInfo + "%' OR EmpNoTree LIKE '%" + EmpInfo + "%')";
            return ret;
        }

        private string GetEmpNameSQL(string EmpInfo)
        {
            string ret = "";
            if (EmpInfo != "")
                ret = " AND EmpName LIKE '" + EmpInfo + "%'";
            return ret;
        }

        private string GetInOutModeInfoSQL(string InOutModeInfo)
        {
            string ret = "";
            if (InOutModeInfo == "") return ret;
            ret = " AND InOutModeName='" + InOutModeInfo + "'";
            return ret;
        }

        private string GetOprtModuleSQL(string OprtModuleInfo)
        {
            string ret = "";
            if (OprtModuleInfo == "") return ret;
            ret = " AND (OprtModule LIKE '%" + OprtModuleInfo + "%')";
            return ret;
        }

        private string GetOprtToolSQL(string OprtToolInfo)
        {
            string ret = "";
            if (OprtToolInfo == "") return ret;
            ret = " AND (OprtTool LIKE '%" + OprtToolInfo + "%')";
            return ret;
        }
        private string GetAlarmModeInfoSQL(string AlarmModeInfo)
        {
            string ret = "";
            if (AlarmModeInfo == "") return ret;
            ret = " AND AlarmMode LIKE '%" + AlarmModeInfo + "%'";
            return ret;
        }
        private string GetMacSNSQL(string TagInfo)
        {
            string ret = "";
            if (TagInfo == "") return ret;

            ret = " AND (OprtDetail LIKE '" + TagInfo + ":%' OR OprtDetail LIKE '%;" + TagInfo + ":%' OR OprtDetail LIKE '% " + TagInfo + ":%')\r\n";
            return ret;
        }
        private string GetDepartInfoSQL(string TagInfo, string DepartInfo, string DepartList)
        {
            string ret = "";
            if (DepartInfo == "") return ret;
            if (TagInfo == "1")
            {
                ret = " AND (DepartID='" + DepartInfo + "'";
                if (DepartList == "")
                    ret += ") ";
                else
                    ret += " OR DepartID IN (" + DepartList + ")) ";
            }
            else
                ret = " AND (DepartID='" + DepartInfo + "' OR  DepartName LIKE '" + DepartInfo + "%')";
            return ret;
        }

        private string GetPowerMacSNInfoSQL(string TagInfo, string EmpInfo)
        {
            string ret = "";
            if (EmpInfo == "") return ret;
            if (TagInfo == "1")
                ret = " AND MacSN='" + EmpInfo + "'";
            else
                ret = " AND (MacSN='" + EmpInfo + "' OR MacDesc LIKE '" + EmpInfo + "%')";
            return ret;
        }

        private string GetMacSNInfoSQL(string TagInfo, string MacInfo)
        {
            string ret = "";
            if (MacInfo == "") return ret;
            ret = " AND MacSN='" + MacInfo + "'";
            return ret;
        }
        public string GetSQL(DBCode code, string[] Param)
        {
            string ret = "";
            int I = 0;
            switch (code)
            {
                case DBCode.DB_000001:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM DBVersion";
                            break;
                        case 1:
                            ret = "SELECT * FROM SY_Oprt ORDER BY OprtNo";
                            break;
                        case 2:
                            ret = "SELECT * FROM SY_Oprt WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "UPDATE SY_Oprt SET OprtLastLoginTime=getdate() WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT DepartID,DepartName FROM RS_Depart WHERE DepartUpID='' OR DepartUpID IS NULL";
                            break;
                        case 5:
                            ret = "UPDATE DbVersion SET AppVer='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM SY_Wizard WHERE OprtNo='" + Param[1] + "' AND ModuleType=" +
                              Param[2] + " ORDER BY [No]";
                            break;
                        case 7:
                            ret = "DELETE FROM SY_Wizard WHERE OprtNo='" + Param[1] + "' AND ModuleType=" + Param[2];
                            break;
                        case 8:
                            ret = "INSERT INTO SY_Wizard(OprtNo,ModuleType,ModuleID,SubID,[No],vis) VALUES('" + Param[1] + "'," +
                              Param[2] + ",'" + Param[3] + "','" + Param[4] + "'," + Param[5] + "," + Param[6] + ")";
                            break;
                        case 9:
                            ret = "INSERT INTO SY_Log(OprtTime,OprtModule,OprtTool,OprtDetail,OprtNoName,OprtComputerName) " +
                              "VALUES(getdate(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "','" +
                              Param[5] + "')";
                            break;
                        case 10:
                            ret = "UPDATE SY_Oprt SET OprtPWD='" + Param[1] + "' WHERE OprtNo='" + Param[2] + "'";
                            break;
                        case 11:
                            ret = "SELECT DepartID,DepartName FROM RS_Depart WHERE DepartUpID='" + Param[1] + "' ORDER BY DepartID";
                            break;
                        case 12:
                            ret = "SELECT * FROM VRS_Emp WHERE DepartID='" + Param[1] + "'";
                            if (Param.Length > 2) ret += Param[2];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 13:
                            ret = "CONVERT(varchar(10),getdate(),120)";
                            break;
                        case 14:
                            ret = "SELECT getdate() as ServerDate";
                            break;
                        case 15:
                            ret = "SELECT [Value] FROM SY_Config WHERE ID='" + Param[1] + "' AND [Key]='" + Param[2] + "'";
                            break;
                        case 16:
                            ret = "INSERT INTO SY_Config(ID,[Key],[Value]) VALUES('" + Param[1] + "','" + Param[2] + "','" +
                              Param[3] + "')";
                            break;
                        case 17:
                            ret = "UPDATE SY_Config SET [Value]='" + Param[3] + "' WHERE ID='" + Param[1] + "' AND [Key]='" +
                              Param[2] + "'";
                            break;
                        case 18:
                            ret = "DELETE FROM SY_Config WHERE ID='" + Param[1] + "' AND [Key]='" + Param[2] + "'";
                            break;
                        case 100:
                            ret = "DELETE FROM KQ_EmpShift WHERE EmpShiftDate>='" + Param[1] +
                              "' AND EmpShiftDate<='" + Param[2] + "'";
                            break;
                        case 101:
                            ret = "DELETE FROM KQ_DepShift WHERE DepShiftDate>='" + Param[1] +
                              "' AND DepShiftDate<='" + Param[2] + "'";
                            break;
                        case 102:
                            ret = "DELETE FROM KQ_Holiday WHERE HolidayBeginTime>='" + Param[1] +
                              "' AND HolidayEndTime<='" + Param[2] + "'";
                            break;
                        case 103:
                            ret = "DELETE FROM KQ_EmpDayOff WHERE BeginTime>='" + Param[1] + "' AND EndTime<='" + Param[2] + "'";
                            break;
                        case 104:
                            ret = "DELETE FROM KQ_EmpOtSure WHERE BeginTime>='" + Param[1] + "' AND EndTime<='" + Param[2] + "'";
                            break;
                        case 105:
                            ret = "DELETE FROM KQ_KQData WHERE IsSignIn=1 AND KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 106:
                            ret = "DELETE FROM KQ_KQDataPhoto WHERE GUID IN(SELECT GUID FROM KQ_KQData WHERE KQDate>='" +
                              Param[1] + "' AND KQDate<='" + Param[2] + "')\r\n";
                            ret += "DELETE FROM KQ_KQData WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                           
                            break;
                        case 107:
                            ret = "DELETE FROM KQ_KQDataFilter WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            //ret += "DELETE FROM KQ_KQDataFilterMark WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 108:
                            ret = "DELETE FROM KQ_KQReportDay WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 109:
                            ret = "DELETE FROM KQ_KQReportMonth WHERE KQYM>='" + Param[1] + "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 110:
                            ret = "DELETE FROM KQ_KQReportWeek WHERE KQYM>='" + Param[1] + "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 111:
                            ret = "DELETE FROM KQ_KQReportMonthDetail WHERE KQYM>='" + Param[1] + "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 112:
                            ret = "DELETE FROM KQ_MJData WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 113:
                            ret = "DELETE FROM MJ_OpenData WHERE MJDateTime>='" + Param[1] +
                               "' AND MJDateTime<='" + Param[2] + "'";
                            break;
                        case 114:
                            ret = "DELETE FROM MJ_AlarmData WHERE AlarmTime>='" + Param[1] +
                              "' AND AlarmTime<='" + Param[2] + "'";
                            break;
                        case 115:
                            ret = "DELETE FROM MJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] +
                              "' AND KQDateTime<='" + Param[2] + "'";
                            break;
                        case 200:
                            ret = "DELETE FROM KQ_ReportRecords WHERE KQYM>='" + Param[1] + "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 300:
                            ret = "DELETE FROM KQ_MJData WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 301:
                            ret = "DELETE FROM MJ_OpenData WHERE MJDateTime>='" + Param[1] +
                               "' AND MJDateTime<='" + Param[2] + "'";
                            break;
                        case 302:
                            ret = "DELETE FROM MJ_AlarmData WHERE AlarmTime>='" + Param[1] +
                              "' AND AlarmTime<='" + Param[2] + "'";
                            break;
                        case 303:
                            ret = "DELETE FROM MJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] +
                             "' AND KQDateTime<='" + Param[2] + "'";
                            break;
                        case 500:
                            ret = "SELECT TOP 9000 * FROM KQ_EmpShift WHERE EmpShiftDate>='" + Param[1] +
                              "' AND EmpShiftDate<='" + Param[2] + "'";
                            break;
                        case 501:
                            ret = "SELECT TOP 9000 * FROM KQ_DepShift WHERE DepShiftDate>='" + Param[1] +
                              "' AND DepShiftDate<='" + Param[2] + "'";
                            break;
                        case 502:
                            ret = "SELECT TOP 9000 * FROM KQ_Holiday WHERE HolidayBeginTime>='" + Param[1] +
                              "' AND HolidayEndTime<='" + Param[2] + "'";
                            break;
                        case 503:
                            ret = "SELECT TOP 9000 * FROM KQ_EmpDayOff WHERE BeginTime>='" + Param[1] +
                              "' AND EndTime<='" + Param[2] + "'";
                            break;
                        case 504:
                            ret = "SELECT TOP 9000 * FROM KQ_EmpOtSure WHERE BeginTime>='" + Param[1] +
                              "' AND EndTime<='" + Param[2] + "'";
                            break;
                        case 505:
                            ret = "SELECT TOP 9000 * FROM KQ_KQData WHERE IsSignIn=1 AND KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 506:
                            ret = "SELECT TOP 9000 * FROM KQ_KQData WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 507:
                            ret = "SELECT TOP 9000 * FROM KQ_KQDataFilter WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 508:
                            ret = "SELECT TOP 9000 * FROM KQ_KQReportDay WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 509:
                            ret = "SELECT TOP 9000 * FROM KQ_KQReportMonth WHERE KQYM>='" + Param[1] +
                              "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 510:
                            ret = "SELECT TOP 9000 * FROM KQ_KQReportWeek WHERE KQYM>='" + Param[1] +
                              "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 511:
                            ret = "SELECT TOP 9000 * FROM KQ_KQReportMonthDetail WHERE KQYM>='" + Param[1] +
                              "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 512:
                            ret = "SELECT TOP 9000 * FROM KQ_MJData WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 513:
                            ret = "SELECT TOP 9000 * FROM MJ_OpenData WHERE MJDateTime>='" + Param[1] +
                               "' AND MJDateTime<='" + Param[2] + "'";
                            break;
                        case 514:
                            ret = "SELECT TOP 9000 * FROM MJ_AlarmData WHERE AlarmTime>='" + Param[1] +
                              "' AND AlarmTime<='" + Param[2] + "'";
                            break;
                        case 515:
                            ret = "SELECT TOP 9000 * FROM MJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] +
                             "' AND KQDateTime<='" + Param[2] + "'";
                            break;
                        case 550:
                            ret = "SELECT TOP 9000 * FROM KQ_ReportRecords WHERE KQYM>='" + Param[1] +
                              "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 600:
                            ret = "DELETE FROM KQ_EmpShift WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_EmpShift WHERE EmpShiftDate>='" + Param[1] +
                              "' AND EmpShiftDate<='" + Param[2] + "'))";
                            break;
                        case 601:
                            ret = "DELETE FROM KQ_DepShift WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_DepShift WHERE DepShiftDate>='" + Param[1] +
                              "' AND DepShiftDate<='" + Param[2] + "'))";
                            break;
                        case 602:
                            ret = "DELETE FROM KQ_Holiday WHERE (HolidayID IN(SELECT TOP 9000 HolidayID FROM KQ_Holiday WHERE HolidayBeginTime>='" + Param[1] +
                              "' AND HolidayEndTime<='" + Param[2] + "'))";
                            break;
                        case 603:
                            ret = "DELETE FROM KQ_EmpDayOff WHERE (EmpDayOffID IN(SELECT TOP 9000 EmpDayOffID FROM KQ_EmpDayOff WHERE BeginTime>='" + Param[1] +
                              "' AND EndTime<='" + Param[2] + "'))";
                            break;
                        case 604:
                            ret = "DELETE FROM KQ_EmpOtSure WHERE (EmpOtSureID IN(SELECT TOP 9000 EmpOtSureID FROM KQ_EmpOtSure WHERE BeginTime>='" + Param[1] +
                              "' AND EndTime<='" + Param[2] + "'))";
                            break;
                        case 605:
                            ret = "DELETE FROM KQ_KQData WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_KQData WHERE IsSignIn=1 AND KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'))";
                            break;
                        case 606:
                            ret = "DELETE FROM KQ_KQDataPhoto WHERE GUID IN(SELECT TOP 9000 GUID FROM KQ_KQData WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "')\r\n";
                            ret += " DELETE FROM KQ_KQData WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_KQData WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'))";
                            break;
                        case 607:
                            ret = "DELETE FROM KQ_KQDataFilter WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_KQDataFilter WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'))";
                            //ret += " DELETE FROM KQ_KQDataFilterMark WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_KQDataFilterMark WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'))";
                            break;
                        case 608:
                            ret = "DELETE FROM KQ_KQReportDay WHERE (EmpNo IN(SELECT TOP 9000 EmpNo FROM KQ_KQReportDay WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "')) AND KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 609:
                            ret = "DELETE FROM KQ_KQReportMonth WHERE (EmpNo IN(SELECT TOP 9000 EmpNo FROM KQ_KQReportMonth WHERE KQYM>='" + Param[1] +
                              "' AND KQYM<='" + Param[2] + "')) AND KQYM>='" + Param[1] + "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 610:
                            ret = "DELETE FROM KQ_KQReportWeek WHERE (EmpNo IN(SELECT TOP 9000 EmpNo FROM KQ_KQReportWeek WHERE KQYM>='" + Param[1] +
                              "' AND KQYM<='" + Param[2] + "')) AND KQYM>='" + Param[1] + "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 611:
                            ret = "DELETE FROM KQ_KQReportMonthDetail WHERE (EmpNo IN(SELECT TOP 9000 EmpNo FROM KQ_KQReportMonthDetail WHERE KQYM>='" + Param[1] +
                              "' AND KQYM<='" + Param[2] + "')) AND KQYM>='" + Param[1] + "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 612:
                            ret = "DELETE FROM KQ_MJDataPhoto WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_MJData WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'))\r\n";
                            ret += "DELETE FROM KQ_MJData WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_MJData WHERE KQDate>='" + Param[1] +"' AND KQDate<='" + Param[2] + "'))";
                            break;
                        case 613:
                            ret = "DELETE FROM MJ_OpenData WHERE (GUID IN(SELECT TOP 9000 GUID FROM MJ_OpenData WHERE MJDateTime>='" + Param[1] +
                              "' AND MJDateTime<='" + Param[2] + "'))";
                            break;
                        case 614:
                            ret = "DELETE FROM MJ_AlarmData WHERE (GUID IN(SELECT TOP 9000 GUID FROM MJ_AlarmData WHERE AlarmTime>='" + Param[1] +
                              "' AND AlarmTime<='" + Param[2] + "'))";
                            break;
                        case 615:
                            ret = "DELETE FROM MJ_SeaPersonIDCard WHERE (GUID IN(SELECT TOP 9000 GUID FROM MJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] + "' AND KQDateTime<='" + Param[2] + "'))\r\n";
                            ret = "DELETE FROM MJ_SeaPersonIDCard WHERE (GUID IN(SELECT TOP 9000 GUID FROM MJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] +
                              "' AND KQDateTime<='" + Param[2] + "'))";
                            break;
                        case 650:
                            ret = "DELETE FROM KQ_ReportRecords WHERE (EmpNo IN(SELECT TOP 9000 EmpNo FROM KQ_ReportRecords WHERE KQYM>='" + Param[1] +
                              "' AND KQYM<='" + Param[2] + "')) AND KQYM>='" + Param[1] + "' AND KQYM<='" + Param[2] + "'";
                            break;
                        case 700:
                            ret = "SELECT TOP 9000 * FROM KQ_MJData WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'";
                            break;
                        case 701:
                            ret = "SELECT TOP 9000 * FROM MJ_OpenData WHERE MJDateTime>='" + Param[1] +
                               "' AND MJDateTime<='" + Param[2] + "'";
                            break;
                        case 702:
                            ret = "SELECT TOP 9000 * FROM MJ_AlarmData WHERE AlarmTime>='" + Param[1] +
                              "' AND AlarmTime<='" + Param[2] + "'";
                            break;
                        case 703:
                            ret = "SELECT TOP 9000 * FROM MJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] +
                              "' AND KQDateTime<='" + Param[2] + "'";
                            break;
                        case 800:
                            ret = "DELETE FROM KQ_MJDataPhoto WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_MJData WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'))\r\n";
                            ret += "DELETE FROM KQ_MJData WHERE (GUID IN(SELECT TOP 9000 GUID FROM KQ_MJData WHERE KQDate>='" + Param[1] +
                              "' AND KQDate<='" + Param[2] + "'))";
                            break;
                        case 801:
                            ret = "DELETE FROM MJ_OpenData WHERE (GUID IN(SELECT TOP 9000 GUID FROM MJ_OpenData WHERE MJDateTime>='" + Param[1] +
                              "' AND MJDateTime<='" + Param[2] + "'))";
                            break;
                        case 802:
                            ret = "DELETE FROM MJ_AlarmData WHERE (GUID IN(SELECT TOP 9000 GUID FROM MJ_AlarmData WHERE AlarmTime>='" + Param[1] +
                              "' AND AlarmTime<='" + Param[2] + "'))";
                            break;
                        case 803:
                            ret = "DELETE FROM MJ_SeaPersonIDCard WHERE (GUID IN(SELECT TOP 9000 GUID FROM MJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] + "' AND KQDateTime<='" + Param[2] + "'))\r\n";
                            ret = "DELETE FROM MJ_SeaPersonIDCard WHERE (GUID IN(SELECT TOP 9000 GUID FROM MJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] +
                              "' AND KQDateTime<='" + Param[2] + "'))";
                            break;
                    }
                    break;
                case DBCode.DB_000002:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSY_Oprt ORDER BY OprtIsSys,OprtNo";
                            break;
                        case 1:
                            ret = "INSERT INTO SY_Oprt(OprtNo,OprtName,OprtPWD,OprtDesc,OprtIsSys) VALUES('" + Param[1] + "','" +
                              Param[2] + "','" + Param[3] + "','" + Param[4] + "',0)";
                            break;
                        case 2:
                            ret = "UPDATE SY_Oprt SET OprtNo='" + Param[1] + "',OprtName='" + Param[2] + "',OprtPWD='" + Param[3] +
                              "',OprtDesc='" + Param[4] + "' WHERE OprtNo='" + Param[5] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM SY_Oprt WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM SY_Oprt WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM SY_Oprt WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM SY_Oprt WHERE OprtNo<>'" + Param[1] + "' AND OprtNo='" + Param[2] + "'";
                            break;
                        case 101:
                            ret = "DELETE FROM SY_OprtPower WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 102:
                            ret = "INSERT INTO SY_OprtPower(OprtNo,ModuleID,SubID) VALUES('" + Param[1] + "','" +
                              Param[2] + "','" + Param[3] + "')";
                            break;
                        case 103:
                            ret = "SELECT * FROM SY_OprtPower WHERE OprtNo='" + Param[1] + "' AND ModuleID='" + Param[2] +
                              "' AND SubID='" + Param[3] + "'";
                            break;
                        case 201:
                            ret = "SELECT * FROM VSY_MacParam WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 202:
                            ret = "INSERT INTO SY_MacParam([GUID],MacSN, DoorMagneticType, Antiback," +
                                   "ServerRequest,UseAlarm,GlogWarning,DoorMagneticDelay,AlarmDelay,DiMacNo,OpenDoorDelay," +
                                   "Managers,Volume,MutiUser,ShowResultTime,ReverifyTime,ScreensaversTime,SleepTime," +
                                   "WiegandType,ServerIPAddress,ServerPort,WiegandOutput,WiegandInput) VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" +
                                   Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" + Param[9] + "','" +
                                   Param[10] + "','" + Param[11] + "','" + Param[12] + "','" + Param[13] + "','" + Param[14] + "','" +
                                   Param[15] + "','" + Param[16] + "','" + Param[17] + "','" + Param[18] + "','" + Param[19] + "','" + Param[20] + "','" + Param[21] + "','" + Param[22] + "')";
                            break;
                        case 203:
                            ret = "UPDATE SY_MacParam SET DoorMagneticType='" + Param[2] + "',Antiback='" + Param[3] + "',ServerRequest='" +
                              Param[4] + "',UseAlarm='" + Param[5] + "',GlogWarning='" + Param[6] + "',DoorMagneticDelay='" +
                              Param[7] + "',AlarmDelay='" + Param[8] + "',MacSN='" + Param[9] + "',OpenDoorDelay='" +
                              Param[10] + "',Managers='" + Param[11] + "',Volume='" + Param[12] + "',MutiUser='" +
                              Param[13] + "',ShowResultTime='" + Param[14] + "',ReverifyTime='" + Param[15] + "',ScreensaversTime='" +
                              Param[16] + "',SleepTime='" + Param[17] + "',WiegandType='" + Param[18] + "',ServerIPAddress='" +
                              Param[19] + "',ServerPort='" + Param[20] + "',WiegandOutput='" + Param[21] + "',WiegandInput='" + Param[22] + "' WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 204:
                            ret = "UPDATE SY_MacParam SET MacSN='" + Param[2] + "',ServerRequest='" + Param[3] + "',ServerIPAddress='" +
                              Param[4] + "',ServerPort='" + Param[5] + "' WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 205:
                            ret = "DELETE FROM VSY_MacParam WHERE MacSN='" + Param[1] + "'";
                            break;
                    }
                    break;

                case DBCode.DB_000100:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT ISNULL(MAX(DepartID),0) AS MaxID FROM RS_Depart WHERE DepartUpID='" +
                              Param[1] + "' AND ISNUMERIC(DepartID)=1";
                            break;
                        case 1:
                            ret = "SELECT * FROM RS_Depart WHERE DepartID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM RS_Depart WHERE DepartUpID='" + Param[1] + "' ORDER BY DepartID";
                            break;
                        case 3:
                            ret = "SELECT * FROM RS_Depart WHERE DepartID<>'" + Param[1] + "' AND DepartID='" + Param[2] + "'";
                            break;
                        case 4:
                            ret = "INSERT INTO RS_Depart(DepartID,DepartName,DepartUpID,DepartMemo) VALUES('" + Param[1] + "','" +
                              Param[2] + "','" + Param[3] + "','" + Param[4] + "')";
                            break;
                        case 5:
                            ret = "UPDATE RS_Depart SET DepartID='" + Param[1] + "',DepartName='" + Param[2] + "',DepartUpID='" +
                              Param[3] + "',DepartMemo='" + Param[4] + "' WHERE DepartID='" + Param[5] + "'";
                            break;
                        case 6:
                            ret = "DELETE FROM RS_Depart WHERE DepartID='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "SELECT * FROM VRS_Emp WHERE DepartID='" + Param[1] + "'";
                            if (Param.Length > 2) ret += Param[2];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 100:
                            ret = "UPDATE RS_Emp SET DepartID='" + Param[1] + "' WHERE DepartID='" + Param[2] + "'";
                            break;
                        case 101:
                            ret = "UPDATE KQ_ShiftDepart SET DepartID='" + Param[1] + "' WHERE DepartID='" + Param[2] + "'";
                            break;
                        case 102:
                            ret = "UPDATE KQ_DepShift SET DepartID='" + Param[1] + "' WHERE DepartID='" + Param[2] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000101:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT *,CASE FingerPrivilege WHEN 1 THEN '" + Param[2] + "' ELSE '" + Param[1] +
                              "' END AS FingerPrivilegeName FROM VRS_Emp WHERE IsDimission=0";
                            break;
                        case 1:
                            ret = " ORDER BY EmpNo";
                            break;
                        case 2:
                            ret = Param[1] + GetEmpInfoSQL("0", Param[3]) + Param[2];
                            break;
                        case 3:
                            ret = "SELECT * FROM RS_Depart WHERE DepartName='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT MAX(DepartID) AS DepartID FROM RS_Depart";
                            break;
                        case 5:
                            ret = "SELECT EmpNo FROM RS_Emp WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "INSERT INTO RS_Emp(EmpNo,EmpName,EmpSex,DepartID,EmpHireDate,EmpCertNo,CardNo10,CardNo81," +
                              "CardNo82,FingerNo,FingerPrivilege,IsAttend,RuleID,EmpAddress,EmpPhoneNo,EmpMemo,IsDimission," +
                              "EmpGZ,[PassWord],StartDate,EndDate) VALUES('" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] +
                              "'," + Param[5] + ",'" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" + Param[9] + "'," +
                              Param[10] + "," + Param[11] + "," + Param[12] + ",'" + Param[13] + "','" + Param[14] + "','" +
                              Param[15] + "','" + Param[16] + "',0," + Param[17] + ",'" + Param[18] + "'," + Param[19] + "," + Param[20] + ")";
                            break;
                        case 7:
                            ret = "UPDATE RS_Emp SET EmpPhotoImage=@EmpPhotoImage WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 8:
                            ret = "DELETE FROM RS_EmpFingerInfo WITH (TABLOCKX) WHERE FingerNo=(SELECT FingerNo FROM RS_Emp WITH (TABLOCKX) WHERE EmpNo='" +
                              Param[1] + "')";
                            break;
                        case 9:
                            ret = "DELETE FROM RS_Emp WITH (TABLOCKX) WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 10:
                            ret = "SELECT EmpNo FROM RS_Emp WHERE FingerNo=" + Param[1];
                            break;
                        case 11:
                            ret = "SELECT ISNULL(MAX(FingerNo),0)+1 AS MaxID FROM RS_Emp";
                            break;
                        case 12:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 13:
                            ret = "SELECT EmpPhotoImage,EmpPhoto FROM RS_Emp WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 14:
                            ret = "SELECT EmpNo,EmpName FROM RS_Emp WHERE CardNo10='" + Param[1] + "'";
                            break;
                        case 15:
                            ret = "SELECT EmpNo FROM RS_Emp WHERE EmpNo<>'" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 16:
                            ret = "SELECT EmpNo FROM RS_Emp WHERE EmpNo<>'" + Param[1] + "' AND CardNo10='" + Param[2] + "'";
                            break;
                        case 17:
                            ret = "SELECT EmpNo FROM RS_Emp WHERE EmpNo<>'" + Param[1] + "' AND FingerNo=" + Param[2];
                            break;
                        case 18:
                            ret = "UPDATE RS_Emp SET EmpNo='" + Param[1] + "',EmpName='" + Param[2] + "',EmpSex='" +
                              Param[3] + "',DepartID='" + Param[4] + "',EmpHireDate='" + Param[5] + "',EmpCertNo='" +
                              Param[6] + "',CardNo10='" + Param[7] + "',CardNo81='" + Param[8] + "',CardNo82='" +
                              Param[9] + "',FingerNo=" + Param[10] + ",FingerPrivilege=" + Param[11] + ",IsAttend=" +
                              Param[12] + ",RuleID='" + Param[13] + "',EmpAddress='" + Param[14] + "',EmpPhoneNo='" +
                              Param[15] + "',EmpMemo='" + Param[16] + "',EmpGZ=" + Param[17] + ",[PassWord]='" +
                              Param[18] + "',StartDate=" + Param[19] + ",EndDate=" + Param[20] + " WHERE EmpNo='" + Param[21] + "'";
                            break;
                        case 19:
                            ret = "UPDATE RS_EmpFingerInfo SET FingerNo=" + Param[1] +
                              " WHERE FingerNo=(SELECT FingerNo FROM RS_Emp WHERE EmpNo='" + Param[2] + "')";
                            break;
                        case 20:
                            ret = "UPDATE RS_Emp SET CardNo10='" + Param[1] + "',CardNo81='" + Param[2] + "',CardNo82='" +
                              Param[3] + "' WHERE EmpNo='" + Param[4] + "'";
                            break;
                        case 21:
                            ret = "SELECT EmpNo,EmpName FROM RS_Emp WHERE FingerNo=" + Param[1];
                            break;
                        case 22:
                            ret = "SELECT MAX(EmpNo) AS MaxEmpNo FROM RS_Emp";
                            break;
                        case 23:
                            ret = "EXEC PGetMaxIDFromTable 'FingerNo','RS_Emp'";
                            break;
                        case 24:
                            ret = "UPDATE RS_Emp SET EmpPhoto=@EmpPhoto WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 25:
                            ret = "SELECT EmpPhoto FROM RS_Emp WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 26:
                            ret = "SELECT EmpNo,EmpName,EmpSex,DepartID,EmpHireDate,EmpCertNo,CardNo10,PassWord," +
                              "FingerNo,FingerPrivilege,IsAttend,EmpAddress,EmpPhoneNo,IsDimission," +
                              "EmpPhotoImage, EmpPhoto, EmpPhotoCount,EmpMemo,StartDate,EndDate FROM RS_Emp WHERE 1=2";
                            break;
                        case 27:
                            ret = "SELECT FingerNo,EmpNo,EmpHireDate FROM RS_Emp";
                            break;
                        case 28:
                            ret = "SELECT FingerNo,EmpNo FROM RS_EmpDynamicInfo";
                            break;
                        case 29:
                            ret = "SELECT * FROM RS_EmpDynamicInfo where 1=2";
                            break;
                        case 30:
                            ret = "DELETE FROM RS_EmpFingerInfo WHERE FingerNo=" + Param[1] + " AND FingerBkNo=" + Param[2];
                            break;
                        case 31:
                            ret = "UPDATE RS_Emp SET EmpFingerCount_Star=" + Param[2] + ",EmpFaceCount_Star=" + Param[3] + ",EmpPalmVeinCount_Star=" + Param[4] + " WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 32:
                            ret = "SELECT * FROM RS_EmpDynamicInfo";
                            break;
                        case 33:
                            ret = "DELETE FROM RS_EmpDynamicInfo WITH (TABLOCKX) WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 34:
                            ret = "SELECT * FROM RS_EmpDynamicInfo WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 35:
                            ret = "UPDATE RS_Emp SET EmpPhotoCount=" + Param[2] + " WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 36:
                            ret = "UPDATE RS_Emp SET StartDate=" + Param[2] + ",EndDate=" + Param[3] + " WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 37:
                            ret = "SELECT EmpNo,EmpName,EmpSex,DepartID,EmpHireDate,EmpCertNo,CardNo10,PassWord," +
                              "FingerNo,FingerPrivilege,IsAttend,EmpAddress,EmpPhoneNo,IsDimission," +
                              "EmpPhotoImage,EmpMemo,StartDate,EndDate FROM RS_Emp WHERE 1=2";
                            break;
                        case 38:
                            ret = "UPDATE RS_Emp SET DepartID='" + Param[1] + "' WHERE EmpNo IN(" + Param[2] + ")";
                            break;
                        case 39:
                            ret = "SELECT * FROM RS_EmpFingerInfo WHERE FingerNo=" + Param[1] + " AND FingerBkNo=" + Param[2] + "";
                            break;
                        case 101:
                            ret = "SELECT EmpSex,COUNT(1) AS RecCount " +
                              "FROM VRS_Emp WHERE IsDimission=0 GROUP BY EmpSex";
                            break;
                        case 102:
                            ret = "SELECT DepartName AS DepartName,COUNT(1) AS RecCount " +
                              "FROM VRS_Emp WHERE IsDimission=0 GROUP BY DepartName";
                            break;
                        case 201:
                            ret = "SELECT * FROM VRS_Emp WHERE CardNo10='" + Param[1] + "'";
                            break;
                        case 202:
                            ret = "UPDATE RS_Emp SET FingerPrivilege=" + Param[1] + " WHERE EmpNo='" + Param[2] + "'";
                            break;
                        case 203:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpNo='" + Param[1] + "'";
                            if (Param.Length > 2) ret += Param[2];
                            break;
                        case 204:
                            ret = "SELECT EmpNo FROM RS_Emp WHERE EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%'";
                            break;
                        case 205:
                            ret = "SELECT DepartID FROM RS_Depart WHERE DepartID='" + Param[1] + "' OR DepartName LIKE '" + Param[1] + "%'";
                            break;
                        case 206:
                            ret = "SELECT * FROM VRS_Emp WHERE (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')";
                            if (Param.Length > 2) ret += Param[2];
                            break;
                        case 207:
                            ret = "UPDATE RS_Emp SET EmpName='" + Param[2] + "' WHERE FingerNo=" + Param[1];
                            break;
                        case 208:
                            ret = " AND IsDimission=0";
                            break;
                        case 209:
                            ret = Param[1];
                            if (Param[3] != "") ret += " AND (DepartID='" + Param[3] + "' OR DepartID IN (" + Param[4] + ")) ";
                            ret += Param[2];
                            break;
                        case 210:
                            ret = "UPDATE RS_Emp SET CardNo10='" + Param[1] + "' WHERE FingerNo=" + Param[2] + "";
                            break;
                        case 211:
                            ret = "UPDATE RS_Emp SET [PassWord]='" + Param[1] + "' WHERE FingerNo=" + Param[2] + "";
                            break;
                        case 212:
                            ret = "DELETE FROM RS_EmpFingerInfo WHERE FingerFlag=" + Param[1] + " AND FingerNo=" +
                              Param[2] + " AND FingerBkNo=" + Param[3];
                            break;
                        case 213:
                            ret = "UPDATE RS_Emp SET EmpFingerCount=0,EmpFaceCount=0,EmpPWCount=0,EmpCardCount=0,EmpPalmVeinCount=0";
                            break;
                        case 215:
                            ret = "UPDATE RS_Emp SET EmpFingerCount=0,EmpFaceCount=0,EmpPWCount=0,EmpCardCount=0,EmpPalmVeinCount=0 WHERE FingerNo=" + Param[1] + "";
                            break;
                        case 300:
                            if (Param[1] == "0")
                                ret = "EmpFingerCount";
                            else if (Param[1] == "1")
                                ret = "EmpFaceCount";
                            else if (Param[1] == "2")
                                ret = "EmpPWCount";
                            else if (Param[1] == "3")
                                ret = "EmpCardCount";
                            else
                                ret = "EmpPalmVeinCount";
                            ret = "UPDATE RS_Emp SET " + ret + "=" + Param[2] + " WHERE FingerNo=" + Param[3];
                            break;
                        case 301:
                            ret = "SELECT FingerNo,COUNT(1) AS RecCount FROM RS_EmpFingerInfo " +
                              "WHERE FingerBkNo>=0 AND FingerBkNo<=9 GROUP BY FingerNo";
                            break;
                        case 302:
                            ret = "SELECT FingerNo,COUNT(1) AS RecCount FROM RS_EmpFingerInfo " +
                              "WHERE FingerBkNo=12 GROUP BY FingerNo";
                            break;
                        case 303:
                            ret = "SELECT FingerNo,COUNT(1) AS RecCount FROM RS_EmpFingerInfo " +
                              "WHERE FingerBkNo=10 GROUP BY FingerNo";
                            break;
                        case 304:
                            ret = "SELECT FingerNo,COUNT(1) AS RecCount FROM RS_EmpFingerInfo " +
                              "WHERE FingerBkNo=11 GROUP BY FingerNo";
                            break;
                        case 305:
                            ret = "SELECT FingerNo,COUNT(1) AS RecCount FROM RS_EmpFingerInfo " +
                              "WHERE FingerBkNo>=13 AND FingerBkNo<=16 GROUP BY FingerNo";
                            break;
                        case 306:
                            ret = "SELECT FingerNo,CardNo10,CardNo81,CardNo82,EmpNo,EmpName,DepartID,DepartName FROM VRS_Emp WHERE EmpNo='" + Param[1] + "'";
                            if (Param.Length > 2) ret += Param[2];
                            break;
                        case 400:
                            ret = "UPDATE RS_EmpPhoto SET EmpImage=@EmpImage WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 401:
                            ret = "UPDATE RS_EmpPhoto SET EmpPhoto=@EmpPhoto WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 402:
                            ret = "SELECT EmpImage,EmpPhoto FROM RS_EmpPhoto WHERE EmpNo='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000102:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT *,CASE FingerPrivilege WHEN 1 THEN '" + Param[2] + "' ELSE '" + Param[1] +
                              "' END AS FingerPrivilegeName FROM VRS_EmpDimission WHERE 1=1";
                            break;
                        case 1:
                            ret = " ORDER BY EmpNo";
                            break;
                        case 2:
                            ret = "UPDATE RS_Emp SET DimissionOprt=NULL,DimissionDate=NULL,DimissionReason=NULL,IsDimission=0 " +
                              "WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM VRS_EmpDimission WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "UPDATE RS_Emp SET DimissionOprt='" + Param[1] + "',DimissionDate='" + Param[2] +
                              "',DimissionReason='" + Param[3] + "',IsDimission=1 WHERE EmpNo='" + Param[4] + "'";
                            break;
                        case 5:
                            ret = Param[1] + GetEmpInfoSQL("0", Param[3]) + Param[2];
                            break;
                        case 6:
                            ret = Param[1];
                            if (Param[3] != "") ret += " AND (DepartID='" + Param[3] + "' OR DepartID IN (" + Param[4] + ")) ";
                            ret += Param[2];
                            break;
                        case 7:
                            ret = "SELECT FingerNo,FingerBkNo FROM RS_EmpFingerInfo " +
                              "WHERE FingerNo IN(SELECT FingerNo FROM VRS_EmpDimission) ORDER BY FingerNo,FingerBkNo";
                            break;
                    }
                    break;

                case DBCode.DB_000200:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_Rule ORDER BY RuleID";
                            break;
                        case 3:
                            ret = "SELECT COUNT(1) AS RecCount FROM RS_Emp WHERE RuleID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT COUNT(1) AS RecCount FROM RS_Depart WHERE RuleID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "DELETE FROM KQ_Rule WHERE RuleID='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_Rule WHERE RuleID='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "INSERT INTO KQ_Rule(RuleID,RuleName,RuleLateIgnore,RuleLeaveIgnore,RuleDupLimit," +
                              "RuleLateLeaveCalHrs,RuleLateHrs,RuleLeaveHrs,RuleAheadHrs,RuleAheadMins,RuleDeferHrs," +
                              "RuleDeferMins,RuleReadLate,RuleReadLeave,RuleReadWorkHrs,RuleSunday,RuleMonday,RuleTuesday," +
                              "RuleWednesday,RuleThursday,RuleFriday,RuleSaturday,RuleNoRule,RuleRestDays,RuleNSAllowTimeS," +
                              "RuleNSAllowTimeL,RuleHeadAndTail,RuleLeaveOvertime) VALUES('" + Param[1] + "','" + Param[2] + "'," + Param[3] + "," + Param[4] + "," +
                              Param[5] + "," + Param[6] + "," + Param[7] + "," + Param[8] + "," + Param[9] + "," +
                              Param[10] + "," + Param[11] + "," + Param[12] + "," + Param[13] + "," + Param[14] + "," +
                              Param[15] + "," + Param[16] + "," + Param[17] + "," + Param[18] + "," + Param[19] + "," +
                              Param[20] + "," + Param[21] + "," + Param[22] + "," + Param[23] + "," + Param[24] + ",'" +
                              Param[25] + "','" + Param[26] + "'," + Param[27] + "," + Param[28] + ")";
                            break;
                        case 8:
                            ret = "UPDATE KQ_Rule SET RuleName='" + Param[1] + "',RuleLateIgnore=" + Param[2] +
                              ",RuleLeaveIgnore=" + Param[3] + ",RuleDupLimit=" + Param[4] + ",RuleLateLeaveCalHrs=" +
                              Param[5] + ",RuleLateHrs=" + Param[6] + ",RuleLeaveHrs=" + Param[7] + ",RuleAheadHrs=" +
                              Param[8] + ",RuleAheadMins=" + Param[9] + ",RuleDeferHrs=" + Param[10] + ",RuleDeferMins=" +
                              Param[11] + ",RuleReadLate=" + Param[12] + ",RuleReadLeave=" + Param[13] + ",RuleReadWorkHrs=" +
                              Param[14] + ",RuleSunday=" + Param[15] + ",RuleMonday=" + Param[16] + ",RuleTuesday=" + Param[17] +
                              ",RuleWednesday=" + Param[18] + ",RuleThursday=" + Param[19] + ",RuleFriday=" + Param[20] +
                              ",RuleSaturday=" + Param[21] + ",RuleNoRule=" + Param[22] + ",RuleRestDays=" + Param[23] +
                              ",RuleNSAllowTimeS='" + Param[24] + "',RuleNSAllowTimeL='" + Param[25] +
                              "',RuleHeadAndTail=" + Param[26] + ",RuleLeaveOvertime=" + Param[27] + " WHERE RuleID='" + Param[28] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000201:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_RuleCalc ORDER BY SortID";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_RuleCalc WHERE SortID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpOtSure WHERE SortID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpDayOff WHERE SortID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM KQ_RuleCalc WHERE SortID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID," +
                              "OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,AbsenceRate) VALUES('" +
                              Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" + Param[4] + "'," + Param[5] + ",'" +
                              Param[6] + "'," + Param[7] + "," + Param[8] + "," + Param[9] + "," + Param[10] + "," +
                              Param[11] + "," + Param[12] + "," + Param[13] + ")";
                            break;
                        case 6:
                            ret = "UPDATE KQ_RuleCalc SET SortName='" + Param[1] + "',CalcTypeID=" + Param[2] + ",CalcTypeName='" +
                              Param[3] + "',OvertimeTypeID=" + Param[4] + ",OvertimeTypeName='" + Param[5] + "',Start=" +
                              Param[6] + ",Tune=" + Param[7] + ",[Integer]=" + Param[8] + ",WorkRate=" + Param[9] +
                              ",OvertimeRate=" + Param[10] + ",LeaveRate=" + Param[11] + ",AbsenceRate=" + Param[12] +
                              " WHERE SortID='" + Param[13] + "'";
                            break;
                        case 7:
                            ret = "SELECT MAX(SortID) AS SortID FROM KQ_RuleCalc WHERE CalcTypeID=" + Param[1];
                            break;
                        case 8:
                            ret = "SELECT SortName FROM KQ_RuleCalc WHERE CalcTypeID=2 ORDER BY SortID";
                            break;
                    }
                    break;
                case DBCode.DB_000202:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_RuleEmp ORDER BY EmpNo";
                            break;
                        case 1:
                            ret = "UPDATE RS_Emp SET RuleID='' WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "UPDATE RS_Emp SET RuleID='" + Param[1] + "' WHERE EmpNo='" + Param[2] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000203:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_RuleDepart ORDER BY DepartID";
                            break;
                        case 1:
                            ret = "UPDATE RS_Depart SET RuleID='' WHERE DepartID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_RuleDepart WHERE DepartID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "UPDATE RS_Depart SET RuleID='" + Param[1] + "' WHERE DepartID='" + Param[2] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000204:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_Shift ORDER BY ShiftID";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_Shift WHERE ShiftID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_RuleCalc WHERE CalcTypeID<>2 ORDER BY SortID";
                            break;
                        case 3:
                            ret = "SELECT * FROM KQ_Shift WHERE ShiftID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM KQ_ShiftDepart WHERE ShiftID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "INSERT INTO KQ_Shift(ShiftID,ShiftName,Signin1,Signout1,ShiftAhead1,ShiftDefer1,Drift1," +
                              "SigninTime1,SignoutTime1,SortID1,Signin2,Signout2,ShiftAhead2,ShiftDefer2,Drift2,SigninTime2," +
                              "SignoutTime2,SortID2,Signin3,Signout3,ShiftAhead3,ShiftDefer3,Drift3,SigninTime3,SignoutTime3," +
                              "SortID3,Signin4,Signout4,ShiftAhead4,ShiftDefer4,Drift4,SigninTime4,SignoutTime4,SortID4,Signin5," +
                              "Signout5,ShiftAhead5,ShiftDefer5,Drift5,SigninTime5,SignoutTime5,SortID5,WorkHours,OverHours," +
                              "IsAuto,ShiftCount) VALUES('" + Param[1] + "','" + Param[2] + "'," + Param[3] + "," + Param[4] + "," +
                              Param[5] + "," + Param[6] + "," + Param[7] + ",'" + Param[8] + "','" + Param[9] + "','" +
                              Param[10] + "'," + Param[11] + "," + Param[12] + "," + Param[13] + "," + Param[14] + "," +
                              Param[15] + ",'" + Param[16] + "','" + Param[17] + "','" + Param[18] + "'," + Param[19] + "," +
                              Param[20] + "," + Param[21] + "," + Param[22] + "," + Param[23] + ",'" + Param[24] + "','" +
                              Param[25] + "','" + Param[26] + "'," + Param[27] + "," + Param[28] + "," + Param[29] + "," +
                              Param[30] + "," + Param[31] + ",'" + Param[32] + "','" + Param[33] + "','" + Param[34] + "'," +
                              Param[35] + "," + Param[36] + "," + Param[37] + "," + Param[38] + "," + Param[39] + ",'" +
                              Param[40] + "','" + Param[41] + "','" + Param[42] + "'," + Param[43] + "," + Param[44] + "," +
                              Param[45] + "," + Param[46] + ")";
                            break;
                        case 6:
                            ret = "UPDATE KQ_Shift SET ShiftName='" + Param[1] + "',Signin1=" + Param[2] + ",Signout1=" +
                              Param[3] + ",ShiftAhead1=" + Param[4] + ",ShiftDefer1=" + Param[5] + ",Drift1=" + Param[6] +
                              ",SigninTime1='" + Param[7] + "',SignoutTime1='" + Param[8] + "',SortID1='" + Param[9] +
                              "',Signin2=" + Param[10] + ",Signout2=" + Param[11] + ",ShiftAhead2=" + Param[12] + ",ShiftDefer2=" +
                              Param[13] + ",Drift2=" + Param[14] + ",SigninTime2='" + Param[15] + "',SignoutTime2='" + Param[16] +
                              "',SortID2='" + Param[17] + "',Signin3=" + Param[18] + ",Signout3=" + Param[19] + ",ShiftAhead3=" +
                              Param[20] + ",ShiftDefer3=" + Param[21] + ",Drift3=" + Param[22] + ",SigninTime3='" + Param[23] +
                              "',SignoutTime3='" + Param[24] + "',SortID3='" + Param[25] + "',Signin4=" + Param[26] + ",Signout4=" +
                              Param[27] + ",ShiftAhead4=" + Param[28] + ",ShiftDefer4=" + Param[29] + ",Drift4=" + Param[30] +
                              ",SigninTime4='" + Param[31] + "',SignoutTime4='" + Param[32] + "',SortID4='" + Param[33] +
                              "',Signin5=" + Param[34] + ",Signout5=" + Param[35] + ",ShiftAhead5=" + Param[36] + ",ShiftDefer5=" +
                              Param[37] + ",Drift5=" + Param[38] + ",SigninTime5='" + Param[39] + "',SignoutTime5='" + Param[40] +
                              "',SortID5='" + Param[41] + "',WorkHours=" + Param[42] + ",OverHours=" + Param[43] + ",IsAuto=" +
                              Param[44] + ",ShiftCount=" + Param[45] + " WHERE ShiftID='" + Param[46] + "'";
                            break;
                        case 7:
                            ret = "INSERT INTO KQ_ShiftDepart(ShiftID,DepartID) VALUES('" + Param[1] + "','" + Param[2] + "')";
                            break;
                        case 8:
                            ret = "DELETE FROM KQ_ShiftDepart WHERE ShiftID='" + Param[1] + "'";
                            break;
                        case 9:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpShift WHERE ShiftNo='" + Param[1] + "'";
                            break;
                        case 10:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_DepShift WHERE ShiftNo='" + Param[1] + "'";
                            break;
                        case 11:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_ShiftRuleData WHERE ShiftID='" + Param[1] + "'";
                            break;
                        case 12:
                            ret = "DELETE FROM KQ_ShiftDepart WHERE ShiftID='" + Param[1] + "'";
                            break;
                        case 13:
                            ret = "SELECT dbo.GetTimeSecond('" + Param[1] + "','" + Param[2] + "') AS TimeSecond";
                            break;
                    }
                    break;
                case DBCode.DB_000205:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_ShiftRule ORDER BY ShiftRuleID";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_ShiftRuleData WHERE ShiftRuleID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "DELETE FROM KQ_ShiftRule WHERE ShiftRuleID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM KQ_ShiftRule WHERE ShiftRuleID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM KQ_ShiftRuleData WHERE ShiftRuleID='" + Param[1] + "' ORDER BY ShiftRulecycNo";
                            break;
                        case 5:
                            ret = "INSERT INTO KQ_ShiftRule(ShiftRuleID,ShiftRuleName,ShiftRulecycID,ShiftRulecycName," +
                              "ShiftRulecyc) VALUES('" + Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" + Param[4] +
                              "'," + Param[5] + ")";
                            break;
                        case 6:
                            ret = "UPDATE KQ_ShiftRule SET ShiftRuleName='" + Param[1] + "',ShiftRulecycID=" + Param[2] +
                              ",ShiftRulecycName='" + Param[3] + "',ShiftRulecyc=" + Param[4] + " WHERE ShiftRuleID='" +
                              Param[5] + "'";
                            break;
                        case 7:
                            ret = "DELETE FROM KQ_ShiftRuleData WHERE ShiftRuleID='" + Param[1] + "'";
                            break;
                        case 8:
                            ret = "INSERT INTO KQ_ShiftRuleData(ShiftRuleID,ShiftRulecycNo,ShiftID) VALUES('" + Param[1] + "'," +
                                Param[2] + ",'" + Param[3] + "')";
                            break;
                    }
                    break;
                case DBCode.DB_000206:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM KQ_EmpShift WHERE EmpNo='" + Param[1] + "' AND YEAR(EmpShiftDate)=" +
                              Param[2] + " AND MONTH(EmpShiftDate)=" + Param[3];
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_EmpShift WHERE EmpNo='" + Param[1] + "' AND YEAR(EmpShiftDate)=" +
                              Param[2] + " AND MONTH(EmpShiftDate)=" + Param[3];
                            break;
                        case 2:
                            ret = "INSERT INTO KQ_EmpShift(GUID,EmpNo,EmpShiftDate,ShiftNo) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "')";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_EmpShift WHERE EmpNo='" + Param[1] + "' AND EmpShiftDate>='" +
                              Param[2] + "' AND EmpShiftDate<='" + Param[3] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000207:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM KQ_DepShift WHERE DepartID='" + Param[1] + "' AND YEAR(DepShiftDate)=" +
                              Param[2] + " AND MONTH(DepShiftDate)=" + Param[3];
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_DepShift WHERE DepartID='" + Param[1] + "' AND YEAR(DepShiftDate)=" +
                              Param[2] + " AND MONTH(DepShiftDate)=" + Param[3];
                            break;
                        case 2:
                            ret = "INSERT INTO KQ_DepShift(GUID,DepartID,DepShiftDate,ShiftNo) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "')";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_DepShift WHERE DepartID='" + Param[1] + "' AND DepShiftDate>='" +
                              Param[2] + "' AND DepShiftDate<='" + Param[3] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000208:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VRS_Emp WHERE 1=1 ";
                            if (Param[1] != "") ret += " AND EmpNo='" + Param[1] + "'";
                            if (Param[2] != "") ret += " AND (DepartID='" + Param[2] + "' OR DepartID IN (" + Param[3] + ")) ";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 1:
                            ret = "EXEC PKQ_CalcEmpShiftsTotal '" + Param[1] + "','" + Param[2] + "','" + Param[3] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_EmpShiftsTotal WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            if (Param[3] != "") ret += " AND EmpNo='" + Param[3] + "'";
                            if (Param[4] != "") ret += " AND (DepartID='" + Param[4] + "' OR DepartID IN (" + Param[5] + ")) ";
                            ret += " ORDER BY EmpNo,KQDate";
                            break;
                    }
                    break;
                case DBCode.DB_000209:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_Holiday ORDER BY HolidayBeginTime";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_Holiday WHERE HolidayID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM KQ_Holiday WHERE HolidayID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "INSERT INTO KQ_Holiday(HolidayID,HolidayName,HolidayBeginTime,HolidayEndTime) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "')";
                            break;
                        case 4:
                            ret = "UPDATE KQ_Holiday SET HolidayName='" + Param[1] + "',HolidayBeginTime='" + Param[2] +
                              "',HolidayEndTime='" + Param[3] + "' WHERE HolidayID='" + Param[4] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000210:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_EmpDayOff ORDER BY EmpNo,BeginTime";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_EmpDayOff WHERE EmpDayOffID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_RuleCalc WHERE CalcTypeID=2 ORDER BY SortID";
                            break;
                        case 3:
                            ret = "SELECT * FROM VKQ_EmpDayOff WHERE EmpDayOffID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "INSERT INTO KQ_EmpDayOff(EmpDayOffID,EmpNo,SortID,BeginTime,EndTime,DayOffReason,OprtNo," +
                              "OprtDate) VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] +
                              "','" + Param[5] + "','" + Param[6] + "',getdate())";
                            break;
                        case 5:
                            ret = "UPDATE KQ_EmpDayOff SET SortID='" + Param[1] + "',BeginTime='" + Param[2] + "',EndTime='" +
                              Param[3] + "',DayOffReason='" + Param[4] + "',OprtNo='" + Param[5] +
                              "',OprtDate=getdate() WHERE EmpDayOffID='" + Param[6] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM VKQ_EmpDayOff WHERE 1=1";
                            break;
                        case 7:
                            ret = " ORDER BY EmpNo,BeginTime";
                            break;
                        case 8:
                            ret = GetSQL(code, new string[] { "6" });
                            if (Param[1] != "") ret += GetEmpInfoSQL("0", Param[1]);
                            break;
                        case 9:
                            ret = Param[1];
                            if (Param[3] != "") ret += " AND EmpNo='" + Param[3] + "'";
                            if (Param[4] != "") ret += " AND (DepartID='" + Param[4] + "' OR DepartID IN (" + Param[5] + ")) ";
                            ret += Param[2];
                            break;
                        case 10:
                            ret = "SELECT * FROM VKQ_EmpDayOff WHERE EmpNo='" + Param[1] + "' AND BeginTime='" + Param[2] + "' " +
                                "AND EndTime='" + Param[3] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000211:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_EmpOtSure ORDER BY EmpNo,BeginTime";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_EmpOtSure WHERE EmpOtSureID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_RuleCalc WHERE CalcTypeID=1 ORDER BY SortID";
                            break;
                        case 3:
                            ret = "SELECT * FROM VKQ_EmpOtSure WHERE EmpOtSureID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "INSERT INTO KQ_EmpOtSure(EmpOtSureID,EmpNo,SortID,BeginTime,EndTime,AheadHrs,AheadMins," +
                              "DeferHrs,DeferMins,OtReason,OprtNo,OprtDate) VALUES(newid(),'" + Param[1] + "','" + Param[2] +
                              "','" + Param[3] + "','" + Param[4] + "'," + Param[5] + "," + Param[6] + "," + Param[7] + "," +
                              Param[8] + ",'" + Param[9] + "','" + Param[10] + "',getdate())";
                            break;
                        case 5:
                            ret = "UPDATE KQ_EmpOtSure SET SortID='" + Param[1] + "',BeginTime='" + Param[2] + "',EndTime='" +
                              Param[3] + "',AheadHrs=" + Param[4] + ",AheadMins=" + Param[5] + ",DeferHrs=" + Param[6] +
                              ",DeferMins=" + Param[7] + ",OtReason='" + Param[8] + "',OprtNo='" + Param[9] +
                              "',OprtDate=getdate() WHERE EmpOtSureID='" + Param[10] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM VKQ_EmpOtSure WHERE 1=1";
                            break;
                        case 7:
                            ret = " ORDER BY EmpNo,BeginTime";
                            break;
                        case 8:
                            ret = GetSQL(code, new string[] { "6" });
                            if (Param[1] != "") ret += GetEmpInfoSQL("0", Param[1]);
                            break;
                        case 9:
                            ret = Param[1];
                            if (Param[3] != "") ret += " AND EmpNo='" + Param[3] + "'";
                            if (Param[4] != "") ret += " AND (DepartID='" + Param[4] + "' OR DepartID IN (" + Param[5] + ")) ";
                            ret += Param[2];
                            break;
                        case 10:
                            ret = "SELECT * FROM VKQ_EmpOtSure WHERE EmpNo='" + Param[1] + "' AND BeginTime='" + Param[2] + "' " +
                                "AND EndTime='" + Param[3] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000212:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_KQData WHERE IsSignIn=1 ORDER BY EmpNo,KQDate,KQTime";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_KQData WHERE GUID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_KQData WHERE GUID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "EXEC PKQ_KQDataSaveEx '" + Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" +
                              Param[4] + "','" + Param[5] + "'";
                            break;
                        case 4:
                            ret = "UPDATE KQ_KQData SET KQDate='" + Param[1] + "',KQTime=" + Param[2] + ",Remark='" +
                              Param[3] + "',OprtNo='" + Param[4] + "',OprtDate=getdate() WHERE GUID='" + Param[5] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM VKQ_KQData WHERE IsSignIn=1";
                            break;
                        case 6:
                            ret = " ORDER BY EmpNo,KQDate,KQTime";
                            break;
                        case 7:
                            ret = GetSQL(code, new string[] { "5" });
                            if (Param[1] != "") ret += GetEmpInfoSQL("0", Param[1]);
                            ret += GetSQL(code, new string[] { "6" });
                            break;
                        case 8:
                            ret = Param[1];
                            if (Param[3] != "") ret += " AND EmpNo='" + Param[3] + "'";
                            if (Param[4] != "") ret += " AND (DepartID='" + Param[4] + "' OR DepartID IN (" + Param[5] + ")) ";
                            ret += Param[2];
                            break;
                    }
                    break;
                case DBCode.DB_000213:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VRS_Emp ORDER BY EmpNo";
                            break;
                        case 1:
                            ret = "EXEC PKQ_Calc '" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "'";
                            break;
                        case 2:
                            ret = "EXEC PKQ_WeekCalc '" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000214:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_KQData WHERE KQDate>='" + Param[6] + "' AND KQDate<='" + Param[7] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += GetMacSNInfoSQL(Param[8], Param[9]);
                            ret += " ORDER BY DepartID,EmpNo,KQDate,KQTime";
                            break;
                        case 1:
                            ret = "SELECT * FROM KQ_KQDataPhoto WHERE GUID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_MJData WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            ret += GetEmpInfoSQL(Param[3], Param[4]) + GetMacSNInfoSQL(Param[5], Param[6]) + GetInOutModeInfoSQL(Param[7]);
                            ret += GetVerifyModeInfoSQL(Param[8]);
                            ret += " ORDER BY KQDate,KQTime";
                            break;
                        case 3:
                            ret = "SELECT * FROM KQ_MJDataPhoto WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT InOutModeName,VerifyModeName FROM VKQ_MJData ";
                            break;
                        case 5:
                            ret = "SELECT * FROM VKQ_MJData WHERE (IsAlarm=0 OR IsAlarm=null) AND KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            ret += GetEmpInfoSQL(Param[3], Param[4]) + GetMacSNInfoSQL(Param[5], Param[6]) + GetInOutModeInfoSQL(Param[7]); ;
                            ret += " ORDER BY KQDate,KQTime";
                            break;
                        case 6:
                            ret = "SELECT * FROM VKQ_MJData WHERE IsAlarm<>0 AND KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            ret += GetEmpInfoSQL(Param[3], Param[4]) + GetMacSNInfoSQL(Param[5], Param[6]) + GetInOutModeInfoSQL(Param[7]); ;
                            ret += " ORDER BY KQDate,KQTime";
                            break;
                        case 7:
                            ret = "SELECT * FROM SY_Log WHERE OprtTime>='" + Param[1] + "' AND OprtTime<='" + Param[2] + "'";
                            ret += GetMacSNSQL(Param[3]) + GetOprtModuleSQL(Param[4]) + GetOprtToolSQL(Param[5]);
                            ret += " ORDER BY OprtTime desc";
                            break;
                        case 10:
                            ret = "SELECT * FROM VDI_SeaSnapShots WHERE OprtDate>='" + Param[1] +
                              "' AND OprtDate<='" + Param[2] + "' order by OprtDate desc";
                            break;
                        case 11:
                            ret = "SELECT * FROM VDI_SeaSnapShots WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 12:
                            ret = "DELETE FROM DI_SeaSnapShots WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 13:
                            ret = "SELECT * FROM VKQ_KQData WHERE KQDateTime>='" + Param[1] + "' AND KQDateTime<='" + Param[2] + "'";
                            ret += " ORDER BY DepartID,EmpNo,KQDate,KQTime";
                            break;
                        case 14:
                            ret = "SELECT * FROM DI_SeaSnapShotsPhoto WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 15:
                            ret = "DELETE FROM DI_SeaSnapShotsPhoto WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 20:
                            ret = @"SELECT * FROM VMJ_SeaPersonIDCard WHERE KQDateTime>='" + Param[1] +
                              "' AND KQDateTime<='" + Param[2] + "'";
                            ret += GetEmpNameSQL(Param[3]) + GetMacSNInfoSQL(Param[4], Param[5]) + GetInOutModeInfoSQL(Param[6]);
                            ret += " ORDER BY KQDateTime desc";
                            break;
                        case 21:
                            ret = "SELECT * FROM MJ_SeaPersonIDCardPhoto WHERE [GUID]='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000215:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_KQDataFilterMark WHERE KQDate>='" + Param[6] + "' AND KQDate<='" + Param[7] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " ORDER BY DepartID,EmpNo,KQDate";
                            break;
                        case 1:
                            ret = "SELECT * FROM KQ_ReportRecords WHERE KQYM='" + Param[6] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " ORDER BY DepartID,EmpNo";
                            break;
                        case 2:
                            ret = "SELECT KQDateTime FROM VKQ_KQData WHERE EmpNo='" + Param[1] + "' AND KQDate='" + Param[2] +
                              "' ORDER BY KQDate,KQTime";
                            break;
                        case 3:
                            ret = "INSERT INTO KQ_ReportRecords(KQYM,EmpNo,EmpName,DepartID,DepartName,CardTime01,CardTime02," +
                              "CardTime03,CardTime04,CardTime05,CardTime06,CardTime07,CardTime08,CardTime09,CardTime10," +
                              "CardTime11,CardTime12,CardTime13,CardTime14,CardTime15,CardTime16,CardTime17,CardTime18," +
                              "CardTime19,CardTime20,CardTime21,CardTime22,CardTime23,CardTime24,CardTime25,CardTime26," +
                              "CardTime27,CardTime28,CardTime29,CardTime30,CardTime31) VALUES('" + Param[1] + "','" +
                              Param[2] + "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "','" +
                              Param[7] + "','" + Param[8] + "','" + Param[9] + "','" + Param[10] + "','" + Param[11] + "','" +
                              Param[12] + "','" + Param[13] + "','" + Param[14] + "','" + Param[15] + "','" + Param[16] + "','" +
                              Param[17] + "','" + Param[18] + "','" + Param[19] + "','" + Param[20] + "','" + Param[21] + "','" +
                              Param[22] + "','" + Param[23] + "','" + Param[24] + "','" + Param[25] + "','" + Param[26] + "','" +
                              Param[27] + "','" + Param[28] + "','" + Param[29] + "','" + Param[30] + "','" + Param[31] + "','" +
                              Param[32] + "','" + Param[33] + "','" + Param[34] + "','" + Param[35] + "','" + Param[36] + "')";
                            break;
                    }
                    break;
                case DBCode.DB_000216:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_KQReportDay WHERE KQDate>='" + Param[6] + "' AND KQDate<='" + Param[7] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            string[] S = new string[5] { "", "", "", "", "" };
                            string tmp = "";
                            if (Param[8] == "1") S[0] = "LeaveDays<>0";
                            if (Param[9] == "1") S[1] = "LeaveMins<>0";
                            if (Param[10] == "1") S[2] = "LateMins<>0";
                            if (Param[11] == "1") S[3] = "AbsentDays<>0";
                            if (Param[12] == "1") S[4] = "OtHrs<>0";
                            for (int x = 0; x < 5; x++)
                            {
                                if (S[x] != "") tmp += " OR " + S[x];
                            }
                            if (tmp != "") tmp = " AND (" + tmp.Substring(4) + ")";
                            ret += tmp;
                            ret += " ORDER BY DepartID,EmpNo,KQDate";
                            break;
                        case 1:
                            ret = "SELECT * FROM VKQ_KQData WHERE EmpNo='" + Param[1] + "' AND KQDate='" +
                              Param[2] + "' ORDER BY KQTime";
                            break;
                    }
                    break;
                case DBCode.DB_000217:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_KQReportMonth WHERE KQYM='" + Param[6] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " ORDER BY DepartID,EmpNo";
                            break;
                        case 1:
                            ret = "SELECT * FROM VKQ_KQReportWeek WHERE KQYM='" + Param[6] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " ORDER BY DepartID,EmpNo";
                            break;
                    }
                    break;
                case DBCode.DB_000218:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT *,DAY(KQDate) AS KQDateDay FROM VKQ_KQReportTotal " +
                              "WHERE KQDate>=StartDate AND KQDate<=EndDate AND KQYM='" + Param[6] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " ORDER BY DepartID,EmpNo,KQDate";
                            break;
                        case 1:
                            ret = "SELECT *,DAY(KQDate) AS KQDateDay FROM VKQ_KQWeekReportTotal " +
                              "WHERE KQDate>=StartDate AND KQDate<=EndDate AND KQYM='" + Param[6] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " ORDER BY DepartID,EmpNo,KQDate";
                            break;
                    }
                    break;
                case DBCode.DB_000219:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_KQReportMonthDetail WHERE KQYM='" + Param[6] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " ORDER BY DepartID,EmpNo";
                            break;
                    }
                    break;
                case DBCode.DB_000300:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VDI_MacInfo WHERE 1=1";
                            if (Param.Length > 1) ret += Param[1];
                            if (!SystemInfo.IsMacNomber)
                                ret += " ORDER BY MacSN";
                            else if (SystemInfo.IsMacNomber)
                                ret += " ORDER BY MacSN+0";
                            break;
                        case 1:
                            ret = "DELETE FROM DI_MacInfo WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VDI_MacInfo WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD," +
                              "MacDesc,ParamInfo,IsGPRS,MacSeriesTypeId,MacSeriesTypeName,MacSeriesUserName,InOutMode,DevGroupID,DevGroupName,DevModeID) " +
                              "VALUES('" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "','" +
                              Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" +
                              Param[8] + "','" + Param[9] + "'," + Param[10] + "," + Param[11] + ",'" + Param[12] + "'," +
                              "'" + Param[13] + "','" + Param[14] + "','" + Param[15] + "','" + Param[16] + "'," + Param[17] + ")";
                            break;
                        case 4:
                            ret = "SELECT * FROM VDI_MacInfo WHERE MacSN<>'" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 5:
                            ret = "UPDATE DI_MacInfo SET MacSN='" + Param[1] + "',MacTypeID=" + Param[2] + ",MacTypeName='" +
                              Param[3] + "',MacConnType='" + Param[4] + "',MacIP='" + Param[5] + "',MacPort='" +
                              Param[6] + "',MacConnPWD='" + Param[7] + "',MacDesc='" + Param[8] + "',ParamInfo='" +
                              Param[9] + "',IsGPRS=" + Param[10] + ",MacSeriesTypeId=" + Param[11] + ",MacSeriesTypeName='" + Param[12] + "'," +
                              "MacSeriesUserName='" + Param[13] + "',InOutMode='" + Param[14] + "',DevGroupID='" + Param[15] + "'," +
                              "DevGroupName='" + Param[16] + "',DevModeID=" + Param[17] + " WHERE MacSN='" + Param[18] + "'";
                            break;
                        case 6:
                            ret = "UPDATE DI_MacInfo SET OpenState='" + Param[1] + "' WHERE MacSN='" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "UPDATE DI_MacInfo SET SetTimer='" + Param[1] + "',IsTimerOpen=" + Param[2] + " WHERE MacSN='" + Param[3] + "'";
                            break;
                        case 8:
                            ret = "SELECT * FROM VDI_MacInfo WHERE MacSeriesTypeId=1 OR MacSeriesTypeId=0 OR MacSeriesTypeId is NULL";
                            if (Param.Length > 1) ret += Param[1];
                            if (!SystemInfo.IsMacNomber)
                                ret += " ORDER BY MacSN";
                            else if (SystemInfo.IsMacNomber)
                                ret += " ORDER BY MacSN+0";
                            break;
                        case 9:
                            ret = "SELECT * FROM VDI_MacInfo WHERE MacSeriesTypeId=2";
                            if (Param.Length > 1) ret += Param[1];
                            ret += " ORDER BY MacSN+0";
                            break;
                        case 10:
                            ret = "UPDATE DI_MacInfo SET MacSeriesUserName='" + Param[1] + "',MacConnPWD='" + Param[2] + "'  WHERE MacSN='" + Param[3] + "'";
                            break;
                        case 20:
                            ret = "SELECT * FROM VDI_MacInfo WHERE MacSeriesTypeId=3";
                            if (Param.Length > 1) ret += Param[1];
                            ret += " ORDER BY MacSN";
                            break;
                        case 21:
                            ret = "SELECT * FROM DI_StarParam";
                            break;
                        case 22:
                            ret = "INSERT INTO DI_StarParam([MacSN],[DevName],[WiegandType],[DevLanguage],[AntiPass],[OpenDoorDelay],[TamperAlarm],[AlarmDelay]," +
                                "[Volume],[ReverifyTime],[ScreensaversTime],[SleepTime],[verifyMode]) VALUES(" +
                                "'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "'," + Param[6] + ",'" + Param[7] + "'," +
                                "" + Param[8] + "," + Param[9] + "," + Param[10] + "," + Param[11] + "," + Param[12] + ",'" + Param[13] + "')";
                            break;
                        case 23:
                            ret = "UPDATE DI_StarParam Set [DevName]='" + Param[1] + "',[WiegandType]='" + Param[2] + "',[DevLanguage]='" + Param[3] + "'," +
                                "[AntiPass]='" + Param[4] + "',[OpenDoorDelay]=" + Param[5] + ",[TamperAlarm]='" + Param[6] + "',[AlarmDelay]=" + Param[7] + "," +
                                "[Volume]=" + Param[8] + ",[ReverifyTime]=" + Param[9] + ",[ScreensaversTime]=" + Param[10] + ",[SleepTime]=" + Param[11] + ",[verifyMode]='" + Param[12] + "'" +
                                " WHERE [MacSN]='" + Param[13] + "'";
                            break;
                        case 24:
                            ret = "INSERT INTO DI_StarParam([MacSN],[ServerHost],[ServerPort],[PushServerHost],[PushServerPort],[Interval],[pushEnable]) VALUES(" +
                                "'" + Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" + Param[4] + "'," + Param[5] + "," + Param[6] + ",'" + Param[7] + "')";
                            break;
                        case 25:
                            ret = "UPDATE DI_StarParam Set [ServerHost]='" + Param[1] + "'," +
                                "[ServerPort]=" + Param[2] + ",[PushServerHost]='" + Param[3] + "',[PushServerPort]=" + Param[4] + ",[Interval]=" + Param[5] + ",[pushEnable]='" + Param[6] + "'" +
                                " WHERE [MacSN]='" + Param[7] + "'";
                            break;
                        case 30:
                            ret = "SELECT DevGroupID,DevGroupName FROM DI_DevGroup ORDER BY DevGroupID";
                            break;
                        case 31:
                            ret = "SELECT DevGroupID,DevGroupName FROM DI_DevGroup WHERE DevGroupUpID='" + Param[1] + "' ORDER BY DevGroupID";
                            break;
                        case 32:
                            ret = "SELECT DevGroupID,DevGroupName FROM DI_DevGroup WHERE DevGroupUpID='' OR DevGroupUpID IS NULL";
                            break;
                        case 33:
                            ret = "SELECT * FROM DI_DevGroup WHERE DevGroupID='" + Param[1] + "' ORDER BY DevGroupID";
                            break;
                        case 34:
                            ret = "INSERT INTO DI_DevGroup(DevGroupID,DevGroupName,DevGroupUpID,DevGroupMemo) VALUES('" + Param[1] + "','" +
                              Param[2] + "','" + Param[3] + "','" + Param[4] + "')";
                            break;
                        case 35:
                            ret = "SELECT * FROM DI_DevGroup WHERE DevGroupID<>'" + Param[1] + "' AND DevGroupID='" + Param[2] + "'";
                            break;
                        case 36:
                            ret = "UPDATE DI_DevGroup SET DevGroupID='" + Param[1] + "',DevGroupName='" + Param[2] + "',DevGroupUpID='" +
                              Param[3] + "',DevGroupMemo='" + Param[4] + "' WHERE DevGroupID='" + Param[5] + "'";
                            break;
                        case 37:
                            ret = "UPDATE DI_MacInfo SET DevGroupID='" + Param[1] + "',DevGroupName='" + Param[2] + "' WHERE DevGroupID='" + Param[3] + "'";
                            break;
                        case 38:
                            ret = "SELECT DevGroupID FROM DI_MacInfo WHERE DevGroupID='" + Param[1] + "'";
                            break;
                        case 39:
                            ret = "DELETE FROM DI_DevGroup WHERE DevGroupID='" + Param[1] + "'";
                            break;
                        case 40:
                            ret = "UPDATE DI_DevGroup SET DevGroupUpID='" + Param[1] + "' WHERE DevGroupUpID='" + Param[2] + "'";
                            break;
                        case 101:
                            ret = " AND (MacConnType='LAN' OR MacConnType='WAN')";
                            break;
                        case 102:
                            ret = " AND (1=2)";
                            break;
                        case 103:
                            ret = "EXEC PGetMaxIDFromTable 'MacSN','DI_MacInfo'";
                            break;
                        case 104:
                            ret = "UPDATE DI_MacInfo SET ParamInfo='" + Param[1] + "' WHERE MacSN='" + Param[2] + "'";
                            break;
                        case 105:
                            ret = "SELECT ParamInfo FROM DI_MacInfo WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 106:
                            ret = "EXEC PKQ_KQDataSave " + Param[1] + ",'" + Param[2] + "','" + Param[3] + "'," + Param[4] + ",'" +
                              Param[5] + "','" + Param[6] + "','" + Param[7] + "'," + Param[8] + ",'" + Param[9] + "'," +
                              Param[10] + ",'" + Param[11] + "','" + Param[12] + "'," + Param[13] + "";
                            break;
                        case 107:
                            ret = "SELECT * FROM VRS_Emp WHERE ((LEN(CardNo10)=10 AND ISNUMERIC(CardNo10)=1) OR " +
                              "FingerNo IN(SELECT DISTINCT FingerNo FROM RS_EmpFingerInfo)) " + Param[1];
                            if (Param.Length >= 3) ret += " AND (EmpNo='" + Param[2] + "' OR EmpName LIKE '" + Param[2] + "%')";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 108:
                            ret = "INSERT INTO KQ_KQDataPhoto(GUID,Photo) VALUES('" + Param[1] + "',@Photo)";
                            break;
                        case 109:
                            ret = " AND ((LEN(CardNo10)=10 AND ISNUMERIC(CardNo10)=1) OR " +
                              "FingerNo IN(SELECT DISTINCT FingerNo FROM RS_EmpFingerInfo))";
                            break;
                        case 110:
                            ret = "SELECT * FROM VRS_Emp WHERE (EmpNo='" + Param[2] + "' OR EmpName LIKE '" +
                              Param[2] + "%') " + Param[1] + " ORDER BY EmpNo";
                            break;
                        case 111:
                            ret = "EXEC PKQ_MJDataSave '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "','" + Param[4] +
                              "','" + Param[5] + "'," + Param[6] + ",'" + Param[7] + "'," + Param[8] + ",'" + Param[9] + "'," +
                              "" + Param[10] + ",'" + Param[11] + "','" + Param[12] + "','" + Param[13] + "'," + Param[14] + "";
                            break;
                        case 112:
                            ret = "INSERT INTO KQ_MJDataPhoto(GUID,Photo) VALUES('" + Param[1] + "',@Photo)";
                            break;
                        case 113:
                            ret = "INSERT INTO KQ_SuperData(GUID,DevID,SEnrollNo,GEnrollNo,ManID,ManName,BakNo,BakName,STime,OprtNo," +
                              "OprtDate) VALUES(newid()," + Param[1] + "," + Param[2] + "," + Param[3] + "," + Param[4] + ",'" +
                             Param[5] + "'," + Param[6] + ",'" + Param[7] + "','" + Param[8] + "','" + Param[9] + "',getdate())";
                            break;
                        case 114:
                            ret = "INSERT INTO MJ_SeaPersonIDCardPhoto([GUID],Photo) VALUES('" + Param[1] + "',@Photo)";
                            break;
                        case 201:
                            ret = "TRUNCATE TABLE RS_EmpFingerInfo";
                            break;
                        case 202:
                            ret = "UPDATE RS_EmpFingerInfo SET FingerData=@FingerData WHERE FingerFlag=" + Param[1] +
                              " AND FingerNo=" + Param[2] + " AND FingerBkNo=" + Param[3];
                            break;
                        case 203:
                            ret = "SELECT FingerNo FROM RS_EmpFingerInfo WHERE FingerFlag=" + Param[1] + " AND FingerNo=" +
                              Param[2] + " AND FingerBkNo=" + Param[3];
                            break;
                        case 204:
                            ret = "INSERT INTO RS_EmpFingerInfo(FingerFlag,FingerNo,FingerBkNo,FingerPWD) VALUES(" +
                              Param[1] + "," + Param[2] + "," + Param[3] + "," + Param[4] + ")";
                            break;
                        case 205:
                            ret = "UPDATE RS_EmpFingerInfo SET FingerPWD=" + Param[3] + " WHERE FingerFlag=" +
                              Param[1] + " AND FingerNo=" + Param[2] + " AND FingerBkNo=" + Param[3];
                            break;
                        case 206:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 207:
                            ret = "SELECT * FROM VRS_EmpFingerInfo WHERE EmpNo IN(" + Param[1] + ") ORDER BY FingerNo,FingerBkNo";
                            break;
                        case 208:
                            ret = "SELECT * FROM VRS_Emp WHERE FingerNo=" + Param[1];
                            break;
                        case 209:
                            ret = "SELECT EmpNo,EmpName,DepartID,DepartName FROM VRS_Emp WHERE FingerNo=" + Param[1];
                            break;
                        case 210:
                            ret = "SELECT * FROM VDI_MacInfo WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 300:
                            ret = "UPDATE DI_MacInfo SET MacMANAGERS=" + Param[1] + ",MacUSERS=" + Param[2] + ",MacFPS=" +
                              Param[3] + ",MacFaceS=" + Param[4] + ",MacPSWS=" + Param[5] + ",MacCARDS=" + Param[6] +
                              ",MacPALMVEINS=" + Param[7] + ",MacGLOGS=" + Param[8] + ",MacAGLOGS=" + Param[9] +
                              " WHERE MacSN='" + Param[10] + "'";
                            break;
                        case 301:
                            ret = "UPDATE DI_MacInfo SET DoorState='" + Param[1] + "' WHERE MacSN='" + Param[2] + "'";
                            break;
                        case 302:
                            ret = "SELECT * FROM VRS_EmpFingerInfo ORDER BY FingerNo,FingerBkNo";
                            break;
                        case 303:
                            ret = "SELECT * FROM VRS_Emp where IsDimission=0 ORDER BY FingerNo";
                            break;
                        case 304:
                            ret = "UPDATE DI_MacInfo SET MacConnectState='" + Param[1] + "',MacDefenseState='" + Param[2] + "'" +
                              " WHERE MacSN='" + Param[3] + "'";
                            break;
                        case 305:
                            ret = "UPDATE DI_MacInfo SET MacConnectState='" + Param[1] + "'" +
                              " WHERE MacSN='" + Param[2] + "'";
                            break;
                        case 400:
                            ret = "SELECT * FROM DI_PsssTime ORDER BY PassTimeID";
                            break;
                        case 401:
                            ret = "DELETE FROM DI_PsssTime WHERE PassTimeID=" + Param[1];
                            break;
                        case 402:
                            ret = "EXEC PGetMaxIDFromTable 'PassTimeID','DI_PsssTime'";
                            break;
                        case 403:
                            ret = "SELECT * FROM DI_PsssTime WHERE PassTimeID=" + Param[1];
                            break;
                        case 404:
                            ret = "INSERT INTO DI_PsssTime(PassTimeID,PassTimeName,T1S,T1E,T2S,T2E,T3S,T3E,T4S,T4E,T5S,T5E," +
                              "T6S,T6E,OprtNo,OprtDate) VALUES(" + Param[1] + ",'" + Param[2] + "','" + Param[3] + "','" +
                              Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" +
                              Param[9] + "','" + Param[10] + "','" + Param[11] + "','" + Param[12] + "','" + Param[13] + "','" +
                              Param[14] + "','" + Param[15] + "',getdate())";
                            break;
                        case 405:
                            ret = "UPDATE DI_PsssTime SET PassTimeName='" + Param[2] + "',T1S='" + Param[3] + "',T1E='" +
                              Param[4] + "',T2S='" + Param[5] + "',T2E='" + Param[6] + "',T3S='" + Param[7] + "',T3E='" +
                              Param[8] + "',T4S='" + Param[9] + "',T4E='" + Param[10] + "',T5S='" + Param[11] + "',T5E='" +
                              Param[12] + "',T6S='" + Param[13] + "',T6E='" + Param[14] + "',OprtNo='" + Param[15] +
                              "',OprtDate=getdate() WHERE PassTimeID=" + Param[1];
                            break;
                        case 500:
                            ret = "SELECT * FROM VDI_Power WHERE MacSN='" + Param[1] + "' ORDER BY EmpNo";
                            break;
                        case 501:
                            ret = "SELECT * FROM VDI_Power WHERE MacSN='" + Param[1] + "'";
                            if (Param[2] != "") ret += " AND (DepartID='" + Param[2] + "' OR DepartID IN (" + Param[3] + ")) ";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 502:
                            ret = "DELETE FROM DI_Power WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 503:
                            ret = "SELECT * FROM DI_Power WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 504:
                            ret = "INSERT INTO DI_Power(GUID,MacSN,EmpNo,SunID,MonID,TueID,WedID,ThuID,FriID,SatID,OprtNo," +
                              "OprtDate,StartDate,EndDate) VALUES(newid()," + Param[1] + ",'" + Param[2] + "'," + Param[3] + "," +
                              Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + "," + Param[8] + "," + Param[9] + ",'" +
                              Param[10] + "',getdate()," + Param[11] + "," + Param[12] + ")";
                            break;
                        case 505:
                            ret = "UPDATE DI_Power SET SunID=" + Param[3] + ",MonID=" + Param[4] + ",TueID=" + Param[5] + ",WedID=" +
                              Param[6] + ",ThuID=" + Param[7] + ",FriID=" + Param[8] + ",SatID=" + Param[9] + ",OprtNo='" +
                              Param[10] + "',OprtDate=getdate(),StartDate=" + Param[11] + ",EndDate=" + Param[12] + " WHERE MacSN='" +
                              Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 506:
                            ret = "DELETE FROM DI_Power WITH (TABLOCKX) WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 507:
                            ret = "DELETE FROM DI_Power WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 508:
                            ret = "SELECT FingerNo FROM RS_Emp ORDER BY FingerNo";
                            break;
                        case 510:
                            ret = "SELECT * FROM VDI_SeaPower WHERE MacSN='" + Param[1] + "' ORDER BY EmpNo";
                            break;
                        case 511:
                            ret = "SELECT * FROM VDI_SeaPower WHERE MacSN='" + Param[1] + "'";
                            if (Param[2] != "") ret += " AND (DepartID='" + Param[2] + "' OR DepartID IN (" + Param[3] + ")) ";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 512:
                            ret = "DELETE FROM DI_SeaPower WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 513:
                            ret = "SELECT * FROM DI_SeaPower WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 514:
                            ret = "INSERT INTO DI_SeaPower(GUID,MacSN,EmpNo,OprtNo," +
                              "OprtDate,StartDate,EndDate) VALUES(newid()," + Param[1] + ",'" + Param[2] + "','" + Param[3] + "',getdate()," + Param[4] + "," + Param[5] + ")";
                            break;
                        case 515:
                            ret = "UPDATE DI_SeaPower SET OprtNo='" +
                              Param[3] + "',OprtDate=getdate(),StartDate=" + Param[4] + ",EndDate=" + Param[5] + " WHERE MacSN='" +
                              Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 516:
                            ret = "DELETE FROM DI_SeaPower WITH (TABLOCKX) WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 517:
                            ret = "DELETE FROM DI_SeaPower WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 518:
                            ret = "SELECT [GUID],MacSN,EmpNo,OprtNo,OprtDate,StartDate,EndDate FROM DI_SeaPower WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 519:
                            ret = "SELECT [GUID],MacSN,EmpNo,OprtNo,OprtDate,StartDate,EndDate FROM DI_SeaPower WHERE 1=2";
                            break;
                        case 550:
                            ret = "SELECT * FROM VDI_StarPower WHERE MacSN='" + Param[1] + "' ORDER BY EmpNo";
                            break;
                        case 551:
                            ret = "SELECT * FROM VDI_StarPower WHERE MacSN='" + Param[1] + "'";
                            if (Param[2] != "") ret += " AND (DepartID='" + Param[2] + "' OR DepartID IN (" + Param[3] + ")) ";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 552:
                            ret = "DELETE FROM DI_StarPower WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 553:
                            ret = "SELECT * FROM DI_StarPower WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 554:
                            ret = "INSERT INTO DI_StarPower(GUID,MacSN,EmpNo,OprtNo," +
                              "OprtDate,StartDate,EndDate) VALUES(newid()," + Param[1] + ",'" + Param[2] + "','" + Param[3] + "',getdate()," + Param[4] + "," + Param[5] + ")";
                            break;
                        case 555:
                            ret = "UPDATE DI_StarPower SET OprtNo='" +
                              Param[3] + "',OprtDate=getdate(),StartDate=" + Param[4] + ",EndDate=" + Param[5] + " WHERE MacSN='" +
                              Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 556:
                            ret = "DELETE FROM DI_StarPower WITH (TABLOCKX) WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 557:
                            ret = "DELETE FROM DI_StarPower WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 558:
                            ret = "SELECT [GUID],MacSN,EmpNo,OprtNo,OprtDate,StartDate,EndDate FROM DI_StarPower WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 559:
                            ret = "SELECT [GUID],MacSN,EmpNo,OprtNo,OprtDate,StartDate,EndDate FROM DI_StarPower WHERE 1=2";
                            break;
                        case 600:
                            ret = "SELECT * FROM VDI_Power  WHERE 1=1";
                            if (Param[1] != "") ret += " AND DepartID='" + Param[1] + "' OR DepartID IN (" + Param[2] + ")";
                            if (Param[3] != "") ret += GetPowerMacSNInfoSQL("0", Param[3]);
                            ret += " ORDER BY EmpNo,MacSN";
                            break;
                        case 601:
                            ret = "SELECT * FROM VDI_Power WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 602:
                            ret = "UPDATE DI_Power SET SunID=" + Param[2] + ",MonID=" + Param[3] + ",TueID=" + Param[4] + ",WedID=" +
                              Param[5] + ",ThuID=" + Param[6] + ",FriID=" + Param[7] + ",SatID=" + Param[8] + ",OprtNo='" + Param[9] +
                              "',OprtDate=getdate(),StartDate=" + Param[10] + ",EndDate=" + Param[11] + " WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 603:
                            ret = "SELECT * FROM DI_MacInfo order by MacSN";
                            break;
                        case 604:
                            ret = "SELECT * FROM VRS_EmpDownload WHERE EmpNo IN(" + Param[1] + ") ORDER BY FingerNo";
                            break;
                        case 605:
                            ret = "SELECT * FROM VRS_EmpDownload ORDER BY FingerNo";
                            break;
                        case 610:
                            ret = "SELECT * FROM VDI_SeaPower  WHERE 1=1 ";
                            if (Param[1] != "") ret += " AND DepartID='" + Param[1] + "' OR DepartID IN (" + Param[2] + ")";
                            if (Param[3] != "") ret += GetPowerMacSNInfoSQL("0", Param[3]);
                            ret += " ORDER BY EmpNo,MacSN";
                            break;
                        case 611:
                            ret = "SELECT * FROM VDI_SeaPower WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 612:
                            ret = "UPDATE DI_SeaPower SET OprtNo='" + Param[2] +
                              "',OprtDate=getdate(),StartDate=" + Param[3] + ",EndDate=" + Param[4] + " WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 613:
                            ret = "SELECT * FROM VDI_SeaPowerDownload";
                            if (Param[1] != "") ret += " WHERE DepartID='" + Param[1] + "' OR DepartID IN (" + Param[2] + ")";
                            ret += " ORDER BY EmpNo,MacSN";
                            break;
                        case 620:
                            ret = "SELECT * FROM VDI_StarPower  WHERE 1=1";
                            if (Param[1] != "") ret += " AND DepartID='" + Param[1] + "' OR DepartID IN (" + Param[2] + ")";
                            if (Param[3] != "") ret += GetPowerMacSNInfoSQL("0", Param[3]);
                            ret += " ORDER BY EmpNo,MacSN";
                            break;
                        case 621:
                            ret = "SELECT * FROM VDI_StarPower WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 622:
                            ret = "UPDATE DI_StarPower SET OprtNo='" + Param[2] +
                              "',OprtDate=getdate(),StartDate=" + Param[3] + ",EndDate=" + Param[4] + " WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 623:
                            ret = "SELECT * FROM VDI_StarPowerDownload";
                            if (Param[1] != "") ret += " WHERE DepartID='" + Param[1] + "' OR DepartID IN (" + Param[2] + ")";
                            ret += " ORDER BY EmpNo,MacSN";
                            break;
                        case 700:
                            ret = "INSERT INTO MJ_TemporaryData([GUID],MJDateTime,MacSN,EmpNo,EmpName) VALUES(newid(),'" + Param[1] + "'," +
                                            "'" + Param[2] + "','" + Param[3] + "','" + Param[4] + "')";
                            break;
                        case 701:
                            ret = "SELECT * FROM VMJ_TemporaryData WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 702:
                            ret = "DELETE FROM MJ_TemporaryData WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 703:
                            ret = "SELECT * FROM MJ_TemporaryData WHERE MacSN='" + Param[1] + "'  ORDER BY MJDateTime";
                            break;
                        case 704:
                            ret = "INSERT INTO MJ_OpenData([GUID],MJDateTime,MacSN,MacDesc,InOutModeName,EmpNoOne,EmpNoTwo," +
                                "EmpNoTree,EmpNoFour,EmpNoFive) VALUES(newid(),'" + Param[1] + "'," +
                                 "'" + Param[2] + "','" + Param[3] + "','" + Param[4] + "'," +
                                 "'" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" + Param[8] + "')";
                            break;
                        case 705:
                            ret = "SELECT * FROM VMJ_OpenData WHERE MJDateTime='" + Param[1] + "' AND EmpNoOne='" + Param[2] + "'";
                            break;
                        case 706:
                            ret = "UPDATE MJ_OpenData SET MJDateTime='" + Param[2] + "',MacSN='" + Param[3] + "',MacDesc='" + Param[4] + "',InOutModeName='" +
                              Param[5] + "',EmpNoOne='" + Param[6] + "',EmpNoTwo='" + Param[7] + "',EmpNoTree='" + Param[8] + "' WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 707:
                            ret = "SELECT * FROM VMJ_OpenData WHERE MJDateTime>='" + Param[1] + "' AND MJDateTime<='" + Param[2] + "'";
                            ret += GetMJEmpInfoSQL(Param[3]) + GetMacSNInfoSQL(Param[4], Param[5]) + GetInOutModeInfoSQL(Param[6]); ;
                            ret += " ORDER BY MJDateTime";
                            break;
                        case 708:
                            ret = "INSERT INTO MJ_TemporaryData(GUID,MJDateTime,MacSN,EmpNo,EmpName) VALUES('" + Param[1] + "','" + Param[2] + "'," +
                                            "'" + Param[3] + "','" + Param[4] + "','" + Param[5] + "')";
                            break;
                        case 709:
                            ret = "DELETE FROM MJ_TemporaryData";
                            break;
                        case 710:
                            ret = "DELETE FROM MJ_TemporaryData WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 800:
                            ret = "INSERT INTO MJ_AlarmData([GUID],AlarmTime,MacSN,MacDesc,AlarmMode) VALUES(newid(),'" + Param[1] + "'," +
                                 "'" + Param[2] + "','" + Param[3] + "','" + Param[4] + "')";
                            break;
                        case 801:
                            ret = "SELECT * FROM VMJ_AlarmData WHERE AlarmTime='" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 802:
                            ret = "UPDATE MJ_AlarmData SET AlarmTime='" + Param[2] + "',MacSN='" + Param[3] + "',MacDesc='" + Param[4] + "',AlarmMode='" +
                              Param[5] + "' WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 803:
                            ret = "SELECT AlarmMode FROM VMJ_AlarmData ";
                            break;
                        case 804:
                            ret = "SELECT * FROM VMJ_AlarmData WHERE AlarmTime>='" + Param[1] + "' AND AlarmTime<='" + Param[2] + "'";
                            ret += GetMacSNInfoSQL(Param[3], Param[4]) + GetAlarmModeInfoSQL(Param[5]); ;
                            ret += " ORDER BY AlarmTime";
                            break;
                    }
                    break;

                case DBCode.DB_000400:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM KQ_RuleCalc where CalcTypeID=2";
                            break;
                        case 1:
                            ret = "SELECT *,case RuleMode when 1 Then '{0}' when 0 then '{1}' end as Mode from VGZ_Rule";
                            break;
                        case 2:
                            ret = "SELECT * FROM GZ_Rule WHERE RuleID=" + Param[1];
                            break;
                        case 3:
                            ret = "INSERT INTO GZ_Rule(RuleID,RuleName,RuleMode,IsFunction,RuleCash,RuleFunction," +
                              "VRuleFunction) VALUES(" + Param[1] + ",'" + Param[2] + "'," + Param[3] + "," + Param[4] +
                              "," + Param[5] + ",'" + Param[6] + "','" + Param[7] + "')";
                            break;
                        case 4:
                            ret = "UPDATE GZ_Rule SET RuleName='" + Param[1] + "',RuleMode=" + Param[2] + ",IsFunction=" +
                              Param[3] + ",RuleCash=" + Param[4] + ",RuleFunction='" + Param[5] + "',VRuleFunction='" +
                              Param[6] + "' WHERE RuleID=" + Param[7];
                            break;
                        case 5:
                            ret = "DELETE FROM GZ_Rule WHERE RuleID=" + Param[1];
                            break;
                        case 6:
                            ret = "SELECT EmpNo,({0}) FROM VGZ_RuleItem";
                            break;
                        case 7:
                            ret = "SELECT COUNT(1) AS RecCount FROM GZ_Item WHERE ItemOut0=" + Param[1] + " or ItemOut1=" +
                              Param[1] + " or ItemOut2=" + Param[1] + " or ItemOut3=" + Param[1] + " or ItemOut4=" +
                              Param[1] + "" + " or ItemOut5=" + Param[1] + " or ItemOut6=" + Param[1] + " or ItemOut7=" +
                              Param[1] + " or ItemOut8=" + Param[1] + " or ItemOut9=" + Param[1] + " or ItemOut10=" +
                              Param[1] + " or ItemOut11=" + Param[1] + " or ItemOut12=" + Param[1] + " or ItemOut13=" +
                              Param[1] + " or ItemOut14=" + Param[1] + " or ItemOut15=" + Param[1] + " or ItemOut16=" +
                              Param[1] + " or ItemOut17=" + Param[1] + " or ItemOut18=" + Param[1] + " or ItemOut19=" +
                              Param[1] + "" + " or ItemIn0=" + Param[1] + " or ItemIn1=" + Param[1] + " or ItemIn2=" +
                              Param[1] + " or ItemIn3=" + Param[1] + " or ItemIn4=" + Param[1] + " or ItemIn5=" +
                              Param[1] + " or ItemIn6=" + Param[1] + " or ItemIn7=" + Param[1] + " or ItemIn8=" +
                              Param[1] + " or ItemIn9=" + Param[1] + " or ItemIn10=" + Param[1] + " or ItemIn11=" +
                              Param[1] + " or ItemIn12=" + Param[1] + " or ItemIn13=" + Param[1] + " or ItemIn14=" +
                              Param[1] + " or ItemIn15=" + Param[1] + " " + " or ItemIn16=" + Param[1] + " or ItemIn17=" +
                              Param[1] + " or ItemIn18=" + Param[1] + " or ItemIn19=" + Param[1] + "";
                            break;
                        case 100:
                            ret = "SELECT * FROM KQ_KQDataInOutMode WHERE InOutModeID=" + Param[1];
                            break;
                        case 101:
                            ret = "INSERT INTO KQ_KQDataInOutMode(InOutModeID,InOutModeName) VALUES(" + Param[1] + ",'" + Param[2] + "')";
                            break;
                        case 102:
                            ret = "UPDATE KQ_KQDataInOutMode SET InOutModeName='" + Param[2] + "' WHERE InOutModeID=" + Param[1];
                            break;
                    }
                    break;
                case DBCode.DB_000401:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM GZ_Rule";
                            break;
                        case 1:
                            ret = "SELECT * FROM VGZ_Item";
                            break;
                        case 2:
                            ret = "SELECT * FROM GZ_Item WHERE ItemID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "INSERT INTO GZ_Item(ItemID,ItemName,ItemIn0,ItemIn1,ItemIn2,ItemIn3,ItemIn4,ItemIn5," +
                              "ItemIn6,ItemIn7,ItemIn8,ItemIn9,ItemIn10,ItemIn11,ItemIn12,ItemIn13,ItemIn14,ItemIn15," +
                              "ItemIn16,ItemIn17,ItemIn18,ItemIn19,ItemOut0,ItemOut1,ItemOut2,ItemOut3,ItemOut4," +
                              "ItemOut5,ItemOut6,ItemOut7,ItemOut8,ItemOut9,ItemOut10,ItemOut11,ItemOut12,ItemOut13," +
                              "ItemOut14,ItemOut15,ItemOut16,ItemOut17,ItemOut18,ItemOut19) VALUES(" + Param[1] + ",'" +
                              Param[2] + "'," + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," +
                              Param[7] + "," + Param[8] + "," + Param[9] + "," + Param[10] + "," + Param[11] + "," +
                              Param[12] + "," + Param[13] + "," + Param[14] + "," + Param[15] + "," + Param[16] + "," +
                              Param[17] + "," + Param[18] + "," + Param[19] + "," + Param[20] + "," + Param[21] + "," +
                              Param[22] + "," + Param[23] + "," + Param[24] + "," + Param[25] + "," + Param[26] + "," +
                              Param[27] + "," + Param[28] + "," + Param[29] + "," + Param[30] + "," + Param[31] + "," +
                              Param[32] + "," + Param[33] + "," + Param[34] + "," + Param[35] + "," + Param[36] + "," +
                              Param[37] + "," + Param[38] + "," + Param[39] + "," + Param[40] + "," + Param[41] + "," +
                              Param[42] + ")";
                            break;
                        case 4:
                            ret = "UPDATE GZ_Item SET ItemName='" + Param[1] + "',ItemIn0=" + Param[2] + ",ItemIn1=" +
                              Param[3] + ",ItemIn2=" + Param[4] + ",ItemIn3=" + Param[5] + ",ItemIn4=" + Param[6] + ",ItemIn5=" +
                              Param[7] + ",ItemIn6=" + Param[8] + ",ItemIn7=" + Param[9] + ",ItemIn8=" + Param[10] + ",ItemIn9=" +
                              Param[11] + ",ItemIn10=" + Param[12] + ",ItemIn11=" + Param[13] + ",ItemIn12=" +
                              Param[14] + ",ItemIn13=" + Param[15] + ",ItemIn14=" + Param[16] + ",ItemIn15=" +
                              Param[17] + ",ItemIn16=" + Param[18] + ",ItemIn17=" + Param[19] + ",ItemIn18=" +
                              Param[20] + ",ItemIn19=" + Param[21] + ",ItemOut0=" + Param[22] + ",ItemOut1=" +
                              Param[23] + ",ItemOut2=" + Param[24] + ",ItemOut3=" + Param[25] + ",ItemOut4=" +
                              Param[26] + ",ItemOut5=" + Param[27] + ",ItemOut6=" + Param[28] + ",ItemOut7=" +
                              Param[29] + ",ItemOut8=" + Param[30] + ",ItemOut9=" + Param[31] + ",ItemOut10=" +
                              Param[32] + ",ItemOut11=" + Param[33] + ",ItemOut12=" + Param[34] + ",ItemOut13=" +
                              Param[35] + ",ItemOut14=" + Param[36] + ",ItemOut15=" + Param[37] + ",ItemOut16=" +
                              Param[38] + ",ItemOut17=" + Param[39] + ",ItemOut18=" + Param[40] + ",ItemOut19=" +
                              Param[41] + " WHERE ItemID=" + Param[42];
                            break;
                        case 5:
                            ret = "DELETE FROM GZ_Item WHERE ItemID=" + Param[1];
                            break;
                    }
                    break;
                case DBCode.DB_000402:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VGZ_ItemEmp ORDER BY EmpNo";
                            break;
                        case 1:
                            ret = "UPDATE RS_Emp SET GZRuleID=NULL WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "UPDATE RS_Emp SET GZRuleID=" + Param[1] + " WHERE EmpNo='" + Param[2] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM VGZ_ItemEmp WHERE EmpNo='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000403:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VGZ_ItemDepart ORDER BY DepartID";
                            break;
                        case 1:
                            ret = "UPDATE RS_Depart SET GZRuleID=NULL WHERE DepartID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VGZ_ItemDepart WHERE DepartID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "UPDATE RS_Depart SET GZRuleID=" + Param[1] + " WHERE DepartID='" + Param[2] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM VGZ_ItemDepart WHERE DepartID='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000404:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VGZ_Item ORDER BY ItemID";
                            break;
                        case 1:
                            ret = "SELECT * FROM VGZ_Item where ItemID=" + Param[1];
                            break;
                        case 2:
                            ret = "SELECT * FROM VGZ_ItemDepart WHERE DepartID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "UPDATE RS_Depart SET GZRuleID='" + Param[1] + "' WHERE DepartID='" + Param[2] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM VGZ_Report WHERE KQYM='" + Param[7] + "' And GZRuleID=" + Param[1];
                            ret += GetEmpInfoSQL(Param[2], Param[3]) + GetDepartInfoSQL(Param[4], Param[5], Param[6]);
                            ret += " ORDER BY DepartID,EmpNo";
                            break;
                        case 5:
                            ret = "SELECT * FROM VRS_Emp WHERE 1=1";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " ORDER BY DepartID,EmpNo";
                            break;
                        case 6:
                            ret = "EXEC PGZ_Calc '" + Param[1] + "','" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "UPDATE GZ_GZReport SET IsFreeze=" + Param[1] + " WHERE KQYM='" + Param[2] +
                              "'  AND EmpNo='" + Param[3] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_000500:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "INSERT INTO DI_SeaSound([MacSN],VerifyFailAudio,VerifySuccAudio,RemoteCtrlAudio,VerifySuccGuiTip,UnregisteredGuiTip," +
                                "VerifyFailGuiTip,Volume,IPHide,IsShowName,IsShowTitle,IsShowVersion,IsShowDate,IDCardNumHide,ICCardNumHide) VALUES('" + Param[1] + "'," + Param[2] + "," +
                                 "" + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + "," + Param[8] + "," + Param[9] + "," + Param[10] + "" +
                                 "," + Param[11] + "," + Param[12] + "," + Param[13] + "," + Param[14] + "," + Param[15] + ")";
                            break;
                        case 1:
                            ret = "UPDATE DI_SeaSound SET VerifyFailAudio=" + Param[2] + ",VerifySuccAudio=" + Param[3] + ",RemoteCtrlAudio=" + Param[4] + ",VerifySuccGuiTip=" + Param[5] + ",UnregisteredGuiTip=" + Param[6] + "," +
                                "VerifyFailGuiTip=" + Param[7] + ",Volume=" + Param[8] + ",IPHide=" + Param[9] + ",IsShowName=" + Param[10] + ",IsShowTitle=" + Param[11] + ",IsShowVersion=" + Param[12] + "," +
                                "IsShowDate=" + Param[13] + ",IDCardNumHide=" + Param[14] + ",ICCardNumHide=" + Param[15] + " WHERE [MacSN]='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM DI_SeaSound";
                            break;
                        case 10:
                            ret = "INSERT INTO DI_SeaDoorCondition([MacSN],FaceThreshold,IDCardThreshold,OpendoorWay,VerifyMode,Wiegand," +
                                "ControlType,PublicMjCardNo,AutoMjCardBgnNo,AutoMjCardEndNo,IOStayTime) VALUES('" + Param[1] + "'," + Param[2] + "," +
                                 "" + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + ",'" + Param[8] + "','" + Param[9] + "','" + Param[10] + "'" +
                                 ",'" + Param[11] + "')";
                            break;
                        case 11:
                            ret = "UPDATE DI_SeaDoorCondition SET FaceThreshold=" + Param[2] + ",IDCardThreshold=" + Param[3] + ",OpendoorWay=" + Param[4] + ",VerifyMode=" + Param[5] + ",Wiegand=" + Param[6] + "," +
                                "ControlType=" + Param[7] + ",PublicMjCardNo='" + Param[8] + "',AutoMjCardBgnNo='" + Param[9] + "',AutoMjCardEndNo='" + Param[10] + "',IOStayTime='" + Param[11] + "' WHERE [MacSN]='" + Param[1] + "'";
                            break;
                        case 12:
                            ret = "SELECT * FROM DI_SeaDoorCondition";
                            break;
                        case 20:
                            ret = "INSERT INTO DI_SeaTemperature([MacSN],FaceMaskTPTMode,TemperatureCheck,TemperatureHigh,EnvTemperature,EnvTemperatureCheck," +
                                "OpenLaser) VALUES('" + Param[1] + "'," + Param[2] + "," +
                                 "" + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + ")";
                            break;
                        case 21:
                            ret = "UPDATE DI_SeaTemperature SET FaceMaskTPTMode=" + Param[2] + ",TemperatureCheck=" + Param[3] + ",TemperatureHigh=" + Param[4] + ",EnvTemperature=" + Param[5] + ",EnvTemperatureCheck=" + Param[6] + "," +
                                "OpenLaser=" + Param[7] + " WHERE [MacSN]='" + Param[1] + "'";
                            break;
                        case 22:
                            ret = "SELECT * FROM DI_SeaTemperature";
                            break;
                        case 30:
                            ret = "INSERT INTO DI_SeaNetParam([MacSN],IPAddr,Submask,Gateway,ListenPort,WebPort) VALUES('" + Param[1] + "','" + Param[2] + "'," +
                                 "'" + Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "')";
                            break;
                        case 31:
                            ret = "UPDATE DI_SeaNetParam SET IPAddr='" + Param[2] + "',Submask='" + Param[3] + "',Gateway='" + Param[4] + "',ListenPort='" + Param[5] + "',WebPort='" + Param[6] + "' WHERE [MacSN]='" + Param[1] + "'";
                            break;
                        case 32:
                            ret = "SELECT * FROM DI_SeaNetParam";
                            break;
                    }
                    break;
            }
            return ret;
        }
    }
}