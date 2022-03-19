using Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Jobs;
using Application.Core;

namespace API.Extensions;


public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices
    (
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddDbContext<DataContext>(options => {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        })
        .AddCors(option => {
            option.AddPolicy("CorsPolicy", policy => {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
            });
        })
        .AddMediatR(typeof(JobList.Handler).Assembly)
        .AddAutoMapper(typeof(MappingProfiles).Assembly);

        return services;
    }
}