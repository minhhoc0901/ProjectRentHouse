using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentHouse.DashBoardBody.ManagerAllListForm.KHACHHANG;
using RentHouseBUS;
using RentHouseDAL.Entity;

namespace RentHouse.DashBoardBody
{
    public partial class Form2 : Form
    {
        private readonly KhachHangServices khachHangServices = new KhachHangServices(); 
        public Form2()
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
            comboBox1.Items.Add("Họ tên");
            comboBox1.Items.Add("Số điện thoại");
        }

        private void ComboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Lọc")
            {
                comboBox1.Text = string.Empty;
                comboBox1.ForeColor = Color.Black;
            }
        }

        public void LoadData(List<KhachThue> listKhach)
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer(this);
            updateCustomer.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                List<KhachThue> listKhach = khachHangServices.GetAllKhachHang();
                LoadData(listKhach);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load form, lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddDataToGrid(KhachThue newKhach)
        {
            if(dgvKhach != null && dgvKhach.Columns.Contains("col_MaKhachHang"))
            {
                dgvKhach.Rows.Add(newKhach.MaKH, newKhach.HoTen, newKhach.CCCD, newKhach.SDT, newKhach.DiaChi, newKhach.GhiChu);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvKhach.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvKhach.CurrentRow;
                    if(selectedRow != null && selectedRow.Cells["col_MaKhachHang"].Value != null)
                    {
                        int maKhach = int.Parse(selectedRow.Cells["col_MaKhachHang"].Value.ToString());
                        var confirm = MessageBox.Show("Bạn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirm == DialogResult.Yes)
                        {
                            khachHangServices.Del(maKhach);
                            dgvKhach.Rows.RemoveAt(dgvKhach.SelectedRows[0].Index);
                            var listKhach = khachHangServices.GetAllKhachHang();
                            LoadData(listKhach);
                            MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu, lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var listKhach = khachHangServices.GetAllKhachHang();
                string dataType = comboBox1.SelectedItem.ToString();
                string dataSearch = guna2TextBox1.Text;
                List<KhachThue> filteredList = new List<KhachThue>();
                if (dataType == "Họ tên")
                {
                    filteredList = listKhach.Where(kh => kh.HoTen.Contains(dataSearch)).ToList();
                }
                if (dataType == "Số điện thoại")
                {
                    filteredList = listKhach.Where(kh => kh.SDT.Contains(dataSearch)).ToList();
                    
                    if (string.IsNullOrEmpty(dataSearch))
                    {
                        filteredList = listKhach;
                    }
                    /*else
                    {
                        MessageBox.Show("Số điện thoại phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                }
                LoadData(filteredList);   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm dữ liệu, lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
