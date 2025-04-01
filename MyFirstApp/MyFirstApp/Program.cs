using MyFirstApp.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.UseMiddleware<MyCustomMiddleware>();

app.Run();