using MapsterMapper;
using MongoDB.Bson;
using Storage.Entities.Dogs;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Dogs
{
    internal class DogsRepositoryService : IDogsRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IStorageService<DogRecord> _dogStorageService;

        public DogsRepositoryService(IMapper mapper, IStorageService<DogRecord> dogsStorageService)
        {
            _mapper = mapper;
            _dogStorageService = dogsStorageService;
        }

        public async Task<AddDogInternalStorageResponse> AddDogAsync(CreateDogInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(AddDogAsync)}: '{request?.Dump()}'");
            
            var addRequest = _mapper.Map<DogRecord>(request);
            
            var addedActionRecord = await _dogStorageService.AddAsync(addRequest, cancellationToken);

            var response = new AddDogInternalStorageResponse
            {
                Id = addedActionRecord.Id
            };

            return response;
        }

        public async Task<UpdateDogResponse> UpdateDogAsync(UpdateDogInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(UpdateDogAsync)}: '{request?.Dump()}'");
            
            var updateRequest = _mapper.Map<DogRecord>(request);
            
            Console.WriteLine(updateRequest);
            
            var result = await _dogStorageService.UpdateAsync(updateRequest, cancellationToken);

            return new UpdateDogResponse
            {
                
            };
        }

        public async Task DeleteDogAsync(DeleteDogInternalStorageRequest request, CancellationToken cancellationToken)
        {
            await _dogStorageService.DeleteAsync(request.Id, cancellationToken);
        }

        public async Task<GetDogsFilteredByChipInternalStorageResponse> GetDogsFilteredByChipAsync(GetDogsFilteredByChipInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var filter = new List<(string key, string likeValue)> { ("Chip", request.Chip) };
            var result = await _dogStorageService.GetByFilterBeLikeAsync(filter, cancellationToken);

            if (result == null)
                return null;
            
            var response = _mapper.Map<GetDogsFilteredByChipInternalStorageResponse>(result);

            return response;
        }

        public async Task<GetAllDogsInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _dogStorageService.GetAllAsync(cancellationToken);


            var response = new GetAllDogsInternalStorageResponse
            {
                Dogs = result
                    .Select(dog => _mapper.Map<GetAllDogsInternalStorageResponse.DogDto>(dog))
                    .ToList()
            };

            return response;
        }
    }
}
