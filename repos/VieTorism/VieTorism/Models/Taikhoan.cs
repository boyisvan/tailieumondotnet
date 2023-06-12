using System;
using System.Collections.Generic;

namespace VieTorism.Models
{
    public partial class Taikhoan
    {
        public string Tendangnhap { get; set; } = null!;
        public string? Matkhau { get; set; }
        public string? Role { get; set; }
        public string? Trangthai { get; set; }

        public virtual Role? RoleNavigation { get; set; }
        public virtual Nguoidung? Nguoidung { get; set; }
    }
}
