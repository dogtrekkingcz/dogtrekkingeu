using API.GRPCService.Extensions;
using PetsOnTrail.Interfaces.Actions.Entities.Pets;
using PetsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;
using PetsOnTrail.Interfaces.Actions.Entities.JwtToken;
using Google.Protobuf.WellKnownTypes;

namespace API.GRPCService.Services.Pets;

internal class PetsService : Protos.Pets.Pets.PetsBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IPetsService _petsService;
    private readonly IPetTypesService _petTypesService;
    private readonly IJwtTokenService _jwtTokenService;

    public PetsService(ILogger<PetsService> logger, IMapper mapper, IPetsService petsService, IPetTypesService petTypesService, IJwtTokenService jwtTokenService)
    {
        _logger = logger;
        _mapper = mapper;
        _petsService = petsService;
        _petTypesService = petTypesService;
        _jwtTokenService = jwtTokenService;
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

    public async override Task<Protos.Pets.UpdatePet.UpdatePetResponse> updatePet(Protos.Pets.UpdatePet.UpdatePetRequest request, ServerCallContext context)
    {
        var updateRequest = _mapper.Map<UpdatePetRequest>(request);

        var response = await _petsService.UpdatePetAsync(updateRequest, context.CancellationToken);

        return _mapper.Map<Protos.Pets.UpdatePet.UpdatePetResponse>(response);
    }

    public async override Task<Protos.Pets.GetMyPets.GetMyPetsResponse> getMyPets(Protos.Pets.GetMyPets.GetMyPetsRequest request, ServerCallContext context)
    {
        var apiRequest = _mapper.Map<GetMyPetsRequest>(request) with
        {
            UserId = _jwtTokenService.GetUserId()
        };

        var response = await _petsService.GetMyPetsAsync(apiRequest, context.CancellationToken);

        return _mapper.Map<Protos.Pets.GetMyPets.GetMyPetsResponse>(response);
    }

    public async override Task<Protos.Pets.AddMyPet.AddMyPetResponse> addMyPet(Protos.Pets.AddMyPet.AddMyPetRequest request, ServerCallContext context)
    {
        var apiRequest = _mapper.Map<AddMyPetRequest>(request) with
        {
            Id = request.Id?.ToGuid() ?? Guid.NewGuid(),
            UserId = _jwtTokenService.GetUserId(),
            PetType = request.PetType?.ToGuid() ?? Guid.Empty
        };

        var response = await _petsService.AddMyPetAsync(apiRequest, context.CancellationToken);

        return _mapper.Map<Protos.Pets.AddMyPet.AddMyPetResponse>(response);
    }

    public async override Task<Protos.Pets.GetPetTypes.GetPetTypesResponse> getPetTypes(Empty request, ServerCallContext context)
    {
        var response = await _petTypesService.GetPetTypesAsync(context.CancellationToken);

        return _mapper.Map<Protos.Pets.GetPetTypes.GetPetTypesResponse>(response);
    }
}