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

    private readonly string _connectionString;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public DatabaseContext()
    {
        _connectionString = string.Empty;
    }

    /// <summary>
    /// <see cref="DatabaseContext"/> constructor.
    /// <param name="connectionString">Database connection string implementation.</param>
    /// </summary>
    public DatabaseContext(IConnectionString connectionString)
    {
        _connectionString = connectionString.GetString();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionString);
    }
}
