using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Taurus
{
    public partial class frmMJSeaPowerEdit : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "MJPowerEdit";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            txtEmpNo.Enabled = false;
            txtEmpName.Enabled = false;
            txtDepartName.Enabled = false;
            LoadData();
            KeyPreview = true;
            btnSelectStartDate.Text = "...";
            btnSelectEndDate.Text = "...";
        }

        public frmMJSeaPowerEdit(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
              
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "611", SysID }));
                if (dr.Read())
                {
                    txtEmpNo.Text = dr["EmpNo"].ToString();
                    txtEmpName.Text = dr["EmpName"].ToString();
                    txtDepartName.Text = dr["DepartName"].ToString();
                    DateTime d = new DateTime();
                    if (DateTime.TryParse(dr["StartDate"].ToString(), out d))
                    {
                        txtStartDate.Text = d.ToShortDateString();
                    }
                    if (DateTime.TryParse(dr["EndDate"].ToString(), out d))
                    {
                        txtEndDate.Text = d.ToShortDateString();
                    }
                }
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

        private void SetTimeIndex(ComboBox cbb, string value)
        {
            if (value == "0")
            {
                cbb.SelectedIndex = 0;
                return;
            }
            int index = 0;
            if (cbb.Items.Count > 0)
                index = 1;
            cbb.SelectedIndex = index;

            for (int i = 1; i < cbb.Items.Count; i++)
            {
                if (((TIDAndName)cbb.Items[i]).id == value)
                {
                    cbb.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string StartDate = "NULL";
            string EndDate = "NULL";
            DateTime StartDT;
            DateTime endDT;
            if (DateTime.TryParse(txtStartDate.Text, out StartDT))
                StartDate = "'" + StartDT.ToString(SystemInfo.SQLDateFMT) + "'";
            if (DateTime.TryParse(txtEndDate.Text, out endDT))
                EndDate = "'" + endDT.ToString(SystemInfo.SQLDateFMT) + "'";

            if (StartDT > endDT)
            {
                Pub.MessageBoxShow(Pub.GetResText("BaseDate", "Error001", ""));
                return;
            }
            string sql = "";
            try
            {
                sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "612", SysID, OprtInfo.OprtNo, StartDate, EndDate });
                SystemInfo.db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
            //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelectStartDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtStartDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtStartDate.Text = d.ToShortDateString();
        }

        private void btnSelectEndDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtEndDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtEndDate.Text = d.ToShortDateString();
        }
    }
}