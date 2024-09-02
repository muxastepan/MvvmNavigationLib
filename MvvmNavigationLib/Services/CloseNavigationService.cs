using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services
{
    public class CloseNavigationService<TNavigationStore>(TNavigationStore navigationStore) : INavigationService
        where TNavigationStore: INavigationStore
    {
        public void Navigate()=>navigationStore.CurrentViewModel = null;
    }
}
