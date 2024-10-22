using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentHouse.DashBoardBody.ManagerAllListForm.PHONG;
using RentHouseBUS;
using RentHouseDAL.Entity;

namespace RentHouse.DashBoardBody
{
    public partial class Form1 : Form
    {
        private readonly PhongTroService phongTroService = new PhongTroService();
        private readonly ChiTietHopDongServices chiTietHopDongServices = new ChiTietHopDongServices();  
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
            comboBox1.Items.Add("Mã phòng");
            comboBox1.Items.Add("Giá phòng");
        }

        private void ComboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Lọc")
            {
                comboBox1.Text = string.Empty;
                comboBox1.ForeColor = Color.Black;
            }
        }

        public void LoadData(List<PhongTro> listPhong)
        {
            dgvPhong.Rows.Clear();
            foreach(var phong in listPhong)
            { 
                int index = dgvPhong.Rows.Add();
                dgvPhong.Rows[index].Cells["col_MaPhong"].Value = phong.MaPhong;
                dgvPhong.Rows[index].Cells["col_ThongTin"].Value = phong.ThongTin;
                dgvPhong.Rows[index].Cells["col_GiaPhong"].Value = phong.GiaPhong;
                dgvPhong.Rows[index].Cells["col_DienTich"].Value = phong.DienTich;
                dgvPhong.Rows[index].Cells["col_TrangThai"].Value = phong.TrangThai;
                dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateRoom updateRoom = new UpdateRoom(this);   
            updateRoom.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                var listPhongTro = phongTroService.GetALLPhongTro() ?? new List<PhongTro>();
                LoadData(listPhongTro);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi ở form 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddDataToGrid(PhongTro newPhongTro)
        {
            if(dgvPhong != null && dgvPhong.Columns.Contains("col_MaPhong"))
            {
                dgvPhong.Rows.Add(newPhongTro.MaPhong, newPhongTro.ThongTin, newPhongTro.GiaPhong, newPhongTro.DienTich, newPhongTro.TrangThai);    
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhong.SelectedRows.Count > 0)
                {
                    string maPhong = dgvPhong.CurrentRow.Cells["col_MaPhong"].Value.ToString();
                    var confirm = MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        phongTroService.DelPhongTro(maPhong);
                        dgvPhong.Rows.RemoveAt(dgvPhong.SelectedRows[0].Index);
                        MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    var listPhongTro = phongTroService.GetALLPhongTro();
                    LoadData(listPhongTro);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var listPhongTro = phongTroService.GetALLPhongTro();
                string dataType = comboBox1.SelectedItem.ToString();    
                string dataSearch = guna2TextBox1.Text;
                List<PhongTro> filteredList = new List<PhongTro>(); 
                if(dataType == "Mã phòng")
                {
                    filteredList = listPhongTro.Where(p => p.MaPhong.Contains(dataSearch)).ToList();
                }
                else if(dataType == "Giá phòng")
                {
                    if(float.TryParse(dataSearch, out float value))
                    {
                        filteredList = listPhongTro.Where(p => p.GiaPhong ==  value).ToList();  
                    }
                    else if (string.IsNullOrEmpty(dataSearch))
                    {
                        filteredList = listPhongTro;
                    }
                    else
                    {
                        MessageBox.Show("Giá phòng phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                }
                LoadData(filteredList);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var listHopDong = chiTietHopDongServices.GetAllChiTietHopDong();
                foreach(var hopDong in listHopDong)
                {
                    if(hopDong.TinhTrangKetThuc == "Đã kết thúc")
                    {
                        phongTroService.CapNhatTrangThaiPhong(hopDong.MaPhong, "Phòng trống");
                    }
                    else if(hopDong.TinhTrangKetThuc == "Chưa kết thúc")
                    {
                        phongTroService.CapNhatTrangThaiPhong(hopDong.MaPhong, "Phòng đã cho thuê");
                    }
                }
                var listPhongTro = phongTroService.GetALLPhongTro();    
                LoadData(listPhongTro);
                MessageBox.Show("Cập nhật tình trạng phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
