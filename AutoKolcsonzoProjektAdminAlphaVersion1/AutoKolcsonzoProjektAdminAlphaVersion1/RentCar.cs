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
        private Label StartLabel;
        private Label EndLabel;
        private Label OtherInfoLabel;
        private Label LocationLabel;
        private Label CarLabel;
        private Label UserLabel;
        private Label EmailLabel;
        private Label PhoneLabel;
        private ComboBox StartCB;
        private ComboBox EndCB;
        private ComboBox LocationCB;
        private ComboBox CarCB;
        private TextBox UserTB;
        private TextBox EmailTB;
        private TextBox PhoneTB;
        private TextBox OtherInfoLabelTB;
        private Label NameLabel;
        private TextBox NameTB;
        private Button AddRentBtn;
        private Label IDHeaderLabel;
        private Label StartHeaderLabel;
        private Label EndHeaderLabel;
        private Label CarIDHeaderLabel;
        private Label BrandHeaderLabel;
        private Label TypeHeaderLabel;
        private Label RentLabel;
        public RentCar()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.RentLabel = new System.Windows.Forms.Label();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this.RentPanel = new System.Windows.Forms.Panel();
            this.HeaderDGV = new System.Windows.Forms.DataGridView();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.OtherInfoLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.CarLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.StartCB = new System.Windows.Forms.ComboBox();
            this.EndCB = new System.Windows.Forms.ComboBox();
            this.LocationCB = new System.Windows.Forms.ComboBox();
            this.CarCB = new System.Windows.Forms.ComboBox();
            this.UserTB = new System.Windows.Forms.TextBox();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.PhoneTB = new System.Windows.Forms.TextBox();
            this.OtherInfoLabelTB = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.AddRentBtn = new System.Windows.Forms.Button();
            this.IDHeaderLabel = new System.Windows.Forms.Label();
            this.StartHeaderLabel = new System.Windows.Forms.Label();
            this.EndHeaderLabel = new System.Windows.Forms.Label();
            this.CarIDHeaderLabel = new System.Windows.Forms.Label();
            this.BrandHeaderLabel = new System.Windows.Forms.Label();
            this.TypeHeaderLabel = new System.Windows.Forms.Label();
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
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.StartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.StartLabel.Location = new System.Drawing.Point(10, 66);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(66, 18);
            this.StartLabel.TabIndex = 37;
            this.StartLabel.Text = "Kezdete:";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.EndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.EndLabel.Location = new System.Drawing.Point(10, 96);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(45, 18);
            this.EndLabel.TabIndex = 38;
            this.EndLabel.Text = "Vége:";
            // 
            // OtherInfoLabel
            // 
            this.OtherInfoLabel.AutoSize = true;
            this.OtherInfoLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.OtherInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.OtherInfoLabel.Location = new System.Drawing.Point(10, 128);
            this.OtherInfoLabel.Name = "OtherInfoLabel";
            this.OtherInfoLabel.Size = new System.Drawing.Size(127, 18);
            this.OtherInfoLabel.TabIndex = 39;
            this.OtherInfoLabel.Text = "Egyéb információ:";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.LocationLabel.Location = new System.Drawing.Point(260, 66);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(41, 18);
            this.LocationLabel.TabIndex = 40;
            this.LocationLabel.Text = "Hely:";
            // 
            // CarLabel
            // 
            this.CarLabel.AutoSize = true;
            this.CarLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CarLabel.Location = new System.Drawing.Point(260, 96);
            this.CarLabel.Name = "CarLabel";
            this.CarLabel.Size = new System.Drawing.Size(42, 18);
            this.CarLabel.TabIndex = 41;
            this.CarLabel.Text = "Autó:";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.UserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.UserLabel.Location = new System.Drawing.Point(470, 66);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(115, 18);
            this.UserLabel.TabIndex = 42;
            this.UserLabel.Text = "Felhasználónév:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.EmailLabel.Location = new System.Drawing.Point(470, 96);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(49, 18);
            this.EmailLabel.TabIndex = 43;
            this.EmailLabel.Text = "Email:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.PhoneLabel.Location = new System.Drawing.Point(470, 126);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(98, 18);
            this.PhoneLabel.TabIndex = 44;
            this.PhoneLabel.Text = "Telefonszám:";
            // 
            // StartCB
            // 
            this.StartCB.FormattingEnabled = true;
            this.StartCB.Location = new System.Drawing.Point(82, 66);
            this.StartCB.Name = "StartCB";
            this.StartCB.Size = new System.Drawing.Size(121, 21);
            this.StartCB.TabIndex = 45;
            // 
            // EndCB
            // 
            this.EndCB.FormattingEnabled = true;
            this.EndCB.Location = new System.Drawing.Point(82, 96);
            this.EndCB.Name = "EndCB";
            this.EndCB.Size = new System.Drawing.Size(121, 21);
            this.EndCB.TabIndex = 46;
            // 
            // LocationCB
            // 
            this.LocationCB.FormattingEnabled = true;
            this.LocationCB.Location = new System.Drawing.Point(321, 66);
            this.LocationCB.Name = "LocationCB";
            this.LocationCB.Size = new System.Drawing.Size(121, 21);
            this.LocationCB.TabIndex = 47;
            // 
            // CarCB
            // 
            this.CarCB.FormattingEnabled = true;
            this.CarCB.Location = new System.Drawing.Point(321, 96);
            this.CarCB.Name = "CarCB";
            this.CarCB.Size = new System.Drawing.Size(121, 21);
            this.CarCB.TabIndex = 48;
            // 
            // UserTB
            // 
            this.UserTB.Location = new System.Drawing.Point(588, 66);
            this.UserTB.Name = "UserTB";
            this.UserTB.Size = new System.Drawing.Size(124, 20);
            this.UserTB.TabIndex = 49;
            // 
            // EmailTB
            // 
            this.EmailTB.Location = new System.Drawing.Point(588, 96);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(124, 20);
            this.EmailTB.TabIndex = 50;
            // 
            // PhoneTB
            // 
            this.PhoneTB.Location = new System.Drawing.Point(588, 126);
            this.PhoneTB.Name = "PhoneTB";
            this.PhoneTB.Size = new System.Drawing.Size(124, 20);
            this.PhoneTB.TabIndex = 51;
            // 
            // OtherInfoLabelTB
            // 
            this.OtherInfoLabelTB.Location = new System.Drawing.Point(13, 149);
            this.OtherInfoLabelTB.Multiline = true;
            this.OtherInfoLabelTB.Name = "OtherInfoLabelTB";
            this.OtherInfoLabelTB.Size = new System.Drawing.Size(451, 71);
            this.OtherInfoLabelTB.TabIndex = 52;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.NameLabel.Location = new System.Drawing.Point(470, 156);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 18);
            this.NameLabel.TabIndex = 53;
            this.NameLabel.Text = "Név:";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(588, 156);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(124, 20);
            this.NameTB.TabIndex = 54;
            // 
            // AddRentBtn
            // 
            this.AddRentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.AddRentBtn.Location = new System.Drawing.Point(695, 208);
            this.AddRentBtn.Name = "AddRentBtn";
            this.AddRentBtn.Size = new System.Drawing.Size(89, 23);
            this.AddRentBtn.TabIndex = 55;
            this.AddRentBtn.Text = "Hozzáadás";
            this.AddRentBtn.UseVisualStyleBackColor = true;
            // 
            // IDHeaderLabel
            // 
            this.IDHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IDHeaderLabel.Location = new System.Drawing.Point(1, 232);
            this.IDHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.IDHeaderLabel.Name = "IDHeaderLabel";
            this.IDHeaderLabel.Size = new System.Drawing.Size(30, 15);
            this.IDHeaderLabel.TabIndex = 56;
            this.IDHeaderLabel.Text = "ID";
            this.IDHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartHeaderLabel
            // 
            this.StartHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartHeaderLabel.Location = new System.Drawing.Point(32, 232);
            this.StartHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StartHeaderLabel.Name = "StartHeaderLabel";
            this.StartHeaderLabel.Size = new System.Drawing.Size(55, 15);
            this.StartHeaderLabel.TabIndex = 57;
            this.StartHeaderLabel.Text = "Kezdete";
            this.StartHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndHeaderLabel
            // 
            this.EndHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EndHeaderLabel.Location = new System.Drawing.Point(88, 232);
            this.EndHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EndHeaderLabel.Name = "EndHeaderLabel";
            this.EndHeaderLabel.Size = new System.Drawing.Size(55, 15);
            this.EndHeaderLabel.TabIndex = 58;
            this.EndHeaderLabel.Text = "Vége";
            this.EndHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CarIDHeaderLabel
            // 
            this.CarIDHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CarIDHeaderLabel.Location = new System.Drawing.Point(144, 232);
            this.CarIDHeaderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CarIDHeaderLabel.Name = "CarIDHeaderLabel";
            this.CarIDHeaderLabel.Size = new System.Drawing.Size(43, 15);
            this.CarIDHeaderLabel.TabIndex = 59;
            this.CarIDHeaderLabel.Text = "AutóID";
            this.CarIDHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrandHeaderLabel
            // 
            this.BrandHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrandHeaderLabel.Location = new System.Drawing.Point(188, 232);
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
            this.TypeHeaderLabel.Location = new System.Drawing.Point(255, 232);
            this.TypeHeaderLabel.Name = "TypeHeaderLabel";
            this.TypeHeaderLabel.Size = new System.Drawing.Size(66, 15);
            this.TypeHeaderLabel.TabIndex = 61;
            this.TypeHeaderLabel.Text = "Típus";
            this.TypeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RentCar
            // 
            this.Controls.Add(this.TypeHeaderLabel);
            this.Controls.Add(this.BrandHeaderLabel);
            this.Controls.Add(this.CarIDHeaderLabel);
            this.Controls.Add(this.EndHeaderLabel);
            this.Controls.Add(this.StartHeaderLabel);
            this.Controls.Add(this.IDHeaderLabel);
            this.Controls.Add(this.AddRentBtn);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.OtherInfoLabelTB);
            this.Controls.Add(this.PhoneTB);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.UserTB);
            this.Controls.Add(this.CarCB);
            this.Controls.Add(this.LocationCB);
            this.Controls.Add(this.EndCB);
            this.Controls.Add(this.StartCB);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.CarLabel);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.OtherInfoLabel);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
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
