﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DatabasePostgres.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabasePostgresPersistance(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
