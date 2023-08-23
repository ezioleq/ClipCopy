namespace ClipCopy.ViewModels;

public class SettingsPageViewModel : ContentPage
{
    private bool _enableHistory;

    public bool EnableHistory
    {
        get => _enableHistory;
        set
        {
            _enableHistory = value;
            OnPropertyChanged(nameof(EnableHistory));
        }
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        if (propertyName == nameof(EnableHistory))
            ToggleHistory(EnableHistory);
    }

    private void ToggleHistory(bool enabled)
    {
        // TODO: Set history preferences
    }
}
