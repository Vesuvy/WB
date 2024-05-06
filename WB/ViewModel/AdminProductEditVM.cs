using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WB.DB;
using WB.Models.Database;
using WB.Utilities;

namespace WB.ViewModel
{
    internal class AdminProductEditVM : ViewModelBase
    {
        private readonly IDataBase _idataBase;
        private readonly ViewModelStore _viewModelStore;
        private readonly Products _products;
        private Employees _employees;

        public string Title
        {
            get => _products.Title;
            set
            {
                _products.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public int Quantity
        {
            get => _products.Quantity;
            set
            {
                _products.Quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public decimal Price
        {
            get => _products.Price;
            set
            {
                _products.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand GoToProductListCommand { get; private set; }

        public AdminProductEditVM(ViewModelStore viewModelStore, Employees employees, Products product)
        {
            _viewModelStore = viewModelStore;
            _products = product;
            LoadProductDetails();
            SaveCommand = new RelayCommand(SaveChanges);
            DeleteCommand = new RelayCommand(DeleteProduct);
            GoToProductListCommand = new RelayCommand(GoToProductList);
        }

        private void GoToProductList(object obj)
        {
            _viewModelStore.CurrentViewModel = new ProductListVM(_viewModelStore, _employees);
        }

        private void SaveChanges(object obj)
        {
            _idataBase.UpdateProduct(_products);
            // _viewModelStore.CurrentViewModel = new AdminProductListVM(_viewModelStore, _employees);
        }

        private void DeleteProduct(object obj)
        {
            _idataBase.DeleteProduct(_products);
            //_viewModelStore.CurrentViewModel = new AdminProductListVM(_viewModelStore, _employees);
        }

        private void LoadProductDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionKey"].ConnectionString))
            {
                sqlConnection.Open();

                string queryString =
                    "SELECT p.Id_Product, p.Title, p.Price, SUM(od.Quantity) as Quantity " +
                    "FROM Products p " +
                    "LEFT JOIN Orders_Details od ON p.Id_Product = od.FK_Product " +
                    "GROUP BY p.Id_Product, p.Title, p.Price";

                SqlCommand command = new SqlCommand(queryString, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Title = reader.GetString(1);
                        Price = reader.GetDecimal(2);
                        Quantity = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                    }
                }
            }
        }
        protected virtual void Dispose() { }
    }
}
