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

    public async override Task<Protos.Dogs.CreateDogResponse> createDog(Protos.Dogs.CreateDogRequest request, ServerCallContext context)
    {
        var createDogRequest = _mapper.Map<CreateDogRequest>(request.Dog);
        
        var newDog = await _dogsService.CreateDogAsync(createDogRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Dogs.CreateDogResponse>(newDog);

        return response;
    }

    public async override Task<Protos.Dogs.GetAllDogsResponse> getAllDogs(Protos.Dogs.GetAllDogsRequest request, ServerCallContext context)
    {
        var getAllDogsRequest = _mapper.Map<GetAllDogsRequest>(request);

        var dogs = await _dogsService.GetAllDogsAsync(getAllDogsRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Dogs.GetAllDogsResponse>(dogs);

        return response;
    }

    public async override Task<Protos.Dogs.DeleteDogResponse> deleteDog(Protos.Dogs.DeleteDogRequest request, ServerCallContext context)
    {
        var deleteDogRequest = _mapper.Map<DeleteDogRequest>(request);

        await _dogsService.DeleteDogAsync(deleteDogRequest, context.CancellationToken);

        return new Protos.Dogs.DeleteDogResponse();
    }
}