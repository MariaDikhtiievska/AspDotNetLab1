namespace AspDotNetLabs.Middlewares
{
    public class SecretMiddleware
    {
        private readonly RequestDelegate next;

        public SecretMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if(httpContext.Request.Path == "/secret-571743235872348" || httpContext.Request.Path == "/secret-571743235872349")
            {
                await httpContext.Response.WriteAsync("Secret page!!");
                return;
            }
            await next.Invoke(httpContext);
        }
    }
}
