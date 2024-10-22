using RentHouse_BUS;
using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace RentHouse.DashBoardBody.ManagerAllListForm.HOPDONG
{
    public partial class frmThemHopDong : Form
    {

        private readonly HopDongService hopDongService = new HopDongService();
        private readonly KhachThueService khachThueService = new KhachThueService();
        private readonly PhongTroService phongTroService = new PhongTroService();
        private readonly ChiTietHopDongService chiTietHDService = new ChiTietHopDongService();



        public frmThemHopDong()
        {
            InitializeComponent();

        }


        // form load
        private void frmThemHopDong_Load(object sender, EventArgs e)
        {
            rdHopDong.Checked = true;
            var trangThai = new List<string> { "Đã kết thúc", "Chưa Kết Thúc " };
            cmbTrangThai.DataSource = trangThai;
            cmbTrangThai.SelectedIndex = 1;
            dateNgayLap.Value = DateTime.Now;
            dateNgayBD.Value = DateTime.Now;
            dateNgayKT.Value = DateTime.Today.AddYears(1);
            KhoaMo(true);
            var chiTietHopDongs = chiTietHDService.GetAllChiTietHD();
            BindDataCTHopDong(chiTietHopDongs);

        }

        // Load dữ liệu khách thuê
        private void BindDataKhachThue(List<KhachThue> khachThues)
        {
            dgvDaThongTin.Columns.Clear(); // Clear existing columns
            dgvDaThongTin.Rows.Clear();

            // Add new columns
            dgvDaThongTin.Columns.Add("MaKH", "MaKH");
            dgvDaThongTin.Columns.Add("HoTen", "HoTen");
            dgvDaThongTin.Columns.Add("CMND", "CMND");
            dgvDaThongTin.Columns.Add("DiaChi", "DiaChi");
            dgvDaThongTin.Columns.Add("SDT", "SDT");

            foreach (var khachthue in khachThues)
            {
                int index = dgvDaThongTin.Rows.Add();
                dgvDaThongTin.Rows[index].Cells[0].Value = khachthue.MaKH;
                dgvDaThongTin.Rows[index].Cells[1].Value = khachthue.HoTen;
                dgvDaThongTin.Rows[index].Cells[2].Value = khachthue.CCCD;
                dgvDaThongTin.Rows[index].Cells[3].Value = khachthue.DiaChi;
                dgvDaThongTin.Rows[index].Cells[4].Value = khachthue.SDT;
            }
        }

        // cell dữ liệu 
        private void dgvDaThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDaThongTin.Rows[e.RowIndex];
                if (rdKhachHang.Checked)
                {
                    
                    txtMaKT.Text = row.Cells[0].Value.ToString();
                    txtTenKT.Text = row.Cells[1].Value.ToString();
                   
                }
                else if (rdPhong.Checked)
                {
                    
                    txtMaPhong.Text = row.Cells[0].Value.ToString();
                    txtDienTich.Text = row.Cells[2].Value.ToString();
                    txtTienThue.Text = row.Cells[3].Value.ToString();
                   
                }
                else if (rdHopDong.Checked)
                {
                    string soHD = row.Cells[0].Value.ToString();
                    var hopDongs = hopDongService.GetAllHopDong().FirstOrDefault(hd => hd.SoHopDong == soHD);
                    if (hopDongs != null)
                    {
                        txtCTSoHD.Text = hopDongs.SoHopDong;
                        txtMaKT.Text = hopDongs.MaKH.ToString();
                        txtTenKT.Text = hopDongs.KhachThue.HoTen.ToString();
                        txtTienCoc.Text = hopDongs.TienCoc.ToString();
                    }

                }
            }
        }

        // Clear data nhập
        private void RestData()
        {
            txtCTSoHD.Text = "";
            txtMaKT.Text = "";
            txtTenKT.Text = "";
            txtMaPhong.Text = "";
            txtDienTich.Text = "";
            txtTienCoc.Text = "";
            txtTienThue.Text = "";
            cmbTrangThai.SelectedIndex = 1;
            dateNgayLap.Value = DateTime.Now;
            dateNgayBD.Value = DateTime.Now;
            dateNgayKT.Value = DateTime.Now;
            grCTHD.Text = "";
            txtMaCTHD.Text = "";
        }

        // Load dư liệu Phòng Trọ
        private void BindDataPhongTro(List<PhongTro> phongTros)
        {
            dgvDaThongTin.Columns.Clear(); // Clear existing columns
            dgvDaThongTin.Rows.Clear();

            // Add new columns
            dgvDaThongTin.Columns.Add("colMaPhong", "Mã Phòng");
            dgvDaThongTin.Columns.Add("colThongTin", "Thông Tin");
            dgvDaThongTin.Columns.Add("colDienTich", "Diện Tích");
            dgvDaThongTin.Columns.Add("colGiaPhong", "Giá Phòng");
            dgvDaThongTin.Columns.Add("colTinhTrang", "Tình Trạng");

            foreach (var phongtro in phongTros)
            {
                int index = dgvDaThongTin.Rows.Add();
                dgvDaThongTin.Rows[index].Cells[0].Value = phongtro.MaPhong;
                dgvDaThongTin.Rows[index].Cells[1].Value = phongtro.ThongTin;
                dgvDaThongTin.Rows[index].Cells[2].Value = phongtro.DienTich;
                dgvDaThongTin.Rows[index].Cells[3].Value = phongtro.GiaPhong;
                dgvDaThongTin.Rows[index].Cells[4].Value = phongtro.TrangThai;
            }
        }


        // Checked rb HopDong
        private void rdHopDong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdHopDong.Checked)
            {
                KhoaMo(false);
                var hopDongs = hopDongService.GetAllHopDong();
                BindDataHopDong(hopDongs);
                //BindDataCTHopDong(chiTietHDService.GetAllChiTietHD());
            }
            else { KhoaMo(true); }
        }


        // Checked rb KhachHang
        private void rdKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdKhachHang.Checked)
            {
                var khachThues = khachThueService.GetAllKhachThue();
                BindDataKhachThue(khachThues);
            }
        }

        // Checked rb Phong
        private void rdPhong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPhong.Checked)
            {
                var phongTros = phongTroService.GetAllNoDaThue();
                //var phongTros = phongTroService.GetAllPhongTro();
                BindDataPhongTro(phongTros);
            }
        }

        // Tìm kiếm
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            if (rdKhachHang.Checked)
            {
                var khachThues = khachThueService.GetAllKhachThue()
                    .Where(khachThue => khachThue.HoTen.ToLower().Contains(keyword) ||
                                        khachThue.MaKH.ToString().Contains(keyword))
                    .ToList();
                BindDataKhachThue(khachThues);
            }
            else if (rdPhong.Checked)
            {
                var phongTros = phongTroService.GetAllPhongTro()
                    .Where(phongTro => phongTro.ThongTin.ToLower().Contains(keyword) ||
                                       phongTro.MaPhong.ToLower().Contains(keyword) ||
                                       phongTro.TrangThai.ToLower().Contains(keyword) ||
                                       phongTro.GiaPhong.ToString().Contains(keyword))
                    .ToList();
                BindDataPhongTro(phongTros);
            }
            else if (rdHopDong.Checked)
            {
                var hopDongs = hopDongService.GetAllHopDong()
                    .Where(hopDong => hopDong.SoHopDong.ToLower().Contains(keyword) ||
                                      hopDong.MaKH.ToString().Contains(keyword) ||
                                      hopDong.TienCoc.ToString().Contains(keyword))
                    .ToList();
                BindDataHopDong(hopDongs);
            }
            else 
            {
                var cthopDongs = chiTietHDService.GetAllChiTietHD()
                    .Where(ctHD => ctHD.SoHopDong.ToLower().Contains(keyword) ||
                                   ctHD.MaPhong.ToLower().Contains(keyword) ||
                                   ctHD.GiaThue.ToString().Contains(keyword) ||
                                   ctHD.TinhTrangKetThuc.ToLower().Contains(keyword))
                    .ToList();
                BindDataCTHD(cthopDongs);
            }
        }

        // Kiểm tra dữ liệu chi tiết hợp đồng
        public bool IsValidChiTietHopDong()
        {
            // Kiểm tra SoHopDong
            if (string.IsNullOrWhiteSpace(txtCTSoHD.Text) || txtCTSoHD.Text.Length < 3 || txtCTSoHD.Text.Length > 50)
            {
                MessageBox.Show("Số hợp đồng không hợp lệ. Số hợp đồng phải có từ 3 đến 50 ký tự.");
                return false;
            }

            // Kiểm tra MaPhong
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Mã phòng không được để trống.");
                return false;
            }

            // Kiểm tra DienTich
            if (!float.TryParse(txtDienTich.Text, out float dienTich) || dienTich <= 0)
            {
                MessageBox.Show("Diện tích không hợp lệ. Diện tích phải là số lớn hơn 0.");
                return false;
            }

            // Kiểm tra TienThue (GiaThue)
            if (!float.TryParse(txtTienThue.Text, out float tienThue) || tienThue <= 0)
            {
                MessageBox.Show("Tiền thuê không hợp lệ. Tiền thuê phải là số lớn hơn 0.");
                return false;
            }

            // Kiểm tra NgayBatDau
            if (dateNgayBD.Value == default(DateTime))
            {
                MessageBox.Show("Ngày bắt đầu không hợp lệ.");
                return false;
            }

            // Kiểm tra NgayKetThuc
            if (dateNgayKT.Value == default(DateTime) || dateNgayKT.Value <= dateNgayBD.Value)
            {
                MessageBox.Show("Ngày kết thúc không hợp lệ. Ngày kết thúc phải lớn hơn ngày bắt đầu.");
                return false;
            }

            // Kiểm tra GhiChu (nếu có)
            if (!string.IsNullOrWhiteSpace(grCTHD.Text) && (grCTHD.Text.Length < 3 || grCTHD.Text.Length > 255))
            {
                MessageBox.Show("Ghi chú không hợp lệ. Ghi chú phải có từ 3 đến 255 ký tự.");
                return false;
            }

            return true; // Nếu tất cả các điều kiện đều hợp lệ
        }


        // Kiểm tra dữ liệu hợp đồng 

        private bool IsHopDong()
        {
            // Kiểm tra SoHopDong
            if (string.IsNullOrWhiteSpace(txtCTSoHD.Text))
            {
                MessageBox.Show("Số hợp đồng không được để trống.");
                return false;
            }
            if (txtCTSoHD.Text.Length < 3 || txtCTSoHD.Text.Length > 50)
            {
                MessageBox.Show("Số hợp đồng phải có độ dài từ 3 đến 50 ký tự.");
                return false;
            }

            // Kiểm tra MaKH
            if (string.IsNullOrWhiteSpace(txtMaKT.Text))
            {
                MessageBox.Show("Mã khách thuê không được để trống.");
                return false;
            }
            if (!int.TryParse(txtMaKT.Text, out int maKT))
            {
                MessageBox.Show("Mã khách thuê phải là số nguyên.");
                return false;
            }

            // Kiểm tra TienCoc
            if (string.IsNullOrWhiteSpace(txtTienCoc.Text))
            {
                MessageBox.Show("Tiền cọc không được để trống.");
                return false;
            }
            if (!float.TryParse(txtTienCoc.Text, out float tienCoc))
            {
                MessageBox.Show("Tiền cọc phải là số thực.");
                return false;
            }
            if (tienCoc <= 0)
            {
                MessageBox.Show("Tiền cọc phải lớn hơn 0.");
                return false;
            }

            // Kiểm tra NgayLapHD
            if (dateNgayLap.Value == default(DateTime))
            {
                MessageBox.Show("Ngày lập hợp đồng không hợp lệ.");
                return false;
            }
            if (dateNgayLap.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày lập hợp đồng không được lớn hơn ngày hiện tại.");
                return false;
            }

            return true;
        }

        // Thêm hợp đồng

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (rdHopDong.Checked)
            {
                try
                {
                    if (!IsValidChiTietHopDong())
                    {
                        return;
                    }
                    var hopDongs = hopDongService.GetHopDongById(txtCTSoHD.Text);
                    var cthopDongs = chiTietHDService.GetAllChiTietHD().FirstOrDefault(s => s.SoHopDong == txtCTSoHD.Text);

                    if (hopDongs != null)
                    {
                        DialogResult result = MessageBox.Show("Số hợp đồng đã tồn tại. Bạn có muốn cập nhật dữ liệu không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            hopDongs.MaKH = int.Parse(txtMaKT.Text);
                            hopDongs.TienCoc = float.Parse(txtTienCoc.Text);
                            hopDongs.NgayLapHD = dateNgayLap.Value;
                            hopDongService.UpdateHopDong(hopDongs);
                            if( cthopDongs != null)
                            {
                                cthopDongs.SoHopDong = txtCTSoHD.Text;
                                cthopDongs.MaPhong = txtMaPhong.Text;
                                cthopDongs.GiaThue = float.Parse(txtTienThue.Text);
                                cthopDongs.NgayBatDau = dateNgayBD.Value;
                                cthopDongs.NgayKetThuc = dateNgayKT.Value;
                                cthopDongs.TinhTrangKetThuc = cmbTrangThai.SelectedValue.ToString();
                                cthopDongs.GhiChu = txtGhiChus.Text;
                                chiTietHDService.UpdateChiTietHD(cthopDongs);
                            }
                            
                            MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        HopDong hd = new HopDong()
                        {

                            SoHopDong = txtCTSoHD.Text,
                            MaKH = int.Parse(txtMaKT.Text),
                            TienCoc = float.Parse(txtTienCoc.Text),
                            NgayLapHD = dateNgayLap.Value
                        };
                        hopDongService.AddHopDong(hd);
                       
                        ChiTietHopDong chiTietHopDong = new ChiTietHopDong()
                        {
                            //MaCTHD = int.Parse(txtMaCTHD.Text) ,
                            SoHopDong = txtCTSoHD.Text,
                            MaPhong = txtMaPhong.Text,
                            GiaThue = float.Parse(txtTienThue.Text),
                            NgayBatDau = dateNgayBD.Value,
                            NgayKetThuc = dateNgayKT.Value,
                            TinhTrangKetThuc = cmbTrangThai.SelectedValue.ToString(),
                            GhiChu = txtGhiChus.Text
                        };
                        chiTietHDService.addChiTietHD(chiTietHopDong);
                        MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    BindDataHopDong(hopDongService.GetAllHopDong());
                    BindDataCTHopDong(chiTietHDService.GetAllChiTietHD());
                    RestData();

                    //txtCTSoHD.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm mới dữ liệu thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vào hợp đồng trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load dữ liệu hợp đồng
        private void BindDataHopDong(List<HopDong> hopDongs)
        {
            dgvDaThongTin.Columns.Clear(); // Clear existing columns
            dgvDaThongTin.Rows.Clear();

            // Define columns
            dgvDaThongTin.Columns.Add("colSoHD", "Số HĐ");
            dgvDaThongTin.Columns.Add("colMaKH", "Mã KH");
            dgvDaThongTin.Columns.Add("colTienCoc", "Tiền Cọc");
            dgvDaThongTin.Columns.Add("colNgayLapHD", "Ngày Lập HD");

            foreach (var hopdong in hopDongs)
            {
                int index = dgvDaThongTin.Rows.Add();
                dgvDaThongTin.Rows[index].Cells[0].Value = hopdong.SoHopDong;
                dgvDaThongTin.Rows[index].Cells[1].Value = hopdong.MaKH;
                dgvDaThongTin.Rows[index].Cells[2].Value = hopdong.TienCoc;
                dgvDaThongTin.Rows[index].Cells[3].Value = hopdong.NgayLapHD;
            }
        }

        // Load dữ liệu chi tiết hợp đồng
        private void BindDataCTHD(List<ChiTietHopDong> chiTietHopDongs)
        {
            dgvDaThongTin.Columns.Clear(); // Clear existing columns
            dgvDaThongTin.Rows.Clear();
            dgvDaThongTin.Columns.Add("colMaCTHD", "Mã CTHD");
            dgvDaThongTin.Columns.Add("colSoHD", "Số HĐ");
            dgvDaThongTin.Columns.Add("colMaPhong", "Mã Phòng");
            dgvDaThongTin.Columns.Add("colGiaThue", "Giá Thuê");
            dgvDaThongTin.Columns.Add("colNgayBD", "Ngày Bắt Đầu");
            dgvDaThongTin.Columns.Add("colNgayKT", "Ngày Kết Thúc");
            dgvDaThongTin.Columns.Add("colTinhTrangKT", "Tình Trạng");
            dgvDaThongTin.Columns.Add("colGhiChu", "Ghi Chú");
            foreach (var cthd in chiTietHopDongs)
            {
                int index = dgvDaThongTin.Rows.Add();
                dgvDaThongTin.Rows[index].Cells[0].Value = cthd.MaCTHD;
                dgvDaThongTin.Rows[index].Cells[1].Value = cthd.SoHopDong;
                dgvDaThongTin.Rows[index].Cells[2].Value = cthd.MaPhong;
                dgvDaThongTin.Rows[index].Cells[3].Value = cthd.GiaThue;
                dgvDaThongTin.Rows[index].Cells[4].Value = cthd.NgayBatDau;
                dgvDaThongTin.Rows[index].Cells[5].Value = cthd.NgayKetThuc;
                dgvDaThongTin.Rows[index].Cells[6].Value = cthd.TinhTrangKetThuc;
                dgvDaThongTin.Rows[index].Cells[7].Value = cthd.GhiChu;
            }
        }
        private void BindDataCTHopDong(List<ChiTietHopDong> chiTietHopDongs)
        {
            dgvCTHD.Columns.Clear(); 
            dgvCTHD.Rows.Clear();
            dgvCTHD.Columns.Add("colMaCTHD", "Mã CTHD");
            dgvCTHD.Columns.Add("colSoHD", "Số HĐ");
            dgvCTHD.Columns.Add("colMaPhong", "Mã Phòng");
            dgvCTHD.Columns.Add("colGiaThue", "Giá Thuê");
            dgvCTHD.Columns.Add("colNgayBD", "Ngày Bắt Đầu");
            dgvCTHD.Columns.Add("colNgayKT", "Ngày Kết Thúc");
            dgvCTHD.Columns.Add("colTinhTrangKT", "Tình Trạng");
            dgvCTHD.Columns.Add("colGhiChu", "Ghi Chú");
            foreach (var cthd in chiTietHopDongs)
            {
                int index = dgvCTHD.Rows.Add();
                dgvCTHD.Rows[index].Cells[0].Value = cthd.MaCTHD;
                dgvCTHD.Rows[index].Cells[1].Value = cthd.SoHopDong;
                dgvCTHD.Rows[index].Cells[2].Value = cthd.MaPhong;
                dgvCTHD.Rows[index].Cells[3].Value = cthd.GiaThue;
                dgvCTHD.Rows[index].Cells[4].Value = cthd.NgayBatDau;
                dgvCTHD.Rows[index].Cells[5].Value = cthd.NgayKetThuc;
                dgvCTHD.Rows[index].Cells[6].Value = cthd.TinhTrangKetThuc;
                dgvCTHD.Rows[index].Cells[7].Value = cthd.GhiChu;
            }
        }

        //  Xóa chi tiết hợp đồng
        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            
                if (dgvCTHD.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết hợp đồng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
             
                string maCTHD = dgvCTHD.SelectedRows[0].Cells[0].Value.ToString();


            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết hợp đồng " + txtCTSoHD.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                chiTietHDService.DeleteChiTietHD(int.Parse(maCTHD));
                hopDongService.DeleteHopDong(txtCTSoHD.Text);
                BindDataCTHopDong(chiTietHDService.GetAllChiTietHD());
                BindDataHopDong(hopDongService.GetAllHopDong());
            }
            RestData();   
        }

        private void btnDongFrm_Click(object sender, EventArgs e)
        {
            frmQLHD frm = new frmQLHD();
            frm.Show();  
        }


        public void KhoaMo(bool b)
        {
            btnThemHD.Enabled = !b;
            btnXoaCTHD.Enabled = !b;
        }       
        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCTHD.Rows[e.RowIndex];
                string maCTHD = row.Cells[0].Value.ToString();
                var cthopDongs = chiTietHDService.GetAllChiTietHD().FirstOrDefault(hd => hd.MaCTHD.ToString() == maCTHD);
                if (cthopDongs != null && cthopDongs.HopDong != null)
                {
                    txtMaCTHD.Text = cthopDongs.MaCTHD.ToString();
                    txtCTSoHD.Text = cthopDongs.SoHopDong;
                    txtMaKT.Text = cthopDongs.HopDong.MaKH.ToString();
                    txtTenKT.Text = cthopDongs.HopDong.KhachThue.HoTen.ToString();
                    dateNgayBD.Value = cthopDongs.NgayBatDau.Value;
                    dateNgayKT.Value = cthopDongs.NgayKetThuc.Value;
                    cmbTrangThai.Text = cthopDongs.TinhTrangKetThuc;
                    txtTienCoc.Text = cthopDongs.HopDong.TienCoc.ToString();
                    txtMaPhong.Text = cthopDongs.MaPhong;
                    txtDienTich.Text = cthopDongs.PhongTro.DienTich.ToString();
                    txtTienThue.Text = cthopDongs.GiaThue.ToString();
                    txtGhiChus.Text = cthopDongs.GhiChu;
                }
            }
        }

        private void frmThemHopDong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đóng form không?", "Xác nhận", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                frmQLHD frm = new frmQLHD();
                frm.Show();
            }
        }
    }
}
