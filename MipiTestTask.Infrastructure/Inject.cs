using Microsoft.Extensions.DependencyInjection;
using MipiTestTask.Application.Interfaces;
using MipiTestTask.Infrastructure.Adapters;

namespace MipiTestTask.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDocumentAdapter, DocumentAdapter>(); ;

        return services;
    }
}
