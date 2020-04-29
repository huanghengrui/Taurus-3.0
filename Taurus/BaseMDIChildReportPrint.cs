using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmBaseMDIChildReportPrint : frmBaseMDIChildReport
    {
        protected bool IsInitBaseForm = false;

        protected override void InitForm()
        {
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemDelete", false);
            //SetToolItemState("ItemLine2", false);
            IgnoreSelect = true;
            IgnoreRefreshFirst = true;
            if (IsInitBaseForm) base.InitForm();
            RefreshForm(true);
        }

        public frmBaseMDIChildReportPrint()
        {
            InitializeComponent();
        }
    }
}