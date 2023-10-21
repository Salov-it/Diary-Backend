using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UserServices.Application.Config;
using UserServices.Application.CQRS.Command.UserRegistration;
using UserServices.Application.Interface;

namespace UserServices.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            JwtSettings jwtSettings = new JwtSettings();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IRegistration,Registration>();
            services.AddScoped<RegistrationCommand>();
            services.AddScoped<RegistrationHandler>();

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
