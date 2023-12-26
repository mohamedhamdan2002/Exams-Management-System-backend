using Api.Utitlities;
using Application.Services;
using Application.Services.Contracts;
using Domain.Data;
using Domain.Repositories;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString(AppConstans.Constr)));
        }

        public static void ConfigureIServiceManager(this IServiceCollection services)
            => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureIRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();
             


        public static void SetAllRequiredConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureEfCore(configuration);
            services.ConfigureIRepositoryManager();
            services.ConfigureIServiceManager();
        }
    }
}
