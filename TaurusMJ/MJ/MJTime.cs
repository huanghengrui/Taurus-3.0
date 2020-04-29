using grproLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmMJTime : frmBaseMDIChildReport
    {
        protected override void InitForm()
        {
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemDelete", false);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            formCode = "MJTime";
            ReportFile = "PassTime";
            ReportStartIndex = 2;
            base.InitForm();
            //InitTime();
            QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "400" });
            ExecItemRefresh();
        }

        public frmMJTime()
        {
            InitializeComponent();
        }
        protected void InitTime()
        {
            string ID = "1";
            string T1S = "00:00";
            string T1E = "23:59";
            string T2S = "00:00";
            string T2E = "00:00";
            string T3S = "00:00";
            string T3E = "00:00";
            string T4S = "00:00";
            string T4E = "00:00";
            string T5S = "00:00";
            string T5E = "00:00";
            string T6S = "00:00";
            string T6E = "00:00";
            DataTableReader dr = null;
            string sql = "";
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "403", ID }));
                if (dr.Read())
                    return;
                //      sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "405", ID, "", T1S, T1E, T2S, T2E, T3S, T3E,
                //T4S, T4E, T5S, T5E, T6S, T6E, OprtInfo.OprtNo });
                else
                    sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "404", ID,"", T1S, T1E, T2S, T2E, T3S, T3E,
              T4S, T4E, T5S, T5E, T6S, T6E, OprtInfo.OprtNo });
                SystemInfo.db.ExecSQL(sql);
               
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
        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmMJTimeAdd frm = new frmMJTimeAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmMJTimeAdd frm = new frmMJTimeAdd(this.Text, CurrentTool, Report.FieldByName("PassTimeID").AsString);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            new frmMJOprt(this.Text, CurrentTool, 0, null).ShowDialog();
            ExecItemRefresh();
        }

        protected override void ExecItemTAG2()
        {
            List<string> empNo = new List<string>();
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiChecked)
                {
                    empNo.Add(Report.FieldByName("PassTimeID").AsString);
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (empNo.Count == 0)
            {
                string msg = string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""), Pub.GetResText(formCode, "PassTimeID", ""));
                Pub.MessageBoxShow(msg);
                return;
            }
            base.ExecItemTAG2();
            new frmMJOprt(this.Text, CurrentTool, 1, empNo).ShowDialog();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
                string ret = Pub.GetSQL(DBCode.DB_000300, new string[] { "401", Report.FieldByName("PassTimeID").AsString });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = Pub.GetResText(formCode, "PassTimeID", "") + "=" + Report.FieldByName("PassTimeID").AsString;
            return ret;
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemTAG1.Enabled = State;
        }
    }
}