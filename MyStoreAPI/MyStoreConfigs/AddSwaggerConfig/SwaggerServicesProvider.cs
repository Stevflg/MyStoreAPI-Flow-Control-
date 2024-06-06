using Microsoft.OpenApi.Models;

namespace MyStoreAPI.MyStoreConfigs.AddSwaggerConfig
{
     public static class SwaggerServicesProvider
    {
        public static IServiceCollection AddMyStoreSwaggerApp(this IServiceCollection services)
        {
            services.AddSwaggerGen(a => {

                a.SwaggerDoc(
                   "v1", new OpenApiInfo
                   {
                       Title = "MyStoreAPI",
                       Version = "v1",
                   });

                a.CustomSchemaIds(a => a.FullName?.Replace("+", "."));
                }); 

            return services ;
        }
    }
}
