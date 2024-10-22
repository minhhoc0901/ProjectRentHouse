namespace RentHouseDAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongTro")]
    public partial class PhongTro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongTro()
        {
            ChiTietHopDongs = new HashSet<ChiTietHopDong>();
        }

        [Key]
        [StringLength(50)]
        public string MaPhong { get; set; }

        [StringLength(255)]
        public string ThongTin { get; set; }

        public double? GiaPhong { get; set; }

        public double? DienTich { get; set; }

        [StringLength(255)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; }
    }
}
