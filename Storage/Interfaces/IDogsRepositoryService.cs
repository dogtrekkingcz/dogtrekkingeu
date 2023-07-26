using Storage.Entities.Dogs;

namespace Storage.Interfaces
{
    public interface IDogsRepositoryService : IRepositoryService
    {
        Task<AddDogInternalStorageResponse> AddDogAsync(CreateDogInternalStorageRequest request, CancellationToken cancellationToken);

        Task<UpdateDogResponse> UpdateDogAsync(UpdateDogInternalStorageRequest request, CancellationToken cancellationToken);

        Task<GetDogsFilteredByChipInternalStorageResponse> GetDogsFilteredByChipAsync(GetDogsFilteredByChipInternalStorageRequest request, CancellationToken cancellationToken);
        
        Task DeleteDogAsync(DeleteDogInternalStorageRequest request, CancellationToken cancellationToken);

        Task<GetAllDogsInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken);
    }
}
