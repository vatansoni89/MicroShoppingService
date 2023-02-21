using Logging;
using Serilog;
using Shipping;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
            .UseSerilog(SeriLogger.Configure)
            .ConfigureAppConfiguration((hostingContext, config) => {
                 config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                 config.AddJsonFile($"appsettings.{Environments.Development}.json", optional: true).AddEnvironmentVariables();
                 //config.AddJsonFile($"appsettings.{Environments.Staging}.json", optional: true).AddEnvironmentVariables();
                 //config.AddJsonFile($"appsettings.{Environments.Production}.json", optional: true).AddEnvironmentVariables();
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
