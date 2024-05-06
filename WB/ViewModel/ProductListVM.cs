using System;
using System.Windows.Input;
using WB.Models.Database;
using WB.Utilities;
using System.Configuration;
using System.Collections.ObjectModel;
using WB.DB;
using System.Data.SqlClient;
using WB.Views;
using System.Windows;
using System.Linq;

namespace WB.ViewModel
{
    internal class ProductListVM : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        DataBase dataBase = new DataBase();

        #region ModelDef

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
        private Employees _employees;
        public Employees Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        // свойство фильтра (цена > или < какого-то значения)
        private decimal _filterPrice;
        public decimal FilterPrice
        {
            get { return _filterPrice; }
            set
            {
                _filterPrice = value;
                OnPropertyChanged(nameof(FilterPrice));
                ApplyFilter();
            }
        }
        // свойство сортировки
        private bool _isMinToMaxSortApplied;
        public bool IsMinToMaxSortApplied
        {
            get { return _isMinToMaxSortApplied; }
            set
            {
                _isMinToMaxSortApplied = value;
                OnPropertyChanged(nameof(IsMinToMaxSortApplied));
                ApplySort();
            }
        }
        // строка поиска
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                ApplySearch();
            }
        }
        private ObservableCollection<Products> _searchResults;
        public ObservableCollection<Products> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
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

        public ICommand MinToMaxPriceSortCommand { get; private set; }
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
            MinToMaxPriceSortCommand = new RelayCommand(ApplyMinToMaxSort);
            FilterCommand = new RelayCommand(ApplyFilter);
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
                    Products = new ObservableCollection<Products>();
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
                    ApplySearch();
                }
            }
        }

        #region Методы навигации
        private void GoToStatistics(object obj)
        {
            if (IsAdmin())
            {
                MessageBox.Show($"Ваша роль - {_employees.IsAdmin}");
                _viewModelStore.CurrentViewModel = new AdminStatisticsPvzVM(_viewModelStore, _employees);
            }
            else
            {
                MessageBox.Show($"Ваша роль - {_employees.IsAdmin}");
                _viewModelStore.CurrentViewModel = new EmployeeStatisticsPvzVM(_viewModelStore, _employees);
            }
        }
        private void GoToEditProducts(object obj)
        {
            if (IsAdmin())
            {
                var product = Products.FirstOrDefault();
                if (product != null)
                {
                    _viewModelStore.CurrentViewModel = new AdminProductEditVM(_viewModelStore, _employees, product);
                }
            }
            else
            {
                _viewModelStore.CurrentViewModel = new EmployeeProductEditVM(_viewModelStore, _employees);
            }
        }
        private void GoToCustomerOrders(object obj)
        {
            _viewModelStore.CurrentViewModel = new UserOrdersVM(_viewModelStore, _employees);
        }
        private bool IsAdmin()
        {
            if (_employees.IsAdmin)
                return true;
            else
                return false;
        }
        #endregion


        #region Методы для сортировки, фильтрации, поиска
        //фильтрация
        private void ApplyFilter(object obj)
        {
            if (FilterPrice == 0)
            {
                LoadProducts(); // Сброс фильтра и загрузка исходного списка продуктов
                return;
            }

            var filteredProducts = new ObservableCollection<Products>(Products.Where(p => p.Price < FilterPrice || p.Price > FilterPrice));
            Products = filteredProducts;
        }
        private void ApplyFilter()
        {
            if (FilterPrice == 0)
            {
                LoadProducts(); // Сброс фильтра и загрузка исходного списка продуктов
                return;
            }

            var filteredProducts = new ObservableCollection<Products>(Products.Where(p => p.Price < FilterPrice || p.Price > FilterPrice));
            Products = filteredProducts;
        }

        //сортировка
        private void ApplySort()
        {
            if (IsMinToMaxSortApplied)
            {
                var sortedProducts = new ObservableCollection<Products>(Products.OrderBy(p => p.Price));
                Products = sortedProducts;
            }
            else
            {
                LoadProducts(); // Сброс сортировки и загрузка исходного списка продуктов
            }
        }
        private void ApplyMinToMaxSort(object obj)
        {
            if (IsMinToMaxSortApplied)
            {
                Products = new ObservableCollection<Products>(Products.OrderBy(p => p.Price));
            }
            else
            {
                LoadProducts(); // Сброс сортировки и загрузка исходного списка продуктов
            }

            IsMinToMaxSortApplied = !IsMinToMaxSortApplied;
        }
        private void ApplySearch()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                SearchResults = Products;
                return;
            }

            var results = Products.Where(p => p.Title.Contains(SearchText)).ToList();
            SearchResults = new ObservableCollection<Products>(results);
        }

        #endregion

        protected virtual void Dispose() { }
    }
}