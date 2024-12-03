using API.Error;
using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware(IHostEnvironment env, RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext content)
        {
            try
            {
                await next(content);
            }
            catch (Exception ex) { await HandeldExceptionAsync(content, ex, (Microsoft.AspNetCore.Hosting.IHostingEnvironment)env); }
        }

        private static Task HandeldExceptionAsync(HttpContext content, Exception ex, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            content.Response.ContentType = "application/json";
            content.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = env.IsDevelopment()
                ? new APIerrorResponse(content.Response.StatusCode, ex.Message, ex.StackTrace)
                : new APIerrorResponse(content.Response.StatusCode, ex.Message, "Internsl Error");
            var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json  = JsonSerializer.Serialize(response, option);
            return content.Response.WriteAsync(json);
        }
    }
}
