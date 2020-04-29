using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public partial class frmMacDataFormat : frmBaseDialog
  {
    private KQTextFormatInfo textFormat = new KQTextFormatInfo("");

    protected override void InitForm()
    {
      formCode = "MacDataFormat";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      lblHint.ForeColor = Color.Blue;
      lblMacSNHint.ForeColor = Color.Red;
      lblEmpNoHint.ForeColor = Color.Red;
      lblEmpNameHint.ForeColor = Color.Red;
      lblEmpNo.Text = lblMacSN.Text;
      lblEmpName.Text = lblMacSN.Text;
      lblCardNo.Text = lblMacSN.Text;
      SetTextboxNumber(txtMacSN);
      SetTextboxNumber(txtEmpNo);
      SetTextboxNumber(txtEmpName);
      SetTextboxNumber(txtCardNo);
      RadioButton_Click(null, null);
      chkAllow_CheckedChanged(null, null);
      LoadTextFormat();
    }

    public frmMacDataFormat(string title, string CurrentTool)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      InitializeComponent();
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
      chkAllow.Checked = textFormat.Allow;
      rbSepNo.Checked = textFormat.SepFlag == 0;
      rbSepTAB.Checked = textFormat.SepFlag == 1;
      rbSepCustom.Checked = textFormat.SepFlag == 2;
      if (!rbSepNo.Checked && rbSepTAB.Checked && rbSepCustom.Checked) rbSepNo.Checked = true;

      txtSep.Text = textFormat.SepStr;
      chkMacSN.Checked = textFormat.MacSNAllow;
      txtMacSN.Text = textFormat.MacSNLen.ToString();
      txtMacSN.Tag = textFormat.MacSNOrder;
      chkEmpNo.Checked = textFormat.EmpNoAllow;
      txtEmpNo.Text = textFormat.EmpNoLen.ToString();
      txtEmpNo.Tag = textFormat.EmpNoOrder;
      chkEmpName.Checked = textFormat.EmpNameAllow;
      txtEmpName.Text = textFormat.EmpNameLen.ToString();
      txtEmpName.Tag = textFormat.EmpNameOrder;
      chkCardNo.Checked = textFormat.CardNoAllow;
      txtCardNo.Text = textFormat.CardNoLen.ToString();
      txtCardNo.Tag = textFormat.CardNoOrder;
      chkDataTime.Checked = textFormat.DataTimeAllow;
      txtDataTime.Text = textFormat.DataTimeFormat;
      txtDataTime.Tag = textFormat.DataTimeOrder;
      chkOrder.Items.Clear();
      if (textFormat.EmpNoOrder == 0)
        chkOrder.Items.Add(chkEmpNo.Text);
      else if (textFormat.EmpNameOrder == 0)
        chkOrder.Items.Add(chkEmpName.Text);
      else if (textFormat.CardNoOrder == 0)
        chkOrder.Items.Add(chkCardNo.Text);
      else if (textFormat.DataTimeOrder == 0)
        chkOrder.Items.Add(chkDataTime.Text);
      else
        chkOrder.Items.Add(chkMacSN.Text);
      if (textFormat.MacSNOrder == 1)
        chkOrder.Items.Add(chkMacSN.Text);
      else if (textFormat.EmpNoOrder == 1)
        chkOrder.Items.Add(chkEmpNo.Text);
      else if (textFormat.EmpNameOrder == 1)
        chkOrder.Items.Add(chkEmpName.Text);
      else if (textFormat.CardNoOrder == 1)
        chkOrder.Items.Add(chkCardNo.Text);
      else if (textFormat.DataTimeOrder == 1)
        chkOrder.Items.Add(chkDataTime.Text);
      if (textFormat.MacSNOrder == 2)
        chkOrder.Items.Add(chkMacSN.Text);
      else if (textFormat.EmpNoOrder == 2)
        chkOrder.Items.Add(chkEmpNo.Text);
      else if (textFormat.EmpNameOrder == 2)
        chkOrder.Items.Add(chkEmpName.Text);
      else if (textFormat.CardNoOrder == 2)
        chkOrder.Items.Add(chkCardNo.Text);
      else if (textFormat.DataTimeOrder == 2)
        chkOrder.Items.Add(chkDataTime.Text);
      if (textFormat.MacSNOrder == 3)
        chkOrder.Items.Add(chkMacSN.Text);
      else if (textFormat.EmpNoOrder == 3)
        chkOrder.Items.Add(chkEmpNo.Text);
      else if (textFormat.EmpNameOrder == 3)
        chkOrder.Items.Add(chkEmpName.Text);
      else if (textFormat.CardNoOrder == 3)
        chkOrder.Items.Add(chkCardNo.Text);
      else if (textFormat.DataTimeOrder == 3)
        chkOrder.Items.Add(chkDataTime.Text);
      if (textFormat.MacSNOrder == 4)
        chkOrder.Items.Add(chkMacSN.Text);
      else if (textFormat.EmpNoOrder == 4)
        chkOrder.Items.Add(chkEmpNo.Text);
      else if (textFormat.EmpNameOrder == 4)
        chkOrder.Items.Add(chkEmpName.Text);
      else if (textFormat.CardNoOrder == 4)
        chkOrder.Items.Add(chkCardNo.Text);
      else if (textFormat.DataTimeOrder == 4)
        chkOrder.Items.Add(chkDataTime.Text);
    }

    private void chkAllow_CheckedChanged(object sender, EventArgs e)
    {
      gbxFormat.Enabled = chkAllow.Checked;
      lblOrder.Enabled = chkAllow.Checked;
      chkOrder.Enabled = chkAllow.Checked;
      btnOrderUp.Enabled = chkAllow.Checked;
      btnOrderDown.Enabled = chkAllow.Checked;
      btnShowFormat.Enabled = chkAllow.Checked;
      txtFormat.Enabled = chkAllow.Checked;
      if (chkAllow.Checked)
      {
        chkMacSN.Checked = true;
        chkEmpNo.Checked = true;
        chkEmpName.Checked = true;
        chkCardNo.Checked = true;
        chkDataTime.Checked = true;
      }
    }

    private void RadioButton_Click(object sender, EventArgs e)
    {
      txtSep.Enabled = rbSepCustom.Checked;
    }

    private void chkMacSN_CheckedChanged(object sender, EventArgs e)
    {
      txtMacSN.Enabled = chkMacSN.Checked;
      if (txtMacSN.Enabled && (txtMacSN.Text == "")) txtMacSN.Text = "3";
    }

    private void chkEmpNo_CheckedChanged(object sender, EventArgs e)
    {
      txtEmpNo.Enabled = chkEmpNo.Checked;
      if (txtEmpNo.Enabled && (txtEmpNo.Text == "")) txtEmpNo.Text = "10";
    }

    private void chkEmpName_CheckedChanged(object sender, EventArgs e)
    {
      txtEmpName.Enabled = chkEmpName.Checked;
      if (txtEmpName.Enabled && (txtEmpName.Text == "")) txtEmpName.Text = "10";
    }

    private void chkCardNo_CheckedChanged(object sender, EventArgs e)
    {
      txtCardNo.Enabled = chkCardNo.Checked;
      if (txtCardNo.Enabled && (txtCardNo.Text == "")) txtCardNo.Text = "10";
    }

    private void chkDataTime_CheckedChanged(object sender, EventArgs e)
    {
      txtDataTime.Enabled = chkDataTime.Checked;
      if (txtDataTime.Enabled && (txtDataTime.Text == "")) txtDataTime.Text = "yyyyMMddHHmmss";
    }

    private void btnOrderUp_Click(object sender, EventArgs e)
    {
      string s;
      int i;
      if (chkOrder.SelectedIndex == -1) chkOrder.SelectedIndex = chkOrder.Items.Count - 1;
      i = chkOrder.SelectedIndex;
      if (i == 0) return;
      s = chkOrder.Items[i].ToString();
      chkOrder.Items[i] = chkOrder.Items[i - 1];
      chkOrder.Items[i - 1] = s;
      chkOrder.SelectedIndex = i - 1;
    }

    private void btnOrderDown_Click(object sender, EventArgs e)
    {
      string s;
      int i;
      if (chkOrder.SelectedIndex == -1) chkOrder.SelectedIndex = 0;
      i = chkOrder.SelectedIndex;
      if (i == chkOrder.Items.Count - 1) return;
      s = chkOrder.Items[i].ToString();
      chkOrder.Items[i] = chkOrder.Items[i + 1];
      chkOrder.Items[i + 1] = s;
      chkOrder.SelectedIndex = i + 1;
    }

    private void btnShowFormat_Click(object sender, EventArgs e)
    {
      textFormat = new KQTextFormatInfo(GetFieldsString());
      txtFormat.Text = textFormat.GetKQFormatText("1", "E0001", "ZhangSan", "1", DateTime.Now);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string fmt = GetFieldsString();
      string msg = Pub.GetResText(formCode, "MsgSaveSucceed", "");
      if (SystemInfo.db.WriteConfig(KQTextFormatInfo.KQ_ConfigID, KQTextFormatInfo.KQ_TextFormat, fmt))
      {
        SystemInfo.db.WriteSYLog(this.Text, CurrentOprt, msg);
        //Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private byte GetFieldTag(string Name)
    {
      byte ret = 0;
      for (byte i = 0; i < chkOrder.Items.Count; i++)
      {
        if (chkOrder.Items[i].ToString() == Name)
        {
          ret = i;
          break;
        }
      }
      return ret;
    }

    private string GetFieldsString()
    {
      string ret = "";
      byte Flag = 0;
      string Sep = "";
      if (rbSepNo.Checked)
        Flag = 0;
      else if (rbSepTAB.Checked)
        Flag = 1;
      else
      {
        Flag = 2;
        Sep = txtSep.Text;
      }
      ret = string.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}#{10}#{11}#{12}#{13}#{14}#{15}#{16}#{17}", 
        Convert.ToByte(chkAllow.Checked), Flag, Sep,
        Convert.ToByte(chkMacSN.Checked), txtMacSN.Text, GetFieldTag(chkMacSN.Text), 
        Convert.ToByte(chkEmpNo.Checked), txtEmpNo.Text, GetFieldTag(chkEmpNo.Text), 
        Convert.ToByte(chkEmpName.Checked), txtEmpName.Text, GetFieldTag(chkEmpName.Text), 
        Convert.ToByte(chkCardNo.Checked), txtCardNo.Text, GetFieldTag(chkCardNo.Text), 
        Convert.ToByte(chkDataTime.Checked), txtDataTime.Text, GetFieldTag(chkDataTime.Text));
      return ret;
    }
  }
}