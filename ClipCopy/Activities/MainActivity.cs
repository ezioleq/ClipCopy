using Android.Util;
using ClipCopy.Database;
using Microsoft.EntityFrameworkCore;

namespace ClipCopy.Activities;

[Activity(MainLauncher = true)]
public class MainActivity : Activity
{
    private const string Tag = nameof(MainActivity);

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        ApplyMigrations();

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
    }

    /// <summary>
    /// Apply pending database migrations.
    /// </summary>
    private static void ApplyMigrations()
    {
        using var dbContext = new DatabaseContext(new ConnectionString());

        dbContext.Database.Migrate();
        Log.Verbose(Tag, "All pending migrations were applied.");

        dbContext.SaveChanges();
    }
}
