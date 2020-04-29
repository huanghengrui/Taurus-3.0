using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;
using System.Media;
using System.Diagnostics;
using DevComponents.DotNetBar.Controls;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Taurus
{
    public partial class frmMain : frmBaseForm
    {
        private static string MDICaption = "";
        private bool RegisterExit = false;
        private string LocalFormat = "";
        private byte IsWorking = 0;
        private string StrPosition = "";
        private string StrReading = "";
        private string StrReadEnd = "";
        private string MsgString = "";
        private string AInOutModeName = "";
        private int Panel5Conut = 0;
        private const int btnWidth = 81;
        private string imagePath = "";
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;
        protected bool isMonitoring = false;
        private bool isPanelMuenVisible = true;
        private bool isMove = false;
        private int TimerMonitoringCount = 0;
        protected static int superTabHigth = 0;
        private List<TDIConnInfo> connList = new List<TDIConnInfo>();
        private List<TDIConnInfo> connTimerList = new List<TDIConnInfo>();
        private List<Monitoring> monitoringsList = new List<Monitoring>();
        public delegate void OutDelegate(string text);
        private KQTextFormatInfo textFormat = new KQTextFormatInfo("");
        private bool AllowShowAll = false;
        private FingerReadData readData = null;
        private int Port = 0;
        private int sePort = 0;
        private int stPort = 0;
        private int AcPort = 7005;
        private int SeaPort = 8080;
        private int StaPort = 8001;
        private bool IsExistDelete = true;
        private bool IsUploadName = true;
        protected bool isGetNewData = false;
        private string usbFile = "";
        private string usbFKModel = "";
        private TDownSelectList[] selList = new TDownSelectList[0];
        private List<UInt32> cardList = new List<UInt32>();
        private List<TDownInfoList> downList = new List<TDownInfoList>();

        private List<MJInfoList> NMJList = new List<MJInfoList>();
        private DateTime serverDate = new DateTime();
        private DataTable dtReal = new DataTable();
        private DataTable dtDoorReal = new DataTable();
        private DataTable dtAlarmReal = new DataTable();
        private SoundPlayer sp = new SoundPlayer();
        private List<TimeZone> timeList = new List<TimeZone>();
        private List<UInt32> fingerNoList = new List<UInt32>();

        private SeaHttpServer seaHttpServer = null;
        private StarHttpServer starHttpServer = null;
        private DataTable dtUpload = null;
        private DataTable dtUploadcount = null;
        private List<TDimInfo> dimList = new List<TDimInfo>();
        private List<TDimInfo> execList = new List<TDimInfo>();
        private int BellTime = 0;
        private string bellPath = "";
        public int xvalues = 0;
        public int yvalues = 0;
        public bool beginMove = false;
        public int currentXPosition = 0;
        public int currentYPosition = 0;
        public static bool UpdateEmpInfoCountFlag = false;
        public static bool UpdateEmpInfoCountStarFlag = false;

        Assembly objRS = null;
        Type tpRS = null;
        Assembly objRSReport = null;
        Type tpRSReport = null;
        Assembly objMJ = null;
        Type tpMJ = null;
        Assembly objMJReport = null;
        Type tpMJReport = null;
        Assembly objKQ = null;
        Type tpKQ = null;
        Assembly objKQReport = null;
        Type tpKQReport = null;
        Assembly objGZ = null;
        Type tpGZ = null;
        Assembly objGZReport = null;
        Type tpGZReport = null;
        Assembly objSEA = null;
        Type tpSEA = null;
        Assembly objSEAReport = null;
        Type tpSEAReport = null;
        Assembly objSTAR = null;
        Type tpSTAR = null;
        Assembly objSTARReport = null;
        Type tpSTARReport = null;
        public const int HTLEFT = 10;
        public const int HTRIGHT = 11;
        public const int HTTOP = 12;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 0x10;
        public const int HTBOTTOMRIGHT = 17;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息 
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标 
                    m.LParam = IntPtr.Zero;//默认值 
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void LoadDll(ref Assembly obj, ref Type tp, string DllName, ref int itemIndex,
          System.EventHandler clickEvent)
        {
            LoadDll(ref obj, ref tp, DllName, ref itemIndex, clickEvent, true);
        }

        private void LoadDll(ref Assembly obj, ref Type tp, string DllName, ref int itemIndex,
          System.EventHandler clickEvent, bool NewFunc)
        {
            string FileName = SystemInfo.AppPath + DllName;
            FuncObject funcObj;
            FuncSubObject funcSubObj;
            ToolStripMenuItem item;
            ToolStripMenuItem itemSub;
            ToolStripMenuItem itemSubEx;
            obj = null;
            if (File.Exists(FileName))
            {
                try
                {
                    obj = Assembly.LoadFile(FileName);
                    if (obj.GetTypes().Length > 0)
                    {
                        tp = obj.GetType("Taurus.ShowForms");
                        if (tp != null)
                        {
                            Object objX = tp.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public |
                              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                            funcObj = (FuncObject)tp.InvokeMember("GetFormsList", BindingFlags.DeclaredOnly | BindingFlags.Public |
                              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, objX, null);
                            if (NewFunc)
                            {
                                SystemInfo.funcList.Add(funcObj);
                                item = new ToolStripMenuItem(funcObj.Text);
                                item.Name = "mnu" + funcObj.Name;

                            }
                            else
                            {
                                //ToolStripItem[] Find = MenuBar.Items.Find("mnu" + funcObj.Name, false);
                                //item = (ToolStripMenuItem)Find[0];
                            }
                            itemSubEx = null;
                            for (int i = 0; i < funcObj.SubCount; i++)
                            {
                                funcSubObj = funcObj.SubGet(i);
                                if (funcSubObj.IsLine == 2)
                                {
                                    if (itemSubEx != null)
                                    {
                                        //item.DropDownItems.Add(itemSubEx);
                                        //itemSubEx = null;
                                    }
                                    itemSubEx = new ToolStripMenuItem(funcSubObj.Text);
                                    itemSubEx.Name = "mnu" + funcSubObj.Name;
                                    //if (item.DropDownItems.Count > 0) item.DropDownItems.Add(new ToolStripSeparator());

                                    continue;
                                }
                                else if ((funcSubObj.IsLine == 3) || (funcSubObj.IsLine == 4))
                                {
                                    itemSub = new ToolStripMenuItem(funcSubObj.Text);
                                    itemSub.Name = "mnu" + funcSubObj.Name;
                                    itemSub.Click += clickEvent;
                                    itemSub.Tag = funcSubObj.Name;
                                    if (funcSubObj.IsLine == 4) itemSubEx.DropDownItems.Add(new ToolStripSeparator());
                                    itemSubEx.DropDownItems.Add(itemSub);

                                    continue;
                                }
                                if (itemSubEx != null)
                                {
                                    //item.DropDownItems.Add(itemSubEx);
                                    //itemSubEx = null;
                                }
                                itemSub = new ToolStripMenuItem(funcSubObj.Text);
                                itemSub.Name = "mnu" + funcSubObj.Name;
                                itemSub.Click += clickEvent;
                                itemSub.Tag = funcSubObj.Name;
                                //if (funcSubObj.IsLine == 1) item.DropDownItems.Add(new ToolStripSeparator());
                                //item.DropDownItems.Add(itemSub);
                                itemSub.BackColor = dataGrid.BackgroundColor;
                            }
                            if (itemSubEx != null)
                            {
                                //item.DropDownItems.Add(itemSubEx);
                                //itemSubEx = null;
                            }
                            // item.Tag = "1";
                            if (NewFunc)
                            {
                                //MenuBar.Items.Insert(itemIndex, item);
                                itemIndex += 1;
                            }
                        }
                    }
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
            }
        }

        private bool ShowDllForm(Type tp, string frmName, string frmText)
        {
            bool ret = false;
            Form frm = null;
            bool i = false;
            //if (tp == null) return false;
            if (tp == null)
            {
                frmName = frmName.Substring(3);
                if (frmName.IndexOf("RS") >= 0)
                {
                    string fileName = SystemInfo.AppPath + SystemInfo.NameSpace + ".RS.dll";
                    Assembly obj = Assembly.LoadFile(fileName);
                    tp = obj.GetType("Taurus.ShowForms");
                    i = true;
                }

            }
            try
            {
                Object objX = tp.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public |
                  BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                frm = (Form)tp.InvokeMember("GetForm", BindingFlags.DeclaredOnly | BindingFlags.Public |
                  BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null,
                  objX, new object[] { frmName });
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (frm != null)
            {
                ret = true;
                if (i)
                    ShowMDIForms(frm, frmText);
                else
                    ShowMDIForm(frm, frmText);
            }
            return ret;
        }

        private void SetGroupButtonItemStyle(ButtonItem btn)
        {
            btn.Cursor = Cursors.Hand;
        }

        private void WriteItem(ItemPanel itemPanelEx, string item, string type)
        {
            ButtonItem btn = new ButtonItem();
            btn.ButtonStyle = eButtonStyle.ImageAndText;
            btn.Tag = item;
            btn.Text = Pub.GetResText(formCode, "mnu" + item, "");
            btn.Tooltip = btn.Text;
            SetGroupButtonItemStyle(btn);
            string bmpFile = SystemInfo.AppPath + "www\\images\\" + btn.Tag + ".ico";
            if (File.Exists(bmpFile))
            {
                btn.Icon = new System.Drawing.Icon(bmpFile);
            }
            else
            {
                bmpFile = SystemInfo.AppPath + "www\\images\\" + btn.Tag + ".png";
                if (!File.Exists(bmpFile)) bmpFile = SystemInfo.AppPath + "www\\images\\" + btn.Tag + ".bmp";
                if (!File.Exists(bmpFile)) bmpFile = SystemInfo.AppPath + "www\\images\\" + btn.Tag + ".jpg";
                if (File.Exists(bmpFile))
                {
                    btn.ImageFixedSize = new Size(24, 24);
                    btn.Image = Image.FromFile(bmpFile);
                }
            }
            btn.Click += new System.EventHandler(this.ButtonItem_Click);
            itemPanelEx.Items.AddRange(new BaseItem[] { btn });
            btn.Parent.Name = "grp" + type;
            btn.Parent.Tag = type;
            btn.Parent.Text = Pub.GetResText(formCode, "mnu" + type, "");
        }

        private void WriteGroup(string GroupName)
        {
            ItemPanel itemPanelEx = new ItemPanel();
            itemPanelEx.BackgroundStyle.Class = "ItemPanelEx";
            itemPanelEx.BackgroundStyle.CornerType = eCornerType.Square;
            itemPanelEx.ContainerControlProcessDialogKey = true;
            itemPanelEx.Dock = DockStyle.Fill;
            itemPanelEx.DragDropSupport = true;
            itemPanelEx.LayoutOrientation = eOrientation.Vertical;
            itemPanelEx.Location = new Point(0, 0);
            itemPanelEx.Name = "itemPanelEx";
            itemPanelEx.TabIndex = 0;

            if (GroupName == "SY")
            {
                LabelItem labelItem = new LabelItem();
                labelItem.PaddingLeft = 5;
                labelItem.PaddingTop = 5;
                labelItem.Text = Pub.GetResText("", "ItemSwitchingThemes", "");
                labelItem.Tooltip = labelItem.Text;

                uC_PanelMuen.PanelMuen.Controls.Add(itemPanelEx);
                itemPanelEx.Visible = false;
                itemPanelEx.Name = "grp" + GroupName;
                uC_Navbar.sNISY.Click += new EventHandler(this.sideNavItemEx_Click);

                uC_Navbar.sNISY.Name = "grp" + GroupName;

                uC_Navbar.sNISY.Tag = uC_Navbar.sNISY.Name;
                uC_Navbar.sNISY.Text = Pub.GetResText(formCode, "mnu" + GroupName, "");

                string bmpFiles = SystemInfo.AppPath + "www\\images\\" + uC_Navbar.sNIHelp.Name + ".png";
                if (File.Exists(bmpFiles))
                {
                    uC_Navbar.sNISY.Image = Image.FromFile(bmpFiles);
                }
                else
                {
                    if (!File.Exists(bmpFiles)) bmpFiles = SystemInfo.AppPath + "www\\images\\" + uC_Navbar.sNISY.Name + ".bmp";
                    if (!File.Exists(bmpFiles)) bmpFiles = SystemInfo.AppPath + "www\\images\\" + uC_Navbar.sNISY.Name + ".jpg";
                    if (File.Exists(bmpFiles))
                    {
                        uC_Navbar.sNISY.Image = Image.FromFile(bmpFiles);
                    }
                }

                WriteItem(itemPanelEx, "SYPower", GroupName);

                WriteItem(itemPanelEx, "SYPassword", GroupName);
                if (((objGZ != null) && (tpGZ != null)) || ((objSEA != null) && (tpSEA != null)) || ((objSTAR != null) && (tpSTAR != null)))
                {
                    WriteItem(itemPanelEx, "SYRegister", GroupName);
                }
                if (SystemInfo.AllowInOutMode) WriteItem(itemPanelEx, "KQInOutMode", GroupName);
                WriteItem(itemPanelEx, "SYDataBack", GroupName);
                WriteItem(itemPanelEx, "SYDataRest", GroupName);
                WriteItem(itemPanelEx, "SYDataUpdate", GroupName);
                WriteItem(itemPanelEx, "SYDataCompact", GroupName);
                WriteItem(itemPanelEx, "SYDataType", GroupName);
                WriteItem(itemPanelEx, "SYDataClear", GroupName);

                WriteItem(itemPanelEx, "SYOption", GroupName);
                WriteItem(itemPanelEx, "SYSetPort", GroupName);
            }
            else if (GroupName == "Help")
            {
                uC_PanelMuen.PanelMuen.Controls.Add(itemPanelEx);
                itemPanelEx.Visible = false;
                itemPanelEx.Name = "grp" + GroupName;
                uC_Navbar.sNIHelp.Click += new EventHandler(this.sideNavItemEx_Click);

                uC_Navbar.sNIHelp.Name = "grp" + GroupName;

                uC_Navbar.sNIHelp.Tag = uC_Navbar.sNIHelp.Name;
                uC_Navbar.sNIHelp.Text = Pub.GetResText(formCode, "mnu" + GroupName, "");

                string bmpFiles = SystemInfo.AppPath + "www\\images\\" + uC_Navbar.sNIHelp.Name + ".ico";
                if (!File.Exists(bmpFiles))
                {
                    bmpFiles = SystemInfo.AppPath + "www\\images\\" + uC_Navbar.sNIHelp.Name + ".png";
                    if (!File.Exists(bmpFiles)) bmpFiles = SystemInfo.AppPath + "www\\images\\" + uC_Navbar.sNIHelp.Name + ".bmp";
                    if (!File.Exists(bmpFiles)) bmpFiles = SystemInfo.AppPath + "www\\images\\" + uC_Navbar.sNIHelp.Name + ".jpg";
                    if (File.Exists(bmpFiles))
                    {
                        uC_Navbar.sNIHelp.Image = Image.FromFile(bmpFiles);
                    }
                }

                WriteItem(itemPanelEx, "PubReportLog", GroupName);
                WriteItem(itemPanelEx, "HelpTopic", GroupName);
                WriteItem(itemPanelEx, "HelpAbout", GroupName);
            }
        }
        private void WriteGroup(FuncObject funcObj)
        {

            SideNavItem sideNavItemEx = null;
            ItemPanel itemPanelEx = null;

            if (funcObj.Name != "KQ")
            {
                itemPanelEx = new ItemPanel();
                itemPanelEx.BackgroundStyle.Class = "ItemPanelEx";
                itemPanelEx.BackgroundStyle.CornerType = eCornerType.Square;
                itemPanelEx.ContainerControlProcessDialogKey = true;
                itemPanelEx.Dock = DockStyle.Fill;
                itemPanelEx.DragDropSupport = true;
                itemPanelEx.LayoutOrientation = eOrientation.Vertical;
                itemPanelEx.Location = new Point(0, 0);
                itemPanelEx.Name = "grp" + funcObj.Name;
                itemPanelEx.TabIndex = 0;

                uC_PanelMuen.PanelMuen.Controls.Add(itemPanelEx);
                uC_PanelMuen.labelItem.Text = Pub.GetResText(formCode, "mnu" + funcObj.Name, "");

                sideNavItemEx = new SideNavItem();
                sideNavItemEx.Checked = false;
                sideNavItemEx.Name = "grp" + funcObj.Name;

                sideNavItemEx.Tag = funcObj.Name;
                sideNavItemEx.Text = funcObj.Text;
                sideNavItemEx.Tooltip = funcObj.Text;
                sideNavItemEx.Click += new EventHandler(this.sideNavItemEx_Click);

                string bmpFiles = SystemInfo.AppPath + "www\\images\\" + funcObj.Name + ".ico";
                if (File.Exists(bmpFiles))
                {
                    sideNavItemEx.Icon = new Icon(bmpFiles);
                }
                else
                {
                    bmpFiles = SystemInfo.AppPath + "www\\images\\" + funcObj.Name + ".png";
                    if (!File.Exists(bmpFiles)) bmpFiles = SystemInfo.AppPath + "www\\images\\" + funcObj.Name + ".bmp";
                    if (!File.Exists(bmpFiles)) bmpFiles = SystemInfo.AppPath + "www\\images\\" + funcObj.Name + ".jpg";
                    if (File.Exists(bmpFiles))
                    {
                        sideNavItemEx.ImageFixedSize = new Size(24, 24);
                        sideNavItemEx.Image = Image.FromFile(bmpFiles);
                    }
                }

                uC_Navbar.iPanMenu.Items.AddRange(new BaseItem[] { sideNavItemEx });
            }

            FuncSubObject funcSubObj;
            ButtonItem btn;
            for (int i = 0; i < funcObj.SubCount; i++)
            {
                funcSubObj = funcObj.SubGet(i);
                if (funcSubObj.IsLine == 2)
                {

                    itemPanelEx = new ItemPanel();
                    itemPanelEx.BackgroundStyle.Class = "ItemPanelEx";
                    itemPanelEx.BackgroundStyle.CornerType = eCornerType.Square;
                    itemPanelEx.ContainerControlProcessDialogKey = true;
                    itemPanelEx.Dock = DockStyle.Fill;
                    itemPanelEx.DragDropSupport = true;
                    itemPanelEx.LayoutOrientation = eOrientation.Vertical;
                    itemPanelEx.Location = new Point(0, 0);
                    itemPanelEx.Name = "grp" + funcSubObj.Name;
                    itemPanelEx.TabIndex = 0;

                    uC_PanelMuen.PanelMuen.Controls.Add(itemPanelEx);
                    itemPanelEx.Visible = false;
                    sideNavItemEx = new SideNavItem();
                    sideNavItemEx.Checked = false;
                    sideNavItemEx.Name = "grp" + funcSubObj.Name;

                    sideNavItemEx.Tag = funcObj.Name;
                    sideNavItemEx.Text = funcSubObj.Text;
                    sideNavItemEx.Tooltip = funcSubObj.Text;
                    sideNavItemEx.Click += new EventHandler(this.sideNavItemEx_Click);
                    string bmpFiles = SystemInfo.AppPath + "www\\images\\" + funcSubObj.Name + ".ico";
                    if (File.Exists(bmpFiles))
                    {
                        sideNavItemEx.Icon = new Icon(bmpFiles);
                    }
                    else
                    {
                        bmpFiles = SystemInfo.AppPath + "www\\images\\" + funcSubObj.Name + ".png";
                        if (!File.Exists(bmpFiles)) bmpFiles = SystemInfo.AppPath + "www\\images\\" + funcSubObj.Name + ".bmp";
                        if (!File.Exists(bmpFiles)) bmpFiles = SystemInfo.AppPath + "www\\images\\" + funcSubObj.Name + ".jpg";
                        if (File.Exists(bmpFiles))
                        {
                            sideNavItemEx.ImageFixedSize = new Size(24, 24);
                            sideNavItemEx.Image = Image.FromFile(bmpFiles);
                        }
                    }

                    uC_Navbar.iPanMenu.Items.AddRange(new BaseItem[] { sideNavItemEx });

                    continue;
                }
                if (funcSubObj.IsLine == 0 || funcSubObj.IsLine == 1)
                {

                    if (funcObj.Name == "KQ")
                    {
                        itemPanelEx = null;
                        sideNavItemEx = null;
                    }

                }

                btn = new ButtonItem();
                btn.ButtonStyle = eButtonStyle.ImageAndText;
                btn.Tag = funcSubObj.Name;
                btn.Text = funcSubObj.Text;
                btn.Tooltip = btn.Text;
                SetGroupButtonItemStyle(btn);
                string bmpFile = SystemInfo.AppPath + "www\\images\\" + funcSubObj.Name + ".ico";
                if (File.Exists(bmpFile))
                {
                    btn.Icon = new Icon(bmpFile);
                }
                else
                {
                    bmpFile = SystemInfo.AppPath + "www\\images\\" + funcSubObj.Name + ".png";
                    if (!File.Exists(bmpFile)) bmpFile = SystemInfo.AppPath + "www\\images\\" + funcSubObj.Name + ".bmp";
                    if (!File.Exists(bmpFile)) bmpFile = SystemInfo.AppPath + "www\\images\\" + funcSubObj.Name + ".jpg";
                    if (File.Exists(bmpFile))
                    {
                        btn.ImageFixedSize = new Size(24, 24);
                        btn.Image = Image.FromFile(bmpFile);
                    }
                }

                btn.Click += new EventHandler(this.ButtonItem_Click);
                if (itemPanelEx != null)
                {
                    itemPanelEx.Items.AddRange(new BaseItem[] { btn });
                    btn.Parent.Name = "grp" + funcSubObj.Name;
                    btn.Parent.Tag = funcObj.Name;
                    btn.Parent.Text = funcSubObj.Text;
                }
            }
            if (sideNavItemEx != null)
            {
                uC_Navbar.iPanMenu.Items.AddRange(new BaseItem[] { sideNavItemEx });
            }

        }

        private void sideNavItemEx_Click(object sender, EventArgs e)
        {
            if (sender is SideNavItem)
            {
                SideNavItem btn = (SideNavItem)sender;
                for (int i = 0; i < uC_Navbar.iPanMenu.Items.Count; i++)
                {
                    uC_Navbar.iPanMenu.Items[i].Enabled = true;
                    if (uC_Navbar.iPanMenu.Items[i].Name == btn.Name)
                    {
                        btn.Enabled = false;
                    }
                }
                for (int i = 0; i < uC_PanelMuen.PanelMuen.Controls.Count; i++)
                {
                    uC_PanelMuen.PanelMuen.Controls[i].Visible = false;

                    if (uC_PanelMuen.PanelMuen.Controls[i].Name == btn.Name)
                    {
                        uC_PanelMuen.PanelMuen.Controls[i].Visible = true;
                        uC_PanelMuen.labelItem.Text = Pub.GetResText(formCode, "mnu" + btn.Name.Substring(3), "");
                    }
                }

            }

            if (sender is ItemPanel)
            {
                ItemPanel btn = (ItemPanel)sender;
                for (int i = 0; i < uC_Navbar.iPanMenu.Items.Count; i++)
                {
                    uC_Navbar.iPanMenu.Items[i].Enabled = true;
                    if (uC_Navbar.iPanMenu.Items[i].Name == btn.Name)
                    {
                        btn.Enabled = false;
                    }
                }
                for (int i = 0; i < uC_PanelMuen.PanelMuen.Controls.Count; i++)
                {
                    uC_PanelMuen.PanelMuen.Controls[i].Visible = false;

                    if (uC_PanelMuen.PanelMuen.Controls[i].Name == btn.Name)
                    {
                        uC_PanelMuen.PanelMuen.Controls[i].Visible = true;
                        uC_PanelMuen.labelItem.Text = Pub.GetResText(formCode, "mnu" + btn.Name.Substring(3), "");
                    }

                }

            }

            if (sender is LabelX)
            {
                LabelX btn = (LabelX)sender;
                for (int i = 0; i < uC_Navbar.iPanMenu.Items.Count; i++)
                {
                    uC_Navbar.iPanMenu.Items[i].Enabled = true;
                    if (uC_Navbar.iPanMenu.Items[i].Name == btn.Name)
                    {
                        btn.Enabled = false;
                    }
                }
                for (int i = 0; i < uC_PanelMuen.PanelMuen.Controls.Count; i++)
                {
                    uC_PanelMuen.PanelMuen.Controls[i].Visible = false;
                    if (uC_PanelMuen.PanelMuen.Controls[i].Name == btn.Name)
                    {
                        uC_PanelMuen.PanelMuen.Controls[i].Visible = true;
                        uC_PanelMuen.labelItem.Text = Pub.GetResText(formCode, "mnu" + btn.Name.Substring(3), "");
                    }
                }
            }

            uC_PanelMuen.Visible = true;
        }

        private void InitIconLI()
        {
            string bmpFile = "";
            if (SystemInfo.IsZhNeutral)
            {
                bmpFile = SystemInfo.AppPath + "www\\images\\logoZHLi.png";
                if (!File.Exists(bmpFile)) bmpFile = SystemInfo.AppPath + "www\\images\\logoZHLi.bmp";
                if (!File.Exists(bmpFile)) bmpFile = SystemInfo.AppPath + "www\\images\\logoZHLi.jpg";

            }
            else
            {
                bmpFile = SystemInfo.AppPath + "www\\images\\logoLi.png";
                if (!File.Exists(bmpFile)) bmpFile = SystemInfo.AppPath + "www\\images\\logoLi.bmp";
                if (!File.Exists(bmpFile)) bmpFile = SystemInfo.AppPath + "www\\images\\logoLi.jpg";

            }
            if (File.Exists(bmpFile))
            {
                pBICON.Image = Image.FromFile(bmpFile);
            }

        }

        private void InitHome()
        {
            InitIconLI();
            int start = 1;
            //MenuBar.Visible = false;
            axRealSvr.Visible = false;
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            for (int i = start; i < SystemInfo.funcList.Count; i++)
            {
                WriteGroup(SystemInfo.funcList[i]);
            }
            WriteGroup("SY");
            WriteGroup("Help");

            InitOnline();
            //office2016.PerformClick();

            ThreadPool.SetMaxThreads(100, 100);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessFile));
            //自动导出txt越南定制
            // ThreadPool.QueueUserWorkItem(new WaitCallback(SaveTxtFile));
        }
        #region 自动导出txt越南定制
        private static object obj = new object();
        public static bool isSaveTxt = true;
        public static bool isSaveTxtTT = false;
        public static int SaveTxtCount = 0;

        private void SaveTxtFile(object state)
        {
            while (true)
            {
                if(isSaveTxt)
                {
                    if (SystemInfo.IsZDTxtTime)
                    {
                        if (SystemInfo.ZDTxtTime.Equals(DateTime.Now.ToString("HH:mm")))
                        {
                            SaveTxtCount = 0;
                            isSaveTxt = false;
                            isSaveTxtTT = true;
                            SaveRealDataToTxt();
                        }
                    }
                }
                if(isSaveTxtTT)
                {
                    SaveTxtCount++;
                    if(SaveTxtCount>60)
                    {
                        isSaveTxt = true;
                        isSaveTxtTT = false;
                    }
                }

                Thread.Sleep(1000);
            }
        }

        private void SaveRealDataToTxt()
        {
            lock (obj)
            {
                string MacSN = "";
                string KQDate = "";
                string KQTime = "";
                string FingerNo = "";
                string EmpNo = "";
                DataTableReader dr = null;
                DateTime dateTime = DateTime.Now;
                string startDate = dateTime.AddDays(-1).ToString(SystemInfo.SQLDateFMT) +" "+ SystemInfo.ZDTxtTime;
                string EndDate = dateTime.ToString(SystemInfo.SQLDateFMT) + " " + SystemInfo.ZDTxtTime;
                string path = SystemInfo.ZDTxtPath + "\\" + dateTime.ToString(SystemInfo.SQLDateymd) + ".txt";
                StreamWriter swData = new StreamWriter(path, true, System.Text.Encoding.Default);

                string sql = Pub.GetSQL(DBCode.DB_000214, new string[] { "13", startDate, EndDate });
                try
                {
                    DataTable dtData = SystemInfo.db.GetDataTable(sql);
                    if (dtData == null) return;

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        MacSN = dtData.Rows[i]["MacSN"].ToString();
                        if(!string.IsNullOrEmpty(dtData.Rows[i]["KQDateTime"].ToString()))
                        {
                            KQDate = (Convert.ToDateTime(dtData.Rows[i]["KQDateTime"].ToString())).ToString(SystemInfo.SQLDateTMF);
                            KQTime = (Convert.ToDateTime(dtData.Rows[i]["KQDateTime"].ToString())).ToString(SystemInfo.SQLDatehms);
                        }
                        EmpNo = dtData.Rows[i]["EmpNo"].ToString();
                        FingerNo = "";
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "12", EmpNo }));
                        if(dr.Read())
                        {
                            FingerNo = dr["FingerNo"].ToString();
                        }
                        dr.Close();

                        string dataStr = string.Format("{0}\t{1}\t{2}\t'{3}\r\n", MacSN.PadLeft(2, '0'), KQDate,
                        KQTime, FingerNo.PadLeft(10, '0'));
                        swData.Write(dataStr);
                    }
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
                finally
                {
                    if (dr != null)
                        dr.Close();

                    swData.Dispose();
                    swData.Close();
                }

            }
        }
        #endregion
        private void ProcessFile(object state)
        {
            while (true)
            {
                if (isPanelMuenVisible && !isMove)
                {
                    if (MouseButtons == MouseButtons.Left)
                    {
                        updatePanelVisible("");
                    }
                }

                Thread.Sleep(100);
            }
        }

        public void updatePanelVisible(string msg)
        {
            if (uC_PanelMuen.InvokeRequired)
            {
                OutDelegate outdelegate = new OutDelegate(updatePanelVisible);
                this.BeginInvoke(outdelegate, new object[] { msg });
                return;
            }
            if (isPanelMuenVisible && uC_PanelMuen.Visible && !isMove)
            {
                if (MousePosition.X > (LocationOnClient(uC_PanelMuen).X + uC_PanelMuen.Width) + 10
                    && MousePosition.X < (LocationOnClient(dockSite9).X + dockSite9.Width)
                    && MousePosition.Y > LocationOnClient(uC_PanelMuen).Y + 10
                     && MousePosition.Y < (LocationOnClient(statusBar).Y + statusBar.Height + statusBar.Height))
                {
                    uC_PanelMuen_CloseClick(null, null);
                }
            }
        }

        private Point LocationOnClient(Control c)
        {
            Point retval = new Point(0, 0);
            do
            {
                retval.Offset(c.Location);
                c = c.Parent;
            }
            while (c != null);
            return retval;
        }

        private void UpdateTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }

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

        private void InitGrid()
        {
            dataGrid.Columns.Clear();

            AddColumn(3, "SelectCheck", false, false, 1, 0);
            AddColumn(0, "MacSN", false, 0);
            AddColumn(0, "MacDesc", false, false, 0);
            AddColumn(0, "MacSeriesTypeId", true, false, 0);
            AddColumn(0, "MacSeriesTypeName", false, false, 0);
            AddColumn(0, "MacTypeID", true, false, 0);
            AddColumn(0, "MacTypeName", true, false, 0);
            AddColumn(0, "MacConnType", false, false, 0);
            AddColumn(0, "MacConnectState", false, false, 0);
            AddColumn(0, "MacDefenseState", true, false, 0);
            AddColumn(0, "MacIP", false, false, 0);
            AddColumn(0, "MacPort", false, false, 0);
            AddColumn(0, "MacConnPWD", true, false, 0);
            AddColumn(1, "IsGPRS", false, false, 1, 60);

            AddColumn(0, "MacMANAGERS", false, false, 0);
            AddColumn(0, "MacUSERS", false, false, 0);
            AddColumn(0, "MacFPS", false, false, 0);
            AddColumn(0, "MacFaceS", false, false, 0);
            AddColumn(0, "MacPSWS", false, false, 0);
            AddColumn(0, "MacCARDS", false, false, 0);
            AddColumn(0, "MacPALMVEINS", false, false, 0);
            AddColumn(0, "MacGLOGS", false, false, 0);
            AddColumn(0, "MacAGLOGS", false, false, 0);
            AddColumn(0, "DoorState", false, false, 0);
            AddColumn(0, "MacSeriesUserName", true, false, 0);
            AddColumn(0, "DevGroupID", true, false, 0);
            AddColumn(0, "DevGroupName", false, false, 0);

            AddColumn(realGrid, 0, "CardTime", false, false, 1, 120);
            AddColumn(realGrid, 0, "MacSN", false, false, 0, 60);
            AddColumn(realGrid, 0, "FingerNo", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpNo", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpName", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartID", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartName", false, false, 0, 80);
            AddColumn(realGrid, 0, "VerifyMode", false, false, 1, 0);
            //AddColumn(realGrid, 0, "InOutMode", !SystemInfo.AllowInOutMode, false, 1, 0);
            AddColumn(realGrid, 0, "InOutMode", false, false, 1, 0);
            AddColumn(realGrid, 0, "MacDesc", false, false, 0, 100);
            AddColumn(realGrid, 0, "GUID", true, false, 1, 0);
            AddColumn(realGrid, 0, "MacDoorStateTime", false, false, 1, 100);
            AddColumn(realGrid, 1, "IsAlarm", true, false, 1, 0);
            //开门
            AddColumn(DoorGrid, 0, "DoorTime", false, false, 1, 120);
            AddColumn(DoorGrid, 0, "MacSN", false, false, 0, 60);
            AddColumn(DoorGrid, 0, "MacDesc", false, false, 0, 100);
            AddColumn(DoorGrid, 0, "InOutMode", false, false, 1, 0);
            AddColumn(DoorGrid, 0, "GUID", true, false, 1, 0);
            AddColumn(DoorGrid, 0, "EmpNoOne", false, false, 1, 120);
            AddColumn(DoorGrid, 0, "EmpNoTwo", false, false, 1, 120);
            AddColumn(DoorGrid, 0, "EmpNoTree", false, false, 1, 120);
            AddColumn(DoorGrid, 0, "EmpNoFour", false, false, 1, 120);
            AddColumn(DoorGrid, 0, "EmpNoFive", false, false, 1, 120);

            //报警
            AddColumn(alarmGrid, 0, "AlarmTime", false, false, 1, 120);
            AddColumn(alarmGrid, 0, "MacSN", false, false, 0, 60);
            AddColumn(alarmGrid, 0, "MacDesc", false, false, 0, 100);
            AddColumn(alarmGrid, 0, "AlarmMode", false, false, 1, 100);

            AddColumn(alarmGrid, 0, "GUID", true, false, 1, 0);

            if (SystemInfo.ShowMJ == 0)
            {
                dataGrid.Columns[23].Visible = false;
                realGrid.Columns[8].Visible = false;
                realGrid.Columns[11].Visible = false;
                tabOpenDoorlog.Visible = false;
                tabAlarmLog.Visible = false;

            }

            InitOnline();

        }

        private void InitDeviceDefine()
        {
            FuncObject funcObj = new FuncObject();
            funcObj.Name = "DI_DI";
            funcObj.Text = SystemInfo.res.GetResText(formCode, "TitleBar", "");
            funcObj.SubAdd("ItemAdd", SystemInfo.res.GetResText(formCode, "ItemAdd", ""), 0, false);
            funcObj.SubAdd("ItemEdit", SystemInfo.res.GetResText(formCode, "ItemEdit", ""), 0, false);
            funcObj.SubAdd("ItemDelete", SystemInfo.res.GetResText(formCode, "ItemDelete", ""), 0, false);
            funcObj.SubAdd("ItemDevSet", SystemInfo.res.GetResText(formCode, "ItemDevSet", ""), 0, false);
            funcObj.SubAdd("mnuPubReportLog", SystemInfo.res.GetResText(formCode, "mnuPubReportLog", ""), 0, false);
            funcObj.SubAdd("ItemTAG1", SystemInfo.res.GetResText(formCode, "ItemTAG1", ""), 0, false);
            funcObj.SubAdd("ItemTAG2", SystemInfo.res.GetResText(formCode, "ItemTAG2", ""), 0, false);
            funcObj.SubAdd("ItemTAG3", SystemInfo.res.GetResText(formCode, "ItemTAG3", ""), 0, false);
            funcObj.SubAdd("ItemTAG4", SystemInfo.res.GetResText(formCode, "ItemTAG4", ""), 0, false);
            funcObj.SubAdd("ItemDownload", SystemInfo.res.GetResText(formCode, "ItemDownload", ""), 0, false);
            funcObj.SubAdd("ItemDownloadUSB", SystemInfo.res.GetResText(formCode, "ItemDownloadUSB", ""), 0, false);
            funcObj.SubAdd("ItemUpload", SystemInfo.res.GetResText(formCode, "ItemUpload", ""), 0, false);
            funcObj.SubAdd("ItemUploadUSB", SystemInfo.res.GetResText(formCode, "ItemUploadUSB", ""), 0, false);
            funcObj.SubAdd("ItemClearData", SystemInfo.res.GetResText(formCode, "ItemClearData", ""), 0, false);
            funcObj.SubAdd("ItemClearManager", SystemInfo.res.GetResText(formCode, "ItemClearManager", ""), 0, false);
            funcObj.SubAdd("ItemClearInfo", SystemInfo.res.GetResText(formCode, "ItemClearInfo", ""), 0, false);
            funcObj.SubAdd("ItemClearInfoDim", SystemInfo.res.GetResText(formCode, "ItemClearInfoDim", ""), 0, false);
            funcObj.SubAdd("ItemInitDevice", SystemInfo.res.GetResText(formCode, "ItemInitDevice", ""), 0, false);
            funcObj.SubAdd("ItemGetAllData", SystemInfo.res.GetResText(formCode, "ItemGetAllData", ""), 0, false);
            funcObj.SubAdd("ItemUSBData", SystemInfo.res.GetResText(formCode, "ItemUSBData", ""), 0, false);
            funcObj.SubAdd("ItemUSBText", SystemInfo.res.GetResText(formCode, "ItemUSBText", ""), 0, false);
            funcObj.SubAdd("ItemTextFormat", SystemInfo.res.GetResText(formCode, "ItemTextFormat", ""), 0, false);
            SystemInfo.funcList.Add(funcObj);
        }
        /// <summary>
        /// 初始化设备在线状态
        /// </summary>
        private void InitOnline()
        {
            DataTableReader dr = null;
            string MacSNo = "";
            string Offline = Pub.GetResText(formCode, "Offline", "");
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "0" }));
                while (dr.Read())
                {
                    MacSNo = dr["MacSN"].ToString();
                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "305", Offline, MacSNo }));
                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "6", "4", MacSNo }));
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

        protected override void InitForm()
        {
            Pub.SetFormAppIcon(this);
            DateTimeFormatInfo fmtInfo = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            LocalFormat = "dddd  " + fmtInfo.LongDatePattern + " " + fmtInfo.LongTimePattern;
            formCode = "Main";
            InitGrid();

            base.InitForm();

            SetControlsText(dotNetBarManager.Bars[0]);
            TitleBar.Text = Pub.GetResText(formCode, TitleBar.Name, "");


            // ExpBar.Font = this.Font;
            // TitleBar.Font = this.Font;

            ToolStripMenuItem item;
            for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
            {
                if (ItemTAGExt.DropDownItems[i] is ToolStripMenuItem)
                {
                    item = (ToolStripMenuItem)ItemTAGExt.DropDownItems[i];
                    item.Text = Pub.GetResText(formCode, item.Name, "");
                }
            }
            StrPosition = Pub.GetResText(formCode, "ItemPosition", "");
            StrReading = Pub.GetResText(formCode, "MsgReadingData", "");
            StrReadEnd = Pub.GetResText(formCode, "MsgReadEndData", "");

            switch (SystemInfo.DBType)
            {
                case 0:
                    MDICaption = "(Access)";
                    break;
                case 1:
                    MDICaption = "(SQL SERVER)";
                    break;
                case 2:
                    MDICaption = "(MSDE)";
                    break;
                default:
                    MDICaption = "";
                    break;
            }
            MDICaption = SystemInfo.AppTitle + MDICaption + " " + SystemInfo.AppVersion;
            if (SystemInfo.CustomerName != "") MDICaption = MDICaption + "[" + SystemInfo.CustomerName + "]";
            this.Text = MDICaption;

            SystemInfo.SystemIsExit = false;
            SystemInfo.MainHandle = this.Handle;
            lblUser.Text = Pub.GetResText("", lblUser.Name, "") + OprtInfo.OprtNoAndName;
            SystemInfo.funcList.Clear();
            int itemIndex = 1;
            InitDeviceDefine();
            LoadDll(ref objRS, ref tpRS, SystemInfo.NameSpace + ".RS.dll", ref itemIndex, mnuRS_Click);
            if (SystemInfo.ShowMJ == 1) //常规设备
                LoadDll(ref objMJ, ref tpMJ, SystemInfo.NameSpace + ".MJ.dll", ref itemIndex, mnuMJ_Click);

            if (SystemInfo.ShowSEA == 1)  //海系设备
                LoadDll(ref objSEA, ref tpSEA, SystemInfo.NameSpace + ".SEA.dll", ref itemIndex, mnuSEA_Click);

            if (SystemInfo.ShowSTAR == 1) //星系设备
                LoadDll(ref objSTAR, ref tpSTAR, SystemInfo.NameSpace + ".STAR.dll", ref itemIndex, mnuSTAR_Click);

            if (SystemInfo.ShowKQ == 1) //考勤模块
                LoadDll(ref objKQ, ref tpKQ, SystemInfo.NameSpace + ".KQ.dll", ref itemIndex, mnuKQ_Click);

            LoadDll(ref objRSReport, ref tpRSReport, "RSReport.dll", ref itemIndex, mnuRSReport_Click, false);

            if (SystemInfo.ShowKQ == 1) //考勤模块
                LoadDll(ref objKQReport, ref tpKQReport, "KQReport.dll", ref itemIndex, mnuKQReport_Click, false);

            if (SystemInfo.ShowMJ == 1)
                LoadDll(ref objMJReport, ref tpMJReport, SystemInfo.NameSpace + ".MJReport.dll", ref itemIndex, mnuMJReport_Click);

            if (SystemInfo.ShowSEA == 1)  //海系设备
                LoadDll(ref objSEAReport, ref tpSEAReport, "SEAReport.dll", ref itemIndex, mnuSEAReport_Click, false);

            if (SystemInfo.ShowSTAR == 1) //星系设备
                LoadDll(ref objSTARReport, ref tpSTARReport, "STARReport.dll", ref itemIndex, mnuSTARReport_Click, false);

            if (SystemInfo.ShowGZ == 1)  //工资管理
            {
                LoadDll(ref objGZ, ref tpGZ, SystemInfo.NameSpace + ".GZ.dll", ref itemIndex, mnuGZ_Click);
                LoadDll(ref objGZReport, ref tpGZReport, "GZReport.dll", ref itemIndex, mnuGZReport_Click, false);
            }


            if (objRSReport != null) SystemInfo.db.UpdateModuleResources(this.Text, objRSReport);
            if (objMJReport != null) SystemInfo.db.UpdateModuleResources(this.Text, objMJReport);
            if (objKQReport != null) SystemInfo.db.UpdateModuleResources(this.Text, objKQReport);
            if (objGZReport != null) SystemInfo.db.UpdateModuleResources(this.Text, objGZReport);
            if (objSEAReport != null) SystemInfo.db.UpdateModuleResources(this.Text, objSEAReport);
            if (objSTARReport != null) SystemInfo.db.UpdateModuleResources(this.Text, objSTARReport);
            SystemInfo.AllowMJ = true;
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "0" }));
                if (dr.Read())
                {
                    SystemInfo.DBVersion = dr["DBVer"].ToString() + ".";
                    DateTime dt = Convert.ToDateTime(dr["DBDate"]);
                    SystemInfo.DBVersion = SystemInfo.DBVersion + dt.ToString(SystemInfo.DateFormatDBVer);
                }
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            InitHome();

            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Width = rect.Width;
            this.Height = rect.Height;
            RefreshDevice();
            LoadTextFormat();
            ItemText.Text = AcPort.ToString();
            dtReal.Columns.Add("CardTime", typeof(string));
            dtReal.Columns.Add("MacSN", typeof(string));
            dtReal.Columns.Add("FingerNo", typeof(UInt32));
            dtReal.Columns.Add("EmpNo", typeof(string));
            dtReal.Columns.Add("EmpName", typeof(string));
            dtReal.Columns.Add("DepartID", typeof(string));
            dtReal.Columns.Add("DepartName", typeof(string));
            dtReal.Columns.Add("VerifyMode", typeof(string));
            dtReal.Columns.Add("InOutMode", typeof(string));
            dtReal.Columns.Add("MacDesc", typeof(string));
            dtReal.Columns.Add("GUID", typeof(string));
            dtReal.Columns.Add("MacDoorStateTime", typeof(string));
            dtReal.Columns.Add("IsAlarm", typeof(bool));
            realGrid.DataSource = dtReal;
            //开门记录

            dtDoorReal.Columns.Add("DoorTime", typeof(string));
            dtDoorReal.Columns.Add("MacSN", typeof(string));
            dtDoorReal.Columns.Add("MacDesc", typeof(string));
            dtDoorReal.Columns.Add("InOutMode", typeof(string));
            dtDoorReal.Columns.Add("GUID", typeof(string));
            dtDoorReal.Columns.Add("EmpNoOne", typeof(string));
            dtDoorReal.Columns.Add("EmpNoTwo", typeof(string));
            dtDoorReal.Columns.Add("EmpNoTree", typeof(string));
            dtDoorReal.Columns.Add("EmpNoFour", typeof(string));
            dtDoorReal.Columns.Add("EmpNoFive", typeof(string));
            DoorGrid.DataSource = dtDoorReal;

            //报警记录
            dtAlarmReal.Columns.Add("AlarmTime", typeof(string));
            dtAlarmReal.Columns.Add("MacSN", typeof(string));
            dtAlarmReal.Columns.Add("MacDesc", typeof(string));
            dtAlarmReal.Columns.Add("AlarmMode", typeof(string));
            dtAlarmReal.Columns.Add("GUID", typeof(string));
            alarmGrid.DataSource = dtAlarmReal;

            // UpdateTextPosition();
            bool IsMenuExpanded = SystemInfo.ini.ReadIni("Setup", "IsMenuExpanded", false);
            refreshPanMenu(IsMenuExpanded);

            bool isible = SystemInfo.ini.ReadIni("Setup", "IsClosed", false);
            uC_PanelMuen.Visible = isible;
            if (isible)
            {
                dockSite9.BringToFront();
                isPanelMuenVisible = false;
                uC_PanelMuen.btnAutoHide.Symbol = "58132";
            }
            else
            {
                uC_PanelMuen.BringToFront();
                isPanelMuenVisible = true;
                uC_PanelMuen.btnAutoHide.Symbol = "58133";
            }

            //ItemLabel2.Visible = SystemInfo.ShowSEA == 1;
            //ItemTextSea.Visible = SystemInfo.ShowSEA == 1;

            //ItemLabel3.Visible = SystemInfo.ShowSTAR == 1;
            //ItemTextStar.Visible = SystemInfo.ShowSTAR == 1;

            //加入注册
            RegisterInfo.Serial = SystemInfo.db.GetRegSerial();
            if (((objGZ != null) && (tpGZ != null)) || ((objSEA != null) && (tpSEA != null)) || ((objSTAR != null) && (tpSTAR != null)))
            {
                RegisterInfo.MustReg = true;
            }
            else
            {
                RegisterInfo.MustReg = false;
            }
            if (SystemInfo.AllowInOutMode) RegisterInfo.MustReg = false;

            if (RegisterInfo.MustReg) SystemInfo.db.IsRegister(true, "", "");
            SetMDICaption();
            string[] titleX = (this.Text).Split('(');
            lbTitleX.Text = titleX[0];
            lbTitleXV.Text = Pub.GetResText("About", "Version", "") + ": (" + titleX[1];
            lbTitleXV.Location = new Point(this.Width - lbTitleXV.Width - btnCloseX.Width * 5, 7);
            ItemFindText.ToolTipText = "";
            uC_PanelMuen.Width = SystemInfo.ini.ReadIni("Setup", uC_PanelMuen.Name, 218);
            uC_Navbar.Width = SystemInfo.ini.ReadIni("Setup", uC_Navbar.Name, uC_Navbar.Width);
            ItemFindText.ToolTipText = string.Format(Pub.GetResText(formCode, "MsgFindMacSN", ""),
            Pub.GetResText(formCode, "MacSN", ""),
            Pub.GetResText(formCode, "MacDesc", ""));
            this.Show();
            if (RegisterInfo.MustReg)
            {
                if (RegisterInfo.IsValid || RegisterInfo.IsTest) ShowRegister("SYRegister");
            }
        }

        protected override void FreeForm()
        {
            timer.Enabled = false;
            tpRS = null;
            objRS = null;
            tpRSReport = null;
            objRSReport = null;
            tpMJ = null;
            objMJ = null;
            tpMJReport = null;
            objMJReport = null;
            tpKQ = null;
            objKQ = null;
            tpKQReport = null;
            objKQReport = null;
            tpGZ = null;
            objGZ = null;
            tpGZReport = null;
            objGZReport = null;
            tpSEA = null;
            objSEA = null;
            tpSEAReport = null;
            objSEAReport = null;
            tpSTAR = null;
            objSTAR = null;
            tpSTARReport = null;
            objSTARReport = null;
            dtReal = null;
            SystemInfo.ini.WriteIni("Setup", uC_PanelMuen.Name, uC_PanelMuen.Width);
            SystemInfo.ini.WriteIni("Setup", uC_Navbar.Name, uC_Navbar.Width);

            if (uC_Navbar.sNISY.Text == "")
            {
                SystemInfo.ini.WriteIni("Setup", "IsMenuExpanded", true);
            }
            else
            {
                SystemInfo.ini.WriteIni("Setup", "IsMenuExpanded", false);
            }
            SystemInfo.ini.WriteIni("Setup", "IsClosed", uC_PanelMuen.Visible);
            SystemInfo.db.Close();
            base.FreeForm();
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!RegisterExit)
                {
                    if (Pub.MessageBoxShowQuestion(string.Format(Pub.GetResText(formCode, "MsgExitSystem", ""), MDICaption)))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                statusBar = null;
                SystemInfo.SystemIsExit = true;
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    this.MdiChildren[i].Dispose();
                }
                FreeForm();
                e.Cancel = false;
                Process.GetCurrentProcess().Kill();
                // Environment.Exit(1);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        private void InitTimerList()
        {
            connTimerList.Clear();
            DataTableReader dr = null;
            string isopen = "";
            string macsn = "";
            bool ret = false;
            if (dataGrid.RowCount > 0)
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "0" }));
                while (dr.Read())
                {
                    isopen = dr["IsTimerOpen"].ToString();
                    macsn = dr["MacSN"].ToString();
                    if (isopen == "1")
                    {
                        for (int i = 0; i < dataGrid.RowCount; i++)
                        {
                            if (dataGrid[1, i].Value.ToString() == macsn.ToString())
                            {
                                connTimerList.Add(RowDataToConnInfo(i));
                                SystemInfo.SetTimer = DateTime.Parse(dr["SetTimer"].ToString());
                                ret = true;
                            }

                        }

                    }

                }
                if (ret)
                {
                    SystemInfo.IsTimerOpen = true;
                    SystemInfo.TimerOpen = connTimerList;
                }

            }
        }
        #region 定时开门
        //private void Timer_Opendoor()
        //{
        //    if (SystemInfo.IsTimerOpen)
        //    {

        //        if (DateTime.Now >= SystemInfo.SetTimer)
        //        {
        //            SystemInfo.IsTimerOpen = false;
        //            bool state;
        //            string msg = "";
        //            string MacMsg = "";
        //            DateTime start = new DateTime();
        //            start = DateTime.Now;
        //            string ExecTimes = "";
        //            TDIConnInfo conn;

        //            for (int i = 0; i < SystemInfo.TimerOpen.Count; i++)
        //            {
        //                MacMsg = "";
        //                conn = SystemInfo.TimerOpen[i];
        //                RefreshMacMsg(Pub.GetResText("", "FK_DOOR_COMMNAD", "") + "[" + conn.MacSN.ToString() + "]......");
        //                DeviceObject.objFK623.InitConn(conn);
        //                if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
        //                DeviceObject.objFK623.EnableDevice(0);
        //                state = DeviceObject.objFK623.IsOpen;
        //                if (state)
        //                {
        //                    DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_CLOSED);
        //                    SystemInfo.isclose = true;
        //                    DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_CONTROLRESET);
        //                    SystemInfo.isclose = false;
        //                };
        //                ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);

        //                UpdateMacMsg(MacMsg + DeviceObject.objFK623.ErrMsg + ExecTimes, state);
        //                msg = msg + conn.MacSN.ToString() + ":" + MacMsg + DeviceObject.objFK623.ErrMsg + ";";
        //                DeviceObject.objFK623.EnableDevice(1);
        //                DeviceObject.objFK623.Close();
        //                Application.DoEvents();
        //                start = DateTime.Now;
        //                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "7", SystemInfo.SetTimer.ToString(SystemInfo.SQLDateTimeFMT), "0", conn.MacSN.ToString() }));
        //            }
        //            SystemInfo.db.WriteSYLog(Pub.GetResText("", "FK_DOOR_COMMNAD", ""), Pub.GetResText("", "FK_DOOR_COMMNAD", ""), msg);

        //        }
        //    }
        //}
        #endregion
        //监测在线状态

        public void TimerMonitoring()
        {
            if (isMonitoring)
            {
                TimerMonitoringCount = TimerMonitoringCount + 1;
                if (TimerMonitoringCount >= 90)
                {
                    for (int c = 0; c < monitoringsList.Count; c++)
                    {
                        if (c < dataGrid.Rows.Count)
                        {
                            if (dataGrid[1, c].Value.ToString() == monitoringsList[c].MacSN)
                            {
                                if (monitoringsList[c].BakNo == 1)
                                {
                                    if (dataGrid[8, c].Value.ToString() == Pub.GetResText("", "Offline", ""))
                                    {
                                        for (int s = 0; s < panel5.Controls.Count; s++)
                                        {

                                            if (panel5.Controls[s].Name == "btn" + monitoringsList[c].MacSN)
                                            {
                                                panel5.Controls[s].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\1.jpg");
                                                break;
                                            }

                                        }
                                    }

                                    dataGrid[8, c].Value = Pub.GetResText("", "Online", "");
                                    dataGrid.Rows[c].Cells[6].Style.ForeColor = Color.Green;
                                    dataGrid.Rows[c].Cells[6].Style.SelectionForeColor = Color.Green;
                                }
                                else if (monitoringsList[c].BakNo == 0)
                                {
                                    if (dataGrid[8, c].Value.ToString() == Pub.GetResText("", "Online", ""))
                                    {
                                        for (int s = 0; s < panel5.Controls.Count; s++)
                                        {

                                            if (panel5.Controls[s].Name == "btn" + monitoringsList[c].MacSN)
                                            {
                                                panel5.Controls[s].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\4.jpg");
                                                break;
                                            }

                                        }
                                    }
                                    dataGrid[8, c].Value = Pub.GetResText("", "Offline", "");
                                    dataGrid.Rows[c].Cells[8].Style.ForeColor = Color.Red;
                                    dataGrid.Rows[c].Cells[8].Style.SelectionForeColor = Color.Red;
                                }
                            }
                            monitoringsList[c].BakNo = 0;
                        }

                    }
                    TimerMonitoringCount = 0;
                }
            }

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToString(LocalFormat);
            //TimerMonitoring();
            autoGetNewData();
        }
        private void autoGetNewData()
        {
            if (!isMonitoring)
            {
                DateTime time = DateTime.Now;

                if (SystemInfo.ini.ReadIni("Public", "cbOne", "").Equals("1") && time.ToString(SystemInfo.SQLDatehms).Equals(SystemInfo.ini.ReadIni("Public", "Time_One", "")) && isGetNewData)
                {
                    isGetNewData = false;
                    if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG3", true)) return;
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetNewData", ""), 2);
                }
                else if (SystemInfo.ini.ReadIni("Public", "cbTwo", "").Equals("1") && time.ToString(SystemInfo.SQLDatehms).Equals(SystemInfo.ini.ReadIni("Public", "Time_Two", "")) && isGetNewData)
                {
                    isGetNewData = false;
                    if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG3", true)) return;
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetNewData", ""), 2);
                }
                else if (SystemInfo.ini.ReadIni("Public", "cbThree", "").Equals("1") && time.ToString(SystemInfo.SQLDatehms).Equals(SystemInfo.ini.ReadIni("Public", "Time_Three", "")) && isGetNewData)
                {
                    isGetNewData = false;
                    if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG3", true)) return;
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetNewData", ""), 2);
                }
                else if (SystemInfo.ini.ReadIni("Public", "cbFour", "").Equals("1") && time.ToString(SystemInfo.SQLDatehms).Equals(SystemInfo.ini.ReadIni("Public", "Time_Four", "")) && isGetNewData)
                {
                    isGetNewData = false;
                    if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG3", true)) return;
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetNewData", ""), 2);
                }
                else if (SystemInfo.ini.ReadIni("Public", "cbFive", "").Equals("1") && time.ToString(SystemInfo.SQLDatehms).Equals(SystemInfo.ini.ReadIni("Public", "Time_Five", "")) && isGetNewData)
                {
                    isGetNewData = false;
                    if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG3", true)) return;
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetNewData", ""), 2);
                }
                else
                {
                    isGetNewData = true;
                }
            }
        }

        private void mnuRS_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
                ShowRS(((ToolStripItem)sender).Name.Substring(3));
            else
                ShowRS((ToolStripMenuItem)sender);
        }

        private void mnuRSReport_Click(object sender, EventArgs e)
        {
            ShowRSReport((ToolStripMenuItem)sender);
        }

        private void mnuMJ_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
                ShowMJ(((ToolStripItem)sender).Name.Substring(3));
            else
                ShowMJ((ToolStripMenuItem)sender);
        }

        private void mnuMJReport_Click(object sender, EventArgs e)
        {
            ShowMJReport((ToolStripMenuItem)sender);
        }

        private void mnuKQ_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
                ShowKQ(((ToolStripItem)sender).Name.Substring(3));
            else
                ShowKQ((ToolStripMenuItem)sender);
        }

        private void mnuKQReport_Click(object sender, EventArgs e)
        {
            ShowKQReport((ToolStripMenuItem)sender);
        }

        private void mnuGZ_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
                ShowGZ(((ToolStripItem)sender).Name.Substring(3));
            else
                ShowGZ((ToolStripMenuItem)sender);
        }
        private void mnuGZReport_Click(object sender, EventArgs e)
        {
            ShowGZReport((ToolStripMenuItem)sender);
        }
        private void mnuSEA_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
                ShowSEA(((ToolStripItem)sender).Name.Substring(3));
            else
                ShowSEA((ToolStripMenuItem)sender);
        }
        private void mnuSEAReport_Click(object sender, EventArgs e)
        {
            ShowSEAReport((ToolStripMenuItem)sender);
        }
        private void mnuSTAR_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
                ShowSTAR(((ToolStripItem)sender).Name.Substring(3));
            else
                ShowSTAR((ToolStripMenuItem)sender);
        }
        private void mnuSTARReport_Click(object sender, EventArgs e)
        {
            ShowSTARReport((ToolStripMenuItem)sender);
        }

        private void ButtonItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < uC_PanelMuen.PanelMuen.Controls.Count; i++)
            {
                if (uC_PanelMuen.PanelMuen.Controls[i].Name == "barMuen")
                    continue;
                uC_PanelMuen.PanelMuen.Controls[i].Enabled = false;
            }
            if (sender is ButtonItem)
            {
                ButtonItem btn = (ButtonItem)sender;
                if (btn.Tag.ToString() != "")
                {
                    string ModuleName = btn.Tag.ToString();
                    string Module = btn.Parent.Tag.ToString();
                    if (isPanelMuenVisible)
                    {
                        uC_PanelMuen.Visible = false;
                        for (int i = 0; i < uC_Navbar.iPanMenu.Items.Count; i++)
                        {
                            uC_Navbar.iPanMenu.Items[i].Enabled = true;
                        }
                    }
                    else
                    {
                        uC_PanelMuen.Visible = true;
                    }
                    ExecModule(ModuleName, Module);
                }
            }
            for (int i = 0; i < uC_PanelMuen.PanelMuen.Controls.Count; i++)
            {
                uC_PanelMuen.PanelMuen.Controls[i].Enabled = true;
            }
        }

        private DialogResult ExecShowFormDialog(Form frm)
        {
            return frm.ShowDialog();
        }

        private DialogResult ExecShowFormDialogEx(Form frm)
        {
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            frm.Left = rect.Left;
            frm.Top = rect.Top;
            frm.Width = rect.Width;
            frm.Height = rect.Height;
            return frm.ShowDialog();
        }
        private void ShowMDIForms(Form frm, string frmText)
        {
            if (frmText == "")
                frmText = Pub.GetResText(formCode, "mnu" + frm.Name.Substring(3), "");
            frm.Text = frmText;
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;

            frm.Left = rect.Left;
            frm.Top = rect.Top;
            frm.Width = rect.Width;
            frm.Height = rect.Height;

            frm.Show();
        }
        private void ShowMDIForm(Form frm, string frmText)
        {
            if (frmText == "")
                frmText = Pub.GetResText(formCode, "mnu" + frm.Name.Substring(3), "");
            frm.Text = frmText;
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;

            //frm.Left = rect.Left;
            //frm.Top = rect.Top;
            //frm.Width = rect.Width;
            //frm.Height = rect.Height;
            //frm.ShowDialog();
            addTabControl(frm.Name, frm.Text, bar1, frm);
        }

        private void selectBars(ref Bar objTabControl)
        {
            if (dotNetBarManager.Bars.Count > 0)
            {
                objTabControl = dotNetBarManager.Bars[0];
                if (!objTabControl.Visible)
                {
                    dotNetBarManager.Bars.Remove(dotNetBarManager.Bars[0]);
                    selectBars(ref objTabControl);
                }
            }
        }

        private void addTabControl(string MainTabControlKey, string MainTabControlName, Bar objTabControl, Form objfrm)
        {
            try
            {
                selectBars(ref objTabControl);

                if (ErgodicModiForm(MainTabControlKey, objTabControl))
                {
                    DockContainerItem tabPage = new DockContainerItem();
                    tabPage.Name = MainTabControlKey;
                    tabPage.Text = MainTabControlName;
                    tabPage.Visible = false;
                    tabPage.DefaultFloatingSize = new Size(640, 480);
                    tabPage.TextChanged += TabPage_TextChanged;
                    PanelDockContainer superTabControlPanel = new PanelDockContainer();
                    tabPage.Control = superTabControlPanel;
                    objfrm.Hide();
                    objfrm.TopLevel = false;
                    objfrm.Dock = DockStyle.Fill;
                    objfrm.FormBorderStyle = FormBorderStyle.None;
                    superTabControlPanel.Controls.Add(objfrm);
                    tabPage.Visible = true;

                    objfrm.Show();
                    objTabControl.Items.AddRange(new BaseItem[] { tabPage });

                    objTabControl.SelectedDockContainerItem = tabPage;
                    objTabControl.SelectedDockContainerItem.Name = MainTabControlKey;
                }

            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        private void TabPage_TextChanged(object sender, EventArgs e)
        {
            int i = 0;

            DockContainerItem item = (DockContainerItem)sender;

            foreach (Bar con in dotNetBarManager.Bars)
            {
                i = 0;

                foreach (DockContainerItem it in con.Items)
                {
                    if (it.Name == item.Name)
                    {
                        if (i == 0)
                        {
                            i++;
                        }
                        if (con.Items.Count > 1)
                        {
                            con.SelectedDockContainerItem = (DockContainerItem)con.Items[i - 1];
                            con.Items.Remove(it);
                        }
                        else
                        {
                            dotNetBarManager.RemoveBar(con);
                        }

                        return;
                    }
                    i++;
                }

            }
        }

        private Boolean ErgodicModiForm(string MainTabControlKey, Bar objTabControl)
        {
            bool ret = true;
            //遍历选项卡判断是否存在该子窗体
            foreach (Bar con in dotNetBarManager.Bars)
            {
                if (con.Name == MainTabControlKey)
                {
                    foreach (DockContainerItem item in con.Items)
                    {
                        DockContainerItem tab = (DockContainerItem)item;
                        if (tab.Name == MainTabControlKey)
                        {
                            con.SelectedDockContainerItem = tab;
                            ret = false;
                            break;
                        }
                    }
                }
                objTabControl = con;
                foreach (DockContainerItem item in objTabControl.Items)
                {
                    DockContainerItem tab = (DockContainerItem)item;
                    if (tab.Name == MainTabControlKey)
                    {
                        objTabControl.SelectedDockContainerItem = tab;
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }

        private void SetMDICaption()
        {
            this.Text = MDICaption;
            if (RegisterInfo.MustReg)
            {
                this.Text = this.Text + " - " + RegisterInfo.StateText;
            }
        }

        private void ShowSY(string ModuleName)
        {
            if (!SystemInfo.db.CheckOprtRole("SYPower", true)) return;
            string text = Pub.GetResText(formCode, "mnu" + ModuleName, "");
            switch (ModuleName)
            {
                case "SYPower":
                    ShowMDIForm(new frmSYPower(), text);
                    break;
                case "SYDataBack":
                    ExecShowFormDialog(new frmSYDataBack(text));
                    break;
                case "SYDataRest":
                    ExecShowFormDialog(new frmSYDataRest(text));
                    break;
                case "SYDataUpdate":
                    ExecShowFormDialog(new frmSYDataUpdate(text));
                    break;
                case "SYDataType":
                    ExecShowFormDialog(new frmSYDataType(text));
                    break;
                case "SYDataClear":
                    ExecShowFormDialog(new frmSYDataClear(text));
                    break;
                case "SYOption":
                    ExecShowFormDialog(new frmSYOption(text));
                    break;
                case "SYSetPort":
                    ExecShowFormDialog(new frmSYSetPort(text));
                    break;
            }

        }

        private void ShowSYPassword(string ModuleName)
        {
            ExecShowFormDialog(new frmSYPassword(Pub.GetResText(formCode, "mnu" + ModuleName, "")));
        }

        private void ShowRegister(string ModuleName)
        {
            string text = Pub.GetResText(formCode, "mnu" + ModuleName, "");
            if (ExecShowFormDialog(new frmSYRegister(text)) == DialogResult.OK)
            {
                RegisterExit = true;
                SystemInfo.IsRestart = true;
                SystemInfo.Restart = 1;
                string strAppFileName = Process.GetCurrentProcess().MainModule.FileName;
                Process myNewProcess = new Process();
                myNewProcess.StartInfo.FileName = strAppFileName;
                myNewProcess.StartInfo.WorkingDirectory = Application.ExecutablePath;
                myNewProcess.Start();
                Application.Exit();
                SystemInfo.Restart = 0;
            }
        }


        private void ShowSYDataCompact()
        {
            if (!SystemInfo.db.CheckOprtRole("SYDataCompact", true)) return;
            if (Pub.ShowMessageDialog(Pub.GetResText(formCode, "MsgCompacting", ""), "CompactDB"))
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCompactSuccess", ""), MessageBoxIcon.Information);
            }
        }

        private void ShowAbout(string ModuleName)
        {
            string text = Pub.GetResText(formCode, "mnu" + ModuleName, "");
            ExecShowFormDialog(new frmAbout(text));
        }

        private void ShowHelp(string ModuleName)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "mnu" + ModuleName, true)) return;
            string text = Pub.GetResText(formCode, "mnu" + ModuleName, "");
            addTabControl("mnu" + ModuleName, text, bar1, new frmPubReportLog(text));
            //frm.Show();
        }

        private void ShowHelpTopic()
        {
            string HelpFolder = "";
            if (SystemInfo.LangName == "CHT")
            {
                HelpFolder = SystemInfo.AppPath + "\\Help\\help_TW.chm";
            }
            else if (SystemInfo.LangName == "CHS")
            {
                HelpFolder = SystemInfo.AppPath + "\\Help\\help_ZH.chm";
            }
            else
            {
                HelpFolder = SystemInfo.AppPath + "\\Help\\help_EN.chm";
            }
            try
            {
                //if (Directory.Exists(HelpFolder))             
                //  System.Diagnostics.Process.Start(HelpFolder);
                Help.ShowHelp(this, HelpFolder);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        private bool ShowRS(ToolStripMenuItem item)
        {
            if (!SystemInfo.db.CheckOprtRole(item.Name.Substring(3), true)) return false;
            return ShowDllForm(tpRS, item.Tag.ToString(), item.Text);
        }

        public bool ShowRS(string ItemName)
        {
            if (!SystemInfo.db.CheckOprtRole(ItemName, true)) return false;
            return ShowDllForm(tpRS, ItemName, "");
        }

        private bool ShowRSReport(ToolStripMenuItem item)
        {
            return ShowDllForm(tpRSReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowMJ(ToolStripMenuItem item)
        {
            if (!SystemInfo.db.CheckOprtRole(item.Name.Substring(3), true)) return false;
            return ShowDllForm(tpMJ, item.Tag.ToString(), item.Text);
        }

        private bool ShowMJ(string ItemName)
        {
            if (!SystemInfo.db.CheckOprtRole(ItemName, true)) return false;
            return ShowDllForm(tpMJ, ItemName, "");
        }

        private bool ShowMJReport(ToolStripMenuItem item)
        {
            return ShowDllForm(tpMJReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowMJReport(string ItemName)
        {
            if (!SystemInfo.db.CheckOprtRole(ItemName, true)) return false;
            return ShowDllForm(tpMJReport, ItemName, "");
        }

        private bool ShowKQ(ToolStripMenuItem item)
        {
            if (!SystemInfo.db.CheckOprtRole(item.Name.Substring(3), true)) return false;
            return ShowDllForm(tpKQ, item.Tag.ToString(), item.Text);
        }


        private bool ShowKQ(string ItemName)
        {
            if (!SystemInfo.db.CheckOprtRole(ItemName, true)) return false;
            return ShowDllForm(tpKQ, ItemName, "");
        }

        private bool ShowKQReport(ToolStripMenuItem item)
        {
            return ShowDllForm(tpKQReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowGZ(ToolStripMenuItem item)
        {
            if (!SystemInfo.db.CheckOprtRole(item.Name.Substring(3), true)) return false;
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            return ShowDllForm(tpGZ, item.Tag.ToString(), item.Text);
        }

        private bool ShowGZ(string ItemName)
        {
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            if (!SystemInfo.db.CheckOprtRole(ItemName, true)) return false;
            return ShowDllForm(tpGZ, ItemName, "");
        }
        private bool ShowGZReport(ToolStripMenuItem item)
        {
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            return ShowDllForm(tpGZReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowSEA(ToolStripMenuItem item)
        {
            if (!SystemInfo.db.CheckOprtRole(item.Name.Substring(3), true)) return false;
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            return ShowDllForm(tpSEA, item.Tag.ToString(), item.Text);
        }
        private bool ShowSEA(string ItemName)
        {
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            if (!SystemInfo.db.CheckOprtRole(ItemName, true)) return false;
            return ShowDllForm(tpSEA, ItemName, "");
        }

        private bool ShowSEAReport(ToolStripMenuItem item)
        {
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            return ShowDllForm(tpSEAReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowSTAR(ToolStripMenuItem item)
        {
            if (!SystemInfo.db.CheckOprtRole(item.Name.Substring(3), true)) return false;
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            return ShowDllForm(tpSTAR, item.Tag.ToString(), item.Text);
        }
        private bool ShowSTAR(string ItemName)
        {
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            if (!SystemInfo.db.CheckOprtRole(ItemName, true)) return false;
            return ShowDllForm(tpSTAR, ItemName, "");
        }

        private bool ShowSTARReport(ToolStripMenuItem item)
        {
            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
            {
                if (RegisterInfo.EndDate < DateTime.Now)
                {
                    Pub.MessageBoxShow(RegisterInfo.StateText);
                    return false;
                }
            }
            return ShowDllForm(tpSTARReport, item.Tag.ToString(), item.Text);
        }

        public void ExecModule(string ModuleName, string Module)
        {
            switch (Module.ToUpper())
            {
                case "":
                case "HELP":
                    switch (ModuleName)
                    {
                        case "PubReportLog":
                            ShowHelp(ModuleName);
                            break;
                        case "HelpTopic":
                            ShowHelpTopic();
                            break;
                        case "HelpAbout":
                            ShowAbout(ModuleName);
                            break;
                    }
                    break;
                case "SY":
                    switch (ModuleName)
                    {
                        case "SYPassword":
                            ShowSYPassword(ModuleName);
                            break;
                        case "SYRegister":
                            ShowRegister(ModuleName);
                            break;
                        case "SYDataCompact":
                            ShowSYDataCompact();
                            break;
                        case "KQInOutMode":
                            ShowKQ(ModuleName);
                            break;
                        default:
                            ShowSY(ModuleName);
                            break;
                    }
                    break;
                case "RS":
                    ShowRS(ModuleName);
                    break;
                case "MJ":
                    ShowMJ(ModuleName);

                    break;
                case "KQ":
                    ShowKQ(ModuleName);
                    break;
                case "GZ":
                    ShowGZ(ModuleName);
                    break;
                case "SEA":
                    ShowSEA(ModuleName);
                    break;
                case "STAR":
                    ShowSTAR(ModuleName);
                    break;
                case "MJREPORT":
                    ShowMJReport(ModuleName);
                    break;
                case "EXT":
                    this.Close();
                    break;
            }
        }
        //打开工资管理的快捷键
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Alt)
            //{
            //    bool v;
            //    switch (e.KeyCode)
            //    {
            //        case Keys.A:
            //            // AllowShowAll = true;
            //            RefresButton(dataGrid.Enabled);
            //            break;
            //        case Keys.G:
            //            v = SystemInfo.AllowGZ ? false : true;
            //            if (SystemInfo.db.WriteConfig("SystemInfo", "AllowGZ", v))
            //            {
            //                RegisterExit = true;
            //                SystemInfo.IsRestart = true;
            //                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSystemSetup", ""), MessageBoxIcon.Information);
            //                this.Close();
            //            }
            //            break;
            //    }
            //}
        }

        private void ItemAdd_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemAdd", true)) return;
            frmMacInfoAdd frm = new frmMacInfoAdd(TitleBar.Text, ItemAddDev.Text, "");
            if (frm.ShowDialog() == DialogResult.OK) RefreshDevice();
        }

        private void ItemEdit_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemEdit", true)) return;
            frmMacInfoAdd frm = new frmMacInfoAdd(TitleBar.Text, ItemEdit.Text, GetMacSN().ToString());
            if (frm.ShowDialog() == DialogResult.OK) RefreshDevice();
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemDelete", true)) return;
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgDeleteSelect", ""))) return;
            List<string> sql = new List<string>();
            string msg = "";
            string tmp = "";
            string MacSN = "";
            if (dataGrid.Columns[0].DataPropertyName.ToLower() == "selectcheck")
            {
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
                    {
                        MacSN = dataGrid[1, i].Value.ToString();
                        sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "1", MacSN }));
                        sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "507", MacSN }));
                        tmp = dataGrid.Columns[1].HeaderText + "=" + MacSN;
                        if (tmp != "") tmp = tmp + ";";
                        msg = msg + tmp;
                    }
                }
            }
            if (sql.Count == 0)
            {
                int i = bindingSource.Position;
                MacSN = dataGrid[1, i].Value.ToString();
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "1", MacSN }));
                sql.Add(Pub.GetSQL(DBCode.DB_000300, new string[] { "507", MacSN }));
                tmp = dataGrid.Columns[1].HeaderText + "=" + MacSN;
                if (tmp != "") tmp = tmp + ";";
                msg = msg + tmp;
            }
            if (sql.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgNoSelectDelete", ""));
                return;
            }
            if (SystemInfo.db.ExecSQL(sql) != 0) return;
            SystemInfo.db.WriteSYLog(TitleBar.Text, ItemDelete.Text, msg);
            RefreshDevice();
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
        }

        private void ItemTAG1_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG1", true)) return;
            ExecMacOprt(ItemTAG1.Text, 0);
        }

        private void ItemTAG2_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG2", true)) return;
            ExecMacOprt(ItemTAG2.Text, 1);
        }

        private void ItemTAG3_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG3", true)) return;

            dtDoorReal.Clear();
            dtAlarmReal.Clear();
            //ExecMacOprt(ItemTAG3.Text, 2);
            //if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemGetAllData", true)) return;
            if (!InitMacList(true)) return;
            frmBaseDate dt = new frmBaseDate(ItemGetAllData.Text);
            dtReal.Clear();

            if (dt.ShowDialog() == DialogResult.OK)
            {
                if (app.IsEmp)
                {
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetSelectData", ""), 12);
                }
                else if (app.IsAll)
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetAllData", ""), 12);
                else if (app.IsNew)
                {
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetNewData", ""), 2);
                }
                else
                    ExecMacOprt(Pub.GetResText(formCode, "MsgSetTimingData", ""), 12);
            }
        }

        private void ItemTAG4_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTAG4", true)) return;
            try
            {
                timer1.Enabled = true;
                isMonitoring = true;
                //旧机型
                string s = SystemInfo.RegularPort.ToString();
                if (!Pub.IsNumeric(s)) s = AcPort.ToString();
                int.TryParse(s, out Port);
                if (Port > 0xffff) Port = AcPort;
                if (SystemInfo.ShowSEA == 1 || SystemInfo.ShowSTAR == 1)
                {
                    if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                    {
                        if (RegisterInfo.EndDate < DateTime.Now)
                        {
                            Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "MsgUnRegisterInfo", ""), Pub.GetResText(formCode, "mnuMJ", "")));
                            return;
                        }
                    }
                }
                if (SystemInfo.ShowSEA == 1)
                {
                    //海系列
                    s = SystemInfo.SeaPort.ToString();
                    if (!Pub.IsNumeric(s)) s = SeaPort.ToString();
                    int.TryParse(s, out sePort);
                    if (Port > 0xffff) sePort = SeaPort;
                }
                if (SystemInfo.ShowSTAR == 1)
                {
                    //星序列
                    s = SystemInfo.StarPort.ToString();
                    if (!Pub.IsNumeric(s)) s = StaPort.ToString();
                    int.TryParse(s, out stPort);
                    if (Port > 0xffff) stPort = StaPort;
                }


                dtReal.Clear();
                dtDoorReal.Clear();
                dtAlarmReal.Clear();
                readData = new FingerReadData(TitleBar.Text + "[" + ItemTAG4.Text + "]");

                int ResultCode = axRealSvr.OpenNetwork(Port);

                seaHttpServer = new SeaHttpServer();
                seaHttpServer.Setup(sePort, ShowReadDataProcess, lbTitleX, textFormat);

                starHttpServer = new StarHttpServer();
                starHttpServer.Setup(stPort, ShowReadDataProcess, lbTitleX, textFormat);

                if (ResultCode != (int)FKRun.RUN_SUCCESS)
                {
                    lblMsg.Text = DeviceObject.objFK623.GetRunMsg(ResultCode);
                    return;
                }
            }
            catch
            {

            }
            finally
            {
                IsWorking = 2;
                RefresButton(true);
            }
        }

        private void ItemTAG5_Click(object sender, EventArgs e)
        {
            try
            {
                axRealSvr.CloseNetwork(Port);
                timer1.Enabled = false;
                isMonitoring = false;

                if (SystemInfo.ShowSEA == 1 || SystemInfo.ShowSTAR == 1)
                {
                    if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                    {
                        if (RegisterInfo.EndDate < DateTime.Now)
                        {
                            Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "MsgUnRegisterInfo", ""), Pub.GetResText(formCode, "mnuMJ", "")));
                            return;
                        }
                    }
                }
                if (seaHttpServer != null)
                    seaHttpServer.Setup(0, ShowReadDataProcess, null, textFormat);

                if (starHttpServer != null)
                    starHttpServer.Setup(0, ShowReadDataProcess, null, textFormat);

                sp.Stop();
            }
            catch
            {

            }
            finally
            {
                IsWorking = 0;
                readData = null;
                RefresButton(true);
            }
        }

        private void ItemDownload_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemDownload", true)) return;
            //ExecMacOprt(ItemDownload.Text, 3);
            bool SelectAll = false;
            if (!InitMacList(true)) return;
            if (!GetSelectEmp(ItemDownload.Text, out SelectAll)) return;
            if (SelectAll == true)
            {
                //Download All UserInfo
                ExecMacOprt(ItemDownload.Text, 3);
            }
            else
            {
                //Download Select UserInfo
                if (selectEmpList.Count <= 0)
                {
                    Pub.MessageBoxShow(Pub.GetResText("Public", "ErrorSelectEmp", ""));
                    return;
                }
                ExecMacOprt(ItemDownload.Text, 15);
            }
        }

        private void ItemDownloadUSB_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemDownloadUSB", true)) return;
            frmFKFirmwareVer frm = new frmFKFirmwareVer(ItemDownloadUSB.Text, true);
            if (frm.ShowDialog() != DialogResult.OK) return;
            usbFKModel = frm.SelectVer;
            usbFile = frm.USBFile;
            string MacMsg = "";
            RefresButton(false);

            ExecMacCommand(ItemDownloadUSB.Text, 4, "0", ref MacMsg);
            progBar.Value = 0;
            if (MacMsg != "") RefreshMacMsg(ItemDownloadUSB.Text + "  " + MacMsg);
            RefresButton(true);
        }

        #region GetSelectedEmp(FingerNo?)
        private List<UInt32> selectEmpList = new List<UInt32>();
        public bool GetSelectEmp(string Title, out bool SelectAll)
        {
            selectEmpList.Clear();
            frmBaseSelectEmp frm = new frmBaseSelectEmp(Title, selectEmpList, connList);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                SelectAll = frm.SelectAll;
                return false;
            }
            if (selectEmpList.Count >= 0 || frm.SelectAll == true)
            {
                SelectAll = frm.SelectAll;
                return true;
            }
            else
            {
                SelectAll = frm.SelectAll;
                return false;
            }
        }
        #endregion

        private bool GetUploadSelectEmp(bool IsNoUSB)
        {
            dtUpload = null;
            dtUploadcount = null;
            bool ret = false;

            if (!SystemInfo.db.GetServerDate(ref serverDate)) return ret;
            frmSelectEmp frm = null;
            if (IsNoUSB)
                frm = new frmSelectEmp(TitleBar.Text, ItemUpload.Text);
            else
                frm = new frmSelectEmp(TitleBar.Text, ItemUploadUSB.Text);
            if (frm.ShowDialog() != DialogResult.OK) return ret;
            string sql = "";
            string sqlcount = "";
          
            if (frm.selEmpNo != "")
            {
                selList = new TDownSelectList[frm.selList.Length];
                selList = frm.selList;
                sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "207", frm.selEmpNo });
                sqlcount = Pub.GetSQL(DBCode.DB_000300, new string[] { "604", frm.selEmpNo });
            }
            else
            {
                return true;
            }
           
            try
            {
                dtUpload = SystemInfo.db.GetDataTable(sql);
                dtUploadcount = SystemInfo.db.GetDataTable(sqlcount);
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        private void ItemUpload_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemUpload", true)) return;
            if (!GetUploadSelectEmp(true)) return;
            IsExistDelete = SystemInfo.db.ReadConfig("SystemInfo", "IsExistDelete", true);
            IsUploadName = SystemInfo.db.ReadConfig("SystemInfo", "IsUploadName", true);
            ExecMacOprt(ItemUpload.Text, 5);
        }

        private void ItemUploadUSB_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemUploadUSB", true)) return;
            frmFKFirmwareVer frmVer = new frmFKFirmwareVer(ItemUploadUSB.Text, false);
            if (frmVer.ShowDialog() != DialogResult.OK) return;
            usbFKModel = frmVer.SelectVer;
            usbFile = frmVer.USBFile;
            if (!GetUploadSelectEmp(false)) return;
            string MacMsg = "";
            RefresButton(false);

            ExecMacCommand(ItemUploadUSB.Text, 6, "0", ref MacMsg);
            progBar.Value = 0;
            if (MacMsg != "") RefreshMacMsg(ItemUploadUSB.Text + "  " + MacMsg);
            RefresButton(true);
        }

        private void ItemClearData_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemClearData", true)) return;
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgClearData", ""))) return;
            ExecMacOprt(ItemClearData.Text, 7);
        }

        private void ItemClearManager_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemClearManager", true)) return;
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgClearManager", ""))) return;
            ExecMacOprt(ItemClearManager.Text, 8);
        }

        private void ItemClearInfo_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemClearInfo", true)) return;
          
            bool SelectAll = false;
            if (!InitMacList(true)) return;
            if (!GetSelectEmp(ItemClearInfo.Text, out SelectAll)) return;
            if (SelectAll == true)
            {
                //Clear All UserInfo
                if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgClearInfo", ""))) return;
                ExecMacOprt(ItemClearInfo.Text, 9);
            }
            else
            {
                //Clear Select UserInfo
                if (selectEmpList.Count <= 0)
                {
                    Pub.MessageBoxShow(Pub.GetResText("Public", "ErrorSelectEmp", ""));
                    return;
                }
                ExecMacOprt(ItemClearInfo.Text, 16);
            }
        }

        private bool GetDimList()
        {
            dimList.Clear();
            bool ret = false;
            string sql = Pub.GetSQL(DBCode.DB_000102, new string[] { "7" });
            DataTableReader dr = null;
            TDimInfo dim;
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                while (dr.Read())
                {
                    dim = new TDimInfo(Convert.ToUInt32(dr[0].ToString()), Convert.ToInt32(dr[1].ToString()));
                    dimList.Add(dim);
                }
                ret = true;
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
            if (ret && dimList.Count == 0)
            {
                ret = false;
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgClearInfoDimNoInfo", ""));
            }
            return ret;
        }

        private void ItemClearInfoDim_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemClearInfoDim", true)) return;
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgClearInfoDim", ""))) return;
            if (!GetDimList()) return;
            ExecMacOprt(ItemClearInfoDim.Text, 10);
        }

        private void ItemInitDevice_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemInitDevice", true)) return;
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgInit", ""))) return;
            ExecMacOprt(ItemInitDevice.Text, 11);
        }

        private void ItemGetAllData_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemGetAllData", true)) return;
            if (!InitMacList(true)) return;
            frmBaseDate dt = new frmBaseDate(ItemGetAllData.Text);
            dtReal.Clear();

            if (dt.ShowDialog() == DialogResult.OK)
            {
                if (app.IsEmp)
                {
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetSelectData", ""), 12);
                }
                else if (app.IsAll)
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetAllData", ""), 12);
                else if (app.IsNew)
                {
                    ExecMacOprt(Pub.GetResText(formCode, "MsgGetNewData", ""), 2);
                }
                else
                    ExecMacOprt(Pub.GetResText(formCode, "MsgSetTimingData", ""), 12);
            }

        }

        private void ItemUSBData_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemUSBData", true)) return;
            dtReal.Clear();
            dlgOpen.Multiselect = true;
            dlgOpen.Filter = Pub.GetResText(formCode, "FilterUSB", "") + "(*.txt)|*.txt";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            foreach (string file in dlgOpen.FileNames)
            {
                usbFile = file;
                string MacMsg = "";
                RefresButton(false);
                ExecMacCommand(ItemUSBData.Text, 13, "0", ref MacMsg);
                if (MacMsg != "") RefreshMacMsg(ItemUSBData.Text + "  " + MacMsg);
            }

            RefresButton(true);
        }

        private void ItemUSBText_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemUSBText", true)) return;
            dtReal.Clear();
            dlgOpen.Multiselect = true;
            dlgOpen.Filter = Pub.GetResText(formCode, "FilterText", "") + "(KQF*.txt)|KQF*.txt";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            foreach (string file in dlgOpen.FileNames)
            {
                usbFile = file;
                string MacMsg = "";
                RefresButton(false);
                ExecMacCommand(ItemUSBText.Text, 14, "0", ref MacMsg);
                if (MacMsg != "") RefreshMacMsg(ItemUSBText.Text + "  " + MacMsg);
            }

            RefresButton(true);
        }

        private void ItemTextFormat_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemTextFormat", true)) return;
            frmMacDataFormat frm = new frmMacDataFormat(TitleBar.Text, ItemTextFormat.Text);
            if (frm.ShowDialog() == DialogResult.OK) LoadTextFormat();
        }

        private void ItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshDevice();
        }

        private void msgGrid_Resize(object sender, EventArgs e)
        {
            Column1.Width = msgGrid.Width - 20;
        }
        //刷新页面
        private void RefreshDevice()
        {
            SystemInfo.IsMacNomber = false;
            string QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "0" });
            DataTableReader dr = null;
            string MacNomber = "";
            string Online = Pub.GetResText(formCode, "Online", "");
            DateTime StartTime = DateTime.Now;
            int row = -1;
            RefreshMsg(StrReading);
            if (QuerySQL != "")
            {
                try
                {
                    dr = SystemInfo.db.GetDataReader(QuerySQL);
                    while (dr.Read())
                    {
                        SystemInfo.IsMacNomber = true;
                        MacNomber = dr["MacSN"].ToString();
                        if (!Pub.IsNumeric(MacNomber))
                        {
                            SystemInfo.IsMacNomber = false;
                            break;
                        }

                    }
                    QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "0" });
                    if (bindingSource.DataSource != null) row = bindingSource.Position;
                    bindingSource.DataSource = null;
                    bindingSource.DataSource = SystemInfo.db.GetDataTable(QuerySQL);
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E, QuerySQL);
                }
                finally
                {
                    if ((bindingSource.DataSource != null) && (row >= 0))
                    {
                        if (row < bindingSource.Count)
                            bindingSource.Position = row;
                        else if (bindingSource.Count > 0)
                            bindingSource.Position = bindingSource.Count - 1;
                    }
                }
            }
            SystemInfo.IsMacNomber = false;
            RefresButton(true);
            InitTimerList();
            RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
            monitoringsList.Clear();
            if (bindingSource.DataSource != null)
                for (int i = 0; i < bindingSource.Count; i++)
                {
                    if (SystemInfo.ShowMJ == 1)
                        dataGrid[23, i].Value = "";
                    string line = dataGrid[8, i].Value.ToString();
                    string HeartBeatMacSN = dataGrid[1, i].Value.ToString();
                    if (line == Online)
                    {
                        dataGrid.Rows[i].Cells[8].Style.ForeColor = Color.Green;
                        dataGrid.Rows[i].Cells[8].Style.SelectionForeColor = Color.Green;
                        Panel btn1L = new Panel();

                        btn1L.BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\3.jpg");
                    }
                    else
                    {
                        dataGrid.Rows[i].Cells[8].Style.ForeColor = Color.Red;
                        dataGrid.Rows[i].Cells[8].Style.SelectionForeColor = Color.Red;
                    }
                    monitoringsList.Add(new Monitoring(HeartBeatMacSN, 0));//初始化在线状态
                }
            AllowShowAll = true;
            panel5_Resize(null, null);

        }

        private void RefresButton(bool State)
        {
            int row = 0;
            int rows = 0;
            if (bindingSource.DataSource != null)
            {
                row = bindingSource.Position + 1;
                rows = bindingSource.Count;
            }
            ItemAddDev.Enabled = State && (IsWorking == 0);
            ItemEdit.Enabled = State && (rows > 0) && (IsWorking == 0);
            ItemDelete.Enabled = State && (rows > 0) && (IsWorking == 0);
            ItemTAG1.Enabled = State && (rows > 0) && (IsWorking == 0);
            ItemTAG2.Enabled = State && (rows > 0) && (IsWorking == 0);
            ItemTAG3.Enabled = State && (rows > 0) && (IsWorking == 0);
            ItemTAG4.Enabled = State && (rows > 0) && (IsWorking == 0);
            ItemTAG5.Enabled = State && (rows > 0) && (IsWorking == 2);
            ItemTAGExt.Enabled = State && (rows > 0) && (IsWorking == 0);
            ItemRefresh.Enabled = State && (IsWorking == 0);
            lblRecordState.Text = string.Format(StrPosition, row, rows);
            //ItemGetAllData.Visible = AllowShowAll;
            //ItemText.Enabled = State && (IsWorking == 0);
            //ItemTextSea.Enabled = State && (IsWorking == 0);
            //ItemTextStar.Enabled = State && (IsWorking == 0);
            ItemFindText.Enabled = State && (IsWorking == 0);
            dataGrid.Enabled = State && (IsWorking == 0);
        }

        private void SelectData(bool State)
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

        private void LoadTextFormat()
        {
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "15",
          KQTextFormatInfo.KQ_ConfigID, KQTextFormatInfo.KQ_TextFormat }));
                if (dr.Read()) textFormat = new KQTextFormatInfo(dr["Value"].ToString());
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

        private string GetMacSN()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            if (drv == null)
                return "0";
            else
                return drv.Row["MacSN"].ToString();
        }

        private TDIConnInfo RowDataToConnInfo(int RowIndex)
        {
            int MacSN = 0;
            string MacSN_GRPS = "";
            int MacSeriesTypeId = 0;
            Int32.TryParse(dataGrid[3, RowIndex].Value.ToString(), out MacSeriesTypeId);
            bool IsGPRS = Pub.ValueToBool(dataGrid[13, RowIndex].Value);
            if (IsGPRS || MacSeriesTypeId == 3)
                MacSN_GRPS = dataGrid[1, RowIndex].Value.ToString();
            else
            {
                MacSN = Convert.ToInt32(dataGrid[1, RowIndex].Value.ToString());
                MacSN_GRPS = MacSN.ToString();
            }
            string MacConnType = dataGrid[7, RowIndex].Value.ToString();
            string MacIP = dataGrid[10, RowIndex].Value.ToString();
            string MacPort = dataGrid[11, RowIndex].Value.ToString();
            string MacConnPWD = dataGrid[12, RowIndex].Value.ToString();
            string SeaSeriesPwd = dataGrid[12, RowIndex].Value.ToString();
            string MacSeriesUserName = dataGrid[24, RowIndex].Value.ToString();

            return Pub.ValueToDIConnInfo(MacSN, MacSN_GRPS, MacConnType, MacIP, MacPort, MacConnPWD, IsGPRS, MacSeriesTypeId, SeaSeriesPwd, MacSeriesUserName);
        }

        private void RowToConnInfo(int RowIndex)
        {
            connList.Add(RowDataToConnInfo(RowIndex));
        }

        private bool InitMacList(bool IsMac)
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
            if ((connList.Count == 0) && !IsMac)
            {
                RowToConnInfo(dataGrid.CurrentRow.Index);
            }
            if (connList.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
            }
            return connList.Count > 0;
        }

        private void RefreshMsg(string msg)
        {
            RefreshMsg(msg, false);
        }

        private void RefreshMsg(string msg, bool IsEnd)
        {
            lblMsg.Text = msg;
            if ((lblMsg.Text == "") || IsEnd)
            {
                progBar.Value = 0;
                progBar.ProgressType = eProgressItemType.Standard;
            }
            else
            {
                progBar.Value = 100;
                progBar.ProgressType = eProgressItemType.Marquee;
            }
            statusBar.Refresh();
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

        private void ExecMacOprt(string Oprt, byte flag)
        {
            ExecMacOprt(Oprt, flag, true);
        }

        private void ExecMacOprt(string Oprt, byte flag, bool IsMac)
        {
            bool state = false;
            string msg = "";
            string MacMsg = "";
            string Defence = "";
            string Online = "";
            bool isLine = false;
            string url = "";
            if (!InitMacList(IsMac)) return;
            IsWorking = 1;
            RefresButton(false);
            DateTime start = new DateTime();
            start = DateTime.Now;
            string ExecTimes = "";
            TDIConnInfo conn;
            JObject vjobj = null;
            Application.DoEvents();
            try
            {
                for (int i = 0; i < connList.Count; i++)
                {
                    conn = connList[i];
                    vjobj = new JObject();
                    MacMsg = "";
                    RefreshMsg(Oprt + "[" + conn.MacSN_GPRS + "]......");
                    RefreshMacMsg(Oprt + "[" + conn.MacSN_GPRS + "]......");

                    switch (conn.MacSeriesTypeId)
                    {
                        case 2://海系列
                            if (SystemInfo.ShowSEA != 1)
                            {
                                MacMsg = string.Format(Pub.GetResText(formCode, "MsgUnModuleInfo", ""), Pub.GetResText(formCode, "SeaDev", ""));
                                break;
                            }
                            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                            {
                                if (RegisterInfo.EndDate < DateTime.Now)
                                {
                                    MacMsg = RegisterInfo.StateText;
                                    break;
                                }
                            }
                            SystemInfo.MacSeriesTypeId = 2;
                            url = "http://" + conn.NetHost + "/";
                            string body = "";
                            string urlTestConnt = "http://" + conn.NetHost + "/action/GetSysParam";
                            bool ret = DeviceObject.objFK623.POST_GetResponse(urlTestConnt, conn.MacSeriesUserName, conn.SeaSeries_Pwd, ref body);

                            if (ret)
                            {
                                isLine = true;
                                state = Sea_ExecMacCommand(Oprt, flag, conn.MacSN_GPRS, url, conn.MacSeriesUserName, conn.SeaSeries_Pwd, ref MacMsg);
                            }
                            else
                            {
                                state = false;
                            }
                            break;
                        case 3://星系列
                            if (SystemInfo.ShowSTAR != 1)
                            {
                                MacMsg = string.Format(Pub.GetResText(formCode, "MsgUnModuleInfo", ""), Pub.GetResText(formCode, "StarDev", ""));
                                break;
                            }
                            if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                            {
                                if (RegisterInfo.EndDate < DateTime.Now)
                                {
                                    MacMsg = RegisterInfo.StateText;
                                    break;
                                }
                            }
                            SystemInfo.MacSeriesTypeId = 3;
                            string cmd = "GetDeviceInfo";
                            DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
                            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));
                            if (DeviceObject.socKetClient.Open(conn.NetHost, conn.NetPort, conn.NetPassword))
                            {
                                if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                                {
                                    isLine = true;
                                    state = Star_ExecMacCommand(Oprt, flag, conn.MacSN_GPRS, ref MacMsg);
                                }
                            }
                            break;
                        default://常规系列
                            SystemInfo.MacSeriesTypeId = 1;
                            DeviceObject.objFK623.InitConn(conn);
                            if (IsMac)
                            {
                                if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
                                DeviceObject.objFK623.EnableDevice(0);
                            }
                            if (DeviceObject.objFK623.IsOpen)
                            {
                                isLine = true;
                                state = ExecMacCommand(Oprt, flag, conn.MacSN_GPRS, ref MacMsg);
                            }
                            break;
                    }

                    if (isLine)
                    {
                        Online = Pub.GetResText(formCode, "Online", "");

                        #region 获取布防状态
                        //vjobj.Add("cmd", "alarm_enable_get");
                        //string vstrJsonStr = vjobj.ToString();
                        //DeviceObject.objFK623.ExecJsonCmd(ref vstrJsonStr);
                        //if (vstrJsonStr.Contains("yes"))
                        //    Defence = Pub.GetResText(formCode, "btnDefence", "");
                        //else
                        //    Defence = Pub.GetResText(formCode, "btnWithdrawal", "");
                        #endregion
                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "304", Online
                        , Defence,conn.MacSN_GPRS.ToString()}));

                        for (int j = 0; j < dataGrid.RowCount; j++)
                        {
                            if (dataGrid[1, j].Value.ToString() == conn.MacSN_GPRS.ToString())
                            {
                                dataGrid[8, j].Value = Online;
                                dataGrid[9, j].Value = Defence;
                                dataGrid.Rows[j].Cells[8].Style.ForeColor = Color.Green;
                                dataGrid.Rows[j].Cells[8].Style.SelectionForeColor = Color.Green;
                                for (int x = 0; x < panel5.Controls.Count; x++)
                                {
                                    if (panel5.Controls[x].Name == "btn" + conn.MacSN_GPRS.ToString())
                                    {
                                        panel5.Controls[x].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\1.jpg");
                                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "6", "1", conn.MacSN_GPRS.ToString() }));
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        Online = Pub.GetResText(formCode, "Offline", "");

                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "305", Online, conn.MacSN_GPRS.ToString() }));

                        for (int j = 0; j < dataGrid.RowCount; j++)
                        {
                            if (dataGrid[1, j].Value.ToString() == conn.MacSN_GPRS.ToString())
                            {
                                dataGrid[8, j].Value = Online;
                                dataGrid.Rows[j].Cells[8].Style.ForeColor = Color.Red;
                                dataGrid.Rows[j].Cells[8].Style.SelectionForeColor = Color.Red;
                                for (int x = 0; x < panel5.Controls.Count; x++)
                                {
                                    if (panel5.Controls[x].Name == "btn" + conn.MacSN_GPRS.ToString())
                                    {

                                        panel5.Controls[x].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\4.jpg");
                                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "6", "4", conn.MacSN_GPRS.ToString() }));
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    if (IsMac)
                    {
                        if (MacMsg != "") MacMsg = "[" + MacMsg + "]";

                        switch (conn.MacSeriesTypeId)
                        {
                            case 2:
                                UpdateMacMsg(MacMsg + DeviceObject.objFK623.SeaBodyStr() + ExecTimes, state);
                                msg = msg + conn.MacSN_GPRS + ":" + MacMsg + DeviceObject.objFK623.SeaBodyStr() + ";";
                                break;
                            case 3:
                                UpdateMacMsg(MacMsg + DeviceObject.socKetClient.ErrMsg + ExecTimes, state);
                                msg = msg + conn.MacSN_GPRS + ":" + MacMsg + DeviceObject.socKetClient.ErrMsg + ";";
                                DeviceObject.socKetClient.Close();
                                break;
                            default:
                                UpdateMacMsg(MacMsg + DeviceObject.objFK623.ErrMsg + ExecTimes, state);
                                msg = msg + conn.MacSN_GPRS + ":" + MacMsg + DeviceObject.objFK623.ErrMsg + ";";
                                DeviceObject.objFK623.EnableDevice(1);
                                DeviceObject.objFK623.Close();
                                break;
                        }

                    }
                    else if (state)
                    {
                        UpdateMacMsg(Pub.GetResText(formCode, "MsgSaveSucceed", "") + ExecTimes, state);
                        msg = msg + conn.MacSN_GPRS + ":" + Pub.GetResText(formCode, "MsgSaveSucceed", "") + MacMsg + ";";
                    }
                    else
                    {
                        UpdateMacMsg(Pub.GetResText(formCode, "MsgSaveFailed", "") + ExecTimes, state);
                        msg = msg + conn.MacSN_GPRS + ":" + Pub.GetResText(formCode, "MsgSaveFailed", "") + MacMsg + ";";
                    }
                    Application.DoEvents();
                    start = DateTime.Now;
                    if (IsWorking == 0) break;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }

            SystemInfo.db.WriteSYLog(TitleBar.Text, Oprt, msg);
            IsWorking = 0;
            RefresButton(true);
            RefreshMsg("");
        }

        private void ShowReadDataProcess(int RecordCount, int RecordIndex, string MacSN, TFingerLog attLog, string GUID,
          bool ShowDetailData)
        {
            if (ShowDetailData)
            {
                string EmpNo = "";
                string EmpNoOne = "";
                string EmpNoTwo = "";
                string EmpNoTree = "";
                string EmpNoFour = "";
                string EmpNoFive = "";
                string EmpName = "";
                string DepartID = "";
                string DepartName = "";
                string MacDesc = "";
                bellPath = "";
                string ReMacSN = "";
                string ReEmpNo = "";
                string ReEmpName = "";
                string reGUID = "";

                DataTableReader dr = null;
                MJInfoList mJInfoList = null;
                if (attLog == null)
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "11", GUID }));
                    if (dr.Read())
                    {
                        MacDesc = dr["MacDesc"].ToString();
                        DateTime date = Convert.ToDateTime(dr["OprtDate"]);
                        dtReal.Rows.Add(new object[] { date.ToString(SystemInfo.SQLDateTimeFMT), MacSN, null,
                "", "", null, "", "", "",MacDesc, GUID,"",false });
                        realGrid.CurrentCell = realGrid.Rows[realGrid.RowCount - 1].Cells[0];
                        realGrid_CellClick(null, null);
                    }
                    return;
                }

                try
                {
                    if (attLog.CardID != "")
                    {
                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "208", attLog.CardID }));
                        if (dr.Read())
                        {
                            EmpNo = dr["EmpNo"].ToString();
                            EmpName = dr["EmpName"].ToString();
                            DepartID = dr["DepartID"].ToString();
                            DepartName = dr["DepartName"].ToString();
                            if (!Pub.FindMJInfo(attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, EmpNo))
                            {
                                DataTable dt = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000300, new string[] { "703", MacSN }));
                                if (dt.Rows.Count > 0)
                                {
                                    DateTime timeInterval1 = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1]["MJDateTime"].ToString());
                                    DateTime timeInterval2 = attLog.CardTime;

                                    TimeSpan ts = timeInterval2 - timeInterval1;
                                    long timeInterval = Convert.ToInt64(ts.TotalMinutes);

                                    if (timeInterval > 5)
                                    {
                                        SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "710", MacSN }));
                                    }
                                }
                                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "700",
                                attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, EmpNo, EmpName }));
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
                try
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "210", MacSN }));
                    if (dr.Read())
                    {
                        MacDesc = dr["MacDesc"].ToString();
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
                try
                {
                    for (int c = 0; c < dataGrid.RowCount; c++)
                    {
                        if (dataGrid[1, c].Value.ToString() == MacSN.ToString())
                        {

                            dataGrid[8, c].Value = Pub.GetResText("", "Online", "");
                            dataGrid.Rows[c].Cells[8].Style.ForeColor = Color.Green;
                            dataGrid.Rows[c].Cells[8].Style.SelectionForeColor = Color.Green;
                            break;
                        }
                    }
                    for (int c = 0; c < dataGrid.RowCount; c++)
                    {
                        if (monitoringsList[c].MacSN.Equals(MacSN.ToString()))
                        {
                            monitoringsList[c].BakNo = 1;
                            break;
                        }
                    }
                    if (attLog.DoorMode == 1)
                    {

                        for (int s = 0; s < panel5.Controls.Count; s++)
                        {
                            if (panel5.Controls[s].Name == "btn" + MacSN.ToString())
                            {
                                panel5.Controls[s].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\1.jpg");
                                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "6", "1", MacSN.ToString() }));
                                break;
                            }
                        }

                    }
                    if (attLog.DoorMode == 9)
                    {
                        for (int s = 0; s < panel5.Controls.Count; s++)
                        {

                            if (panel5.Controls[s].Name == "btn" + MacSN.ToString())
                            {
                                panel5.Controls[s].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\3.jpg");
                                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "6", "3", MacSN.ToString() }));
                                break;
                            }

                        }

                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "703", MacSN }));
                        while (dr.Read())
                        {
                            ReMacSN = dr["MacSN"].ToString();
                            ReEmpNo = dr["EmpNo"].ToString();
                            ReEmpName = dr["EmpName"].ToString();

                            mJInfoList = new MJInfoList(ReMacSN, ReEmpNo, ReEmpName);
                            NMJList.Add(mJInfoList);
                            reGUID = dr["GUID"].ToString();
                            SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "702", reGUID }));
                        }
                        switch(NMJList.Count)
                        {
                            case 1:
                                EmpNoOne = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                                EmpNoTwo = "";
                                EmpNoTree = "";
                                break;
                            case 2:
                                EmpNoOne = NMJList[NMJList.Count - 2].EnrollNumber + " [" + NMJList[NMJList.Count - 2].EmpName + "] ";
                                EmpNoTwo = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                                EmpNoTree = "";
                                break;
                            case 3:
                                EmpNoOne = NMJList[NMJList.Count - 3].EnrollNumber + " [" + NMJList[NMJList.Count - 3].EmpName + "] ";
                                EmpNoTwo = NMJList[NMJList.Count - 2].EnrollNumber + " [" + NMJList[NMJList.Count - 2].EmpName + "] ";
                                EmpNoTree = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                                break;
                            case 4:
                                EmpNoOne = NMJList[NMJList.Count - 4].EnrollNumber + " [" + NMJList[NMJList.Count - 4].EmpName + "] ";
                                EmpNoTwo = NMJList[NMJList.Count - 3].EnrollNumber + " [" + NMJList[NMJList.Count - 3].EmpName + "] ";
                                EmpNoTree = NMJList[NMJList.Count - 2].EnrollNumber + " [" + NMJList[NMJList.Count - 2].EmpName + "] ";
                                EmpNoFour = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                                break;
                            case 5:
                                EmpNoOne = NMJList[NMJList.Count - 5].EnrollNumber + " [" + NMJList[NMJList.Count - 5].EmpName + "] ";
                                EmpNoTwo = NMJList[NMJList.Count - 4].EnrollNumber + " [" + NMJList[NMJList.Count - 4].EmpName + "] ";
                                EmpNoTree = NMJList[NMJList.Count - 3].EnrollNumber + " [" + NMJList[NMJList.Count - 3].EmpName + "] ";
                                EmpNoFour = NMJList[NMJList.Count - 2].EnrollNumber + " [" + NMJList[NMJList.Count - 2].EmpName + "] ";
                                EmpNoFive = NMJList[NMJList.Count - 1].EnrollNumber + " [" + NMJList[NMJList.Count - 1].EmpName + "] ";
                                break;
                        }
                      
                        dtDoorReal.Rows.Add(new object[] { attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, MacDesc,
                            attLog.InOutModeName, GUID,EmpNoOne,EmpNoTwo,EmpNoTree,EmpNoFour,EmpNoFive});

                        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "705", attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), EmpNoOne }));
                        if (!dr.Read())
                        {
                            SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "704",
                                    attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, MacDesc,
                            attLog.InOutModeName,EmpNoOne,EmpNoTwo,EmpNoTree,EmpNoFour,EmpNoFive}));
                        }

                        NMJList.Clear();
                    }

                    if (attLog.FingerNo == 0)
                        dtReal.Rows.Add(new object[] { attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, null,
                 EmpNo, EmpName, DepartID, DepartName, attLog.VerifyModeName, attLog.InOutModeName,MacDesc, GUID,attLog.DoorStauts,attLog.Bell });
                    else
                    {
                        if (SystemInfo.IsZDTxtReal)
                        {
                            attLog.MacSN = MacSN;

                            //ThreadPool.QueueUserWorkItem(new WaitCallback(SaveRealDataToTxt),(object)attLog); //越南定制自动导出txt
                        }


                        dtReal.Rows.Add(new object[] { attLog.CardTime.ToString(SystemInfo.SQLDateTimeFMT), MacSN, attLog.FingerNo,
                 EmpNo, EmpName, DepartID, DepartName, attLog.VerifyModeName, attLog.InOutModeName,MacDesc, GUID,attLog.DoorStauts,attLog.Bell });
                    }

                    if (attLog.VerifyMode == 8)
                        attLog.Bell = true;
                    if (attLog.Bell)
                    {

                        for (int s = 0; s < panel5.Controls.Count; s++)
                        {

                            if (panel5.Controls[s].Name == "btn" + MacSN.ToString())
                            {
                                panel5.Controls[s].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\5.jpg");
                                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000300, new string[] { "6", "5", MacSN.ToString() }));
                                break;
                            }
                        }

                        dtAlarmReal.Rows.Add(new object[] { attLog.CardTime.ToString(SystemInfo.DateTimeFormat), MacSN, MacDesc, attLog.VerifyModeName, GUID });
                        realGrid.Rows[realGrid.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;

                        if (SystemInfo.IsWarning)
                        {
                            BellTime = 0;
                            if (File.Exists(SystemInfo.db.ReadConfig("SystemInfo", "Path")))
                            {
                                bellPath = SystemInfo.db.ReadConfig("SystemInfo", "Path");
                            }
                            if (bellPath == "")
                                bellPath = SystemInfo.AppPath + "\\www\\bell\\2.WAV";
                            sp.SoundLocation = bellPath;
                            sp.Load();
                            sp.PlayLooping();
                        }
                    }
                    realGrid.CurrentCell = realGrid.Rows[realGrid.RowCount - 1].Cells[0];
                    realGrid_CellClick(null, null);

                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
            }
            else
            {
                if (progBar == null)
                {
                    return;
                }
                if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetSelectData", "")))
                {
                    RecordCount = RecordIndex;
                    progBar.Value = RecordIndex * 100 / RecordCount;
                    lblMsg.Text = MsgString + string.Format("{0} /{1} ", RecordIndex, RecordCount);
                }
                else
                {
                    progBar.Value = RecordIndex * 100 / RecordCount;
                    lblMsg.Text = MsgString + string.Format("{0} /{1} ", RecordIndex, RecordCount);
                }
            }
            Application.DoEvents();
        }
        #region 越南定制

          private void SaveRealDataToTxt(object attLog)
          {
              lock(obj)
              {
                  DateTime dateTime = DateTime.Now;
                  TFingerLog log = (TFingerLog)attLog;

                  string path = SystemInfo.ZDTxtPath + "\\" + dateTime.ToString(SystemInfo.SQLDateymd) + ".txt";

                  string dataStr = string.Format("{0}\t{1}\t{2}\t'{3}\r\n", log.MacSN.PadLeft(2, '0'), log.CardTime.ToString(SystemInfo.SQLDateTMF),
                      log.CardTime.ToString(SystemInfo.SQLDatehms), log.FingerNo.ToString().PadLeft(10, '0'));

                  StreamWriter swData = new StreamWriter(path, true, System.Text.Encoding.Default);
                  swData.Write(dataStr);
                  swData.Dispose();
                  swData.Close();
              }
          }
        #endregion

        private bool ExecMacCommand(string Oprt, byte flag, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            byte IsNew = 0;
            if (flag == 2) IsNew = 1;
            int RecordCount = 0;
            int RecordIndex = 0;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://同步时间
                    ret = SyncTime();
                    break;
                case 1://机器信息
                    ret = ReadMacInfo(MacSN);
                    break;
                case 2:
                case 12:
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]", IsNew);
                    MsgString = lblMsg.Text;

                    //回收选择记录
                    if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetSelectData", "")))
                    {
                        app.IsAll = false;
                        progBar.ProgressType = eProgressItemType.Marquee;
                        progBar.Value = 0;
                        ret = readData.FK623ReadData(textFormat, MacSN, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                        RecordCount = RecordIndex;
                    }
                    //设置定时回收记录(必须在前)
                    else if (MsgString.Contains(Pub.GetResText(formCode, "MsgSetTimingData", "")))
                    {
                        app.IsAll = true;
                        MacMsg = Oprt;
                        ret = true;
                        readData = null;
                        break;
                    }
                    //回收所有记录
                    else if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetAllData", "")))
                    {
                        app.IsAll = true;
                        progBar.ProgressType = eProgressItemType.Standard;
                        progBar.Value = 0;
                        ret = readData.FK623ReadData(textFormat, MacSN, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    }
                    //回收新记录 
                    else if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetNewData", "")))
                    {
                        app.IsAll = true;
                        progBar.ProgressType = eProgressItemType.Standard;
                        progBar.Value = 0;
                        ret = readData.FK623ReadData(textFormat, MacSN, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    }
                    MacMsg = string.Format("{0} /{1} ", RecordIndex, RecordCount);
                    readData = null;
                    app.IsAll = true;
                    break;
                case 3://下载登记资料
                    ret = DownloadInfo(ref MacMsg);
                    break;
                case 4://U盘下载登记资料

                    ret = DownloadInfoUSB(Oprt, ref MacMsg);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = "";
                    break;
                case 5://上传登记资料 
                    ret = UploadInfo(MacSN, ref MacMsg);
                    break;
                case 6://U盘上传登记资料

                    ret = UploadInfoUSB(Oprt, ref MacMsg);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = "";
                    break;
                case 7://清除刷卡记录
                    ret = ClearData();
                    break;
                case 8://清除管理员
                    ret = ClearManager();
                    break;
                case 9://清除登记资料
                    ret = ClearInfo();
                    break;
                case 10://清除离职人员登记资料
                    ret = ClearInfoDim(ref MacMsg);
                    break;
                case 11://初始化机器
                    ret = InitDevice();
                    break;
                case 13://导入U盘数据
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]");
                    RefreshMsg(Oprt + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.ProgressType = eProgressItemType.Marquee;
                    progBar.Value = 0;
                    ret = readData.FK623ReadDataUSB(usbFile, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    if (!ret) MacMsg = DeviceObject.objFK623.ErrMsg;
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    RefreshMsg("");
                    break;
                case 14://导入文本数据
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]");
                    RefreshMsg(Oprt + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.ProgressType = eProgressItemType.Marquee;
                    progBar.Value = 0;
                    ret = readData.ReadDataText(usbFile, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    RefreshMsg("");
                    break;
                case 15://选择人员下载登记资料
                    ret = DownloadInfo(selectEmpList, ref MacMsg);
                    break;
                case 16://选择人员删除登记资料
                    ret = ClearInfo(selectEmpList);
                    MacMsg = string.Format("{0}", selectEmpList.Count);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    break;
            }
            return ret;
        }
        /// <summary>
        /// 海系列动态人脸门禁机
        /// </summary>
        /// <param name="Oprt"></param>
        /// <param name="flag"></param>
        /// <param name="MacSN"></param>
        /// <param name="url"></param>
        /// <param name="MacMsg"></param>
        /// <returns></returns>
        private bool Sea_ExecMacCommand(string Oprt, byte flag, string MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            byte IsNew = 0;
            if (flag == 2) IsNew = 1;
            int RecordCount = 0;
            int RecordIndex = 0;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://同步时间
                    ret = SeaSeries_SyncTime(url, name, pwd);
                    break;
                case 1://机器信息
                    ret = SeaSeries_ReadMacInfo(MacSN, url, name, pwd);
                    break;
                case 2:
                case 12:
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]", IsNew);
                    MsgString = lblMsg.Text;

                    //回收选择记录
                    if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetSelectData", "")))
                    {
                        app.IsAll = false;
                        progBar.ProgressType = eProgressItemType.Marquee;
                        progBar.Value = 0;
                        ret = readData.SeaSeries_FK623ReadData(textFormat, MacSN, url, name, pwd, true, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                        RecordCount = RecordIndex;
                    }
                    //设置定时回收记录(必须在前)
                    else if (MsgString.Contains(Pub.GetResText(formCode, "MsgSetTimingData", "")))
                    {
                        app.IsAll = true;
                        MacMsg = Oprt;
                        ret = true;
                        readData = null;
                        break;
                    }
                    //回收所有记录
                    else if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetAllData", "")) || MsgString.Contains(Pub.GetResText(formCode, "MsgGetNewData", "")))
                    {
                        app.IsAll = true;
                        progBar.ProgressType = eProgressItemType.Standard;
                        progBar.Value = 0;
                        ret = readData.SeaSeries_FK623ReadData(textFormat, MacSN, url, name, pwd, false, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    }


                    MacMsg = string.Format("{0} /{1} ", RecordIndex, RecordCount);
                    readData = null;
                    app.IsAll = true;
                    break;
                case 3://下载登记资料
                    ret = SeaSeries_DownloadInfo(url, name, pwd, MacSN, ref MacMsg);
                    break;
                case 4://U盘下载登记资料

                    ret = DownloadInfoUSB(Oprt, ref MacMsg);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = "";
                    break;
                case 5://上传登记资料 
                    ret = SeaSeries_UploadInfo(url, name, pwd, MacSN, ref MacMsg);
                    break;
                case 6://U盘上传登记资料

                    ret = UploadInfoUSB(Oprt, ref MacMsg);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = "";
                    break;
                case 7://清除刷卡记录
                    ret = SeaSeries_ClearData(url, name, pwd);
                    break;
                case 8://清除管理员
                    DeviceObject.objFK623.RunCode = (int)FKRun.RUNERR_UNKNOWNERROR;
                    MacMsg = Pub.GetResText("", "ErrorMacParam", "");
                    //  ret = ClearManager();
                    break;
                case 9://清除登记资料
                    ret = SeaSeries_ClearInfo(url, name, pwd);
                    break;
                case 10://清除离职人员登记资料
                    ret = SeaSeries_ClearInfoDim(url, name, pwd, MacSN, ref MacMsg);
                    break;
                case 11://初始化机器
                    ret = SeaSeries_InitDevice(url, name, pwd);
                    break;
                case 13://导入U盘数据
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]");
                    RefreshMsg(Oprt + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.ProgressType = eProgressItemType.Marquee;
                    progBar.Value = 0;
                    ret = readData.FK623ReadDataUSB(usbFile, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    if (!ret) MacMsg = DeviceObject.objFK623.ErrMsg;
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    RefreshMsg("");
                    break;
                case 14://导入文本数据
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]");
                    RefreshMsg(Oprt + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.ProgressType = eProgressItemType.Marquee;
                    progBar.Value = 0;
                    ret = readData.ReadDataText(usbFile, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    RefreshMsg("");
                    break;
                case 15://选择人员下载登记资料
                    ret = SeaSeries_DownloadInfo(selectEmpList, url, name, pwd, MacSN, ref MacMsg);
                    break;
                case 16://选择人员删除登记资料
                    ret = SeaSeries_ClearInfo(selectEmpList, url, name, pwd, MacSN);
                    MacMsg = string.Format("{0}", selectEmpList.Count);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    break;
            }
            return ret;
        }


        private bool Star_ExecMacCommand(string Oprt, byte flag, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            byte IsNew = 0;
            if (flag == 2) IsNew = 1;
            int RecordCount = 0;
            int RecordIndex = 0;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://同步时间
                    ret = Star_SyncTime();
                    break;
                case 1://机器信息
                    ret = Star_ReadMacInfo(MacSN);
                    break;
                case 2:
                case 12:
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]", IsNew);
                    MsgString = lblMsg.Text;

                    //回收选择记录
                    if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetSelectData", "")))
                    {
                        app.IsAll = true;
                        progBar.ProgressType = eProgressItemType.Marquee;
                        progBar.Value = 0;
                        ret = readData.Star_FK623ReadData(textFormat, MacSN, true, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                        RecordCount = RecordIndex;
                    }
                    //设置定时回收记录(必须在前)
                    else if (MsgString.Contains(Pub.GetResText(formCode, "MsgSetTimingData", "")))
                    {
                        app.IsAll = true;
                        MacMsg = Oprt;
                        ret = true;
                        readData = null;
                        break;
                    }
                    //回收所有记录
                    else if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetAllData", "")))
                    {
                        app.IsAll = true;
                        progBar.ProgressType = eProgressItemType.Standard;
                        progBar.Value = 0;
                        ret = readData.Star_FK623ReadData(textFormat, MacSN, false, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    }
                    //回收新纪录
                    else if (MsgString.Contains(Pub.GetResText(formCode, "MsgGetNewData", "")))
                    {
                        app.IsAll = false;
                        progBar.ProgressType = eProgressItemType.Standard;
                        progBar.Value = 0;
                        ret = readData.Star_FK623ReadData(textFormat, MacSN, false, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    }

                    MacMsg = string.Format("{0} /{1} ", RecordIndex, RecordCount);
                    readData = null;
                    app.IsAll = true;
                    break;
                case 3://下载登记资料
                    ret = Star_DownloadInfo(selectEmpList, true, ref MacMsg);
                    break;
                case 4://U盘下载登记资料

                    ret = DownloadInfoUSB(Oprt, ref MacMsg);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = "";
                    break;
                case 5://上传登记资料 
                    ret = Star_UploadInfo(MacSN, ref MacMsg);
                    break;
                case 6://U盘上传登记资料

                    ret = UploadInfoUSB(Oprt, ref MacMsg);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = "";
                    break;
                case 7://清除刷卡记录
                    ret = Star_ClearData();
                    break;
                case 8://清除管理员
                    ret = Star_ClearManager();
                    break;
                case 9://清除登记资料
                    ret = Star_ClearInfo(selectEmpList, true);
                    break;
                case 10://清除离职人员登记资料
                    ret = Star_ClearInfoDim(ref MacMsg);
                    break;
                case 11://初始化机器
                    ret = Star_ClearData();
                    ret = Star_ClearInfo(selectEmpList, true);
                    ret = Star_InitDevice();
                    break;
                case 13://导入U盘数据
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]");
                    RefreshMsg(Oprt + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.ProgressType = eProgressItemType.Marquee;
                    progBar.Value = 0;
                    ret = readData.FK623ReadDataUSB(usbFile, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    if (!ret) MacMsg = DeviceObject.objFK623.ErrMsg;
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    RefreshMsg("");
                    break;
                case 14://导入文本数据
                    if (readData == null) readData = new FingerReadData(TitleBar.Text + "[" + Oprt + "]");
                    RefreshMsg(Oprt + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.ProgressType = eProgressItemType.Marquee;
                    progBar.Value = 0;
                    ret = readData.ReadDataText(usbFile, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    MacMsg += "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    RefreshMsg("");
                    break;
                case 15://选择人员下载登记资料
                    ret = Star_DownloadInfo(selectEmpList, false, ref MacMsg);
                    break;
                case 16://选择人员删除登记资料
                    ret = Star_ClearInfo(selectEmpList, false);
                    MacMsg = string.Format("{0}", selectEmpList.Count);
                    lblMsg.Text = MsgString + MacMsg;
                    readData = null;
                    break;
            }
            return ret;
        }

        private bool SyncTime()
        {
            bool ret = false;
            DateTime dt = new DateTime();
            if (SystemInfo.db.GetServerDate(ref dt))
            {
                ret = DeviceObject.objFK623.SetDeviceTime(dt);
            }
            return ret;
        }

        private bool Star_SyncTime()
        {
            bool ret = false;
            DateTime dt = new DateTime();
            if (SystemInfo.db.GetServerDate(ref dt))
            {
                string cmd = "SetTime";
                SetTimeCmd setTimeCmd = new SetTimeCmd(dt.ToString(SystemInfo.StarDateTimeFMT));
                _DeviceCmd<SetTimeCmd> devSetTimeCmd = new _DeviceCmd<SetTimeCmd>(cmd, setTimeCmd);
                StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devSetTimeCmd));
                if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                {
                    int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                    if (state == 0)
                    {
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
            return ret;
        }

        private bool SeaSeries_SyncTime(string url, string name, string pwd)
        {
            bool ret = false;
            DateTime dt = new DateTime();
            string syncTime = "";
            if (SystemInfo.db.GetServerDate(ref dt))
            {
                url = url + "action/SetSysTime";
                SeaSeriesSyncTime seaSeriesSyncTime = new SeaSeriesSyncTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                jsonBody<SeaSeriesSyncTime> jsonBody = new jsonBody<SeaSeriesSyncTime>("SetSysTime", seaSeriesSyncTime);
                syncTime = JsonConvert.SerializeObject(jsonBody);
                ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref syncTime);
            }

            return ret;
        }

        private bool ReadMacInfo(string MacSN)
        {
            int MacMANAGERS = 0;
            int MacUSERS = 0;
            int MacFPS = 0;
            int MacFaceS = 0;
            int MacPSWS = 0;
            int MacCARDS = 0;
            int MacPALMVEINS = 0;
            int MacGLOGS = 0;
            int MacAGLOGS = 0;

            bool ret = DeviceObject.objFK623.GetDeviceInfo(ref MacMANAGERS, ref MacUSERS, ref MacFPS, ref MacFaceS,
              ref MacPSWS, ref MacCARDS, ref MacPALMVEINS, ref MacGLOGS, ref MacAGLOGS);
            if (ret)
            {
                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "300", MacMANAGERS.ToString(), MacUSERS.ToString(),
          MacFPS.ToString(), MacFaceS.ToString(), MacPSWS.ToString(), MacCARDS.ToString(), MacPALMVEINS.ToString(),
          MacGLOGS.ToString(), MacAGLOGS.ToString(), MacSN });
                try
                {
                    SystemInfo.db.ExecSQL(sql);
                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        if (dataGrid[1, i].Value.ToString() == MacSN)
                        {
                            dataGrid[14, i].Value = MacMANAGERS;
                            dataGrid[15, i].Value = MacUSERS;
                            dataGrid[16, i].Value = MacFPS;
                            dataGrid[17, i].Value = MacFaceS;
                            dataGrid[18, i].Value = MacPSWS;
                            dataGrid[19, i].Value = MacCARDS;
                            dataGrid[20, i].Value = MacPALMVEINS;
                            dataGrid[21, i].Value = MacGLOGS;
                            dataGrid[22, i].Value = MacAGLOGS;
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
            if (ret)
            {
                if (SystemInfo.ShowMJ == 1)
                {
                    bool b = MJDoorStateGet(MacSN);
                    if (!b)
                    {
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_NOSUPPORT)
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                        else
                            ret = false;
                    }
                }

            }
            return ret;
        }

        private bool Star_ReadMacInfo(string MacSN)
        {
            bool ret = false;
            int MacMANAGERS = 0;
            int MacUSERS = 0;
            int MacFPS = 0;
            int MacFaceS = 0;
            int MacPSWS = 0;
            int MacCARDS = 0;
            int MacPALMVEINS = 0;
            int MacGLOGS = 0;
            int MacAGLOGS = 0;
            string cmd = "GetDeviceInfo";
            DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));

            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    _ResultInfo<DeviceInfo> deviceInfo = JsonConvert.DeserializeObject<_ResultInfo<DeviceInfo>>(jsonStringBuilder.ToString());
                    MacMANAGERS = deviceInfo.result_data.managerCount;
                    MacUSERS = deviceInfo.result_data.userCount;
                    MacFPS = deviceInfo.result_data.fpCount;
                    MacFaceS = deviceInfo.result_data.faceCount;
                    MacPSWS = deviceInfo.result_data.pwdCount;
                    MacCARDS = deviceInfo.result_data.cardCount;
                    MacGLOGS = deviceInfo.result_data.logCount;
                    MacAGLOGS = deviceInfo.result_data.allLogCount;
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
            if (ret)
            {
                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "300", MacMANAGERS.ToString(), MacUSERS.ToString(),
          MacFPS.ToString(), MacFaceS.ToString(), MacPSWS.ToString(), MacCARDS.ToString(), MacPALMVEINS.ToString(),
          MacGLOGS.ToString(), MacAGLOGS.ToString(), MacSN });
                try
                {
                    SystemInfo.db.ExecSQL(sql);
                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        if (dataGrid[1, i].Value.ToString() == MacSN)
                        {
                            dataGrid[14, i].Value = MacMANAGERS;
                            dataGrid[15, i].Value = MacUSERS;
                            dataGrid[16, i].Value = MacFPS;
                            dataGrid[17, i].Value = MacFaceS;
                            dataGrid[18, i].Value = MacPSWS;
                            dataGrid[19, i].Value = MacCARDS;
                            dataGrid[20, i].Value = MacPALMVEINS;
                            dataGrid[21, i].Value = MacGLOGS;
                            dataGrid[22, i].Value = MacAGLOGS;
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

        private bool SeaSeries_ReadMacInfo(string MacSN, string url, string name, string pwd)
        {
            bool ret = false;
            int MacMANAGERS = 0;
            int MacUSERS = 0;
            int MacFPS = 0;
            int MacFaceS = 0;
            int MacPSWS = 0;
            int MacCARDS = 0;
            int MacPALMVEINS = 0;
            int MacGLOGS = 0;
            int MacAGLOGS = 0;
            string infoUrl = url + "action/GetMachineInfo";

            string jsonBodyStr = "";
            ret = DeviceObject.objFK623.POST_GetResponse(infoUrl, name, pwd, ref jsonBodyStr);

            if (ret)
            {
                jsonBody<GetMachineInfo> getMachineInfo = JsonConvert.DeserializeObject<jsonBody<GetMachineInfo>>(jsonBodyStr);
                MacUSERS = getMachineInfo.info.PersonNum;
                MacFaceS = MacUSERS;
                MacCARDS = getMachineInfo.info.CardNum;
                MacAGLOGS = getMachineInfo.info.RecordNum;

                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "300", MacMANAGERS.ToString(), MacUSERS.ToString(),
          MacFPS.ToString(), MacFaceS.ToString(), MacPSWS.ToString(), MacCARDS.ToString(), MacPALMVEINS.ToString(),
          MacGLOGS.ToString(), MacAGLOGS.ToString(), MacSN });
                try
                {
                    SystemInfo.db.ExecSQL(sql);
                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        if (dataGrid[1, i].Value.ToString() == MacSN)
                        {
                            dataGrid[14, i].Value = MacMANAGERS;
                            dataGrid[15, i].Value = MacUSERS;
                            dataGrid[16, i].Value = MacFPS;
                            dataGrid[17, i].Value = MacFaceS;
                            dataGrid[18, i].Value = MacPSWS;
                            dataGrid[19, i].Value = MacCARDS;
                            dataGrid[20, i].Value = MacPALMVEINS;
                            dataGrid[21, i].Value = MacGLOGS;
                            dataGrid[22, i].Value = MacAGLOGS;
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

        private void CountFingerInfo(int BackupNumber, ref int FingerCount, ref int PSWCount, ref int CardCount,
          ref int FaceCount, ref int PalmVeinCnt)
        {
            switch (BackupNumber)
            {
                case (int)FKBackup.BACKUP_FP_0:
                case (int)FKBackup.BACKUP_FP_1:
                case (int)FKBackup.BACKUP_FP_2:
                case (int)FKBackup.BACKUP_FP_3:
                case (int)FKBackup.BACKUP_FP_4:
                case (int)FKBackup.BACKUP_FP_5:
                case (int)FKBackup.BACKUP_FP_6:
                case (int)FKBackup.BACKUP_FP_7:
                case (int)FKBackup.BACKUP_FP_8:
                case (int)FKBackup.BACKUP_FP_9:
                    FingerCount++;
                    break;
                case (int)FKBackup.BACKUP_PSW:
                    PSWCount++;
                    break;
                case (int)FKBackup.BACKUP_CARD:
                    CardCount++;
                    break;
                case (int)FKBackup.BACKUP_FACE:
                    FaceCount++;
                    break;
                case (int)FKBackup.BACKUP_PALMVEIN_0:
                case (int)FKBackup.BACKUP_PALMVEIN_1:
                case (int)FKBackup.BACKUP_PALMVEIN_2:
                case (int)FKBackup.BACKUP_PALMVEIN_3:
                    PalmVeinCnt++;
                    break;
            }
        }

        private void AddDownInfo(TDownInfoList downInfo)
        {
            bool isFind = false;
            for (int i = 0; i < downList.Count; i++)
            {
                if (downList[i].EnrollNumber == downInfo.EnrollNumber)
                {
                    isFind = true;
                    break;
                }
            }
            if (!isFind) downList.Add(downInfo);
        }

        private bool FindExecInfo(UInt32 EnrollNumber, int BackupNumber)
        {
            bool ret = false;
            for (int i = 0; i < execList.Count; i++)
            {
                if (execList[i].EnrollNumber == EnrollNumber && execList[i].BakNo == BackupNumber)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        private bool MJPowerDownload(UInt32 fingerNo, ref string StartDate, ref string EndDate)
        {
            bool ret = true;
            byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
            ExtCmd_USERDOORINFO ui = new ExtCmd_USERDOORINFO();

            ui.Init(false, fingerNo);
            DeviceObject.objFK623.StructToByteArray(ui, byt);
            ret = DeviceObject.objFK623.ExtCommand(byt);
            if (!ret)
            {
                return ret;
            }

            ui = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));

            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
            ret = true;
            DataTableReader dr = null;
            string EmpNo = "";

            DateTime dt;
            try
            {
                ret = SystemInfo.db.GetEmpNoByFingerNo(ui.UserID, ref EmpNo);
                if (!ret) return ret;

                StartDate = "NULL";
                dt = new DateTime();
                try
                {
                    dt = new DateTime(ui.StartYear, ui.StartMonth, ui.StartDay);
                    StartDate = dt.ToString(SystemInfo.SQLDateFMT);
                }
                catch
                {

                }
                EndDate = "NULL";
                try
                {
                    dt = new DateTime(ui.EndYear, ui.EndMonth, ui.EndDay);
                    EndDate = dt.ToString(SystemInfo.SQLDateFMT);
                }
                catch
                {

                }
            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }

            return ret;
        }


        private bool DownloadInfo(ref string MacMsg)
        {
            downList.Clear();
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int PasswordData = 0;
            byte[] fpData = new byte[(int)FKMax.FK_FaceDataSize];
            string EnrollName = "";
            DialogResult MessRet;
            string EmpNo = "";
            bool ReqName = false;
            int FingerCount = 0;
            int PSWCount = 0;
            int CardCount = 0;
            int FaceCount = 0;
            int PalVeinCnt = 0;
            int EmpCount = 0;
            int ErrCode = 0;
            execList.Clear();
            string StatusMsg = lblMsg.Text;
            progBar.ProgressType = eProgressItemType.Standard;
            ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_USERS, ref EmpCount);
            if (!ret) return false;
            ReOpen:
            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.ReadAllUserID();
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (!ret) return false;
            do
            {
            FFF:
                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetAllUserID(ref EnrollNumber, ref BackupNumber,
                  ref Privilege, ref EnableFlag);
                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                {
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    break;
                }
                if (FindExecInfo(EnrollNumber, BackupNumber)) goto FFF;
                EEE:
                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetEnrollData(EnrollNumber, BackupNumber,
                  ref Privilege, fpData, ref PasswordData);

                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                {
                    ErrCode = DeviceObject.objFK623.RunCode;
                    if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_READ_FAIL)
                    {
                        if (DeviceObject.objFK623.ReOpen()) goto ReOpen;
                        DeviceObject.objFK623.RunCode = ErrCode;
                    }
                    MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                      Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                    if (MessRet == DialogResult.Yes)
                        goto EEE;
                    else if (MessRet == DialogResult.Cancel)
                        break;
                    else
                        goto FFF;
                }
                CountFingerInfo(BackupNumber, ref FingerCount, ref PSWCount, ref CardCount, ref FaceCount, ref PalVeinCnt);
                SystemInfo.db.SaveEnrollToDB(EnrollNumber, BackupNumber, EnableFlag, Privilege, PasswordData,
                  fpData, "", ref ReqName);


                AddDownInfo(new TDownInfoList(EnrollNumber, ReqName));
                execList.Add(new TDimInfo(EnrollNumber, BackupNumber));
                lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                  string.Format(" - {2}/{3}  [{0}: {1}]", EnrollNumber, BackupNumber, downList.Count, EmpCount);
                if (EmpCount > 0)
                    progBar.Value = downList.Count * 100 / EmpCount;
                Application.DoEvents();
            }
            while (true);
            byte[] buff = new byte[0];
            byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
            ExtCmd_USERDOORINFO ui = new ExtCmd_USERDOORINFO();
            DateTime dt;
            string StartDate = "";
            string EndDate = "";
            bool retDate = false;
            StatusMsg = StatusMsg + Pub.GetResText(formCode, "MsgFingerName", "");
            for (int i = 0; i < downList.Count; i++)
            {
                EnrollNumber = downList[i].EnrollNumber;
                lblMsg.Text = StatusMsg + string.Format(" - {1}/{2}  [{0}]", EnrollNumber, i + 1, downList.Count);
                progBar.Value = (i + 1) * 100 / downList.Count;

                ui.Init(false, EnrollNumber);
                DeviceObject.objFK623.StructToByteArray(ui, byt);
                retDate = DeviceObject.objFK623.ExtCommand(byt);
                ui = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));

                StartDate = "";
                dt = new DateTime();
                try
                {
                    dt = new DateTime(ui.StartYear, ui.StartMonth, ui.StartDay);
                    StartDate = dt.ToString(SystemInfo.SQLDateFMT);
                }
                catch
                {
                }
                EndDate = "";
                try
                {
                    dt = new DateTime(ui.EndYear, ui.EndMonth, ui.EndDay);
                    EndDate = dt.ToString(SystemInfo.SQLDateFMT);
                }
                catch
                {
                }

                if (downList[i].ReqName)
                {
                    EnrollName = "";
                    DeviceObject.objFK623.GetUserName(EnrollNumber, ref EnrollName);
                    if (EnrollName != "") SystemInfo.db.SetEmpNameByFinger(EnrollNumber, EnrollName);
                }
                if (SystemInfo.db.GetEmpNoByFingerNo(EnrollNumber, ref EmpNo))
                {

                    if (retDate)
                    {
                        if (SystemInfo.DBType == 0)
                        {
                            if (StartDate == "") StartDate = "NULL";
                            else StartDate = "CDate('" + StartDate + "')";
                            if (EndDate == "") EndDate = "NULL";
                            else EndDate = "CDate('" + EndDate + "')";
                        }
                        else
                        {
                            if (StartDate == "") StartDate = "NULL";
                            else StartDate = "'" + StartDate + "'";
                            if (EndDate == "") EndDate = "NULL";
                            else EndDate = "'" + EndDate + "'";
                        }
                        //保存有效期
                        string sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "36", EmpNo, StartDate, EndDate });
                        SystemInfo.db.ExecSQL(sql);
                    }

                    if (DeviceObject.objFK623.GetEnrollPhoto(EnrollNumber, ref buff) && buff.Length > 0)
                    {
                        SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "7", EmpNo }),
                          "EmpPhotoImage", buff);
                    }
                }
                buff = null;
                Application.DoEvents();
            }

            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgDownInfo", "");
                MacMsg = string.Format(tmp, downList.Count, FingerCount, FaceCount, PSWCount, CardCount, PalVeinCnt, "0");
            }
            SystemInfo.db.UpdateEmpInfoCount(this.Text);
            SystemInfo.db.UpdateEmpInfoCount_Star();
            return ret;
        }

        private bool Star_DownloadInfo(List<UInt32> downUserIdList, bool IsAll, ref string MacMsg)
        {
            if (!IsAll)
            {
                //从数据库获得登记号列表对比，用于提示
                fingerNoList.Clear();
                DataTableReader dr = null;
                try
                {
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "508" }));
                    while (dr.Read())
                    {
                        fingerNoList.Add(Convert.ToUInt32(dr["FingerNo"].ToString()));
                    }
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                    return false;
                }
                //对比提示重复
                List<string> repeatUserId = new List<string>();
                foreach (var item in downUserIdList)
                {
                    if (fingerNoList.Contains(item))
                    {
                        repeatUserId.Add(item.ToString());
                    }
                }
                if (repeatUserId.Count > 0)
                {
                    if (Pub.MessageBoxShowQuestion(string.Format(Pub.GetResText("Public", "MsgRepeatNo", ""), string.Join(",", repeatUserId.ToArray()))))
                    {
                        MacMsg = Pub.GetResText("Public", "btnCancel", "");
                        return false;
                    }
                }
            }

            downList.Clear();
            bool ret = false;
            int Privilege = 0;
            byte[] fpData = new byte[(int)FKMax.FK_FaceDataSize];
            string EmpNo = "";
            int FingerCount = 0;
            int PSWCount = 0;
            int CardCount = 0;
            int FaceCount = 0;
            int PalVeinCnt = 0;
            string StartDate = "";
            string EndDate = "";
            execList.Clear();
            DataTable dtInsert = new DataTable();
            DataTable dtUpdate = new DataTable();
            DataTable dtSelect = new DataTable();
            DataTable dtSelectData = new DataTable();
            DataTable dtInsertData = new DataTable();
            DataTable dtUpdateData = new DataTable();
            DataRow[] rows = null;
            DataRow[] rowsData = null;
            string HireDate = "";
            string EmpSex = "";

            int userCount = 0;
            byte[] CardData = new byte[0];
            byte[] PwdData = new byte[0];

            byte[] EmpPhotoBuff = null;

            byte[] face00 = new byte[0];
            byte[] palm00 = new byte[0];
            byte[] photo = new byte[0];
            int sendCount = 0;
            int count = 0;
            string cmd = "";
            int UsersCount = 0;
            StringBuilder jsonStringBuilder = null;
            string StatusMsg = lblMsg.Text;
            progBar.ProgressType = eProgressItemType.Standard;
            List<_ResultInfo<PersonInfo<GetUsers>>> PersonInfoList = new List<_ResultInfo<PersonInfo<GetUsers>>>();
            List<string> usersIDList = new List<string>();

            try
            {
                dtInsert = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "37" }));
                dtUpdate = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "37" }));
                dtSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "27" }));
                dtSelectData = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "28" }));
                dtInsertData = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "29" }));
                dtUpdateData = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "29" }));
                progBar.ProgressType = eProgressItemType.Marquee;
                ret = true;

                sendCount = 0;
                PersonInfoList.Clear();
                GetUserInfoCmd getUserInfoCmd = null;

                if (IsAll)
                {
                    #region 首先获取机器上的所有用户数
                    cmd = "GetDeviceInfo";
                    DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
                    jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));

                    if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                    {
                        int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                        if (state == 0)
                        {
                            _ResultInfo<DeviceInfo> deviceInfo = JsonConvert.DeserializeObject<_ResultInfo<DeviceInfo>>(jsonStringBuilder.ToString());
                            UsersCount = deviceInfo.result_data.userCount;
                        }
                    }

                    #endregion
                    getUserInfoCmd = new GetUserInfoCmd(0, null);
                }
                else
                {
                    for (int i = 0; i < downUserIdList.Count; i++)
                    {
                        usersIDList.Add(downUserIdList[i].ToString());
                    }
                    if (usersIDList != null || usersIDList.Count > 0)
                    {
                        UsersCount = usersIDList.Count;
                    }

                    getUserInfoCmd = new GetUserInfoCmd(0, usersIDList);
                }
                if (UsersCount <= 0)
                {
                    DeviceObject.socKetClient.ErrMsg = Pub.GetResText("", "FK_RUNERR_DATAARRAY_NONE", "");
                    ret = false;
                    return ret;
                }
                cmd = "GetUserInfo";
                _DeviceCmd<GetUserInfoCmd> devGetUserInfoCmd = new _DeviceCmd<GetUserInfoCmd>(cmd, getUserInfoCmd);
                while (true)
                {
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgGetDataInfoBao", "") + " - " + devGetUserInfoCmd.data.packageId;
                    Application.DoEvents();

                    jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devGetUserInfoCmd));
                    if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                    {
                        int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                        if (state == 0)
                        {
                            _ResultInfo<PersonInfo<GetUsers>> getUserInfo = JsonConvert.DeserializeObject<_ResultInfo<PersonInfo<GetUsers>>>(jsonStringBuilder.ToString());

                            if (getUserInfo.result_data.users == null)
                            {
                                ret = false;
                                break;
                            }

                            PersonInfoList.Add(getUserInfo);

                            if (getUserInfo.result_data.packageId != 0)//表示没有获取完数据，让packageId+1，重新发送获取获取下一包数据
                            {
                                devGetUserInfoCmd.data.packageId++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (state == -6)
                        {
                            sendCount++;
                            if (sendCount > 2)
                            {
                                ret = false;
                                break;
                            }
                            else
                            {
                                if (DeviceObject.socKetClient.Open()) continue;
                                else
                                {
                                    ret = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            ret = false;
                            break;
                        }
                    }
                    else
                    {
                        if (DeviceObject.socKetClient.ErrMsg.Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.socKetClient.ErrMsg + "\r\n\r\n" +
                     Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                            if (MessRet == DialogResult.OK)
                            {
                                if (DeviceObject.socKetClient.Open()) continue;
                                else
                                {
                                    ret = false;
                                    break;
                                }
                            }
                            else
                            {
                                ret = false;
                                break;
                            }
                        }
                    }
                }
                if (PersonInfoList.Count > 0)
                {
                    progBar.ProgressType = eProgressItemType.Standard;
                    for (int l = 0; l < PersonInfoList.Count; l++)
                    {
                        _ResultInfo<PersonInfo<GetUsers>> getUserInfo = PersonInfoList[l];
                        for (int i = 0; i < getUserInfo.result_data.users.Length; i++)
                        {
                            count++;

                            face00 = null;
                            palm00 = null;
                            photo = null;
                            EmpPhotoBuff = null;

                            if (getUserInfo.result_data.users[i].photo != null)
                            {
                                string photoStr = getUserInfo.result_data.users[i].photo;
                                photo = Convert.FromBase64String(photoStr);

                                MemoryStream ms = new MemoryStream(photo);
                                Image empPhotoImage = CustomSizeImage(Image.FromStream(ms));
                                ms.Dispose();
                                using (Bitmap t = new Bitmap(empPhotoImage))
                                {
                                    ms = new MemoryStream();
                                    t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    EmpPhotoBuff = ms.ToArray();
                                    ms.Dispose();
                                    ms.Close();
                                }
                            }
                            StartDate = getUserInfo.result_data.users[i].vaildStart;
                            EndDate = getUserInfo.result_data.users[i].vaildEnd;

                            StartDate = stringToTimeStr(StartDate);
                            EndDate = stringToTimeStr(EndDate);

                            StartDate = CheckTimeStr(StartDate);
                            EndDate = CheckTimeStr(EndDate);

                            if (!string.IsNullOrEmpty(getUserInfo.result_data.users[i].pwd))
                            {
                                PSWCount++;
                            }
                            if (!string.IsNullOrEmpty(getUserInfo.result_data.users[i].card))
                            {
                                CardCount++;
                            }

                            rows = dtSelect.Select("FingerNo=" + getUserInfo.result_data.users[i].userId + "");
                            if (rows.Length > 0)
                            {
                                EmpNo = rows[0]["EmpNo"].ToString();
                                HireDate = rows[0]["EmpHireDate"].ToString();

                                dtUpdate.Rows.Add(new object[] { EmpNo, getUserInfo.result_data.users[i].name, EmpSex, SystemInfo.CommanyID, HireDate , "",
                                getUserInfo.result_data.users[i].card,getUserInfo.result_data.users[i].pwd,getUserInfo.result_data.users[i].userId,Privilege.ToString(), true,
                                "","",false,EmpPhotoBuff,"",StartDate,EndDate});
                            }
                            else
                            {
                                EmpNo = SystemInfo.db.GetAutoEmpNo(Convert.ToUInt32(getUserInfo.result_data.users[i].userId));
                                HireDate = DateTime.Now.ToString(Pub.GetResText("", "YMWFormatForm", ""));
                                dtSelect.Rows.Add(new object[] { getUserInfo.result_data.users[i].userId, EmpNo, HireDate });
                                dtInsert.Rows.Add(new object[] { EmpNo, getUserInfo.result_data.users[i].name, EmpSex, SystemInfo.CommanyID, HireDate , "",
                                getUserInfo.result_data.users[i].card,getUserInfo.result_data.users[i].pwd,getUserInfo.result_data.users[i].userId,Privilege.ToString(), true,
                                "","",false,EmpPhotoBuff,"",StartDate,EndDate});
                            }

                            if (getUserInfo.result_data.users[i].face != null)
                            {
                                string faceStr = getUserInfo.result_data.users[i].face;
                                face00 = Convert.FromBase64String(faceStr);
                                FaceCount++;
                            }
                            if (getUserInfo.result_data.users[i].palm != null)
                            {
                                string palmStr = getUserInfo.result_data.users[i].palm;
                                palm00 = Convert.FromBase64String(palmStr);
                                PalVeinCnt++;
                            }
                            if (getUserInfo.result_data.users[i].fps != null)
                            {
                                for (int j = 0; j < getUserInfo.result_data.users[i].fps.Count; j++)
                                {
                                    if (getUserInfo.result_data.users[i].fps[j] != null)
                                    {
                                        #region 指纹
                                        //FingerCount++;
                                        //string fpsStr = getUserInfo.result_data.users[i].fps[j];
                                        //switch (j)
                                        //{
                                        //    case 0:
                                        //        fps00 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 1:
                                        //        fps01 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 2:
                                        //        fps02 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 3:
                                        //        fps03 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 4:
                                        //        fps04 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 5:
                                        //        fps05 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 6:
                                        //        fps06 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 7:
                                        //        fps07 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 8:
                                        //        fps08 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //    case 9:
                                        //        fps09 = Convert.FromBase64String(fpsStr);
                                        //        break;
                                        //}
                                        #endregion
                                        FingerCount++;
                                        byte[] fpDatas = Convert.FromBase64String(getUserInfo.result_data.users[i].fps[j]);
                                        byte[] buff = new byte[1680];
                                        byte[] FpDataConv = new byte[1680];
                                        byte[] header = { 0x45, 0x4e, 0x52, 0x4f, 0x4c, 0x4c, 0x46, 0x50, 0x01, 0x28 };
                                        Array.Copy(header, 0, FpDataConv, 0, header.Length); //Add Fixed Header 
                                        Array.Copy(fpDatas, 0, FpDataConv, 80, fpDatas.Length);
                                        ObjFpReader.ConvEnrollData(FpDataConv, ref buff, 1680);

                                        SystemInfo.db.SaveStarEnrollToDB(UInt32.Parse(getUserInfo.result_data.users[i].userId), buff, j.ToString());

                                    }
                                }
                            }

                            rowsData = dtSelectData.Select("FingerNo=" + getUserInfo.result_data.users[i].userId + "");
                            if (rowsData.Length == 0)
                            {
                                dtInsertData.Rows.Add(new object[] { EmpNo,getUserInfo.result_data.users[i].userId, null, null, null, null, null, null, null, null, null, null,
                               face00,palm00 });
                            }
                            else
                            {
                                dtUpdateData.Rows.Add(new object[] { EmpNo,getUserInfo.result_data.users[i].userId, null, null, null, null, null, null, null, null, null, null,
                               face00,palm00 });
                            }

                            userCount++;
                            lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                          string.Format(" - {2}/{3}  [{0}: {1}]", getUserInfo.result_data.users[i].userId, getUserInfo.result_data.users[i].name, userCount, UsersCount);
                            if (userCount > 0)
                                progBar.Value = userCount * 100 / UsersCount;
                            Application.DoEvents();

                            if (dtInsert.Rows.Count > 100)
                            {
                                SystemInfo.db.batchEmpInSertData(dtInsert, "RS_Emp");
                                dtInsert.Clear();
                            }
                            if (dtUpdate.Rows.Count > 100)
                            {
                                SystemInfo.db.batchEmpUpdateData(dtUpdate, "RS_Emp", "EmpNo");
                                dtUpdate.Clear();
                            }

                            if (dtInsertData.Rows.Count > 100)
                            {
                                SystemInfo.db.batchEmpInSertData(dtInsertData, "RS_EmpDynamicInfo");
                                dtInsertData.Clear();
                            }
                            if (dtUpdateData.Rows.Count > 100)
                            {
                                SystemInfo.db.batchEmpUpdateData(dtUpdateData, "RS_EmpDynamicInfo", "EmpNo");
                                dtUpdateData.Clear();
                            }
                        }
                        if (dtInsert.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsert, "RS_Emp");
                            dtInsert.Clear();
                        }
                        if (dtUpdate.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdate, "RS_Emp", "EmpNo");
                            dtUpdate.Clear();
                        }

                        if (dtInsertData.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsertData, "RS_EmpDynamicInfo");
                            dtInsertData.Clear();
                        }
                        if (dtUpdateData.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdateData, "RS_EmpDynamicInfo", "EmpNo");
                            dtUpdateData.Clear();
                        }
                    }
                }
                SystemInfo.db.UpdateEmpInfoCount("");
                SystemInfo.db.UpdateEmpInfoCount_Star();
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgDownInfo_Star", "");
                MacMsg = string.Format(tmp, userCount, FingerCount, FaceCount, PSWCount, CardCount, PalVeinCnt);
            }

            return ret;
        }

        private bool SeaSeries_DownloadInfo(string url, string name, string pwd, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            string HireDate = "";
            int Privilege = 0;
            byte[] Photo = new byte[0];
            int EmpCount = 0;
            DataRow[] rows = null;
            string EmpNo = "";
            byte[] EmpPhotoBuff = null;
            byte[] PhotoBuff = null;
            int PersonNum = 0;
            int PhotoCount = 0;
            string EmpSex = "";
            string jsonString = "";
            string StatusMsg = lblMsg.Text;
            string CardNo = "";
            int userCount = 0;
            int CardCount = 0;
            string StartDate = "";
            string EndDate = "";

            byte[] CardData = new byte[0];

            progBar.ProgressType = eProgressItemType.Standard;

            DataTable dtInsert = new DataTable();
            DataTable dtUpdate = new DataTable();
            DataTable dtSelect = new DataTable();
            try
            {
                dtInsert = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "26" }));
                dtUpdate = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "26" }));
                dtSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "27" }));

                //查询人员总数
                string searchTotlePersonUrl = url + "action/SearchPersonNum";
                SearchTotlePerson searchTotlePerson = new SearchTotlePerson(Convert.ToInt32(MacSN), 0, "", "", 2, "0-100", 0, "");
                jsonBody<SearchTotlePerson> jsonBodySearchTotlePerson = new jsonBody<SearchTotlePerson>("SearchPersonNum", searchTotlePerson);
                jsonString = JsonConvert.SerializeObject(jsonBodySearchTotlePerson);
                ret = DeviceObject.objFK623.POST_GetResponse(searchTotlePersonUrl, name, pwd, ref jsonString);
                if (!ret) return false;
                jsonBody<SearchTotlePersonInfo> searchTotlePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchTotlePersonInfo>>(jsonString);
                {
                    PersonNum = searchTotlePersonInfo.info.PersonNum;
                }
                if (PersonNum == 0)
                {
                    return false;
                }
                int i = 0;
                while (true)
                {
                    //查询人员
                    string searchMultipleUrl = url + "action/SearchPersonList";
                    SearchMultiplePerson searchMultiple = new SearchMultiplePerson(Convert.ToInt32(MacSN), 0, "", "", 2, "0-100", 0, "", i * 10, 10, 1);
                    i++;

                    jsonBody<SearchMultiplePerson> jsonBodySearchMultiplePerson = new jsonBody<SearchMultiplePerson>("SearchPersonList", searchMultiple);
                ES:
                    jsonString = JsonConvert.SerializeObject(jsonBodySearchMultiplePerson);
                    ret = DeviceObject.objFK623.POST_GetResponse(searchMultipleUrl, name, pwd, ref jsonString);
                    if (!ret)
                    {
                        if (DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                   Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                            if (MessRet == DialogResult.OK)
                            {
                                goto ES;
                            }
                            else
                            {
                                ret = false;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                    jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>> searchMultiplePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>>>(jsonString);
                    {
                        for (int j = 0; j < searchMultiplePersonInfo.info.Listnum; j++)
                        {
                            EmpCount++;
                            Photo = new byte[0];
                            if (!string.IsNullOrEmpty(searchMultiplePersonInfo.info.List[j].Picinfo))
                                Photo = Convert.FromBase64String(searchMultiplePersonInfo.info.List[j].Picinfo.Replace("data:image/jpeg;base64,", ""));
                            if (searchMultiplePersonInfo.info.List[j].RFIDCard != null)
                            {
                                CardNo = searchMultiplePersonInfo.info.List[j].RFIDCard.ToString();

                                if (CardNo != "")
                                    CardNo = HexToStr(CardNo);
                                if (CardNo.Length > 10) CardNo = CardNo.Substring(CardNo.Length - 10, 10);
                                CardCount++;
                            }
                            else
                            {
                                CardNo = searchMultiplePersonInfo.info.List[j].MjCardNo.ToString();
                                if (CardNo.Length > 1) CardCount++;
                                else
                                {
                                    CardNo = "";
                                }
                                if (CardNo.Length > 10) CardNo = CardNo.Substring(CardNo.Length - 10, 10);
                            }

                            if (searchMultiplePersonInfo.info.List[j].Gender == 0)
                            {
                                EmpSex = Pub.GetResText("", "EmpSex0", "");
                            }
                            else if (searchMultiplePersonInfo.info.List[j].Gender == 1)
                            {
                                EmpSex = Pub.GetResText("", "EmpSex1", "");
                            }
                            else
                            {
                                EmpSex = "";
                            }
                            if (searchMultiplePersonInfo.info.List[j].Tempvalid != 0)
                            {
                                StartDate = searchMultiplePersonInfo.info.List[j].ValidBegin;
                                EndDate = searchMultiplePersonInfo.info.List[j].ValidEnd;
                            }
                            else
                            {
                                StartDate = null;
                                EndDate = null;
                            }

                            if (Photo.Length > 1)
                            {
                                MemoryStream ms = new MemoryStream(Photo);
                                Image empPhotoImage = CustomSizeImage(Image.FromStream(ms));
                                ms.Dispose();
                                using (Bitmap t = new Bitmap(empPhotoImage))
                                {
                                    ms = new MemoryStream();
                                    t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    EmpPhotoBuff = ms.ToArray();
                                    ms.Dispose();
                                    ms.Close();
                                }

                                MemoryStream msi = new MemoryStream(Photo);
                                Image empPhoto = CustomSizePhoto(Image.FromStream(msi));
                                msi.Dispose();
                                using (Bitmap ti = new Bitmap(empPhoto))
                                {
                                    msi = new MemoryStream();
                                    ti.Save(msi, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    PhotoBuff = msi.ToArray();
                                    msi.Dispose();
                                    msi.Close();
                                }
                                PhotoCount = 1;
                            }
                            else
                            {
                                PhotoCount = 0;
                            }
                            EmpNo = "";
                            HireDate = "";

                            rows = dtSelect.Select("FingerNo=" + searchMultiplePersonInfo.info.List[j].CustomizeID + "");
                            if (rows.Length > 0)
                            {
                                EmpNo = rows[0]["EmpNo"].ToString();
                                HireDate = rows[0]["EmpHireDate"].ToString();

                                dtUpdate.Rows.Add(new object[] { EmpNo, searchMultiplePersonInfo.info.List[j].Name, EmpSex, SystemInfo.CommanyID, HireDate , searchMultiplePersonInfo.info.List[j].IdCard
                                ,CardNo,"",searchMultiplePersonInfo.info.List[j].CustomizeID,Privilege.ToString(), true,
                                searchMultiplePersonInfo.info.List[j].Address,searchMultiplePersonInfo.info.List[j].Telnum,false,
                                EmpPhotoBuff,PhotoBuff,PhotoCount,searchMultiplePersonInfo.info.List[j].Notes,StartDate,EndDate});
                            }
                            else
                            {
                                EmpNo = SystemInfo.db.GetAutoEmpNo(searchMultiplePersonInfo.info.List[j].CustomizeID);
                                HireDate = DateTime.Now.ToString(Pub.GetResText("", "YMWFormatForm", ""));
                                dtSelect.Rows.Add(new object[] { searchMultiplePersonInfo.info.List[j].CustomizeID, EmpNo, HireDate });
                                dtInsert.Rows.Add(new object[] { EmpNo, searchMultiplePersonInfo.info.List[j].Name, EmpSex, SystemInfo.CommanyID, HireDate , searchMultiplePersonInfo.info.List[j].IdCard
                                ,CardNo,"",searchMultiplePersonInfo.info.List[j].CustomizeID,Privilege.ToString(), true,
                                searchMultiplePersonInfo.info.List[j].Address,searchMultiplePersonInfo.info.List[j].Telnum,
                                false,EmpPhotoBuff,PhotoBuff,PhotoCount,searchMultiplePersonInfo.info.List[j].Notes,StartDate,EndDate});
                            }

                            userCount++;
                            lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                          string.Format(" - {2}/{3}  [{0}: {1}]", searchMultiplePersonInfo.info.List[j].CustomizeID, searchMultiplePersonInfo.info.List[j].Name, EmpCount, PersonNum);
                            if (EmpCount > 0)
                                progBar.Value = EmpCount * 100 / PersonNum;
                            Application.DoEvents();
                        }
                        if (dtInsert.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsert, "RS_Emp");
                            dtInsert.Clear();
                        }
                        if (dtUpdate.Rows.Count > 0)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdate, "RS_Emp", "EmpNo");
                            dtUpdate.Clear();
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
                string tmp = Pub.GetResText(formCode, "MsgDownInfo", "");
                MacMsg = string.Format(tmp, userCount, 0, 0, 0, CardCount, 0, userCount);
            }
            if (userCount > 0)
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                ret = true;
            }
            return ret;
        }

        private bool DownloadInfo(List<UInt32> downUserIdList, ref string MacMsg)
        {
            bool ret = false;
            //从数据库获得登记号列表对比，用于提示
            fingerNoList.Clear();
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "508" }));
                while (dr.Read())
                {
                    fingerNoList.Add(Convert.ToUInt32(dr["FingerNo"].ToString()));
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
                return false;
            }
            //对比提示重复
            List<string> repeatUserId = new List<string>();
            foreach (var item in downUserIdList)
            {
                if (fingerNoList.Contains(item))
                {
                    repeatUserId.Add(item.ToString());
                }
            }
            if (repeatUserId.Count > 0)
            {
                if (Pub.MessageBoxShowQuestion(string.Format(Pub.GetResText("Public", "MsgRepeatNo", ""), string.Join(",", repeatUserId.ToArray()))))
                {
                    MacMsg = Pub.GetResText("Public", "btnCancel", "");
                    return false;
                }
            }

            downList.Clear();
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int PasswordData = 0;
            byte[] fpData = new byte[(int)FKMax.FK_FaceDataSize];
            string EnrollName = "";
            DialogResult MessRet;
            string EmpNo = "";
            bool ReqName = false;
            int FingerCount = 0;
            int PSWCount = 0;
            int CardCount = 0;
            int FaceCount = 0;
            int PalVeinCnt = 0;
            int EmpCount = 0;
            int ErrCode = 0;
            execList.Clear();
            progBar.ProgressType = eProgressItemType.Standard;
            string StatusMsg = lblMsg.Text;
            ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_USERS, ref EmpCount);
            if (!ret) return false;
            ReOpen:
            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.ReadAllUserID();
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (!ret) return false;
            do
            {
            FFF:
                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetAllUserID(ref EnrollNumber, ref BackupNumber,
                  ref Privilege, ref EnableFlag);
                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                {
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    break;
                }
                //如果不是列表里的,跳过
                if (!downUserIdList.Contains(EnrollNumber)) goto FFF;
                if (FindExecInfo(EnrollNumber, BackupNumber)) goto FFF;
                EEE:
                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetEnrollData(EnrollNumber, BackupNumber,
                  ref Privilege, fpData, ref PasswordData);
                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                {
                    ErrCode = DeviceObject.objFK623.RunCode;
                    if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_READ_FAIL)
                    {
                        if (DeviceObject.objFK623.ReOpen()) goto ReOpen;
                        DeviceObject.objFK623.RunCode = ErrCode;
                    }
                    MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                      Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                    if (MessRet == DialogResult.Yes)
                        goto EEE;
                    else if (MessRet == DialogResult.Cancel)
                        break;
                    else
                        goto FFF;
                }
                CountFingerInfo(BackupNumber, ref FingerCount, ref PSWCount, ref CardCount, ref FaceCount, ref PalVeinCnt);
                SystemInfo.db.SaveEnrollToDB(EnrollNumber, BackupNumber, EnableFlag, Privilege, PasswordData,
                  fpData, "", ref ReqName);
                //如果是列表里有的，则添加下载，否则跳过
                if (downUserIdList.Contains(EnrollNumber))
                {
                    AddDownInfo(new TDownInfoList(EnrollNumber, ReqName));
                    execList.Add(new TDimInfo(EnrollNumber, BackupNumber));
                }
                lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                  string.Format(" - {2}/{3}  [{0}: {1}]", EnrollNumber, BackupNumber, downList.Count, EmpCount);
                progBar.Value = downList.Count * 100 / EmpCount;
                Application.DoEvents();
            }
            while (true);
            byte[] buff = new byte[0];
            byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
            ExtCmd_USERDOORINFO ui = new ExtCmd_USERDOORINFO();
            DateTime dt;
            string StartDate = "";
            string EndDate = "";
            bool retDate = false;
            StatusMsg = StatusMsg + Pub.GetResText(formCode, "MsgFingerName", "");
            for (int i = 0; i < downList.Count; i++)
            {
                EnrollNumber = downList[i].EnrollNumber;
                lblMsg.Text = StatusMsg + string.Format(" - {1}/{2}  [{0}]", EnrollNumber, i + 1, downList.Count);
                progBar.Value = (i + 1) * 100 / downList.Count;

                ui.Init(false, EnrollNumber);
                DeviceObject.objFK623.StructToByteArray(ui, byt);
                retDate = DeviceObject.objFK623.ExtCommand(byt);
                ui = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));

                StartDate = "";
                dt = new DateTime();
                try
                {
                    dt = new DateTime(ui.StartYear, ui.StartMonth, ui.StartDay);
                    StartDate = dt.ToString(SystemInfo.SQLDateFMT);
                }
                catch
                {
                }
                EndDate = "";
                try
                {
                    dt = new DateTime(ui.EndYear, ui.EndMonth, ui.EndDay);
                    EndDate = dt.ToString(SystemInfo.SQLDateFMT);
                }
                catch
                {
                }

                if (downList[i].ReqName)
                {
                    EnrollName = "";
                    DeviceObject.objFK623.GetUserName(EnrollNumber, ref EnrollName);
                    if (EnrollName != "") SystemInfo.db.SetEmpNameByFinger(EnrollNumber, EnrollName);
                }
                if (SystemInfo.db.GetEmpNoByFingerNo(EnrollNumber, ref EmpNo))
                {

                    if (retDate)
                    {
                        if (SystemInfo.DBType == 0)
                        {
                            if (StartDate == "") StartDate = "NULL";
                            else StartDate = "CDate('" + StartDate + "')";
                            if (EndDate == "") EndDate = "NULL";
                            else EndDate = "CDate('" + EndDate + "')";
                        }
                        else
                        {
                            if (StartDate == "") StartDate = "NULL";
                            else StartDate = "'" + StartDate + "'";
                            if (EndDate == "") EndDate = "NULL";
                            else EndDate = "'" + EndDate + "'";
                        }
                        //保存有效期
                        string sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "36", EmpNo, StartDate, EndDate });
                        SystemInfo.db.ExecSQL(sql);
                    }

                    if (DeviceObject.objFK623.GetEnrollPhoto(EnrollNumber, ref buff) && buff.Length > 0)
                    {
                        SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "7", EmpNo }),
                          "EmpPhotoImage", buff);
                    }
                }
                buff = null;
                Application.DoEvents();
            }
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgDownInfo", "");
                MacMsg = string.Format(tmp, downList.Count, FingerCount, FaceCount, PSWCount, CardCount, PalVeinCnt, "0");
            }
            SystemInfo.db.UpdateEmpInfoCount(this.Text);
            return ret;
        }

        private bool SeaSeries_DownloadInfo(List<UInt32> downUserIdList, string url, string name, string pwd, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            //从数据库获得登记号列表对比，用于提示
            fingerNoList.Clear();
            DataTableReader dr = null;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "508" }));
                while (dr.Read())
                {
                    fingerNoList.Add(Convert.ToUInt32(dr["FingerNo"].ToString()));
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
                return false;
            }
            //对比提示重复
            List<string> repeatUserId = new List<string>();
            foreach (var item in downUserIdList)
            {
                if (fingerNoList.Contains(item))
                {
                    repeatUserId.Add(item.ToString());
                }
            }
            if (repeatUserId.Count > 0)
            {
                if (Pub.MessageBoxShowQuestion(string.Format(Pub.GetResText("Public", "MsgRepeatNo", ""), string.Join(",", repeatUserId.ToArray()))))
                {
                    MacMsg = Pub.GetResText("Public", "btnCancel", "");
                    return false;
                }
            }

            string HireDate = "";
            int Privilege = 0;
            byte[] Photo = new byte[0];
            int EmpCount = 0;
            DataRow[] rows = null;
            string EmpNo = "";
            byte[] EmpPhotoBuff = null;
            byte[] PhotoBuff = null;
            int PhotoCount = 0;
            string EmpSex = "";
            string jsonString = "";
            string StatusMsg = lblMsg.Text;
            string CardNo = "";
            url = url + "action/SearchPerson";
            byte[] CardData = new byte[0];
            int userCount = 0;
            int CardCount = 0;
            string StartDate = null;
            string EndDate = null;
            progBar.ProgressType = eProgressItemType.Standard;

            DataTable dtInsert = new DataTable();
            DataTable dtUpdate = new DataTable();
            DataTable dtSelect = new DataTable();
            try
            {
                dtInsert = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "26" }));
                dtUpdate = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "26" }));
                dtSelect = SystemInfo.db.GetDataTable(Pub.GetSQL(DBCode.DB_000101, new string[] { "27" }));

                for (int i = 0; i < downUserIdList.Count; i++)
                {
                    //查询人员
                    SearchOnePerson searchOnePerson = new SearchOnePerson(Int32.Parse(MacSN), 0, downUserIdList[i].ToString(), 1);
                    jsonBody<SearchOnePerson> searchOnePersonCmd = new jsonBody<SearchOnePerson>("SearchPerson", searchOnePerson);
                ES:
                    jsonString = JsonConvert.SerializeObject(searchOnePersonCmd);
                    ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
                    if (!ret)
                    {
                        DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                       Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                        if (MessRet == DialogResult.OK)
                        {
                            goto ES;
                        }
                        else
                        {
                            ret = false;
                            break;
                        }
                    }
                    SearchOnePersonInfo<SearchPersonInfo> searchPersonInfo = JsonConvert.DeserializeObject<SearchOnePersonInfo<SearchPersonInfo>>(jsonString);
                    {
                        EmpCount++;
                        Photo = new byte[0];
                        if (searchPersonInfo.info.CustomizeID == 0)
                        {
                            continue;
                        }
                        if (!string.IsNullOrEmpty(searchPersonInfo.picinfo))
                            Photo = Convert.FromBase64String(searchPersonInfo.picinfo.Replace("data:image/jpeg;base64,", ""));
                        if (searchPersonInfo.info.RFIDCard != null)
                        {
                            CardNo = searchPersonInfo.info.RFIDCard.ToString();
                        }

                        if (CardNo != "")
                            CardNo = HexToStr(CardNo);

                        if (searchPersonInfo.info.Gender == 0)
                        {
                            EmpSex = Pub.GetResText("", "EmpSex0", "");
                        }
                        else if (searchPersonInfo.info.Gender == 1)
                        {
                            EmpSex = Pub.GetResText("", "EmpSex1", "");
                        }
                        else
                        {
                            EmpSex = "";
                        }
                        if (Photo.Length > 1)
                        {
                            MemoryStream ms = new MemoryStream(Photo);
                            Image empPhotoImage = CustomSizeImage(Image.FromStream(ms));
                            ms.Dispose();
                            using (Bitmap t = new Bitmap(empPhotoImage))
                            {
                                ms = new MemoryStream();
                                t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                EmpPhotoBuff = ms.ToArray();
                                ms.Dispose();
                                ms.Close();
                            }

                            MemoryStream msi = new MemoryStream(Photo);
                            Image empPhoto = CustomSizePhoto(Image.FromStream(msi));
                            msi.Dispose();
                            using (Bitmap ti = new Bitmap(empPhoto))
                            {
                                msi = new MemoryStream();
                                ti.Save(msi, System.Drawing.Imaging.ImageFormat.Jpeg);
                                PhotoBuff = msi.ToArray();
                                msi.Dispose();
                                msi.Close();
                            }
                            PhotoCount = 1;
                        }
                        else
                        {
                            PhotoCount = 0;
                        }
                        EmpNo = "";
                        HireDate = "";
                        if (searchPersonInfo.info.Tempvalid != 0)
                        {
                            StartDate = searchPersonInfo.info.ValidBegin;
                            EndDate = searchPersonInfo.info.ValidEnd;
                        }
                        else
                        {
                            StartDate = null;
                            EndDate = null;
                        }
                        rows = dtSelect.Select("FingerNo=" + searchPersonInfo.info.CustomizeID + "");
                        if (rows.Length > 0)
                        {
                            EmpNo = rows[0]["EmpNo"].ToString();
                            HireDate = rows[0]["EmpHireDate"].ToString();

                            dtUpdate.Rows.Add(new object[] { EmpNo, searchPersonInfo.info.Name, EmpSex, SystemInfo.CommanyID, HireDate , searchPersonInfo.info.IdCard
                                ,CardNo,"",searchPersonInfo.info.CustomizeID,Privilege.ToString(), true,
                                searchPersonInfo.info.Address,searchPersonInfo.info.Telnum,false,
                                EmpPhotoBuff,PhotoBuff,PhotoCount,searchPersonInfo.info.Notes,StartDate,EndDate});
                        }
                        else
                        {
                            EmpNo = SystemInfo.db.GetAutoEmpNo(searchPersonInfo.info.CustomizeID);
                            HireDate = DateTime.Now.ToString(Pub.GetResText("", "YMWFormatForm", ""));
                            dtSelect.Rows.Add(new object[] { searchPersonInfo.info.CustomizeID, EmpNo, HireDate });
                            dtInsert.Rows.Add(new object[] { EmpNo, searchPersonInfo.info.Name, EmpSex, SystemInfo.CommanyID, HireDate , searchPersonInfo.info.IdCard
                                ,CardNo,"",searchPersonInfo.info.CustomizeID,Privilege.ToString(), true,
                                searchPersonInfo.info.Address,searchPersonInfo.info.Telnum,
                                false,EmpPhotoBuff,PhotoBuff,PhotoCount,searchPersonInfo.info.Notes,StartDate,EndDate});
                        }

                        userCount++;
                        lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {2}/{3}  [{0}: {1}]", searchPersonInfo.info.CustomizeID, searchPersonInfo.info.Name, EmpCount, downUserIdList.Count);
                        if (EmpCount > 0)
                            progBar.Value = EmpCount * 100 / downUserIdList.Count;
                        Application.DoEvents();

                        if (dtInsert.Rows.Count > 100)
                        {
                            SystemInfo.db.batchEmpInSertData(dtInsert, "RS_Emp");
                            dtInsert.Clear();
                        }
                        if (dtUpdate.Rows.Count > 100)
                        {
                            SystemInfo.db.batchEmpUpdateData(dtUpdate, "RS_Emp", "EmpNo");
                            dtUpdate.Clear();
                        }
                    }
                    if (dtInsert.Rows.Count > 0)
                    {
                        SystemInfo.db.batchEmpInSertData(dtInsert, "RS_Emp");
                        dtInsert.Clear();
                    }
                    if (dtUpdate.Rows.Count > 0)
                    {
                        SystemInfo.db.batchEmpUpdateData(dtUpdate, "RS_Emp", "EmpNo");
                        dtUpdate.Clear();
                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgDownInfo", "");
                MacMsg = string.Format(tmp, userCount, 0, 0, 0, CardCount, 0, userCount);
            }
            if (userCount > 0)
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                ret = true;
            }
            return ret;
        }

        private void GetUSBPhoto(List<UInt32> downList, string StatusMsg, ref int PhotoCount)
        {
            UInt32 EnrollNumber = 0;
            string EmpNo = "";
            string picPath = Pub.GetFileNamePath(usbFile);
            string DypicPath = Pub.GetFileNamePath(usbFile);
            string picFileName = "";
            string DypicFileName = "";
            picPath = picPath + "AttendPhoto\\";
            DypicPath = DypicPath + "DynamicPhoto\\";
            byte[] buff = new byte[0];
            byte[] facebuff = new byte[0];
            int bufLen = 0;
            Image img;
            MemoryStream ms;
            Image faceimg;
            MemoryStream facems;
            progBar.ProgressType = eProgressItemType.Standard;
            StatusMsg = StatusMsg + Pub.GetResText(formCode, "MsgFingerName", "");
            for (int i = 0; i < downList.Count; i++)
            {
                EnrollNumber = downList[i];
                lblMsg.Text = StatusMsg + string.Format(" - {1}/{2}  [{0}]", EnrollNumber, i + 1, downList.Count);
                progBar.Value = (i + 1) * 100 / downList.Count;
                Application.DoEvents();
                picFileName = picPath + "LF" + EnrollNumber.ToString("00000000") + ".jpg";
                if (picFileName == "" || !File.Exists(picFileName))
                {
                    picFileName = picPath + "LF" + EnrollNumber.ToString("00000000") + ".bmp";
                }
                if (picFileName == "" || !File.Exists(picFileName))
                {
                    picFileName = picPath + "LF" + EnrollNumber.ToString("00000000") + ".png";
                }
                if (picFileName == "" || !File.Exists(picFileName))
                {
                    picFileName = picPath + "LF" + EnrollNumber.ToString("00000000") + ".gif";
                }

                DypicFileName = DypicPath + "LF" + EnrollNumber.ToString("00000000") + ".jpg";

                if (DypicFileName == "" || !File.Exists(DypicFileName))
                {
                    DypicFileName = DypicPath + "LF" + EnrollNumber.ToString("00000000") + ".bmp";
                }
                if (DypicFileName == "" || !File.Exists(DypicFileName))
                {
                    DypicFileName = DypicPath + "LF" + EnrollNumber.ToString("00000000") + ".png";
                }
                if (DypicFileName == "" || !File.Exists(DypicFileName))
                {
                    DypicFileName = DypicPath + "LF" + EnrollNumber.ToString("00000000") + ".gif";
                }

                if ((picFileName == "" || !File.Exists(picFileName)) && ((DypicFileName == "" || !File.Exists(DypicFileName)))) continue;
                if (SystemInfo.db.GetEmpNoByFingerNo(EnrollNumber, ref EmpNo))
                {
                    try
                    {
                        if (File.Exists(picFileName))
                        {
                            img = CustomSizeImage(Image.FromFile(picFileName));
                            ms = new MemoryStream();
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img.Dispose();
                            img = null;
                            bufLen = (int)ms.Length;
                            if (bufLen > 0)
                            {
                                buff = new byte[bufLen];
                                ms.Position = 0;
                                ms.Read(buff, 0, bufLen);
                                SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "7", EmpNo }),
                                  "EmpPhotoImage", buff);
                            }
                            ms.Dispose();
                        }
                        if (File.Exists(DypicFileName))
                        {
                            faceimg = CustomSizePhoto(Image.FromFile(DypicFileName));
                            facems = new MemoryStream();
                            faceimg.Save(facems, System.Drawing.Imaging.ImageFormat.Jpeg);
                            faceimg.Dispose();
                            faceimg = null;
                            bufLen = (int)facems.Length;
                            if (bufLen > 0)
                            {
                                facebuff = new byte[bufLen];
                                facems.Position = 0;
                                facems.Read(facebuff, 0, bufLen);
                                SystemInfo.db.UpdateByteData(Pub.GetSQL(DBCode.DB_000101, new string[] { "24", EmpNo }),
                                  "EmpPhoto", facebuff);
                                PhotoCount++;
                                SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000101, new string[] { "35", EmpNo, "1" }));
                            }
                            facems.Dispose();
                        }

                    }
                    catch (Exception E)
                    {
                        Pub.ShowErrorMsg(E);
                    }
                }
                facebuff = null;
                facems = null;
                buff = null;
                ms = null;
                Application.DoEvents();
            }
        }

        private bool DownloadInfoUSB(string Oprt, ref string MacMsg)
        {
            bool ret = DeviceObject.objFK623.SetUDiskFileFKModel(usbFKModel);
            if (!ret) return ret;
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int PasswordData = 0;
            byte[] fpData = new byte[(int)FKMax.FK_FaceDataSize];
            string EnrollName = "";
            DialogResult MessRet;
            List<UInt32> downList = new List<UInt32>();
            bool ReqName = false;
            int FingerCount = 0;
            int PSWCount = 0;
            int CardCount = 0;
            int FaceCount = 0;
            int PalVeinCnt = 0;
            int PhotoCount = 0;
            int EmpCount = 0;

            // string EmpNo = "";
            string StatusMsg = Oprt + "......";
            ret = DeviceObject.objFK623.USBReadAllEnrollDataFromFile(usbFile);
            if (ret) ret = DeviceObject.objFK623.USBReadAllEnrollDataCount(ref EmpCount);
            progBar.ProgressType = eProgressItemType.Marquee;
            if (ret)
            {
                do
                {
                EEE:
                    EnrollName = new string((char)0x20, 256);
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.USBGetOneEnrollData(ref EnrollNumber,
                      ref BackupNumber, ref Privilege, fpData, ref PasswordData, ref EnableFlag, ref EnrollName);
                    if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                    {
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                        break;
                    }
                    if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                    {
                        MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                          Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNo);
                        if (MessRet == DialogResult.Yes)
                            goto EEE;
                        else if (MessRet == DialogResult.No)
                            break;
                    }
                    //EmpNo = "";
                    //DataTableReader dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "10", EnrollNumber.ToString() }));
                    //if (dr.Read()) EmpNo = dr["EmpNo"].ToString();
                    //dr.Close();
                    //if (EmpNo == "")
                    //{
                    //    EmpNo = SystemInfo.db.GetAutoEmpNo(EnrollNumber);
                    //}
                    //dr.Close();
                    //dr = SystemInfo.db.GetDataReader("Select * from RS_EmpDynamicInfo where  FingerNo=" + EnrollNumber + "");
                    //if(!dr.Read())
                    //{
                    //    SystemInfo.db.ExecSQL("insert into RS_EmpDynamicInfo(EmpNo,FingerNo)VALUES('"+ EmpNo + "',"+ EnrollNumber + ")");
                    //}

                    //if(BackupNumber>=0 && BackupNumber<=9)
                    //{
                    //    byte[] fpDataZip = new byte[(int)FKMax.FK_FPDataSize];
                    //    Array.Copy(fpData, 0, fpDataZip, 0, fpDataZip.Length);

                    //    byte[] buffConv = new byte[(int)FKMax.FK_FPDataSize];

                    //    long apnVersion = 0x80;
                    //    long apnSize = 1680;
                    //    int apnFpDataSize = 1680;
                    //    byte[] fpdata = new byte[1600];
                    //    ObjFpReader.ConvEnrollData(fpData, ref buffConv, 1680);
                    //    Array.Copy(buffConv, 80, fpdata, 0, 1600);

                    //    ObjFpReader.FPCONV_Init();
                    //    ObjFpReader.FPCONV_GetFpDataVersionAndSize(fpdata, ref apnVersion, ref apnSize);

                    //    ObjFpReader.FPCONV_GetFpDataSize(0x80, ref apnFpDataSize);
                    //    byte[] buffConvNew = new byte[apnFpDataSize];
                    //    ObjFpReader.FPCONV_Convert((int)apnVersion, fpdata, 0x80, buffConvNew);

                    //    switch (BackupNumber)
                    //    {
                    //        case 0:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb00=@Fb00 where FingerNo=" + EnrollNumber + "", "Fb00", buffConvNew);
                    //            break;
                    //        case 1:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb01=@Fb01 where FingerNo=" + EnrollNumber + "", "Fb01", buffConvNew);
                    //            break;
                    //        case 2:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb02=@Fb02 where FingerNo=" + EnrollNumber + "", "Fb02", buffConvNew);
                    //            break;
                    //        case 3:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb03=@Fb03 where FingerNo=" + EnrollNumber + "", "Fb03", buffConvNew);
                    //            break;
                    //        case 4:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb04=@Fb04 where FingerNo=" + EnrollNumber + "", "Fb04", buffConvNew);
                    //            break;
                    //        case 5:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb05=@Fb05 where FingerNo=" + EnrollNumber + "", "Fb05", buffConvNew);
                    //            break;
                    //        case 6:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb06=@Fb06 where FingerNo=" + EnrollNumber + "", "Fb06", buffConvNew);
                    //            break;
                    //        case 7:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb07=@Fb07 where FingerNo=" + EnrollNumber + "", "Fb07", buffConvNew);
                    //            break;
                    //        case 8:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb08=@Fb08 where FingerNo=" + EnrollNumber + "", "Fb08", buffConvNew);
                    //            break;
                    //        case 9:
                    //            SystemInfo.db.UpdateByteData(@"Update RS_EmpDynamicInfo Set Fb09=@Fb09 where FingerNo=" + EnrollNumber + "", "Fb09", buffConvNew);
                    //            break;
                    //    }

                    //}

                    CountFingerInfo(BackupNumber, ref FingerCount, ref PSWCount, ref CardCount, ref FaceCount, ref PalVeinCnt);
                    SystemInfo.db.SaveEnrollToDB(EnrollNumber, BackupNumber, EnableFlag, Privilege, PasswordData,
                      fpData, "", ref ReqName);
                    if (ReqName && EnrollName != "") SystemInfo.db.SetEmpNameByFinger(EnrollNumber, EnrollName);
                    if (downList.IndexOf(EnrollNumber) == -1) downList.Add(EnrollNumber);
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {2}/{3}  [{0}: {1}]", EnrollNumber, BackupNumber,
                      FingerCount + PSWCount + CardCount + FaceCount, EmpCount);

                    Application.DoEvents();
                }
                while (true);
                GetUSBPhoto(downList, StatusMsg, ref PhotoCount);
            }
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgDownInfo", "");
                MacMsg = string.Format(tmp, downList.Count, FingerCount, FaceCount, PSWCount, CardCount, PalVeinCnt, PhotoCount);
            }
            SystemInfo.db.UpdateEmpInfoCount(this.Text);
            SystemInfo.db.UpdateEmpInfoCount_Star();
            return ret;
        }

        private void SetUploadSuccess(UInt32 EnrollNumber)
        {
            for (int i = 0; i < selList.Length; i++)
            {
                if (selList[i].EnrollNumber == EnrollNumber)
                {
                    selList[i].IsSuccess = true;
                    return;
                }
            }
        }

        private bool GetUploadSuccess(UInt32 EnrollNumber)
        {
            bool ret = false;
            for (int i = 0; i < selList.Length; i++)
            {
                if (selList[i].EnrollNumber == EnrollNumber)
                {
                    ret = selList[i].IsSuccess;
                    return ret;
                }
            }
            return ret;
        }

        private bool GetDeteleCardSuccess(UInt32 EnrollNumber)
        {
            bool ret = false;
            for (int i = 0; i < cardList.Count; i++)
            {
                if (cardList[i] == EnrollNumber)
                {
                    ret = true;
                    return ret;
                }
            }
            return ret;
        }

        private bool UploadInfo(string MacSN, ref string MacMsg)
        {

            bool ret = false;

            ExtCmd_USERDOORINFO uiOld;
            ExtCmd_USERDOORINFO uiNew;
            DateTime dt;
            byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];

            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int PasswordData = 0;
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            byte[] buff = new byte[0];
            string EnrollName = "";
            string getName = "";
            string EmpNo = "";
            DialogResult MessRet;
            bool SupportFlag = false;
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            int ExistsCount = 0;
            int ExistsCardCount = 0;
            bool IsSupportPhoto = true;
            int ErrCode = 0;
            string CardNo = "";
            string pwd = "";
            cardList.Clear();
            cardList.Add(0);
            int cardCount = 0;
            bool IsReOpen = false;
            if (dtUpload == null)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }
            progBar.ProgressType = eProgressItemType.Standard;
            try
            {
                for (int i = 0; i < dtUpload.Rows.Count; i++)
                {
                    progBar.Value = (i + 1) * 100 / dtUpload.Rows.Count;
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {3}/{4}  {0}[{1}: {2}]", EnrollName, EnrollNumber, BackupNumber,
                      i + 1, dtUpload.Rows.Count);

                    EnrollNumber = Convert.ToUInt32(dtUpload.Rows[i]["FingerNo"].ToString());
                    BackupNumber = Convert.ToInt32(dtUpload.Rows[i]["FingerBkNo"].ToString());
                    if (BackupNumber == (int)FKBackup.BACKUP_PSW || BackupNumber == (int)FKBackup.BACKUP_CARD)
                    {
                        continue;
                    }
                    Privilege = Convert.ToInt32(dtUpload.Rows[i]["FingerPrivilege"].ToString());
                    EnrollName = dtUpload.Rows[i]["EmpName"].ToString();

                    if (string.IsNullOrEmpty(dtUpload.Rows[i]["FingerData"].ToString()))
                        continue;
                    buff = (byte[])dtUpload.Rows[i]["FingerData"];
                    if (BackupNumber >= (int)FKBackup.BACKUP_FP_0 && BackupNumber <= (int)FKBackup.BACKUP_FP_9)
                    {
                        fpData = new byte[(int)FKMax.FK_FPDataSize];
                    }

                    else if (BackupNumber == (int)FKBackup.BACKUP_FACE)
                    {
                        fpData = new byte[(int)FKMax.FK_FaceDataSize];
                    }
                    else if (BackupNumber == (int)FKBackup.BACKUP_VEIN_0)
                    {
                        fpData = new byte[(int)FKMax.FK_VeinDataSize];
                    }
                    else if (BackupNumber >= (int)FKBackup.BACKUP_PALMVEIN_0 && BackupNumber <= (int)FKBackup.BACKUP_PALMVEIN_3)
                    {
                        fpData = new byte[(int)FKMax.PALMVEINDataSize];
                    }
                    Array.Copy(buff, fpData, fpData.Length);
                EEE:
                    DeviceObject.objFK623.IsSupportedEnrollData(BackupNumber, ref SupportFlag);
                    if (SupportFlag)
                    {

                        if (IsExistDelete)
                        {

                            if (!GetDeteleCardSuccess(EnrollNumber))
                            {
                                if (DeviceObject.objFK623.GetUserName(EnrollNumber, ref getName))
                                {
                                    for (int xi = 0; xi < 16; xi++)
                                    {
                                        DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, xi);
                                    }

                                }
                                cardList.Add(EnrollNumber);
                            }
                        }

                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.PutEnrollData(EnrollNumber, BackupNumber,
                         Privilege, fpData, PasswordData);
                    }
                    else if (!IsReOpen)
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATADOUBLE)
                    {
                        if (IsExistDelete)
                        {
                            DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, BackupNumber);
                            goto EEE;
                        }
                        else
                        {
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            ExistsCount++;
                        }
                    }
                    if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                    {
                        if (GetUploadSuccess(EnrollNumber) || DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_INVALID_PARAM)
                        {
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            continue;
                        }
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_MEMORYOVER)
                        {
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            break;
                        }
                        IsReOpen = false;
                        ErrCode = DeviceObject.objFK623.RunCode;
                        if (ErrCode == (int)FKRun.RUNERR_UNKNOWNERROR) continue;
                        if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                        {
                            IsReOpen = true;
                            if (DeviceObject.objFK623.ReOpen()) goto EEE;
                            DeviceObject.objFK623.RunCode = ErrCode;
                        }
                        MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                          Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                        if (MessRet == DialogResult.Yes)
                            goto EEE;
                        else if (MessRet == DialogResult.Cancel)
                            break;
                        else
                            continue;
                    }
                    else
                    {
                        CountUpFp++;
                    }
                    Application.DoEvents();
                }
                if (dtUpload.Rows.Count > 0 && ExistsCount < dtUpload.Rows.Count)
                {
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.SaveEnrollData();
                }
                cardCount = 0;
                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());

                    CardNo = dtUploadcount.Rows[i]["CardNo10"].ToString();
                    pwd = dtUploadcount.Rows[i]["pwd"].ToString();
                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    Privilege = Convert.ToInt32(dtUploadcount.Rows[i]["FingerPrivilege"].ToString());
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            if (string.IsNullOrEmpty(CardNo)) continue;
                            BackupNumber = 11;
                            buff = EncAndDec.getCard(CardNo);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(pwd)) break;
                            BackupNumber = 10;
                            buff = EncAndDec.getPWD(pwd);
                        }
                        cardCount++;
                        progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;
                        lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "EmpCardNo", "") + "、" + Pub.GetResText(formCode, "EmpPWDNo", "") +
                          string.Format(" - {3}/{4}  {0}[{1}: {2}]", EnrollName, EnrollNumber, BackupNumber,
                          i + 1, dtUploadcount.Rows.Count);

                        fpData = new byte[(int)FKMax.FK_PasswordDataSize];
                        Array.Copy(buff, fpData, fpData.Length);
                    EEE:
                        DeviceObject.objFK623.IsSupportedEnrollData(BackupNumber, ref SupportFlag);
                        if (SupportFlag)
                        {

                            if (IsExistDelete)
                            {

                                if (!GetDeteleCardSuccess(EnrollNumber))
                                {
                                    if (DeviceObject.objFK623.GetUserName(EnrollNumber, ref getName))
                                    {
                                        for (int xi = 0; xi < 16; xi++)
                                        {
                                            DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, xi);
                                        }

                                    }
                                    cardList.Add(EnrollNumber);
                                }
                            }

                            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.PutEnrollData(EnrollNumber, BackupNumber,
                             Privilege, fpData, PasswordData);
                        }
                        else if (!IsReOpen)
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATADOUBLE)
                        {
                            if (IsExistDelete)
                            {
                                DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, BackupNumber);
                                goto EEE;
                            }
                            else
                            {
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                ExistsCardCount++;
                            }
                        }
                        if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                        {
                            if (GetUploadSuccess(EnrollNumber) || DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_INVALID_PARAM)
                            {
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                continue;
                            }
                            if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_MEMORYOVER)
                            {
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                break;
                            }
                            IsReOpen = false;
                            ErrCode = DeviceObject.objFK623.RunCode;
                            if (ErrCode == (int)FKRun.RUNERR_UNKNOWNERROR) continue;
                            if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                            {
                                IsReOpen = true;
                                if (DeviceObject.objFK623.ReOpen()) goto EEE;
                                DeviceObject.objFK623.RunCode = ErrCode;
                            }
                            MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                              Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                            if (MessRet == DialogResult.Yes)
                                goto EEE;
                            else if (MessRet == DialogResult.Cancel)
                                break;
                            else
                                continue;
                        }
                        else
                        {
                            CountUpFp++;
                        }
                        Application.DoEvents();
                    }

                }

                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                {
                    if (cardCount > 0 && ExistsCardCount < cardCount)
                    {
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.SaveEnrollData();
                    }
                    if (IsUploadName)
                    {
                        for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                        {
                            EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                            lblMsg.Text = StatusMsg + Pub.GetResText("", "MsgFingerName", "") + string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber,
                              i + 1, dtUploadcount.Rows.Count);
                            progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;
                            Application.DoEvents();
                            EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());
                        ContinueName:
                            if (!DeviceObject.objFK623.SetUserName(EnrollNumber, EnrollName, ref ErrCode))
                            {
                                if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                                {
                                    if (DeviceObject.objFK623.ReOpen()) goto ContinueName;
                                }
                                MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.GetRunMsg(ErrCode) + "\r\n\r\n" +
                                  Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNo);
                                if (MessRet == DialogResult.Yes)
                                    goto ContinueName;
                                else
                                    break;
                            }
                            CountUp++;
                            if (IsSupportPhoto)
                            {
                                DataTableReader drPhoto = null;
                                try
                                {
                                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                                    drPhoto = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "13", EmpNo }));
                                    if (drPhoto.Read())
                                    {
                                        if (drPhoto["EmpPhotoImage"].ToString() != "")
                                        {
                                            byte[] buf = (byte[])(drPhoto["EmpPhotoImage"]);
                                            nPhotoSize = buf.Length;
                                            if (nPhotoSize > 0) DeviceObject.objFK623.SetEnrollPhoto(EnrollNumber, buf, nPhotoSize);
                                        }
                                    }
                                }
                                catch (Exception E)
                                {
                                    Pub.ShowErrorMsg(E);
                                }
                                finally
                                {
                                    if (drPhoto != null) drPhoto.Close();
                                    drPhoto = null;
                                }
                            }

                            uiOld = new ExtCmd_USERDOORINFO();
                            uiOld.Init(false, EnrollNumber);
                            DeviceObject.objFK623.StructToByteArray(uiOld, byt);
                            ret = DeviceObject.objFK623.ExtCommand(byt);
                            uiOld = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));

                            uiNew = new ExtCmd_USERDOORINFO();
                            uiNew.Init(true, EnrollNumber);
                            uiNew.WeekPassTime = uiOld.WeekPassTime;
                            try
                            {
                                dt = Convert.ToDateTime(dtUploadcount.Rows[i]["StartDate"].ToString());
                                uiNew.StartYear = (short)dt.Year;
                                uiNew.StartMonth = (byte)dt.Month;
                                uiNew.StartDay = (byte)dt.Day;
                            }
                            catch
                            {
                            }
                            try
                            {
                                dt = Convert.ToDateTime(dtUploadcount.Rows[i]["EndDate"].ToString());
                                uiNew.EndYear = (short)dt.Year;
                                uiNew.EndMonth = (byte)dt.Month;
                                uiNew.EndDay = (byte)dt.Day;
                            }
                            catch
                            {
                            }

                            if (uiNew.StartYear == 0 && uiNew.EndYear == 0)
                            {
                                continue;
                            }
                            if (uiNew.StartYear == 0)
                                uiNew.StartYear = 1900;
                            DeviceObject.objFK623.StructToByteArray(uiNew, byt);
                            ret = DeviceObject.objFK623.ExtCommand(byt);
                        }
                    }
                    ret = true;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");

                MacMsg = string.Format(tmp, dtUploadcount.Rows.Count, CountUp, CountUpFp);

            }
            return ret;
        }

        private bool Star_UploadInfo(string MacSN, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            string EmpNo = "";

            string CardNo10 = "";

            string Pwd = "";
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            int Privilege = 0;
            SetUsers setUsers = null;
            SetUserInfoCmd<SetUsers> setUserInfoCmd = null;
            _DeviceCmd<SetUserInfoCmd<SetUsers>> devSetUserInfoCmd = null;
            List<SetUsers> usersList = new List<SetUsers>();
            List<string> fps = new List<string>();
            string face = "";
            string palm = "";
            string photo = "";
            string vaildStart = "";
            string vaildEnd = "";
            int BufferLen = 0;
            byte photoEnroll = 0;
            byte update = 0;
            int sendCount = 0;
            string ID = "";
            List<int> CustomizeIDList = new List<int>();
            DataTableReader dr = null;
            DataTableReader drfp = null;
            int maxBufferLen = 0;
            byte[] dataBuffer = new byte[0];
            List<string> usersIDList = new List<string>();
            if (dtUploadcount == null)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }
            progBar.ProgressType = eProgressItemType.Standard;

            #region 获取可发送数据的最大值
            string cmd = "GetDeviceInfo";
            DeviceCmd getDeviceCmd = new DeviceCmd(cmd);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(getDeviceCmd));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    _ResultInfo<DeviceInfo> deviceInfo = JsonConvert.DeserializeObject<_ResultInfo<DeviceInfo>>(jsonStringBuilder.ToString());
                    maxBufferLen = deviceInfo.result_data.maxBufferLen;
                }
                else
                {
                    string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                    MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                    return true;
                }
            }
            #endregion

            #region 首先获取机器上的所有用户id
            cmd = "GetUserIdList";
            GetUserIdListCmd getUserIdListCmd = new GetUserIdListCmd(0);
            _DeviceCmd<GetUserIdListCmd> devGetUserIdListCmd = new _DeviceCmd<GetUserIdListCmd>(cmd, getUserIdListCmd);
        RE:
            jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devGetUserIdListCmd));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    try
                    {
                        _ResultInfo<UserListInfo<UserIdName>> personIDList = JsonConvert.DeserializeObject<_ResultInfo<UserListInfo<UserIdName>>>(jsonStringBuilder.ToString());
                        if (personIDList.result_data.users != null)
                        {
                            foreach (UserIdName idName in personIDList.result_data.users)
                            {
                                usersIDList.Add(idName.userId);
                            }
                            if (personIDList.result_data.packageId != 0)
                            {
                                devGetUserIdListCmd.data.packageId++;
                                goto RE;
                            }
                            ret = true;
                        }
                    }
                    catch
                    {

                    }

                }
                else if (state == -6)
                {
                    sendCount++;
                    if (sendCount > 2)
                        return ret;
                    else
                        goto RE;
                }
                else
                {
                    return ret;
                }
            }
            else
            {
                ret = false;
            }
            #endregion

            try
            {
                sendCount = 0;
                cmd = "SetUserInfo";
                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    fps = new List<string>();
                    face = null;
                    palm = null;
                    photo = null;
                    vaildStart = null;
                    vaildEnd = null;

                    photoEnroll = 1;
                    update = 0;
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());

                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber,
                      i + 1, dtUploadcount.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;

                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                    CardNo10 = dtUploadcount.Rows[i]["CardNo10"].ToString();
                    Pwd = dtUploadcount.Rows[i]["pwd"].ToString();
                    Privilege = Convert.ToInt32(dtUploadcount.Rows[i]["FingerPrivilege"].ToString());
                    vaildStart = dtUploadcount.Rows[i]["StartDate"].ToString();
                    IsDateTime("yyyyMMdd", ref vaildStart);

                    vaildEnd = dtUploadcount.Rows[i]["EndDate"].ToString();
                    IsDateTime("yyyyMMdd", ref vaildEnd);

                    if (string.IsNullOrEmpty(vaildStart)) vaildStart = "00000000";
                    if (string.IsNullOrEmpty(vaildEnd)) vaildEnd = "00000000";
                    CountUp++;
                    photo = "";
                    nPhotoSize = 0;
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EmpPhoto"].ToString()))
                    {

                        dataBuffer = (byte[])(dtUploadcount.Rows[i]["EmpPhoto"]);
                        nPhotoSize = dataBuffer.Length;
                        if (nPhotoSize > 0)
                        {
                            photo = Convert.ToBase64String(dataBuffer);

                        }

                    }
                    if (nPhotoSize == 0)
                    {
                        if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EmpPhotoImage"].ToString()))
                        {
                            dataBuffer = (byte[])(dtUploadcount.Rows[i]["EmpPhotoImage"]);
                            nPhotoSize = dataBuffer.Length;
                            if (nPhotoSize > 0)
                            {
                                photo = Convert.ToBase64String(dataBuffer);

                            }
                        }
                    }
                    if (CardNo10 == "") CardNo10 = null;
                    if (Pwd == "") Pwd = null;

                    for (int j = 0; j < 10; j++)
                    {
                        drfp = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "39", EnrollNumber.ToString(), j.ToString() }));
                        if (drfp.Read())
                        {
                            dataBuffer = (byte[])(drfp["FingerData"]);

                            byte[] fpDataZip = new byte[(int)FKMax.FK_FPDataSize];
                            Array.Copy(dataBuffer, 0, fpDataZip, 0, fpDataZip.Length);

                            byte[] buffConv = new byte[(int)FKMax.FK_FPDataSize];

                            long apnVersion = 0x80;
                            long apnSize = 1680;
                            int apnFpDataSize = 1680;
                            byte[] fpdata = new byte[1600];
                            ObjFpReader.ConvEnrollData(dataBuffer, ref buffConv, 1680);
                            Array.Copy(buffConv, 80, fpdata, 0, 1600);

                            ObjFpReader.FPCONV_Init();
                            ObjFpReader.FPCONV_GetFpDataVersionAndSize(fpdata, ref apnVersion, ref apnSize);

                            ObjFpReader.FPCONV_GetFpDataSize(0x80, ref apnFpDataSize);
                            byte[] buffConvNew = new byte[apnFpDataSize];
                            ObjFpReader.FPCONV_Convert((int)apnVersion, fpdata, 0x80, buffConvNew);

                            fps.Add(Convert.ToBase64String(buffConvNew));
                        }
                        drfp.Close();
                    }

                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "34", EmpNo }));
                    if (dr.Read())
                    {
                        #region 指纹
                        //for (int j = 0; j < 10; j++)
                        //{
                        //    //if (!string.IsNullOrEmpty(dr["Fb0" + j].ToString()))
                        //    //{
                        //    //    dataBuffer = (byte[])(dr["Fb0" + j]);
                        //    //    fps.Add(Convert.ToBase64String(dataBuffer));
                        //    //}

                        //} 
                        #endregion
                        if (!string.IsNullOrEmpty(dr["Face00"].ToString()))
                        {
                            dataBuffer = (byte[])(dr["Face00"]);
                            face = Convert.ToBase64String(dataBuffer);
                            photoEnroll = 0;
                        }

                        if (!string.IsNullOrEmpty(dr["Falm00"].ToString()))
                        {
                            dataBuffer = (byte[])(dr["Falm00"]);
                            palm = Convert.ToBase64String(dataBuffer);
                        }
                    }
                    if (usersIDList != null)
                    {
                        if (usersIDList.IndexOf(EnrollNumber.ToString()) > 0)
                        {
                            update = 1;
                        }
                    }
                    if (string.IsNullOrEmpty(photo))
                    {
                        photo = null;
                        photoEnroll = 0;
                    }
                    CountUpFp++;
                    setUsers = new SetUsers(EnrollNumber.ToString(), EnrollName, Privilege, CardNo10, Pwd, fps, face, palm, photo, vaildStart, vaildEnd, update, photoEnroll);
                    BufferLen += CalculatedLength(setUsers);
                    if (BufferLen > maxBufferLen)
                    {
                        setUserInfoCmd = new SetUserInfoCmd<SetUsers>(usersList);
                        devSetUserInfoCmd = new _DeviceCmd<SetUserInfoCmd<SetUsers>>(cmd, setUserInfoCmd);
                    ES:
                        jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devSetUserInfoCmd), maxBufferLen);

                        if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                        {
                            int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                            if (state == 0)
                            {
                                _ResultInfo<SetUsersErorr> resultInfo = JsonConvert.DeserializeObject<_ResultInfo<SetUsersErorr>>(jsonStringBuilder.ToString());
                                if (resultInfo.result_data != null)
                                {
                                    foreach (string id in resultInfo.result_data.usersId)
                                    {
                                        ID += " [" + id + "] ";
                                        CountUp--;
                                    }
                                }

                                ret = true;
                            }
                            else if (state == -6)
                            {
                                sendCount++;
                                if (sendCount > 3)
                                {
                                    ret = false;
                                    return ret;
                                }
                                else
                                {
                                    if (DeviceObject.socKetClient.Open()) goto ES;
                                    else
                                    {
                                        ret = false;
                                        return ret;
                                    }
                                }
                            }
                            else
                            {
                                ret = false;
                                return ret;
                            }
                        }
                        else
                        {
                            if (DeviceObject.socKetClient.ErrMsg.Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                            {
                                DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.socKetClient.ErrMsg + "\r\n\r\n" +
                         Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                                if (MessRet == DialogResult.OK)
                                {
                                    if (DeviceObject.socKetClient.Open()) goto ES;
                                    else
                                    {
                                        ret = false;
                                        return ret;
                                    }
                                }
                                else
                                {
                                    ret = false;
                                    return ret;
                                }
                            }
                        }
                        BufferLen = CalculatedLength(setUsers);
                        usersList.Clear();
                    }

                    usersList.Add(setUsers);

                    Application.DoEvents();
                }
                sendCount = 0;
                if (usersList.Count > 0)
                {
                    setUserInfoCmd = new SetUserInfoCmd<SetUsers>(usersList);
                    devSetUserInfoCmd = new _DeviceCmd<SetUserInfoCmd<SetUsers>>(cmd, setUserInfoCmd);
                ER:
                    jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devSetUserInfoCmd), maxBufferLen);

                    if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                    {
                        int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                        if (state == 0)
                        {
                            _ResultInfo<SetUsersErorr> resultInfo = JsonConvert.DeserializeObject<_ResultInfo<SetUsersErorr>>(jsonStringBuilder.ToString());
                            if (resultInfo.result_data != null)
                            {
                                foreach (string id in resultInfo.result_data.usersId)
                                {
                                    ID += " [" + id + "] ";
                                    CountUp--;
                                }
                            }

                            ret = true;
                        }
                        else if (state == -6)
                        {
                            sendCount++;
                            if (sendCount > 3)
                            {
                                ret = false;
                                return ret;
                            }
                            else
                            {
                                if (DeviceObject.socKetClient.Open()) goto ER;
                                else
                                {
                                    ret = false;
                                    return ret;
                                }
                            }
                        }
                        else
                        {
                            ret = false;
                            return ret;
                        }

                    }
                    else
                    {
                        if (DeviceObject.socKetClient.ErrMsg.Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.socKetClient.ErrMsg + "\r\n\r\n" +
                     Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                            if (MessRet == DialogResult.OK)
                            {
                                if (DeviceObject.socKetClient.Open()) goto ER;
                                else
                                {
                                    ret = false;
                                    return ret;
                                }
                            }
                            else
                            {
                                ret = false;
                                return ret;
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
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                if (ID != "")
                {
                    tmp += "  <" + Pub.GetResText(formCode, "UnsuccessfulEmpNo", "") + ID + ">  ";
                }
                MacMsg = string.Format(tmp, CountUp, dtUploadcount.Rows.Count, CountUpFp);
            }
            return ret;
        }

        private bool SeaSeries_UploadInfo(string url, string name, string pwd, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            string addUrl = url + "action/AddPerson";
            string selUrl = url + "action/SearchPerson";
            string updUrl = url + "action/EditPerson";
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            int EmpSex = 2;
            string EmpNo = "";
            long WeCardNo10 = 0;
            int WeCardNoType = 0;
            string EmpCertNo = "";
            string CardNo10 = "";
            string EmpAddress = "";
            string EmpPhoneNo = "";
            string picinfo = "";
            string EmpMemo = "";
            string ValidBegin = "";
            string ValidEnd = "";
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            int Valid = 0;
            EditPersonInfo editPerson = null;
            Person<EditPersonInfo> editPersonCmd = null;

            SearchOnePerson searchOnePerson = null;
            jsonBody<SearchOnePerson> searchOnePersonCmd = null;

            PersonInfo personInfo = null;
            Person<PersonInfo> addPerson = null;
            string jsonString = "";
            List<int> CustomizeIDList = new List<int>();
            string ID = "";
            bool IsUpdate = false;

            if (dtUploadcount == null)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }
            progBar.ProgressType = eProgressItemType.Standard;
            try
            {
                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    CustomizeIDList = new List<int>();
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());
                    CustomizeIDList.Add(Convert.ToInt32(EnrollNumber));
                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber,
                      i + 1, dtUploadcount.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;

                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                    if (dtUploadcount.Rows[i]["EmpSex"].ToString().Equals(Pub.GetResText("", "EmpSex0", "")))
                    {
                        EmpSex = 0;
                    }
                    else if (dtUploadcount.Rows[i]["EmpSex"].ToString().Equals(Pub.GetResText("", "EmpSex1", "")))
                    {
                        EmpSex = 1;
                    }
                    else
                    {
                        EmpSex = 2;
                    }
                    EmpCertNo = dtUploadcount.Rows[i]["EmpCertNo"].ToString();
                    CardNo10 = dtUploadcount.Rows[i]["CardNo10"].ToString();
                    long.TryParse(CardNo10, out WeCardNo10);
                    EmpAddress = dtUploadcount.Rows[i]["EmpAddress"].ToString();
                    EmpPhoneNo = dtUploadcount.Rows[i]["EmpPhoneNo"].ToString();
                    EmpMemo = dtUploadcount.Rows[i]["EmpMemo"].ToString();
                    ValidBegin = "";
                    ValidEnd = "";
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["StartDate"].ToString()))
                        ValidBegin = Convert.ToDateTime(dtUploadcount.Rows[i]["StartDate"]).ToString(SystemInfo.SQLDateFMT) + "T00:00:00";
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EndDate"].ToString()))
                        ValidEnd = Convert.ToDateTime(dtUploadcount.Rows[i]["EndDate"]).ToString(SystemInfo.SQLDateFMT) + "T23:59:59";

                    if (ValidBegin != "" || ValidEnd != "")
                    {
                        Valid = 1;
                    }
                    else
                    {
                        Valid = 0;
                    }

                    CountUp++;

                    picinfo = "";
                    nPhotoSize = 0;
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EmpPhoto"].ToString()))
                    {

                        byte[] buf = (byte[])(dtUploadcount.Rows[i]["EmpPhoto"]);
                        nPhotoSize = buf.Length;
                        if (nPhotoSize > 0)
                        {
                            picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buf);
                            CountUpFp++;
                        }

                    }
                    if (nPhotoSize == 0)
                    {
                        if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EmpPhotoImage"].ToString()))
                        {
                            byte[] buf = (byte[])(dtUploadcount.Rows[i]["EmpPhotoImage"]);
                            nPhotoSize = buf.Length;
                            if (nPhotoSize > 0)
                            {
                                picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buf);
                                CountUpFp++;
                            }
                        }
                    }

                    CardNo10 = StrToHex(CardNo10);
                    if (CardNo10.Length > 10) CardNo10 = CardNo10.Substring(CardNo10.Length - 10, 10);
                    if (WeCardNo10 != 0) WeCardNoType = 2;
                    else WeCardNoType = 0;
                    searchOnePerson = new SearchOnePerson(Int32.Parse(MacSN), 0, EnrollNumber.ToString(), 0);
                    searchOnePersonCmd = new jsonBody<SearchOnePerson>("SearchPerson", searchOnePerson);
                    jsonString = JsonConvert.SerializeObject(searchOnePersonCmd);
                    IsUpdate = false;
                    ret = DeviceObject.objFK623.POST_GetResponse(selUrl, name, pwd, ref jsonString);
                    if (ret)
                    {
                        jsonBody<SearchPersonInfo> searchPersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchPersonInfo>>(jsonString);
                        if (searchPersonInfo.info.CustomizeID == EnrollNumber)
                        {
                            IsUpdate = true;
                        }
                    }
                EEE:
                    if (IsUpdate)
                    {
                        editPerson = new EditPersonInfo(Convert.ToInt32(MacSN), 0, Convert.ToInt32(EnrollNumber), 0, EnrollName, EmpSex, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                         EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, CardNo10, Valid, "", ValidBegin, ValidEnd);
                        editPersonCmd = new Person<EditPersonInfo>("EditPerson", editPerson, picinfo);
                        jsonString = JsonConvert.SerializeObject(editPersonCmd);
                        ret = DeviceObject.objFK623.POST_GetResponse(updUrl, name, pwd, ref jsonString);
                    }
                    else
                    {
                        //增加人员
                        personInfo = new PersonInfo(Convert.ToInt32(MacSN), 0, EnrollName, EmpSex, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                            EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, CardNo10, Valid, Convert.ToInt32(EnrollNumber), "", ValidBegin, ValidEnd, "1", "1", "1", "1");
                        addPerson = new Person<PersonInfo>("AddPerson", personInfo, picinfo);
                        jsonString = JsonConvert.SerializeObject(addPerson);
                        ret = DeviceObject.objFK623.POST_GetResponse(addUrl, name, pwd, ref jsonString);
                    }

                    if (!ret)
                    {
                        if (DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                     Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                            if (MessRet == DialogResult.Yes)
                                goto EEE;
                            else if (MessRet == DialogResult.Cancel)
                            {
                                ret = false;
                                break;
                            }
                            else
                                continue;
                        }
                        else
                        {
                            ID += "[" + EnrollNumber + "]" + DeviceObject.objFK623.SeaBodyStr() + "]";
                        }

                    }
                    ret = true;
                    Application.DoEvents();
                }

            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                if (ID != "")
                {
                    tmp += "  <" + Pub.GetResText(formCode, "UnsuccessfulEmpNo", "") + ID + ">  ";
                }
                MacMsg = string.Format(tmp, dtUploadcount.Rows.Count, CountUp, CountUpFp);
            }

            return ret;
        }

        private void SetUSBPhoto(string StatusMsg)
        {
            string picPath = Pub.GetFileNamePath(usbFile);
            string DypicPath = Pub.GetFileNamePath(usbFile);
            string picFileName = "";
            string DypicFileName = "";
            string EnrollName = "";
            string EmpNo = "";
            picPath = picPath + "AttendPhoto\\";
            DypicPath = DypicPath + "DynamicPhoto\\";
            if (!Directory.Exists(picPath)) Directory.CreateDirectory(picPath);
            if (!Directory.Exists(DypicPath)) Directory.CreateDirectory(DypicPath);
            UInt32 EnrollNumber;
            byte[] buff = new byte[0];
            Image img;
            MemoryStream ms;
            DataTableReader drPhoto = null;
            progBar.ProgressType = eProgressItemType.Standard;
            for (int i = 0; i < dtUploadcount.Rows.Count; i++)
            {

                EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());
                EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                picFileName = picPath + "LF" + EnrollNumber.ToString("00000000") + ".jpg";
                DypicFileName = DypicPath + "LF" + EnrollNumber.ToString("00000000") + ".jpg";
                lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerName", "") +
                  string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber, i + 1, dtUploadcount.Rows.Count);
                progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;
                try
                {
                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                    drPhoto = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "13", EmpNo }));
                    if (drPhoto.Read())
                    {
                        if (drPhoto["EmpPhotoImage"].ToString() != "")
                        {
                            buff = (byte[])(drPhoto["EmpPhotoImage"]);
                            if (buff.Length > 0)
                            {
                                ms = new MemoryStream();
                                ms.Write(buff, 0, buff.Length);
                                ms.Position = 0;
                                img = Image.FromStream(ms);
                                img.Save(picFileName);
                                ms.Dispose();
                                img.Dispose();
                            }
                        }
                        if (drPhoto["EmpPhoto"].ToString() != "")
                        {
                            buff = (byte[])(drPhoto["EmpPhoto"]);
                            if (buff.Length > 0)
                            {
                                ms = new MemoryStream();
                                ms.Write(buff, 0, buff.Length);
                                ms.Position = 0;
                                img = Image.FromStream(ms);
                                img.Save(DypicFileName);
                                ms.Dispose();
                                img.Dispose();
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
                    if (drPhoto != null) drPhoto.Close();
                    drPhoto = null;
                }
                img = null;
                ms = null;
                buff = null;

                Application.DoEvents();
            }
        }

        private bool UploadInfoUSB(string Oprt, ref string MacMsg)
        {
            bool ret = DeviceObject.objFK623.SetUDiskFileFKModel(usbFKModel);
            if (!ret) return ret;
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int PasswordData = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            DialogResult MessRet;
            string StatusMsg = Oprt + "......";
            string CardNo = "";
            string pwd = "";
            byte[] buff = new byte[0];
            int CountUp = 0;
            if (dtUpload == null)
            {
                return true;
            }
            try
            {
                for (int i = 0; i < dtUpload.Rows.Count; i++)
                {
                    EnrollNumber = Convert.ToUInt32(dtUpload.Rows[i]["FingerNo"].ToString());
                    BackupNumber = Convert.ToInt32(dtUpload.Rows[i]["FingerBkNo"].ToString());
                    Privilege = Convert.ToInt32(dtUpload.Rows[i]["FingerPrivilege"].ToString());
                    EnrollName = dtUpload.Rows[i]["EmpName"].ToString();
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {3}/{4}  {0}[{1}: {2}]", EnrollName, EnrollNumber, BackupNumber,
                      i + 1, dtUpload.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dtUpload.Rows.Count;
                    buff = (byte[])dtUpload.Rows[i]["FingerData"];
                    if (BackupNumber >= (int)FKBackup.BACKUP_FP_0 && BackupNumber <= (int)FKBackup.BACKUP_FP_9)
                    {
                        fpData = new byte[(int)FKMax.FK_FPDataSize];
                    }
                    else if (BackupNumber == (int)FKBackup.BACKUP_PSW || BackupNumber == (int)FKBackup.BACKUP_CARD)
                    {
                        fpData = new byte[(int)FKMax.FK_PasswordDataSize];
                    }
                    else if (BackupNumber == (int)FKBackup.BACKUP_FACE)
                    {
                        fpData = new byte[(int)FKMax.FK_FaceDataSize];
                    }
                    else if (BackupNumber >= (int)FKBackup.BACKUP_PALMVEIN_0 && BackupNumber <= (int)FKBackup.BACKUP_PALMVEIN_3)
                    {
                        fpData = new byte[(int)FKMax.PALMVEINDataSize];
                    }
                    else if (BackupNumber == (int)FKBackup.BACKUP_VEIN_0)
                    {
                        fpData = new byte[(int)FKMax.FK_VeinDataSize];
                    }
                    Array.Copy(buff, fpData, fpData.Length);
                EEE:
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.USBSetOneEnrollData(EnrollNumber, BackupNumber,
                      Privilege, fpData, PasswordData, EnableFlag, EnrollName);
                    if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                    {
                        if (GetUploadSuccess(EnrollNumber) || DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_INVALID_PARAM)
                        {
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            continue;
                        }
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_MEMORYOVER)
                        {
                            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            break;
                        }
                        MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                          Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNo);
                        if (MessRet == DialogResult.Yes)
                            goto EEE;
                        else if (MessRet == DialogResult.No)
                            break;
                    }
                    else
                    {
                        CountUp++;
                    }
                    SetUploadSuccess(EnrollNumber);
                    //SuccessList[i].IsSuccess = true;  
                    Application.DoEvents();
                }

                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["FingerNo"].ToString());
                    CardNo = dtUploadcount.Rows[i]["CardNo10"].ToString();
                    pwd = dtUploadcount.Rows[i]["pwd"].ToString();
                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    Privilege = Convert.ToInt32(dtUploadcount.Rows[i]["FingerPrivilege"].ToString());


                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            if (string.IsNullOrEmpty(CardNo)) continue;
                            BackupNumber = 11;

                            buff = EncAndDec.getCard(CardNo);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(pwd)) break;

                            BackupNumber = 10;

                            buff = EncAndDec.getPWD(pwd);
                        }

                        lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "EmpCardNo", "") + "、" + Pub.GetResText(formCode, "EmpPWDNo", "") +
                        string.Format(" - {3}/{4}  {0}[{1}: {2}]", EnrollName, EnrollNumber, BackupNumber,
                        i + 1, dtUploadcount.Rows.Count);
                        progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;

                        fpData = new byte[(int)FKMax.FK_PasswordDataSize];
                        Array.Copy(buff, fpData, fpData.Length);
                    EEE:
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.USBSetOneEnrollData(EnrollNumber, BackupNumber,
                          Privilege, fpData, PasswordData, EnableFlag, EnrollName);
                        if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                        {
                            if (GetUploadSuccess(EnrollNumber) || DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_INVALID_PARAM)
                            {
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                continue;
                            }
                            if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_MEMORYOVER)
                            {
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                break;
                            }
                            MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                              Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNo);
                            if (MessRet == DialogResult.Yes)
                                goto EEE;
                            else if (MessRet == DialogResult.No)
                                break;
                        }
                        else
                        {
                            CountUp++;
                        }
                        SetUploadSuccess(EnrollNumber);
                        //SuccessList[i].IsSuccess = true;  
                        Application.DoEvents();
                    }
                }
                if (dtUpload.Rows.Count > 0 || dtUploadcount.Rows.Count > 0)
                {
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                    {
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.USBWriteAllEnrollDataToFile(usbFile);
                        SetUSBPhoto(StatusMsg);
                        ret = true;
                    }
                }
                else
                    ret = true;
            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E);
            }
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, dtUploadcount.Rows.Count, dtUploadcount.Rows.Count, CountUp);
            }
            else if (File.Exists(usbFile))
            {
                try
                {
                    File.Delete(usbFile);
                }
                catch
                {
                }
            }
            return ret;
        }

        private bool ClearData()
        {
            return DeviceObject.objFK623.EmptyGeneralLogData();
        }

        private bool Star_ClearData()
        {
            bool ret = false;
            string cmd = "ClearLogData";
            DeviceCmd devClearLogDataCmd = new DeviceCmd(cmd);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devClearLogDataCmd));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
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
            return ret;
        }

        private bool SeaSeries_ClearData(string url, string name, string pwd)
        {
            bool ret = false;
            url = url + "action/SetFactoryDefault";
            SeaSeriesInitDevice seaSeriesInitDevice = new SeaSeriesInitDevice(0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0);
            jsonBody<SeaSeriesInitDevice> SeaSeriesInitDeviceJson = new jsonBody<SeaSeriesInitDevice>("SetFactoryDefault", seaSeriesInitDevice);
            string jsonString = JsonConvert.SerializeObject(SeaSeriesInitDeviceJson);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);

            return ret;
        }

        private bool ClearManager()
        {
            return DeviceObject.objFK623.BenumbAllManager();
        }

        private bool Star_ClearManager()
        {
            bool ret = false;
            string cmd = "ClearManager";
            DeviceCmd devClearManagerCmd = new DeviceCmd(cmd);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devClearManagerCmd));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
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
            return ret;
        }

        private bool ClearInfo()
        {
            return DeviceObject.objFK623.EmptyEnrollData();
        }

        private bool Star_ClearInfo(List<UInt32> downUserIdList, bool IsAll)
        {
            bool ret = false;
            List<string> usersIDList = new List<string>();
            string cmd = "";
            StringBuilder jsonStringBuilder = null;
            DeleteUserInfoCmd deleteUserInfoCmd = null;
            cmd = "DeleteUserInfo";
            if (IsAll)
            {
                deleteUserInfoCmd = new DeleteUserInfoCmd(0, null);
            }
            else
            {
                for (int i = 0; i < downUserIdList.Count; i++)
                {
                    usersIDList.Add(downUserIdList[i].ToString());
                }
                deleteUserInfoCmd = new DeleteUserInfoCmd(usersIDList.Count, usersIDList);
            }
            _DeviceCmd<DeleteUserInfoCmd> devDeleteUserInfoCmd = new _DeviceCmd<DeleteUserInfoCmd>(cmd, deleteUserInfoCmd);
            ret = false;
            jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devDeleteUserInfoCmd));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }

            return ret;
        }

        private bool SeaSeries_ClearInfo(string url, string name, string pwd)
        {
            bool ret = false;
            url = url + "action/SetFactoryDefault";
            DefaltPersonCmd seaSeriesInitDevice = new DefaltPersonCmd(1);
            jsonBody<DefaltPersonCmd> SeaSeriesInitDeviceJson = new jsonBody<DefaltPersonCmd>("SetFactoryDefault", seaSeriesInitDevice);
            string jsonString = JsonConvert.SerializeObject(SeaSeriesInitDeviceJson);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
            if (!ret)
            {
                ret = false;
            }
            else
            {
                jsonBody<Answer> answer = JsonConvert.DeserializeObject<jsonBody<Answer>>(jsonString);
                {
                    if (answer.info.Result != "Ok")
                    {
                        ret = false;
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUNERR_UNKNOWNERROR;
                    }
                    else
                    {
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    }

                }
            }
            return ret;
        }

        private bool ClearInfo(List<UInt32> EnrollNumberList)
        {
            string StatusMsg = lblMsg.Text;
            progBar.ProgressType = eProgressItemType.Standard;
            for (int n = 0; n < EnrollNumberList.Count; n++)
            {
                lblMsg.Text = StatusMsg +
                      string.Format(" - {0}/{1}", n + 1, EnrollNumberList.Count);
                progBar.Value = (n + 1) * 100 / EnrollNumberList.Count;
                Application.DoEvents();
                for (int i = 0; i < 16; i++)
                {
                    DeviceObject.objFK623.DeleteEnrollData(EnrollNumberList[n], i);
                }
            }
            return true;
        }

        private bool SeaSeries_ClearInfo(List<UInt32> EnrollNumberList, string url, string name, string pwd, string MacSN)
        {
            bool ret = false;
            url = url + "action/DeletePerson";
            UInt32 EnrollNumber = 0;
            int BakNo = 0;
            DeletePerson deletePersonInfo = null;
            jsonBody<DeletePerson> deletePerson = null;
            string jsonString = "";
            string StatusMsg = lblMsg.Text;
            List<int> IDList = new List<int>();
            List<int> CustomizeIDList = new List<int>();
            try
            {
                for (int i = 0; i < EnrollNumberList.Count; i++)
                {
                    CustomizeIDList = new List<int>();
                    EnrollNumber = EnrollNumberList[i];
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {0}/{1}  {2}-{3}", i + 1, EnrollNumberList.Count, EnrollNumber, BakNo);
                    if (IDList.Contains(Convert.ToInt32(EnrollNumber)))
                        continue;
                    IDList.Add(Convert.ToInt32(EnrollNumber));
                    CustomizeIDList.Add(Convert.ToInt32(EnrollNumber));
                    //删除人员
                    deletePersonInfo = new DeletePerson(Convert.ToInt32(MacSN), CustomizeIDList.Count, 0, CustomizeIDList);

                    deletePerson = new jsonBody<DeletePerson>("DeletePerson", deletePersonInfo);
                    jsonString = JsonConvert.SerializeObject(deletePerson);
                    ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
                    Application.DoEvents();
                }

                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        private bool ClearInfoDim(ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int BakNo = 0;
            string StatusMsg = lblMsg.Text;
            try
            {
                for (int i = 0; i < dimList.Count; i++)
                {
                    EnrollNumber = dimList[i].EnrollNumber;
                    BakNo = dimList[i].BakNo;
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {0}/{1}  {2}-{3}", i + 1, dimList.Count, EnrollNumber, BakNo);
                EEE:
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, BakNo);
                    if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                    {
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_NO_OPEN_COMM ||
                          DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_WRITE_FAIL)
                        {
                            if (DeviceObject.objFK623.ReOpen()) goto EEE;
                        }
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    }
                    Application.DoEvents();
                }
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (ret) MacMsg = dimList.Count.ToString();
            return ret;
        }


        private bool Star_ClearInfoDim(ref string MacMsg)
        {
            bool ret = false;
            string StatusMsg = lblMsg.Text;
            List<string> usersIDList = new List<string>();
            try
            {
                for (int i = 0; i < dimList.Count; i++)
                {
                    usersIDList.Add(dimList[i].EnrollNumber.ToString());
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {0}/{1}  {2}-{3}", i + 1, dimList.Count, dimList[i].EnrollNumber, 0);

                    Application.DoEvents();
                }
                string cmd = "DeleteUserInfo";
                DeleteUserInfoCmd deleteUserInfoCmd = new DeleteUserInfoCmd(usersIDList.Count, usersIDList);
                _DeviceCmd<DeleteUserInfoCmd> devDeleteUserInfoCmd = new _DeviceCmd<DeleteUserInfoCmd>(cmd, deleteUserInfoCmd);
                StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devDeleteUserInfoCmd));
                if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
                {
                    int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                    if (state == 0)
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                    }
                }
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (ret) MacMsg = dimList.Count.ToString();
            return ret;
        }

        private bool SeaSeries_ClearInfoDim(string url, string name, string pwd, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            url = url + "action/DeletePerson";
            UInt32 EnrollNumber = 0;
            int BakNo = 0;
            DeletePerson deletePersonInfo = null;
            jsonBody<DeletePerson> deletePerson = null;
            string jsonString = "";
            string StatusMsg = lblMsg.Text;
            List<int> CustomizeIDList = new List<int>();
            List<int> IDList = new List<int>();
            try
            {
                for (int i = 0; i < dimList.Count; i++)
                {
                    CustomizeIDList = new List<int>();
                    EnrollNumber = dimList[i].EnrollNumber;
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {0}/{1}  {2}-{3}", i + 1, dimList.Count, EnrollNumber, BakNo);
                    if (IDList.Contains(Convert.ToInt32(EnrollNumber)))
                        continue;
                    IDList.Add(Convert.ToInt32(EnrollNumber));
                    CustomizeIDList.Add(Convert.ToInt32(EnrollNumber));
                    //删除人员
                    deletePersonInfo = new DeletePerson(Convert.ToInt32(MacSN), CustomizeIDList.Count, 0, CustomizeIDList);

                    deletePerson = new jsonBody<DeletePerson>("DeletePerson", deletePersonInfo);
                    jsonString = JsonConvert.SerializeObject(deletePerson);
                    ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
                    Application.DoEvents();
                }

                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (ret) MacMsg = dimList.Count.ToString();
            return ret;
        }

        private bool InitDevice()
        {
            return DeviceObject.objFK623.ClearKeeperData();
        }

        private bool Star_InitDevice()
        {
            bool ret = false;
            string cmd = "ResetDevice";
            DeviceCmd devClearManagerCmd = new DeviceCmd(cmd);
            StringBuilder jsonStringBuilder = new StringBuilder(JsonConvert.SerializeObject(devClearManagerCmd));
            if (DeviceObject.socKetClient.SendData(ref jsonStringBuilder))
            {
                int state = DeviceObject.socKetClient.JsonRecive(jsonStringBuilder);
                if (state == 0)
                {
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
            return ret;
        }

        private bool SeaSeries_InitDevice(string url, string name, string pwd)
        {
            bool ret = false;
            url = url + "action/SetFactoryDefault";
            SeaSeriesInitDevice seaSeriesInitDevice = new SeaSeriesInitDevice(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            jsonBody<SeaSeriesInitDevice> SeaSeriesInitDeviceJson = new jsonBody<SeaSeriesInitDevice>("SetFactoryDefault", seaSeriesInitDevice);
            string jsonString = JsonConvert.SerializeObject(SeaSeriesInitDeviceJson);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
            return ret;
        }

        private bool MJDoorStateGet(string MacSN)
        {
            int v = 0;
            bool ret = DeviceObject.objFK623.GetDoorStatus(ref v);
            if (ret)
            {
                string state = "";
                switch (v)
                {
                    case (int)FKDoor.DOOR_CONTROLRESET:
                        state = Pub.GetResText(formCode, "FK_DOOR_CONTROLRESET", "");
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
                string sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "301", state, MacSN });
                try
                {
                    SystemInfo.db.ExecSQL(sql);

                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        if (dataGrid[1, i].Value.ToString() == MacSN)
                        {
                            dataGrid[23, i].Value = state;
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

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void realGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void msgGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void bindingSource_PositionChanged(object sender, EventArgs e)
        {
            RefresButton(true);
        }

        private void realGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e == null)
                realGrid.Rows[realGrid.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = realGrid.Rows[realGrid.Rows.Count - 1].DefaultCellStyle.ForeColor;
            else if (e.RowIndex >= 0)
                realGrid.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = realGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor;

            picPhoto.BackgroundImage = null;
            picData.BackgroundImage = null;
            if (realGrid.SelectedRows.Count < 1) return;
            if (realGrid.SelectedRows[0].Cells[3].Value == null) return;
            string EmpNo = realGrid.SelectedRows[0].Cells[3].Value.ToString();
            string GUID = realGrid.SelectedRows[0].Cells[10].Value.ToString();
            string InOut = realGrid.SelectedRows[0].Cells[8].Value.ToString();
            DataTableReader dr = null;

            if (EmpNo == "")
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "14", GUID }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }
                dr.Close();
                if (picData.BackgroundImage != null)
                {
                    return;
                }
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "11", GUID }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }
                if (picData.BackgroundImage != null)
                {
                    return;
                }
                dr.Close();
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "3", GUID }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }

                return;
            }
            if (EmpNo == "") return;

            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "13", EmpNo }));
                if (dr.Read())
                {
                    if (dr["EmpPhotoImage"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["EmpPhotoImage"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picPhoto.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }
                dr.Close();
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "1", GUID }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }
                else
                {
                    dr.Close();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000214, new string[] { "3", GUID }));
                    if (dr.Read())
                    {
                        if (dr["Photo"].ToString() != "")
                        {
                            byte[] buff = (byte[])(dr["Photo"]);
                            if (buff.Length > 0)
                            {
                                MemoryStream ms = new MemoryStream(buff);
                                picData.BackgroundImage = Image.FromStream(ms);
                                ms.Close();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
        }

        private void SaveDoorStauts(TFingerLog attLog, string MacSN, byte[] PhotoImage, bool door)
        {
            string GUID = "";
            int DevMode = 0;
            //获取设备模式
            DataTableReader dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "2", MacSN }));
            if (dr.Read())
            {
                Int32.TryParse(dr["DevModeID"].ToString(), out DevMode);
            }
            dr.Close();

            if (attLog.VerifyMode == 0)
            {
                attLog.VerifyMode = attLog.DoorMode;
                attLog.VerifyModeName = attLog.DoorModeName;
            }

            string sqldoor = "";

            if (door)
            {
                for (int x = 0; x < panel5.Controls.Count; x++)
                {
                    if (panel5.Controls[x].Name == "btn" + MacSN.ToString())
                    {
                        panel5.Controls[x].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\2.jpg");
                        sqldoor = Pub.GetSQL(DBCode.DB_000300, new string[] { "6", "2", MacSN });
                        break;
                    }
                }
            }
            else
            {
                for (int x = 0; x < panel5.Controls.Count; x++)
                {
                    if (panel5.Controls[x].Name == "btn" + MacSN.ToString())
                    {
                        panel5.Controls[x].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\1.jpg");
                        sqldoor = Pub.GetSQL(DBCode.DB_000300, new string[] { "6", "1", MacSN });
                        break;
                    }
                }
            }
            SystemInfo.db.ExecSQL(sqldoor);
            //attLog.CardTime=attLog.CardTime.AddSeconds(2);
            readData.WriteTextFileMJ(attLog, MacSN);

            if (DevMode == 0 || DevMode == 2)
            {
                readData.SaveDBMJ(attLog, MacSN, false, ref GUID);
            }

            if (GUID != "") ShowReadDataProcess(1, 1, MacSN, attLog, GUID, true);
        }

        private void SaveRealData(TFingerLog attLog, string MacSN, byte[] PhotoImage)
        {
            string GUID = "";
            int DevMode = 0;
            if (readData != null)
            {
                //获取设备模式
                DataTableReader dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "2", MacSN }));
                if (dr.Read())
                {
                    Int32.TryParse(dr["DevModeID"].ToString(), out DevMode);
                }
                dr.Close();

                readData.SetLogName(attLog);
                bool IsKQ = readData.IsKQData(attLog);
                if (IsKQ)
                {
                    string InOutModeName = attLog.InOutModeName;
                    readData.SetInOutModeName(attLog.InOutMode, ref InOutModeName);
                    attLog.InOutModeName = InOutModeName;
                    if (AInOutModeName != "")
                        attLog.InOutModeName = AInOutModeName;
                    readData.WriteTextFile(attLog, MacSN);

                    if (DevMode == 0 || DevMode == 1)
                    {
                        readData.SaveDB(attLog, MacSN, false, ref GUID);

                        if (GUID != "" && PhotoImage != null && PhotoImage.Length > 0)
                        {
                            readData.SaveDBPhoto(GUID, PhotoImage);
                        }
                    }
                    
                }
                else
                {
                    if (attLog.VerifyMode == 0)
                    {
                        attLog.VerifyMode = attLog.DoorMode;
                        attLog.VerifyModeName = attLog.DoorModeName;
                    }
                    readData.WriteTextFileMJ(attLog, MacSN);

                    if (DevMode == 0 || DevMode == 2)
                    {
                        readData.SaveDBMJ(attLog, MacSN, false, ref GUID);
                        if (GUID != "" && PhotoImage != null && PhotoImage.Length > 0)
                        {
                            readData.SaveDBPhotoMJ(GUID, PhotoImage);
                        }
                    }
                   
                }
                if (IsKQ && attLog.DoorMode > 0)
                {
                    string Name = attLog.VerifyModeName;
                    attLog.VerifyMode = attLog.DoorMode;
                    attLog.VerifyModeName = attLog.DoorModeName;
                    if (DevMode == 0 || DevMode == 2)
                    {
                        readData.SaveDBMJ(attLog, MacSN, false, ref GUID);
                        if (GUID != "" && PhotoImage != null && PhotoImage.Length > 0)
                        {
                            readData.SaveDBPhotoMJ(GUID, PhotoImage);
                        }
                    }
                    attLog.VerifyModeName = Name + "  " + attLog.VerifyModeName;
                }
            }
            if (GUID != "") ShowReadDataProcess(1, 1, MacSN, attLog, GUID, true);
        }

        private void axRealSvr_OnReceiveGLogDataExtend(object sender,
          AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogDataExtendEvent e)
        {
            UInt32 id = DeviceObject.objFK623.EnrollNumberToUInt32(e.anSEnrollNumber);
            TFingerLog attLog = new TFingerLog();
            attLog.CardID = id.ToString("0000000000");
            attLog.CardTime = e.anLogDate;
            attLog.Remark = e.astrDeviceIP + "[" + e.anDevicePort.ToString() + "]";
            attLog.FingerNo = id;
            attLog.VerifyMode = e.anVerifyMode;
            attLog.InOutMode = e.anInOutMode;
            SaveRealData(attLog, e.anDeviceID.ToString(), null);
        }

        private bool GetFieldValue(string LogText, string FieldName, ref string FieldValue)
        {
            bool ret = false;
            FieldValue = "";
            string[] s1 = LogText.Split(',');
            for (int i = 0; i < s1.Length; i++)
            {
                string[] s2 = s1[i].Split(':');
                if (s2.Length != 2) continue;
                if (s2[0].ToLower() == FieldName)
                {
                    FieldValue = s2[1];
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        private void ProgMJStautJsonText(string logText, string Remark)
        {
            string v = "";
            byte[] PhotoImage = new byte[0];
            TFingerLog attLog = new TFingerLog();
            string MacSN = "0";
            string HeartBeatMacSN = "0";
            if (GetFieldValue(logText, "heartbeatdevice", ref v)) HeartBeatMacSN = v;
            if (GetFieldValue(logText, "fk_device_id", ref v)) MacSN = v;
            attLog.Remark = Remark;
            string Door_Status = "";
            bool IsOpenDoor = false;
            if (GetFieldValue(logText, "door_status", ref v))
            {
                switch (int.Parse(v))
                {
                    case (int)FKDoor.DOOR_CONTROLRESET:
                        Door_Status = Pub.GetResText(formCode, "FK_DOOR_CLOSED", "");
                        IsOpenDoor = false;
                        break;
                    case (int)FKDoor.DOOR_OPEND:
                        Door_Status = Pub.GetResText(formCode, "FK_DOOR_OPEND", "");
                        IsOpenDoor = true;
                        break;
                    case (int)FKDoor.DOOR_CLOSED:
                        Door_Status = Pub.GetResText(formCode, "FK_DOOR_CONTROLRESET", "");
                        break;
                    case (int)FKDoor.DOOR_COMMNAD:
                        Door_Status = Pub.GetResText(formCode, "FK_DOOR_COMMNAD", "");
                        break;
                    default:
                        Door_Status = Pub.GetResText(formCode, "FK_DOOR_UNKNOWN", "");
                        break;
                }

            }
            if (GetFieldValue(logText, "doorchangetime", ref v) && v.Length == 14)
            {
                int y = 0;
                int m = 0;
                int d = 0;
                int hh = 0;
                int mi = 0;
                int se = 0;
                if (int.TryParse(v.Substring(0, 4), out y) && int.TryParse(v.Substring(4, 2), out m) &&
                  int.TryParse(v.Substring(6, 2), out d) && int.TryParse(v.Substring(8, 2), out hh) &&
                  int.TryParse(v.Substring(10, 2), out mi) && int.TryParse(v.Substring(12, 2), out se))
                {
                    attLog.CardTime = new DateTime(y, m, d, hh, mi, se);
                }
            }
            attLog.DoorStauts = Door_Status;
            if (HeartBeatMacSN != "0" && MacSN == "0")
            {
                for (int c = 0; c < dataGrid.RowCount; c++)
                {
                    if (dataGrid[1, c].Value.ToString() == HeartBeatMacSN.ToString())
                    {
                        if (dataGrid[8, c].Value.ToString() == Pub.GetResText("", "Offline", ""))
                        {
                            for (int s = 0; s < panel5.Controls.Count; s++)
                            {

                                if (panel5.Controls[s].Name == "btn" + monitoringsList[c].MacSN)
                                {
                                    panel5.Controls[s].BackgroundImage = Image.FromFile(SystemInfo.AppPath + "www\\Images\\1.jpg");
                                    break;
                                }

                            }
                        }
                        dataGrid[8, c].Value = Pub.GetResText("", "Online", "");
                        dataGrid.Rows[c].Cells[8].Style.ForeColor = Color.Green;
                        dataGrid.Rows[c].Cells[8].Style.SelectionForeColor = Color.Green;
                        break;
                    }
                }
                for (int c = 0; c < dataGrid.RowCount; c++)
                {
                    if (monitoringsList[c].MacSN.Equals(HeartBeatMacSN))
                    {
                        monitoringsList[c].BakNo = 1;
                        break;
                    }
                }
                return;
            }

            SaveDoorStauts(attLog, MacSN, PhotoImage, IsOpenDoor);
        }


        private void ProgJsonText(string logText, string Remark, string LogImage, int flag, ref string sendLog)
        {
            sendLog = "";
            TFingerLog attLog = new TFingerLog();
            string v = "";
            AInOutModeName = "";
            if (GetFieldValue(logText, "user_id", ref v))
            {
                UInt32 id = 0;
                if (UInt32.TryParse(v, out id))
                {
                    attLog.CardID = id.ToString("0000000000");
                    attLog.FingerNo = id;
                }
            }
            if (GetFieldValue(logText, "io_time", ref v) && v.Length == 14)
            {
                int y = 0;
                int m = 0;
                int d = 0;
                int hh = 0;
                int mi = 0;
                int se = 0;
                if (int.TryParse(v.Substring(0, 4), out y) && int.TryParse(v.Substring(4, 2), out m) &&
                  int.TryParse(v.Substring(6, 2), out d) && int.TryParse(v.Substring(8, 2), out hh) &&
                  int.TryParse(v.Substring(10, 2), out mi) && int.TryParse(v.Substring(12, 2), out se))
                {
                    attLog.CardTime = new DateTime(y, m, d, hh, mi, se);
                }
            }
            if (GetFieldValue(logText, "verify_mode", ref v))
            {
                switch (v.ToLower())
                {
                    case "fp":
                        attLog.VerifyMode = (int)FKLog.LOG_FPVERIFY;
                        break;
                    case "pass":
                    case "password":
                        attLog.VerifyMode = (int)FKLog.LOG_PASSVERIFY;
                        break;
                    case "card":
                    case "idcard":
                        attLog.VerifyMode = (int)FKLog.LOG_CARDVERIFY;
                        break;
                    case "fp+pass":
                    case "fp+password":
                        attLog.VerifyMode = (int)FKLog.LOG_FPPASS_VERIFY;
                        break;
                    case "fp+card":
                    case "fp+idcard":
                        attLog.VerifyMode = (int)FKLog.LOG_FPCARD_VERIFY;
                        break;
                    case "pass+fp":
                    case "password+fp":
                        attLog.VerifyMode = (int)FKLog.LOG_PASSFP_VERIFY;
                        break;
                    case "card+fp":
                    case "idcard+fp":
                        attLog.VerifyMode = (int)FKLog.LOG_CARDFP_VERIFY;
                        break;
                    case "card+pass":
                    case "card+password":
                    case "idcard+pass":
                    case "idcard+password":
                        attLog.VerifyMode = (int)FKLog.LOG_CARDPASS_VERIFY;
                        break;
                    case "face":
                        attLog.VerifyMode = (int)FKLog.LOG_FACEVERIFY;
                        break;
                    case "face+card":
                    case "face+idcard":
                        attLog.VerifyMode = (int)FKLog.LOG_FACECARDVERIFY;
                        break;
                    case "face+pass":
                    case "face+password":
                        attLog.VerifyMode = (int)FKLog.LOG_FACEPASSVERIFY;
                        break;
                    case "card+face":
                    case "idcard+face":
                        attLog.VerifyMode = (int)FKLog.LOG_CARDFACEVERIFY;
                        break;
                    case "pass+face":
                    case "password+face":
                        attLog.VerifyMode = (int)FKLog.LOG_PASSFACEVERIFY;
                        break;
                    case "face+fp":
                        attLog.VerifyMode = (int)FKLog.LOG_FACE_FP_VERIFY;
                        break;
                    case "fp+face":
                        attLog.VerifyMode = (int)FKLog.LOG_FP_FACE_VERIFY;
                        break;
                    case "pp":
                        attLog.VerifyMode = (int)FKLog.LOG_PPVERIFY;
                        break;
                    case "pp+pass":
                    case "pp+password":
                        attLog.VerifyMode = (int)FKLog.LOG_PPPASSVERIFY;
                        break;
                    case "pp+card":
                    case "pp+idcard":
                        attLog.VerifyMode = (int)FKLog.LOG_PPCARDVERIFY;
                        break;
                    case "pass+pp":
                    case "password+pp":
                        attLog.VerifyMode = (int)FKLog.LOG_PASSPPVERIFY;
                        break;
                    case "card+pp":
                    case "idcard+pp":
                        attLog.VerifyMode = (int)FKLog.LOG_CARDPPVERIFY;
                        break;
                    case "face+pp":
                        attLog.VerifyMode = (int)FKLog.LOG_FACE_PP_VERIFY;
                        break;
                    case "pp+face":
                        attLog.VerifyMode = (int)FKLog.LOG_PP_FACE_VERIFY;
                        break;
                    case "fp+pp":
                        attLog.VerifyMode = (int)FKLog.LOG_FP_PP_VERIFY;
                        break;
                    default:
                        attLog.VerifyModeName = v;
                        break;
                }
            }
            if (GetFieldValue(logText, "io_mode", ref v))
            {
                int tmp = 0;
                if (int.TryParse(v, out tmp))
                {
                    attLog.InOutMode = tmp;
                }
                else
                {
                    switch (v.ToLower())
                    {
                        case "in":
                            attLog.InOutMode = (int)FKLog.LOG_IOMODE_IN1;
                            break;
                        case "out":
                            attLog.InOutMode = (int)FKLog.LOG_IOMODE_OUT1;
                            break;
                        default:
                            AInOutModeName = v;
                            break;
                    }
                }
            }
            string MacSN = "0";
            if (GetFieldValue(logText, "fk_device_id", ref v)) MacSN = v;
            attLog.Remark = Remark;
            if (attLog.CardID != null && attLog.CardTime != null)
            {
                string tmp = LogImage;
                int len = tmp.Length / 2;
                byte[] PhotoImage = new byte[len];
                for (int i = 0; i < len; i++)
                {
                    PhotoImage[i] = Convert.ToByte(tmp.Substring(i * 2, 2), 16);
                }
                SaveRealData(attLog, MacSN, PhotoImage);

            }
            if (GetFieldValue(logText, "log_id", ref v))
            {
                if (flag == 1)
                    sendLog = "{\"log_id\":\"" + v + "\",\"result\":\"OK\",\"mode\":\"nothing\"}";
                else
                    sendLog = "{\"log_id\":\"" + v + "\",\"result\":\"OK\"}";
            }
        }

        private void axRealSvr_OnReceiveGLogTextAndImage(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogTextAndImageEvent e)
        {
            string logText = e.astrLogText.Trim().Replace("\"", "").Replace("{", "").Replace("}", "");
            string Remark = e.astrClientIP + "[" + e.anClientPort.ToString() + "]";
            string LogImage = e.astrLogImage.Replace(" ", "");
            string sendLog = "";
            ProgJsonText(logText, Remark, LogImage, 0, ref sendLog);
            axRealSvr.SendResponse(e.astrClientIP, e.anClientPort, sendLog);
        }

        private void axRealSvr_OnReceiveGLogTextOnDoorOpen(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogTextOnDoorOpenEvent e)
        {
            string logText = e.astrLogText.Trim().Replace("\"", "").Replace("{", "").Replace("}", "");
            string Remark = e.astrClientIP + "[" + e.anClientPort.ToString() + "]";
            string LogImage = e.astrLogImage.Replace(" ", "");
            string sendLog = "";
            ProgJsonText(logText, Remark, LogImage, 1, ref sendLog);
            axRealSvr.SendRtLogResponseV3(e.astrClientIP, e.anClientPort, sendLog);
        }

        private void axRealSvr_OnReceiveGLogText(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogTextEvent e)
        {
            string logText = e.astrLogText.Trim().Replace("\"", "").Replace("{", "").Replace("}", "");
            string Remark = e.astrClientIP + "[" + e.anClientPort.ToString() + "]";
            ProgMJStautJsonText(logText, Remark);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BellTime = BellTime + 1;
            string time = SystemInfo.db.ReadConfig("SystemInfo", "Time");
            if (time == "")
                time = "30";

            if (BellTime >= int.Parse(time))
            {
                sp.Stop();
            }

        }

        private void WriteMainButton(int topIndex, int Index, string ButtonName, int IsOpen)
        {
            string title = Pub.GetResText(formCode, ButtonName, "");
            if (title == "") title = ButtonName;
            Panel btn = new Panel();
            btn.BackgroundImageLayout = ImageLayout.Stretch;

            btn.Name = "btn" + ButtonName;
            btn.Width = 30;
            btn.Height = 45;
            btn.TabStop = false;
            btn.Left = (btn.Width + 25) * (topIndex - 1) + 25;
            btn.Top = (btn.Height + 25) * (Index - 1) + 10;
            btn.Font = new Font(Font.Name, 12, FontStyle.Bold);
            string imageFile1 = imagePath + "1" + ".jpg";
            string imageFile2 = imagePath + "2" + ".jpg";
            string imageFile3 = imagePath + "3" + ".jpg";
            string imageFile4 = imagePath + "4" + ".jpg";
            string imageFile5 = imagePath + "5" + ".jpg";
            if (IsOpen == 1)
            {
                if (File.Exists(imageFile1))
                    btn.BackgroundImage = Image.FromFile(imageFile1);

            }
            else if (IsOpen == 2)
            {
                if (File.Exists(imageFile2))
                    btn.BackgroundImage = Image.FromFile(imageFile2);

            }
            else if (IsOpen == 3)
            {
                if (File.Exists(imageFile3))
                    btn.BackgroundImage = Image.FromFile(imageFile3);

            }
            else if (IsOpen == 4)
            {
                if (File.Exists(imageFile4))
                    btn.BackgroundImage = Image.FromFile(imageFile4);

            }
            else if (IsOpen == 5)
            {
                if (File.Exists(imageFile5))
                    btn.BackgroundImage = Image.FromFile(imageFile5);

            }

            Label lbl = new Label();
            lbl.BackColor = Color.Transparent;
            lbl.Cursor = Cursors.Hand;

            lbl.ForeColor = Color.Black;
            lbl.Location = new Point(0, 0);
            lbl.Name = "btn" + ButtonName + "L";
            lbl.Text = title;
            lbl.Width = 40;
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Left = (btn.Width + 25) * (topIndex - 1) + 22;
            lbl.Top = (btn.Height + 25) * (Index - 1) + 54;
            if (SystemInfo.ShowMJ == 1)
            {
                panel5.Controls.Add(lbl);
                panel5.Controls.Add(btn);
                panel5.AutoScroll = true;
            }
        }

        private void ItemDevSet_Click(object sender, EventArgs e)
        {
            //if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemDevSet", true)) return;
            // frmMJDevSet frm = new frmMJDevSet(this.Text, Pub.GetResText(formCode, "ItemDevSet", ""));
            //frmPubMacParam frm = new frmPubMacParam(this.Text, Pub.GetResText(formCode, "ItemDevSet", ""));
            //frm.Show();
        }

        private void panel5_Resize(object sender, EventArgs e)
        {
            if (!AllowShowAll)
                return;
            panel5.Controls.Clear();
            Panel5Conut = panel5.Width / 65;
            if (Panel5Conut < 1)
                Panel5Conut = 1;
            string Online = Pub.GetResText(formCode, "Online", "");
            int a = 0;
            int x = 0;
            int xx = 1;
            int door = 4;
            string macSN = "";
            string OpenState = "";
            string sa = "";
            DataTableReader dr = null;
            imagePath = SystemInfo.AppPath + "www\\Images\\";
            SystemInfo.IsMacNomber = false;
            string QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "0" });
            string MacNomber = "";
            if (QuerySQL != "")
            {
                try
                {
                    dr = SystemInfo.db.GetDataReader(QuerySQL);
                    while (dr.Read())
                    {
                        SystemInfo.IsMacNomber = true;
                        MacNomber = dr["MacSN"].ToString();
                        if (!Pub.IsNumeric(MacNomber))
                        {
                            SystemInfo.IsMacNomber = false;
                            break;
                        }

                    }
                    if (dr != null)
                        dr.Close();
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "0" }));
                    while (dr.Read())
                    {
                        sa = dr["MacConnectState"].ToString();
                        OpenState = dr["OpenState"].ToString();

                        if (OpenState != null && OpenState != "")
                        {
                            if (OpenState == "2")
                                door = 2;
                            else if (OpenState == "1")
                                door = 1;
                            else if (OpenState == "3")
                                door = 3;
                            else if (OpenState == "5")
                                door = 5;
                            else if (OpenState == "4")
                                door = 4;
                        }
                        else
                            door = 4;

                        macSN = dr["MacSN"].ToString();
                        if (a > 0)
                            if (a % Panel5Conut == 0)
                            {
                                x = 0;
                                xx++;
                            }
                        x++;
                        a++;
                        WriteMainButton(x, xx, macSN, door);
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
                Application.DoEvents();
            }

        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                dataGrid.Rows[e.RowIndex].Cells[8].Style.SelectionForeColor = dataGrid.Rows[e.RowIndex].Cells[8].Style.ForeColor;
                Application.DoEvents();
            }
        }

        private void tsnCopy_Click(object sender, EventArgs e)
        {
            if (msgGrid.Rows.Count > 0)
            {
                Clipboard.SetDataObject(msgGrid.GetClipboardContent());
            }
        }

        private void tsnDelete_Click(object sender, EventArgs e)
        {
            if (msgGrid.Rows.Count > 0)
            {
                int t = msgGrid.CurrentRow.Index;
                msgGrid.Rows.RemoveAt(t);
            }
        }

        private void tsnClear_Click(object sender, EventArgs e)
        {
            msgGrid.Rows.Clear();
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.ShiftKey) && (!isSelectEnd))
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
            if (dataGrid.CurrentRow == null || dataGrid.Rows.Count == 0) return;
           
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

        private void frmMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            ShowHelpTopic();
        }

        private void dotNetBarManager_DockTabClosing(object sender, DockTabClosingEventArgs e)
        {
            DockContainerItem item = e.DockContainerItem;

            string name = item.Name;
            foreach (Bar con in dotNetBarManager.Bars)
            {
                foreach (DockContainerItem it in con.Items)
                {
                    if (it.Name == name)
                    {
                        if (it.Name != "TitleBar")
                            it.Text = "";
                        return;
                    }

                }

            }
            e.Cancel = true;
        }

        private void dotNetBarManager_BarClosing(object sender, BarClosingEventArgs e)
        {
            Bar item = (Bar)sender;

            string name = item.Name;
            foreach (Bar con in dotNetBarManager.Bars)
            {
                foreach (DockContainerItem it in con.Items)
                {
                    if (it.Name == name)
                    {
                        if (it.Name != "TitleBar")
                            it.Text = "";
                        return;
                    }

                }

            }
            e.Cancel = true;
        }

        private void bar1_DockTabClosing(object sender, DockTabClosingEventArgs e)
        {
            if (e.DockContainerItem.Name == "TitleBar")
            {
                e.Cancel = true;
            }
        }

        private void btnCloseX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void panTitle_MouseMove(object sender, MouseEventArgs e)
        {

            if (beginMove && e.Button == MouseButtons.Left)
            {
                int lx = MousePosition.X - currentXPosition;
                int ty = MousePosition.Y - currentYPosition;
                if (Math.Abs(lx) > 10 || Math.Abs(ty) > 10)
                {
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        btnMaxX.Symbol = "58310";
                    }
                    this.Left += lx;//根据鼠标x坐标确定窗体的左边坐标x
                    this.Top += ty;//根据鼠标的y坐标窗体的顶部，即Y坐标
                    currentXPosition = MousePosition.X;
                    currentYPosition = MousePosition.Y;
                }

            }
        }

        private void panTitle_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;

            }
        }

        private void btnMaxX_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaxX.Symbol = "58336";
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaxX.Symbol = "58310";
            }
        }

        private void btnMinX_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHelpX_Click(object sender, EventArgs e)
        {
            ShowHelpTopic();
        }

        private void sNIMuenX_Click(object sender, EventArgs e)
        {
            bool ret = true;

            for (int i = 0; i < uC_Navbar.iPanMenu.Items.Count; i++)
            {
                if (uC_Navbar.iPanMenu.Items[i] is ButtonItem)
                {
                    if (((ButtonItem)uC_Navbar.iPanMenu.Items[i]).ButtonStyle == eButtonStyle.Default)
                    {
                        ret = false;
                        break;
                    }
                }
            }

            refreshPanMenu(ret);
        }

        private void refreshPanMenu(bool ret)
        {
            int width = 0;
            string lbName = "";
            foreach (Control item in uC_Navbar.iPanMenu.Controls)
            {
                if (item is LabelX)
                {
                    if (ret)
                    {
                        sNIMuenX.Symbol = "58836";
                        ((LabelX)item).Text = "";

                    }
                    else
                    {
                        sNIMuenX.Symbol = "57921";
                        lbName = ((LabelX)item).Name;
                        ((LabelX)item).Text = Pub.GetResText(formCode, "mnu" + lbName.Replace("grp", ""), "");
                        uC_Navbar.sNIColse.Text = Pub.GetResText(formCode, "mnuSYClose", "");
                    }

                }
            }

            for (int i = 0; i < uC_Navbar.iPanMenu.Items.Count; i++)
            {
                if (uC_Navbar.iPanMenu.Items[i] is ButtonItem)
                {
                    if (ret)
                    {
                        ((ButtonItem)uC_Navbar.iPanMenu.Items[i]).ButtonStyle = eButtonStyle.Default;
                        if (i == 0)
                            uC_Navbar.Width = ((ButtonItem)uC_Navbar.iPanMenu.Items[i]).Size.Width;
                    }
                    else
                    {
                        ButtonItem te = (ButtonItem)uC_Navbar.iPanMenu.Items[i];
                        ((ButtonItem)uC_Navbar.iPanMenu.Items[i]).ButtonStyle = eButtonStyle.ImageAndText;
                        width = ((ButtonItem)uC_Navbar.iPanMenu.Items[i]).Size.Width;
                        if (width > uC_Navbar.Width)
                        {
                            uC_Navbar.Width = width + 6;
                        }

                    }

                }
            }
            uC_Navbar.Refresh();
        }

        private void LableX_MouseEnter(object sender, EventArgs e)
        {
            Control item = (LabelX)sender;
            item.BackColor = Color.FromArgb(105, 191, 255);
            item.ForeColor = Color.Black;
            if (item.Name == "btnCloseX")
            {
                btnCloseX.BackColor = Color.Red;
                btnCloseX.ForeColor = Color.White;
            }
        }

        private void LableX_MouseLeave(object sender, EventArgs e)
        {
            Control item = (LabelX)sender;
            item.BackColor = Color.FromArgb(1, 115, 199);
            item.ForeColor = Color.White;
        }

        private void panTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnMaxX.Symbol = "58336";
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                btnMaxX.Symbol = "58310";
            }
            beginMove = false;
        }

        private void ItemFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                dataGrid.Rows[i].Visible = true;
            }
            QuickSearchNormalMac(ItemFindText.Text, dataGrid);
            ItemFindText.Focus();
        }

        private void msgGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmBaseShowMsg frm = new frmBaseShowMsg(lbTitleX.Text, msgGrid[0, e.RowIndex].Value.ToString());
            frm.ShowDialog();
        }

        private void uC_PanelMuen_CloseClick(object sender, EventArgs e)
        {
            uC_PanelMuen.Visible = false;

            for (int i = 0; i < uC_Navbar.iPanMenu.Items.Count; i++)
            {
                uC_Navbar.iPanMenu.Items[i].Enabled = true;
            }
        }

        private void uC_PanelMuen_AutoClick(object sender, EventArgs e)
        {
            if (isPanelMuenVisible)
            {
                dockSite9.BringToFront();
                isPanelMuenVisible = false;
                uC_PanelMuen.btnAutoHide.Symbol = "58132";
            }
            else
            {
                uC_PanelMuen.BringToFront();
                isPanelMuenVisible = true;
                uC_PanelMuen.btnAutoHide.Symbol = "58133";
            }
        }

        private void ItemGroup_Click(object sender, EventArgs e)
        {
            if (!SystemInfo.db.CheckOprtRole("DI_DI", "ItemGroup", true)) return;
            frmPubDevGroup frm = new frmPubDevGroup(TitleBar.Text, ItemGroup.Text);
            frm.ShowDialog();
        }

        private void ItemSelectGroup_Click(object sender, EventArgs e)
        {
            frmPubSelectDevGroup frm = new frmPubSelectDevGroup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string s1 = frm.GroupID;
                string s2 = frm.GroupName;
                ItemFindText.Tag = s1;
                ItemFindText.Text = s2;
                SelectGroup();
            }
        }

        private void Select_MacSN(string ID)
        {
            string DevGroupUpID = "";
            DataTableReader dr = null;
            int count = dataGrid.Rows.Count;
            dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "31", ID }));
            while (dr.Read())
            {
                DevGroupUpID = dr["DevGroupID"].ToString();
                for (int j = 0; j < count; j++)
                {
                    if (Equals(this.dataGrid.Rows[j].Cells[25].Value.ToString(), DevGroupUpID))
                    {
                        dataGrid.Rows[j].Cells[0].Value = 1;
                        continue;
                    }
                }
            }
        }

        private void SelectGroup()
        {
            string DevGroupUpID = "";
            string ID = ItemFindText.Tag.ToString();
            DataTableReader dr = null;
            try
            {
                if (string.IsNullOrEmpty(ItemFindText.Text)) return;
                RefreshDevice();
                int count = dataGrid.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (Equals(dataGrid.Rows[i].Cells[25].Value.ToString(), ID))
                    {
                        dataGrid.Rows[i].Cells[0].Value = 1;

                        continue;
                    }
                    dataGrid.Rows[i].Cells[0].Value = 0;

                }
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "31", ID }));
                while (dr.Read())
                {
                    DevGroupUpID = dr["DevGroupID"].ToString();
                    for (int j = 0; j < count; j++)
                    {
                        if (Equals(dataGrid.Rows[j].Cells[25].Value.ToString(), DevGroupUpID))
                        {
                            dataGrid.Rows[j].Cells[0].Value = 1;

                            Select_MacSN(DevGroupUpID);
                            continue;
                        }
                    }
                }
                for (int i = 0; i < count; i++)
                {
                    if (SystemInfo.DBType == 0)
                    {
                        if (dataGrid.Rows[i].Cells[0].Value.ToString() == "0")
                        {
                            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid.Rows[i].DataGridView.DataSource];
                            cm.SuspendBinding(); //挂起
                            dataGrid.Rows[i].ReadOnly = true;//继续，这行可选，如果你的DataGridView是编辑的就加上
                            dataGrid.Rows[i].Visible = false;
                            cm.ResumeBinding();//继续，这行必需有
                        }
                    }
                    else
                    {
                        if (!bool.Parse(dataGrid.Rows[i].Cells[0].Value.ToString()))
                        {
                            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid.Rows[i].DataGridView.DataSource];
                            cm.SuspendBinding();
                            dataGrid.Rows[i].ReadOnly = true;
                            dataGrid.Rows[i].Visible = false;
                            cm.ResumeBinding();
                        }
                    }

                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string hex = "";
            string str = "56789";
            try
            {
                hex = Convert.ToInt64(str, 16).ToString("0000000000");

                hex = HexToStr(str);
            }
            catch
            {

            }
        }
    }

    public class TDownSelectList
    {
        private string _empNo = "";
        private bool _isSuccess = false;
        private UInt32 _enrollNumber = 0;
        private string _enrollName = "";
        private int _privilege = 0;
        private int _enableFlag = 0;

        public string EmpNo
        {
            get { return _empNo; }
            set { _empNo = value; }
        }

        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }

        public UInt32 EnrollNumber
        {
            get { return _enrollNumber; }
            set { _enrollNumber = value; }
        }

        public string EnrollName
        {
            get { return _enrollName; }
            set { _enrollName = value; }
        }

        public int Privilege
        {
            get { return _privilege; }
            set { _privilege = value; }
        }

        public int EnableFlag
        {
            get { return _enableFlag; }
            set { _enableFlag = value; }
        }
    }

    public class TDownInfoList
    {
        private UInt32 _enrollNumber = 0;
        private bool _isReqName = false;

        public TDownInfoList(UInt32 EnrollNo, bool ReqName)
        {
            _enrollNumber = EnrollNo;
            _isReqName = ReqName;
        }

        public UInt32 EnrollNumber
        {
            get { return _enrollNumber; }
            set { _enrollNumber = value; }
        }

        public bool ReqName
        {
            get { return _isReqName; }
            set { _isReqName = value; }
        }
    }
    public class MJInfoList
    {
        private string _enrollNumber = "";
        private string _EmpName = "";
        private string _MacSN = "";

        public MJInfoList(string MacSN, string EnrollNo, string EmpName)
        {
            _MacSN = MacSN;
            _enrollNumber = EnrollNo;
            _EmpName = EmpName;
        }
        public string MacSN
        {
            get { return _MacSN; }
            set { _MacSN = value; }
        }

        public string EnrollNumber
        {
            get { return _enrollNumber; }
            set { _enrollNumber = value; }
        }

        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; }
        }
    }

    public class TDimInfo
    {
        private UInt32 _enrollNumber = 0;
        private int _bakNo = 0;

        public TDimInfo(UInt32 EnrollNo, int BakNo)
        {
            _enrollNumber = EnrollNo;
            _bakNo = BakNo;
        }

        public UInt32 EnrollNumber
        {
            get { return _enrollNumber; }
            set { _enrollNumber = value; }
        }

        public int BakNo
        {
            get { return _bakNo; }
            set { _bakNo = value; }
        }
    }
    public class Monitoring
    {
        private string _MacSN = "";
        private int _bakNo = 0;
        public Monitoring(string MacSN, int BakNo)
        {
            _MacSN = MacSN;
            _bakNo = BakNo;
        }
        public string MacSN
        {
            get { return _MacSN; }
            set { _MacSN = value; }
        }

        public int BakNo
        {
            get { return _bakNo; }
            set { _bakNo = value; }
        }
    }
}