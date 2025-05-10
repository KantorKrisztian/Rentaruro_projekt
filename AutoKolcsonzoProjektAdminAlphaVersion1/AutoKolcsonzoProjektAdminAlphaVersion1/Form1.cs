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
        public PersonalInfos personalInfos1= new PersonalInfos();
        public RentCar rentCar1 = new RentCar();
        public AddCar addCar1 = new AddCar();
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            this.Controls.Add(personalInfos1);
            this.Controls.Add(rentCar1);
            this.Controls.Add(addCar1);

            addCar1.Top = 30;
            rentCar1.Top = 30;
            personalInfos1.Top = 30;
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
