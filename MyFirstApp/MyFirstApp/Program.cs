//using System.IO;
//using Microsoft.Extensions.Primitives;
//using MyFirstApp.CustomMiddleware;
using MyFirstApp.LoginMiddleware;
//sing MyFirstApp.MathApp;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<MyCustomMiddleware>();
//builder.Services.AddTransient<MyMathApp>();
//builder.Services.AddTransient<MyLoginApp>();

var app = builder.Build();

app.UseMyLoginMiddleware();

app.Run(async context => {
    await context.Response.WriteAsync("No response");
});
//app.UseMiddleware<MyCustomMiddleware>();

//app.UseMyCustomMiddleware();

//app.UseHelloCustomMiddleware();

//app.UseMyMathApp();

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