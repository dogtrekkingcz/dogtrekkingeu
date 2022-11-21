using Storage.Interfaces.Entities;

namespace Storage.Interfaces.Services;

public interface IStorageService
{
    public Task<AddActionResponse> AddActionAsync(AddActionRequest request);
}