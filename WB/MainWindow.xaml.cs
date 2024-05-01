using System;
using System.Windows;
using WB.ViewModel;

namespace WB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            

            ViewModelStore viewModelStore = new ViewModelStore();
            MainWindowVM mainWindowVM = new MainWindowVM(viewModelStore);
            DataContext = mainWindowVM;
            viewModelStore.CurrentViewModel = new AuthorizationVM(viewModelStore);
        }
    }
}
