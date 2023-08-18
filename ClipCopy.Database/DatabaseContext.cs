using ClipCopy.Models;
using Microsoft.EntityFrameworkCore;

namespace ClipCopy.Database;

/// <summary>
/// Application database context.
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    /// A set of <see cref="ClipEntry"/>.
    /// </summary>
    public DbSet<ClipEntry> ClipEntries { get; set; } = null!;

    private string DatabasePath { get; }
    private const string DatabaseFilename = "database.db";

    /// <summary>
    /// Default constructor.
    /// </summary>
    public DatabaseContext()
    {
        DatabasePath = DatabaseFilename;
    }

    /// <summary>
    /// Default <see cref="DatabaseContext"/> constructor.
    /// <param name="applicationDataDir">Application's data directory path.</param>
    /// </summary>
    /// <exception cref="IOException">Failed to get application's data directory.</exception>
    public DatabaseContext(string? applicationDataDir)
    {
        // var path = Application.Context.FilesDir?.Path;

        if (string.IsNullOrEmpty(applicationDataDir))
            // This SHOULDN'T happen.
            throw new IOException("Failed to get Data Files Directory path");

        DatabasePath = Path.Join(applicationDataDir, DatabaseFilename);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Filename={DatabasePath}");
    }
}
