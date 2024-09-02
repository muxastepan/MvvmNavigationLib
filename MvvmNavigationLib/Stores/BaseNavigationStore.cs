using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MvvmNavigationLib.Utilities;

namespace MvvmNavigationLib.Stores;

public class BaseNavigationStore<TViewModelChangedMessage>:INavigationStore
    where TViewModelChangedMessage: class,new()
{
    private readonly IMessenger _messenger;

    private ObservableObject? _currentViewModel;

    public ObservableObject? CurrentViewModel
    {
        get=>_currentViewModel;
        set
        {
            AddViewModelToHistory(_currentViewModel);
            _currentViewModel = value;
            _messenger.Send<TViewModelChangedMessage>();
        }
    }

    private StackQueue<ObservableObject>? _recentViewModels;
    private bool _isGoingBack;

    public StackQueue<ObservableObject> RecentViewModels
    {
        get=>_recentViewModels??=new StackQueue<ObservableObject>(); 
        set=>_recentViewModels=value;
    }

    protected BaseNavigationStore(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void GoBack()
    {
        _isGoingBack = true;
        if (RecentViewModels.Count > 0)
            CurrentViewModel = RecentViewModels.Pop();
        _isGoingBack = false;
    }

    private void AddViewModelToHistory(ObservableObject? viewModel)
    {
        if(viewModel is not null && !_isGoingBack) RecentViewModels.Push(viewModel);
        if (RecentViewModels.Count > 10) RecentViewModels.Dequeue();
    }
}

public class NavigationStore(IMessenger messenger) : BaseNavigationStore<ViewModelChangedMessage>(messenger);
public class ModalNavigationStore(IMessenger messenger): BaseNavigationStore<ModalViewModelChangedMessage>(messenger);