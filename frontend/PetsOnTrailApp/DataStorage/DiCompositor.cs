using Blazored.LocalStorage;
using Mapster;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using Protos.Actions.GetSelectedPublicActionsList;
using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage;

public static class DiCompositor
{
    public static IServiceCollection AddDataStorage(this IServiceCollection services)
    {
        services
            .AddBlazoredLocalStorage()
            .AddSingleton<IActionsRepository, ActionsRepository>()
            .AddSingleton<IDataStorageService<GetSelectedPublicActionsListResponse>>((serviceProvider) =>
            {
                var obj = new DataStorageService<GetSelectedPublicActionsListResponse>(serviceProvider.GetRequiredService<ILocalStorageService>());
                obj.InitWithFunction(async (id) =>
                {
                    var actionsClient = serviceProvider.GetRequiredService<ActionsClient>();

                    return await actionsClient.getSelectedPublicActionsListAsync(
                        new GetSelectedPublicActionsListRequest()
                        {
                            Ids = { id.ToString() }
                        });
                });

                return obj;
            });

        return services;
    }

    public static TypeAdapterConfig AddDataStorageMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig
            .AddPublicActionMapping();

        return typeAdapterConfig;
    }
}
