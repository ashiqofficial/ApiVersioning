using ApiVersioning.Sample.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Sample.Controllers;

/// <summary>
/// Controller that exposes blog endpoints for multiple API versions.
/// Route: api/v{version}/blogs
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/blogs")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[ApiVersion("3.0", Deprecated = true)]
public class BlogsController : ControllerBase
{
    /// <summary>
    /// Shared endpoint available in v1 and v2 that returns a blog by identifier.
    /// </summary>
    /// <param name="id">The blog identifier.</param>
    /// <returns>An <see cref="IActionResult"/> with the blog payload.</returns>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { Id = id, Title = "Shared Blog" });
    }

    /// <summary>
    /// v1 - Returns a single v1 blog representation.
    /// </summary>
    /// <returns>A <see cref="BlogV1"/> instance.</returns>
    [HttpGet]
    [MapToApiVersion("1.0")]
    public IActionResult GetV1()
    {
        return Ok(new BlogV1
        {
            Id = 1,
            Title = "ASP.NET Basics",
            Content = "Simple content"
        });
    }

    /// <summary>
    /// v2 - Returns a paged response containing a v2 blog representation.
    /// </summary>
    /// <param name="page">The page number (default: 1).</param>
    /// <param name="pageSize">The page size (default: 10).</param>
    /// <returns>A paged payload with <see cref="BlogV2"/> data.</returns>
    [HttpGet]
    [MapToApiVersion("2.0")]
    public IActionResult GetV2(int page = 1, int pageSize = 10)
    {
        return Ok(new
        {
            Page = page,
            PageSize = pageSize,
            Data = new BlogV2
            {
                Id = 1,
                Title = "Advanced ASP.NET",
                Content = "Enhanced content",
                Author = "Admin",
                CreatedDate = DateTime.UtcNow
            }
        });
    }

    /// <summary>
    /// v3 (Deprecated / Preview) - Returns a v3 blog representation.
    /// </summary>
    /// <remarks>
    /// This API version is marked as deprecated in controller attributes.
    /// </remarks>
    /// <returns>A <see cref="BlogV3"/> instance.</returns>
    [HttpGet]
    [MapToApiVersion("3.0")]
    public IActionResult GetV3()
    {
        return Ok(new BlogV3
        {
            Id = 1,
            Title = "Future Blog API",
            Summary = "Preview version",
            Tags = new List<string> { "preview", "v3" }
        });
    }
}
