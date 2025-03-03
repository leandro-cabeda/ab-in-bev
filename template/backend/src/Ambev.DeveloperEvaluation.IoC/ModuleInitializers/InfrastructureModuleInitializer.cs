using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;
using Ambev.DeveloperEvaluation.IoC.Consumers;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // Adiciona o Rebus com o RabbitMQ
        builder.Services.AddRebus(config => config
                .Transport(t => t.UseRabbitMq("amqp://guest:guest@localhost:5672", "DeveloperEvaluationQueue"))
                .Logging(l => l.Console()));

        // Adiciona os consumidores
            builder.Services.AutoRegisterHandlersFromAssemblyOf<CreateUserConsumer>();
    }
}