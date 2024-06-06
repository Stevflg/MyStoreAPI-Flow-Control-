namespace MyStoreAPI.MyStoreConfigs.AddSwaggerConfig
{
    public static class AddSwaggerConfigurations
    {
        public static IApplicationBuilder AddSwaggerConfigs(this IApplicationBuilder cnfg)
        {

            cnfg.UseSwagger();
            cnfg.UseSwaggerUI(
                    c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyStoreAPI")
                );

            return cnfg;
        }

    }
}
