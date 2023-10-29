using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UserServices.Application.Config;
using UserServices.Application.CQRS.Command.Authorization;
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

            services.AddScoped<IUserAuthorization,UserAuthorization>();
            services.AddScoped<AuthorizationCommand>();
            services.AddScoped<AuthorizationHandler>();
            


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSettings.GetSymmetricSecurityKey(),
                    ValidateIssuer = true,
                    ValidIssuer = JwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = JwtSettings.Audience,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
