namespace RentHouseDAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDong")]
    public partial class HopDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HopDong()
        {
            ChiTietHopDongs = new HashSet<ChiTietHopDong>();
        }

        [Key]
        [StringLength(50)]
        public string SoHopDong { get; set; }

        public int? MaKH { get; set; }

        public DateTime? NgayLapHD { get; set; }

        public double? TienCoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; }

        public virtual KhachThue KhachThue { get; set; }
    }
}
