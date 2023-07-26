using DogsOnTrail.Interfaces.Actions.Entities.Dogs;
using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;
using Storage.Entities.Dogs;

namespace DogsOnTrail.Actions.Services.DogsManage;

internal static class DogsServiceMapping
{
    public static TypeAdapterConfig AddDogsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreateDogRequest, CreateDogInternalStorageRequest>()
            .Ignore(d => d.Id);
        typeAdapterConfig.NewConfig<CreateDogRequest.VaccinationDto, CreateDogInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreateDogRequest.VaccinationType, CreateDogInternalStorageRequest.VaccinationType>();
        
        typeAdapterConfig.NewConfig<AddDogInternalStorageResponse, CreateDogResponse>();
        
        typeAdapterConfig.NewConfig<GetAllDogsInternalStorageResponse, GetAllDogsResponse>();
        typeAdapterConfig.NewConfig<GetAllDogsInternalStorageResponse.DogDto, GetAllDogsResponse.DogDto>();
        typeAdapterConfig.NewConfig<GetAllDogsInternalStorageResponse.VaccinationType, GetAllDogsResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetAllDogsInternalStorageResponse.VaccinationDto, GetAllDogsResponse.VaccinationDto>();
        
        return typeAdapterConfig;
    }
}