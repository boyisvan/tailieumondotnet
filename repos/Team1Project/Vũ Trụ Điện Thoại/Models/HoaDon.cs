using System;
using System.Collections.Generic;

namespace Vũ_Trụ_Điện_Thoại.Models
{
    public partial class HoaDon
    {
        public string MaHoaDon { get; set; } = null!;
        public string? MaSanPham { get; set; }
        public string? MaKhachHang { get; set; }
        public string? MaNhanVien { get; set; }
        public int? SoLuong { get; set; }
        public string? TongTienThanhToan { get; set; }
        public DateTime? Ngay { get; set; }

        public virtual KhachHang? MaKhachHangNavigation { get; set; }
        public virtual NhanVien? MaNhanVienNavigation { get; set; }
        public virtual SanPham? MaSanPhamNavigation { get; set; }
    }
}
