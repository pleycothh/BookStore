using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConsoleWebApi
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from new file 1 \n");
            await next(context);
            await context.Response.WriteAsync("Hello from new file 1 \n");
        }
    }
}
