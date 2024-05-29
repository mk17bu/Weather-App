using Newtonsoft.Json;
using WeatherApp.Model;

namespace WeatherApp.Services;

public class WeatherService
{
    public WeatherService()
    {
        _httpClient = new HttpClient();
    }

    private readonly HttpClient _httpClient;

    public async Task<WeatherData?> GetWeatherData(string query)
    {
        WeatherData? weatherData = null;

        try
        {
            var response = await _httpClient.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return weatherData;
    }
}