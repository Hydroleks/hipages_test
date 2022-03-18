using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog
(
    (hostingContext, loggingConfiguration) => 
        loggingConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync();
        await Seed.SeedData(context);
    }
    catch(Exception ex)
    {
        Log.Error(ex, "An error occured during migration.");
    }
}

try
{
    Log.Information("Starting HiPages.");
    await app.RunAsync();
}
catch(Exception ex)
{
    Log.Fatal(ex, "HiPages terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}
