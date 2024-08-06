using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services
{
    public class NavigationService<TViewModel>:INavigationService
    where TViewModel : ObservableObject
    {
        private readonly INavigationStore _navigationStore;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public NavigationService(INavigationStore navigationStore,
            CreateViewModel<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
