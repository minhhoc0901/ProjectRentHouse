using RentHouse.DashBoardBody;
using RentHouse.Login_App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouse
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
            SetFormRegion(); // Set góc bo tròn cho form
            RegisterButtonEvents(button_Login); // Đăng ký sự kiện cho button "Đăng nhập"
            RegisterLabelEvents(label_RecoveryPw);
            RegisterLabelEvents(label_Register);// Đăng ký sự kiện cho label "Quên mật khẩu"
        }

        private void SetFormRegion()
        {
            int radius = 50; // Độ bo tròn của góc
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textLogin_TextChanged(object sender, EventArgs e)
        {
            if (textLogin.Text.Length > 23)
            {
                MessageBox.Show("Tên đăng nhập không được quá 23 ký tự");
                textLogin.Text = textLogin.Text.Replace(" ", "");
                textLogin.Text = textLogin.Text.Substring(0, 23);
                textLogin.SelectionStart = textLogin.Text.Length;
            }
            else if (textLogin.Text.Contains(" "))
            {
                textLogin.Text = textLogin.Text.Replace(" ", "");
                textLogin.SelectionStart = textLogin.Text.Length;
            }
        }

        private void textPassWord_TextChanged(object sender, EventArgs e)
        {
            textPassWord.PasswordChar = '*';
            if (textPassWord.Text.Length > 23)
            {
                MessageBox.Show("Mật khẩu không được quá 23 ký tự");
                textPassWord.Text = textPassWord.Text.Substring(0, 23);
                textPassWord.SelectionStart = textPassWord.Text.Length;
            }
        }

        // Sự kiện khi click vào button "Đăng nhập"
        private void RegisterButtonEvents(Button button)
        {
            button.MouseEnter += (sender, e) => Button_MouseHover(sender, e, button, true);
            button.MouseLeave += (sender, e) => Button_MouseHover(sender, e, button, false);
            SetDefaultButtonColors(button);
        }

        private void SetDefaultButtonColors(Button button)
        {
            button.ForeColor = Color.White;
            button.BackColor = Color.MediumSlateBlue;
        }

        private void Button_MouseHover(object sender, EventArgs e, Button button, bool isMouseEnter)
        {
            if (isMouseEnter)
            {
                button.ForeColor = Color.White;
                button.BackColor = Color.MediumSeaGreen;
            }
            else
            {
                button.ForeColor = Color.White;
                button.BackColor = Color.MediumSlateBlue;
            }
        }

        // Sự kiện khi click vào label 
        private void RegisterLabelEvents(Label label)
        {
            label.MouseEnter += (sender, e) => Label_MouseHover(sender, e, label, true);
            label.MouseLeave += (sender, e) => Label_MouseHover(sender, e, label, false);
        }

        private void Label_MouseHover(object sender, EventArgs e, Label label, bool isMouseEnter)
        {
            if (isMouseEnter)
            {
                label.Font = new Font(label.Font, FontStyle.Underline);
            }
            else
            {
                label.Font = new Font(label.Font, FontStyle.Bold);
            }
        }

        private void label_RecoveryPw_Click(object sender, EventArgs e)
        {
            Form_RecoveryPassWord frm_RP = new Form_RecoveryPassWord();
            frm_RP.Show();
        }

        private void label_Register_Click(object sender, EventArgs e)
        {
            Form_RegisterAccout form_RegisterAccout = new Form_RegisterAccout();
            form_RegisterAccout.Show();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            if(textLogin.Text == "admin" && textPassWord.Text == "123")
            {
                MessageBox.Show("Đăng nhập thành công");
                Form_DashBoard frm_DB = new Form_DashBoard();
                frm_DB.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
