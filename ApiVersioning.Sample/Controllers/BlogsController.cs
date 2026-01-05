using ApiVersioning.Sample.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Sample.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/blogs")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[ApiVersion("3.0", Deprecated = true)]
public class BlogsController : ControllerBase
{
    // ✅ Shared endpoint (v1 + v2)
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { Id = id, Title = "Shared Blog" });
    }

    // 🔹 v1
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

    // 🔹 v2
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

    // 🔹 v3 (Deprecated / Preview)
    [HttpGet]
    [MapToApiVersion("3.0")]
    public IActionResult GetV3()
    {
        return Ok(new BlogV3
        {
            Id = 1,
            Title = "Future Blog API",
            Summary = "Preview version",
            Tags = ["preview", "v3"]
        });
    }
}
