using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Taurus
{
  public partial class frmAbout : frmBaseDialog
  {
    private string GetFileInfo(string fileName)
    {
      string ret = "";
      if (File.Exists(fileName))
      {
        string fileTime = Pub.GetFileTimeString(fileName);
        FileVersionInfo fileVer = FileVersionInfo.GetVersionInfo(fileName);
        ret = fileVer.ProductVersion;
        if (ret == null) ret = "";
        if (ret == "")
          ret = fileTime;
        else
        {
          ret = ret.Replace(" ", "");
          ret = ret.Replace(',', '.');
          ret = ret + "(" + fileTime + ")";
        }
        ret = Pub.GetFileName(fileName) + ":  " + ret + "\r\n";
      }
      return ret;
    }

    protected override void InitForm()
    {
      formCode = "About";
      base.InitForm();
      this.Text = Title + " " + SystemInfo.AppTitle;
      string grPath = Pub.GetObjFilePath("grdes.DesignerProps");
      string fileInfo = Pub.GetResText(formCode, "Version", "") + ":  " + SystemInfo.AppVersion + "(" +
        Pub.GetFileTimeString(Application.ExecutablePath).ToString() + ")\r\n" +
        Pub.GetResText(formCode, "DBVersion", "") + ":  " + SystemInfo.DBVersion + "\r\n"+
        GetFileInfo(grPath + "grdes50.dll") + GetFileInfo(grPath + "gregn50.dll") +
        GetFileInfo(grPath + "FK623Attend.dll") + GetFileInfo(grPath + "FKAttend.dll") +
        GetFileInfo(grPath + "FKViaDev.dll") + GetFileInfo(grPath + "FpDataConv.dll") +
        GetFileInfo(grPath + "LFWViaDev.dll") + GetFileInfo(grPath + "RealSvrOcxTcp.ocx");
      txtInfo.Text = fileInfo.Trim();
      string oem = SystemInfo.ini.ReadIni("Public", "OemInfo", "");
      oem = oem.Replace("\\r\\n", "\r\n");
      lblOem.Text = oem;
    }

    public frmAbout(string title)
    {
      Title = title;
      InitializeComponent();
    }
  }
}