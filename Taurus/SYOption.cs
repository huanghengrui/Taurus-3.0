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
    public partial class frmSYOption : frmBaseDialog
    {

        protected override void InitForm()
        {
            formCode = "SYOption";
            base.InitForm();
            SetTextboxNumber(txtTime);
            this.Text = Title;
            LoadData();
        }

        public frmSYOption(string title)
        {
            Title = title;
            InitializeComponent();
        }

        private void LoadData()
        {
            chkExistDelete.Checked = SystemInfo.db.ReadConfig("SystemInfo", "IsExistDelete", true);
            chkUploadName.Checked = SystemInfo.db.ReadConfig("SystemInfo", "IsUploadName", true);
            chkWarning.Checked = SystemInfo.db.ReadConfig("SystemInfo", "IsWarning", false);
            chkOutHrs.Checked = SystemInfo.db.ReadConfig("SystemInfo", "OutHrs", false);
            chkAttendancePhoto.Checked = SystemInfo.db.ReadConfig("SystemInfo", "AttendancePhoto", false);
            txtPath.Text = SystemInfo.db.ReadConfig("SystemInfo", "Path");
            txtTime.Text = SystemInfo.db.ReadConfig("SystemInfo", "Time");
            rb26.Checked = SystemInfo.db.ReadConfig("SystemInfo", "Isrb26", false);
            rb34.Checked = SystemInfo.db.ReadConfig("SystemInfo", "Isrb34", true);
            txtTXTPath.Text = SystemInfo.db.ReadConfig("SystemInfo", "TxtPath");
            rbTime.Checked = SystemInfo.db.ReadConfig("SystemInfo", "IsrbTime", false);
            rbReal.Checked = SystemInfo.db.ReadConfig("SystemInfo", "IsrbReal", true);

            string time = SystemInfo.db.ReadConfig("SystemInfo", "dtTime");

            if (!string.IsNullOrEmpty(time))
            {
                dtTime.Value = Convert.ToDateTime(time);
            }

            if (rbTime.Checked)
            {
                dtTime.Enabled = true;
            }
            else
            {
                dtTime.Enabled = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.WriteConfig("SystemInfo", "IsExistDelete", chkExistDelete.Checked, this.Text, CurrentOprt)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "IsUploadName", chkUploadName.Checked, this.Text, CurrentOprt)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "IsWarning", chkWarning.Checked, this.Text, CurrentOprt)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "OutHrs", chkOutHrs.Checked, this.Text, CurrentOprt)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "AttendancePhoto", chkAttendancePhoto.Checked, this.Text, CurrentOprt)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "Path", txtPath.Text)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "Time", txtTime.Text)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "Isrb26", rb26.Checked, this.Text, CurrentOprt)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "Isrb34", rb34.Checked, this.Text, CurrentOprt)) return;

            if (!SystemInfo.db.WriteConfig("SystemInfo", "TxtPath", txtTXTPath.Text)) return;

            if (!SystemInfo.db.WriteConfig("SystemInfo", "dtTime", dtTime.Value.ToString(SystemInfo.SQLDatehm))) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "IsrbTime", rbTime.Checked, this.Text, CurrentOprt)) return;
            if (!SystemInfo.db.WriteConfig("SystemInfo", "IsrbReal", rbReal.Checked, this.Text, CurrentOprt)) return;

            SystemInfo.isAttendancePhoto = chkAttendancePhoto.Checked;
            SystemInfo.IsWarning = chkWarning.Checked;

            SystemInfo.IsZDTxtTime = rbTime.Checked;
            SystemInfo.IsZDTxtReal = rbReal.Checked;
            SystemInfo.ZDTxtPath = txtTXTPath.Text;
            SystemInfo.ZDTxtTime = dtTime.Value.ToString(SystemInfo.SQLDatehm);

            string msg = Pub.GetResText(formCode, "MsgSaveSucceed", "");
            SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, msg);
            Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            string TfileName = "";
            string Tfilter = "音频文件(*.WAV)|*.WAV|所有文件(*.*)|";
            string Ttitle = "Warning File";
            string TA = SaveFilePathName(TfileName, Tfilter, Ttitle);
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (TA != "")
            {
                txtPath.Text = TA;
            }
        }
        public static string SaveFilePathName(string fileName, string filter, string title)
        {
            string path = "";
            OpenFileDialog fbd = new OpenFileDialog();
            if (!string.IsNullOrEmpty(fileName))
            {
                fbd.FileName = fileName;
            }
            if (!string.IsNullOrEmpty(filter))
            {
                fbd.Filter = filter;// "Excel|*.xls;*.xlsx;";
            }
            if (!string.IsNullOrEmpty(title))
            {
                fbd.Title = title;// "保存为";
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.FileName;
            }
            return path;
        }

        private void btnSecletPatn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if(folder.ShowDialog() == DialogResult.OK)
            {
                txtTXTPath.Text = folder.SelectedPath;
            }
            return;
        }

        private void rbTime_CheckedChanged(object sender, EventArgs e)
        {
            if(rbTime.Checked)
            {
                dtTime.Enabled = true;
            }
            else
            {
                dtTime.Enabled = false;
            }
        }
    }
}