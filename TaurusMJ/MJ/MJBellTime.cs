using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmMJBellTime : frmBaseDialog
    {
        private int rowMax = 0;

        protected override void InitForm()
        {
            formCode = "MJBellTime";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
            dataGrid.Rows.Clear();
            rowMax = (int)FKMax.MAX_BELLCOUNT_DAY;
            rowMax /= 2;
            for (int i = 0; i < rowMax; i++)
            {
                dataGrid.Rows.Add();
                dataGrid[0, i].Value = i + 1;
                dataGrid[1, i].Value = "0";
                dataGrid[2, i].Value = "00:00";
                dataGrid[3, i].Value = i + 1 + rowMax;
                dataGrid[4, i].Value = "0";
                dataGrid[5, i].Value = "00:00";
            }
            cbbCount.Items.Clear();
            for (int i = 0; i <= rowMax * 2; i++)
            {
                cbbCount.Items.Add(i.ToString());
            }
            dataGrid.Columns[0].HeaderText = Pub.GetResText(formCode, "BellTimeID", "");
            dataGrid.Columns[1].HeaderText = Pub.GetResText(formCode, "Allow", "");
            dataGrid.Columns[2].HeaderText = Pub.GetResText(formCode, "BellTime", "");
            dataGrid.Columns[3].HeaderText = Pub.GetResText(formCode, "BellTimeID", "");
            dataGrid.Columns[4].HeaderText = Pub.GetResText(formCode, "Allow", "");
            dataGrid.Columns[5].HeaderText = Pub.GetResText(formCode, "BellTime", "");
            LoadData();
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.Columns[i].ReadOnly = false;
            }
        }

        public frmMJBellTime()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string Src = SystemInfo.db.ReadConfig("MJFunc", "BellTime");
            MJBellTime bt = new MJBellTime(Src);
            if (bt.Exists)
            {
                for (int i = 0; i < rowMax; i++)
                {
                    dataGrid[1, i].Value = bt.Allow[i];
                    dataGrid[1, i].ToolTipText = "0 - 60";
                    dataGrid[2, i].Value = bt.Time[i];
                    dataGrid[4, i].Value = bt.Allow[i + rowMax];
                    dataGrid[4, i].ToolTipText = "0 - 60";
                    dataGrid[5, i].Value = bt.Time[i + rowMax];
                }
            }
            cbbCount.SelectedIndex = bt.BellCount;
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string v = "";
            switch (e.ColumnIndex)
            {
                case 0:
                case 3:
                    break;
                case 1:
                case 4:
                    int count = 0;
                    if (!(int.TryParse(dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString(), out count) && count >= 0 && count <= 60))
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = 0; 
                    break;
                default:
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null &&
                      dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                    {
                        txtTime.Text = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        v = Pub.ValidatTime(txtTime.Text.Trim());
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = v;
                    }
                    break;
            }
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void GridMenu_Opening(object sender, CancelEventArgs e)
        {
            ItemPasteUpData.Enabled = dataGrid.CurrentRow.Index > 0;
        }

        private void ItemPasteUpData_Click(object sender, EventArgs e)
        {
            dataGrid.CurrentRow.Cells[1].Value = dataGrid[1, dataGrid.CurrentRow.Index - 1].Value;
            dataGrid.CurrentRow.Cells[2].Value = dataGrid[2, dataGrid.CurrentRow.Index - 1].Value;
            dataGrid.CurrentRow.Cells[4].Value = dataGrid[4, dataGrid.CurrentRow.Index - 1].Value;
            dataGrid.CurrentRow.Cells[5].Value = dataGrid[5, dataGrid.CurrentRow.Index - 1].Value;
        }

        private void ItemEmptyData_Click(object sender, EventArgs e)
        {
            dataGrid.CurrentRow.Cells[1].Value = "0";
            dataGrid.CurrentRow.Cells[2].Value = "00:00";
            dataGrid.CurrentRow.Cells[4].Value = "0";
            dataGrid.CurrentRow.Cells[5].Value = "00:00";
        }

        private string GetTime(int col, int row)
        {
            return Pub.ValidatTime(dataGrid[col, row].Value.ToString());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string Src = "";
            string Src1 = "";
            for (int i = 0; i < rowMax; i++)
            {
                Src += Convert.ToByte(dataGrid[1, i].Value).ToString() + "@" + GetTime(2, i) + "@";
                Src1 += Convert.ToByte(dataGrid[4, i].Value).ToString() + "@" + GetTime(5, i) + "@";
            }
            Src = Src + Src1 + cbbCount.Text;
            if (!SystemInfo.db.WriteConfig("MJFunc", "BellTime", Src)) return;
            SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, Src);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            new frmMJOprt(this.Text, btnDown.Text, 10,null).ShowDialog();
            LoadData();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            new frmMJOprt(this.Text, btnUp.Text, 11,null).ShowDialog();
        }
    }
}