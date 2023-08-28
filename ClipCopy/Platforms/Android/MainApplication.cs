using Android.App;
using Android.Runtime;
using Android.Util;
using ClipCopy.Database;
using Microsoft.EntityFrameworkCore;

namespace ClipCopy.Platforms.Android;

[Application]
public class MainApplication : MauiApplication
{
    private const string Tag = nameof(MainApplication);

    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
        ApplyMigrations();
    }

    protected override MauiApp CreateMauiApp() => Program.CreateMauiApp();

    private static void ApplyMigrations()
    {
        var connectionString = DependencyService.Get<IConnectionString>();
        using var dbContext = new DatabaseContext(connectionString);

        dbContext.Database.Migrate();
        Log.Verbose(Tag, "All pending migrations were applied.");

        dbContext.SaveChanges();
    }
}
