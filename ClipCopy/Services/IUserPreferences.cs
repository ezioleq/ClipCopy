namespace ClipCopy.Services;

/// <summary>
/// Interface for abstract storage containing current user preferences as values with unique keys.
/// </summary>
public interface IUserPreferences
{
    /// <summary>
    /// Set a value under a unique key in the store.
    /// </summary>
    /// <param name="key">Unique identifier for the value.</param>
    /// <param name="value">Value to set under provided key.</param>
    void Set(string key, string value);

    /// <summary>
    /// Unset value from specified key.
    /// </summary>
    /// <param name="key">Key of the value to unset.</param>
    void Unset(string key);

    /// <summary>
    /// Check whether provided key has set value in the store.
    /// </summary>
    /// <param name="key">Key to check.</param>
    /// <returns>Whether the key has value.</returns>
    bool IsSet(string key);

    /// <summary>
    /// Get the value associated with the given key.
    /// </summary>
    /// <param name="key">Key of the value to get.</param>
    /// <returns>Underlying value of the key.</returns>
    string Get(string key);
}
