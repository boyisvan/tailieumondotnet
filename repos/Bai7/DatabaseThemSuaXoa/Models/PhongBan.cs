using System;
using System.Collections.Generic;

namespace DatabaseThemSuaXoa.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaPhong { get; set; } = null!;
        public string? TenPhong { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
