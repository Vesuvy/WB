  using Microsoft.Data.SqlClient;
using System;
using System.Windows.Input;
using WB.Models.Database;
using WB.Utilities;


namespace WB.ViewModel
{
    public enum UserRole // Роли пользователей
    {
        Admin,
        Employ
    }

    internal class ProductListVM : ViewModelBase
    {
        private readonly string _connectionString = 
            @"Data Source=localhost;Initial Catalog=Store;Integrated Security=True";
        private readonly SqlConnection _connection;

        private UserRole _userRole;
        public Products _products;
        public UserRole UserRole
        {
            get { return _userRole; }
            set
            {
                _userRole = value;
                OnPropertyChanged(nameof(UserRole));
            }
        }

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

        public ProductListVM(ViewModelStore viewModelStore)
        {

        }

        protected virtual void Dispose() { }
    }




    
}
