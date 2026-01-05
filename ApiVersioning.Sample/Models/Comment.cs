namespace ApiVersioning.Sample.Models;

/// <summary>
/// Represents a comment associated with a blog post.
/// </summary>
public class Comment
{
    /// <summary>
    /// Gets or sets the unique identifier of the comment.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the comment text.
    /// Defaults to an empty string to avoid null values.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the author of the comment.
    /// Defaults to an empty string to avoid null values.
    /// </summary>
    public string Author { get; set; } = string.Empty;
}