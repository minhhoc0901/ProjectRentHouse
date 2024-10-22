using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentHouseBUS;
using RentHouseDAL.Entity;

namespace RentHouse.DashBoardBody.ManagerAllListForm.KHACHHANG
{
    public partial class UpdateCustomer : Form
    {
        private readonly KhachHangServices khachHangServices = new KhachHangServices();
        private readonly Form2 form2;
        public UpdateCustomer(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2 ?? throw new ArgumentNullException(nameof(form2), "Form quản lý chưa được khởi tạo"); 
        }

        private void LoadData(List<KhachThue> listKhach)
        {
            try
            {
                dgvKhach.Rows.Clear();
                foreach (var item in listKhach)
                {
                    int index = dgvKhach.Rows.Add();
                    dgvKhach.Rows[index].Cells["col_MaKhachHang"].Value = item.MaKH;
                    dgvKhach.Rows[index].Cells["col_HoTen"].Value = item.HoTen;
                    dgvKhach.Rows[index].Cells["col_CCCD"].Value = item.CCCD;
                    dgvKhach.Rows[index].Cells["col_SDT"].Value = item.SDT;
                    dgvKhach.Rows[index].Cells["col_DiaChi"].Value = item.DiaChi;
                    dgvKhach.Rows[index].Cells["col_GhiChu"].Value = item.GhiChu;
                    dgvKhach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi ở hàm LoadData, lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                var listKhach = khachHangServices.GetAllKhachHang();
                LoadData(listKhach);    
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi khi load form, lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvKhach.Rows[e.RowIndex];
                txtMaKhachHang.Text = selectedRow.Cells[0].Value.ToString();
                txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                txtCCCD.Text = selectedRow.Cells[2].Value.ToString();
                txtSDT.Text = selectedRow.Cells[3].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[4].Value.ToString();
                txtGhiChu.Text = selectedRow.Cells[5].Value.ToString();
            }
        }

        private void AddDataToGrid(KhachThue newKhach)
        {
            if (dgvKhach != null && dgvKhach.Columns.Contains("col_MaKhachHang"))
            {
                dgvKhach.Rows.Add(newKhach.MaKH, newKhach.HoTen, newKhach.CCCD, newKhach.SDT, newKhach.DiaChi, newKhach.GhiChu);
            }
        }

        private void ReturnToDefault()
        {
            txtMaKhachHang.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtMaKhachHang.Text) || string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtCCCD.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtGhiChu.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(!IsValidCCCD(txtCCCD.Text))
                {
                    MessageBox.Show("Căn cước công dân phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(!IsValidPhoneNumber(txtSDT.Text))
                {
                    MessageBox.Show("Số điện thoại phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var listKhach = khachHangServices.GetAllKhachHang();
                var khach = listKhach.FirstOrDefault(kh => kh.MaKH == int.Parse(txtMaKhachHang.Text));
                if (khach != null)
                {
                    khach.HoTen = txtHoTen.Text;
                    khach.CCCD = txtCCCD.Text;
                    khach.SDT = txtSDT.Text;
                    khach.DiaChi = txtDiaChi.Text;
                    khach.GhiChu = txtGhiChu.Text;

                    khachHangServices.InsertUpdate(khach);
                }
                else
                {
                    var newKhach = new KhachThue()
                    {
                        MaKH = int.Parse(txtMaKhachHang.Text),
                        HoTen = txtHoTen.Text,
                        CCCD = txtCCCD.Text,
                        SDT = txtSDT.Text,
                        DiaChi = txtDiaChi.Text,
                        GhiChu = txtGhiChu.Text,
                    };

                    AddDataToGrid(newKhach);
                    form2.AddDataToGrid(newKhach);
                    khachHangServices.InsertUpdate(newKhach);
                }
                LoadData(khachHangServices.GetAllKhachHang());
                form2.LoadData(khachHangServices.GetAllKhachHang());
                ReturnToDefault();
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex )
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu, lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit); 
        }

        private bool IsValidCCCD(string cccd)
        {
            return cccd.All(char.IsDigit);
        }
    }
}
