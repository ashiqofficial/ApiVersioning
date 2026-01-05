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

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            description.GroupName.ToUpperInvariant()
        );
    }
});

app.MapControllers();
app.Run();
