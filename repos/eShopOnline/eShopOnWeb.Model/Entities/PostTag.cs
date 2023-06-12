using System;
using System.Collections.Generic;

#nullable disable

namespace eShopOnWeb.Model.Entities
{
    public partial class PostTag
    {
        public int? PostId { get; set; }
        public string TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
