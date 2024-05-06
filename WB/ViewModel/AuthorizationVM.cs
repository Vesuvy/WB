using System;
using System.Windows;
using WB.Models.Database;
using WB.Views;
using WB.Utilities;
using WB.ViewModel;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using WB.DB;

namespace WB.ViewModel
{
    internal class AuthorizationVM : ViewModelBase
    {
        DataBase dataBase = new DataBase();
        readonly ViewModelStore _viewModelStore;
        //private ViewModelStore _viewModelStore;

        #region ModelDefinitions

        private Employees _employees = new Employees();
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
        public bool IsAdmin
        {
            get { return _employees.IsAdmin; }
            set
            {
                _employees.IsAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        #endregion

        #region Commands

        public RelayCommand EnterCommand { get; }
        public NavigateCommand GoToProductListCommand;

        #endregion

        public AuthorizationVM(ViewModelStore viewModelStore)
        {
            _viewModelStore = viewModelStore;
            EnterCommand = new RelayCommand(AuthFunction);
        }

        //public string Status => IsAdmin ? "Admin" : "Employ";
        public void AuthFunction(object parameter)
        {
            if (CheckLogin(Login, Password, out bool isAdmin) && ValidateLoginForm(Login, Password))
            {
                IsAdmin = isAdmin;

                // GoToProductListCommand = new NavigateCommand(_viewModelStore,() => { return new ProductListVM(_viewModelStore, _employees); });

                _viewModelStore.CurrentViewModel = new ProductListVM(_viewModelStore, _employees);
            }
            else
                MessageBox.Show("Неверные логин или пароль.");
        }
        public bool ValidateLoginForm(string login, string password)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Заполните данные!");
                return false;
            }
            else if (Login.Length <= 3 || Password.Length <= 3)
            {
                MessageBox.Show("Логин и Пароль должны быть не менее 4 символов!");
                return false;
            }
            return true;
        }
        public bool CheckLogin(string login, string password, out bool isAdmin)
        {
            var loginUser = login;
            var passwordUser = password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString =
                "select Id_Employee, Name, Login, Password, Salary, FK_PickupPoint, isAdmin from Employees where Login = @login and Password = @password";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            command.Parameters.AddWithValue("@login", loginUser);
            command.Parameters.AddWithValue("@password", passwordUser);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                // var user = new (table.Rows[0].ItemArray[2].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[6]));

                isAdmin = Convert.ToBoolean(table.Rows[0].ItemArray[6]);
                var userLoginForShow = table.Rows[0].ItemArray[2].ToString();
                MessageBox.Show($"Вы успешно вошли!\nВаш логин: {userLoginForShow}", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            isAdmin = false;
            return false;
        }


        protected virtual void Dispose() { }

    }

}
