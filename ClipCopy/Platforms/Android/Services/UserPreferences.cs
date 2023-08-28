using Android.Content;
using Android.Util;
using ClipCopy.Services;

[assembly: Dependency(typeof(ClipCopy.Platforms.Android.Services.UserPreferences))]

namespace ClipCopy.Platforms.Android.Services;

public class UserPreferences : IUserPreferences
{
    private const string Tag = nameof(UserPreferences);

    /// <inheritdoc/>
    public void Set(string key, string value)
    {
        var editor = GetSharedPreferences()?.Edit();
        editor?.PutString(key, value);
        editor?.Apply();

        if (editor is null)
            Log.Error(Tag, $"Failed to set {key} to {value}");
    }

    /// <inheritdoc/>
    public void Unset(string key)
    {
        var editor = GetSharedPreferences()?.Edit();
        editor?.Remove(key);
        editor?.Apply();

        if (editor is null)
            Log.Error(Tag, $"Failed to unset {key}");
    }

    /// <inheritdoc/>
    public bool IsSet(string key)
    {
        var prefs = GetSharedPreferences();
        var exists = prefs?.Contains(key) ?? false;

        return exists;
    }

    /// <inheritdoc/>
    public string Get(string key, string? defaultValue = null)
    {
        var prefs = GetSharedPreferences();
        var value = prefs?.GetString(key, defaultValue);

        return value ?? string.Empty;
    }

    /// <summary>
    /// Get Android's shared preferences for the application.
    /// </summary>
    /// <returns>Shared preferences instance.</returns>
    private static ISharedPreferences? GetSharedPreferences()
    {
        var context = global::Android.App.Application.Context;
        var sharedPreferences = context.GetSharedPreferences(Constants.PreferenceFileKey, FileCreationMode.Private);

        if (sharedPreferences is null)
        {
            Log.Error(Tag, "Failed to get application shared preferences");
            return null;
        }

        return sharedPreferences;
    }
}
