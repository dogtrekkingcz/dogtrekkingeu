using Storage.Entities.Dogs;

namespace Storage.Interfaces
{
    public interface IDogsRepositoryService : IRepositoryService
    {
        Task<AddDogResponse> AddDogAsync(AddDogRequest request, CancellationToken cancellationToken);

        Task<UpdateDogResponse> UpdateDogAsync(UpdateDogRequest request, CancellationToken cancellationToken);

        Task<GetDogResponse> GetDogAsync(GetDogRequest request, CancellationToken cancellationToken);
        
        Task DeleteDogAsync(DeleteDogRequest request, CancellationToken cancellationToken);
    }
}
