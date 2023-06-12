using System;
using System.Collections.Generic;

namespace Vũ_Trụ_Điện_Thoại.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            KhachHangs = new HashSet<KhachHang>();
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaNguoiDung { get; set; } = null!;
        public string? TenTaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? LoaiTaiKhoan { get; set; }

        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
