using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmPubSelectDate : frmBaseDialog
  {
    public DateTime SelectDateTime = new DateTime();
    private bool _ShowTime = false;

    protected override void InitForm()
    {
      formCode = "PubSelectDate";
      base.InitForm();
      label1.Visible = _ShowTime;
      dtpTime.Enabled = _ShowTime;
      dtpTime.Visible = _ShowTime;
      dtpTime.Value = DateTime.Now;
      Calendar.SelectionRange.Start = DateTime.Now.Date;
      Calendar.SelectionRange.End = DateTime.Now.Date;
      if (SelectDateTime >= Calendar.MinDate)
      {
        Calendar.SelectionRange.Start = SelectDateTime;
        Calendar.SelectionRange.End = SelectDateTime;
        Calendar.SetDate(SelectDateTime);
        if (_ShowTime) dtpTime.Value = SelectDateTime;
      }
    }

    public frmPubSelectDate(bool ShowTime, DateTime currentDate)
    {
      _ShowTime = ShowTime;
      SelectDateTime = currentDate;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      SelectDateTime = Calendar.SelectionRange.Start;
      if (_ShowTime)
      {
        SelectDateTime = new DateTime(SelectDateTime.Year, SelectDateTime.Month, SelectDateTime.Day,
          dtpTime.Value.Hour, dtpTime.Value.Minute, dtpTime.Value.Second);
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}