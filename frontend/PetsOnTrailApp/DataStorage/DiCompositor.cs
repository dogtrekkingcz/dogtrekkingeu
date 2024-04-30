﻿using Blazored.LocalStorage;
using Mapster;
using MapsterMapper;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;
using Protos.Actions;
using Protos.Actions.GetSelectedPublicActionsList;
using Protos.Actions.GetSimpleActionsList;
using Protos.Activities.GetActivityByUserIdAndActivityId;
using static Protos.Actions.Actions;
using static Protos.Activities.Activities;

namespace PetsOnTrailApp.DataStorage;

public static class DiCompositor
{
    public static IServiceCollection AddDataStorage(this IServiceCollection services)
    {
        services
            .AddBlazoredLocalStorage()
            .AddSingleton<IActionsRepository, ActionsRepository>()
            .AddSingleton<IActivityRepository, ActivityRepository>()

            .AddSingleton<IDataStorageService<GetSelectedPublicActionsListResponse, GetSelectedPublicActionsListResponseModel>>((serviceProvider) =>
            {
                var obj = new DataStorageService<GetSelectedPublicActionsListResponse, GetSelectedPublicActionsListResponseModel>(
                    serviceProvider.GetRequiredService<ILocalStorageService>(), 
                    serviceProvider.GetRequiredService<IMapper>()
                );

                obj.InitWithItemFunction(async (id) =>
                {
                    var actionsClient = serviceProvider.GetRequiredService<ActionsClient>();

                    return await actionsClient.getSelectedPublicActionsListAsync(
                        new GetSelectedPublicActionsListRequest()
                        {
                            Ids = { id.ToString() }
                        });
                });

                return obj;
            })
            .AddSingleton<IDataStorageService<GetSimpleActionsListResponse, GetSimpleActionsListResponseModel>>((serviceProvider) =>
            {
                var obj = new DataStorageService<GetSimpleActionsListResponse, GetSimpleActionsListResponseModel>(
                    serviceProvider.GetRequiredService<ILocalStorageService>(), 
                    serviceProvider.GetRequiredService<IMapper>()
                );

                obj.InitWithListFunction(async (ids) =>
                {
                    var actionsClient = serviceProvider.GetRequiredService<ActionsClient>();

                    return await actionsClient.getSimpleActionsListAsync(new IdsRequest { Ids = { ids.Select(id => id.ToString()) } });
                });

                return obj;
            })
            .AddSingleton<IDataStorageService<GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel>>((serviceProvider) =>
            {
                var obj = new DataStorageService<GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel>(
                                       serviceProvider.GetRequiredService<ILocalStorageService>(), 
                                                          serviceProvider.GetRequiredService<IMapper>()
                                                                         );

                obj.InitWithListFunction(async (guidList) =>
                {
                    var activitiesClient = serviceProvider.GetRequiredService<ActivitiesClient>();

                    return await activitiesClient.getActivityByUserIdAndActivityIdAsync(new Protos.Activities.UserIdAndActivityId { UserId = guidList[0].ToString(), ActivityId = guidList[1].ToString() });
                });

                return obj;
            });

        return services;
    }

    public static TypeAdapterConfig AddDataStorageMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig
            .AddPublicActionMapping()
            .AddActivityMapping();

        return typeAdapterConfig;
    }
}
