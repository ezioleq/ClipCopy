using System.ComponentModel.DataAnnotations;

namespace ClipCopy.Models;

/// <summary>
/// Represents single clip entry.
/// </summary>
public class ClipEntry
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Text content of the clip entry.
    /// </summary>
    [Required]
    public string TextContent { get; set; } = string.Empty;

    /// <summary>
    /// Clip creation time in UTC.
    /// </summary>
    public DateTime CreationTimeUtc { get; set; }

    /// <summary>
    /// Clip last modification time in UTC.
    /// </summary>
    public DateTime ModificationTimeUtc { get; set; }

    /// <summary>
    /// Whether the clip is pinned.
    /// </summary>
    public bool IsPinned { get; set; }
}
