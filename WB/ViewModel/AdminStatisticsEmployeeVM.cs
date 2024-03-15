using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Models.Database;

namespace WB.ViewModel
{
    internal class AdminStatisticsEmployeeVM : INotifyPropertyChanged
    {
        public Employees _employees;

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


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose() { }
    }
}
