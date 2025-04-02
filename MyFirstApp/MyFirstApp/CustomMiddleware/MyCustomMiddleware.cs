namespace MyFirstApp.CustomMiddleware;

public class MyCustomMiddleware
{
    private readonly RequestDelegate _next;

    public MyCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        string path = context.Request.Path;
        var method = context.Request.Method;
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"]!;
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
        await context.Response.WriteAsync($"<h1>Path: {path}</h1>");
        await _next(context);
        await context.Response.WriteAsync($"<h2>Method: {method}</h2>");
    }
}
public static class MyCustomMiddlewareExtensions
{
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyCustomMiddleware>();
    }
}