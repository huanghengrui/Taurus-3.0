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
  public partial class frmFKFirmwareVer : frmBaseDialog
  {
    public string SelectVer = "";
    public string USBFile = "";

    private bool IsDown = false;

    private const string fn1 = "Reg.dat";
    private const string fn2 = "plu001.dat";
    private string USBPath = "";

    protected override void InitForm()
    {
      SelectVer = "";
      USBFile = "";
      formCode = "FKFirmwareVer";
      base.InitForm();
      this.Text = Title;
      dlgOpen.Filter = Pub.GetResText(formCode, "FilterUSBF", "") + "(*.dat)|*.dat";
      dlgSave.Filter = Pub.GetResText(formCode, "FilterUSBF", "") + "(*.dat)|*.dat";
      USBPath = SystemInfo.AppPath;
      cbbVer.Items.Clear();
      TIDAndName id = new TIDAndName("HS001", "HS001[NEO]");
      cbbVer.Items.Add(id);
      id = new TIDAndName("HS002", "HS002[NEO]");
      cbbVer.Items.Add(id);
      id = new TIDAndName("HS101", "HS101[PRO]");
      cbbVer.Items.Add(id);
      cbbVer.SelectedIndex = 0;
    }

    public frmFKFirmwareVer(string title, bool isDown)
    {
      Title = title;
      IsDown = isDown;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string s1 = ((TIDAndName)cbbVer.Items[cbbVer.SelectedIndex]).id;
      string s2 = txtFile.Text.Trim();
      if (s1 == "")
      {
        cbbVer.Focus();
        ShowErrorSelectCorrect(label1.Text);
        return;
      }
      if (s2 == "")
      {
        button1.Focus();
        ShowErrorSelectCorrect(label2.Text);
        return;
      }
      SelectVer = s1;
      USBFile = s2;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (IsDown)
      {
        if (dlgOpen.ShowDialog() == DialogResult.OK) txtFile.Text = dlgOpen.FileName;
      }
      else
      {
        string path = Pub.SelectDBPath(true, true, SystemInfo.AppPath);
        if (path != "")
        {
          USBPath = path;
          cbbVer_SelectedIndexChanged(null, null);
        }
        //if (dlgSave.ShowDialog() == DialogResult.OK) txtFile.Text = dlgSave.FileName;
      }
    }

    private void cbbVer_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (IsDown) return;
      switch (cbbVer.SelectedIndex)
      {
        case 0:
        case 1:
          txtFile.Text = USBPath + fn1;
          break;
        case 2:
          txtFile.Text = USBPath + fn2;
          break;
      }
    }
  }
}