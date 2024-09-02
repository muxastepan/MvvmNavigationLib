namespace MvvmNavigationLib.Services;

public interface INavigationService
{
    void Navigate();
}

public interface IParameterNavigationService<TParam>
{
    void Navigate(TParam param);
}
