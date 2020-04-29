using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmBellTime : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "BellTime";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            dataGrid.Rows.Clear();
            for (int i = 0; i < (int)FKMax.MAX_BELLCOUNT_DAY; i++)
            {
                dataGrid.Rows.Add();
                dataGrid[0, i].Value = i + 1;
                dataGrid[1, i].Value = false;
                dataGrid[2, i].Value = "00:00";
            }
            cbbCount.Items.Clear();
            for (int i = 0; i <= (int)FKMax.MAX_BELLCOUNT_DAY; i++)
            {
                cbbCount.Items.Add(i.ToString());
            }
            tvGrid.Nodes.Clear();
            tvGrid.Nodes.Add(Pub.GetResText(formCode, "BellTimeID", ""));
            tvGrid.Nodes.Add(Pub.GetResText(formCode, "Allow", ""));
            tvGrid.Nodes.Add(Pub.GetResText(formCode, "BellTime", ""));
            LoadData();
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.Columns[i].ReadOnly = false;
            }
        }

        public frmBellTime(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }

        private void LoadData()
        {
            string Src = SystemInfo.db.ReadConfig("MJFunc", "BellTime");
            MJBellTime bt = new MJBellTime(Src);
            if (bt.Exists)
            {
                for (int i = 0; i < (int)FKMax.MAX_BELLCOUNT_DAY; i++)
                {
                    dataGrid[1, i].Value = bt.Allow[i];
                    dataGrid[2, i].Value = bt.Time[i];
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
                    break;
                case 1:
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
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.CurrentRow.Cells[i].Value = dataGrid[i, dataGrid.CurrentRow.Index - 1].Value;
            }
        }

        private void ItemEmptyData_Click(object sender, EventArgs e)
        {
            dataGrid.CurrentRow.Cells[1].Value = false;
            dataGrid.CurrentRow.Cells[2].Value = "00:00";
        }

        private string GetTime(int col, int row)
        {
            return Pub.ValidatTime(dataGrid[col, row].Value.ToString());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string Src = "";
            for (int i = 0; i < (int)FKMax.MAX_BELLCOUNT_DAY; i++)
            {
                Src += Convert.ToByte(dataGrid[1, i].Value).ToString() + "@" + GetTime(2, i) + "@";
            }
            Src = Src + cbbCount.Text;
            if (!SystemInfo.db.WriteConfig("MJFunc", "BellTime", Src)) return;
            SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, Src);
            //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}