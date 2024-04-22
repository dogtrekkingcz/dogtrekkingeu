using MapsterMapper;
using PetsOnTrailApp.Models;
using Protos.Actions.GetSelectedPublicActionsList;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public class ActionsRepository : IActionsRepository
{
    private readonly IDataStorageService<GetSelectedPublicActionsListResponse> _dataStorageServicePublicActions;
    private readonly IMapper _mapper;

    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

    private Dictionary<Guid, RacesModel> _races = new Dictionary<Guid, RacesModel>();
    private Dictionary<(Guid actionId, Guid raceId), CategoriesModel> _categories = new Dictionary<(Guid, Guid), CategoriesModel>();
    private Dictionary<(Guid actionId, Guid raceId, Guid categoryId), ResultsModel> _results = new Dictionary<(Guid, Guid, Guid), ResultsModel>();

    public ActionsRepository(IDataStorageService<GetSelectedPublicActionsListResponse> dataStorageService, IMapper mapper)
    {
        _dataStorageServicePublicActions = dataStorageService;
        _mapper = mapper;
    }

    public async Task<RacesModel> GetRacesForActionAsync(Guid actionId)
    {
        var result = null as RacesModel;

        await semaphoreSlim.WaitAsync();
        try
        {
            result = _races.GetValueOrDefault(actionId, default(RacesModel));

            if (result == null)
            {
                await LoadAndParseActionAsync(actionId, CancellationToken.None);
                result = _races.GetValueOrDefault(actionId, default(RacesModel));
            }
        }
        finally
        {
            semaphoreSlim.Release();
        }

        return result;
    }

    public async Task<CategoriesModel> GetCategoriesForActionRaceAsync(Guid actionId, Guid raceId)
    {
        var result = null as CategoriesModel;

        await semaphoreSlim.WaitAsync();
        try
        {
            result = _categories.GetValueOrDefault((actionId, raceId), default(CategoriesModel));

            if (result == null)
            {
                await LoadAndParseActionAsync(actionId, CancellationToken.None);
                result = _categories.GetValueOrDefault((actionId, raceId), default(CategoriesModel));
            }
        }
        finally
        {
            semaphoreSlim.Release();
        }

        return result;
    }

    public async Task<ResultsModel> GetResultsForActionRaceCategoryAsync(Guid actionId, Guid raceId, Guid categoryId)
    {
        var result = null as ResultsModel;

        await semaphoreSlim.WaitAsync();

        try
        {
            result = _results.GetValueOrDefault((actionId, raceId, categoryId), default(ResultsModel));

            if (result == null)
            {
                await LoadAndParseActionAsync(actionId, CancellationToken.None);
                result = _results.GetValueOrDefault((actionId, raceId, categoryId), default(ResultsModel));
            }
        }
        finally
        {
            semaphoreSlim.Release();
        }

        return result;
    }

    public Task AddResultAsync(Guid actionId, Guid raceId, Guid categoryId, ResultsModel.ResultDto result)
    {
        throw new NotImplementedException();
    }

    private async Task LoadAndParseActionAsync(Guid actionId, CancellationToken cancellationToken)
    {
        var action = await _dataStorageServicePublicActions.GetAsync(actionId, cancellationToken);

        if (action != null)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                _races[actionId] = _mapper.Map<RacesModel>(action);

                foreach (var race in action.Data.Actions[0].Races)
                {
                    var raceId = Guid.Parse(race.Id);

                    _categories[(actionId, raceId)] = _mapper.Map<CategoriesModel>(race) with
                    {
                        ActionId = Guid.Parse(action.Data.Actions[0].Id),
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
