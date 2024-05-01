using System;
using System.Windows;
using WB.ViewModel;
using System.Data.SqlClient;
using WB.DB;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace WB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection _sqlConnection = null;
        public MainWindow()
        {
            InitializeComponent();

            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionKey"].ConnectionString);
            _sqlConnection.Open();

            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Подключение успешно установлено!");
            }

            ViewModelStore viewModelStore = new ViewModelStore();
            MainWindowVM mainWindowVM = new MainWindowVM(viewModelStore);
            DataContext = mainWindowVM;
            viewModelStore.CurrentViewModel = new AuthorizationVM(viewModelStore);
        }
    }
}
