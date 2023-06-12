using System;
using System.Collections.Generic;

namespace Vũ_Trụ_Điện_Thoại.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string MaDanhMuc { get; set; } = null!;
        public string? TenDanhMuc { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
