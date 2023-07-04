using Storage.Entities.Actions;

namespace Storage.Interfaces
{
    public interface IActionsRepositoryService : IRepositoryService
    {
        public Task<CreateActionInternalStorageResponse> AddActionAsync(CreateActionInternalStorageRequest request, CancellationToken cancellationToken);

        public Task<UpdateActionInternalStorageResponse> UpdateActionAsync(UpdateActionInternalStorageRequest request, CancellationToken cancellationToken);

        public Task DeleteActionAsync(DeleteActionInternalStorageRequest request, CancellationToken cancellationToken);

        public Task<GetActionInternalStorageResponse> GetActionAsync(GetActionInternalStorageRequest request, CancellationToken cancellationToken);

        public Task<GetAllActionsInternalStorageResponse> GetAllActionsAsync(CancellationToken cancellationToken);

        public Task<AddResultInternalStorageResponse> AddResultAsync(AddResultInternalStorageRequest request, CancellationToken cancellationToken);
        
        public Task<GetSelectedActionsInternalStorageResponse> GetSelectedActionsAsync(GetSelectedActionsInternalStorageRequest request, CancellationToken cancellationToken);
    }
}
