using System;
using System.Collections.Generic;

namespace Vũ_Trụ_Điện_Thoại.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string MaSanPham { get; set; } = null!;
        public string? TenSanPham { get; set; }
        public string? MaDanhMuc { get; set; }
        public string? SoLuong { get; set; }
        public string? Gia { get; set; }
        public string? MoTa { get; set; }
        public string? HinhAnh { get; set; }

        public virtual DanhMuc? MaDanhMucNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
