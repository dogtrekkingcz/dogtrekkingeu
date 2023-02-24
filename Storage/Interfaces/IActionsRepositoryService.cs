using Storage.Entities.Actions;

namespace Storage.Interfaces
{
    public interface IActionsRepositoryService : IRepositoryService
    {
        public Task<AddActionResponse> AddActionAsync(AddActionRequest request);

        public Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request);

        public Task DeleteActionAsync(DeleteActionRequest request);

        public Task<GetActionResponse> GetActionAsync(GetActionRequest request);

        public Task<GetAllActionsResponse> GetAllActionsAsync();
    }
}
