using System;
using System.Collections.Generic;

namespace Vũ_Trụ_Điện_Thoại.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string MaNhanVien { get; set; } = null!;
        public string? MaNguoiDung { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? MaChucVu { get; set; }

        public virtual ChucVu? MaChucVuNavigation { get; set; }
        public virtual TaiKhoan? MaNguoiDungNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
