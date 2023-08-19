using ClipCopy.Database;

namespace ClipCopy.Platforms.Android.Database;

/// <summary>
/// Implementation of the <see cref="IConnectionString"/> for Android system.
/// </summary>
public class ConnectionString : IConnectionString
{
    private const string DatabaseFilename = "database.db";

    public string GetString()
    {
        var path = Path.Join(GetFilesDirPath(), DatabaseFilename);

        return $"Filename={path}";
    }

    /// <summary>
    /// Get application's files directory path.
    /// </summary>
    /// <exception cref="IOException">When gathered files directory is null or empty.</exception>
    /// <returns>Application's files directory path.</returns>
    private static string GetFilesDirPath()
    {
        var dataDir = global::Android.App.Application.Context.FilesDir?.Path;

        if (string.IsNullOrEmpty(dataDir))
            throw new IOException("Failed to get application's files directory path");

        return dataDir;
    }
}
