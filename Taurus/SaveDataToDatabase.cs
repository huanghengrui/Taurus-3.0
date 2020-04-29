using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Taurus
{
    /// <summary>
    /// 该类用于批量插入数据到数据库
    /// </summary>
    public class SaveDataToDatabase
    {
        private Base Pub = new Base();
        public DataTable table = null;
        public DataTable tableSvae = null;
        public DataTable tableMJ = null;
        public DataTable tablePID = null;
        public DataTable tableRSEmp = null;
        public DataTable dtMJData = new DataTable();
        public DataTable dtData = new DataTable();
        public DataTable dtPIDData = new DataTable();

        private string GetGUID()
        {
            string ret = System.Guid.NewGuid().ToString().ToUpper();
            return ret;
        }

        public bool PKQ_KQDataSave(int CardType, string CardNo, DateTime KQDate, string MacSN, string Remark,
      int VerifyModeID, string VerifyModeName, int InOutModeID, string InOutModeName, string Temperature, int TemperatureAlarm, ref string guid)
        {
            bool ret = false;
            guid = "";
            if (Temperature == "0") Temperature = "";
            DataRow[] dataRow = null;
            int KQTime = KQDate.Hour * 60 * 60 + KQDate.Minute * 60 + KQDate.Second;
            string sql = "";
            if (CardType == 1)
                dataRow = tableRSEmp.Select("CardNo10 = " + CardNo + "");
            else if (CardType == 2)
                dataRow = tableRSEmp.Select("CardNo81 = " + CardNo + "");
            else if (CardType == 3)
                dataRow = tableRSEmp.Select("CardNo82 = " + CardNo + "");
            else if (CardType == 4)
                dataRow = tableRSEmp.Select("FingerNo = " + CardNo + "");
            string EmpNo = "";
            try
            {
                if (dataRow.Length > 0)
                {
                    EmpNo = dataRow[0]["EmpNo"].ToString();
                }
                if (EmpNo != "")
                {
                    sql = "SELECT EmpNo,KQDate,KQTime FROM KQ_KQData";

                    if (table == null)
                    {
                        table = SystemInfo.db.GetDataTable(sql);
                    }
                    if (SystemInfo.DBType == 0 || SystemInfo.DBType == 255)
                    {
                        if (table.Select("EmpNo='" + EmpNo + "' AND KQDate='" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "' AND KQTime='" + KQDate.ToString("HHmmss") + "'").Length == 0&&
                            dtData.Select("EmpNo='" + EmpNo + "' AND KQDate='" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "' AND KQTime='" + KQDate.ToString("HHmmss") + "'").Length == 0)
                        {
                            guid = GetGUID().ToString();
                            dtData.Rows.Add(new object[] { guid, EmpNo, KQDate.ToString(SystemInfo.SQLDateTimeFMT), KQDate.Date.ToString(SystemInfo.SQLDateFMT), KQDate.ToString("HHmmss"), MacSN
                           , false, true, OprtInfo.OprtNo, DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), Remark, VerifyModeID, VerifyModeName, InOutModeID, InOutModeName,
                           Temperature.ToString(),TemperatureAlarm});

                            ret = true;
                        }
                   
                    }
                    else if (SystemInfo.DBType == 1 || SystemInfo.DBType == 2)
                    {
                        if (table.Select("EmpNo='" + EmpNo + "' AND KQDate='" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "' AND KQTime='" + KQTime.ToString() + "'").Length == 0&&
                            dtData.Select("EmpNo='" + EmpNo + "' AND KQDate='" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "' AND KQTime='" + KQTime.ToString() + "'").Length == 0)
                        {
                            guid = GetGUID().ToString();

                            dtData.Rows.Add(new object[] { guid, EmpNo, KQDate.Date.ToString(SystemInfo.SQLDateFMT), KQTime, MacSN
                           , false, true, OprtInfo.OprtNo, DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), Remark, VerifyModeID, VerifyModeName, InOutModeID, InOutModeName,
                           Temperature.ToString(),TemperatureAlarm});

                            ret = true;
                        }

                    }
                    if (dtData.Rows.Count >= 5000)
                    {
                        SystemInfo.db.batchSeveData(dtData, "KQ_KQData");
                        int count = table.Rows.Count;
                    EE:
                        table = null;
                        table = SystemInfo.db.GetDataTable(sql);

                        if (table.Rows.Count == 0 || count == table.Rows.Count)
                        {
                            goto EE;
                        }

                        dtData.Rows.Clear();
                    }

                }
            }
            catch (Exception E)
            {
                guid = "";
                Pub.ShowErrorMsg(E, sql);
            }
            return ret;
        }
        public bool PKQ_MJDataSave(int CardType, DateTime KQDate, string MacSN, string Remark, int VerifyModeID, string VerifyModeName,
         int InOutModeID, string InOutModeName, string CardNo, string DoorStauts, bool IsAlarm, string Temperature,int TemperatureAlarm,  ref string guid)
        {
            bool ret = false;
            guid = "";
            string sql = "";
            int KQTime = KQDate.Hour * 60 * 60 + KQDate.Minute * 60 + KQDate.Second;
            if (Temperature == "0") Temperature = "";
            DataRow[] dataRow = null;
           
            if (CardType == 1)
                dataRow = tableRSEmp.Select("CardNo10 = " + CardNo + "");
            else if (CardType == 2)
                dataRow = tableRSEmp.Select("CardNo81 = " + CardNo + "");
            else if (CardType == 3)
                dataRow = tableRSEmp.Select("CardNo82 = " + CardNo + "");
            else if (CardType == 4)
                dataRow = tableRSEmp.Select("FingerNo = " + CardNo + "");
            string EmpNo = "";
            try
            {
                if (dataRow.Length > 0)
                {
                    EmpNo = dataRow[0]["EmpNo"].ToString();
                }

                sql = "SELECT [GUID], MacSN,VerifyModeID,KQDate,KQTime FROM KQ_MJData";

                if (tableMJ == null)
                {
                    tableMJ = SystemInfo.db.GetDataTable(sql);
                }
                if (SystemInfo.DBType == 0 || SystemInfo.DBType == 255)
                {
                    if (tableMJ.Select("MacSN='" + MacSN + "' AND VerifyModeID=" + VerifyModeID.ToString() + " AND " +
               "KQDate='" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "' AND KQTime='" + KQDate.ToString("HHmmss") + "'").Length == 0)
                    {

                        if (dtMJData.Select("MacSN='" + MacSN + "' AND VerifyModeID=" + VerifyModeID.ToString() + " AND " +
               "KQDate='" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "' AND KQTime='" + KQDate.ToString("HHmmss") + "'").Length == 0)
                        {
                            guid = GetGUID().ToString();

                            if (tableMJ.Select("GUID = '" + guid + "'").Length == 0)
                            {
                                dtMJData.Rows.Add(new object[]{guid,KQDate.ToString(SystemInfo.SQLDateTimeFMT),KQDate.Date.ToString(SystemInfo.SQLDateFMT), 
                                    KQDate.ToString("HHmmss"),MacSN,VerifyModeID, VerifyModeName, InOutModeID, InOutModeName,OprtInfo.OprtNo, 
                                    DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), Remark, EmpNo.ToString(), DoorStauts, IsAlarm,Temperature,TemperatureAlarm});
                            }
                            ret = true;
                        }

                    }
                }
                else if (SystemInfo.DBType == 1 || SystemInfo.DBType == 2)
                {
                    if (tableMJ.Select("MacSN='" + MacSN + "' AND VerifyModeID=" + VerifyModeID.ToString() + " AND " +
               "KQDate='" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "' AND KQTime='" + KQTime.ToString() + "'").Length == 0)
                    {

                        if (dtMJData.Select("MacSN='" + MacSN + "' AND VerifyModeID=" + VerifyModeID.ToString() + " AND " +
               "KQDate='" + KQDate.Date.ToString(SystemInfo.SQLDateFMT) + "' AND KQTime='" + KQTime.ToString() + "'").Length == 0)
                        {
                            guid = GetGUID().ToString();

                            if (tableMJ.Select("GUID = '" + guid + "'").Length == 0)
                            {
                                dtMJData.Rows.Add(new object[] {guid, KQDate.ToString(SystemInfo.SQLDateFMT), KQTime, MacSN, VerifyModeID, VerifyModeName,
                                    InOutModeID, InOutModeName, OprtInfo.OprtNo, DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), Remark, EmpNo.ToString(),
                                    DoorStauts, IsAlarm,Temperature,TemperatureAlarm});
                            }
                            ret = true;
                        }

                    }
                }
                if (dtMJData.Rows.Count >= 6000)
                {
                    SystemInfo.db.batchSeveData(dtMJData, "KQ_MJData");  
                    int count = tableMJ.Rows.Count;
                EE:
                    tableMJ = null;
                    tableMJ = SystemInfo.db.GetDataTable(sql);

                    if (tableMJ.Rows.Count == 0 || count == tableMJ.Rows.Count)
                    {
                        goto EE;
                    }
                    dtMJData.Rows.Clear();
                }
            }
            catch (Exception E)
            {
                guid = "";
                Pub.ShowErrorMsg(E, sql);
            }
            return ret;
        }

        public bool PKQ_PIDDataSave(string EmpName, DateTime KQDateTime, string MacSN, string Gender,DateTime Birthday,string CardType, 
            string EmpCertNo, string EmpAddress, int InOutModeID, string InOutModeName, string Temperature, int TemperatureAlarm, string Nation,ref string guid)
        {
            bool ret = false;
            guid = "";
            string sql = "";
           
            if (Temperature == "0") Temperature = "";

            try
            {
               
                sql = "SELECT MacSN,KQDateTime FROM MJ_SeaPersonIDCard";

                if (tablePID == null)
                {
                    tablePID = SystemInfo.db.GetDataTable(sql);
                }
                if (tablePID.Select("MacSN='" + MacSN + "' AND KQDateTime='" + KQDateTime.ToString(SystemInfo.SQLDateTimeFMT) + "'").Length == 0)
                {

                    if (dtPIDData.Select("MacSN='" + MacSN + "' AND KQDateTime='" + KQDateTime.ToString(SystemInfo.SQLDateTimeFMT) + "'").Length == 0)
                    {
                        guid = GetGUID().ToString();

                        if (dtPIDData.Select("GUID = '" + guid + "'").Length == 0)
                        {
                            dtPIDData.Rows.Add(new object[]{guid, EmpName, KQDateTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, Gender,
                                    Birthday.ToString(SystemInfo.SQLDateFMT),CardType, EmpCertNo,EmpAddress,InOutModeID,InOutModeName, Temperature,TemperatureAlarm,Nation});
                        }
                        ret = true;
                    }

                }

                if (dtPIDData.Rows.Count >= 6000)
                {
                    SystemInfo.db.batchSeveData(dtPIDData, "MJ_SeaPersonIDCard");
                    int count = tablePID.Rows.Count;
                EE:
                    tablePID = null;
                    tablePID = SystemInfo.db.GetDataTable(sql);

                    if (tablePID.Rows.Count == 0 || count == tablePID.Rows.Count)
                    {
                        goto EE;
                    }
                    dtPIDData.Rows.Clear();
                }
            }
            catch (Exception E)
            {
                guid = "";
                Pub.ShowErrorMsg(E, sql);
            }
            return ret;
        }
    }
}
