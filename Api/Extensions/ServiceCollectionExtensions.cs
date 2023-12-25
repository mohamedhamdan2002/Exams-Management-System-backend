using Api.Utitlities;
using Domain.Data;
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
             
    }
}
