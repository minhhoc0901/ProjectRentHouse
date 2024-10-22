using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
   using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RentHouse.Login_App
{
    public partial class Form_RegisterAccout : Form
    {
        public Form_RegisterAccout()
        {
            InitializeComponent();
            SetFormRegion(); // Set góc bo tròn cho form
            btnRegisterEvent(); // Đăng ký sự kiện cho button "Đăng ký"
            RegisterButtonHoverEvent(button1); // Đăng ký sự kiện cho button "Đăng ký"

        }

        private void Form_RegisterAccout_Load(object sender, EventArgs e)
        {

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

        private void btnRegisterEvent()
        {
            RegisterTextBoxEvent(textBox1, "Nhập tên đăng nhập");
            RegisterTextBoxEvent(textBox2, "Nhập mật khẩu");
            RegisterTextBoxEvent(textBox3, "Xác nhận mật khẩu");
            RegisterTextBoxEvent(textBox4, "Nhập họ và tên");
            RegisterTextBoxEvent(textBox5, "Nhập số điện thoại");
            RegisterTextBoxEvent(textBox6, "Nhập email");
            RegisterTextBoxEvent(textBox7, "Nhập địa chỉ");
        }


        private void RegisterTextBoxEvent(System.Windows.Forms.TextBox textBox, string defaultText)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = defaultText;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == defaultText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (textBox.Text == "")
                {
                    textBox.ForeColor = Color.Gray;
                    textBox.Text = defaultText;
                }
            };
        }

        private void RegisterButtonHoverEvent(System.Windows.Forms.Button button)
        {
            Color originalBackColor = button.BackColor;
            Color originalForeColor = button.ForeColor;

            button.MouseEnter += (s, e) =>
            {
                button.BackColor = Color.MediumSeaGreen;
                button.ForeColor = Color.White;
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = originalBackColor;
                button.ForeColor = originalForeColor;
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string input = textBox4.Text;
            string filteredInput = FilterInput(input);
            textBox4.Text = filteredInput;
        }

        private string FilterInput(string input)
        {
            string filteredInput = "";
            foreach (char c in input)
            {
                if (char.IsLetter(c) || c == ' ')
                {
                    filteredInput += c;
                }
            }
            return filteredInput;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private bool IsValidEmail(string email)
        //{
        //    // Biểu thức chính quy để kiểm tra địa chỉ email
        //    string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        //    // Kiểm tra xem chuỗi nhập vào có khớp với biểu thức chính quy hay không
        //    return Regex.IsMatch(email, pattern);
        //}

        //private void textBox5_TextChanged(object sender, EventArgs e)
        //{
        //    string input = textBox5.Text;

        //    if (IsValidEmail(input))
        //    {
        //        // Địa chỉ email hợp lệ
        //        // Thực hiện các hành động khác tại đây
        //    }
        //    else
        //    {
        //        // Địa chỉ email không hợp lệ
        //        // Thực hiện các hành động khác tại đây
        //    }
        //}
    }
}
