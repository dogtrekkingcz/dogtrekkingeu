using MapsterMapper;
using PetsOnTrailApp.Extensions;

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

    public void InitWithItemFunction(Func<Guid, Task<T>> function)
    {
        _function = function;
    }

    public void InitWithListFunction(Func<IList<Guid>, Task<T>> function)
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
            Console.WriteLine(loadedData.Dump());

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

    public async Task<DataStorageModel<R>> GetListAsync(IList<Guid> ids, CancellationToken cancellationToken)
    {
        DataStorageModel<R> data = null;

        var id = string.Join(":", ids.Select(id => id.ToString()));

        if (await _localStorage.ContainKeyAsync(id))
            data = await _localStorage.GetItemAsync<DataStorageModel<R>>(id, cancellationToken);

        if (data == null || data.Created < DateTimeOffset.Now.AddMinutes(-DATA_VALID_TIMEOUT))
        {
            var loadedData = await _functionByList.Invoke(ids);
            Console.WriteLine(loadedData.Dump());

            var model = _mapper.Map<R>(loadedData);

            data = new DataStorageModel<R>()
            {
                Data = model,
                Created = DateTime.UtcNow,
                Id = ids[0]
            };

            await _localStorage.SetItemAsync(id, data, cancellationToken);
        }

        return await _localStorage.GetItemAsync<DataStorageModel<R>>(id, cancellationToken);
    }

    public async Task PutAsync(Guid id, R value, CancellationToken cancellationToken)
    {
        await _localStorage.SetItemAsync(id.ToString(), value, cancellationToken);
    }
}
