using DogtrekkingCz.Storage.Entities.UserProfiles;
using DogtrekkingCz.Storage.Models;
using MapsterMapper;
using MongoDB.Bson;
using Storage.Entities.Dogs;
using Storage.Interfaces;
using Storage.Interfaces.Services;
using Storage.Models;

namespace Storage.Services.Repositories
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

        public async Task<AddDogResponse> AddDogAsync(AddDogRequest request)
        {
            var addRequest = _mapper.Map<DogRecord>(request);
            
            var addedActionRecord = await _dogStorageService.AddAsync(addRequest);

            var response = new AddDogResponse
            {
                
            };

            return response;
        }

        public async Task<UpdateDogResponse> UpdateDogAsync(UpdateDogRequest request)
        {
            Console.WriteLine(request.ToJson());
            
            var updateRequest = _mapper.Map<DogRecord>(request);
            
            Console.WriteLine(updateRequest);
            
            var result = await _dogStorageService.UpdateAsync(updateRequest);

            return new UpdateDogResponse
            {
                
            };
        }

        public async Task DeleteDogAsync(DeleteDogRequest request)
        {
            var deleteRequest = _mapper.Map<DogRecord>(request);

            await _dogStorageService.DeleteAsync(deleteRequest);
        }

        public async Task<GetDogResponse> GetDogAsync(GetDogRequest request)
        {
            var result = await _dogStorageService.GetByFilterAsync("Chip", request.Chip);

            if (result == null)
                return null;
            
            var response = _mapper.Map<GetDogResponse>(result);

            return response;
        }
    }
}
