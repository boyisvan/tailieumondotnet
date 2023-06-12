using System;
using System.Collections.Generic;

namespace VieTorism.Models
{
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string Madanhmuc { get; set; } = null!;
        public string? Tendanhmuc { get; set; }
        public string? Trangthai { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
