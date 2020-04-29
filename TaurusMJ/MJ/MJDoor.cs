using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using DevComponents.DotNetBar;

namespace Taurus
{
    public partial class frmMJDoor : frmBaseMDIChild
    {
        private List<TDIConnInfo> connList = new List<TDIConnInfo>();
        private bool IsWorking = false;
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;

        private void AddColumn(int colType, string Field, int colWidth)
        {
            AddColumn(colType, Field, false, true, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, int colWidth)
        {
            AddColumn(colType, Field, IsHide, true, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, bool HasSort, int colWidth)
        {
            AddColumn(colType, Field, IsHide, HasSort, 0, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, bool HasSort, byte CenterFlag, int colWidth)
        {
            AddColumn(dataGrid, colType, Field, IsHide, HasSort, CenterFlag, colWidth);
        }
        public override void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            SelectData(e.CheckedState);
        }
        protected override void InitForm()
        {
            formCode = "MJDoor";
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", true);
            SetToolItemState("ItemTAG4", true);
            SetToolItemState("ItemTAG5", false);
            SetToolItemState("ItemTAG6", false);
            SetToolItemState("ItemTAG7", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);           

            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemDelete", false);
            SetToolItemState("ItemSelect", false);
            SetToolItemState("ItemUnselect", false);
            SetToolItemState("ItemClose", false);
            
            dataGrid.Columns.Clear();
            AddColumn(3, "SelectCheck", false, false,1, 0);
            AddColumn(0, "MacSN", false, 0);
            AddColumn(0, "MacDesc", false, false, 0);
            AddColumn(0, "MacTypeID", true, false, 0);
            AddColumn(0, "MacTypeName", true, false, 0);
            AddColumn(0, "MacConnType", false, false, 0);
            AddColumn(0, "MacIP", false, false, 0);
            AddColumn(0, "MacPort", false, false, 0);
            AddColumn(0, "MacConnPWD", true, false, 0);
            AddColumn(1, "IsGPRS", false, false, 1, 60);
            AddColumn(0, "DoorState", false, false, 0);
            
            base.InitForm();

            ItemTAG1.Text = Pub.GetResText(formCode, "btnOpen", "");
            ItemTAG2.Text = Pub.GetResText(formCode, "btnCOpen", "");
            ItemTAG3.Text = Pub.GetResText(formCode, "btnClose", "");
            ItemTAG4.Text = Pub.GetResText(formCode, "btnAlarm", "");
            ItemTAG7.Text = Pub.GetResText(formCode, "btnDefence", "");
            ItemTAG6.Text = Pub.GetResText(formCode, "btnWithdrawal", "");
            ItemTAG7.Text = Pub.GetResText(formCode, "btnHuiF", "");

            msgGrid.BackgroundColor = dataGrid.BackgroundColor;
            msgGrid.DefaultCellStyle.SelectionForeColor = dataGrid.DefaultCellStyle.SelectionForeColor;
            ItemFindText.ToolTipText = "";
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
            string QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "8" });
            try
            {
                bindingSource.DataSource = SystemInfo.db.GetDataTable(QuerySQL);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, QuerySQL);
            }
            RefresButton();
            msgGrid_Resize(null, null);
            SystemInfo.IsTimerOpen = false;
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
               
