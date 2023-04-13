using DogtrekkingCz.Storage.Models;

namespace Storage.Interfaces.Services;

internal interface IStorageService<T> where T: IRecord
{
    public Task<T> AddAsync(T request, CancellationToken cancellationToken);

    public Task<T> UpdateAsync(T request, CancellationToken cancellationToken);

    public Task DeleteAsync(T request, CancellationToken cancellationToken);

    public Task<T> GetAsync(T request, CancellationToken cancellationToken);

    public Task<IReadOnlyList<T>> GetByFilterAsync(IList<(string key, string value)> filterList, CancellationToken cancellationToken);
    
    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
}