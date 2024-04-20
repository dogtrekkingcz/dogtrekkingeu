using MapsterMapper;
using PetsOnTrailApp.Models;
using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public class ActionsRepository<ActionsClient> : IRepository<ActionsClient>
{
    private readonly IDataStorageService _dataStorageService;
    private readonly IMapper _mapper;

    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

    private Dictionary<Guid, RacesModel> _races = new Dictionary<Guid, RacesModel>();
    private Dictionary<(Guid actionId, Guid raceId), CategoriesModel> _categories = new Dictionary<(Guid, Guid), CategoriesModel>();
    private Dictionary<(Guid actionId, Guid raceId, Guid categoryId), ResultsModel> _results = new Dictionary<(Guid, Guid, Guid), ResultsModel>();

    public ActionsRepository(IDataStorageService dataStorageService, IMapper mapper)
    {
        _dataStorageService = dataStorageService;
        _mapper = mapper;
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

                foreach (var race in action.Actions[0].Races)
                {
                    var raceId = Guid.Parse(race.Id);

                    _categories[(actionId, raceId)] = _mapper.Map<CategoriesModel>(race) with
                    {
                        ActionId = Guid.Parse(action.Actions[0].Id),
                        SynchronizedAt = DateTime.Now,
                    };

                    foreach (var category in race.Categories)
                    {
                        _results[(actionId, raceId, Guid.Parse(category.Id))] = _mapper.Map<ResultsModel>(category);
                    }
                }
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }
}
