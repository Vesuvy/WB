using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Models.Database;

namespace WB.ViewModel
{
    internal class AdminStatisticsPvzVM : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose() { }
    }
}
