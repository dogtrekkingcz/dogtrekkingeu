using DogsOnTrail.Interfaces.Actions.Entities.Pets;

namespace DogsOnTrail.Interfaces.Actions.Services;

public interface IPetsService
{
    Task<CreatePetResponse> CreatePetAsync(CreatePetRequest request, CancellationToken cancellationToken);

    Task<GetAllPetsResponse> GetAllPetsAsync(GetAllPetsRequest request, CancellationToken cancellationToken);

    Task<DeletePetResponse> DeletePetAsync(DeletePetRequest request, CancellationToken cancellationToken);

    Task<GetPetsFilteredByChipResponse> GetPetsFilteredByChipAsync(GetPetsFilteredByChipRequest request, CancellationToken cancellationToken);

    Task<GetPetResponse> GetPetAsync(GetPetRequest request, CancellationToken cancellationToken);

    Task<UpdatePetResponse> UpdatePetAsync(UpdatePetRequest request, CancellationToken cancellationToken);
}