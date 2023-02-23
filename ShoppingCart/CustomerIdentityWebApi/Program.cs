using CustomerIdentityWebApi.CQRS.Commands.Handlers;
using CustomerIdentityWebApi.CQRS.Commands.Interfaces;
using CustomerIdentityWebApi.CQRS.Queries.Handlers;
using CustomerIdentityWebApi.CQRS.Queries.Interfaces;
using CustomerIdentityWebApi.Database;
//using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerDAL, CustomerDAL>();
//builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
//builder.Configuration.GetConnectionString("DefaultConnection")
//));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICustomerCommand, CustomerCommandHandler>();
builder.Services.AddScoped<ICustomerQuery, CustomerQueryHandler>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
