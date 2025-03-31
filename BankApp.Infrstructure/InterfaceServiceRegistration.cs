using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Infrastructure.Context;
using BankApp.Infrastructure.Repository;
using BankApp.Infrstructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BankApp.Infrastructure
{
    public static class InterfaceServiceRegistration
    {   
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BankDBContext>(options => 
            { 
                options.UseSqlServer(configuration.GetConnectionString("LocalConnectionString"));
            
            });

            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;


        }
    }
}