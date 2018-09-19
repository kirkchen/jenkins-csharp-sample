using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JenkinsCSharpSample.Models
{
    public class ShoppingCart
    {
        public decimal Price { get; set; }

        public decimal Qty { get; set; }

        public decimal? TotalPrice { get; set; }

        public MemberType MemberType { get; set; }
    }
}