               dataGrid[10, i].Value = "";
               
            }
            panelEx1.Visible = true;
        }

        public frmMJDoor()
        {
            InitializeComponent();
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void msgGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void msgGrid_Resize(object sender, EventArgs e)
        {
            Column1.Width = msgGrid.Width - 20;
        }

        private void RefresButton()
        {
            dataGrid.Enabled = !IsWorking;
        }
        protected override void ExecItemFindText()
        {
            QuickSearchNormalMac(ItemFindText.Text, dataGrid);
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            ExecMacOprt(ItemTAG1.Text, 0);
        }
        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            ExecMacOprt(ItemTAG2.Text, 3);
        }
        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            ExecMacOprt(ItemTAG3.Text, 1);
        }
        protected override void ExecItemTAG4()
        {
            base.ExecItemTAG4();
            ExecMacOprt(ItemTAG4.Text, 7);
        }
        protected override void ExecItemTAG5()
        {
            base.ExecItemTAG5();
            frmMJpwd frm = new frmMJpwd(ItemTAG5.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ExecMacOprt(ItemTAG5.Text, 4);
            }
        }
        protected override void ExecItemTAG6()
        {
            base.ExecItemTAG6();
           
            frmMJpwd frm = new frmMJpwd(ItemTAG6.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ExecMacOprt(ItemTAG6.Text, 5);
            }
        }
        protected override void ExecItemTAG7()
        {
            base.ExecItemTAG7();
            ExecMacOprt(ItemTAG7.Text, 2);
        }
        

        private TDIConnInfo RowDataToConnInfo(int RowIndex)
        {
            int MacSN = 0;
            string MacSN_GRPS = "";
            bool IsGPRS = Pub.ValueToBool(dataGrid[9, RowIndex].Value);
            if (IsGPRS)
                MacSN_GRPS = dataGrid[1, RowIndex].Value.ToString();
            else
            {
                MacSN = Convert.ToInt32(dataGrid[1, RowIndex].Value.ToString());
                MacSN_GRPS = MacSN.ToString();
            }
            string MacConnType = dataGrid[5, RowIndex].Value.ToString();
            string MacIP = dataGrid[6, RowIndex].Value.ToString();
            string MacPort = dataGrid[7, RowIndex].Value.ToString();
            string MacConnPWD = dataGrid[8, RowIndex].Value.ToString();
            string SeaSeriesPwd = dataGrid[8, RowIndex].Value.ToString();
           
            return Pub.ValueToDIConnInfo(MacSN, MacSN_GRPS, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS,1, SeaSeriesPwd, "");
        }

        private void RowToConnInfo(int RowIndex)
        {
            connList.Add(RowDataToConnInfo(RowIndex));
        }

        private bool InitMacList()
        {
            connList.Clear();
            if (dataGrid.RowCount == 1)
            {
                RowToConnInfo(0);
            }
            else
            {
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
                    {
                        RowToConnInfo(i);
                    }
                }
            }
            if (connList.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
            }
            return connList.Count > 0;
        }

        private void RefreshMacMsg(string msg)
        {
            msgGrid.Rows.Add();
            msgGrid[0, msgGrid.RowCount - 1].Value = "[" + DateTime.Now.ToString() + "] " + msg;
            msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
            msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
        }

        private void UpdateMacMsg(string msg, bool state)
        {
            string s = msgGrid[0, msgGrid.RowCount - 1].Value.ToString();

            msgGrid[0, msgGrid.RowCount - 1].Value = s + "    " + msg;
            if (state)
                msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Blue;
            else
                msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Red;
        }

        private void ExecMacOprt(string oprt, int flag)
        {
            bool state;
            string msg = "";
            string MacMsg = "";
            if (!InitMacList()) return;
            IsWorking = true;
            RefresButton();
            DateTime start = new DateTime();
            start = DateTime.Now;
            string ExecTimes = "";
            TDIConnInfo conn;
            for (int i = 0; i < connList.Count; i++)
            {
                MacMsg = "";
                conn = connList[i];
                RefreshMacMsg(oprt + "[" + conn.MacSN.ToString() + "]......");
                DeviceObject.objFK623.InitConn(conn);
                if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
                DeviceObject.objFK623.EnableDevice(0);
                state = DeviceObject.objFK623.IsOpen;
                if (state) state = ExecMacCommand(flag, conn.MacSN, ref MacMsg);
                ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                UpdateMacMsg(MacMsg + DeviceObject.objFK623.ErrMsg + ExecTimes, state);
                msg = msg + conn.MacSN.ToString() + ":" + MacMsg + DeviceObject.objFK623.ErrMsg + ";";
                DeviceObject.objFK623.EnableDevice(1);
                DeviceObject.objFK623.Close();
                Application.DoEvents();
                start = DateTime.Now;
                if (!IsWorking) break;
            }
            SystemInfo.db.WriteSYLog(this.Text, oprt, msg);
            IsWorking = false;
            RefresButton();
        }

        private bool ExecMacCommand(int flag, int MacSN, ref string MacMsg)
        {
            bool ret = false;
            DateTime start = new DateTime();
            start = DateTime.Now;
            int stata = 0;
            MacMsg = "";
            switch (flag)
            {
                case 0://开门
                    ret = MJDoorState(true, MacSN);
                    break;
                case 1://常关
                    ret = MJDoorState(false, MacSN);
                    break;
                case 2://控制状态
                    DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_CLOSED);
                    SystemInfo.isclose = true;
                    ret = DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_CONTROLRESET);
                    SystemInfo.isclose = false;
                    if (ret) ret = MJDoorStateGet(MacSN, stata);
                    break;
                case 3://常开
                    ret = DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_OPEND);
                    stata = 1;
                    if (ret) ret = MJDoorStateGet(MacSN,stata);
                    break;
                case 4://布防
                    ret = MJDefence(MacSN);
                    break;
                case 5://撤防
                    ret = MJWithdrawal(MacSN);
                    break;
                case 6://定时开门
                    SystemInfo.IsTimerOpen = true;
                    SystemInfo.TimerOpen = connList;
                    ret = DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_OPEND);
                    if (ret)
                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "7", SystemInfo.SetTimer.ToString(SystemInfo.SQLDateTimeFMT), "1", MacSN.ToString()}));
                    stata = 1;
                    if (ret) ret = MJDoorStateGet(MacSN, stata);
                    break;
                case 7://解除报警
                    ret = AlarmParam(MacSN);
                    break;
            }
            return ret;
        }

        private bool AlarmParam(int MacSN)
        {
            bool ret = false;
            ret = DeviceObject.objFK623.SetAlarmStatus(0);
            return ret;
        }

        private bool MJDefence(int MacSN)
        {
            bool ret = false;
            JObject vjobj = new JObject();
            JObject vjobjparam = new JObject();
            vjobj.Add("cmd", "alarm_enable_set");
            vjobjparam.Add("enable_alarm", "yes");
            vjobj.Add("param", vjobjparam);
            string vstrJsonStr = vjobj.ToString();

            ret = DeviceObject.objFK623.ExecJsonCmd(ref vstrJsonStr);

            return ret;
        }

        private bool MJWithdrawal(int MacSN)
        {
            bool ret = false;
            JObject vjobj = new JObject();
            JObject vjobjparam = new JObject();
            vjobj.Add("cmd", "alarm_enable_set");
            vjobjparam.Add("enable_alarm", "no");
            vjobj.Add("param", vjobjparam);
            string vstrJsonStr = vjobj.ToString();
            ret = DeviceObject.objFK623.ExecJsonCmd(ref vstrJsonStr);
            return ret;
        }
        private bool MJDoorState(bool IsOpen, int MacSN)
        {
            bool ret = false;
            int stata = 0;
            if (IsOpen)
            {
                ret = DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_COMMNAD);
                stata = 3;
            }
               
            else
            {
                ret = DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_CLOSED);
                SystemInfo.isclose = ret;
                stata = 2;
            }
               
            if (ret) ret = MJDoorStateGet(MacSN,stata);

            //if (!IsOpen)
            //{
            //    DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_CONTROLRESET);

            //}
            SystemInfo.isclose = false;
            return ret;
        }

        private bool MJDoorStateGet(int MacSN,int stata)
        {
            int v = 0;
            bool ret = DeviceObject.objFK623.GetDoorStatus(ref v);
            if (ret)
            {
                string state = "";
                switch (v)
                {
                    case (int)FKDoor.DOOR_CONTROLRESET:
                        if(stata==0)
                            state = Pub.GetResText(formCode, "FK_DOOR_CONTROLRESET", "");
                        else if(stata==1)
                            state = Pub.GetResText(formCode, "FK_DOOR_OPEND", "");
                        else if (stata == 2)
                            state = Pub.GetResText(formCode, "FK_DOOR_CLOSED", "");
                        else if (stata == 3)
                            state = Pub.GetResText(formCode, "FK_DOOR_COMMNAD", "");
                        break;
                    case (int)FKDoor.DOOR_OPEND:
                        state = Pub.GetResText(formCode, "FK_DOOR_OPEND", "");
                        break;
                    case (int)FKDoor.DOOR_CLOSED:
                        state = Pub.GetResText(formCode, "FK_DOOR_CLOSED", "");
                        break;
                    case (int)FKDoor.DOOR_COMMNAD:
                        state = Pub.GetResText(formCode, "FK_DOOR_COMMNAD", "");
                        break;
                    default:
                        state = Pub.GetResText(formCode, "FK_DOOR_UNKNOWN", "");
                        break;
                }
                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "301", state, MacSN.ToString() });
                try
                {
                    SystemInfo.db.ExecSQL(sql);
                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        if (dataGrid[1, i].Value.ToString() == MacSN.ToString())
                        {
                            dataGrid[10, i].Value = state;
                            break;
                        }
                    }
                }
                catch (Exception E)
                {
                    ret = false;
                    Pub.ShowErrorMsg(E, sql);
                }
            }
            return ret;
        }

        private void frmMJDoor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }

        private void selectData(bool State)
        {
            if (bindingSource.DataSource != null)
            {
                DataTable dt = (DataTable)bindingSource.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i].BeginEdit();
                    dt.Rows[i]["SelectCheck"] = State;
                    dt.Rows[i].EndEdit();
                }
            }
        }

        private void ItemSelect_Click(object sender, EventArgs e)
        {
            selectData(true);
        }

        private void ItemUnselect_Click(object sender, EventArgs e)
        {
            selectData(false);
        }

        private void btnTimerOpen_Click(object sender, EventArgs e)
        {
            if (!InitMacList()) return;
            SystemInfo.IsTimerOpen = false;
            frmMJSetTimer frm = new frmMJSetTimer("");
            if (frm.ShowDialog() == DialogResult.OK)
            { 
                ExecMacOprt("", 6);
            }
            
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey && !isSelectEnd)
            {
                selectNo = dataGrid.CurrentRow.Index;
                isSelect = true;
                isSelectEnd = true;
            }
          
        }

        private void dataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            isSelect = false;
            isSelectEnd = false;
        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGrid.Rows.Count == 0) return;
            selectNoEnd = dataGrid.CurrentRow.Index;
            if (selectNoEnd < 0) return;
            if (isSelect)
            {
                int i = 0;
                for (int j = 0; j < dataGrid.RowCount; j++)
                {

                    if (selectNo < selectNoEnd)
                    {
                        if (i >= selectNo && i <= selectNoEnd)
                            dataGrid.Rows[i].Cells[0].Value = true;
                    }
                    else
                    {
                        if (i <= selectNo && i >= selectNoEnd)
                            dataGrid.Rows[i].Cells[0].Value = true;
                    }
                    i++;
                }
            }
        }
      
    }
}