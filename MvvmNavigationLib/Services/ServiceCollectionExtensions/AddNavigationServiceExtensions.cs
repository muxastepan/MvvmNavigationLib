using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using MvvmNavigationLib.Stores;

namespace MvvmNavigationLib.Services.ServiceCollectionExtensions
{
    public static class AddNavigationServiceExtensions
    {
        public static IServiceCollection AddParameterNavigationService<TViewModel,TNavigationStore,TParam>(
            this IServiceCollection serviceCollection,
            Func<IServiceProvider, CreateViewModel<TViewModel,TParam>> viewModelFactory)
            where TViewModel : ObservableObject 
            where TNavigationStore : INavigationStore=>
            serviceCollection.AddSingleton(
                    services => new ParameterNavigationService<TViewModel, TParam>(
                        services.GetRequiredService<TNavigationStore>(), 
                        services.GetRequiredService<CreateViewModel<TViewModel, TParam>>()))
                .AddSingleton(viewModelFactory);

        public static IServiceCollection AddNavigationService<TViewModel, TNavigationStore>(
            this IServiceCollection serviceCollection,
            Func<IServiceProvider,TViewModel> viewModelFactory)
            where TViewModel : ObservableObject 
            where TNavigationStore : INavigationStore =>
            CreateNavigationService<TViewModel,TNavigationStore>(serviceCollection)
                .AddTransient(viewModelFactory);

        public static IServiceCollection AddNavigationService<TViewModel, TNavigationStore>(
            this IServiceCollection serviceCollection)
            where TViewModel : ObservableObject 
            where TNavigationStore : INavigationStore =>
            CreateNavigationService<TViewModel,TNavigationStore>(serviceCollection)
                .AddTransient<TViewModel>();

        public static IServiceCollection AddUtilityNavigationServices<TNavigationStore>(
            this IServiceCollection serviceCollection)
            where TNavigationStore : INavigationStore =>
            serviceCollection.AddSingleton<GoBackNavigationService<TNavigationStore>>()
                .AddSingleton<CloseNavigationService<TNavigationStore>>();
            

        private static IServiceCollection CreateNavigationService<TViewModel, TNavigationStore>(
            this IServiceCollection serviceCollection)
            where TViewModel : ObservableObject 
            where TNavigationStore : INavigationStore =>
            serviceCollection.AddSingleton(
                services => new NavigationService<TViewModel>(
                        services.GetRequiredService<TNavigationStore>(),
                    services.GetRequiredService<TViewModel>));

    }
}
