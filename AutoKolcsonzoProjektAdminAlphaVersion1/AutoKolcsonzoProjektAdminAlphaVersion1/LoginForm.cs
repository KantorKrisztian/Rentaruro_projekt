using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            LoginBtn.Click += (object s, EventArgs e) => formShow();
            LoginPassTb.PasswordChar = '*';

            ShowPB.ImageLocation = "E:\\git\\13\\13-projekt\\képek\\eye.png";
            ShowPB.Click += showPassword;
        }
        void closeForm(object s, EventArgs e)
        {
            Application.Exit();
        }
        HttpRequests httpRequests = new HttpRequests();
        async void formShow()
        {

            bool loginSuccess = await httpRequests.Login(LoginUserTb.Text, LoginPassTb.Text);
            if (loginSuccess)
            {
                Form1 carForm = new Form1();
                this.Hide();
                carForm.Show();
                carForm.FormClosing += closeForm;
                carForm.ExitLabel.Click += exitForm;
                LoginUserTb.Text = "";
                LoginPassTb.Text = "";
                void exitForm(object s, EventArgs e)
                {
                    this.Show();
                    carForm.Hide();
                    Token.token = "";
                    Token.role = "";
                }
            }
        }

        void showPassword(object s, EventArgs e)
        {
            if (LoginPassTb.PasswordChar == '*')
            {
                LoginPassTb.PasswordChar = '\0';
                ShowPB.ImageLocation = "E:\\git\\13\\13-projekt\\képek\\hidden.png";
            }
            else
            {
                LoginPassTb.PasswordChar = '*';
                ShowPB.ImageLocation = "E:\\git\\13\\13-projekt\\képek\\eye.png";
            }
        }
    }
}
