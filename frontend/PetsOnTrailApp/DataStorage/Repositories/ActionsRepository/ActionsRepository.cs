using MapsterMapper;
using PetsOnTrailApp.Models;
using Protos.Actions.GetSelectedPublicActionsList;
using Protos.Results;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public class ActionsRepository : IActionsRepository
{
    private readonly IDataStorageService<GetSelectedPublicActionsListResponse, GetSelectedPublicActionsListResponseModel> _dataStorageServicePublicActions;
    private readonly IDataStorageService<GetSimpleActionsListByTypeResponse, GetSimpleActionsListByTypeResponseModel> _dataStorageServiceActionsByType;
    private readonly IMapper _mapper;

    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

    private Dictionary<Guid, ActionSimpleModel> _actionsSimple = new Dictionary<Guid, ActionSimpleModel>();
    private Dictionary<Guid, ActionModel> _actions = new Dictionary<Guid, ActionModel>();
    private Dictionary<Guid, RacesModel> _races = new Dictionary<Guid, RacesModel>();
    private Dictionary<(Guid actionId, Guid raceId), CategoriesModel> _categories = new Dictionary<(Guid, Guid), CategoriesModel>();
    private Dictionary<(Guid actionId, Guid raceId, Guid categoryId), ResultsModel> _results = new Dictionary<(Guid, Guid, Guid), ResultsModel>();

    public ActionsRepository(IDataStorageService<GetSelectedPublicActionsListResponse, GetSelectedPublicActionsListResponseModel> dataStorageService, IMapper mapper)
    {
        _dataStorageServicePublicActions = dataStorageService;
        _mapper = mapper;
    }

    public async Task<IList<ActionModel>> GetAllActionsByTypeAsync(Guid typeId)
    {
        var actions = new List<ActionModel>();

        await semaphoreSlim.WaitAsync();
        try
        {
            result = _actionsSimple.GetValueOrDefault(typeId, default(ActionSimpleModel));
        }
        finally
        {
            semaphoreSlim.Release();
        }

        if (result == null)
        {
            await LoadAndParseActionsSimpleAsync(typeId, CancellationToken.None);
        }


        await semaphoreSlim.WaitAsync();
        try
        {
            result = _actionsSimple.GetValueOrDefault(typeId, default(ActionSimpleModel));
        }
        finally
        {
            semaphoreSlim.Release();
        }

        return actions;
    }

    public async Task<RacesModel> GetRacesForActionAsync(Guid actionId)
    {
        var result = null as RacesModel;

        await semaphoreSlim.WaitAsync();
        try
        {
            result = _races.GetValueOrDefault(actionId, default(RacesModel));
        }
        finally
        {
            semaphoreSlim.Release();
        }

        if (result == null)
        {
            await LoadAndParseActionAsync(actionId, CancellationToken.None);
        }


        await semaphoreSlim.WaitAsync();
        try
        {
            result = _races.GetValueOrDefault(actionId, default(RacesModel));
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
        }
        finally
        {
            semaphoreSlim.Release();
        }

        if (result == null)
        {
            await LoadAndParseActionAsync(actionId, CancellationToken.None);
        }

        await semaphoreSlim.WaitAsync();
        try
        {
            result = _categories.GetValueOrDefault((actionId, raceId), default(CategoriesModel));
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
        }
        finally
        {
            semaphoreSlim.Release();
        }

        if (result == null)
        {
            await LoadAndParseActionAsync(actionId, CancellationToken.None);
        }



        await semaphoreSlim.WaitAsync();

        try
        {
            result = _results.GetValueOrDefault((actionId, raceId, categoryId), default(ResultsModel));
        }
        finally
        {
            semaphoreSlim.Release();
        }

        return result;
    }

    public async Task<ActionModel> GetActionModelAsync(Guid actionId)
    {
        var result = null as ActionModel;

        await semaphoreSlim.WaitAsync();

        try
        {
            result = _actions.GetValueOrDefault(actionId, default(ActionModel));
        }
        finally
        {
            semaphoreSlim.Release();
        }

        if (result == null)
        {
            await LoadAndParseActionAsync(actionId, CancellationToken.None);
        }

        await semaphoreSlim.WaitAsync();

        try
        {
            result = _actions.GetValueOrDefault(actionId, default(ActionModel));
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
                _actions[actionId] = _mapper.Map<ActionModel>(action);

                _races[actionId] = _mapper.Map<RacesModel>(action);

                foreach (var race in action.Data.Actions[0].Races)
                {
                    var raceId = race.Id;

                    _categories[(actionId, raceId)] = _mapper.Map<CategoriesModel>(race) with
                    {
                        ActionId = action.Data.Actions[0].Id,
                        SynchronizedAt = action.Created
                    };

                    foreach (var category in race.Categories)
                    {
                        _results[(actionId, raceId, category.Id)] = _mapper.Map<ResultsModel>(category) with
                        {
                            SynchronizedAt = action.Created
                        };
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
