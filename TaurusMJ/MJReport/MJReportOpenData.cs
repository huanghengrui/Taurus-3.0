using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Taurus
{
  public partial class frmMJReportOpenData : frmBaseMDIChildReportPrint
  {
    protected override void InitForm()
    {
      formCode = "KQReportMJData";
      ReportFile = "MJReportOpenData";
      IsInitBaseForm = true;
      IgnoreDimission = false;
      base.InitForm();
     
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
 
    }

    public frmMJReportOpenData()
    {
      InitializeComponent();
    }


        protected override void ExecItemRefresh()
        {
            string EmpNo = "";
            string MacTag = "0";
            string MacSN = "";
            string InOutMode = "";
          
            if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }

            if ((txtMacSN.Text.Trim() != "") && (txtMacSN.Tag != null))
            {
                MacSN = txtMacSN.Text.Trim();
                MacTag = "1";
            }
            else if ((txtMacSN.Text.Trim() != ""))
            {
                MacSN = txtMacSN.Text.Trim();
            }
            if (txtInOutMode.Text.Trim() != "")
            {
                InOutMode = txtInOutMode.Text.Trim();
            }
            
            QuerySQL = Pub.GetSQL(DBCode.DB_000300, new string[] { "707", dtpStart.Value.ToString(SystemInfo.SQLDateFMT),
       dtpEnd.Value.ToString(SystemInfo.SQLDateFMT),EmpNo, MacTag, MacSN, InOutMode});
            RefreshSQL();
            //cbbInOutMode_DropDown();
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp(IgnoreDimission);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp.Text = frm.EmpName;
                txtEmp.Tag = frm.EmpNo;
            }
        }

        private void btnSelectMacSN_Click(object sender, EventArgs e)
        {
            frmPubSelectMacSN frm = new frmPubSelectMacSN();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtMacSN.Text = frm.MacSN;
                txtMacSN.Tag = frm.MacSN;
            }
        }

        private void RefreshSQL()
        {
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }

      /*  private void cbbInOutMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInOutMode.Text = cbbInOutMode.Text;
        }

        private void cbbInOutMode_DropDown()
        {
            bool ret = false;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                ret = false;
                if (Report.FieldByName("InOutModeName").IsNull)
                {
                    Report.DetailGrid.Recordset.Next();
                    continue;
                }

                if (Report.FieldByName("InOutModeName").AsString.ToString() == "")
                {
                    Report.DetailGrid.Recordset.Next();
                    continue;
                } 
                if (cbbInOutMode.Items.Count > 0)
                    for (int i = 0; i < cbbInOutMode.Items.Count; i++)
                    {
                        if (cbbInOutMode.Items[i].ToString() == Report.FieldByName("InOutModeName").AsString)
                        {
                            ret = true;
                            break;
                        }
                    }
                if (!ret)
                    cbbInOutMode.Items.Add(Report.FieldByName("InOutModeName").AsString);
                Report.DetailGrid.Recordset.Next();
            }
        }*/
    }
}