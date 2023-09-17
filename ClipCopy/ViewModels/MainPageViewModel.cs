using System.Collections.ObjectModel;
using System.Windows.Input;
using ClipCopy.Database;
using ClipCopy.Database.Models;
using ClipCopy.Views;

namespace ClipCopy.ViewModels;

public class MainPageViewModel : ContentPage
{
    private readonly INavigation _navigation;

    public ICommand RefreshCommand { get; }

    public ICommand SettingsCommand { get; }

    public ObservableCollection<ClipEntry> ClipEntries { get; set; } = new();

    private bool _isRefreshing;

    public bool IsRefreshing
    {
        get => _isRefreshing;
        private set
        {
            _isRefreshing = value;
            OnPropertyChanged();
        }
    }

    public MainPageViewModel(MainPage page)
    {
        _navigation = page.Navigation;

        RefreshCommand = new Command(Refresh);
        SettingsCommand = new Command(GoToSettings);

        Refresh();
    }

    private async void Refresh()
    {
        if (IsRefreshing)
            return;

        IsRefreshing = true;

        var connectionString = DependencyService.Get<IConnectionString>();
        await using var dbContext = new DatabaseContext(connectionString);

        var entries = dbContext.ClipEntries.ToList();
        ClipEntries.Clear();

        foreach (var entry in entries)
            ClipEntries.Add(entry);

        IsRefreshing = false;
    }

    private async void GoToSettings()
    {
        if (_navigation.NavigationStack.Last() is SettingsPage)
            return;

        await _navigation.PushAsync(new SettingsPage());
    }
}
