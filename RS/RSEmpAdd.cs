using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AForge.Video.DirectShow;
using System.Windows;
using Size = System.Drawing.Size;
using System.Windows.Media.Imaging;

namespace Taurus
{
    public partial class frmRSEmpAdd : frmBaseDialog
    {
        public bool IsAddNext = false;
        private bool IsAdd = false;
        private string FingerNoOld = "";
        public List<string> devIdList = new List<string>();
        private static bool StopFlag = true;
        private uint contextId = 0;
        private string FilePathName = "";
        private string GUID = "";
        private bool IsEnabled = false;
        private FilterInfoCollection videoDevices;

        protected override void InitForm()
        {
            formCode = "RSEmpAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            SetTextboxNumber(txtFingerNo);
            SetTextboxNumber(txtPWDNo);
            SetTextboxNumber(txtCardNo);
            tabItemDynPhoto.Visible = SystemInfo.AllowMJ;
            IsAdd = SysID == "";
            cbbEmpSex.Items.Clear();
            cbbEmpSex.Items.Add(SystemInfo.EmpSexMale);
            cbbEmpSex.Items.Add(SystemInfo.EmpSexFemale);
            cbbFingerPrivilege.Items.Clear();
            cbbFingerPrivilege.Items.Add(SystemInfo.FingerPrivilegeGeneralUser);
            cbbFingerPrivilege.Items.Add(SystemInfo.FingerPrivilegeManager);
            txtEmpGZ.Text = SystemInfo.CurrencySymbol + "0.00";
            LoadData();
            label1.ForeColor = Color.Red;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Red;
            label15.ForeColor = Color.Red;
            chkIsAdd.Enabled = IsEnabled;
            chkIsAdd.Visible = chkIsAdd.Enabled;
            btnSelectEmpHireDate.Text = btnSelectDepart.Text;
            txtEmpGZ.Enter += TextBoxCurrency_Enter;
            txtEmpGZ.Leave += TextBoxCurrency_Leave;
            btnReadCard.Text = btnSelectDepart.Text;
            btnIDCard.Enabled = SystemInfo.ini.ReadIni("Public", "IDCardUse", false);
            btnIDCard.Visible = btnIDCard.Enabled;
            cbbRemoteReg.Items.AddRange(new object[] { 
                new RegType(0,Pub.GetResText("","VK_FP","")),
                new RegType(12,Pub.GetResText("","VK_FACE","")),
                new RegType(13,Pub.GetResText("","VK_PALMVEIN","")),
                });
            cbbRemoteReg.SelectedIndex = 0;
            KeyPreview = true;
        }

        public frmRSEmpAdd(string title, string CurrentTool, string GUID,int flag)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            if(flag==3)
            {
                this.GUID = GUID;
                IsEnabled = false;
            }
            else
            {
                SysID = GUID;
                IsEnabled = SysID=="";
            }
            
            InitializeComponent();
        }

