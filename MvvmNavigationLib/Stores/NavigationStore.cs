using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MvvmNavigationLib.Stores.Messages;

namespace MvvmNavigationLib.Stores
{
    public class NavigationStore : BaseNavigationStore
    {
        private ObservableObject? _currentViewModel;

        public override ObservableObject? CurrentViewModel
        {
            get => this._currentViewModel;
            set
            {
                AddViewModelToHistory(_currentViewModel);
                this._currentViewModel = value;
                Messenger.Send(new ViewModelChangedMessage(value));
            }
        }

        public NavigationStore(IMessenger messenger) : base(messenger)
        {
        }
    }
}
