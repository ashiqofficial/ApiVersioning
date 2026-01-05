using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ApiVersioning.Sample.Configurations;

/// <summary>
/// Configures Swagger documents for each API version discovered by the API versioning provider.
/// </summary>
public sealed class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
    /// </summary>
    /// <param name="provider">The API version description provider.</param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    /// <summary>
    /// Configure SwaggerGen options to add a Swagger doc per API version.
    /// </summary>
    /// <param name="options">The swagger generation options to configure.</param>
    public void Configure(SwaggerGenOptions options)
    {
        // ✅ ADD THIS BLOCK
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        if (File.Exists(xmlPath))
        {
            options.IncludeXmlComments(xmlPath);
        }

        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                new OpenApiInfo
                {
                    Title = "Sample API",
                    Version = description.ApiVersion.ToString(),
                    Description = description.IsDeprecated
                        ? "⚠️ This API version has been deprecated."
                        : "Sample API demonstrating API versioning with Swagger"
                });
        }
    }
}
