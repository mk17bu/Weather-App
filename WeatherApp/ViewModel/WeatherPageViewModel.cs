using System.Collections.ObjectModel;
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
    
    [ObservableProperty]
    private ObservableCollection<WeatherData> _weatherDataList = new ObservableCollection<WeatherData>();

    [RelayCommand]
    private async Task GetCityWeatherAsync()
    {
        if (!string.IsNullOrWhiteSpace(CityName))
        {
            var weatherData = await weatherService.GetWeatherData(GenerateRequestUrl(Constants.OpenWeatherMapEndpoint));

            if (weatherData != null)
            {
                _weatherDataList.Add(weatherData);
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