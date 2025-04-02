namespace MyFirstApp.CustomMiddleware;

public class HelloCustomMiddleware
{
    private readonly RequestDelegate _next;

    public HelloCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Query.ContainsKey("firstName") && context.Request.Query.ContainsKey("lastName"))
        {
            string fullName = context.Request.Query["firstName"] + " " + context.Request.Query["lastName"];
            await context.Response.WriteAsync($"Hello, {fullName}!");
        }
        await _next(context);
    }
}

public static class HelloCustomMiddlewareExtension
{
    public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HelloCustomMiddleware>();
    }
}
