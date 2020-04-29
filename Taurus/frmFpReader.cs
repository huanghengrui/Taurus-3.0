using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmFpReader : frmBaseDialog
    {

        public List<string> devIdList = new List<string>();
        public List<byte[]> fpDataList = new List<byte[]>();
        public uint contextId;
        public int deviceCompany;
        public int imageWidth, imageHeight, imageRes, featureSize, templateSize, updatedFlag;
        public int fpAreaTh, noCheckCountTh;
        public byte[] imageBuffer, template, updatedTemplate, rawImgBuffer;
        public const int maxContinuosFpPressCount = 5;

        public byte[][] feature = new byte[3][];

        public bool StopFlag = false;
        public bool InitFlag = true;

        public frmFpReader(string EmpNo, string FingerNo)
        {
            InitializeComponent();
            txtEmpNo.Text = EmpNo;
            txtFingerNo.Text = FingerNo;
        }

        protected override void InitForm()
        {
            formCode = "FPReader";
            gbxFpReader.Enabled = false;
            cbbDevice.Enabled = false;
            try
            {
                btnInit_Click(null, null);
            }
            catch { }
            base.InitForm();
            this.Text = Pub.GetResText(formCode, this.Name, "");

        }

        private bool Init()
        {
            devIdList.Clear();
            cbbDevice.Items.Clear();

            for (int i = 0; i < ObjFpReader.PISFP_MAX_DEVICE_COUNTS; i++)
            {
                byte[] vstrDeviceDescription = new byte[1024];
                byte[] vstrDevId = new byte[1024];

                if (ObjFpReader.pisEnumerateDevice(i, vstrDevId, vstrDeviceDescription) == ObjFpReader.PISFP_OK)
                {
                    cbbDevice.Items.Add(Encoding.Default.GetString(vstrDeviceDescription, 0, vstrDeviceDescription.Length));
                    devIdList.Add(Encoding.Default.GetString(vstrDevId, 0, vstrDevId.Length));
                }
            }

            if (cbbDevice.Items.Count > 0)
            {
                InitFlag = true  ;
                cbbDevice.SelectedIndex = 0;
                InitFlag = false;
                return true;
            }

            return false;
        }

        private void Exit()
        {
            StopFlag = true;
           
            if (deviceCompany == ObjFpReader.PRODUCT_HYSOON || deviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_OFF);
            }

            ObjFpReader.pisCloseDevice(contextId);
            ObjFpReader.pisDestroyContext(contextId);
            gbxFpReader.Enabled = false;
            btnInit.Enabled = true;
            cbbDevice.Enabled = true;

        }

        private void frmFpReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit();
        }

        #region 存取数据库中的指纹数据
        private bool GetDbFingerData(string EmpNo, string FingerNo)
        {
            fpDataList.Clear();
            string sql = "SELECT * FROM VRS_EmpFingerInfo WHERE EmpNo='" + EmpNo + "' AND FingerBkNo BETWEEN 0 AND 9 ORDER BY FingerBkNo";
            DataTable dt = new DataTable();
            try
            {
                dt = SystemInfo.db.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    byte[] buff = (byte[])dt.Rows[i]["FingerData"];
                    byte[] buffConv = new byte[1680];
                    byte[] fpdata = new byte[1600];
                    ObjFpReader.ConvEnrollData(buff, ref buffConv, 1680);
                    Array.Copy(buffConv, 80, fpdata, 0, 1600);
                    fpDataList.Add(fpdata);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool GetDbFingerNo(string EmpNo)
        {
            string sql = "SELECT * FROM RS_Emp WHERE EmpNo='" + EmpNo + "'";
            DataTable dt = new DataTable();
            try
            {
                dt = SystemInfo.db.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                    txtFingerNo.Text = dt.Rows[0]["FingerNo"].ToString();
                else return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool SaveFpDataToDB(byte[] FpData)
        {
            List<string> sql = new List<string>();
            byte[] buff = new byte[1680];
            byte[] FpDataConv = new byte[1680];
            byte[] header = { 0x45, 0x4e, 0x52, 0x4f, 0x4c, 0x4c, 0x46, 0x50, 0x01, 0x28 };
            Array.Copy(header, 0, FpDataConv, 0, header.Length); //Add Fixed Header 
            Array.Copy(FpData, 0, FpDataConv, 80, FpData.Length);
            ObjFpReader.ConvEnrollData(FpDataConv, ref buff, 1680);

            //Update RS_Emp、VRS_EmpFingerInfo Table
            string EmpNo = txtEmpNo.Text;
            string EnrollNumber = txtFingerNo.Text;
            string BackupNumber = fpDataList.Count.ToString();
            int EmpFingerCount = fpDataList.Count + 1;

            try
            {
                sql.Add("UPDATE RS_Emp SET EmpFingerCount=" + EmpFingerCount.ToString() + " WHERE EmpNo='" + EmpNo + "'");
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "204", SystemInfo.MacTypeID.ToString(),
              EnrollNumber, fpDataList.Count.ToString(), "NULL"  }));
                if (SystemInfo.db.ExecSQL(sql) == 0)
                {
                    SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000300, new string[] { "202", SystemInfo.MacTypeID.ToString(),
                EnrollNumber, BackupNumber }), "FingerData", buff);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ClearFpDataToDB(string EmpNo, string FingerNo)
        {
            List<string> sql = new List<string>();

            //Update RS_Emp、VRS_EmpFingerInfo Table
            try
            {
                sql.Add("UPDATE RS_Emp SET EmpFingerCount=0" + " WHERE EmpNo='" + EmpNo + "'");
                sql.Add("DELETE FROM RS_EmpFingerInfo WHERE FingerNo=" + FingerNo + " AND FingerBkNo BETWEEN 0 AND 9");
                SystemInfo.db.ExecSQL(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnGetFpData_Click(object sender, EventArgs e)
        {
            GetDbFingerData(txtEmpNo.Text, txtFingerNo.Text);
        }

        private void btnClearFpData_Click(object sender, EventArgs e)
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgClearRequest", ""))) return;
            fpDataList.Clear();
            if (ClearFpDataToDB(txtEmpNo.Text, txtFingerNo.Text))
            {
                ObjFpReader.pisClearTptArray(contextId);
                txtInfo.Text = string.Format(Pub.GetResText(formCode, "MsgClearComplete", ""), txtEmpNo.Text);
            }
        }
        #endregion

        private void txtEmpNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GetDbFingerNo(txtEmpNo.Text))
                {
                    gbxFpReader.Enabled = true;
                    GetDbFingerData(txtEmpNo.Text, txtFingerNo.Text);
                    EnrollImport();
                }
                else
                {
                    gbxFpReader.Enabled = false;
                }
            }
        }

        private void Verify()
        {
            int vnRet;
            //控制设备灯
            int temp_DeviceCompany = deviceCompany;
            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);
            }
            else if (temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);

            }

            if (StopFlag) StopFlag = false;
            int isCheckFp = 0, fpArea = 0;
            bool doubleCheckFlag = true;
            ObjFpReader.CaptureFpStatus capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_Init;
            while (!StopFlag)
            {
                Application.DoEvents();
                memset(feature[0], 0x00, featureSize);
                memset(updatedTemplate, 0x00, templateSize);

                vnRet = ObjFpReader.pisCapture(contextId, imageBuffer);
                if (vnRet == ObjFpReader.PISFP_ERR_NOT_CONNECT_DEV)
                {
                    ErrorDescription(ObjFpReader.VERIFY_PROC, ObjFpReader.CAPTURE_FUNC, vnRet);

                    ObjFpReader.pisCloseDevice(contextId);

                    vnRet = ObjFpReader.pisOpenDevice(contextId, devIdList[cbbDevice.SelectedIndex]);
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
                else if (vnRet != ObjFpReader.PISFP_OK)
                {
                    ErrorDescription(ObjFpReader.VERIFY_PROC, ObjFpReader.CAPTURE_FUNC, vnRet);
                    ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);
                    return;
                }

                DrawFpImage();

                vnRet = ObjFpReader.pisCheckFp(contextId, imageBuffer, imageWidth, imageHeight, imageRes, ref isCheckFp, ref fpArea);
                txtInfo.Text = string.Empty;
                //初始化
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_Init)
                {
                    if (isCheckFp != 0)
                    {
                        txtInfo.Text = Pub.GetResText(formCode, "MsgLeaveFinger", "");
                        continue;
                    }
                    else
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger;
                    }
                }

                //等待手指按下时的操作
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger)
                {
                    if (isCheckFp == 0)
                    {
                        continue;
                    }

                    if (fpArea > 80)
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_GoodFpCaptured;
                    }
                }

                //处理获取到的图片
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_GoodFpCaptured)
                {
                    // 使用最大指纹图像提取指纹
                    if (ObjFpReader.pisProcess(contextId, imageBuffer, imageWidth, imageHeight, imageRes,
                        feature[0]) != ObjFpReader.PISFP_OK)
                    {
                        continue;
                    }

                    //检查fpdata是否已经存在
                    if (doubleCheckFlag == true)
                    {
                        int identifiedID = 0;
                        vnRet = ObjFpReader.pisIdentify(contextId, feature[0],
                                                         ref identifiedID, updatedTemplate, ref updatedFlag);

                        if (vnRet == ObjFpReader.PISFP_OK)
                            txtInfo.Text = string.Format("{0} - {1}", txtEmpNo.Text, identifiedID);
                        else {
                            if(isCheckFp != 0)
                                txtInfo.Text = Pub.GetResText(formCode, "MsgFPunregistered", "");
                        }
                        //txtInfo.Text = string.Empty;
                        if (isCheckFp == 0)
                            capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_Init;
                        continue;
                    }
                  
                }
               
            }

            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON || temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_OFF);
            }

            if (StopFlag == true)
            {
                txtInfo.Text = Pub.GetResText(formCode, "MsgStop", "");

                return;
            }
        }

        private bool EnrollImport()
        {
            int vnRet;
            vnRet = ObjFpReader.pisClearTptArray(contextId);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.CLEAR_TPT_ARRAY_FUNC, vnRet);
                ObjFpReader.pisDestroyContext(contextId);
                return false;
            }

            for (int i = 0; i < fpDataList.Count; i++)
            {
                int identifiedID = i + 1;
                vnRet = ObjFpReader.pisAddTptArray(contextId, identifiedID, fpDataList[i]);
                if (vnRet != ObjFpReader.PISFP_OK)
                {
                    ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.ADD_TPT_ARRAY_FUNC, vnRet);
                    ObjFpReader.pisDestroyContext(contextId);
                    return false;
                }
            }
            return true;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            gbxFpReader.Enabled = false;
            Verify();
            gbxFpReader.Enabled = true;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            Exit();
            if (Init())
            {
                OpenDev(0);
            }
            else
            {
                MessageBoxEx.Show(Pub.GetResText(formCode, "MsgNoDevice", ""));
                txtInfo.Text = Pub.GetResText(formCode, "MsgNoDevice", "");
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Exit();
        }


        private void cbbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = 0;

            Index = cbbDevice.SelectedIndex;
            if (InitFlag)
            {
                return;
            }
           Exit();
                OpenDev(Index);
        }

        private void OpenDev(int index)
        {
            string vDevId = string.Empty;
            int vnRet;
            if (!GetDevIdFromListIndex(index, ref vDevId))
            {
                MessageBoxEx.Show(Pub.GetResText(formCode, "MsgNoDevice", ""));
            }
            vnRet = ObjFpReader.pisCreateContext(ref contextId);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.CREATE_CONTEXT_FUNC, vnRet);
            }

            txtInfo.Text = Pub.GetResText(formCode, "MsgOpenDevice", "");

            vnRet = ObjFpReader.pisOpenDevice(contextId, vDevId);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ObjFpReader.pisDestroyContext(contextId);
                ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.OPEN_DEVICE_FUNC, vnRet);
                return;
            }

            vnRet = ObjFpReader.pisGetDeviceInfo(contextId, ObjFpReader.PISFP_PARAM_KIND_COMPANY, ref deviceCompany);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                deviceCompany = ObjFpReader.PRODUCT_PEFIS;
            }

            fpAreaTh = 18;
            noCheckCountTh = 20;
            int temp_DeviceCompany = deviceCompany;
            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON || temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);
                fpAreaTh = 17;
                noCheckCountTh = 20;
            }


            byte[] engineInfo = new byte[1024];
            vnRet = ObjFpReader.pisGetInfo(contextId, ref engineInfo[0], ref imageWidth, ref imageHeight, ref imageRes,
                        ref featureSize, ref templateSize);

            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON || temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_OFF);
            }

            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ObjFpReader.pisDestroyContext(contextId);
                ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.GET_INFO_FUNC, vnRet);
                return;
            }

            picFpImage.Width = imageWidth;
            picFpImage.Height = imageHeight;
            picFpImage.Image = null;

            imageBuffer = new byte[picFpImage.Width * picFpImage.Height];
            feature[0] = new byte[featureSize];
            feature[1] = new byte[featureSize];
            feature[2] = new byte[featureSize];
            template = new byte[templateSize];
            updatedTemplate = new byte[templateSize];
            rawImgBuffer = new byte[ObjFpReader.IMPORT_RAW_IMAGE_WIDTH * ObjFpReader.IMPORT_RAW_IMAGE_HEIGHT];

            memset(imageBuffer, 0x55, picFpImage.Width * picFpImage.Height);

            vnRet = ObjFpReader.pisSetMatchParameter(contextId, ObjFpReader.PISFP_DEFAULT_ROTATION_RANGE, ObjFpReader.PISFP_DEFAULT_THRESHOLD);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ObjFpReader.pisDestroyContext(contextId);
                ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.GET_INFO_FUNC, vnRet);
                return;
            }

            StopFlag = true;
            gbxFpReader.Enabled = true;

            GetDbFingerData(txtEmpNo.Text, txtFingerNo.Text);
            EnrollImport();
            txtInfo.Text = Pub.GetResText(formCode, "MsgInitSuccess", "");
            btnInit.Enabled = false;
        }
        private void Enroll()
        {
            //超过 10 枚指纹，不再注册
            if (fpDataList.Count > 9)
            {
                txtInfo.Text = Pub.GetResText(formCode, "MsgOverRegister", "");
                return;
            }

            int vnRet;
            int flag = 1;
            //控制设备灯
            int temp_DeviceCompany = deviceCompany;
            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);
            }
            else if (temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);
            }

            if (StopFlag) StopFlag = false;
            int isCheckFp = 0, fpArea = 0;
            int fpExtractCount = 0;
            int continuosFpPressCount = 0;
            bool doubleCheckFlag = true;
            ObjFpReader.CaptureFpStatus capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_Init;
            while (!StopFlag)
            {
                Application.DoEvents();
                vnRet = ObjFpReader.pisCapture(contextId, imageBuffer);
                if (vnRet == ObjFpReader.PISFP_ERR_NOT_CONNECT_DEV)
                {
                    ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.CAPTURE_FUNC, vnRet);

                    ObjFpReader.pisCloseDevice(contextId);

                    vnRet = ObjFpReader.pisOpenDevice(contextId, devIdList[cbbDevice.SelectedIndex]);
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
                else if (vnRet != ObjFpReader.PISFP_OK)
                {
                    ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.CAPTURE_FUNC, vnRet);
                    ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);
                    return;
                }

                DrawFpImage();

                vnRet = ObjFpReader.pisCheckFp(contextId, imageBuffer, imageWidth, imageHeight, imageRes, ref isCheckFp, ref fpArea);

                //初始化
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_Init)
                {
                    if (isCheckFp != 0)
                    {
                        txtInfo.Text = Pub.GetResText(formCode, "MsgLeaveFinger", ""); ;
                        continue;
                    }
                    else
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger;
                        continuosFpPressCount = 0;
                    }
                }

                //等待手指按下时的操作
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger)
                {
                    if (isCheckFp == 0)
                    {
                        promptPressFinger(fpExtractCount + 1);
                        if (continuosFpPressCount < 2)
                        {
                            continuosFpPressCount = 0;
                            continue;
                        }
                    }

                    continuosFpPressCount++;
                    if (fpArea > 80 && continuosFpPressCount > maxContinuosFpPressCount)
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_GoodFpCaptured;
                    }
                }

                //处理获取到的图片
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_GoodFpCaptured)
                {
                    // 使用最大指纹图像提取指纹
                    if (ObjFpReader.pisProcess(contextId, imageBuffer, imageWidth, imageHeight, imageRes,
                        feature[fpExtractCount]) != ObjFpReader.PISFP_OK)
                    {
                        ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.PROCESS_FUNC, vnRet);
                        //
                        return;
                    }


                    //检查指纹数据是否已经存在
                    if (doubleCheckFlag == true)
                    {
                        int identifiedID = 0;
                        vnRet = ObjFpReader.pisIdentify(contextId, feature[fpExtractCount],
                                                         ref identifiedID, updatedTemplate, ref updatedFlag);

                        if (vnRet == ObjFpReader.PISFP_OK)
                        {
                            txtInfo.Text = string.Format(Pub.GetResText(formCode, "MsgExist", ""), txtEmpNo.Text, identifiedID);
                            return;
                        }
                    }

                    fpExtractCount++;


                    continuosFpPressCount = 0;

                    if (flag >= 3)
                        flag = 1;
                    if (fpExtractCount == 3) break;
                    else
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_PromptTakeoffFinger;
                    }
                }

                //获取图片后手指的操作提示
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_PromptTakeoffFinger)
                {
                    //检测指纹是否合格

                    int sum = 0;
                    for (int i = 0; i < 57344; i++)
                    {
                        sum += int.Parse(imageBuffer[i].ToString());
                    }

                    if (isCheckFp != 0)
                    {
                        txtInfo.Text = Pub.GetResText(formCode, "MsgLeaveFinger", "");
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_Init;
                        continue;
                    }

                    // capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger;

                }
            }

            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON || temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_OFF);
            }

            if (StopFlag == true)
            {
                txtInfo.Text = Pub.GetResText(formCode, "MsgStop", "");

                return;
            }

            //生成模板
            vnRet = ObjFpReader.pisCreateTemplate(contextId, feature[0], feature[1], feature[2], template);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.CREATE_TEMPLATE_FUNC, vnRet);
                //txtInfo.Text = Pub.GetResText(formCode, "MsgCreateTemplate", "");
                return;
            }

            ////写出到文件
            //using (var fs = new FileStream(string.Format("{0}.dat", txtEmpNo.Text), FileMode.Create))
            //{
            //    fs.Write(template, 0, template.Length);
            //}

            //添加进识别
            vnRet = ObjFpReader.pisAddTptArray(contextId, fpDataList.Count + 1, template);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.ADD_TPT_ARRAY_FUNC, vnRet);
                return;
            }

            //保存到数据库
            if (SaveFpDataToDB(template))
                fpDataList.Add(template);

            txtInfo.Text = string.Format(Pub.GetResText(formCode, "MsgRegisterSuccess", ""), txtEmpNo.Text, fpDataList.Count);
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            gbxFpReader.Enabled = false;
            Enroll();
            gbxFpReader.Enabled = true;
        }

        private void promptPressFinger(int PressCount)
        {
            if (PressCount < 0) txtInfo.Text = Pub.GetResText(formCode, "MsgPressFinger", "");
            else txtInfo.Text = string.Format(Pub.GetResText(formCode, "MsgPressFinger", "") + " - {0}", PressCount);
            Application.DoEvents();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            StopFlag = true;
        }

        public void DrawFpImage()
        {
            Image img = ToGrayBitmap(imageBuffer, imageWidth, imageHeight);
            picFpImage.Image = img;
        }

        /// <summary>
        /// 将一个字节数组转换为8bit灰度位图
        /// </summary>
        /// <param name="rawValues">显示字节数组</param>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <returns>位图</returns>
        public static Bitmap ToGrayBitmap(byte[] rawValues, int width, int height)
        {
            //// 申请目标位图的变量，并将其内存区域锁定
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            //// 获取图像参数
            int stride = bmpData.Stride;  // 扫描线的宽度
            int offset = stride - width;  // 显示宽度与扫描线宽度的间隙
            IntPtr iptr = bmpData.Scan0;  // 获取bmpData的内存起始位置
            int scanBytes = stride * height;   // 用stride宽度，表示这是内存区域的大小

            //// 下面把原始的显示大小字节数组转换为内存中实际存放的字节数组
            int posScan = 0, posReal = 0;   // 分别设置两个位置指针，指向源数组和目标数组
            byte[] pixelValues = new byte[scanBytes];  //为目标数组分配内存
            for (int x = 0; x < height; x++)
            {
                //// 下面的循环节是模拟行扫描
                for (int y = 0; y < width; y++)
                {
                    pixelValues[posScan++] = rawValues[posReal++];
                }
                posScan += offset;  //行扫描结束，要将目标位置指针移过那段“间隙”
            }

            //// 用Marshal的Copy方法，将刚才得到的内存字节数组复制到BitmapData中
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpData);  // 解锁内存区域

            //// 下面的代码是为了修改生成位图的索引表，从伪彩修改为灰度
            ColorPalette tempPalette;
            using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                tempPalette = tempBmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                tempPalette.Entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = tempPalette;

            //// 算法到此结束，返回结果
            return bmp;
        }

        public static void memset(byte[] buf, byte val, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                buf[i] = val;
        }

        public bool GetDevIdFromListIndex(int index, ref string pDevId)
        {
            if ((index < 0) || (index >= cbbDevice.Items.Count)) return false;
            pDevId = devIdList[index].PadRight(36, '0');
            return true;
        }

        public void ErrorDescription(string ProcDesc, string FuncDesc, int ErrValue)
        {
            string errStr = string.Empty;
            switch (ErrValue)
            {
                case ObjFpReader.PISFP_ERR_INVALID_CONTEXT:
                    errStr = "ContextID is not valid.";
                    break;
                case ObjFpReader.PISFP_ERR_NOT_CONNECT_DEV:
                    errStr = "Device is not connect.";
                    break;
                case ObjFpReader.PISFP_ERR_FUNC_PARAMETER:
                    errStr = "Function's parameter is not valid.";
                    break;
                case ObjFpReader.PISFP_ERR_SYSTEM_MEMORY_ALLOC:
                    errStr = "System's memory can't alloc.";
                    break;
                case ObjFpReader.PISFP_ERR_TEMPLATE_ARRAY_OVER:
                    errStr = "TptArray is over.";
                    break;
                case ObjFpReader.PISFP_ERR_DEV_STOP:
                    errStr = "Device is stop.";
                    break;
                case ObjFpReader.PISFP_ERR_DEV_BUSY:
                    errStr = "Device is busy.";
                    break;
                case ObjFpReader.PISFP_ERR_CONTEXT_OVER:
                    errStr = "Context is over.";
                    break;
                default:
                    errStr = string.Format("Fail =  {0}", ErrValue);
                    break;
            }

            txtInfo.Text = string.Format("{0} Fail : ({1}:<{2}>)", ProcDesc, FuncDesc, errStr);
        }
    }
}

