using DogtrekkingCzShared.Entities;
using Mapster;
using Storage.Entities.ActionRights;
using Storage.Models;

namespace Storage.Services.Repositories.ActionRights
{
    internal static class ActionRightsRepositoryMapping
    {
        internal static TypeAdapterConfig AddActionRightsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddActionRightsRequest, ActionRightsRecord>()
                .Ignore(d => d.Id);

            typeAdapterConfig.NewConfig<ActionRightsRecord, AddActionRightsResponse>();

            typeAdapterConfig.NewConfig<GetAllRightsRequest, ActionRightsRecord>()
                .MapWith(s => new ActionRightsRecord { UserId = s.UserId });

            typeAdapterConfig.NewConfig<ActionRightsRecord, ActionRightsDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<IList<ActionRightsRecord>, GetAllRightsResponse>()
                .MapWith(s => new GetAllRightsResponse
                {
                    Rights = s
                        .Select(r => new ActionRightsDto
                        {
                            Id = r.Id, 
                            Rights = r.Rights, 
                            ActionId = r.ActionId, 
                            UserId = r.UserId, 
                            Roles = r.Roles
                        })
                        .ToList()
                });
            
            return typeAdapterConfig;
        }
    }
}
