namespace PetsOnTrailApp.DataStorage;

public static class DiCompositor
{
    public static IServiceCollection AddDataStorage(this IServiceCollection services)
    {
        services
            .AddSingleton<IDataStorageService, DataStorageService>();

        return services;
    }
}
