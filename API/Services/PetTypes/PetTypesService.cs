using PetsOnTrail.Interfaces.Actions.Entities.PetTypes;
using PetsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Storage.Interfaces;

namespace PetsOnTrail.Actions.Services.PetsManage;

internal class PetTypesService : IPetTypesService
{
    private readonly IMapper _mapper;
    private readonly IPetTypeRepositoryService _petTypesRepositoryService;
    
    public PetTypesService(IMapper mapper, IPetTypeRepositoryService petTypesRepositoryService)
    {
        _mapper = mapper;
        _petTypesRepositoryService = petTypesRepositoryService;
    }

    public async Task<GetPetTypesResponse> GetPetTypesAsync(CancellationToken cancellationToken)
    {
        var result = await _petTypesRepositoryService.GetAllAsync(cancellationToken);

        var response = new GetPetTypesResponse();
        foreach (var petType in result.PetTypes)
        {
            response.PetTypes.Add(_mapper.Map<GetPetTypesResponse.PetTypeDto>(petType));
        }

        return response;

    }
}