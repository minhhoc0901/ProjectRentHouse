using RentHouse_BUS;
using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouse.DashBoardBody.ManagerAllListForm.HOPDONG
{
    public partial class frmQLHD : Form
    {
        private readonly ChiTietHopDongService chiTietHDService = new ChiTietHopDongService();
        RentHouseContextDB contextDB = new RentHouseContextDB();
        public frmQLHD()
        {
            InitializeComponent();
        }

        private void frmQLHD_Load(object sender, EventArgs e)
        {
            var chiTietHopDongs = chiTietHDService.GetAllChiTietHD();
            BindGrid(chiTietHopDongs);
        }
        // Hiển thị dữ liệu lên datagridview
        public void BindGrid(List<ChiTietHopDong> chiTietHopDongs)
        {
            dgvQLHopDong.Rows.Clear();
            foreach (var item in chiTietHopDongs)
            {
                int index = dgvQLHopDong.Rows.Add();
                dgvQLHopDong.Rows[index].Cells[0].Value = item.SoHopDong;
                dgvQLHopDong.Rows[index].Cells[1].Value = item.HopDong.KhachThue.HoTen;
                dgvQLHopDong.Rows[index].Cells[2].Value = item.PhongTro.MaPhong;
                dgvQLHopDong.Rows[index].Cells[3].Value = item.PhongTro.GiaPhong;
                dgvQLHopDong.Rows[index].Cells[4].Value = item.HopDong.TienCoc;
                dgvQLHopDong.Rows[index].Cells[5].Value = item.HopDong.NgayLapHD;
                dgvQLHopDong.Rows[index].Cells[6].Value = item.NgayBatDau;
                dgvQLHopDong.Rows[index].Cells[7].Value = item.NgayKetThuc;
                dgvQLHopDong.Rows[index].Cells[8].Value = item.TinhTrangKetThuc;
                dgvQLHopDong.Rows[index].Cells[9].Value = item.GhiChu;
               
            }
        }

        // Tìm kiếm hợp đồng
        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemHD.Text.Trim();
            var ctHopDongs = chiTietHDService.GetAllChiTietHD().Where(ctHD => ctHD.SoHopDong.Contains(keyword) ||
                                                                      ctHD.HopDong.KhachThue.HoTen.Contains(keyword) ||
                                                                      ctHD.PhongTro.MaPhong.Contains(keyword) ||
                                                                      ctHD.TinhTrangKetThuc.Contains(keyword)).ToList();
            BindGrid(ctHopDongs);
        }

        // Hiển thị hợp đồng đã kết thúc
        private void cbHienThiHD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiHD.Checked)
            {
                var chiTietHopDongs = chiTietHDService.GetAllChiTietHD().Where(hd => hd.TinhTrangKetThuc == "Đã kết thúc").ToList();
                BindGrid(chiTietHopDongs);
            }
            else
            {
                var chiTietHopDongs = chiTietHDService.GetAllChiTietHD();
                BindGrid(chiTietHopDongs);
            }
        }

        // Load form xóa hợp đồng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            frmThemHopDong frmThemHopDong = new frmThemHopDong();
            frmThemHopDong.ShowDialog();
            //this.Hide();
        }

        // Load form cập nhật hợp đồng
        private void btnUpDate_Click(object sender, EventArgs e)
        {
            frmThemHopDong frmThemHopDong = new frmThemHopDong();
            frmThemHopDong.ShowDialog();
            //this.Hide();

        }

        // Trể vào giao diện chính
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form_DashBoard frmDashBoard = new Form_DashBoard();
            frmDashBoard.ShowDialog();
            this.Hide();
        }
    }
}

