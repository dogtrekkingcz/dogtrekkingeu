using DogtrekkingCz.Interfaces.Actions.Entities.Dogs;
using DogtrekkingCz.Interfaces.Actions.Entities.Entries;
using Mapster;
using Storage.Entities.Dogs;

namespace DogtrekkingCz.Actions.Services.DogsManage;

internal static class DogsServiceMapping
{
    public static TypeAdapterConfig AddDogsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreateDogRequest, AddDogInternalStorageRequest>();
        typeAdapterConfig.NewConfig<AddDogInternalStorageResponse, CreateDogResponse>();
        typeAdapterConfig.NewConfig<GetAllDogsInternalStorageResponse, GetAllDogsResponse>();
        
        return typeAdapterConfig;
    }
}