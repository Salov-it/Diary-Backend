﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserServices.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserServicesApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}