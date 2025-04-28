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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            personalInfos1.Hide();
            rentCar1.Hide();
            RentLabel.Click += showRentedCars;
            CarsLabel.Click += showCars;
            WorkersLabel.Click += showWorkers;
            if (Token.role.ToLower() == "admin")
            {
                WorkersLabel.Visible = true;
            }
            else
            {
                WorkersLabel.Visible = false;
            }
        }
        void showRentedCars(object s, EventArgs e)
        {
            rentCar1.Show();
            addCar1.Hide();
            personalInfos1.Hide();
        }
        void showCars(object s, EventArgs e)
        {
            rentCar1.Hide();
            personalInfos1.Hide();
            addCar1.Show();
        }
        void showWorkers(object s, EventArgs e)
        {
            rentCar1.Hide();
            addCar1.Hide();
            personalInfos1.Show();
        }
    }
}
