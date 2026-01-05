using System;

namespace ApiVersioning.Sample.Models;

/// <summary>
/// Represents the v2 blog model returned by the v2 API.
/// Extends v1 with author and creation date information.
/// </summary>
public class BlogV2
{
    /// <summary>
    /// Gets or sets the unique identifier of the blog.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the blog title.
    /// Defaults to an empty string to avoid null values.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the blog content.
    /// Defaults to an empty string to avoid null values.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the author of the blog.
    /// Defaults to an empty string to avoid null values.
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the UTC creation date of the blog entry.
    /// </summary>
    public DateTime CreatedDate { get; set; }
}
