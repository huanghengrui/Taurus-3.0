using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmMJSeaSetSound : frmBaseDialog
    {

        protected override void InitForm()
        {
            formCode = "MJSeaSetSound";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
            cbbVolume.SelectedIndex = 0;
        }
        public frmMJSeaSetSound()
        {
            InitializeComponent();
        }
        private void frmMJSeaSetSound_Load(object sender, EventArgs e)
        {
            DataTableReader dr = null;
            string sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "2" });
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    if(!string.IsNullOrEmpty(dr["VerifyFailAudio"].ToString()))
                    {
                        chkVerifyFailAudio.Checked = Convert.ToBoolean(dr["VerifyFailAudio"]);
                    }
                    if (!string.IsNullOrEmpty(dr["VerifySuccAudio"].ToString()))
                    {
                        chkVerifySuccAudio.Checked = Convert.ToBoolean(dr["VerifySuccAudio"]);
                    }
                    if (!string.IsNullOrEmpty(dr["RemoteCtrlAudio"].ToString()))
                    {
                        chkRemoteCtrlAudio.Checked = Convert.ToBoolean(dr["RemoteCtrlAudio"]);
                    }
                    if (!string.IsNullOrEmpty(dr["VerifySuccGuiTip"].ToString()))
                    {
                        chkVerifySuccGuiTip.Checked = Convert.ToBoolean(dr["VerifySuccGuiTip"]);
                    }
                    if (!string.IsNullOrEmpty(dr["UnregisteredGuiTip"].ToString()))
                    {
                        chkUnregisteredGuiTip.Checked = Convert.ToBoolean(dr["UnregisteredGuiTip"]);
                    }
                    if (!string.IsNullOrEmpty(dr["VerifyFailGuiTip"].ToString()))
                    {
                        chkVerifyFailGuiTip.Checked = Convert.ToBoolean(dr["VerifyFailGuiTip"]);
                    }
                    if (!string.IsNullOrEmpty(dr["Volume"].ToString()))
                    {
                        cbbVolume.Text = dr["Volume"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["IPHide"].ToString()))
                    {
                        chkIPHide.Checked = Convert.ToBoolean(dr["IPHide"]);
                    }
                    if (!string.IsNullOrEmpty(dr["IsShowName"].ToString()))
                    {
                        chkIsShowName.Checked = Convert.ToBoolean(dr["IsShowName"]);
                    }
                    if (!string.IsNullOrEmpty(dr["IsShowTitle"].ToString()))
                    {
                        chkIsShowTitle.Checked = Convert.ToBoolean(dr["IsShowTitle"]);
                    }
                    if (!string.IsNullOrEmpty(dr["IsShowVersion"].ToString()))
                    {
                        chkIsShowVersion.Checked = Convert.ToBoolean(dr["IsShowVersion"]);
                    }
                    if (!string.IsNullOrEmpty(dr["IsShowDate"].ToString()))
                    {
                        chkIsShowDate.Checked = Convert.ToBoolean(dr["IsShowDate"]);
                    }
                    if (!string.IsNullOrEmpty(dr["IDCardNumHide"].ToString()))
                    {
                        chkIDCardNumHide.Checked = Convert.ToBoolean(dr["IDCardNumHide"]);
                    }
                    if (!string.IsNullOrEmpty(dr["ICCardNumHide"].ToString()))
                    {
                        chkICCardNumHide.Checked = Convert.ToBoolean(dr["ICCardNumHide"]);
                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                dr = null;
            }
            Application.DoEvents();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (cbbVolume.Text == "")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label1.Text));
                cbbVolume.Focus();
                return;
            }
            int VerifySuccAudio = Convert.ToInt32(chkVerifySuccAudio.Checked);
            int VerifyFailAudio = Convert.ToInt32(chkVerifyFailAudio.Checked);
            int RemoteCtrlAudio = Convert.ToInt32(chkRemoteCtrlAudio.Checked);
            int VerifySuccGuiTip = Convert.ToInt32(chkVerifySuccGuiTip.Checked);
            int VerifyFailGuiTip = Convert.ToInt32(chkVerifyFailGuiTip.Checked);
            int UnregisteredGuiTip = Convert.ToInt32(chkUnregisteredGuiTip.Checked);
            int Volume = Convert.ToInt32(cbbVolume.Text);
            int IPHide = Convert.ToInt32(chkIPHide.Checked);
            int IsShowName = Convert.ToInt32(chkIsShowName.Checked);
            int IsShowTitle = Convert.ToInt32(chkIsShowTitle.Checked);
            int IsShowVersion = Convert.ToInt32(chkIsShowVersion.Checked);
            int IsShowDate = Convert.ToInt32(chkIsShowDate.Checked);
            int IDCardNumHide = Convert.ToInt32(chkIDCardNumHide.Checked);
            int ICCardNumHide = Convert.ToInt32(chkICCardNumHide.Checked);
            SetSound setSound = new SetSound(VerifySuccAudio, VerifyFailAudio, RemoteCtrlAudio, Volume, VerifySuccGuiTip, VerifyFailGuiTip, UnregisteredGuiTip, IPHide,
                IsShowName, IsShowTitle, IsShowVersion, IsShowDate, IDCardNumHide, ICCardNumHide);
            jsonBody<SetSound> jsonBody = new jsonBody<SetSound>("SetSound", setSound);
            string jsonString = JsonConvert.SerializeObject(jsonBody);
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(this.Text, btnOk.Text, jsonString, 9, null);
            frm.ShowDialog();
            SaveParam();
        }

        private void btnGetSetSound_Click(object sender, EventArgs e)
        {
            string sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "2" });

            try
            {
                string param = "";
                frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(this.Text, btnGetSetSound.Text, param, 10, null);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    param = frm.BodyParameter;
                    if (param != "")
                    {
                        Pub.MessageBoxShow(btnGetSetSound.Text + Pub.GetResText("", "FK_RUN_SUCCESS", ""));
                        jsonBody<SetSound> jsonDoorCondition = JsonConvert.DeserializeObject<jsonBody<SetSound>>(param);

                        chkVerifyFailAudio.Checked = Convert.ToBoolean(jsonDoorCondition.info.VerifyFailAudio);
                        chkVerifySuccAudio.Checked = Convert.ToBoolean(jsonDoorCondition.info.VerifySuccAudio);
                        chkRemoteCtrlAudio.Checked = Convert.ToBoolean(jsonDoorCondition.info.RemoteCtrlAudio);
                        chkVerifySuccGuiTip.Checked = Convert.ToBoolean(jsonDoorCondition.info.VerifySuccGuiTip);
                        chkUnregisteredGuiTip.Checked = Convert.ToBoolean(jsonDoorCondition.info.UnregisteredGuiTip);
                        chkVerifyFailGuiTip.Checked = Convert.ToBoolean(jsonDoorCondition.info.VerifyFailGuiTip);
                        cbbVolume.Text = jsonDoorCondition.info.Volume.ToString();
                        chkIPHide.Checked = Convert.ToBoolean(jsonDoorCondition.info.IPHide);
                        chkIsShowName.Checked = Convert.ToBoolean(jsonDoorCondition.info.IsShowName);
                        chkIsShowTitle.Checked = Convert.ToBoolean(jsonDoorCondition.info.IsShowTitle);
                        chkIsShowVersion.Checked = Convert.ToBoolean(jsonDoorCondition.info.IsShowVersion);
                        chkIsShowDate.Checked = Convert.ToBoolean(jsonDoorCondition.info.IsShowDate);
                        chkIDCardNumHide.Checked = Convert.ToBoolean(jsonDoorCondition.info.IDCardNumHide);
                        chkICCardNumHide.Checked = Convert.ToBoolean(jsonDoorCondition.info.ICCardNumHide);

                        SaveParam();
                    }
                    else
                    {
                        Pub.MessageBoxShow(btnGetSetSound.Text + Pub.GetResText("", "FK_RUNERR_NON_CARRYOUT", ""));
                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
          
        }

        private void SaveParam()
        {
            DataTableReader dr = null;
            string sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "2" });
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    string MacSN = dr["MacSN"].ToString();
                    sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "1",MacSN, Convert.ToByte(chkVerifyFailAudio.Checked).ToString(),Convert.ToByte(chkVerifySuccAudio.Checked).ToString(),
                        Convert.ToByte(chkRemoteCtrlAudio.Checked).ToString(),
                        Convert.ToByte(chkVerifySuccGuiTip.Checked).ToString(),Convert.ToByte(chkUnregisteredGuiTip.Checked).ToString(),Convert.ToByte(chkVerifyFailGuiTip.Checked).ToString(),
                        cbbVolume.Text.ToString(),Convert.ToByte(chkIPHide.Checked).ToString(),Convert.ToByte(chkIsShowName.Checked).ToString(),
                        Convert.ToByte(chkIsShowTitle.Checked).ToString(),Convert.ToByte(chkIsShowVersion.Checked).ToString(),Convert.ToByte(chkIsShowDate.Checked).ToString(),
                        Convert.ToByte(chkIDCardNumHide.Checked).ToString(),Convert.ToByte(chkICCardNumHide.Checked).ToString() });
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "0","1", Convert.ToByte(chkVerifyFailAudio.Checked).ToString(),Convert.ToByte(chkVerifySuccAudio.Checked).ToString(),
                        Convert.ToByte(chkRemoteCtrlAudio.Checked).ToString(),
                        Convert.ToByte(chkVerifySuccGuiTip.Checked).ToString(),Convert.ToByte(chkUnregisteredGuiTip.Checked).ToString(),Convert.ToByte(chkVerifyFailGuiTip.Checked).ToString(),
                        cbbVolume.Text.ToString(),Convert.ToByte(chkIPHide.Checked).ToString(),Convert.ToByte(chkIsShowName.Checked).ToString(),
                        Convert.ToByte(chkIsShowTitle.Checked).ToString(),Convert.ToByte(chkIsShowVersion.Checked).ToString(),Convert.ToByte(chkIsShowDate.Checked).ToString(),
                        Convert.ToByte(chkIDCardNumHide.Checked).ToString(),Convert.ToByte(chkICCardNumHide.Checked).ToString() });
                }

                SystemInfo.db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                dr = null;
            }
        }
    }
}
