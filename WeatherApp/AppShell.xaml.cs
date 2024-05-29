using WeatherApp.View;

namespace WeatherApp;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("weatherpage", typeof(WeatherPage));
    }
}