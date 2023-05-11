using SharedCode.Entities;
using MapsterMapper;
using MongoDB.Bson;
using Storage.Entities.Dogs;
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

        public async Task<AddDogInternalStorageResponse> AddDogAsync(AddDogInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var addRequest = _mapper.Map<DogRecord>(request);
            
            var addedActionRecord = await _dogStorageService.AddAsync(addRequest, cancellationToken);

            var response = new AddDogInternalStorageResponse
            {
                Id = addedActionRecord.Id
            };

            return response;
        }

        public async Task<UpdateDogResponse> UpdateDogAsync(UpdateDogRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.ToJson());
            
            var updateRequest = _mapper.Map<DogRecord>(request);
            
            Console.WriteLine(updateRequest);
            
            var result = await _dogStorageService.UpdateAsync(updateRequest, cancellationToken);

            return new UpdateDogResponse
            {
                
            };
        }

        public async Task DeleteDogAsync(DeleteDogInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var deleteRequest = _mapper.Map<DogRecord>(request);

            await _dogStorageService.DeleteAsync(deleteRequest, cancellationToken);
        }

        public async Task<GetDogsFilteredByChipInternalStorageResponse> GetDogsFilteredByChipAsync(GetDogsFilteredByChipInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var filter = new List<(string key, string likeValue)> { ("Chip", request.Chip) };
            var result = await _dogStorageService.GetByFilterBeLikeAsync(filter, cancellationToken);

            if (result == null)
                return null;
            
            var response = _mapper.Map<GetDogsFilteredByChipInternalStorageResponse>(result.FirstOrDefault());

            return response;
        }

        public async Task<GetAllDogsInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _dogStorageService.GetAllAsync(cancellationToken);

            var response = new GetAllDogsInternalStorageResponse();

            foreach (var dog in result)
            {
                response.Dogs.Add(_mapper.Map<DogDto>(dog));
            }

            return response;
        }
    }
}
