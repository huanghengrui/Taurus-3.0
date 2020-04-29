using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using DevComponents.DotNetBar;
//using DAO = Microsoft.Office.Interop.Access.Dao;
using System.Diagnostics;

namespace Taurus
{
    public partial class frmLogin : frmBaseDialog
    {
        private bool IsRePassword = false;
        private string RePassword = "";
        private string DBAppDate = "";
        private string DBAppVer = "";
        private DateTime appLastWriteTime = new DateTime();

        private void CompareFileTime(string fileName)
        {
            if (File.Exists(fileName))
            {
                DateTime dtTime = Pub.GetFileTime(fileName);
                if (dtTime > appLastWriteTime) appLastWriteTime = dtTime;
            }
        }

        private bool ShowDBConnect()
        {
            bool ret = false;
            if (new frmDBConnect().ShowDialog() == DialogResult.OK)
            {
                SystemInfo.IsRestart = true;
                this.Close();
                ret = true;
            }
            return ret;
        }

        protected override void InitForm()
        {
            formCode = "Login";
            Icon icon = this.Icon;
            btnConnect.Visible = false;
            base.InitForm();
            lbTitlte.Text = this.Text;
            Icon = icon;
            btnConnect.Visible = SystemInfo.DBType == 1;
            btnConnect.Enabled = btnConnect.Visible;
            appLastWriteTime = Pub.GetFileTime(Application.ExecutablePath);
            SystemInfo.ConnStr = GetConnStr();
            if ((SystemInfo.DBType == 1) && (DBServerInfo.ServerName == ""))
            {
                if (ShowDBConnect()) return;
            }

            SystemInfo.ConnStrReport = GetConnStrReport();
           
            LoadData();

            IsRePassword = SystemInfo.ini.ReadIni("Public", "IsRePassword", false);
            RePassword = SystemInfo.ini.ReadIni("Public", "RePassword", "");
            chkPass.Checked = IsRePassword;
            if (IsRePassword) txtPass.Text = Pub.GetOprtDecrypt(RePassword);
            if (SystemInfo.LangName == "CHS" || SystemInfo.LangName == "CHT")
            {
                lblTitle.Font = new Font(Font.Name, 20, FontStyle.Bold);
                lblVersion.Font = new Font(Font.Name, 10, FontStyle.Bold);
            }
            else
            {
                lblTitle.Font = new Font(Font.Name, 16, FontStyle.Bold);
                lblVersion.Font = new Font(Font.Name, 10, FontStyle.Bold);
            }

            lblTitle.Text = SystemInfo.AppTitle;
            label1.Font = lblTitle.Font;
            label1.Text = lblTitle.Text;
            float size = 20;
            while (label1.Width > lblTitle.Width)
            {
                label1.Font = new Font(Font.Name, size, FontStyle.Bold);
                size = size - (float)0.5;
            }
            lblTitle.Font = label1.Font;
            lblVersion.Text = SystemInfo.AppVersion;
            lblHint.ForeColor = Color.Blue;
            lblTitle.ForeColor = Color.Red;
            lblVersion.ForeColor = Color.Blue;
            
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ShowDBConnect();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            #region 检测是否安装Access驱动
            //try
            //{
            //    if (SystemInfo.DBType == 0 || SystemInfo.DBType == 255)
            //    {
            //        DAO.DBEngine dbEngine = new DAO.DBEngine();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Pub.ShowErrorMsg(ex, Pub.GetResText("", "AccessEorror", ""));

            //    Process process = new Process();
            //    process.StartInfo.FileName = SystemInfo.AppPath + "AccessDatabaseEngine.exe";
            //    process.StartInfo.UseShellExecute = false;
            //    process.StartInfo.RedirectStandardOutput = false;
            //    process.StartInfo.RedirectStandardInput = true;
            //    process.StartInfo.CreateNoWindow = false;
            //    process.Start();
            //    process.WaitForExit();
            //    process.Close();
            //}
            #endregion
            if (!SystemInfo.db.CheckAppIsNewVer(true, DBAppVer))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Error001", ""), DBAppVer));
                return;
            }
            TOprtObject obj = (TOprtObject)cbbOpter.Items[cbbOpter.SelectedIndex];
            string OprtNo = obj.Value;
            string OprtPWD = Pub.GetOprtEncrypt(txtPass.Text.Trim());
            string PWD = OprtPWD;
            if (PWD == "") PWD = Pub.GetOprtEncrypt("0");
            DataTableReader dr = null;
            bool IsOk = false;
            string Pass = "";
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "2", OprtNo }));
                dr.Read();
                Pass = dr["OprtPWD"].ToString();
                if (Pass != OprtPWD && Pass != PWD)
                {
                    txtPass.Focus();
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
                }
                else
                    IsOk = true;
                if (IsOk)
                {
                    OprtInfo.OprtNo = OprtNo;
                    OprtInfo.OprtIsSys = (dr["OprtIsSys"].ToString() == "1");
                    OprtInfo.OprtNoAndName = cbbOpter.Text;
                    SystemInfo.ini.WriteIni("Public", "OprtNo", OprtInfo.OprtNo);
                    if (chkPass.Checked)
                    {
                        SystemInfo.ini.WriteIni("Public", "IsRePassword", chkPass.Checked);
                        SystemInfo.ini.WriteIni("Public", "RePassword", OprtPWD);
                    }
                    else
                    {
                        SystemInfo.ini.WriteIni("Public", "IsRePassword", "");
                        SystemInfo.ini.WriteIni("Public", "RePassword", "");
                    }

                    dr.Close();
                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "3", OprtNo }));
                    dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "4" }));
                    if (dr.Read())
                    {
                        SystemInfo.CommanyName = dr["DepartName"].ToString();
                        SystemInfo.CommanyID = dr["DepartID"].ToString();
                    }
                }
            }
            catch (Exception E)
            {
                IsOk = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsOk)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void LoadData()
        {
            string DefNo = SystemInfo.ini.ReadIni("Public", "OprtNo", "");
            DataTableReader dr = null;
            TOprtObject objOprt;
            string DBPath = "";
            string DBName = SystemInfo.NameSpace;
            string sql = "";
            cbbOpter.Items.Clear();
            try
            {
                if (SystemInfo.DBType == 0)
                {
                    if (!File.Exists(SystemInfo.AccessDB))
                    {
                        Pub.ShowMessageForm(Pub.GetResText("", "MsgCreating", ""));
                        SystemInfo.objAC.CreateDatabase();
                        SystemInfo.db.Open(SystemInfo.ConnStr);
                        SystemInfo.db.UpdateDatabase(SystemInfo.AppTitle, new DateTime());
                    }
                }
                else if (SystemInfo.DBType == 1 || SystemInfo.DBType == 2)
                {
                    if (SystemInfo.db.IsOpen) SystemInfo.db.Close();
                    SystemInfo.db.Open(Pub.GetMSSQLConnStr(DBServerInfo.ServerName, DBServerInfo.WindowsNT,
                      DBServerInfo.UserName, DBServerInfo.UserPass, "master"));//打开数据库
                    dr = SystemInfo.db.GetDataReader("SELECT * FROM sysdatabases WHERE name='" + SystemInfo.NameSpace + "'");//查询数据库信息
                    if (!dr.Read())
                    {
                        Pub.ShowMessageForm(Pub.GetResText("", "MsgCreating", ""));
                        DBPath = SystemInfo.db.GetDatabasePath().ToString();
                        string mdfFile = DBPath + DBName + ".mdf";
                        string ldfFile = DBPath + DBName + ".ldf";
                        if (File.Exists(mdfFile) && File.Exists(ldfFile))
                            sql = "EXEC sp_attach_db '" + DBName + "','" + mdfFile + "','" + ldfFile + "'"; //将数据库附加到服务器
                        else if (File.Exists(mdfFile))
                            sql = "EXEC sp_attach_single_file_db '" + DBName + "','" + mdfFile + "'";  //恢复数据库
                        else
                            sql = "CREATE DATABASE " + DBName + " ON(NAME='" + DBName + "_Data', FILENAME='" + mdfFile +
                              "') LOG ON(NAME='" + DBName + "_Log',FILENAME='" + ldfFile + "')";       //创建数据库
                        SystemInfo.db.ExecSQL(sql);
                        SystemInfo.db.Close();
                        SystemInfo.db.Open(SystemInfo.ConnStr);
                        SystemInfo.db.UpdateDatabase(SystemInfo.AppTitle, new DateTime());
                    }
                    dr.Close();
                    SystemInfo.db.Close();
                }
                if (!SystemInfo.db.IsOpen) SystemInfo.db.Open(SystemInfo.ConnStr);
                CheckDBUpdate();
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "1" }));
                while (dr.Read())
                {
                    objOprt = new TOprtObject();
                    objOprt.Name = dr["OprtName"].ToString();
                    objOprt.Value = dr["OprtNo"].ToString();
                    objOprt.Text = objOprt.Value + "[" + objOprt.Name + "]";
                    cbbOpter.Items.Add(objOprt);
                    if ((DefNo != "") && (objOprt.Value == DefNo)) cbbOpter.SelectedIndex = cbbOpter.Items.Count - 1;
                }
                dr.Close();
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                Pub.FreeMessageForm();
                if (dr != null) dr.Close();
                dr = null;
            }
            if ((cbbOpter.SelectedIndex == -1) && (cbbOpter.Items.Count > 0)) cbbOpter.SelectedIndex = 0;
            btnOk.Enabled = (cbbOpter.SelectedIndex >= 0);
        }

        private void CheckDBUpdate()
        {
            DataTableReader dr = null;
            DateTime dt = new DateTime();
            try
            {
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "0" }));
                if (dr.Read())
                {
                    DBAppDate = dr["AppVer"].ToString();
                    SystemInfo.DBVersion = dr["DBVer"].ToString() + ".";
                    dt = Convert.ToDateTime(dr["DBDate"]);
                }
                SystemInfo.DBVersion = SystemInfo.DBVersion + dt.ToString(SystemInfo.DateFormatDBVer);
                SystemInfo.DBDate = dt;
                SystemInfo.db.ReadSystemConfig();
                SystemInfo.db.UpdateDatabase(this.Text, dt);
                dr = SystemInfo.db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "0" }));
                if (dr.Read())
                {
                    SystemInfo.DBVersion = dr["DBVer"].ToString() + ".";
                    dt = Convert.ToDateTime(dr["DBDate"]);
                    SystemInfo.DBVersion = SystemInfo.DBVersion + dt.ToString(SystemInfo.DateFormatDBVer);
                    DBAppVer = dr["AppVer"].ToString();
                }
                if ((DBAppVer == "") || (SystemInfo.db.CheckAppIsNewVer(DBAppVer)))
                {
                    DBAppVer = Application.ProductVersion;
                    SystemInfo.db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "5", DBAppVer }), true);
                }
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
        }
    }

    public class TOprtObject
    {
        private string _text = "";
        private string _name = "";
        private string _value = "";

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}