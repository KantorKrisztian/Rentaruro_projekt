using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    class OneCar:UserControl
    {
        public Label LicensePlateLabel;
        public Label BrandLabel;
        public Label TypeLabel;
        public Label YearLabel;
        public Label DriveLabel;
        public Label ShiftLabel;
        public Label FuelLabel;
        public Label AirCondLabel;
        public Label RadarLabel;
        public Label CruiseControlLabel;
        public Label OneToFiveLabel;
        public Label FromFifteenLabel;
        public Label DepositLabel;
        public Button UpdateBtn;
        public Button DeleteBtn;
        public Label LocationLabel;
        public Label SixToFourteenLabel;

        public OneCar()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            ShiftLabel.MouseHover += (s, e) =>
            {
                ToolTip toolTip = new ToolTip();
                if (ShiftLabel.Text=="A")
                {
                    toolTip.SetToolTip(ShiftLabel, "Autómata");
                }
                else if(ShiftLabel.Text=="M")
                {
                    toolTip.SetToolTip(ShiftLabel, "Manuális");
                }
            };
        }
        private void InitializeComponent()
        {
            this.LicensePlateLabel = new System.Windows.Forms.Label();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.DriveLabel = new System.Windows.Forms.Label();
            this.ShiftLabel = new System.Windows.Forms.Label();
            this.FuelLabel = new System.Windows.Forms.Label();
            this.AirCondLabel = new System.Windows.Forms.Label();
            this.RadarLabel = new System.Windows.Forms.Label();
            this.CruiseControlLabel = new System.Windows.Forms.Label();
            this.OneToFiveLabel = new System.Windows.Forms.Label();
            this.SixToFourteenLabel = new System.Windows.Forms.Label();
            this.FromFifteenLabel = new System.Windows.Forms.Label();
            this.DepositLabel = new System.Windows.Forms.Label();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LicensePlateLabel
            // 
            this.LicensePlateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LicensePlateLabel.Location = new System.Drawing.Point(1, 0);
            this.LicensePlateLabel.Name = "LicensePlateLabel";
            this.LicensePlateLabel.Size = new System.Drawing.Size(66, 46);
            this.LicensePlateLabel.TabIndex = 0;
            this.LicensePlateLabel.Text = "AA AA-999";
            this.LicensePlateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrandLabel
            // 
            this.BrandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrandLabel.Location = new System.Drawing.Point(69, 0);
            this.BrandLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(75, 23);
            this.BrandLabel.TabIndex = 1;
            this.BrandLabel.Text = "Koenigsegg";
            this.BrandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TypeLabel
            // 
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TypeLabel.Location = new System.Drawing.Point(69, 23);
            this.TypeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(75, 23);
            this.TypeLabel.TabIndex = 2;
            this.TypeLabel.Text = "Angelholm";
            this.TypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YearLabel
            // 
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YearLabel.Location = new System.Drawing.Point(145, 0);
            this.YearLabel.Margin = new System.Windows.Forms.Padding(0);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(35, 46);
            this.YearLabel.TabIndex = 3;
            this.YearLabel.Text = "2025";
            this.YearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DriveLabel
            // 
            this.DriveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DriveLabel.Location = new System.Drawing.Point(181, 0);
            this.DriveLabel.Name = "DriveLabel";
            this.DriveLabel.Size = new System.Drawing.Size(65, 46);
            this.DriveLabel.TabIndex = 4;
            this.DriveLabel.Text = "4WD";
            this.DriveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShiftLabel
            // 
            this.ShiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ShiftLabel.Location = new System.Drawing.Point(247, 0);
            this.ShiftLabel.Name = "ShiftLabel";
            this.ShiftLabel.Size = new System.Drawing.Size(34, 46);
            this.ShiftLabel.TabIndex = 5;
            this.ShiftLabel.Text = "A";
            this.ShiftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FuelLabel
            // 
            this.FuelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FuelLabel.Location = new System.Drawing.Point(282, 0);
            this.FuelLabel.Name = "FuelLabel";
            this.FuelLabel.Size = new System.Drawing.Size(73, 46);
            this.FuelLabel.TabIndex = 6;
            this.FuelLabel.Text = "Benzin";
            this.FuelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AirCondLabel
            // 
            this.AirCondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AirCondLabel.Location = new System.Drawing.Point(356, 0);
            this.AirCondLabel.Name = "AirCondLabel";
            this.AirCondLabel.Size = new System.Drawing.Size(39, 46);
            this.AirCondLabel.TabIndex = 7;
            this.AirCondLabel.Text = "✔";
            this.AirCondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RadarLabel
            // 
            this.RadarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadarLabel.Location = new System.Drawing.Point(396, 0);
            this.RadarLabel.Name = "RadarLabel";
            this.RadarLabel.Size = new System.Drawing.Size(41, 46);
            this.RadarLabel.TabIndex = 8;
            this.RadarLabel.Text = "✔";
            this.RadarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CruiseControlLabel
            // 
            this.CruiseControlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CruiseControlLabel.Location = new System.Drawing.Point(438, 0);
            this.CruiseControlLabel.Name = "CruiseControlLabel";
            this.CruiseControlLabel.Size = new System.Drawing.Size(67, 46);
            this.CruiseControlLabel.TabIndex = 9;
            this.CruiseControlLabel.Text = "✖";
            this.CruiseControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OneToFiveLabel
            // 
            this.OneToFiveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OneToFiveLabel.Location = new System.Drawing.Point(506, 0);
            this.OneToFiveLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OneToFiveLabel.Name = "OneToFiveLabel";
            this.OneToFiveLabel.Size = new System.Drawing.Size(48, 46);
            this.OneToFiveLabel.TabIndex = 11;
            this.OneToFiveLabel.Text = "50000";
            this.OneToFiveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SixToFourteenLabel
            // 
            this.SixToFourteenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SixToFourteenLabel.Location = new System.Drawing.Point(555, 0);
            this.SixToFourteenLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SixToFourteenLabel.Name = "SixToFourteenLabel";
            this.SixToFourteenLabel.Size = new System.Drawing.Size(49, 46);
            this.SixToFourteenLabel.TabIndex = 12;
            this.SixToFourteenLabel.Text = "100000";
            this.SixToFourteenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FromFifteenLabel
            // 
            this.FromFifteenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FromFifteenLabel.Location = new System.Drawing.Point(604, 0);
            this.FromFifteenLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FromFifteenLabel.Name = "FromFifteenLabel";
            this.FromFifteenLabel.Size = new System.Drawing.Size(49, 46);
            this.FromFifteenLabel.TabIndex = 13;
            this.FromFifteenLabel.Text = "100000";
            this.FromFifteenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepositLabel
            // 
            this.DepositLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DepositLabel.Location = new System.Drawing.Point(653, 0);
            this.DepositLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DepositLabel.Name = "DepositLabel";
            this.DepositLabel.Size = new System.Drawing.Size(49, 46);
            this.DepositLabel.TabIndex = 14;
            this.DepositLabel.Text = "100000";
            this.DepositLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.Color.Transparent;
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpdateBtn.Location = new System.Drawing.Point(732, 0);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(36, 24);
            this.UpdateBtn.TabIndex = 15;
            this.UpdateBtn.Text = "🔧";
            this.UpdateBtn.UseVisualStyleBackColor = false;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.Red;
            this.DeleteBtn.Location = new System.Drawing.Point(732, 23);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(36, 23);
            this.DeleteBtn.TabIndex = 17;
            this.DeleteBtn.Text = "✖";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // LocationLabel
            // 
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LocationLabel.Location = new System.Drawing.Point(699, 0);
            this.LocationLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(33, 46);
            this.LocationLabel.TabIndex = 18;
            this.LocationLabel.Text = "BUD";
            this.LocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OneCar
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.DepositLabel);
            this.Controls.Add(this.FromFifteenLabel);
            this.Controls.Add(this.SixToFourteenLabel);
            this.Controls.Add(this.OneToFiveLabel);
            this.Controls.Add(this.CruiseControlLabel);
            this.Controls.Add(this.RadarLabel);
            this.Controls.Add(this.AirCondLabel);
            this.Controls.Add(this.FuelLabel);
            this.Controls.Add(this.ShiftLabel);
            this.Controls.Add(this.DriveLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.LicensePlateLabel);
            this.Name = "OneCar";
            this.Size = new System.Drawing.Size(768, 46);
            this.ResumeLayout(false);

        }
    }
}
