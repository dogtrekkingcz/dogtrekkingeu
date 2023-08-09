using Import.DogtrekkingCz;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Import;

public static class DiCompositor
{
    public static IServiceCollection AddImport(this IServiceCollection serviceProvider, TypeAdapterConfig typeAdapterConfig)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        serviceProvider
            .AddHttpClient()
            .AddSingleton<IDogtrekkingCzService, DogtrekkingCzService>();

        typeAdapterConfig.AddDogtrekkingCzMapping();

        return serviceProvider;
    }   
}