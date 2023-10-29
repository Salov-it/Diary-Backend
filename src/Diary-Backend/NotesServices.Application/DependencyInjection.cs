using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NotesServices.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNotesServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
