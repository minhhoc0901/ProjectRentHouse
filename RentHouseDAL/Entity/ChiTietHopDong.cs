namespace RentHouseDAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHopDong")]
    public partial class ChiTietHopDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietHopDong()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaCTHD { get; set; }

        [StringLength(50)]
        public string SoHopDong { get; set; }

        [StringLength(50)]
        public string MaPhong { get; set; }

        public double? GiaThue { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        [StringLength(50)]
        public string TinhTrangKetThuc { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public virtual PhongTro PhongTro { get; set; }

        public virtual HopDong HopDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
