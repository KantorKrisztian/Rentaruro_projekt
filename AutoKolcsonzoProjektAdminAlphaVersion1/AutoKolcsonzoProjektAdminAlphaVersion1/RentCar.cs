using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Label StartHeaderLabel;
        private Label EndHeaderLabel;
        private Label LicensePlateHeaderLabel;
        private Label BrandHeaderLabel;
        private Label TypeHeaderLabel;
        private Label UseHeaderLabel;
        private Label NameHeaderLabel;
        private Label EmailHeaderLabel;
        private Label PhoneHeaderLabel;
        private Label RentLabel;

        public List<jsonRents> AllRents = new List<jsonRents>();
        private MonthCalendar StartEndCalendar;
        HttpRequests httpRequests = new HttpRequests();
        public RentCar()
        {
            InitializeComponent();
            Start();

            UpdateRentBtn.Click += (s,e)=> { UpdateRent();};
            
        }
        public async void Start()
        {
            StartEndCalendar.MaxSelectionCount=int.MaxValue;
            RentPanel.AutoScroll = Enabled;
            AllRents = await httpRequests.ListAllRents();
            for (int i = 0; i < 20; i++)
            {
                OneRent rent = new OneRent();
                rent.Top = i * rent.Height;
                RentPanel.Controls.Add(rent);

            }
            RentList();
        }
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
                
                AllRents = await httpRequests.UpdateRent(rent);
                RentList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public async void RentList()
        {
            
            try
            {
                if (AllRents == null)
                {
                    MessageBox.Show("Nincs autó a rendszerben");
                    return;
                }
                int count = 0;
                RentPanel.Controls.Clear();
                foreach (jsonRents item in AllRents)
                {
                    count++;
                    OneRent rent = new OneRent();
                    string[] asd = item.start.ToString().Split(' ');
                    string[] asd2 = item.end.ToString().Split(' ');
                    rent.StartLabel.Text = asd[0]+ asd[1]+ asd[2];
                    rent.EndLabel.Text = asd2[0] + asd2[1] + asd2[2];
                    rent.LicensePlateLabel.Text = item.licensePlate;
                    rent.BrandLabel.Text = item.brand;
                    rent.TypeLabel.Text = item.type;
                    rent.UserLabel.Text = item.username;
                    rent.NameLabel.Text = item.name;
                    rent.EmailLabel.Text = item.email;
                    rent.PhoneLabel.Text = item.phone;
                    RentPanel.Controls.Add(rent);
                    rent.Top = (count - 1) * rent.Height;
                    rent.DeleteBtn.Click +=async (s, e) =>
                    {
                        AllRents = await httpRequests.DeleteRent(item.id);
                        RentList();
                    };
                    rent.UpdateBtn.Click += (s, e) =>
                    {
                        OtherInfoLabelTB.Text = item.other;
                        StartEndCalendar.SetDate(item.start);
                        StartEndCalendar.SetSelectionRange(item.start, item.end);
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
        private void InitializeComponent()
        {
            this.RentLabel = new System.Windows.Forms.Label();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this.RentPanel = new System.Windows.Forms.Panel();
            this.HeaderDGV = new System.Windows.Forms.DataGridView();
            this.OtherInfoLabel = new System.Windows.Forms.Label();
            this.OtherInfoLabelTB = new System.Windows.Forms.TextBox();
            this.UpdateRentBtn = new System.Windows.Forms.Button();
            this.StartHeaderLabel = new System.Windows.Forms.Label();
            this.EndHeaderLabel = new System.Windows.Forms.Label();
            this.LicensePlateHeaderLabel = new System.Windows.Forms.Label();
            this.BrandHeaderLabel = new System.Windows.Forms.Label();
            this.TypeHeaderLabel = new System.Windows.Forms.Label();
            this.UseHeaderLabel = new System.Windows.Forms.Label();
            this.NameHeaderLabel = new System.Windows.Forms.Label();
            this.EmailHeaderLabel = new System.Windows.Forms.Label();
            this.PhoneHeaderLabel = new System.Windows.Forms.Label();
            this.StartEndCalendar = new System.Windows.Forms.MonthCalendar();
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
            this.InfoDGV.Size = new System.Drawing.Size(785, 175);
            this.InfoDGV.TabIndex = 4;
            // 
            // RentPanel
            // 
            this.RentPanel.Location = new System.Drawing.Point(0, 248);
            this.RentPanel.Name = "RentPanel";
            this.RentPanel.Size = new System.Drawing.Size(785, 282);
            this.RentPanel.TabIndex = 5;
            // 
            // HeaderDGV
            // 
            this.HeaderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HeaderDGV.Location = new System.Drawing.Point(0, 231);
            this.HeaderDGV.Name = "HeaderDGV";
            this.HeaderDGV.Size = new System.Drawing.Size(785, 17);
            this.HeaderDGV.TabIndex = 36;
            // 
            // OtherInfoLabel
            // 
            this.OtherInfoLabel.AutoSize = true;
            this.OtherInfoLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.OtherInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.OtherInfoLabel.Location = new System.Drawing.Point(328, 110);
            this.OtherInfoLabel.Name = "OtherInfoLabel";
            this.OtherInfoLabel.Size = new System.Drawing.Size(127, 18);
            this.OtherInfoLabel.TabIndex = 39;
            this.OtherInfoLabel.Text = "Egyéb információ:";
            // 
            // OtherInfoLabelTB
            // 
            this.OtherInfoLabelTB.Location = new System.Drawing.Point(331, 131);
            this.OtherInfoLabelTB.Multiline = true;
            this.OtherInfoLabelTB.Name = "OtherInfoLabelTB";
            this.OtherInfoLabelTB.Size = new System.Drawing.Size(451, 71);
            this.OtherInfoLabelTB.TabIndex = 52;
            // 
            // UpdateRentBtn
            // 
            this.UpdateRentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.UpdateRentBtn.Location = new System.Drawing.Point(695, 208);
            this.UpdateRentBtn.Name = "UpdateRentBtn";
            this.UpdateRentBtn.Size = new System.Drawing.Size(89, 23);
            this.UpdateRentBtn.TabIndex = 55;
            this.UpdateRentBtn.Text = "Módosítás";
            this.UpdateRentBtn.UseVisualStyleBackColor = true;
            // 
            // StartHeaderLabel
            // 
            this.StartHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartHeaderLabel.Location = new System.Drawing.Point(1, 232);
            this.StartHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StartHeaderLabel.Name = "StartHeaderLabel";
            this.StartHeaderLabel.Size = new System.Drawing.Size(64, 15);
            this.StartHeaderLabel.TabIndex = 57;
            this.StartHeaderLabel.Text = "Kezdete";
            this.StartHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndHeaderLabel
            // 
            this.EndHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EndHeaderLabel.Location = new System.Drawing.Point(66, 232);
            this.EndHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EndHeaderLabel.Name = "EndHeaderLabel";
            this.EndHeaderLabel.Size = new System.Drawing.Size(64, 15);
            this.EndHeaderLabel.TabIndex = 58;
            this.EndHeaderLabel.Text = "Vége";
            this.EndHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LicensePlateHeaderLabel
            // 
            this.LicensePlateHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LicensePlateHeaderLabel.Location = new System.Drawing.Point(131, 232);
            this.LicensePlateHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LicensePlateHeaderLabel.Name = "LicensePlateHeaderLabel";
            this.LicensePlateHeaderLabel.Size = new System.Drawing.Size(69, 15);
            this.LicensePlateHeaderLabel.TabIndex = 59;
            this.LicensePlateHeaderLabel.Text = "Rendszám";
            this.LicensePlateHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrandHeaderLabel
            // 
            this.BrandHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrandHeaderLabel.Location = new System.Drawing.Point(201, 232);
            this.BrandHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BrandHeaderLabel.Name = "BrandHeaderLabel";
            this.BrandHeaderLabel.Size = new System.Drawing.Size(66, 15);
            this.BrandHeaderLabel.TabIndex = 60;
            this.BrandHeaderLabel.Text = "Márka";
            this.BrandHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TypeHeaderLabel
            // 
            this.TypeHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TypeHeaderLabel.Location = new System.Drawing.Point(268, 232);
            this.TypeHeaderLabel.Name = "TypeHeaderLabel";
            this.TypeHeaderLabel.Size = new System.Drawing.Size(66, 15);
            this.TypeHeaderLabel.TabIndex = 61;
            this.TypeHeaderLabel.Text = "Típus";
            this.TypeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UseHeaderLabel
            // 
            this.UseHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UseHeaderLabel.Location = new System.Drawing.Point(335, 232);
            this.UseHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UseHeaderLabel.Name = "UseHeaderLabel";
            this.UseHeaderLabel.Size = new System.Drawing.Size(100, 15);
            this.UseHeaderLabel.TabIndex = 63;
            this.UseHeaderLabel.Text = "Felhasználónév";
            this.UseHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameHeaderLabel
            // 
            this.NameHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameHeaderLabel.Location = new System.Drawing.Point(436, 232);
            this.NameHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NameHeaderLabel.Name = "NameHeaderLabel";
            this.NameHeaderLabel.Size = new System.Drawing.Size(95, 15);
            this.NameHeaderLabel.TabIndex = 64;
            this.NameHeaderLabel.Text = "Név";
            this.NameHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmailHeaderLabel
            // 
            this.EmailHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmailHeaderLabel.Location = new System.Drawing.Point(532, 232);
            this.EmailHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EmailHeaderLabel.Name = "EmailHeaderLabel";
            this.EmailHeaderLabel.Size = new System.Drawing.Size(95, 15);
            this.EmailHeaderLabel.TabIndex = 65;
            this.EmailHeaderLabel.Text = "Email";
            this.EmailHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneHeaderLabel
            // 
            this.PhoneHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PhoneHeaderLabel.Location = new System.Drawing.Point(628, 232);
            this.PhoneHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PhoneHeaderLabel.Name = "PhoneHeaderLabel";
            this.PhoneHeaderLabel.Size = new System.Drawing.Size(90, 15);
            this.PhoneHeaderLabel.TabIndex = 66;
            this.PhoneHeaderLabel.Text = "Telefonszám";
            this.PhoneHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartEndCalendar
            // 
            this.StartEndCalendar.Location = new System.Drawing.Point(9, 61);
            this.StartEndCalendar.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.StartEndCalendar.Name = "StartEndCalendar";
            this.StartEndCalendar.TabIndex = 67;
            // 
            // RentCar
            // 
            this.Controls.Add(this.StartEndCalendar);
            this.Controls.Add(this.PhoneHeaderLabel);
            this.Controls.Add(this.EmailHeaderLabel);
            this.Controls.Add(this.NameHeaderLabel);
            this.Controls.Add(this.UseHeaderLabel);
            this.Controls.Add(this.TypeHeaderLabel);
            this.Controls.Add(this.BrandHeaderLabel);
            this.Controls.Add(this.LicensePlateHeaderLabel);
            this.Controls.Add(this.EndHeaderLabel);
            this.Controls.Add(this.StartHeaderLabel);
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
