using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Utilities;

namespace MvvmNavigationLib.Stores;

public interface INavigationStore
{
    ObservableObject? CurrentViewModel { set; }
    StackQueue<ObservableObject> RecentViewModels { set; }

    void GoBack();
}