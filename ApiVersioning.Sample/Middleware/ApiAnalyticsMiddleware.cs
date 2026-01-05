using Microsoft.AspNetCore.Mvc;

public class ApiAnalyticsMiddleware
{
    private readonly RequestDelegate _next;

    public ApiAnalyticsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        var apiVersion = context.GetRequestedApiVersion()?.ToString();

        if (!string.IsNullOrEmpty(apiVersion))
        {
            context.Response.Headers.TryAdd("X-Api-Version", apiVersion);
            context.Response.Headers.TryAdd("X-Api-Deprecated", "false");
        }
    }
}
