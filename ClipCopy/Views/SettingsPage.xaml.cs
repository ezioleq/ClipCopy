using ClipCopy.ViewModels;

namespace ClipCopy.Views;

public partial class SettingsPage
{
    public SettingsPage()
    {
        InitializeComponent();
        BindingContext = new SettingsPageViewModel();
    }
}
