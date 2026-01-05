using System.Collections.Generic;

namespace ApiVersioning.Sample.Models;

/// <summary>
/// Represents the v3 blog model returned by the v3 (preview / deprecated) API.
/// Introduces a concise summary and tag collection.
/// </summary>
public class BlogV3
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
    /// Gets or sets a short summary of the blog content.
    /// Defaults to an empty string to avoid null values.
    /// </summary>
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a list of tags associated with the blog.
    /// Initialized to an empty list to avoid null values.
    /// </summary>
    public List<string> Tags { get; set; } = new List<string>();
}