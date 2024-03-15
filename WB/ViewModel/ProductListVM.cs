using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WB.Models.Database;
using WB.Views;

namespace WB.ViewModel
{
    internal class ProductListVM : INotifyPropertyChanged
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
        public decimal Price
        {
            get { return (decimal)_products.Price; }
            set
            {
                _products.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public ICommand SortCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand BackToListCommand { get; }

        public ProductListVM()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose() { }
    }




    
}
