namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LoginLabel = new System.Windows.Forms.Label();
            this.LoginUserLabel = new System.Windows.Forms.Label();
            this.LoginUserTb = new System.Windows.Forms.TextBox();
            this.LoginPassLabel = new System.Windows.Forms.Label();
            this.LoginPassTb = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPB)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginLabel.Location = new System.Drawing.Point(9, 9);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(265, 42);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Bejelentkezés";
            // 
            // LoginUserLabel
            // 
            this.LoginUserLabel.AutoSize = true;
            this.LoginUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginUserLabel.Location = new System.Drawing.Point(41, 103);
            this.LoginUserLabel.Name = "LoginUserLabel";
            this.LoginUserLabel.Size = new System.Drawing.Size(124, 20);
            this.LoginUserLabel.TabIndex = 1;
            this.LoginUserLabel.Text = "Felhasználónév:";
            // 
            // LoginUserTb
            // 
            this.LoginUserTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginUserTb.Location = new System.Drawing.Point(45, 126);
            this.LoginUserTb.Name = "LoginUserTb";
            this.LoginUserTb.Size = new System.Drawing.Size(175, 26);
            this.LoginUserTb.TabIndex = 2;
            // 
            // LoginPassLabel
            // 
            this.LoginPassLabel.AutoSize = true;
            this.LoginPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginPassLabel.Location = new System.Drawing.Point(42, 167);
            this.LoginPassLabel.Name = "LoginPassLabel";
            this.LoginPassLabel.Size = new System.Drawing.Size(58, 20);
            this.LoginPassLabel.TabIndex = 3;
            this.LoginPassLabel.Text = "Jelszó:";
            // 
            // LoginPassTb
            // 
            this.LoginPassTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginPassTb.Location = new System.Drawing.Point(45, 190);
            this.LoginPassTb.Name = "LoginPassTb";
            this.LoginPassTb.Size = new System.Drawing.Size(175, 26);
            this.LoginPassTb.TabIndex = 4;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginBtn.Location = new System.Drawing.Point(55, 250);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(155, 35);
            this.LoginBtn.TabIndex = 5;
            this.LoginBtn.Text = "Bejelentkezés";
            this.LoginBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // ShowPB
            // 
            this.ShowPB.InitialImage = ((System.Drawing.Image)(resources.GetObject("ShowPB.InitialImage")));
            this.ShowPB.Location = new System.Drawing.Point(226, 190);
            this.ShowPB.Name = "ShowPB";
            this.ShowPB.Size = new System.Drawing.Size(26, 26);
            this.ShowPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPB.TabIndex = 7;
            this.ShowPB.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.ShowPB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.LoginPassTb);
            this.Controls.Add(this.LoginPassLabel);
            this.Controls.Add(this.LoginUserTb);
            this.Controls.Add(this.LoginUserLabel);
            this.Controls.Add(this.LoginLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(300, 370);
            this.MinimumSize = new System.Drawing.Size(300, 370);
            this.Name = "LoginForm";
            this.Text = "Bejelentkezés";
            ((System.ComponentModel.ISupportInitialize)(this.ShowPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label LoginUserLabel;
        private System.Windows.Forms.TextBox LoginUserTb;
        private System.Windows.Forms.Label LoginPassLabel;
        private System.Windows.Forms.TextBox LoginPassTb;
        public System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ShowPB;
    }
}