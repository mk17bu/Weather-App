using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Model;
using WeatherApp.Services;

namespace WeatherApp.ViewModel;

public partial class WeatherPageViewModel : ObservableObject
{
    private WeatherService _weatherService;
    
    [ObservableProperty]
    private string _cityName = "Barcelona";

    [ObservableProperty]
    private WeatherData? _currentWeather;

    public WeatherPageViewModel(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [RelayCommand]
    private async Task GetCityWeatherAsync()
    {
        if (!string.IsNullOrWhiteSpace(CityName))
        {
            CurrentWeather = await _weatherService.GetWeatherData(GenerateRequestUrl(Constants.OpenWeatherMapEndpoint));
        }
    }

    private string GenerateRequestUrl(string endpoint)
    {
        return $"{endpoint}?q={CityName}&units=metric&APPID={Constants.OpenWeatherMapApiKey}";
    }
}