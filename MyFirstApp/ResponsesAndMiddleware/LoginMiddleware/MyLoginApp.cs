namespace MyFirstApp.LoginMiddleware;
using System.IO;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
public class MyLoginApp
{
    private readonly RequestDelegate _next;

    public MyLoginApp(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        if(context.Request.Method == "POST" && context.Request.Path == "/")
        {
            System.IO.StreamReader reader = new StreamReader(context.Request.Body);
            string body = await reader.ReadToEndAsync();
            Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
            
            if(queryDict.ContainsKey("email") && queryDict.ContainsKey("password"))
            {
                if (queryDict["email"] == "admin@example.com" &&
                    queryDict["password"] == "admin1234")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Successful login\n");
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid login\n");
                    await _next(context);
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                if (!queryDict.ContainsKey("email"))
                {
                    await context.Response.WriteAsync("Invalid input for email\n");
                }
                if (!queryDict.ContainsKey("password"))
                {
                    await context.Response.WriteAsync("Invalid input for password\n");

                }
            }
        }
        await _next(context);
    }
}
public static class MyLoginMiddlewareExtensions
{
    public static IApplicationBuilder UseMyLoginMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyLoginApp>();
    }
}