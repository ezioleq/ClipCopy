namespace ClipCopy;

/// <summary>
/// A set of constants used around the application.
/// </summary>
public static class Constants
{
    /// <summary>
    /// Determines supported MIME type when receiving data from other applications.
    /// </summary>
    public const string SupportedMimeType = "text/*";

    /// <summary>
    /// Application's data directory path.
    /// </summary>
    // Disable "Validate platform compatibility" warning. It's dumb. Just like me.
#pragma warning disable CA1416
    public static readonly string? ApplicationDataDir = Application.Context.DataDir?.Path;
#pragma warning restore CA1416
}
