using DogtrekkingCz.Storage.Models;

namespace Storage.Interfaces.Services;

internal interface IStorageService<T> where T: BaseRecord
{
    public Task<T> AddAsync(T request);

    public Task<T> UpdateAsync(T request);

    public Task<IReadOnlyList<T>> GetAllAsync();
}