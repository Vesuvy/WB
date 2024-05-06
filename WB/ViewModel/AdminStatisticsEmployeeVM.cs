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
    internal class AdminStatisticsEmployeeVM : ViewModelBase
    {
        private ViewModelStore _viewModelStore;
        private Employees _employees;

        public string Name
        {
            get { return _employees.Name; }
            set
            {
                _employees.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Login
        {
            get { return _employees.Login; }
            set
            {
                _employees.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public decimal Salary
        {
            get { return (decimal)_employees.Salary; }
            set
            {
                _employees.Salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }

        public ICommand GoToProductListCommand { get; private set; }

        public AdminStatisticsEmployeeVM(ViewModelStore viewModelStore, Employees employees)
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
