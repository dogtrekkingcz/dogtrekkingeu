using Storage.Entities.PetTypes;

namespace Storage.Interfaces;

public interface IPetTypeRepositoryService : IRepositoryService
{
    public Task AddAsync(AddPetTypeInternalStorageRequest request, CancellationToken cancellationToken);

    public Task<GetPetTypesInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken);

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
