using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentHouseDAL.Entity;

namespace RentHouseBUS
{
    public class ChiTietHopDongServices
    {
        RentHouseContextDB db = new RentHouseContextDB();
        public List<ChiTietHopDong> GetAllChiTietHopDong()
        {
            return db.ChiTietHopDongs.ToList();
        }
        public void CapNhatTrangThaiHopDong(string maPhong, string tinhTrangHopDong)
        {
            var phongTro = db.PhongTroes.FirstOrDefault(p => p.MaPhong == maPhong);

            if (phongTro == null)
            {
                throw new Exception("Phòng không tồn tại");
            }

            if (tinhTrangHopDong == "Đã kết thúc")
            {
                phongTro.TrangThai = "Phòng trống";
            }
            else if (tinhTrangHopDong == "Chưa kết thúc")
            {
                phongTro.TrangThai = "Phòng đã cho thuê";
            }
            db.SaveChanges(); 
        }
    }
}
