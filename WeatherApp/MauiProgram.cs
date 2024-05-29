using Microsoft.Extensions.Logging;
using WeatherApp.Services;
using WeatherApp.View;
using WeatherApp.ViewModel;

namespace WeatherApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<WeatherService>();

        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddTransient<WeatherPageViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<WeatherPage>();
        
        return builder.Build();
    }
}