using System;
using System.Windows;
using WB.DB;
using WB.ViewModel;

namespace WB
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ViewModelStore _viewModelStore;
        private DataWork _dataWork;
        public App()
        {
            _viewModelStore = new ViewModelStore()
            { CurrentViewModel = new AuthorizationVM(_viewModelStore, _dataWork) };

            _dataWork = new DataWork();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(_viewModelStore, _dataWork)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
