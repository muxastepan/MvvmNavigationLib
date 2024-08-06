using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmNavigationLib.Services
{
    public class CompositeNavigationService<TViewModel>:INavigationService
    where TViewModel : ObservableObject
    {
        private readonly INavigationService[] _navigationServices;

        public CompositeNavigationService(params INavigationService[] navigationServices)
        {
            _navigationServices = navigationServices;
        }

        public void Navigate()
        {
            foreach (var navigationService in _navigationServices)
            {
                navigationService.Navigate();
            }
        }
    }
}
