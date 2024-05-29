using CommunityToolkit.Mvvm.Input;

namespace WeatherApp.ViewModel;

public partial class MainPageViewModel
{
    [RelayCommand]
    async Task NavigateToWeatherPageAsync()
    {
        await Shell.Current.GoToAsync("weatherpage", true);
    }
}