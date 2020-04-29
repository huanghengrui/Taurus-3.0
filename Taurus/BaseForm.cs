using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using AxgrproLib;
using grproLib;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;
using TabControl = System.Windows.Forms.TabControl;
using System.Drawing.Drawing2D;
using DevComponents.DotNetBar.Controls;
using System.Net;

namespace Taurus
{
    public partial class frmBaseForm : Form
    {
        protected string formCode = "";
        protected Base Pub = new Base();
        protected bool IgnoreReportSet = false;
        protected bool IsToggleCheckStateAll = false;
        protected bool IsAllEmpInfo = false;
        protected bool IgnoreDimission = true;
 
        public frmBaseForm()
        {
            InitializeComponent();
        }
      
        private void frmBaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FreeForm();
        }

        private void frmBaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmBaseForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox txt = (TextBox)sender;
                txt.SelectionStart = 0;
                txt.SelectionLength = txt.Text.Length;
                txt.Select();
                txt.SelectAll();
            }
            else if (sender is MaskedTextBox)
            {
                MaskedTextBox mtxt = (MaskedTextBox)sender;
                mtxt.SelectionStart = 0;
                mtxt.SelectionLength = mtxt.Text.Length;
                mtxt.Select();
                mtxt.SelectAll();
            }
            else if (sender is NumericUpDown)
            {
                NumericUpDown num = (NumericUpDown)sender;
                num.Select(0, num.Value.ToString().Length);
            }
            else if (sender is RichTextBox)
            {
                RichTextBox rtxt = (RichTextBox)sender;
                rtxt.SelectionStart = 0;
                rtxt.SelectionLength = rtxt.Text.Length;
                rtxt.Select();
                rtxt.SelectAll();
            }
            else if (sender is ToolStripTextBox)
            {
                ToolStripTextBox ttxt = (ToolStripTextBox)sender;
                ttxt.SelectionStart = 0;
                ttxt.SelectionLength = ttxt.Text.Length;
                ttxt.Select();
                ttxt.SelectAll();
            }
        }

        private void ComboBox_OnDropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownListWidth((ComboBox)sender);
        }

        private void AdjustComboBoxDropDownListWidth(ComboBox cbb)
        {
            Graphics g = null;
            Font font = null;
            try
            {
                int width = cbb.Width;
                g = cbb.CreateGraphics();
                font = cbb.Font;
                int vertScrollBarWidth = (cbb.Items.Count > cbb.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;
                int newWidth;
                foreach (object s in cbb.Items)
                {
                    if (s != null)
                    {
                        newWidth = (int)g.MeasureString(s.ToString().Trim(), font).Width + vertScrollBarWidth;
                        if (width < newWidth) width = newWidth;
                    }
                }
                cbb.DropDownWidth = width;
            }
            catch
            {
            }
            finally
            {
                if (g != null) g.Dispose();
            }
        }

        protected void AddColumn(DataGridView grid, int colType, string Field, bool IsHide, bool HasSort,
          byte CenterFlag, int colWidth)
        {
            DataGridViewTextBoxColumn colText;
            DataGridViewCheckBoxColumn colCheck;
            DataGridViewComboBoxColumn colCombo;
            switch (colType)
            {
                case 0:
                    colText = new DataGridViewTextBoxColumn();
                    colText.DataPropertyName = Field;
                    colText.Visible = !IsHide;
                    if (!HasSort) colText.SortMode = DataGridViewColumnSortMode.NotSortable;
                    colText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (CenterFlag == 1)
                        colText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    else if (CenterFlag == 2)
                        colText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    if (colWidth > 0)
                        colText.Width = colWidth;
                    else
                        colText.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grid.Columns.Add(colText);
                    break;
                case 1:
                    colCheck = new DataGridViewCheckBoxColumn();
                    colCheck.DataPropertyName = Field;
                    colCheck.Visible = !IsHide;
                    colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (CenterFlag == 1)
                        colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    else if (CenterFlag == 2)
                        colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    if (colWidth > 0)
                        colCheck.Width = colWidth;
                    else
                        colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grid.Columns.Add(colCheck);
                    break;
                case 2:
                    colCombo = new DataGridViewComboBoxColumn();
                    colCombo.DataPropertyName = Field;
                    colCombo.Visible = !IsHide;
                    colCombo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (CenterFlag == 1)
                        colCombo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    else if (CenterFlag == 2)
                        colCombo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    if (colWidth > 0)
                        colCombo.Width = colWidth;
                    else
                        colCombo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    colCombo.DisplayStyleForCurrentCellOnly = true;
                    grid.Columns.Add(colCombo);
                    break;
                case 3:
                    colCheck = new DataGridViewCheckBoxColumn();
                    colCheck.DataPropertyName = Field;
                    colCheck.Visible = !IsHide;
                    colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    if (CenterFlag == 1)
                        colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    else if (CenterFlag == 2)
                        colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                   
                    if (colWidth > 0)
                        colCheck.Width = colWidth;

                    else
                        colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    
                    datagridviewCheckboxHeaderCell ch = new datagridviewCheckboxHeaderCell();
                    ch.OnCheckBoxClicked += new datagridviewCheckboxHeaderCell.HeaderEventHander(ch_OnCheckBoxClicked);
                    colCheck.HeaderCell = ch;
                    grid.Columns.Add(colCheck);
                    break;
            }
        }

        public delegate void datagridviewcheckboxHeaderEventHander(object sender, datagridviewCheckboxHeaderEventArgs e);

        public virtual void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {

        }


        protected void SetControlsText(Control obj)
        {
            MenuStrip menuBar;
            ContextMenuStrip ContextMenu;
            ToolStrip toolBar;
            ListView listView;
            DataGridView grid;
            DataGridViewX gridX;
            StatusStrip statusBar;
            ToolStripMenuItem MenuItem;
            TabControl tabC;
            SuperTabControl superTab;
            DevComponents.DotNetBar.TabControl tabD;
            GroupBox gbx;
            Label lab;
            LabelX labX;
            CheckBox chk;
            RadioButton rb;
            Button btn;
            ButtonX btnX;
            AxGRDisplayViewer grv;
            SplitContainer sc;
            TextBox txt;
            Bar bar;
            PanelDockContainer panelDock;
            for (int i = 0; i < obj.Controls.Count; i++)
            {
                if (obj.Controls[i].ContextMenuStrip != null)
                {
                    ContextMenu = (ContextMenuStrip)obj.Controls[i].ContextMenuStrip;
                    for (int j = 0; j < ContextMenu.Items.Count; j++)
                    {
                        ContextMenu.Items[j].Text = Pub.GetResText(formCode, ContextMenu.Items[j].Name, ContextMenu.Items[j].Text);
                    }
                }
                if (obj.Controls[i] is MenuStrip)
                {
                    menuBar = (MenuStrip)obj.Controls[i];
                    for (int j = 0; j < menuBar.Items.Count; j++)
                    {
                        MenuItem = (ToolStripMenuItem)menuBar.Items[j];
                        MenuItem.Text = Pub.GetResText(formCode, MenuItem.Name, MenuItem.Text);
                        for (int k = 0; k < MenuItem.DropDownItems.Count; k++)
                        {
                            MenuItem.DropDownItems[k].Text = Pub.GetResText(formCode, MenuItem.DropDownItems[k].Name, MenuItem.DropDownItems[k].Text);
                        }
                    }
                }
                else if (obj.Controls[i] is ToolStrip)
                {
                    toolBar = (ToolStrip)obj.Controls[i];
                    for (int j = 0; j < toolBar.Items.Count; j++)
                    {
                        if (toolBar.Items[j].Tag != null)
                            toolBar.Items[j].Text = Pub.GetResText(formCode, toolBar.Items[j].Tag.ToString(), toolBar.Items[j].Text);
                        else
                            toolBar.Items[j].Text = Pub.GetResText(formCode, toolBar.Items[j].Name, toolBar.Items[j].Text);
                        toolBar.Items[j].ToolTipText = toolBar.Items[j].Text;
                        if (toolBar.Items[j] is ToolStripTextBox)
                        {
                            toolBar.Items[j].Text = "";
                            ((ToolStripTextBox)toolBar.Items[j]).GotFocus += TextBox_GotFocus;
                        }
                    }
                }
                else if (obj.Controls[i] is ListView)
                {
                    listView = (ListView)obj.Controls[i];
                    for (int j = 0; j < listView.Columns.Count; j++)
                    {
                        if (listView.Columns[j].Tag != null)
                            listView.Columns[j].Text = Pub.GetResText(formCode, listView.Columns[j].Tag.ToString(), listView.Columns[j].Text);
                        else
                            listView.Columns[j].Text = Pub.GetResText(formCode, listView.Columns[j].Name, listView.Columns[j].Text);
                    }
                }
                else if (obj.Controls[i] is TreeView)
                {
                    ((TreeView)obj.Controls[i]).ItemHeight = 17;
                }
                else if (obj.Controls[i] is DataGridView)
                {
                    grid = (DataGridView)obj.Controls[i];
                    grid.DataError += DataGridView_DataError;
                    for (int j = 0; j < grid.ColumnCount; j++)
                    {
                        if (grid.Columns[j].DataPropertyName == "")
                            grid.Columns[j].HeaderText = Pub.GetResText(formCode, grid.Columns[j].Name, grid.Columns[j].HeaderText).Replace("|", " ");
                        else
                            grid.Columns[j].HeaderText = Pub.GetResText(formCode, grid.Columns[j].DataPropertyName, grid.Columns[j].HeaderText).Replace("|", " ");
                        if (j > 0) grid.Columns[j].ReadOnly = true;
                    }
                }
                else if (obj.Controls[i] is DataGridViewX)
                {
                    gridX = (DataGridViewX)obj.Controls[i];
                    gridX.DataError += DataGridView_DataError;
                    for (int j = 0; j < gridX.ColumnCount; j++)
                    {
                        if (gridX.Columns[j].DataPropertyName == "")
                            gridX.Columns[j].HeaderText = Pub.GetResText(formCode, gridX.Columns[j].Name, gridX.Columns[j].HeaderText).Replace("|", " ");
                        else
                            gridX.Columns[j].HeaderText = Pub.GetResText(formCode, gridX.Columns[j].DataPropertyName, gridX.Columns[j].HeaderText).Replace("|", " ");
                        if (j > 0) gridX.Columns[j].ReadOnly = true;
                    }
                }
                else if (obj.Controls[i] is StatusStrip)
                {
                    statusBar = (StatusStrip)obj.Controls[i];
                    for (int j = 0; j < statusBar.Items.Count; j++)
                    {
                        statusBar.Items[j].Text = Pub.GetResText(formCode, statusBar.Items[j].Name, statusBar.Items[j].Text);
                    }
                }
                else if (obj.Controls[i] is Panel)
                {
                    SetControlsText(obj.Controls[i]);
                }
             
                else if (obj.Controls[i] is PanelEx)
                {
                    SetControlsText(obj.Controls[i]);
                }

                else if (obj.Controls[i] is GroupBox)
                {
                    gbx = (GroupBox)obj.Controls[i];
                    gbx.Text = Pub.GetResText(formCode, gbx.Name, gbx.Text);
                    if ((gbx.Text == "") && (gbx.Tag != null))
                    {
                        gbx.Text = Pub.GetResText(formCode, gbx.Tag.ToString(), gbx.Text);
                    }
                    SetControlsText(gbx);
                }
                else if (obj.Controls[i] is TabControl)
                {
                    tabC = (TabControl)obj.Controls[i];
                    for (int j = 0; j < tabC.TabCount; j++)
                    {
                        tabC.TabPages[j].Text = Pub.GetResText(formCode, tabC.TabPages[j].Name, tabC.TabPages[j].Text);
                        if ((tabC.TabPages[j].Text == "") && (tabC.TabPages[j].Tag != null))
                        {
                            tabC.TabPages[j].Text = Pub.GetResText(formCode, tabC.TabPages[j].Tag.ToString(), tabC.TabPages[j].Text);
                        }
                        SetControlsText(tabC.TabPages[j]);
                    }
                }
                else if (obj.Controls[i] is SuperTabControl)
                {
                    superTab = (SuperTabControl)obj.Controls[i];
                    for (int j = 0; j < superTab.Tabs.Count; j++)
                    {
                        superTab.Tabs[j].Text = Pub.GetResText(formCode, superTab.Tabs[j].Name, superTab.Tabs[j].Text);
                        if ((superTab.Tabs[j].Text == "") && (superTab.Tabs[j].Tag != null))
                        {
                            superTab.Tabs[j].Text = Pub.GetResText(formCode, superTab.Tabs[j].Tag.ToString(), superTab.Tabs[j].Text);
                        }
                        SetControlsText(superTab);
                    }
                }
                else if (obj.Controls[i] is Bar)
                {
                    bar = (Bar)obj.Controls[i];
                    for (int j = 0; j < bar.Items.Count; j++)
                    {
                        bar.Items[j].Text = Pub.GetResText(formCode, bar.Items[j].Name, bar.Items[j].Text);
                        if ((bar.Items[j].Text == "") && (bar.Items[j].Tag != null))
                        {
                            bar.Items[j].Text = Pub.GetResText(formCode, bar.Items[j].Tag.ToString(), bar.Items[j].Text);
                        }
                        SetControlsText(bar);
                    }
                    SetControlsText(obj.Controls[i]);
                }
                else if (obj.Controls[i] is PanelDockContainer)
                {
                    panelDock = (PanelDockContainer)obj.Controls[i];
                    SetControlsText(obj.Controls[i]);
                }
                else if (obj.Controls[i] is DevComponents.DotNetBar.TabControl)
                {
                    tabD = (DevComponents.DotNetBar.TabControl)obj.Controls[i];
                    for (int j = 0; j < tabD.Tabs.Count; j++)
                    {
                        tabD.Tabs[j].Text = Pub.GetResText(formCode, tabD.Tabs[j].Name, tabD.Tabs[j].Text);
                        if ((tabD.Tabs[j].Text == "") && (tabD.Tabs[j].Tag != null))
                        {
                            tabD.Tabs[j].Text = Pub.GetResText(formCode, tabD.Tabs[j].Tag.ToString(), tabD.Tabs[j].Text);
                        }
                        SetControlsText(tabD);
                    }
                }
                else if (obj.Controls[i] is Label)
                {
                    lab = (Label)obj.Controls[i];
                    lab.BackColor = Color.Transparent;
                    lab.Text = Pub.GetResText(formCode, lab.Name, lab.Text);
                    if ((lab.Text == "") && (lab.Tag != null))
                    {
                        lab.Text = Pub.GetResText(formCode, lab.Tag.ToString(), lab.Text);
                    }
                    toolTip.SetToolTip(lab, lab.Text);
                }
                else if (obj.Controls[i] is LabelX)
                {
                    labX = (LabelX)obj.Controls[i];
                    labX.BackColor = Color.Transparent;
                    labX.Text = Pub.GetResText(formCode, labX.Name, labX.Text);
                    if ((labX.Text == "") && (labX.Tag != null))
                    {
                        labX.Text = Pub.GetResText(formCode, labX.Tag.ToString(), labX.Text);
                    }
                    toolTip.SetToolTip(labX, labX.Text);
                }
                else if (obj.Controls[i] is CheckBox)
                {
                    chk = (CheckBox)obj.Controls[i];
                    chk.BackColor = Color.Transparent;
                    chk.Text = Pub.GetResText(formCode, chk.Name, chk.Text);
                    if ((chk.Text == "") && (chk.Tag != null))
                    {
                        chk.Text = Pub.GetResText(formCode, chk.Tag.ToString(), chk.Text);
                    }
                    toolTip.SetToolTip(chk, chk.Text);
                }
                else if (obj.Controls[i] is RadioButton)
                {
                    rb = (RadioButton)obj.Controls[i];
                    rb.BackColor = Color.Transparent;
                    rb.Text = Pub.GetResText(formCode, rb.Name, rb.Text);
                    if ((rb.Text == "") && (rb.Tag != null))
                    {
                        rb.Text = Pub.GetResText(formCode, rb.Tag.ToString(), rb.Text);
                    }
                    toolTip.SetToolTip(rb, rb.Text);
                }
                else if (obj.Controls[i] is Button)
                {
                    btn = (Button)obj.Controls[i];
                    btn.Text = Pub.GetResText(formCode, btn.Name, btn.Text);
                    if ((btn.Text == "") && (btn.Tag != null))
                    {
                        btn.Text = Pub.GetResText(formCode, btn.Tag.ToString(), btn.Text);
                    }
                    toolTip.SetToolTip(btn, btn.Text);
                }
                else if (obj.Controls[i] is ButtonX)
                {
                    btnX = (ButtonX)obj.Controls[i];
                    btnX.Text = Pub.GetResText(formCode, btnX.Name, btnX.Text);
                    if ((btnX.Text == "") && (btnX.Tag != null))
                    {
                        btnX.Text = Pub.GetResText(formCode, btnX.Tag.ToString(), btnX.Text);
                    }
                    toolTip.SetToolTip(btnX, btnX.Text);
                }
          
                else if (obj.Controls[i] is TextBox)
                {
                    txt = (TextBox)obj.Controls[i];
                    if (txt.PasswordChar.ToString() == "\0") txt.ImeMode = ImeMode.On;
                }
                else if (obj.Controls[i] is AxGRDisplayViewer)
                {
                    grv = (AxGRDisplayViewer)obj.Controls[i];
                    if (grv.Report == null) continue;
                    SetReportCaption(grv);
                }
                else if (obj.Controls[i] is SplitContainer)
                {
                    sc = (SplitContainer)obj.Controls[i];
                    SetControlsText(sc.Panel1);
                    SetControlsText(sc.Panel2);
                }
                if ((obj.Controls[i] is TextBox) || (obj.Controls[i] is MaskedTextBox) ||
                  (obj.Controls[i] is NumericUpDown) || (obj.Controls[i] is RichTextBox))
                {
                    obj.Controls[i].GotFocus += TextBox_GotFocus;
                }
                if (obj.Controls[i] is ComboBox)
                {
                    ((ComboBox)obj.Controls[i]).DropDown += ComboBox_OnDropDown;
                    ((ComboBox)obj.Controls[i]).ImeMode = ImeMode.Disable;
                }
                if ((obj.Controls[i] is DataGridView) || (obj.Controls[i] is HeaderView) || (obj.Controls[i] is RowMergeView))
                {
                    grid = (DataGridView)obj.Controls[i];
                    grid.AutoGenerateColumns = false;
                    if (!(obj.Controls[i] is HeaderView))
                    {
                        grid.ColumnHeadersHeight = 20;
                    }
                    grid.RowTemplate.Height = 20;
                }
            }
        }

        protected void SetReportCaption(AxGRDisplayViewer grv)
        {
            if (IgnoreReportSet) return;
            if (grv.Report != null)
            {
                grv.Report.Font.Name = this.Font.Name;
                grv.Report.Font.Charset = this.Font.GdiCharSet;
                SetReportCaption(grv.Report);
            }
            grv.BorderStyle = GRViewerBorderStyle.grvbsFixed3D;
            grv.ShowFooter = true;
            grv.ShowHeader = true;
            grv.GridCenterView = true;
            grv.RowSelection = true;
            grv.Resortable = true;
            grv.ResortCaseSensitive = true;
            grv.ResortDefaultAsc = true;
            grv.ColumnMove = true;
            grv.ColumnResize = true;
            grv.Searchable = true;
            grv.SelectionBackColor = Color.Teal;
            grv.SelectionForeColor = Color.White;
            grv.SelectionFollowScroll = false;
        }

        protected void SetReportCaption(GridppReport rpt)
        {
            IGRColumnTitleCell supCell;
            if (IgnoreReportSet) return;
            string s = "";
            string s1 = "";
            string cap = "";
            rpt.Font.Name = this.Font.Name;
            rpt.Font.Charset = this.Font.GdiCharSet;
            if (rpt.DetailGrid != null)
            {
                rpt.DetailGrid.CenterView = true;
                rpt.DetailGrid.Font.Name = this.Font.Name;
                rpt.DetailGrid.Font.Charset = this.Font.GdiCharSet;
                rpt.DetailGrid.ColumnTitle.Font.Name = this.Font.Name;
                rpt.DetailGrid.ColumnTitle.Font.Charset = this.Font.GdiCharSet;
                for (int j = 1; j <= rpt.ReportHeaderCount; j++)
                {
                    for (int k = 1; k <= rpt.get_ReportHeader(j).Controls.Count; k++)
                    {
                        if (rpt.get_ReportHeader(j).Controls[k].Name == null) continue;
                        s = rpt.get_ReportHeader(j).Controls[k].Name;
                        if (s.ToLower().Trim() == "maintitlebox")
                            rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text = "";
                        else if (s.ToLower().Trim() == "staticboxdate")
                            rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text = "";
                        else if (rpt.get_ReportHeader(j).Controls[k] is IGRStaticBox)
                        {
                            s1 = rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Tag;
                            if (s1 != null && s1 != "")
                                s1 = Pub.GetResText(formCode, s1, rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text).Replace("|", " ") ;
                            else
                                s1 = Pub.GetResText(formCode, s, rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text).Replace("|", " ");
                            rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text = s1;
                        }
                    }
                }
                for (int j = 1; j <= rpt.DetailGrid.Groups.Count; j++)
                {
                    for (int k = 1; k <= rpt.DetailGrid.Groups[j].Header.Controls.Count; k++)
                    {
                        if (rpt.DetailGrid.Groups[j].Header.Controls[k].Name == null) continue;
                        if (rpt.DetailGrid.Groups[j].Header.Controls[k] is IGRStaticBox)
                        {
                            s = rpt.DetailGrid.Groups[j].Header.Controls[k].Name;
                            if (s.ToLower() == "commanyname")
                            {
                                s = SystemInfo.CommanyName;
                                rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Text = s;
                            }
                            else
                            {
                                s1 = rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Tag;
                                if (s1 != null && s1 != "")
                                    s1 = Pub.GetResText(formCode, s1, rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Text).Replace("|", " ");
                                else
                                    s1 = Pub.GetResText(formCode, s, rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Text).Replace("|", " ");
                                rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Text = s1;
                            }
                        }
                    }
                    for (int k = 1; k <= rpt.DetailGrid.Groups[j].Footer.Controls.Count; k++)
                    {
                        if (rpt.DetailGrid.Groups[j].Footer.Controls[k].Name == null) continue;
                        s = rpt.DetailGrid.Groups[j].Footer.Controls[k].Name;
                        if (s.ToLower().Trim() == "staticboxsum")
                        {
                            s = Pub.GetResText(formCode, "StaticBoxSum", "");
                            rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text = s;
                        }
                        else if (s.ToLower().Trim() == "staticboxsummin")
                        {
                            s = Pub.GetResText(formCode, "StaticBoxSumMin", "");
                            rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text = s;
                        }
                        else if (rpt.DetailGrid.Groups[j].Footer.Controls[k] is IGRStaticBox)
                        {
                            s1 = rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Tag;
                            if (s1 != null && s1 != "")
                                s1 = Pub.GetResText(formCode, s1, rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text).Replace("|", " ");
                            else
                                s1 = Pub.GetResText(formCode, s, rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text).Replace("|", " ");
                            rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text = s1;
                        }
                    }
                }
                for (int j = 1; j <= rpt.ReportFooterCount; j++)
                {
                    for (int k = 1; k <= rpt.get_ReportFooter(j).Controls.Count; k++)
                    {
                        if (rpt.get_ReportFooter(j).Controls[k].Name == null) continue;
                        s = rpt.get_ReportFooter(j).Controls[k].Name;
                        if (s.ToLower().Trim() == "staticboxsum")
                        {
                            s = Pub.GetResText(formCode, "StaticBoxSum", "");
                            rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text = s;
                        }
                        else if (s.ToLower().Trim() == "staticboxsummin")
                        {
                            s = Pub.GetResText(formCode, "StaticBoxSumMin", "");
                            rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text = s;
                        }
                        else if (rpt.get_ReportFooter(j).Controls[k] is IGRStaticBox)
                        {
                            s1 = rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Tag;
                            if (s1 != null && s1 != "")
                                s1 = Pub.GetResText(formCode, s1, rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text).Replace("|", " ");
                            else
                                s1 = Pub.GetResText(formCode, s, rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text).Replace("|", " ");
                            rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text = s1;
                        }
                    }
                }
                for (int j = 1; j <= rpt.DetailGrid.Columns.Count; j++)
                {
                    try
                    {
                        rpt.DetailGrid.Columns[j].TitleCell.Font.Name = this.Font.Name;
                        rpt.DetailGrid.Columns[j].TitleCell.Font.Charset = this.Font.GdiCharSet;
                        rpt.DetailGrid.Columns[j].ContentCell.Font.Name = this.Font.Name;
                        rpt.DetailGrid.Columns[j].ContentCell.Font.Charset = this.Font.GdiCharSet;
                        supCell = rpt.DetailGrid.Columns[j].TitleCell.SupCell;
                        while (supCell != null)
                        {
                            s = supCell.Name;
                            s = Pub.GetResText(formCode, s, supCell.Text);
                            supCell.Text = s;
                            supCell = supCell.SupCell;
                        }
                        if (rpt.DetailGrid.Columns[j].Name.ToLower().Trim() == "checkbox")
                            cap = Pub.GetResText(formCode, "SelectCheck", "").Replace("|", " ");
                        else
                        {
                            s = rpt.DetailGrid.Columns[j].Name;
                            cap = Pub.GetResText(formCode, s, rpt.DetailGrid.Columns[j].TitleCell.Text).Replace("|", " ");
                            if ((cap == "") && (rpt.DetailGrid.Columns[j].TitleCell.Tag != null))
                            {
                                s = rpt.DetailGrid.Columns[j].TitleCell.Tag;
                                cap = Pub.GetResText(formCode, s, rpt.DetailGrid.Columns[j].TitleCell.Text).Replace("|", " ");
                            }
                            if ((cap == "") && !rpt.DetailGrid.Columns[j].ContentCell.FreeCell)
                            {
                                s = rpt.DetailGrid.Columns[j].ContentCell.DataField;
                                cap = Pub.GetResText(formCode, s, rpt.DetailGrid.Columns[j].TitleCell.Text).Replace("|", " ");
                            }
                        }
                        for (int k = 1; k <= rpt.DetailGrid.Columns[j].TitleCell.Controls.Count; k++)
                        {
                            if (rpt.DetailGrid.Columns[j].TitleCell.Controls[k] is IGRStaticBox)
                            {
                                if (rpt.DetailGrid.Columns[j].TitleCell.Controls[k].Name != null)
                                {
                                    s = rpt.DetailGrid.Columns[j].TitleCell.Controls[k].Name;
                                    s = Pub.GetResText(formCode, s, rpt.DetailGrid.Columns[j].TitleCell.Controls[k].AsStaticBox.Text).Replace("|", " ");
                                    rpt.DetailGrid.Columns[j].TitleCell.Controls[k].AsStaticBox.Text = s;
                                }
                            }
                        }
                        rpt.DetailGrid.Columns[j].TitleCell.Text = cap;
                    }
                    catch
                    {
                    }
                }
            }
        }

        protected void SetReportTitle(AxGRDisplayViewer grv, string Title)
        {
            if (grv.Report == null) return;
            string reportTitle = SystemInfo.CommanyName;
            bool hasCommanyBox = false;
            if (grv.Report.PageHeader != null)
            {
                for (int j = 1; j <= grv.Report.PageHeader.Controls.Count; j++)
                {
                    if (grv.Report.PageHeader.Controls[j].Name == null) continue;
                    if (grv.Report.PageHeader.Controls[j].Name.ToLower() == "staticboxcommany")
                    {
                        hasCommanyBox = true;
                        grv.Report.PageHeader.Controls[j].AsStaticBox.Text = reportTitle;
                        break;
                    }
                }
            }
            if (!hasCommanyBox)
            {
                for (int j = 1; j <= grv.Report.ReportHeaderCount; j++)
                {
                    for (int k = 1; k <= grv.Report.get_ReportHeader(j).Controls.Count; k++)
                    {
                        if (grv.Report.get_ReportHeader(j).Controls[k].Name == null) continue;
                        if (grv.Report.get_ReportHeader(j).Controls[k].Name.ToLower().Trim() == "staticboxcommany")
                        {
                            grv.Report.get_ReportHeader(j).Controls[k].AsStaticBox.Text = reportTitle;
                            hasCommanyBox = true;
                            break;
                        }
                    }
                    if (hasCommanyBox) break;
                }
            }
            if (!hasCommanyBox) Title = reportTitle + Title;
            for (int j = 1; j <= grv.Report.ReportHeaderCount; j++)
            {
                for (int k = 1; k <= grv.Report.get_ReportHeader(j).Controls.Count; k++)
                {
                    if (grv.Report.get_ReportHeader(j).Controls[k].Name == null) continue;
                    if (grv.Report.get_ReportHeader(j).Controls[k].Name.ToLower().Trim() == "maintitlebox")
                    {
                        grv.Report.get_ReportHeader(j).Controls[k].AsStaticBox.Text = Title;
                        return;
                    }
                }
            }
        }

        protected void SetReportDate(AxGRDisplayViewer grv, string date)
        {
            if (grv.Report == null) return;
            for (int j = 1; j <= grv.Report.ReportHeaderCount; j++)
            {
                for (int k = 1; k <= grv.Report.get_ReportHeader(j).Controls.Count; k++)
                {
                    if (grv.Report.get_ReportHeader(j).Controls[k].Name == null) continue;
                    if (grv.Report.get_ReportHeader(j).Controls[k].Name.ToLower().Trim() == "staticboxdate")
                    {
                        grv.Report.get_ReportHeader(j).Controls[k].AsStaticBox.Text = date;
                        grv.Report.get_ReportHeader(j).Controls[k].AsStaticBox.Dock = GRDockStyle.grdsBottom;
                        return;
                    }
                }
            }
        }

        private string GetFileName(string FileName)
        {
            FileName = FileName.Replace("/","\\");
            string ret = "";
            string[] tmp = FileName.Split('\\');
            ret = tmp[tmp.Length - 1];
            tmp = ret.Split('.');
            ret = tmp[0];
            return ret;
        }

        protected virtual void InitForm()
        {
            try
            {
                if (!SystemInfo.isInit)
                {
                    SystemInfo.isInit = true;
                    SystemInfo.AppPath = Pub.GetFileNamePath(Application.ExecutablePath);
                    SystemInfo.NameSpace = GetFileName(Application.ExecutablePath);
                    SystemInfo.AccessDB = SystemInfo.AppPath + SystemInfo.NameSpace + ".mdb";
                    SystemInfo.ReportPath = SystemInfo.AppPath + "Report\\";
                    SystemInfo.DataFilePath = SystemInfo.AppPath + "DataFile\\";
                    SystemInfo.System32Path = Environment.SystemDirectory;
                    if (SystemInfo.System32Path.Substring(SystemInfo.System32Path.Length - 1) != "\\")
                    {
                        SystemInfo.System32Path = SystemInfo.System32Path + "\\";
                    }
                    string IniFileName = SystemInfo.AppPath + SystemInfo.NameSpace + ".ini";
                    if (SystemInfo.ini == null)
                    {
                        SystemInfo.ini = new IniFile(IniFileName);
                        string tmpLang = SystemInfo.ini.ReadIni("Public", "Lang", "");
                        if (SystemInfo.langList.IndexOf(tmpLang) >= 0)
                        {
                            SystemInfo.LangName = tmpLang;
                            switch (SystemInfo.LangName)
                            {
                                case "CHS"://简体中文
                                    SystemInfo.AppTitle = SystemInfo.AppTitleLNG[0];
                                    break;
                                case "CHT"://繁体中文
                                    SystemInfo.AppTitle = SystemInfo.AppTitleLNG[1];
                                    break;
                                default:
                                    SystemInfo.AppTitle = SystemInfo.AppTitleLNG[SystemInfo.AppTitleLNG.Length - 1];
                                    break;
                            }
                        }
                    }
                    if (SystemInfo.res == null) SystemInfo.res = new LangRes(SystemInfo.AppPath);
                    if (SystemInfo.webIni == null) SystemInfo.webIni = new IniFile(SystemInfo.AppPath + "www\\menu.ini");
                    SystemInfo.ComputerName = Pub.GetComputerName();
                    SystemInfo.DBType = SystemInfo.ini.ReadIni("Public", "DBType", 0);
                    SystemInfo.ShowMJ = SystemInfo.ini.ReadIni("Public", "ShowMJ", 1);
                    SystemInfo.ShowKQ = SystemInfo.ini.ReadIni("Public", "ShowKQ", 1);
                    SystemInfo.ShowGZ = SystemInfo.ini.ReadIni("Public", "ShowGZ", 1);
                    SystemInfo.ShowSEA = SystemInfo.ini.ReadIni("Public", "ShowSEA", 1);
                    SystemInfo.ShowSTAR = SystemInfo.ini.ReadIni("Public", "ShowSTAR", 1);
                    SystemInfo.FingerPrivilegeGeneralUser = Pub.GetResText(formCode, "FingerPrivilege0", "");
                    SystemInfo.FingerPrivilegeManager = Pub.GetResText(formCode, "FingerPrivilege1", "");
                    SystemInfo.EmpSexMale = Pub.GetResText(formCode, "EmpSex0", "");
                    SystemInfo.EmpSexFemale = Pub.GetResText(formCode, "EmpSex1", "");
                    SystemInfo.CurrencySymbol = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                    SystemInfo.DateTimeFormat = Pub.GetResText("Public", "DateTimeFormat", "yyyy-MM-dd HH:mm:ss");
                    SystemInfo.DateTimeFormatLog = Pub.GetResText("Public", "DateTimeFormatLog", "yyyyMMddHHmmss");
                    SystemInfo.DateFormatLog = Pub.GetResText("Public", "DateFormatLog", "yyyyMMdd");
                    SystemInfo.YMFormat = Pub.GetResText("Public", "YMFormat", "yyyy-MM");
                    SystemInfo.YMFormatDB = Pub.GetResText("Public", "YMFormatDB", "yyyyMM");
                    SystemInfo.YMFormatForm = Pub.GetResText("Public", "YMFormatForm", "yyyy-MM");
                    SystemInfo.YMWFormatForm = Pub.GetResText("Public", "YMWFormatForm", "yyyy-MM-dd");
                    

                    if (SystemInfo.DateTimeFormat == "") SystemInfo.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    if (SystemInfo.DateTimeFormatLog == "") SystemInfo.DateTimeFormatLog = "yyyyMMddHHmmss";
                    if (SystemInfo.DateFormatLog == "") SystemInfo.DateFormatLog = "yyyyMMdd";
                    if (SystemInfo.YMFormat == "") SystemInfo.YMFormat = "yyyy-MM";
                    if (SystemInfo.YMFormatDB == "") SystemInfo.YMFormatDB = "yyyyMM";
                    if (SystemInfo.YMFormatForm == "") SystemInfo.YMFormatForm = "yyyy-MM";
                    if (SystemInfo.YMWFormatForm == "") SystemInfo.YMWFormatForm = "yyyy-MM-dd";
                    if (SystemInfo.db == null) SystemInfo.db = new Database("");
                }
                this.Text = Pub.GetResText(formCode, "Caption", this.Text);
               // Pub.SetFormAppIcon(this);
                SetControlsText(this);
            }
            catch (Exception E)
            {
                if (SystemInfo.ConnStr != "") Pub.ShowErrorMsg(E);
            }
        }

        protected virtual void FreeForm()
        {

        }

        protected string GetConnStr()
        {
            switch (SystemInfo.DBType)
            {
                case 1:
                    DBServerInfo.ServerName = SystemInfo.ini.ReadIni("MSSQL", "Server", "");
                    DBServerInfo.WindowsNT = SystemInfo.ini.ReadIni("MSSQL", "WindowsNT", true);
                    DBServerInfo.UserName = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserName", ""), SystemInfo.Encry);
                    DBServerInfo.UserPass = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserPass", ""), SystemInfo.Encry);
                    break;
                case 2:
                    DBServerInfo.ServerName = SystemInfo.ini.ReadIni("MSDE", "Server", "(local)\\MSDE");
                    DBServerInfo.WindowsNT = SystemInfo.ini.ReadIni("MSDE", "WindowsNT", false);
                    DBServerInfo.UserName = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSDE", "UserName", ""), SystemInfo.Encry);
                    DBServerInfo.UserPass = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSDE", "UserPass", ""), SystemInfo.Encry);
                    if (DBServerInfo.UserName == "") DBServerInfo.UserName = "sa";
                    if (DBServerInfo.UserPass == "") DBServerInfo.UserPass = "1234";
                    break;
            }
            return GetConnStr(SystemInfo.DBType, DBServerInfo.ServerName, DBServerInfo.WindowsNT, DBServerInfo.UserName,
              DBServerInfo.UserPass);
        }

        protected string GetConnStr(int DBType, string ServerName, bool WindowsNT, string UserName, string UserPass)
        {
            string ret = "";
            switch (DBType)
            {
                case 0:
                    ret = Pub.GetACCESSConnStr();
                    break;
                case 1:
                case 2:
                    ret = Pub.GetMSSQLConnStr(ServerName, WindowsNT, UserName, UserPass, SystemInfo.NameSpace);
                    break;
            }
            return ret;
        }

        protected string GetConnStrReport()
        {
            switch (SystemInfo.DBType)
            {
                case 1:
                    DBServerInfo.ServerName = SystemInfo.ini.ReadIni("MSSQL", "Server", "");
                    DBServerInfo.WindowsNT = SystemInfo.ini.ReadIni("MSSQL", "WindowsNT", true);
                    DBServerInfo.UserName = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserName", ""), SystemInfo.Encry);
                    DBServerInfo.UserPass = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserPass", ""), SystemInfo.Encry);
                    break;
                case 2:
                    DBServerInfo.ServerName = SystemInfo.ini.ReadIni("MSDE", "Server", "(local)\\MSDE");
                    DBServerInfo.WindowsNT = SystemInfo.ini.ReadIni("MSDE", "WindowsNT", false);
                    DBServerInfo.UserName = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSDE", "UserName", ""), SystemInfo.Encry);
                    DBServerInfo.UserPass = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSDE", "UserPass", ""), SystemInfo.Encry);
                    if (DBServerInfo.UserName == "") DBServerInfo.UserName = "sa";
                    if (DBServerInfo.UserPass == "") DBServerInfo.UserPass = "1234";
                    break;
            }
            return GetConnStrReport(SystemInfo.DBType, DBServerInfo.ServerName, DBServerInfo.WindowsNT,
              DBServerInfo.UserName, DBServerInfo.UserPass);
        }

        protected string GetConnStrReport(int DBType, string ServerName, bool WindowsNT, string UserName, string UserPass)
        {
            string ret = "";
            switch (DBType)
            {
                case 0:
                    ret = Pub.GetACCESSConnStrReport();
                    break;
                case 1:
                case 2:
                    ret = Pub.GetMSSQLConnStrReport(ServerName, WindowsNT, UserName, UserPass);
                    break;
            }
            return ret;
        }

        protected void TextBoxCurrency_Enter(object sender, EventArgs e)
        {
            bool IsText = (sender is TextBox);
            string v = "";
            if (IsText)
            {
                v = ((TextBox)sender).Text;
                ((TextBox)sender).ImeMode = ImeMode.Disable;
            }
            else
                v = ((ToolStripTextBox)sender).Text;
            if (v == "") v = SystemInfo.CurrencySymbol + "0.00";
            if (v.Substring(0, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol)
            {
                v = v.Substring(SystemInfo.CurrencySymbol.Length);
            }
            double d = Convert.ToDouble(v);
            if (IsText)
            {
                ((TextBox)sender).Text = d.ToString("0.00");
                ((TextBox)sender).SelectAll();
            }
            else
            {
                ((ToolStripTextBox)sender).Text = d.ToString("0.00");
                ((ToolStripTextBox)sender).SelectAll();
            }
        }

        protected void TextBoxCurrency_Leave(object sender, EventArgs e)
        {
            bool IsText = (sender is TextBox);
            string v = "";
            if (IsText)
                v = ((TextBox)sender).Text;
            else
                v = ((ToolStripTextBox)sender).Text;
            if (v == "") v = SystemInfo.CurrencySymbol + "0.00";
            if (IsText)
                ((TextBox)sender).Text = CurrencyToString(v);
            else
                ((ToolStripTextBox)sender).Text = CurrencyToString(v);
        }

        protected string CurrencyToString(string src)
        {
            string ret = src;
            if (src.Length > SystemInfo.CurrencySymbol.Length)
            {
                if (ret.Substring(0, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol)
                {
                    ret = ret.Substring(SystemInfo.CurrencySymbol.Length);
                }
                if (!Pub.IsNumeric(ret)) ret = "0.00";
            }
            else if (Pub.IsNumeric(src))
                ret = src;
            else
                ret = "0.00";
            ret = Convert.ToDecimal(ret).ToString(SystemInfo.CurrencySymbol + "0.00");
            return ret;
        }

        protected string CurrencyToStringEx(string src)
        {
            string ret = src;
            if (src.Length > SystemInfo.CurrencySymbol.Length)
            {
                if (ret.Substring(0, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol)
                {
                    ret = ret.Substring(SystemInfo.CurrencySymbol.Length);
                }
                if (!Pub.IsNumeric(ret)) ret = "0.00";
            }
            else if (Pub.IsNumeric(src))
                ret = src;
            else
                ret = "0.00";
            return ret;
        }
        public string StrToHex(string str)
        {
            string hex = "";
            try
            {
                long hexInt = Convert.ToInt64(str, 10);
                int index = str.Length - hexInt.ToString().Length;

                switch (index)
                {
                    case 0:
                        hex = hexInt.ToString("X");
                        break;
                    case 1:
                        hex = "0" + hexInt.ToString("X");
                        break;
                    case 2:
                        hex = "00" + hexInt.ToString("X");
                        break;
                    case 3:
                        hex = "000" + hexInt.ToString("X");
                        break;
                    case 4:
                        hex = "0000" + hexInt.ToString("X");
                        break;
                    case 5:
                        hex = "00000" + hexInt.ToString("X");
                        break;
                    case 6:
                        hex = "000000" + hexInt.ToString("X");
                        break;
                    case 7:
                        hex = "0000000" + hexInt.ToString("X");
                        break;
                    case 8:
                        hex = "00000000" + hexInt.ToString("X");
                        break;
                    case 9:
                        hex = "000000000" + hexInt.ToString("X");
                        break;
                    case 10:
                        hex = "0000000000" + hexInt.ToString("X");
                        break;
                    default:
                        hex = hexInt.ToString();
                        break;
                }


            }
            catch
            {

            }
            return hex;
        }

        public string HexToStr(string str)
        {
            string hex = "";
            try
            {
                long hexInt = Convert.ToInt64(str, 16);
                int index = str.Length - hexInt.ToString("X").Length;

                switch (index)
                {
                    case 0:
                        hex = hexInt.ToString();
                        break;
                    case 1:
                        hex = "0" + hexInt.ToString();
                        break;
                    case 2:
                        hex = "00" + hexInt.ToString();
                        break;
                    case 3:
                        hex = "000" + hexInt.ToString();
                        break;
                    case 4:
                        hex = "0000" + hexInt.ToString();
                        break;
                    case 5:
                        hex = "00000" + hexInt.ToString();
                        break;
                    case 6:
                        hex = "000000" + hexInt.ToString();
                        break;
                    case 7:
                        hex = "0000000" + hexInt.ToString();
                        break;
                    case 8:
                        hex = "00000000" + hexInt.ToString();
                        break;
                    case 9:
                        hex = "000000000" + hexInt.ToString();
                        break;
                    case 10:
                        hex = "0000000000" + hexInt.ToString();
                        break;
                    default:
                        hex = hexInt.ToString();
                        break;

                }


            }
            catch
            {

            }
            return hex;
        }

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
        private const int GWL_STYLE = (-16);
        private const int ES_NUMBER = 0x2000;
        protected void SetTextboxNumber(TextBox txtBox)
        {
            int CurrentStyle = GetWindowLong(txtBox.Handle, GWL_STYLE);
            CurrentStyle = CurrentStyle | ES_NUMBER;
            SetWindowLong(txtBox.Handle, GWL_STYLE, CurrentStyle);
            txtBox.ImeMode = ImeMode.Disable;
        }

        protected void SetcomboboxNumber(ComboBox txtBox)
        {
            int CurrentStyle = GetWindowLong(txtBox.Handle, GWL_STYLE);
            CurrentStyle = CurrentStyle | ES_NUMBER;
            SetWindowLong(txtBox.Handle, GWL_STYLE, CurrentStyle);
            txtBox.ImeMode = ImeMode.Disable;
        }

        protected void ShowErrorEnterCorrect(string text)
        {
            string errEnter = Pub.GetResText(formCode, "ErrorEnterCorrect", "");
            Pub.MessageBoxShow(string.Format(errEnter, text));
        }

        protected void ShowErrorSelectCorrect(string text)
        {
            string errSelect = Pub.GetResText(formCode, "ErrorSelectCorrect", "");
            Pub.MessageBoxShow(string.Format(errSelect, text));
        }

        protected void ShowErrorCannotRepeated(string text)
        {
            string errRepeated = Pub.GetResText(formCode, "ErrorCannotRepeated", "");
            Pub.MessageBoxShow(string.Format(errRepeated, text));
        }

        protected void InitDepartTreeView(TreeView tv)
        {
            InitDepartTreeView(tv, false);
        }

        protected void InitDepartTreeView(TreeView tv, bool InitEmp)
        {
            InitDepartTreeView(tv, InitEmp, "");
        }

        protected void InitDepartTreeView(TreeView tv, bool InitEmp, string otherCoin)
        {
            tv.BeginUpdate();
            if (tv.StateImageList == null)
            {
                if (tv.GetType().GetEvent("AfterCheck") == null)
                {
                    tv.AfterCheck += TreeViewAfterCheck;
                    tv.CheckBoxes = true;
                }
            }
            else
            {
                tv.KeyUp += TreeViewKeyUp;
                tv.NodeMouseClick += TreeViewNodeMouseClick;
            }
            tv.Nodes.Clear();
            DataTableReader dr = null;
            TreeNode node;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "4" }));
                while (dr.Read())
                {
                    node = tv.Nodes.Add("[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString());
                    node.Tag = dr["DepartID"].ToString();
                    if (tv.StateImageList != null) node.StateImageIndex = 0;
                    if (InitEmp) AddSubDepartEmp(tv, node, otherCoin);
                    AddSubDepart(tv, node, InitEmp, otherCoin);
                }
            }
            catch (Exception E)
            {
                if (SystemInfo.ConnStr != "") Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (tv.Nodes.Count > 0) tv.SelectedNode = tv.Nodes[0];
            tv.EndUpdate();
        }

        private void AddSubDepart(TreeView tv, TreeNode node, bool InitEmp, string otherCoin)
        {
            DataTableReader dr = null;
            TreeNode nod;
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "11", node.Tag.ToString() }));
                while (dr.Read())
                {
                    nod = node.Nodes.Add("[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString());
                    nod.Tag = dr["DepartID"].ToString();
                    if (tv.StateImageList != null) nod.StateImageIndex = 0;
                    if (InitEmp) AddSubDepartEmp(tv, nod, otherCoin);
                    AddSubDepart(tv, nod, InitEmp, otherCoin);
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
            node.Expand();
        }

        private void AddSubDepartEmp(TreeView tv, TreeNode node, string otherCoin)
        {
            DataTableReader dr = null;
            TreeNode nod;
            string s = "";
            string CardNo = "";
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000100, new string[] { "7",
          node.Tag.ToString(), otherCoin }));
                while (dr.Read())
                {
                    s = "  " + dr["FingerNo"].ToString();
                    CardNo = dr["CardNo10"].ToString();
                    if (CardNo != "") s = s + "[" + CardNo + "]";
                    s = "[" + dr["EmpNo"].ToString() + "]" + dr["EmpName"].ToString() + s;
                    nod = node.Nodes.Add(s);
                    nod.Tag = dr["EmpNo"].ToString();
                    nod.ImageIndex = 1;
                    nod.SelectedImageIndex = 1;
                    if (tv.StateImageList != null) nod.StateImageIndex = 0;
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
            node.Expand();
        }

        protected void SelectTreeNode(TreeNode node)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Checked = node.Checked;
                SelectTreeNode(node.Nodes[i]);
            }
        }
        protected void InitMacSNTreeView(TreeView tv, bool InitMacSN, string otherCoin)
        {
            tv.BeginUpdate();
            if (tv.StateImageList == null)
            {
                if (tv.GetType().GetEvent("AfterCheck") == null)
                {
                    tv.AfterCheck += TreeViewAfterCheck;
                    tv.CheckBoxes = true;
                }
            }
            else
            {
                tv.KeyUp += TreeViewKeyUp;
                tv.NodeMouseClick += TreeViewNodeMouseClick;
            }
            tv.Nodes.Clear();
            DataTableReader dr = null;
            TreeNode node;
            try
            {

                node = tv.Nodes.Add("[" + Pub.GetResText(formCode, "MacSN", "") + "]" + " " + Pub.GetResText(formCode, "MacDesc", ""));
                node.Tag = Pub.GetResText(formCode, "MacSN", "");
                if (tv.StateImageList != null) node.StateImageIndex = 0;
                if (InitMacSN) AddSubMacSN(tv, node, otherCoin);

            }
            catch (Exception E)
            {
                if (SystemInfo.ConnStr != "") Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (tv.Nodes.Count > 0) tv.SelectedNode = tv.Nodes[0];
            tv.EndUpdate();
        }

        private void AddSubMacSN(TreeView tv, TreeNode node, string otherCoin)
        {
            DataTableReader dr = null;
            TreeNode nod;
            string s = "";

            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "603" }));
                while (dr.Read())
                {
                    s = "[" + dr["MacSN"].ToString() + "]    " + dr["MacDesc"].ToString();
                    nod = node.Nodes.Add(s);
                    nod.Tag = dr["MacSN"].ToString();
                    nod.ImageIndex = 1;
                    nod.SelectedImageIndex = 1;
                    if (tv.StateImageList != null) nod.StateImageIndex = 0;
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
            node.Expand();
        }

        protected void InitDevGroupTreeView(TreeView tv, bool InitEmp, string otherCoin)
        {

            tv.BeginUpdate();
            if (tv.StateImageList == null)
            {
                if (tv.GetType().GetEvent("AfterCheck") == null)
                {
                    tv.AfterCheck += TreeViewAfterCheck;
                    tv.CheckBoxes = true;
                }
            }
            else
            {
                tv.KeyUp += TreeViewKeyUp;
                tv.NodeMouseClick += TreeViewNodeMouseClick;
            }
            tv.Nodes.Clear();
            DataTableReader dr = null;
            TreeNode node;
            // string DevGroup = "";
            //Departnext = "";
            try
            {

                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "32" }));
                while (dr.Read())
                {
                    node = tv.Nodes.Add("[" + dr["DevGroupID"].ToString() + "]" + dr["DevGroupName"].ToString());
                    node.Tag = dr["DevGroupID"].ToString();
                    if (tv.StateImageList != null) node.StateImageIndex = 0;
                    //if (InitEmp) AddSubDepartEmp(tv, node, otherCoin);
                    AddSubDevGroup(tv, node, InitEmp, otherCoin);
                }
            }
            catch (Exception E)
            {
                if (SystemInfo.ConnStr != "") Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (tv.Nodes.Count > 0) tv.SelectedNode = tv.Nodes[0];
            tv.EndUpdate();
        }

        private void AddSubDevGroup(TreeView tv, TreeNode node, bool InitEmp, string otherCoin)
        {
            DataTableReader dr = null;
            TreeNode nod;

            try
            {

                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "31", node.Tag.ToString() }));
                while (dr.Read())
                {
                    nod = node.Nodes.Add("[" + dr["DevGroupID"].ToString() + "]" + dr["DevGroupName"].ToString());
                    nod.Tag = dr["DevGroupID"].ToString();
                    if (tv.StateImageList != null) nod.StateImageIndex = 0;
                    // if (InitEmp) AddSubDepartEmp(tv, nod, otherCoin);
                    AddSubDevGroup(tv, nod, false, "");
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
            node.Expand();
        }

        private void ToggleCheckStateChildren(TreeNode node)
        {
            TreeNode nod;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                nod = node.Nodes[i];
                nod.StateImageIndex = node.StateImageIndex;
                if (nod.Nodes.Count > 0) ToggleCheckStateChildren(nod);
            }
        }

        private void ToggleCheckStateParent(TreeNode node)
        {
            int SelecCount = 0;
            int SelectCount2 = 0;
            TreeNode nod = node.Parent;
            if (nod == null) return;
            for (int i = 0; i < nod.Nodes.Count; i++)
            {
                if (nod.Nodes[i].StateImageIndex == 1) SelecCount++;
                if (nod.Nodes[i].StateImageIndex == 2) SelectCount2++;
            }
            if (nod.Nodes.Count == SelecCount)
                nod.StateImageIndex = 1;
            else if (SelectCount2 != 0)
                nod.StateImageIndex = 2;
            else if (SelecCount == 0)
                nod.StateImageIndex = 0;
            else
                nod.StateImageIndex = 2;
            ToggleCheckStateParent(nod);
        }

        protected virtual void ToggleCheckStateAll(TreeNode node)
        {
            ToggleCheckStateChildren(node);
            ToggleCheckStateParent(node);
        }

        protected void ToggleCheckState(TreeNode node)
        {
            if (node.StateImageIndex == 1)
                node.StateImageIndex = 0;
            else
                node.StateImageIndex = 1;
            if (IsToggleCheckStateAll) ToggleCheckStateAll(node);
        }

        protected void TreeViewAfterCheck(object sender, TreeViewEventArgs e)
        {
            SelectTreeNode(e.Node);
        }

        protected void TreeViewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && sender is TreeView)
            {
                TreeNode node = ((TreeView)sender).SelectedNode;
                if (node != null) ToggleCheckState(node);
            }
        }

        protected void TreeViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && sender is TreeView)
            {
                Rectangle rect = new Rectangle(e.Node.Bounds.X, e.Node.Bounds.Y, e.Node.Bounds.Width, e.Node.Bounds.Height);
                if (e.X <= rect.X && e.X > rect.X - 15)
                {
                    ToggleCheckState(e.Node);
                }
            }
        }

        protected void CreateCardGridView(DataGridView grid)
        {
            grid.Columns.Clear();
            AddColumn(grid, 0, "FingerNo", false, true, 1, 80);
            AddColumn(grid, 0, "CardNo10", true, true, 1, 80);
            AddColumn(grid, 0, "CardNo81", true, true, 1, 80);
            AddColumn(grid, 0, "CardNo82", true, true, 1, 80);
            AddColumn(grid, 0, "EmpNo", false, true, 0, 70);
            AddColumn(grid, 0, "EmpName", false, true, 0, 80);
            AddColumn(grid, 0, "DepartID", false, true, 1, 0);
            AddColumn(grid, 0, "DepartName", false, true, 0, 80);
        }

        private DataTable QuickSearchNormalCardDataTable(DataGridView grid)
        {
            DataTable rtn = new DataTable();
            if (grid.DataSource == null)
            {
                rtn.Columns.Add("FingerNo", typeof(UInt32));
                rtn.Columns.Add("CardNo10", typeof(string));
                rtn.Columns.Add("CardNo81", typeof(string));
                rtn.Columns.Add("CardNo82", typeof(string));
                rtn.Columns.Add("EmpNo", typeof(string));
                rtn.Columns.Add("EmpName", typeof(string));
                rtn.Columns.Add("DepartID", typeof(string));
                rtn.Columns.Add("DepartName", typeof(string));
            }
            else
                rtn = (DataTable)grid.DataSource;
            return rtn;
        }

        private DataTable QuickSearchNormalMacDataTable(DataGridView grid)
        {
            DataTable rtn = new DataTable();
            if (grid.DataSource == null)
            {
                rtn.Columns.Add("MacSN", typeof(string));
                rtn.Columns.Add("MacDesc", typeof(string));
            }
            else
                rtn = (DataTable)grid.DataSource;
            return rtn;
        }

        protected void QuickSearchNormalCard(TextBox txt, KeyEventArgs e, DataGridView grid)
        {
            if (e.KeyCode != Keys.Enter) return;
            DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
            DataTableReader dr = null;
            string sql = "";
            if (IgnoreDimission) sql = Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
            if (IsAllEmpInfo)
                sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "110", sql, txt.Text.Trim() });
            else
                sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "107", sql, txt.Text.Trim() });
            string EmpNo = "";
            string CompEmpNo = "";
            bool IsExists = false;
            try
            {
                dr = SystemInfo.db.GetDataReader(sql);
                while (dr.Read())
                {
                    EmpNo = dr["EmpNo"].ToString();
                    IsExists = false;
                    for (int j = 0; j < dtGrid.Rows.Count; j++)
                    {
                        CompEmpNo = dtGrid.Rows[j]["EmpNo"].ToString();
                        if (CompEmpNo == EmpNo)
                        {
                            IsExists = true;
                            break;
                        }
                    }
                    if (!IsExists)
                    {
                        dtGrid.Rows.Add(new object[] { dr["FingerNo"], dr["CardNo10"], dr["CardNo81"], dr["CardNo82"],
              dr["EmpNo"], dr["EmpName"], dr["DepartID"], dr["DepartName"] });
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
            grid.DataSource = dtGrid;
            if (grid.RowCount > 0)
            {
                grid.Rows[grid.RowCount - 1].Selected = true;
                grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[0];
            }
        }

        protected void QuickSearchNormalCard(string Title, DataGridView grid)
        {
            string OtherCoin = "";
            if (IgnoreDimission) OtherCoin = Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
            if (!IsAllEmpInfo) OtherCoin += Pub.GetSQL(DBCode.DB_000300, new string[] { "109" });
            DataTable dt = new DataTable();
            if (!Pub.ShowSelectEmpList(Title, OtherCoin, ref dt)) return;
            DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
            string EmpNo = "";
            string CompEmpNo = "";
            bool IsExists = false;
            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                EmpNo = dr["EmpNo"].ToString();
                IsExists = false;
                for (int j = 0; j < dtGrid.Rows.Count; j++)
                {
                    CompEmpNo = dtGrid.Rows[j]["EmpNo"].ToString();
                    if (CompEmpNo == EmpNo)
                    {
                        IsExists = true;
                        break;
                    }
                }
                if (!IsExists)
                {
                    dtGrid.Rows.Add(new object[] { dr["FingerNo"], dr["CardNo10"], dr["CardNo81"], dr["CardNo82"],
            dr["EmpNo"], dr["EmpName"], dr["DepartID"], dr["DepartName"] });
                }
            }
            grid.DataSource = dtGrid;
            if (grid.RowCount > 0)
            {
                grid.Rows[grid.RowCount - 1].Selected = true;
                grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[0];
            }
        }

        protected void QuickSearchNormalEmp(TextBox txt, KeyEventArgs e, DataGridView grid)
        {
            QuickSearchNormalEmp(txt, e, grid, "");
        }

        protected void QuickSearchNormalEmp(TextBox txt, KeyEventArgs e, DataGridView grid, string OtherCoin)
        {
            if (e.KeyCode != Keys.Enter) return;
            DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
            DataTableReader dr = null;
            string EmpNo = "";
            bool IsExists = false;
            if (IgnoreDimission) OtherCoin += Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000101, new string[] { "206",
          txt.Text.Trim(), OtherCoin }));
                while (dr.Read())
                {
                    EmpNo = dr["EmpNo"].ToString();
                    IsExists = false;
                    for (int j = 0; j < dtGrid.Rows.Count; j++)
                    {
                        if (dtGrid.Rows[j]["EmpNo"].ToString() == EmpNo)
                        {
                            IsExists = true;
                            break;
                        }
                    }
                    if (!IsExists)
                    {
                        dtGrid.Rows.Add(new object[] { dr["FingerNo"], dr["CardNo10"], dr["CardNo81"], dr["CardNo82"],
            dr["EmpNo"], dr["EmpName"], dr["DepartID"], dr["DepartName"] });
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
            grid.DataSource = dtGrid;
            if (grid.RowCount > 0)
            {
                grid.Rows[grid.RowCount - 1].Selected = true;
                grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[0];
            }
        }

        protected void QuickSearchNormalEmp(string Title, DataGridView grid)
        {
            QuickSearchNormalEmp(Title, grid, "");
        }

        protected void QuickSearchNormalEmp(string Title, DataGridView grid, string OtherCoin)
        {
            DataTable dt = new DataTable();
            if (IgnoreDimission) OtherCoin += Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
            if (!Pub.ShowSelectEmpList(Title, OtherCoin, ref dt)) return;
            DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
            string EmpNo = "";
            bool IsExists = false;
            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                EmpNo = dr["EmpNo"].ToString();
                IsExists = false;
                for (int j = 0; j < dtGrid.Rows.Count; j++)
                {
                    if (dtGrid.Rows[j]["EmpNo"].ToString() == EmpNo)
                    {
                        IsExists = true;
                        break;
                    }
                }
                if (!IsExists)
                {
                    dtGrid.Rows.Add(new object[] { dr["FingerNo"], dr["CardNo10"], dr["CardNo81"], dr["CardNo82"],
            dr["EmpNo"], dr["EmpName"], dr["DepartID"], dr["DepartName"] });
                }
            }
            grid.DataSource = dtGrid;
            if (grid.RowCount > 0)
            {
                grid.Rows[grid.RowCount - 1].Selected = true;
                grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[0];
            }
        }

        protected void QuickSearchNormalMac(TextBox txt, KeyEventArgs e, DataGridView grid)
        {
            QuickSearchNormalMac(txt, e, grid, "");
        }

        protected void QuickSearchNormalMac(TextBox txt, KeyEventArgs e, DataGridView grid, string OtherCoin)
        {
            if (e.KeyCode != Keys.Enter) return;
            QuickSearchNormalMac(txt.Text.ToString(), grid);
        }

        protected void QuickSearchNormalMac(string txt, DataGridView grid)
        { 
            bool ret = false;
            if (grid.RowCount > 0 && txt != "")
            {
                string[] tmp = txt.Trim().Split(',');
                if (tmp.Length > 0)
                {
                    for (int x = 0; x < tmp.Length; x++)
                    {
                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            if(isNumberic(tmp[x]))
                            {
                                if (tmp[x] == grid[1, i].Value.ToString())
                                {
                                    grid[0, i].Value = true;
                                    grid.Rows[i].Selected = true;
                                      grid.CurrentCell = grid.Rows[i].Cells[0];
                                    ret = true;
                                    break;
                                }
                            }
                            else if (tmp[x] != "")
                            {
                                if ( grid[2, i].Value.ToString().Contains(tmp[x]))
                                {
                                    grid[0, i].Value = true;
                                    grid.Rows[i].Selected = true;
                                    grid.CurrentCell = grid.Rows[i].Cells[0];
                                    ret = true;
                                    continue;
                                }
                            }
                           
                        }
                    }
                    string[] tmpT = txt.Trim().Split('，');
                    if (tmpT.Length > 0)
                    {
                        for (int x = 0; x < tmpT.Length; x++)
                        {
                            for (int i = 0; i < grid.Rows.Count; i++)
                            {
                                if (isNumberic(tmpT[x]))
                                {
                                    if (tmpT[x] == grid[1, i].Value.ToString())
                                    {
                                        grid[0, i].Value = true;
                                        grid.Rows[i].Selected = true;
                                        grid.CurrentCell = grid.Rows[i].Cells[0];
                                        ret = true;
                                        break;
                                    }
                                }
                                else if (tmpT[x] != "")
                                {
                                    if (grid[2, i].Value.ToString().Contains(tmpT[x]))
                                    {
                                        grid[0, i].Value = true;
                                        grid.Rows[i].Selected = true;
                                        grid.CurrentCell = grid.Rows[i].Cells[0];
                                        ret = true;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    string[] tmpK = txt.Trim().Split(' ');
                    if (tmpK.Length > 0)
                    {
                        for (int x = 0; x < tmpK.Length; x++)
                        {
                            for (int i = 0; i < grid.Rows.Count; i++)
                            {
                                if (isNumberic(tmpK[x]))
                                {
                                    if (tmpK[x] == grid[1, i].Value.ToString())
                                    {
                                        grid[0, i].Value = true;
                                        grid.Rows[i].Selected = true;
                                        grid.CurrentCell = grid.Rows[i].Cells[0];
                                        ret = true;
                                        break;
                                    }
                                }
                                else if (tmpK[x] != "")
                                {
                                    if (grid[2, i].Value.ToString().Contains(tmpK[x]))
                                    {
                                        grid[0, i].Value = true;
                                        grid.Rows[i].Selected = true;
                                        grid.CurrentCell = grid.Rows[i].Cells[0];
                                        ret = true;
                                        continue;
                                    }
                                }
                            }
                        }

                    }
                    string[] tmpM = txt.Trim().Split('.');
                    if (tmpM.Length > 0)
                    {
                        for (int x = 0; x < tmpM.Length; x++)
                        {
                            for (int i = 0; i < grid.Rows.Count; i++)
                            {
                                if (isNumberic(tmpM[x]))
                                {
                                    if (tmpM[x] == grid[1, i].Value.ToString())
                                    {
                                        grid[0, i].Value = true;
                                        grid.Rows[i].Selected = true;
                                        grid.CurrentCell = grid.Rows[i].Cells[0];
                                        ret = true;
                                        break;
                                    }
                                }
                                else if (tmpM[x] != "")
                                {
                                    if (grid[2, i].Value.ToString().Contains(tmpM[x]))
                                    {
                                        grid[0, i].Value = true;
                                        grid.Rows[i].Selected = true;
                                        grid.CurrentCell = grid.Rows[i].Cells[0];
                                        ret = true;
                                        continue;
                                    }
                                }
                            }
                        }

                    }
                }
                if (!ret)
                {
                    string msg = string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""),
                        Pub.GetResText("", "MacSN", "") + "," + Pub.GetResText("", "MacDesc", ""));
                    Pub.MessageBoxShow(msg);
                }
            }
        }
        protected bool isNumberic(string message)
        {
            try
            {
                Convert.ToInt32(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 计算发送的数据的大小
        /// </summary>
        /// <param name="setUsers"></param>
        /// <returns></returns>
        public int CalculatedLength(SetUsers setUsers)
        {
            int ret = 300;  //约包含一个int/两个byte/标点符号/名称
            if (setUsers.card != null)
            {
                ret += setUsers.card.Length;
            }
            if (setUsers.face != null)
            {
                ret += setUsers.face.Length;
            }
            if (setUsers.name != null)
            {
                ret += setUsers.name.Length;
            }
            if (setUsers.palm != null)
            {
                ret += setUsers.palm.Length;
            }
            if (setUsers.photo != null)
            {
                ret += setUsers.photo.Length;
            }
            if (setUsers.pwd != null)
            {
                ret += setUsers.pwd.Length;
            }
            if (setUsers.userId != null)
            {
                ret += setUsers.userId.Length;
            }
            if (setUsers.vaildEnd != null)
            {
                ret += setUsers.vaildEnd.Length;
            }
            if (setUsers.vaildStart != null)
            {
                ret += setUsers.vaildStart.Length;
            }
            if (setUsers.fps != null)
            {
                for (int i = 0; i < setUsers.fps.Count; i++)
                {
                    if (setUsers.fps[i] != null)
                        ret += setUsers.fps[i].Length;
                }
            }
            return ret;
        }
        /// <summary>
        /// 字符串转数据格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string stringToTimeStr(string time)
        {
            if (time.Length == 8)
            {
                time = time.Insert(4, "-");
                time = time.Insert(7, "-");
            }
            return time;
        }

        public string CheckTimeStr(string time)
        {
            try
            {
                Convert.ToDateTime(time);
            }
            catch
            {
                time = null;
            }
            return time;
        }

        /// <summary>
        /// 转换时间格式
        /// </summary>
        /// <param name="type"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool IsDateTime(string type, ref string time)
        {
            try
            {
                time = Convert.ToDateTime(time).ToString(type);

            }
            catch
            {
                time = null;
                return false;
            }
            return true;
        }

        protected Bitmap CustomSizeImage(Image img)
        {
            double whX = 240.00 / 180.00;
            int w = 180;
            int h = Convert.ToInt32(w * whX);
            Bitmap bmp = new Bitmap(w, h);
            int srcX = 0;
            int srcY = 0;
            int srcW = img.Width;
            int srcH = img.Height;
            double zoom = ((double)w) / ((double)srcW);
            Graphics g = Graphics.FromImage(bmp);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            Color c = Color.FromArgb(new Bitmap(img).GetPixel(1, 1).ToArgb());
            g.Clear(c);
            if (srcW * whX != srcH)
            {
                if (srcW * whX >= srcH)
                {
                    srcH = Convert.ToInt32(srcW * whX);
                    srcY = -(srcH - img.Height) / 2;
                }
                else
                {
                    srcW = Convert.ToInt32(srcH / whX);
                    srcX = -(srcW - img.Width) / 2;
                }
            }
            g.DrawImage(img, new Rectangle(0, 0, w, h), new Rectangle(srcX, srcY, srcW, srcH), GraphicsUnit.Pixel);
            img.Dispose();
            g.Dispose();
            return bmp;
        }

        protected Bitmap CustomSizePhoto(Image img)
        {
            int gd = 720;
            int width = img.Width;
            int heigth = img.Height;
            double scale = 0.0;
            int h = 0;
            int w = 0;
            double whX = 0.0;
            if (width <= heigth )
            {
                scale = ((double)width) / ((double)heigth);
                h = (int)(gd / scale);
                whX = (double)h / (double)gd;
                w = gd;

                if (width < gd)
                {
                    h = heigth;
                    w = width;
                    whX = (double)heigth / (double)width;
                }
            }
            else
            {
                scale = ((double)heigth) / ((double)width);
                w = (int)(gd / scale);
                whX = (double)w / (double)gd;
                h = gd;

                if (heigth < gd)
                {
                    h = heigth;
                    w = width;
                    whX = (double)width / (double)heigth;
                }
            }
         
            Bitmap bmp = new Bitmap(w, h);
            int srcX = 0;
            int srcY = 0;
            int srcW = img.Width;
            int srcH = img.Height;
            double zoom = ((double)w) / ((double)srcW);
            Graphics g = Graphics.FromImage(bmp);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            Color c = Color.FromArgb(new Bitmap(img).GetPixel(1, 1).ToArgb());
            g.Clear(c);
            if (srcW * whX != srcH)
            {
                if (srcW * whX >= srcH)
                {
                    srcH = Convert.ToInt32(srcW * whX);
                    srcY = -(srcH - img.Height) / 2;
                }
                else
                {
                    srcW = Convert.ToInt32(srcH / whX);
                    srcX = -(srcW - img.Width) / 2;
                }
            }
            g.DrawImage(img, new Rectangle(0, 0, w, h), new Rectangle(srcX, srcY, srcW, srcH), GraphicsUnit.Pixel);
            img.Dispose();
            g.Dispose();
            return bmp;
        }

        public bool IsIpAddr(string ipStr)
        {
            bool ret = false;
            IPAddress IP;
            if(IPAddress.TryParse(ipStr,out IP))
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

    }
}