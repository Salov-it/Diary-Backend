using DatabasePostgres.Persistance.Config;
using DatabasePostgres.Persistance.Interface;
using DatabasePostgres.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Reflection;

namespace DatabasePostgres.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabasePostgres(this IServiceCollection services)
        {
            Configs configs = new Configs();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<NpgsqlConnection>(new NpgsqlConnection(configs.Connection));

            services.AddScoped<IUserRepositoryPostgres, UserRepositoryPostgres>();
            services.AddScoped<ITaskListRepositoryPostgres, TaskListRepositoryPostgres>();
            return services;
        }
    }
}
