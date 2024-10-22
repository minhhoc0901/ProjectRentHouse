namespace RentHouse
{
    partial class Form_Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_RecoveryPw = new System.Windows.Forms.Label();
            this.label_Register = new System.Windows.Forms.Label();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPassWord = new System.Windows.Forms.TextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Login);
            this.panel1.Controls.Add(this.textPassWord);
            this.panel1.Controls.Add(this.textLogin);
            this.panel1.Controls.Add(this.label_Register);
            this.panel1.Controls.Add(this.label_RecoveryPw);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(474, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 437);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RentHouse.Properties.Resources.CloseUpdate;
            this.pictureBox1.Location = new System.Drawing.Point(273, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(35, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "PHẦN MỀM QUẢN LÝ TRỌ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(107)))), ((int)(((byte)(229)))));
            this.label2.Location = new System.Drawing.Point(69, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 44);
            this.label2.TabIndex = 2;
            this.label2.Text = "HOUSE G4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(107)))), ((int)(((byte)(229)))));
            this.label3.Location = new System.Drawing.Point(34, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên đăng nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(107)))), ((int)(((byte)(229)))));
            this.label4.Location = new System.Drawing.Point(34, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mật khẩu: ";
            // 
            // label_RecoveryPw
            // 
            this.label_RecoveryPw.AutoSize = true;
            this.label_RecoveryPw.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RecoveryPw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(107)))), ((int)(((byte)(229)))));
            this.label_RecoveryPw.Location = new System.Drawing.Point(35, 352);
            this.label_RecoveryPw.Name = "label_RecoveryPw";
            this.label_RecoveryPw.Size = new System.Drawing.Size(138, 19);
            this.label_RecoveryPw.TabIndex = 10;
            this.label_RecoveryPw.Text = "Quên mật khẩu?";
            this.label_RecoveryPw.Click += new System.EventHandler(this.label_RecoveryPw_Click);
            // 
            // label_Register
            // 
            this.label_Register.AutoSize = true;
            this.label_Register.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(107)))), ((int)(((byte)(229)))));
            this.label_Register.Location = new System.Drawing.Point(210, 352);
            this.label_Register.Name = "label_Register";
            this.label_Register.Size = new System.Drawing.Size(73, 19);
            this.label_Register.TabIndex = 11;
            this.label_Register.Text = "Đăng ký";
            this.label_Register.Click += new System.EventHandler(this.label_Register_Click);
            // 
            // textLogin
            // 
            this.textLogin.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLogin.Location = new System.Drawing.Point(38, 174);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(243, 27);
            this.textLogin.TabIndex = 7;
            this.textLogin.TextChanged += new System.EventHandler(this.textLogin_TextChanged);
            // 
            // textPassWord
            // 
            this.textPassWord.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassWord.Location = new System.Drawing.Point(38, 248);
            this.textPassWord.Name = "textPassWord";
            this.textPassWord.Size = new System.Drawing.Size(243, 27);
            this.textPassWord.TabIndex = 8;
            this.textPassWord.TextChanged += new System.EventHandler(this.textPassWord_TextChanged);
            // 
            // button_Login
            // 
            this.button_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(107)))), ((int)(((byte)(229)))));
            this.button_Login.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Login.ForeColor = System.Drawing.Color.White;
            this.button_Login.Location = new System.Drawing.Point(38, 294);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(243, 41);
            this.button_Login.TabIndex = 9;
            this.button_Login.Text = "ĐĂNG NHẬP";
            this.button_Login.UseVisualStyleBackColor = false;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::RentHouse.Properties.Resources.brgLoginUpdate;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(805, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textPassWord;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Label label_Register;
        private System.Windows.Forms.Label label_RecoveryPw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Login;
    }
}

