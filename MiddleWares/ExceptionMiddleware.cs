using System.Security.Authentication;

namespace JsonPlaceHolder.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch 
            {
                context.Response.StatusCode = 400;
            }
        }
    }
}
