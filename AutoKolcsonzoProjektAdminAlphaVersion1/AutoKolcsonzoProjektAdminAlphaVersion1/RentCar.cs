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
        private Label RentLabel;
        public RentCar()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.RentLabel = new System.Windows.Forms.Label();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).BeginInit();
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
            this.InfoDGV.Size = new System.Drawing.Size(785, 212);
            this.InfoDGV.TabIndex = 4;
            // 
            // RentCar
            // 
            this.Controls.Add(this.InfoDGV);
            this.Controls.Add(this.RentLabel);
            this.Name = "RentCar";
            this.Size = new System.Drawing.Size(785, 532);
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
