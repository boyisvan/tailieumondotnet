using System;
using System.Collections.Generic;

namespace VieTorism.Models
{
    public partial class Nguoidung
    {
        public string Tendangnhap { get; set; } = null!;
        public string Hovaten { get; set; } = null!;
        public string? Tuoi { get; set; }
        public string? Gioitinh { get; set; }
        public string? Diachi { get; set; }

        public virtual Taikhoan TendangnhapNavigation { get; set; } = null!;
    }
}
