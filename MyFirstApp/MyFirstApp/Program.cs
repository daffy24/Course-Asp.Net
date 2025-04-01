using MyFirstApp.CustomMiddleware;
using System.IO;
using Microsoft.Extensions.Primitives;
using MyFirstApp.MathApp;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<MyCustomMiddleware>();
builder.Services.AddTransient<MyMathApp>();

var app = builder.Build();

// app.UseMiddleware<MyCustomMiddleware>();
app.UseMiddleware<MyMathApp>();

// app.Run(async (HttpContext context) =>
// {
//     System.IO.StreamReader reader = new StreamReader(context.Request.Body);
//     string body = await reader.ReadToEndAsync();
//
//     Dictionary<string, StringValues> queryDict =
//         Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
//
//     if (queryDict.ContainsKey("firstName"))
//     {
//         foreach (var firstName in queryDict["firstName"])
//         {
//             await context.Response.WriteAsync($"<p>{firstName}</p>");
//         }
//       
//     }
// });

app.Run();