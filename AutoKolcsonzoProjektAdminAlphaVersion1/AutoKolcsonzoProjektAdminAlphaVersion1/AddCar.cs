using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    public class AddCar: UserControl
    {
        private PictureBox CarPictureBox;
        private DataGridView InfoDGV;
        private Label BrandLabel;
        private Label DriveLabel;
        private Label ShiftLabel;
        private Label FuelLabel;
        private Label TypeLabel;
        private Label AirCondLabel;
        private Label RadarLabel;
        private Label CruiseControlLabel;
        private Label PricesLabel;
        private Label OneToFiveRentalLabel;
        private Label SixToFourteenRentalLabel;
        private Label FromFifteenRentalLabel;
        private Label DepositLabel;
        private Label OtherInfoLabel;
        private TextBox BrandTB;
        private TextBox textBox5;
        private TextBox FromFifteenRentalTB;
        private TextBox DepositTB;
        private TextBox OneToFiveRentalTB;
        private TextBox SixToFourteenRentalTB;
        private TextBox TypeTB;
        private ComboBox DriveCB;
        private ComboBox ShiftCB;
        private ComboBox FuelCB;
        private Button AddCarBtn;
        private CheckBox AirCondChB;
        private CheckBox RadarChB;
        private CheckBox CruiseControlChB;
        private DataGridView HeaderDGV;
        private Label IDHeaderLabel;
        private Label BrandHeaderLabel;
        private Label TypeHeaderLabel;
        private Label YearHeaderLabel;
        private Label DriveHeaderLabel;
        private Label ShiftHeaderLabel;
        private Label FuelHeaderLabel;
        private Label AirCondHeaderLabel;
        private Label RadarHeaderLabel;
        private Label CruiseControlHeaderLabel;
        private Label OneToFiveHeaderLabel;
        private Label SixToFourteenHeaderLabel;
        private Label FromFifteenHeaderLabel;
        private Label DepositeHeaderLabel;
        public Panel CarPanel;
        private Label LocationHeaderLabel;
        private Label CarsLabel;

        public AddCar()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            CarPictureBox.Click += (sender, e) =>
            {
                ofd.ShowDialog();
                object path = ofd.FileName;
                CarPictureBox.ImageLocation = path.ToString();
            };
            CarPanel.AutoScroll = Enabled;
            
            for (int i = 0; i < 20; i++)
            {
                OneCar auto = new OneCar();
                auto.Top = i * auto.Height;
                CarPanel.Controls.Add(auto);
                
            }
        }

        private void InitializeComponent()
        {
            this.CarsLabel = new System.Windows.Forms.Label();
            this.CarPictureBox = new System.Windows.Forms.PictureBox();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.DriveLabel = new System.Windows.Forms.Label();
            this.ShiftLabel = new System.Windows.Forms.Label();
            this.FuelLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.AirCondLabel = new System.Windows.Forms.Label();
            this.RadarLabel = new System.Windows.Forms.Label();
            this.CruiseControlLabel = new System.Windows.Forms.Label();
            this.PricesLabel = new System.Windows.Forms.Label();
            this.OneToFiveRentalLabel = new System.Windows.Forms.Label();
            this.SixToFourteenRentalLabel = new System.Windows.Forms.Label();
            this.FromFifteenRentalLabel = new System.Windows.Forms.Label();
            this.DepositLabel = new System.Windows.Forms.Label();
            this.OtherInfoLabel = new System.Windows.Forms.Label();
            this.BrandTB = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.FromFifteenRentalTB = new System.Windows.Forms.TextBox();
            this.DepositTB = new System.Windows.Forms.TextBox();
            this.OneToFiveRentalTB = new System.Windows.Forms.TextBox();
            this.SixToFourteenRentalTB = new System.Windows.Forms.TextBox();
            this.TypeTB = new System.Windows.Forms.TextBox();
            this.DriveCB = new System.Windows.Forms.ComboBox();
            this.ShiftCB = new System.Windows.Forms.ComboBox();
            this.FuelCB = new System.Windows.Forms.ComboBox();
            this.AddCarBtn = new System.Windows.Forms.Button();
            this.AirCondChB = new System.Windows.Forms.CheckBox();
            this.RadarChB = new System.Windows.Forms.CheckBox();
            this.CruiseControlChB = new System.Windows.Forms.CheckBox();
            this.HeaderDGV = new System.Windows.Forms.DataGridView();
            this.IDHeaderLabel = new System.Windows.Forms.Label();
            this.BrandHeaderLabel = new System.Windows.Forms.Label();
            this.TypeHeaderLabel = new System.Windows.Forms.Label();
            this.YearHeaderLabel = new System.Windows.Forms.Label();
            this.DriveHeaderLabel = new System.Windows.Forms.Label();
            this.ShiftHeaderLabel = new System.Windows.Forms.Label();
            this.FuelHeaderLabel = new System.Windows.Forms.Label();
            this.AirCondHeaderLabel = new System.Windows.Forms.Label();
            this.RadarHeaderLabel = new System.Windows.Forms.Label();
            this.CruiseControlHeaderLabel = new System.Windows.Forms.Label();
            this.OneToFiveHeaderLabel = new System.Windows.Forms.Label();
            this.SixToFourteenHeaderLabel = new System.Windows.Forms.Label();
            this.FromFifteenHeaderLabel = new System.Windows.Forms.Label();
            this.DepositeHeaderLabel = new System.Windows.Forms.Label();
            this.CarPanel = new System.Windows.Forms.Panel();
            this.LocationHeaderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CarPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CarsLabel
            // 
            this.CarsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CarsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CarsLabel.Location = new System.Drawing.Point(0, 0);
            this.CarsLabel.Name = "CarsLabel";
            this.CarsLabel.Size = new System.Drawing.Size(785, 57);
            this.CarsLabel.TabIndex = 0;
            this.CarsLabel.Text = "Autók";
            this.CarsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CarPictureBox
            // 
            this.CarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CarPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CarPictureBox.Location = new System.Drawing.Point(0, 57);
            this.CarPictureBox.Name = "CarPictureBox";
            this.CarPictureBox.Size = new System.Drawing.Size(240, 107);
            this.CarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CarPictureBox.TabIndex = 2;
            this.CarPictureBox.TabStop = false;
            // 
            // InfoDGV
            // 
            this.InfoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoDGV.Location = new System.Drawing.Point(0, 57);
            this.InfoDGV.Name = "InfoDGV";
            this.InfoDGV.Size = new System.Drawing.Size(785, 212);
            this.InfoDGV.TabIndex = 3;
            // 
            // BrandLabel
            // 
            this.BrandLabel.AutoSize = true;
            this.BrandLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BrandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrandLabel.Location = new System.Drawing.Point(252, 64);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(54, 18);
            this.BrandLabel.TabIndex = 4;
            this.BrandLabel.Text = "Márka:";
            // 
            // DriveLabel
            // 
            this.DriveLabel.AutoSize = true;
            this.DriveLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.DriveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DriveLabel.Location = new System.Drawing.Point(252, 88);
            this.DriveLabel.Name = "DriveLabel";
            this.DriveLabel.Size = new System.Drawing.Size(80, 18);
            this.DriveLabel.TabIndex = 5;
            this.DriveLabel.Text = "Meghajtás:";
            // 
            // ShiftLabel
            // 
            this.ShiftLabel.AutoSize = true;
            this.ShiftLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ShiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ShiftLabel.Location = new System.Drawing.Point(252, 112);
            this.ShiftLabel.Name = "ShiftLabel";
            this.ShiftLabel.Size = new System.Drawing.Size(45, 18);
            this.ShiftLabel.TabIndex = 6;
            this.ShiftLabel.Text = "Váltó:";
            // 
            // FuelLabel
            // 
            this.FuelLabel.AutoSize = true;
            this.FuelLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.FuelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FuelLabel.Location = new System.Drawing.Point(252, 136);
            this.FuelLabel.Name = "FuelLabel";
            this.FuelLabel.Size = new System.Drawing.Size(91, 18);
            this.FuelLabel.TabIndex = 7;
            this.FuelLabel.Text = "Üzemanyag:";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TypeLabel.Location = new System.Drawing.Point(480, 64);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(48, 18);
            this.TypeLabel.TabIndex = 8;
            this.TypeLabel.Text = "Típus:";
            // 
            // AirCondLabel
            // 
            this.AirCondLabel.AutoSize = true;
            this.AirCondLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AirCondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AirCondLabel.Location = new System.Drawing.Point(480, 88);
            this.AirCondLabel.Name = "AirCondLabel";
            this.AirCondLabel.Size = new System.Drawing.Size(49, 18);
            this.AirCondLabel.TabIndex = 9;
            this.AirCondLabel.Text = "Klíma:";
            // 
            // RadarLabel
            // 
            this.RadarLabel.AutoSize = true;
            this.RadarLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.RadarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadarLabel.Location = new System.Drawing.Point(480, 112);
            this.RadarLabel.Name = "RadarLabel";
            this.RadarLabel.Size = new System.Drawing.Size(88, 18);
            this.RadarLabel.TabIndex = 10;
            this.RadarLabel.Text = "Tolatóradar:";
            // 
            // CruiseControlLabel
            // 
            this.CruiseControlLabel.AutoSize = true;
            this.CruiseControlLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CruiseControlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CruiseControlLabel.Location = new System.Drawing.Point(480, 136);
            this.CruiseControlLabel.Name = "CruiseControlLabel";
            this.CruiseControlLabel.Size = new System.Drawing.Size(84, 18);
            this.CruiseControlLabel.TabIndex = 11;
            this.CruiseControlLabel.Text = "Tempomat:";
            // 
            // PricesLabel
            // 
            this.PricesLabel.AutoSize = true;
            this.PricesLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PricesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PricesLabel.Location = new System.Drawing.Point(44, 167);
            this.PricesLabel.Name = "PricesLabel";
            this.PricesLabel.Size = new System.Drawing.Size(137, 25);
            this.PricesLabel.TabIndex = 12;
            this.PricesLabel.Text = "Bérleti díjak";
            // 
            // OneToFiveRentalLabel
            // 
            this.OneToFiveRentalLabel.AutoSize = true;
            this.OneToFiveRentalLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OneToFiveRentalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OneToFiveRentalLabel.Location = new System.Drawing.Point(1, 207);
            this.OneToFiveRentalLabel.Name = "OneToFiveRentalLabel";
            this.OneToFiveRentalLabel.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.OneToFiveRentalLabel.Size = new System.Drawing.Size(72, 18);
            this.OneToFiveRentalLabel.TabIndex = 13;
            this.OneToFiveRentalLabel.Text = "1-5 nap:";
            // 
            // SixToFourteenRentalLabel
            // 
            this.SixToFourteenRentalLabel.AutoSize = true;
            this.SixToFourteenRentalLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SixToFourteenRentalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SixToFourteenRentalLabel.Location = new System.Drawing.Point(1, 238);
            this.SixToFourteenRentalLabel.Name = "SixToFourteenRentalLabel";
            this.SixToFourteenRentalLabel.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.SixToFourteenRentalLabel.Size = new System.Drawing.Size(72, 18);
            this.SixToFourteenRentalLabel.TabIndex = 14;
            this.SixToFourteenRentalLabel.Text = "6-14 nap:";
            // 
            // FromFifteenRentalLabel
            // 
            this.FromFifteenRentalLabel.AutoSize = true;
            this.FromFifteenRentalLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FromFifteenRentalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FromFifteenRentalLabel.Location = new System.Drawing.Point(188, 208);
            this.FromFifteenRentalLabel.Name = "FromFifteenRentalLabel";
            this.FromFifteenRentalLabel.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.FromFifteenRentalLabel.Size = new System.Drawing.Size(79, 18);
            this.FromFifteenRentalLabel.TabIndex = 15;
            this.FromFifteenRentalLabel.Text = "15 naptól:";
            // 
            // DepositLabel
            // 
            this.DepositLabel.AutoSize = true;
            this.DepositLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DepositLabel.Location = new System.Drawing.Point(187, 238);
            this.DepositLabel.Name = "DepositLabel";
            this.DepositLabel.Padding = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.DepositLabel.Size = new System.Drawing.Size(80, 18);
            this.DepositLabel.TabIndex = 16;
            this.DepositLabel.Text = "Kaució:";
            // 
            // OtherInfoLabel
            // 
            this.OtherInfoLabel.AutoSize = true;
            this.OtherInfoLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.OtherInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OtherInfoLabel.Location = new System.Drawing.Point(383, 174);
            this.OtherInfoLabel.Name = "OtherInfoLabel";
            this.OtherInfoLabel.Size = new System.Drawing.Size(135, 18);
            this.OtherInfoLabel.TabIndex = 17;
            this.OtherInfoLabel.Text = "Egyébb információ:";
            // 
            // BrandTB
            // 
            this.BrandTB.Location = new System.Drawing.Point(339, 65);
            this.BrandTB.Name = "BrandTB";
            this.BrandTB.Size = new System.Drawing.Size(100, 20);
            this.BrandTB.TabIndex = 18;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(386, 195);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(307, 71);
            this.textBox5.TabIndex = 22;
            // 
            // FromFifteenRentalTB
            // 
            this.FromFifteenRentalTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FromFifteenRentalTB.Location = new System.Drawing.Point(267, 207);
            this.FromFifteenRentalTB.Name = "FromFifteenRentalTB";
            this.FromFifteenRentalTB.Size = new System.Drawing.Size(100, 20);
            this.FromFifteenRentalTB.TabIndex = 23;
            // 
            // DepositTB
            // 
            this.DepositTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DepositTB.Location = new System.Drawing.Point(267, 237);
            this.DepositTB.Name = "DepositTB";
            this.DepositTB.Size = new System.Drawing.Size(100, 20);
            this.DepositTB.TabIndex = 24;
            // 
            // OneToFiveRentalTB
            // 
            this.OneToFiveRentalTB.Location = new System.Drawing.Point(73, 206);
            this.OneToFiveRentalTB.Name = "OneToFiveRentalTB";
            this.OneToFiveRentalTB.Size = new System.Drawing.Size(100, 20);
            this.OneToFiveRentalTB.TabIndex = 25;
            // 
            // SixToFourteenRentalTB
            // 
            this.SixToFourteenRentalTB.Location = new System.Drawing.Point(73, 237);
            this.SixToFourteenRentalTB.Name = "SixToFourteenRentalTB";
            this.SixToFourteenRentalTB.Size = new System.Drawing.Size(100, 20);
            this.SixToFourteenRentalTB.TabIndex = 26;
            // 
            // TypeTB
            // 
            this.TypeTB.Location = new System.Drawing.Point(534, 64);
            this.TypeTB.Name = "TypeTB";
            this.TypeTB.Size = new System.Drawing.Size(100, 20);
            this.TypeTB.TabIndex = 27;
            // 
            // DriveCB
            // 
            this.DriveCB.FormattingEnabled = true;
            this.DriveCB.Location = new System.Drawing.Point(339, 88);
            this.DriveCB.Name = "DriveCB";
            this.DriveCB.Size = new System.Drawing.Size(121, 21);
            this.DriveCB.TabIndex = 28;
            // 
            // ShiftCB
            // 
            this.ShiftCB.FormattingEnabled = true;
            this.ShiftCB.Location = new System.Drawing.Point(339, 112);
            this.ShiftCB.Name = "ShiftCB";
            this.ShiftCB.Size = new System.Drawing.Size(121, 21);
            this.ShiftCB.TabIndex = 29;
            // 
            // FuelCB
            // 
            this.FuelCB.FormattingEnabled = true;
            this.FuelCB.Location = new System.Drawing.Point(339, 136);
            this.FuelCB.Name = "FuelCB";
            this.FuelCB.Size = new System.Drawing.Size(121, 21);
            this.FuelCB.TabIndex = 30;
            // 
            // AddCarBtn
            // 
            this.AddCarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddCarBtn.Location = new System.Drawing.Point(695, 245);
            this.AddCarBtn.Name = "AddCarBtn";
            this.AddCarBtn.Size = new System.Drawing.Size(89, 23);
            this.AddCarBtn.TabIndex = 31;
            this.AddCarBtn.Text = "Hozzáadás";
            this.AddCarBtn.UseVisualStyleBackColor = true;
            // 
            // AirCondChB
            // 
            this.AirCondChB.AutoSize = true;
            this.AirCondChB.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AirCondChB.Location = new System.Drawing.Point(572, 93);
            this.AirCondChB.Name = "AirCondChB";
            this.AirCondChB.Size = new System.Drawing.Size(15, 14);
            this.AirCondChB.TabIndex = 32;
            this.AirCondChB.UseVisualStyleBackColor = false;
            // 
            // RadarChB
            // 
            this.RadarChB.AutoSize = true;
            this.RadarChB.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.RadarChB.Location = new System.Drawing.Point(572, 117);
            this.RadarChB.Name = "RadarChB";
            this.RadarChB.Size = new System.Drawing.Size(15, 14);
            this.RadarChB.TabIndex = 33;
            this.RadarChB.UseVisualStyleBackColor = false;
            // 
            // CruiseControlChB
            // 
            this.CruiseControlChB.AutoSize = true;
            this.CruiseControlChB.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CruiseControlChB.Location = new System.Drawing.Point(572, 140);
            this.CruiseControlChB.Name = "CruiseControlChB";
            this.CruiseControlChB.Size = new System.Drawing.Size(15, 14);
            this.CruiseControlChB.TabIndex = 34;
            this.CruiseControlChB.UseVisualStyleBackColor = false;
            // 
            // HeaderDGV
            // 
            this.HeaderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HeaderDGV.Location = new System.Drawing.Point(0, 268);
            this.HeaderDGV.Name = "HeaderDGV";
            this.HeaderDGV.Size = new System.Drawing.Size(785, 17);
            this.HeaderDGV.TabIndex = 35;
            // 
            // IDHeaderLabel
            // 
            this.IDHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IDHeaderLabel.Location = new System.Drawing.Point(1, 269);
            this.IDHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.IDHeaderLabel.Name = "IDHeaderLabel";
            this.IDHeaderLabel.Size = new System.Drawing.Size(30, 15);
            this.IDHeaderLabel.TabIndex = 36;
            this.IDHeaderLabel.Text = "ID";
            this.IDHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrandHeaderLabel
            // 
            this.BrandHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrandHeaderLabel.Location = new System.Drawing.Point(32, 269);
            this.BrandHeaderLabel.Name = "BrandHeaderLabel";
            this.BrandHeaderLabel.Size = new System.Drawing.Size(73, 15);
            this.BrandHeaderLabel.TabIndex = 37;
            this.BrandHeaderLabel.Text = "Márka";
            this.BrandHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TypeHeaderLabel
            // 
            this.TypeHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TypeHeaderLabel.Location = new System.Drawing.Point(106, 269);
            this.TypeHeaderLabel.Name = "TypeHeaderLabel";
            this.TypeHeaderLabel.Size = new System.Drawing.Size(66, 15);
            this.TypeHeaderLabel.TabIndex = 38;
            this.TypeHeaderLabel.Text = "Típus";
            this.TypeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YearHeaderLabel
            // 
            this.YearHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YearHeaderLabel.Location = new System.Drawing.Point(173, 269);
            this.YearHeaderLabel.Name = "YearHeaderLabel";
            this.YearHeaderLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.YearHeaderLabel.Size = new System.Drawing.Size(35, 15);
            this.YearHeaderLabel.TabIndex = 39;
            this.YearHeaderLabel.Text = "Év";
            // 
            // DriveHeaderLabel
            // 
            this.DriveHeaderLabel.AutoSize = true;
            this.DriveHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DriveHeaderLabel.Location = new System.Drawing.Point(209, 269);
            this.DriveHeaderLabel.Name = "DriveHeaderLabel";
            this.DriveHeaderLabel.Size = new System.Drawing.Size(42, 15);
            this.DriveHeaderLabel.TabIndex = 40;
            this.DriveHeaderLabel.Text = "Hajtás";
            this.DriveHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShiftHeaderLabel
            // 
            this.ShiftHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ShiftHeaderLabel.Location = new System.Drawing.Point(252, 269);
            this.ShiftHeaderLabel.Name = "ShiftHeaderLabel";
            this.ShiftHeaderLabel.Size = new System.Drawing.Size(59, 15);
            this.ShiftHeaderLabel.TabIndex = 41;
            this.ShiftHeaderLabel.Text = "Váltó";
            this.ShiftHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FuelHeaderLabel
            // 
            this.FuelHeaderLabel.AutoSize = true;
            this.FuelHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FuelHeaderLabel.Location = new System.Drawing.Point(312, 269);
            this.FuelHeaderLabel.Name = "FuelHeaderLabel";
            this.FuelHeaderLabel.Size = new System.Drawing.Size(73, 15);
            this.FuelHeaderLabel.TabIndex = 42;
            this.FuelHeaderLabel.Text = "Üzemanyag";
            // 
            // AirCondHeaderLabel
            // 
            this.AirCondHeaderLabel.AutoSize = true;
            this.AirCondHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AirCondHeaderLabel.Location = new System.Drawing.Point(386, 269);
            this.AirCondHeaderLabel.Name = "AirCondHeaderLabel";
            this.AirCondHeaderLabel.Size = new System.Drawing.Size(39, 15);
            this.AirCondHeaderLabel.TabIndex = 43;
            this.AirCondHeaderLabel.Text = "Klíma";
            // 
            // RadarHeaderLabel
            // 
            this.RadarHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadarHeaderLabel.AutoSize = true;
            this.RadarHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadarHeaderLabel.Location = new System.Drawing.Point(426, 269);
            this.RadarHeaderLabel.Name = "RadarHeaderLabel";
            this.RadarHeaderLabel.Size = new System.Drawing.Size(41, 15);
            this.RadarHeaderLabel.TabIndex = 44;
            this.RadarHeaderLabel.Text = "Radar";
            this.RadarHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CruiseControlHeaderLabel
            // 
            this.CruiseControlHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CruiseControlHeaderLabel.Location = new System.Drawing.Point(468, 269);
            this.CruiseControlHeaderLabel.Name = "CruiseControlHeaderLabel";
            this.CruiseControlHeaderLabel.Size = new System.Drawing.Size(28, 15);
            this.CruiseControlHeaderLabel.TabIndex = 45;
            this.CruiseControlHeaderLabel.Text = "CC";
            this.CruiseControlHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OneToFiveHeaderLabel
            // 
            this.OneToFiveHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OneToFiveHeaderLabel.Location = new System.Drawing.Point(497, 269);
            this.OneToFiveHeaderLabel.Name = "OneToFiveHeaderLabel";
            this.OneToFiveHeaderLabel.Size = new System.Drawing.Size(42, 15);
            this.OneToFiveHeaderLabel.TabIndex = 47;
            this.OneToFiveHeaderLabel.Text = "1-5";
            this.OneToFiveHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SixToFourteenHeaderLabel
            // 
            this.SixToFourteenHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SixToFourteenHeaderLabel.Location = new System.Drawing.Point(540, 269);
            this.SixToFourteenHeaderLabel.Name = "SixToFourteenHeaderLabel";
            this.SixToFourteenHeaderLabel.Size = new System.Drawing.Size(49, 15);
            this.SixToFourteenHeaderLabel.TabIndex = 48;
            this.SixToFourteenHeaderLabel.Text = "6-14";
            this.SixToFourteenHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FromFifteenHeaderLabel
            // 
            this.FromFifteenHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FromFifteenHeaderLabel.Location = new System.Drawing.Point(590, 269);
            this.FromFifteenHeaderLabel.Name = "FromFifteenHeaderLabel";
            this.FromFifteenHeaderLabel.Size = new System.Drawing.Size(49, 15);
            this.FromFifteenHeaderLabel.TabIndex = 49;
            this.FromFifteenHeaderLabel.Text = "15<";
            this.FromFifteenHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepositeHeaderLabel
            // 
            this.DepositeHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DepositeHeaderLabel.Location = new System.Drawing.Point(640, 269);
            this.DepositeHeaderLabel.Name = "DepositeHeaderLabel";
            this.DepositeHeaderLabel.Size = new System.Drawing.Size(49, 15);
            this.DepositeHeaderLabel.TabIndex = 50;
            this.DepositeHeaderLabel.Text = "Kaució";
            this.DepositeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CarPanel
            // 
            this.CarPanel.Location = new System.Drawing.Point(0, 287);
            this.CarPanel.Name = "CarPanel";
            this.CarPanel.Size = new System.Drawing.Size(785, 243);
            this.CarPanel.TabIndex = 51;
            // 
            // LocationHeaderLabel
            // 
            this.LocationHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LocationHeaderLabel.Location = new System.Drawing.Point(690, 269);
            this.LocationHeaderLabel.Name = "LocationHeaderLabel";
            this.LocationHeaderLabel.Size = new System.Drawing.Size(33, 15);
            this.LocationHeaderLabel.TabIndex = 52;
            this.LocationHeaderLabel.Text = "Hely";
            this.LocationHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddCar
            // 
            this.Controls.Add(this.LocationHeaderLabel);
            this.Controls.Add(this.CarPanel);
            this.Controls.Add(this.DepositeHeaderLabel);
            this.Controls.Add(this.FromFifteenHeaderLabel);
            this.Controls.Add(this.SixToFourteenHeaderLabel);
            this.Controls.Add(this.OneToFiveHeaderLabel);
            this.Controls.Add(this.CruiseControlHeaderLabel);
            this.Controls.Add(this.RadarHeaderLabel);
            this.Controls.Add(this.AirCondHeaderLabel);
            this.Controls.Add(this.FuelHeaderLabel);
            this.Controls.Add(this.ShiftHeaderLabel);
            this.Controls.Add(this.DriveHeaderLabel);
            this.Controls.Add(this.YearHeaderLabel);
            this.Controls.Add(this.TypeHeaderLabel);
            this.Controls.Add(this.BrandHeaderLabel);
            this.Controls.Add(this.IDHeaderLabel);
            this.Controls.Add(this.HeaderDGV);
            this.Controls.Add(this.CruiseControlChB);
            this.Controls.Add(this.RadarChB);
            this.Controls.Add(this.AirCondChB);
            this.Controls.Add(this.AddCarBtn);
            this.Controls.Add(this.FuelCB);
            this.Controls.Add(this.ShiftCB);
            this.Controls.Add(this.DriveCB);
            this.Controls.Add(this.TypeTB);
            this.Controls.Add(this.SixToFourteenRentalTB);
            this.Controls.Add(this.OneToFiveRentalTB);
            this.Controls.Add(this.DepositTB);
            this.Controls.Add(this.FromFifteenRentalTB);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.BrandTB);
            this.Controls.Add(this.OtherInfoLabel);
            this.Controls.Add(this.DepositLabel);
            this.Controls.Add(this.FromFifteenRentalLabel);
            this.Controls.Add(this.SixToFourteenRentalLabel);
            this.Controls.Add(this.OneToFiveRentalLabel);
            this.Controls.Add(this.PricesLabel);
            this.Controls.Add(this.CruiseControlLabel);
            this.Controls.Add(this.RadarLabel);
            this.Controls.Add(this.AirCondLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.FuelLabel);
            this.Controls.Add(this.ShiftLabel);
            this.Controls.Add(this.DriveLabel);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.CarPictureBox);
            this.Controls.Add(this.InfoDGV);
            this.Controls.Add(this.CarsLabel);
            this.Name = "AddCar";
            this.Size = new System.Drawing.Size(785, 530);
            ((System.ComponentModel.ISupportInitialize)(this.CarPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
