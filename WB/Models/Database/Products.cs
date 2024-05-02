using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

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

        /*public BitmapImage ImageSource
        {
            get
            {
                using (MemoryStream stream = new MemoryStream(Image))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    return bitmap;
                }
            }
        }*/
    }
}
