using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmNavigationLib.Services
{
    public delegate TViewModel CreateViewModel<out TViewModel>()
        where TViewModel : ObservableObject;

    public delegate TViewModel CreateViewModel<out TViewModel, in TParam>(TParam param)
        where TViewModel : ObservableObject;
}
