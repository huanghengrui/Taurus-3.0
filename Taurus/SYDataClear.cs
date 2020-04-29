using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmSYDataClear : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "SYDataClear";
            base.InitForm();
            this.Text = Title;
            dtpStart.Value = new DateTime(DateTime.Now.Year - 1, 1, 1);
            dtpEnd.Value = new DateTime(DateTime.Now.Year - 1, 12, 31);
            panelBar.Visible = false;
            lbBar.Text = this.Text + "...";
            clbClear.Items.Clear();

            if (SystemInfo.ShowKQ == 1)
            {
                AddClearItem(0, "KQEmpShift");
                AddClearItem(0, "KQDepShift");
                AddClearItem(1, "KQHoliday");
                AddClearItem(1, "KQEmpDayOff");
                AddClearItem(1, "KQEmpOtSure");
                AddClearItem(0, "KQEmpSignCard");
                AddClearItem(0, "KQReportData");
                AddClearItem(0, "KQReportDataFilter");
                AddClearItem(0, "KQReportDay");
                AddClearItem(2, "KQReportMonth");
                AddClearItem(2, "KQReportWeek");
                AddClearItem(2, "KQReportMonthDetail");
            }
            if (SystemInfo.ShowMJ == 1)
            {
                AddClearItem(0, "MJReportMJData");
                AddClearItem(1, "MJReportOpenData");
                AddClearItem(1, "MJReportAlarmData");
                AddClearItem(1, "MJSeaPersonIDCard");
            }

            for (int i = 0; i < clbClear.Items.Count; i++)
            {
                clbClear.SetItemChecked(i, true);
            }
        }

        public frmSYDataClear(string title)
        {
            Title = title;
            InitializeComponent();
        }

        private void AddClearItem(byte flag, string name)
        {
            TIDAndName idn = new TIDAndName(flag.ToString() + name, Pub.GetResText(formCode, "mnu" + name, ""));
            clbClear.Items.Add(idn);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return;
            panelBar.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
           List<string> sql = new List<string>();
            int index = 100;
            if (SystemInfo.ShowKQ == 0 && SystemInfo.ShowMJ == 1)
            {
                index = 300;
            }
            byte flag = 0;
            string msg = "";
            string StartDate = "";
            string EndDate = "";
            string s = ""; ;
            DataTableReader dr = null;
            int count = 0;
            List< string> dataSql = new List<string>();
            string[] tmp;
            DateTime T1 = dtpStart.Value;
            DateTime T2 = dtpEnd.Value;
            try
            {
                for (int i = 0; i < clbClear.Items.Count; i++)
                {
                    lbBar.Text = this.Text + " [" + ((TIDAndName)clbClear.Items[i]).name + "] ...";
                    
                    if (clbClear.GetItemChecked(i))
                    {
                        flag = Convert.ToByte(((TIDAndName)clbClear.Items[i]).id.Substring(0, 1));
                        switch (flag)
                        {
                            case 0:
                                StartDate = T1.ToString("yyyy/M/d");
                                EndDate = T2.ToString("yyyy/M/d");
                                break;
                            case 1:
                                StartDate = new DateTime(T1.Year, T1.Month, T1.Day, 0, 0, 0).ToString("yyyy/M/d H:mm:ss");
                                EndDate = new DateTime(T2.Year, T2.Month, T2.Day, 23, 59, 59).ToString("yyyy/M/d H:mm:ss");
                                break;
                            case 2:
                                StartDate = T1.ToString(SystemInfo.YMFormatDB);
                                EndDate = T2.ToString(SystemInfo.YMFormatDB);
                                break;
                        }
                        if (index >= 300 && index < 304)
                        {

                            while (true)
                            {
                                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { (index + 400).ToString(), StartDate, EndDate }));
                                if (dr.Read())
                                {
                                    if ((index + 500) == 800||(index + 500) == 803)
                                    {
                                        string s1 = Pub.GetSQL(DBCode.DB_000001, new string[] { (index + 500).ToString(), StartDate, EndDate });
                                        string[] ttp = s1.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                                        for (int x = 0; x < ttp.Length; x++)
                                        {
                                            SystemInfo.db.ExecSQL(ttp[x]);
                                        }
                                    }
                                    else
                                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { (index + 500).ToString(), StartDate, EndDate }));
                                    Application.DoEvents();
                                    count++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            s = Pub.GetSQL(DBCode.DB_000001, new string[] { index.ToString(), StartDate, EndDate });
                            sql.Add(s);
                        }
                        else
                        {
                            while (true)
                            {
                                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { (index + 400).ToString(), StartDate, EndDate }));
                                if (dr.Read())
                                {
                                    if((index+500)==606|| (index + 500) == 607 || (index + 500) == 612 || (index + 500) == 615)
                                    {
                                        string s1 = Pub.GetSQL(DBCode.DB_000001, new string[] { (index + 500).ToString(), StartDate, EndDate });
                                        string[] ttp = s1.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                                        for(int x=0;x<ttp.Length;x++)
                                        {
                                            SystemInfo.db.ExecSQL(ttp[x]);
                                        }
                                    }
                                    else
                                    {
                                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { (index + 500).ToString(), StartDate, EndDate }));
                                    }
                                    Application.DoEvents();
                                    count++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (index == 107)
                            {
                                while (true)
                                {

                                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "550", T1.ToString(SystemInfo.YMFormatDB),
                                    T2.ToString(SystemInfo.YMFormatDB) }));
                                    if (dr.Read())
                                    {
                                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "650", T1.ToString(SystemInfo.YMFormatDB),
                                        T2.ToString(SystemInfo.YMFormatDB) }));
                                        Application.DoEvents();
                                        count++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            s = Pub.GetSQL(DBCode.DB_000001, new string[] { index.ToString(), StartDate, EndDate });
                            tmp = s.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                            for (int j = 0; j < tmp.Length; j++)
                            {
                                sql.Add(tmp[j]);
                            }
                            if (index == 107)
                            {
                                StartDate = T1.ToString(SystemInfo.YMFormatDB);
                                EndDate = T2.ToString(SystemInfo.YMFormatDB);
                                s = Pub.GetSQL(DBCode.DB_000001, new string[] { "200", StartDate, EndDate });
                                sql.Add(s);

                            }
                        }

                    }
                    msg = msg + s + "\r\n";
                    index++;
                }
                panelBar.Visible = false;
                SystemInfo.db.WriteSYLog(Pub.GetResText("Main", "mnuSY", ""), this.Text, msg);
                if (sql.Count == 0)
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }

                if (SystemInfo.db.ExecSQL(sql) == 0)
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg002", ""), MessageBoxIcon.Information);
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                panelBar.Visible = false;
                if (dr != null) dr.Close();
                dr = null;
            }  
        }

        private void SelectModule(bool state)
        {
            for (int i = 0; i < clbClear.Items.Count; i++)
            {
                clbClear.SetItemChecked(i, state);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectModule(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectModule(false);
        }
    }
}