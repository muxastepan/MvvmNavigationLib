using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services
{
    public class GoBackNavigationService<TNavigationStore> : INavigationService
    where TNavigationStore : INavigationStore
    {
        private readonly TNavigationStore _navigationStore;

        public GoBackNavigationService(TNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public void Navigate()
        {
            _navigationStore.GoBack();
        }
    }
}
