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

namespace RentHouse.Login_App
{
    public partial class Form_RecoveryPassWord : Form
    {
        public Form_RecoveryPassWord()
        {
            InitializeComponent();
            SetFormRegion(); // Set góc bo tròn cho form
        }

        private void Form_RecoveryPassWord_Load(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
