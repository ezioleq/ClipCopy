using ClipCopy.Models;
using Microsoft.EntityFrameworkCore;

namespace ClipCopy;

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
    /// Default <see cref="DatabaseContext"/> constructor.
    /// </summary>
    /// <exception cref="IOException">Failed to get application's data directory.</exception>
    public DatabaseContext()
    {
        var path = Application.Context.FilesDir?.Path;

        if (string.IsNullOrEmpty(path))
            // This SHOULDN'T happen.
            throw new IOException("Failed to get Data Files Directory path");

        DatabasePath = Path.Join(path, DatabaseFilename);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Filename={DatabasePath}");
    }
}
