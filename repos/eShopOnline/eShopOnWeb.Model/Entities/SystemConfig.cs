using System;
using System.Collections.Generic;

#nullable disable

namespace eShopOnWeb.Model.Entities
{
    public partial class SystemConfig
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ValueString { get; set; }
        public string ValueInt { get; set; }
    }
}
