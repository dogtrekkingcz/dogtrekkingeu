using PetsOnTrail.Interfaces.Actions.Entities.Pets;
using Mapster;
using Storage.Entities.Pets;
using Storage.Entities.UserProfiles;

namespace PetsOnTrail.Actions.Services.PetsManage;

internal static class PetsServiceMapping
{
    public static TypeAdapterConfig AddPetsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreatePetRequest, CreatePetInternalStorageRequest>()
            .Ignore(d => d.Id)
            .Ignore(d => d.UserId);
        typeAdapterConfig.NewConfig<CreatePetRequest.VaccinationDto, CreatePetInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<AddPetInternalStorageResponse, CreatePetResponse>();
        
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse, GetAllPetsResponse>();
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse.PetDto, GetAllPetsResponse.PetDto>();
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse.VaccinationDto, GetAllPetsResponse.VaccinationDto>();
        
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse, GetPetsFilteredByChipResponse>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.PetDto, GetPetsFilteredByChipResponse.PetDto>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.VaccinationDto, GetPetsFilteredByChipResponse.VaccinationDto>();

        typeAdapterConfig.NewConfig<CreatePetRequest, UpdateUserProfileInternalStorageRequest.PetDto>()
            .Ignore(d => d.Id);
        typeAdapterConfig.NewConfig<CreatePetRequest.VaccinationDto, UpdateUserProfileInternalStorageRequest.VaccinationDto>();

        typeAdapterConfig.NewConfig<UpdatePetRequest, UpdateUserProfileInternalStorageRequest.PetDto>();
        typeAdapterConfig.NewConfig<UpdatePetRequest.VaccinationDto, UpdateUserProfileInternalStorageRequest.VaccinationDto>();
        
        typeAdapterConfig.NewConfig<GetPetInternalStorageResponse, GetPetResponse>();
        typeAdapterConfig.NewConfig<GetPetInternalStorageResponse.VaccinationDto, GetPetResponse.VaccinationDto>();
        
        typeAdapterConfig.NewConfig<UpdatePetRequest, UpdatePetInternalStorageRequest>();
        typeAdapterConfig.NewConfig<UpdatePetRequest.VaccinationDto, UpdatePetInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<UpdatePetInternalStorageResponse, UpdatePetResponse>();

        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.PetDto, GetMyPetsResponse.MyPetDto>();

        typeAdapterConfig.NewConfig<AddMyPetRequest, UpdateUserProfileInternalStorageRequest.PetDto>();
        typeAdapterConfig.NewConfig<AddMyPetRequest.VaccinationDto, UpdateUserProfileInternalStorageRequest.VaccinationDto>();

        return typeAdapterConfig;
    }
}