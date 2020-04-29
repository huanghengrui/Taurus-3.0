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
  public partial class frmPowerSetupEdit : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "PowerSetupEdit";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      txtEmpNo.Enabled = false;
      txtEmpName.Enabled = false;
      txtDepartName.Enabled = false;
      LoadData();
      KeyPreview = true;
      btnSelectStartDate.Text = "...";
      btnSelectEndDate.Text = "...";
    }

    public frmPowerSetupEdit(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      cbbSun.Items.Clear();
      cbbMon.Items.Clear();
      cbbTue.Items.Clear();
      cbbWed.Items.Clear();
      cbbThu.Items.Clear();
      cbbFri.Items.Clear();
      cbbSat.Items.Clear();
      cbbSun.Items.Add("0");
      cbbMon.Items.Add("0");
      cbbTue.Items.Add("0");
      cbbWed.Items.Add("0");
      cbbThu.Items.Add("0");
      cbbFri.Items.Add("0");
      cbbSat.Items.Add("0");
      DataTableReader dr = null;
      TIDAndName idn;
      try
      {
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "400" }));
        while (dr.Read())
        {
          idn = new TIDAndName(dr["PassTimeID"].ToString(), "[" + dr["PassTimeID"].ToString() + "]" +
            dr["PassTimeName"].ToString());
          cbbSun.Items.Add(idn);
          cbbMon.Items.Add(idn);
          cbbTue.Items.Add(idn);
          cbbWed.Items.Add(idn);
          cbbThu.Items.Add(idn);
          cbbFri.Items.Add(idn);
          cbbSat.Items.Add(idn);
        }
        dr.Close();
        dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000300, new string[] { "601", SysID }));
        if (dr.Read())
        {
          txtEmpNo.Text = dr["EmpNo"].ToString();
          txtEmpName.Text = dr["EmpName"].ToString();
          txtDepartName.Text = dr["DepartName"].ToString();
          SetTimeIndex(cbbSun, dr["SunID"].ToString());
          SetTimeIndex(cbbMon, dr["MonID"].ToString());
          SetTimeIndex(cbbTue, dr["TueID"].ToString());
          SetTimeIndex(cbbWed, dr["WedID"].ToString());
          SetTimeIndex(cbbThu, dr["ThuID"].ToString());
          SetTimeIndex(cbbFri, dr["FriID"].ToString());
          SetTimeIndex(cbbSat, dr["SatID"].ToString());
          DateTime d = new DateTime();
          if (DateTime.TryParse(dr["StartDate"].ToString(), out d))
          {
            txtStartDate.Text = d.ToShortDateString();
          }
          if (DateTime.TryParse(dr["EndDate"].ToString(), out d))
          {
            txtEndDate.Text = d.ToShortDateString();
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
    }

    private void SetTimeIndex(ComboBox cbb, string value)
    {
      cbb.SelectedIndex = 0;
      for (int i = 1; i < cbb.Items.Count; i++)
      {
        if (((TIDAndName)cbb.Items[i]).id == value)
        {
          cbb.SelectedIndex = i;
          break;
        }
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (cbbSun.SelectedIndex == -1)
      {
        cbbSun.Focus();
        ShowErrorSelectCorrect(label3.Text);
        return;
      }
      if (cbbMon.SelectedIndex == -1)
      {
        cbbMon.Focus();
        ShowErrorSelectCorrect(label5.Text);
        return;
      }
      if (cbbTue.SelectedIndex == -1)
      {
        cbbTue.Focus();
        ShowErrorSelectCorrect(label6.Text);
        return;
      }
      if (cbbWed.SelectedIndex == -1)
      {
        cbbWed.Focus();
        ShowErrorSelectCorrect(label7.Text);
        return;
      }
      string SunID = cbbSun.Text;
      string MonID = cbbMon.Text;
      string TueID = cbbTue.Text;
      string WedID = cbbWed.Text;
      string ThuID = cbbThu.Text;
      string FriID = cbbFri.Text;
      string SatID = cbbSat.Text;
      if (cbbSun.SelectedIndex > 0) SunID = ((TIDAndName)cbbSun.Items[cbbSun.SelectedIndex]).id;
      if (cbbMon.SelectedIndex > 0) MonID = ((TIDAndName)cbbMon.Items[cbbMon.SelectedIndex]).id;
      if (cbbTue.SelectedIndex > 0) TueID = ((TIDAndName)cbbTue.Items[cbbTue.SelectedIndex]).id;
      if (cbbWed.SelectedIndex > 0) WedID = ((TIDAndName)cbbWed.Items[cbbWed.SelectedIndex]).id;
      if (cbbThu.SelectedIndex > 0) ThuID = ((TIDAndName)cbbThu.Items[cbbThu.SelectedIndex]).id;
      if (cbbFri.SelectedIndex > 0) FriID = ((TIDAndName)cbbSun.Items[cbbFri.SelectedIndex]).id;
      if (cbbSat.SelectedIndex > 0) SatID = ((TIDAndName)cbbSun.Items[cbbSat.SelectedIndex]).id;
      string StartDate = "NULL";
      string EndDate = "NULL";
      DateTime dt;
      if (DateTime.TryParse(txtStartDate.Text, out dt)) StartDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
      if (DateTime.TryParse(txtEndDate.Text, out dt)) EndDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
      string sql = "";
      try
      {
        sql = Pub.GetSQL(DBCode.DB_000300, new string[] { "602", SysID, SunID, MonID, TueID, WedID, 
          ThuID, FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
        SystemInfo.db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
        return;
      }
      SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, sql);
      //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnSelectStartDate_Click(object sender, EventArgs e)
    {
      DateTime d = new DateTime();
      DateTime.TryParse(txtStartDate.Text, out d);
      if (Pub.GetSelectDate(false, ref d)) txtStartDate.Text = d.ToShortDateString();
    }

    private void btnSelectEndDate_Click(object sender, EventArgs e)
    {
      DateTime d = new DateTime();
      DateTime.TryParse(txtEndDate.Text, out d);
      if (Pub.GetSelectDate(false, ref d)) txtEndDate.Text = d.ToShortDateString();
    }
  }
}