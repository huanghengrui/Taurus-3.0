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
    public partial class frmMJSeaTemperature : frmBaseDialog
    {

        protected override void InitForm()
        {
            formCode = "MJSeaTemperature";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");

            cbbFaceMaskTPTMode.Items.AddRange(new object[] {
               new TemperatureType(0, Pub.GetResText(formCode, "Null", "")),
               new TemperatureType(1, Pub.GetResText(formCode, "Temperature", "")),
               new TemperatureType(2, Pub.GetResText(formCode, "Mask", "")),
               new TemperatureType(3, Pub.GetResText(formCode, "TemperatureAndWhite", "")),
               new TemperatureType(4, Pub.GetResText(formCode, "MaskAndWhite", "")),
               new TemperatureType(5, Pub.GetResText(formCode, "MaskAndTemperature", "")),
               new TemperatureType(6, Pub.GetResText(formCode, "MaskAndTemperatureAndWhite", ""))
                });

            cbbFaceMaskTPTMode.SelectedIndex = 0;

            cbbOpenLaser.Items.AddRange(new object[] {
                Pub.GetResText(formCode,"no",""),
                Pub.GetResText(formCode,"yes","")
                });

            cbbOpenLaser.SelectedIndex = 0;

            DataTableReader dr = null;
            int FaceMaskTPTMode = 0;
            double TemperatureCheck = 0.00;
            double TemperatureHigh = 37.30;
            double EnvTemperature = 17.00;
            double EnvTemperatureCheck = 0.00;
            int OpenLaser = 0;

            string sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "22" });
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    Int32.TryParse(dr["FaceMaskTPTMode"].ToString(), out FaceMaskTPTMode);
                    Double.TryParse(dr["TemperatureCheck"].ToString(), out TemperatureCheck);
                    Double.TryParse(dr["TemperatureHigh"].ToString(), out TemperatureHigh);
                    Double.TryParse(dr["EnvTemperature"].ToString(), out EnvTemperature);
                    Double.TryParse(dr["EnvTemperatureCheck"].ToString(), out EnvTemperatureCheck);
                    Int32.TryParse(dr["OpenLaser"].ToString(), out OpenLaser);
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

            cbbFaceMaskTPTMode.SelectedIndex = FaceMaskTPTMode;
            cbbOpenLaser.SelectedIndex = OpenLaser;
            txtTemperatureCheck.Text = TemperatureCheck.ToString("0.00");
            txtTemperatureHigh.Text = TemperatureHigh.ToString("0.00");
            txtEnvTemperature.Text = EnvTemperature.ToString("0.00");
            txtEnvTemperatureCheck.Text = EnvTemperatureCheck.ToString("0.00");

        }
        public frmMJSeaTemperature()
        {
            InitializeComponent();
        }
   
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTemperatureCheck.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), lbTemperatureCheck.Text));
                txtTemperatureCheck.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTemperatureHigh.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), lbTemperatureHigh.Text));
                txtTemperatureHigh.Focus();
                return;
            }
            if (txtEnvTemperature.Text=="")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), lbEnvTemperature.Text));
                txtTemperatureCheck.Focus();
                return;
            }
            if (txtEnvTemperatureCheck.Text=="")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), lbEnvTemperatureCheck.Text));
                txtEnvTemperatureCheck.Focus();
                return;
            }
            int FaceMaskTPTMode = ((TemperatureType)cbbFaceMaskTPTMode.SelectedItem).id;
            double TemperatureCheck = Math.Round(Convert.ToDouble(txtTemperatureCheck.Text),2);
            double TemperatureHigh = Math.Round(Convert.ToDouble(txtTemperatureHigh.Text), 2);
            double EnvTemperature = Math.Round(Convert.ToDouble(txtEnvTemperature.Text), 2);
            double EnvTemperatureCheck = Math.Round(Convert.ToDouble(txtEnvTemperatureCheck.Text), 2);
            int OpenLaser = cbbOpenLaser.SelectedIndex;


            TemperatureParam temperatureParam = new TemperatureParam(111111,FaceMaskTPTMode, TemperatureCheck,TemperatureHigh,EnvTemperature, EnvTemperatureCheck, OpenLaser);
            jsonBody<TemperatureParam> jsonBody = new jsonBody<TemperatureParam>("SetTemperature", temperatureParam);
            string jsonString = JsonConvert.SerializeObject(jsonBody);
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(this.Text, btnOk.Text, jsonString, 14, null);
            frm.ShowDialog();

            SaveParam();

        }

        private void btnGetNetParam_Click(object sender, EventArgs e)
        {
            string param = "";
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(this.Text, btnGetTemperatureParam.Text, param, 15,null);

            if(frm.ShowDialog()==DialogResult.OK)
            {
                param = frm.BodyParameter;
                if(param!="")
                {
                    Pub.MessageBoxShow(btnGetTemperatureParam.Text + Pub.GetResText("", "FK_RUN_SUCCESS", ""));
                    jsonBody<TemperatureParam> jsonTemperatureParam = JsonConvert.DeserializeObject<jsonBody<TemperatureParam>>(param);
                   
                    txtTemperatureCheck.Text = jsonTemperatureParam.info.TemperatureCheck.ToString("0.00");
                    txtTemperatureHigh.Text = jsonTemperatureParam.info.TemperatureHigh.ToString("0.00");
                    txtEnvTemperature.Text = jsonTemperatureParam.info.EnvTemperature.ToString("0.00");
                    txtEnvTemperatureCheck.Text = jsonTemperatureParam.info.EnvTemperatureCheck.ToString("0.00");
                    cbbFaceMaskTPTMode.SelectedIndex = jsonTemperatureParam.info.FaceMaskTPTMode;
                    cbbOpenLaser.SelectedIndex = jsonTemperatureParam.info.OpenLaser;

                    SaveParam();
                }
                else
                {
                    Pub.MessageBoxShow(btnGetTemperatureParam.Text + Pub.GetResText("", "FK_RUNERR_NON_CARRYOUT", ""));
                }
            }

           
        }

        private void SaveParam()
        {
            DataTableReader dr = null;
            string sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "22" });
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    string MacSN = dr["MacSN"].ToString();
                    sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "21",MacSN, ((TemperatureType)cbbFaceMaskTPTMode.SelectedItem).id.ToString(),txtTemperatureCheck.Text.ToString(),
                                txtTemperatureHigh.Text.ToString(),txtEnvTemperatureCheck.Text.ToString(),txtEnvTemperature.Text.ToString(),cbbOpenLaser.SelectedIndex.ToString()});
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "20","1", ((TemperatureType)cbbFaceMaskTPTMode.SelectedItem).id.ToString(),txtTemperatureCheck.Text.ToString(),
                                txtTemperatureHigh.Text.ToString(),txtEnvTemperatureCheck.Text.ToString(),txtEnvTemperature.Text.ToString(),cbbOpenLaser.SelectedIndex.ToString()});
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
    public class TemperatureType
    {
        private int _id;
        private string _name;

        public TemperatureType(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
