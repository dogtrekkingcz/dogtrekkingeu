using PetsOnTrail.Interfaces.Actions.Entities.PetTypes;

namespace PetsOnTrail.Interfaces.Actions.Services;

public interface IPetTypesService
{
    Task<GetPetTypesResponse> GetPetTypesAsync(CancellationToken cancellationToken);
}