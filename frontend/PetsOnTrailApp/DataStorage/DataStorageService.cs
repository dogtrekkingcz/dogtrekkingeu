namespace PetsOnTrailApp.DataStorage;

public class DataStorageService<T> : IDataStorageService<T> where T : class
{
    private readonly Blazored.LocalStorage.ILocalStorageService _localStorage;
    private Func<Guid, Task<T>> _function;
    private const int DATA_VALID_TIMEOUT = 5;

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
        DataStorageModel<T> data = null;

        if (await _localStorage.ContainKeyAsync(id.ToString()))
            data = await _localStorage.GetItemAsync<DataStorageModel<T>>(id.ToString(), cancellationToken);
        else if (data == null || data.Created < DateTimeOffset.Now.AddMinutes(-DATA_VALID_TIMEOUT))
        {
            var loadedData = await _function.Invoke(id);

            data = new DataStorageModel<T>()
            {
                Data = loadedData,
                Created = DateTime.UtcNow,
                Id = id
            };

            Console.WriteLine($"DataStorageService.SetAsync: {id} => {data} -> {data.Data}");

            await _localStorage.SetItemAsync(id.ToString(), data, cancellationToken);
        }

        return data;
    }

    public async Task PutAsync(Guid id, T value, CancellationToken cancellationToken)
    {
        await _localStorage.SetItemAsync(id.ToString(), value, cancellationToken);
    }
}
