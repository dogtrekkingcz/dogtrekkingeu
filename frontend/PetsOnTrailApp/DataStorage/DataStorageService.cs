
using PetsOnTrailApp.Models;
using SharedLib.Models;
using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage;

public class DataStorageService : IDataStorageService
{
    private readonly ActionsClient _actionsClient;

    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

    private Dictionary<Guid, RacesModel> _races = new Dictionary<Guid, RacesModel>();
    private Dictionary<(Guid actionId, Guid raceId), CategoriesModel> _categories = new Dictionary<(Guid, Guid), CategoriesModel>();
    private Dictionary<(Guid actionId, Guid raceId, Guid categoryId), ResultsModel> _results = new Dictionary<(Guid, Guid, Guid), ResultsModel>();

    public DataStorageService(ActionsClient actionsClient)
    {
        _actionsClient = actionsClient;
    }

    public Task AddResultAsync(Guid actionId, Guid raceId, Guid categoryId, ResultsModel.ResultDto result)
    {
        throw new NotImplementedException();
    }

    public async Task<RacesModel> GetRacesForActionAsync(Guid actionId)
    {
        var result = null as RacesModel;

        await semaphoreSlim.WaitAsync();
        try
        {
            await Task.FromResult(_races.GetValueOrDefault(actionId, default(RacesModel)));
        }
        finally
        {
            semaphoreSlim.Release();
        }

        return result;
    }

    public async Task<CategoriesModel> GetCategoriesForActionRaceAsync(Guid actionId, Guid raceId)
    {
        return await Task.FromResult(_categories.GetValueOrDefault((actionId, raceId), default(CategoriesModel)));
    }

    public async Task<ResultsModel> GetResultsForActionRaceCategoryAsync(Guid actionId, Guid raceId, Guid categoryId)
    {
        return await Task.FromResult(_results.GetValueOrDefault((actionId, raceId, categoryId), default(ResultsModel)));
    }

    private async Task LoadAndParseActionAsync(Guid actionId)
    {
        var action = await _actionsClient.getSelectedPublicActionsListAsync(
            new Protos.Actions.GetSelectedPublicActionsList.GetSelectedPublicActionsListRequest() { Ids = { actionId.ToString() } });

        if (action != null)
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                _races[actionId] = _mapper.Map<RacesModel>(action);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }
}
