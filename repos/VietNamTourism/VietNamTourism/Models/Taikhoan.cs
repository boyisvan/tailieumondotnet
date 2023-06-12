using System;
using System.Collections.Generic;

namespace VietNamTourism.Models
{
    public partial class Taikhoan
    {
        public string Tendangnhap { get; set; } = null!;
        public string? Matkhau { get; set; }
        public string? Manguoidung { get; set; }
        public string? Maquyen { get; set; }
    }
}
