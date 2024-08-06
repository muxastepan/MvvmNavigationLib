using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services.ServiceCollectionExtensions
{
    public static class AddNavigationServiceExtensions
    {
        public static IServiceCollection AddParameterNavigationService<TViewModel,TNavigationStore,TParam>(
            this IServiceCollection serviceCollection)
            where TViewModel : ObservableObject where TNavigationStore : INavigationStore
        {
            return serviceCollection.AddSingleton(
                services => new ParameterNavigationService<TViewModel, TParam>(
                    services.GetRequiredService<TNavigationStore>(),
                    services.GetRequiredService<CreateViewModel<TViewModel, TParam>>()));
        }

        public static IServiceCollection AddNavigationService<TViewModel, TNavigationStore>(
            this IServiceCollection serviceCollection)
            where TViewModel : ObservableObject where TNavigationStore : INavigationStore
        {
            return serviceCollection.AddSingleton(
                services => new NavigationService<TViewModel>(
                    services.GetRequiredService<TNavigationStore>(),
                    services.GetRequiredService<TViewModel>));
        }

    }
}
