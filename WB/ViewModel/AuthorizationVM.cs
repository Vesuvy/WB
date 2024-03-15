using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using WB.Models.Database;
using WB.Views;

namespace WB.ViewModel
{
    internal class AuthorizationVM : INotifyPropertyChanged
    {
        public Employees _employees;
        public string Login
        {
            get { return _employees.Login; }
            set
            {
                _employees.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get { return _employees.Password; }
            set
            {
                _employees.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public void Authorizationction(object parameter)
        {
            // Логика авторизации
            if (Login == "admin" && Password == "admin123")
            {
                MessageBox.Show("Вы вошли как администратор.");
                var mainWindow = new MainWindow();
                var productList = new ProductListUC();
                mainWindow.Content = productList;
                mainWindow.Show();
            }
            else if (Login == "user" && Password == "user123")
            {
                MessageBox.Show("Вы вошли как пользователь.");
                var mainWindow = new MainWindow();
                var productList = new ProductListUC();
                mainWindow.Content = productList;
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверные логин или пароль.");
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
