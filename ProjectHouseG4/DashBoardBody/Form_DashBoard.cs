using RentHouse.DashBoardBody.ManagerAllListForm;
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

namespace RentHouse.DashBoardBody
{
    public partial class Form_DashBoard : Form
    {
        public Form_DashBoard()
        {
            InitializeComponent();
            SetFormRegion(); // Set góc bo tròn cho form
            this.FormClosed += new FormClosedEventHandler(Form_Dashboard_FormClosed);
            button1.Click += button1_Click; // Add click event handler for button1
        }

        private void Form_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form_DashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void SetFormRegion()
        {
            int radius = 25; // Độ bo tròn của góc
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        private void ShowFormInPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            ShowFormInPanel(form1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            ShowFormInPanel(form2);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            ShowFormInPanel(form3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            ShowFormInPanel(form4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmHopDong form5 = new frmHopDong();
            ShowFormInPanel(form5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            ShowFormInPanel(form6);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void Form_DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


    }
}
