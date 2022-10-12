using AccioBook.WepApi;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    var startUp = new Startup(builder.Configuration);
    startUp.ConfigureServices(builder.Services);
    builder.Host.UseSerilog(Log.Logger);
    var app = builder.Build();
    startUp.Configure(app, builder.Environment);
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server shutting down...");
    Log.CloseAndFlush();
}


   
