using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Model;
using WeatherApp.Services;

namespace WeatherApp.ViewModel;

public partial class WeatherPageViewModel : ObservableObject
{
    public WeatherPageViewModel(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    private readonly WeatherService _weatherService;
    
    [ObservableProperty]
    private string _cityName = "Barcelona";

    [ObservableProperty]
    private WeatherData? _currentWeather;
    
    [ObservableProperty]
    private ObservableCollection<WeatherData> _weatherDataList = new ObservableCollection<WeatherData>();

    [RelayCommand]
    private async Task GetCityWeatherAsync()
    {
        if (!string.IsNullOrWhiteSpace(CityName))
        {
            var weatherData = await _weatherService.GetWeatherData(GenerateRequestUrl(Constants.OpenWeatherMapEndpoint));

            if (weatherData != null)
            {
                WeatherDataList.Add(weatherData);
            }
        }
    }
    
    [RelayCommand]
    private void RemoveCityWeather(WeatherData weatherData)
    {
        if (WeatherDataList.Contains(weatherData))
        {
            WeatherDataList.Remove(weatherData);
        }
    }    

    private string GenerateRequestUrl(string endpoint)
    {
        return $"{endpoint}?q={CityName}&units=metric&APPID={Constants.OpenWeatherMapApiKey}";
    }
}