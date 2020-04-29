using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmBaseMDIChildTree : frmBaseMDIChild
    {
        protected string otherCoin = "";
        protected bool IsInit = false;
        protected bool InitEmp = false;

        protected override void InitForm()
        {
            this.Hide();
            IsInit = true;
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            // SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemAdd", false);
            IgnoreSelect = true;
            lblRecordState.Visible = false;

            base.InitForm();
            if (IgnoreDimission) otherCoin = Pub.GetSQL(DBCode.DB_000101, new string[] { "208" });
            InitDepartTreeView(tvEmp, InitEmp, otherCoin);
            IsInit = false;
            this.Show();
        }
      
        public frmBaseMDIChildTree()
        {
            InitializeComponent();
          
        }
    }
}