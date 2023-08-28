using API.GRPCService.Extensions;
using DogsOnTrail.Interfaces.Actions.Entities.Pets;
using DogsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;

namespace API.GRPCService.Services.Pets;

internal class PetsService : Protos.Pets.Pets.PetsBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IPetsService _petsService;

    public PetsService(ILogger<PetsService> logger, IMapper mapper, IPetsService petsService)
    {
        _logger = logger;
        _mapper = mapper;
        _petsService = petsService;
    }

    public async override Task<Protos.Pets.CreatePet.CreatePetResponse> createPet(Protos.Pets.CreatePet.CreatePetRequest request, ServerCallContext context)
    {
        var createPetRequest = _mapper.Map<CreatePetRequest>(request);
        
        var newPet = await _petsService.CreatePetAsync(createPetRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Pets.CreatePet.CreatePetResponse>(newPet);

        return response;
    }

    public async override Task<Protos.Pets.GetAllPets.GetAllPetsResponse> getAllPets(Protos.Pets.GetAllPets.GetAllPetsRequest request, ServerCallContext context)
    {
        var getAllPetsRequest = _mapper.Map<GetAllPetsRequest>(request);

        var Pets = await _petsService.GetAllPetsAsync(getAllPetsRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Pets.GetAllPets.GetAllPetsResponse>(Pets);

        return response;
    }

    public async override Task<Protos.Pets.DeletePet.DeletePetResponse> deletePet(Protos.Pets.DeletePet.DeletePetRequest request, ServerCallContext context)
    {
        var deletePetRequest = _mapper.Map<DeletePetRequest>(request);

        await _petsService.DeletePetAsync(deletePetRequest, context.CancellationToken);

        return new Protos.Pets.DeletePet.DeletePetResponse();
    }
    
    public async override Task<Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipResponse> getPetsFilteredByChip(Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipRequest request, ServerCallContext context)
    {
        var getPetsFilteredByChipRequest = _mapper.Map<GetPetsFilteredByChipRequest>(request);

        await _petsService.GetPetsFilteredByChipAsync(getPetsFilteredByChipRequest, context.CancellationToken);

        return new Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipResponse();
    }

    public async override Task<Protos.Pets.GetPet.GetPetResponse> getPet(Protos.Pets.GetPet.GetPetRequest request, ServerCallContext context)
    {
        var pet = await _petsService.GetPetAsync(new GetPetRequest { Id = request.Id.ToGuid() }, context.CancellationToken);

        return _mapper.Map<Protos.Pets.GetPet.GetPetResponse>(pet);
    }
}