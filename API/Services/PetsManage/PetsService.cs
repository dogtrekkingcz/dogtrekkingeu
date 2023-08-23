using DogsOnTrail.Interfaces.Actions.Entities.Pets;
using DogsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Storage.Entities.Pets;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.PetsManage;

internal class PetsService : IPetsService
{
    private readonly IMapper _mapper;
    private readonly IPetsRepositoryService _petsRepositoryService;
    private readonly ICurrentUserIdService _currentUserIdService;
    
    public PetsService(IMapper mapper, IPetsRepositoryService petsRepositoryService, ICurrentUserIdService currentUserIdService)
    {
        _mapper = mapper;
        _petsRepositoryService = petsRepositoryService;
        _currentUserIdService = currentUserIdService;
    }
    
    public async Task<CreatePetResponse> CreatePetAsync(CreatePetRequest request, CancellationToken cancellationToken)
    {
        var addPetRequest = _mapper.Map<CreatePetInternalStorageRequest>(request)
            with
            {
                Id = Guid.NewGuid(),
                UserId = _currentUserIdService.GetUserId()
            };
        
        var result = await _petsRepositoryService.AddPetAsync(addPetRequest, cancellationToken);

        var response = _mapper.Map<CreatePetResponse>(result);

        return response;
    }

    public async Task<GetAllPetsResponse> GetAllPetsAsync(GetAllPetsRequest request, CancellationToken cancellationToken)
    {
        var result = await _petsRepositoryService.GetAllAsync(cancellationToken);

        var response = new GetAllPetsResponse();
        foreach (var Pet in result.Pets)
        {
            response.Pets.Add(_mapper.Map<GetAllPetsResponse.PetDto>(Pet));
        }
        
        return response;
    }

    public async Task<GetPetsFilteredByChipResponse> GetPetsFilteredByChipAsync(GetPetsFilteredByChipRequest request, CancellationToken cancellationToken)
    {
        var result = await _petsRepositoryService.GetPetsFilteredByChipAsync(new GetPetsFilteredByChipInternalStorageRequest { Chip = request.Chip }, cancellationToken);

        if ((result?.Pets?.Count ?? 0) > 0)
            return _mapper.Map<GetPetsFilteredByChipResponse>(result.Pets.First());

        return null;
    }

    public async Task<DeletePetResponse> DeletePetAsync(DeletePetRequest request, CancellationToken cancellationToken)
    {
        await _petsRepositoryService.DeletePetAsync(new DeletePetInternalStorageRequest { Id = request.Id }, cancellationToken);

        return new DeletePetResponse();
    }
}