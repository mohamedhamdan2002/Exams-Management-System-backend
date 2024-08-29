using Application.Services;
using Application.Services.Contracts;
using Application.Utilities;
using Domain.Data;
using Domain.Entities.Models;
using Domain.Repositories;
using Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        private static void ConfigureEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString(AppConstants.Constr)));
        }

        private static void ConfigureIRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        private static void ConfigureIServiceManager(this IServiceCollection services)
            => services.AddScoped<IServiceManager, ServiceManager>();
        private static void ConfigureCors(this IServiceCollection services)
            => services.AddCors(option =>
            {
                option.AddPolicy(AppConstants.AppPolicy, builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });
        private static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<AppDbContext>();

        }
        private static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JWT();
            configuration.Bind(AppConstants.JwtSection, jwtSettings);
            var secretKey = configuration.GetSection(AppConstants.SECRET).Value;
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
                };
            });

        }
        public static void SetAllRequiredConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureEfCore(configuration);
            services.ConfigureIRepositoryManager();
            services.ConfigureIServiceManager();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IAuthService, AuthService>();
            services.ConfigureCors();
            services.ConfigureIdentity();
            services.ConfigureJWT(configuration);
            services.Configure<JWT>(configuration.GetSection(AppConstants.JwtSection));
            services.AddSignalR();
        }
    }
}
