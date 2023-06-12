using System;
using System.Collections.Generic;

namespace Vũ_Trụ_Điện_Thoại.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string MaKhachHang { get; set; } = null!;
        public string? MaNguoiDung { get; set; }
        public string? TenKhachHang { get; set; }
        public string? Tuoi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }

        public virtual TaiKhoan? MaNguoiDungNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
