using Storage.Entities.VaccinationTypes;

namespace Storage.Interfaces;

public interface IVaccinationTypeRepositoryService : IRepositoryService
{
    public Task<AddVaccinationTypeInternalStorageResponse> AddAsync(AddVaccinationTypeInternalStorageRequest request, CancellationToken cancellationToken);

    public Task<GetAllVaccinationTypesInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken);

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
