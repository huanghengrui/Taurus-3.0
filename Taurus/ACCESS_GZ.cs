using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Reflection;

namespace Taurus
{
    public class ACCESS_GZ
    {
        private Base Pub = new Base();

        private void PGZ_CalcRule(string EmpNo, string Rule, string @YM, ref string sql, ref double Ret)
        {
            Ret = 0;
            if (!double.TryParse(Rule, out Ret))
            {
                sql = "SELECT " + Rule + " FROM VGZ_RuleItem WHERE EmpNo='" + EmpNo + "' AND KQYM='" + YM + "'";
                DataTableReader dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read()) double.TryParse(dr[0].ToString(), out Ret);
                dr.Close();
            }
        }

        public bool PGZ_Calc(string EmpNo, string YM)
        {
            bool ret = false;
            string GZItemID = "";
            double EmpGZ = 0;
            string DepartID = "";
            string[] ItemIn = new string[20];
            string[] ItemOut = new string[20];
            double[] InD = new double[20];
            double[] OutD = new double[20];
            double Sum = 0;
            string sql = "SELECT * FROM GZ_GZReport WHERE EmpNo='" + EmpNo + "' AND KQYM='" + YM + "' AND IsFreeze";
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read()) goto TheEnd;
                dr.Close();
                sql = "DELETE FROM GZ_GZReport WHERE EmpNo='" + EmpNo + "' AND KQYM='" + YM + "'";
                SystemInfo.db.ExecSQL(sql);
                sql = "SELECT DepartID,GZRuleID,EmpGZ FROM RS_Emp WHERE EmpNo='" + EmpNo + "'";
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    DepartID = dr[0].ToString();
                    GZItemID = dr[1].ToString();
                    double.TryParse(dr[2].ToString(), out EmpGZ);
                }
                dr.Close();
                if (GZItemID == "")
                {
                    sql = "SELECT GZRuleID FROM RS_Depart WHERE DepartID='" + DepartID + "'";
                    dr = SystemInfo.db.GetDataReader(sql);
                    if (dr.Read()) GZItemID = dr[0].ToString();
                    dr.Close();
                }
                if(GZItemID == "")
                {
                   return ret;
                }
                Sum = EmpGZ;
                sql = "SELECT * FROM VGZ_ItemCalc WHERE ItemId=" + GZItemID;
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    for (int i = 0; i <= 19; i++)
                    {
                        ItemIn[i] = dr[i + 1].ToString();
                        ItemOut[i] = dr[i + 21].ToString();
                    }
                }
                dr.Close();
                for (int i = 0; i <= 19; i++)
                {
                    if (ItemIn[i] == "") goto TheOut;
                    PGZ_CalcRule(EmpNo, ItemIn[i], YM, ref sql, ref InD[i]);
                    Sum += InD[i];
                }
            TheOut:
                for (int i = 0; i <= 19; i++)
                {
                    if (ItemOut[i] == "") goto TheSave;
                    PGZ_CalcRule(EmpNo, ItemOut[i], YM, ref sql, ref OutD[i]);
                    Sum -= OutD[i];
                }
            TheSave:
                string s1 = "";
                string s2 = "";
                string s3 = "";
                string s4 = "";
                for (int i = 1; i <= 20; i++)
                {
                    s1 += "In" + i.ToString() + ",";
                    s2 += "Out" + i.ToString() + ",";
                    s3 += InD[i - 1].ToString("0.00") + ",";
                    s4 += OutD[i - 1].ToString("0.00") + ",";
                }
                sql = "INSERT INTO GZ_GZReport(KQYM,EmpNo,UpdateDate,EmpGZ," + s1 + s2 + "[SUM],IsFreeze) VALUES('" +
                  YM + "','" + EmpNo + "',now()," + EmpGZ.ToString("0.00") + "," + s3 + s4 + Sum.ToString("0.00") + ",0)";
                SystemInfo.db.ExecSQL(sql);
                ret = true;
            TheEnd:
                ;
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