using Microsoft.Extensions.Configuration;
using Serilog;

namespace AccioBook.CrossCutting.IoC.Logging
{
    public static class SerilogExtension
    {
        public static void AddLogging(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }
    }
}
