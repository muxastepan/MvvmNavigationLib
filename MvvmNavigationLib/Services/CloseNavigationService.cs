using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services
{
    public class CloseNavigationService<TNavigationStore>:INavigationService
    where TNavigationStore: INavigationStore
    {
        private readonly TNavigationStore _navigationStore;

        public CloseNavigationService(TNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = null;
        }
    }
}
