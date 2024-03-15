using System;

namespace WB.Models.Database
{
    internal class Products
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int Quantity { get; set; }
    }
}
