using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services
{
    public class NavigationService<TViewModel>(INavigationStore navigationStore,
            CreateViewModel<TViewModel> createViewModel)
        : INavigationService
        where TViewModel : ObservableObject
    {
        public void Navigate()=>navigationStore.CurrentViewModel = createViewModel();
    }
}
