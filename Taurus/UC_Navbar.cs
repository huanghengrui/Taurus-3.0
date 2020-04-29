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
    public partial class UC_Navbar : UserControl
    {
        private int startWidth = 0;
        private int endWidth = 0;
        private bool isMove = false;
        public bool isPanelMuenVisible = false;
        public UC_Navbar()
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

        private void LableX_MouseEnter(object sender, EventArgs e)
        {
            Control item = (DevComponents.DotNetBar.LabelX)sender;
            item.BackColor = Color.FromArgb(105, 191, 255);
            item.ForeColor = Color.Black;
            if(item.Name == "sNIColse")
            {
                sNIColse.BackColor = Color.Red;
                sNIColse.ForeColor = Color.White;
            }
           
        }

        private void LableX_MouseLeave(object sender, EventArgs e)
        {
            Control item =  sender as DevComponents.DotNetBar.LabelX;
            item.BackColor = Color.FromArgb(1, 115, 199);
            item.ForeColor = Color.White;
        }


        private void sNIColse_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
