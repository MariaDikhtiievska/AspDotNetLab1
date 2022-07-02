namespace AspDotNetLabs.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;

        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            File.AppendAllText("access.txt", $"{DateTime.Now} {httpContext.Request.Path}\n");
            await next.Invoke(httpContext);
        }
    }
}
