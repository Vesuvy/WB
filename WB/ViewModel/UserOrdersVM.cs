using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Models.Database;

namespace WB.ViewModel
{
    internal class UserOrdersVM : INotifyPropertyChanged
    {
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


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose() { }
    }
}
