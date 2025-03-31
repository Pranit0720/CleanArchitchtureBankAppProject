
using BankApp.Application.Interfaces.Identity;
using BankApp.Identity.Context;
using BankApp.Identity.Models;
using BankApp.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Identity
{
    public static class IdentityServiceRegister
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankAppIdentityDbContext>(options =>
            
                options.UseSqlServer(configuration.GetConnectionString("LocalConnectionString")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BankAppIdentityDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}
