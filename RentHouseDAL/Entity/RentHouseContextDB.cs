using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RentHouseDAL.Entity
{
    public partial class RentHouseContextDB : DbContext
    {
        public RentHouseContextDB()
            : base("name=RentHouseContextDB")
        {
        }

        public virtual DbSet<ChiTietHopDong> ChiTietHopDongs { get; set; }
        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachThue> KhachThues { get; set; }
        public virtual DbSet<PhongTro> PhongTroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.CTHoaDons)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);
        }
    }
}
