using System;
using WB.ViewModel;

namespace WB.Utilities
{
    internal class NavigateCommand : CommandBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigateCommand(ViewModelStore viewModelStore, Func<ViewModelBase> createViewModel)
        {
            _viewModelStore = viewModelStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            

            _viewModelStore.CurrentViewModel = _createViewModel();
        }

        /* 
        viewModelStore - экземпляр ViewModelStore, 
            который используется для хранения текущей ViewModel и 
            предоставления методов для навигации между ViewModel.
         
        createViewModel - делегат Func<ViewModelBase>, 
            который используется для создания новой ViewModel при выполнении команды.
       
        Пример применения команды:

            GoToStatCommand = 
                new NavigateCommand(_viewModelStore, 
                () => { return new AdminProductEditVM(_viewModelStore); });
        */
    }
}
