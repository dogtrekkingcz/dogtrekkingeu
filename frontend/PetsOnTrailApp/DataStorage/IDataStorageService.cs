using Protos.Actions.GetSelectedPublicActionsList;

namespace PetsOnTrailApp.DataStorage;

public interface IDataStorageService<T, R> where T : class where R: class
{
    void InitWithItemFunction(Func<Guid, Task<T>> function);

    void InitWithListFunction(Func<IList<Guid>, Task<T>> function);


    Task<DataStorageModel<R>> GetAsync(Guid id, CancellationToken cancellationToken);

    Task<DataStorageModel<R>> GetListAsync(IList<Guid> ids, CancellationToken cancellationToken);

    Task PutAsync(Guid id, R value, CancellationToken cancellationToken);
}
