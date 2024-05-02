using System;
using System.Windows.Input;
using WB.Models.Database;
using WB.Utilities;
using System.Configuration;
using System.Collections.ObjectModel;
using WB.DB;
using System.Data.SqlClient;
using WB.Views;

namespace WB.ViewModel
{
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
        /*public string Title
        {
            get { return _products.Title; }
            set
            {
                _products.Title = value;
                OnPropertyChanged(nameof(Title));
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

        public ICommand SortCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand GoToStatisticsCommand { get; private set; }
        public ICommand GoToCustomerOrdersCommand { get; private set; }
        public ICommand GoToEditProductsCommand { get; private set; }

        #endregion

        public ProductListVM(ViewModelStore viewModelStore, Employees employees)
        {
            _viewModelStore = viewModelStore;
            _employees = employees;

            _products = new ObservableCollection<Products>();

            LoadProducts();

            //Commands
            GoToStatisticsCommand = new RelayCommand(GoToStatistics);
            GoToCustomerOrdersCommand = new RelayCommand(GoToCustomerOrders);
            GoToEditProductsCommand = new RelayCommand(GoToEditProducts);
        }

        private void LoadProducts()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionKey"].ConnectionString))
            {
                sqlConnection.Open();

                string queryString = "select * from Products";
                SqlCommand command = new SqlCommand(queryString, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products products = new Products
                        {
                            //Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            //Image = (byte[])reader[4]
                        };

                        Products.Add(products); // + товар в коллекцию


                    }
                }
            }
        }

        private void GoToStatistics(object parameter)
        {
            if (IsAdmin())
            {
                _viewModelStore.CurrentViewModel = new AdminStatisticsPvzVM(_viewModelStore, _employees);
            }
            else
            {
                _viewModelStore.CurrentViewModel = new EmployeeStatisticsPvzVM(_viewModelStore, _employees);
            }
        }
        private void GoToEditProducts(object obj)
        {
            throw new NotImplementedException();
        }

        private void GoToCustomerOrders(object obj)
        {
            throw new NotImplementedException();
        }
        private bool IsAdmin()
        {
            if (_employees.isAdmin)
                return true;
            else 
                return false;
        }

        protected virtual void Dispose() { }
    }
}