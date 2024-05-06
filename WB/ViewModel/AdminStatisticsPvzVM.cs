using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WB.Models.Database;
using WB.Utilities;

namespace WB.ViewModel
{
    internal class AdminStatisticsPvzVM : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private Employees _employees;
        public PickupPoints _pickupPoints;

        public string Address
        {
            get { return _pickupPoints.Address; }
            set
            {
                _pickupPoints.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public decimal Rating
        {
            get { return _pickupPoints.Rating; }
            set
            {
                _pickupPoints.Rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }

        public ICommand GoToProductListCommand { get; private set; }
        public AdminStatisticsPvzVM(ViewModelStore viewModelStore, Employees employees)
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
