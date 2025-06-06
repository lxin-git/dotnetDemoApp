using DemoApp.Data;
using DemoApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=demo.db"));

// Register RabbitMQ options
builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddSingleton<RabbitMqService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();