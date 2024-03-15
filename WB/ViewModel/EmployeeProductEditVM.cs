using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Models.Database;

namespace WB.ViewModel
{
    internal class EmployeeProductEditVM : INotifyPropertyChanged
    {
        public Products _products;

        public string Name
        {
            get { return _products.Title; }
            set
            {
                _products.Title = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Quantity
        {
            get { return _products.Quantity; }
            set
            {
                _products.Quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public decimal Price
        {
            get { return (decimal)_products.Price; }
            set
            {
                _products.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose() { }
    }
}
