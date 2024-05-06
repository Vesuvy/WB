using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using WB.Models.Database;
using WB.Utilities;

namespace WB.ViewModel
{
    internal class EmployeeStatisticsPvzVM : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        public PickupPoints _pickupPoints;
        private Employees _employees;


        public ICommand GoToProductListCommand { get; private set; }

        public EmployeeStatisticsPvzVM(ViewModelStore viewModelStore, Employees employees)
        {
            _viewModelStore = viewModelStore;

            GoToProductListCommand = new RelayCommand(GoToProductList);
        }

        private void GoToProductList(object obj)
        {
            _viewModelStore.CurrentViewModel = new ProductListVM(_viewModelStore, _employees);
        }

        protected virtual void Dispose() { }
    }
}
