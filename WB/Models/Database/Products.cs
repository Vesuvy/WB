using System;
using System.Collections;
using System.Collections.Generic;

namespace WB.Models.Database
{
    internal class Products
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; }
        public bool SortAsc { get; set; } = true;
        public IList<Sellers> SellersList { get; set; } = new List<Sellers>();
        public IList<Products> ProductList { get; set; } = new List<Products>();
        
    }
}
