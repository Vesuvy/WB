using System;
using WB.Utilities;
using WB.ViewModel;

namespace WB
{
    internal class MainWindowVM : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        public ViewModelBase CurrentViewModel => _viewModelStore.CurrentViewModel;

        public MainWindowVM(ViewModelStore viewModelStore)
        {
            _viewModelStore = viewModelStore;
            _viewModelStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
