namespace PetsOnTrailApp.DataStorage;

public class DataStorageService<T> : IDataStorageService<T>
{
    private readonly Blazored.LocalStorage.ILocalStorageService _localStorage;
    private Func<Guid, Task<T>> _function;

    public DataStorageService(Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public void InitWithFunction(Func<Guid, Task<T>> action)
    {
        _function = action;
    }

    public async Task<T> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var data = await _localStorage.GetItemAsync<T>(id.ToString(), cancellationToken);

        if (data == null)
        {
            data = _function.Invoke(id);

            await _localStorage.SetItemAsync(id.ToString(), data, cancellationToken);
        }

        return data;
    }

    public async Task PutAsync(Guid id, T value, CancellationToken cancellationToken)
    {
        await _localStorage.SetItemAsync(id.ToString(), value, cancellationToken);
    }
}
