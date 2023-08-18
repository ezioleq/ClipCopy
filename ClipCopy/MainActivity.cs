using ClipCopy.Models;
using ClipCopy.Database;
using Microsoft.EntityFrameworkCore;

namespace ClipCopy;

[Activity(MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        TestDbUsage();

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
    }

    private static void TestDbUsage()
    {
        using var dbContext = new DatabaseContext(Constants.ApplicationDataDir);
        dbContext.Database.Migrate();

        var clipEntry = new ClipEntry()
        {
            Id = new Guid(),
            IsPinned = false,
            TextContent = "content",
            CreationTimeUtc = DateTime.UtcNow,
            ModificationTimeUtc = DateTime.UtcNow,
        };

        dbContext.Add(clipEntry);
        dbContext.SaveChanges();
    }
}
