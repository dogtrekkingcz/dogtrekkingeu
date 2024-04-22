using Protos.Actions.GetSelectedPublicActionsList;

namespace PetsOnTrailApp.DataStorage;

public interface IDataStorageService<T, R> where T : class where R: class
{
    void InitWithFunction(Func<Guid, Task<T>> function);

    Task<DataStorageModel<R>> GetAsync(Guid id, CancellationToken cancellationToken);

    Task PutAsync(Guid id, R value, CancellationToken cancellationToken);
}
