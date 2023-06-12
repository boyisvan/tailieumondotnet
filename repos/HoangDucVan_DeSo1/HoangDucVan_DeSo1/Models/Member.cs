using System;
using System.Collections.Generic;

namespace HoangDucVan_DeSo1.Models
{
    public partial class Member
    {
        public string MemberId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Age { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
