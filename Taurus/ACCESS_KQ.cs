using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
//using DAO = Microsoft.Office.Interop.Access.Dao;

namespace Taurus
{
    public class ACCESS_KQ
    {
        private Base Pub = new Base();

        public bool PKQ_KQDataSave(int CardType, string CardNo, DateTime KQDate, string MacSN, string Remark,
         int VerifyModeID, string VerifyModeName, int InOutModeID, string InOutModeName, string Temperature, int TemperatureAlarm, ref string guid)
        {
            bool ret = false;
            guid = "";
            string sql = "";
            if (Temperature == "0") Temperature = "";
            if (CardType == 1)
                sql = "SELECT EmpNo FROM RS_Emp WHERE CardNo10='" + CardNo + "'";
            else if (CardType == 2)
                sql = "SELECT EmpNo FROM RS_Emp WHERE CardNo81='" + CardNo + "'";
            else if (CardType == 3)
                sql = "SELECT EmpNo FROM RS_Emp WHERE CardNo82='" + CardNo + "'";
            else if (CardType == 4)
                sql = "SELECT EmpNo FROM RS_Emp WHERE FingerNo=" + CardNo;
            DataTableReader dr = null;
            string EmpNo = "";
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read()) EmpNo = dr[0].ToString().Trim();
                dr.Close();
                if (EmpNo != "")
                {
                    sql = "SELECT * FROM KQ_KQData WHERE EmpNo='" + EmpNo + "' AND KQDateTime=CDate('" +
                      KQDate.ToString(SystemInfo.SQLDateTimeFMT) + "')";
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (!dr.Read())
                    {
                        guid = GetGUID().ToString();
                        sql = "INSERT INTO KQ_KQData([GUID],EmpNo,KQDateTime,KQDate,KQTime,MacSN,IsSignIn,IsInvalid,OprtNo," +
                          "OprtDate,Remark,VerifyModeID,VerifyModeName,InOutModeID,InOutModeName,Temperature,TemperatureAlarm) VALUES('" + guid + "','" +
                          EmpNo + "',CDate('" + KQDate.ToString(SystemInfo.SQLDateTimeFMT) + "'),CDate('" +
                          KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "'),'" + KQDate.ToString("HHmmss") + "','" +
                          MacSN + "',0,1,'" + OprtInfo.OprtNo + "',now(),'" + Remark + "'," + VerifyModeID.ToString() + ",'" +
                          VerifyModeName + "'," + InOutModeID.ToString() + ",'" + InOutModeName + "','" + Temperature + "'," + TemperatureAlarm + ")";
                        SystemInfo.db.ExecSQL(sql);
                        ret = true;
                    }
                }
            }
            catch (Exception E)
            {
                guid = "";
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return ret;
        }
        public string PKQ_KQDataSaveEx(string EmpNo, DateTime KQDate, string Remark)
        {
            string ret = "";
            string sql = "SELECT EmpNo,KQDateTime FROM KQ_KQData WHERE EmpNo='" + EmpNo + "' AND KQDateTime=CDate('" +
              KQDate.ToString(SystemInfo.SQLDateFMT) + "')";
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (!dr.Read())
                {
                    ret = "INSERT INTO KQ_KQData([GUID],EmpNo,KQDateTime,KQDate,KQTime,MacSN,IsSignIn,IsInvalid,OprtNo," +
                      "OprtDate,Remark) VALUES('" + GetGUID().ToString() + "','" + EmpNo + "',CDate('" +
                      KQDate.ToString(SystemInfo.SQLDateTimeFMT) + "'),CDate('" +
                      KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "'),'" + KQDate.ToString("HHmmss") + "',0,1,1,'" +
                      OprtInfo.OprtNo + "',now(),'" + Remark + "')";
                }
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
            return ret;
        }

        public string PKQ_KQDataSaveExU(string EmpNo, DateTime KQDate, string Remark, string GUID)
        {
            string ret = "UPDATE KQ_KQData SET KQDateTime=CDate('" + KQDate.ToString(SystemInfo.SQLDateTimeFMT) +
              "'),KQDate=CDate('" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "'),KQTime='" +
              KQDate.ToString("HHmmss") + "',OprtNo='" + OprtInfo.OprtNo + "',OprtDate=now(),Remark='" +
              Remark + "' WHERE [GUID]='" + GUID + "'";
            return ret;
        }

