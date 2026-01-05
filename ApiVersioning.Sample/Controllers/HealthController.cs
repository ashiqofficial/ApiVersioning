using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Sample.Controllers;

/// <summary>
/// Health probe controller.
/// Route: api/health
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    /// <summary>
    /// Returns the current health status and server time (UTC).
    /// </summary>
    /// <returns>Healthy status and UTC time.</returns>
    [HttpGet]
    public IActionResult Get() =>
        Ok(new { Status = "Healthy", Time = DateTime.UtcNow });
}
