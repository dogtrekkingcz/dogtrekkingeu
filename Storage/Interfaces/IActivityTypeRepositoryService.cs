using Storage.Entities.ActivityTypes;

namespace Storage.Interfaces
{
    public interface IActivityTypeRepositoryService : IRepositoryService
    {
        public Task<AddActivityTypeInternalStorageResponse> AddAsync(AddActivityTypeInternalStorageRequest request, CancellationToken cancellationToken);

        public Task<GetAllActivityTypesInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken);

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
