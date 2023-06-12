using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VieTorism.Models
{
    public partial class Sanpham
    {
        public int Id { get; set; }
        public string Tensanpham { get; set; } = null!;
        public string Anh { get; set; } = null!;
        public string Mota { get; set; } = null!;
        public string Danhgia { get; set; } = null!;
        public string Madanhmuc { get; set; } = null!;

        public virtual Danhmuc MadanhmucNavigation { get; set; } = null!;
        [NotMapped]
        public IFormFile Anhtailen { get; set; } = null!;
    }
}
