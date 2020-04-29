using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmPubDataIn : frmBaseDialog
    {

        private bool IsShowDepart = false;
        private string[] ImpFieldList;
        private int state = 0;
        private string RecordCountString = "";
        private string RecordIndexString = "";
        private string RecordFactString = "";
        private DataTable dtIn = null;
        private bool IsInitImportField = true;
        private string TableName = "";
        private ProcessImportData prcImportData = null;
        private bool IsImporting = false;
        private Database db = new Database("");

        public delegate bool ProcessImportData(DataRow row, List<string> sys, List<string> src, string DepartUpID,
          ref string ErrorMsg);

        protected override void InitForm()
        {
            formCode = "PubDataIn";
            base.InitForm();
            this.Text = this.Text + "[" + Title + "]";
            RecordCountString = label7.Text;
            RecordIndexString = label8.Text;
            RecordFactString = label9.Text;
            label6.ForeColor = Color.Blue;
            btnSelectDepart.Text = "...";
            RefreshForm();
            lblPic.Visible = IsShowDepart;
        }

        public frmPubDataIn(string title, bool ShowDepart, string[] ImportFieldList, ProcessImportData ImportData)
        {
            Title = title;
            IsShowDepart = ShowDepart;
            ImpFieldList = ImportFieldList;
            prcImportData = ImportData;
            InitializeComponent();
        }

        private void frmPubDataIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Close();
            if (dtIn != null) dtIn.Reset();
        }

        private void frmPubDataIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsImporting)
            {
                IsImporting = false;
                e.Cancel = true;
            }
        }

        private void btnFileName_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            cbbTable.Items.Clear();
            txtFileName.Text = dlgOpen.FileName;
            string ext = Pub.GetFileNameExt(dlgOpen.FileName).ToLower();
            string ConnStr = "Provider={0};Data Source=\"" + txtFileName.Text + "\";Extended properties='Excel {1};HDR=YES'";
            if (ext == "xlsx")
                ConnStr = string.Format(ConnStr, "Microsoft.Ace.OleDb.12.0", "12.0 Xml");
            else
                ConnStr = string.Format(ConnStr, "Microsoft.Jet.OLEDB.4.0", "8.0");
            try
            {
                db.Close();
                db.Open(255, ConnStr);
                DataTable dt = db.GetDataTableList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbbTable.Items.Add(dt.Rows[i]["TABLE_NAME"].ToString());
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (cbbTable.Items.Count > 0) cbbTable.SelectedIndex = 0;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            state = state - 1;
            if ((state == 0) && (dtIn != null)) dtIn.Reset();
            RefreshForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            #region 无用
            //string EmpNo = Pub.GetResText(formCode, "EmpNo", "");
            //string EmpName = Pub.GetResText(formCode, "EmpName", "");
            //string EmpSex = Pub.GetResText(formCode, "EmpSex", "");
            //string DepartID = Pub.GetResText(formCode, "DepartID", "");
            //string DepartName = Pub.GetResText(formCode, "DepartName", "");
            //string EmpHireDate = Pub.GetResText(formCode, "EmpHireDate", "");
            //string EmpCertNo = Pub.GetResText(formCode, "EmpCertNo", "");
            //string CardNo10 = Pub.GetResText(formCode, "EmpCardNo", "");
            //string EmpPWDNo = Pub.GetResText(formCode, "EmpPWDNo", "");
            //string FingerNo = Pub.GetResText(formCode, "FingerNo", "");
            //string FingerPrivilege = Pub.GetResText(formCode, "FingerPrivilege", "");
            //string IsAttend = Pub.GetResText(formCode, "IsAttend", "");

            //string RuleID = Pub.GetResText(formCode, "RuleID", "");
            //string EmpAddress = Pub.GetResText(formCode, "EmpAddress", "");
            //string EmpPhoneNo = Pub.GetResText(formCode, "EmpPhoneNo", "");
            //string EmpMemo = Pub.GetResText(formCode, "EmpMemo", "");
            #endregion
            bool IsErr = false;
            string[] ImpNameList = new string[0];
            if (state == 0)
            {
                if (txtFileName.Text == "")
                {
                    txtFileName.Focus();
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }
                if (cbbTable.Text == "")
                {
                    cbbTable.Focus();
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""));
                    return;
                }
                TableName = cbbTable.Text;
                try
                {
                    dtIn = db.GetDataTable("SELECT * FROM [" + TableName + "]");
                }
                catch (Exception E)
                {
                    IsErr = true;
                    Pub.ShowErrorMsg(E);
                }
            }
            if (IsErr) return;
            state = state + 1;
            RefreshForm();
            string na = "";
            int index = 0;
            if (state == 1)
            {
                dataGrid.Columns.Clear();
                for (int i = 0; i < dtIn.Columns.Count; i++)
                {
                    na = dtIn.Columns[i].ColumnName;
                    AddColumn(dataGrid, 0, na, false, false, 0, 0);
                    if(na==Pub.GetResText("", "ColumnValid", ""))
                    {
                        index = i;
                        na = Pub.GetResText("", "StartDate", "");
                        dtIn.Columns[i].ColumnName = na;
                    }
                    if(index != 0 && i == index + 1)
                    {
                        na = Pub.GetResText("", "EndDate", "");
                        dtIn.Columns[i].ColumnName = na;
                        index = 0;
                    }
                    dataGrid.Columns[dataGrid.ColumnCount - 1].HeaderText = na;
                }
                dataGrid.DataSource = dtIn;
                dataGrid.Refresh();
            }
            else if (state == 2)
            {
                ImpNameList = new string[ImpFieldList.Length];
                #region 无用
                //ImpFieldList = new string[dtIn.Columns.Count];
                //for (int i = 0; i < dtIn.Columns.Count; i++)
                //{
                //    na = dtIn.Columns[i].ColumnName;
                //    if (EmpNo.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpNo";
                //    }
                //    else if (EmpName.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpName";
                //    }
                //    else if (EmpSex.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpSex";
                //    }
                //    else if (DepartID.Contains(na))
                //    {
                //        ImpFieldList[i] = "DepartID";
                //    }
                //    else if (DepartName.Contains(na))
                //    {
                //        ImpFieldList[i] = "DepartName";
                //    }
                //    else if (EmpHireDate.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpHireDate";
                //    }
                //    else if (EmpCertNo.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpCertNo";
                //    }
                //    else if (CardNo10.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpCardNo";
                //    }
                //    else if (EmpPWDNo.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpPWDNo";
                //    }
                //    else if (FingerNo.Contains(na))
                //    {
                //        ImpFieldList[i] = "FingerNo";
                //    }
                //    else if (FingerPrivilege.Contains(na))
                //    {
                //        ImpFieldList[i] = "FingerPrivilege";
                //    }
                //    else if (IsAttend.Contains(na))
                //    {
                //        ImpFieldList[i] = "IsAttend";
                //    }
                //    else if (RuleID.Contains(na))
                //    {
                //        ImpFieldList[i] = "RuleID";
                //    }
                //    else if (EmpAddress.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpAddress";
                //    }
                //    else if (EmpPhoneNo.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpPhoneNo";
                //    }
                //    else if (EmpMemo.Contains(na))
                //    {
                //        ImpFieldList[i] = "EmpMemo";
                //    }
                //    else
                //    {
                //        ImpFieldList[i] = "";
                //    }
                //}
                #endregion
                IsInitImportField = true;
                impGrid.Rows.Clear();
                if (ImpFieldList != null)
                {
                    for (int i = 0; i < ImpFieldList.Length; i++)
                    {
                        if (ImpFieldList[i] == "")
                            continue;
                        impGrid.Rows.Add();
                        impGrid[1, i].Value = Pub.GetResText(formCode, ImpFieldList[i], "");
                        impGrid[2, i].Value = ImpFieldList[i];
                        ImpNameList[i] = Pub.GetResText(formCode, ImpFieldList[i], "");
                        impGrid[3, i].Value = "";
                    }
                }
                DataGridViewComboBoxColumn colCombo = (DataGridViewComboBoxColumn)impGrid.Columns[3];

                colCombo.Items.Clear();
                colCombo.Items.Add("");
                for (int i = 0; i < dtIn.Columns.Count; i++)
                {
                    na = dtIn.Columns[i].ColumnName;
                    colCombo.Items.Add(na);

                    if (i < impGrid.RowCount)
                    {
                        for (int j = 0; j < ImpNameList.Length; j++)
                        {
                            if (ImpNameList[j] == na)
                            {
                                for (int x = 0; x < ImpFieldList.Length; x++)
                                {
                                    if (Pub.GetResText(formCode, ImpFieldList[x], "") == na)
                                    {
                                        impGrid[3, x].Value = na;
                                        break;
                                    }

                                }
                                break;
                            }
                        }

                    }
                }
                colCombo.ReadOnly = false;
                IsInitImportField = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<string> sysField = new List<string>();
            List<string> srcField = new List<string>();
            for (int i = 0; i < impGrid.RowCount; i++)
            {
                if ((impGrid[0, i].Value != null) && Pub.ValueToBool(impGrid[0, i].Value))
                {
                    sysField.Add(impGrid[2, i].Value.ToString());
                    if (impGrid[3, i].Value.ToString() == ""|| impGrid[3, i].Value == null)
                    {
                        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
                        return;
                    }
                    srcField.Add(impGrid[3, i].Value.ToString());
                }
            }
            if (sysField.Count == 0)
            {
                impGrid.Focus();
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
                return;
            }
            IsImporting = true;
            DateTime StartTime = DateTime.Now;
            RefreshForm();
            string DepartUpID = "";
            if (txtDepart.Tag != null) DepartUpID = txtDepart.Tag.ToString();
            if (DepartUpID == "") DepartUpID = SystemInfo.CommanyID;
            int RecordCount = dtIn.Rows.Count;
            int RecordFact = 0;
            string FileName = SystemInfo.AppPath + "FormDataIn\\" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            string Msg = string.Format(Pub.GetResText(formCode, "Msg001", ""), Title);
            progBar.Value = 0;
            label7.Text = RecordCountString + RecordCount.ToString();
            label8.Text = RecordIndexString + "0";
            label9.Text = RecordFactString + RecordFact.ToString();
            Pub.WriteTextFile(FileName, Msg);
            string ErrorMsg = "";
            string NoStr = Pub.GetResText(formCode, "Msg003", "");
            Application.DoEvents();
            for (int i = 0; i < dtIn.Rows.Count; i++)
            {
                if (!IsImporting) break;
                if (prcImportData(dtIn.Rows[i], sysField, srcField, DepartUpID, ref ErrorMsg)) RecordFact = RecordFact + 1;
                progBar.Value = (i + 1) * 100 / RecordCount;
                label7.Text = RecordCountString + RecordCount.ToString();
                label8.Text = RecordIndexString + (i + 1).ToString();
                label9.Text = RecordFactString + RecordFact.ToString();
                if (ErrorMsg != "")
                {
                    Msg = string.Format(NoStr, i + 1) + ErrorMsg;
                    Pub.WriteTextFile(FileName, Msg);
                }
                Application.DoEvents();
            }
            IsImporting = false;
            RefreshForm();
            Msg = string.Format(Pub.GetResText(formCode, "Msg002", ""), Title, label7.Text, label8.Text, label9.Text);
            string ss = Pub.GetDateDiffTimes(StartTime, DateTime.Now);
            Pub.WriteTextFile(FileName, Msg + "    " + ss);
            Pub.MessageBoxShow(Msg + "\r\n\r\n" + ss, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void impGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 3) && (impGrid.RowCount > 0) && !IsInitImportField)
            {
                impGrid[0, e.RowIndex].Value = true;
            }
        }

        private void RefreshForm()
        {
            tabControl1.Tabs.Clear();
            switch (state)
            {
                case 0:
                    tabControl1.Tabs.Add(tabPage1);
                    break;
                case 1:
                    tabControl1.Tabs.Add(tabPage2);
                    break;
                case 2:
                    tabControl1.Tabs.Add(tabPage3);
                    break;
            }
            txtDepart.Enabled = (state == 2) && IsShowDepart;
            txtDepart.Visible = txtDepart.Enabled;
            btnSelectDepart.Enabled = txtDepart.Enabled;
            btnSelectDepart.Visible = txtDepart.Enabled;
            label10.Visible = txtDepart.Enabled;
            btnPrev.Enabled = state != 0;
            btnNext.Enabled = state != 2;
            btnOk.Enabled = state == 2;
            btnOk.Visible = btnOk.Enabled;
            impGrid.Enabled = (state == 2) && !IsImporting;
            label10.Enabled = label10.Enabled && !IsImporting;
            txtDepart.Enabled = txtDepart.Enabled && !IsImporting;
            btnSelectDepart.Enabled = btnSelectDepart.Enabled && !IsImporting;
            btnPrev.Enabled = btnPrev.Enabled && !IsImporting;
            btnOk.Enabled = btnOk.Enabled && !IsImporting;
            btnCancel.Enabled = btnCancel.Enabled && !IsImporting;
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK) txtDepart.Tag = frm.DepartID;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < impGrid.RowCount; i++)
            {
                impGrid[0, i].Value = checkBox1.Checked;
            }
        }
    }
}