using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmSelectEmp : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        public TDownSelectList[] selList = new TDownSelectList[0];
        public string selEmpNo = "";
        private DataTable Upload = null;

        protected override void InitForm()
        {
            formCode = "SelectEmp";
            CreateCardGridView(cardGrid);
            
            selList = new TDownSelectList[0];
            selEmpNo = "";
            IsAllEmpInfo = true;
            base.InitForm();
            lblQuickSearchToolTip.ForeColor = Color.Blue;
            this.Text = oprt;
            RadioButton_Click(null, null);
            rbAll.Text = Pub.GetResText("KQDataAssay", rbAll.Name, "");
            rbEmp.Text = Pub.GetResText("KQDataAssay", rbEmp.Name, "");
        }

        public frmSelectEmp(string Title, string Oprt)
        {
            title = Title;
            oprt = Oprt;
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            gbxEmpInfo.Enabled = rbEmp.Checked;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalCard(btnQuickSearch.Text, cardGrid);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalCard(txtQuickSearch, e, cardGrid);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (rbEmp.Checked)
            {
                if (cardGrid.RowCount == 0)
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                    return;
                }
                selList = new TDownSelectList[cardGrid.RowCount];
                DataTable dtEmp = (DataTable)cardGrid.DataSource;
                for (int i = 0; i < dtEmp.Rows.Count; i++)
                {
                    selList[i] = new TDownSelectList();
                    selList[i].EmpNo = dtEmp.Rows[i]["EmpNo"].ToString();
                    selList[i].EnrollName = dtEmp.Rows[i]["EmpName"].ToString();
                    selList[i].EnrollNumber = Convert.ToUInt32(dtEmp.Rows[i]["FingerNo"].ToString());
                    selEmpNo += "'" + selList[i].EmpNo + "',";
                }
                if (selEmpNo != "") selEmpNo = selEmpNo.Substring(0, selEmpNo.Length - 1);
            }
            else
            {
                sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "303" });
                Upload = SystemInfo.db.GetDataTable(sql);

                for (int i = 0; i < Upload.Rows.Count; i++)
                {
                    selEmpNo += "'" + Upload.Rows[i]["EmpNo"].ToString() + "',";
                }
                if (selEmpNo != "") selEmpNo = selEmpNo.Substring(0, selEmpNo.Length - 1);

            }

            this.Close();

            this.DialogResult = DialogResult.OK;

        }

        private void cardGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblMsg.Text = string.Format(Pub.GetResText(formCode, "MsgSelectNo", ""), cardGrid.Rows.Count);
        }
    }
}