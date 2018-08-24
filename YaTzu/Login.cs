using Bunifu.Framework.UI;
using System.Application.Common;
using System.Framework;
using System.DataLayer.Entities;
using System.DataLayer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YaTzu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            APConfig.LoadConfig();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(checkSubmit()))
            {
                Account entAccount = new Account(APConfig.Conn);
                entAccount.ACT_SERNO = My.GenSerNo();
                entAccount.ACT_NAME = txtName.Text;
                entAccount.ACT_ACCOUNT = txtAccount.Text;
                entAccount.ACT_PASSWORD = txtPassword.Text;
                entAccount.ACT_CREATEDTTM = DateTime.Now;
                entAccount.insert();
                APConfig.SweetAlert(ShowBoxType.alert, "新增完成!");
            }
        }

        private string checkSubmit()
        {
            string msg = "";
            string pattern = @"^[a-zA-Z0-9]+$"; //判斷只有英文數字  
            bool isEmpty = false;

            foreach (Control pages in this.Controls)
            {
                if(pages is Panel)
                {
                    Panel panel = pages as Panel;
                    if (panel.Name.ToString() == "panelSubmit")
                    {
                        foreach (Control c in pages.Controls)
                        {
                            if (c is BunifuMetroTextbox)
                            {
                                BunifuMetroTextbox textBox = c as BunifuMetroTextbox;
                                if (textBox.Text == string.Empty)
                                {
                                    msg = "欄位不能為空值!";
                                    isEmpty = true;
                                }
                                else if (!Regex.Match(textBox.Text, pattern).Success)
                                {
                                    msg = "欄位內容只能包含英文數字!";
                                    isEmpty = true;
                                }
                            }
                        }
                    }
                }
            }

            if(!isEmpty && txtPassword.Text != txtPassword2.Text)
            {
                msg = "密碼輸入不相同!";
            }

            if(!string.IsNullOrEmpty(msg))
            {
                APConfig.SweetAlert(ShowBoxType.alert, msg);
            }
            return msg;
        }

        private bool checkLogin()
        {
            string msg = "";
            string pattern = @"^[a-zA-Z0-9]+$"; //判斷只有英文數字  

            if (!Regex.Match(txtLoginAccount.Text, pattern).Success || !Regex.Match(txtLoginPassword.Text, pattern).Success)
            {
                APConfig.SweetAlert(ShowBoxType.alert, "欄位內容只能包含英文數字!");
                return false;
            }
            return true;
        }

        private void lbBackLogin_Click(object sender, EventArgs e)
        {
            panelSubmit.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            if (checkLogin())
            {
                AccountInfo view = new AccountInfo(APConfig.Conn);
                view.Conditions = view.getCondition(AccountInfo.ncConditions.ACCOUNT.ToString(), txtLoginAccount.Text);
                if (view.load())
                {
                    if (view.ACT_PASSWORD != txtLoginPassword.Text)
                    {
                        APConfig.SweetAlert(ShowBoxType.alert, "密碼錯誤!");
                    }
                    else
                    {
                        APConfig.AccountName = view.ACT_NAME;
                        APConfig.SweetAlert(ShowBoxType.alert, string.Format("歡迎使用!\r\n{0}", view.ACT_NAME));
                        this.Hide();
                        Main form = new Main();
                        form.ShowDialog();
                        this.Close();
                    }
                }
                else
                    APConfig.SweetAlert(ShowBoxType.alert, "查無此帳號!");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            panelSubmit.Visible = true;
        }

        private void txtLoginPassword_Enter(object sender, EventArgs e)
        {
            txtLoginPassword.isPassword = true;
        }

        #region 移動介面 (Border Style = none)
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion

        #region 待改進
        private void txtAccount_Leave(object sender, EventArgs e)
        {
            if (txtAccount.Text == "")
            {
                txtAccount.Text = "請輸入帳號";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {

        }

        private void txtPassword2_Leave(object sender, EventArgs e)
        {

        }

        private void txtName_Leave(object sender, EventArgs e)
        {

        }

        private void txtAccount_Enter(object sender, EventArgs e)
        {
            if (txtAccount.Text == "請輸入帳號")
            {
                txtAccount.Text = "";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "請輸入密碼")
            {
                txtPassword.Text = "";
                txtPassword.isPassword = true;
            }
        }

        private void txtPassword2_Enter(object sender, EventArgs e)
        {
            if (txtPassword2.Text == "請確認密碼")
            {
                txtPassword2.Text = "";
                txtPassword2.isPassword = true;
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "請輸入名稱")
            {
                txtName.Text = "";
            }
        }
        #endregion

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
