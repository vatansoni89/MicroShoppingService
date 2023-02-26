using Logging;
using Ordering.Infrastructure.Persistence;
using Serilog;
using Shipmenting.Infrastructure.Persistence;
using Shipping;
using Shipping.Extensions;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase<ShipmentWriteContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<ShipmentWriteContextSeed>>();
                ShipmentWriteContextSeed
                    .SeedAsync(context, logger)
                    .Wait();
            }).Run();
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
