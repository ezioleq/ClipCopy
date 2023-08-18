using Android.OS;
using ClipCopy.Database;

namespace ClipCopy;

/// <summary>
/// Implementation of the <see cref="IConnectionString"/> for Android system.
/// </summary>
public class ConnectionString : IConnectionString
{
    private const string DatabaseFilename = "database.db";

    public string GetString()
    {
        var path = Path.Join(GetDataDirPath(), DatabaseFilename);

        return $"Filename={path}";
    }

    /// <summary>
    /// Get application's data directory path.
    /// </summary>
    /// <exception cref="NotSupportedException">When method is called on API under 24 (Nougat).</exception>
    /// <exception cref="IOException">When gathered data directory is null or empty.</exception>
    /// <returns>Application's data directory path.</returns>
    private static string GetDataDirPath()
    {
        if (Build.VERSION.SdkInt < BuildVersionCodes.N)
            throw new NotSupportedException("Minimum required Android API version to get DataDir is 24 (Nougat)");

#pragma warning disable CA1416
        var dataDir = Application.Context.DataDir?.Path;
#pragma warning restore CA1416

        if (string.IsNullOrEmpty(dataDir))
            throw new IOException("Failed to get application's data directory path");

        return dataDir;
    }
}
