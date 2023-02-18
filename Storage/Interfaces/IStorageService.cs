namespace Storage.Interfaces.Services;

internal interface IStorageService<T>
{
    public Task<T> AddAsync(T request);

    public Task<IReadOnlyList<T>> GetAllAsync();
}