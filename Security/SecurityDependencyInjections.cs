using Application.Contracts.SecurityApp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Security.TokenAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public static class SecurityDependencyInjections
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddSecurityServices();
            return services; 
        }
        private static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IGenerateToken, GenerateToken>();
            services.AddScoped<IGetUserSession, GetUserSession>();
            return services;
        }
    }
}
