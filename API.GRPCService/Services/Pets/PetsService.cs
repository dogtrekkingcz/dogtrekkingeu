using DogsOnTrail.Interfaces.Actions.Entities.Pets;
using DogsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;
using PetsOnTrail.Interfaces.Actions.Services;

namespace API.GRPCService.Services.Pets;

internal class PetsService : Protos.Pets.Pets.PetsBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IPetsService _PetsService;

    public PetsService(ILogger<PetsService> logger, IMapper mapper, IPetsService PetsService)
    {
        _logger = logger;
        _mapper = mapper;
        _PetsService = PetsService;
    }

    public async override Task<Protos.Pets.CreatePet.CreatePetResponse> createPet(Protos.Pets.CreatePet.CreatePetRequest request, ServerCallContext context)
    {
        var createPetRequest = _mapper.Map<CreatePetRequest>(request);
        
        var newPet = await _PetsService.CreatePetAsync(createPetRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Pets.CreatePet.CreatePetResponse>(newPet);

        return response;
    }

    public async override Task<Protos.Pets.GetAllPets.GetAllPetsResponse> getAllPets(Protos.Pets.GetAllPets.GetAllPetsRequest request, ServerCallContext context)
    {
        var getAllPetsRequest = _mapper.Map<GetAllPetsRequest>(request);

        var Pets = await _PetsService.GetAllPetsAsync(getAllPetsRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Pets.GetAllPets.GetAllPetsResponse>(Pets);

        return response;
    }

    public async override Task<Protos.Pets.DeletePet.DeletePetResponse> deletePet(Protos.Pets.DeletePet.DeletePetRequest request, ServerCallContext context)
    {
        var deletePetRequest = _mapper.Map<DeletePetRequest>(request);

        await _PetsService.DeletePetAsync(deletePetRequest, context.CancellationToken);

        return new Protos.Pets.DeletePet.DeletePetResponse();
    }
    
    public async override Task<Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipResponse> getPetsFilteredByChip(Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipRequest request, ServerCallContext context)
    {
        var getPetsFilteredByChipRequest = _mapper.Map<GetPetsFilteredByChipRequest>(request);

        await _PetsService.GetPetsFilteredByChipAsync(getPetsFilteredByChipRequest, context.CancellationToken);

        return new Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipResponse();
    }
}