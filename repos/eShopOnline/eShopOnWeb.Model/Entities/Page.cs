using System;
using System.Collections.Generic;

#nullable disable

namespace eShopOnWeb.Model.Entities
{
    public partial class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public bool? Status { get; set; }
    }
}
