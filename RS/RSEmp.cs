using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using grproLib;
using System.Reflection;
using DevComponents.DotNetBar;

namespace Taurus
{
    public partial class frmRSEmp : frmBaseMDIChildReportTree
    {
        private int DepartImportID = 1;
        private bool IsFilling = false;
         public List<string> devIdList = new List<string>();
        private uint contextId = 0;
        /// <summary>
        /// 会员信息
        /// </summary>
        private MemberInfo memberInfo { get; set; }
        private CardReader cardReader;
        protected override void InitForm()
        {
            formCode = "RSEmp";
            ReportFile = "RSEmp";
            ReportStartIndex = 2;
            SetToolItemState("ItemLine1", true);
            SetToolItemState("ItemLine2", true);
            SetToolItemState("ItemLine3", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", true);
            AddExtDropDownItem("ItemCardFill", CardFill_Click);
            IsInitBaseForm = true;
            base.InitForm();
            Application.DoEvents();
            FindSQL = Pub.GetSQL(DBCode.DB_000101, new string[] { "0", SystemInfo.FingerPrivilegeGeneralUser,
        SystemInfo.FingerPrivilegeManager });
            FindOrderBy = Pub.GetSQL(DBCode.DB_000101, new string[] { "1" });
            FindKeyWord = formCode;
            ImportShowDepart = true;
            ImportFieldList = new string[] { "EmpNo", "EmpName", "EmpSex", "DepartID", "DepartName", "EmpHireDate",
        "EmpCertNo", "FingerNo","EmpCardNo","EmpPWDNo" , "FingerPrivilege", "IsAttend"/*, "EmpGZ"*/, "RuleID", "EmpAddress", "EmpPhoneNo",
         "EmpMemo","StartDate","EndDate"};
            ExecTreeAfterSelect(tvEmp.SelectedNode);
            Pub.IDCardInit();
        }

        protected override void FreeForm()
        {
            Pub.IDCardFree();
            base.FreeForm();
        }
        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            new frmRSOprt(this.Text, CurrentTool, 0, null).ShowDialog();
            ExecItemRefresh();
        }

