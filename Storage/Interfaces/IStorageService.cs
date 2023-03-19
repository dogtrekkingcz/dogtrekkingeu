using DogtrekkingCz.Storage.Models;

namespace Storage.Interfaces.Services;

internal interface IStorageService<T> where T: IRecord
{
    public Task<T> AddAsync(T request);

    public Task<T> UpdateAsync(T request);

    public Task DeleteAsync(T request);

    public Task<T> GetAsync(T request);

    public Task<IReadOnlyList<T>> GetByFilterAsync(IList<(string key, string value)> filterList);
    
    public Task<IReadOnlyList<T>> GetAllAsync();
}