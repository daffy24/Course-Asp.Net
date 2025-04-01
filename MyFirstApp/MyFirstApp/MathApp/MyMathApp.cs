namespace MyFirstApp.MathApp;

public class MyMathApp : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Method == "GET" && context.Request.Path == "/")
        {
            int firstNumber = 0;
            int secondNumber = 0;
            string? operation = null;
            long? result = null;

            if (context.Request.Query.ContainsKey("firstNumber") && context.Request.Query.ContainsKey("secondNumber"))
            {
                firstNumber =  Int32.Parse(context.Request.Query["firstNumber"]);
                secondNumber =  Int32.Parse(context.Request.Query["secondNumber"]);
                operation = context.Request.Query["operation"];
                switch (operation)
                {
                    case "add": result = firstNumber + secondNumber; break;
                    case "sub": result = firstNumber - secondNumber; break;
                    case "mul": result = firstNumber * secondNumber; break;
                    case "div": result = firstNumber / secondNumber; break;
                    case "mod": result = firstNumber % secondNumber; break;
                    default: context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid input for 'operation'");
                        return;
                }
                await context.Response.WriteAsync($"<p>{result}</p>");
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input");
            }
            
        }
        
    }
}