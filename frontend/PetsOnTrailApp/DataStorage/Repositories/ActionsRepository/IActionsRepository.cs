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

    Task<ResultsModel> GetResultsForActionRaceCategoryAsync(Guid actionId, Guid raceId, Guid categoryId, bool forceReloadFromServer);
    Task<ResultsModel> GetResultsForActionRaceAsync(Guid actionId, Guid raceId, bool forceReloadFromServer);

    Task AddResultAsync(Guid actionId, Guid raceId, Guid categoryId, ResultsModel.ResultDto result);

    Task<bool> CanIEditResultsAsync(Guid actionId, CancellationToken cancellationToken);

    Task StartNow(Guid actionId, Guid raceId, Guid categoryId, Guid racerId);
    Task FinishNow(Guid actionId, Guid raceId, Guid categoryId, Guid racerId);
    Task DeleteStart(Guid actionId, Guid raceId, Guid categoryId, Guid racerId);
    Task DeleteFinish(Guid actionId, Guid raceId, Guid categoryId, Guid racerId);
    Task Dns(Guid actionId, Guid raceId, Guid categoryId, Guid racerId);
    Task Dnf(Guid actionId, Guid raceId, Guid categoryId, Guid racerId);
    Task Dsq(Guid actionId, Guid raceId, Guid categoryId, Guid racerId);
    Task ResetStates(Guid actionId, Guid raceId, Guid categoryId, Guid racerId);
}
