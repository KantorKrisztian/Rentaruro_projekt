using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    public class OnePersonalInfo:UserControl
    {
        public Label EmailLabel;
        public Label PhoneLabel;
        public Label BirthLabel;
        public Label TaxLabel;
        public Label AdressLabel;
        public Label NameLabel;
        public Label RoleLabel;
        public Button UpdateBtn;
        public Button DeleteBtn;
        public Label UserLabel;
        public OnePersonalInfo()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.UserLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.BirthLabel = new System.Windows.Forms.Label();
            this.TaxLabel = new System.Windows.Forms.Label();
            this.AdressLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserLabel
            // 
            this.UserLabel.AutoEllipsis = true;
            this.UserLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.UserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UserLabel.Location = new System.Drawing.Point(0, 0);
            this.UserLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(97, 46);
            this.UserLabel.TabIndex = 10;
            this.UserLabel.Text = "BiczoFerenc2000";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoEllipsis = true;
            this.EmailLabel.BackColor = System.Drawing.Color.Transparent;
            this.EmailLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmailLabel.Location = new System.Drawing.Point(96, 0);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(95, 46);
            this.EmailLabel.TabIndex = 12;
            this.EmailLabel.Text = "Biczo.Ferenc@gmail.com";
            this.EmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoEllipsis = true;
            this.PhoneLabel.BackColor = System.Drawing.Color.Transparent;
            this.PhoneLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PhoneLabel.Location = new System.Drawing.Point(190, 0);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(91, 46);
            this.PhoneLabel.TabIndex = 13;
            this.PhoneLabel.Text = "+36308975556";
            this.PhoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BirthLabel
            // 
            this.BirthLabel.AutoEllipsis = true;
            this.BirthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BirthLabel.Location = new System.Drawing.Point(284, 0);
            this.BirthLabel.Name = "BirthLabel";
            this.BirthLabel.Size = new System.Drawing.Size(95, 46);
            this.BirthLabel.TabIndex = 14;
            this.BirthLabel.Text = "2025.05.30";
            this.BirthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaxLabel
            // 
            this.TaxLabel.AutoEllipsis = true;
            this.TaxLabel.BackColor = System.Drawing.Color.Transparent;
            this.TaxLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.TaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TaxLabel.Location = new System.Drawing.Point(382, 0);
            this.TaxLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TaxLabel.Name = "TaxLabel";
            this.TaxLabel.Size = new System.Drawing.Size(80, 46);
            this.TaxLabel.TabIndex = 15;
            this.TaxLabel.Text = "9999999999";
            this.TaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdressLabel
            // 
            this.AdressLabel.AutoEllipsis = true;
            this.AdressLabel.BackColor = System.Drawing.Color.Transparent;
            this.AdressLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.AdressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdressLabel.Location = new System.Drawing.Point(462, 0);
            this.AdressLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AdressLabel.Name = "AdressLabel";
            this.AdressLabel.Size = new System.Drawing.Size(100, 46);
            this.AdressLabel.TabIndex = 16;
            this.AdressLabel.Text = "Budapest, 1011, Petőfi Sándor u. 19, 3. e. 38\r\n";
            this.AdressLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoEllipsis = true;
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLabel.Location = new System.Drawing.Point(562, 0);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(100, 46);
            this.NameLabel.TabIndex = 17;
            this.NameLabel.Text = "Biczó Ferenc Gábor";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoleLabel
            // 
            this.RoleLabel.AutoEllipsis = true;
            this.RoleLabel.BackColor = System.Drawing.Color.Transparent;
            this.RoleLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.RoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RoleLabel.Location = new System.Drawing.Point(662, -1);
            this.RoleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(57, 46);
            this.RoleLabel.TabIndex = 18;
            this.RoleLabel.Text = "Dolgozó";
            this.RoleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.Color.Transparent;
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpdateBtn.Location = new System.Drawing.Point(719, 0);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(49, 23);
            this.UpdateBtn.TabIndex = 19;
            this.UpdateBtn.Text = "🔧";
            this.UpdateBtn.UseVisualStyleBackColor = false;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.Red;
            this.DeleteBtn.Location = new System.Drawing.Point(719, 22);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(49, 24);
            this.DeleteBtn.TabIndex = 20;
            this.DeleteBtn.Text = "✖";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // OnePersonalInfo
            // 
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.RoleLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.AdressLabel);
            this.Controls.Add(this.TaxLabel);
            this.Controls.Add(this.BirthLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.UserLabel);
            this.Name = "OnePersonalInfo";
            this.Size = new System.Drawing.Size(768, 46);
            this.ResumeLayout(false);

        }
    }
}
