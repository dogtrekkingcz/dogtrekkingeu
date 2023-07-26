using DogsOnTrail.Interfaces.Actions.Entities.Dogs;
using DogsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Storage.Entities.Dogs;
using Storage.Interfaces;
using GetAllDogsResponse = DogsOnTrail.Interfaces.Actions.Entities.Dogs.GetAllDogsResponse;

namespace DogsOnTrail.Actions.Services.DogsManage;

internal class DogsService : IDogsService
{
    private readonly IMapper _mapper;
    private readonly IDogsRepositoryService _dogsRepositoryService;
    
    public DogsService(IMapper mapper, IDogsRepositoryService dogsRepositoryService)
    {
        _mapper = mapper;
        _dogsRepositoryService = dogsRepositoryService;
    }
    
    public async Task<CreateDogResponse> CreateDogAsync(CreateDogRequest request, CancellationToken cancellationToken)
    {
        var addDogRequest = _mapper.Map<CreateDogInternalStorageRequest>(request)
            with
            {
                Id = Guid.NewGuid()
            };
        
        var result = await _dogsRepositoryService.AddDogAsync(addDogRequest, cancellationToken);

        var response = _mapper.Map<CreateDogResponse>(result);

        return response;
    }

    public async Task<GetAllDogsResponse> GetAllDogsAsync(GetAllDogsRequest request, CancellationToken cancellationToken)
    {
        var result = await _dogsRepositoryService.GetAllAsync(cancellationToken);

        var response = new GetAllDogsResponse();
        foreach (var dog in result.Dogs)
        {
            response.Dogs.Add(_mapper.Map<GetAllDogsResponse.DogDto>(dog));
        }
        
        return response;
    }

    public async Task<GetDogsFilteredByChipResponse> GetDogsFilteredByChipAsync(GetDogsFilteredByChipRequest request, CancellationToken cancellationToken)
    {
        var result = await _dogsRepositoryService.GetDogsFilteredByChipAsync(new GetDogsFilteredByChipInternalStorageRequest { Chip = request.Chip }, cancellationToken);

        if ((result?.Dogs?.Count ?? 0) > 0)
            return _mapper.Map<GetDogsFilteredByChipResponse>(result.Dogs.First());

        return null;
    }

    public async Task<DeleteDogResponse> DeleteDogAsync(DeleteDogRequest request, CancellationToken cancellationToken)
    {
        await _dogsRepositoryService.DeleteDogAsync(new DeleteDogInternalStorageRequest { Id = request.Id }, cancellationToken);

        return new DeleteDogResponse();
    }
}