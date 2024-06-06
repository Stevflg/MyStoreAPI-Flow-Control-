using Application.ConfigDependencyInjections;
using Infraestructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MyStoreAPI.Commons.Errors;
using MyStoreAPI.MyStoreConfigs.AddSwaggerConfig;
using Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Se agrega configuracion para registrar el filtro de errores
builder.Services.AddControllers();

builder.Services.AddApplicationServices();
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddSecurity();

//Registro del servicio de problemsdetailsfactory
builder.Services.AddSingleton<ProblemDetailsFactory, MyStoreAppProblemDetailsFactory>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMyStoreSwaggerApp();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.AddSwaggerConfigs();
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
