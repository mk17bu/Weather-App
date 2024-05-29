using WeatherApp.ViewModel;

namespace WeatherApp.View;

public partial class WeatherPage
{
    public WeatherPage(WeatherPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}