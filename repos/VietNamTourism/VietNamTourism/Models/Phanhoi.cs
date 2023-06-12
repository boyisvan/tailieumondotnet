using System;
using System.Collections.Generic;

namespace VietNamTourism.Models
{
    public partial class Phanhoi
    {
        public int Maphanhoi { get; set; }
        public string Manguoidung { get; set; } = null!;
        public string Noidung { get; set; } = null!;
        public string Trangthaiphanhoi { get; set; } = null!;
    }
}
