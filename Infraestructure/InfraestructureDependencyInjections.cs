using Infraestructure.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public static class InfraestructureDependencyInjections
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddMyContext(services,configuration);
            return services;    
        }
        private static IServiceCollection AddMyContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyStoreAppContext>(op =>
                op.UseMySQL(configuration.GetConnectionString("mystore"),
                a => a.MigrationsAssembly("Infraestructure")));
            return services;
        }
    }
}
