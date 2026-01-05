using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Sample.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/comments")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class CommentsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new { Id = 1, Text = "Great post!", Author = "User1" }
        });
    }
}