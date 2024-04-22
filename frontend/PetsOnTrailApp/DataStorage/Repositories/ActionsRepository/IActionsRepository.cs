using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public interface IActionsRepository
{
    Task <ActionModel> GetActionModelAsync(Guid actionId);

    Task<RacesModel> GetRacesForActionAsync(Guid actionId);

    Task<CategoriesModel> GetCategoriesForActionRaceAsync(Guid actionId, Guid raceId);

    Task<ResultsModel> GetResultsForActionRaceCategoryAsync(Guid actionId, Guid raceId, Guid categoryId);

    Task AddResultAsync(Guid actionId, Guid raceId, Guid categoryId, ResultsModel.ResultDto result);
}
