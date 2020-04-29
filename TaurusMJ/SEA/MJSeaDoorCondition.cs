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
    public partial class frmMJDoorCondition : frmBaseDialog
    {

        protected override void InitForm()
        {
            formCode = "MJDoorCondition";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
            SetTextboxNumber(txtIOStayTime);
            SetTextboxNumber(txtPublicMjCardNo);
            SetTextboxNumber(txtAutoMjCardBgnNo);
            SetTextboxNumber(txtAutoMjCardEndNo);
            cbbOpendoorWay.Items.AddRange(new object[] {
                Pub.GetResText(formCode,"FaceOpenMode",""),
                Pub.GetResText(formCode,"RemoteDoorOpenMode",""),
                Pub.GetResText(formCode,"RemoteDoorOrFaceOpenMode","")
                });
            cbbOpendoorWay.SelectedIndex = 0;
            cbbVerifyMode.Items.AddRange(new object[] {
              new VerifyModeType(1, Pub.GetResText(formCode, "Whitelist", "")),
              new VerifyModeType(2, Pub.GetResText(formCode, "IdCard", "")),
              new VerifyModeType(3, Pub.GetResText(formCode, "WhitelistAndIdCard", "")),
              new VerifyModeType(4, Pub.GetResText(formCode, "WhitelistOrIdCard", "")),
              new VerifyModeType(21, Pub.GetResText(formCode, "RFCard", "")),
              new VerifyModeType(22, Pub.GetResText(formCode, "RFCardAndWhiteList", "")),
              new VerifyModeType(23, Pub.GetResText(formCode, "RFCardOrWhiteList", "")),
              new VerifyModeType(24, Pub.GetResText(formCode, "WiganCard", "")),
              new VerifyModeType(25, Pub.GetResText(formCode, "WiganCardAndWhiteList", "")),
              new VerifyModeType(26, Pub.GetResText(formCode, "WiganCardOrWhiteList", "")),
              new VerifyModeType(261, Pub.GetResText(formCode, "Mask", "")),
              new VerifyModeType(517, Pub.GetResText(formCode, "Temperature", "")),
              new VerifyModeType(257, Pub.GetResText(formCode, "MaskAndWhite", "")),
              new VerifyModeType(513, Pub.GetResText(formCode, "TemperatureAndWhite", "")),
              new VerifyModeType(768, Pub.GetResText(formCode, "MaskAndTemperature", "")),
              new VerifyModeType(793, Pub.GetResText(formCode, "MaskAndTemperatureAndWhite", ""))
                });
            cbbVerifyMode.SelectedIndex = 0;
            cbbWiegand.Items.AddRange(new object[] {
               "26",
               "34"
                });
            cbbControlType.Items.AddRange(new object[] {
                Pub.GetResText(formCode,"WiganInterface",""),
                Pub.GetResText(formCode,"SwitchingValue",""),
                Pub.GetResText(formCode,"WiganInterfaceAndSwitchingValue","")
                });
            cbbControlType.SelectedIndex = 0;
            int FaceThreshold = 0;
            int IDCardThreshold = 0;
            int OpendoorWay = 0;
            int VerifyMode = 0;
            int Wiegand = 0;
            int ControlType = 0;


            DataTableReader dr = null;
            string sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "12" });
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    Int32.TryParse(dr["FaceThreshold"].ToString(), out FaceThreshold);
                    Int32.TryParse(dr["IDCardThreshold"].ToString(), out IDCardThreshold);
                    Int32.TryParse(dr["OpendoorWay"].ToString(), out OpendoorWay);
                    Int32.TryParse(dr["VerifyMode"].ToString(),  out VerifyMode);
                    Int32.TryParse(dr["Wiegand"].ToString(), out Wiegand);
                    Int32.TryParse(dr["ControlType"].ToString(), out ControlType);
                    txtPublicMjCardNo.Text = dr["PublicMjCardNo"].ToString();
                    txtAutoMjCardBgnNo.Text = dr["AutoMjCardBgnNo"].ToString(); 
                    txtAutoMjCardEndNo.Text = dr["AutoMjCardEndNo"].ToString();
                    txtIOStayTime.Text = dr["IOStayTime"].ToString();
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

            cbbFaceThreshold.SelectedIndex = FaceThreshold;
            cbbIDCardThreshold.SelectedIndex = IDCardThreshold;
            cbbOpendoorWay.SelectedIndex = OpendoorWay;
            foreach (VerifyModeType verify in cbbVerifyMode.Items)
            {
                if (VerifyMode == verify.id)
                {
                    cbbVerifyMode.SelectedItem = verify;
                    break;
                }
            }

            cbbWiegand.SelectedIndex = Wiegand;
            cbbControlType.SelectedIndex = ControlType;
            if(string.IsNullOrEmpty(txtPublicMjCardNo.Text))
            {
                txtPublicMjCardNo.Text = "2";
            }
            if (string.IsNullOrEmpty(txtAutoMjCardBgnNo.Text))
            {
                txtAutoMjCardBgnNo.Text = "2";
            }
            if (string.IsNullOrEmpty(txtAutoMjCardEndNo.Text))
            {
                txtAutoMjCardEndNo.Text = "4";
            }
            if (string.IsNullOrEmpty(txtIOStayTime.Text))
            {
                txtIOStayTime.Text = "5";
            }
            Application.DoEvents();
        }
        public frmMJDoorCondition()
        {
            InitializeComponent();
        }
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName();
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        string ip = "";
                        ip = IpEntry.AddressList[i].ToString();
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbVerifyMode.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""), label4.Text));
                return;
            }
            if (string.IsNullOrEmpty(cbbControlType.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""), label5.Text));
                return;
            }
            if (string.IsNullOrEmpty(txtPublicMjCardNo.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), label7.Text));
                txtPublicMjCardNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtAutoMjCardBgnNo.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), label8.Text));
                txtAutoMjCardBgnNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtAutoMjCardEndNo.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), label9.Text));
                txtAutoMjCardEndNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtIOStayTime.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorEnterCorrect", ""), label10.Text));
                txtIOStayTime.Focus();
                return;
            }
            int FaceThreshold = cbbFaceThreshold.SelectedIndex + 50;
            int IDCardThreshold = cbbIDCardThreshold.SelectedIndex + 50;
            int OpendoorWay = cbbOpendoorWay.SelectedIndex;

            int VerifyMode = ((VerifyModeType)cbbVerifyMode.SelectedItem).id;
            int ControlType = cbbControlType.SelectedIndex;
            int Wiegand = cbbWiegand.SelectedIndex;
            uint PublicMjCardNo = Convert.ToUInt32(txtPublicMjCardNo.Text);
            uint AutoMjCardBgnNo = Convert.ToUInt32(txtAutoMjCardBgnNo.Text);
            uint AutoMjCardEndNo = Convert.ToUInt32(txtAutoMjCardEndNo.Text);
            int IOStayTime = Convert.ToInt32(txtIOStayTime.Text);

            DoorCondition doorCondition = new DoorCondition(FaceThreshold, IDCardThreshold, OpendoorWay, VerifyMode, ControlType, Wiegand, PublicMjCardNo,
                AutoMjCardBgnNo, AutoMjCardEndNo, IOStayTime);
            jsonBody<DoorCondition> jsonDoorCondition = new jsonBody<DoorCondition>("SetDoorCondition", doorCondition);
            string jsonString = JsonConvert.SerializeObject(jsonDoorCondition);
           
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(this.Text, btnOk.Text, jsonString, 2,null);
            frm.ShowDialog();

            SaveParam();
        }

        private void btnGetParam_Click(object sender, EventArgs e)
        {
            string param = "";
            frmMJSeaSeriesOprt frm = new frmMJSeaSeriesOprt(this.Text, btnGetParam.Text, param, 3,null);
            if( frm.ShowDialog()==DialogResult.OK)
            {
                param = frm.BodyParameter;
                if (param != "")
                {
                    Pub.MessageBoxShow(btnGetParam.Text + Pub.GetResText("", "FK_RUN_SUCCESS", ""));
                    jsonBody<DoorCondition> jsonDoorCondition = JsonConvert.DeserializeObject<jsonBody<DoorCondition>>(param);
                    cbbFaceThreshold.SelectedIndex = jsonDoorCondition.info.FaceThreshold-50;
                    cbbIDCardThreshold.SelectedIndex = jsonDoorCondition.info.IDCardThreshold-50;
                    cbbOpendoorWay.SelectedIndex = jsonDoorCondition.info.OpendoorWay;
                    foreach(VerifyModeType verify in cbbVerifyMode.Items)
                    {
                        if(jsonDoorCondition.info.VerifyMode == verify.id)
                        {
                            cbbVerifyMode.SelectedItem = verify;
                            break;
                        }
                    }

                    cbbWiegand.SelectedIndex = jsonDoorCondition.info.Wiegand;
                    cbbControlType.SelectedIndex = jsonDoorCondition.info.ControlType;
                    txtPublicMjCardNo.Text = jsonDoorCondition.info.PublicMjCardNo.ToString();
                    txtAutoMjCardBgnNo.Text = jsonDoorCondition.info.AutoMjCardBgnNo.ToString();
                    txtAutoMjCardEndNo.Text = jsonDoorCondition.info.AutoMjCardEndNo.ToString();
                    txtIOStayTime.Text = jsonDoorCondition.info.IOStayTime.ToString();

                    SaveParam();
                }
                else
                {
                    Pub.MessageBoxShow(btnGetParam.Text + Pub.GetResText("", "FK_RUNERR_NON_CARRYOUT", ""));
                }
            }
        }

        private void SaveParam()
        {
            DataTableReader dr = null;
            string sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "12" });
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                if (dr.Read())
                {
                    string MacSN = dr["MacSN"].ToString();
                    sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "11",MacSN, cbbFaceThreshold.SelectedIndex.ToString(),cbbIDCardThreshold.SelectedIndex.ToString(),
                                cbbOpendoorWay.SelectedIndex.ToString(),((VerifyModeType)cbbVerifyMode.SelectedItem).id.ToString(),cbbWiegand.SelectedIndex.ToString(),cbbControlType.SelectedIndex.ToString(),
                                 txtPublicMjCardNo.Text,txtAutoMjCardBgnNo.Text,txtAutoMjCardEndNo.Text,txtIOStayTime.Text});
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_000500, new string[] { "10","1", cbbFaceThreshold.SelectedIndex.ToString(),cbbIDCardThreshold.SelectedIndex.ToString(),
                                cbbOpendoorWay.SelectedIndex.ToString(),((VerifyModeType)cbbVerifyMode.SelectedItem).id.ToString(),cbbWiegand.SelectedIndex.ToString(),cbbControlType.SelectedIndex.ToString(),
                                 txtPublicMjCardNo.Text,txtAutoMjCardBgnNo.Text,txtAutoMjCardEndNo.Text,txtIOStayTime.Text});
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

        private void cbbControlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbControlType.SelectedIndex == 0)
            {
                txtPublicMjCardNo.Enabled = false;
                txtAutoMjCardBgnNo.Enabled = false;
                txtAutoMjCardEndNo.Enabled = false;
            }
            else
            {
                txtPublicMjCardNo.Enabled = true;
                txtAutoMjCardBgnNo.Enabled = true;
                txtAutoMjCardEndNo.Enabled = true;
            }
        }
    }
    public class VerifyModeType
    {
        private int _id;
        private string _name;

        public VerifyModeType(int id, string name)
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
