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
    /// Android's shared preferences file key.
    /// </summary>
    public const string PreferenceFileKey = "com.ezioleq.clipcopy.preferences";

    /// <summary>
    /// Holds constants related to the application settings.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Whether the history should be enabled by default.
        /// </summary>
        public const bool EnableHistoryByDefault = true;

        /// <summary>
        /// Enable history preference key.
        /// </summary>
        public const string EnableHistoryKey = "com.ezioleq.clipcopy.enable_history";
    }
}
