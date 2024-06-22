using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public interface IActionsRepository : IBaseRepository
{
    Task<IList<SimpleActionModel>> GetAllActionsByTypeAsync(IList<Guid> typeIds, CancellationToken cancellationToken);

    Task<ActionModel> GetActionModelAsync(Guid actionId, CancellationToken cancellationToken);

    Task <SimpleActionModel> GetSimpleActionModelAsync(Guid actionId, CancellationToken cancellationToken);

    Task<RacesModel> GetRacesForActionAsync(Guid actionId);

    Task<RaceModel> GetRaceForActionAsync(Guid actionId, Guid raceId, CancellationToken cancellationToken);

    Task<CategoriesModel> GetCategoriesForActionRaceAsync(Guid actionId, Guid raceId);

    Task<ResultsModel> GetResultsForActionRaceCategoryAsync(Guid actionId, Guid raceId, Guid categoryId);

    Task AddResultAsync(Guid actionId, Guid raceId, Guid categoryId, ResultsModel.ResultDto result);

    Task<bool> CanIEditResultsAsync(Guid actionId, CancellationToken cancellationToken);
}
