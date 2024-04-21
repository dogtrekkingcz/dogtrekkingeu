using Protos.Actions.GetSelectedPublicActionsList;

namespace PetsOnTrailApp.DataStorage;

public interface IDataStorageService<T> where T : class
{
    void InitWithFunction(Func<Guid, Task<T>> function);

    Task<DataStorageModel<T>> GetAsync(Guid id, CancellationToken cancellationToken);

    Task PutAsync(Guid id, T value, CancellationToken cancellationToken);
}
