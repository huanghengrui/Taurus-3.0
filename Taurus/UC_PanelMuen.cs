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
    public partial class UC_PanelMuen : UserControl
    {
        private int startWidth = 0;
        private int endWidth = 0;
        private bool isMove = false;
       
        [Description("按钮点击事件"), Category("自定义")]
        public event EventHandler CloseClick;
        public event EventHandler AutoClick;

        public UC_PanelMuen()
        {
            InitializeComponent();
        }

        private void splitter_MouseDown(object sender, MouseEventArgs e)
        {
            startWidth = e.X;
            isMove = true;
        }

        private void splitter_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                endWidth = e.X;
                this.Width = this.Width + endWidth - startWidth;
            }
        }

        private void splitter_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void btnClosePanel_Click(object sender, EventArgs e)
        {
            if (this.CloseClick != null)
                CloseClick(this, e);
        }

        private void btnAutoHide_Click(object sender, EventArgs e)
        {
            if (this.AutoClick != null)
                AutoClick(this, e);
        }

        private void LableX_MouseEnter(object sender, EventArgs e)
        {
            Control item = (DevComponents.DotNetBar.LabelX)sender;
            item.BackColor = Color.FromArgb(105, 191, 255);
            item.ForeColor = Color.Black;
        }

        private void LableX_MouseLeave(object sender, EventArgs e)
        {
            Control item = sender as DevComponents.DotNetBar.LabelX;
            item.BackColor = Color.FromArgb(1, 115, 199);
            item.ForeColor = Color.White;
        }
    }
}
