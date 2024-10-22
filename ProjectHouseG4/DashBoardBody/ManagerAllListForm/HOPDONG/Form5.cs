using RentHouse.DashBoardBody.ManagerAllListForm.HOPDONG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouse.DashBoardBody.ManagerAllListForm
{
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemHopDong frm = new frmThemHopDong();
            frm.ShowDialog();

        }
    }
}
