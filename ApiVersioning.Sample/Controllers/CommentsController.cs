using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Sample.Controllers;

/// <summary>
/// Controller that exposes comment endpoints for multiple API versions.
/// Route: api/v{version}/comments
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/comments")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class CommentsController : ControllerBase
{
    /// <summary>
    /// Returns a collection of comments.
    /// This endpoint is available in API versions 1.0 and 2.0.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing a list of comments.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new { Id = 1, Text = "Great post!", Author = "User1" }
        });
    }
}
