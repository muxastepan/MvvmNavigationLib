using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmNavigationLib.Services
{
    public class CompositeNavigationService<TViewModel>
        (params INavigationService[] navigationServices) : INavigationService
        where TViewModel : ObservableObject
    {
        public void Navigate()
        {
            foreach (var navigationService in navigationServices)
            {
                navigationService.Navigate();
            }
        }
    }
}
