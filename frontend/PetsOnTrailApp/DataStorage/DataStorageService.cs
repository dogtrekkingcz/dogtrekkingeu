namespace PetsOnTrailApp.DataStorage;

public class DataStorageService<T> : IDataStorageService<T> where T : class
{
    private readonly Blazored.LocalStorage.ILocalStorageService _localStorage;
    private Func<Guid, Task<T>> _function;

    public DataStorageService(Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public void InitWithFunction(Func<Guid, Task<T>> function)
    {
        _function = function;
    }

    public async Task<DataStorageModel<T>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var data = await _localStorage.GetItemAsync<DataStorageModel<T>>(id.ToString(), cancellationToken);

        if (data == null)
        {
            var loadedData = await _function.Invoke(id);

            data = new DataStorageModel<T>()
            {
                Data = loadedData,
                Created = DateTime.UtcNow,
                Id = id
            };

            await _localStorage.SetItemAsync(id.ToString(), data, cancellationToken);
        }

        return data;
    }

    public async Task PutAsync(Guid id, T value, CancellationToken cancellationToken)
    {
        await _localStorage.SetItemAsync(id.ToString(), value, cancellationToken);
    }
}
