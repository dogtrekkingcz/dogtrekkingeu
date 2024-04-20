using Protos.Actions.GetSelectedPublicActionsList;

namespace PetsOnTrailApp.DataStorage;

public interface IDataStorageService
{
    GetSelectedPublicActionsListResponse GetSelectedPublicActionsListAsync(List<Guid> ids);
}
