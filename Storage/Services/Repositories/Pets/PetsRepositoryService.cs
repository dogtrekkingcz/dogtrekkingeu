using MapsterMapper;
using MongoDB.Bson;
using Storage.Entities.Pets;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Pets
{
    internal class PetsRepositoryService : IPetsRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IStorageService<PetRecord> _petStorageService;

        public PetsRepositoryService(IMapper mapper, IStorageService<PetRecord> petsStorageService)
        {
            _mapper = mapper;
            _petStorageService = petsStorageService;
        }

        public async Task<AddPetInternalStorageResponse> AddPetAsync(CreatePetInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"PetsRepositoryService::{nameof(AddPetAsync)}: '{request?.Dump()}'");
            
            var addRequest = _mapper.Map<PetRecord>(request);
            
            var addedActionRecord = await _petStorageService.AddOrUpdateAsync(addRequest, cancellationToken);

            var response = new AddPetInternalStorageResponse
            {
                Id = addedActionRecord.Id
            };

            return response;
        }

        public async Task<UpdatePetInternalStorageResponse> UpdatePetAsync(UpdatePetInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(UpdatePetAsync)}: '{request?.Dump()}'");
            
            var updateRequest = _mapper.Map<PetRecord>(request);
            
            Console.WriteLine(updateRequest);
            
            var result = await _petStorageService.AddOrUpdateAsync(updateRequest, cancellationToken);

            return new UpdatePetInternalStorageResponse
            {
                Id = result.Id
            };
        }

        public async Task<GetPetInternalStorageResponse> GetPetAsync(GetPetInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var pet = await _petStorageService.GetAsync(request.Id, cancellationToken);

            return _mapper.Map<GetPetInternalStorageResponse>(pet);
        }

        public async Task DeletePetAsync(DeletePetInternalStorageRequest request, CancellationToken cancellationToken)
        {
            await _petStorageService.DeleteAsync(request.Id, cancellationToken);
        }

        public async Task<GetPetsFilteredByChipInternalStorageResponse> GetPetsFilteredByChipAsync(GetPetsFilteredByChipInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var filter = new List<(string key, string likeValue)> { ("Chip", request.Chip) };
            var result = await _petStorageService.GetByFilterBeLikeAsync(filter, cancellationToken);

            if (result == null)
                return null;
            
            var response = _mapper.Map<GetPetsFilteredByChipInternalStorageResponse>(result);

            return response;
        }

        public async Task<GetAllPetsInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _petStorageService.GetAllAsync(cancellationToken);

            var response = new GetAllPetsInternalStorageResponse
            {
                Pets = result
                    .Select(Pet => _mapper.Map<GetAllPetsInternalStorageResponse.PetDto>(Pet))
                    .ToList()
            };

            return response;
        }
    }
}
