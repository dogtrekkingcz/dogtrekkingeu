using Blazored.LocalStorage;
using Protos.Actions.GetSelectedPublicActionsList;
using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage;

public static class DiCompositor
{
    public static IServiceCollection AddDataStorage(this IServiceCollection services)
    {
        services
            .AddBlazoredLocalStorage()
            .AddSingleton<IDataStorageService<GetSelectedPublicActionsListResponse>>((serviceProvider) =>
            {
                var obj = new DataStorageService<GetSelectedPublicActionsListResponse>(serviceProvider.GetRequiredService<ILocalStorageService>());
                obj.InitWithFunction(async (id, Task<GetSelectedPublicActionsListResponse>) =>
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
}
