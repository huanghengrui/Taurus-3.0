using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taurus
{
    public partial class frmBaseDialog : frmBaseForm
    {
        protected string Title = "";
        protected string SysID = "";
        protected string CurrentOprt = "";
        public bool beginMove = false;
        public int currentXPosition = 0;
        public int currentYPosition = 0;
        public frmBaseDialog()
        {
            InitializeComponent();
        }
        private void btnClosess_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void panTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove && e.Button == MouseButtons.Left)
            {
                int lx = MousePosition.X - currentXPosition;
                int ty = MousePosition.Y - currentYPosition;
                if (Math.Abs(lx) > 10 || Math.Abs(ty) > 10)
                {
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.Left += lx;//根据鼠标x坐标确定窗体的左边坐标x
                    this.Top += ty;//根据鼠标的y坐标窗体的顶部，即Y坐标
                    currentXPosition = MousePosition.X;
                    currentYPosition = MousePosition.Y;
                }

            }
        }

        private void panTitle_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }

        private void btnClosess_MouseEnter(object sender, EventArgs e)
        {
            btnClosess.SymbolColor = Color.Red;
        }

        private void btnClosess_MouseLeave(object sender, EventArgs e)
        {
            btnClosess.SymbolColor = Color.White;
        }

        private void frmBaseDialog_Load(object sender, EventArgs e)
        {
            lbTitlte.Text = this.Text;
        }
    }
}
