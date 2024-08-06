using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MvvmNavigationLib.Utilities;

namespace MvvmNavigationLib.Stores
{
    public class BaseNavigationStore:INavigationStore
    {
        protected readonly IMessenger Messenger;
        public virtual ObservableObject? CurrentViewModel { get; set; }

        private StackQueue<ObservableObject>? _recentViewModels;
        private bool _isGoingBack;

        public StackQueue<ObservableObject> RecentViewModels
        {
            get=>_recentViewModels??=new StackQueue<ObservableObject>(); 
            set=>_recentViewModels=value;
        }

        protected BaseNavigationStore(IMessenger messenger)
        {
            Messenger = messenger;
        }

        public void GoBack()
        {
            _isGoingBack = true;
            if (RecentViewModels.Count > 0)
                CurrentViewModel = RecentViewModels.Pop();
            _isGoingBack = false;
        }

        protected void AddViewModelToHistory(ObservableObject? viewModel)
        {
            if(viewModel is not null && !_isGoingBack) RecentViewModels.Push(viewModel);
            if (RecentViewModels.Count > 10) RecentViewModels.Dequeue();
        }
    }
}
