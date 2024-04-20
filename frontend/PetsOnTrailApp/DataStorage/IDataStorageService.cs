using Protos.Actions.GetSelectedPublicActionsList;

namespace PetsOnTrailApp.DataStorage;

public interface IDataStorageService<Client, FunctionName, ReturnType>
{
    Task<ReturnType> GetListAsync(List<Guid> ids);
}
