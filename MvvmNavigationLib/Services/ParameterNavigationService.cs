using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services
{
    public class ParameterNavigationService<TViewModel, TParam>(INavigationStore navigationStore,
            CreateViewModel<TViewModel, TParam> createViewModel)
        : IParameterNavigationService<TParam>
        where TViewModel : ObservableObject
    {
        public void Navigate(TParam param)=> navigationStore.CurrentViewModel = createViewModel(param);
    }
}
