using System;
using System.Collections.Generic;

namespace VieTorism.Models
{
    public partial class Role
    {
        public Role()
        {
            Taikhoans = new HashSet<Taikhoan>();
        }

        public string Role1 { get; set; } = null!;
        public string? Tenrole { get; set; }

        public virtual ICollection<Taikhoan> Taikhoans { get; set; }
    }
}
