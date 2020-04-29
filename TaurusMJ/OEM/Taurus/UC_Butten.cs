using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class UC_Butten : UserControl
    {
        public UC_Butten()
        {
            InitializeComponent();
        }

        [Description("图标"),Category("自定义")]
        public string UCSymbol
        {
            get { return btnUc.Symbol;}
            set { btnUc.Symbol = value; }
        }
    }
}
