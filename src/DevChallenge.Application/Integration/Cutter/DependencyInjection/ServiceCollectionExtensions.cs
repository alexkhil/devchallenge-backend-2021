using DevChallenge.Application.Integration.Cutter.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DevChallenge.Application.Integration.Cutter.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCutter(this IServiceCollection services)
    {
        services.AddSingleton<VerticalCutter>();
        services.AddSingleton<HorizontalCutter>();
        services.AddSingleton<ICutter>(s => new ParallelCutter(
            new ICutter[]
            {
                s.GetRequiredService<VerticalCutter>(),
                s.GetRequiredService<HorizontalCutter>()
            }));

        return services;
    }
}