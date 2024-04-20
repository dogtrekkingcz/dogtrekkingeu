using Google.Protobuf.Collections;
using MapsterMapper;
using Protos.Actions.GetSelectedPublicActionsList;
using System.Reflection;
using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage;

public class DataStorageService<Client, FunctionName, Parameter, ReturnType> : IDataStorageService<Client, FunctionName, Parameter, ReturnType>
{
    public readonly string _functionName;
    private readonly Client _client;
    private readonly IMapper _mapper;
    private readonly Blazored.LocalStorage.ILocalStorageService _localStorage;

    public DataStorageService(Client client, IMapper mapper, Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        _client = client;
        _localStorage = localStorage;
        _mapper = mapper;
    }

    public async Task<ReturnType> GetListAsync(List<Guid> ids)
    {
        MethodInfo method = typeof(Client).GetMethod(_functionName);
        MethodInfo generic = method.MakeGenericMethod(typeof(Parameter));

        var param = new object[] { _mapper.Map<Parameter>(ids) };
        var task = (Task) generic.Invoke(_client, param);

        await task.ConfigureAwait(false);

        var resultProperty = task.GetType().GetProperty("Result");
        
        var values = (ReturnType) resultProperty.GetValue(task);

        foreach (var action in actions.Actions)
        {
            await _localStorage.SetItemAsync("name", "John Smith");
            // var name = await _localStorage.GetItemAsync<string>("name");
        }

        return values;
    }    
}
