using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WB.Models.Database
{
    internal class Sellers_Products
    {
        public int Id { get; set; }
        public Products FK_Product { get; set; }
        public Sellers FK_Seller { get; set; }
    }
}
