using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMart.API.Errors;
using ShoppingMart.API.Extensions;
using ShoppingMart.API.Helpers;
using ShoppingMart.API.Middleware;
using ShoppingMart.Core.Interfaces;
using ShoppingMart.Infrastructure.Data;
using ShoppingMart.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration); //--Extension Method


var app = builder.Build();


app.UseMiddleware<ExceptionMiddleware>(); //--Custom Middleware
app.UseStatusCodePagesWithReExecute("/errors/{0}"); //--Redirect to unmatch endpoint


app.UseSwagger();
app.UseSwaggerUI();


app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}



app.Run();
