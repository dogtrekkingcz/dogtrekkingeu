using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public interface IActionsRepository
{
    Task<IList<SimpleActionModel>> GetAllActionsByTypeAsync(Guid typeId, CancellationToken cancellationToken);

    Task <SimpleActionModel> GetActionModelAsync(Guid actionId, CancellationToken cancellationToken);

    Task<RacesModel> GetRacesForActionAsync(Guid actionId);

    Task<CategoriesModel> GetCategoriesForActionRaceAsync(Guid actionId, Guid raceId);

    Task<ResultsModel> GetResultsForActionRaceCategoryAsync(Guid actionId, Guid raceId, Guid categoryId);

    Task AddResultAsync(Guid actionId, Guid raceId, Guid categoryId, ResultsModel.ResultDto result);
}