        public bool PKQ_MJDataSave(int CardType, DateTime KQDate, string MacSN, string Remark, int VerifyModeID, string VerifyModeName,
       int InOutModeID, string InOutModeName, string CardNo, string DoorStauts, bool IsAlarm, string Temperature, int TemperatureAlarm, ref string guid)
        {
            bool ret = false;
            guid = "";
            string sql = "";
            if (CardType == 1)
                sql = "SELECT EmpNo FROM RS_Emp WHERE CardNo10='" + CardNo + "'";
            else if (CardType == 2)
                sql = "SELECT EmpNo FROM RS_Emp WHERE CardNo81='" + CardNo + "'";
            else if (CardType == 3)
                sql = "SELECT EmpNo FROM RS_Emp WHERE CardNo82='" + CardNo + "'";
            else if (CardType == 4)
                sql = "SELECT EmpNo FROM RS_Emp WHERE FingerNo=" + CardNo;
            string EmpNo = "";
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read()) EmpNo = dr[0].ToString().Trim();
                dr.Close();
                sql = "SELECT * FROM KQ_MJData WHERE MacSN='" + MacSN + "' AND VerifyModeID=" + VerifyModeID.ToString() + " AND KQDateTime=CDate('" + KQDate.ToString(SystemInfo.SQLDateTimeFMT) + "')";
                dr = SystemInfo.db.GetDataReader(sql);
                if (!dr.Read())
                {
                    guid = GetGUID().ToString();
                    sql = "SELECT * FROM KQ_MJData WHERE GUID='" + guid + "'";
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (!dr.Read())
                    {
                        sql = "INSERT INTO KQ_MJData([GUID],KQDateTime,KQDate,KQTime,MacSN,OprtNo,OprtDate,Remark," +
                "VerifyModeID,VerifyModeName,InOutModeID,InOutModeName,FingerNo,DoorStauts,IsAlarm,Temperature,TemperatureAlarm) VALUES('" + guid + "',CDate('" +
                KQDate.ToString(SystemInfo.SQLDateTimeFMT) + "'),CDate('" +
                KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "'),'" + KQDate.ToString("HHmmss") + "','" +
                MacSN + "','" + OprtInfo.OprtNo + "',now(),'" + Remark + "'," + VerifyModeID.ToString() + ",'" +
                VerifyModeName + "'," + InOutModeID.ToString() + ",'" + InOutModeName + "','" + EmpNo.ToString() + "','" + DoorStauts + "','" + Convert.ToByte(IsAlarm).ToString() + "','"+ Temperature + "',"+ TemperatureAlarm + ")";
                        SystemInfo.db.ExecSQL(sql);
                        ret = true;
                    }
                }
            }
            catch (Exception E)
            {
                guid = "";
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return ret;
        }

        public bool PKQ_KQSLogSave(string MacSN, UInt32 SEnrollNo, UInt32 GEnrollNo, int Manipulation, string ManipulationName,
          int BakNo, string BakName, string STime)
        {
            bool ret = false;
            string sql = "INSERT INTO KQ_SuperData(GUID,DevID,SEnrollNo,GEnrollNo,ManID,ManName,BakNo,BakName,STime,OprtNo," +
              "OprtDate) VALUES(newid(),'" + GetGUID().ToString() + "'," + SEnrollNo.ToString() + "," + GEnrollNo.ToString() + "," +
              Manipulation.ToString() + ",'" + ManipulationName + "'," + BakNo.ToString() + ",'" + BakName + "','" + STime + "','" +
              OprtInfo.OprtNo + "',getdate())";
            try
            {
                SystemInfo.db.ExecSQL(sql);
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            return ret;
        }

        private int TimeStrToSecond(string TimeStr)
        {
            int ret = 0;
            ret = Convert.ToInt32(TimeStr.Substring(0, 2)) * 60 * 60 + Convert.ToInt32(TimeStr.Substring(3, 2)) * 60;
            return ret;
        }

        private int TimeStrToMinute(string TimeStr)
        {
            int ret = TimeStrToSecond(TimeStr);
            ret /= 60;
            return ret;
        }

        public double GetTimeSecond(string InTime, string OutTime)
        {
            double ret = 0;
            if (InTime.Length == 5 && OutTime.Length == 5)
            {
                int t1 = TimeStrToSecond(InTime);
                int t2 = TimeStrToSecond(OutTime);
                int t = t2 - t1;
                ret = (double)t;
            }
            return ret;
        }

        private string GetTimeStr(int IntTime)
        {
            string ret = "";
            int Sec = Math.Abs(IntTime);
            int Hour = Sec / 3600;
            Sec %= 3600;
            int Min = Sec / 60;
            ret = string.Format("{0:d2}:{1:d2}", Hour, Min);
            return ret;
        }

        private string DateToTimeStr(DateTime dt)
        {
            string ret = "";
            if (dt.Year != 1) ret = dt.ToString("HH:mm");
            return ret;
        }

        private double RoundNum(double Value)
        {
            return Math.Round(Value, 10);
        }

        private double RoundTwo(double Value)
        {
            return Math.Round(Value, 2);
        }

        private double CalcAdjust(double Src, int Start, int Tune, int Integer)
        {
            double Ret = Src;
            double JCount = 0;

            if (SystemInfo.AllowAdjust)
            {
                if (Start > 0 && Tune > 0 && Integer > 0)
                {
                    if (Ret * 60.00 > Start)
                    {
                        double ICount = RoundNum(Ret * 60.00);
                        Ret = ((int)(ICount / Integer)) * Integer;
                        //JCount = RoundNum(ICount - Ret + Tune);
                        JCount = RoundNum(ICount - Ret);
                        if (JCount >= Tune)
                        {
                            Ret += Integer;
                        }
                        // if (JCount >= Integer) Ret += Integer;
                        Ret = RoundNum(Ret / 60.00);
                    }
                    else
                        Ret = 0;
                }
            }
            return Ret;
        }

        private string GetGUID()
        {
            string ret = System.Guid.NewGuid().ToString().ToUpper();
            return ret;
        }

        private string GetRemark(string sql)
        {
            string ret = "";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            if (dr.Read()) ret = dr[0].ToString().Trim();
            dr.Close();
            return ret;
        }

        private int TimeToMinutes(DateTime Start, DateTime End)
        {
            int ret = (int)Pub.DateDiff(DateInterval.Second, Start, End);
            double mis = ret / 60.00;
            ret = (int)Math.Round(mis, 0);
            if (mis - ret >= 0.5) ret++;
            return ret;
        }

        public void PKQ_Temp_KQ_KQData(DateTime StartDate, DateTime EndDate)
        {
            SystemInfo.db.ExecSQL("DROP TABLE Temp_KQ_KQData", true);
            string sql = "SELECT * INTO Temp_KQ_KQData FROM KQ_KQData WHERE 1=2";
            SystemInfo.db.ExecSQL(sql);
            sql = "ALTER TABLE Temp_KQ_KQData ADD PRIMARY KEY([GUID])";
            SystemInfo.db.ExecSQL(sql);
            sql = "ALTER TABLE Temp_KQ_KQData ADD CONSTRAINT AK_Temp_KQ_KQData UNIQUE(EmpNo,KQDateTime)";
            SystemInfo.db.ExecSQL(sql);
            sql = "INSERT INTO Temp_KQ_KQData([GUID],EmpNo,KQDateTime,KQDate,KQTime,MacSN,IsSignIn,IsInvalid," +
                        "OprtNo,OprtDate,Remark) SELECT [GUID],EmpNo,KQDateTime,KQDate,KQTime,MacSN,IsSignIn,0," +
                        "OprtNo,OprtDate,Remark FROM KQ_KQData WHERE  KQDate>=CDate('" +
                        StartDate.AddDays(-1).ToString(SystemInfo.SQLDateFMT) + "') AND KQDate<=CDate('" +
                        EndDate.AddDays(1).ToString(SystemInfo.SQLDateFMT) + "')";
            SystemInfo.db.ExecSQL(sql);
        }

        private void PKQ_CalcDataFilter(string EmpNo, DateTime StartDate, DateTime EndDate, int DupLimit, ref string sql)
        {
            StartDate = StartDate.AddDays(-1);

            EndDate = EndDate.AddDays(1);

            DupLimit *= 60;
            int MarkIndex = 1;
            bool IsInvalid = false;
            sql = "DELETE FROM KQ_KQDataFilter WHERE EmpNo='" + EmpNo + "' AND KQDate>=CDate('" +
              StartDate.ToString(SystemInfo.SQLDateFMT) + "') AND KQDate<=CDate('" +
              EndDate.ToString(SystemInfo.SQLDateFMT) + "')";
            SystemInfo.db.ExecSQL(sql);
            sql = "DELETE FROM KQ_KQDataFilterMark WHERE EmpNo='" + EmpNo + "' AND KQDate>=CDate('" +
              StartDate.ToString(SystemInfo.SQLDateFMT) + "') AND KQDate<=CDate('" +
              EndDate.ToString(SystemInfo.SQLDateFMT) + "')";
            SystemInfo.db.ExecSQL(sql);
            //sql = "INSERT INTO Temp_KQ_KQData([GUID],EmpNo,KQDateTime,KQDate,KQTime,MacSN,IsSignIn,IsInvalid," +
            //  "OprtNo,OprtDate,Remark) SELECT [GUID],EmpNo,KQDateTime,KQDate,KQTime,MacSN,IsSignIn,0," +
            //  "OprtNo,OprtDate,Remark FROM KQ_KQData WHERE EmpNo='" + EmpNo + "' AND KQDate>=CDate('" +
            //  StartDate.ToString(SystemInfo.SQLDateFMT) + "') AND KQDate<=CDate('" +
            //  EndDate.ToString(SystemInfo.SQLDateFMT) + "')";
            //SystemInfo.db.ExecSQL(sql);
            sql = "SELECT KQDateTime,MacSN,OprtNo,OprtDate FROM Temp_KQ_KQData WHERE EmpNo='" + EmpNo + "' AND KQDate>=CDate('" +
                  StartDate.ToString(SystemInfo.SQLDateFMT) + "') AND KQDate<=CDate('" +
                  EndDate.ToString(SystemInfo.SQLDateFMT) + "') ORDER BY KQDateTime";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            DateTime dt = new DateTime();
            DateTime dt1 = new DateTime();
            DateTime optDate = new DateTime();
            string MacSN = "";
            string OprtNo = "";
            DateTime[] MarkDate = new DateTime[10];

            int NumMarkIndex = 0;
            while (dr.Read())
            {
                DateTime.TryParse(dr[0].ToString(), out dt);
                DateTime.TryParse(dr[3].ToString(), out optDate);
                MacSN = dr[1].ToString();
                OprtNo = dr[2].ToString();
                if (dt1.Year == 1)
                {
                    sql = "INSERT INTO Temp_KQ_KQDataFilter([GUID],EmpNo,KQDateTime,KQDate,KQTime,MarkIndex,MacSN," +
                      "IsInvalid,OprtNo,OprtDate) VALUES('" + GetGUID().ToString() + "','" + EmpNo + "',CDate('" +
                      dt.ToString(SystemInfo.SQLDateTimeFMT) + "'),CDate('" + dt.ToString(SystemInfo.SQLDateFMT) +
                      "'),'" + dt.ToString("HH:mm:ss") + "'," + MarkIndex.ToString() + ",'" + MacSN + "'," +
                      Convert.ToByte(IsInvalid).ToString() + ",'" + OprtNo + "',CDate('" +
                      optDate.ToString(SystemInfo.SQLDateTimeFMT) + "'))";
                    SystemInfo.db.ExecSQL(sql);
                    MarkDate[MarkIndex - 1] = dt;
                    dt1 = dt;
                    MarkIndex += 1;
                }
                else if (dt1.Date == dt.Date && Pub.DateDiff(DateInterval.Second, dt1, dt) >= DupLimit)
                {
                    sql = "INSERT INTO Temp_KQ_KQDataFilter([GUID],EmpNo,KQDateTime,KQDate,KQTime,MarkIndex,MacSN," +
                      "IsInvalid,OprtNo,OprtDate) VALUES('" + GetGUID().ToString() + "','" + EmpNo + "',CDate('" +
                      dt.ToString(SystemInfo.SQLDateTimeFMT) + "'),CDate('" + dt.ToString(SystemInfo.SQLDateFMT) +
                      "'),'" + dt.ToString("HH:mm:ss") + "'," + MarkIndex.ToString() + ",'" + MacSN + "'," +
                      Convert.ToByte(IsInvalid).ToString() + ",'" + OprtNo + "',CDate('" +
                      optDate.ToString(SystemInfo.SQLDateTimeFMT) + "'))";
                    SystemInfo.db.ExecSQL(sql);
                    if (MarkIndex <= 10) MarkDate[MarkIndex - 1] = dt;
                    dt1 = dt;
                    MarkIndex += 1;

                }
                else if (dt.Date > dt1.Date && Pub.DateDiff(DateInterval.Second, dt1, dt) + 86399 >= DupLimit)
                {
                    sql = "INSERT INTO KQ_KQDataFilterMark([GUID],EmpNo,KQDate,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10) VALUES('" +
                      GetGUID().ToString() + "','" + EmpNo + "',CDate('" + MarkDate[0].ToString(SystemInfo.SQLDateFMT) +
                      "'),'" + MarkDate[0].ToString("HH:mm") + "','" + DateToTimeStr(MarkDate[1]) + "','" +
                      DateToTimeStr(MarkDate[2]) + "','" + DateToTimeStr(MarkDate[3]) + "','" +
                      DateToTimeStr(MarkDate[4]) + "','" + DateToTimeStr(MarkDate[5]) + "','" +
                      DateToTimeStr(MarkDate[6]) + "','" + DateToTimeStr(MarkDate[7]) + "','" +
                      DateToTimeStr(MarkDate[8]) + "','" + DateToTimeStr(MarkDate[9]) + "')";
                    SystemInfo.db.ExecSQL(sql);
                    if (dt1.Date == StartDate)
                    {
                    }
                    else
                    {
                        NumMarkIndex = NumMarkIndex + MarkIndex - 1;
                    }

                    MarkIndex = 1;
                    sql = "INSERT INTO Temp_KQ_KQDataFilter([GUID],EmpNo,KQDateTime,KQDate,KQTime,MarkIndex,MacSN," +
                      "IsInvalid,OprtNo,OprtDate) VALUES('" + GetGUID().ToString() + "','" + EmpNo + "',CDate('" +
                      dt.ToString(SystemInfo.SQLDateTimeFMT) + "'),CDate('" + dt.ToString(SystemInfo.SQLDateFMT) +
                      "'),'" + dt.ToString("HH:mm:ss") + "'," + MarkIndex.ToString() + ",'" + MacSN + "'," +
                      Convert.ToByte(IsInvalid).ToString() + ",'" + OprtNo + "',CDate('" +
                      optDate.ToString(SystemInfo.SQLDateTimeFMT) + "'))";
                    SystemInfo.db.ExecSQL(sql);
                    MarkDate = new DateTime[10];
                    MarkDate[MarkIndex - 1] = dt;
                    dt1 = dt;
                    MarkIndex += 1;
                }
            }
            dr.Close();
            sql = "INSERT INTO KQ_KQDataFilter([GUID],EmpNo,KQDateTime,KQDate,KQTime,MarkIndex,MacSN,IsInvalid," +
              "OprtNo,OprtDate) SELECT [GUID],EmpNo,KQDateTime,KQDate,KQTime,MarkIndex,MacSN,IsInvalid,OprtNo," +
              "OprtDate FROM Temp_KQ_KQDataFilter";
            SystemInfo.db.ExecSQL(sql);
            if (MarkDate[0].Year != 1)
            {
                if (dt.Date == EndDate)
                {
                }
                else
                {
                    NumMarkIndex = NumMarkIndex + MarkIndex - 1;
                }

                NumMarkIndex = 0;
                sql = "INSERT INTO KQ_KQDataFilterMark([GUID],EmpNo,KQDate,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10) VALUES('" +
                  GetGUID().ToString() + "','" + EmpNo + "',CDate('" + MarkDate[0].ToString(SystemInfo.SQLDateFMT) +
                  "'),'" + MarkDate[0].ToString("HH:mm") + "','" + DateToTimeStr(MarkDate[1]) + "','" +
                  DateToTimeStr(MarkDate[2]) + "','" + DateToTimeStr(MarkDate[3]) + "','" +
                  DateToTimeStr(MarkDate[4]) + "','" + DateToTimeStr(MarkDate[5]) + "','" +
                  DateToTimeStr(MarkDate[6]) + "','" + DateToTimeStr(MarkDate[7]) + "','" +
                  DateToTimeStr(MarkDate[8]) + "','" + DateToTimeStr(MarkDate[9]) + "')";
                SystemInfo.db.ExecSQL(sql);
            }
            sql = "";
        }

        private void PKQ_CalcFindTime(string EmpNo, bool IsChangeMark, DateTime BeginDateTime, DateTime EndDateTime,
          bool IsIn, ref DateTime KQDateTime, ref string sql)
        {
            KQDateTime = new DateTime();
            DateTime T1 = BeginDateTime;
            DateTime T2 = BeginDateTime.Date.AddDays(1).AddSeconds(-1);
            DateTime T3 = EndDateTime.Date;
            DateTime T4 = EndDateTime;
            if (BeginDateTime.Date != EndDateTime.Date)
            {
                sql = "SELECT TOP 1 KQDateTime FROM Temp_KQ_KQDataFilter WHERE NOT IsInvalid AND EmpNo='" +
                  EmpNo + "' AND ((KQDateTime>=CDate('" + T1.ToString(SystemInfo.SQLDateTimeFMT) +
                  "') AND KQDateTime<=CDate('" + T2.ToString(SystemInfo.SQLDateTimeFMT) +
                  "')) OR (KQDateTime>=CDate('" + T3.ToString(SystemInfo.SQLDateTimeFMT) +
                  "') AND KQDateTime<=CDate('" + T4.ToString(SystemInfo.SQLDateTimeFMT) + "'))) ORDER BY KQDateTime";
            }
            else
            {
                sql = "SELECT TOP 1 KQDateTime FROM Temp_KQ_KQDataFilter WHERE NOT IsInvalid AND EmpNo='" +
                  EmpNo + "' AND (KQDateTime>=CDate('" + T1.ToString(SystemInfo.SQLDateTimeFMT) +
                  "') AND KQDateTime<=CDate('" + T4.ToString(SystemInfo.SQLDateTimeFMT) + "')) ORDER BY KQDateTime";
            }
            if (!IsIn) sql += " DESC";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            if (dr.Read()) DateTime.TryParse(dr[0].ToString(), out KQDateTime);
            dr.Close();
            if (KQDateTime.Year != 1 && IsChangeMark)
            {
                sql = "UPDATE Temp_KQ_KQDataFilter SET IsInvalid=1 WHERE EmpNo='" + EmpNo +
                  "' AND KQDateTime=CDate('" + KQDateTime.ToString(SystemInfo.SQLDateTimeFMT) + "')";
                SystemInfo.db.ExecSQL(sql);
            }
            sql = "";
        }

        private void PKQ_CalcOutHrs(string EmpNo, DateTime BeginTime, DateTime EndTime, ref double OutHrs,
          ref string sql)
        {
            bool ret = false;
            string ssql = "SELECT[Value] FROM SY_Config WHERE ID = 'SystemInfo' AND[Key] = 'OutHrs'";
            DataTableReader dr = SystemInfo.db.GetDataReader(ssql);
            if (dr.Read())
            {
                if (dr[0].ToString() == "1") ret = true;
                else ret = false;
            }
            if (ret)
            {
                OutHrs = 0;
                if (BeginTime.Year == 1 || EndTime.Year == 1) return;
                DateTime InDateTime = BeginTime.AddSeconds(1);
                DateTime OutDateTime = EndTime.AddSeconds(-1);
                DateTime T1 = new DateTime();
                DateTime T2 = new DateTime();
                while (InDateTime.Year != 1 && OutDateTime.Year != 1)
                {
                    PKQ_CalcFindTime(EmpNo, false, InDateTime, OutDateTime, true, ref T1, ref sql);
                    if (T1.Year != 1)
                    {
                        InDateTime = T1.AddSeconds(1);
                        PKQ_CalcFindTime(EmpNo, false, InDateTime, OutDateTime, true, ref T2, ref sql);
                        if (T2.Year != 1) InDateTime = T2.AddSeconds(1);
                    }
                    if (T1.Year == 1 || T2.Year == 1) break;
                    OutHrs += TimeToMinutes(T1, T2);
                }
                OutHrs /= 60.00;
                OutHrs = RoundNum(OutHrs);
                if (OutHrs < 0 || OutHrs > 24) OutHrs = 0;
            }

        }

        private void PKQ_CalcOtHrs(string EmpNo, DateTime BeginTime, DateTime EndTime, bool AheadHrs, int AheadMins,
          bool DeferHrs, int DeferMins, bool ReadLate, bool ReadLeave, ref double OtHrs, ref double OutHrs,
          ref string sql)
        {
            OtHrs = 0;
            OutHrs = 0;
            if (BeginTime.Year == 1 || EndTime.Year == 1) return;
            DateTime InDateTime = BeginTime;
            DateTime OutDateTime = EndTime;
            DateTime KQInDateTime = new DateTime();
            DateTime KQOutDateTime = new DateTime();
            if (AheadHrs) InDateTime = InDateTime.AddMinutes(-AheadMins);
            if (DeferHrs) OutDateTime = OutDateTime.AddMinutes(DeferMins);
            if (AheadHrs)
            {
                PKQ_CalcFindTime(EmpNo, false, InDateTime, EndTime, true, ref KQInDateTime, ref sql);
                InDateTime = KQInDateTime;
            }
            if (DeferHrs)
            {
                PKQ_CalcFindTime(EmpNo, false, BeginTime, OutDateTime, false, ref KQOutDateTime, ref sql);
                OutDateTime = KQOutDateTime;
            }
            if (InDateTime.Year != 1 && OutDateTime.Year != 1)
            {
                OtHrs = TimeToMinutes(BeginTime, EndTime);
                if (ReadLate)
                {
                    if (InDateTime > BeginTime) OtHrs -= TimeToMinutes(BeginTime, InDateTime);
                    if (BeginTime > InDateTime) OtHrs += TimeToMinutes(InDateTime, BeginTime);
                }
                if (ReadLeave)
                {
                    if (EndTime > OutDateTime) OtHrs -= TimeToMinutes(OutDateTime, EndTime);
                    if (OutDateTime > EndTime) OtHrs += TimeToMinutes(EndTime, OutDateTime);
                }
                OtHrs /= 60.00;
                OtHrs = RoundNum(OtHrs);
            }
            if (OtHrs < 0 || OtHrs > 24) OtHrs = 0;
            PKQ_CalcOutHrs(EmpNo, InDateTime, OutDateTime, ref OutHrs, ref sql);
        }

        private void PKQ_CalcRegHrs(string EmpNo, string DayOffIDList, DateTime BeginTime, DateTime EndTime,bool IsLeaveOvertime, string SortIDOld,
          ref double RegHrs, ref double[] Hrs, ref string sql)
        {
            RegHrs = 0;
            for (int i = 0; i < Hrs.Length; i++) Hrs[i] = 0;
            sql = "SELECT a.BeginTime,a.EndTime,a.SortID,b.Start,b.Tune,b.[Integer] FROM KQ_EmpDayOff a,KQ_RuleCalc b " +
              "WHERE b.SortID=a.SortID AND a.EmpNo='" + EmpNo + "' AND ((a.BeginTime>=CDate('" +
              BeginTime.ToString(SystemInfo.SQLDateTimeFMT) + "') AND a.EndTime<=CDate('" +
              EndTime.ToString(SystemInfo.SQLDateTimeFMT) + "')) OR (a.BeginTime>=CDate('" +
              BeginTime.ToString(SystemInfo.SQLDateTimeFMT) + "') AND a.BeginTime<CDate('" +
              EndTime.ToString(SystemInfo.SQLDateTimeFMT) + "') AND a.EndTime>CDate('" +
              EndTime.ToString(SystemInfo.SQLDateTimeFMT) + "')) OR (a.BeginTime<CDate('" +
              BeginTime.ToString(SystemInfo.SQLDateTimeFMT) + "') AND a.EndTime>=CDate('" +
              EndTime.ToString(SystemInfo.SQLDateTimeFMT) + "')) OR (a.BeginTime < CDate('"+
              BeginTime.ToString(SystemInfo.SQLDateTimeFMT)+"') AND a.EndTime <= CDate('"+ 
              EndTime.ToString(SystemInfo.SQLDateTimeFMT) + "') AND a.EndTime > CDate('"+ 
              BeginTime.ToString(SystemInfo.SQLDateTimeFMT) + "')))";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            DateTime T1 = new DateTime();
            DateTime T2 = new DateTime();
            string SortID = "";
            double Count = 0;
            int Start = 0;
            int Tune = 0;
            int Integer = 0;
            while (dr.Read())
            {
                DateTime.TryParse(dr[0].ToString(), out T1);
                DateTime.TryParse(dr[1].ToString(), out T2);
                SortID = dr[2].ToString();
                int.TryParse(dr[3].ToString(), out Start);
                int.TryParse(dr[4].ToString(), out Tune);
                int.TryParse(dr[5].ToString(), out Integer);
                if (T1 >= BeginTime)
                {
                    if (T2 > EndTime)
                        Count = TimeToMinutes(T1, EndTime);
                    else
                        Count = TimeToMinutes(T1, T2);
                }
                else if (T2 > EndTime)
                    Count = TimeToMinutes(BeginTime, EndTime);
                else
                    Count = TimeToMinutes(BeginTime, T2);
                Count /= 60.00;
                Count = RoundNum(Count);
                if (Count < 0 || Count > 24) Count = 0;
                if (IsLeaveOvertime && Convert.ToInt32(SortIDOld.Replace("A0", "")) > 10 && Convert.ToInt32(SortIDOld.Replace("A0", "")) < 21)
                    Count = 0;
                RegHrs += Count;
                RegHrs = CalcAdjust(RegHrs, Start, Tune, Integer);
                while (SortID.Length < 10) SortID = "0" + SortID;
                for (int i = 0; i < Hrs.Length; i++)
                {
                    if (DayOffIDList.IndexOf(SortID) == i * 10)
                    {
                        Hrs[i] = RegHrs;
                        break;
                    }
                }
               
            }
            dr.Close();
            sql = "";
        }

        private void PKQ_CalcRest(string EmpNo, DateTime Date, string RuleID, string DayOffIDList, bool ReadLate,
          bool ReadLeave,bool IsLeaveOvertime, ref double OtHrs, ref double OutHrs, ref double RegHrs, ref double[] Hrs, ref string sql)
        {
            OtHrs = 0;
            OutHrs = 0;
            RegHrs = 0;
            for (int i = 0; i < Hrs.Length; i++) Hrs[i] = 0;
            DateTime RestTime = Date.AddSeconds(86399);
            sql = "SELECT a.BeginTime,a.EndTime,a.AheadHrs,a.AheadMins,a.DeferHrs,a.DeferMins,b.OvertimeRate," +
              "b.Start,b.Tune,b.[Integer],a.SortID FROM KQ_EmpOtSure a,KQ_RuleCalc b WHERE b.SortID=a.SortID AND " +
              "EmpNo='" + EmpNo + "' AND BeginTime>=CDate('" + Date.ToString(SystemInfo.SQLDateTimeFMT) +
              "') AND EndTime<=CDate('" + RestTime.ToString(SystemInfo.SQLDateTimeFMT) + "')";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            DateTime BeginTime = new DateTime();
            DateTime EndTime = new DateTime();
            bool AheadHrs = false;
            int AheadMins = 0;
            bool DeferHrs = false;
            int DeferMins = 0;
            double Rate = 0;
            int Start = 0;
            int Tune = 0;
            int Integer = 0;
            double OtHrs1 = 0;
            double OutHrs1 = 0;
            double RegHrs1 = 0;
            string SortIDOld = "";
            double[] HrsX = new double[10];
            while (dr.Read())
            {
                DateTime.TryParse(dr[0].ToString(), out BeginTime);
                DateTime.TryParse(dr[1].ToString(), out EndTime);
                bool.TryParse(dr[2].ToString(), out AheadHrs);
                int.TryParse(dr[3].ToString(), out AheadMins);
                bool.TryParse(dr[4].ToString(), out DeferHrs);
                int.TryParse(dr[5].ToString(), out DeferMins);
                double.TryParse(dr[6].ToString(), out Rate);
                int.TryParse(dr[7].ToString(), out Start);
                int.TryParse(dr[8].ToString(), out Tune);
                int.TryParse(dr[9].ToString(), out Integer);
                SortIDOld = dr[10].ToString();
                OtHrs1 = 0;
                OutHrs1 = 0;
                PKQ_CalcOtHrs(EmpNo, BeginTime, EndTime, AheadHrs, AheadMins, DeferHrs, DeferMins, ReadLate, ReadLeave,
                  ref OtHrs1, ref OutHrs1, ref sql);
                OtHrs1 *= Rate;
                OtHrs1 = CalcAdjust(OtHrs1, Start, Tune, Integer);
                OtHrs += OtHrs1;
                OutHrs += OutHrs1;
                PKQ_CalcRegHrs(EmpNo, DayOffIDList, BeginTime, EndTime, IsLeaveOvertime, SortIDOld, ref RegHrs1, ref HrsX, ref sql);
                RegHrs += RegHrs1;
                for (int i = 0; i < Hrs.Length; i++) Hrs[i] += HrsX[i];
            }
            dr.Close();
        }

        private void PKQ_CalcFindShiftA(string EmpNo, DateTime Date, int SAhead, int SDefer, string SIn, string SOut,
          bool NeedIn, bool NeedOut, ref bool Exists, int LateHrs, int LeaveHrs, ref int LateMins, ref int LeaveMins,
          ref string sql)
        {
            Exists = false;
            double SHrs = RoundNum(GetTimeSecond(SIn, SOut) / 60.00 / 60.00);
            int InMi = TimeStrToMinute(SIn);
            int OutMi = TimeStrToMinute(SOut);
            DateTime BeginTime = Date.AddMinutes(InMi);
            DateTime EndTime = Date.AddMinutes(OutMi);
            DateTime T = BeginTime.AddMinutes(-SAhead);
            DateTime T0 = BeginTime.AddMinutes(LateHrs);
            DateTime T1DateTime = new DateTime();
            DateTime T2DateTime = new DateTime();
            string InTime = "";
            string OutTime = "";
            string s;
            int MinuteS;
            PKQ_CalcFindTime(EmpNo, false, T, T0, true, ref T1DateTime, ref sql);
            if (T1DateTime.Year != 1)
            {
                s = T1DateTime.ToString("HH:mm:ss");
                MinuteS = TimeStrToMinute(s);
                if (InMi >= 1440)
                    MinuteS += ((int)Pub.DateDiff(DateInterval.Day, Date, T1DateTime.Date)) * 1440;
                else
                    MinuteS += ((int)Pub.DateDiff(DateInterval.Day, T1DateTime.Date, Date)) * 1440;
                InTime = GetTimeStr(MinuteS * 60);
            }
            if (!NeedOut)
                OutTime = SOut;
            else
            {
                T = EndTime.AddMinutes(SDefer);
                T0 = EndTime.AddMinutes(-LeaveHrs);
                PKQ_CalcFindTime(EmpNo, false, T0, T, false, ref T2DateTime, ref sql);
                if (T2DateTime.Year != 1)
                {
                    s = T2DateTime.ToString("HH:mm:ss");
                    MinuteS = TimeStrToMinute(s);
                    MinuteS += ((int)Pub.DateDiff(DateInterval.Day, Date, T2DateTime.Date)) * 1440;
                    OutTime = GetTimeStr(MinuteS * 60);
                }
            }
            if (InTime != "" && OutTime != "")
            {
                Exists = true;
                int SInMi = TimeStrToMinute(InTime);
                int SOutMi = TimeStrToMinute(OutTime);
                if (SInMi >= InMi) LateMins += (SInMi - InMi);
                if (OutMi >= SOutMi) LeaveMins += (OutMi - SOutMi);
            }
        }

        private void PKQ_CalcFindShift(string EmpNo, DateTime Date, string FindShiftID, ref string ShiftID,
          int LateHrs, int LeaveHrs, ref string sql)
        {
            ShiftID = "";
            sql = "SELECT * FROM KQ_Shift WHERE ShiftID='" + FindShiftID + "'";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            int[] SAhead = new int[5];
            int[] SDefer = new int[5];
            string[] SIn = new string[5];
            string[] SOut = new string[5];
            bool[] NeedIn = new bool[5];
            bool[] NeedOut = new bool[5];
            bool[] Exists = new bool[5];
            int LateMins = 0;
            int LeaveMins = 0;
            if (dr.Read())
            {
                for (int i = 1; i <= 5; i++)
                {
                    int.TryParse(dr["ShiftAhead" + i.ToString()].ToString(), out SAhead[i - 1]);
                    int.TryParse(dr["ShiftDefer" + i.ToString()].ToString(), out SDefer[i - 1]);
                    SIn[i - 1] = dr["SigninTime" + i.ToString()].ToString();
                    SOut[i - 1] = dr["SignoutTime" + i.ToString()].ToString();
                    bool.TryParse(dr["Signin" + i.ToString()].ToString(), out NeedIn[i - 1]);
                    bool.TryParse(dr["Signout" + i.ToString()].ToString(), out NeedOut[i - 1]);
                }
            }
            dr.Close();
            for (int i = 0; i < 5; i++)
            {
                if (SIn[i] != "" && SOut[i] != "")
                    PKQ_CalcFindShiftA(EmpNo, Date, SAhead[i], SDefer[i], SIn[i], SOut[i], NeedIn[i], NeedOut[i],
                      ref Exists[i], LateHrs, LeaveHrs, ref LateMins, ref LeaveMins, ref sql);
                else if (i == 0)
                    return;
                else
                    Exists[i] = true;
            }
            bool b = true;
            for (int i = 0; i < 5; i++)
            {
                if (!Exists[i])
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                ShiftID = FindShiftID;
                sql = "SELECT * FROM KQ_ShiftFind WHERE ShiftID='" + ShiftID + "'";
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                    sql = "UPDATE KQ_ShiftFind SET LateMins=LateMins+" + LateMins.ToString() + ",LeaveMins=LeaveMins+" +
                      LeaveMins.ToString() + " WHERE ShiftID='" + ShiftID + "'";
                else
                    sql = "INSERT INTO KQ_ShiftFind(ShiftID,LateMins,LeaveMins) VALUES('" + ShiftID + "'," + LateMins.ToString() + "," + LeaveMins.ToString() + ")";
                SystemInfo.db.ExecSQL(sql);
            }
        }

        private void PKQ_CalcLateLeaveMins(string EmpNo, DateTime Date, int LateIgnore, int LeaveIgnore,
          int LateLeaveCalHrs, bool AheadHrs, int AheadMins, bool DeferHrs, int DeferMins, string SIn, string SOut,
          string InTime, string OutTime, double ShiftHrs, int LateHrs, int LeaveHrs, ref int LateMins,
          ref int LeaveMins, ref double AbsentDays, ref int LateCount, ref int LeaveCount, ref double OtHrs,
          ref string sql)
        {
            LateMins = 0;
            LeaveMins = 0;
            AbsentDays = 0;
            LateCount = 0;
            LeaveCount = 0;
            OtHrs = 0;
            int SInMi = TimeStrToMinute(SIn);
            int SOutMi = TimeStrToMinute(SOut);
            int InMi = TimeStrToMinute(InTime);
            int OutMi = TimeStrToMinute(OutTime);
            double Hrs = RoundNum((SOutMi - SInMi) / 60.00);
            double AheadOtHrs = 0;
            double DeferOtHrs = 0;
            DateTime SInDate = Date.AddMinutes(SInMi);
            DateTime SOutDate = Date.AddMinutes(SOutMi);
            sql = "SELECT a.BeginTime,a.EndTime FROM KQ_EmpDayOff a,KQ_RuleCalc b WHERE b.SortID=a.SortID AND " +
              "a.EmpNo='" + EmpNo + "' AND a.BeginTime<=CDate('" + SInDate.ToString(SystemInfo.SQLDateTimeFMT) +
              "') AND a.EndTime>=CDate('" + SInDate.ToString(SystemInfo.SQLDateTimeFMT) + "')";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            DateTime LBegin = new DateTime();
            DateTime LEnd = new DateTime();
            if (dr.Read())
            {
                DateTime.TryParse(dr[0].ToString(), out LBegin);
                DateTime.TryParse(dr[1].ToString(), out LEnd);
            }
            dr.Close();
            LateMins = InMi - SInMi;
            if (LateMins > 0 && LBegin.Year != 1)
            {
                int LEndMins = TimeStrToMinute(LEnd.ToString("HH:mm"));
                if (Date.Day < LEnd.Day)
                {
                    LEndMins = (LEnd.Day - Date.Day) * 24 * 60 + LEndMins;
                }
                LateMins = InMi - LEndMins;
                if (LateMins < 0) LateMins = 0;
            }
            if ((LateMins >= LateHrs && LateHrs > 0) || (LateMins > 0 && LateHrs == 0))
            {
                if (ShiftHrs > 0)
                {
                    AbsentDays = RoundNum(Hrs / ShiftHrs);
                    LateMins = 0;
                    LateCount = 0;
                }
                else
                {
                    LateCount = 1;
                }
               
            }
            else if (LateMins >= 0)
            {
                if ((LateMins >= LateIgnore && LateIgnore > 0) || (LateMins > 0 && LateIgnore == 0))
                {
                    if (LateMins >= LateLeaveCalHrs && LateLeaveCalHrs > 0)
                    {
                        if (ShiftHrs > 0) AbsentDays = RoundNum(LateMins / 60.00 / ShiftHrs);
                    }
                    LateCount = 1;
                }
                else
                    LateMins = 0;
            }
            else
            {
                LateMins = 0;
                if (AheadHrs)
                {
                    AheadOtHrs = SInMi - InMi;
                    if (AheadOtHrs >= AheadMins && AheadMins >= 0)
                        AheadOtHrs = RoundNum(AheadOtHrs / 60.00);
                    else
                        AheadOtHrs = 0;
                }
            }
            sql = "SELECT a.BeginTime,a.EndTime FROM KQ_EmpDayOff a,KQ_RuleCalc b WHERE b.SortID=a.SortID AND " +
              "a.EmpNo='" + EmpNo + "' AND a.BeginTime<=CDate('" + SOutDate.ToString(SystemInfo.SQLDateTimeFMT) +
              "') AND a.EndTime>=CDate('" + SOutDate.ToString(SystemInfo.SQLDateTimeFMT) + "')";
            dr = SystemInfo.db.GetDataReader(sql);
            LBegin = new DateTime();
            LEnd = new DateTime();
            if (dr.Read())
            {
                DateTime.TryParse(dr[0].ToString(), out LBegin);
                DateTime.TryParse(dr[1].ToString(), out LEnd);
            }
            dr.Close();
            LeaveMins = SOutMi - OutMi;
            if (LeaveMins > 0 && LBegin.Year != 1)
            {
                int LEndMins = TimeStrToMinute(LEnd.ToString("HH:mm"));
                if (Date.Day < LEnd.Day)
                {
                    LEndMins = (LEnd.Day - Date.Day) * 24 * 60 + LEndMins;
                }
                LeaveMins = SOutMi - LEndMins;
                //if (LeaveMins < 0) LeaveMins += 24 * 60;
                if (LeaveMins < 0) LeaveMins = 0;
            }
            if ((LeaveMins >= LeaveHrs && LeaveHrs > 0) || (LeaveMins > 0 && LeaveHrs == 0))
            {
                if (ShiftHrs > 0)
                {
                    AbsentDays = RoundNum(Hrs / ShiftHrs);
                    LeaveMins = 0;
                    LeaveCount = 0;
                } 
                else
                {
                    LeaveCount = 1;
                }
            }
            else if (LeaveMins >= 0)
            {
                if ((LeaveMins >= LeaveIgnore && LeaveIgnore > 0) || (LeaveMins > 0 && LeaveIgnore == 0))
                {
                    if (LeaveMins >= LateLeaveCalHrs && LateLeaveCalHrs > 0)
                    {
                        if (ShiftHrs > 0) AbsentDays = RoundNum(AbsentDays + LeaveMins / 60.00 / ShiftHrs);
                    }
                    LeaveCount = 1;
                }
                else
                    LeaveMins = 0;
            }
            else
            {
                LeaveMins = 0;
                if (DeferHrs)
                {
                    DeferOtHrs = OutMi - SOutMi;
                    if (DeferOtHrs >= DeferMins && DeferMins >= 0)
                        DeferOtHrs = RoundNum(DeferOtHrs / 60.00);
                    else
                        DeferOtHrs = 0;
                }
            }
            OtHrs = AheadOtHrs + DeferOtHrs;
            if (OtHrs < 0 || OtHrs > 24) OtHrs = 0;
            sql = "";
        }

        private void PKQ_CalcNormalTime(string EmpNo, DateTime Date, string DayOffIDList, double ShiftHrs, int SAhead,
          int SDefer, string SIn, string SOut, bool NeedIn, bool NeedOut, string SortID, bool Drift, int TypeID,
          int OTType, double Rate, int ShiftIndex, ref string InTime, ref string OutTime, ref double RegHrsT,
          ref double AbsentDays, ref int LateMins, ref int LateCount, ref int LeaveMins, ref int LeaveCount,
          ref double OtHrs, ref double OtHrsM, ref double SunHrsM, ref double HdHrsM, ref double OutHrs,
          ref double RegHrs, ref double[] Hrs, DateTime DriftTime, int LateIgnore, int LeaveIgnore,
          int LateLeaveCalHrs, bool AheadHrs, int AheadMins, bool DeferHrs, int DeferMins, bool ReadLate,
          bool ReadLeave, int LateHrs, int LeaveHrs, int Start, int Tune, int Integer,bool IsLeaveOvertime, ref string sql, ref double SHrs)
        {
            SHrs = RoundNum(GetTimeSecond(SIn, SOut) / 60.00 / 60.00);
            int InMi = TimeStrToMinute(SIn);
            int OutMi = TimeStrToMinute(SOut);
            DateTime BeginTime = Date.AddMinutes(InMi);
            DateTime EndTime = Date.AddMinutes(OutMi);
            double RegHrs1 = 0;
            double[] HrsX = new double[10];

            PKQ_CalcRegHrs(EmpNo, DayOffIDList, BeginTime, EndTime, IsLeaveOvertime, SortID, ref RegHrs1, ref HrsX, ref sql);

            RegHrs += RegHrs1;
            for (int i = 0; i < 9; i++) Hrs[i] += HrsX[i];
            InTime = "";
            OutTime = "";
            string s;
            int MinuteS;
            DateTime T;
            DateTime T1DateTime = new DateTime();
            DateTime T2DateTime = new DateTime();
            double OtHrs1 = 0;
            double OutHrs1 = 0;
            double AbsentDays1 = 0;
            int LateMins1 = 0;
            int LateCount1 = 0;
            int LeaveMins1 = 0;
            int LeaveCount1 = 0;
            double ShiftOtHrs = 0;
            if (!NeedIn)
                InTime = SIn;
            else
            {
                T = BeginTime.AddMinutes(-SAhead);
                PKQ_CalcFindTime(EmpNo, true, T, EndTime, true, ref T1DateTime, ref sql);
                if (T1DateTime.Year != 1)
                {
                    s = T1DateTime.ToString("HH:mm:ss");
                    MinuteS = TimeStrToMinute(s);
                    if (InMi >= 1440)
                        MinuteS += ((int)Pub.DateDiff(DateInterval.Day, Date, T1DateTime.Date)) * 1440;
                    else
                        MinuteS += ((int)Pub.DateDiff(DateInterval.Day, T1DateTime.Date, Date)) * 1440;
                    InTime = GetTimeStr(MinuteS * 60);
                }
            }
            if (!NeedOut)
                OutTime = SOut;
            else if (!Drift)
            {
                T = EndTime.AddMinutes(SDefer);
                PKQ_CalcFindTime(EmpNo, true, BeginTime, T, false, ref T2DateTime, ref sql);
                if (T2DateTime.Year != 1)
                {
                    s = T2DateTime.ToString("HH:mm:ss");
                    MinuteS = TimeStrToMinute(s);
                    MinuteS += ((int)Pub.DateDiff(DateInterval.Day, Date, T2DateTime.Date)) * 1440;
                    OutTime = GetTimeStr(MinuteS * 60);
                }
            }
            else
            {
                PKQ_CalcFindTime(EmpNo, true, EndTime, DriftTime, true, ref T2DateTime, ref sql);
                if (T2DateTime.Year == 1)
                {
                    T = EndTime.AddMinutes(SDefer);
                    PKQ_CalcFindTime(EmpNo, true, BeginTime, T, false, ref T2DateTime, ref sql);
                }
                if (T2DateTime.Year != 1)
                {
                    s = T2DateTime.ToString("HH:mm:ss");
                    MinuteS = TimeStrToMinute(s);
                    MinuteS += ((int)Pub.DateDiff(DateInterval.Day, Date, T2DateTime.Date)) * 1440;
                    OutTime = GetTimeStr(MinuteS * 60);
                }
            }
            if (TypeID == 0)//正常班段
            {
                RegHrsT += RegHrs1;
                if (InTime == "" || OutTime == "")
                    AbsentDays += RoundNum(SHrs / ShiftHrs - RegHrs1 / ShiftHrs);
                else
                {
                    PKQ_CalcOutHrs(EmpNo, BeginTime, EndTime, ref OutHrs1, ref sql);
                    OutHrs += OutHrs1;
                    PKQ_CalcLateLeaveMins(EmpNo, Date, LateIgnore, LeaveIgnore, LateLeaveCalHrs, AheadHrs, AheadMins,
                      DeferHrs, DeferMins, SIn, SOut, InTime, OutTime, ShiftHrs, LateHrs, LeaveHrs, ref LateMins1,
                      ref LeaveMins1, ref AbsentDays1, ref LateCount1, ref LeaveCount1, ref OtHrs1, ref sql);
                    LateMins += LateMins1;
                    LateCount += LateCount1;
                    LeaveMins += LeaveMins1;
                    LeaveCount += LeaveCount1;
                    AbsentDays1 -= RoundNum(RegHrs1 / ShiftHrs);
                    if (AbsentDays1 < 0) AbsentDays1 = 0;
                    AbsentDays += AbsentDays1;
                    OtHrs1 = CalcAdjust(OtHrs1, Start, Tune, Integer);
                    OtHrs += OtHrs1;
                    OtHrsM += OtHrs1;
                }
            }
            else//加班班段
            {
                if (InTime != "" && OutTime != "")
                {
                    PKQ_CalcOutHrs(EmpNo, BeginTime, EndTime, ref OutHrs1, ref sql);
                    OutHrs += OutHrs1;
                    if (!Drift)
                    {
                        PKQ_CalcLateLeaveMins(EmpNo, Date, LateIgnore, LeaveIgnore, LateLeaveCalHrs, AheadHrs, AheadMins,
                          DeferHrs, DeferMins, SIn, SOut, InTime, OutTime, ShiftHrs, LateHrs, LeaveHrs, ref LateMins1,
                          ref LeaveMins1, ref AbsentDays1, ref LateCount1, ref LeaveCount1, ref OtHrs1, ref sql);
                        OtHrs1 = CalcAdjust(OtHrs1, Start, Tune, Integer);
                        ShiftOtHrs = Rate * (SHrs - OutHrs1 - RegHrs1 - RoundNum(LateMins1 / 60.00) - RoundNum(LeaveMins1 / 60.00)) + OtHrs1;
                    }
                    else
                    {
                        ShiftOtHrs = TimeStrToMinute(OutTime) - TimeStrToMinute(InTime);
                        ShiftOtHrs = RoundNum((ShiftOtHrs * Rate) / 60.00);
                        ShiftOtHrs = CalcAdjust(ShiftOtHrs, Start, Tune, Integer);
                    }
                }
                if (ShiftOtHrs < 0) ShiftOtHrs = 0;
                if (OTType == 1) OtHrsM += ShiftOtHrs;
                if (OTType == 2) SunHrsM += ShiftOtHrs;
                if (OTType == 3) HdHrsM += ShiftOtHrs;
                if (ReadLate) LateMins += LateMins1;
                if (ReadLeave) LeaveMins += LeaveMins1;
                OtHrs += ShiftOtHrs;
            }
        }

        private void GetRuleCalcID(string SortID, ref int TypeID, ref int OTType, ref double Rate, ref int Start,
          ref int Tune, ref int Integer, ref string sql)
        {
            sql = "SELECT CalcTypeID,OvertimeTypeID,OvertimeRate,Start,Tune,[Integer] FROM KQ_RuleCalc WHERE SortID='" + SortID + "'";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            if (dr.Read())
            {
                int.TryParse(dr[0].ToString(), out TypeID);
                int.TryParse(dr[1].ToString(), out OTType);
                double.TryParse(dr[2].ToString(), out Rate);
                int.TryParse(dr[3].ToString(), out Start);
                int.TryParse(dr[4].ToString(), out Tune);
                int.TryParse(dr[5].ToString(), out Integer);
            }
            dr.Close();
            sql = "";
        }

        private void PKQ_CalcNormal(string EmpNo, DateTime Date, string DayOffIDList, string ShiftID, ref string[] In,
          ref string[] Out, ref double AbsentDays, ref int LateMins, ref int LateCount, ref int LeaveMins,
          ref int LeaveCount, ref double OtHrs, ref double OtHrsM, ref double SunHrsM, ref double HdHrsM,
          ref double OutHrs, ref double RegHrs, ref double[] Hrs, ref double WorkHrs, ref double WorkDays,
          ref int NSCount, ref int MidCount, ref string Remark, ref double RestDays, ref double RestDaysDB, bool IsNormal,
          bool ReadLate, bool ReadLeave, int LateIgnore, int LeaveIgnore, int LateLeaveCalHrs, bool AheadHrs,
          int AheadMins, bool DeferHrs, int DeferMins, string Small, string Big, int LateHrs, int LeaveHrs,bool IsLeaveOvertime, ref string sql)
        {
            sql = "SELECT * FROM KQ_Shift WHERE ShiftID='" + ShiftID + "'";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            double ShiftHrs = 0;
            int[] SAhead = new int[5];
            int[] SDefer = new int[5];
            string[] SIn = new string[5];
            string[] SOut = new string[5];
            bool[] NeedIn = new bool[5];
            bool[] NeedOut = new bool[5];
            string[] SortID = new string[5];
            bool[] Drift = new bool[5];
            double TempRestDay = 0;
            if (dr.Read())
            {
                double.TryParse(dr["WorkHours"].ToString(), out ShiftHrs);
                for (int i = 1; i <= 5; i++)
                {
                    int.TryParse(dr["ShiftAhead" + i.ToString()].ToString(), out SAhead[i - 1]);
                    int.TryParse(dr["ShiftDefer" + i.ToString()].ToString(), out SDefer[i - 1]);
                    SIn[i - 1] = dr["SigninTime" + i.ToString()].ToString();
                    SOut[i - 1] = dr["SignoutTime" + i.ToString()].ToString();
                    bool.TryParse(dr["Signin" + i.ToString()].ToString(), out NeedIn[i - 1]);
                    bool.TryParse(dr["Signout" + i.ToString()].ToString(), out NeedOut[i - 1]);
                    SortID[i - 1] = dr["SortID" + i.ToString()].ToString();
                    bool.TryParse(dr["Drift" + i.ToString()].ToString(), out Drift[i - 1]);
                }
            }
            dr.Close();
            int[] InMi = new int[5];
            int[] OutMi = new int[5];
            for (int i = 0; i < 5; i++)
            {
                if (SIn[i] != "" && SOut[i] != "")
                {
                    InMi[i] = TimeStrToMinute(SIn[i]);
                    OutMi[i] = TimeStrToMinute(SOut[i]);
                }
            }
            int TypeID = 0;
            int OTType = 0;
            double Rate = 0;
            int Start = 0;
            int Tune = 0;
            int Integer = 0;
            DateTime DriftTime;
            double RegHrsT = 0;
            int NormalStart = 0;
            int NormalTune = 0;
            int NormalInteger = 0;
            double SHrs = 0;
            for (int i = 0; i < 5; i++)
            {
                if (SIn[i] != "" && SOut[i] != "")
                {
                    GetRuleCalcID(SortID[i], ref TypeID, ref OTType, ref Rate, ref Start, ref Tune, ref Integer, ref sql);
                    if (TypeID == 0)
                    {
                        NormalStart = Start;
                        NormalTune = Tune;
                        NormalInteger = Integer;
                    }
                    DriftTime = Date.AddMinutes(24 * 60 + InMi[0] - SAhead[0]);
                    if (i < 4)
                    {
                        if (SIn[i + 1] != "" && SOut[i + 1] != "") DriftTime = Date.AddMinutes(InMi[i + 1]);
                    }
                    PKQ_CalcNormalTime(EmpNo, Date, DayOffIDList, ShiftHrs, SAhead[i], SDefer[i], SIn[i], SOut[i], NeedIn[i],
                      NeedOut[i], SortID[i], Drift[i], TypeID, OTType, Rate, i + 1, ref In[i], ref Out[i], ref RegHrsT,
                      ref AbsentDays, ref LateMins, ref LateCount, ref LeaveMins, ref LeaveCount, ref OtHrs, ref OtHrsM,
                      ref SunHrsM, ref HdHrsM, ref OutHrs, ref RegHrs, ref Hrs, DriftTime, LateIgnore, LeaveIgnore,
                      LateLeaveCalHrs, AheadHrs, AheadMins, DeferHrs, DeferMins, ReadLate, ReadLeave, LateHrs, LeaveHrs,
                      Start, Tune, Integer, IsLeaveOvertime, ref sql, ref SHrs);
                }
            }
            if (AbsentDays < 0) AbsentDays = 0;
            if (SHrs < 0) SHrs = 0;
            if (AbsentDays > 0)
            {
                if (RestDaysDB > 0)//减无规则的休息天数
                {
                    if (RestDaysDB > AbsentDays)
                    {
                        TempRestDay = AbsentDays;
                        RestDays += AbsentDays;
                        RestDaysDB -= AbsentDays;
                        AbsentDays = 0;
                        SHrs = 0;
                    }
                    else
                    {
                        TempRestDay = RestDaysDB;
                        RestDays += RestDaysDB;
                        AbsentDays -= RestDaysDB;
                        RestDaysDB = 0;
                    }
                }
            }
            if (AbsentDays < 0) AbsentDays = 0;
            double ShiftOtHrs = 0;
            DateTime RestTime = Date.AddSeconds(86399);
            sql = "SELECT a.BeginTime,a.EndTime,a.AheadHrs,a.AheadMins,a.DeferHrs,a.DeferMins,b.OvertimeTypeID," +
              "b.OvertimeRate,b.Start,b.Tune,b.[Integer],a.SortID FROM KQ_EmpOtSure a,KQ_RuleCalc b " +
              "WHERE b.SortID=a.SortID AND a.EmpNo='" + EmpNo + "' AND BeginTime>=CDate('" +
              Date.ToString(SystemInfo.SQLDateTimeFMT) + "') AND EndTime<=CDate('" +
              RestTime.ToString(SystemInfo.SQLDateTimeFMT) + "')";
            dr = SystemInfo.db.GetDataReader(sql);
            DateTime OtBeginTime = new DateTime();
            DateTime OtEndTime = new DateTime();
            bool OtNeedIn = false;
            int OtAhead = 0;
            bool OtNeedOut = false;
            int OtDelay = 0;
            int OtType = 0;
            double OtHrs1 = 0;
            double OutHrs1 = 0;
            double RegHrs1 = 0;
            string SortIDOld = "";
            double[] HrsX = new double[10];
            while (dr.Read())
            {
                DateTime.TryParse(dr[0].ToString(), out OtBeginTime);
                DateTime.TryParse(dr[1].ToString(), out OtEndTime);
                bool.TryParse(dr[2].ToString(), out OtNeedIn);
                int.TryParse(dr[3].ToString(), out OtAhead);
                bool.TryParse(dr[4].ToString(), out OtNeedOut);
                int.TryParse(dr[5].ToString(), out OtDelay);
                int.TryParse(dr[6].ToString(), out OtType);
                double.TryParse(dr[7].ToString(), out Rate);
                int.TryParse(dr[8].ToString(), out Start);
                int.TryParse(dr[9].ToString(), out Tune);
                int.TryParse(dr[10].ToString(), out Integer);
                SortIDOld = dr[11].ToString();
                PKQ_CalcOtHrs(EmpNo, OtBeginTime, OtEndTime, OtNeedIn, OtAhead, OtNeedOut, OtDelay, ReadLate, ReadLeave,
                  ref OtHrs1, ref OutHrs1, ref sql);
                OtHrs1 *= Rate;
                OtHrs1 = CalcAdjust(OtHrs1, Start, Tune, Integer);
                PKQ_CalcRegHrs(EmpNo, DayOffIDList, OtBeginTime, OtEndTime,IsLeaveOvertime, SortIDOld, ref RegHrs1, ref HrsX, ref sql);
                ShiftOtHrs = OtHrs1 - OutHrs1 - RegHrs1;
                for (int i = 0; i < 9; i++) Hrs[i] += HrsX[i];
                if (ShiftOtHrs < 0) ShiftOtHrs = 0;
                if (OtType == 1) OtHrsM += ShiftOtHrs;
                if (OtType == 2) SunHrsM += ShiftOtHrs;
                if (OtType == 3) HdHrsM += ShiftOtHrs;
            }
            OtHrs += ShiftOtHrs;
            OtHrs = CalcAdjust(OtHrs, Start, Tune, Integer);
            if (ShiftHrs != 0)
            {
                WorkDays = 1 - AbsentDays - RoundNum(RegHrsT / ShiftHrs) - TempRestDay;
                if (WorkDays < 0) WorkDays = 0;
            }
            WorkHrs = WorkDays * ShiftHrs;
            double TempWorkHrs = CalcAdjust(WorkHrs, NormalStart, NormalTune, NormalInteger);
            if (TempWorkHrs != WorkHrs && ShiftHrs != 0)
            {
                double TempAbsentDays = Math.Abs(RoundNum((WorkHrs - TempWorkHrs) / ShiftHrs));
                AbsentDays -= TempAbsentDays;
                WorkHrs = TempWorkHrs;
                if (WorkHrs > ShiftHrs) WorkHrs = ShiftHrs;
                WorkDays = RoundNum(WorkHrs / ShiftHrs);
            }
            int SmallMi = 0;
            int BigMi = 0;
            int InMiX = 0;
            int OutMiX = 0;
            if (Small != "" && Small != ":")
            {
                SmallMi = TimeStrToMinute(Small);
                if (Big != "" && Big != ":") BigMi = TimeStrToMinute(Big);
                for (int i = 0; i < 5; i++)
                {
                    if (In[i] != "" && Out[i] != "")
                    {
                        InMiX = TimeStrToMinute(In[i]);
                        OutMiX = TimeStrToMinute(Out[i]);
                        if (BigMi != 0)
                        {
                            if (OutMiX > BigMi) NSCount += 1;
                        }
                        else if (OutMiX > SmallMi)
                            MidCount += 1;
                    }
                }
            }
            if (RegHrs < 0 || RegHrs > 24) RegHrs = 0;
            if (RegHrs != 0)
            {
                RegHrs = RoundNum(RegHrs);
                sql = "SELECT[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='RegHrs'";
                Remark += "," + GetRemark(sql) + RoundTwo(RegHrs).ToString();
                sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'";
                Remark += GetRemark(sql);
            }
            if (OtHrs < 0 || OtHrs > 24) OtHrs = 0;
            if (OtHrs != 0)
            {
                OtHrs = RoundNum(OtHrs);
                sql = "SELECT[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'";
                Remark += "," + GetRemark(sql) + RoundTwo(OtHrs).ToString();
                sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'";
                Remark += GetRemark(sql);
            }
            if (AbsentDays < 0 || AbsentDays > 1) AbsentDays = 0;
            if (AbsentDays != 0)
            {
                AbsentDays = RoundNum(AbsentDays);
                sql = "SELECT[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='AbsentDays'";
                Remark += "," + GetRemark(sql) + RoundTwo(AbsentDays).ToString();
                sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Days'";
                Remark += GetRemark(sql);
            }
            if (OutHrs < 0 || OutHrs > 24) OutHrs = 0;
            if (OutHrs != 0)
            {
                OutHrs = RoundNum(OutHrs);
                sql = "SELECT[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='OutHrs'";
                Remark += "," + GetRemark(sql) + RoundTwo(OutHrs).ToString();
                sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'";
                Remark += GetRemark(sql);
            }
            sql = "";
        }

        private int GetReadWorkMinute(string sql, ref string KQTime)
        {
            int ret = 0;
            KQTime = "";
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            if (dr.Read())
            {
                string tmp = dr[0].ToString().Trim();
                ret = Convert.ToInt32(tmp.Substring(0, 2)) * 60 * 60;
                ret += Convert.ToInt32(tmp.Substring(3, 2)) * 60;
                // ret += Convert.ToInt32(tmp.Substring(6, 2));
                KQTime = tmp.Substring(0, 5);
            }
            dr.Close();
            return ret;
        }
        private int GetMarkIndex(string sql)
        {
            int ret = 0;
           
            DataTableReader dr = SystemInfo.db.GetDataReader(sql);
            if (dr.Read())
            {
                int.TryParse(dr[0].ToString(),out ret);
            }
            dr.Close();
            return ret;
        }

        public bool PKQ_Calc(string EmpNo, DateTime StartDate, DateTime EndDate, string KQYM, int week)
        {
            bool ret = false;
           // SystemInfo.db.ExecSQL("DROP TABLE Temp_KQ_KQData", true);
            SystemInfo.db.ExecSQL("DROP TABLE Temp_KQ_KQDataFilter", true);
            string sql = "";
            List<string> sqlDay = new List<string>();
            List<string> sqlMonth = new List<string>();
            DataTableReader dr = null;
            try
            {
                //SystemInfo.db.ExecSQL(sql);
                //sql = "ALTER TABLE Temp_KQ_KQData ADD PRIMARY KEY([GUID])";
                //SystemInfo.db.ExecSQL(sql);
                //sql = "ALTER TABLE Temp_KQ_KQData ADD CONSTRAINT AK_Temp_KQ_KQData UNIQUE(EmpNo,KQDateTime)";
                //SystemInfo.db.ExecSQL(sql);
                sql = "SELECT * INTO Temp_KQ_KQDataFilter FROM KQ_KQDataFilter WHERE 1=2";
                SystemInfo.db.ExecSQL(sql);
                sql = "ALTER TABLE Temp_KQ_KQDataFilter ADD PRIMARY KEY([GUID])";
                SystemInfo.db.ExecSQL(sql);
                sql = "ALTER TABLE Temp_KQ_KQDataFilter ADD CONSTRAINT AK_Temp_KQ_KQDataFilter UNIQUE(EmpNo,KQDateTime)";
                SystemInfo.db.ExecSQL(sql);
                sql = "SELECT IsDimission,DimissionDate,EmpHireDate,DepartID,IsAttend FROM RS_Emp WHERE EmpNo='" + EmpNo + "'";
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    DateTime dimDate = new DateTime();
                    DateTime HireDate = new DateTime();
                    bool IsDim = false;
                    bool IsAtt = false;
                    string DepartID = dr["DepartID"].ToString();
                    DateTime.TryParse(dr["DimissionDate"].ToString(), out dimDate);
                    DateTime.TryParse(dr["EmpHireDate"].ToString(), out HireDate);
                    bool.TryParse(dr["IsDimission"].ToString(), out IsDim);
                    bool.TryParse(dr["IsAttend"].ToString(), out IsAtt);
                    dr.Close();
                    sql = "DELETE FROM KQ_KQReportDay WHERE EmpNo='" + EmpNo + "' AND KQDate>=CDate('" +
                      StartDate.ToString(SystemInfo.SQLDateFMT) + "') AND KQDate<=CDate('" +
                      EndDate.ToString(SystemInfo.SQLDateFMT) + "')";
                    SystemInfo.db.ExecSQL(sql);
                    if (week == 1)
                    {
                        sql = "DELETE FROM KQ_KQReportWeek WHERE EmpNo='" + EmpNo + "' AND KQYM='" + KQYM + "'";
                    }
                    else
                    {
                        sql = "DELETE FROM KQ_KQReportMonth WHERE EmpNo='" + EmpNo + "' AND KQYM='" + KQYM + "'";
                    }

                    SystemInfo.db.ExecSQL(sql);
                    sql = "DELETE FROM KQ_KQReportMonthDetail WHERE EmpNo='" + EmpNo + "' AND KQYM='" + KQYM + "'";
                    SystemInfo.db.ExecSQL(sql);

                    DateTime LoopDate = StartDate;
                    string LoopDateStr = "";
                    double MonthDaysM = 0;
                    double SunDaysM = 0;
                    double HdDaysM = 0;
                    double WorkDaysM = 0;
                    double AbsentDaysM = 0;
                    double WorkHrsM = 0;
                    double OtHrsM = 0;
                    double SunHrsM = 0;
                    double HdHrsM = 0;
                    int LateMinsM = 0;
                    int LateCountM = 0;
                    int LeaveMinsM = 0;
                    int LeaveCountM = 0;
                    int NSCountM = 0;
                    int MidCountM = 0;
                    double[] Hrs = new double[10];
                    string DayOffIDList = "";
                    string DayOffID = "";
                    string RuleID = "";
                    bool RuleExists = false;
                    double RestDays = 0;
                    double RestDaysDB = 0;
                    bool NoRule = false;
                    bool ReadWorkHrs = false;
                    bool WeekIsWork = false;
                    int DupLimit = 0;
                    bool ReadLate = false;
                    bool ReadLeave = false;
                    int LateIgnore = 0;
                    int LeaveIgnore = 0;
                    int LateLeaveCalHrs = 0;
                    bool AheadHrs = false;
                    int AheadMins = 0;
                    bool DeferHrs = false;
                    int DeferMins = 0;
                    int LateHrs = 0;
                    int LeaveHrs = 0;
                    string Small = "";
                    string Big = "";
                    string DefShiftID = "";
                    double MustDays = 0;
                    double MustDaysM = 0;
                    string[] DayDetail = new string[31];
                    string[] TimeDetail = new string[31];
                    int DayCount = 0;
                    string KQDate = "";
                    bool IsHandAndTail = false;
                    bool IsLeaveOvertime = true;
                    int MarkIndex = 0;
                    //离职
                    if (IsDim && LoopDate >= dimDate) return true;
                    sql = "SELECT SortID FROM KQ_RuleCalc WHERE CalcTypeID=2 ORDER BY SortID";
                    dr = SystemInfo.db.GetDataReader(sql);
                    while (dr.Read())
                    {
                        DayOffID = dr[0].ToString().Trim();
                        while (DayOffID.Length < 10) DayOffID = "0" + DayOffID;
                        DayOffIDList += DayOffID;
                    }
                    dr.Close();
                    sql = "SELECT EmpRuleID FROM VKQ_RuleEmp WHERE EmpNo='" + EmpNo + "'";
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (dr.Read()) RuleID = dr[0].ToString().Trim();
                    dr.Close();
                    if (RuleID == "")
                    {
                        sql = "SELECT RuleID FROM VKQ_RuleDepart WHERE DepartID='" + DepartID + "'";
                        dr = SystemInfo.db.GetDataReader(sql);
                        if (dr.Read()) RuleID = dr[0].ToString().Trim();
                        dr.Close();
                    }
                    if (RuleID == "") RuleID = "R0001";
                    sql = "SELECT * FROM KQ_Rule WHERE RuleID='" + RuleID + "'";
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (dr.Read())
                    {
                        RuleExists = true;
                        bool.TryParse(dr["RuleNoRule"].ToString(), out NoRule);
                        double.TryParse(dr["RuleRestDays"].ToString(), out RestDaysDB);
                        bool.TryParse(dr["RuleReadWorkHrs"].ToString(), out ReadWorkHrs);
                        int.TryParse(dr["RuleDupLimit"].ToString(), out DupLimit);
                        bool.TryParse(dr["RuleReadLate"].ToString(), out ReadLate);
                        bool.TryParse(dr["RuleReadLeave"].ToString(), out ReadLeave);
                        int.TryParse(dr["RuleLateIgnore"].ToString(), out LateIgnore);
                        int.TryParse(dr["RuleLeaveIgnore"].ToString(), out LeaveIgnore);
                        int.TryParse(dr["RuleLateLeaveCalHrs"].ToString(), out LateLeaveCalHrs);
                        bool.TryParse(dr["RuleAheadHrs"].ToString(), out AheadHrs);
                        int.TryParse(dr["RuleAheadMins"].ToString(), out AheadMins);
                        bool.TryParse(dr["RuleDeferHrs"].ToString(), out DeferHrs);
                        int.TryParse(dr["RuleDeferMins"].ToString(), out DeferMins);
                        int.TryParse(dr["RuleLateHrs"].ToString(), out LateHrs);
                        int.TryParse(dr["RuleLeaveHrs"].ToString(), out LeaveHrs);
                        Small = dr["RuleNSAllowTimeS"].ToString();
                        Big = dr["RuleNSAllowTimeL"].ToString();
                        bool.TryParse(dr["RuleHeadAndTail"].ToString(), out IsHandAndTail);
                        bool.TryParse(dr["RuleLeaveOvertime"].ToString(), out IsLeaveOvertime);
                        if (!NoRule) RestDaysDB = 0;
                    }
                    dr.Close();
                    int DefCount = 0;
                    sql = "SELECT COUNT(1) AS RecCount FROM KQ_Shift a,KQ_ShiftDepart b " +
                      "WHERE b.ShiftID=a.ShiftID AND b.DepartID='" + DepartID + "'";
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (dr.Read()) int.TryParse(dr[0].ToString(), out DefCount);
                    dr.Close();
                    if (DefCount == 1)
                    {
                        sql = "SELECT a.ShiftID FROM KQ_Shift a,KQ_ShiftDepart b " +
                          "WHERE b.ShiftID=a.ShiftID AND b.DepartID='" + DepartID + "'";
                        dr = SystemInfo.db.GetDataReader(sql);
                        if (dr.Read()) DefShiftID = dr[0].ToString().Trim();
                        dr.Close();
                    }
                    if (DefShiftID == "") DefShiftID = "001";
                    if (IsAtt) PKQ_CalcDataFilter(EmpNo, StartDate, EndDate, DupLimit, ref sql);
                    string ShiftID = "";
                    string ShiftIDFind = "";
                    string[] TimeIn = new string[5];
                    string[] TimeOut = new string[5];
                    double WorkDays = 0;
                    double AbsentDays = 0;
                    double OutHrs = 0;
                    double RegHrs = 0;
                    double WorkHrs = 0;
                    double OtHrs = 0;
                    int LateMins = 0;
                    int LeaveMins = 0;
                    string Remark = "";
                    bool IsHD = false;
                    string[] F = new string[31];
                    string[] Y = new string[31];
                    double[] T = new double[10];
                    double[] HrsX = new double[10];
                    bool HasShift = false;
                    bool ShiftExists = false;
                    string s1 = "";
                    string s2 = "";
                 

                    for (int i = 0; i < F.Length; i++)
                    {
                        F[i] = "0";
                        Y[i] = " ";
                    }
                    while (LoopDate <= EndDate)
                    {
                        ShiftID = "";
                        ShiftIDFind = "";
                        for (int i = 0; i < 5; i++)
                        {
                            TimeIn[i] = "";
                            TimeOut[i] = "";
                        }

                        WorkDays = 0;
                        AbsentDays = 0;
                        OutHrs = 0;
                        RegHrs = 0;
                        WorkHrs = 0;
                        OtHrs = 0;
                        LateMins = 0;
                        LeaveMins = 0;
                        Remark = "";
                        MustDays = 0;
                        IsHD = false;

                        for (int i = 0; i < 10; i++)
                        {
                            T[i] = 0;
                            HrsX[i] = 0;
                        }
                        HasShift = false;
                        LoopDateStr = LoopDate.ToString(SystemInfo.SQLDateFMT);
                        if (IsDim && LoopDate >= dimDate)//离职
                        {
                            MonthDaysM = (double)Pub.DateDiff(DateInterval.Day, StartDate, LoopDate);
                            goto DimissionDate;
                        }
                        else if (LoopDate < HireDate)//未入职
                        {
                            sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoOffice'";
                            Remark = GetRemark(sql);
                            goto NoOffice;
                        }
                        else
                        {
                            sql = "SELECT ShiftNo FROM KQ_EmpShift WHERE EmpNo='" + EmpNo + "' AND EmpShiftDate=CDate('" +
                              LoopDateStr + "')";
                            dr = SystemInfo.db.GetDataReader(sql);
                            if (dr.Read())
                            {
                                HasShift = true;
                                ShiftID = dr[0].ToString().Trim();
                            }
                            dr.Close();
                            if (ShiftID == "")
                            {
                                dr.Close();
                                sql = "SELECT ShiftNo FROM KQ_DepShift WHERE DepartID='" + DepartID + "' AND DepShiftDate=CDate('" +
                                  LoopDateStr + "')";
                                dr = SystemInfo.db.GetDataReader(sql);
                                if (dr.Read())
                                {
                                    HasShift = true;
                                    ShiftID = dr[0].ToString().Trim();
                                }
                            }
                            dr.Close();
                        }
                        sql = "SELECT * FROM KQ_Holiday WHERE HolidayBeginTime<=CDate('" + LoopDateStr +
                          "') AND HolidayEndTime>=CDate('" + LoopDateStr + "')";
                        dr = SystemInfo.db.GetDataReader(sql);
                        if (dr.Read()) IsHD = true;
                        dr.Close();
                        if (!IsAtt)//免卡
                        {
                            sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoCard'";
                            Remark = GetRemark(sql);
                            WorkDays = 1;
                        }
                        else if (!RuleExists)
                        {
                            sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoRule'";
                            Remark = GetRemark(sql);
                        }
                        else if (IsHD)
                        {
                            PKQ_CalcRest(EmpNo, LoopDate, RuleID, DayOffIDList, ReadLate, ReadLeave,IsLeaveOvertime, ref OtHrs, ref OutHrs,
                              ref RegHrs, ref HrsX, ref sql);
                            sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='PubRest'";
                            Remark = GetRemark(sql);
                            HdDaysM += 1;
                            for (int i = 0; i < 9; i++) Hrs[i] += HrsX[i];
                            if (OtHrs > 0)
                            {
                                OtHrs = OtHrs - RegHrs - OutHrs;//加班小时减请假小时和外出小时
                                if (OtHrs > 0)
                                {
                                    OtHrs = RoundNum(OtHrs);
                                    HdHrsM += OtHrs;
                                    sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'";
                                    Remark = Remark + "," + GetRemark(sql) + RoundTwo(OtHrs).ToString();
                                    sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'";
                                    Remark = Remark + GetRemark(sql);
                                }
                            }
                        }
                        else if (!HasShift)//未排班
                        {
                            WeekIsWork = false;
                            sql = "SELECT * FROM KQ_Rule WHERE RuleID='" + RuleID + "'";
                            dr = SystemInfo.db.GetDataReader(sql);
                            if (dr.Read())
                            {
                                switch (LoopDate.DayOfWeek)
                                {
                                    case DayOfWeek.Sunday:
                                        bool.TryParse(dr["RuleSunday"].ToString(), out WeekIsWork);
                                        break;
                                    case DayOfWeek.Monday:
                                        bool.TryParse(dr["RuleMonday"].ToString(), out WeekIsWork);
                                        break;
                                    case DayOfWeek.Tuesday:
                                        bool.TryParse(dr["RuleTuesday"].ToString(), out WeekIsWork);
                                        break;
                                    case DayOfWeek.Wednesday:
                                        bool.TryParse(dr["RuleWednesday"].ToString(), out WeekIsWork);
                                        break;
                                    case DayOfWeek.Thursday:
                                        bool.TryParse(dr["RuleThursday"].ToString(), out WeekIsWork);
                                        break;
                                    case DayOfWeek.Friday:
                                        bool.TryParse(dr["RuleFriday"].ToString(), out WeekIsWork);
                                        break;
                                    case DayOfWeek.Saturday:
                                        bool.TryParse(dr["RuleSaturday"].ToString(), out WeekIsWork);
                                        break;
                                }
                            }
                            dr.Close();
                            if (!NoRule)//不启用无规则休息
                            {
                                if (!WeekIsWork)
                                {
                                    AbsentDays = 0;
                                    PKQ_CalcRest(EmpNo, LoopDate, RuleID, DayOffIDList, ReadLate, ReadLeave,IsLeaveOvertime, ref OtHrs, ref OutHrs,
                                      ref RegHrs, ref HrsX, ref sql);
                                    sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='WeekLast'";
                                    Remark = GetRemark(sql);
                                    SunDaysM += 1;
                                    for (int i = 0; i < 9; i++) Hrs[i] += HrsX[i];
                                    if (OtHrs > 0)
                                    {
                                        OtHrs = OtHrs - RegHrs - OutHrs;//加班小时减请假小时和外出小时
                                        if (OtHrs > 0)
                                        {
                                            OtHrs = RoundNum(OtHrs);
                                            SunHrsM += OtHrs;
                                            sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'";
                                            Remark = Remark + "," + GetRemark(sql) + RoundTwo(OtHrs).ToString();
                                            sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'";
                                            Remark = Remark + GetRemark(sql);
                                        }
                                    }
                                }
                                else if (ReadWorkHrs)//计算工时
                                {
                                    if(IsHandAndTail) //只取首尾打卡记录
                                    {
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                  "') AND MarkIndex=1";
                                        T[0] = GetReadWorkMinute(sql, ref s1);

                                        if(T[0]!=0)
                                        {
                                            sql = "SELECT top 1 MarkIndex FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                             "')  order by MarkIndex desc";

                                            MarkIndex = GetMarkIndex(sql);
                                            if(MarkIndex>1)
                                            {
                                                sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                "') AND MarkIndex="+ MarkIndex + "";
                                                T[1] = GetReadWorkMinute(sql, ref s2);
                                            }
                                            if (T[0] != 0 && T[1] != 0)
                                            {
                                                TimeIn[0] = s1;
                                                TimeOut[0] = s2;
                                                WorkHrs += RoundNum((T[1] - T[0]) / 60.00 / 60.00);
                                            }
                                        }   
                                    }
                                    else
                                    {
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                    "') AND MarkIndex=1";
                                        T[0] = GetReadWorkMinute(sql, ref s1);
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                          "') AND MarkIndex=2";
                                        T[1] = GetReadWorkMinute(sql, ref s2);
                                        if (T[0] != 0 && T[1] != 0)
                                        {
                                            TimeIn[0] = s1;
                                            TimeOut[0] = s2;
                                            WorkHrs += RoundNum((T[1] - T[0]) / 60.00 / 60.00);
                                        }
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                          "') AND MarkIndex=3";
                                        T[2] = GetReadWorkMinute(sql, ref s1);
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                          "') AND MarkIndex=4";
                                        T[3] = GetReadWorkMinute(sql, ref s2);
                                        if (T[2] != 0 && T[3] != 0)
                                        {
                                            TimeIn[1] = s1;
                                            TimeOut[1] = s2;
                                            WorkHrs += RoundNum((T[3] - T[2]) / 60.00 / 60.00);
                                        }
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                          "') AND MarkIndex=5";
                                        T[4] = GetReadWorkMinute(sql, ref s1);
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                          "') AND MarkIndex=6";
                                        T[5] = GetReadWorkMinute(sql, ref s2);
                                        if (T[4] != 0 && T[5] != 0)
                                        {
                                            TimeIn[2] = s1;
                                            TimeOut[2] = s2;
                                            WorkHrs += RoundNum((T[5] - T[4]) / 60.00 / 60.00);
                                        }
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                          "') AND MarkIndex=7";
                                        T[6] = GetReadWorkMinute(sql, ref s1);
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                          "') AND MarkIndex=8";
                                        T[7] = GetReadWorkMinute(sql, ref s2);
                                      
                                        if (T[6] != 0 && T[7] != 0)
                                        {
                                            TimeIn[3] = s1;
                                            TimeOut[3] = s2;
                                            WorkHrs += RoundNum((T[7] - T[6]) / 60.00 / 60.00);
                                        }
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                        "') AND MarkIndex=9";
                                        T[8] = GetReadWorkMinute(sql, ref s1);
                                        sql = "SELECT KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=CDate('" + LoopDateStr +
                                          "') AND MarkIndex=10";
                                        T[9] = GetReadWorkMinute(sql, ref s2);
                                        if (T[8] != 0 && T[9] != 0)
                                        {
                                            TimeIn[4] = s1;
                                            TimeOut[4] = s2;
                                            WorkHrs += RoundNum((T[9] - T[8]) / 60.00 / 60.00);
                                        }
                                    }
                                    if (WorkHrs < 0 || WorkHrs > 24) WorkHrs = 0;
                                    if (WorkHrs == 0)
                                    {
                                        sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoPuchCard'";
                                        Remark = GetRemark(sql);
                                    }
                                    sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='CalcHour'";
                                    dr = SystemInfo.db.GetDataReader(sql);
                                    if (dr.Read()) ShiftID = dr[0].ToString();
                                    dr.Close();
                                }
                            }
                            if (NoRule || (!NoRule && !ReadWorkHrs && WeekIsWork))
                            {
                                bool ExistAuto = false;
                                sql = "DELETE FROM KQ_ShiftFind";
                                SystemInfo.db.ExecSQL(sql);
                                sql = "SELECT DISTINCT a.ShiftID,a.ShiftCount FROM KQ_Shift a,KQ_ShiftDepart b " +
                                  "WHERE b.ShiftID=a.ShiftID AND b.DepartID='" + DepartID +
                                  "' AND a.IsAuto  ORDER BY ShiftCount DESC";
                                dr = SystemInfo.db.GetDataReader(sql);
                                int ShiftCount = 0;
                                while (dr.Read())
                                {
                                    ExistAuto = true;
                                    ShiftIDFind = dr[0].ToString();
                                    ShiftCount = 0;
                                    int.TryParse(dr[1].ToString(), out ShiftCount);
                                    PKQ_CalcFindShift(EmpNo, LoopDate, ShiftIDFind, ref ShiftID, LateHrs, LeaveHrs, ref sql);
                                }
                                dr.Close();
                                if (ExistAuto)
                                {
                                    sql = "SELECT * FROM KQ_ShiftFind ORDER BY LateMins,LeaveMins";
                                    dr = SystemInfo.db.GetDataReader(sql);
                                    if (dr.Read()) ShiftID = dr["ShiftID"].ToString();
                                    dr.Close();
                                    if (ShiftID == "")
                                    {
                                        sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoShift'";
                                        Remark = GetRemark(sql);
                                    }
                                    else
                                    {
                                        PKQ_CalcNormal(EmpNo, LoopDate, DayOffIDList, ShiftID, ref TimeIn, ref TimeOut,
                                          ref AbsentDays, ref LateMins, ref LateCountM, ref LeaveMins, ref LeaveCountM, ref OtHrs,
                                          ref OtHrsM, ref SunHrsM, ref HdHrsM, ref OutHrs, ref RegHrs, ref Hrs, ref WorkHrs,
                                          ref WorkDays, ref NSCountM, ref MidCountM, ref Remark, ref RestDays, ref RestDaysDB, false,
                                          ReadLate, ReadLeave, LateIgnore, LeaveIgnore, LateLeaveCalHrs, AheadHrs, AheadMins, DeferHrs,
                                          DeferMins, Small, Big, LateHrs, LeaveHrs, IsLeaveOvertime, ref sql);
                                        MustDays = 1;
                                    }

                                }
                                else if (DefShiftID != "")//未排班使用默认排班次
                                {
                                    ShiftID = DefShiftID;
                                    PKQ_CalcNormal(EmpNo, LoopDate, DayOffIDList, ShiftID, ref TimeIn, ref TimeOut,
                                      ref AbsentDays, ref LateMins, ref LateCountM, ref LeaveMins, ref LeaveCountM, ref OtHrs,
                                      ref OtHrsM, ref SunHrsM, ref HdHrsM, ref OutHrs, ref RegHrs, ref Hrs, ref WorkHrs,
                                      ref WorkDays, ref NSCountM, ref MidCountM, ref Remark, ref RestDays, ref RestDaysDB, false,
                                      ReadLate, ReadLeave, LateIgnore, LeaveIgnore, LateLeaveCalHrs, AheadHrs, AheadMins, DeferHrs,
                                      DeferMins, Small, Big, LateHrs, LeaveHrs, IsLeaveOvertime, ref sql);
                                    MustDays = 1;
                                }
                                else
                                {
                                    sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoShift'";
                                    Remark = GetRemark(sql);
                                }
                            }
                        }
                        else if (ShiftID == "")//班次为空，休息
                        {
                            PKQ_CalcRest(EmpNo, LoopDate, RuleID, DayOffIDList, ReadLate, ReadLeave,IsLeaveOvertime, ref OtHrs, ref OutHrs,
                              ref RegHrs, ref HrsX, ref sql);
                            sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Rest'";
                            Remark = GetRemark(sql);
                            SunDaysM += 1;
                            for (int i = 0; i < 9; i++) Hrs[i] += HrsX[i];
                            if (OtHrs > 0)
                            {
                                OtHrs = OtHrs - RegHrs - OutHrs;//加班小时减请假小时和外出小时
                                if (OtHrs > 0)
                                {
                                    OtHrs = RoundNum(OtHrs);
                                    SunHrsM += OtHrs;
                                    sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'";
                                    Remark = Remark + "," + GetRemark(sql) + RoundTwo(OtHrs).ToString();
                                    sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'";
                                    Remark = Remark + GetRemark(sql);
                                }
                            }
                        }
                        else
                        {
                            sql = "SELECT ShiftID FROM KQ_Shift WHERE ShiftID='" + ShiftID + "'";
                            dr = SystemInfo.db.GetDataReader(sql);
                            ShiftExists = dr.Read();
                            dr.Close();
                            if (ShiftExists)
                            {
                                PKQ_CalcNormal(EmpNo, LoopDate, DayOffIDList, ShiftID, ref TimeIn, ref TimeOut,
                                  ref AbsentDays, ref LateMins, ref LateCountM, ref LeaveMins, ref LeaveCountM, ref OtHrs,
                                  ref OtHrsM, ref SunHrsM, ref HdHrsM, ref OutHrs, ref RegHrs, ref Hrs, ref WorkHrs,
                                  ref WorkDays, ref NSCountM, ref MidCountM, ref Remark, ref RestDays, ref RestDaysDB, true,
                                  ReadLate, ReadLeave, LateIgnore, LeaveIgnore, LateLeaveCalHrs, AheadHrs, AheadMins, DeferHrs,
                                  DeferMins, Small, Big, LateHrs, LeaveHrs, IsLeaveOvertime, ref sql);
                                MustDays = 1;
                            }
                            else //班次不存在
                            {
                                sql = "SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='ShiftNotE'";
                                Remark = GetRemark(sql);
                            }
                        }

                    NoOffice:
                        AbsentDaysM += AbsentDays;
                        WorkHrsM += WorkHrs;
                        WorkDaysM += WorkDays;
                        LateMinsM += LateMins;
                        LeaveMinsM += LeaveMins;
                        MustDaysM += MustDays;
                        if (Remark != "" && Remark.Substring(0, 1) == ",") Remark = Remark.Substring(1);

                        sqlDay.Add("INSERT INTO KQ_KQReportDay(EmpNo,KQDate,ShiftID,TimeIn1,TimeOut1,TimeIn2,TimeOut2,TimeIn3," +
                         "TimeOut3,TimeIn4,TimeOut4,TimeIn5,TimeOut5,WorkDays,AbsentDays,OutHrs,LeaveDays,WorkHrs,OtHrs," +
                         "LateMins,LeaveMins,Remark,MustDays) VALUES('" + EmpNo + "',CDate('" + LoopDateStr + "'),'" + ShiftID + "','" +
                         TimeIn[0] + "','" + TimeOut[0] + "','" + TimeIn[1] + "','" + TimeOut[1] + "','" + TimeIn[2] + "','" +
                         TimeOut[2] + "','" + TimeIn[3] + "','" + TimeOut[3] + "','" + TimeIn[4] + "','" + TimeOut[4] + "'," +
                         RoundTwo(WorkDays).ToString().Replace(",", ".") + "," + RoundTwo(AbsentDays).ToString().Replace(",", ".") + "," + RoundTwo(OutHrs).ToString().Replace(",", ".") + "," +
                         RoundTwo(RegHrs).ToString().Replace(",", ".") + "," + RoundTwo(WorkHrs).ToString().Replace(",", ".") + "," + RoundTwo(OtHrs).ToString().Replace(",", ".") + "," +
                         LateMins.ToString().Replace(",", ".") + "," + LeaveMins.ToString().Replace(",", ".") + ",'" + Remark + "'," + RoundTwo(MustDays).ToString().Replace(",", ".") + ")");

                        #region 考勤月记录表
                        DayDetail[DayCount] = getWeek(LoopDate);

                        //if (MustDays==1 && AbsentDays==1 && WorkDays==0)
                        //{
                        //    TimeDetail[DayCount] = Remark;
                        //}
                        //else if(!NoRule && WeekIsWork && ReadWorkHrs && WorkHrs == 0)
                        //{
                        //    TimeDetail[DayCount] = Remark;
                        //}
                        //else
                        //{


                        //}
                        if (!string.IsNullOrEmpty(TimeIn[0]))
                        {
                            TimeDetail[DayCount] += TimeIn[0];
                        }
                        else
                        {
                            TimeDetail[DayCount] += "      ";
                        }
                        if (!string.IsNullOrEmpty(TimeOut[0]))
                        {
                            if (!string.IsNullOrEmpty(TimeIn[0]))
                            {
                                TimeDetail[DayCount] += "-" + TimeOut[0];
                            }
                            else
                            {
                                TimeDetail[DayCount] += TimeOut[0];
                            }
                        }
                       
                        if (!string.IsNullOrEmpty(TimeIn[1]))
                        {
                            TimeDetail[DayCount] += "\n" + TimeIn[1];
                        }
                        else
                        {
                            TimeDetail[DayCount] += "\n      ";
                        }
                        if (!string.IsNullOrEmpty(TimeOut[1]))
                        {
                            if (!string.IsNullOrEmpty(TimeIn[1]))
                            {
                                TimeDetail[DayCount] += "-" + TimeOut[1];
                            }
                            else
                            {
                                TimeDetail[DayCount] += TimeOut[1];
                            }
                        }
                       
                        if (!string.IsNullOrEmpty(TimeIn[2]))
                        {
                            TimeDetail[DayCount] += "\n" + TimeOut[2];
                        }
                        else
                        {
                            TimeDetail[DayCount] += "\n      ";
                        }
                        if (!string.IsNullOrEmpty(TimeOut[2]))
                        {
                            if (!string.IsNullOrEmpty(TimeIn[2]))
                            {
                                TimeDetail[DayCount] += "-" + TimeOut[2];
                            }
                            else
                            {
                                TimeDetail[DayCount] += TimeOut[2];
                            }
                        }
                      
                        if (!string.IsNullOrEmpty(TimeIn[3]))
                        {
                            TimeDetail[DayCount] += "\n" + TimeIn[3];
                        }
                        else
                        {
                            TimeDetail[DayCount] += "\n      ";
                        }
                        if (!string.IsNullOrEmpty(TimeOut[3]))
                        {
                            if (!string.IsNullOrEmpty(TimeIn[3]))
                            {
                                TimeDetail[DayCount] += "-" + TimeOut[3];
                            }
                            else
                            {
                                TimeDetail[DayCount] += TimeOut[3];
                            }
                        }
                      
                        if (!string.IsNullOrEmpty(TimeIn[4]))
                        {
                            TimeDetail[DayCount] += "\n" + TimeIn[4];
                        }
                        else
                        {
                            TimeDetail[DayCount] += "\n      ";
                        }
                        if (!string.IsNullOrEmpty(TimeOut[4]))
                        {
                            if (!string.IsNullOrEmpty(TimeIn[4]))
                            {
                                TimeDetail[DayCount] += "-" + TimeOut[4];
                            }
                            else
                            {
                                TimeDetail[DayCount] += TimeOut[4];
                            }
                        }

                        #endregion
                        DayCount++;
                        LoopDate = LoopDate.AddDays(1);
                    }
                    SystemInfo.db.ExecSQL(sqlDay);
                    
                    MonthDaysM = Pub.DateDiff(DateInterval.Day, StartDate, EndDate) + 1;
                DimissionDate:
                    if (week == 1)
                    {
                        sqlMonth.Add("INSERT INTO KQ_KQReportWeek(KQYM,EmpNo,UpdateDate,MonthDays,SunDays,HdDays,WorkDays,AbsentDays," +
                        "WorkHrs,OtHrs,SunHrs,HdHrs,LateMins,LateCount,LeaveMins,LeaveCount,NSCount,MidCount,Hrs10,Hrs11," +
                        "Hrs12,Hrs13,Hrs14,Hrs15,Hrs16,Hrs17,Hrs18,Hrs19,StartDate,EndDate,MustDaysM) VALUES('" + KQYM + "','" +
                        EmpNo + "',now()," + RoundTwo(MonthDaysM).ToString().Replace(",", ".") + "," + RoundTwo(SunDaysM).ToString().Replace(",", ".") + "," + RoundTwo(HdDaysM).ToString().Replace(",", ".") + "," +
                        RoundTwo(WorkDaysM).ToString().Replace(",", ".") + "," + RoundTwo(AbsentDaysM).ToString().Replace(",", ".") + "," + RoundTwo(WorkHrsM).ToString().Replace(",", ".") + "," +
                        RoundTwo(OtHrsM).ToString().Replace(",", ".") + "," + RoundTwo(SunHrsM).ToString().Replace(",", ".") + "," + RoundTwo(HdHrsM).ToString().Replace(",", ".") + "," +
                        LateMinsM.ToString().Replace(",", ".") + "," + LateCountM.ToString().Replace(",", ".") + "," + LeaveMinsM.ToString().Replace(",", ".") + "," +
                        LeaveCountM.ToString().Replace(",", ".") + "," + NSCountM.ToString().Replace(",", ".") + "," + MidCountM.ToString().Replace(",", ".") + "," +
                        RoundTwo(Hrs[0]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[1]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[2]).ToString().Replace(",", ".") + "," +
                        RoundTwo(Hrs[3]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[4]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[5]).ToString().Replace(",", ".") + "," +
                        RoundTwo(Hrs[6]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[7]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[8]).ToString().Replace(",", ".") + "," +
                        RoundTwo(Hrs[9]).ToString().Replace(",", ".") + ",CDate('" + StartDate.ToString(SystemInfo.SQLDateFMT) + "'),CDate('" +
                        EndDate.ToString(SystemInfo.SQLDateFMT) + "')," + RoundTwo(MustDaysM).ToString().Replace(",", ".") + ")");
                    }
                    else
                    {
                        sqlMonth.Add( "INSERT INTO KQ_KQReportMonth(KQYM,EmpNo,UpdateDate,MonthDays,SunDays,HdDays,WorkDays,AbsentDays," +
                        "WorkHrs,OtHrs,SunHrs,HdHrs,LateMins,LateCount,LeaveMins,LeaveCount,NSCount,MidCount,Hrs10,Hrs11," +
                        "Hrs12,Hrs13,Hrs14,Hrs15,Hrs16,Hrs17,Hrs18,Hrs19,StartDate,EndDate,MustDaysM) VALUES('" + KQYM + "','" +
                        EmpNo + "',now()," + RoundTwo(MonthDaysM).ToString().Replace(",", ".") + "," + RoundTwo(SunDaysM).ToString().Replace(",", ".") + "," + RoundTwo(HdDaysM).ToString().Replace(",", ".") + "," +
                        RoundTwo(WorkDaysM).ToString().Replace(",", ".") + "," + RoundTwo(AbsentDaysM).ToString().Replace(",", ".") + "," + RoundTwo(WorkHrsM).ToString().Replace(",", ".") + "," +
                        RoundTwo(OtHrsM).ToString().Replace(",", ".") + "," + RoundTwo(SunHrsM).ToString().Replace(",", ".") + "," + RoundTwo(HdHrsM).ToString().Replace(",", ".") + "," +
                        LateMinsM.ToString().Replace(",", ".") + "," + LateCountM.ToString().Replace(",", ".") + "," + LeaveMinsM.ToString().Replace(",", ".") + "," +
                        LeaveCountM.ToString().Replace(",", ".") + "," + NSCountM.ToString().Replace(",", ".") + "," + MidCountM.ToString().Replace(",", ".") + "," +
                        RoundTwo(Hrs[0]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[1]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[2]).ToString().Replace(",", ".") + "," +
                        RoundTwo(Hrs[3]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[4]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[5]).ToString().Replace(",", ".") + "," +
                        RoundTwo(Hrs[6]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[7]).ToString().Replace(",", ".") + "," + RoundTwo(Hrs[8]).ToString().Replace(",", ".") + "," +
                        RoundTwo(Hrs[9]).ToString().Replace(",", ".") + ",CDate('" + StartDate.ToString(SystemInfo.SQLDateFMT) + "'),CDate('" +
                        EndDate.ToString(SystemInfo.SQLDateFMT) + "')," + RoundTwo(MustDaysM).ToString().Replace(",", ".") + ")");
                    }
                    #region 考勤月记录表
                 
                    KQDate = StartDate.ToString(SystemInfo.SQLDateFM);

                    if (KQDate != EndDate.ToString(SystemInfo.SQLDateFM))
                    {
                        KQDate += " - " + EndDate.ToString(SystemInfo.SQLDateFM);
                    }
                    examinationDayDetail(StartDate, DayDetail);

                    sqlMonth.Add("INSERT INTO KQ_KQReportMonthDetail(KQYM,KQDate,EmpNo,UpdateDate,Day01,Day02,Day03,Day04,Day05,Day06,Day07,Day08,Day09,Day10,Day11,Day12,Day13,Day14,Day15," +
                        "Day16,Day17,Day18,Day19,Day20,Day21,Day22,Day23,Day24,Day25,Day26,Day27,Day28,Day29,Day30,Day31,Time01,Time02,Time03,Time04,Time05,Time06,Time07,Time08," +
                        "Time09,Time10,Time11,Time12,Time13,Time14,Time15,Time16,Time17,Time18,Time19,Time20,Time21,Time22,Time23,Time24,Time25,Time26,Time27,Time28,Time29," +
                        "Time30,Time31) VALUES('" + KQYM + "','" + KQDate + "','" + EmpNo + "',now(),'" + DayDetail[0] + "','" + DayDetail[1] + "','" + DayDetail[2] + "','" + DayDetail[3] + "'" +
                        ",'" + DayDetail[4] + "','" + DayDetail[5] + "','" + DayDetail[6] + "','" + DayDetail[7] + "','" + DayDetail[8] + "','" + DayDetail[9] + "','" + DayDetail[10] + "'" +
                        ",'" + DayDetail[11] + "','" + DayDetail[12] + "','" + DayDetail[13] + "','" + DayDetail[14] + "','" + DayDetail[15] + "','" + DayDetail[16] + "','" + DayDetail[17] + "'" +
                        ",'" + DayDetail[18] + "','" + DayDetail[19] + "','" + DayDetail[20] + "','" + DayDetail[21] + "','" + DayDetail[22] + "','" + DayDetail[23] + "','" + DayDetail[24] + "','" + DayDetail[25] + "'" +
                        ",'" + DayDetail[26] + "','" + DayDetail[27] + "','" + DayDetail[28] + "','" + DayDetail[29] + "','" + DayDetail[30] + "','" + TimeDetail[0] + "','" + TimeDetail[1] + "'," +
                        "'" + TimeDetail[2] + "','" + TimeDetail[3] + "'" +
                        ",'" + TimeDetail[4] + "','" + TimeDetail[5] + "','" + TimeDetail[6] + "','" + TimeDetail[7] + "','" + TimeDetail[8] + "','" + TimeDetail[9] + "','" + TimeDetail[10] + "'" +
                        ",'" + TimeDetail[11] + "','" + TimeDetail[12] + "','" + TimeDetail[13] + "','" + TimeDetail[14] + "','" + TimeDetail[15] + "','" + TimeDetail[16] + "','" + TimeDetail[17] + "'" +
                        ",'" + TimeDetail[18] + "','" + TimeDetail[19] + "','" + TimeDetail[20] + "','" + TimeDetail[21] + "','" + TimeDetail[22] + "','" + TimeDetail[23] + "','" + TimeDetail[24] + "','" + TimeDetail[25] + "'" +
                        ",'" + TimeDetail[26] + "','" + TimeDetail[27] + "','" + TimeDetail[28] + "','" + TimeDetail[29] + "','" + TimeDetail[30] + "')");

                    #endregion
                    SystemInfo.db.ExecSQL(sqlMonth);
                    ret = true;
                }
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
            return ret;
        }
        //检查时间是否为空
        public void examinationDayDetail(DateTime StartDate,  string[] DayDetail)
        {
            for(int i=1;i< DayDetail.Length;i++)
            {
                if(DayDetail[i] == null) DayDetail[i] = getWeek(StartDate.AddDays(i));
            }
        }
        //获取星期
        public string getWeek(DateTime dateTime)
        {
            string ret = "";
            int index = Convert.ToInt16(dateTime.DayOfWeek);
            string weekStr = "";
            switch(index)
            {
                case 1:
                    weekStr = "Monday";
                    break;
                case 2:
                    weekStr = "Tuesday";
                    break;
                case 3:
                    weekStr = "Wednesday";
                    break;
                case 4:
                    weekStr = "Thursday";
                    break;
                case 5:
                    weekStr = "Friday";
                    break;
                case 6:
                    weekStr = "Saturday";
                    break;
                default:
                    weekStr = "Sunday";
                    break;
            }

            DataTableReader dr = SystemInfo.db.GetDataReader("select Name from SY_IDName where Class='KQ' and ID='" + weekStr + "'");
            if (dr.Read()) ret = dateTime.Day.ToString("00")+" "+dr[0].ToString();
            return ret;
        }
        public bool PKQ_CalcRecords(string EmpNo, string EmpName, string DepartID, string DepartName,
          DateTime StartDate, DateTime EndDate, string KQYM)
        {
            bool LimitUse = SystemInfo.ini.ReadIni("Public", "LimitUse", true);  
            int LimitCnt = SystemInfo.ini.ReadIni("Public", "LimitCnt", 100);
            bool ret = false;
            string sql = "DELETE FROM KQ_ReportRecords WHERE KQYM='" + KQYM + "' AND EmpNo='" + EmpNo + "'";
            DataTableReader dr = null;
            try
            {
                SystemInfo.db.ExecSQL(sql);
                DateTime LoopDate = StartDate;
                string[] S = new string[31];
                for (int i = 0; i < S.Length; i++)
                {
                    S[i] = "";
                }
                int DupLimit = 10;
                sql = "SELECT * FROM KQ_Rule WHERE RuleID='R0001'";
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read()) int.TryParse(dr["RuleDupLimit"].ToString(), out DupLimit);
                int idx = 0;
                int cnt = 0;
                DateTime OldTime = new DateTime();
                DateTime NewTime;
                bool Valid = true;
                while (LoopDate <= EndDate && idx < 31)
                {
                    sql = Pub.GetSQL(DBCode.DB_000215, new string[] { "2", EmpNo, LoopDate.ToString(SystemInfo.SQLDateFMT) });
                    dr = SystemInfo.db.GetDataReader(sql);
                    cnt = 0;
                    OldTime = new DateTime();
                    while (dr.Read())
                    {
                        NewTime = Convert.ToDateTime(dr[0]);
                        Valid = true;
                        if (LimitUse)
                        {
                            if (NewTime.CompareTo(OldTime.AddMinutes(DupLimit)) < 0) Valid = false;
                        }
                        if (Valid)
                        {
                            S[idx] += NewTime.ToString("HH:mm") + "\r\n";
                            cnt++;
                            OldTime = NewTime;
                            if (LimitCnt > 0 && cnt >= LimitCnt) break;
                        }
                    }
                    if (S[idx] != "") S[idx] = "  \r\n" + S[idx] + "  ";
                    LoopDate = LoopDate.AddDays(1);
                    idx++;
                }
                bool IsEmpty = true;
                for (int i = 0; i < S.Length; i++)
                {
                    if (S[i] != "")
                    {
                        IsEmpty = false;
                        break;
                    }
                }
                if (!IsEmpty)
                {
                    sql = Pub.GetSQL(DBCode.DB_000215, new string[] { "3", KQYM, EmpNo, EmpName, DepartID, DepartName,
            S[0], S[1], S[2], S[3], S[4], S[5], S[6], S[7], S[8], S[9], S[10], S[11], S[12], S[13], S[14],
            S[15], S[16], S[17], S[18], S[19], S[20], S[21], S[22], S[23], S[24], S[25], S[26], S[27], S[28],
            S[29], S[30] });
                    SystemInfo.db.ExecSQL(sql);
                }
                ret = true;
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
            return ret;
        }
    }
}