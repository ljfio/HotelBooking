using System;
using System.Threading.Tasks;
using HotelBooking.Core.Extensions;
using HotelBooking.Infrastructure;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotelBooking.Mediator;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("HotelBooking");

builder.Services.AddDbContext<ModelContext>(config => config.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddCoreServices();

builder.Services.AddMediator();

builder.Services.AddSwaggerGen(c =>
{
    c.MapType<DateTime>(() => new OpenApiSchema() { Type = "string", Format = "date" });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

await app.RunAsync();