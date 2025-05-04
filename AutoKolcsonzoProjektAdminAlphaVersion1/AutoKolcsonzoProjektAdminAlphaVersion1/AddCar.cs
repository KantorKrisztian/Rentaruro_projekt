using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
        private Label LicensePlateHeaderLabel;
        private Label CarHeaderLabel;
        private Label YearHeaderLabel;
        private Label DriveHeaderLabel;
        private Label ShiftHeaderLabel;
        private Label FuelHeaderLabel;
        private Label AirCondHeaderLabel;
        private Label RadarHeaderLabel;
        private Label CruiseControlHeaderLabel;
        public Panel CarPanel;
        private Label CategoryHeaderLabel;
        private Label CategoriLabel;
        private ComboBox CategoryCB;
        private Label YearLabel;
        private ComboBox YearCB;
        private Label CarsLabel;
        private Label LicensePlateLabel;
        private TextBox LicensePlateTB;
        HttpRequests httpRequests = new HttpRequests();
        private Label DepositeHeaderLabel;
        private Label FromFifteenHeaderLabel;
        private Label SixToFourteenHeaderLabel;
        private Label OneToFiveHeaderLabel;
        private Button CancleBtn;
        public List<jsonCars> AllCars = new List<jsonCars>();
        public AddCar()
        {
            InitializeComponent();
            Start();
        }

        public async void Start()
        {
            
            AllCars = await httpRequests.ListAllCars();
            CarPanel.AutoScroll = true;

            SetButtons();
            SetComboBoxes();
            SetPictureBox();
            CarList();
            IfWorker();
            CancleBtn.Click += (s, e) =>
            {
                Clear();
                LicensePlateTB.Enabled = true;
                AddCarBtn.Text = "Hozzáadás";
            };
        }
        async void UpdateCar()
        {
            try
            {
                if (CheckIfEmpty())
                {
                    MessageBox.Show("Kérem töltse ki az összes mezőt!");
                    return;
                }
                AllCars = await httpRequests.ListAllCars();
                jsonCars carss = new jsonCars();
                foreach (jsonCars item in AllCars)
                {
                    if (item.licensePlate == LicensePlateTB.Text)
                    {
                        carss = item;
                    }
                }

                carss.picture = CheckPictureBox(CarPictureBox.ImageLocation);
                if (carss.picture == null)
                {
                    return;
                }
                carss.licensePlate = LicensePlateTB.Text;
                carss.brand = BrandTB.Text;
                carss.type = TypeTB.Text;
                carss.year = YearCB.Text;
                carss.drive = DriveCB.Text;
                carss.gearShift = ShiftCB.Text;
                carss.fuel = FuelCB.Text;
                carss.airCondition = AirCondChB.Checked;
                carss.radar = RadarChB.Checked;
                carss.cruiseControl = CruiseControlChB.Checked;
                carss.info = textBox5.Text;
                carss.category = CategoryCB.Text;
                carss.OneToFive = int.Parse(OneToFiveRentalTB.Text);
                carss.SixToForteen = int.Parse(SixToFourteenRentalTB.Text);
                carss.OverForteen = int.Parse(FromFifteenRentalTB.Text);
                carss.Deposit = int.Parse(DepositTB.Text);
                AllCars = await httpRequests.UpdateCar(carss);
                CarList();
                AddCarBtn.Text = "Hozzáadás";
                Clear();
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        async void AddOneCar()
        {
            try
            {
                if (CheckIfEmpty())
                {
                    MessageBox.Show("Kérem töltse ki az összes mezőt!");
                    return;
                }
                jsonCars carss = new jsonCars();
                
                carss.picture = CheckPictureBox(CarPictureBox.ImageLocation);
                if (carss.picture==null)
                {
                    return;
                }
                carss.licensePlate = LicensePlateTB.Text;
                carss.brand = BrandTB.Text;
                carss.type = TypeTB.Text;
                carss.year = YearCB.Text;
                carss.drive = DriveCB.Text;
                carss.gearShift = ShiftCB.Text;
                carss.fuel = FuelCB.Text;
                carss.airCondition = AirCondChB.Checked;
                carss.radar = RadarChB.Checked;
                carss.cruiseControl = CruiseControlChB.Checked;
                carss.info = textBox5.Text;
                carss.category = CategoryCB.Text;
                carss.OneToFive = int.Parse(OneToFiveRentalTB.Text);
                carss.SixToForteen = int.Parse(SixToFourteenRentalTB.Text);
                carss.OverForteen = int.Parse(FromFifteenRentalTB.Text);
                carss.Deposit = int.Parse(DepositTB.Text);
                AllCars = await httpRequests.CreateCar(carss);
                CarList();
                Clear();
                return;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }
        public void CarList()
        {
            try
            {
                if (AllCars == null)
                {
                    return;
                }
                int count = 0;
                CarPanel.Controls.Clear();
                foreach (jsonCars item in AllCars)
                {
                    count++;
                    OneCar auto = new OneCar();
                    auto.LicensePlateLabel.Text = item.licensePlate;
                    auto.BrandLabel.Text = item.brand;
                    auto.TypeLabel.Text = item.type;
                    auto.YearLabel.Text = item.year;
                    auto.DriveLabel.Text = item.drive;
                    if (item.gearShift=="Autómata")
                    {
                        auto.ShiftLabel.Text = "A";
                    }
                    else
                    {
                        auto.ShiftLabel.Text = "M";
                    }
                    auto.FuelLabel.Text = item.fuel;
                    if (item.airCondition)
                    {
                        auto.AirCondLabel.Text = "✔";
                        auto.AirCondLabel.ForeColor = Color.Green;
                    }
                    else
                    {
                        auto.AirCondLabel.Text = "✘";
                        auto.AirCondLabel.ForeColor = Color.Red;
                    }
                    if (item.radar)
                    {
                        auto.RadarLabel.Text = "✔";
                        auto.RadarLabel.ForeColor = Color.Green;
                    }
                    else
                    {
                        auto.RadarLabel.Text = "✘";
                        auto.RadarLabel.ForeColor = Color.Red;
                    }
                    if (item.cruiseControl)
                    {
                        auto.CruiseControlLabel.Text = "✔";
                        auto.CruiseControlLabel.ForeColor = Color.Green;
                    }
                    else
                    {
                        auto.CruiseControlLabel.Text = "✘";
                        auto.CruiseControlLabel.ForeColor = Color.Red;
                    }
                    auto.OneToFiveLabel.Text = item.OneToFive.ToString();
                    auto.SixToFourteenLabel.Text = item.SixToForteen.ToString();
                    auto.FromFifteenLabel.Text = item.OverForteen.ToString();
                    auto.DepositLabel.Text = item.Deposit.ToString();
                    auto.CategoryLabel.Text = item.category;
                    if (Token.role.ToLower() != "admin")
                    {
                        auto.UpdateBtn.Text = "ⓘ";
                        auto.UpdateBtn.ForeColor = Color.Blue;
                    }
                    CarPanel.Controls.Add(auto);
                    auto.DeleteBtn.Click += async (s, e) =>
                    {
                        AllCars= await httpRequests.DeleteCar(item.id);
                        CarList();
                        IfWorkerSetPanel();
                    };
                    auto.UpdateBtn.Click += (s, e) =>
                    {
                        LicensePlateTB.Enabled = false;
                        
                        string filePath = this.GetType().Assembly.Location;
                        string[] filePathSplit = filePath.Split('\\');
                        string checkfile = "";
                        for (int i = 0; i < filePathSplit.Length - 5; i++)
                        {
                            checkfile += filePathSplit[i] + "\\";
                        }
                        checkfile += "képek\\" + item.picture;
                        CarPictureBox.ImageLocation = checkfile;
                        LicensePlateTB.Text = item.licensePlate;
                        BrandTB.Text = item.brand;
                        TypeTB.Text = item.type;
                        ShiftCB.SelectedIndex = ShiftCB.Items.IndexOf(item.gearShift);
                        YearCB.SelectedIndex= YearCB.Items.IndexOf(int.Parse(item.year));
                        DriveCB.Text = item.drive;
                        FuelCB.Text = item.fuel;
                        AirCondChB.Checked = Convert.ToBoolean(item.airCondition);
                        RadarChB.Checked = Convert.ToBoolean(item.radar);
                        CruiseControlChB.Checked = Convert.ToBoolean(item.cruiseControl);
                        textBox5.Text = item.info;
                        CategoryCB.Text = item.category;
                        OneToFiveRentalTB.Text = item.OneToFive.ToString();
                        SixToFourteenRentalTB.Text = item.SixToForteen.ToString();
                        FromFifteenRentalTB.Text = item.OverForteen.ToString();
                        DepositTB.Text = item.Deposit.ToString();
                    };
                    auto.Top = (count - 1) * auto.Height;
                }
                count = 0;
                foreach (OneCar item in CarPanel.Controls)
                {
                    item.UpdateBtn.Click += (s, e) =>
                    {
                        AddCarBtn.Text = "Módosítás";
                    };
                }
                IfWorkerSetPanel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        private void Clear()
        {
            CarPictureBox.Image = null;
            BrandTB.Text = "";
            TypeTB.Text = "";
            YearCB.SelectedIndex = 0;
            DriveCB.SelectedIndex = 0;
            ShiftCB.SelectedIndex = 0;
            FuelCB.SelectedIndex = 0;
            LicensePlateTB.Text = "";
            AirCondChB.Checked = false;
            RadarChB.Checked = false;
            CruiseControlChB.Checked = false;
            textBox5.Text = "";
            CategoryCB.SelectedIndex = 0;
            OneToFiveRentalTB.Text = "";
            SixToFourteenRentalTB.Text = "";
            FromFifteenRentalTB.Text = "";
            DepositTB.Text = "";
        }
        private void IfWorkerSetPanel()
        {
            if (Token.role == "Dolgozó")
            {
                foreach (OneCar item in CarPanel.Controls)
                {
                    item.DeleteBtn.Hide();
                    item.UpdateBtn.Height = 46;
                }
            }
        }
        private void IfWorker()
        {
            if (Token.role == "Dolgozó")
            {
                BrandTB.Enabled = false;
                TypeTB.Enabled = false;
                YearCB.Enabled = false;
                DriveCB.Enabled = false;
                ShiftCB.Enabled = false;
                FuelCB.Enabled = false;
                AirCondChB.Enabled = false;
                RadarChB.Enabled = false;
                CruiseControlChB.Enabled = false;
                textBox5.Enabled = false;
                CategoryCB.Enabled = false;
                OneToFiveRentalTB.Enabled = false;
                SixToFourteenRentalTB.Enabled = false;
                FromFifteenRentalTB.Enabled = false;
                DepositTB.Enabled = false;
                LicensePlateTB.Enabled = false;
                CarPictureBox.Enabled = false;
                AddCarBtn.Enabled = false;
                AddCarBtn.Hide();
                CancleBtn.Hide();
            }
        }
        private void SetPictureBox()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            CarPictureBox.Click += (sender, e) =>
            {
                ofd.ShowDialog();
                object path = ofd.FileName;
                CarPictureBox.ImageLocation = path.ToString();
            };
        }
        private void SetButtons()
        {
            AddCarBtn.Click += (s, e) => {
                if (AddCarBtn.Text == "Hozzáadás")
                {
                    AddOneCar();
                }
                else
                {
                    UpdateCar();
                    LicensePlateTB.Enabled = true;
                }

            };

            foreach (OneCar item in CarPanel.Controls)
            {
                item.UpdateBtn.Click += (s, e) =>
                {
                    AddCarBtn.Text = "Módosítás";
                };
            }
        }
        private void SetComboBoxes()
        {
            int year = Convert.ToInt32(DateTime.Now.Year);
            for (int i = year; i >= 1900; i--)
            {
                YearCB.Items.Add(i);
            }
            YearCB.DropDownStyle = ComboBoxStyle.DropDownList;
            YearCB.SelectedIndex = 0;
            

            ShiftCB.Items.Add("Manuális");
            ShiftCB.Items.Add("Autómata");
            ShiftCB.DropDownStyle = ComboBoxStyle.DropDownList;
            ShiftCB.SelectedIndex = 0;

            DriveCB.Items.Add("Elsőkerék");
            DriveCB.Items.Add("Hátsókerék");
            DriveCB.Items.Add("Összkerék");
            DriveCB.DropDownStyle = ComboBoxStyle.DropDownList;
            DriveCB.SelectedIndex = 0;

            FuelCB.Items.Add("Benzin");
            FuelCB.Items.Add("Dízel");
            FuelCB.Items.Add("Hibrid");
            FuelCB.Items.Add("Elektromos");
            FuelCB.DropDownStyle = ComboBoxStyle.DropDownList;
            FuelCB.SelectedIndex = 0;

            CategoryCB.Items.Add("Kisautó");
            CategoryCB.Items.Add("Egyterű autó");
            CategoryCB.Items.Add("Kombi autó");
            CategoryCB.Items.Add("Ferdehátú autó");
            CategoryCB.Items.Add("SUV");
            CategoryCB.Items.Add("7 személyes autó");
            CategoryCB.DropDownStyle = ComboBoxStyle.DropDownList;
            CategoryCB.SelectedIndex = 0;
        }
        private bool CheckIfEmpty()
        {
            if (string.IsNullOrEmpty(LicensePlateTB.Text) || string.IsNullOrEmpty(BrandTB.Text) || string.IsNullOrEmpty(TypeTB.Text) || string.IsNullOrEmpty(YearCB.Text) || string.IsNullOrEmpty(DriveCB.Text) || string.IsNullOrEmpty(ShiftCB.Text) || string.IsNullOrEmpty(FuelCB.Text) || string.IsNullOrEmpty(CategoryCB.Text) || string.IsNullOrEmpty(OneToFiveRentalTB.Text) || string.IsNullOrEmpty(SixToFourteenRentalTB.Text) || string.IsNullOrEmpty(FromFifteenRentalTB.Text) || string.IsNullOrEmpty(DepositTB.Text))
            {
                return true;
            }
            return false;
        }
        private string CheckPictureBox(string image)
        {
            if (image == null ||image=="")
            {
                MessageBox.Show("Kérem válasszon ki egy képet!");
                return null;
            }
            string[] imageSplit = image.Split('\\');
            string filePath=this.GetType().Assembly.Location;
            string[] filePathSplit = filePath.Split('\\');
            string checkfile = "";
            for (int i = 0; i < filePathSplit.Length - 5; i++)
            {
                checkfile += filePathSplit[i] + "\\";
            }
            checkfile += "képek\\";
            if (image!= checkfile + imageSplit[imageSplit.Length-1])
            {
                
                MessageBox.Show("Kép helye nem megfelelő!");
                return null;
            }
            return imageSplit[imageSplit.Length-1];
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
            this.LicensePlateHeaderLabel = new System.Windows.Forms.Label();
            this.CarHeaderLabel = new System.Windows.Forms.Label();
            this.YearHeaderLabel = new System.Windows.Forms.Label();
            this.DriveHeaderLabel = new System.Windows.Forms.Label();
            this.ShiftHeaderLabel = new System.Windows.Forms.Label();
            this.FuelHeaderLabel = new System.Windows.Forms.Label();
            this.AirCondHeaderLabel = new System.Windows.Forms.Label();
            this.RadarHeaderLabel = new System.Windows.Forms.Label();
            this.CruiseControlHeaderLabel = new System.Windows.Forms.Label();
            this.CarPanel = new System.Windows.Forms.Panel();
            this.CategoryHeaderLabel = new System.Windows.Forms.Label();
            this.CategoriLabel = new System.Windows.Forms.Label();
            this.CategoryCB = new System.Windows.Forms.ComboBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.YearCB = new System.Windows.Forms.ComboBox();
            this.LicensePlateLabel = new System.Windows.Forms.Label();
            this.LicensePlateTB = new System.Windows.Forms.TextBox();
            this.DepositeHeaderLabel = new System.Windows.Forms.Label();
            this.FromFifteenHeaderLabel = new System.Windows.Forms.Label();
            this.SixToFourteenHeaderLabel = new System.Windows.Forms.Label();
            this.OneToFiveHeaderLabel = new System.Windows.Forms.Label();
            this.CancleBtn = new System.Windows.Forms.Button();
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
            this.BrandLabel.Location = new System.Drawing.Point(252, 60);
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
            this.DriveLabel.Location = new System.Drawing.Point(252, 109);
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
            this.ShiftLabel.Location = new System.Drawing.Point(467, 108);
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
            this.FuelLabel.Location = new System.Drawing.Point(252, 132);
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
            this.TypeLabel.Location = new System.Drawing.Point(467, 84);
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
            this.AirCondLabel.Location = new System.Drawing.Point(667, 63);
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
            this.RadarLabel.Location = new System.Drawing.Point(666, 88);
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
            this.CruiseControlLabel.Location = new System.Drawing.Point(666, 112);
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
            this.OtherInfoLabel.Location = new System.Drawing.Point(383, 179);
            this.OtherInfoLabel.Name = "OtherInfoLabel";
            this.OtherInfoLabel.Size = new System.Drawing.Size(135, 18);
            this.OtherInfoLabel.TabIndex = 17;
            this.OtherInfoLabel.Text = "Egyébb információ:";
            // 
            // BrandTB
            // 
            this.BrandTB.Location = new System.Drawing.Point(339, 61);
            this.BrandTB.Name = "BrandTB";
            this.BrandTB.Size = new System.Drawing.Size(100, 20);
            this.BrandTB.TabIndex = 18;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(386, 196);
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
            this.TypeTB.Location = new System.Drawing.Point(546, 84);
            this.TypeTB.Name = "TypeTB";
            this.TypeTB.Size = new System.Drawing.Size(100, 20);
            this.TypeTB.TabIndex = 27;
            // 
            // DriveCB
            // 
            this.DriveCB.FormattingEnabled = true;
            this.DriveCB.Location = new System.Drawing.Point(339, 109);
            this.DriveCB.Name = "DriveCB";
            this.DriveCB.Size = new System.Drawing.Size(121, 21);
            this.DriveCB.TabIndex = 28;
            // 
            // ShiftCB
            // 
            this.ShiftCB.FormattingEnabled = true;
            this.ShiftCB.Location = new System.Drawing.Point(546, 109);
            this.ShiftCB.Name = "ShiftCB";
            this.ShiftCB.Size = new System.Drawing.Size(121, 21);
            this.ShiftCB.TabIndex = 29;
            // 
            // FuelCB
            // 
            this.FuelCB.FormattingEnabled = true;
            this.FuelCB.Location = new System.Drawing.Point(339, 132);
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
            this.AirCondChB.Location = new System.Drawing.Point(758, 67);
            this.AirCondChB.Name = "AirCondChB";
            this.AirCondChB.Size = new System.Drawing.Size(15, 14);
            this.AirCondChB.TabIndex = 32;
            this.AirCondChB.UseVisualStyleBackColor = false;
            // 
            // RadarChB
            // 
            this.RadarChB.AutoSize = true;
            this.RadarChB.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.RadarChB.Location = new System.Drawing.Point(758, 92);
            this.RadarChB.Name = "RadarChB";
            this.RadarChB.Size = new System.Drawing.Size(15, 14);
            this.RadarChB.TabIndex = 33;
            this.RadarChB.UseVisualStyleBackColor = false;
            // 
            // CruiseControlChB
            // 
            this.CruiseControlChB.AutoSize = true;
            this.CruiseControlChB.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CruiseControlChB.Location = new System.Drawing.Point(758, 116);
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
            // LicensePlateHeaderLabel
            // 
            this.LicensePlateHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LicensePlateHeaderLabel.Location = new System.Drawing.Point(1, 269);
            this.LicensePlateHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LicensePlateHeaderLabel.Name = "LicensePlateHeaderLabel";
            this.LicensePlateHeaderLabel.Size = new System.Drawing.Size(67, 15);
            this.LicensePlateHeaderLabel.TabIndex = 36;
            this.LicensePlateHeaderLabel.Text = "Rendszám";
            this.LicensePlateHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CarHeaderLabel
            // 
            this.CarHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CarHeaderLabel.Location = new System.Drawing.Point(69, 269);
            this.CarHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CarHeaderLabel.Name = "CarHeaderLabel";
            this.CarHeaderLabel.Size = new System.Drawing.Size(75, 15);
            this.CarHeaderLabel.TabIndex = 37;
            this.CarHeaderLabel.Text = "Autó";
            this.CarHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YearHeaderLabel
            // 
            this.YearHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YearHeaderLabel.Location = new System.Drawing.Point(145, 269);
            this.YearHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.YearHeaderLabel.Name = "YearHeaderLabel";
            this.YearHeaderLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.YearHeaderLabel.Size = new System.Drawing.Size(35, 15);
            this.YearHeaderLabel.TabIndex = 39;
            this.YearHeaderLabel.Text = "Év";
            // 
            // DriveHeaderLabel
            // 
            this.DriveHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DriveHeaderLabel.Location = new System.Drawing.Point(181, 269);
            this.DriveHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DriveHeaderLabel.Name = "DriveHeaderLabel";
            this.DriveHeaderLabel.Size = new System.Drawing.Size(65, 15);
            this.DriveHeaderLabel.TabIndex = 40;
            this.DriveHeaderLabel.Text = "Meghajtás";
            this.DriveHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShiftHeaderLabel
            // 
            this.ShiftHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ShiftHeaderLabel.Location = new System.Drawing.Point(247, 269);
            this.ShiftHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ShiftHeaderLabel.Name = "ShiftHeaderLabel";
            this.ShiftHeaderLabel.Size = new System.Drawing.Size(34, 15);
            this.ShiftHeaderLabel.TabIndex = 41;
            this.ShiftHeaderLabel.Text = "Váltó";
            this.ShiftHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FuelHeaderLabel
            // 
            this.FuelHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FuelHeaderLabel.Location = new System.Drawing.Point(282, 269);
            this.FuelHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FuelHeaderLabel.Name = "FuelHeaderLabel";
            this.FuelHeaderLabel.Size = new System.Drawing.Size(73, 15);
            this.FuelHeaderLabel.TabIndex = 42;
            this.FuelHeaderLabel.Text = "Üzemanyag";
            this.FuelHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AirCondHeaderLabel
            // 
            this.AirCondHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AirCondHeaderLabel.Location = new System.Drawing.Point(356, 269);
            this.AirCondHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AirCondHeaderLabel.Name = "AirCondHeaderLabel";
            this.AirCondHeaderLabel.Size = new System.Drawing.Size(39, 15);
            this.AirCondHeaderLabel.TabIndex = 43;
            this.AirCondHeaderLabel.Text = "Klíma";
            this.AirCondHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RadarHeaderLabel
            // 
            this.RadarHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadarHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadarHeaderLabel.Location = new System.Drawing.Point(396, 269);
            this.RadarHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.RadarHeaderLabel.Name = "RadarHeaderLabel";
            this.RadarHeaderLabel.Size = new System.Drawing.Size(41, 15);
            this.RadarHeaderLabel.TabIndex = 44;
            this.RadarHeaderLabel.Text = "Radar";
            this.RadarHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CruiseControlHeaderLabel
            // 
            this.CruiseControlHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CruiseControlHeaderLabel.Location = new System.Drawing.Point(438, 269);
            this.CruiseControlHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CruiseControlHeaderLabel.Name = "CruiseControlHeaderLabel";
            this.CruiseControlHeaderLabel.Size = new System.Drawing.Size(67, 15);
            this.CruiseControlHeaderLabel.TabIndex = 45;
            this.CruiseControlHeaderLabel.Text = "Tempomat";
            this.CruiseControlHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CarPanel
            // 
            this.CarPanel.Location = new System.Drawing.Point(0, 286);
            this.CarPanel.Name = "CarPanel";
            this.CarPanel.Size = new System.Drawing.Size(785, 243);
            this.CarPanel.TabIndex = 51;
            // 
            // CategoryHeaderLabel
            // 
            this.CategoryHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CategoryHeaderLabel.Location = new System.Drawing.Point(685, 269);
            this.CategoryHeaderLabel.Name = "CategoryHeaderLabel";
            this.CategoryHeaderLabel.Size = new System.Drawing.Size(62, 15);
            this.CategoryHeaderLabel.TabIndex = 52;
            this.CategoryHeaderLabel.Text = "Kategória";
            this.CategoryHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CategoriLabel
            // 
            this.CategoriLabel.AutoSize = true;
            this.CategoriLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CategoriLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CategoriLabel.Location = new System.Drawing.Point(467, 131);
            this.CategoriLabel.Name = "CategoriLabel";
            this.CategoriLabel.Size = new System.Drawing.Size(75, 18);
            this.CategoriLabel.TabIndex = 53;
            this.CategoriLabel.Text = "Kategória:";
            // 
            // CategoryCB
            // 
            this.CategoryCB.FormattingEnabled = true;
            this.CategoryCB.Location = new System.Drawing.Point(546, 133);
            this.CategoryCB.Name = "CategoryCB";
            this.CategoryCB.Size = new System.Drawing.Size(121, 21);
            this.CategoryCB.TabIndex = 54;
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YearLabel.Location = new System.Drawing.Point(252, 86);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(57, 18);
            this.YearLabel.TabIndex = 55;
            this.YearLabel.Text = "Évjárat:";
            // 
            // YearCB
            // 
            this.YearCB.FormattingEnabled = true;
            this.YearCB.Location = new System.Drawing.Point(339, 85);
            this.YearCB.Name = "YearCB";
            this.YearCB.Size = new System.Drawing.Size(121, 21);
            this.YearCB.TabIndex = 56;
            // 
            // LicensePlateLabel
            // 
            this.LicensePlateLabel.AutoSize = true;
            this.LicensePlateLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.LicensePlateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LicensePlateLabel.Location = new System.Drawing.Point(467, 60);
            this.LicensePlateLabel.Name = "LicensePlateLabel";
            this.LicensePlateLabel.Size = new System.Drawing.Size(84, 18);
            this.LicensePlateLabel.TabIndex = 57;
            this.LicensePlateLabel.Text = "Rendszám:";
            // 
            // LicensePlateTB
            // 
            this.LicensePlateTB.Location = new System.Drawing.Point(546, 60);
            this.LicensePlateTB.Name = "LicensePlateTB";
            this.LicensePlateTB.Size = new System.Drawing.Size(100, 20);
            this.LicensePlateTB.TabIndex = 58;
            // 
            // DepositeHeaderLabel
            // 
            this.DepositeHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DepositeHeaderLabel.Location = new System.Drawing.Point(639, 269);
            this.DepositeHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DepositeHeaderLabel.Name = "DepositeHeaderLabel";
            this.DepositeHeaderLabel.Size = new System.Drawing.Size(45, 15);
            this.DepositeHeaderLabel.TabIndex = 50;
            this.DepositeHeaderLabel.Text = "Kaució";
            this.DepositeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FromFifteenHeaderLabel
            // 
            this.FromFifteenHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FromFifteenHeaderLabel.Location = new System.Drawing.Point(593, 269);
            this.FromFifteenHeaderLabel.Name = "FromFifteenHeaderLabel";
            this.FromFifteenHeaderLabel.Size = new System.Drawing.Size(45, 15);
            this.FromFifteenHeaderLabel.TabIndex = 49;
            this.FromFifteenHeaderLabel.Text = "15-";
            this.FromFifteenHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SixToFourteenHeaderLabel
            // 
            this.SixToFourteenHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SixToFourteenHeaderLabel.Location = new System.Drawing.Point(547, 269);
            this.SixToFourteenHeaderLabel.Name = "SixToFourteenHeaderLabel";
            this.SixToFourteenHeaderLabel.Size = new System.Drawing.Size(45, 15);
            this.SixToFourteenHeaderLabel.TabIndex = 48;
            this.SixToFourteenHeaderLabel.Text = "6-14";
            this.SixToFourteenHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OneToFiveHeaderLabel
            // 
            this.OneToFiveHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OneToFiveHeaderLabel.Location = new System.Drawing.Point(506, 269);
            this.OneToFiveHeaderLabel.Name = "OneToFiveHeaderLabel";
            this.OneToFiveHeaderLabel.Size = new System.Drawing.Size(40, 15);
            this.OneToFiveHeaderLabel.TabIndex = 47;
            this.OneToFiveHeaderLabel.Text = "1-5";
            this.OneToFiveHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancleBtn
            // 
            this.CancleBtn.Location = new System.Drawing.Point(695, 219);
            this.CancleBtn.Name = "CancleBtn";
            this.CancleBtn.Size = new System.Drawing.Size(89, 23);
            this.CancleBtn.TabIndex = 59;
            this.CancleBtn.Text = "Mégse";
            this.CancleBtn.UseVisualStyleBackColor = true;
            // 
            // AddCar
            // 
            this.Controls.Add(this.CancleBtn);
            this.Controls.Add(this.LicensePlateTB);
            this.Controls.Add(this.LicensePlateLabel);
            this.Controls.Add(this.YearCB);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.CategoryCB);
            this.Controls.Add(this.CategoriLabel);
            this.Controls.Add(this.CategoryHeaderLabel);
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
            this.Controls.Add(this.CarHeaderLabel);
            this.Controls.Add(this.LicensePlateHeaderLabel);
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
