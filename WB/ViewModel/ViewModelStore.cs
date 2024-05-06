using System;
using WB.Views;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using WB.Utilities;
using WB.ViewModel;

namespace WB.ViewModel
{
    internal class ViewModelStore
    {
        ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }


        #region хз
        /*public ICommand AdminProductEditCommand { get; set; }
        public ICommand AdminStatisticsEmployeeCommand { get; set; }
        public ICommand AdminStatisticsPvzCommand { get; set; }
        public ICommand AuthorizationCommand { get; set; }
        public ICommand EmployeeProductEditCommand { get; set; }
        public ICommand EmployeeStatisticsPvzCommand { get; set; }
        public ICommand ProductListCommand { get; set; }
        public ICommand UserOrdersCommand { get; set; }

        private void AdminProductEdit(object obj) => CurrentView = new AdminProductEditUC();
        private void AdminStatisticsEmployee(object obj) => CurrentView = new AdminStatisticsEmployeeVM();
        private void AdminStatisticsPvz(object obj) => CurrentView = new AdminStatisticsPvzVM();
        private void Authorization(object obj) => CurrentView = new AuthorizationVM();
        private void EmployeeProductEdit(object obj) => CurrentView = new EmployeeProductEditVM();
        private void EmployeeStatisticsPvz(object obj) => CurrentView = new EmployeeStatisticsPvzVM();
        private void ProductList(object obj) => CurrentView = new ProductListVM();
        private void UserOrders(object obj) => CurrentView = new UserOrdersVM();

        public ViewModelStore()
        {
            AdminProductEditCommand = new RelayCommand(AdminProductEdit);
            AdminStatisticsEmployeeCommand = new RelayCommand(AdminStatisticsEmployee);
            AdminStatisticsPvzCommand = new RelayCommand(AdminStatisticsPvz);
            AuthorizationCommand = new RelayCommand(Authorization);
            EmployeeProductEditCommand = new RelayCommand(EmployeeProductEdit);
            EmployeeStatisticsPvzCommand = new RelayCommand(EmployeeStatisticsPvz);
            ProductListCommand = new RelayCommand(ProductList);
            UserOrdersCommand = new RelayCommand(UserOrders);

            //start usercontrol
            CurrentView = new AuthorizationUC();
        }*/
        #endregion

    }
}
