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

namespace RentHouse.DashBoardBody.ManagerAllListForm.PHONG
{
    public partial class UpdateRoom : Form
    {
        private readonly PhongTroService phongTroService = new PhongTroService();
        private readonly Form1 form1;
        public UpdateRoom(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1 ?? throw new ArgumentNullException(nameof(form1), "Form quản lý chưa được khởi tạo"); 
        }

        private void ReturnToDefault()
        {
            txtMaPhong.Clear();
            txtThongTin.Clear();
            txtGiaPhong.Clear();
            txtDienTich.Clear();    
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaPhong.Text) || string.IsNullOrEmpty(txtThongTin.Text) || string.IsNullOrEmpty(txtDienTich.Text) || string.IsNullOrEmpty(txtGiaPhong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cbTrangThai.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                float giaPhong, dienTich;
                if (!float.TryParse(txtGiaPhong.Text, out giaPhong))
                {
                    MessageBox.Show("Giá phòng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!float.TryParse(txtDienTich.Text, out dienTich))
                {
                    MessageBox.Show("Diện tích phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var listPhongTro = phongTroService.GetALLPhongTro();
                var phongTro = listPhongTro.FirstOrDefault(p => p.MaPhong == txtMaPhong.Text);
                if (phongTro != null)
                {
                    phongTro.ThongTin = txtThongTin.Text;
                    phongTro.GiaPhong = float.Parse(txtGiaPhong.Text);
                    phongTro.DienTich = float.Parse(txtDienTich.Text);
                    phongTro.TrangThai = cbTrangThai.SelectedItem.ToString();

                    phongTroService.UpdatePhongTro(phongTro);
                    LoadData(phongTroService.GetALLPhongTro());
                    form1.LoadData(phongTroService.GetALLPhongTro());
                    ReturnToDefault();
                    
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var newPhongTro = new PhongTro()
                    {
                        MaPhong = txtMaPhong.Text,
                        ThongTin = txtThongTin.Text,
                        GiaPhong = giaPhong,
                        DienTich = dienTich,
                        TrangThai = cbTrangThai.SelectedItem.ToString()
                    };

                    form1.AddDataToGrid(newPhongTro);
                    AddDataToGrid(newPhongTro);
                    phongTroService.AddPhongTro(newPhongTro);
                    ReturnToDefault();

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi UPDATEROOM: {ex.Message}", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        
        private void UpdateRoom_Load_1(object sender, EventArgs e)
        {
            var trangThaiList = new List<string> { "Phòng đã cho thuê", "Phòng đang bảo trì", "Phòng trống" };
            cbTrangThai.DataSource = trangThaiList;
            var listPhongTro = phongTroService.GetALLPhongTro();
            LoadData(listPhongTro);
        }
        public void LoadData(List<PhongTro> listPhong)
        {
            dgvPhong.Rows.Clear();
            foreach (var phong in listPhong)
            {
                int index = dgvPhong.Rows.Add();
                dgvPhong.Rows[index].Cells["col_MaPhong"].Value = phong.MaPhong;
                dgvPhong.Rows[index].Cells["col_ThongTin"].Value = phong.ThongTin;
                dgvPhong.Rows[index].Cells["col_GiaPhong"].Value = phong.GiaPhong;
                dgvPhong.Rows[index].Cells["col_DienTich"].Value = phong.DienTich;
                dgvPhong.Rows[index].Cells["col_TrangThai"].Value = phong.TrangThai;
            }
        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvPhong.Rows[e.RowIndex];
                txtMaPhong.Text = selectedRow.Cells[0].Value.ToString();
                txtThongTin.Text = selectedRow.Cells[1].Value.ToString();
                txtGiaPhong.Text = selectedRow.Cells[2].Value.ToString();
                txtDienTich.Text = selectedRow.Cells[3].Value.ToString();
                cbTrangThai.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        public void AddDataToGrid(PhongTro newPhongTro)
        {
            if (dgvPhong != null && dgvPhong.Columns.Contains("col_MaPhong"))
            {
                dgvPhong.Rows.Add(newPhongTro.MaPhong, newPhongTro.ThongTin, newPhongTro.GiaPhong, newPhongTro.DienTich, newPhongTro.TrangThai);
            }
        }
    }
}
