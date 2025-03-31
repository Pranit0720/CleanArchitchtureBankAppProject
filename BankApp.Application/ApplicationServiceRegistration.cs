

using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Application
{
    public static class ApplicationServiceRegistration
    {
        //create ststic method to register dependencies 
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(conf => { conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
