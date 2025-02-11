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
            LoginBtn.Click += formShow;
            carForm.FormClosing += closeForm;
            carForm.ExitLabel.Click += exitForm;
            carForm.ExitLabel.MouseHover += hover;
        }
        void hover(object s, EventArgs e)
        {
            
        }
        void closeForm(object s, EventArgs e)
        {
            Application.Exit();
        }
        void formShow(object s, EventArgs e)
        {
            carForm.Show();
            this.Hide();
        }
        void exitForm(object s, EventArgs e)
        {
            this.Show();
            carForm.Hide();
        }
    }
}
