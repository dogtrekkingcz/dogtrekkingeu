using MongoDB.Bson;
using Storage.Models;

namespace Storage.Interfaces;

internal interface IStorageService<T> where T: IRecord
{
    public Task<T> AddOrUpdateAsync(T request, CancellationToken cancellationToken);

    public Task DeleteAsync(string id, CancellationToken cancellationToken);

    public Task<T> GetAsync(string id, CancellationToken cancellationToken);

    public Task<IReadOnlyList<T>> GetByFilterAsync(IList<(string key, Type typeOfValue, object value)> filterList, CancellationToken cancellationToken);

    public Task<IReadOnlyList<T>> GetByFilterBeLikeAsync(IList<(string key, string likeValue)> filterList, CancellationToken cancellationToken);

    public Task<IReadOnlyList<T>> GetByTimeFilterAsync(IList<(string key, FilterOptions option, DateTimeOffset value)> filter, CancellationToken cancellationToken);

    public Task<IReadOnlyList<T>> GetByCustomFilterAsync(BsonDocument filter, CancellationToken cancellationToken);

    public Task<IReadOnlyList<T>> GetByUserId(string userId, CancellationToken cancellationToken);

    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);

    public Task<IReadOnlyList<T>> GetSelectedListAsync(IList<string> ids, CancellationToken cancellationToken);
    
    public Task<IReadOnlyList<T>> GetSelectedListAsync(string key, IList<string> ids, CancellationToken cancellationToken);
    
    public Task<IReadOnlyList<T>> GetSelectedListAsync(IList<Guid> ids, CancellationToken cancellationToken);

    public enum FilterOptions
    {
        Equal = 0,
        MoreThan = 1,
        MoreThanOrEqual = 2,
        LessThan = 3,
        LessThanOrEqual = 4
    };
}