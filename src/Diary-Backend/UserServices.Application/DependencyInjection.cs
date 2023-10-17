using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserServices.Application.CQRS.Command.UserRegistration;
using UserServices.Application.Interface;

namespace UserServices.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IRegistration,Registration>();
            services.AddScoped<RegistrationCommand>();
            services.AddScoped<RegistrationHandler>();
            return services;
        }
    }
}
