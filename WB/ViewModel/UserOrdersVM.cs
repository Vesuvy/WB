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
    internal class UserOrdersVM : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private Employees _employees;

        public Clients _client;

        public string Name
        {
            get { return _client.Name; }
            set
            {
                _client.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Login
        {
            get { return _client.Login; }
            set
            {
                _client.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }


        public ICommand GoToProductListCommand { get; private set; }

        public UserOrdersVM(ViewModelStore viewModelStore, Employees employees)
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
