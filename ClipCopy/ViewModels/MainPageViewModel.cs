using System.Collections.ObjectModel;
using System.Windows.Input;
using ClipCopy.Database;
using ClipCopy.Database.Models;
using ClipCopy.Platforms.Android.Database;
using ClipCopy.Views;

namespace ClipCopy.ViewModels;

public class MainPageViewModel : ContentPage
{
    private readonly INavigation _navigation;

    public ICommand RefreshCommand { get; }

    public ICommand SettingsCommand { get; }

    public ObservableCollection<ClipEntry> ClipEntries { get; set; } = new();

    public MainPageViewModel() : this(null)
    {
    }

    public MainPageViewModel(INavigation? navigation)
    {
        _navigation = navigation ?? Navigation;

        RefreshCommand = new Command(Refresh);
        SettingsCommand = new Command(GoToSettings);

        Refresh();
    }

    private async void Refresh()
    {
        await using var dbContext = new DatabaseContext(new ConnectionString());

        var entries = dbContext.ClipEntries.ToList();
        ClipEntries.Clear();

        foreach (var entry in entries)
            ClipEntries.Add(entry);
    }

    private async void GoToSettings()
    {
        if (_navigation.NavigationStack.Last() is SettingsPage)
            return;

        await _navigation.PushAsync(new SettingsPage());
    }
}
