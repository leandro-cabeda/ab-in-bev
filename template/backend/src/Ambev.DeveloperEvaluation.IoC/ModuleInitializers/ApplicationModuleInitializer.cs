using Ambev.DeveloperEvaluation.Application.Services.Implementations;
using Ambev.DeveloperEvaluation.Application.Services.Interfaces;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        // Adiciona o mapeamento automático
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // Adiciona o MediatR
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        // Adiciona o serviço
        builder.Services.AddScoped<IUserService, UserService>();

    }
}