using DogsOnTrail.Interfaces.Actions.Entities.Dogs;
using DogsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;

namespace API.GRPCService.Services.Dogs;

internal class DogsService : Protos.Dogs.Dogs.DogsBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IDogsService _dogsService;

    public DogsService(ILogger<DogsService> logger, IMapper mapper, IDogsService dogsService)
    {
        _logger = logger;
        _mapper = mapper;
        _dogsService = dogsService;
    }

    public async override Task<Protos.Dogs.CreateDog.CreateDogResponse> createDog(Protos.Dogs.CreateDog.CreateDogRequest request, ServerCallContext context)
    {
        var createDogRequest = _mapper.Map<CreateDogRequest>(request);
        
        var newDog = await _dogsService.CreateDogAsync(createDogRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Dogs.CreateDog.CreateDogResponse>(newDog);

        return response;
    }

    public async override Task<Protos.Dogs.GetAllDogs.GetAllDogsResponse> getAllDogs(Protos.Dogs.GetAllDogs.GetAllDogsRequest request, ServerCallContext context)
    {
        var getAllDogsRequest = _mapper.Map<GetAllDogsRequest>(request);

        var dogs = await _dogsService.GetAllDogsAsync(getAllDogsRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Dogs.GetAllDogs.GetAllDogsResponse>(dogs);

        return response;
    }

    public async override Task<Protos.Dogs.DeleteDog.DeleteDogResponse> deleteDog(Protos.Dogs.DeleteDog.DeleteDogRequest request, ServerCallContext context)
    {
        var deleteDogRequest = _mapper.Map<DeleteDogRequest>(request);

        await _dogsService.DeleteDogAsync(deleteDogRequest, context.CancellationToken);

        return new Protos.Dogs.DeleteDog.DeleteDogResponse();
    }
    
    public async override Task<Protos.Dogs.GetDogsFilteredByChip.GetDogsFilteredByChipResponse> getDogsFilteredByChip(Protos.Dogs.GetDogsFilteredByChip.GetDogsFilteredByChipRequest request, ServerCallContext context)
    {
        var getDogsFilteredByChipRequest = _mapper.Map<GetDogsFilteredByChipRequest>(request);

        await _dogsService.GetDogsFilteredByChipAsync(getDogsFilteredByChipRequest, context.CancellationToken);

        return new Protos.Dogs.GetDogsFilteredByChip.GetDogsFilteredByChipResponse();
    }
}