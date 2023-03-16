using Storage.Entities.Dogs;

namespace Storage.Interfaces
{
    public interface IDogsRepositoryService : IRepositoryService
    {
        Task<AddDogResponse> AddDogAsync(AddDogRequest request);

        Task<UpdateDogResponse> UpdateDogAsync(UpdateDogRequest request);

        Task<GetDogResponse> GetDogAsync(GetDogRequest request);
        
        Task DeleteDogAsync(DeleteDogRequest request);
    }
}
