using DogtrekkingCz.Storage.Models;

namespace Storage.Interfaces.Services;

internal interface IStorageService<T> where T: BaseRecord
{
    public Task<T> AddAsync(T request);

    public Task<T> UpdateAsync(T request);

    public Task DeleteAsync(T request);

    public Task<T> GetAsync(T request);

    public Task<T> GetByFilterAsync(string key, string value);
    
    public Task<IReadOnlyList<T>> GetAllAsync();
}