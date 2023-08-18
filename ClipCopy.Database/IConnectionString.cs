namespace ClipCopy.Database;

/// <summary>
/// Represents the SQLite database connection string.
/// </summary>
public interface IConnectionString
{
    /// <summary>
    /// Get the prepared SQLite connection string.
    /// </summary>
    /// <returns>Connection string.</returns>
    string GetString();
}
