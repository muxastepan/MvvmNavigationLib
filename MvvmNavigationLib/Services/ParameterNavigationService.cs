using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services
{
    public class ParameterNavigationService<TViewModel,TParam>:IParameterNavigationService<TParam>
        where TViewModel : ObservableObject
    {
        private readonly INavigationStore _navigationStore;
        private readonly CreateViewModel<TViewModel,TParam> _createViewModel;

        public ParameterNavigationService(
            INavigationStore navigationStore,
            CreateViewModel<TViewModel,TParam> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParam param)
        {
            _navigationStore.CurrentViewModel = _createViewModel(param);
        }
    }
}
