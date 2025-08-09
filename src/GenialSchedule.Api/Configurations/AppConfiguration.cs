using GenialSchedule.Application;
using GenialSchedule.Application.Usecases.Abstractions;
using System.Diagnostics.CodeAnalysis;

namespace GenialSchedule.Api.Configurations;

[ExcludeFromCodeCoverage]
public static class AppConfiguration
{
    /// <summary>
    /// Register all useCases that implement IUsecase with scoped lifecycle
    /// </summary>
    public static void RegisterUseCases(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<AssemblyMarking>()
                //Register Usecases
                .AddClasses(classes => classes.AssignableTo<IUsecase>())
                    .AsImplementedInterfaces(i => i != typeof(IUsecase))
                    .WithScopedLifetime()

        );
    }
}