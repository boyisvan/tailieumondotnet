using System;
using System.Collections.Generic;

#nullable disable

namespace eShopOnWeb.Model.Entities
{
    public partial class VisitorStaticti
    {
        public int Id { get; set; }
        public DateTime VisitedDate { get; set; }
        public string Ipaddress { get; set; }
    }
}
