using System;
using System.Windows.Input;
using WB.Models.Database;
using WB.Utilities;
using System.Configuration;
using System.Collections.ObjectModel;
using WB.DB;
using System.Data.SqlClient;

namespace WB.ViewModel
{
    public enum UserRole // Роли пользователей
    {
        Admin,
        Employ
    }

    internal class ProductListVM : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        DataBase dataBase = new DataBase();

        #region ModelDef

        private Employees _employees;
        private ObservableCollection<Products> _products;
        public ObservableCollection<Products> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public Employees Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        /*public string Name
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
        }*/

        #endregion

        #region Commands

        public ICommand SortCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand BackToListCommand { get; }

        #endregion


        public ProductListVM(ViewModelStore viewModelStore, Employees employees)
        {
            _viewModelStore = viewModelStore;
            _employees = employees;

            LoadProducts();
        }

        private void LoadProducts()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionKey"].ConnectionString))
            {
                sqlConnection.Open();

                string queryString = "select Id_Product, Title, Price, Rating, Image from Products";
                SqlCommand command = new SqlCommand(queryString, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products products = new Products
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Price = reader.GetDecimal(2),

                        };
                        //int id = reader.GetInt32(0);
                        //string title = reader.GetString(1);
                        //decimal price = reader.GetInt32(2);
                        //byte[] image = (byte[])reader[3];
                    }
                }
            }
        }

        protected virtual void Dispose() { }
    }
}