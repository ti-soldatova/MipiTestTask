using Microsoft.Extensions.DependencyInjection;
using SDK.Interfaces;

namespace SDK;

public static class Inject
{
    public static IServiceCollection AddSdk(this IServiceCollection services)
    {
        services.AddScoped<IDocumentService, DocumentService>();

        return services;
    }
}