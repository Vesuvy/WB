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
            DataContext = new NavigationVM(); // Устанавливаем DataContext в NavigationVM
        }
    }
}
