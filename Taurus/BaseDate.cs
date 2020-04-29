using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmBaseDate : frmBaseDialog
    {

        private string oprt = "";

        protected override void InitForm()
        {
            gbxEmpTime.Enabled = false;
            formCode = "BaseDate";
            IsAllEmpInfo = true;
            base.InitForm();
            this.Text = oprt;
            if (SystemInfo.ini.ReadIni("Public", "Time_One", "") == "" || SystemInfo.ini.ReadIni("Public", "Time_One", "") == null
                || SystemInfo.ini.ReadIni("Public", "Time_Two", "") == "" || SystemInfo.ini.ReadIni("Public", "Time_Two", "") == null
                || SystemInfo.ini.ReadIni("Public", "Time_Three", "") == "" || SystemInfo.ini.ReadIni("Public", "Time_Three", "") == null
                || SystemInfo.ini.ReadIni("Public", "Time_Four", "") == "" || SystemInfo.ini.ReadIni("Public", "Time_Four", "") == null
                || SystemInfo.ini.ReadIni("Public", "Time_Five", "") == "" || SystemInfo.ini.ReadIni("Public", "Time_Five", "") == null)
            {
                SystemInfo.ini.WriteIni("Public", "Time_One", dtOne.Value.ToLongTimeString());
                SystemInfo.ini.WriteIni("Public", "Time_Two", dtTwo.Value.ToLongTimeString());
                SystemInfo.ini.WriteIni("Public", "Time_Three", dtThree.Value.ToLongTimeString());
                SystemInfo.ini.WriteIni("Public", "Time_Four", dtFour.Value.ToLongTimeString());
                SystemInfo.ini.WriteIni("Public", "Time_Five", dtFive.Value.ToLongTimeString());
                if (cbOne.Checked)
                {
                    SystemInfo.ini.WriteIni("Public", "cbOne", "1");
                }
                else
                    SystemInfo.ini.WriteIni("Public", "cbOne", "0");
                if (cbTwo.Checked)
                {
                    SystemInfo.ini.WriteIni("Public", "cbTwo", "1");
                }
                else
                    SystemInfo.ini.WriteIni("Public", "cbTwo", "0");
                if (cbThree.Checked)
                {
                    SystemInfo.ini.WriteIni("Public", "cbThree", "1");
                }
                else
                    SystemInfo.ini.WriteIni("Public", "cbThree", "0");
                if (cbFour.Checked)
                {
                    SystemInfo.ini.WriteIni("Public", "cbFour", "1");
                }
                else
                    SystemInfo.ini.WriteIni("Public", "cbFour", "0");
                if (cbFive.Checked)
                {
                    SystemInfo.ini.WriteIni("Public", "cbFive", "1");
                }
                else
                    SystemInfo.ini.WriteIni("Public", "cbFive", "0");
                return;
            }
            dtOne.Value = Convert.ToDateTime(SystemInfo.ini.ReadIni("Public", "Time_One", ""));
            dtTwo.Value = Convert.ToDateTime(SystemInfo.ini.ReadIni("Public", "Time_Two", ""));
            dtThree.Value = Convert.ToDateTime(SystemInfo.ini.ReadIni("Public", "Time_Three", ""));
            dtFour.Value = Convert.ToDateTime(SystemInfo.ini.ReadIni("Public", "Time_Four", ""));
            dtFive.Value = Convert.ToDateTime(SystemInfo.ini.ReadIni("Public", "Time_Five", ""));
            if (SystemInfo.ini.ReadIni("Public", "cbOne", "").Equals("1"))
            {
                cbOne.Checked = true;
            }
            else
                cbOne.Checked = false;
            if (SystemInfo.ini.ReadIni("Public", "cbTwo", "").Equals("1"))
            {
                cbTwo.Checked = true;
            }
            else
                cbTwo.Checked = false;
            if (SystemInfo.ini.ReadIni("Public", "cbThree", "").Equals("1"))
            {
                cbThree.Checked = true;
            }
            else
                cbThree.Checked = false;
            if (SystemInfo.ini.ReadIni("Public", "cbFour", "").Equals("1"))
            {
                cbFour.Checked = true;
            }
            else
                cbFour.Checked = false;
            if (SystemInfo.ini.ReadIni("Public", "cbFive", "").Equals("1"))
            {
                cbFive.Checked = true;
            }
            else
                cbFive.Checked = false;

            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }

        public frmBaseDate(string Oprt)
        {
            InitializeComponent();
            oprt = Oprt;
            InitForm();
        }

        public void Getdate()
        {
            gbxEmpTime.Enabled = false;
            app.timeStat = dtpStart.Value.ToString("yyyy-MM-dd");
            app.timeEnd = dtpEnd.Value.ToString("yyyy-MM-dd");
        }

        private void cbAll_Click(object sender, EventArgs e)
        {
            gbxEmpTime.Enabled = false;
            paTiming.Enabled = false;
        }

        private void cbEmp_Click(object sender, EventArgs e)
        {
            gbxEmpTime.Enabled = true;
            paTiming.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbEmp.Checked)
            {
                if (DateTime.Compare(dtpStart.Value, dtpEnd.Value) > 0)
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }
                app.IsAll = false;
                app.IsEmp = true;
                app.IsNew = false;
                Getdate();
            }
            else if (cbTiming.Checked)
            {
                app.IsEmp = false;
                app.IsAll = false;
                app.IsNew = false;
            }
            else if (cbAll.Checked)
            {
                app.IsAll = true;
                app.IsEmp = false;
                app.IsNew = false;
            }
            else if (cbNew.Checked)
            {
                app.IsEmp = false;
                app.IsAll = false;
                app.IsNew = true;
            }

            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            app.IsAll = true;
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbTiming_Click(object sender, EventArgs e)
        {
            gbxEmpTime.Enabled = false;
            paTiming.Enabled = true;
        }

        private void dtOne_ValueChanged(object sender, EventArgs e)
        {
            SystemInfo.ini.WriteIni("Public", "Time_One", dtOne.Value.ToLongTimeString());
        }

        private void dtTwo_ValueChanged(object sender, EventArgs e)
        {
            SystemInfo.ini.WriteIni("Public", "Time_Two", dtTwo.Value.ToLongTimeString());
        }

        private void dtThree_ValueChanged(object sender, EventArgs e)
        {
            SystemInfo.ini.WriteIni("Public", "Time_Three", dtThree.Value.ToLongTimeString());
        }

        private void dtFour_ValueChanged(object sender, EventArgs e)
        {
            SystemInfo.ini.WriteIni("Public", "Time_Four", dtFour.Value.ToLongTimeString());
        }

        private void dtFive_ValueChanged(object sender, EventArgs e)
        {
            SystemInfo.ini.WriteIni("Public", "Time_Five", dtFive.Value.ToLongTimeString());
        }

        private void cbOne_Click(object sender, EventArgs e)
        {
            if (cbOne.Checked)
            {
                SystemInfo.ini.WriteIni("Public", "cbOne", "1");
            }
            else
                SystemInfo.ini.WriteIni("Public", "cbOne", "0");
        }

        private void cbTwo_Click(object sender, EventArgs e)
        {
            if (cbTwo.Checked)
            {
                SystemInfo.ini.WriteIni("Public", "cbTwo", "1");
            }
            else
                SystemInfo.ini.WriteIni("Public", "cbTwo", "0");
        }

        private void cbThree_Click(object sender, EventArgs e)
        {
            if (cbThree.Checked)
            {
                SystemInfo.ini.WriteIni("Public", "cbThree", "1");
            }
            else
                SystemInfo.ini.WriteIni("Public", "cbThree", "0");
        }

        private void cbFour_Click(object sender, EventArgs e)
        {
            if (cbFour.Checked)
            {
                SystemInfo.ini.WriteIni("Public", "cbFour", "1");
            }
            else
                SystemInfo.ini.WriteIni("Public", "cbFour", "0");
        }

        private void cbFive_Click(object sender, EventArgs e)
        {
            if (cbFive.Checked)
            {
                SystemInfo.ini.WriteIni("Public", "cbFive", "1");
            }
            else
                SystemInfo.ini.WriteIni("Public", "cbFive", "0");
        }

        private void cbNew_Click(object sender, EventArgs e)
        {
            gbxEmpTime.Enabled = false;
            paTiming.Enabled = false;
        }
    }
    public class app
    {
        public static string timeStat;
        public static string timeEnd;
        public static bool IsAll = false;
        public static bool IsEmp = false;
        public static bool IsNew = false;
    }
}
