using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    public class PersonalInfos:UserControl
    {
        private DataGridView InfoDGV;
        private TextBox RealNameTB;
        private Label NameLabel;
        private Label BirthLabel;
        private MonthCalendar monthCalendar1;
        private Label AdressLabel;
        private TextBox AdressTB;
        private Label EmailLabel;
        private TextBox EmailTB;
        private TextBox PhoneTB;
        private Label PhoneLabel;
        private TextBox TaxTB;
        private Label TaxLabel;
        private Button RegisterBtn;
        public Panel PersonalInfosPanel;
        private DataGridView HeaderDGV;
        private Label UserLabel;
        private TextBox UserTB;
        private TextBox PasswordTB;
        private Label PasswordLabel;
        private TextBox PasswordAgainTB;
        private Label PasswordAgainLabel;
        private Label AdminHeaderLabel;
        private Label NameHeaderLabel;
        private Label AdressHeaderLabel;
        private Label TaxHeaderLabel;
        private Label BirthHeaderLabel;
        private Label PhoneHeaderLabel;
        private Label EmailHeaderLabel;
        private Label UserNameHeaderLabel;
        private Label PersonalILabel;
        private ComboBox RoleCB;
        private Label AdminLabel;
        private Button CancleBtn;
        private PictureBox ShowPassPB;
        private PictureBox ShowPassAgainPB;
        List<jsonPersonalInfo> workers = new List<jsonPersonalInfo>();
        HttpRequests httpRequests = new HttpRequests();
        string file = "";
        public PersonalInfos()
        {
            InitializeComponent();
            Start();
        }
        async void Start()
        {

            PersonalInfosPanel.AutoScroll = true;
            CancleBtn.Hide();
            SetComboBox();

            //Sets the button click events
            RegisterBtn.Click += (s, e) => {
                if (RegisterBtn.Text == "Regisztráció")
                {
                    Register();
                }
                else
                {
                    Update();
                }
            };
            CancleBtn.Click += (s, e) =>
            {
                RegisterBtn.Text = "Regisztráció";
                Clear();
                CancleBtn.Hide();
            };

            //Loads the workers from the database
            workers = await httpRequests.ListAllWorkers();
            OrderList();

            //Sets the password textboxes to hide the password
            PasswordTB.PasswordChar = '*';
            PasswordAgainTB.PasswordChar = '*';

            //Sets the image location for the show password buttons
            string filePath = this.GetType().Assembly.Location;
            string[] filePathSplit = filePath.Split('\\');
            
            for (int i = 0; i < filePathSplit.Length - 5; i++)
            {
                file += filePathSplit[i] + "\\";
            }
            ShowPassPB.ImageLocation = file + "képek\\eye.png";
            ShowPassAgainPB.ImageLocation = file + "képek\\eye.png";

            //Sets the click events for the show password buttons
            ShowPassPB.Click += (s, e) => ShowPass(ShowPassPB,PasswordTB);
            ShowPassAgainPB.Click += (s, e) => ShowPass(ShowPassAgainPB, PasswordAgainTB);
            //Loads the workers from the database
            ListWorkers();
        }
        ///Shows the password in the textbox
        void ShowPass(PictureBox picture,TextBox text)
        {
            if (text.PasswordChar == '*')
            {
                text.PasswordChar = '\0';
                picture.ImageLocation = file + "képek\\hidden.png";
            }
            else
            {
                text.PasswordChar = '*';
                picture.ImageLocation = file+ "képek\\eye.png";
            }
        }
        ///Registers a new worker
        async void Register()
        {
            if (CheckEmpty())
            {
                return;
            }
            if (!CheckPassword(PasswordTB.Text, PasswordAgainTB.Text))
            {
                return;
            }
            jsonPersonalInfo personalInfo = new jsonPersonalInfo();
            personalInfo.username = UserTB.Text;
            personalInfo.password = PasswordTB.Text;
            personalInfo.role = RoleCB.Text;
            personalInfo.realName = RealNameTB.Text;
            personalInfo.address = AdressTB.Text;
            personalInfo.email = EmailTB.Text;
            personalInfo.phone = PhoneTB.Text;
            personalInfo.birth=new DateTime(monthCalendar1.SelectionStart.Year, monthCalendar1.SelectionStart.Month, monthCalendar1.SelectionStart.Day,2,2,2);
            personalInfo.tax = TaxTB.Text;
            workers=await httpRequests.Registration(personalInfo);
            ListWorkers();
            Clear();
        }
        //Updates a worker
        private async void Update()
        {
            if (CheckEmpty())
            {
                return;
            }
            if (!CheckPassword(PasswordTB.Text, PasswordAgainTB.Text))
            {
                return;
            }
            jsonPersonalInfo personalInfo = new jsonPersonalInfo();
            personalInfo.username = UserTB.Text;
            personalInfo.password = PasswordTB.Text;
            personalInfo.role = RoleCB.Text;
            personalInfo.realName = RealNameTB.Text;
            personalInfo.address = AdressTB.Text;
            personalInfo.email = EmailTB.Text;
            personalInfo.phone = PhoneTB.Text;
            personalInfo.birth = new DateTime(monthCalendar1.SelectionStart.Year, monthCalendar1.SelectionStart.Month, monthCalendar1.SelectionStart.Day, 2, 2, 2);
            personalInfo.tax = TaxTB.Text;
            personalInfo.id = Convert.ToInt32(RegisterBtn.TabIndex);
            workers = await httpRequests.UpdateWorker(personalInfo);
            ListWorkers();
            RegisterBtn.Text = "Regisztráció";
            Clear();
            CancleBtn.Hide();
        }
        //Lists the workers in the panel
        void ListWorkers()
        {
            try
            {
                int count = 0;
                PersonalInfosPanel.Controls.Clear();
                foreach (jsonPersonalInfo item in workers)
                {
                    OnePersonalInfo inf = new OnePersonalInfo();
                    inf.RealNameLabel.Text = item.realName;
                    inf.AdressLabel.Text = item.address;
                    inf.TaxLabel.Text = item.tax;
                    inf.BirthLabel.Text = item.birth.ToString();
                    inf.PhoneLabel.Text = item.phone;
                    inf.EmailLabel.Text = item.email;
                    inf.UserLabel.Text = item.username;
                    inf.RoleLabel.Text = item.role;
                    inf.Top = (count)*inf.Height;
                    inf.DeleteBtn.Click += async (s, e) =>
                    {
                        DialogResult result = MessageBox.Show("Biztosan törölni szeretné a dolgozót?", "Törlés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result==DialogResult.Yes)
                        {
                            workers = await httpRequests.DeleteWorker(item.id);
                            ListWorkers();
                        }
                    };
                    inf.UpdateBtn.Click += (s, e) =>
                    {
                        CancleBtn.Show();
                        RealNameTB.Text = item.realName;
                        AdressTB.Text = item.address;
                        EmailTB.Text = item.email;
                        PhoneTB.Text = item.phone;
                        TaxTB.Text = item.tax;
                        UserTB.Text = item.username;
                        PasswordTB.Text = httpRequests.DecodePassword(item.password);
                        PasswordAgainTB.Text = httpRequests.DecodePassword(item.password);
                        RoleCB.Text = item.role;
                        monthCalendar1.SetDate(item.birth);
                        RegisterBtn.TabIndex =item.id;
                        RegisterBtn.Text = "Módosítás";
                    };
                    PersonalInfosPanel.Controls.Add(inf);
                    count++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //Clears the textboxes
        private void Clear()
        {
            RealNameTB.Text = "";
            AdressTB.Text = "";
            EmailTB.Text = "";
            PhoneTB.Text = "";
            TaxTB.Text = "";
            UserTB.Text = "";
            PasswordTB.Text = "";
            PasswordAgainTB.Text = "";
            RoleCB.Text = "";
            monthCalendar1.SetDate(DateTime.Now);
        }
        //Sets the combobox for the role
        private void SetComboBox()
        {
            RoleCB.Items.Add("Admin");
            RoleCB.Items.Add("Dolgozó");
            RoleCB.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleCB.SelectedIndex = 1;
        }
        //Checks if the password is the same
        private bool CheckPassword(string pass, string otherPass)
        {
            if (pass==otherPass)
            {
                return true;
            }
            else
            {
                MessageBox.Show("A jelszavak nem egyeznek meg!");
                return false;
            }
        }
        //Orders the list of workers by the selected header
        private void OrderList()
        {
            bool isAscU=true;
            UserNameHeaderLabel.Click += async (s, e) =>
            {
                workers = await httpRequests.ListAllWorkers();
                if (isAscU)
                {
                    workers = workers.OrderBy(x => x.username).ToList();
                    isAscU = false;
                }
                else
                {
                    workers = workers.OrderByDescending(x => x.username).ToList();
                    isAscU = true;
                }
                ListWorkers();
            };
            bool isAscE = true;
            EmailHeaderLabel.Click += async (s, e) =>
            {
                workers = await httpRequests.ListAllWorkers();
                if (isAscE)
                {
                    workers = workers.OrderBy(x => x.email).ToList();
                    isAscE = false;
                }
                else
                {
                    workers = workers.OrderByDescending(x => x.email).ToList();
                    isAscE = true;
                }
                ListWorkers();
            };
            bool isAscP = true;
            PhoneHeaderLabel.Click += async (s, e) =>
            {
                workers = await httpRequests.ListAllWorkers();
                if (isAscP)
                {
                    workers = workers.OrderBy(x => x.phone).ToList();
                    isAscP = false;
                }
                else
                {
                    workers = workers.OrderByDescending(x => x.phone).ToList();
                    isAscP = true;
                };
                ListWorkers();
            };
            bool isAscB = true;
            BirthHeaderLabel.Click += async (s, e) =>
            {
                workers = await httpRequests.ListAllWorkers();
                if (isAscB)
                {
                    workers = workers.OrderBy(x => x.birth).ToList();
                    isAscB = false;
                }
                else
                {
                    workers = workers.OrderByDescending(x => x.birth).ToList();
                    isAscB = true;
                }
                ListWorkers();
            };
            bool isAscT = true;
            TaxHeaderLabel.Click += async (s, e) =>
            {
                workers = await httpRequests.ListAllWorkers();
                if (isAscT)
                {
                    workers = workers.OrderBy(x => x.tax).ToList();
                    isAscT = false;
                }
                else
                {
                    workers = workers.OrderByDescending(x => x.tax).ToList();
                    isAscT = true;
                }
                ListWorkers();
            };
            bool isAscA = true;
            AdressHeaderLabel.Click += async (s, e) =>
            {
                workers = await httpRequests.ListAllWorkers();
                if (isAscA)
                {
                    workers = workers.OrderBy(x => x.address).ToList();
                    isAscA = false;
                }
                else
                {
                    workers = workers.OrderByDescending(x => x.address).ToList();
                    isAscA = true;
                }
                ListWorkers();
            };
            bool isAscN = true;
            NameHeaderLabel.Click += async (s, e) =>
            {
                workers = await httpRequests.ListAllWorkers();
                if (isAscN)
                {
                    workers = workers.OrderBy(x => x.realName).ToList();
                    isAscN = false;
                }
                else
                {
                    workers = workers.OrderByDescending(x => x.realName).ToList();
                    isAscN = true;
                }
                ListWorkers();
            };
            bool isAscAdmin = true;
            AdminHeaderLabel.Click += async (s, e) =>
            {
                workers = await httpRequests.ListAllWorkers();
                if (isAscAdmin)
                {
                    workers = workers.OrderBy(x => x.role).ToList();
                    isAscAdmin = false;
                }
                else
                {
                    workers = workers.OrderByDescending(x => x.role).ToList();
                    isAscAdmin = true;
                }
                ListWorkers();
            };
            
        }
        //Checks if the textboxes are empty
        private bool CheckEmpty()
        {
            if (RealNameTB.Text == "" || AdressTB.Text == "" || EmailTB.Text == "" || PhoneTB.Text == "" || TaxTB.Text == "" || UserTB.Text == "" || PasswordTB.Text == "" || PasswordAgainTB.Text == "")
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
                return true;
            }
            return false;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalInfos));
            this.PersonalILabel = new System.Windows.Forms.Label();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this.RealNameTB = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.BirthLabel = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.AdressLabel = new System.Windows.Forms.Label();
            this.AdressTB = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.PhoneTB = new System.Windows.Forms.TextBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.TaxTB = new System.Windows.Forms.TextBox();
            this.TaxLabel = new System.Windows.Forms.Label();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.PersonalInfosPanel = new System.Windows.Forms.Panel();
            this.HeaderDGV = new System.Windows.Forms.DataGridView();
            this.UserLabel = new System.Windows.Forms.Label();
            this.UserTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordAgainTB = new System.Windows.Forms.TextBox();
            this.PasswordAgainLabel = new System.Windows.Forms.Label();
            this.AdminHeaderLabel = new System.Windows.Forms.Label();
            this.NameHeaderLabel = new System.Windows.Forms.Label();
            this.AdressHeaderLabel = new System.Windows.Forms.Label();
            this.TaxHeaderLabel = new System.Windows.Forms.Label();
            this.BirthHeaderLabel = new System.Windows.Forms.Label();
            this.PhoneHeaderLabel = new System.Windows.Forms.Label();
            this.EmailHeaderLabel = new System.Windows.Forms.Label();
            this.UserNameHeaderLabel = new System.Windows.Forms.Label();
            this.AdminLabel = new System.Windows.Forms.Label();
            this.RoleCB = new System.Windows.Forms.ComboBox();
            this.CancleBtn = new System.Windows.Forms.Button();
            this.ShowPassPB = new System.Windows.Forms.PictureBox();
            this.ShowPassAgainPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassAgainPB)).BeginInit();
            this.SuspendLayout();
            // 
            // PersonalILabel
            // 
            this.PersonalILabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PersonalILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PersonalILabel.Location = new System.Drawing.Point(0, 0);
            this.PersonalILabel.Name = "PersonalILabel";
            this.PersonalILabel.Size = new System.Drawing.Size(785, 57);
            this.PersonalILabel.TabIndex = 1;
            this.PersonalILabel.Text = "Dolgozók";
            this.PersonalILabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoDGV
            // 
            this.InfoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoDGV.Location = new System.Drawing.Point(0, 57);
            this.InfoDGV.Name = "InfoDGV";
            this.InfoDGV.Size = new System.Drawing.Size(785, 192);
            this.InfoDGV.TabIndex = 4;
            // 
            // RealNameTB
            // 
            this.RealNameTB.Location = new System.Drawing.Point(581, 158);
            this.RealNameTB.Name = "RealNameTB";
            this.RealNameTB.Size = new System.Drawing.Size(190, 20);
            this.RealNameTB.TabIndex = 20;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLabel.Location = new System.Drawing.Point(509, 158);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 18);
            this.NameLabel.TabIndex = 19;
            this.NameLabel.Text = "Név:";
            // 
            // BirthLabel
            // 
            this.BirthLabel.AutoSize = true;
            this.BirthLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BirthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BirthLabel.Location = new System.Drawing.Point(317, 66);
            this.BirthLabel.Name = "BirthLabel";
            this.BirthLabel.Size = new System.Drawing.Size(117, 18);
            this.BirthLabel.TabIndex = 57;
            this.BirthLabel.Text = "Születési dátum:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(319, 84);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 58;
            // 
            // AdressLabel
            // 
            this.AdressLabel.AutoSize = true;
            this.AdressLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AdressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdressLabel.Location = new System.Drawing.Point(509, 67);
            this.AdressLabel.Name = "AdressLabel";
            this.AdressLabel.Size = new System.Drawing.Size(60, 18);
            this.AdressLabel.TabIndex = 59;
            this.AdressLabel.Text = "Lakcím:";
            // 
            // AdressTB
            // 
            this.AdressTB.Location = new System.Drawing.Point(581, 67);
            this.AdressTB.Multiline = true;
            this.AdressTB.Name = "AdressTB";
            this.AdressTB.Size = new System.Drawing.Size(190, 85);
            this.AdressTB.TabIndex = 60;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmailLabel.Location = new System.Drawing.Point(4, 155);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(49, 18);
            this.EmailLabel.TabIndex = 61;
            this.EmailLabel.Text = "Email:";
            // 
            // EmailTB
            // 
            this.EmailTB.Location = new System.Drawing.Point(97, 155);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(190, 20);
            this.EmailTB.TabIndex = 62;
            // 
            // PhoneTB
            // 
            this.PhoneTB.Location = new System.Drawing.Point(97, 185);
            this.PhoneTB.Name = "PhoneTB";
            this.PhoneTB.Size = new System.Drawing.Size(190, 20);
            this.PhoneTB.TabIndex = 64;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PhoneLabel.Location = new System.Drawing.Point(4, 185);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(98, 18);
            this.PhoneLabel.TabIndex = 63;
            this.PhoneLabel.Text = "Telefonszám:";
            // 
            // TaxTB
            // 
            this.TaxTB.Location = new System.Drawing.Point(97, 215);
            this.TaxTB.Name = "TaxTB";
            this.TaxTB.Size = new System.Drawing.Size(190, 20);
            this.TaxTB.TabIndex = 66;
            // 
            // TaxLabel
            // 
            this.TaxLabel.AutoSize = true;
            this.TaxLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TaxLabel.Location = new System.Drawing.Point(4, 215);
            this.TaxLabel.Name = "TaxLabel";
            this.TaxLabel.Size = new System.Drawing.Size(75, 18);
            this.TaxLabel.TabIndex = 65;
            this.TaxLabel.Text = "Adószám:";
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegisterBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RegisterBtn.Location = new System.Drawing.Point(689, 223);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(95, 25);
            this.RegisterBtn.TabIndex = 67;
            this.RegisterBtn.Text = "Regisztráció";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            // 
            // PersonalInfosPanel
            // 
            this.PersonalInfosPanel.Location = new System.Drawing.Point(0, 266);
            this.PersonalInfosPanel.Name = "PersonalInfosPanel";
            this.PersonalInfosPanel.Size = new System.Drawing.Size(785, 264);
            this.PersonalInfosPanel.TabIndex = 68;
            // 
            // HeaderDGV
            // 
            this.HeaderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HeaderDGV.Location = new System.Drawing.Point(0, 248);
            this.HeaderDGV.Name = "HeaderDGV";
            this.HeaderDGV.Size = new System.Drawing.Size(785, 17);
            this.HeaderDGV.TabIndex = 36;
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.UserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UserLabel.Location = new System.Drawing.Point(4, 65);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(115, 18);
            this.UserLabel.TabIndex = 69;
            this.UserLabel.Text = "Felhasználónév:";
            // 
            // UserTB
            // 
            this.UserTB.Location = new System.Drawing.Point(143, 65);
            this.UserTB.Name = "UserTB";
            this.UserTB.Size = new System.Drawing.Size(144, 20);
            this.UserTB.TabIndex = 70;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(143, 95);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(144, 20);
            this.PasswordTB.TabIndex = 72;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PasswordLabel.Location = new System.Drawing.Point(4, 95);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 18);
            this.PasswordLabel.TabIndex = 71;
            this.PasswordLabel.Text = "Jelszó:";
            // 
            // PasswordAgainTB
            // 
            this.PasswordAgainTB.Location = new System.Drawing.Point(143, 125);
            this.PasswordAgainTB.Name = "PasswordAgainTB";
            this.PasswordAgainTB.Size = new System.Drawing.Size(144, 20);
            this.PasswordAgainTB.TabIndex = 74;
            // 
            // PasswordAgainLabel
            // 
            this.PasswordAgainLabel.AutoSize = true;
            this.PasswordAgainLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PasswordAgainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PasswordAgainLabel.Location = new System.Drawing.Point(4, 125);
            this.PasswordAgainLabel.Name = "PasswordAgainLabel";
            this.PasswordAgainLabel.Size = new System.Drawing.Size(142, 18);
            this.PasswordAgainLabel.TabIndex = 73;
            this.PasswordAgainLabel.Text = "Jelszó megerősítés:";
            // 
            // AdminHeaderLabel
            // 
            this.AdminHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdminHeaderLabel.Location = new System.Drawing.Point(664, 249);
            this.AdminHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AdminHeaderLabel.Name = "AdminHeaderLabel";
            this.AdminHeaderLabel.Size = new System.Drawing.Size(57, 15);
            this.AdminHeaderLabel.TabIndex = 84;
            this.AdminHeaderLabel.Text = "Beosztás";
            this.AdminHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameHeaderLabel
            // 
            this.NameHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameHeaderLabel.Location = new System.Drawing.Point(563, 249);
            this.NameHeaderLabel.Name = "NameHeaderLabel";
            this.NameHeaderLabel.Size = new System.Drawing.Size(100, 15);
            this.NameHeaderLabel.TabIndex = 83;
            this.NameHeaderLabel.Text = "Név";
            this.NameHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdressHeaderLabel
            // 
            this.AdressHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdressHeaderLabel.Location = new System.Drawing.Point(462, 249);
            this.AdressHeaderLabel.Name = "AdressHeaderLabel";
            this.AdressHeaderLabel.Size = new System.Drawing.Size(100, 15);
            this.AdressHeaderLabel.TabIndex = 82;
            this.AdressHeaderLabel.Text = "Lakcím";
            this.AdressHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaxHeaderLabel
            // 
            this.TaxHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TaxHeaderLabel.Location = new System.Drawing.Point(381, 249);
            this.TaxHeaderLabel.Name = "TaxHeaderLabel";
            this.TaxHeaderLabel.Size = new System.Drawing.Size(80, 15);
            this.TaxHeaderLabel.TabIndex = 81;
            this.TaxHeaderLabel.Text = "Adószám";
            this.TaxHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BirthHeaderLabel
            // 
            this.BirthHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BirthHeaderLabel.Location = new System.Drawing.Point(285, 249);
            this.BirthHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BirthHeaderLabel.Name = "BirthHeaderLabel";
            this.BirthHeaderLabel.Size = new System.Drawing.Size(95, 15);
            this.BirthHeaderLabel.TabIndex = 80;
            this.BirthHeaderLabel.Text = "Születési dátum";
            this.BirthHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneHeaderLabel
            // 
            this.PhoneHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PhoneHeaderLabel.Location = new System.Drawing.Point(193, 249);
            this.PhoneHeaderLabel.Name = "PhoneHeaderLabel";
            this.PhoneHeaderLabel.Size = new System.Drawing.Size(91, 15);
            this.PhoneHeaderLabel.TabIndex = 79;
            this.PhoneHeaderLabel.Text = "Telefonszám";
            this.PhoneHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmailHeaderLabel
            // 
            this.EmailHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmailHeaderLabel.Location = new System.Drawing.Point(97, 249);
            this.EmailHeaderLabel.Name = "EmailHeaderLabel";
            this.EmailHeaderLabel.Size = new System.Drawing.Size(95, 15);
            this.EmailHeaderLabel.TabIndex = 78;
            this.EmailHeaderLabel.Text = "Email";
            this.EmailHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserNameHeaderLabel
            // 
            this.UserNameHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UserNameHeaderLabel.Location = new System.Drawing.Point(1, 249);
            this.UserNameHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UserNameHeaderLabel.Name = "UserNameHeaderLabel";
            this.UserNameHeaderLabel.Size = new System.Drawing.Size(95, 15);
            this.UserNameHeaderLabel.TabIndex = 77;
            this.UserNameHeaderLabel.Text = "Felhasználónév";
            this.UserNameHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminLabel
            // 
            this.AdminLabel.AutoSize = true;
            this.AdminLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AdminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdminLabel.Location = new System.Drawing.Point(509, 187);
            this.AdminLabel.Name = "AdminLabel";
            this.AdminLabel.Size = new System.Drawing.Size(75, 18);
            this.AdminLabel.TabIndex = 75;
            this.AdminLabel.Text = "Beosztás:";
            // 
            // RoleCB
            // 
            this.RoleCB.FormattingEnabled = true;
            this.RoleCB.Location = new System.Drawing.Point(581, 187);
            this.RoleCB.Name = "RoleCB";
            this.RoleCB.Size = new System.Drawing.Size(121, 21);
            this.RoleCB.TabIndex = 85;
            // 
            // CancleBtn
            // 
            this.CancleBtn.Location = new System.Drawing.Point(608, 223);
            this.CancleBtn.Name = "CancleBtn";
            this.CancleBtn.Size = new System.Drawing.Size(75, 23);
            this.CancleBtn.TabIndex = 86;
            this.CancleBtn.Text = "Mégse";
            this.CancleBtn.UseVisualStyleBackColor = true;
            // 
            // ShowPassPB
            // 
            this.ShowPassPB.InitialImage = ((System.Drawing.Image)(resources.GetObject("ShowPassPB.InitialImage")));
            this.ShowPassPB.Location = new System.Drawing.Point(287, 95);
            this.ShowPassPB.Name = "ShowPassPB";
            this.ShowPassPB.Size = new System.Drawing.Size(20, 20);
            this.ShowPassPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPassPB.TabIndex = 87;
            this.ShowPassPB.TabStop = false;
            // 
            // ShowPassAgainPB
            // 
            this.ShowPassAgainPB.InitialImage = ((System.Drawing.Image)(resources.GetObject("ShowPassAgainPB.InitialImage")));
            this.ShowPassAgainPB.Location = new System.Drawing.Point(287, 125);
            this.ShowPassAgainPB.Name = "ShowPassAgainPB";
            this.ShowPassAgainPB.Size = new System.Drawing.Size(20, 20);
            this.ShowPassAgainPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPassAgainPB.TabIndex = 88;
            this.ShowPassAgainPB.TabStop = false;
            // 
            // PersonalInfos
            // 
            this.Controls.Add(this.ShowPassAgainPB);
            this.Controls.Add(this.ShowPassPB);
            this.Controls.Add(this.CancleBtn);
            this.Controls.Add(this.RoleCB);
            this.Controls.Add(this.AdminHeaderLabel);
            this.Controls.Add(this.NameHeaderLabel);
            this.Controls.Add(this.AdressHeaderLabel);
            this.Controls.Add(this.TaxHeaderLabel);
            this.Controls.Add(this.BirthHeaderLabel);
            this.Controls.Add(this.PhoneHeaderLabel);
            this.Controls.Add(this.EmailHeaderLabel);
            this.Controls.Add(this.UserNameHeaderLabel);
            this.Controls.Add(this.AdminLabel);
            this.Controls.Add(this.PasswordAgainTB);
            this.Controls.Add(this.PasswordAgainLabel);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserTB);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.HeaderDGV);
            this.Controls.Add(this.PersonalInfosPanel);
            this.Controls.Add(this.RegisterBtn);
            this.Controls.Add(this.TaxTB);
            this.Controls.Add(this.TaxLabel);
            this.Controls.Add(this.PhoneTB);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.AdressTB);
            this.Controls.Add(this.AdressLabel);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.BirthLabel);
            this.Controls.Add(this.RealNameTB);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.InfoDGV);
            this.Controls.Add(this.PersonalILabel);
            this.Name = "PersonalInfos";
            this.Size = new System.Drawing.Size(785, 530);
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassAgainPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
