using System;
using System.Windows;
using WB.Models.Database;
using WB.Views;
using WB.Utilities;
using WB.ViewModel;
using System.Windows.Input;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace WB.ViewModel
{
    internal class AuthorizationVM : ViewModelBase
    {
        #region ModelDefinitions
        readonly ViewModelStore _navigationVM;
        readonly Employees _employees = new Employees();
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
        #endregion

        #region Commands
        public ICommand EnterCommand { get; }
        #endregion


        public AuthorizationVM(ViewModelStore viewModelStore)
        {
            _navigationVM = viewModelStore;
            EnterCommand = new RelayCommand(AuthFunction);
        }

        public void AuthFunction() // возможно придется изменить переходы на страницы
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Заполните данные!");
                return;
            }

            if (CheckLoginAndPassword(Login, Password))
            {
                _navigationVM.CurrentViewModel = new ProductListVM(_navigationVM);
            }
            else
                MessageBox.Show("Неверные логин или пароль.");
        }
        public bool CheckLoginAndPassword(string login, string password)
        {
            // пока для примера
            var users = new Dictionary<string, string>
            {
                { "user", "userpas" },
                { "admin", "adminpas" }
            };

            if (users.ContainsKey(login))
            {
                if (users[login] == password && login == "admin")
                {
                    MessageBox.Show("Вы вошли как администратор.");
                    return true;
                }
                else if (users[login] == password)
                {
                    MessageBox.Show("Вы вошли как пользователь.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Неверные логин или пароль.");
                    return false;
                }
            }

            return false;
        }


        protected virtual void Dispose() { }
    }

}
