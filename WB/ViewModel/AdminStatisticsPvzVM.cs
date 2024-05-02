using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Models.Database;
using WB.Utilities;

namespace WB.ViewModel
{
    internal class AdminStatisticsPvzVM : ViewModelBase
    {
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

        public AdminStatisticsPvzVM(ViewModelStore viewModelStore, Employees employees)
        {

        }

        protected virtual void Dispose() { }
    }
}
