using Protos.Actions.GetSelectedPublicActionsList;

namespace PetsOnTrailApp.DataStorage;

public interface IDataStorageService<T>
{
    void InitWithFunction(Func<Guid, T> action);

    Task<T> GetAsync(Guid id, CancellationToken cancellationToken);

    Task PutAsync(Guid id, T value, CancellationToken cancellationToken);
}
