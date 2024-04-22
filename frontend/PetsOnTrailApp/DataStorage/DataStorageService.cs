using MapsterMapper;

namespace PetsOnTrailApp.DataStorage;

public class DataStorageService<T, R> : IDataStorageService<T, R> where T : class where R : class
{
    private readonly Blazored.LocalStorage.ILocalStorageService _localStorage;
    private Func<Guid, Task<T>> _function;
    private const int DATA_VALID_TIMEOUT = 5;
    private readonly IMapper _mapper;

    public DataStorageService(Blazored.LocalStorage.ILocalStorageService localStorage, IMapper mapper)
    {
        _localStorage = localStorage;
        _mapper = mapper;
    }

    public void InitWithFunction(Func<Guid, Task<T>> function)
    {
        _function = function;
    }

    public async Task<DataStorageModel<R>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        DataStorageModel<R> data = null;

        if (await _localStorage.ContainKeyAsync(id.ToString()))
            data = await _localStorage.GetItemAsync<DataStorageModel<R>>(id.ToString(), cancellationToken);

        if (data != null)
            Console.WriteLine($"DataStorageService - got data from localstorage: {id} => {data} -> {data.Data}");
        else
            Console.WriteLine("DataStorageService - no data in localstorage or data is outdated, fetching from server...");

        if (data == null || data.Created < DateTimeOffset.Now.AddMinutes(-DATA_VALID_TIMEOUT))
        {
            Console.WriteLine("Fetching data from server...");
            var loadedData = await _function.Invoke(id);

            Console.WriteLine($"DataStorageService.GetAsync: {id} => {loadedData}, mapping");
            var model = _mapper.Map<R>(loadedData);

            Console.WriteLine("Mapped, saving to localstorage...");

            data = new DataStorageModel<R>()
            {
                Data = model,
                Created = DateTime.UtcNow,
                Id = id
            };

            Console.WriteLine($"DataStorageService.SetAsync: {id} => {data} -> {data.Data}");

            await _localStorage.SetItemAsync(id.ToString(), data, cancellationToken);
        }
               

        return data;
    }

    public async Task PutAsync(Guid id, R value, CancellationToken cancellationToken)
    {
        await _localStorage.SetItemAsync(id.ToString(), value, cancellationToken);
    }
}
