namespace PetsOnTrailApp.DataStorage;

public interface IDataStorageService
{
    Task<List<RaceDto>> GetRacesForActionAsync(Guid actionId);

    Task<List<CategoryDto>> GetCategoriesForActionRaceAsync(Guid actionId, Guid raceId);

    Task<List<ResultDto>> GetResultsForActionRaceCategoryAsync(Guid actionId, Guid raceId, Guid categoryId);

    Task AddResultAsync(Guid actionId, Guid raceId, Guid categoryId, ResultDto result);
}
