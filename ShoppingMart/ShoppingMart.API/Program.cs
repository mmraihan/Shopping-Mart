using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMart.API.Errors;
using ShoppingMart.API.Extensions;
using ShoppingMart.API.Helpers;
using ShoppingMart.API.Middleware;
using ShoppingMart.Core.Entities.Identity;
using ShoppingMart.Core.Interfaces;
using ShoppingMart.Infrastructure.Data;
using ShoppingMart.Infrastructure.Identity;
using ShoppingMart.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration); //--Extension Method
builder.Services.AddIdentityServices(builder.Configuration); //--Extension Method
builder.Services.AddSwaggerDocumentation();//--Extension Method


var app = builder.Build();


app.UseMiddleware<ExceptionMiddleware>(); //--Custom Middleware
app.UseStatusCodePagesWithReExecute("/errors/{0}"); //--Redirect to unmatch endpoint

app.UseSwaggerDocumentation();


app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var identityContext = services.GetRequiredService<AppIdentityDbContext>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{

    await context.Database.MigrateAsync();
    await identityContext.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
    await AppIdentityDbContextSeed.SeedUsersAsync(userManager);

}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}



app.Run();
