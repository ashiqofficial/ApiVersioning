// <summary>
// Program entry for ApiVersioning.Sample.
// Configures services, API versioning (URL segment, header, media-type, query), Swagger generation,
// and registers controllers. Target: .NET 10.
// </summary>

using ApiVersioning.Sample.Configurations;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region API Versioning

// Add API Versioning
builder.Services.AddApiVersioning(options =>
{
    // Default version if not specified
    options.DefaultApiVersion = new ApiVersion(1, 0);

    // Assume default version when not specified
    options.AssumeDefaultVersionWhenUnspecified = true;

    // Report API versions in response headers
    options.ReportApiVersions = true;

    // Read version from multiple sources
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),           // /api/v1/trips
        new HeaderApiVersionReader("X-Api-Version"), // Header: X-Api-Version: 1.0
        new MediaTypeApiVersionReader("v"),          // Accept: application/json;v=1.0
        new QueryStringApiVersionReader("api-version") // ?api-version=1.0
    );
})
.AddMvc()  // Important for .NET 10
.AddApiExplorer(options =>
{
    // Format: 'v'major[.minor][-status]
    options.GroupNameFormat = "'v'VVV";

    // Substitute version in URL
    options.SubstituteApiVersionInUrl = true;
});
#endregion

#region Swagger


builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

#endregion

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                $"Sample API {description.GroupName.ToUpperInvariant()}");
        }
        options.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                $"Sample API {description.GroupName.ToUpperInvariant()}");
        }
        options.RoutePrefix = "swagger";
    });

}

app.MapControllers();
app.Run();
