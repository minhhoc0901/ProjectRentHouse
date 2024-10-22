namespace RentHouseDAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
        }

        [Key]
        public int IDHD { get; set; }

        public int? MaCTHD { get; set; }

        public DateTime? NgayLap { get; set; }

        public double? TienGiam { get; set; }

        public double? TienPhat { get; set; }

        public double? SoTienTra { get; set; }

        public double? TongTien { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public virtual ChiTietHopDong ChiTietHopDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }
    }
}
