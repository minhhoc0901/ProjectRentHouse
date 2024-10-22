using RentHouse.DashBoardBody.ManagerAllListForm.HOPDONG;
using RentHouse_BUS;
using RentHouse_DAL.Entity;
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
    public partial class frmQLHopDong : Form
    {
        private readonly ChiTietHDService chiTietHDService = new ChiTietHDService();
        public frmQLHopDong()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemHopDong frm = new frmThemHopDong();
            frm.HopDongAdded += Frm_HopDongAdded;
            frm.ShowDialog();

        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            var chiTietHopDongs = chiTietHDService.GetAllChiTietHD();
            BindGrid(chiTietHopDongs);

        }
        private void LoadData()
        {
         
        }
        private void BindGrid(List<ChiTietHopDong>  chiTietHopDongs)
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

        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemHD.Text.Trim();
            var ctHopDongs = chiTietHDService.GetAllChiTietHD().Where(ctHD => ctHD.SoHopDong.Contains(keyword) ||
                                                                      ctHD.HopDong.KhachThue.HoTen.Contains(keyword) ||
                                                                      ctHD.PhongTro.MaPhong.Contains(keyword) ||
                                                                      ctHD.TinhTrangKetThuc.Contains(keyword)).ToList();
            BindGrid(ctHopDongs);
        }

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


        private void Frm_HopDongAdded(object sender, ChiTietHopDong e)
        {
            // Thêm dữ liệu mới vào dgvQLHopDong
            int index = dgvQLHopDong.Rows.Add();
            dgvQLHopDong.Rows[index].Cells[0].Value = e.SoHopDong;
            dgvQLHopDong.Rows[index].Cells[1].Value = e.HopDong.KhachThue.HoTen;
            dgvQLHopDong.Rows[index].Cells[2].Value = e.PhongTro.MaPhong;
            dgvQLHopDong.Rows[index].Cells[3].Value = e.PhongTro.GiaPhong;
            dgvQLHopDong.Rows[index].Cells[4].Value = e.HopDong.TienCoc;
            dgvQLHopDong.Rows[index].Cells[5].Value = e.HopDong.NgayLapHD;
            dgvQLHopDong.Rows[index].Cells[6].Value = e.NgayBatDau;
            dgvQLHopDong.Rows[index].Cells[7].Value = e.NgayKetThuc;
            dgvQLHopDong.Rows[index].Cells[8].Value = e.TinhTrangKetThuc;
            dgvQLHopDong.Rows[index].Cells[9].Value = e.GhiChu;
        }
    }
}
