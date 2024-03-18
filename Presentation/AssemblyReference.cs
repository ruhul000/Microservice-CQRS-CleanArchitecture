using Microsoft.Extensions.DependencyInjection;

namespace Presentation;

public static class AssemblyReference
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        return services;
    }
}
