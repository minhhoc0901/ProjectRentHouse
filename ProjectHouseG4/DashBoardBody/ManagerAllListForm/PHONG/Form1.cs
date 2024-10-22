using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouse.DashBoardBody
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBox1.Enter += ComboBox1_Enter;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Text = "Lọc";
            comboBox1.ForeColor = Color.Gray;
        }

        private void ComboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Lọc")
            {
                comboBox1.Text = string.Empty;
                comboBox1.ForeColor = Color.Black;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
