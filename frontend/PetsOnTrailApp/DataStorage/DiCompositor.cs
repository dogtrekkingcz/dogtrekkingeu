using Blazored.LocalStorage;

namespace PetsOnTrailApp.DataStorage;

public static class DiCompositor
{
    public static IServiceCollection AddDataStorage(this IServiceCollection services)
    {
        services
            .AddBlazoredLocalStorage()
            .AddSingleton<IDataStorageService, DataStorageService>();

        return services;
    }
}
