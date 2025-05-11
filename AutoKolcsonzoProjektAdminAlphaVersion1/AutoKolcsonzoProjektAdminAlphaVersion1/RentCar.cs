using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    public class RentCar:UserControl
    {
        private DataGridView InfoDGV;
        private Panel RentPanel;
        private DataGridView HeaderDGV;
        private Label OtherInfoLabel;
        private TextBox OtherInfoLabelTB;
        private Button UpdateRentBtn;
        private Label TimeHeaderLabel;
        private Label LicensePlateHeaderLabel;
        private Label CarHeaderLabel;
        private Label UserHeaderLabel;
        private Label NameHeaderLabel;
        private Label EmailHeaderLabel;
        private Label PhoneHeaderLabel;
        private Label RentLabel;

        public List<jsonRents> AllRents = new List<jsonRents>();
        private MonthCalendar StartEndCalendar;
        private Label InfoHeaderLabel;
        private Label UserLabel;
        private Label EmailLabel;
        private Label PhoneLabel;
        private Label NameLabel;
        private Label BrandLabel;
        private Label LicensePlateLabel;
        private Button CancleBtn;
        HttpRequests httpRequests = new HttpRequests();
        public RentCar()
        {
            InitializeComponent();
            Start();
        }
        public async void Start()
        {
            //Setting the update button to call the UpdateRent method when clicked
            UpdateRentBtn.Click += (s, e) => { UpdateRent(); };
            //Setting the calendar to select a range of dates
            StartEndCalendar.MaxSelectionCount=int.MaxValue;
            RentPanel.AutoScroll = true;
            //Getting the list of all rents from the server
            AllRents = await httpRequests.ListAllRents();
            OrderList();
            CancleBtn.Click += (s, e) => { Clear(); };
            RentList();
        }
        //Update the rent information
        public async void UpdateRent()
        {
            try
            {
                if (AllRents == null)
                {
                    MessageBox.Show("Nincs autó a rendszerben");
                    return;
                }
                jsonRents rent = new jsonRents();
                rent.id = Convert.ToInt32(UpdateRentBtn.Tag);
                rent.start = StartEndCalendar.SelectionRange.Start;
                rent.end = StartEndCalendar.SelectionRange.End;
                rent.other = OtherInfoLabelTB.Text;
                foreach (jsonRents item in AllRents)
                {
                    if (item.id==rent.id)
                    {
                        rent.carId =item.carId;
                    }
                }

                bool succes = await httpRequests.UpdateRent(rent);
                if (!succes)
                {
                    return;
                }
                AllRents = await httpRequests.ListAllRents();
                RentList();
                Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //Lists all the rents in the panel
        async void RentList()
        {
            
            try
            {
                if (AllRents == null)
                {
                    return;
                }
                int count = 0;
                RentPanel.Controls.Clear();
                foreach (jsonRents item in AllRents)
                {
                    count++;
                    OneRent rent = new OneRent();
                    rent.StartLabel.Text = item.start.ToShortDateString();
                    rent.EndLabel.Text = item.end.ToShortDateString();
                    rent.LicensePlateLabel.Text = item.licensePlate;
                    rent.BrandLabel.Text = item.brand;
                    rent.TypeLabel.Text = item.type;
                    rent.UserLabel.Text = item.username;
                    rent.NameLabel.Text = item.name;
                    rent.EmailLabel.Text = item.email;
                    rent.PhoneLabel.Text = item.phone;
                    rent.InfoLabel.Text = item.other;
                    
                    RentPanel.Controls.Add(rent);
                    rent.Top = (count - 1) * rent.Height;
                    rent.DeleteBtn.Click +=async (s, e) =>
                    {
                        DialogResult result = MessageBox.Show("Biztosan törölni szeretné a foglalást?", "Törlés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result==DialogResult.Yes)
                        {
                            AllRents = await httpRequests.DeleteRent(item.id);
                            RentList();
                        }
                    };
                    rent.UpdateBtn.Click += (s, e) =>
                    {
                        OtherInfoLabelTB.Text = item.other;
                        StartEndCalendar.SetDate(item.start);
                        StartEndCalendar.SetSelectionRange(item.start, item.end);
                        LicensePlateLabel.Text ="Rendszám: " +item.licensePlate;
                        BrandLabel.Text = "Márka: " + item.brand;
                        NameLabel.Text = "Név: " + item.name;
                        UserLabel.Text = "Felhasználónév: " + item.username;
                        EmailLabel.Text = "Email: " + item.email;
                        PhoneLabel.Text = "Telefonszám: " + item.phone;
                        UpdateRentBtn.Tag = item.id;
                    };
                }
                count = 0;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        //Sorting the list of rents by clicking on the headers
        private void OrderList()
        {
            bool isAscT = true;
            TimeHeaderLabel.Click += async (s, e) =>
            {
                AllRents = await httpRequests.ListAllRents();
                if (isAscT)
                {
                    AllRents = AllRents.OrderBy(x => x.start).ToList();
                    isAscT = false;
                }
                else
                {
                    AllRents = AllRents.OrderByDescending(x => x.start).ToList();
                    isAscT = true;
                }
                RentList();
            };
            bool isAscL = true;
            LicensePlateHeaderLabel.Click += async (s, e) =>
            {
                AllRents = await httpRequests.ListAllRents();
                if (isAscL)
                {
                    AllRents = AllRents.OrderBy(x => x.licensePlate).ToList();
                    isAscL = false;
                }
                else
                {
                    AllRents = AllRents.OrderByDescending(x => x.licensePlate).ToList();
                    isAscL = true;
                }
                RentList();
            };
            bool isAscC = true;
            CarHeaderLabel.Click += async (s, e) =>
            {
                AllRents = await httpRequests.ListAllRents();
                if (isAscC)
                {
                    AllRents = AllRents.OrderBy(x => x.brand).ToList();
                    isAscC = false;
                }
                else
                {
                    AllRents = AllRents.OrderByDescending(x => x.brand).ToList();
                    isAscC = true;
                }
                RentList();
            };
            bool isAscU = true;
            UserHeaderLabel.Click += async (s, e) =>
            {
                AllRents = await httpRequests.ListAllRents();
                if (isAscU)
                {
                    AllRents = AllRents.OrderBy(x => x.username).ToList();
                    isAscU = false;
                }
                else
                {
                    AllRents = AllRents.OrderByDescending(x => x.username).ToList();
                    isAscU = true;
                }
                RentList();
            };
            bool isAscN = true;
            NameHeaderLabel.Click += async (s, e) =>
            {
                AllRents = await httpRequests.ListAllRents();
                if (isAscN)
                {
                    AllRents = AllRents.OrderBy(x => x.name).ToList();
                    isAscN = false;
                }
                else
                {
                    AllRents = AllRents.OrderByDescending(x => x.name).ToList();
                    isAscN = true;
                }
                RentList();
            };
            bool isAscE = true;
            EmailHeaderLabel.Click += async (s, e) =>
            {
                AllRents = await httpRequests.ListAllRents();
                if (isAscE)
                {
                    AllRents = AllRents.OrderBy(x => x.email).ToList();
                    isAscE = false;
                }
                else
                {
                    AllRents = AllRents.OrderByDescending(x => x.email).ToList();
                    isAscE = true;
                }
                RentList();
            };
            bool isAscP = true;
            PhoneHeaderLabel.Click += async (s, e) =>
            {
                AllRents = await httpRequests.ListAllRents();
                if (isAscP)
                {
                    AllRents = AllRents.OrderBy(x => x.phone).ToList();
                    isAscP = false;
                }
                else
                {
                    AllRents = AllRents.OrderByDescending(x => x.phone).ToList();
                    isAscP = true;
                };
                RentList();
            };
        }
        //Clears the labels and textboxes
        private void Clear()
        {
            OtherInfoLabelTB.Text = "";
            StartEndCalendar.SetDate(DateTime.Now);
            LicensePlateLabel.Text = "Rendszám:";
            BrandLabel.Text = "Márka:";
            NameLabel.Text = "Név:";
            UserLabel.Text = "Felhasználónév:";
            EmailLabel.Text = "Email:";
            PhoneLabel.Text = "Telefonszám:";
            UpdateRentBtn.Tag = 0;
        }
        private void InitializeComponent()
        {
            this.RentLabel = new System.Windows.Forms.Label();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this.RentPanel = new System.Windows.Forms.Panel();
            this.HeaderDGV = new System.Windows.Forms.DataGridView();
            this.OtherInfoLabel = new System.Windows.Forms.Label();
            this.OtherInfoLabelTB = new System.Windows.Forms.TextBox();
            this.UpdateRentBtn = new System.Windows.Forms.Button();
            this.TimeHeaderLabel = new System.Windows.Forms.Label();
            this.LicensePlateHeaderLabel = new System.Windows.Forms.Label();
            this.CarHeaderLabel = new System.Windows.Forms.Label();
            this.UserHeaderLabel = new System.Windows.Forms.Label();
            this.NameHeaderLabel = new System.Windows.Forms.Label();
            this.EmailHeaderLabel = new System.Windows.Forms.Label();
            this.PhoneHeaderLabel = new System.Windows.Forms.Label();
            this.StartEndCalendar = new System.Windows.Forms.MonthCalendar();
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.LicensePlateLabel = new System.Windows.Forms.Label();
            this.CancleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // RentLabel
            // 
            this.RentLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.RentLabel.Location = new System.Drawing.Point(0, 0);
            this.RentLabel.Name = "RentLabel";
            this.RentLabel.Size = new System.Drawing.Size(785, 57);
            this.RentLabel.TabIndex = 0;
            this.RentLabel.Text = "Kölcsönzések";
            this.RentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoDGV
            // 
            this.InfoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoDGV.Location = new System.Drawing.Point(0, 57);
            this.InfoDGV.Name = "InfoDGV";
            this.InfoDGV.Size = new System.Drawing.Size(785, 168);
            this.InfoDGV.TabIndex = 4;
            // 
            // RentPanel
            // 
            this.RentPanel.Location = new System.Drawing.Point(0, 241);
            this.RentPanel.Name = "RentPanel";
            this.RentPanel.Size = new System.Drawing.Size(785, 289);
            this.RentPanel.TabIndex = 5;
            // 
            // HeaderDGV
            // 
            this.HeaderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HeaderDGV.Location = new System.Drawing.Point(0, 224);
            this.HeaderDGV.Name = "HeaderDGV";
            this.HeaderDGV.Size = new System.Drawing.Size(785, 17);
            this.HeaderDGV.TabIndex = 36;
            // 
            // OtherInfoLabel
            // 
            this.OtherInfoLabel.AutoSize = true;
            this.OtherInfoLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.OtherInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.OtherInfoLabel.Location = new System.Drawing.Point(198, 64);
            this.OtherInfoLabel.Name = "OtherInfoLabel";
            this.OtherInfoLabel.Size = new System.Drawing.Size(127, 18);
            this.OtherInfoLabel.TabIndex = 39;
            this.OtherInfoLabel.Text = "Egyéb információ:";
            // 
            // OtherInfoLabelTB
            // 
            this.OtherInfoLabelTB.Location = new System.Drawing.Point(201, 85);
            this.OtherInfoLabelTB.Multiline = true;
            this.OtherInfoLabelTB.Name = "OtherInfoLabelTB";
            this.OtherInfoLabelTB.Size = new System.Drawing.Size(231, 71);
            this.OtherInfoLabelTB.TabIndex = 52;
            // 
            // UpdateRentBtn
            // 
            this.UpdateRentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.UpdateRentBtn.Location = new System.Drawing.Point(693, 200);
            this.UpdateRentBtn.Name = "UpdateRentBtn";
            this.UpdateRentBtn.Size = new System.Drawing.Size(89, 23);
            this.UpdateRentBtn.TabIndex = 55;
            this.UpdateRentBtn.Text = "Módosítás";
            this.UpdateRentBtn.UseVisualStyleBackColor = true;
            // 
            // TimeHeaderLabel
            // 
            this.TimeHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TimeHeaderLabel.Location = new System.Drawing.Point(1, 225);
            this.TimeHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TimeHeaderLabel.Name = "TimeHeaderLabel";
            this.TimeHeaderLabel.Size = new System.Drawing.Size(80, 15);
            this.TimeHeaderLabel.TabIndex = 57;
            this.TimeHeaderLabel.Text = "Foglalás";
            this.TimeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LicensePlateHeaderLabel
            // 
            this.LicensePlateHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LicensePlateHeaderLabel.Location = new System.Drawing.Point(82, 225);
            this.LicensePlateHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LicensePlateHeaderLabel.Name = "LicensePlateHeaderLabel";
            this.LicensePlateHeaderLabel.Size = new System.Drawing.Size(69, 15);
            this.LicensePlateHeaderLabel.TabIndex = 59;
            this.LicensePlateHeaderLabel.Text = "Rendszám";
            this.LicensePlateHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CarHeaderLabel
            // 
            this.CarHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CarHeaderLabel.Location = new System.Drawing.Point(152, 225);
            this.CarHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CarHeaderLabel.Name = "CarHeaderLabel";
            this.CarHeaderLabel.Size = new System.Drawing.Size(100, 15);
            this.CarHeaderLabel.TabIndex = 60;
            this.CarHeaderLabel.Text = "Autó";
            this.CarHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserHeaderLabel
            // 
            this.UserHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UserHeaderLabel.Location = new System.Drawing.Point(253, 225);
            this.UserHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UserHeaderLabel.Name = "UserHeaderLabel";
            this.UserHeaderLabel.Size = new System.Drawing.Size(103, 15);
            this.UserHeaderLabel.TabIndex = 63;
            this.UserHeaderLabel.Text = "Felhasználónév";
            this.UserHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameHeaderLabel
            // 
            this.NameHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameHeaderLabel.Location = new System.Drawing.Point(357, 225);
            this.NameHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NameHeaderLabel.Name = "NameHeaderLabel";
            this.NameHeaderLabel.Size = new System.Drawing.Size(100, 15);
            this.NameHeaderLabel.TabIndex = 64;
            this.NameHeaderLabel.Text = "Név";
            this.NameHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmailHeaderLabel
            // 
            this.EmailHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmailHeaderLabel.Location = new System.Drawing.Point(458, 225);
            this.EmailHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EmailHeaderLabel.Name = "EmailHeaderLabel";
            this.EmailHeaderLabel.Size = new System.Drawing.Size(90, 15);
            this.EmailHeaderLabel.TabIndex = 65;
            this.EmailHeaderLabel.Text = "E-mail";
            this.EmailHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneHeaderLabel
            // 
            this.PhoneHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PhoneHeaderLabel.Location = new System.Drawing.Point(549, 225);
            this.PhoneHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PhoneHeaderLabel.Name = "PhoneHeaderLabel";
            this.PhoneHeaderLabel.Size = new System.Drawing.Size(94, 15);
            this.PhoneHeaderLabel.TabIndex = 66;
            this.PhoneHeaderLabel.Text = "Telefonszám";
            this.PhoneHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartEndCalendar
            // 
            this.StartEndCalendar.Location = new System.Drawing.Point(4, 60);
            this.StartEndCalendar.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.StartEndCalendar.Name = "StartEndCalendar";
            this.StartEndCalendar.TabIndex = 67;
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InfoHeaderLabel.Location = new System.Drawing.Point(644, 225);
            this.InfoHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(100, 15);
            this.InfoHeaderLabel.TabIndex = 68;
            this.InfoHeaderLabel.Text = "Információ";
            this.InfoHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.UserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UserLabel.Location = new System.Drawing.Point(458, 64);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(115, 18);
            this.UserLabel.TabIndex = 70;
            this.UserLabel.Text = "Felhasználónév:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmailLabel.Location = new System.Drawing.Point(458, 94);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(54, 18);
            this.EmailLabel.TabIndex = 71;
            this.EmailLabel.Text = "E-mail:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PhoneLabel.Location = new System.Drawing.Point(458, 124);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(98, 18);
            this.PhoneLabel.TabIndex = 72;
            this.PhoneLabel.Text = "Telefonszám:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLabel.Location = new System.Drawing.Point(458, 154);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 18);
            this.NameLabel.TabIndex = 73;
            this.NameLabel.Text = "Név:";
            // 
            // BrandLabel
            // 
            this.BrandLabel.AutoSize = true;
            this.BrandLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BrandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrandLabel.Location = new System.Drawing.Point(198, 189);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(54, 18);
            this.BrandLabel.TabIndex = 74;
            this.BrandLabel.Text = "Márka:";
            // 
            // LicensePlateLabel
            // 
            this.LicensePlateLabel.AutoSize = true;
            this.LicensePlateLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LicensePlateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LicensePlateLabel.Location = new System.Drawing.Point(198, 161);
            this.LicensePlateLabel.Name = "LicensePlateLabel";
            this.LicensePlateLabel.Size = new System.Drawing.Size(84, 18);
            this.LicensePlateLabel.TabIndex = 75;
            this.LicensePlateLabel.Text = "Rendszám:";
            // 
            // CancleBtn
            // 
            this.CancleBtn.Location = new System.Drawing.Point(693, 175);
            this.CancleBtn.Name = "CancleBtn";
            this.CancleBtn.Size = new System.Drawing.Size(89, 23);
            this.CancleBtn.TabIndex = 76;
            this.CancleBtn.Text = "Mégse";
            this.CancleBtn.UseVisualStyleBackColor = true;
            // 
            // RentCar
            // 
            this.Controls.Add(this.CancleBtn);
            this.Controls.Add(this.LicensePlateLabel);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.InfoHeaderLabel);
            this.Controls.Add(this.StartEndCalendar);
            this.Controls.Add(this.PhoneHeaderLabel);
            this.Controls.Add(this.EmailHeaderLabel);
            this.Controls.Add(this.NameHeaderLabel);
            this.Controls.Add(this.UserHeaderLabel);
            this.Controls.Add(this.CarHeaderLabel);
            this.Controls.Add(this.LicensePlateHeaderLabel);
            this.Controls.Add(this.TimeHeaderLabel);
            this.Controls.Add(this.UpdateRentBtn);
            this.Controls.Add(this.OtherInfoLabelTB);
            this.Controls.Add(this.OtherInfoLabel);
            this.Controls.Add(this.HeaderDGV);
            this.Controls.Add(this.RentPanel);
            this.Controls.Add(this.InfoDGV);
            this.Controls.Add(this.RentLabel);
            this.Name = "RentCar";
            this.Size = new System.Drawing.Size(785, 530);
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
