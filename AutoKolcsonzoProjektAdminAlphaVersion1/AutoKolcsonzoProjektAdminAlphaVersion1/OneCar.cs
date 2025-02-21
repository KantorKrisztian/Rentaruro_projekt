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
        private Label IDLabel;
        private Label BrandLabel;
        private Label TypeLabel;
        private Label YearLabel;
        private Label DirveLabel;
        private Label ShiftLabel;
        private Label FuelLabel;
        private Label AirCondLabel;
        private Label RadarLabel;
        private Label CruiseControlLabel;
        private Label label12;
        private Label label1;
        private Label label2;
        private Button UpdateBtn;
        private Button DeleteBtn;
        private Label label13;

        public OneCar()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.IDLabel = new System.Windows.Forms.Label();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.DirveLabel = new System.Windows.Forms.Label();
            this.ShiftLabel = new System.Windows.Forms.Label();
            this.FuelLabel = new System.Windows.Forms.Label();
            this.AirCondLabel = new System.Windows.Forms.Label();
            this.RadarLabel = new System.Windows.Forms.Label();
            this.CruiseControlLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IDLabel
            // 
            this.IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IDLabel.Location = new System.Drawing.Point(-2, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(35, 19);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "9999";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrandLabel
            // 
            this.BrandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrandLabel.Location = new System.Drawing.Point(32, 0);
            this.BrandLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(73, 19);
            this.BrandLabel.TabIndex = 1;
            this.BrandLabel.Text = "Koenigsegg";
            this.BrandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TypeLabel
            // 
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TypeLabel.Location = new System.Drawing.Point(106, 0);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(66, 19);
            this.TypeLabel.TabIndex = 2;
            this.TypeLabel.Text = "Angelholm";
            this.TypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YearLabel
            // 
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YearLabel.Location = new System.Drawing.Point(173, 0);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(35, 19);
            this.YearLabel.TabIndex = 3;
            this.YearLabel.Text = "2025";
            this.YearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DirveLabel
            // 
            this.DirveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DirveLabel.Location = new System.Drawing.Point(209, 0);
            this.DirveLabel.Name = "DirveLabel";
            this.DirveLabel.Size = new System.Drawing.Size(42, 19);
            this.DirveLabel.TabIndex = 4;
            this.DirveLabel.Text = "4WD";
            this.DirveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShiftLabel
            // 
            this.ShiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ShiftLabel.Location = new System.Drawing.Point(252, 0);
            this.ShiftLabel.Name = "ShiftLabel";
            this.ShiftLabel.Size = new System.Drawing.Size(34, 19);
            this.ShiftLabel.TabIndex = 5;
            this.ShiftLabel.Text = "A";
            this.ShiftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FuelLabel
            // 
            this.FuelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FuelLabel.Location = new System.Drawing.Point(287, 0);
            this.FuelLabel.Name = "FuelLabel";
            this.FuelLabel.Size = new System.Drawing.Size(73, 19);
            this.FuelLabel.TabIndex = 6;
            this.FuelLabel.Text = "Benzin";
            this.FuelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AirCondLabel
            // 
            this.AirCondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AirCondLabel.Location = new System.Drawing.Point(361, 0);
            this.AirCondLabel.Name = "AirCondLabel";
            this.AirCondLabel.Size = new System.Drawing.Size(39, 19);
            this.AirCondLabel.TabIndex = 7;
            this.AirCondLabel.Text = "✔";
            this.AirCondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RadarLabel
            // 
            this.RadarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadarLabel.Location = new System.Drawing.Point(401, 0);
            this.RadarLabel.Name = "RadarLabel";
            this.RadarLabel.Size = new System.Drawing.Size(41, 19);
            this.RadarLabel.TabIndex = 8;
            this.RadarLabel.Text = "✔";
            this.RadarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CruiseControlLabel
            // 
            this.CruiseControlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CruiseControlLabel.Location = new System.Drawing.Point(443, 0);
            this.CruiseControlLabel.Name = "CruiseControlLabel";
            this.CruiseControlLabel.Size = new System.Drawing.Size(28, 19);
            this.CruiseControlLabel.TabIndex = 9;
            this.CruiseControlLabel.Text = "✖";
            this.CruiseControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(472, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 19);
            this.label12.TabIndex = 11;
            this.label12.Text = "50000";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(515, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 19);
            this.label13.TabIndex = 12;
            this.label13.Text = "100000";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(565, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "100000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(615, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "100000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(663, -1);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(65, 20);
            this.UpdateBtn.TabIndex = 15;
            this.UpdateBtn.Text = "⚙️";
            this.UpdateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeleteBtn.Location = new System.Drawing.Point(751, -1);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(17, 20);
            this.DeleteBtn.TabIndex = 17;
            this.DeleteBtn.Text = "✖";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // OneCar
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CruiseControlLabel);
            this.Controls.Add(this.RadarLabel);
            this.Controls.Add(this.AirCondLabel);
            this.Controls.Add(this.FuelLabel);
            this.Controls.Add(this.ShiftLabel);
            this.Controls.Add(this.DirveLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.IDLabel);
            this.Name = "OneCar";
            this.Size = new System.Drawing.Size(768, 19);
            this.ResumeLayout(false);

        }
    }
}
