using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WB.Models.Database;
using WB.Utilities;

namespace WB.ViewModel
{
    internal class EmployeeProductEditVM : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private Employees _employees;
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

        public ICommand GoToProductListCommand { get; private set; }
        public EmployeeProductEditVM(ViewModelStore viewModelStore, Employees employees)
        {
            _viewModelStore = viewModelStore;
            _employees = employees;

            GoToProductListCommand = new RelayCommand(GoToProductList);
        }

        private void GoToProductList(object obj)
        {
            _viewModelStore.CurrentViewModel = new ProductListVM(_viewModelStore, _employees);
        }
        protected virtual void Dispose() { }
    }
}
