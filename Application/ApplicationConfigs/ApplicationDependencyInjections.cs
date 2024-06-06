using Application.AppBehavior;
using FluentValidation;
using Identity.PasswordHasher;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConfigDependencyInjections
{
    public static class ApplicationDependencyInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediaTrServices();
            services.AddFluentValidationApp();
            services.AddMyAutoMapAplication();
            return services;
        }

        private static IServiceCollection AddMediaTrServices(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddMediatR(a => a.RegisterServicesFromAssemblyContaining<MyApplicationAssemblyReference>());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MyValidationBehaviorApp<,>));
            return services;
        }

        private static IServiceCollection AddFluentValidationApp(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining(typeof(MyApplicationAssemblyReference), lifetime: ServiceLifetime.Scoped);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }

        private static IServiceCollection AddMyAutoMapAplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
  
    }
}
