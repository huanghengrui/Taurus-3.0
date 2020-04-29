using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmBaseSelectEmp : frmBaseDialog
    {
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;
        public enum enumErrorCode
        {
            RUN_SUCCESS = 1,
            RUNERR_NOSUPPORT = 0,
            RUNERR_UNKNOWNERROR = -1,
            RUNERR_NO_OPEN_COMM = -2,
            RUNERR_WRITE_FAIL = -3,
            RUNERR_READ_FAIL = -4,
            RUNERR_INVALID_PARAM = -5,
            RUNERR_NON_CARRYOUT = -6,
            RUNERR_DATAARRAY_END = -7,
            RUNERR_DATAARRAY_NONE = -8,
            RUNERR_MEMORY = -9,
            RUNERR_MIS_PASSWORD = -10,
            RUNERR_MEMORYOVER = -11,
            RUNERR_DATADOUBLE = -12,
            RUNERR_MANAGEROVER = -14,
            RUNERR_FPDATAVERSION = -15,
        };

        private string oprt = "";
        public List<UInt32> selList;
        public List<string> selStringList = new List<string>();
        private List<TDIConnInfo> connList;
        public bool SelectAll = true;
        public string selEmpNo = "";
        public bool Stop = false;
        public bool StopGet = false;

        protected override void InitForm()
        {
            formCode = "SelectEmp";
            InitGrid(cardGrid);
            selEmpNo = "";
            IsAllEmpInfo = true;
            base.InitForm();
            this.Text = oprt;
            RadioButton_Click(null, null);
            rbAll.Text = Pub.GetResText("KQDataAssay", rbAll.Name, "");
            rbEmp.Text = Pub.GetResText("KQDataAssay", rbEmp.Name, "");
            #region 部分控件显示文本会在 base.InitForm中自动处理
            //btnGetListFromMac.Text = Pub.GetResText("Public", btnGetListFromMac.Name, "");
            //btnClear.Text = Pub.GetResText("Public", btnClear.Name, "");
            //btnSelectAll.Text = Pub.GetResText("Public", btnSelectAll.Name, "");
            //btnUnselectAll.Text = Pub.GetResText("Public", btnUnselectAll.Name, "");
            //btnRemove.Text = Pub.GetResText("Public", btnRemove.Name, "");
            //btnAdd.Text = Pub.GetResText("Public", btnAdd.Name, "");
            //lblFingerNo.Text = Pub.GetResText("Public", lblFingerNo.Name, "");
            #endregion
            lblMsg.ForeColor = Color.FromName("Black");
            lblMsg.Text = "0";
            lblMsg1.Text = Pub.GetResText(formCode, "MsgReadEndData", "");
            btnStop.Text = Pub.GetResText("KQDataAssay", "button2", "");
            btnStop.Visible = false;
            progBar1.Visible = false;
        }

        public frmBaseSelectEmp(string Oprt, List<UInt32> UserIdList, List<TDIConnInfo> ConnList)
        {
            oprt = Oprt;
            selList = UserIdList;
            connList = ConnList;
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            gbxEmpInfo.Enabled = rbEmp.Checked;
            SelectAll = !rbEmp.Checked;
        }

        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            ChangeAllSelectStatus(e.CheckedState);
        }

        public void InitGrid(DataGridView grid)
        {
            grid.Columns.Clear();
            AddColumn(grid, 3, "SelectCheck", false, false, 1, 60);
            AddColumn(grid, 0, "FingerNo", false, true, 1, 100);
            AddColumn(grid, 0, "EmpName", false, false, 1, 100);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        
            int index = 0;

            if (string.IsNullOrEmpty(txtUserId.Text)) return;
            int count = cardGrid.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                if (Equals(cardGrid.Rows[i].Cells[1].Value.ToString(), txtUserId.Text))
                {
                    lblMsg.ForeColor = Color.FromName("Red");
                    lblMsg.Text = Pub.GetResText(formCode, "ErrorUserIdAdd", "");

                    return;
                }
            }

            index = this.cardGrid.Rows.Add();
            ((DataGridViewCheckBoxCell)cardGrid.Rows[index].Cells[0]).Value = true;
            this.cardGrid.Rows[index].Cells[1].Value = txtUserId.Text;
            selStringList.Add(txtUserId.Text);

            lblMsg.ForeColor = Color.FromName("Black");
            lblMsg.Text = cardGrid.Rows.Count.ToString();
            cardGrid.Sort(this.cardGrid.Columns[1], ListSortDirection.Ascending);//排序
            for (int i = 0; i < count; i++)
            {
                if (Equals(cardGrid.Rows[i].Cells[1].Value.ToString(), txtUserId.Text))
                {
                    cardGrid.FirstDisplayedScrollingRowIndex = i;
                    return;
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.cardGrid.Rows.Clear();
            lblMsg.ForeColor = Color.FromName("Black");
            lblMsg.Text = cardGrid.Rows.Count.ToString();

        }

        private void btnGetAllFromMac_Click(object sender, EventArgs e)
        {
           // progBar1.Style = ProgressBarStyle.Marquee;
            this.cardGrid.Rows.Clear();
            selStringList.Clear();
            GetUserIDListFromMac();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cardGrid.Rows.Count;)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)cardGrid.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)
                {
                    cardGrid.Rows.RemoveAt(i);
                    selStringList.RemoveAt(i);
                }
                //删除...
                else
                    i++;
            }
            lblMsg.ForeColor = Color.FromName("Black");
            lblMsg.Text = cardGrid.Rows.Count.ToString();

        }

        private void GetUserIDListFromMac()
        {
            bool state;
            bool ret = false;
            int vnResultCode = -1;
            UInt32 vEnrollNumber = 0;
            int vBackupNumber = 0;
            int vPrivilege = 0;
            int vnEnableFlag = 0;
            string UserName = "";
            int EnrollNumberCount = 0;
            int PersonNum = 0;
            lblMsg.ForeColor = Color.FromName("Black");
            TDIConnInfo conn;
            progBar1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            progBar1.Visible = true;
            lblMsg1.Visible = true;
            btnStop.Visible = true;
            btnStop.Focus();
            if (connList.Count > 0)
            {
                for (int i = 0; i < connList.Count; i++)
                {
                    conn = connList[i];

                    switch (conn.MacSeriesTypeId)
                    {
                       
                        case 2:
                            if (SystemInfo.ShowSEA != 1)
                            {
                                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "MsgUnModuleInfo", ""), Pub.GetResText(formCode, "SeaDev", "")));
                                break;
                            }
                            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                            {
                                if (RegisterInfo.EndDate < DateTime.Now)
                                {
                                    Pub.MessageBoxShow(RegisterInfo.StateText);
                                    break;
                                }
                            }
                            SystemInfo.MacSeriesTypeId = 2;
                            string url = "http://" + conn.NetHost + "/";
                            //查询人员总数
                            string searchTotlePersonUrl = url + "action/SearchPersonNum";
                            SearchTotlePerson searchTotlePerson = new SearchTotlePerson(Convert.ToInt32(conn.MacSN), 0, "", "", 2, "0-100", 0, "");
                            jsonBody<SearchTotlePerson> jsonBodySearchTotlePerson = new jsonBody<SearchTotlePerson>("SearchPersonNum", searchTotlePerson);
                            string jsonString = JsonConvert.SerializeObject(jsonBodySearchTotlePerson);
                            ret = DeviceObject.objFK623.POST_GetResponse(searchTotlePersonUrl, conn.MacSeriesUserName, conn.SeaSeries_Pwd, ref jsonString);
                            if (!ret)
                            {
                                lblMsg.ForeColor = Color.FromName("red");
                                lblMsg.Text = DeviceObject.objFK623.SeaBodyStr();
                                continue;
                            }
                            jsonBody<SearchTotlePersonInfo> searchTotlePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchTotlePersonInfo>>(jsonString);
                            {
                                PersonNum = searchTotlePersonInfo.info.PersonNum;
                            }
                            if (PersonNum == 0)
                            {
                                lblMsg.ForeColor = Color.FromName("red");
                                lblMsg.Text = (Pub.GetResText(formCode, "ErrorUnUserID", ""));
                                continue;
                            }
                            int count = 0;
                            while(true)
                            {
                                if (Stop || StopGet)
                                {
                                    break;
                                }
                                    //查询人员
                                    string searchMultipleUrl = url + "action/SearchPersonList";
                                SearchMultiplePerson searchMultiple = new SearchMultiplePerson(Convert.ToInt32(conn.MacSN), 0, "", "", 2, "0-100", 0, "", count * 10, 10, 0);
                                count++;
                                jsonBody<SearchMultiplePerson> jsonBodySearchMultiplePerson = new jsonBody<SearchMultiplePerson>("SearchPersonList", searchMultiple);
                                jsonString = JsonConvert.SerializeObject(jsonBodySearchMultiplePerson);
                                ret = DeviceObject.objFK623.POST_GetResponse(searchMultipleUrl, conn.MacSeriesUserName, conn.SeaSeries_Pwd, ref jsonString);
                                if (!ret)
                                {
                                    break;
                                }
                                jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>> searchMultiplePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>>>(jsonString);
                                {
                                    for (int j = 0; j < searchMultiplePersonInfo.info.Listnum; j++)
                                    {
                                        if (Stop || StopGet)
                                        {
                                            break;
                                        }
                                        vEnrollNumber = searchMultiplePersonInfo.info.List[j].CustomizeID;
                                        UserName = searchMultiplePersonInfo.info.List[j].Name;
                                        if (!selStringList.Contains(vEnrollNumber.ToString()) && vEnrollNumber != 0)
                                        {
                                            //int index = this.cardGrid.Rows.Add();
                                            cardGrid.Rows.Add(new object[] {false, vEnrollNumber.ToString(), UserName });
                                            //// ((DataGridViewCheckBoxCell)cardGrid.Rows[index].Cells[0]).Value = true;
                                            //this.cardGrid.Rows[index].Cells[1].Value = vEnrollNumber.ToString();
                                            //this.cardGrid.Rows[index].Cells[2].Value = UserName;

                                            selStringList.Add(vEnrollNumber.ToString());

                                            lblMsg.Text = string.Format("{0}", cardGrid.Rows.Count);
                                        }
                                        //EnrollNumberCount++;

                                        lblMsg1.Text = Pub.GetResText(formCode, "btnGetListFromMac", "") + string.Format("-{0} /{1} ", cardGrid.Rows.Count, cardGrid.Rows.Count);
                                        
                                    }
                                }
                                Application.DoEvents();
                            }
                            break;
                        case 3:
                            if (SystemInfo.ShowSTAR != 1)
                            {
                                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "MsgUnModuleInfo", ""), Pub.GetResText(formCode, "StarDev", "")));
                                break;
                            }
                            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                            {
                                if (RegisterInfo.EndDate < DateTime.Now)
                                {
                                    Pub.MessageBoxShow(RegisterInfo.StateText);
                                    break;
                                }
                            }
                            try
                            {
                                if (DeviceObject.socKetClient.Open(conn.NetHost, conn.NetPort, conn.NetPassword))
                                {
                                    string cmd = "GetDeviceInfo";
                                    DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
                                    StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));
                                    if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                                    {
                                        cmd = "GetUserIdList";
                                        GetUserIdListCmd getUserIdListCmd = new GetUserIdListCmd(0);
                                        _DeviceCmd<GetUserIdListCmd> devGetUserIdListCmd = new _DeviceCmd<GetUserIdListCmd>(cmd, getUserIdListCmd);
                                    RE:
                                        if (Stop || StopGet)
                                        {
                                            break;
                                        }
                                        jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devGetUserIdListCmd));
                                        if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                                        {
                                            int back = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                                            if (back == 0)
                                            {
                                                _ResultInfo<UserListInfo<UserIdName>> personIDList = JsonConvert.DeserializeObject<_ResultInfo<UserListInfo<UserIdName>>>(jsonStringBuilder.ToString());
                                                if(personIDList.result_data.users != null)
                                                {
                                                    for (int x = 0; x < personIDList.result_data.users.Count; x++)
                                                    {
                                                        int index = this.cardGrid.Rows.Add();
                                                        this.cardGrid.Rows[index].Cells[1].Value = personIDList.result_data.users[x].userId;
                                                        this.cardGrid.Rows[index].Cells[2].Value = personIDList.result_data.users[x].name;

                                                        selStringList.Add(personIDList.result_data.users[x].userId);
                                                        EnrollNumberCount = index;
                                                        lblMsg.Text = string.Format("{0}", index);
                                                    }
                                                }
                                                else
                                                {
                                                    lblMsg.ForeColor = Color.FromName("red");
                                                    lblMsg.Text = (Pub.GetResText(formCode, "ErrorUnUserID", ""));
                                                    ret = false;
                                                    continue;
                                                }

                                                if (personIDList.result_data.packageId != 0)
                                                {
                                                    devGetUserIdListCmd.data.packageId++;
                                                    goto RE;
                                                }

                                                lblMsg1.Text = Pub.GetResText(formCode, "btnGetListFromMac", "") + string.Format("-{0} /{1} ", EnrollNumberCount, EnrollNumberCount);
                                                Application.DoEvents();
                                                ret = true;
                                            }
                                            else
                                            {
                                                ret = false;
                                            }
                                        }
                                        else
                                        {
                                            ret = false;
                                        }
                                    }
                                  
                                }
                                else
                                {
                                    lblMsg.ForeColor = Color.FromName("red");
                                    lblMsg.Text = DeviceObject.objFK623.GetRunMsg((int)enumErrorCode.RUNERR_NO_OPEN_COMM);
                                    continue;
                                }
                                DeviceObject.socKetClient.Close();
                            }
                             catch (Exception E)
                            {
                                MessageBox.Show(E.Message);
                            }
                            break;
                        default:
                            SystemInfo.MacSeriesTypeId = 1;
                            DeviceObject.objFK623.InitConn(conn);
                            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
                            vnResultCode = DeviceObject.objFK623.EnableDevice(0);
                            state = DeviceObject.objFK623.IsOpen;
                            if (state)
                                vnResultCode = DeviceObject.objFK623.ReadAllUserID();
                            else
                            {
                                lblMsg.ForeColor = Color.FromName("red");
                                lblMsg.Text = DeviceObject.objFK623.GetRunMsg((int)enumErrorCode.RUNERR_NO_OPEN_COMM);
                            }

                            if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
                            {
                                if (state)
                                {
                                    lblMsg.ForeColor = Color.FromName("red");
                                    lblMsg.Text = (Pub.GetResText(formCode, "ErrorUnUserID", ""));
                                }
                                DeviceObject.objFK623.EnableDevice(1);
                                DeviceObject.objFK623.Close();
                                continue;
                            }
                          
                            do
                            {
                                vnResultCode = DeviceObject.objFK623.GetAllUserID(
                                            ref vEnrollNumber,
                                            ref vBackupNumber,
                                            ref vPrivilege,
                                            ref vnEnableFlag);

                                if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
                                {

                                    DeviceObject.objFK623.EnableDevice(1);
                                    DeviceObject.objFK623.Close();
                                    break;
                                }
                                DeviceObject.objFK623.GetUserName(vEnrollNumber, ref UserName);
                                if (!selStringList.Contains(vEnrollNumber.ToString()) && vEnrollNumber != 0)
                                {

                                    int index = this.cardGrid.Rows.Add();
                                    // ((DataGridViewCheckBoxCell)cardGrid.Rows[index].Cells[0]).Value = true;
                                    this.cardGrid.Rows[index].Cells[1].Value = vEnrollNumber.ToString();
                                    this.cardGrid.Rows[index].Cells[2].Value = UserName;

                                    selStringList.Add(vEnrollNumber.ToString());
                                    EnrollNumberCount = index;
                                    lblMsg.Text = string.Format("{0}", index);
                                }
                                //EnrollNumberCount++;

                                lblMsg1.Text = Pub.GetResText(formCode, "btnGetListFromMac", "") + string.Format("-{0} /{1} ", EnrollNumberCount, EnrollNumberCount);
                                Application.DoEvents();
                                if (StopGet)
                                {
                                    DeviceObject.objFK623.EnableDevice(1);
                                    DeviceObject.objFK623.Close();
                                    break;
                                }
                                if (Stop)
                                {
                                    DeviceObject.objFK623.EnableDevice(1);
                                    DeviceObject.objFK623.Close();
                                    this.Close();
                                }
                            }
                            while (true);
                            break;
                    }

                    cardGrid.Sort(this.cardGrid.Columns[1], ListSortDirection.Ascending);//排序
                    lblMsg.ForeColor = Color.FromName("Black");
                    lblMsg.Text = cardGrid.Rows.Count.ToString();
                    lblMsg1.Text = Pub.GetResText(formCode, "MsgReadEndData", "");
                    progBar1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard;
                    progBar1.Value = 0;
                    StopGet = false;
                    progBar1.Visible = false;
                    lblMsg1.Visible = false;
                    btnStop.Visible = false;
                }
              
            }
        }


        private void ChangeAllSelectStatus(bool IsChecked)
        {
            int count = cardGrid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)cardGrid.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == !IsChecked)
                {
                    cardGrid.BeginEdit(true);
                    checkCell.Value = IsChecked;
                    cardGrid.EndEdit();
                }
                else
                {
                    continue;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopGet = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbEmp.Checked)
            {
                if (cardGrid.RowCount == 0)
                {
                    lblMsg.ForeColor = Color.FromName("Red");
                    lblMsg.Text = (Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                    return;
                }
                int count = cardGrid.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)cardGrid.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        selList.Add(Convert.ToUInt32(cardGrid.Rows[i].Cells[1].Value.ToString()));
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void txtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void textUsernum_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void textUsernum_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Enter) return;
            try
            {
                if (string.IsNullOrEmpty(textUsernum.Text)) return;

                int count = cardGrid.Rows.Count;
                if (count == 0)
                {
                    textUsernum.SelectAll();
                    lblMsg.ForeColor = Color.FromName("Red");
                    lblMsg.Text = (Pub.GetResText(formCode, "ErrorListEmpty", ""));

                    return;
                }

                for (int j = 0; j < count; j++)
                {
                    if (Equals(this.cardGrid.Rows[j].Cells[1].Value.ToString(), textUsernum.Text))
                    {
                        ((DataGridViewCheckBoxCell)cardGrid.Rows[j].Cells[0]).Value = true;
                        cardGrid.FirstDisplayedScrollingRowIndex = j;
                        textUsernum.SelectAll();
                        lblMsg.ForeColor = Color.FromName("Black");
                        lblMsg.Text = cardGrid.Rows.Count.ToString();
                        return;
                    }
                    else
                    {
                        if (j == count - 1)
                        {
                            textUsernum.SelectAll();
                            lblMsg.ForeColor = Color.FromName("Red");
                            lblMsg.Text = (Pub.GetResText(formCode, "ErrorSelectUsernum", ""));

                            return;
                        }
                    }
                }

            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        private void frmBaseSelectEmp_MouseDown(object sender, MouseEventArgs e)
        {
            lblMsg.ForeColor = Color.FromName("Black");
            lblMsg.Text = cardGrid.Rows.Count.ToString();
        }
        //排序
        private void cardGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {        
            e.SortResult = (Convert.ToDouble(e.CellValue1) - Convert.ToDouble(e.CellValue2) > 0) ? 1 : (Convert.ToDouble(e.CellValue1) - Convert.ToDouble(e.CellValue2) < 0) ? -1 : 0;
            e.Handled = true;
        }

        private void frmBaseSelectEmp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop = true;
        }

        private void cardGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey && !isSelectEnd)
            {
                selectNo = cardGrid.CurrentRow.Index;
                isSelect = true;
                isSelectEnd = true;
            }
           
        }

        private void cardGrid_KeyUp(object sender, KeyEventArgs e)
        {
            isSelect = false;
            isSelectEnd = false;
        }

        private void cardGrid_MouseClick(object sender, MouseEventArgs e)
        {
            selectNoEnd = cardGrid.CurrentRow.Index;

            if (selectNoEnd < 0) return;
            if (isSelect)
            {
                int i = 0;
                for (int j = 0; j < cardGrid.RowCount; j++)
                {

                    if (selectNo < selectNoEnd)
                    {
                        if (i >= selectNo && i <= selectNoEnd)
                            cardGrid.Rows[i].Cells[0].Value = true;
                    }
                    else
                    {
                        if (i <= selectNo && i >= selectNoEnd)
                            cardGrid.Rows[i].Cells[0].Value = true;
                    }
                    i++;
                }
            }
        }
    }
}
