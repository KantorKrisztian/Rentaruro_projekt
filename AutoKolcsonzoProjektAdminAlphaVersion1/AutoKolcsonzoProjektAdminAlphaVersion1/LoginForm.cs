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
        Form1 carForm = new Form1();
        public LoginForm()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            LoginBtn.Click += (object s, EventArgs e)=> formShow();
            carForm.FormClosing += closeForm;
            carForm.ExitLabel.Click += exitForm;
            button1.Click += register;
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
                this.Hide();
                carForm.Show();
                LoginUserTb.Text = "";
                LoginPassTb.Text = "";
            }

            

        }
        void register(object s, EventArgs e)
        {
            httpRequests.Registration(LoginUserTb.Text, LoginPassTb.Text);
        }
        void exitForm(object s, EventArgs e)
        {
            this.Show();
            carForm.Hide();
        }
    }
}
