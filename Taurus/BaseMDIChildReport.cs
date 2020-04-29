using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AxgrproLib;
using grproLib;
using DevComponents.DotNetBar;
using System.Threading;

namespace Taurus
{
    public partial class frmBaseMDIChildReport : frmBaseMDIChild
    {
        protected GridppReport Report = new GridppReport();
        protected string ReportFile = "";
        private bool IsFirst = true;
        protected int ReportStartIndex = 1;
        protected string FindSQL = "";
        protected string FindOrderBy = "";
        protected string FindKeyWord = "";
        protected bool FindShowTime = false;
        protected bool DesignReport = false;
        protected bool IgnoreTagExt = false;
        protected bool IgnoreRefreshFirst = false;
        protected bool IgnoreReportHead = false;
        protected bool IsActiveForm = false;
        protected bool ShowKQType = false;
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;
        protected bool IsDataTable = false;

        protected override void InitForm()
        {
            switch (SystemInfo.LangName)
            {
                case "CHS"://繁体中文
                    Report.Language = 0x804;
                    break;
                case "CHT"://繁体中文
                    Report.Language = 0x404;
                    break;
                case "JPN": //日语
                    Report.Language = 0x0411;
                    break;
                case "KOR": //朝鲜语
                    Report.Language = 0x0412;
                    break;
                case "DEU"://德语
                    Report.Language = 0x0407;
                    break;
                case "RUS": //俄语
                    Report.Language = 0x0419;
                    break;
                case "FRA"://法语
                    Report.Language = 0x040c;
                    break;
                case "ESN"://西班牙语
                    Report.Language = 0x040a;
                    break;
                case "ITA"://意大利语
                    Report.Language = 0x0410;
                    break;
                case "PTG"://葡萄牙语
                    Report.Language = 0x0816;
                    break;
                default://英语
                    Report.Language = 0x0409;
                    break;
            }
            ItemExport.Enabled = false;
            ItemPrint.Enabled = false;
            ItemTAGExt.Enabled = false;
            if (ReportFile != "") ReportFile = SystemInfo.ReportPath + ReportFile + ".grf";
            try
            {
                Report.Register(SystemInfo.ReportRegister);
                if ((ReportFile != "") && File.Exists(ReportFile)) Report.LoadFromFile(ReportFile);
                if (Report.DetailGrid != null)
                {
                    Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
                    Report.DetailGrid.Recordset.QuerySQL = "";
                    Report.BeforePostRecord += new _IGridppReportEvents_BeforePostRecordEventHandler(ReportBeforePostRecord);
                    Report.ExportBegin += new _IGridppReportEvents_ExportBeginEventHandler(ReportExportBegin);
                   
                }
                Report.FetchRecord -= new _IGridppReportEvents_FetchRecordEventHandler(ProductListFetchRecord);
                Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ProductListFetchRecord);
                Report.ShowProgressUI = false;
                ShowReportHeader(false);
                //指示查询显示控件分批获取数据
                dispView.BatchGetRecord = true;
                dispView.BatchWantRecords = 0;

                //指示查询显示控件显示出工具栏，并按分页方式显示数据
                dispView.ShowToolbar = true;
                dispView.RowsPerPage = 0;
                dispView.Report = Report;
                dispView.Start();
                //连接报表事件
               
                ItemTAGExt.Enabled = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (!IgnoreTagExt)
            {
                AddExtDropDownItem("ItemSetupDisplay", ItemSetupDisplay_Click);
                SetToolItemState("ItemTAGExt", true);
               // SetToolItemState("ItemLine3", true);
            }
            
            base.InitForm();
            Refresh_KQTypeShow();
            KeyPreview = true;
            
        }

