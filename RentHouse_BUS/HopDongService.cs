using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse_BUS
{
    public class HopDongService
    {
        RentHouseContextDB contextDB = new RentHouseContextDB();
        public List<HopDong> GetAllHopDong()
        {
           
            return contextDB.HopDongs.ToList();
        }
        public HopDong GetHopDongById(string id)
        {
            return contextDB.HopDongs.Find(id);
        }
        public void AddHopDong(HopDong hopDong)
        {
            contextDB.HopDongs.Add(hopDong);
            contextDB.SaveChanges();
        }
        public void UpdateHopDong(HopDong hopDong)
        {
            var hopDongUpdate = contextDB.HopDongs.Find(hopDong.SoHopDong);
            if (hopDongUpdate != null)
            {
                hopDongUpdate.NgayLapHD = hopDong.NgayLapHD;
                hopDongUpdate.TienCoc = hopDong.TienCoc;
                hopDongUpdate.MaKH = hopDong.MaKH;
                
                contextDB.SaveChanges();
            }
        }
        public void DeleteHopDong(string id) 
        { 
            var hopDong = contextDB.HopDongs.Find(id);
            contextDB.HopDongs.Remove(hopDong);
            contextDB.SaveChanges();
        }
    }
}
