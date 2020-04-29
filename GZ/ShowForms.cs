using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
  public class ShowForms
  {
    private const string formCode = "Main";
    private FuncObject FormsList = new FuncObject();

    private void SubAdd(string Name, byte IsLine, bool IsTool)
    {
      FormsList.SubAdd(Name, SystemInfo.res.GetResText(formCode, "mnu" + Name, ""), IsLine, IsTool);
    }

    private void SubAdd(string Name, byte IsLine)
    {
      SubAdd(Name, IsLine, false);
    }

    public FuncObject GetFormsList()
    {
      FormsList.Name = "GZ";
      FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
      SubAdd("GZRule", 0);
      SubAdd("GZItem", 0);
      SubAdd("GZRuleEmp", 0);
      SubAdd("GZRuleDepart", 0);
      SubAdd("GZReport", 1, true);
      return FormsList;
    }

    public Form GetForm(string frmName)
    {
      Form ret = null;
      switch (frmName)
      {
        case "GZItem":
          ret = new frmGZItem();
          break;
        case "GZRule":
          ret = new frmGZRule();
          break;
        case "GZRuleEmp":
          ret = new frmGZRuleEmp();
          break;
        case "GZRuleDepart":
          ret = new frmGZRuleDepart();
          break;
        case "GZReport":
          ret = new frmGZReport();
          break;
      }
      return ret;
    }
  }
}