namespace ApiVersioning.Sample.Models;

/// <summary>
/// Represents the v1 blog model returned by the v1 API.
/// </summary>
public class BlogV1
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
}