        protected override void ExecItemTAG2()
        {
            string GUID = "" ;
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiChecked)
                {
                    GUID += "'"+Report.FieldByName("EmpNo").AsString+"',";
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (GUID.Length == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            else
            {
                GUID = GUID.Substring(0,GUID.Length-1);
            }
            base.ExecItemTAG2();
            new frmRSOprt(this.Text, CurrentTool, 1, GUID).ShowDialog();
        }

        protected override void ExecItemTAG3()
        {
            string GUID = "";
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiChecked)
                {
                    GUID += "'" + Report.FieldByName("EmpNo").AsString + "',";
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (GUID.Length == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            else
            {
                GUID = GUID.Substring(0, GUID.Length - 1);
            }
            base.ExecItemTAG3();
            if(new frmRSConvertDepart(ItemTAG3.Text, GUID).ShowDialog()==DialogResult.OK)
            {
                ExecItemRefresh();
            }
        }

        public frmRSEmp()
        {
            InitializeComponent();
            cardReader = new CardReader(this);
            CardReader.CardRead += new CardReadEventHandler(cardReader_CardRead);
        }
        ~frmRSEmp()
        {
            CardReader.CardRead -= new CardReadEventHandler(cardReader_CardRead);
        }
        void cardReader_CardRead(string cardCode)
        {

            Control.CheckForIllegalCrossThreadCalls = false;
            RFIDReaderCard.num = cardCode;

        }
        private bool IsAddOk = false;
        private void ShowAdd()
        {
            frmRSEmpAdd frm = new frmRSEmpAdd(this.Text, CurrentTool, "",1);
            if (frm.ShowDialog() == DialogResult.OK) IsAddOk = true;
            if (frm.IsAddNext) ShowAdd();
        }

        protected override void ExecItemAdd()
        {
            IsAddOk = false;
            base.ExecItemAdd();
            ShowAdd();
            if (IsAddOk) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            string SysID = GetEmpNo();
            frmRSEmpAdd frm = new frmRSEmpAdd(this.Text, CurrentTool, SysID,2);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemImport()
        {
            
            DepartImportID = 1;
            base.ExecItemImport();
        }

        protected override void ExecItemFindText()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000101, new string[] { "2", FindSQL, FindOrderBy, ItemFindText.Text.Trim() });
            ExecItemRefresh();
        }

        public override bool ProcessImportData(DataRow row, List<string> sys, List<string> src, string DepartUpID,
          ref string ErrorMsg)
        {
            bool ret = base.ProcessImportData(row, sys, src, DepartUpID, ref ErrorMsg);
            string EmpNo = "";
            string EmpName = "";
            string EmpSex = "";
            string DepartID = "";
            string DepartName = "";
            string EmpHireDate = "";
            string EmpCertNo = "";
            string CardNo10 = "";
            string CardNo81 = "";
            string CardNo82 = "";
            string EmpPWDNo = "";
            string FingerNo = "";
            string FingerPrivilege = "";
            string IsAttend = "";
            string EmpGZ = "";
            string RuleID = "";
            string EmpAddress = "";
            string EmpPhoneNo = "";
            string EmpMemo = "";
            string StartDate = "";
            string EndDate = "";
            for (int i = 0; i < sys.Count; i++)
            {
                switch (sys[i])
                {
                    case "EmpNo":
                        EmpNo = row[src[i]].ToString();
                        break;
                    case "EmpName":
                        EmpName = row[src[i]].ToString();
                        break;
                    case "EmpSex":
                        EmpSex = row[src[i]].ToString();
                        break;
                    case "DepartID":
                        DepartID = row[src[i]].ToString();
                        break;
                    case "DepartName":
                        DepartName = row[src[i]].ToString();
                        break;
                    case "EmpHireDate":
                        EmpHireDate = row[src[i]].ToString();
                        break;
                    case "EmpCertNo":
                        EmpCertNo = row[src[i]].ToString();
                        break;
                    case "FingerNo":
                        FingerNo = row[src[i]].ToString();
                        break;
                    case "FingerPrivilege":
                        FingerPrivilege = row[src[i]].ToString();
                        break;
                    case "IsAttend":
                        IsAttend = row[src[i]].ToString();
                        break;
                    case "EmpGZ":
                        EmpGZ = row[src[i]].ToString();
                        break;
                    case "RuleID":
                        RuleID = row[src[i]].ToString();
                        break;
                    case "EmpAddress":
                        EmpAddress = row[src[i]].ToString();
                        break;
                    case "EmpPhoneNo":
                        EmpPhoneNo = row[src[i]].ToString();
                        break;
                    case "EmpCardNo":
                        CardNo10 = row[src[i]].ToString();
                        break;
                    case "EmpPWDNo":
                        EmpPWDNo = row[src[i]].ToString();
                        break;
                    case "EmpMemo":
                        EmpMemo = row[src[i]].ToString();
                        break;
                    case "StartDate":
                        StartDate = row[src[i]].ToString();
                        break;
                    case "EndDate":
                        EndDate = row[src[i]].ToString();
                        break;
                }
            }
            if (EmpNo == "")
            {
                ErrorMsg = Pub.GetResText(formCode, "Error101", "");
                return false;
            }
            if ((DepartID == "") && (DepartName == "")) DepartID = SystemInfo.CommanyID;
            if (EmpSex != SystemInfo.EmpSexMale && EmpSex != SystemInfo.EmpSexFemale) EmpSex = "";
            if (IsAttend != "0") IsAttend = "1";
            if (FingerPrivilege != "0" && FingerPrivilege != "1")
            {
                if (FingerPrivilege != SystemInfo.FingerPrivilegeManager)
                {
                    FingerPrivilege = SystemInfo.FingerPrivilegeGeneralUser;
                }
            }
            if (FingerPrivilege == SystemInfo.FingerPrivilegeManager)
                FingerPrivilege = "1";
            else
                FingerPrivilege = "0";
            if (IsAttend != "0") IsAttend = "1";
            if (!Pub.IsNumeric(EmpGZ)) EmpGZ = "0.00";
            StartDate = stringToTimeStr(StartDate);
            EndDate = stringToTimeStr(EndDate);

            StartDate = CheckTimeStr(StartDate);
            EndDate = CheckTimeStr(EndDate);
            if (SystemInfo.DBType == 0)
            {
                if (StartDate == null) StartDate = "NULL";
                else StartDate = "CDate('" + StartDate + "')";
                if (EndDate == null) EndDate = "NULL";
                else EndDate = "CDate('" + EndDate + "')";
            }
            else
            {
                if (StartDate == null) StartDate = "NULL";
                else StartDate = "'" + StartDate + "'";
                if (EndDate == null) EndDate = "NULL";
                else EndDate = "'" + EndDate + "'";
            }

            bool IsError = false;
            DataTableReader dr = null;
            string sql = "";
            try
            {
                if (DepartID == "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "3", DepartName }));
                    if (dr.Read())
                        DepartID = dr["DepartID"].ToString();
                    else
                    {
                        dr.Close();
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "4" }));
                        string s = "";
                        if (dr.Read()) s = dr[0].ToString();
                        dr.Close();
                        if (Pub.IsNumeric(s))
                        {
                            if (s == "0001")
                                s = "00010001";
                            else
                            {
                                DepartImportID = Convert.ToInt32(s) + 1;
                                s = DepartImportID.ToString("00000000");
                            }
                        }
                        else
                            s = DepartImportID.ToString("00000000");
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "1", s }));
                        while (dr.Read())
                        {
                            dr.Close();
                            DepartImportID = DepartImportID + 1;
                            s = DepartImportID.ToString("000000");
                            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "1", s }));
                        }
                        DepartID = s;
                        sql = Pub.GetSQL(DBCode.DB_000100, new string[] { "4", DepartID, DepartName, DepartUpID, "" });
                        SystemInfo.db.ExecSQL(sql);
                    }
                    dr.Close();
                }
                else if (DepartID != SystemInfo.CommanyID)
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "1", DepartID }));
                    bool HasDepart = false;
                    if (dr.Read()) HasDepart = true;
                    dr.Close();
                    if (!HasDepart)
                    {
                        if (DepartName != "")
                        {
                            sql = Pub.GetSQL(DBCode.DB_000100, new string[] { "4", DepartID, DepartName, DepartUpID, "" });
                            SystemInfo.db.ExecSQL(sql);
                        }
                        else
                        {
                            ErrorMsg = Pub.GetResText(formCode, "Error103", "");
                            return false;
                        }
                    }
                }
                if (DepartID == "")
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error103", "");
                    return false;
                }
                DateTime d = new DateTime();
                if (DateTime.TryParse(EmpHireDate, out d))
                {
                    if (SystemInfo.DBType == 0)
                        EmpHireDate = "CDate('" + d.ToString(SystemInfo.SQLDateFMT) + "')";
                    else
                        EmpHireDate = "'" + d.ToString(SystemInfo.SQLDateFMT) + "'";
                }
                else
                    EmpHireDate = Pub.GetSQL(DBCode.DB_000001, new string[] { "13" });
                if (CardNo10 != "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "14", CardNo10 }));
                    if (dr.Read()) CardNo10 = "";
                    dr.Close();
                }
                if (FingerNo == "" || !Pub.IsNumeric(FingerNo)) FingerNo = "";
                if (FingerNo != "")
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "10", FingerNo }));
                    if (dr.Read()) FingerNo = "";
                }
                if (FingerNo == "" || !Pub.IsNumeric(FingerNo))
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "11" }));
                    dr.Read();
                    FingerNo = dr[0].ToString();
                }
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "5", EmpNo }));
                if (!dr.Read())
                {
                    dr.Close();
                    sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "6", EmpNo, EmpName, EmpSex, DepartID, EmpHireDate,
            EmpCertNo, CardNo10, CardNo81, CardNo82, FingerNo, FingerPrivilege, IsAttend, RuleID, EmpAddress,
            EmpPhoneNo, EmpMemo, EmpGZ, EmpPWDNo,StartDate,EndDate});
                    SystemInfo.db.ExecSQL(sql);
                    string picPath = SystemInfo.AppPath + "EmpPic\\";
                    string picFileName = picPath + EmpNo + ".jpg";
                    if (!File.Exists(picFileName)) picFileName = picPath + EmpNo + ".bmp";
                    if (!File.Exists(picFileName)) picFileName = picPath + EmpNo + ".png";
                    if (!File.Exists(picFileName)) picFileName = picPath + EmpName + ".jpg";
                    if (!File.Exists(picFileName)) picFileName = picPath + EmpName + ".bmp";
                    if (!File.Exists(picFileName)) picFileName = picPath + EmpName + ".png";
                    if (File.Exists(picFileName))
                    {
                        string fileName = Pub.GetTempPathFileName(picFileName);
                         CustomSizeImageFile(picFileName, fileName);
                        byte[] buff = new byte[0];
                        MemoryStream ms = new MemoryStream();
                        using(Bitmap t = new Bitmap(fileName))
                        {
                            t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            t.Dispose(); 
                            buff = ms.ToArray();
                        }
                       
                        SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "7", EmpNo }),
                          "EmpPhotoImage", buff);

                        fileName = Pub.GetTempPathFileName(picFileName);
                        CustomSizePhotoFile(picFileName, fileName);
                        buff = new byte[0];
                        ms = new MemoryStream();
                        using(Bitmap ti = new Bitmap(fileName))
                        {
                            ti.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            ti.Dispose();
                            buff = ms.ToArray();
                        }

                        SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "24", EmpNo }),
                          "EmpPhoto", buff);
                        if (buff.Length > 0)
                            SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000101, new string[] { "35", EmpNo, "1" }));
                    }
                }
                else
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error104", "");
                    return false;
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return false;
            SystemInfo.db.WriteSYLog(this.Text, CurrentTool, sql);
            return ret;
        }

        private void CustomSizeImageFile(string picFileName, string fileName)
        {
            Bitmap bmp = CustomSizeImage(Image.FromFile(picFileName));
            bmp.Save(fileName);
            bmp.Dispose();
            bmp = null;
        }

        private void CustomSizePhotoFile(string picFileName, string fileName)
        {
            Bitmap bmp = CustomSizePhoto(Image.FromFile(picFileName));
            bmp.Save(fileName);
            bmp.Dispose();
            bmp = null;
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string EmpNo = GetEmpNo();
            if (SystemInfo.DBType == 0)
                 sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "8", EmpNo }));
            sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "9", EmpNo }));
            if(SystemInfo.DBType== 0)
            {
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "506", EmpNo }));
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "516", EmpNo }));
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "556", EmpNo }));
                sql.Add(Pub.GetSQL(DBCode.DB_000101, new string[] { "33", EmpNo }));
            }
           
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = Pub.GetResText(formCode, "EmpNo", "") + "=" + Report.FieldByName("EmpNo").AsString + "," +
              Pub.GetResText(formCode, "EmpName", "") + "=" + Report.FieldByName("EmpName").AsString;
            
            return ret;
        }

        private string GetEmpNo()
        {
            return Report.FieldByName("EmpNo").AsString;
        }

        protected override void ExecTreeAfterSelect()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_000101, new string[] { "209", FindSQL, FindOrderBy, nodeDepartID, nodeDepartList });
            base.ExecTreeAfterSelect();
        }

        protected override void ExecItemImportAfter()
        {
            SystemInfo.db.UpdateEmpInfoCount(this.Text);
            InitDepartTreeView(tvEmp, InitEmp, otherCoin);
            ExecTreeAfterSelect();
        }

        private bool CheckCardExists(string EmpNo, string CardNo)
        {
            bool ret = false;
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "16", EmpNo, CardNo }));
                if (dr.Read()) ret = true;
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
            return ret;
        }

        private bool SaveCardToDB(string FingerNo, string CardNo)
        {
            bool ret = false;
            bool IsExists;
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "203",
          SystemInfo.MacTypeID.ToString(), FingerNo, ((int)FKBackup.BACKUP_CARD).ToString() }));
                IsExists = dr.Read();
                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000101, new string[] { "210", CardNo, FingerNo }));
                if (SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { IsExists ? "205" : "204",
          SystemInfo.MacTypeID.ToString(), FingerNo, ((int)FKBackup.BACKUP_CARD).ToString(), "NULL" })) == 1)
                {
                    SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000300, new string[] { "202",
            SystemInfo.MacTypeID.ToString(), FingerNo, ((int)FKBackup.BACKUP_CARD).ToString() }),
                      "FingerData", EncAndDec.getCard(CardNo));
                    ret = true;
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
            return ret;
        }
       
       private void CardFill_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            bool IsFillOk = false;
            string msg = "";
            string EmpNo = "";
            string EmpName = "";
            string FingerNo = "";
            string CardNo = "";
            int CardCount = 0;
            int EmpNoCount = 0;
            int EmpSeCount = 0;
            RFIDReaderCard.num = "";
            GetFrCardNo(ref CardNo);
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {        
                CardCount = Report.FieldByName("EmpCardCount").AsInteger;
                if ((Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiChecked))
                {
                    if (CardCount != 0)
                    {
                        EmpSeCount = EmpSeCount + 1;
                    }
                }
                else
                {     
                    EmpNoCount = EmpNoCount + 1;
                }
                if (EmpNoCount == Report.DetailGrid.Recordset.RecordCount)
                {
                    MessageBoxEx.Show( Pub.GetResText(formCode, "ErrorSelectEmp", ""), Pub.GetResText(formCode, "ErrorMessage", ""));
                   
                    return;
                }
                if (EmpSeCount == Report.DetailGrid.Recordset.RecordCount)
                {
                    MessageBoxEx.Show(Pub.GetResText(formCode, "ErrorCardFill", ""), Pub.GetResText(formCode, "ErrorMessage", ""));
                
                    return;
                }
                Report.DetailGrid.Recordset.Next();
            }
            string tmp = Pub.GetResText(formCode, "ErrorCannotRepeated", "");
            tmp = string.Format(tmp, Pub.GetResText(formCode, "EmpCardNo", ""));

            IsFilling = true;
            RefreshForm(false);
            int pos = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();


            while (!Report.DetailGrid.Recordset.Eof())
            {
                EmpNo = Report.FieldByName("EmpNo").AsString;
                EmpName = Report.FieldByName("EmpName").AsString;
                FingerNo = Report.FieldByName("FingerNo").AsString;
                CardCount = Report.FieldByName("EmpCardCount").AsInteger;
                if ((CardCount == 0) && (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiChecked))
                {
                    msg = Pub.GetResText(formCode, "MsgFillInfo", "");
                    msg = string.Format(msg, EmpNo, EmpName) + "    ";
                    RefreshMsg(msg);
                LoopCard:
                    Application.DoEvents();
                    if (!IsFilling) goto LoopEnd;
                    CardNo = "";
                    if (!Pub.CheckCardExists())
                    {
                        CardNo = RFIDReaderCard.num;
                        RFIDReaderCard.num = "";

                        GetFrCardNo(ref CardNo);
                        if (CardNo != "")
                            goto RFIDCard;
                        else
                            lblMsg.Text = msg + Pub.GetResText(formCode, "MsgCardEmpty", "");
                        goto LoopCard;
                    }
                    if (!Pub.GetCardNo(ref CardNo))
                    {
                        lblMsg.Text = msg + Pub.GetResText(formCode, "MsgCardEmpty", "");
                        goto LoopCard;
                    }
                   
                RFIDCard:
                    if (CheckCardExists(EmpNo, CardNo))
                    {
                        lblMsg.Text = msg + " [" + CardNo + "]  " + tmp;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(500);
                        goto LoopCard;
                    }
                    
                    if (!SaveCardToDB(FingerNo, CardNo)) goto LoopEnd;
                    IsFillOk = true;
                    lblMsg.Text = msg + " [" + CardNo + "]  " + Pub.GetResText(formCode, "MsgCardSuccess", "");
                LoopNoCard:
                    Application.DoEvents();
                    if (Pub.CheckCardExists()) goto LoopNoCard;
                    else
                        System.Threading.Thread.Sleep(1000);
                  
                }
               
                Report.DetailGrid.Recordset.Next();
            }

            Report.DetailGrid.Recordset.MoveBy(pos);
        LoopEnd:
            
            IsFilling = false;
            RefreshForm(true);
            RefreshMsg("");
            if (IsFillOk)
            {
                SystemInfo.db.UpdateEmpInfoCount(this.Text);
                ExecItemRefresh();
            }
        }
          private void Exit()
        {
            ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);

            ObjFpReader.pisCloseDevice(contextId);
            ObjFpReader.pisDestroyContext(contextId);
        }

         private bool GetFrCardNo( ref string CardNo)
        { 
            int vnRet = 0;
            bool ret = false;
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
                    return ret; 
                }
                // vnRet = ObjFpReader.pisGetCardNumber(contextId, RECardNo );
                 //控制设备灯
                RECardNo = new byte[256];
                Application.DoEvents();
                vnRet = ObjFpReader.pisGetCardNumber(contextId, RECardNo );
                if (vnRet == ObjFpReader.PISFP_GET_CARD)
                {
                    System.Threading.Thread.Sleep(10);
                }
                if (vnRet == 0)
                { 
                     CardNo = Pub.GetWGCardNo(RECardNo);
                    ret = true;
                }
                
                 Exit();
            }
            return ret;
        }

        private void frmRSEmp_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (IsFilling)
            {
                IsFilling = false;
                e.Cancel = true;
            }
        }
        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemTAG1.Enabled = State;
        }
        public class RFIDReaderCard
        {
            public static string num = "";
        }

    }
}