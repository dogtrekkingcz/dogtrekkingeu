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
        private readonly IStorageService<PetRecord> _PetStorageService;

        public PetsRepositoryService(IMapper mapper, IStorageService<PetRecord> PetsStorageService)
        {
            _mapper = mapper;
            _PetStorageService = PetsStorageService;
        }

        public async Task<AddPetInternalStorageResponse> AddPetAsync(CreatePetInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"PetsRepositoryService::{nameof(AddPetAsync)}: '{request?.Dump()}'");
            
            var addRequest = _mapper.Map<PetRecord>(request);
            
            var addedActionRecord = await _PetStorageService.AddAsync(addRequest, cancellationToken);

            var response = new AddPetInternalStorageResponse
            {
                Id = addedActionRecord.Id
            };

            return response;
        }

        public async Task<UpdatePetResponse> UpdatePetAsync(UpdatePetInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(UpdatePetAsync)}: '{request?.Dump()}'");
            
            var updateRequest = _mapper.Map<PetRecord>(request);
            
            Console.WriteLine(updateRequest);
            
            var result = await _PetStorageService.UpdateAsync(updateRequest, cancellationToken);

            return new UpdatePetResponse
            {
                
            };
        }

        public async Task DeletePetAsync(DeletePetInternalStorageRequest request, CancellationToken cancellationToken)
        {
            await _PetStorageService.DeleteAsync(request.Id, cancellationToken);
        }

        public async Task<GetPetsFilteredByChipInternalStorageResponse> GetPetsFilteredByChipAsync(GetPetsFilteredByChipInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var filter = new List<(string key, string likeValue)> { ("Chip", request.Chip) };
            var result = await _PetStorageService.GetByFilterBeLikeAsync(filter, cancellationToken);

            if (result == null)
                return null;
            
            var response = _mapper.Map<GetPetsFilteredByChipInternalStorageResponse>(result);

            return response;
        }

        public async Task<GetAllPetsInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _PetStorageService.GetAllAsync(cancellationToken);

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
