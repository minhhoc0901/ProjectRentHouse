using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse_BUS
{
    public class PhongTroService
    {
        RentHouseContextDB contextDB = new RentHouseContextDB();
        public List<PhongTro> GetAllPhongTro()
        {
            return contextDB.PhongTroes.ToList();
        }
        public List<PhongTro> GetAllNoDaThue() 
        {
            return contextDB.PhongTroes.Where(pt =>!( pt.TrangThai == "Phòng đã cho thuê")).ToList();
        }
    }
}
