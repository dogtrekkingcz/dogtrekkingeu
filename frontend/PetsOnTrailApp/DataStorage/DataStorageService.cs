using MapsterMapper;

namespace PetsOnTrailApp.DataStorage;

public class DataStorageService<T, R> : IDataStorageService<T, R> where T : class where R : class
{
    private readonly Blazored.LocalStorage.ILocalStorageService _localStorage;
    private Func<Guid, Task<T>> _function;
    private Func<IList<Guid>, Task<T>> _functionByList;
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

    public void InitWithFunction(Func<IList<Guid>, Task<T>> function)
    {
        _functionByList = function;
    }

    public async Task<DataStorageModel<R>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        DataStorageModel<R> data = null;

        if (await _localStorage.ContainKeyAsync(id.ToString()))
            data = await _localStorage.GetItemAsync<DataStorageModel<R>>(id.ToString(), cancellationToken);

        if (data == null || data.Created < DateTimeOffset.Now.AddMinutes(-DATA_VALID_TIMEOUT))
        {
            var loadedData = await _function.Invoke(id);

            var model = _mapper.Map<R>(loadedData);

            data = new DataStorageModel<R>()
            {
                Data = model,
                Created = DateTime.UtcNow,
                Id = id
            };

            await _localStorage.SetItemAsync(id.ToString(), data, cancellationToken);
        }
               

        return data;
    }

    public async Task<IList<DataStorageModel<R>>> GetListAsync(IList<Guid> ids, CancellationToken cancellationToken)
    {
        var response = new List<DataStorageModel<R>>();

        foreach (var id in ids) 
        { 
            if (await _localStorage.ContainKeyAsync(id.ToString()))
                response.Add(await _localStorage.GetItemAsync<DataStorageModel<R>>(id.ToString(), cancellationToken));
        }

        return response;
    }

    public async Task PutAsync(Guid id, R value, CancellationToken cancellationToken)
    {
        await _localStorage.SetItemAsync(id.ToString(), value, cancellationToken);
    }
}
