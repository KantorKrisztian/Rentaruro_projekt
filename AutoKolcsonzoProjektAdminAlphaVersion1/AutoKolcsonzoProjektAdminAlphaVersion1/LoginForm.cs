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
        string file = "";
        public LoginForm()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            LoginBtn.Click += (object s, EventArgs e) => formShow();
            LoginPassTb.PasswordChar = '*';

            string filePath = this.GetType().Assembly.Location;
            string[] filePathSplit = filePath.Split('\\');
            
            for (int i = 0; i < filePathSplit.Length - 5; i++)
            {
                file += filePathSplit[i] + "\\";
            }
            ShowPB.ImageLocation = file+"\\képek\\eye.png";
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
                ShowPB.ImageLocation = file+"\\képek\\hidden.png";
            }
            else
            {
                LoginPassTb.PasswordChar = '*';
                ShowPB.ImageLocation = file+"\\képek\\eye.png";
            }
        }
    }
}
