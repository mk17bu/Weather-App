using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Model;
using WeatherApp.Services;

namespace WeatherApp.ViewModel;

public partial class WeatherPageViewModel(WeatherService weatherService) : ObservableObject
{
    [ObservableProperty]
    private string _cityName = "Barcelona";

    [ObservableProperty]
    private WeatherData? _currentWeather;

    [RelayCommand]
    private async Task GetCityWeatherAsync()
    {
        if (!string.IsNullOrWhiteSpace(CityName))
        {
            CurrentWeather = await weatherService.GetWeatherData(GenerateRequestUrl(Constants.OpenWeatherMapEndpoint));
        }
    }

    private string GenerateRequestUrl(string endpoint)
    {
        return $"{endpoint}?q={CityName}&units=metric&APPID={Constants.OpenWeatherMapApiKey}";
    }
}