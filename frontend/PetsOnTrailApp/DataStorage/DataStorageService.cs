using MapsterMapper;
using Protos.Actions.GetSelectedPublicActionsList;
using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage;

public class DataStorageService : IDataStorageService
{
    private readonly ActionsClient _actionsClient;
    private readonly Blazored.LocalStorage.ILocalStorageService _localStorage;

    public DataStorageService(ActionsClient actionsClient, IMapper mapper, Blazored.LocalStorage.ILocalStorageService localStorage)
    {
        _actionsClient = actionsClient;
        _localStorage = localStorage;
    }

    public async Task<GetSelectedPublicActionsListResponse> GetSelectedPublicActionsListAsync(List<Guid> ids)
    {
        
        
        var actions = await _actionsClient.getSelectedPublicActionsListAsync(
                        new Protos.Actions.GetSelectedPublicActionsList.GetSelectedPublicActionsListRequest() { Ids = { ids.Select(id => id.ToString()) } });

        foreach (var action in actions.Actions)
        {
            await localStorage.SetItemAsync("name", "John Smith");
            var name = await localStorage.GetItemAsync<string>("name");
        }

        return actions;
    }    
}
