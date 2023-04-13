using Storage.Entities.Actions;

namespace Storage.Interfaces
{
    public interface IActionsRepositoryService : IRepositoryService
    {
        public Task<AddActionResponse> AddActionAsync(AddActionRequest request, CancellationToken cancellationToken);

        public Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request, CancellationToken cancellationToken);

        public Task DeleteActionAsync(DeleteActionRequest request, CancellationToken cancellationToken);

        public Task<GetActionResponse> GetActionAsync(GetActionRequest request, CancellationToken cancellationToken);

        public Task<GetAllActionsResponse> GetAllActionsAsync(CancellationToken cancellationToken);
    }
}
