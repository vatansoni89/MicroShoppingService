using EventBus.Common;
using FluentValidation;
using HealthChecks.UI.Client;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Ordering.Infrastructure.Persistence;
using Shipping.Behaviours;
using Shipping.Data;
using Shipping.Data.Interfaces;
using Shipping.EventBusConsumer;
using Shipping.Middleware;
using Shipping.Repositories;
using Shipping.Repositories.Interfaces;
using System.Reflection;

namespace Shipping
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient<ExceptionHandlingMiddleware>();

            services.AddEntityFrameworkSqlServer().AddDbContext<ShipmentWriteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ShippingConnectionString"))); ;

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IShipmentWriteRepository, ShipmentWriteRepository>();
            services.AddScoped<IShippingReadContext, ShippingReadContext>();
            services.AddScoped<IShipmentReadRepository, ShipmentReadRepository>();

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {

                config.AddConsumer<CreateShipmentConsumer>();
                config.AddConsumer<CreatedShipmentConsumer>();
                config.AddConsumer<UpdatedShipmentConsumer>();
                config.AddConsumer<DeletedShipmentConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                    cfg.ReceiveEndpoint(EventBusConstants.CreateShipmentQueue, c =>
                    {
                        c.ConfigureConsumer<CreateShipmentConsumer>(ctx);
                        c.ConfigureConsumer<CreatedShipmentConsumer>(ctx);
                        c.ConfigureConsumer<UpdatedShipmentConsumer>(ctx);
                        c.ConfigureConsumer<DeletedShipmentConsumer>(ctx);
                    });
                });
            });

            // General Configuration
            services.AddScoped<CreateShipmentConsumer>();
            services.AddScoped<CreatedShipmentConsumer>();
            services.AddScoped<UpdatedShipmentConsumer>();
            services.AddScoped<DeletedShipmentConsumer>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shipping", Version = "v1" });
            });

            services.AddHealthChecks()
                .AddRabbitMQ(Configuration["EventBusSettings:HostAddress"], name: "RabbitMQ Health", failureStatus: HealthStatus.Degraded)
                .AddMongoDb(Configuration["DatabaseSettings:ConnectionString"], "MongoDb Health", HealthStatus.Degraded)
                .AddDbContextCheck<ShipmentWriteContext>("Sql Health", HealthStatus.Degraded);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shipping v1"));
            }
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}
