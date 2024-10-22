using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse_BUS
{
    public class KhachThueService
    {
        RentHouseContextDB contextDB = new RentHouseContextDB();
        public List<KhachThue> GetAllKhachThue()
        {
            return contextDB.KhachThues.ToList();
        }
    }
}
