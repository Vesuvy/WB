using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WB.Models.Database
{
    internal class Orders_Details
    {
        public int Id { get; set; }
        public Products FK_Product { get; set; }
        public Orders FK_Order { get; set; }
        public int Quantity { get; set; }
    }
}
