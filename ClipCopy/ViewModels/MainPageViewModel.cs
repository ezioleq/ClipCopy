using System.Collections.ObjectModel;
using System.Windows.Input;
using ClipCopy.Database;
using ClipCopy.Database.Models;
using ClipCopy.Platforms.Android.Database;

namespace ClipCopy.ViewModels;

public class MainPageViewModel : ContentPage
{
    public ICommand RefreshCommand { get; }

    public ObservableCollection<ClipEntry> ClipEntries { get; set; } = new();

    public MainPageViewModel()
    {
        RefreshCommand = new Command(Refresh);

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
}
