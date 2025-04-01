namespace MyFirstApp.CustomMiddleware;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string path = context.Request.Path;
        var method = context.Request.Method;
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"]!;
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
        
        await context.Response.WriteAsync($"<h1>Path: {path}</h1>");
        await next(context);
        await context.Response.WriteAsync($"<h2>Method: {method}</h2>");
    }
}