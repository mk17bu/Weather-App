using WeatherApp.ViewModel;

namespace WeatherApp.View;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}