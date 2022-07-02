using AspDotNetLabs.Middlewares;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<LoggerMiddleware>();
app.UseMiddleware<SecretMiddleware>();

app.UseStatusCodePagesWithReExecute("/{0}.html");

app.UseFileServer();
app.UseFileServer(new FileServerOptions
{
    EnableDirectoryBrowsing = true,
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"static"))
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/home/index", () => "Home / Index");
app.MapGet("/home/about", () => "Home / About");


app.Run();
