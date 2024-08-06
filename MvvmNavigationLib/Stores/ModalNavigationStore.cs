using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MvvmNavigationLib.Stores.Messages;

namespace MvvmNavigationLib.Stores
{
    public class ModalNavigationStore : BaseNavigationStore
    {

        

        private ObservableObject? _currentViewModel;

        public override ObservableObject? CurrentViewModel
        {
            get => this._currentViewModel;
            set
            {
                AddViewModelToHistory(_currentViewModel);
                _currentViewModel = value;
                Messenger.Send(new ModalViewModelChangedMessage(value));
            }
        }

        public bool IsOpen => this.CurrentViewModel != null;


        public void Close() => this.CurrentViewModel = null;

        public ModalNavigationStore(IMessenger messenger) : base(messenger)
        {
        }
    }
}
