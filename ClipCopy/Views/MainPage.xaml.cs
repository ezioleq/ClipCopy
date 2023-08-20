using ClipCopy.ViewModels;

namespace ClipCopy.Views;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel(Navigation);
    }
}