        private void LoadData()
        {
            TIDAndName idn = new TIDAndName("", "");
            cbbRule.Items.Clear();
            cbbRule.Items.Add(idn);
            label13.Text = "";
            label14.Text = "";
            btnPhotograph.Enabled = false;
            btnCloseDev.Enabled = false;
            Image image = null;
            DataTableReader dr = null;
            try
            {
                if(GUID != "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "11", GUID }));
                    if (dr.Read())
                    {
                        if (!string.IsNullOrEmpty(dr["Photo"].ToString()))
                        {
                            byte[] buff = (byte[])(dr["Photo"]);
                            if (buff.Length > 0)
                            {
                                MemoryStream ms = new MemoryStream(buff);
                                image = Image.FromStream(ms);
                                picPhoto.BackgroundImage = image;
                                picDynPhoto.BackgroundImage = image;
                                ms.Close();
                                label14.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Width, image.Height);
                                label13.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Width, image.Height);
                            } 
                        }
                    }
                    if(picDynPhoto.BackgroundImage==null)
                    {
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "14", GUID }));
                        if (dr.Read())
                        {
                            if (!string.IsNullOrEmpty(dr["Photo"].ToString()))
                            {
                                byte[] buff = (byte[])(dr["Photo"]);
                                if (buff.Length > 0)
                                {
                                    MemoryStream ms = new MemoryStream(buff);
                                    image = Image.FromStream(ms);
                                    picPhoto.BackgroundImage = image;
                                    picDynPhoto.BackgroundImage = image;
                                    ms.Close();
                                    label14.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Width, image.Height);
                                    label13.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Width, image.Height);
                                }
                            }
                        }
                    }
                }
              
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000200, new string[] { "0" }));
                while (dr.Read())
                {
                    idn = new TIDAndName(dr["RuleID"].ToString(), "[" + dr["RuleID"].ToString() + "]" +
                      dr["RuleName"].ToString());
                    cbbRule.Items.Add(idn);
                }
                dr.Close();
                if (SysID == "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "22" }));
                    if (dr.Read())
                    {
                        string tmp = dr[0].ToString().Trim();
                        if (tmp == "") tmp = "E0000";
                        string s = tmp;
                        while (!Pub.IsNumeric(s))
                        {
                            s = s.Substring(1);
                            if (s == "") break;
                        }
                        if (s == "")
                        {
                            txtEmpNo.Text = "E0001";
                        }
                        else
                        {
                            int l = tmp.Length;
                            tmp = tmp.Substring(0, l - s.Length);
                            if (s.Substring(0, 1) == "-")
                            {
                                tmp += "-";
                                l += 1;
                                s = s.Substring(1);
                            }
                            UInt64 n = Convert.ToUInt64(s) + 1;
                            s = n.ToString();
                            while (s.Length < l - tmp.Length)
                            {
                                s = "0" + s;
                            }
                            txtEmpNo.Text = tmp + s;
                        }
                    }
                    dr.Close();
                    txtEmpHireDate.Text = DateTime.Now.Date.ToShortDateString();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "11" }));
                    if (dr.Read()) txtFingerNo.Text = dr[0].ToString();
                    txtDepartName.Text = SystemInfo.CommanyName;
                    txtDepartName.Tag = SystemInfo.CommanyID;
                    cbbEmpSex.SelectedIndex = 0;
                    cbbFingerPrivilege.SelectedIndex = 0;
                    cbbRule.SelectedIndex = 0;
                }
                else
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "12", SysID }));
                    if (dr.Read())
                    {
                        txtEmpNo.Text = dr["EmpNo"].ToString();
                        txtEmpName.Text = dr["EmpName"].ToString();
                        cbbEmpSex.Text = dr["EmpSex"].ToString();
                        DateTime d = new DateTime();
                        if (DateTime.TryParse(dr["EmpHireDate"].ToString(), out d))
                        {
                            txtEmpHireDate.Text = d.ToShortDateString();
                        }
                        txtDepartName.Text = dr["DepartName"].ToString();
                        txtDepartName.Tag = dr["DepartID"].ToString();
                        txtCardNo.Text = dr["CardNo10"].ToString();
                        txtPWDNo.Text = dr["pwd"].ToString();
                        txtEmpCertNo.Text = dr["EmpCertNo"].ToString();
                        FingerNoOld = dr["FingerNo"].ToString();
                        txtFingerNo.Text = FingerNoOld;
                        double m = 0;
                        double.TryParse(dr["EmpGZ"].ToString(), out m);
                        txtEmpGZ.Text = m.ToString(SystemInfo.CurrencySymbol + "0.00");
                        int index = 0;
                        int.TryParse(dr["FingerPrivilege"].ToString(), out index);
                        if (index > 2) index = 0;//管理员
                        cbbFingerPrivilege.SelectedIndex = index;
                        chkIsAttend.Checked = Pub.ValueToBool(dr["IsAttend"].ToString());
                        cbbRule.SelectedIndex = 0;
                        for (int i = 1; i < cbbRule.Items.Count; i++)
                        {
                            if (((TIDAndName)cbbRule.Items[i]).id == dr["EmpRuleID"].ToString())
                            {
                                cbbRule.SelectedIndex = i;
                                break;
                            }
                        }
                        txtEmpAddress.Text = dr["EmpAddress"].ToString();
                        txtEmpPhoneNo.Text = dr["EmpPhoneNo"].ToString();
                        txtEmpMemo.Text = dr["EmpMemo"].ToString();
                        if(dr["StartDate"].ToString()!="")
                        {
                            txtStartDate.Text = Convert.ToDateTime(dr["StartDate"].ToString()).ToString(Pub.GetResText("", "YMWFormatForm", ""));
                        }
                        else
                        {
                            txtStartDate.Text = "";
                        }
                        
                        if(dr["EndDate"].ToString()!="")
                        {
                            txtEndDate.Text = Convert.ToDateTime(dr["EndDate"].ToString()).ToString(Pub.GetResText("", "YMWFormatForm", ""));
                        }
                        else
                        {
                            txtEndDate.Text = "";
                        }
                        
                        dr.Close();
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "13", SysID }));
                        if (dr.Read())
                        {
                            if (!string.IsNullOrEmpty( dr["EmpPhotoImage"].ToString()))
                            {
                                byte[] buff = (byte[])(dr["EmpPhotoImage"]);
                                if (buff.Length > 0)
                                {
                                    MemoryStream ms = new MemoryStream(buff);
                                    image = Image.FromStream(ms);
                                    picPhoto.BackgroundImage = image;
                                    ms.Close();
                                    label14.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Height, image.Width);
                                }
                            }
                            if (!string.IsNullOrEmpty(dr["EmpPhoto"].ToString()))
                            {
                                byte[] buff = (byte[])(dr["EmpPhoto"]);
                                if (buff.Length > 0)
                                {
                                    MemoryStream ms = new MemoryStream(buff);
                                    image = Image.FromStream(ms);
                                    picDynPhoto.BackgroundImage = image;
                                    ms.Close();
                                    label13.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Height, image.Width);
                                }
                            } 
                        }
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

        private void btnSelectEmpHireDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtEmpHireDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtEmpHireDate.Text = d.ToShortDateString();
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepartName.Text = frm.DepartName;
                txtDepartName.Tag = frm.DepartID;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image image = null;
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            FilePathName = dlgOpen.FileName;
            image =  CustomSizeImage(Image.FromFile(dlgOpen.FileName));
            picPhoto.BackgroundImage = image;
            label14.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Height, image.Width);
            image = CustomSizePhoto(Image.FromFile(dlgOpen.FileName));
            picDynPhoto.BackgroundImage = image;
            label13.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Height, image.Width);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            picPhoto.BackgroundImage = null;
            picDynPhoto.BackgroundImage = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string EmpNo = txtEmpNo.Text.Trim();
            string EmpName = txtEmpName.Text.Trim();
            string EmpSex = cbbEmpSex.Text;
            string DepartID = "";
            if (txtDepartName.Tag != null) DepartID = txtDepartName.Tag.ToString();
            string EmpHireDate = txtEmpHireDate.Text.Trim();
            string EmpCertNo = txtEmpCertNo.Text.Trim();
            string FingerNo = txtFingerNo.Text.Trim();
            string FingerPrivilege = cbbFingerPrivilege.SelectedIndex.ToString();
            string IsAttend = Convert.ToByte(chkIsAttend.Checked).ToString();
            string RuleID = "";
            if (cbbRule.SelectedIndex > 0) RuleID = ((TIDAndName)cbbRule.Items[cbbRule.SelectedIndex]).id;
            string EmpAddress = txtEmpAddress.Text.Trim();
            string EmpPhoneNo = txtEmpPhoneNo.Text.Trim();
            string EmpMemo = txtEmpMemo.Text.Trim();
            string EmpGZ = CurrencyToStringEx(txtEmpGZ.Text.Trim());
            string EmpCard = txtCardNo.Text.Trim();
            string EmpPWD = txtPWDNo.Text.Trim();
            string StartDate = txtStartDate.Text.Trim();
            string EndDate = txtEndDate.Text.Trim();

            if(!string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("BaseDate", "ErrorEnterCorrect", ""), label11.Text));
                return;
            }
            if (string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("BaseDate", "ErrorEnterCorrect", ""), label10.Text));
                return;
            }
            DateTime StartDT;
            DateTime endDT;
            DateTime.TryParse(StartDate, out StartDT);
            DateTime.TryParse(EndDate, out endDT);

            if (StartDT > endDT)
            {
                Pub.MessageBoxShow(Pub.GetResText("BaseDate", "Error001", ""));
                return;
            }
            

            if (SystemInfo.DBType == 0)
            {
                if (StartDate == "") StartDate = "NULL";
                else StartDate = "CDate('" + StartDT.ToString(SystemInfo.SQLDateFMT) + "')";
                if (EndDate == "") EndDate = "NULL";
                else EndDate = "CDate('" + endDT.ToString(SystemInfo.SQLDateFMT) + "')";
            }
            else
            {
                if (StartDate == "") StartDate = "NULL";
                else StartDate = "'" + StartDT.ToString(SystemInfo.SQLDateFMT) + "'";
                if (EndDate == "") EndDate = "NULL";
                else EndDate = "'" + endDT.ToString(SystemInfo.SQLDateFMT) + "'";
            }
           
            if (EmpNo == "")
            {
                txtEmpNo.Focus();
                ShowErrorEnterCorrect(label1.Text);
                return;
            }
            if (!Pub.CheckTextMaxLength(label1.Text, EmpNo, txtEmpNo.MaxLength))
            {
                txtEmpNo.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label2.Text, EmpName, txtEmpName.MaxLength))
            {
                txtEmpName.Focus();
                return;
            }
            if (!Pub.IsNumeric(EmpGZ))
            {
                txtEmpGZ.Focus();
                ShowErrorEnterCorrect(lblEmpGZ.Text);
                return;
            }
            DateTime d = new DateTime();
            if ((EmpHireDate == "") || (!DateTime.TryParse(EmpHireDate, out d)))
            {
                txtEmpHireDate.Focus();
                ShowErrorEnterCorrect(label5.Text);
                return;
            }
            EmpHireDate = d.ToString(SystemInfo.SQLDateFMT);
            if (DepartID == "")
            {
                txtDepartName.Focus();
                ShowErrorSelectCorrect(label4.Text);
                return;
            }
            if (!Pub.CheckTextMaxLength(label16.Text, EmpCertNo, txtEmpCertNo.MaxLength))
            {
                txtEmpCertNo.Focus();
                return;
            }
            if (FingerNo == "")
            {
                txtFingerNo.Focus();
                ShowErrorEnterCorrect(label15.Text);
                return;
            }
            if ((FingerNo != "") && (!Pub.IsNumeric(FingerNo)))
            {
                txtFingerNo.Focus();
                ShowErrorEnterCorrect(label15.Text);
                return;
            }
            if (!Pub.CheckTextMaxLength(label15.Text, FingerNo, txtFingerNo.MaxLength))
            {
                txtFingerNo.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label17.Text, EmpPhoneNo, txtEmpPhoneNo.MaxLength))
            {
                txtEmpPhoneNo.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label7.Text, EmpAddress, txtEmpAddress.MaxLength))
            {
                txtEmpAddress.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label8.Text, EmpMemo, txtEmpMemo.MaxLength))
            {
                txtEmpMemo.Focus();
                return;
            }
            
            DataTableReader dr = null;
            bool IsOk = true;
            List<string> sql = new List<string>();
            try
            {
                if (IsAdd)
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "5", EmpNo }));
                    if (dr.Read())
                    {
                        txtEmpNo.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                        IsOk = false;
                    }
                    dr.Close();
                    if (IsOk)
                    {
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "10", FingerNo }));
                        if (dr.Read())
                        {
                            txtFingerNo.Focus();
                            ShowErrorCannotRepeated(label15.Text);
                            IsOk = false;
                        }
                        dr.Close();
                    }
                    if (IsOk && EmpCard != "")
                    {
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "14", EmpCard }));
                        if (dr.Read())
                        {
                            txtCardNo.Focus();
                            ShowErrorCannotRepeated(lblCardNo.Text);
                            IsOk = false;
                        }
                        dr.Close();
                    }
                    if (IsOk)
                    {
                        if (SystemInfo.DBType == 0)
                            EmpHireDate = "CDate('" + EmpHireDate + "')";
                        else
                            EmpHireDate = "'" + EmpHireDate + "'";
                        sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "6", EmpNo, EmpName, EmpSex, DepartID,
              EmpHireDate, EmpCertNo, EmpCard, "", "", FingerNo, FingerPrivilege, IsAttend,
              RuleID, EmpAddress, EmpPhoneNo, EmpMemo, EmpGZ, EmpPWD,StartDate,EndDate }));
                    }
                }
                else
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "15", SysID, EmpNo }));
                    if (dr.Read())
                    {
                        txtEmpNo.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                        IsOk = false;
                    }
                    dr.Close();
                    if (IsOk)
                    {
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "17", SysID, FingerNo }));
                        if (dr.Read())
                        {
                            txtFingerNo.Focus();
                            ShowErrorCannotRepeated(label15.Text);
                            IsOk = false;
                        }
                        dr.Close();
                    }
                    if (IsOk && EmpCard != "")
                    {
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "16", SysID, EmpCard }));
                        if (dr.Read())
                        {
                            txtCardNo.Focus();
                            ShowErrorCannotRepeated(lblCardNo.Text);
                            IsOk = false;
                        }
                        dr.Close();
                    }
                    if (IsOk)
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "18", EmpNo, EmpName, EmpSex, DepartID,
              EmpHireDate, EmpCertNo, EmpCard, "", "", FingerNo, FingerPrivilege, IsAttend, RuleID, EmpAddress,
              EmpPhoneNo, EmpMemo, EmpGZ, EmpPWD,StartDate,EndDate, SysID }));
                        if (SystemInfo.DBType == 0)
                        {
                            if (EmpNo != SysID)
                            {
                                sql.Add("UPDATE KQ_EmpDayOff SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_EmpOtSure SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_EmpShift SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_KQData SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_KQDataFilter SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_KQDataFilterMark SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_KQReportDay SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_KQReportMonth SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                               
                                sql.Add("UPDATE KQ_ReportRecords SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE DI_Power SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE GZ_GZReport SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE MJ_TemporaryData SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_MJData SET FingerNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE KQ_KQReportWeek SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE DI_SeaPower SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");
                                sql.Add("UPDATE DI_StarPower SET EmpNo='" + EmpNo + "' WHERE EmpNo='" + SysID + "'");

                            }
                            if (FingerNo != FingerNoOld)
                            {
                                sql.Add("UPDATE RS_EmpFingerInfo SET FingerNo=" + FingerNo + " WHERE FingerNo=" + FingerNoOld);
                            }
                        }
                    }
                }
                if (SystemInfo.db.ExecSQL(sql) != 0) IsOk = false;
                
                if (IsOk)
                {
                    byte[] buff = new byte[0];
                    byte[] PhotoBuff = new byte[0];
                    if (picPhoto.BackgroundImage != null)
                    {
                        //picPhoto.BackgroundImage = CustomSizeImage(picPhoto.BackgroundImage);
                        MemoryStream ms = new MemoryStream();
                        using(Bitmap t = new Bitmap(picPhoto.BackgroundImage))
                        {
                            t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            buff = ms.ToArray();
                        } 
                    }
                    if (picDynPhoto.BackgroundImage != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        using(Bitmap t = new Bitmap(picDynPhoto.BackgroundImage))
                        {
                            t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            PhotoBuff = ms.ToArray();
                        }
                        
                    }

                    SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "7", EmpNo }),
                      "EmpPhotoImage", buff);
                    SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "24", EmpNo }),
                     "EmpPhoto", PhotoBuff);
                    if(PhotoBuff.Length>0)
                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000101, new string[] { "35", EmpNo, "1"}));
                    else
                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000101, new string[] { "35", EmpNo, "0" }));
                }
            }
            catch (Exception E)
            {
                IsOk = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsOk)
            {
                if(GUID != "")
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                }
                SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
                SystemInfo.db.UpdateOneEmpInfoCount(FingerNo);
                //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                if(e!=null)
                {
                    IsAddNext = chkIsAdd.Checked;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
              
            }
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            string CardNo = "";
            if (Pub.GetCardNo(ref CardNo)) txtCardNo.Text = CardNo;
        }

        private void btnIDCard_Click(object sender, EventArgs e)
        {
            string EmpName = "";
            byte EmpSexNum = 0;
            string EmpAddress = "";
            string EmpIDCard = "";
            string EmpPhotoPath = "";
            if (!Pub.IDCardGet(ref EmpName, ref EmpSexNum, ref EmpIDCard, ref EmpAddress, ref EmpPhotoPath)) return;
            txtEmpName.Text = EmpName;
            if (EmpSexNum == 2)
                cbbEmpSex.SelectedIndex = 1;
            else
                cbbEmpSex.SelectedIndex = 0;
            txtEmpCertNo.Text = EmpIDCard;
            txtEmpAddress.Text = EmpAddress;
            if (EmpPhotoPath != "" && File.Exists(EmpPhotoPath))
            {
                Image img = Image.FromFile(EmpPhotoPath);
                picPhoto.BackgroundImage = CustomSizeImage(img);
                try
                {
                    img.Dispose();
                    File.Delete(EmpPhotoPath);
                }
                catch(Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
            }
        }

        private void btnFpReader_Click(object sender, EventArgs e)
        {
            frmFpReader fp = new frmFpReader(txtEmpNo.Text, txtFingerNo.Text);
            fp.ShowDialog();
        }

        private void Exit()
        {
            try
            {
                StopFlag = true;
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);

                ObjFpReader.pisCloseDevice(contextId);
                ObjFpReader.pisDestroyContext(contextId);
            }catch
            {

            }
           
        }

        private void txtCardNo_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtCardNo.Focused)
            { 
                if (StopFlag) StopFlag = false;
                GetFrCardNo();
            }
           
        }

        private void GetFrCardNo()
        { 
            int vnRet = 0;
            string CardNo = "";
            byte[] RECardNo = new byte[256];
            for (int i = 0; i < ObjFpReader.PISFP_MAX_DEVICE_COUNTS; i++)
            {
                byte[] vstrDeviceDescription = new byte[1024];
                byte[] vstrDevId = new byte[1024];
                if (ObjFpReader.pisEnumerateDevice(i, vstrDevId, vstrDeviceDescription) == ObjFpReader.PISFP_OK)
                {
                    devIdList.Add(Encoding.Default.GetString(vstrDevId, 0, vstrDevId.Length));
                }
            }
           
            if (devIdList.Count > 0)
            { 
                 Exit();
                 vnRet = ObjFpReader.pisCreateContext(ref contextId); 
                 vnRet = ObjFpReader.pisOpenDevice(contextId, devIdList[0]);
                if (vnRet != 0)
                { 
                    Exit();
                    return; 
                }
                 vnRet = ObjFpReader.pisGetCardNumber(contextId, RECardNo );
                 //控制设备灯
                if (StopFlag) StopFlag = false;
                while (!StopFlag)
                {
                    if (!txtCardNo.Focused) break;
                    if (StopFlag)break;
                    RECardNo = new byte[256];
                    Application.DoEvents();
                    
                    vnRet = ObjFpReader.pisGetCardNumber(contextId, RECardNo );
                    if (vnRet == ObjFpReader.PISFP_GET_CARD)
                    {
                        System.Threading.Thread.Sleep(10);
                        continue;
                    }
                    if (vnRet == 0)
                    { 
                         CardNo = Pub.GetWGCardNo(RECardNo);

                         txtCardNo.Text = CardNo;
                        
                    }  
                }
                 Exit();
            }  
        }
        private void frmRSEmpAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopFlag = true;
            Exit();
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            e.Cancel = false;
        }

        private void frmRSEmpAdd_MouseEnter(object sender, EventArgs e)
        {
             if (txtCardNo.Focused)
            {
                if (StopFlag) StopFlag = false;
                GetFrCardNo();
            }
            else if (!txtCardNo.Focused)
            {
                StopFlag = true;    
            }
        }

        private void frmRSEmpAdd_MouseLeave(object sender, EventArgs e)
        {
             if (txtCardNo.Focused)
            {
                if (StopFlag) StopFlag = false;
                GetFrCardNo();
            }
            else if (!txtCardNo.Focused)
            {
                StopFlag = true;    
            }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                cbbCameras.Items.Clear();
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    cbbCameras.Items.Add(device.Name);
                }

                cbbCameras.SelectedIndex = 0;
            }
            catch
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error01", ""));
                videoDevices = null;
            }
        }

        //连接摄像头
        private void CameraConn()
        {
            try
            {
                VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[cbbCameras.SelectedIndex].MonikerString);

                videoSourcePlayer.VideoSource = videoSource;
                videoSourcePlayer.Start();
                videoSourcePlayer.Visible = true;
                btnPhotograph.Enabled = true;
                btnCloseDev.Enabled = true;
            }
            catch
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error02", ""));
                videoDevices = null;
                btnPhotograph.Enabled = false;
                btnCloseDev.Enabled = false;
            }

        }

        private void btnCloseDev_Click(object sender, EventArgs e)
        {
            videoSourcePlayer.Visible = false;
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            btnPhotograph.Enabled = false;
            btnCloseDev.Enabled = false;
        }

        private void btnPhotograph_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoSourcePlayer.IsRunning)
                {
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                    videoSourcePlayer.GetCurrentVideoFrame().GetHbitmap(),
                                    IntPtr.Zero,
                                     Int32Rect.Empty,
                                    BitmapSizeOptions.FromWidthAndHeight(480,640));
                    PngBitmapEncoder pE = new PngBitmapEncoder();
                    pE.Frames.Add(BitmapFrame.Create(bitmapSource));
                    Image image = null;
                    Image imageDyn = null;
                    using (Stream stream = new MemoryStream())
                    {
                        pE.Save(stream);
                        image = CustomSizeImage(Bitmap.FromStream(stream, true));
                        picPhoto.BackgroundImage = image;
                        label14.Text = string.Format(Pub.GetResText(formCode, "label14", ""), image.Width, image.Height);
                        imageDyn = CustomSizePhoto(Bitmap.FromStream(stream, true));
                        picDynPhoto.BackgroundImage = imageDyn;
                        label13.Text = string.Format(Pub.GetResText(formCode, "label14", ""), imageDyn.Width, imageDyn.Height);
                    }
                    //拍照完成后关摄像头并刷新同时关窗体
                    if (videoSourcePlayer != null && videoSourcePlayer.IsRunning)
                    {
                        videoSourcePlayer.SignalToStop();
                        videoSourcePlayer.WaitForStop();
                    }
                    videoSourcePlayer.Visible = false;
                    btnPhotograph.Enabled = false;
                    btnCloseDev.Enabled = false; 
                }
            }
            catch (Exception ex)
            {
                Pub.ShowErrorMsg(ex, Pub.GetResText(formCode, "Error02", ""));
                videoDevices = null;
                btnPhotograph.Enabled = true;
                btnCloseDev.Enabled = true;
            }
        
        }
        private string GetImagePath()
        {
            string personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + Path.DirectorySeparatorChar.ToString() + "PersonImg";
            if (!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }

        private void cbbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedTabIndex = 0;
            videoSourcePlayer.Visible = false;
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            CameraConn();
        }

        private void btnRemoteReg_Click(object sender, EventArgs e)
        {
            btnOk_Click(null,null);

            string FingerNo = txtFingerNo.Text.Trim();
            string EmpNo = txtEmpNo.Text.Trim();
            SysID = EmpNo;
            IsAdd = false;
            FingerNoOld = FingerNo;
            if (FingerNo == "")
            {
                txtFingerNo.Focus();
                ShowErrorEnterCorrect(label15.Text);
                return;
            }
            if ((FingerNo != "") && (!Pub.IsNumeric(FingerNo)))
            {
                txtFingerNo.Focus();
                ShowErrorEnterCorrect(label15.Text);
                return;
            }
            if (!Pub.CheckTextMaxLength(label15.Text, FingerNo, txtFingerNo.MaxLength))
            {
                txtFingerNo.Focus();
                return;
            }
            if (cbbRemoteReg.Text == "")
            {
                cbbRemoteReg.Focus();
                ShowErrorEnterCorrect(btnRemoteReg.Text);
                return;
            }
            
            string BackupNumber = ((RegType)cbbRemoteReg.SelectedItem).BackupNumber.ToString();
            string Privilege = cbbFingerPrivilege.SelectedIndex.ToString();
            frmRSOprt frm = new frmRSOprt(btnRemoteReg.Text, btnRemoteReg.Text, 10, FingerNo+"@"+ BackupNumber + "@" + Privilege + "@'" + EmpNo+"'");
            frm.ShowDialog();
        }

        private void txtDepartName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    class RegType
    {
        private int _BackupNumber;
        private string _BackupType;

        public RegType(int backupNumber, string backupType)
        {
            BackupNumber = backupNumber;
            BackupType = backupType;  
        }

        public string BackupType
        {
            get { return _BackupType; }
            set { _BackupType = value; }
        }

        public int BackupNumber
        {
            get { return _BackupNumber; }
            set { _BackupNumber = value; }
        }

        public override string ToString()
        {
            return BackupType;
        }
    }
}