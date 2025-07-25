using Microsoft.Extensions.DependencyInjection;
using MipiTestTask.Application.ApplicationServices;
using MipiTestTask.Application.Interfaces;

namespace MipiTestTask.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDocumentApplicationService, DocumentApplicationService>();

        return services;
    }
}