        public DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)//PageIndex表示第几页，PageSize表示每页的记录数
        {
            if (PageIndex == 0)
                return dt;//0页代表每页数据，直接返回

            DataTable newdt = dt.Copy();
            newdt.Clear();//copy dt的框架
            try
            {
                int rowbegin = (PageIndex - 1) * PageSize;
                int rowend = PageIndex * PageSize;

                if (rowbegin >= dt.Rows.Count)
                    return newdt;//源数据记录数小于等于要显示的记录，直接返回dt

                if (rowend > dt.Rows.Count)
                    rowend = dt.Rows.Count;
                for (int i = rowbegin; i <= rowend - 1; i++)
                {
                    DataRow newdr = newdt.NewRow();
                    DataRow dr = dt.Rows[i];
                    foreach (DataColumn column in dt.Columns)
                    {
                        newdr[column.ColumnName] = dr[column.ColumnName];
                    }
                    newdt.Rows.Add(newdr);
                }
                return newdt;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, QuerySQL);
                return newdt;
            }
            finally
            {
                dt = null;

            }
           
        }
        private void ProductListFetchRecord()
        {
            if (IsDataTable)
            {
                IsDataTable = false;
                QuerySQL = "";
                return;
            }
            DataTable data = null;
            try
            {
                if (QuerySQL != "")
                {
                    dispView.Report.DetailGrid.Recordset.Empty();
                    Report.DetailGrid.Recordset.Empty();
                    data = SystemInfo.db.GetDataTable(QuerySQL);
                    FillRecordToReport(Report, data);
                    data.Clear();
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }
     
        public frmBaseMDIChildReport()
        {
            InitializeComponent();
        }

        protected override void ExecItemExport()
        {
            ShowReportHeader(true);
            ExportToXLS(Report, this.Text, SystemInfo.AppPath + this.Text + ".xls");
            ShowReportHeader(false);
        }

        protected override void ExecItemPrint()
        {
            ShowReportHeader(true);
            if (Report.ColumnByName("CheckBox") != null) Report.ColumnByName("CheckBox").Visible = false;
            frmPubPreview frm = new frmPubPreview(Report, this.Text);
            frm.ShowDialog();
            if (Report.ColumnByName("CheckBox") != null) Report.ColumnByName("CheckBox").Visible = true;
            ShowReportHeader(false);
        }

        protected override void ExecItemDelete()
        {
            base.ExecItemDelete();
            List<string> sql = new List<string>();
            List<string> sqlThread = new List<string>();
            string msg = "";
            string info = "";
            int count = 0;
            int maxWorkerThreads = 0;
            int workerThreads = 0;
            int portThreads = 0;
            progBar.ProgressType = eProgressItemType.Marquee;
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
           
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiChecked)
                {
                    count++;
                    info = GetDelMsg(0);
                    lblMsg.Text = Pub.GetResText(formCode, "ItemDelete", "")+" "+ info + "..." + count + "/" + count;
                    GetDelSql(0, ref sql);
                    msg = msg + info + ";";

                    if (sql.Count >= 2000)
                    {
                        GetDelSqlExt(ref sql);
                        sqlThread = new List<string>(sql);
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessFile), sqlThread);
                        sql.Clear();
                    }
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (sql.Count == 0 && sqlThread.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgNoSelectDelete", ""));
                {
                    return;
                }
            }
            
            while (true)
            {
                Thread.Sleep(1000);
                ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                if (maxWorkerThreads - workerThreads <= 1)
                {
                    break;
                }
                Application.DoEvents();
            }

            if (sql.Count > 0)
            {
                GetDelSqlExt(ref sql);
                if (SystemInfo.db.ExecSQL(sql) != 0)
                {
                    return;
                }
            }

            progBar.ProgressType = eProgressItemType.Standard;
            SystemInfo.db.WriteSYLog(this.Text, CurrentTool, msg);
          
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
            ExecItemRefresh();
        }

        private void ProcessFile(object state)
        {
            List<string> sql = (List<string>)state;

            if (SystemInfo.db.ThreadExecSQL(sql) != 0)
            {
                return;
            }
        }

        protected override void ExecItemRefresh()
        {
            DateTime StartTime = DateTime.Now;
            contextMenu.Close();
            int row = -1;
            RefreshMsg(StrReading);
            //Pub.ShowMessageForm(Pub.GetResText(formCode, "MsgReadingData", ""));
            if (QuerySQL != "" && dispView.Report != null)
            {
               // dispView.Report.DetailGrid.Recordset.QuerySQL = QuerySQL;
                try
                {
                    row = dispView.SelRowNo;
                    //dispView.Refresh();
                    dispView.Stop();
                    dispView.Start();
                    Application.DoEvents();
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E, QuerySQL);
                }
                finally
                {
                    if (row < dispView.RowCount)
                        dispView.SelRowNo = row;
                    else if (dispView.RowCount > 0)
                        dispView.SelRowNo = dispView.RowCount - 1;

                    //Pub.FreeMessageForm();
                }
            }
            string s = this.Text;
            if (s == "") s = Pub.GetResText("Main", "mnu" + formCode, "");
            SetReportTitle(dispView, s);
            RefreshForm(true);
            RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
        }

        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }

        // 将 DataReader 的数据转储到 Grid++Report 的数据集中
        public static void FillRecordToReport(IGridppReport Report, IDataReader dr)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dr.FieldCount)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dr.FieldCount; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.RunningDBField, dr.GetName(i), true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // Loop through the contents of the OleDbDataReader object.
            // 将 DataReader 中的每一条记录转储到Grid++Report 的数据集中去
            while (dr.Read())
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsDBNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr.GetValue(MatchFieldPairs[i].MatchColumnIndex);
                }

                Report.DetailGrid.Recordset.Post();
            }
        }
        /// <summary>
        /// 将 DataTable 的数据转储到 Grid++Report 的数据集中
        /// </summary>
        /// <param name="Report">报表对象</param>
        /// <param name="dt">DataTable对象</param>
        public void FillRecordToReport(IGridppReport report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];
            try
            {
                //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
                int MatchFieldCount = 0;
                for (int i = 0; i < dt.Columns.Count; ++i)
                {
                    foreach (IGRField fld in report.DetailGrid.Recordset.Fields)
                    {
                        if (string.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                        {
                            MatchFieldPairs[MatchFieldCount].grField = fld;
                            MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                            ++MatchFieldCount;
                            break;
                        }
                    
                    }
                }

                // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
                foreach (DataRow dr in dt.Rows)
                {
                    report.DetailGrid.Recordset.Append();
                    for (int i = 0; i < MatchFieldCount; ++i)
                    {
                        var columnIndex = MatchFieldPairs[i].MatchColumnIndex;
                        if (!dr.IsNull(columnIndex))
                        {
                            MatchFieldPairs[i].grField.Value = dr[columnIndex];
                        }
                    }
                    report.DetailGrid.Recordset.Post();
                  
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                MatchFieldPairs = null;
                dt = null;
                report = null;  
            }
        }
        protected override void SelectData(bool State)
        {
            if (dispView.RowCount == 0) return;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                Report.DetailGrid.Recordset.Edit();
                if (State)
                    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiChecked;
                else
                    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiUnchecked;
                Report.DetailGrid.Recordset.Post();
                Report.DetailGrid.Recordset.Next();
            }
            dispView.UpdateViewer();
        }

        protected override void RefreshForm(bool State)
        {
            int row = 0;
            int rows = 0;
            pnlDisp.Enabled = State;
            //ItemLine1.Visible = true;
            try
            {
                row = dispView.SelRowNo;
                rows = dispView.RowCount;
                if (rows > 0) row = row + 1;
            }
            catch
            {
            }
            finally
            {
            }
            if (row < 0) row = 0;
            ItemImport.Enabled = State;
            ItemExport.Enabled = State && (rows > 0);
            ItemPrint.Enabled = State && (rows > 0);
            ItemAdd.Enabled = State;
            ItemEdit.Enabled = State && (rows > 0);
            ItemDelete.Enabled = State && (rows > 0);
            ItemTAG1.Enabled = State && (rows > 0);
            ItemTAG2.Enabled = State && (rows > 0);
            ItemTAG3.Enabled = State && (rows > 0);
            ItemTAG4.Enabled = State && (rows > 0);
            ItemTAG5.Enabled = State && (rows > 0);
            ItemTAG6.Enabled = State && (rows > 0);
            ItemTAG7.Enabled = State && (rows > 0);
            ItemTAGExt.Enabled = State;
            for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
            {
                if (ItemTAGExt.DropDownItems[i].Name == "ItemSetupDisplay")
                    ItemTAGExt.DropDownItems[i].Enabled = State && (Report.DetailGrid != null);
                else
                    ItemTAGExt.DropDownItems[i].Enabled = State && (rows > 0);
            }
            ItemSelect.Enabled = State && (rows > 0);
            ItemUnselect.Enabled = State && (rows > 0);
            ItemRefresh.Enabled = State;
            SetContextMenuState();
            lblRecordState.Text = string.Format(StrPosition, row, rows);
        }

        private void dispView_ColumnLayoutChange(object sender, EventArgs e)
        {
            string sql;
            if ((ReportFile != "") && File.Exists(ReportFile))
            {
                if (Report.DetailGrid != null)
                {
                    sql = Report.DetailGrid.Recordset.QuerySQL;
                    dispView.PostColumnLayout();
                    Report.DetailGrid.Recordset.ConnectionString = "";
                    Report.DetailGrid.Recordset.QuerySQL = "";
                    Report.SaveToFile(ReportFile);
                    Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
                    Report.DetailGrid.Recordset.QuerySQL = sql;
                }
                else
                {
                    dispView.PostColumnLayout();
                    Report.SaveToFile(ReportFile);
                }
            }
        }

        private void dispView_ContentCellClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellClickEvent e)
        {
            if ((Report.ColumnByName("CheckBox") != null) && (Report.ColumnByName("CheckBox").Name == e.pSender.Column.Name))
            {
                Report.DetailGrid.Recordset.Edit();
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsiUnchecked)
                    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiChecked;
                else
                    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiUnchecked;
                Report.DetailGrid.Recordset.Post();
                dispView.UpdateSelCell();
            }
        }

        private void dispView_ContentCellDblClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEvent e)
        {
            if (ItemEdit.Enabled) ItemEdit.PerformClick();
        }

        private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
        {
            RefreshForm(true);
        }

        private void dispView_KeyDownEvent(object sender, _IGRDisplayViewerEvents_KeyDownEvent e)
        {
            if (e.key == 16 && !isSelectEnd)
            {
                selectNo = Report.DetailGrid.Recordset.RecordNo;
                isSelect = true;
                isSelectEnd = true;
            }
      
        }
        private void dispView_KeyUpEvent(object sender, _IGRDisplayViewerEvents_KeyUpEvent e)
        {
            isSelect = false;
            isSelectEnd = false;
        }

        private void dispView_MouseDownEvent(object sender, AxgrproLib._IGRDisplayViewerEvents_MouseDownEvent e)
        {
            if (e.button == GRMouseButton.grmbRight) contextMenu.Show(dispView, e.xPos, e.yPos);

            selectNoEnd = Report.DetailGrid.Recordset.RecordNo;

            try
            {
                if (Report.ColumnByName("CheckBox") == null) return;
                if (Report.ColumnByName("CheckBox").Visible)
                {
                    if (isSelect)
                    {
                        //isSelectEnd = true;
                        if (dispView.RowCount == 0) return;
                        Report.DetailGrid.Recordset.First();
                        int i = 0;
                        while (!Report.DetailGrid.Recordset.Eof())
                        {
                            Report.DetailGrid.Recordset.Edit();
                            if (selectNo < selectNoEnd)
                            {
                                if (i >= selectNo && i <= selectNoEnd)
                                    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiChecked;
                                //else
                                //    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiUnchecked;
                            }
                            else
                            {
                                if (i <= selectNo && i >= selectNoEnd)
                                    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiChecked;
                                //else
                                //    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiUnchecked;
                            }

                            Report.DetailGrid.Recordset.Post();
                            Report.DetailGrid.Recordset.Next();
                            i++;
                        }

                        dispView.UpdateViewer();

                    }
                }
            }
            catch(Exception E)
            {
                MessageBoxEx.Show(E.Message);
            }
           
        }

        private void Refresh_KQTypeShow()
        {
            IsActiveForm = true;
            try
            {
                dispView.Start();
            }
            catch
            {
            }
            if (IsFirst)
            {
                IsFirst = false;
                if (ShowKQType)
                {
                    KQTypeShow();
                    dispView.Refresh();
                    dispView_ColumnLayoutChange(null, null);
                }
                if (!IgnoreRefreshFirst) ExecItemRefresh();
            }
        }

        private void ItemSetupDisplay_Click(object sender, EventArgs e)
        {
            frmPubDisplay frm = new frmPubDisplay(Report, this.Text + "[" + ((ToolStripItem)sender).Text + "]",
              ReportStartIndex);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dispView.Refresh();
                dispView_ColumnLayoutChange(null, null);
            }
        }

        private void ReportBeforePostRecord()
        {
            if (Report.DetailGrid != null)
            {
                if ((Report.FieldByName("Checked") != null) && Report.FieldByName("Checked").IsNull)
                {
                    Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsiUnchecked;
                }
                if (Report.FieldByName("IsSignIn") != null)
                {
                    if (Report.FieldByName("IsSignIn").IsNull)
                        Report.FieldByName("IsSignIn").AsInteger = (int)GRSystemImage.grsiUnchecked;
                    else if (Report.FieldByName("IsSignIn").AsBoolean)
                        Report.FieldByName("IsSignIn").AsInteger = (int)GRSystemImage.grsiChecked;
                    else
                        Report.FieldByName("IsSignIn").AsInteger = (int)GRSystemImage.grsiUnchecked;
                }
                if (Report.FieldByName("IsAttend") != null)
                {
                    if (Report.FieldByName("IsAttend").IsNull)
                        Report.FieldByName("IsAttend").AsInteger = (int)GRSystemImage.grsiUnchecked;
                    else if (Report.FieldByName("IsAttend").AsBoolean)
                        Report.FieldByName("IsAttend").AsInteger = (int)GRSystemImage.grsiChecked;
                    else
                        Report.FieldByName("IsAttend").AsInteger = (int)GRSystemImage.grsiUnchecked;
                }
            }
        }

        private void ReportExportBegin(IGRExportOption Sender)
        {
            switch (Sender.ExportType)
            {
                case GRExportType.gretXLS:
                    Sender.AsE2XLSOption.MailExportFile = false;
                    Sender.AsE2XLSOption.ExportPageBreak = false;
                    Sender.AsE2XLSOption.ColumnAsDetailGrid = false;
                    Sender.AsE2XLSOption.SameAsPrint = false;
                    Sender.AsE2XLSOption.ExportPageHeaderFooter = false;
                    Sender.AsE2XLSOption.OnlyExportPureText = false;
                    Sender.AsE2XLSOption.ExpandRowHeight = false;
                    Sender.AsE2XLSOption.OnlyExportDetailGrid = true;
                    Sender.AsE2XLSOption.SupressEmptyLines = false;
                    Sender.AsE2XLSOption.ExpandRowHeight = false;
                    break;
                case GRExportType.gretTXT:
                    Sender.AsE2TXTOption.MailExportFile = false;
                    Sender.AsE2TXTOption.OnlyExportDetailGrid = true;
                    break;
                case GRExportType.gretHTM:
                    Sender.AsE2HTMOption.OnlyExportDetailGrid = true;
                    break;
                case GRExportType.gretRTF:
                    Sender.AsE2RTFOption.ExportPageBreak = false;
                    Sender.AsE2RTFOption.SameAsPrint = false;
                    Sender.AsE2RTFOption.ExportPageHeaderFooter = false;
                    Sender.AsE2RTFOption.OnlyExportDetailGrid = true;
                    break;
                case GRExportType.gretPDF:
                    break;
                case GRExportType.gretCSV:
                    Sender.AsE2CSVOption.OnlyExportDetailGrid = true;
                    break;
                case GRExportType.gretIMG:
                    Sender.AsE2IMGOption.ImageType = GRExportImageType.greitJPEG;
                    break;
            }
        }

        private void ShowReportHeader(bool state)
        {
            if (IgnoreReportHead) return;
            for (int j = 1; j <= Report.ReportHeaderCount; j++)
            {
                Report.get_ReportHeader(j).Visible = state;
            }
        }

        protected void LoadReport()
        {
            if (IsActiveForm) return;
            ItemExport.Enabled = false;
            ItemPrint.Enabled = false;
            ItemTAGExt.Enabled = false;
            if (ReportFile != "") ReportFile = SystemInfo.ReportPath + ReportFile + ".grf";
            try
            {
                dispView.Stop();
            }
            catch
            {
            }
            try
            {
                if ((ReportFile != "") && File.Exists(ReportFile)) Report.LoadFromFile(ReportFile);
                if (Report.DetailGrid != null)
                {
                    Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
                    Report.DetailGrid.Recordset.QuerySQL = "";
                    //Report.BeforePostRecord += new _IGridppReportEvents_BeforePostRecordEventHandler(ReportBeforePostRecord);
                    //Report.ExportBegin += new _IGridppReportEvents_ExportBeginEventHandler(ReportExportBegin);
                    //Report.BeforePostRecord += new _IGridppReportEvents_BeforePostRecordEventHandler(ReportBeforePostRecord);
                }
                Report.ShowProgressUI = false;
                ShowReportHeader(false);
                //指示查询显示控件分批获取数据
                dispView.BatchGetRecord = true;
                dispView.BatchWantRecords = 0;

                //指示查询显示控件显示出工具栏，并按分页方式显示数据
                dispView.ShowToolbar = true;
                dispView.RowsPerPage = 0;
                IsDataTable = true;
                dispView.Start();
                ItemTAGExt.Enabled = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            SetContextMenuState();
        }

        protected void SetReportColumnVisible(string colName, bool visible)
        {
            if (Report.ColumnByName(colName) != null) Report.ColumnByName(colName).Visible = visible;
        }

        protected virtual void KQTypeShow()
        {
            DataTable dt = null;
            try
            {
                dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000201, new string[] { "8" }));
                string colName;
                int colIdx;
                IGRColumn col;
                bool validCol;
                string SortName;
                for (int i = 1; i <= 10; i++)
                {
                    colName = "Hrs" + i.ToString("00");
                    col = Report.DetailGrid.Columns[colName];
                    validCol = i - 1 < dt.Rows.Count;
                    SortName = "";
                    if (validCol) SortName = dt.Rows[i - 1]["SortName"].ToString();
                    if (col != null)
                    {
                        col.Visible = validCol;
                        if (validCol) col.TitleCell.Text = SortName;
                    }
                    if (Report.DetailGrid.Groups.Count > 0)
                    {
                        colIdx = Report.DetailGrid.Groups[1].Footer.Controls.IndexByName(colName);
                        if (colIdx > 0)
                        {
                            Report.DetailGrid.Groups[1].Footer.Controls[colIdx].Visible = validCol;
                            if (validCol) Report.DetailGrid.Groups[1].Footer.Controls[colIdx].AsStaticBox.Text = SortName;
                        }
                        colIdx = Report.DetailGrid.Groups[1].Footer.Controls.IndexByName(colName + "F");
                        if (colIdx > 0) Report.DetailGrid.Groups[1].Footer.Controls[colIdx].Visible = validCol;

                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Clear();
                    dt.Reset();
                }
            }
        }

        protected virtual void ExecKeyDown(KeyEventArgs e)
        {
            if (!ItemExport.Enabled) return;
            if (e.Control && e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.D0:
                        ShowReportHeader(true);
                        ExportToTXT(Report, this.Text, SystemInfo.AppPath + this.Text + ".txt");
                        ShowReportHeader(false);
                        break;
                    case Keys.D1:
                        ShowReportHeader(true);
                        ExportToHTM(Report, this.Text, SystemInfo.AppPath + this.Text + ".html");
                        ShowReportHeader(false);
                        break;
                    case Keys.D2:
                        ShowReportHeader(true);
                        ExportToRTF(Report, this.Text, SystemInfo.AppPath + this.Text + ".rtf");
                        ShowReportHeader(false);
                        break;
                    case Keys.D3:
                        ShowReportHeader(true);
                        ExportToPDF(Report, this.Text, SystemInfo.AppPath + this.Text + ".pdf");
                        ShowReportHeader(false);
                        break;
                    case Keys.D4:
                        ShowReportHeader(true);
                        ExportToCSV(Report, this.Text, SystemInfo.AppPath + this.Text + ".csv");
                        ShowReportHeader(false);
                        break;
                    case Keys.D5:
                        ShowReportHeader(true);
                        ExportToIMG(Report, this.Text, SystemInfo.AppPath + this.Text);
                        ShowReportHeader(false);
                        break;
                }
            }
        }

        private void frmBaseMDIChildReport_KeyDown(object sender, KeyEventArgs e)
        {
            ExecKeyDown(e);
        }
    }
}